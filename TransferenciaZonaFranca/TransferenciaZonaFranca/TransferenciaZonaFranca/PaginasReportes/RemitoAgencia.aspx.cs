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

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class RemitoAgencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                Documento documento = new Documento();
                string Comprobante = base.Request.QueryString["C"];
                string item = base.Request.QueryString["R"];
                string DocSerie = base.Request.QueryString["S"];
                this.lblDocumento.Text = Comprobante;
                this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
                this.lblSubdeposito.Text = base.Request.QueryString["SUB"];
                string str = DateTime.Now.Hour.ToString();
                int minute = DateTime.Now.Minute;
                string Hour = string.Concat(str, ":", minute.ToString());
                this.ObjectDataSource1.TypeName = "TransferenciasZF.DsRemitoAgenciaCOOXTableAdapters.VIEW_REMITOAGENCIAWEBTableAdapter";
                Documento pal = new Documento();
                DataSet DsCilindros = new DataSet();
                DsCilindros = pal.ReimpresionRemitoAgenciaWeb(this.lblEmpresa.Text.Trim(), this.lblDocumento.Text.Trim(), this.Session["SESSION_AGENCIA"].ToString(), this.Session["CONECTAR_A"].ToString());
                ReportDataSource rds = new ReportDataSource()
                {
                    Name = "DataSet1",
                    Value = DsCilindros.Tables[0]
                };
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(rds);
                this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteRemitoAgencia.rdlc";
                this.ReportViewer1.LocalReport.Refresh();
                ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", ""), new ReportParameter("HORA", Hour), new ReportParameter("DocSerie", DocSerie.Substring(0, 5)), new ReportParameter("CONDUCTOR", ""), new ReportParameter("VEHICULO", ""), new ReportParameter("DESTINO", ""), new ReportParameter("ORIGINAL_COPI", "C") };
                this.ReportViewer1.LocalReport.SetParameters(parametros);
            }
        }
    }
}