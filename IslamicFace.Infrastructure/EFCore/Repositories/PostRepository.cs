using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class PostRepository : BasRepository<Post, decimal> , IPostRepository
{
    public PostRepository(AppDbContext context) : base(context){ }

}
