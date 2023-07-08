using Microsoft.Reporting.WebForms;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class FacturaPreliminar : System.Web.UI.Page
    {
        public FacturaPreliminar()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                Documento documento = new Documento();
                string item = base.Request.QueryString["C"];
                string str = base.Request.QueryString["R"];
                string item1 = base.Request.QueryString["T"];
                string str1 = base.Request.QueryString["Num"];
                this.TextBox1.Text = item;
                string str2 = documento.ValorEnLetrasTotalFacturaPrevisoria(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), this.Session["CONECTAR_A"].ToString(), item);
                Documento documento1 = new Documento();
                DataSet dataSet = new DataSet();
                dataSet = documento1.ImprimirVistaPreliminarFactura(item, this.Session["CONECTAR_A"].ToString());
                ReportDataSource reportDataSource = new ReportDataSource()
                {
                    Name = "DataSet1",
                    Value = dataSet.Tables[0]
                };
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.ReportViewer1.LocalReport.ReportPath = "Reportes\\VistaPreliminarFactura.rdlc";
                this.ReportViewer1.LocalReport.Refresh();
                ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.TextBox1.Text.Trim()), new ReportParameter("RUTA", str), new ReportParameter("PLACA", item1), new ReportParameter("NUM", str1), new ReportParameter("VALORLETRAS", str2) };
                this.ReportViewer1.LocalReport.SetParameters(reportParameter);
            }
        }
    }
}