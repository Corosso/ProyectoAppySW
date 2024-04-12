using proyectoindicadores2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Controllers
{
    public class ControlUnidadMedicion
    {
        UnidadMedicion objUnidadMedicion;

        public ControlUnidadMedicion(UnidadMedicion objUnidadMedicion)
        {
            this.objUnidadMedicion = objUnidadMedicion;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            string msg = "ok";

            try
            {
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string descripcion = objUnidadMedicion.Descripcion;
                string comandoSQL = $"INSERT INTO unidadmedicion(descripcion) VALUES('{descripcion}')";

                objControlConexion.abrirBD();
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }

            return msg;
        }

        public UnidadMedicion[] Listar()
        {
            UnidadMedicion[] arregloUnidadesMedicion = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            string msg = "ok";

            try
            {
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string comandoSQL = "SELECT * FROM unidadmedicion";

                objControlConexion.abrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloUnidadesMedicion = new UnidadMedicion[objDataSet.Tables[0].Rows.Count];

                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        UnidadMedicion objUnidadMedicion = new UnidadMedicion();
                        objUnidadMedicion.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i]["id"]);
                        objUnidadMedicion.Descripcion = objDataSet.Tables[0].Rows[i]["descripcion"].ToString();

                        arregloUnidadesMedicion[i] = objUnidadMedicion;
                    }
                }

                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }

            return arregloUnidadesMedicion;
        }

        public string Modificar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            string msg = "ok";

            try
            {
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                int id = objUnidadMedicion.Id;
                string descripcion = objUnidadMedicion.Descripcion;
                string comandoSQL = $"UPDATE unidadmedicion SET descripcion='{descripcion}' WHERE id={id}";

                objControlConexion.abrirBD();
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }

            return msg;
        }

        public string Borrar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            string msg = "ok";

            try
            {
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                int id = objUnidadMedicion.Id;
                string comandoSQL = $"DELETE FROM unidadmedicion WHERE id={id}";

                objControlConexion.abrirBD();
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }

            return msg;
        }

        public UnidadMedicion Consultar()
        {
            UnidadMedicion objUnidadMedicionConsulta = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";

            try
            {
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                int id = objUnidadMedicion.Id;
                string comandoSQL = $"SELECT * FROM unidadmedicion WHERE id={id}";

                objControlConexion.abrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUnidadMedicionConsulta = new UnidadMedicion();
                    objUnidadMedicionConsulta.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0]["id"]);
                    objUnidadMedicionConsulta.Descripcion = objDataSet.Tables[0].Rows[0]["descripcion"].ToString();
                }

                objControlConexion.cerrarBD();
            }
            catch (Exception)
            {
                // Manejar la excepción si es necesario
            }

            return objUnidadMedicionConsulta;
        }
    }
}
