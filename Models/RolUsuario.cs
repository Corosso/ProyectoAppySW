using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Models
{
    public class RolUsuario
    {
        private string fkEmail;
        private int fkIdRol;

        public string FkEmail { get => fkEmail; set => fkEmail = value; }
        public int FkIdRol { get => fkIdRol; set => fkIdRol = value; }

        public RolUsuario(string fkEmail, int fkIdRol)
        {
            this.fkEmail = fkEmail;
            this.fkIdRol = fkIdRol;
        }
        public RolUsuario()
        {
            this.fkEmail = "";
            this.fkIdRol = 0;
        }
    }
}