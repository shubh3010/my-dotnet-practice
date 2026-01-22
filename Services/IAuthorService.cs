using blogpractice.Dtos;
using Models;

namespace blogpractice.Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> ListAuthorsAsync(int page, int pageSize, CancellationToken ct = default);
}