using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers.SeriesController
{
    public class SeriesController : Controller
    {
        private readonly ISeriesServices _seriesServices;
        private readonly IProductionService _productionService;
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesServices seriesServices, IProductionService productionService, IGenderService genderService, IMapper mapper)
        {
            _seriesServices = seriesServices;
            _productionService = productionService;
            _genderService = genderService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _seriesServices.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Productions = await _productionService.GetAllAsync();
            ViewBag.Genders = await _genderService.GetAllAsync();
            return View("Create", new SeriesSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SeriesSaveViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Productions = await _productionService.GetAllAsync();
                    ViewBag.Genders = await _genderService.GetAllAsync();
                    return View("Create", vm);
                }
                await _seriesServices.AddAsync(vm);
                return RedirectToRoute(new { controller = "Series", action = "Index" });
            }
            catch(Exception e)
            {
                return View("Index", e);
            }
            
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Productions = await _productionService.GetAllAsync();
            ViewBag.Genders = await _genderService.GetAllAsync();
            return View("Create", await _seriesServices.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SeriesSaveViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Productions = await _productionService.GetAllAsync();
                    ViewBag.Genders = await _genderService.GetAllAsync();
                    return View("Create", vm);
                }
                await _seriesServices.UpdateAsync(vm);
                return RedirectToRoute(new { controller = "Series", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Index", e);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _seriesServices.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SeriesSaveViewModel vm)
        {
            try
            {
                await _seriesServices.DeleteAsync(vm);
                return RedirectToRoute(new { controller = "Series", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Delete", e);
            }
        }
    }
}
