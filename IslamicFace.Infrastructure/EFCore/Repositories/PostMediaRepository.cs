using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class PostMediaRepository : BasRepository<PostMedia, decimal>, IPostMediaRepository
{
    public PostMediaRepository(AppDbContext context) : base(context){ }

}
