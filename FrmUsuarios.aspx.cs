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
        protected Usuario[] arregloUsuarios = null;
        protected Rol[] arregloRoles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUsuario objControlUsuario = new ControlUsuario(null);
            arregloUsuarios = objControlUsuario.listar();
            if (!IsPostBack) //Si es la primera vez que carga la página
            {
                ControlRol objControlRol = new ControlRol(null);
                arregloRoles = objControlRol.listar();
                for (int i = 0; i < arregloRoles.Length; i++)
                {
                    comboRoles.Items.Add(arregloRoles[i].Id.ToString() + ";" + arregloRoles[i].Nombre);
                }
            } 

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            //este guardar debería llamar a un procedimiento almacenado con control de transacciones
            //int cuenta = listRolesUsuario.Items.Count;
            string ema = txtEmail.Text;
            string con = txtContrasena.Text;
            Usuario objUsuario = new Usuario(ema, con);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            string msg = objControlUsuario.guardar();

            for (int i = 0; i < listRolesUsuario.Items.Count; i++)
            {
                string[] idYNombre = listRolesUsuario.Items[i].Value.Split(';');
                int id = Convert.ToInt32(idYNombre[0]);
                RolUsuario objRolUsuario = new RolUsuario(ema, id);
                ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
                objControlRolUsuario.guardar();
            }
            Response.Redirect("FrmUsuarios.aspx");
        }
        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            string ema = txtEmail.Text;
            Usuario objUsuario = new Usuario(ema, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objUsuario = objControlUsuario.consultar();
            txtContrasena.Text = objUsuario.Contrasena;
            ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(null);
            RolUsuario[] arregloRolUsuario= objControlRolUsuario.listar(ema);
            listRolesUsuario.Items.Clear();
            //debería tener un control de excepciones
            for (int i = 0;i< arregloRolUsuario.Length; i++)
            {
                listRolesUsuario.Items.Add(arregloRolUsuario[i].FkIdRol.ToString());
            }
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            string ema = txtEmail.Text;
            string con = txtContrasena.Text;
            Usuario objUsuario = new Usuario(ema, con);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            string msg = objControlUsuario.borrar();
            objControlUsuario.guardar();
            for (int i = 0; i < listRolesUsuario.Items.Count; i++)
            {
                string[] idYNombre = listRolesUsuario.Items[i].Value.Split(';');
                int id = Convert.ToInt32(idYNombre[0]);
                RolUsuario objRolUsuario = new RolUsuario(ema, id);
                ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
                objControlRolUsuario.guardar();
            }
            Response.Redirect("FrmUsuarios.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            string ema = txtEmail.Text;
            Usuario objUsuario = new Usuario(ema, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            string msg = objControlUsuario.borrar();
            Response.Redirect("FrmUsuarios.aspx");
        }

        protected void btnAgregarRol(object sender, EventArgs e)
        {
            listRolesUsuario.Items.Add(comboRoles.Text);
            comboRoles.Items.Remove(comboRoles.Text);
        }

        protected void btnRemoverRol(object sender, EventArgs e)
        {
            listRolesUsuario.Items.Remove(listRolesUsuario.Text);
        }

    }
}