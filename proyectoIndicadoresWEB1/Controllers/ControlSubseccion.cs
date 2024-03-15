using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlSubseccion
    {
        Subseccion objSubseccion;

        public ControlSubseccion(Subseccion objSubseccion)
        {
            this.objSubseccion = objSubseccion;
        }

        public ControlSubseccion()
        {
            this.objSubseccion = null;
        }

        public void Guardar()
        {
            string nombre = objSubseccion.Nombre;
            string sql = "INSERT INTO subseccion (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objSubseccion.Id;
            string nombre = objSubseccion.Nombre;
            string sql = "UPDATE subseccion SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objSubseccion.Id;
            string sql = "DELETE FROM subseccion WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public Subseccion[] Listar()
        {
            int n = 0;
            int i = 0;
            Subseccion[] arregloSubseccion = null;
            string sql = "SELECT * FROM subseccion";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloSubseccion = new Subseccion[n];
            while (i < n)
            {
                Subseccion objSubseccion = new Subseccion();
                objSubseccion.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objSubseccion.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloSubseccion[i] = objSubseccion;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloSubseccion;
        }

        public Subseccion Consultar()
        {
            int id = objSubseccion.Id;
            string sql = "SELECT * FROM subseccion WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objSubseccion.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objSubseccion;
        }
    }
}