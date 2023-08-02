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
            return new EditReservationDTO(reservation.Id, reservation.FechaInicio, reservation.FechaFin);
        }

        public IEnumerable<ListReservationDTO> GetAll()
        {
            List<Reservacion> reservaciones =
                _repository.GetAll
                    (s => s.FechaInicio.Date >= DateTime.Now.Date.AddMonths(-1) || s.FechaFin.Date >= DateTime.Now.Date.AddMonths(-1),
                    includes: i => i.Cliente ).ToList();

            return reservaciones.ConvertAll
                (s => new ListReservationDTO(s.Id, s.FechaInicio.ToString(), s.FechaFin.ToString()));
        }

        public Result<int> Create(CreateReservationDTO dto)
        {
            Reservacion reservaciones =
                Reservacion.Create
                (
                    dto.IdCliente,
                    dto.IdPaquete,
                    dto.IdHabitaciones,
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
            throw new NotImplementedException();
        }

        public Result Edit(EditReservationDTO dto)
        {
            throw new NotImplementedException();
        }

    }
}
