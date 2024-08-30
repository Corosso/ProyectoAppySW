using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using proyectoindicadores2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace proyectoindicadores2
{
    public partial class FrmRolServicios : System.Web.UI.Page
    {
        private readonly HttpClient client = new HttpClient();
        protected List<Entidad> arregloRoles;

        protected async void Page_Load(object sender, EventArgs e)
        {
            await LoadRoles();
            if (!IsPostBack)
            {
                controlDeAcceso("email", "arregloRolesUsuario", "FrmLogin.aspx");
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

        private async Task LoadRoles()
        {
            var response = await client.GetAsync("http://localhost:2849/api/entidades/rol");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                try
                {
                    var rolesData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data);
                    var roles = new List<Entidad>();
                    foreach (var roleData in rolesData)
                    {
                        roles.Add(new Entidad(roleData));
                    }

                    arregloRoles = roles;
                    Session["arregloRoles"] = arregloRoles;  // Guardar en la sesión
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine("Error en la deserialización: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No se pudo cargar los roles: " + response.StatusCode);
            }
        }

        protected async void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            var rol = new { nombre = nombre };
            var json = JsonConvert.SerializeObject(rol);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:2849/api/entidades/rol", data);
            if (response.IsSuccessStatusCode)
            {
                await LoadRoles(); // Refresh roles list
            }
            else
            {
                // Handle error or display message
            }
        }

        protected async void BtnConsultar_Click(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Clear();  // Limpiar encabezados por defecto
            int id = Convert.ToInt32(txtId.Text.Trim());
            string nombreTabla = "rol";
            string nombreCampo = "id";
            var response = await client.GetAsync($"http://localhost:2849/api/entidades/{nombreTabla}/{nombreCampo}/{id}");
            txtNombre.Text = "";
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                try
                {
                    var rolData = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
                    var rol = new Entidad(rolData);
                    txtNombre.Text = rol["nombre"].ToString();
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine("Error en la deserialización: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error en la solicitud: " + response.StatusCode);
            }
        }


        protected async void BtnModificar_Click(object sender, EventArgs e)
        {
            string mensaje = "ok";
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());  // Asegúrate de que esto no falle si el campo está vacío
                string nombre = txtNombre.Text.Trim();
                var rol = new { nombre = nombre };  // Asegúrate que los nombres de propiedades coinciden con la base de datos
                var json = JsonConvert.SerializeObject(rol);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"http://localhost:2849/api/entidades/rol/id/{id}", data);
                if (response.IsSuccessStatusCode)
                {
                    await LoadRoles(); // Refresh roles list
                     mensaje="Rol actualizado exitosamente.";
                }
                else
                {
                    mensaje = $"Error al actualizar el rol: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al intentar modificar el rol: {ex.Message}";
            }
        }


        protected async void BtnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            var response = await client.DeleteAsync($"http://localhost:2849/api/entidades/rol/id/{id}");
            if (response.IsSuccessStatusCode)
            {
                await LoadRoles(); // Refresh roles list
            }
            else
            {
                // Handle error or display message
            }
        }
    }
}
