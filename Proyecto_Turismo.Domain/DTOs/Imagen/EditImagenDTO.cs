using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Imagen
{
    public class EditImagenDTO
    {
        public EditImagenDTO() { }

        public EditImagenDTO(int id, byte[] datosImagen)
            : this()
        {
            Id = id;
            DatosImagen = datosImagen;
        }
        public int Id { get; set; } 

        public byte[] DatosImagen { get; set; }
    }
}
