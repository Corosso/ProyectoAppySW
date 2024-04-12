using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace proyectoindicadores2.Controllers
{
    public class ControlConexion
    {
        // Declaración de variables de clase
        String cadenaConexion;
        SqlConnection objSqlConnection;

        // Constructor por defecto
        public ControlConexion()
        {
            cadenaConexion = null;
            objSqlConnection = null;
        }

        // Constructor con un parámetro para especificar la base de datos a la que conectarse
        public ControlConexion(String baseDeDatos)
        {
            // Se construye la cadena de conexión utilizando la base de datos especificada
            this.cadenaConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\" + baseDeDatos + ";Integrated Security = True";

            // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
            objSqlConnection = new SqlConnection(cadenaConexion);
        }

        // Método para abrir la conexión a la base de datos
        public String abrirBD()
        {
            String msg = "ok";
            try
            {
                // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                objSqlConnection = new SqlConnection(cadenaConexion);
                // Se abre la conexión a la base de datos
                objSqlConnection.Open();
            }
            catch (Exception Ex)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Ex.Message;
            }
            return msg;
        }

        // Método para cerrar la conexión a la base de datos
        public String cerrarBD()
        {
            String msg = "ok";
            try
            {
                // Se cierra la conexión a la base de datos
                objSqlConnection.Close();
            }
            catch (Exception Ex)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Ex.Message;
            }
            return msg;
        }

        // Método para ejecutar un comando SQL en la base de datos
        public String ejecutarComandoSQL(String comandoSql)
        {
            String msg = "ok";
            try
            {
                // Se crea un nuevo SqlCommand utilizando el comando SQL y la conexión a la base de datos
                SqlCommand sqlComando = new SqlCommand(comandoSql, objSqlConnection);
                // Se ejecuta el comando SQL en la base de datos
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Ex.Message;
            }
            return msg;
        }

        // Método para ejecutar una consulta SQL en la base de datos y devolver un DataSet
        public DataSet ejecutarConsultaSql(String comandoSql)
        {
            String msg = "ok";
            DataSet objDataSet = new DataSet();

            try
            {
                // Se crea un nuevo SqlDataAdapter utilizando la consulta SQL y la conexión a la base de datos
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comandoSql, objSqlConnection);
                // Se llena el DataSet con los resultados de la consulta SQL
                sqlDataAdap.Fill(objDataSet);
            }
            catch (Exception Exc)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Exc.Message;
            }
            return objDataSet;
        }
    }

}