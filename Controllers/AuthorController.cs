using blogpractice.Dtos;
using blogpractice.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace blogpractice.Controllers.cs;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        this._authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> ListAuthors([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken ct = default)
    {
        var authors = await _authorService.ListAuthorsAsync(page, pageSize, ct);
        return Ok(authors);
    }
}
