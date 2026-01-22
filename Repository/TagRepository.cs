using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace blogpractice.Repository;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(BloggingContext context): base(context) {}

    public async Task<Tag> GetByIdAsync(int id)
    {   
        return await _dbSet
            .Include(t => t.Posts)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        _dbSet.Update(tag);
        await _context.SaveChangesAsync();
    }
    
}
