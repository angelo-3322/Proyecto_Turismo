using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Facturas
{
    public class ListFactureDTO
    {
        public ListFactureDTO() {}

        public ListFactureDTO(int id, string reservacion, string fechaEmision, float monto)
        {
            Id = id;
            Reservacion = reservacion;
            FechaEmision = fechaEmision;
            Monto = monto;
            
        }

        public int Id { get; set; }

        public string Reservacion { get;  set; }

        public string FechaEmision { get;  set; }

        public float Monto { get;  set; }
    }
}
