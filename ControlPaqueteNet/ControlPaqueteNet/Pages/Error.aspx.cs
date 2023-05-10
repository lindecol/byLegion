using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPaqueteNet.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblError.Text = this.Request.QueryString["mensaje"];
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(ConfigurationManager.AppSettings["PaginaInicio"]);
        }
    }
}