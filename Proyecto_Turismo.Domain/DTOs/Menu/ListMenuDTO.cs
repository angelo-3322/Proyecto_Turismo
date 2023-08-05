

namespace Proyecto_Turismo.Domain.DTOs.Menu
{
    public class ListMenuDTO
    {
        public ListMenuDTO() {}

        public ListMenuDTO(int id, string nombre)
        {

            Id = id;
            Nombre = nombre;
        }

        public int Id { get;  set; } 

        public string Nombre { get;  set; }

    }
}
