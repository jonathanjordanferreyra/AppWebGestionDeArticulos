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
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.EsAdmin(Session["Usuario"]))
            {
                Session["Error"] = "Necesitas ser admin para ingresar a esta página";
                Response.Redirect("Error.aspx");
            }
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

        protected void txtFiltroAvanzado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void CKBFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            ddlCampo.SelectedIndex = 0;
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                List<Articulo> ListaFiltroAvanzado = negocio.FiltroAvanzado(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                GVArticulos.DataSource = ListaFiltroAvanzado;
                GVArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", "Error al buscar con filtro avanzado " + ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                if (CKBFiltroAvanzado.Checked)
                {
                    txtFiltroAvanzado.Text = "";
                    GVArticulos.DataSource = articuloNegocio.ListarArticulos();
                    GVArticulos.DataBind();
                }
                else
                {
                    txtFiltro.Text = "";
                    GVArticulos.DataSource = articuloNegocio.ListarArticulos();
                    GVArticulos.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}