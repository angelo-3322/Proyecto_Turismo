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
        public string Nombre { get;  set; }

        [StringLength(30, MinimumLength = 7)]
        public string Descripcion { get;  set; }

        [Required]
        public float Precio { get;  set; }

        [Required]
        [ForeignKey("Menu")]
        public int IdMenu { get;  set; }
        public Menu menu { get;   set; }
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
