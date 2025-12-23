using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                Usuario usuario = negocio.Login(txtEmail.Text, txtPassword.Text);
                if (usuario != null)
                {
                    Session.Add("Usuario",usuario);
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    lblError.Text = "El email o contraseña es incorrecto";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }

        }
    }
}