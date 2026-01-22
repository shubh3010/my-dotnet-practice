using blogpractice.Dtos;
using blogpractice.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace blogpractice.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;
    private readonly IPostRepository _postRepository;

    public TagService(ITagRepository tagRepository, IPostRepository postRepository)
    {
        _tagRepository = tagRepository;
        _postRepository = postRepository;
    }

    public async Task<Tag> CreateTagAsync(CreateTagDto dto)
    {
        var tag = new Tag { Name = dto.Name };
        _tagRepository.Add(tag);
        await _tagRepository.SaveChangesAsync();

        return tag;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _tagRepository.GetAllAsync();
    }

    public async Task<Tag> GetAsync(int id)
    {
        return await _tagRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateTagDto dto)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null) throw new ArgumentException("Tag not found");

        tag.Name = dto.Name;

        await _tagRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null) throw new ArgumentException("Tag not found");

        _tagRepository.Remove(tag);
        await _tagRepository.SaveChangesAsync();
    }  
    
    // Many-to-Many Operations -----------------------------

    public async Task AssignTagsToPostAsync(int postId, List<int> tagIds)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null) throw new ArgumentException("Post not found");
        
        var allTags = await _tagRepository.GetAllAsync();
        var tags = allTags.Where(t => tagIds.Contains(t.Id)).ToList();
        var existingTagIds = post.Tags.Select(pt => pt.Id).ToHashSet();

        foreach (var tag in tags)
        {
            if (!existingTagIds.Contains(tag.Id))
            {
                post.Tags.Add(tag);
            }
        }
        await _postRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tag>> GetTagsForPostAsync(int postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null) throw new ArgumentException("Post not found");

        return post.Tags;
    }
    
    public async Task RemoveTagFromPostAsync(int postId, int tagId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null) throw new ArgumentException("Post not found");

       var tag = post.Tags.FirstOrDefault(t => t.Id == tagId);
         if (tag == null) throw new ArgumentException("Tag not associated with the post");
         
         post.Tags.Remove(tag);
         await _postRepository.SaveChangesAsync();
    }

    public async Task ReplaceTagsForPostAsync(int postId, List<int> tagIds)
    {
        var post = await _postRepository.GetByIdAsync(postId);


        if (post == null) throw new ArgumentException("Post not found");
        
        post.Tags.Clear();
        
        var allTags = await _tagRepository.GetAllAsync();
        var tags = allTags.Where(t => tagIds.Contains(t.Id)).ToList();
        foreach (var tag in tags)
        {
            post.Tags.Add(tag);
        }
        await _postRepository.SaveChangesAsync();
    }
}