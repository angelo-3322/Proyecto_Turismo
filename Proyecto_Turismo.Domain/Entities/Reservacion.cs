using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Reservacion
    {
        public Reservacion() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [ForeignKey("Habitaciones")]
        public int IdHabitaciones { get; private set; }


        [Required]
        [ForeignKey("Paquetes")]
        public int IdPaquete { get; private set; }


        [Required]
        [ForeignKey("Clientes")]
        public int IdCliente { get; private set; }

        [Required]
        public DateTime FechaInicio { get; private set; }

        [Required]
        public DateTime FechaFin { get; private set; }

        public static Reservacion Create(int idhabitaciones, int idpaquete, int idcliente, DateTime fechainicio, DateTime fechafin)
        {
            return
                new Reservacion()
                {
                    IdHabitaciones = idhabitaciones,
                    IdPaquete = idpaquete,
                    IdCliente = idcliente,
                    FechaInicio = fechainicio,
                    FechaFin = fechafin
                };
        }
    }
}
