namespace IslamicFace.Domain.Abstractions.IRepositories;

public interface IBasRepository<TEntity, IdType> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(IdType id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> SaveChangesAsync();
    Task<PagedResult<TEntity>> GetPagedAsync(
    IQueryable<TEntity> query, PaginationParams paginationParams, CancellationToken cancellationToken = default);
}
