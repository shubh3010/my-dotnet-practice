using blogpractice.Dtos;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace blogpractice.Controllers.cs;

[ApiController]
[Route("api/[controller]")]
public class PostController: ControllerBase
{
    private readonly IPostService _postService;
    
    public PostController(IPostService postService)
    {
        this._postService = postService;
    }
    
    // GET /api/posts?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PostQueryParameters queryParameters, CancellationToken ct = default)
    {
        var posts = await _postService.ListPostsAsync(queryParameters.Page, queryParameters.PageSize, ct);
        return Ok(posts);
    }
    
    // GET /api/posts/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPost(int id, CancellationToken ct = default)
    {
        var post = await _postService.GetPostAsync(id, ct);
        if(post == null) return NotFound();
        return Ok(post);
    }
    
    // POST /api/posts
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostDto dto, CancellationToken ct = default)
    {
        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            AuthorId = dto.AuthorId
        };
        var created = await _postService.CreatePostAsync(post, ct);
        return CreatedAtAction(nameof(Get), new {id = created.Id}, created);
    }
    
    // PUT /api/posts/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDto dto, CancellationToken ct = default)
    {
        if(id != dto.Id) return BadRequest("Id mismatch.");
        var post = new Post
        {
            Id = dto.Id,
            Title = dto.Title,
            Content = dto.Content,
            PublishedAt = dto.PublishedAt
        };

        try
        {
            await _postService.UpdatePostAsync(post, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
    {
        try 
        {
            await _postService.DeletePostAsync(id, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("getComplex/{postId}")]
    public async Task<IActionResult> GetPostsByAuthor(int postId, CancellationToken ct = default)
    {
        var posts = await _postService.GetComplexPostAsync(postId, ct);
        return Ok(posts);
    }
}

