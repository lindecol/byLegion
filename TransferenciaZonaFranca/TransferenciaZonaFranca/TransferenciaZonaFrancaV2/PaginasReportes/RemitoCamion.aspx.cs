using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class RemitoCamion : System.Web.UI.Page
    {
        public RemitoCamion()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                Documento documento = new Documento();
                string item = base.Request.QueryString["C"];
                string str = base.Request.QueryString["C1"];
                string item1 = base.Request.QueryString["S"];
                this.TxtComprobante.Text = item;
                this.txtVehiculo.Text = item1;
                List<Documento> documentos = new List<Documento>();
                documentos = documento.ConsultarRutaConductorProcesoFact(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), str, this.Session["CONECTAR_A"].ToString());
                if (documentos.Count > 0)
                {
                    ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("SUCURSAL", "BOGOTA"), new ReportParameter("CONDUCTOR", documentos[0].Conductor), new ReportParameter("AGENCIA", documentos[0].AgenciaDestino) };
                    this.ReportViewer1.LocalReport.SetParameters(reportParameter);
                    return;
                }
                ReportParameter[] reportParameterArray = new ReportParameter[] { new ReportParameter("SUCURSAL", "BOGOTA"), new ReportParameter("CONDUCTOR", "  "), new ReportParameter("AGENCIA", "  ") };
                this.ReportViewer1.LocalReport.SetParameters(reportParameterArray);
            }
        }
    }
}