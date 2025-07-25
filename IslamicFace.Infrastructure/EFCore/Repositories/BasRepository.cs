using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class BasRepository<TEntity, IdType> : IBasRepository<TEntity, IdType> where TEntity : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BasRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(IdType id) => await _dbSet.FindAsync(id);
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public int SaveChange() => _context.SaveChanges();

    public async Task<PagedResult<TEntity>> GetPagedAsync(IQueryable<TEntity> query, PaginationParams paginationParams, CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip(paginationParams.Skip)
            .Take(paginationParams.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<TEntity>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = paginationParams.PageNumber,
            PageSize = paginationParams.PageSize
        };
    }
}
