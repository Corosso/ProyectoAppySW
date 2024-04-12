using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Data;

namespace proyectoindicadores2.Controllers
{
    public class ControlSentido
    {
        private Sentido objSentido;

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
            string sql = "INSERT INTO sentido (Nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objSentido.Id;
            string nombre = objSentido.Nombre;
            string sql = "UPDATE sentido SET Nombre='" + nombre + "' WHERE Id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objSentido.Id;
            string sql = "DELETE FROM sentido WHERE Id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
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
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloSentido = new Sentido[n];
            while (i < n)
            {
                Sentido objSentido = new Sentido();
                objSentido.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["Id"]);
                objSentido.Nombre = objDataset.Tables[0].Rows[i]["Nombre"].ToString();
                arregloSentido[i] = objSentido;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloSentido;
        }

        public Sentido Consultar()
        {
            int id = objSentido.Id;
            string sql = "SELECT * FROM sentido WHERE Id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objSentido.Nombre = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
            objControlConexion.cerrarBD();
            return objSentido;
        }
    }
}
