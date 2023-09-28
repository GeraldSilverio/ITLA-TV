using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.ProductionViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class NameOfGenderValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var genderService = validationContext.GetService(typeof(IGenderService)) as IGenderService;
            var name = (string)value;
            var viewModel = (ProductionSaveViewModel)validationContext.ObjectInstance;

            if (genderService.IsNameCreated(name, viewModel.Id))
            {
                return new ValidationResult("The name was created.Please write other name.");
            }

            return ValidationResult.Success;
        }

    }
}
