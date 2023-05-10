using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlPaqueteNet.Pages
{
    public partial class ErrorDispositivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblError.Text = this.Request.QueryString["mensaje"];
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(ConfigurationManager.AppSettings["PaginaInicioDispositivo"]);
        }
    }
}