using AjaxControlToolkit;
using ControlPaqueteNet.WsPraxair;
using Microsoft.Reporting.WebForms;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlPaqueteNet.Pages
{
    public partial class ReporteSubdeposito : System.Web.UI.Page
    {
        private WsPackage.ServiceSoapClient wsData = new WsPackage.ServiceSoapClient();
        private WsPraxair.ServiceSoapClient oServices = new WsPraxair.ServiceSoapClient();
        private AccesoDatos oData = new AccesoDatos();


        public void btnScript_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                try
                {
                    DataSet reporte_seleccion = new DataSet();
                    reporte_seleccion = this.oData.Consulta("", "", this.sub_desde.Text, this.sub_hasta.Text, Conversions.ToString(this.Session["Conexion"]));
                    this.ReportViewer1.Visible = true;
                    ReportDataSource dataSource = new ReportDataSource("principal_maestro_subdeposito", reporte_seleccion.Tables[0]);
                    this.ReportViewer1.LocalReport.DataSources.Clear();
                    this.ReportViewer1.LocalReport.DataSources.Add(dataSource);
                    this.ReportViewer1.LocalReport.Refresh();
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    this.MensajeError(exception.Message);
                    this.ReportViewer1.LocalReport.DataSources.Clear();
                    this.ReportViewer1.LocalReport.Refresh();
                    this.ReportViewer1.Visible = false;
                    ProjectData.ClearProjectError();
                }
            }
            finally
            {
                this.sub_desde.SelectedIndex = 0;
                this.sub_hasta.SelectedIndex = 0;
            }
        }

        private void Configuracion()
        {
            try
            {
                int iGrupo = Conversions.ToInteger(this.Session["Grupo"]);
                int iEmpresa = Conversions.ToInteger(this.Session["Empresa"]);
                DataSet lista_ruta = new DataSet();
                DataSet lista_subdeposito = new DataSet();
                lista_subdeposito = this.wsData.ConsultarSubdepositosConfigurados(Conversions.ToString(this.Session["Conexion"]), iGrupo, iEmpresa, Conversions.ToInteger(this.Session["Agencia"]));
                this.sub_desde.DataSource = lista_subdeposito;
                this.sub_desde.DataValueField = "codigo_subdeposito";
                this.sub_desde.DataTextField = "nombre_subdepoisto";
                this.sub_desde.Items.Add("0");
                this.sub_desde.DataBind();
                this.sub_hasta.DataSource = lista_subdeposito;
                this.sub_hasta.DataValueField = "codigo_subdeposito";
                this.sub_hasta.DataTextField = "nombre_subdepoisto";
                this.sub_hasta.Items.Add("0");
                this.sub_hasta.DataBind();
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        private void MensajeError(string mensaje)
        {
            this.lblError.Visible = true;
            this.lblError.Text = mensaje;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.objSeg.Credentials = CredentialCache.DefaultCredentials;
            if (!this.Page.IsPostBack)
            {
                //if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
                if (!Operators.ConditionalCompareObjectNotEqual(this.Session[7], "", false))
                {
                    this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
                }
                else
                {
                    this.Configuracion();
                }
            }
        }

        public void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            IEnumerator<ReportParameterInfo> enumerator = null;
            try
            {
                ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
                DataSet ds = new DataSet();
                string temp = "";
                //using (int i = 0)
                int i = 0;
                {
                    enumerator = DrillThroughValues.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ReportParameterInfo d = enumerator.Current;
                        temp = (Operators.CompareString(temp, "", false) != 0 ? string.Concat(temp, ",", d.Values[0].ToString().Trim()) : d.Values[0].ToString().Trim());
                        i = checked(i + 1);
                    }
                }
                string[] parametros = temp.Split(new char[] { ',' });
                ds = this.oData.detalle_subdeposito(parametros, Conversions.ToString(this.Session["Conexion"]));
                LocalReport drillthroughReport = (LocalReport)e.Report;
                ReportDataSource dataSource = new ReportDataSource("principal_detalle_subdeposito", ds.Tables[0]);
                drillthroughReport.DataSources.Add(dataSource);
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                this.MensajeError(exception.Message);
                ProjectData.ClearProjectError();
            }
        }
    }
}