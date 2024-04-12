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
    public partial class FrmTipoIndicador : System.Web.UI.Page
    {
        protected TipoIndicador[] arregloTiposIndicador = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(null);
            arregloTiposIndicador = objControlTipoIndicador.Listar();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            TipoIndicador tipoIndicador = new TipoIndicador(0, nombre);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(tipoIndicador);
            objControlTipoIndicador.Guardar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            TipoIndicador tipoIndicador = new TipoIndicador(id, nombre);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(tipoIndicador);
            tipoIndicador = objControlTipoIndicador.Consultar();
            txtNombre.Text = tipoIndicador.Nombre;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            TipoIndicador tipoIndicador = new TipoIndicador(id, nombre);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(tipoIndicador);
            objControlTipoIndicador.Modificar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoIndicador tipoIndicador = new TipoIndicador(id, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(tipoIndicador);
            objControlTipoIndicador.Borrar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }
    }
}
