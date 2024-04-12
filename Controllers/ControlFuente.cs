using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Data;

namespace proyectoindicadores2.Controllers
{
    public class ControlFuente
    {
        private Fuente objFuente;

        public ControlFuente(Fuente objFuente)
        {
            this.objFuente = objFuente;
        }

        public ControlFuente()
        {
            this.objFuente = null;
        }

        public void Guardar()
        {
            string nombre = objFuente.Nombre;
            string sql = "INSERT INTO fuente (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objFuente.Id;
            string nombre = objFuente.Nombre;
            string sql = "UPDATE fuente SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objFuente.Id;
            string sql = "DELETE FROM fuente WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public Fuente[] Listar()
        {
            int n = 0;
            int i = 0;
            Fuente[] arregloFuente = null;
            string sql = "SELECT * FROM fuente";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloFuente = new Fuente[n];
            while (i < n)
            {
                Fuente objFuente = new Fuente();
                objFuente.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["id"]);
                objFuente.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloFuente[i] = objFuente;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloFuente;
        }

        public Fuente Consultar()
        {
            int id = objFuente.Id;
            string sql = "SELECT * FROM fuente WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objFuente.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objFuente;
        }
    }
}
