using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BlogMcpServer.Tools;

[McpServerToolType]
public class PostTools(BlogApiClient api)
{
    [McpServerTool(Name = "list_posts")]
    [Description("List blog posts with optional filters. Returns a summary list including id, title, authorId, and publishedAt.")]
    public async Task<string> ListPosts(
        [Description("Page number (default 1)")] int page = 1,
        [Description("Number of posts per page (default 10)")] int pageSize = 10,
        [Description("Filter by author ID")] int? authorId = null,
        [Description("Filter by tag name")] string? tag = null,
        [Description("Filter posts published after this date (ISO 8601)")] DateTime? from = null,
        [Description("Filter posts published before this date (ISO 8601)")] DateTime? to = null,
        CancellationToken ct = default)
    {
        try
        {
            var posts = await api.ListPostsAsync(page, pageSize, authorId, tag, from, to, ct);
            if (posts.Count == 0) return "No posts found.";

            return string.Join("\n", posts.Select(p =>
                $"[{p.Id}] \"{p.Title}\" — Author {p.AuthorId}, Published {p.PublishedAt:yyyy-MM-dd}"));
        }
        catch (HttpRequestException ex)
        {
            return $"Error fetching posts: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }

    [McpServerTool(Name = "get_post")]
    [Description("Get full details of a single blog post by its ID, including content.")]
    public async Task<string> GetPost(
        [Description("The ID of the post to retrieve")] int id,
        CancellationToken ct = default)
    {
        try
        {
            var post = await api.GetPostAsync(id, ct);
            if (post is null) return $"Post {id} not found.";

            return $"""
                    Id:          {post.Id}
                    Title:       {post.Title}
                    Author:      {post.AuthorId}
                    Published:   {post.PublishedAt:yyyy-MM-dd}
                    
                    {post.Content}
                    """;
        }
        catch (HttpRequestException ex)
        {
            return $"Error fetching post {id}: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }
}
