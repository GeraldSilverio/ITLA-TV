using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ProductionCompain:BaseEntity
    {
        public ICollection<Series> Series { get; set; } = null!;
    }
}
