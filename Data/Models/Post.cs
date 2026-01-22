using System;
using System.Collections.Generic;

namespace Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime PublishedAt { get; set; }
    
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; } = null!;
    
    public virtual List<Comment> Comments { get; set; } = new();
    
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}