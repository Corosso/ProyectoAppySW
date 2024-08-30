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
    public partial class FrmRol : System.Web.UI.Page
    {
        protected List<Entidad> arregloEntidades;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            ControlEntidad objControlEntidad = new ControlEntidad("rol");
            arregloEntidades = objControlEntidad.Listar();
            if (!IsPostBack)
            {
                objControlEntidad.controlDeAcceso("email", "arregloRolesUsuario", "FrmLogin.aspx");
            }
        }


        protected void BtnGuardar(object sender, EventArgs e)
        {
            string nom = txtNombre.Text.Trim();
            Dictionary<string, object> propiedades = new Dictionary<string, object> { { "nombre", nom } };
            Entidad entidad = new Entidad(propiedades);
            ControlEntidad controlEntidad = new ControlEntidad("rol");
            string resultado = controlEntidad.Guardar(entidad);
            lblMensaje.Text = resultado;  // Mostrar mensaje de éxito o error
            Response.Redirect("FrmRol.aspx");
        }


        protected void BtnConsultar(object sender, EventArgs e)
        {
            // Asegúrate de que el ID exista y sea numérico
            if (!int.TryParse(txtId.Text, out int id))
            {
                lblMensaje.Text = "ID no válido.";
                return;
            }

            ControlEntidad controlEntidad = new ControlEntidad("rol");
            Entidad entidad = controlEntidad.Consultar("id", id);
            if (entidad != null)
            {
                txtNombre.Text = entidad["nombre"].ToString();
            }
            else
            {
                lblMensaje.Text = "Rol no encontrado.";
            }
        }

        protected void BtnModificar(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                lblMensaje.Text = "ID no válido.";
                return;
            }

            string nom = txtNombre.Text.Trim();
            Dictionary<string, object> propiedades = new Dictionary<string, object> { { "nombre", nom } };
            Entidad entidad = new Entidad(propiedades);
            ControlEntidad controlEntidad = new ControlEntidad("rol");
            string resultado = controlEntidad.Modificar(entidad, "id", id);
            lblMensaje.Text = resultado;  // Mostrar mensaje de éxito o error
            Response.Redirect("FrmRol.aspx");
        }

        protected void BtnBorrar(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                lblMensaje.Text = "ID no válido.";
                return;
            }

            ControlEntidad controlEntidad = new ControlEntidad("rol");
            string resultado = controlEntidad.Borrar("id", id);
            lblMensaje.Text = resultado;  // Mostrar mensaje de éxito o error
            Response.Redirect("FrmRol.aspx");
        }
    }
}
