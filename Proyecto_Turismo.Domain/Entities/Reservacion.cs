using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Proyecto_Turismo.Domain.Entities
{
    public class Reservacion
    {
        public Reservacion() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [ForeignKey("Habitacion")]
        public int IdHabitaciones { get; set; }

        public Habitacion Habitacion { get; private set; }


        [Required]
        [ForeignKey("Paquete")]
        public int IdPaquete { get; set; }

        public Paquete Paquete { get; private set; }


        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; private set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public bool Activa { get; set; }

        public static Reservacion Create(int idhabitaciones, int idpaquete, int idcliente, DateTime fechainicio, DateTime fechafin)
        {
            return
                new Reservacion()
                {
                    IdHabitaciones = idhabitaciones,
                    IdPaquete = idpaquete,
                    IdCliente = idcliente,
                    FechaInicio = fechainicio,
                    FechaFin = fechafin,
                    Activa = true
                };
        }
    }
}
