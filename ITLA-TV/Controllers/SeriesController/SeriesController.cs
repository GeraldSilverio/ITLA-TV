using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers.SeriesController
{
    public class SeriesController : Controller
    {
        private readonly ISeriesServices _seriesServices;

        public SeriesController(ISeriesServices seriesServices)
        {
            _seriesServices = seriesServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _seriesServices.GetAllViewModel());
        }
    }
}
