using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
namespace proyectoindicadores2
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Usar ControlEntidad para validar las credenciales del usuario
            ControlEntidad controlEntidad = new ControlEntidad("usuario"); 
            Entidad usuarioValidado = controlEntidad.ValidarIngreso(email, contrasena);

            if (usuarioValidado != null)
            {
                // Si el usuario es validado correctamente, almacena su información relevante en la sesión
                Session["email"] = usuarioValidado["email"];  // Asegúrate de que 'Email' es la clave correcta en tus propiedades de Entidad

                ControlEntidad controlRoles = new ControlEntidad("rol");
                List<Entidad> rolesUsuario = controlRoles.Listar();
                Session["arregloRolesUsuario"] = rolesUsuario;

                Response.Redirect("FrmMenu.aspx");
            }
            else
            {
                // Si las credenciales son incorrectas, redirige al usuario de vuelta al formulario de login
                //lblError.Text = "Email o contraseña inválidos. Intente de nuevo.";  // Asegúrate de tener un Label para errores en tu formulario
                                                                                    // Response.Redirect("FrmLogin.aspx"); // Puedes elegir redirigir o simplemente mostrar el mensaje de error
            }
        }

    }
}