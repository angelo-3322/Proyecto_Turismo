using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Restaurante
    {
        public Restaurante() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Nombre { get; set; }

        [ForeignKey("Menu")]
        public int IdMenu { get; set; }

        public Menu Menu { get; private set; }

        public static Restaurante Create(string nombre,int idmenu)
        {
            return
                new Restaurante()
                {
                    Nombre = nombre,
                    IdMenu = idmenu
                };
        }
    }
}
