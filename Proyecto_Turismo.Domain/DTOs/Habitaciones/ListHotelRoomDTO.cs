using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Habitaciones
{
    public class ListHotelRoomDTO
    {
        public ListHotelRoomDTO() {}

        public ListHotelRoomDTO(int id, int numerohabitaciones, string tipohabitacion, int capacidad, float precio)
        {
            Id = id;
            NumeroHabitaciones = numerohabitaciones;
            TipoHabitacion = tipohabitacion;
            Capacidad = capacidad;
            Precio = precio;
        }

        public int Id { get; set; }

        public int NumeroHabitaciones { get; set; }

        public string TipoHabitacion { get; set; }

        public int Capacidad { get; set; }

        public float Precio { get; set; }
    }
}
