using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace TransferenciaZonaFrancaV2.PaginasReportes
{
    public partial class Report : System.Web.UI.Page
    {
        public Report()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string item = base.Request.QueryString["C"];
                string str = base.Request.QueryString["R"];
                this.TextBox1.Text = item;
                string str1 = DateTime.Now.Hour.ToString();
                int minute = DateTime.Now.Minute;
                string str2 = string.Concat(str1, ":", minute.ToString());
                ReportParameter[] reportParameter = new ReportParameter[] { new ReportParameter("USUARIO", this.Session["SESSION_USUARIO"].ToString()), new ReportParameter("RUTA", str), new ReportParameter("HORA", str2) };
                this.ReportViewer1.LocalReport.SetParameters(reportParameter);
            }
        }
    }
}