using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Habitacion
    {
        public Habitacion() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int NumeroHabitaciones { get; private set; }

        [Required]
        [StringLength(20,MinimumLength = 2)]
        public string TipoHabitacion { get; private set; }

        [Required]
        public int Capacidad { get; private set; }

        [Required]
        public float Precio { get; private set; }

        [Required]
        public bool Disponible { get; private set; }

        public ICollection<Imagen> Imagenes { get; set; } = new List<Imagen>();

        public static Habitacion Create(int numerohabitaciones, string tipohabitacion, int capacidad,float precio, bool disponible, List<byte[]> imagenes)
        {
            var habitacion =
                new Habitacion()
                {
                    NumeroHabitaciones = numerohabitaciones,
                    TipoHabitacion = tipohabitacion,
                    Capacidad = capacidad,
                    Precio = precio,
                    Disponible = disponible,
                    Imagenes = new List<Imagen>()
                };
            
            foreach (var imagen in imagenes)
            {
                habitacion.Imagenes.Add(new Imagen { DatosImagen = imagen });
            }

            return habitacion;
        }

        public void Update(int numerohabitaciones, string tipohabitacion, int capacidad, float precio, bool disponble)
        {
            NumeroHabitaciones = numerohabitaciones;
            TipoHabitacion = tipohabitacion;
            Capacidad = capacidad;
            Precio = precio;
            Disponible = disponble;

        }
    }
}
