using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Imagen
{
    public class ListImagenDTO
    {
        public ListImagenDTO() { }

        public ListImagenDTO(int id, byte[] datosImagen,int idhabitacion)
        {
            Id = id;
            DatosImagen = datosImagen;
            IdHabitacion = idhabitacion;
        }

        public int Id { get; set; }

        public byte[] DatosImagen { get; set; } 

        [ForeignKey("HabitacionId")]
        public int IdHabitacion { get; set; } 
    }
}
