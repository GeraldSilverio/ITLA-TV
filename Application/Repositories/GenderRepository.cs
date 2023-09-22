using Application.Interfaces.Repositories;
using Database.Context;
using Database.Models;

namespace Application.Repositories;

public class GenderRepository : BaseRepository<Genders>, IGendersRepository
{
    public GenderRepository(ItlaStreamContext dbContext) : base(dbContext)
    {
    }
}
