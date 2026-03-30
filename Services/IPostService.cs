using blogpractice.Dtos;
using Models;

public interface IPostService
{
    Task<IEnumerable<Post>> ListPostsAsync(PostQueryParameters qp, CancellationToken ct = default);
    Task<Post?> GetPostAsync(int id, CancellationToken ct = default);
    Task<Post> CreatePostAsync(Post p, CancellationToken ct = default);
    Task UpdatePostAsync(Post p, CancellationToken ct = default);
    Task DeletePostAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<PostSummaryDto>> GetComplexPostAsync (int id, CancellationToken ct = default);
}