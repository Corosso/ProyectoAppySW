using proyectoindicadores2.Models;
using System;
using System.Data;

namespace proyectoindicadores2.Controllers
{
    public class ControlFuentesPorIndicador
    {
        FuentesPorIndicador objFuentesPorIndicador;

        public ControlFuentesPorIndicador(FuentesPorIndicador objFuentesPorIndicador)
        {
            this.objFuentesPorIndicador = objFuentesPorIndicador;
        }

        public ControlFuentesPorIndicador()
        {
            this.objFuentesPorIndicador = null;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int fkIdFuente = objFuentesPorIndicador.FkIdFuente;
            int fkIdIndicador = objFuentesPorIndicador.FkIdIndicador;
            string comandoSQL = String.Format("INSERT INTO FuentesPorIndicador (fkidfuente, fkidindicador) VALUES ({0}, {1})", fkIdFuente, fkIdIndicador);
            string msg = "ok";
            try
            {
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

        public FuentesPorIndicador[] Listar(int idIndicador)
        {
            FuentesPorIndicador[] arregloFuentesPorIndicador = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = String.Format("SELECT * FROM FuentesPorIndicador WHERE fkidindicador = {0}", idIndicador);
            try
            {
                objControlConexion.abrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloFuentesPorIndicador = new FuentesPorIndicador[objDataSet.Tables[0].Rows.Count];
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        FuentesPorIndicador fuentesPorIndicador = new FuentesPorIndicador();
                        fuentesPorIndicador.FkIdFuente = Convert.ToInt32(objDataSet.Tables[0].Rows[i]["fkidfuente"]);
                        fuentesPorIndicador.FkIdIndicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i]["fkidindicador"]);
                        arregloFuentesPorIndicador[i] = fuentesPorIndicador;
                    }
                }
                objControlConexion.cerrarBD();
            }
            catch (Exception)
            {
                // Manejo de excepciones
            }
            return arregloFuentesPorIndicador;
        }
    }
}
