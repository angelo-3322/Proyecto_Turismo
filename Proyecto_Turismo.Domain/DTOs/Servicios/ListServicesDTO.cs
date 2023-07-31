﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Servicios
{
    public class ListServicesDTO
    {
        public ListServicesDTO(int id, string nombre, float precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public float Precio { get; set; }
    }
}
