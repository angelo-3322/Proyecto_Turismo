using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Imagen
    {
        [Key]
        public int Id { get; set; }

        public byte[] DatosImagen { get; set; } // Array de bytes para guardar la imagen

        [ForeignKey("HabitacionId")]
        public int IdHabitacion { get; set; }  // Clave foránea
        public Habitacion Habitacion { get; set; }  // Propiedad de navegación
    }
}
