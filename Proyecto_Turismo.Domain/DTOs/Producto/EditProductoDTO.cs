using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Producto
{
    public class EditProductoDTO
    {
        public EditProductoDTO() { }

        public EditProductoDTO(int id, string nombre, string descripcion, float precio,int menus)
            : this()
        {

            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            IdMenu = menus;

        }
        public int Id { get;  set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Nombre { get; set; }

        [StringLength(30, MinimumLength = 7)]
        public string Descripcion { get; set; }

        [Required]
        public float Precio { get; set; }

        [Required]
        [ForeignKey("Menu")]
        public int IdMenu { get; set; }

    }
}
