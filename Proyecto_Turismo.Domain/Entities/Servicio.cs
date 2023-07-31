using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Servicio
    {
        public Servicio() {}

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required]
        public float Precio { get; private set; }

        public static Servicio Create(string nombre, float precio)
        {
            return
                new Servicio()
                {
                    Nombre = nombre,
                    Precio = precio
                };
        }
    }
}
