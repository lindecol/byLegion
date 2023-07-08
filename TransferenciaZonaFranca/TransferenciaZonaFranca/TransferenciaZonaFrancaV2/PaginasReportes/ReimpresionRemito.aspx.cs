using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class ReimpresionRemito : System.Web.UI.Page
    {
        private static string Conectar_a;

        static ReimpresionRemito()
        {
            ReimpresionRemito.Conectar_a = "ConexionOracle";
        }

        public ReimpresionRemito()
        {
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Empresa empresa = new Empresa();
            ReimpresionRemito.Conectar_a = empresa.ConsultarConexion(this.lblEmpresa.Text.ToString());
            List<Documento> documentos = new List<Documento>();
            Documento documento = new Documento();
            documentos = documento.ConsultarRutaConductorProceso(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), this.lblDocumento.Text, ReimpresionRemito.Conectar_a);
            if (documentos.Count <= 0)
            {
                this.ReportViewer1.Visible = false;
                this.lblmsj.Text = "Remito No Encontrado";
                return;
            }
            this.ObjectDataSource1.TypeName = "TransferenciasZF.DsRemitoCOOXTableAdapters.VIEW_REMISION_ZFTableAdapter";
            Documento documento1 = new Documento();
            DataSet dataSet = new DataSet();
            dataSet = documento1.ReimpresionremitoIntercompania(this.lblEmpresa.Text.Trim(), this.lblDocumento.Text.Trim(), this.txtSerie.Text.Trim(), ReimpresionRemito.Conectar_a);
            string connectionString = ConfigurationManager.ConnectionStrings[ReimpresionRemito.Conectar_a].ConnectionString;
            ReportDataSource reportDataSource = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = dataSet.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteRemision.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", documentos[0].CodigoRuta), new ReportParameter("HORA", "09:09"), new ReportParameter("DocSerie", "00001"), new ReportParameter("CONDUCTOR", documentos[0].Conductor), new ReportParameter("VEHICULO", documentos[0].Vehiculo), new ReportParameter("DESTINO", documentos[0].AgenciaDestino), new ReportParameter("ORIGINAL_COPI", "C") };
            this.ReportViewer1.LocalReport.SetParameters(reportParameter);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
            this.txtSerie.Text = this.Session["SESSION_AGENCIA"].ToString();
            this.lblSubdeposito.Text = "";
            if (!base.IsPostBack)
            {
                this.ReportViewer1.Visible = false;
            }
        }
    }
}