using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
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

        public HomeController(ILogger<HomeController> logger, IFacturaService facturaService, IHabitacionService habitacionService,
            IPaqueteService paqueteService, IReservacionService reservacionService, IRestauranteService restauranteService)
        {
            _logger = logger;
            _facturaService = facturaService;
            _habitacionService = habitacionService;
            _paqueteService = paqueteService;
            _reservacionService = reservacionService;
            _restauranteService = restauranteService;
        }

        public IActionResult Index()
        {
            var facturas = _facturaService.GetAll();
            return View(facturas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateFactureViewModel();
            model.Reservations = _reservacionService.GetAll().ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateFactureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _facturaService.Create(model.Facture);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            model.Reservations = _reservacionService.GetAll().ToList();
            return View(model);
        }

        //[HttpGet("//edit/{id}")]
        //public IActionResult Edit([FromRoute] int id)
        //{
        //    var service = _servicioService.Get(id);
        //    var model =
        //        new EditServiceViewModel
        //        {
        //            Nombre = service.Nombre,
        //            Precio = service.Precio,

        //        };

        //    return View(model);
        //}

        //[HttpPost("//edit/{id}")]
        //public IActionResult Edit([FromRoute] int id, EditServiceViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var service = new EditServicesDTO(id, model.Nombre, model.Precio);
        //        var result = _servicioService.Edit(service);

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