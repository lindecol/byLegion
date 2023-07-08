using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFrancaV2
{
    public partial class MatarSesion : System.Web.UI.Page
    {
        private static string Conectar_a;
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Documento> CargarDocumentos(string ConectarA)
        {
            List<Documento> lista = new List<Documento>();
            return (new Documento()).TiposDocumento(ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarSesionUsuario(string Usuario, string Doc)
        {
            (new Pallet()).EliminarSesionUsuario(Usuario, MatarSesion.Conectar_a, Doc);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session["SESSION_EMPRESA"].ToString();
            Empresa Emp = new Empresa();
            MatarSesion.Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
        }
    }
}