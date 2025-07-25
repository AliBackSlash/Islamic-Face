using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class FriendRequestRepository : BasRepository<FriendRequest, decimal>, IFriendRequestRepository
{
    public FriendRequestRepository(AppDbContext context) : base(context){ }

}
