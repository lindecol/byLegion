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

namespace TransferenciaZonaFranca.PaginasReportes
{
    public partial class ReimpresionRemito : System.Web.UI.Page
    {
        private static string Conectar_a;
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            Empresa Emp = new Empresa();
            ReimpresionRemito.Conectar_a = Emp.ConsultarConexion(this.lblEmpresa.Text.ToString());
            List<Documento> lista = new List<Documento>();
            Documento Doc = new Documento();
            lista = Doc.ConsultarRutaConductorProceso(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), this.lblDocumento.Text, ReimpresionRemito.Conectar_a);
            if (lista.Count <= 0)
            {
                this.ReportViewer1.Visible = false;
                this.lblmsj.Text = "Remito No Encontrado";
                return;
            }
            this.ObjectDataSource1.TypeName = "TransferenciasZF.DsRemitoCOOXTableAdapters.VIEW_REMISION_ZFTableAdapter";
            Documento pal = new Documento();
            DataSet DsCilindros = new DataSet();
            DsCilindros = pal.ReimpresionremitoIntercompania(this.lblEmpresa.Text.Trim(), this.lblDocumento.Text.Trim(), this.txtSerie.Text.Trim(), ReimpresionRemito.Conectar_a);
            string connectionString = ConfigurationManager.ConnectionStrings[ReimpresionRemito.Conectar_a].ConnectionString;
            ReportDataSource rds = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = DsCilindros.Tables[0]
            };
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteRemision.rdlc";
            this.ReportViewer1.LocalReport.Refresh();
            ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", lista[0].CodigoRuta), new ReportParameter("HORA", "09:09"), new ReportParameter("DocSerie", "00001"), new ReportParameter("CONDUCTOR", lista[0].Conductor), new ReportParameter("VEHICULO", lista[0].Vehiculo), new ReportParameter("DESTINO", lista[0].AgenciaDestino), new ReportParameter("ORIGINAL_COPI", "C") };
            this.ReportViewer1.LocalReport.SetParameters(parametros);
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