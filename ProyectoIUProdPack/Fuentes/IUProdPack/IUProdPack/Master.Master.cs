using AjaxControlToolkit;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using IUProdPack.WsPraxair;
using System.Configuration;

namespace IUProdPack
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public Master()
        {
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("~/salir.aspx");
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
            this.Page.ClientScript.RegisterClientScriptInclude(base.GetType(), "ddlevelsmenu", base.ResolveClientUrl("~/Menu/ddlevelsmenu.js"));
            try
            {
                if (base.Session["SessionActiva"] == null)
                {
                    throw new Exception("Session terminada");
                }
                this.lblPais.Text = "Colombia";
                ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
                string str = serviceSoapClient.Pais();
                if (base.Session["Empresa"] == null) {
                    var s = ConfigurationManager.AppSettings["ENTRADA"].ToString();
                    var s2 = serviceSoapClient.DesEncriptar(s, 2);
                    this.InicioAplicacion(s2);
                } 

                this.lblPais.Text = serviceSoapClient.valorCache(str, base.Session["Empresa"].ToString(), "NOM_PAIS");
                this.Label2.Text = string.Concat("Usuario: ", serviceSoapClient.datosUsuario(base.Session["USUARIO"].ToString(), 6));
                if (base.Session["Grupo"] == null)
                {
                    this.lblGrupo.Visible = false;
                }
                else
                {
                    this.lblGrupo.Text = string.Concat("Grupo: ", base.Session["Grupo"].ToString(), "- ", serviceSoapClient.descripcionGrupo(Convert.ToInt32(base.Session["Grupo"].ToString())));
                    this.lblGrupo.Visible = true;
                }
                if (base.Session["Empresa"] == null)
                {
                    this.lblEmpresa.Visible = false;
                }
                else
                {
                    this.lblEmpresa.Text = string.Concat("Empresa: ", base.Session["Empresa"].ToString(), "- ", serviceSoapClient.descripcionEmpresa(Convert.ToInt32(base.Session["Empresa"].ToString()), Convert.ToInt32(base.Session["Grupo"].ToString())));
                    this.lblEmpresa.Visible = true;
                }
                if (base.Session["Agencia"] == null)
                {
                    this.lblAgencia.Visible = false;
                }
                else
                {
                    this.lblAgencia.Text = string.Concat("Agencia: ", base.Session["Agencia"].ToString(), "- ", serviceSoapClient.descripcionAgencia(Convert.ToInt32(base.Session["Empresa"].ToString()), Convert.ToInt32(base.Session["Grupo"].ToString()), base.Session["Agencia"].ToString()));
                    this.lblAgencia.Visible = true;
                }
            }
            catch (Exception exception)
            {
                base.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
                throw;
            }
        }
    }
}