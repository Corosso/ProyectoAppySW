using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Models
{
    public class Subseccion
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Subseccion(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Subseccion()
        {
            this.Id = 0;
            this.Nombre = "";
        }
    }
}