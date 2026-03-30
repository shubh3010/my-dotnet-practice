using Models;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<Post>> GetPostsWithCommentsAsync(int page = 1, int pageSize = 10, CancellationToken ct = default);
    Task<Post?> GetPostWithCommentsAsync(int id, CancellationToken ct = default);
     IQueryable<Post> GetPosts(CancellationToken ct = default);
    Task<IEnumerable<Post>> GetFilteredPostsAsync(int page, int pageSize, IEnumerable<IPostFilterStrategy> filters, CancellationToken ct = default);
}