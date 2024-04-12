using proyectoindicadores2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Controllers
{
    public class ControlUsuario
    {
        Usuario objUsuario;
        public ControlUsuario(Usuario objUsuario)
        {
            this.objUsuario = objUsuario;
        }
        public Usuario[] listar()
        {
            Usuario[] arregloUsuario = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM Usuario";
            string msg = "ok";
            int i;
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloUsuario = new Usuario[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objUsuario = new Usuario();
                        objUsuario.Email = objDataSet.Tables[0].Rows[i][0].ToString();
                        objUsuario.Contrasena = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloUsuario[i] = objUsuario;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloUsuario;
        }
        public bool validarIngreso()
        {
            bool validar = false;
            string ema = objUsuario.Email;
            string con = objUsuario.Contrasena;
            //string comamdoSql = "SELECT * FROM USUARIO WHERE email='"+ema+"' AND contrasena='"+con+"'";
            string comamdoSql = String.Format("SELECT * FROM USUARIO WHERE email='{0}' AND contrasena='{1}'", ema, con);
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comamdoSql);
            if (objDataSet.Tables[0].Rows.Count > 0)
            {
                validar = true;
            }
            objControlConexion.cerrarBD();
            return validar;
        }
        public Usuario consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string comandoSQL = String.Format("SELECT * FROM Usuario WHERE email='{0}'", ema);
            string msg = "ok";
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUsuario.Contrasena = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return this.objUsuario;
        }
        public string guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string con = objUsuario.Contrasena;
            string comandoSQL = String.Format("INSERT INTO usuario(email,contrasena) VALUES('{0}','{1}')", ema, con);
            string msg = "ok";
            objControlConexion.abrirBD();
            try
            {
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return msg;
        }
        public string modificar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string con = objUsuario.Contrasena;
            string comandoSQL = String.Format("UPDATE usuario SET contrasena='{0}' WHERE email='{1}'", con, ema);
            string msg = "ok";
            objControlConexion.abrirBD();
            try
            {
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return msg;
        }
        public string borrar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string comandoSQL = String.Format("DELETE FROM usuario WHERE email='{0}'", ema);
            string msg = "ok";
            objControlConexion.abrirBD();
            try
            {
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return msg;
        }
    }

}