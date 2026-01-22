using blogpractice.Dtos;
using Models;

namespace blogpractice.Services;

public interface ITagService
{
    Task<Tag> CreateTagAsync(CreateTagDto dto);
    Task<IEnumerable<Tag>> GetAllAsync();
    Task<Tag> GetAsync(int id);
    Task UpdateAsync(int id, UpdateTagDto dto);
    Task DeleteAsync(int id);

    Task AssignTagsToPostAsync(int postId, List<int> tagIds);
    // Task<IEnumerable<Tag>> GetTagsForPostAsync(int postId);
    // Task RemoveTagFromPostAsync(int postId, int tagId);
    // Task ReplaceTagsForPostAsync(int postId, List<int> tagIds);
}
