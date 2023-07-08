using Microsoft.Reporting.WebForms;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class WebLetin : System.Web.UI.Page
    {
        private static string Conectar_a;
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            if (this.lblEmpresa.Text.Trim() != "21")
            {
                WebLetin.Conectar_a = "ConexionOracle";
            }
            else
            {
                WebLetin.Conectar_a = "ConexionOracleCOOX";
            }
            Pallet pal = new Pallet();
            DataSet ff = new DataSet();
            ff = pal.Pallets();
            ReportDataSource rds = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = ff.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteLetin.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("P_PALLET", "00001") };
            this.ReportViewer1.LocalReport.SetParameters(parametros);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
            }
            this.lblEmpresa.Text = "21";
            this.lblSubdeposito.Text = "";
            this.lblAgencia.Text = "00001";
            this.lblUsuario.Text = "HGARCIA";
        }
    }
}