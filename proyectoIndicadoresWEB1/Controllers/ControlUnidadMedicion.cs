using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoIndicadoresWEB1.Controllers
{
    public class ControlUnidadMedicion
    {
        UnidadMedicion objUnidadMedicion;

        public ControlUnidadMedicion(UnidadMedicion objUnidadMedicion)
        {
            this.objUnidadMedicion = objUnidadMedicion;
        }

        public ControlUnidadMedicion()
        {
            this.objUnidadMedicion = null;
        }

        public void Guardar()
        {
            string descripcion = objUnidadMedicion.Descripcion;
            string sql = "INSERT INTO unidadMedicion (descripcion) VALUES ('" + descripcion + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Modificar()
        {
            int id = objUnidadMedicion.Id;
            string descripcion = objUnidadMedicion.Descripcion;
            string sql = "UPDATE unidadMedicion SET descripcion='" + descripcion + "' WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public void Borrar()
        {
            int id = objUnidadMedicion.Id;
            string sql = "DELETE FROM unidadMedicion WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }

        public UnidadMedicion[] Listar()
    }