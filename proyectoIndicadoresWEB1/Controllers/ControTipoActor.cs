using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlTipoActor
    {
        TipoActor objTipoActor;

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
            string sql = "INSERT INTO tipoActor (nombre) VALUES ('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objTipoActor.Id;
            string nombre = objTipoActor.Nombre;
            string sql = "UPDATE tipoActor SET nombre='" + nombre + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objTipoActor.Id;
            string sql = "DELETE FROM tipoActor WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public TipoActor[] Listar()
        {
            int n = 0;
            int i = 0;
            TipoActor[] arregloTipoActor = null;
            string sql = "SELECT * FROM tipoActor";
        }