using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransferenciaZonaFrancaV2.Account
{
    public partial class Register : System.Web.UI.Page
    {
        public Register()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterUser.ContinueDestinationPageUrl = base.Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(this.RegisterUser.UserName, false);
            string continueDestinationPageUrl = this.RegisterUser.ContinueDestinationPageUrl;
            if (string.IsNullOrEmpty(continueDestinationPageUrl))
            {
                continueDestinationPageUrl = "~/";
            }
            base.Response.Redirect(continueDestinationPageUrl);
        }
    }
}