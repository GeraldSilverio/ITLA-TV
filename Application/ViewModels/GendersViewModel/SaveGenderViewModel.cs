using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.GendersViewModel
{
    public class SaveGenderViewModel
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "NAME CANNOT BE EMPYT")]
        public string Name { get; set; } = null!;
    }

}
