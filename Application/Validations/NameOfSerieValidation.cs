using Application.Interfaces.Repositories;
using Application.Services;
using Application.ViewModels.SeriesViewModel;
using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class NameOfSerieValidation : ValidationAttribute
    {
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var seriesService = validationContext.GetService(typeof(ISeriesServices)) as ISeriesServices;
            var name = (string)value;
            var viewModel = (SeriesSaveViewModel)validationContext.ObjectInstance;

            if (seriesService.IsNameCreated(name, viewModel.Id))
            {
                return new ValidationResult("The name was created.Please write other name.");
            }

            return ValidationResult.Success;
        }

    }
}
