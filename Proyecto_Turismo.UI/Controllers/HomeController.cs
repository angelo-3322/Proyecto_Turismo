using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Cuenta;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.DTOs.Servicios;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.UI.Models;
using Proyecto_Turismo.UI.Models.ViewModels;
using System.Diagnostics;

namespace Proyecto_Turismo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICuentaService _cuentaService;
        private readonly IFacturaService _facturaService;
        private readonly IHabitacionService _habitacionService;
        private readonly IPaqueteService _paqueteService;
        private readonly IReservacionService _reservacionService;
        private readonly IRestauranteService _restauranteService;
        private readonly IServicioService _servicioService;

        public HomeController(ILogger<HomeController> logger,
            ICuentaService cuentaService, IFacturaService facturaService, IHabitacionService habitacionService,
            IPaqueteService paqueteService, IReservacionService reservacionService, IRestauranteService restauranteService,
            IServicioService servicioService)
        {
            _logger = logger;
            _cuentaService = cuentaService;
            _facturaService = facturaService;
            _habitacionService = habitacionService;
            _paqueteService = paqueteService;
            _reservacionService = reservacionService;
            _restauranteService = restauranteService;
            _servicioService = servicioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateHotelRoomViewModel();


            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _servicioService.Create(model.Services);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }



            return View(model);
        }

        [HttpGet("//edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var service = _servicioService.Get(id);
            var model =
                new EditServiceViewModel
                {
                    Nombre = service.Nombre,
                    Precio = service.Precio,

                };

            return View(model);
        }

        [HttpPost("//edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new EditServicesDTO(id, model.Nombre, model.Precio);
                var result = _servicioService.Edit(service);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}