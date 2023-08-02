using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class HabitacionService : IHabitacionService
    {

        private readonly IHabitacionRepository _repository;

        public HabitacionService(IHabitacionRepository repository)
        {
            _repository = repository;
        }

        public EditHotelRoomDTO Get(int id)
        {
            Habitacion room = _repository.Get(s => s.Id == id);
            return new EditHotelRoomDTO(room.Id, room.NumeroHabitaciones, room.TipoHabitacion, room.Capacidad, room.Precio);
        }

        public IEnumerable<ListHotelRoomDTO> GetAll()
        {
            List<Habitacion> habitaciones =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.NumeroHabitaciones.ToString()) || !string.IsNullOrEmpty(s.TipoHabitacion)
                    || string.IsNullOrEmpty(s.Capacidad.ToString()) || string.IsNullOrEmpty(s.Precio.ToString())).ToList();

            return habitaciones.ConvertAll
                (s => new ListHotelRoomDTO(s.Id, s.NumeroHabitaciones, s.TipoHabitacion, s.Capacidad, s.Precio)); ;
        }

        public Result<int> Create(CreateHotelRoomDTO dto)
        {
            Habitacion habitacion =
                Habitacion.Create
                (
                    dto.Capacidad,
                    dto.TipoHabitacion,
                    dto.NumeroHabitaciones,
                    dto.Precio,
                    dto.Disponible,
                    dto.Imagenes
                );

            try
            {
                _repository.Instert(habitacion);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(habitacion.Id);
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result Edit(EditHotelRoomDTO dto)
        {
            throw new NotImplementedException();
        }


    }
}
