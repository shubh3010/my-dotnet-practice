using Models;

namespace blogpractice.Repository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync(int page = 1, int pageSize = 10, CancellationToken ct = default);
    
    IQueryable<Author> GetAuthors(CancellationToken ct = default);
}