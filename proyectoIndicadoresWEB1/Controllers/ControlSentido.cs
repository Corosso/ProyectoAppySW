using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlSentido
    {
        Sentido objSentido;

        public ControlSentido(Sentido objSentido)
        {
            this.objSentido = objSentido;
        }

        public ControlSentido()
        {
            this.objSentido = null;
        }

        public void Guardar()
        {
            string nombre = objSentido.Nombre;
            string sql = "INSERT INTO sentido (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objSentido.Id;
            string nombre = objSentido.Nombre;
            string sql = "UPDATE sentido SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objSentido.Id;
            string sql = "DELETE FROM sentido WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public Sentido[] Listar()
        {
            int n = 0;
            int i = 0;
            Sentido[] arregloSentido = null;
            string sql = "SELECT * FROM sentido";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloSentido = new Sentido[n];
            while (i < n)
            {
                Sentido objSentido = new Sentido();
                objSentido.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objSentido.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloSentido[i] = objSentido;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloSentido;
        }

        public Sentido Consultar()
        {
            int id = objSentido.Id;
            string sql = "SELECT * FROM sentido WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objSentido.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objSentido;
        }
    }
}