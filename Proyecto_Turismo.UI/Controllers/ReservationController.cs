using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.Infrastructure.Contexts;
using Proyecto_Turismo.UI.Models.ViewModels;
using Proyecto_Turismo.UI.Models.ViewModels.AccountModels;
using System.Security.Claims;

namespace Proyecto_Turismo.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservacionService _reservacionService;
        private readonly IClienteService _clienteService;
        private readonly IPaqueteService _paqueteService;
        private readonly IHabitacionService _habitacionService;
        private readonly ApplicationIdentityDbContext _identityContext;

        public ReservationController(IReservacionService reservacionService,IClienteService clienteService, 
            IPaqueteService paqueteService, IHabitacionService habitacionService,
            ApplicationIdentityDbContext identityContext)
        {
            _reservacionService = reservacionService;
            _clienteService = clienteService;
            _paqueteService = paqueteService;
            _habitacionService = habitacionService;
            _identityContext = identityContext;
        }


        public IActionResult MyReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservaciones = _reservacionService.GetAll().Where(r => r.UserId == userId).ToList();
            var habitaciones = _habitacionService.GetAll().ToList();

            var viewModel = new MyReservationsViewModel
            {
                Reservations = reservaciones.Select(r =>
                {
                    var habitacion = habitaciones.FirstOrDefault(h => h.Id == r.Id);
                    var imagen = habitaciones.FirstOrDefault(h => h.NumeroHabitaciones == r.Habitacion);

                    return new MyReservationsViewModel.ReservationDetails
                    {
                        HabitacionImagen = imagen?.Imagen,
                        NumeroHabitacion = r.Habitacion,
                        FechaInicio = r.FechaInicio,
                        FechaFin = r.FechaFin,
                        UsuarioEmail = _identityContext.Users.FirstOrDefault(u => u.Id == r.UserId)?.Email
                    };
                }).ToList()
            };

            return View(viewModel);
        }


        public IActionResult Index()
        {
            var reservaciones = _reservacionService.GetAll().ToList();
            var habitaciones = _habitacionService.GetAll().ToList();
            var paquetes = _paqueteService.GetAll().ToList();

            var reservacionesVM = reservaciones.Select(r => new ReservacionViewModel
            {
                Reservacion = r,
                UsuarioEmail = _identityContext.Users.FirstOrDefault(u => u.Id == r.UserId)?.Email
            }).ToList();

            return View(reservacionesVM);
        }

        public IActionResult Cindex()
        {
            var rooms = _habitacionService.GetAll();
            return View(rooms);
        }


        [HttpGet("/Reservation/Reservar/{id}")]
        public IActionResult Reservar([FromRoute] int id)
        {
            var room = _habitacionService.Get(id);
            var packages = _paqueteService.GetAll().Where(p =>
             (p.Nombre.Contains("Familiar") && room.Capacidad >= 4) ||
             (!p.Nombre.Contains("Familiar") && room.Capacidad <= 2)
             ).ToList();
            var model = new CreateReservationModel
            {
                Habitacion = new EditHotelRoomDTO
                {
                    Id = room.Id,
                    NumeroHabitaciones = room.NumeroHabitaciones,
                    TipoHabitacion = room.TipoHabitacion,
                    Capacidad = room.Capacidad,
                    Precio = room.Precio,
                    Disponible = room.Disponible,
                    Imagen = room.Imagen

                },
                PaquetesDisponibles = packages.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Reservar(CreateReservationModel model)
        {
            //if (ModelState.IsValid)
            //{
                var userau = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var reservation = new CreateReservationDTO
                {
                    IdHabitaciones = model.Habitacion.Id,
                    IdPaquete = model.PaqueteSeleccionado,
                    UserId = userau,
                    FechaInicio = model.FechaInicio,
                    FechaFin = model.FechaFin,
                    Activa = true
                    //Dias = model.Dias,
                    //Total = model.Total
                };
                var result = _reservacionService.Create(reservation);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, result.Error);
            //}
            return View(model);
        }

        [HttpGet("/reservation/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var reservation = _reservacionService.Get(id);
            var model =
                new EditReservationViewModel
                {
                    FechaInicio = reservation.FechaInicio,
                    FechaFin = reservation.FechaFin,
                    Activa = reservation.Activa,

                };

            return View(model);
        }

        [HttpPost("/reservation/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = new EditReservationDTO(id, model.FechaInicio, model.FechaFin, model.Activa);
                var result = _reservacionService.Edit(reservation);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }

        [HttpDelete]
        [Route("Reservacion/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return Json(new { success = false, message = "ID inválido." });
            }

            var result = _reservacionService.Delete(id);

            if (!result.IsSuccess)
            {
                return Json(new { success = false, message = result.Error });
            }

            return Json(new { success = true });
        }

    }
}
