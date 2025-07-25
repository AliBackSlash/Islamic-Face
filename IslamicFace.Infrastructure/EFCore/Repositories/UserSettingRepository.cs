using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class UserSettingRepository : BasRepository<UserSetting, byte>, IUserSettingRepository
{
    public UserSettingRepository(AppDbContext context) : base(context){ }

}