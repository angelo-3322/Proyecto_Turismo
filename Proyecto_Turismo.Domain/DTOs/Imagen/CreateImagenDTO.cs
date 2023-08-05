using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Turismo.Domain.DTOs.Imagen
{
    public class CreateImagenDTO
    {
        public CreateImagenDTO() { }

        public int Id { get; set; }

        public byte[] DatosImagen { get; set; }

        [ForeignKey("HabitacionId")]
        public int IdHabitacion { get; set; }
    }
}
