using System;

namespace Models;

public class Comment
{
    public int Id { get; set; }
    public string Body { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int PostId { get; set; }

    public string AuthorName { get; set; } = "Anonymous";
    public virtual Post? Post { get; set; }
}