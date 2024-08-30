using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;

namespace proyectoindicadores2
{
    public partial class FrmUsuariosServicios : System.Web.UI.Page
    {
        private readonly HttpClient client = new HttpClient();
        protected List<Entidad> arregloEntidades; // Lista de usuarios
        protected List<Entidad> arregloRoles; // Lista de roles

        protected async void Page_Load(object sender, EventArgs e)
        {
            await LoadRoles();
            await LoadUsers();
            ControlEntidad objControlEnt = new ControlEntidad("rol_usuario");

            if (!IsPostBack)
            {
                objControlEnt.controlDeAcceso("email", "arregloRolesUsuario", "FrmLogin.aspx");

                // Inicializar el combobox de roles en la carga inicial
                comboRoles.Items.Clear();
                foreach (var rol in arregloRoles)
                {
                    string text = $"{rol["id"]} - {rol["nombre"]}";
                    string value = rol["id"].ToString();
                    comboRoles.Items.Add(new ListItem(text, value));
                }
            }
        }

        
        private async Task LoadUsers()
        {
            var response = await client.GetAsync("http://localhost:2849/api/entidades/usuario");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                try
                {
                    var rolesData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data);
                    var usuarios = new List<Entidad>();
                    foreach (var roleData in rolesData)
                    {
                        usuarios.Add(new Entidad(roleData));
                    }

                    arregloEntidades = usuarios;
                    Session["arregloEntidades"] = arregloEntidades;  // Guardar en la sesión
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
            string email = txtEmail.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            var usuario = new { email, contrasena };
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:2849/api/entidades/usuario", data);
            if (response.IsSuccessStatusCode)
            {
                await SaveUserRoles(email); // Guardar roles del usuario tras la creación exitosa
                await LoadUsers(); // Recargar la lista de usuarios
            }
            else
            {
                Console.WriteLine("Error al guardar el usuario: " + response.StatusCode);
            }
        }

        private async Task SaveUserRoles(string email)
        {
            foreach (ListItem item in listRolesUsuario.Items)
            {
                var userRole = new { fkemail = email, fkidrol = item.Value };
                var roleJson = JsonConvert.SerializeObject(userRole);
                var roleData = new StringContent(roleJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:2849/api/entidades/rol_usuario", roleData);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error al guardar el rol del usuario: " + response.StatusCode);
                }
                else
                {
                    Console.WriteLine("Rol del usuario guardado correctamente.");
                }
            }
        }


        protected async void BtnConsultar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string encodedEmail = HttpUtility.UrlEncode(email);  // Codificando el email para que pueda ser incluido de forma segura en la URL

            try
            {
                // Realiza la solicitud GET usando HttpClient
                var response = await client.GetAsync($"http://localhost:2849/api/entidades/usuarios/email?email={encodedEmail}");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // Deserializa la respuesta JSON directamente a un objeto Dictionary
                    var usuario = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);

                    if (usuario != null && usuario.ContainsKey("email") && usuario.ContainsKey("contrasena"))
                    {
                        // Actualiza los campos del formulario con la información del usuario
                        txtEmail.Text = usuario["email"].ToString();
                        txtContrasena.Text = usuario["contrasena"].ToString();
                        // Consulta los roles asociados al usuario y los muestra en el ListBox
                        ControlEntidad controlRolUsuario = new ControlEntidad("rol_usuario");
                        List<Entidad> rolesUsuario = controlRolUsuario.ConsultarRolesPorUsuario(email);
                        listRolesUsuario.Items.Clear(); // Limpia el ListBox antes de agregar nuevos ítems
                        foreach (Entidad rol in rolesUsuario)
                        {
                            ListItem listItem = new ListItem(rol["id"].ToString() + " - " + rol["nombre"].ToString());
                            listRolesUsuario.Items.Add(listItem);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Datos de usuario incompletos.");
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado o error en la solicitud: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar la solicitud: " + ex.Message);
            }
        }

        protected async void BtnModificar_Click(object sender, EventArgs e)
        {
            // Obtén el email del cuadro de texto y codifícalo para su uso en la URL.
            string email = txtEmail.Text.Trim();
            string encodedEmail = HttpUtility.UrlEncode(email);

            // Crea un diccionario con los campos que deseas actualizar.
            var usuario = new Dictionary<string, object>
            {
                { "contrasena", txtContrasena.Text.Trim() }
            };

            // Serializa el diccionario a JSON.
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Actualiza los datos del usuario mediante el método PUT.
            var response = await client.PutAsync($"http://localhost:2849/api/entidades/usuario/email?email={encodedEmail}", data);

            if (response.IsSuccessStatusCode)
            {
                // Si la actualización fue exitosa, elimina los roles actuales del usuario.
                await DeleteUserRoles(encodedEmail);

                // Guarda los nuevos roles seleccionados en el ListBox.
                await SaveUserRoles(email);

                // Recarga la lista de usuarios para reflejar los cambios.
                await LoadUsers();

                Console.WriteLine("Usuario y roles actualizados exitosamente.");
            }
            else
            {
                Console.WriteLine($"Error al modificar el usuario: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        private async Task DeleteUserRoles(string encodedEmail)
        {
            // Llama al método DELETE para eliminar los roles asociados al usuario.
            var response = await client.DeleteAsync($"http://localhost:2849/api/entidades/rol_usuario/email?email={encodedEmail}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error al eliminar los roles del usuario: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }



        protected async void BtnBorrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string encodedEmail = HttpUtility.UrlEncode(email);  // Codificando el email correctamente

            try
            {
                // Asegúrate de que la URL corresponde con la configuración de tu API
                // Aquí asumimos que la API espera el email como un parámetro de consulta, no en la ruta
                var url = $"http://localhost:2849/api/entidades/usuario/email?email={encodedEmail}";
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    await LoadUsers(); // Actualizar lista de usuarios
                    Console.WriteLine("Usuario eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error al borrar el usuario: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar la solicitud: " + ex.Message);
            }
        }



        protected void btnAgregarRol(object sender, EventArgs e)
        {
            if (comboRoles.SelectedItem != null)
            {
                var newItem = new ListItem(comboRoles.SelectedItem.Text, comboRoles.SelectedItem.Value);
                listRolesUsuario.Items.Add(newItem);
            }
        }

        protected void btnRemoverRol(object sender, EventArgs e)
        {
            if (listRolesUsuario.SelectedItem != null)
            {
                listRolesUsuario.Items.Remove(listRolesUsuario.SelectedItem);
            }
        }
    }
}
