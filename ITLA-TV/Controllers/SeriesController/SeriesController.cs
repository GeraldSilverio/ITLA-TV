using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers.SeriesController
{
    public class SeriesController : Controller
    {
        private readonly SeriesServices _seriesServices;

        public SeriesController(SeriesServices seriesServices)
        {
            _seriesServices = seriesServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _seriesServices.GetAllViewModel());
        }
    }
}
