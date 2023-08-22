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
            return new EditHotelRoomDTO(room.Id,room.NumeroHabitaciones, room.TipoHabitacion, room.Capacidad, room.Precio,room.Disponible,room.Imagen);
        }

        public IEnumerable<ListHotelRoomDTO> GetAll()
        {
            List<Habitacion> habitaciones =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.NumeroHabitaciones.ToString())).ToList();

            return habitaciones.Select(s =>
        new ListHotelRoomDTO(
            s.Id,
            s.NumeroHabitaciones,
            s.TipoHabitacion,
            s.Capacidad,
            s.Precio,
            s.Disponible,
            s.Imagen
        ));
        }

        public Result<int> Create(CreateHotelRoomDTO dto)
        {
            
            Habitacion habitacion =
                Habitacion.Create
                (
                    dto.NumeroHabitaciones,
                    dto.TipoHabitacion,
                    dto.Capacidad,
                    dto.Precio,
                    dto.Disponible,
                    dto.Imagen
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

        public Result Edit(EditHotelRoomDTO dto)
        {
            Habitacion existingHotelRoom = _repository.GetAll().FirstOrDefault(t => t.Id == dto.Id);

            existingHotelRoom.Update(dto.NumeroHabitaciones, dto.TipoHabitacion, dto.Capacidad, dto.Precio, dto.Disponible,dto.Imagen);

            _repository.Save();

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            try
            {
                Habitacion habitacion = _repository.Get(s => s.Id == id);
                if (habitacion == null)
                {
                    return Result.Fail("Habitación no encontrada.");
                }

                _repository.Delete(habitacion);
                _repository.Save();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al eliminar la habitación. Detalles: {ex.Message}");
            }
        }





    }
}
