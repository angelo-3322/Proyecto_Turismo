using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cliente
{
    public class ListClienteDTO
    {
        public ListClienteDTO() {}

        public ListClienteDTO(int id, string nombre, string email, int telefono)
        {

            Id = id;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;

        }

        public int Id { get;  set; }

        public string Nombre { get;  set; }


        public string Email { get;  set; }

        public int Telefono { get;  set; }
    }
}
