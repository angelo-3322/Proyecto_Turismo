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
            Habitacion room = _repository.Get(s => s.Id == id, includes: i => i.Imagenes);

             // Mapear la lista de Imagen a una lista de byte[]
             List<byte[]> imagenes = room.Imagenes.Select(i => i.DatosImagen).ToList();

            return new EditHotelRoomDTO(room.Id, room.NumeroHabitaciones, room.TipoHabitacion, room.Capacidad, room.Precio,room.Disponible, imagenes);
        }

        public IEnumerable<ListHotelRoomDTO> GetAll()
        {
            List<Habitacion> habitaciones =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.NumeroHabitaciones.ToString()), includes: s => s.Imagenes).ToList();

            return habitaciones.Select(s =>
        new ListHotelRoomDTO(
            s.Id,
            s.NumeroHabitaciones,
            s.TipoHabitacion,
            s.Capacidad,
            s.Precio,
            s.Disponible,
            s.Imagenes.Select(i => i.DatosImagen).ToList()
        ));
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

        public Result Edit(EditHotelRoomDTO dto)
        {
            Habitacion existingHotelRoom = _repository.GetAll().FirstOrDefault(t => t.Id == dto.Id);

            existingHotelRoom.Update(dto.NumeroHabitaciones, dto.TipoHabitacion, dto.Capacidad, dto.Precio, dto.Disponible);

            _repository.Save();

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        


    }
}
