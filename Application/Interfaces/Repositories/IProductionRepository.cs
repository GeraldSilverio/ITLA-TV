using Application.Interfaces.Generic;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IProductionRepository:IBaseRepository<ProductionCompain>
    {
        bool IsNameCreated(string name, int idSerie);
    }
}
