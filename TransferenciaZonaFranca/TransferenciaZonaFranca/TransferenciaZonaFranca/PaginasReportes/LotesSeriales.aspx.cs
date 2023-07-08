using Microsoft.Reporting.WebForms;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class LotesSeriales : System.Web.UI.Page
    {
        private static string Conectar_a;

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Empresa Emp = new Empresa();
            LotesSeriales.Conectar_a = Emp.ConsultarConexion(this.Session["SESSION_EMPRESA"].ToString().Trim());
            Pallet pal = new Pallet();
            DataSet DsCilindros = new DataSet();
            DsCilindros = pal.RelacionSerieLotes(this.lblDocumento.Text.Trim(), LotesSeriales.Conectar_a);
            ReportDataSource rds = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = DsCilindros.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\RptRelacionSeriesLotes.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("P_LOTE", this.lblDocumento.Text.Trim()) };
            this.ReportViewer1.LocalReport.SetParameters(parametros);
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