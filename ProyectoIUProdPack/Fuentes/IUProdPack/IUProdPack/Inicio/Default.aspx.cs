//using Parametros;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using IUProdPack.WsPraxair;

namespace IUProdPack.Inicio
{
    public partial class Default : System.Web.UI.Page
    {
        private void generarmensaje(string pMensaje)
        {
            ClientScriptManager clientScript = this.Page.ClientScript;
            if (!clientScript.IsStartupScriptRegistered(base.GetType(), "winPop"))
            {
                clientScript.RegisterStartupScript(base.GetType(), "winPop", string.Concat("alert('", pMensaje, "');"), true);
            }
        }

        private void InicioAplicacion(string pDatos)
        {
            char[] chr = new char[] { Convert.ToChar(",") };
            string[] strArrays = pDatos.Split(chr);
            this.Session.Clear();
            this.Session.Add("SessionActiva", "1");
            this.Session.Add("USUARIO", strArrays[0]);
            this.Session.Add("Password", strArrays[1]);
            this.Session.Add("IdUsuario", strArrays[2]);
            this.Session.Add("grupo", strArrays[3]);
            this.Session.Add("empresa", strArrays[4]);
            this.Session.Add("agencia", strArrays[5]);
            this.Session.Add("PasswordBd", strArrays[6]);
            ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
            this.Session.Add("CONEXION", serviceSoapClient.BaseEmpresa(Convert.ToInt32(this.Session["GRUPO"].ToString()), Convert.ToInt32(this.Session["EMPRESA"].ToString())));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            try
            {
                this.Label1.Visible = false;
                this.Label1.Text = "";
                if (this.Session["MENSAJE_RVV"] == null)
                {
                    ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                    if (base.Request.QueryString.Count != 0)
                    {
                        if (base.Request.QueryString["ID"] != null)
                            str = serviceSoapClient.DesEncriptar(base.Request.QueryString["ID"].ToString(), 2);
                        else {
                            str = serviceSoapClient.DesEncriptar(ConfigurationManager.AppSettings["ENTRADA"].ToString(), 2);
                        }
                    }
                    else
                    {
                        string str1 = ConfigurationManager.AppSettings["ENTRADA"].ToString();
                        str = serviceSoapClient.DesEncriptar(str1, 2);
                        if (str1.Equals(""))
                        {
                            base.Response.Redirect("pagError.aspx?mensaje=No está autorizado el ingreso");
                        }
                    }
                    this.InicioAplicacion(str);
                }
                else
                {
                    this.Label1.Visible = true;
                    this.Label1.Text = this.Session["MENSAJE_RVV"].ToString();
                    this.Session["MENSAJE_RV"] = null;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.Label1.Visible = true;
                this.Label1.Text = clsParametros.manejoError(exception.ToString());
            }
        }
    }
}