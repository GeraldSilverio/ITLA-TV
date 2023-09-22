using Database.Models;


namespace Application.ViewModels.SeriesViewModel
{
    public class SeriesViewModel : BaseEntity
    {
        public string ImagenUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int IdProduction { get; set; }
    }
}
