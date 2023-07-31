using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cuenta
{
    public class EditAccountDTO
    {
        public EditAccountDTO(){}

        public EditAccountDTO(int id, string usuario,string contrasena)
            :this()
        {
            Id = id;
            Usuario = usuario;
            Contrasena = contrasena;
        }

        public int Id { get; private set; }

        public string Usuario { get; private set; }

        public string Contrasena { get; private set; }
    }
}
