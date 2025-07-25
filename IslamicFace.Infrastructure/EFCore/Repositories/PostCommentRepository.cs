using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class PostCommentRepository : BasRepository<PostComment, decimal>, IPostCommentRepository
{
    public PostCommentRepository(AppDbContext context) : base(context){ }

}
