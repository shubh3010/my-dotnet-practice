using Microsoft.EntityFrameworkCore;
using Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly BloggingContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(BloggingContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default) =>
        await _dbSet.AsNoTracking().ToListAsync(ct);

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await _dbSet.FindAsync(new object[] { id }, ct);

    public virtual async Task AddAsync(T entity, CancellationToken ct = default) =>
        await _dbSet.AddAsync(entity, ct);

    public virtual void Update(T entity) => _dbSet.Update(entity);

    public virtual void Remove(T entity) => _dbSet.Remove(entity);

    public virtual async Task SaveChangesAsync(CancellationToken ct = default) => 
        await _context.SaveChangesAsync(ct);
    
    public T Add(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }
    
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

}