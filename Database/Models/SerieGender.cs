using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class SerieGender
    {
        public int IdSerie { get; set; }
        public Series Serie { get; set; } = null!;
        public int IdGender { get; set; }
        public Genders Gender { get; set; } = null!;
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfEdit { get; set; }



    }
}
