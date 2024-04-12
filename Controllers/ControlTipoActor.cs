using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Data;

namespace proyectoindicadores2.Controllers
{
    public class ControlTipoActor
    {
        private TipoActor objTipoActor;

        public ControlTipoActor(TipoActor objTipoActor)
        {
            this.objTipoActor = objTipoActor;
        }

        public ControlTipoActor()
        {
            this.objTipoActor = null;
        }

        public void Guardar()
        {
            string nombre = objTipoActor.Nombre;
            string sql = "INSERT INTO TipoActor (Nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objTipoActor.Id;
            string nombre = objTipoActor.Nombre;
            string sql = "UPDATE TipoActor SET Nombre='" + nombre + "' WHERE Id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objTipoActor.Id;
            string sql = "DELETE FROM TipoActor WHERE Id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public TipoActor[] Listar()
        {
            int n = 0;
            int i = 0;
            TipoActor[] arregloTipoActor = null;
            string sql = "SELECT * FROM TipoActor";
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloTipoActor = new TipoActor[n];
            while (i < n)
            {
                TipoActor objTipoActor = new TipoActor();
                objTipoActor.Id = Convert.ToInt32(objDataset.Tables[0].Rows[i]["Id"]);
                objTipoActor.Nombre = objDataset.Tables[0].Rows[i]["Nombre"].ToString();
                arregloTipoActor[i] = objTipoActor;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloTipoActor;
        }

        public TipoActor Consultar()
        {
            int id = objTipoActor.Id;
            string sql = "SELECT * FROM TipoActor WHERE Id=" + id;
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objTipoActor.Nombre = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
            objControlConexion.cerrarBD();
            return objTipoActor;
        }
    }
}
