using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Models
{
    public class Seccion
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Seccion(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Seccion()
        {
            this.Id = 0;
            this.Nombre = "";
        }
    }
}