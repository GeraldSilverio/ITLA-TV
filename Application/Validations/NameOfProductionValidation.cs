using Application.Interfaces.Services;
using Application.ViewModels.ProductionViewModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Validations
{
    public class NameOfProductionValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var productionService = validationContext.GetService(typeof(IProductionService)) as IProductionService;
            var name = (string)value;
            var viewModel = (ProductionSaveViewModel)validationContext.ObjectInstance;

            if (productionService.IsNameCreated(name, viewModel.Id))
            {
                return new ValidationResult("The name was created.Please write other name.");
            }

            return ValidationResult.Success;
        }
    }
}
