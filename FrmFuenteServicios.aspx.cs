using Newtonsoft.Json;
using proyectoindicadores2.Controllers;
using proyectoindicadores2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace proyectoindicadores2
{
    public partial class FrmFuenteServicios : System.Web.UI.Page
    {
        private readonly HttpClient client = new HttpClient();
        protected List<Entidad> arregloEntidades; // Lista de usuarios
        protected List<Entidad> arregloFuente; // Lista de fuentes


        protected async void Page_Load(object sender, EventArgs e)
        {
            await LoadRoles();
            await LoadUsers();
            ControlEntidad objControlEnt = new ControlEntidad("fuenteporindicador");

            if (!IsPostBack)
            {
                objControlEnt.controlDeAcceso("id", "arregloRolesUsuario", "FrmLogin.aspx");

                ControlEntidad controlRoles = new ControlEntidad("fuente");
                List<Entidad> arregloFuente = controlRoles.Listar();

                // Inicializar el combobox de roles en la carga inicial
                comboRoles.Items.Clear();
                foreach (var fuente in arregloFuente)
                {
                    string text = $"{fuente["id"]} - {fuente["nombre"]}";
                    string value = fuente["id"].ToString();
                    comboRoles.Items.Add(new ListItem(text, value));
                }
            }
        }
        private async Task LoadUsers()
        {
            var response = await client.GetAsync("http://localhost:2849/api/entidades/fuente");
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
            var response = await client.GetAsync("http://localhost:2849/api/entidades/rfu");
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

                    arregloFuente = roles;
                    Session["arregloRoles"] = arregloFuente;  // Guardar en la sesión
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

        protected  async void btnGuardar_Click(object sender, EventArgs e)
        {
            string id = txtEmail.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            var usuario = new { id, contrasena };
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:2849/api/entidades/fuente", data);
            if (response.IsSuccessStatusCode)
            {
                await SaveUserRoles(id); // Guardar id del fuente tras la creación exitosa
                await LoadUsers(); // Recargar la lista de usuarios
            }
            else
            {
                Console.WriteLine("Error al guardar el usuario: " + response.StatusCode);
            }
        }
        private async Task SaveUserRoles(string id)
        {
            foreach (ListItem item in listRolesUsuario.Items)
            {
                var userRole = new { fkidfuente = id, fkidindicador = item.Value };
                var roleJson = JsonConvert.SerializeObject(userRole);
                var roleData = new StringContent(roleJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:2849/api/entidades/fuenteporindicador", roleData);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error al guardar el rol del usuario: " + response.StatusCode);
                }
                else
                {
                    Console.WriteLine("FUENTE del usuario guardado correctamente.");
                }
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {

        }
    }

}