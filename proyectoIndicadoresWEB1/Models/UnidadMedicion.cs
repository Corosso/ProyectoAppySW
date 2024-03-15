using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Models
{
    public class UnidadMedicion
    {
        private int id;
        private string descripcion;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public UnidadMedicion(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public UnidadMedicion()
        {
            this.Id = 0;
            this.Descripcion = "";
        }
    }
}