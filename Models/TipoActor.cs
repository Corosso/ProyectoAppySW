using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Models
{
    public class TipoActor
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public TipoActor(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public TipoActor()
        {
            Id = 0;
            Nombre = "";
        }
    }

}