using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.Entities;
using System.Linq.Expressions;

namespace Proyecto_Turismo.Application.Services
{
    public class ReservacionService : IReservacionService
    {

        private readonly IReservacionRepository _repository;

        public ReservacionService(IReservacionRepository repository)
        {
            _repository = repository;
        }

        public EditReservationDTO Get(int id)
        {
            Reservacion reservation = _repository.Get(s => s.Id == id);
            return new EditReservationDTO(reservation.Id,reservation.FechaInicio, reservation.FechaFin,reservation.Activa);
        }

        public IEnumerable<ListReservationDTO> GetAll()
        {
            List<Reservacion> reservaciones =
                _repository.GetAll
                    (s => s.FechaInicio.Date >= DateTime.Now.Date.AddMonths(-1) || s.FechaFin.Date >= DateTime.Now.Date.AddMonths(-1),
                    includes: new Expression<Func<Reservacion, object>>[] { i => i.Habitacion, i => i.Paquete }).ToList();


            return reservaciones.ConvertAll
                (s => new ListReservationDTO(s.Id,  /*s.UserId,*/ s.Paquete.Nombre,s.Habitacion.TipoHabitacion, s.FechaInicio, s.FechaFin, s.Activa));
        }

        public Result<int> Create(CreateReservationDTO dto)
        {
            Reservacion reservaciones =
                Reservacion.Create
                (
                    dto.IdHabitaciones,
                    dto.IdPaquete,
                    //dto.UserId,
                    dto.FechaInicio,
                    dto.FechaFin
                );

            try
            {
                _repository.Instert(reservaciones);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(reservaciones.Id);
        }

        public Result Delete(int id)
        {
            var reservacion = _repository.Get(m => m.Id == id);
            if (reservacion == null)
            {
                return Result.Fail("Reservacion not found");
            }

            try
            {
                _repository.Delete(reservacion);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

        public Result Edit(EditReservationDTO dto)
        {
            var reservacion = _repository.Get(m => m.Id == dto.Id);
            if (reservacion == null)
            {
                return Result.Fail("reservacion not found");
            }

            reservacion.FechaInicio = dto.FechaInicio;
            reservacion.FechaFin = dto.FechaFin;
            reservacion.Activa = dto.Activa;

            try
            {
                _repository.Update(reservacion);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

    }
}
