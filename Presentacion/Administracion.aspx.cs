using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                try
                {
                    GVArticulos.DataSource = negocio.ListarArticulos();
                    GVArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", "No se pudo cargar la grilla " + ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            GVArticulos.DataSource = negocio.BuscarPorNombre(txtFiltro.Text);
            GVArticulos.DataBind();
        }

        protected void GVArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            GVArticulos.PageIndex = e.NewPageIndex;
            GVArticulos.DataSource = negocio.ListarArticulos();
            GVArticulos.DataBind();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx");
        }

        protected void GVArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GVArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id);
        }

        protected void GVArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = (int)GVArticulos.DataKeys[e.RowIndex].Value;
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.EliminarArticulo(id);
                GVArticulos.DataSource = negocio.ListarArticulos();
                GVArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", "Error al eliminar artículo. " + ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}