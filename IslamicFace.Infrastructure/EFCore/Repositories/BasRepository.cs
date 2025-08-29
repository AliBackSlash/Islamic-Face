

using IslamicFace.Domain.Pagination;
using IslamicFace.Infrastructure.EFCore.context;
using System.Threading;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class BasRepository<TEntity, IdType>(AppDbContext _context) : IBasRepository<TEntity, IdType> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = _context.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(IdType id, CancellationToken cancellationToken) => await _dbSet.FindAsync(id, cancellationToken);
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) => await _dbSet.ToListAsync(cancellationToken);
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);
    public void Update(TEntity entity) => _dbSet.Update(entity);
    public void Delete(TEntity entity) => _dbSet.Remove(entity);
    public async Task<Result<int>> SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            var affectedRows = await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(affectedRows);
        }
        catch (DbUpdateException ex)
        {
            return Result.Failure<int>(Error.Conflict("Database.Update", ex.InnerException?.Message ?? ex.Message));
        }
        catch (ValidationException ex)
        {
            return Result.Failure<int>(Error.Conflict("Validation.Error", ex.Message));
        }
        catch (Exception ex)
        {
            return Result.Failure<int>(Error.InternalServer("Unknown.Error", ex.Message));
        }
    }
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
