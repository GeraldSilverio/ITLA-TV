using Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.SeriesViewModel
{
    public class SeriesSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be Empty")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "ImagenUrl cannot be Empty")]
        public string ImagenUrl { get; set; } = null!;

        [Required(ErrorMessage = "VideoUrl cannot be Empty")]
        public string VideoUrl { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Produccion cannot be Empty")]
        public int IdProduction { get; set; }

        [GenderValidation]
        [Range(1, int.MaxValue, ErrorMessage = "Primary Gender cannot be Empty")]
        public int IdGender { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Secundary Gender cannot be Empty")]
        public int IdGenderSecundary { get; set; }
    }
}
