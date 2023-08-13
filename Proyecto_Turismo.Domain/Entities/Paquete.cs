using System.ComponentModel.DataAnnotations;


namespace Proyecto_Turismo.Domain.Entities
{
    public class Paquete
    {
        public Paquete() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 10)]
        public string Nombre { get; private set; }

        [Required]
        [StringLength(35, MinimumLength = 10)]
        public string Descripcion { get; private set; }

        [Required]
        public float Precio { get; private set; }



        public static Paquete Create(string nombre,string descripcion,float precio)
        {
            return
                new Paquete()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio
                };
        }
        public void Update(string nombre, string descripcion, float precio)
        {
            Nombre = Nombre;
            Descripcion = descripcion;
            Precio = precio;

        }
    }
}
