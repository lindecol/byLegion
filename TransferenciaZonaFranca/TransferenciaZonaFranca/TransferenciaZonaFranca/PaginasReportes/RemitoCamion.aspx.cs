using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class RemitoCamion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                TransferenciasZF.Data.Documento Documento = new TransferenciasZF.Data.Documento();
                string Comprobante = base.Request.QueryString["C"];
                string Comprobante_ZF = base.Request.QueryString["C1"];
                string strVehiculo = base.Request.QueryString["S"];
                this.TxtComprobante.Text = Comprobante;
                this.txtVehiculo.Text = strVehiculo;
                List<TransferenciasZF.Data.Documento> lista = new List<TransferenciasZF.Data.Documento>();
                lista = Documento.ConsultarRutaConductorProcesoFact(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), Comprobante_ZF, this.Session["CONECTAR_A"].ToString());
                if (lista.Count > 0)
                {
                    //ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("SUCURSAL", "BOGOTA"), new ReportParameter("CONDUCTOR", lista[0].Conductor), new ReportParameter("AGENCIA", lista[0].AgenciaDestino) };
                    List<ReportParameter> parametro = new List<ReportParameter>();// = new ReportParameter[] { new ReportParameter("SUCURSAL", "BOGOTA"), new ReportParameter("CONDUCTOR", lista[0].Conductor), new ReportParameter("AGENCIA", lista[0].AgenciaDestino) };
                    parametro.Add(new ReportParameter("SUCURSAL", "BOGOTA"));
                    parametro.Add(new ReportParameter("CONDUCTOR", lista[0].Conductor));
                    parametro.Add(new ReportParameter("AGENCIA", lista[0].AgenciaDestino));

                    this.ReportViewer1.LocalReport.SetParameters(parametro.ToArray());
                    return;
                }
                ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("SUCURSAL", "BOGOTA"), new ReportParameter("CONDUCTOR", "  "), new ReportParameter("AGENCIA", "  ") };
                this.ReportViewer1.LocalReport.SetParameters(parametros);
            }
        }
    }
}