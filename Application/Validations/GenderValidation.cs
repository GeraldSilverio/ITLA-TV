using Application.ViewModels.SeriesViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class GenderValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int idGender && validationContext.ObjectInstance is SeriesSaveViewModel viewModel)
            {
                int idGenderSecundary = viewModel.IdGenderSecundary;

                if (idGender == idGenderSecundary)
                {
                    return new ValidationResult("The genders need to be different.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
