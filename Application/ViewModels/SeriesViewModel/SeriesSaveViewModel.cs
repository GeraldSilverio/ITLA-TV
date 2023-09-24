using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SeriesViewModel
{
    public class SeriesSaveViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int IdProduction { get; set; }
        public List<int> IdGender { get; set; } = null!;
    }
}
