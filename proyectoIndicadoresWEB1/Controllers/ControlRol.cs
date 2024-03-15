using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlRol
    {
        Rol objRol;

        public ControlRol(Rol objRol)
        {
            this.objRol = objRol;
        }

        public ControlRol()
        {
            this.objRol = null;
        }

        public void Guardar()
        {
            string nombre = objRol.Nombre;
            string sql = "INSERT INTO rol (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objRol.Id;
            string nombre = objRol.Nombre;
            string sql = "UPDATE rol SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objRol.Id;
            string sql = "DELETE FROM rol WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public Rol[] Listar()
        {
            int n = 0;
            int i = 0;
            Rol[] arregloRol = null;
            string sql = "SELECT * FROM rol";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloRol = new Rol[n];
            while (i < n)
            {
                Rol objRol = new Rol();
                objRol.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objRol.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloRol[i] = objRol;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloRol;
        }

        public Rol Consultar()
        {
            int id = objRol.Id;
            string sql = "SELECT * FROM rol WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objRol.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objRol;
        }
    }
}