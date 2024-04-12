using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Web.UI.WebControls;

namespace proyectoindicadores2
{
    public partial class FrmRepresenVisual : System.Web.UI.Page
    {
        protected RepresenVisual[] arregloRepresenVisual = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(null);
            arregloRepresenVisual = objControlRepresenVisual.Listar();
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(0, nombre);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.Guardar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(id, nombre);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objRepresenVisual = objControlRepresenVisual.Consultar();
            txtNombre.Text = objRepresenVisual.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(id, nombre);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.Modificar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            RepresenVisual objRepresenVisual = new RepresenVisual(id, "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.Borrar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }
    }
}
