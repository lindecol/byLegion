using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPaqueteNet.Pages
{
    public partial class salir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScriptManager csm = this.Page.ClientScript;
            if (!csm.IsStartupScriptRegistered(this.GetType(), "winClose"))
            {
                csm.RegisterStartupScript(this.GetType(), "winClose", "window.close();", true);
            }
        }
    }
}