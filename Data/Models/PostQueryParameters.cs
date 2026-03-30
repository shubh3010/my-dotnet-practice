namespace Models;

public class PostQueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? AuthorId { get; set; }
    public string? Tag { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}