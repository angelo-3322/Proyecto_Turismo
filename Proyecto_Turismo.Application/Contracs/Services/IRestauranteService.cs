using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IRestauranteService
    {
        EditRestaurantDTO Get(int id);

        IEnumerable<ListRestaurantDTO> GetAll();

        Result<int> Create(CreateRestaurantDTO dto);

        Result Edit(EditRestaurantDTO dto);

        Result Delete(int id);
    }
}
