using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransferenciaZonaFrancaV2.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public Login()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterHyperLink.NavigateUrl = string.Concat("Register.aspx?ReturnUrl=", HttpUtility.UrlEncode(base.Request.QueryString["ReturnUrl"]));
        }
    }
}