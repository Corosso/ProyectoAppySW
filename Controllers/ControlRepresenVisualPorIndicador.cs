using proyectoindicadores2.Models;
using System;
using System.Data;

namespace proyectoindicadores2.Controllers
{
    public class ControlRepresenVisualPorIndicador
    {
        RepresenVisualPorIndicador objRepresenVisualPorIndicador;

        public ControlRepresenVisualPorIndicador(RepresenVisualPorIndicador objRepresenVisualPorIndicador)
        {
            this.objRepresenVisualPorIndicador = objRepresenVisualPorIndicador;
        }

        public ControlRepresenVisualPorIndicador()
        {
            this.objRepresenVisualPorIndicador = null;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int fkIdIndicador = objRepresenVisualPorIndicador.FkIdIndicador;
            int fkIdRepresenVisual = objRepresenVisualPorIndicador.FkIdRepresenVisual;
            string comandoSQL = String.Format("INSERT INTO RepresenVisualPorIndicador (fkidindicador, fkidrepresenvisual) VALUES ({0}, {1})", fkIdIndicador, fkIdRepresenVisual);
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

        public RepresenVisualPorIndicador[] Listar(int idIndicador)
        {
            RepresenVisualPorIndicador[] arregloRepresenVisualPorIndicador = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = String.Format("SELECT * FROM RepresenVisualPorIndicador WHERE fkidindicador = {0}", idIndicador);
            try
            {
                objControlConexion.abrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloRepresenVisualPorIndicador = new RepresenVisualPorIndicador[objDataSet.Tables[0].Rows.Count];
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        RepresenVisualPorIndicador represenVisualPorIndicador = new RepresenVisualPorIndicador();
                        represenVisualPorIndicador.FkIdIndicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i]["fkidindicador"]);
                        represenVisualPorIndicador.FkIdRepresenVisual = Convert.ToInt32(objDataSet.Tables[0].Rows[i]["fkidrepresenvisual"]);
                        arregloRepresenVisualPorIndicador[i] = represenVisualPorIndicador;
                    }
                }
                objControlConexion.cerrarBD();
            }
            catch (Exception)
            {
                // Manejo de excepciones
            }
            return arregloRepresenVisualPorIndicador;
        }
    }
}
