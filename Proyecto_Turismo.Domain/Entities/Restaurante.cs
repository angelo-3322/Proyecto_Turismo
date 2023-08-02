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
        public string Nombre { get; private set; }

        [ForeignKey("Menu")]
        public int IdMenu { get; private set; }

        public Menu menu { get; private set; }

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
