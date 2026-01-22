namespace blogpractice.Dtos;

public class PostSummaryDto
{
    public int Id { get; set; }
    
    public int AuthorId { get; set; }
    public string Title { get; set; } = null!;
    public DateTime PublishedAt { get; set; }
}