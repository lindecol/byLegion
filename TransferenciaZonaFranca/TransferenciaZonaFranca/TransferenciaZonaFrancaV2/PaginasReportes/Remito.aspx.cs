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


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class Remito : System.Web.UI.Page
    {
        public Remito()
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
                this.lblSucursal.Text = this.Session["SESSION_AGENCIA"].ToString();
                this.lblSubdeposito.Text = base.Request.QueryString["SUB"];
                string str1 = DateTime.Now.Hour.ToString();
                int minute = DateTime.Now.Minute;
                string str2 = string.Concat(str1, ":", minute.ToString());
                List<Documento> documentos = new List<Documento>();
                documentos = documento.ConsultarRutaConductorProceso(Convert.ToInt32(this.Session["SESSION_EMPRESA"].ToString()), item, this.Session["CONECTAR_A"].ToString());
                if (documentos.Count > 0)
                {
                    this.ObjectDataSource1.TypeName = "TransferenciasZF.DsRemitoCOOXTableAdapters.VIEW_REMISION_ZFTableAdapter";
                    Documento documento1 = new Documento();
                    DataSet dataSet = new DataSet();
                    dataSet = documento1.ReimpresionremitoIntercompania(this.lblEmpresa.Text.Trim(), this.lblDocumento.Text.Trim(), this.lblSucursal.Text, this.Session["CONECTAR_A"].ToString());
                    ReportDataSource reportDataSource = new ReportDataSource()
                    {
                        Name = "DataSet1",
                        Value = dataSet.Tables[0]
                    };
                    this.ReportViewer1.LocalReport.DataSources.Clear();
                    this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    this.ReportViewer1.LocalReport.ReportPath = "Reportes\\ReporteRemision.rdlc";
                    this.ReportViewer1.LocalReport.Refresh();
                    ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", documentos[0].CodigoRuta), new ReportParameter("HORA", str2), new ReportParameter("DocSerie", item1.Substring(0, 5)), new ReportParameter("CONDUCTOR", documentos[0].Conductor), new ReportParameter("VEHICULO", documentos[0].Vehiculo), new ReportParameter("DESTINO", documentos[0].AgenciaDestino), new ReportParameter("ORIGINAL_COPI", "C") };
                    this.ReportViewer1.LocalReport.SetParameters(reportParameter);
                }
            }
        }
    }
}