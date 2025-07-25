using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class UserRepository : BasRepository<User, int> ,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context){ }

}
