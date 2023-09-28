using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.SeriesViewModel;
using ITLA_TV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITLA_TV.Controllers.HomeController
{
    public class HomeController : Controller
    {
        private readonly ISeriesServices _seriesServices;
        private readonly IProductionService _productionService;

        public HomeController(ISeriesServices seriesServices, IProductionService productionService)
        {
            _seriesServices = seriesServices;
            _productionService = productionService;
        }
        public async Task<IActionResult> Index(SerieFilterViewModel serieFilter)
        {
            ViewBag.Productions = await _productionService.GetAllAsync();
            return View(await _seriesServices.GetByFiltersAsync(serieFilter));
        }
        public async Task<IActionResult> Details(int id)
        {
            SeriesSaveViewModel serie = await _seriesServices.GetByIdAsync(id);
            
            return View("Details",serie);
        }
    }
}