using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlUsuario
    {
        Usuario objUsuario;

        public ControlUsuario(Usuario objUsuario)
        {
            this.objUsuario = objUsuario;
        }
        public ControlUsuario()
        {
            this.objUsuario = null;
        }
        public void guardar()
        {
            string email = objUsuario.Email;
            string contrasena = objUsuario.Contrasena;
            string sql = "insert into usuario values('" + email + "','" + contrasena + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();

        }
        public void modificar()
        {
            string sql = "UPDATE usuario SET contrasena='" + objUsuario.Contrasena + "' WHERE email='" + objUsuario.Email + "'";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            string email = objUsuario.Email;
            string sql = "DELETE FROM usuario WHERE email='" + objUsuario.Email + "'";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public Usuario[] listar()
        {
            int n = 0;
            int i = 0;
            Usuario[] arregloUsuario = null;
            string sql = "SELECT * FROM usuario";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloUsuario = new Usuario[n];
            while (i < n)
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Email = objDataset.Tables[0].Rows[i]["email"].ToString();
                objUsuario.Contrasena = objDataset.Tables[0].Rows[i]["contrasena"].ToString();
                arregloUsuario[i] = objUsuario;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloUsuario;
        }
        public Usuario consultar()
        {
            string email = objUsuario.Email;
            string sql = "SELECT * FROM usuario WHERE email='" + email + "'";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objUsuario.Contrasena = objDataset.Tables[0].Rows[0]["contrasena"].ToString();
            objControlConexion.cerrarBD();
            return objUsuario;
        }
    }
}