using Microsoft.Reporting.WebForms;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class LotesSeriales : System.Web.UI.Page
    {
        private static string Conectar_a;

        static LotesSeriales()
        {
            LotesSeriales.Conectar_a = "";
        }

        public LotesSeriales()
        {
        }


        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Empresa empresa = new Empresa();
            LotesSeriales.Conectar_a = empresa.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
            Pallet pallet = new Pallet();
            DataSet dataSet = new DataSet();
            dataSet = pallet.RelacionSerieLotes(this.lblDocumento.Text.Trim(), LotesSeriales.Conectar_a);
            ReportDataSource reportDataSource = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = dataSet.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\RptRelacionSeriesLotes.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("P_LOTE", this.lblDocumento.Text.Trim()) };
            this.ReportViewer1.LocalReport.SetParameters(reportParameter);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
            this.lblSubdeposito.Text = "";
            this.Session["SESSION_EMPRESA"] = this.lblEmpresa.Text;
            Pallet pallet = new Pallet();
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
            }
        }
    }
}