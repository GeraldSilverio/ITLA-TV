using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfEdit { get; set; }
    }
}
