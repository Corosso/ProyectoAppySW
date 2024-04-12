using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Models
{
    public class Rol
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Rol(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public Rol()
        {
            this.id = 0;
            this.nombre = "";
        }
    }
}