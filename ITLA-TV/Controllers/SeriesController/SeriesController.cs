using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.SeriesViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers.SeriesController
{
    public class SeriesController : Controller
    {
        private readonly ISeriesServices _seriesServices;
        private readonly IProductionService _productionService;
        private readonly IGenderService _genderService;

        public SeriesController(ISeriesServices seriesServices, IProductionService productionService, IGenderService genderService)
        {
            _seriesServices = seriesServices;
            _productionService = productionService;
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _seriesServices.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Productions = await _productionService.GetAllAsync();
            ViewBag.Genders = await _genderService.GetAllAsync();
            return View("Create", new SeriesViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SeriesViewModel vm)
        {
            await _seriesServices.AddAsync(vm);
            return RedirectToRoute(new { controller = "Series", action = "Index" });
        }
    }
}
