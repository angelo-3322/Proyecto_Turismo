using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Cuenta
    {
        public Cuenta() { }

        [Key]   
        public int Id { get; private set; }

        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; private set; }

        public Cliente Cliente { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Usuario { get; private set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Contrasena { get; private set; }

        public static Cuenta Create(int idCliente, string usuario, string contrasena)
        {
            return
                new Cuenta()
                {
                    IdCliente = idCliente,
                    Usuario = usuario,
                    Contrasena = contrasena
                };
        }
    }
}
