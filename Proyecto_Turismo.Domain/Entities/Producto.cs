using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Nombre { get; private set; }

        [StringLength(30, MinimumLength = 7)]
        public string Descripcion { get; private set; }

        [Required]
        public float Precio { get; private set; }

        [Required]
        [ForeignKey("Menu")]
        public int IdMenu { get; private set; }
        public Menu menu { get; private set; }
        public static Producto Create(string nombre, string descripcion, float precio,int idmenu)
        {
            return
                new Producto()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio,
                    IdMenu = idmenu
                };
        }
    }
}
