using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly IHabitacionService _habitacionService;

        public HotelRoomController(IHabitacionService habitacionService)
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
        public async  Task<IActionResult> Create(CreateHotelRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ImageFile.CopyToAsync(memoryStream);
                        model.Rooms.Imagen = memoryStream.ToArray();
                    }
                }

                var result = _habitacionService.Create(model.Rooms);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index", "HotelRoom");
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View(model);
        }

        [HttpGet("/hotelroom/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var room = _habitacionService.Get(id);
            var model =
                new EditHotelRoomViewModel
                {
                    Id = room.Id,
                    NumeroHabitaciones = room.NumeroHabitaciones,
                    TipoHabitacion = room.TipoHabitacion,
                    Capacidad = room.Capacidad,
                    Precio = room.Precio,
                    Disponible = room.Disponible,
                    Imagen = room.Imagen,
                    ImageSrc = "data:image/jpeg;base64," + Convert.ToBase64String(room.Imagen)
                };

            return View(model);
        }


        [HttpPost("/hotelroom/edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, EditHotelRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageBytes = null;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ImageFile.CopyToAsync(memoryStream);
                        imageBytes = memoryStream.ToArray();
                    }
                }
                else
                {
                    imageBytes = model.Imagen; // Usar la imagen actual si no se ha proporcionado una nueva.
                }

                // Asegurarse de que se pasen los bytes de imagen correctos al DTO.
                var room = new EditHotelRoomDTO(id, model.NumeroHabitaciones, model.TipoHabitacion, model.Capacidad, model.Precio, model.Disponible, imageBytes);
                var result = _habitacionService.Edit(room);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }

        [HttpDelete("/hotelroom/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _habitacionService.Delete(id);
            if (result.IsSuccess)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
