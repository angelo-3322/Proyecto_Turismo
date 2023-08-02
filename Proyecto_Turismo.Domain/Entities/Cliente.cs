using System.ComponentModel.DataAnnotations;


namespace Proyecto_Turismo.Domain.Entities
{
    public class Cliente
    {
        public Cliente() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required, EmailAddress]
        [StringLength(30, MinimumLength = 10)]
        public string Email { get; private set; }

        [Required]
        public int Telefono { get; private set; }

        public static Cliente Create(string nombre, string email, int telefono)
        {
            return
                new Cliente()
                {
                    Nombre = nombre,
                    Email = email,
                    Telefono = telefono
                };
        }
    }
}
