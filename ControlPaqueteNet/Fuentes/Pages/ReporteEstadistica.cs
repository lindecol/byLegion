using AjaxControlToolkit;
using ControlPaquete.wsPraxair;
using Microsoft.Reporting.WebForms;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
	/// Clase ReporteEstadistica.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class ReporteEstadistica : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private ToolkitScriptManager _ScriptManager1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("cmbTipoProgramacion")]
		private DropDownList _cmbTipoProgramacion;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("txtFechaInicio")]
		private TextBox _txtFechaInicio;

		[AccessedThroughProperty("ibFechaInicio")]
		private Image _ibFechaInicio;

		[AccessedThroughProperty("CalendarioFechaIN")]
		private CalendarExtender _CalendarioFechaIN;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("txtFechaFin")]
		private TextBox _txtFechaFin;

		[AccessedThroughProperty("Image2")]
		private Image _Image2;

		[AccessedThroughProperty("CalendarioFechaFi")]
		private CalendarExtender _CalendarioFechaFi;

		[AccessedThroughProperty("btnScript")]
		private ImageButton _btnScript;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("rvReporte")]
		private ReportViewer _rvReporte;

		[AccessedThroughProperty("ObjectDataSource1")]
		private ObjectDataSource _ObjectDataSource1;

		private AccesoDatos oData;

		private Service objSeg;

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
					ReporteEstadistica reporteEstadistica = this;
					this._btnScript.Click -= new ImageClickEventHandler(reporteEstadistica.btnScript_Click);
				}
				this._btnScript = value;
				if (this._btnScript != null)
				{
					ReporteEstadistica reporteEstadistica1 = this;
					this._btnScript.Click += new ImageClickEventHandler(reporteEstadistica1.btnScript_Click);
				}
			}
		}

		protected virtual CalendarExtender CalendarioFechaFi
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CalendarioFechaFi;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CalendarioFechaFi = value;
			}
		}

		protected virtual CalendarExtender CalendarioFechaIN
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CalendarioFechaIN;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CalendarioFechaIN = value;
			}
		}

		protected virtual DropDownList cmbTipoProgramacion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbTipoProgramacion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbTipoProgramacion = value;
			}
		}

		protected virtual Image ibFechaInicio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibFechaInicio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ibFechaInicio = value;
			}
		}

		protected virtual Image Image2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Image2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Image2 = value;
			}
		}

		protected virtual Label Label1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		protected virtual Label Label3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
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

		protected virtual ReportViewer rvReporte
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rvReporte;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rvReporte = value;
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

		protected virtual TextBox txtFechaFin
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtFechaFin;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtFechaFin = value;
			}
		}

		protected virtual TextBox txtFechaInicio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtFechaInicio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtFechaInicio = value;
			}
		}

		[DebuggerNonUserCode]
		static ReporteEstadistica()
		{
			ReporteEstadistica.__ENCList = new ArrayList();
		}

		public ReporteEstadistica()
		{
			ReporteEstadistica reporteEstadistica = this;
			base.Load += new EventHandler(reporteEstadistica.Page_Load);
			ArrayList _ENCList = ReporteEstadistica.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ReporteEstadistica.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.oData = new AccesoDatos();
			this.objSeg = new Service();
		}

		public void btnScript_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				this.lblError.Visible = false;
				if (!(this.cmbTipoProgramacion.SelectedIndex == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFechaInicio.Text, "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFechaFin.Text, "", false) == 0))
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFechaInicio.Text, "", false) != 0)
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFechaFin.Text, "", false) == 0)
						{
							this.MensajeError("Debe colocar la fecha inicio y la fecha fin");
							return;
						}
						else if (DateTime.Compare(Conversions.ToDate(this.txtFechaFin.Text), Conversions.ToDate(this.txtFechaInicio.Text)) < 0)
						{
							this.MensajeError("La fecha de inicio debe ser menor que la fecha fin");
							return;
						}
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFechaFin.Text, "", false) != 0)
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFechaInicio.Text, "", false) == 0)
						{
							this.MensajeError("Debe colocar la fecha inicio y la fecha fin");
							return;
						}
						else if (DateTime.Compare(Conversions.ToDate(this.txtFechaFin.Text), Conversions.ToDate(this.txtFechaInicio.Text)) < 0)
						{
							this.MensajeError("La fecha de inicio debe ser menor que la fecha fin");
							return;
						}
					}
					DataSet dsReporte = new DataSet();
					dsReporte = this.oData.Consulta_tabla_estadisticas(this.txtFechaInicio.Text, this.txtFechaFin.Text, Conversions.ToString(this.Session["Conexion"]), "pck_ocpp_reportes.pr_lista_estadisticas", this.cmbTipoProgramacion.SelectedValue, "", Conversions.ToString(this.Session["Agencia"]), "");
					this.rvReporte.LocalReport.DataSources.Clear();
					if (dsReporte.Tables[0].Rows.Count <= 0)
					{
						this.rvReporte.Visible = false;
					}
					else
					{
						this.rvReporte.Visible = true;
						ReportDataSource dataSource = new ReportDataSource("Reporte_Estadisticas_OCPP_REPORTE_ESTADISTICAS", dsReporte.Tables[0]);
						this.rvReporte.LocalReport.DataSources.Add(dataSource);
						this.rvReporte.LocalReport.Refresh();
						this.txtFechaFin.Text = "";
						this.txtFechaInicio.Text = "";
						this.cmbTipoProgramacion.SelectedIndex = 0;
					}
					return;
				}
				else
				{
					this.MensajeError("Debe escoger un tipo de búsqueda para el conteo");
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				this.rvReporte.LocalReport.DataSources.Clear();
				this.rvReporte.LocalReport.Refresh();
				this.rvReporte.Visible = false;
				this.txtFechaFin.Text = "";
				this.txtFechaInicio.Text = "";
				this.cmbTipoProgramacion.SelectedIndex = 0;
				ProjectData.ClearProjectError();
				return;
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
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_REPEST"), "0", false) == 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
		}
	}
}