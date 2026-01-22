using blogpractice.Dtos;
using blogpractice.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/posts/{postId}/tags")]
public class PostTagController : ControllerBase
{
    private readonly ITagService _tagService;

    public PostTagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost]
    public async Task<IActionResult> AssignTags(int postId, AssignTagsDto dto)
    {
        await _tagService.AssignTagsToPostAsync(postId, dto.TagIds);
        return NoContent();
    }

    // [HttpGet]
    // public async Task<IActionResult> GetTags(int postId)
    // {
    //     return Ok(await _tagService.GetTagsForPostAsync(postId));
    // }
    //
    // [HttpDelete("{tagId}")]
    // public async Task<IActionResult> RemoveTag(int postId, int tagId)
    // {
    //     await _tagService.RemoveTagFromPostAsync(postId, tagId);
    //     return NoContent();
    // }
    //
    // [HttpPut]
    // public async Task<IActionResult> ReplaceTags(int postId, AssignTagsDto dto)
    // {
    //     await _tagService.ReplaceTagsForPostAsync(postId, dto.TagIds);
    //     return NoContent();
    // }
}