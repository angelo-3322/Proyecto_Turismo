using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController( IMenuService menuService)
        {
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            var menus = _menuService.GetAll();
            return View(menus);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateMenuViewModel();


            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _menuService.Create(model.Menus);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }


            return View(model);
        }

        [HttpGet("/menu/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var menus = _menuService.Get(id);
            var model =
                new EditMenuViewModel
                {
                    Nombre = menus.Nombre,

                };

            return View(model);
        }

        [HttpPost("/menu/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var menus = new EditMenuDTO(id, model.Nombre);
                var result = _menuService.Edit(menus);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }
    }
}
