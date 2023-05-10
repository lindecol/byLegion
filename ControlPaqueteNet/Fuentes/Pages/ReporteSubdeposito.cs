using AjaxControlToolkit;
using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Microsoft.Reporting.WebForms;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPaquete
{
	/// 	<summary>
	/// Clase ReporteSubdeposito.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class ReporteSubdeposito : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private ToolkitScriptManager _ScriptManager1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("sub_desde")]
		private DropDownList _sub_desde;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("sub_hasta")]
		private DropDownList _sub_hasta;

		[AccessedThroughProperty("btnScript")]
		private ImageButton _btnScript;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("ReportViewer1")]
		private ReportViewer _ReportViewer1;

		[AccessedThroughProperty("ObjectDataSource1")]
		private ObjectDataSource _ObjectDataSource1;

		private AccesoDatos oData;

		private ControlPaquete.wsPackage.Service oServices;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual ImageButton btnScript
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnScript;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._btnScript != null)
				{
					ReporteSubdeposito reporteSubdeposito = this;
					this._btnScript.Click -= new ImageClickEventHandler(reporteSubdeposito.btnScript_Click);
				}
				this._btnScript = value;
				if (this._btnScript != null)
				{
					ReporteSubdeposito reporteSubdeposito1 = this;
					this._btnScript.Click += new ImageClickEventHandler(reporteSubdeposito1.btnScript_Click);
				}
			}
		}

		protected virtual Label Label2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		protected virtual Label Label4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		protected virtual Label lblError
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblError;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblError = value;
			}
		}

		protected virtual Label lblTitulo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblTitulo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblTitulo = value;
			}
		}

		protected virtual ObjectDataSource ObjectDataSource1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ObjectDataSource1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ObjectDataSource1 = value;
			}
		}

		protected virtual ReportViewer ReportViewer1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ReportViewer1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ReportViewer1 != null)
				{
					ReporteSubdeposito reporteSubdeposito = this;
					this._ReportViewer1.Drillthrough -= new DrillthroughEventHandler(reporteSubdeposito.ReportViewer1_Drillthrough);
				}
				this._ReportViewer1 = value;
				if (this._ReportViewer1 != null)
				{
					ReporteSubdeposito reporteSubdeposito1 = this;
					this._ReportViewer1.Drillthrough += new DrillthroughEventHandler(reporteSubdeposito1.ReportViewer1_Drillthrough);
				}
			}
		}

		protected virtual ToolkitScriptManager ScriptManager1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ScriptManager1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ScriptManager1 = value;
			}
		}

		protected virtual DropDownList sub_desde
		{
			[DebuggerNonUserCode]
			get
			{
				return this._sub_desde;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._sub_desde = value;
			}
		}

		protected virtual DropDownList sub_hasta
		{
			[DebuggerNonUserCode]
			get
			{
				return this._sub_hasta;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._sub_hasta = value;
			}
		}

		[DebuggerNonUserCode]
		static ReporteSubdeposito()
		{
			ReporteSubdeposito.__ENCList = new ArrayList();
		}

		public ReporteSubdeposito()
		{
			ReporteSubdeposito reporteSubdeposito = this;
			base.Load += new EventHandler(reporteSubdeposito.Page_Load);
			ArrayList _ENCList = ReporteSubdeposito.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ReporteSubdeposito.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.oData = new AccesoDatos();
			this.oServices = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

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
				lista_subdeposito = this.oServices.ConsultarSubdepositosConfigurados(Conversions.ToString(this.Session["Conexion"]), iGrupo, iEmpresa, Conversions.ToInteger(this.Session["Agencia"]));
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
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!this.Page.IsPostBack)
			{
				if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
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
				using (int i = 0)
				{
					enumerator = DrillThroughValues.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ReportParameterInfo d = enumerator.Current;
						temp = (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(temp, "", false) != 0 ? string.Concat(temp, ",", d.Values[0].ToString().Trim()) : d.Values[0].ToString().Trim());
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