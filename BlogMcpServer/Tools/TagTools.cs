using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BlogMcpServer.Tools;

[McpServerToolType]
public class TagTools(BlogApiClient api)
{
    [McpServerTool(Name = "list_tags")]
    [Description("List all available tags.")]
    public async Task<string> ListTags(CancellationToken ct = default)
    {
        try
        {
            var tags = await api.ListTagsAsync(ct);
            if (tags.Count == 0) return "No tags found.";

            return string.Join("\n", tags.Select(t => $"[{t.Id}] {t.Name}"));
        }
        catch (HttpRequestException ex)
        {
            return $"Error fetching tags: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }

    [McpServerTool(Name = "get_tag")]
    [Description("Get details of a single tag by its ID.")]
    public async Task<string> GetTag(
        [Description("The ID of the tag to retrieve")] int id,
        CancellationToken ct = default)
    {
        try
        {
            var tag = await api.GetTagAsync(id, ct);
            if (tag is null) return $"Tag {id} not found.";

            return $"[{tag.Id}] {tag.Name}";
        }
        catch (HttpRequestException ex)
        {
            return $"Error fetching tag {id}: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }
}
