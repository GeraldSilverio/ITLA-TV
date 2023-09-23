using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductionViewModel
{
    public class ProductionSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "NAME CANNOT BE EMPYT")]
        public string Name { get; set; } = null!;
    }
}
