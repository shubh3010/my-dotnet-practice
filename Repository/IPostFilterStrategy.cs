using Models;

public interface IPostFilterStrategy
{
    IQueryable<Post> Apply(IQueryable<Post> posts);
}

public class FilterByAuthor: IPostFilterStrategy
{
    public int authorId;
    public FilterByAuthor(int authorId) => this.authorId = authorId;

    public IQueryable<Post> Apply(IQueryable<Post> posts)
    {
        return posts.Where(p => p.AuthorId == authorId);
    }
}

public class FilterByDateRange: IPostFilterStrategy
{
    public DateTime startDate;
    public DateTime endDate;
    public FilterByDateRange(DateTime startDate, DateTime endDate)
    {
        this.startDate = startDate;
        this.endDate = endDate;
    }

    public IQueryable<Post> Apply(IQueryable<Post> posts)
    {
        return posts.Where(p => p.PublishedAt >= startDate && p.PublishedAt <= endDate);
    }
}

public class FilterByTag: IPostFilterStrategy
{
    public string _tagName;
    public FilterByTag(string tagName) => this._tagName = tagName;

    public IQueryable<Post> Apply(IQueryable<Post> posts)
    {
        return posts.Where(p => p.Tags.Any(t => t.Name == _tagName));
    }
}