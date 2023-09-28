using Application.Interfaces.Generic;
using Database.Models;

namespace Application.Interfaces.Repositories
{
    public interface IGendersRepository:IBaseRepository<Genders>
    {
        bool IsNameCreated(string name, int idSerie);
    }
}


