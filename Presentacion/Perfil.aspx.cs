using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Presentacion
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Precargo imagen de perfil si la hay
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    imgPerfil.ImageUrl = usuario.UrlImagenPerfil != null ? "~/Images/" + usuario.UrlImagenPerfil : "https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg";

                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtEmail.Text = usuario.Email;
                    txtEmail.ReadOnly = true;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                //Escribir img
                Usuario usuario = (Usuario)Session["Usuario"];
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuarioNegocio.ActualizarPerfil(usuario);
                Session["Usuario"] = usuario;
                if (fuImagenPerfil.HasFile)
                {
                    string extension = Path.GetExtension(fuImagenPerfil.FileName).ToLower();
                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                    {
                        Session["Error"] = "Formato de imagen no permitido";
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    string ruta = Server.MapPath("./Images/");
                    fuImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + extension);
                    usuario.UrlImagenPerfil = "perfil-" + usuario.Id + extension;
                    imgPerfil.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}