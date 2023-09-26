using Application.Interfaces.Repositories;
using Application.ViewModels.SeriesViewModel;
using ITLA_TV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITLA_TV.Controllers.HomeController
{
    public class HomeController : Controller
    {
        private readonly ISeriesServices _seriesServices;

        public HomeController(ISeriesServices seriesServices)
        {
            _seriesServices = seriesServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _seriesServices.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            SeriesViewModel serie = await _seriesServices.GetByIdAsync(id);
            
            return View("Details",serie);
        }
    }
}