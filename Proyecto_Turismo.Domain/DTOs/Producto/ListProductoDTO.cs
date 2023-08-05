using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Producto
{
    public class ListProductoDTO
    {
        public ListProductoDTO() {}

        public ListProductoDTO(int id, string nombre, string descripcion, float precio,int idmenu)
        {

            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            IdMenu = idmenu;

        }
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public float Precio { get; set; }

        [ForeignKey("Menu")]
        public int IdMenu { get; set; }
    }
}
