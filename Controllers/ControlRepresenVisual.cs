using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Data;

namespace proyectoindicadores2.Controllers
{
    public class ControlRepresenVisual
    {
        private RepresenVisual objRepresenVisual;

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
            // Reemplaza 'nombre' por el campo correspondiente en tu base de datos
            string sql = "INSERT INTO represenvisual (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objRepresenVisual.Id;
            string nombre = objRepresenVisual.Nombre;
            // Reemplaza 'nombre' por el campo correspondiente en tu base de datos
            string sql = "UPDATE represenvisual SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objRepresenVisual.Id;
            string sql = "DELETE FROM represenvisual WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public RepresenVisual[] Listar()
        {
            int n = 0;
            int i = 0;
            RepresenVisual[] arregloRepresenVisual = null;
            string sql = "SELECT * FROM represenvisual";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
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
            string sql = "SELECT * FROM represenvisual WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objRepresenVisual.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objRepresenVisual;
        }
    }
}
