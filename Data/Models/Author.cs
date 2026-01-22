using System;
namespace Models;

public class Author
{
    public int Id { get; set; } 
   
    public string UserName { get; set; } = null!;
   
    public string Email { get; set; } = null!;
   
    public string Bio { get; set; } = "";
    
    public virtual List<Post> Posts { get; set; }
}
