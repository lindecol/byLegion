using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;



namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class ReimpresionFactura : System.Web.UI.Page
    {
        public ReimpresionFactura()
        {
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Documento documento = new Documento();
            string str = "ConexionOracle";
            Empresa empresa = new Empresa();
            str = empresa.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
            List<Documento> documentos = new List<Documento>();
            documentos = documento.ConsultarRutaConductorProcesoFact(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), this.TextBox1.Text.Trim(), str);
            if (documentos.Count <= 0)
            {
                this.ReportViewer1.Visible = false;
                this.lblmsj.Text = "Factura No encontrada";
                return;
            }
            Documento documento1 = new Documento();
            DataSet dataSet = new DataSet();
            dataSet = documento1.ImpresionFacturaZF(this.TextBox1.Text.Trim(), str);
            ReportDataSource reportDataSource = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = dataSet.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteFactura.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", documentos[0].CodigoRuta), new ReportParameter("PLACA", documentos[0].Vehiculo) };
            this.ReportViewer1.LocalReport.SetParameters(reportParameter);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
            }
        }
    }
}