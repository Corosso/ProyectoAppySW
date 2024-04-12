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
        protected Rol[] arregloRoles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlRol objControlRol = new ControlRol(null);
            arregloRoles = objControlRol.listar();

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            //este guardar debería llamar a un procedimiento almacenado con control de transacciones
            //int cuenta = listRolesRol.Items.Count;
            string nom = txtNombre.Text;
            Rol objRol = new Rol(0, nom);
            ControlRol objControlRol = new ControlRol(objRol);
            string msg = objControlRol.guardar();

            Response.Redirect("FrmRol.aspx");
        }
        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nom = txtNombre.Text;
            Rol objRol = new Rol(id, nom);
            ControlRol objControlRol = new ControlRol(objRol);
            objRol = objControlRol.consultar();
            txtNombre.Text = objRol.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nom = txtNombre.Text;
            Rol objRol = new Rol(id, nom);
            ControlRol objControlRol = new ControlRol(objRol);
            objControlRol.modificar();
            Response.Redirect("FrmRol.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Rol objRol = new Rol(id, "");
            ControlRol objControlRol = new ControlRol(objRol);
            objControlRol.borrar();
            Response.Redirect("FrmRol.aspx");
        }
    }
}