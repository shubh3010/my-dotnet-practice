using System;


namespace Models;

public class User
{
    public int Id { get; set; } 
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    // polymorphic method example
    public virtual string GetDisplayName() => UserName;
}
