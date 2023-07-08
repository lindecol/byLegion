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
    public partial class FacturaPreliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                TransferenciasZF.Data.Documento Documento = new TransferenciasZF.Data.Documento();
                string Usuario = base.Request.QueryString["C"];
                string Ruta = base.Request.QueryString["R"];
                string Placa = base.Request.QueryString["T"];
                string Numero = base.Request.QueryString["Num"];
                this.TextBox1.Text = Usuario;
                string ValorTotalCadena = Documento.ValorEnLetrasTotalFacturaPrevisoria(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), this.Session["CONECTAR_A"].ToString(), Usuario);
                TransferenciasZF.Data.Documento pal = new TransferenciasZF.Data.Documento();
                DataSet DsCilindros = new DataSet();
                DsCilindros = pal.ImprimirVistaPreliminarFactura(Usuario, this.Session["CONECTAR_A"].ToString());
                ReportDataSource rds = new ReportDataSource()
                {
                    Name = "DataSet1",
                    Value = DsCilindros.Tables[0]
                };
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(rds);
                this.ReportViewer1.LocalReport.ReportPath = "Reportes\\VistaPreliminarFactura.rdlc";
                this.ReportViewer1.LocalReport.Refresh();
                ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("USUARIO", this.TextBox1.Text.Trim()), new ReportParameter("RUTA", Ruta), new ReportParameter("PLACA", Placa), new ReportParameter("NUM", Numero), new ReportParameter("VALORLETRAS", ValorTotalCadena) };
                this.ReportViewer1.LocalReport.SetParameters(parametros);
            }
        }
    }
}