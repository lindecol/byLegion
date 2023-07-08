using Microsoft.Reporting.WebForms;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using IUReportes.WsReportes;


namespace IUReportes
{
    public partial class wfReporte : System.Web.UI.Page
    {
        public wfReporte()
        {
        }

        public void cargarReporte()
        {
            string item = base.Request.QueryString["Usuario"];
            string str = base.Request.QueryString["Password"];
            string item1 = base.Request.QueryString["Conexion"];
            string str1 = base.Request.QueryString["TipoDoc"];
            string item2 = base.Request.QueryString["Prefijo"];
            string str2 = base.Request.QueryString["Cliente"];
            string item3 = base.Request.QueryString["NumDoc"];
            string str3 = base.Request.QueryString["FechaGen"];
            string item4 = base.Request.QueryString["Comprobante"];
            string str4 = base.Request.QueryString["Observaciones"];
            string item5 = base.Request.QueryString["TIPOIMPRESION"];
            int num = Convert.ToInt32(str1);
            int num1 = Convert.ToInt32(item5);
            DateTime dateTime = Convert.ToDateTime(str3);
            WsReportes.ServiceSoapClient service = new WsReportes.ServiceSoapClient();
            DataSet dataSet = new DataSet();
            dataSet = service.CargarReporte(item, str, item1, num, item2, str2, item3, dateTime, item4, str4, num1);
            if (dataSet.Tables[0].Rows.Count.Equals(0))
            {
                this.Label1.Visible = true;
                return;
            }
            string str5 = dataSet.Tables[0].Rows[0]["DTSNOMREPORTE"].ToString();
            string str6 = string.Concat("Reportes\\", dataSet.Tables[0].Rows[0]["RDLC"].ToString());
            ReportDataSource reportDataSource = new ReportDataSource(str5, dataSet.Tables[0]);
            this.rptVisorReportes.LocalReport.ReportPath = str6;
            this.rptVisorReportes.LocalReport.DataSources.Add(reportDataSource);
            if (num1 == 1)
            {
                this.imprimirReporte();
            }
        }

        private void imprimirReporte()
        {
            string str;
            string str1;
            string str2;
            Warning[] warningArray;
            string[] strArrays;
            string str3 = "PDF";
            string str4 = "<DeviceInfo>  <OutputFormat>PDF</OutputFormat>  <PageWidth>9in</PageWidth>  <PageHeight>11in</PageHeight>  <MarginTop>0.5in</MarginTop>  <MarginLeft>0.5in</MarginLeft>  <MarginRight>0.5in</MarginRight>  <MarginBottom>0.5in</MarginBottom></DeviceInfo>";
            byte[] numArray = this.rptVisorReportes.LocalReport.Render(str3, str4, out str, out str1, out str2, out strArrays, out warningArray);
            base.Response.Clear();
            base.Response.ContentType = str;
            base.Response.AddHeader("Content-Length", ((int)numArray.Length).ToString());
            base.Response.BinaryWrite(numArray);
            base.Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarReporte();
        }
    }
}