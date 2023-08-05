using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Paquetes
{
    public class ListPackageDTO
    {
        public ListPackageDTO(){}

        public ListPackageDTO(int id, string nombre, float precio, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
        }
        public int Id { get;  set; }
        public string Nombre { get;  set; }
        public string Descripcion { get; set; }
        public float Precio { get;  set; }
    }
}
