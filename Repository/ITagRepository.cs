using Models;

namespace blogpractice.Repository;

public interface ITagRepository : IRepository<Tag>
{
    Task<Tag> GetByIdAsync(int id);
    Task<IEnumerable<Tag>> GetAllAsync();
}
