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
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Precargo drop down list
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                try
                {
                    imgArticulo.ImageUrl = "https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg";
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    List<Categoria> lista = negocio.ListarCategoria();
                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    List<Marca> listamarca = negocioMarca.ListarMarca();
                    ddlMarca.DataSource = listamarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx");
                }


            }
            //Si viene un ID por query string, estamos modificando.
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> lista = articuloNegocio.ListarArticulos(Request.QueryString["id"]);
                Articulo seleccionado = lista[0];

                //Precargar los datos
                txtId.Text = seleccionado.Id.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtCodigo.Text = seleccionado.Codigo;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtImagenUrl.Text = seleccionado.ImagenUrl;
                txtPrecio.Text = seleccionado.Precio.ToString("0.00");
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                imgArticulo.ImageUrl = seleccionado.ImagenUrl.ToString();
                btnAceptar.Text = "Modificar";
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            if (txtImagenUrl.Text == "")
            {
                imgArticulo.ImageUrl = "https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg";
            }
            else
            {
                imgArticulo.ImageUrl = txtImagenUrl.Text;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                Articulo articulo = new Articulo();
                articulo.Nombre = txtNombre.Text;
                articulo.Codigo = txtCodigo.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagenUrl.Text;
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                ArticuloNegocio negocio = new ArticuloNegocio();
                //Valido si quiero modificar o agregar
                if (Request.QueryString["id"] != null)
                {
                    articulo.Id = int.Parse(txtId.Text);
                    negocio.ModificarArticulo(articulo);
                }
                else
                {
                    negocio.AgregarArticulo(articulo);
                }
                Response.Redirect("Administracion.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }
    }
}