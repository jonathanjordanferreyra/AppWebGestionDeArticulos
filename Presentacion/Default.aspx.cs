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
    }
}