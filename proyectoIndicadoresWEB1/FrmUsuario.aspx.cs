using proyectoIndicadoresWEB1.Controllers;
using proyectoIndicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectoIndicadoresWEB1
{
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected Usuario[] arregloUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUsuario objControlUsuario = new ControlUsuario();
            arregloUsuario = objControlUsuario.listar();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string email= txtEmail.Text;
            string contrasena=txtContrasena.Text;
            Usuario objUsuario = new Usuario(email, contrasena);
            ControlUsuario objControlUsuario= new ControlUsuario(objUsuario);
            objControlUsuario.guardar();
            Response.Redirect("FrmUsuario.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Usuario objUsuario = new Usuario(email, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            //txtContrasena.Text = objControlUsuario.consultar().Email;
            objUsuario= objControlUsuario.consultar();
            txtContrasena.Text = objUsuario.Contrasena;

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contrasena = txtContrasena.Text;
            Usuario objUsuario = new Usuario(email, contrasena);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.modificar();
            Response.Redirect("FrmUsuario.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Usuario objUsuario = new Usuario(email, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.borrar();
            Response.Redirect("FrmUsuario.aspx");
        }
    }
}