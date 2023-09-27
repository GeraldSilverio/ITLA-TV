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
            return View(await _genderService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View("Create", new SaveGenderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGenderViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                await _genderService.AddAsync(vm);
                return RedirectToRoute(new { controller = "Gender", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Create", e);
            }

        }

        public async Task<IActionResult> Update(int id)
        {
            return View("Create", await _genderService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveGenderViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                await _genderService.UpdateAsync(vm);
                return RedirectToRoute(new { controller = "Gender", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Create", e);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _genderService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaveGenderViewModel vm)
        {
            try
            {
                await _genderService.DeleteAsync(vm);
                return RedirectToRoute(new { controller = "Gender", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Delete", e);
            }

        }

    }
}
