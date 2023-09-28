using Application.Interfaces.Repositories;
using Database.Context;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ProductionRepository : BaseRepository<ProductionCompain>, IProductionRepository
    {
        private readonly ItlaStreamContext _dbContext;
        public ProductionRepository(ItlaStreamContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsNameCreated(string name, int idSerie)
        {
            return _dbContext.ProductionCompanies.Any(s => s.Name == name && s.Id != idSerie);
        }
    }
}
