using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Registro || Page is Default || Page is DetalleArticulo))
            {
                if (!Seguridad.SesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
        }

        protected void btnDesloguearse_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}