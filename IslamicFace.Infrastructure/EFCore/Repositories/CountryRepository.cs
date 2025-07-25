using IslamicFace.Domain.Abstractions.IRepositories;
using IslamicFace.Domain.Entities;
using IslamicFace.Infrastructure.context;

namespace IslamicFace.Infrastructure.EFCore.Repositories;

public class CountryRepository : BasRepository<Country, byte>, ICountryRepository
{
    public CountryRepository(AppDbContext context) : base(context){ }

}
