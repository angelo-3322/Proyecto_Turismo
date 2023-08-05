using Proyecto_Turismo.Domain.DTOs.Imagen;
using System.ComponentModel.DataAnnotations;


namespace Proyecto_Turismo.Domain.DTOs.Habitaciones
{
    public class EditHotelRoomDTO
    {
        public EditHotelRoomDTO() { }

        public EditHotelRoomDTO(int id, int numeroHabitacion, string tipoHabitacion, int capacidad, float precio,bool activo , List<byte[]> imagenes)
            : this()
        {
            Id = id;
            NumeroHabitaciones = numeroHabitacion;
            TipoHabitacion = tipoHabitacion;
            Capacidad = capacidad;
            Precio = precio;
            Disponible = activo;
            Imagenes = imagenes;
        }

        public int Id { get; set; }

        [Required]
        public int NumeroHabitaciones { get;  set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string TipoHabitacion { get;  set; }

        [Required]
        public int Capacidad { get;  set; }

        [Required]
        public float Precio { get;  set; }

        [Required]
        public bool Disponible { get; private set; }

        public List<byte[]> Imagenes { get; set; }
    }
}
