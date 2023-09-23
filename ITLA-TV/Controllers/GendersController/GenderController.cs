using Application.Interfaces.Repositories;
using Application.ViewModels.GendersViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers.GendersController
{
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _genderService.GetAll());
        }
        public IActionResult Create(){
            return View("Create", new SaveGenderViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveGenderViewModel vm)
        {
            await _genderService.AddAsync(vm);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }
        public IActionResult Update()
        {
            return View("Create", new SaveGenderViewModel());
        }

    
    }
}
