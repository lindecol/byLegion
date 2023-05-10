using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
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
	/// Clase festivos.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class festivos : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("cmbSucursal")]
		private DropDownList _cmbSucursal;

		[AccessedThroughProperty("chkSabado")]
		private CheckBox _chkSabado;

		[AccessedThroughProperty("chkDomingo")]
		private CheckBox _chkDomingo;

		[AccessedThroughProperty("MiCalendario")]
		private Calendar _MiCalendario;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual CheckBox chkDomingo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkDomingo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkDomingo = value;
			}
		}

		protected virtual CheckBox chkSabado
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkSabado;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkSabado = value;
			}
		}

		protected virtual DropDownList cmbSucursal
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbSucursal;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbSucursal != null)
				{
					festivos festivo = this;
					this._cmbSucursal.SelectedIndexChanged -= new EventHandler(festivo.cmbSucursal_SelectedIndexChanged);
				}
				this._cmbSucursal = value;
				if (this._cmbSucursal != null)
				{
					festivos festivo1 = this;
					this._cmbSucursal.SelectedIndexChanged += new EventHandler(festivo1.cmbSucursal_SelectedIndexChanged);
				}
			}
		}

		protected virtual ImageButton ibGuardar
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibGuardar;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibGuardar != null)
				{
					festivos festivo = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(festivo.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					festivos festivo1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(festivo1.ibGuardar_Click);
				}
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

		protected virtual Calendar MiCalendario
		{
			[DebuggerNonUserCode]
			get
			{
				return this._MiCalendario;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._MiCalendario != null)
				{
					festivos festivo = this;
					this._MiCalendario.SelectionChanged -= new EventHandler(festivo.MiCalendario_SelectionChanged);
				}
				this._MiCalendario = value;
				if (this._MiCalendario != null)
				{
					festivos festivo1 = this;
					this._MiCalendario.SelectionChanged += new EventHandler(festivo1.MiCalendario_SelectionChanged);
				}
			}
		}

		protected virtual System.Web.UI.ScriptManager ScriptManager1
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

		protected virtual UpdatePanel UpdatePanel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._UpdatePanel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._UpdatePanel1 = value;
			}
		}

		[DebuggerNonUserCode]
		static festivos()
		{
			festivos.__ENCList = new ArrayList();
		}

		public festivos()
		{
			festivos festivo = this;
			base.Load += new EventHandler(festivo.Page_Load);
			ArrayList _ENCList = festivos.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				festivos.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CargarSucursales()
		{
			try
			{
				this.lblError.Visible = false;
				DataSet ConsultarSucursales = this.wsData.ConsultarSucursales(Conversions.ToString(this.Session["Conexion"]), -777, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (ConsultarSucursales.Tables[0].Rows.Count > 0)
				{
					this.cmbSucursal.DataSource = ConsultarSucursales.Tables[0];
					this.cmbSucursal.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.chkSabado.Checked = false;
			this.chkDomingo.Checked = false;
			this.LimpiarCalendario();
			this.ConsultarCalendario();
		}

		private void Configuracion()
		{
			this.CargarSucursales();
			List<DateTime> lstFechas = new List<DateTime>();
			this.Session["Calendario"] = lstFechas;
			List<DateTime> lstFechasEnviar = new List<DateTime>();
			this.Session["CalendarioEnviar"] = lstFechasEnviar;
		}

		private void ConsultarCalendario()
		{
			try
			{
				this.LimpiarCalendario();
				DataSet Consulta = this.wsData.ConsultarFestivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				List<DateTime> lstFechas = new List<DateTime>();
				this.Session["esFestivoSabado"] = false;
				this.Session["esFestivoDomingo"] = false;
				if (Consulta.Tables[0].Rows.Count <= 0)
				{
					this.LimpiarCalendario();
					this.MensajeError("La sucursal no tiene días festivos");
				}
				else
				{
					int count = checked(Consulta.Tables[0].Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						this.MiCalendario.SelectedDates.Add(Conversions.ToDate(Consulta.Tables[0].Rows[i][0]));
						lstFechas.Add(Conversions.ToDate(Consulta.Tables[0].Rows[i][0]));
						if (i == 0)
						{
							if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Consulta.Tables[0].Rows[i][1], "S", false))
							{
								this.Session["esFestivoSabado"] = false;
							}
							else
							{
								this.Session["esFestivoSabado"] = true;
							}
							if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Consulta.Tables[0].Rows[i][2], "S", false))
							{
								this.Session["esFestivoDomingo"] = false;
							}
							else
							{
								this.Session["esFestivoDomingo"] = true;
							}
						}
					}
					this.Session["Calendario"] = lstFechas;
					this.chkSabado.Checked = Conversions.ToBoolean(this.Session["esFestivoSabado"]);
					this.chkDomingo.Checked = Conversions.ToBoolean(this.Session["esFestivoDomingo"]);
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void GuardarFestivos()
		{
			try
			{
				this.lblError.Visible = false;
				if (this.cmbSucursal.SelectedIndex != 0)
				{
					this.lblError.Visible = true;
					List<DateTime> lstFechas = new List<DateTime>();
					lstFechas = (List<DateTime>)this.Session["CalendarioEnviar"];
					this.MensajeError(this.Session["esFestivoSabado"].ToString());
					string GenerarFestivos = this.wsData.GenerarFestivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToBoolean(this.Session["esFestivoSabado"]), this.chkSabado.Checked, Conversions.ToBoolean(this.Session["esFestivoDomingo"]), this.chkDomingo.Checked, Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), lstFechas.ToArray(), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(GenerarFestivos, "", false) != 0)
					{
						this.MensajeError(GenerarFestivos);
					}
				}
				else
				{
					this.MensajeError("Debe escoger una sucursal");
					return;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
			this.ConsultarCalendario();
		}

		private void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.GuardarFestivos();
		}

		private void LimpiarCalendario()
		{
			List<DateTime> lstFechas = new List<DateTime>();
			lstFechas = (List<DateTime>)this.Session["Calendario"];
			lstFechas.Clear();
			this.Session["Calendario"] = lstFechas;
			this.MiCalendario.SelectedDates.Clear();
			List<DateTime> lstFechasEnviar = new List<DateTime>();
			this.Session["CalendarioEnviar"] = lstFechasEnviar;
		}

		private void MensajeError(string mensaje)
		{
			this.lblError.Visible = true;
			this.lblError.Text = mensaje;
		}

		private void MiCalendario_SelectionChanged(object sender, EventArgs e)
		{
			List<DateTime> lstFechas = new List<DateTime>();
			lstFechas = (List<DateTime>)this.Session["Calendario"];
			List<DateTime> lstFechasEnviar = new List<DateTime>();
			lstFechasEnviar = (List<DateTime>)this.Session["CalendarioEnviar"];
			if (!lstFechas.Contains(this.MiCalendario.SelectedDate))
			{
				int year = this.MiCalendario.SelectedDate.Year;
				DateTime now = DateAndTime.Now;
				if (DateTime.Compare(this.MiCalendario.SelectedDate, DateAndTime.Now) >= 0 & year == now.Year)
				{
					lstFechas.Add(this.MiCalendario.SelectedDate);
					lstFechasEnviar.Add(this.MiCalendario.SelectedDate);
				}
			}
			else
			{
				lstFechas.Remove(this.MiCalendario.SelectedDate);
				lstFechasEnviar.Remove(this.MiCalendario.SelectedDate);
			}
			this.MiCalendario.SelectedDates.Clear();
			this.MiCalendario.SelectedDate = Conversions.ToDate("01/01/1950");
			int count = checked(lstFechas.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				this.MiCalendario.SelectedDates.Add(lstFechas[i]);
			}
			this.Session["Calendario"] = lstFechas;
			this.Session["CalendarioEnviar"] = lstFechasEnviar;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARFES"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.Configuracion();
			}
		}
	}
}