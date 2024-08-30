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
    public partial class FrmUsuarios : System.Web.UI.Page
    {
        protected List<Entidad> arregloEntidades;
        protected List<Entidad> arregloRoles;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlEntidad controlUsuario = new ControlEntidad("usuario");
            arregloEntidades = controlUsuario.Listar();
            if (!IsPostBack)
            {

                controlDeAcceso("email", "arregloRolesUsuario", "FrmLogin.aspx");

                ControlEntidad controlRol = new ControlEntidad("rol");
                arregloRoles = controlRol.Listar();

                comboRoles.Items.Clear();
                foreach (var rol in arregloRoles)
                {
                    string text = $"{rol["id"]} - {rol["nombre"]}";
                    string value = rol["id"].ToString();
                    comboRoles.Items.Add(new ListItem(text, value));
                }
            }
        }
        public string controlDeAcceso(string claveDeSession, string claveArregloRolesUsuario, string paginaRetorno)
        {
            string mensaje = "ok";
            if (HttpContext.Current.Session[claveDeSession] != null)
            {
                try
                {
                    List<Entidad> rolesUsuario = (List<Entidad>)HttpContext.Current.Session[claveArregloRolesUsuario];
                    bool permiso = rolesUsuario.Any(entidad => Convert.ToInt32(entidad["id"]) == 1);

                    if (!permiso)
                    {
                        HttpContext.Current.Response.Redirect("FrmMenu.aspx", true);
                        mensaje = "Acceso denegado.";
                    }
                }
                catch (Exception e)
                {
                    HttpContext.Current.Response.Redirect("FrmLogin.aspx", true);
                    mensaje = "Error de configuración de roles: " + e.Message;
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(paginaRetorno, true);
                mensaje = "Usuario no autenticado.";
            }

            return mensaje;
        }

        protected void BtnGuardar(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            Dictionary<string, object> propiedadesUsuario = new Dictionary<string, object>
            {
                {"email", email},
                {"contrasena", contrasena}  //  'contrasena' debe ser con hash
            };

            Entidad usuario = new Entidad(propiedadesUsuario);
            ControlEntidad controlUsuario = new ControlEntidad("usuario");
            string resultadoUsuario = controlUsuario.Guardar(usuario);

            // Asumiendo que listRolesUsuario es un ListBox que tiene los roles seleccionados
            foreach (ListItem item in listRolesUsuario.Items)
            {
                //if (item.Selected)
                //{
                    Dictionary<string, object> propiedadesRolUsuario = new Dictionary<string, object>
                    {
                        {"fkemail", email}, 
                        {"fkidrol", item.Value.Split(' ')[0]}  
                    };

                    Entidad rolUsuario = new Entidad(propiedadesRolUsuario);
                    ControlEntidad controlRolUsuario = new ControlEntidad("rol_usuario"); 
                    string resultadoRolUsuario = controlRolUsuario.Guardar(rolUsuario);

                    // aquí manejar mensajes
                //}
            }

            // Opcional: mostrar un mensaje de resultado
            // lblMensaje.Text = "Usuario y roles guardados correctamente";

            Response.Redirect("FrmUsuarios.aspx");
        }


        protected void BtnConsultar(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            ControlEntidad controlUsuario = new ControlEntidad("usuario");
            Entidad entidad = controlUsuario.Consultar("email", email);
            if (entidad != null)
            {
                txtEmail.Text = entidad["email"].ToString();
                txtContrasena.Text = entidad["contrasena"].ToString();

                // Consulta los roles asociados al usuario y los muestra en el ListBox
                ControlEntidad controlRolUsuario = new ControlEntidad("rol_usuario");
                List<Entidad> rolesUsuario = controlRolUsuario.ConsultarRolesPorUsuario(email);
                listRolesUsuario.Items.Clear(); // Limpia el ListBox antes de agregar nuevos ítems
                foreach (Entidad rol in rolesUsuario)
                {
                    ListItem listItem = new ListItem(rol["id"].ToString()+" - "+ rol["nombre"].ToString());
                    listRolesUsuario.Items.Add(listItem);
                }
            }
            else
            {
                // Opcional: Mostrar un mensaje de error si el usuario no se encuentra
                // lblMensaje.Text = "Usuario no encontrado.";
            }
        }


        protected void BtnModificar(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            Dictionary<string, object> propiedades = new Dictionary<string, object>
            {
                {"email", email},
                {"contrasena", txtContrasena.Text.Trim()}
            };

            Entidad entidad = new Entidad(propiedades);
            ControlEntidad controlUsuario = new ControlEntidad("usuario");
            string mensaje1 = controlUsuario.Modificar(entidad, "email", email);

            ControlEntidad controlRolUsuario = new ControlEntidad("rol_usuario");
            string mensaje2 = controlRolUsuario.Borrar("email", email);
            foreach (ListItem item in listRolesUsuario.Items)
            {
                Dictionary<string, object> propiedadesRolUsuario = new Dictionary<string, object>
                    {
                        {"fkemail", email},
                        {"fkidrol", item.Value.Split(' ')[0]}
                    };

                Entidad rolUsuario = new Entidad(propiedadesRolUsuario);
                string resultadoRolUsuario = controlRolUsuario.Guardar(rolUsuario);
            }
            //lblMensaje.Text = resultado;
            Response.Redirect("FrmUsuarios.aspx");
        }

        protected void BtnBorrar(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            ControlEntidad controlUsuario = new ControlEntidad("usuario");
            string resultado = controlUsuario.Borrar("email", email);
            //lblMensaje.Text = resultado;
            Response.Redirect("FrmUsuarios.aspx");
        }
        protected void btnAgregarRol(object sender, EventArgs e)
        {
            //if (comboRoles.SelectedItem != null)
            //{
                ListItem newItem = new ListItem(comboRoles.SelectedItem.Text, comboRoles.SelectedItem.Value);
                //newItem.Selected = true;

                listRolesUsuario.Items.Add(newItem);  // Agrega al ListBox
                //comboRoles.Items.Remove(newItem);  // Remueve del DropDownList
            //}
        }

        protected void btnRemoverRol(object sender, EventArgs e)
        {
            if (listRolesUsuario.SelectedItem != null)
            {
                // Devuelve el ítem al DropDownList
                comboRoles.Items.Add(new ListItem(listRolesUsuario.SelectedItem.Text, listRolesUsuario.SelectedItem.Value));

                // Remueve el ítem seleccionado del ListBox
                listRolesUsuario.Items.Remove(listRolesUsuario.SelectedItem);
            }
        }

    }
}
