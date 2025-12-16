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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Precargo campos por QueriString ID
                    if (Request.QueryString["id"] != null)
                    {
                        int idArticulo = int.Parse(Request.QueryString["id"]);
                        if (!(idArticulo >= 0))
                        {
                            Response.Redirect("Default.aspx");
                            return;
                        }
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo encontrado = negocio.BuscarArticulo(idArticulo);
                        if (encontrado != null)
                        {
                            txtNombre.Text = encontrado.Nombre;
                            txtDescripcion.Text = encontrado.Descripcion;
                            txtPrecio.Text = encontrado.Precio.ToString("F2");
                            if (encontrado.ImagenUrl != null && encontrado.ImagenUrl.StartsWith("http"))
                            {
                                imgArticulo.ImageUrl = encontrado.ImagenUrl;
                            }
                            else
                            {
                                imgArticulo.ImageUrl = "https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg";
                            }
                        }
                        else
                        {
                            Response.Redirect("Default.aspx");
                        }
                        //Precargo ddl Marca y Categorias
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        ddlMarca.DataSource = marcaNegocio.ListarMarca();
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataBind();
                        ddlMarca.SelectedValue = encontrado.Marca.Id.ToString();

                        ddlCategoria.DataSource = categoriaNegocio.ListarCategoria();
                        ddlCategoria.DataTextField = "Descripcion";
                        ddlCategoria.DataValueField = "Id";
                        ddlCategoria.DataBind();
                        ddlCategoria.SelectedValue = encontrado.Categoria.Id.ToString();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Session.Add("Error", "Ocurrió un error o no se encontró el artículo");
                Response.Redirect("Error.aspx");
            }
        }
    }
}