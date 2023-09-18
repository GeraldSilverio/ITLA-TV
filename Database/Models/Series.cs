using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Series:BaseEntity
    {
        public string ImagenUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int IdProduction { get; set; }
        public ProductionCompain ProductionCompain { get; set; } = null!;
        public ICollection<SerieGender> SerieGender { get; set; } = null!;

    }
}
