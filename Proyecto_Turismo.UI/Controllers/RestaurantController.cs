using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestauranteService _restauranteService;
        private readonly IMenuService _menuService;

        public RestaurantController(IRestauranteService restauranteService,IMenuService menuService)
        {
            _restauranteService = restauranteService;
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            var restaurant = _restauranteService.GetAll();
            return View(restaurant);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateRestaurantViewModel();

            model.menus = _menuService.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateRestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _restauranteService.Create(model.Restaurants);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            model.menus = _menuService.GetAll().ToList();

            return View(model);
        }

        [HttpGet("/restaurant/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var restaurant = _restauranteService.Get(id);
            var model =
                new EditRestaurantViewModel
                {

                    Nombre = restaurant.Nombre,

                };

            return View(model);
        }

        [HttpPost("/restaurant/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditRestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new EditRestaurantDTO(id, model.Nombre);
                var result = _restauranteService.Edit(restaurant);

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
