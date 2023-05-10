using ControlPaqueteNet.WsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace ControlPaqueteNet
{
    public partial class Default : System.Web.UI.Page
    {
        private static ArrayList __ENCList;
        private WsPraxair.ServiceSoapClient objSeg;

        protected void Page_Load(object sender, EventArgs e)
        {
            string p_Datos = "";
            if (this.Request.QueryString.Count != 0)
            {
                objSeg = new ServiceSoapClient();
                p_Datos = this.objSeg.DesEncriptar(this.Request.QueryString["ID"].ToString(), 2);
                this.InicioAplicacion(p_Datos);
            }
            else
            {
                this.Session["UsuarioRegistro"] = ConfigurationManager.AppSettings["UsuarioRegistro"];
                this.Session["Usuario"] = ConfigurationManager.AppSettings["Usuario"];
                this.Session["Grupo"] = ConfigurationManager.AppSettings["Grupo"];
                this.Session["Empresa"] = ConfigurationManager.AppSettings["Empresa"];
                this.Session["Agencia"] = ConfigurationManager.AppSettings["Agencia"];
                HttpSessionState session = this.Session;
                string[] item = new string[] { ConfigurationManager.AppSettings["Data"], ";", ConfigurationManager.AppSettings["UsuarioBD"], ";", ConfigurationManager.AppSettings["PassBD"] };
                session["Conexion"] = string.Concat(item);
            }
        }

        private void InicioAplicacion(string pDatos)
        {
            string[] Cadena = pDatos.Split(new char[] { ',' });
            this.Session["UsuarioRegistro"] = Cadena[0];
            this.Session["Password"] = Cadena[1];
            this.Session["Usuario"] = Cadena[2];
            this.Session["Grupo"] = Cadena[3];
            this.Session["Empresa"] = Cadena[4];
            this.Session["Agencia"] = Cadena[5];
            this.Session["PasswordBd"] = Cadena[6];
            this.Session["Conexion"] = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(this.objSeg.BaseEmpresa(Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"])), ";"), this.Session["UsuarioRegistro"]), ";"), this.Session["PasswordBd"]);
        }
    }
}