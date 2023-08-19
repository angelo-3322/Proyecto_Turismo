
namespace Proyecto_Turismo.Domain.DTOs.Habitaciones
{
    public class ListHotelRoomDTO
    {
        public ListHotelRoomDTO() {}

        public ListHotelRoomDTO(int id, int numerohabitaciones, string tipohabitacion, int capacidad, float precio,bool disponible , byte[] imagenes)
        {
            Id = id;
            NumeroHabitaciones = numerohabitaciones;
            TipoHabitacion = tipohabitacion;
            Capacidad = capacidad;
            Precio = precio;
            Disponible = disponible;
            Imagen = imagenes;
        }

        public int Id { get; set; }

        public int NumeroHabitaciones { get; set; }

        public string TipoHabitacion { get; set; }

        public int Capacidad { get; set; }

        public float Precio { get; set; }
        public bool Disponible { get; set; }

        public byte[] Imagen { get; set; }
    }
}
