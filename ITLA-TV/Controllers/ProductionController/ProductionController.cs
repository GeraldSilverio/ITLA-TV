using Application.Interfaces.Services;
using Application.ViewModels.ProductionViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers.ProductionController
{
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productionService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View("Create", new ProductionSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionSaveViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                await _productionService.AddAsync(vm);
                return RedirectToRoute(new { controller = "Production", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Create", e);

            }
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("Create", await _productionService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductionSaveViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                await _productionService.UpdateAsync(vm);
                return RedirectToRoute(new { controller = "Production", action = "Index" });
            }
            catch (Exception e)
            {
                return View("Create", e);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _productionService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductionSaveViewModel vm)
        {
            try
            {
                await _productionService.DeleteAsync(vm);
                return RedirectToRoute(new { controller = "Production", action = "Index" });
            }
            catch(Exception e)
            {
                return View("Delete", e);
            }
        }




    }
}
