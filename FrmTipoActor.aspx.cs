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
    public partial class FrmTipoActor : System.Web.UI.Page
    {
        protected TipoActor[] arregloTiposActor = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoActor objControlTipoActor = new ControlTipoActor();
            arregloTiposActor = objControlTipoActor.Listar();
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre.Text;
            TipoActor objTipoActor = new TipoActor(0, nombre);
            ControlTipoActor objControlTipoActor = new ControlTipoActor();
            objControlTipoActor.Guardar();

            Response.Redirect("FrmTipoActor.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoActor objTipoActor = new TipoActor(id, "");
            ControlTipoActor objControlTipoActor = new ControlTipoActor();
            objTipoActor = objControlTipoActor.Consultar();
            txtNombre.Text = objTipoActor.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            TipoActor objTipoActor = new TipoActor(id, nombre);
            ControlTipoActor objControlTipoActor = new ControlTipoActor();
            objControlTipoActor.Modificar();
            Response.Redirect("FrmTipoActor.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoActor objTipoActor = new TipoActor(id, "");
            ControlTipoActor objControlTipoActor = new ControlTipoActor();
            objControlTipoActor.Borrar();
            Response.Redirect("FrmTipoActor.aspx");
        }
    }
}
