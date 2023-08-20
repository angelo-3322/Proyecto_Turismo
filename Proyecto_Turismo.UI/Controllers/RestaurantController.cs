using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.UI.Models;
using Proyecto_Turismo.UI.Models.ViewModels;
using Proyecto_Turismo.UI.Models.ViewModels.AccountModels;

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
            var restaurantes = _restauranteService.GetAll();
            var model = new List<RestauranteViewModel>();

            foreach (var restaurante in restaurantes)
            {
                var menu = _menuService.Get(restaurante.IdMenu);
                var restauranteViewModel = new RestauranteViewModel
                {
                    Restaurante = restaurante,
                    NombreMenu = menu.Nombre
                };
                model.Add(restauranteViewModel);
            }

            return View(model);
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
            var menusEn = _menuService.GetAll();
            var menus = menusEn.Select(m => new ListMenuDTO(m.Id, m.Nombre)).ToList();

            var model = new EditRestaurantViewModel
            {
                Restaurante = new EditRestaurantDTO
                {
                    Id = restaurant.Id,
                    Nombre = restaurant.Nombre,
                    IdMenu = restaurant.IdMenu
                },
                Menus = menus
            };

            return View(model);
        }


        [HttpPost("/restaurant/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditRestaurantViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var restaurant = new EditRestaurantDTO(id, model.Restaurante.Nombre,model.Restaurante.IdMenu);
                var result = _restauranteService.Edit(restaurant);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            // Si hay algún error, volver a cargar la lista de menús y mostrar la vista de nuevo
            var menuEntities = _menuService.GetAll();
            var menus = menuEntities.Select(m => new ListMenuDTO
            {
                Id = m.Id,
                Nombre = m.Nombre
            }).ToList();
            model.Menus = menus;
            return View(model);
        }

    }
}
