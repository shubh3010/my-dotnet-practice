namespace blogpractice.Dtos;

public class AuthorDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<PostSummaryDto> Posts { get; set; } = new();
}
