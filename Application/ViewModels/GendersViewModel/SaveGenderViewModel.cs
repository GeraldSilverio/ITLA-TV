using Application.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.GendersViewModel
{
    public class SaveGenderViewModel
    {
        public int Id {get;set;}
        [NameOfGenderValidation]
        [Required(ErrorMessage = "NAME CANNOT BE EMPYT")]
        public string Name { get; set; } = null!;
    }
}
