using Application.Interfaces.Repositories;
using Database.Context;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class SerieGenderRepository : BaseRepository<SerieGender>, ISeriesGendersRepository
    {
        public SerieGenderRepository(ItlaStreamContext dbContext) : base(dbContext)
        {
            
        }
    }
}
