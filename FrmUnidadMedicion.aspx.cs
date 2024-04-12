using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectoindicadores2
{
    public partial class FrmUnidadMedicion : System.Web.UI.Page
    {
        protected UnidadMedicion[] arregloUnidadesMedicion = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(null);
            arregloUnidadesMedicion = objControlUnidadMedicion.Listar();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            UnidadMedicion unidadMedicion = new UnidadMedicion(0, descripcion);
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(unidadMedicion);
            string msg = objControlUnidadMedicion.Guardar();
            Response.Redirect("FrmUnidadMedicion.aspx");
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string descripcion = txtDescripcion.Text;
            UnidadMedicion unidadMedicion = new UnidadMedicion(id, descripcion);
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(unidadMedicion);
            unidadMedicion = objControlUnidadMedicion.Consultar();
            txtDescripcion.Text = unidadMedicion.Descripcion;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string descripcion = txtDescripcion.Text;
            UnidadMedicion unidadMedicion = new UnidadMedicion(id, descripcion);
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(unidadMedicion);
            objControlUnidadMedicion.Modificar();
            Response.Redirect("FrmUnidadMedicion.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            UnidadMedicion unidadMedicion = new UnidadMedicion(id, "");
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(unidadMedicion);
            objControlUnidadMedicion.Borrar();
            Response.Redirect("FrmUnidadMedicion.aspx");
        }
    }
}
