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
    public partial class RemitoAgencia : System.Web.UI.Page
    {
        public RemitoAgencia()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                Documento documento = new Documento();
                string item = base.Request.QueryString["C"];
                string str = base.Request.QueryString["R"];
                string item1 = base.Request.QueryString["S"];
                this.lblDocumento.Text = item;
                this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
                this.lblSubdeposito.Text = base.Request.QueryString["SUB"];
                string str1 = DateTime.Now.Hour.ToString();
                int minute = DateTime.Now.Minute;
                string str2 = string.Concat(str1, ":", minute.ToString());
                this.ObjectDataSource1.TypeName = "TransferenciasZF.DsRemitoAgenciaCOOXTableAdapters.VIEW_REMITOAGENCIAWEBTableAdapter";
                Documento documento1 = new Documento();
                DataSet dataSet = new DataSet();
                dataSet = documento1.ReimpresionRemitoAgenciaWeb(this.lblEmpresa.Text.Trim(), this.lblDocumento.Text.Trim(), this.Session["SESSION_AGENCIA"].ToString(), this.Session["CONECTAR_A"].ToString());
                ReportDataSource reportDataSource = new ReportDataSource()
                {
                    Name = "DataSet1",
                    Value = dataSet.Tables[0]
                };
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteRemitoAgencia.rdlc";
                this.ReportViewer1.LocalReport.Refresh();
                ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", ""), new ReportParameter("HORA", str2), new ReportParameter("DocSerie", item1.Substring(0, 5)), new ReportParameter("CONDUCTOR", ""), new ReportParameter("VEHICULO", ""), new ReportParameter("DESTINO", ""), new ReportParameter("ORIGINAL_COPI", "C") };
                this.ReportViewer1.LocalReport.SetParameters(reportParameter);
            }
        }
    }
}