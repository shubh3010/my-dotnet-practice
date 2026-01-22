using blogpractice.Dtos;
using blogpractice.Repository;
using blogpractice.Services;
using Models;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<IEnumerable<AuthorDto>> ListAuthorsAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var authors = await _authorRepository.GetAuthorsAsync(page, pageSize, ct);
        var dtos = authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            UserName = a.UserName,
            Email = a.Email,
            Posts = a.Posts.Select(p => new PostSummaryDto
            {
                Id = p.Id, 
                Title = p.Title, 
                PublishedAt = p.PublishedAt
            }).ToList()
        });
        return dtos;
    }
        
}