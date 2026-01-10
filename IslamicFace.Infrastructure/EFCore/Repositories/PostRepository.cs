using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.EFCore.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class PostRepository : BasRepository<Post, decimal> , IPostRepository
{
    public PostRepository(AppDbContext context) : base(context){ }

}
