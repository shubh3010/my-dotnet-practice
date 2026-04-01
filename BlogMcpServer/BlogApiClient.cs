using System.Net.Http.Json;
using System.Web;

namespace BlogMcpServer;

// Response shapes mirroring the BlogPractice DTOs
public record PostSummary(int Id, int AuthorId, string Title, DateTime PublishedAt);
public record PostDetail(int Id, int AuthorId, string Title, string Content, DateTime PublishedAt);
public record AuthorDto(int Id, string UserName, string Email, List<PostSummary> Posts);
public record TagDto(int Id, string Name);

public class BlogApiClient(HttpClient http)
{
    public async Task<List<PostSummary>> ListPostsAsync(
        int page = 1, int pageSize = 10,
        int? authorId = null, string? tag = null,
        DateTime? from = null, DateTime? to = null,
        CancellationToken ct = default)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["page"] = page.ToString();
        query["pageSize"] = pageSize.ToString();
        if (authorId.HasValue) query["authorId"] = authorId.Value.ToString();
        if (tag is not null)   query["tag"] = tag;
        if (from.HasValue)     query["from"] = from.Value.ToString("o");
        if (to.HasValue)       query["to"]   = to.Value.ToString("o");

        var response = await http.GetAsync($"/api/post?{query}", ct);
        await EnsureSuccessAsync(response, "posts");
        return await response.Content.ReadFromJsonAsync<List<PostSummary>>(ct) ?? [];
    }

    public async Task<PostDetail?> GetPostAsync(int id, CancellationToken ct = default)
    {
        var response = await http.GetAsync($"/api/post/{id}", ct);
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
        await EnsureSuccessAsync(response, $"post {id}");
        return await response.Content.ReadFromJsonAsync<PostDetail>(ct);
    }

    public async Task<List<AuthorDto>> ListAuthorsAsync(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var response = await http.GetAsync($"/api/author?page={page}&pageSize={pageSize}", ct);
        await EnsureSuccessAsync(response, "authors");
        return await response.Content.ReadFromJsonAsync<List<AuthorDto>>(ct) ?? [];
    }

    public async Task<List<TagDto>> ListTagsAsync(CancellationToken ct = default)
    {
        var response = await http.GetAsync("/api/tags", ct);
        await EnsureSuccessAsync(response, "tags");
        return await response.Content.ReadFromJsonAsync<List<TagDto>>(ct) ?? [];
    }

    public async Task<TagDto?> GetTagAsync(int id, CancellationToken ct = default)
    {
        var response = await http.GetAsync($"/api/tags/{id}", ct);
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
        await EnsureSuccessAsync(response, $"tag {id}");
        return await response.Content.ReadFromJsonAsync<TagDto>(ct);
    }

    private static async Task EnsureSuccessAsync(HttpResponseMessage response, string resource)
    {
        if (response.IsSuccessStatusCode) return;
        var body = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException(
            $"Blog API returned {(int)response.StatusCode} for {resource}: {body}",
            inner: null,
            statusCode: response.StatusCode);
    }
}
