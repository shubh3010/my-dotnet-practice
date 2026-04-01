using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BlogMcpServer.Tools;

[McpServerToolType]
public class AuthorTools(BlogApiClient api)
{
    [McpServerTool(Name = "list_authors")]
    [Description("List all authors with pagination. Returns each author's id, username, email, and their post summaries.")]
    public async Task<string> ListAuthors(
        [Description("Page number (default 1)")] int page = 1,
        [Description("Number of authors per page (default 10)")] int pageSize = 10,
        CancellationToken ct = default)
    {
        try
        {
            var authors = await api.ListAuthorsAsync(page, pageSize, ct);
            if (authors.Count == 0) return "No authors found.";

            return string.Join("\n\n", authors.Select(a =>
            {
                var postList = a.Posts.Count == 0
                    ? "  (no posts)"
                    : string.Join("\n", a.Posts.Select(p => $"  [{p.Id}] \"{p.Title}\" ({p.PublishedAt:yyyy-MM-dd})"));
                return $"[{a.Id}] {a.UserName} <{a.Email}>\n{postList}";
            }));
        }
        catch (HttpRequestException ex)
        {
            return $"Error fetching authors: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }
}
