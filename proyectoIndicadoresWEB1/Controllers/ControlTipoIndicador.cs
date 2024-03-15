using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlTipoIndicador
    {
        TipoIndicador objTipoIndicador;

        public ControlTipoIndicador(TipoIndicador objTipoIndicador)
        {
            this.objTipoIndicador = objTipoIndicador;
        }

        public ControlTipoIndicador()
        {
            this.objTipoIndicador = null;
        }

        public void Guardar()
        {
            string nombre = objTipoIndicador.Nombre;
            string sql = "INSERT INTO tipoIndicador (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objTipoIndicador.Id;
            string nombre = objTipoIndicador.Nombre;
            string sql = "UPDATE tipoIndicador SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objTipoIndicador.Id;
            string sql = "DELETE FROM tipoIndicador WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public TipoIndicador[] Listar()
        {
            int n = 0;
            int i = 0;
            TipoIndicador[] arregloTipoIndicador = null;
            string sql = "SELECT * FROM tipoIndicador";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloTipoIndicador = new TipoIndicador[n];
            while (i < n)
            {
                TipoIndicador objTipoIndicador = new TipoIndicador();
                objTipoIndicador.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objTipoIndicador.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloTipoIndicador[i] = objTipoIndicador;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloTipoIndicador;
        }

        public TipoIndicador Consultar()
        {
            int id = objTipoIndicador.Id;
            string sql = "SELECT * FROM tipoIndicador WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objTipoIndicador.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objTipoIndicador;
        }
    }
}