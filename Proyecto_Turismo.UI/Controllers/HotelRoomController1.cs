using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class HotelRoomController1 : Controller
    {
        private readonly IHabitacionService _habitacionService;

        public HotelRoomController1(IHabitacionService habitacionService)
        {
            _habitacionService = habitacionService;
        }

        public IActionResult Index()
        {
            var rooms = _habitacionService.GetAll();
            return View(rooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateHotelRoomViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateHotelRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _habitacionService.Create(model.Rooms);
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
            var room = _habitacionService.Get(id);
            var model =
                new EditHotelRoomViewModel
                {
                    NumeroHabitaciones = room.NumeroHabitaciones,
                    TipoHabitacion = room.TipoHabitacion,
                    Capacidad = room.Capacidad,
                    Precio = room.Precio,
                };

            return View(model);
        }

        [HttpPost("//edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditHotelRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var room = new EditHotelRoomDTO(id, model.NumeroHabitaciones, model.TipoHabitacion, model.Capacidad,model.Precio);
                //var result = _habitacionService.Edit(room);

                //if (result.IsSuccess)
                //{
                //    return RedirectToAction(nameof(Index));
                //}

                //ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }
    }
}
