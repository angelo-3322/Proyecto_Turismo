using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.UI.Models;
using Proyecto_Turismo.UI.Models.ViewModels;
using System.Diagnostics;

namespace Proyecto_Turismo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFacturaService _facturaService;
        private readonly IHabitacionService _habitacionService;
        private readonly IPaqueteService _paqueteService;
        private readonly IReservacionService _reservacionService;
        private readonly IRestauranteService _restauranteService;
        private readonly IMenuService _menuService;
        private readonly IProductoService _productoService;

        public HomeController(ILogger<HomeController> logger, IFacturaService facturaService, IHabitacionService habitacionService,
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
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var model = new CreateMenuViewModel();
            

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Create(CreateMenuViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _menuService.Create(model.Menus);
        //        if (result.IsSuccess)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }

        //        ModelState.AddModelError(string.Empty, result.Error);
        //    }

            
        //    return View(model);
        //}

        //[HttpGet("/menu/edit/{id}")]
        //public IActionResult Edit([FromRoute] int id)
        //{
        //    var menu = _menuService.Get(id);
        //    var model =
        //        new EditMenuViewModel
        //        {
        //            Nombre = menu.Nombre,

        //        };

        //    return View(model);
        //}

        //[HttpPost("/menu/edit/{id}")]
        //public IActionResult Edit([FromRoute] int id, EditMenuViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var menus = new EditMenuDTO(id, model.Nombre);
        //        var result = _menuService.Edit(menus);

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