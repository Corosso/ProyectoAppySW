using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Web.UI.WebControls;

namespace proyectoindicadores2
{
    public partial class FrmFuente : System.Web.UI.Page
    {
        protected Fuente[] arregloFuentes = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFuente objControlFuente = new ControlFuente(null);
            arregloFuentes = objControlFuente.Listar();
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre.Text;
            Fuente objFuente = new Fuente(0, nombre);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.Guardar();
            Response.Redirect("FrmFuente.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            Fuente objFuente = new Fuente(id, nombre);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objFuente = objControlFuente.Consultar();
            txtNombre.Text = objFuente.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            Fuente objFuente = new Fuente(id, nombre);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.Modificar();
            Response.Redirect("FrmFuente.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.Borrar();
            Response.Redirect("FrmFuente.aspx");
        }
    }
}
