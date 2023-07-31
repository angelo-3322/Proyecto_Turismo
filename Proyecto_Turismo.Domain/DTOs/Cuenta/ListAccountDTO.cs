using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cuenta
{
    public class ListAccountDTO
    {
        public ListAccountDTO() { }

        public ListAccountDTO(int id, string cliente, string usuario, string contrasena)
        {
            Id = id;
            Cliente = cliente;
            Usuario = usuario;
            Contrasena = contrasena;
        }

        public int Id { get; set; }

        public string Cliente { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }
    }
}
