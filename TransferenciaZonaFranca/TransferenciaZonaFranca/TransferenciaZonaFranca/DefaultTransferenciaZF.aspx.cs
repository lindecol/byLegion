using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using TransferenciaZonaFranca.WsPraxair;


namespace TransferenciaZonaFranca
{
    public partial class DefaultTransferenciaZF : System.Web.UI.Page
    {
        private void InicioAplicacion(string pDatos, string idEntrada)
        {
            char[] chr = new char[] { Convert.ToChar(",") };
            string[] _cadena = pDatos.Split(chr);
            this.Session.Clear();
            this.Session.Add("ID_ENTRADA", idEntrada);
            this.Session.Add("SESSION_USUARIO", _cadena[0]);
            this.Session.Add("SESSION_AGENCIA", _cadena[5]);
            this.Session.Add("SESSION_EMPRESA", _cadena[4]);
            this.Session.Add("PasswordBd", _cadena[6]);
            ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
            this.Session["SESSION_EMPRESA"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string p_entrada;
            string p_Datos;
            try
            {
                string Opt = base.Request.QueryString["OPT"].ToString();
                ServiceSoapClient objSeg = new ServiceSoapClient();
                this.Session.Clear();
                if (base.Request.QueryString.Count != 0)
                {
                    p_entrada = base.Request.QueryString["ID"].ToString();
                    p_Datos = objSeg.DesEncriptar(base.Request.QueryString["ID"].ToString(), 2);
                }
                else
                {
                    p_entrada = ConfigurationManager.AppSettings["ENTRADA"].ToString();
                    p_Datos = objSeg.DesEncriptar(p_entrada, 2);
                    if (p_entrada.Equals(""))
                    {
                        base.Response.Redirect("pagError.aspx?mensaje=No está autorizado el ingreso");
                    }
                }
                this.InicioAplicacion(p_Datos, p_entrada);
                if (Opt == "1")
                {
                    base.Response.Redirect("DocumentoTransferencia.aspx");
                }
                if (Opt == "2")
                {
                    base.Response.Redirect("ConfiguracionPP.aspx");
                }
                if (Opt == "3")
                {
                    base.Response.Redirect("PaginasReportes/ReimpresionRemito.aspx");
                }
                if (Opt == "4")
                {
                    base.Response.Redirect("PaginasReportes/ReimpresionFactura.aspx");
                }
                if (Opt == "5")
                {
                    base.Response.Redirect("AdministracionPallets.aspx");
                }
                if (Opt == "6")
                {
                    base.Response.Redirect("AdministracionPalletsCerrados.aspx");
                }
                if (Opt == "7")
                {
                    base.Response.Redirect("PaginasReportes/CilindrosCargados.aspx");
                }
                if (Opt == "8")
                {
                    base.Response.Redirect("GuiaSalidaZonaFranca.aspx");
                }
                if (Opt == "9")
                {
                    base.Response.Redirect("PaginasReportes/ReporteMovRemitos.aspx");
                }
                if (Opt == "10")
                {
                    base.Response.Redirect("TomaPedidos.aspx");
                }
                if (Opt == "11")
                {
                    base.Response.Redirect("PaginasReportes/ReportesPedidos.aspx");
                }
                if (Opt == "12")
                {
                    base.Response.Redirect("BajaPedidos.aspx");
                }
                if (Opt == "13")
                {
                    base.Response.Redirect("MatarSesion.aspx");
                }
                if (Opt == "14")
                {
                    base.Response.Redirect("EliminarTransferenciasOBC.aspx");
                }
                if (Opt == "15")
                {
                    base.Response.Redirect("PaginasReportes/AjenosCargadosDet.aspx");
                }
                if (Opt == "16")
                {
                    base.Response.Redirect("RemitoAgenciaWeb.aspx");
                }
                if (Opt == "17")
                {
                    base.Response.Redirect("PaginasReportes/LotesSeriales.aspx");
                }
                if (Opt == "18")
                {
                    base.Response.Redirect("DocumentoTransferenciaSinFact.aspx");
                }
                if (Opt == "19")
                {
                    base.Response.Redirect("CambiarDestino.aspx");
                }
            }
            catch (Exception exception)
            {
            }
        }
    }
}