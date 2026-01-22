using blogpractice.Dtos;
using blogpractice.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

public class PostService(IPostRepository postRepo, ITagRepository tagRepo, IAuthorRepository authorRepo) : IPostService
{
    public async Task<IEnumerable<Post>> ListPostsAsync(int page, int pageSize, CancellationToken ct = default) =>
        await postRepo.GetPostsWithCommentsAsync(page, pageSize, ct);

    public async Task<Post?> GetPostAsync(int id, CancellationToken ct = default) =>
        await postRepo.GetPostWithCommentsAsync(id, ct);

    public async Task<Post> CreatePostAsync(Post p, CancellationToken ct = default)
    {
        await postRepo.AddAsync(p, ct);
        await postRepo.SaveChangesAsync(ct);
        return p;
    }

    public async Task UpdatePostAsync(Post p,CancellationToken ct = default)
    {
        var existing = await postRepo.GetByIdAsync(p.Id, ct);
        if (existing == null) throw new KeyNotFoundException("Post not found.");
        
        existing.Title = p.Title;
        existing.Content = p.Content;
        existing.PublishedAt = p.PublishedAt;

        postRepo.Update(existing);

        try
        {
            await postRepo.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            // The row version didn't match; inform caller.
            //throw new ConcurrencyException("The post was modified by another user. Please refresh and try again.");
        }
    }

    public async Task DeletePostAsync(int id, CancellationToken ct = default)
    {
        var p = await postRepo.GetByIdAsync(id, ct);
        if (p == null) throw new KeyNotFoundException();
        postRepo.Remove(p);
        await postRepo.SaveChangesAsync(ct);
    }
    
    public async Task<IEnumerable<PostSummaryDto>> GetComplexPostAsync(int id, CancellationToken ct = default)
    {
        // simple join 
        
        
        // var res = await postRepo.GetPosts(ct).Join(
        //     authorRepo.GetAuthors(ct),
        //     post => post.AuthorId,
        //     author => author.Id,
        //     (post, author) => new PostSummaryDto
        //     {
        //         Id = post.Id,
        //         AuthorId = author.Id,
        //     }
        // ).ToListAsync(cancellationToken: ct);
        //
        // return res;
        
        
        // grouop join

        var res = await authorRepo.GetAuthors(ct).GroupJoin(
            postRepo.GetPosts(ct),
            author => author.Id,
            post => post.AuthorId,
            (author, post) => new { author,post } // author : ["p1", "p2"] <--- x
        ).SelectMany(
            x => x.post.DefaultIfEmpty(),
            (x, post) => new PostSummaryDto
            {
                AuthorId = x.author.Id,
                Title = post != null ? post.Title : " No Post",
            }
        ).ToListAsync(ct);

        return res;
    }
    
    // var result = _context.Authors
    //     .SelectMany(
    //         a => a.Posts.DefaultIfEmpty(),
    //         (author, post) => new 
    //         {
    //             Author = author.Name,
    //             Post = post?.Title ?? "(No Posts)"
    //         }
    //     )
    //     .ToList();
}
