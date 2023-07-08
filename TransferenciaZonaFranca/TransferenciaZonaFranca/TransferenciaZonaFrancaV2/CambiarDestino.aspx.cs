using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFrancaV2
{
    public partial class CambiarDestino : System.Web.UI.Page
    {
        private static string Conectar_a;

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Documento> ConsultarDetallesRemito(int IdEmpresa, string Comprobante, string Sucursal)
        {
            List<Documento> lista = new List<Documento>();
            return (new Documento()).DetallesRemitoInter(IdEmpresa, Comprobante, Sucursal, CambiarDestino.Conectar_a);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje ModificarDestino(string Comprobante, string Fecha, string Agencia, string ConectarA)
        {
            Mensaje mensaje = new Mensaje()
            {
                IdError = "01"
            };
            string MsjProceso = (new Documento()).ModificarDestino(Comprobante, Fecha, Agencia, ConectarA);
            if (MsjProceso.Trim() != "0")
            {
                mensaje.IdError = "02";
                mensaje.MensajeError = MsjProceso;
            }
            else
            {
                mensaje.IdError = "01";
                mensaje.MensajeError = "";
            }
            return mensaje;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session["SESSION_EMPRESA"].ToString();
            this.lblEmpresa_.Text = this.Session["SESSION_EMPRESA"].ToString();
            this.lblSucursal.Text = this.Session["SESSION_AGENCIA"].ToString();
            Empresa Emp = new Empresa();
            CambiarDestino.Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
            this.lblBd.Text = CambiarDestino.Conectar_a;
        }
    }
}