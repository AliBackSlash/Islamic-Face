using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class PostTagRepository : BasRepository<PostTag, decimal> , IPostTagRepository
{
    public PostTagRepository(AppDbContext context) : base(context){ }

}
