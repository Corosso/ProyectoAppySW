using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Models
{
    public class Usuario
    {
        string email;
        string contrasena;

        public string Email { get => email; set => email = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }

        public Usuario(string email, string contrasena)
        {
            this.email = email;
            this.contrasena = contrasena;
        }
        public Usuario()
        {
            this.email = "";
            this.contrasena = "";
        }
    }
}