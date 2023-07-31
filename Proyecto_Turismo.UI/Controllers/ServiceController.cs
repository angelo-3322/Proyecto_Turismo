using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Servicios;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IServicioService _servicioService;

        public ServiceController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        public IActionResult Index()
        {
            var service = _servicioService.GetAll();
            return View(service);
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
    }
}
