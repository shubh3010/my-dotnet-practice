using blogpractice.Dtos;
using blogpractice.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tags")]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTagDto dto)
    {
        var result = await _tagService.CreateTagAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _tagService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _tagService.GetAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTagDto dto)
    {
        await _tagService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _tagService.DeleteAsync(id);
        return NoContent();
    }
}