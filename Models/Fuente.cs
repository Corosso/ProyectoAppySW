using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Models
{
    public class Fuente
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Fuente(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Fuente()
        {
            this.Id = 0;
            this.Nombre = "";
        }
    }
}