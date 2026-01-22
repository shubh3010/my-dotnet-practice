namespace blogpractice.Dtos;

public class CreatePostDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    public int AuthorId { get; set; }
}