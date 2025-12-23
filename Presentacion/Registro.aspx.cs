using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario.Nombre = txtNombre.Text;
                usuario.Pass = txtPassword.Text;
                usuario.Email = txtEmail.Text;
                int id = negocio.Registrarse(usuario);
                if (id > 0)
                {
                    Session.Add("Usuario",usuario);
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    lblError.Text = "El email ya existe";
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}