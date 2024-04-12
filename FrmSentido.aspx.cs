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
    public partial class FrmSentido : System.Web.UI.Page
    {
        protected Sentido[] arregloSentidos = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlSentido objControlSentido = new ControlSentido();
            arregloSentidos = objControlSentido.Listar();
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre.Text;
            Sentido objSentido = new Sentido(0, nombre);
            ControlSentido objControlSentido = new ControlSentido();
            objControlSentido.Guardar();

            Response.Redirect("FrmSentido.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Sentido objSentido = new Sentido(id, "");
            ControlSentido objControlSentido = new ControlSentido();
            objSentido = objControlSentido.Consultar();
            txtNombre.Text = objSentido.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            Sentido objSentido = new Sentido(id, nombre);
            ControlSentido objControlSentido = new ControlSentido();
            objControlSentido.Modificar();
            Response.Redirect("FrmSentido.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Sentido objSentido = new Sentido(id, "");
            ControlSentido objControlSentido = new ControlSentido();
            objControlSentido.Borrar();
            Response.Redirect("FrmSentido.aspx");
        }
    }
}
