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
        public DateOnly DateofCreation { get; set; }
        public DateOnly DateofEdit { get; set; }
    }
}
