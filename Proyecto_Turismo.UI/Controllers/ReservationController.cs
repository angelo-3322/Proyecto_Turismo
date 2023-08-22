using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Infrastructure.Contexts;
using Proyecto_Turismo.UI.Models.ViewModels;
using Proyecto_Turismo.UI.Models.ViewModels.AccountModels;

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


        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateReservationViewModel();

            model.Clients = _clienteService.GetAll().ToList();
            model.Rooms = _habitacionService.GetAll().ToList();
            model.Packages = _paqueteService.GetAll().ToList();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _reservacionService.Create(model.Reservations);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            model.Clients = _clienteService.GetAll().ToList();
            //model.Packages = _paqueteService.GetAll().ToList();
            //model.Rooms = _habitacionService.GetAll().ToList();

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
    }
}
