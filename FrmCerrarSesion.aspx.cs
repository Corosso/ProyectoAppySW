using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectoindicadores2
{
    public partial class FrmCerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            //Session["email"] = null;
            //Session["arregloRolusuario"] = null;
            Response.Redirect("FrmMenu.aspx");
        }
    }
}