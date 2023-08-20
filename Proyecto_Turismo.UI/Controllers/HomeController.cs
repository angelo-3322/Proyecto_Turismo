using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.UI.Models;
using Proyecto_Turismo.UI.Models.ViewModels;
using System.Diagnostics;

namespace Proyecto_Turismo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteService _clienteService;
        private readonly IFacturaService _facturaService;
        private readonly IHabitacionService _habitacionService;
        private readonly IPaqueteService _paqueteService;
        private readonly IReservacionService _reservacionService;
        private readonly IRestauranteService _restauranteService;
        private readonly IMenuService _menuService;
        private readonly IProductoService _productoService;

        public HomeController(ILogger<HomeController> logger, IClienteService clienteService,IFacturaService facturaService, IHabitacionService habitacionService,
            IPaqueteService paqueteService, IReservacionService reservacionService, IRestauranteService restauranteService, IMenuService menuService, IProductoService productoService)
        {
            _logger = logger;
            _facturaService = facturaService;
            _habitacionService = habitacionService;
            _paqueteService = paqueteService;
            _reservacionService = reservacionService;
            _restauranteService = restauranteService;
            _menuService = menuService;
            _productoService = productoService;
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Restaurant()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateRestaurantViewModel();

            model.menus = _menuService.GetAll().ToList();
            //model.Packages = _paqueteService.GetAll().ToList();
            //model.Rooms = _habitacionService.GetAll().ToList();
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
            //model.Packages = _paqueteService.GetAll().ToList();
            //model.Rooms = _habitacionService.GetAll().ToList();

            return View(model);
        }

        //[HttpGet("/reservation/edit/{id}")]
        //public IActionResult Edit([FromRoute] int id)
        //{
        //    var restaurant = _restauranteService.Get(id);
        //    var model =
        //        new EditRestaurantViewModel
        //        {
                    
        //            Nombre = restaurant.Nombre,

        //        };

        //    return View(model);
        //}

        //[HttpPost("/reservation/edit/{id}")]
        //public IActionResult Edit([FromRoute] int id, EditRestaurantViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var restaurant = new EditRestaurantDTO(id, model.Nombre,model.IdMenu);
        //        var result = _restauranteService.Edit(restaurant);

        //        if (result.IsSuccess)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }

        //        ModelState.AddModelError(string.Empty, result.Error);
        //    }
        //    return View(model);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}