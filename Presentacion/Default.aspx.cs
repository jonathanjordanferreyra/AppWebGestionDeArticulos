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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    RepeaterProductos.DataSource = negocio.ListarArticulos();
                    RepeaterProductos.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = ((Button)sender).CommandArgument;
                Response.Redirect("DetalleArticulo.aspx?id=" + valor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //List<Articulo> ListaFiltrada = ((List<Articulo>)Session["Lista"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            //RepeaterProductos.DataSource = ListaFiltrada;
            //RepeaterProductos.DataBind();}

            //Lo hice asi porque segun yo es más escalable que guardarlo en sesión si tenes muchos articulos
            ArticuloNegocio negocio = new ArticuloNegocio();
            RepeaterProductos.DataSource = negocio.BuscarPorNombre(txtFiltro.Text);
            RepeaterProductos.DataBind();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            txtFiltro.Text = "";
            RepeaterProductos.DataSource = negocio.ListarArticulos();
            RepeaterProductos.DataBind();
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Session.Add("Error", "Debes loguearte para poder agregar a favoritos.");
                    Response.Redirect("Error.aspx");
                    return;
                }
                else
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    FavoritosNegocio negocio = new FavoritosNegocio();
                    int IdArticulo = int.Parse(((Button)sender).CommandArgument);
                    negocio.Agregar(usuario.Id, IdArticulo);
                    Response.Redirect("Favoritos.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}