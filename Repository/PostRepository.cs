using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(BloggingContext context) : base(context) {}

    public async Task<IEnumerable<Post>> GetPostsWithCommentsAsync(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        return await _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Tags)
            .Include(p => p.Author)
            .OrderByDescending(p => p.PublishedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Post?> GetPostWithCommentsAsync(int id, CancellationToken ct = default)
    {
        return await _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }
    
    public IQueryable<Post> GetPosts(CancellationToken ct = default)
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<IEnumerable<Post>> GetFilteredPostsAsync(int page, int pageSize, IEnumerable<IPostFilterStrategy> filters, CancellationToken ct = default)
    {
        IQueryable<Post> query = _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Tags)
            .Include(p => p.Author);

        foreach (var filter in filters)
        {
            query = filter.Apply(query);
        }

        return await query
            .OrderByDescending(p => p.PublishedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(ct);
    }
}