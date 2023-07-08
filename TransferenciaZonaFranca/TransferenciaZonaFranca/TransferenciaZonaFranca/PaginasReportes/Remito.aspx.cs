using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
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
    public partial class Remito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                TransferenciasZF.Data.Documento Documento = new TransferenciasZF.Data.Documento();
                string Comprobante = base.Request.QueryString["C"];
                string item = base.Request.QueryString["R"];
                string DocSerie = base.Request.QueryString["S"];
                this.lblDocumento.Text = Comprobante;
                this.lblEmpresa.Text = this.Session["SESSION_EMPRESA"].ToString();
                this.lblSucursal.Text = this.Session["SESSION_AGENCIA"].ToString();
                this.lblSubdeposito.Text = base.Request.QueryString["SUB"];
                string str = DateTime.Now.Hour.ToString();
                int minute = DateTime.Now.Minute;
                string Hour = string.Concat(str, ":", minute.ToString());
                List<TransferenciasZF.Data.Documento> lista = new List<TransferenciasZF.Data.Documento>();
                lista = Documento.ConsultarRutaConductorProceso(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), Comprobante, this.Session["CONECTAR_A"].ToString());
                if (lista.Count > 0)
                {
                    this.ObjectDataSource1.TypeName = "TransferenciasZF.DsRemitoCOOXTableAdapters.VIEW_REMISION_ZFTableAdapter";
                    TransferenciasZF.Data.Documento pal = new TransferenciasZF.Data.Documento();
                    DataSet DsCilindros = new DataSet();
                    DsCilindros = pal.ReimpresionremitoIntercompania(this.lblEmpresa.Text.Trim(), this.lblDocumento.Text.Trim(), this.lblSucursal.Text, this.Session["CONECTAR_A"].ToString());
                    ReportDataSource rds = new ReportDataSource()
                    {
                        Name = "DataSet1",
                        Value = DsCilindros.Tables[0]
                    };
                    this.ReportViewer1.LocalReport.DataSources.Clear();
                    this.ReportViewer1.LocalReport.DataSources.Add(rds);
                    this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteRemision.rdlc";
                    this.ReportViewer1.LocalReport.Refresh();
                    ReportParameter[] parametros = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", lista[0].CodigoRuta), new ReportParameter("HORA", Hour), new ReportParameter("DocSerie", DocSerie.Substring(0, 5)), new ReportParameter("CONDUCTOR", lista[0].Conductor), new ReportParameter("VEHICULO", lista[0].Vehiculo), new ReportParameter("DESTINO", lista[0].AgenciaDestino), new ReportParameter("ORIGINAL_COPI", "C") };
                    this.ReportViewer1.LocalReport.SetParameters(parametros);
                }
            }
        }
    }
}