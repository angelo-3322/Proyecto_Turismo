using System.ComponentModel.DataAnnotations;


namespace Proyecto_Turismo.Domain.Entities
{
    public class Menu
    {
        public Menu() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; set; }

        public List<Producto> Productos { get; set; }
        public List<Restaurante> Restaurantes { get; set; }


        public static Menu Create(string nombre)
        {
            return
                new Menu()
                {
                    Nombre = nombre
                };
        }
    }
}
