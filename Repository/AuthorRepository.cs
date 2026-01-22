using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace blogpractice.Repository;

public class AuthorRepository :  Repository<Author>, IAuthorRepository
{
    public AuthorRepository(BloggingContext context): base(context) { }
    
    public async Task<IEnumerable<Author>> GetAuthorsAsync(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        return await _dbSet
            // .OrderBy(a => a.UserName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(ct);
    }
    
    public IQueryable<Author> GetAuthors(CancellationToken ct = default)
    {
        return _dbSet.AsNoTracking();
    }
}