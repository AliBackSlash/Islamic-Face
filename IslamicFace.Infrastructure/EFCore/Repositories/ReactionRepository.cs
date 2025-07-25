using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class ReactionRepository : BasRepository<Reaction, byte>, IReactionRepository
{
    public ReactionRepository(AppDbContext context) : base(context){ }

}
