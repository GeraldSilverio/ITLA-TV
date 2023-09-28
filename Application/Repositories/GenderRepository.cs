using Application.Interfaces.Repositories;
using Database.Context;
using Database.Models;

namespace Application.Repositories;

public class GenderRepository : BaseRepository<Genders>, IGendersRepository
{
    private readonly ItlaStreamContext _dbContext;
    public GenderRepository(ItlaStreamContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsNameCreated(string name, int idSerie)
    {
        return _dbContext.Genders.Any(s => s.Name == name && s.Id != idSerie);
    }
}
