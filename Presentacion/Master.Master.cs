using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

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
            if (Seguridad.SesionActiva(Session["Usuario"]) && !string.IsNullOrEmpty(((Usuario)Session["Usuario"]).UrlImagenPerfil))
            {
                imgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["Usuario"]).UrlImagenPerfil;
            }
            else
            {
                imgAvatar.ImageUrl = "https://cdn-icons-png.flaticon.com/512/4123/4123763.png";
            }
        }

        protected void btnDesloguearse_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}