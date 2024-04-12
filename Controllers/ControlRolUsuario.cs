using proyectoindicadores2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace proyectoindicadores2.Controllers
{

    public class ControlRolUsuario
    {
        RolUsuario objRolUsuario;

        public ControlRolUsuario(RolUsuario objRolUsuario)
        {
            this.objRolUsuario = objRolUsuario;
        }
        public string guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string fkemail = objRolUsuario.FkEmail;
            int fkidrol = objRolUsuario.FkIdRol;
            string comandoSQL = String.Format("INSERT INTO rol_usuario(fkemail,fkidrol) VALUES('{0}',{1})", fkemail, fkidrol);
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
        public RolUsuario[] listar(string email)
        {
            RolUsuario[] arregloRolUsuario = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = String.Format("SELECT * FROM rol_usuario WHERE fkemail='{0}'",email);
            string msg = "ok";
            int i;
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRolUsuario = new RolUsuario[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        RolUsuario objRolUsuario = new RolUsuario();
                        objRolUsuario.FkEmail= objDataSet.Tables[0].Rows[i][0].ToString();
                        objRolUsuario.FkIdRol = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());

                        arregloRolUsuario[i] = objRolUsuario;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }

            return arregloRolUsuario;
        }
    }

}