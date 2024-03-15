using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlSeccion
    {
        Seccion objSeccion;

        public ControlSeccion(Seccion objSeccion)
        {
            this.objSeccion = objSeccion;
        }

        public ControlSeccion()
        {
            this.objSeccion = null;
        }

        public void Guardar()
        {
            string nombre = objSeccion.Nombre;
            string sql = "INSERT INTO seccion (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objSeccion.Id;
            string nombre = objSeccion.Nombre;
            string sql = "UPDATE seccion SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objSeccion.Id;
            string sql = "DELETE FROM seccion WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public Seccion[] Listar()
        {
            int n = 0;
            int i = 0;
            Seccion[] arregloSeccion = null;
            string sql = "SELECT * FROM seccion";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloSeccion = new Seccion[n];
            while (i < n)
            {
                Seccion objSeccion = new Seccion();
                objSeccion.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objSeccion.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloSeccion[i] = objSeccion;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloSeccion;
        }

        public Seccion Consultar()
        {
            int id = objSeccion.Id;
            string sql = "SELECT * FROM seccion WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objSeccion.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objSeccion;
        }
    }
}