using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlRepresenVisual
    {
        RepresenVisual objRepresenVisual;

        public ControlRepresenVisual(RepresenVisual objRepresenVisual)
        {
            this.objRepresenVisual = objRepresenVisual;
        }

        public ControlRepresenVisual()
        {
            this.objRepresenVisual = null;
        }

        public void Guardar()
        {
            string nombre = objRepresenVisual.Nombre;
            string sql = "INSERT INTO represenVisual (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objRepresenVisual.Id;
            string nombre = objRepresenVisual.Nombre;
            string sql = "UPDATE represenVisual SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objRepresenVisual.Id;
            string sql = "DELETE FROM represenVisual WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public RepresenVisual[] Listar()
        {
            int n = 0;
            int i = 0;
            RepresenVisual[] arregloRepresenVisual = null;
            string sql = "SELECT * FROM represenVisual";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloRepresenVisual = new RepresenVisual[n];
            while (i < n)
            {
                RepresenVisual objRepresenVisual = new RepresenVisual();
                objRepresenVisual.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objRepresenVisual.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloRepresenVisual[i] = objRepresenVisual;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloRepresenVisual;
        }

        public RepresenVisual Consultar()
        {
            int id = objRepresenVisual.Id;
            string sql = "SELECT * FROM represenVisual WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objRepresenVisual.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objRepresenVisual;
        }
    }
}