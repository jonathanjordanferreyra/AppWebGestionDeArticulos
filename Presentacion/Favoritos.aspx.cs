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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    FavoritosNegocio negocio = new FavoritosNegocio();
                    List<Articulo> lista = negocio.ListarFavoritos(usuario.Id);
                    if (lista.Count == 0)
                    { 
                        lblAvisoo.Visible = true;
                    }
                    repFavoritos.DataSource = lista;
                    repFavoritos.DataBind();
                }

            }
        }

        protected void btnQuitarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                FavoritosNegocio negocio = new FavoritosNegocio();
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                negocio.Eliminar(usuario.Id, idArticulo);

                repFavoritos.DataSource = negocio.ListarFavoritos(usuario.Id);
                repFavoritos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}