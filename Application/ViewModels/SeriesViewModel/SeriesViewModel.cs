


namespace Application.ViewModels.SeriesViewModel
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int IdProduction { get; set; }
    }
}
