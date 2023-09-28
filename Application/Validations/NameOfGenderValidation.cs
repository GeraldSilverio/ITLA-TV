using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels.GendersViewModel;
using Application.ViewModels.ProductionViewModel;
using Application.ViewModels.SeriesViewModel;
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
            var genderService = (IGenderService)validationContext.GetService(typeof(IGenderService));
            var name = (string)value;
            var viewModel = (SaveGenderViewModel)validationContext.ObjectInstance;

            // Verificar si el nombre ya existe en la base de datos
            if (genderService.IsNameCreated(name, viewModel.Id))
            {
                return new ValidationResult("El nombre ya existe en la base de datos.");
            }

            return ValidationResult.Success;
        }

    }
}
