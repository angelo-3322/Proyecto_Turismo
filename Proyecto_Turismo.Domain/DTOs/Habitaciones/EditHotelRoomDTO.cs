using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Habitaciones
{
    public class EditHotelRoomDTO
    {
        public EditHotelRoomDTO(){ }

        public EditHotelRoomDTO(int id, int numeroHabitacion, string tipoHabitacion, int capacidad, float precio)
            :this()
        {
            Id = id;
            NumeroHabitaciones = numeroHabitacion;
            TipoHabitacion = tipoHabitacion;
            Capacidad = capacidad;
            Precio = precio;   
        }

        public int Id { get; set; }


        public int NumeroHabitaciones { get; private set; }


        public string TipoHabitacion { get; private set; }

        public int Capacidad { get; private set; }

        public float Precio { get; private set; }
    }
}
