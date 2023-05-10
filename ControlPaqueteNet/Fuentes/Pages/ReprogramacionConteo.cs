using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Factory;
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
	public class ReprogramacionConteo : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("lblSubtitulo")]
		private Label _lblSubtitulo;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("txtDate")]
		private TextBox _txtDate;

		[AccessedThroughProperty("ibCalendario")]
		private ImageButton _ibCalendario;

		[AccessedThroughProperty("MiCalendario")]
		private Calendar _MiCalendario;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("cmbHoraInicio")]
		private DropDownList _cmbHoraInicio;

		[AccessedThroughProperty("cmbHora")]
		private DropDownList _cmbHora;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("cmbHoraFin")]
		private DropDownList _cmbHoraFin;

		[AccessedThroughProperty("cmbHoraAP")]
		private DropDownList _cmbHoraAP;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("cmbTipoProgramacion")]
		private DropDownList _cmbTipoProgramacion;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("cmbUsuario")]
		private DropDownList _cmbUsuario;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("cmbSector")]
		private DropDownList _cmbSector;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("cmbSubdeposito")]
		private DropDownList _cmbSubdeposito;

		[AccessedThroughProperty("grConteo")]
		private GridView _grConteo;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		private List<DateTime> lstFechas;

		private Utilidades oFactory;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual DropDownList cmbHora
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHora;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHora = value;
			}
		}

		protected virtual DropDownList cmbHoraAP
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHoraAP;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHoraAP = value;
			}
		}

		protected virtual DropDownList cmbHoraFin
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHoraFin;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHoraFin = value;
			}
		}

		protected virtual DropDownList cmbHoraInicio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHoraInicio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHoraInicio = value;
			}
		}

		protected virtual DropDownList cmbSector
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbSector;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbSector != null)
				{
					ReprogramacionConteo reprogramacionConteo = this;
					this._cmbSector.SelectedIndexChanged -= new EventHandler(reprogramacionConteo.cmbSector_SelectedIndexChanged);
				}
				this._cmbSector = value;
				if (this._cmbSector != null)
				{
					ReprogramacionConteo reprogramacionConteo1 = this;
					this._cmbSector.SelectedIndexChanged += new EventHandler(reprogramacionConteo1.cmbSector_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbSubdeposito
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbSubdeposito;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbSubdeposito != null)
				{
					ReprogramacionConteo reprogramacionConteo = this;
					this._cmbSubdeposito.SelectedIndexChanged -= new EventHandler(reprogramacionConteo.cmbSubdeposito_SelectedIndexChanged);
				}
				this._cmbSubdeposito = value;
				if (this._cmbSubdeposito != null)
				{
					ReprogramacionConteo reprogramacionConteo1 = this;
					this._cmbSubdeposito.SelectedIndexChanged += new EventHandler(reprogramacionConteo1.cmbSubdeposito_SelectedIndexChanged);
				}
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

		protected virtual DropDownList cmbUsuario
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbUsuario;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbUsuario = value;
			}
		}

		protected virtual GridView grConteo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grConteo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grConteo != null)
				{
					ReprogramacionConteo reprogramacionConteo = this;
					this._grConteo.SelectedIndexChanged -= new EventHandler(reprogramacionConteo.grConteo_SelectedIndexChanged);
				}
				this._grConteo = value;
				if (this._grConteo != null)
				{
					ReprogramacionConteo reprogramacionConteo1 = this;
					this._grConteo.SelectedIndexChanged += new EventHandler(reprogramacionConteo1.grConteo_SelectedIndexChanged);
				}
			}
		}

		protected virtual ImageButton ibCalendario
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibCalendario;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibCalendario != null)
				{
					ReprogramacionConteo reprogramacionConteo = this;
					this._ibCalendario.Click -= new ImageClickEventHandler(reprogramacionConteo.ibCalendario_Click);
				}
				this._ibCalendario = value;
				if (this._ibCalendario != null)
				{
					ReprogramacionConteo reprogramacionConteo1 = this;
					this._ibCalendario.Click += new ImageClickEventHandler(reprogramacionConteo1.ibCalendario_Click);
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
					ReprogramacionConteo reprogramacionConteo = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(reprogramacionConteo.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					ReprogramacionConteo reprogramacionConteo1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(reprogramacionConteo1.ibGuardar_Click);
				}
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

		protected virtual Label Label6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
			}
		}

		protected virtual Label Label7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		protected virtual Label Label9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label9 = value;
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

		protected virtual Label lblSubtitulo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblSubtitulo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblSubtitulo = value;
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
					ReprogramacionConteo reprogramacionConteo = this;
					this._MiCalendario.SelectionChanged -= new EventHandler(reprogramacionConteo.MiCalendario_SelectionChanged);
				}
				this._MiCalendario = value;
				if (this._MiCalendario != null)
				{
					ReprogramacionConteo reprogramacionConteo1 = this;
					this._MiCalendario.SelectionChanged += new EventHandler(reprogramacionConteo1.MiCalendario_SelectionChanged);
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

		protected virtual TextBox txtDate
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtDate;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtDate = value;
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
		static ReprogramacionConteo()
		{
			ReprogramacionConteo.__ENCList = new ArrayList();
		}

		public ReprogramacionConteo()
		{
			ReprogramacionConteo reprogramacionConteo = this;
			base.Load += new EventHandler(reprogramacionConteo.Page_Load);
			ArrayList _ENCList = ReprogramacionConteo.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ReprogramacionConteo.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.oFactory = new Utilidades();
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CargarSectores(int sucursal)
		{
			this.lblError.Visible = false;
			try
			{
				this.cmbSector.Items.Clear();
				this.cmbSector.DataSource = null;
				this.cmbSector.DataBind();
				this.cmbSector.Items.Add("");
				DataSet ConsultarSectores = this.wsData.CrearSectores(Conversions.ToString(this.Session["Conexion"]), sucursal, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (ConsultarSectores.Tables[0].Rows.Count > 0)
				{
					this.cmbSector.DataSource = ConsultarSectores.Tables[0];
					this.cmbSector.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarSubdepositos(int Sucursal)
		{
			this.lblError.Visible = false;
			try
			{
				this.cmbSubdeposito.Items.Clear();
				this.cmbSubdeposito.DataSource = null;
				this.cmbSubdeposito.DataBind();
				this.cmbSubdeposito.Items.Add("");
				DataSet ConsultarSubdepositos = this.wsData.ConsultarSubdepositos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Sucursal);
				if (ConsultarSubdepositos.Tables[0].Rows.Count > 0)
				{
					this.cmbSubdeposito.DataSource = ConsultarSubdepositos.Tables[0];
					this.cmbSubdeposito.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarUsuarios()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet ConsultarUsuarios = this.wsData.ObtenerUsuarios(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (ConsultarUsuarios.Tables[0].Rows.Count > 0)
				{
					this.cmbUsuario.DataSource = ConsultarUsuarios.Tables[0];
					this.cmbUsuario.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.InsertarEnGrilla(Conversions.ToString(this.Session["SucursalConteo"]), string.Concat(this.cmbSector.SelectedValue, "-", this.cmbSector.Items[this.cmbSector.SelectedIndex].Text), "");
		}

		public void cmbSubdeposito_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.InsertarEnGrilla(Conversions.ToString(this.Session["SucursalConteo"]), "", string.Concat(this.cmbSubdeposito.SelectedValue, "-", this.cmbSubdeposito.Items[this.cmbSubdeposito.SelectedIndex].Text));
		}

		private void Configuracion()
		{
			object[] objArray;
			this.lblError.Visible = false;
			try
			{
				this.lblSubtitulo.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
				this.txtDate.Text = Strings.Format(Conversions.ToDate(this.Session["FechaInicio"]), "dddd, dd 'de' MMMM 'de' yyyy");
				this.cmbHoraInicio.SelectedIndex = this.oFactory.ObtenerIndicePorHora(Conversions.ToString(this.Session["HoraInicio"]).Substring(0, 5));
				this.cmbHora.SelectedIndex = this.oFactory.ObtenerIndiceAMPM(Conversions.ToString(this.Session["HoraInicio"]).Substring(6));
				this.cmbHoraFin.SelectedIndex = this.oFactory.ObtenerIndicePorHora(Conversions.ToString(this.Session["HoraFin"]).Substring(0, 5));
				this.cmbHoraAP.SelectedIndex = this.oFactory.ObtenerIndiceAMPM(Conversions.ToString(this.Session["HoraFin"]).Substring(6));
				DataSet dt = new DataSet();
				dt = this.wsData.ObtenerSubdepositosConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				this.grConteo.DataSource = dt.Tables[0];
				this.grConteo.DataBind();
				this.Session["Grilla"] = dt.Tables[0];
				this.Session["SucursalConteo"] = this.grConteo.Rows[0].Cells[0].Text;
				DataSet ConsultarConteo = this.wsData.ObtenerDatosConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]));
				if (ConsultarConteo.Tables[0].Rows.Count > 0)
				{
					this.cmbUsuario.SelectedValue = Conversions.ToString(ConsultarConteo.Tables[0].Rows[0][0]);
					this.cmbTipoProgramacion.SelectedValue = Conversions.ToString(ConsultarConteo.Tables[0].Rows[0][1]);
					if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(ConsultarConteo.Tables[0].Rows[0][1], "A", false))
					{
						this.cmbSector.Enabled = false;
						this.cmbSubdeposito.Enabled = true;
						object item = this.Session["SucursalConteo"];
						objArray = new object[] { 0, this.grConteo.Rows[0].Cells[0].Text.IndexOf("-") };
						this.CargarSubdepositos(Conversions.ToInteger(NewLateBinding.LateGet(item, null, "Substring", objArray, null, null, null)));
					}
					else
					{
						this.cmbSector.Enabled = true;
						this.cmbSubdeposito.Enabled = false;
						object obj = this.Session["SucursalConteo"];
						objArray = new object[] { 0, this.grConteo.Rows[0].Cells[0].Text.IndexOf("-") };
						this.CargarSectores(Conversions.ToInteger(NewLateBinding.LateGet(obj, null, "Substring", objArray, null, null, null)));
					}
				}
				this.CargarUsuarios();
				this.cmbTipoProgramacion.Enabled = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void EliminarRegistro(string Sucursal, string Sector, string Subdep)
		{
			this.lblError.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Subdep, "&nbsp;", false) == 0)
				{
					Subdep = "";
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Sector, "&nbsp;", false) == 0)
				{
					Sector = "";
				}
				this.Session["Grilla"] = this.oFactory.EliminarFilaEnGrillaProgramacion((DataTable)this.Session["Grilla"], Sucursal, Sector, Subdep);
				this.grConteo.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Grilla"]);
				this.grConteo.DataBind();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grConteo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow item = this.grConteo.Rows[this.grConteo.SelectedIndex];
			this.EliminarRegistro(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
			item = null;
		}

		public void ibCalendario_Click(object sender, ImageClickEventArgs e)
		{
			if (!this.MiCalendario.Visible)
			{
				this.MiCalendario.Visible = true;
			}
			else
			{
				this.MiCalendario.Visible = false;
			}
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			if (this.ValidarDatos())
			{
				this.InsertarRegistro();
			}
		}

		private void InsertarEnGrilla(string Sucursal, string Sector, string Subdep)
		{
			this.lblError.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["Grilla"];
				if (!this.oFactory.ExisteFilaEnGrillaProgramacion(dt, Sucursal, Sector, Subdep))
				{
					DataRow dr = dt.NewRow();
					dr[0] = Sucursal;
					dr[1] = Sector;
					dr[2] = Subdep;
					dt.Rows.Add(dr);
					this.Session["Grilla"] = dt;
					this.grConteo.DataSource = dt;
					this.grConteo.DataBind();
				}
				this.cmbSubdeposito.Text = "";
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void InsertarRegistro()
		{
			this.lblError.Visible = false;
			try
			{
				if (DateTime.Compare(this.MiCalendario.SelectedDate, Conversions.ToDate("0:00:00")) == 0)
				{
					this.MiCalendario.SelectedDate = Conversions.ToDate(this.Session["FechaInicio"]);
				}
				DataTable dt = new DataTable();
				dt = ((DataTable)this.Session["Grilla"]).Copy();
				DataSet dsRepro = new DataSet();
				dsRepro.Tables.Add(dt);
				string Reprogramacion = this.wsData.ReprogramarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.MiCalendario.SelectedDate, string.Concat(this.cmbHoraInicio.Items[this.cmbHoraInicio.SelectedIndex].Text, " ", this.cmbHora.Items[this.cmbHora.SelectedIndex].Text), string.Concat(this.cmbHoraFin.Items[this.cmbHoraFin.SelectedIndex].Text, " ", this.cmbHoraAP.Items[this.cmbHoraAP.SelectedIndex].Text), this.cmbTipoProgramacion.SelectedValue, Conversions.ToInteger(this.cmbUsuario.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), dsRepro);
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Reprogramacion, "", false) == 0)
				{
					this.Response.Redirect("ConteosReprogramacion.aspx");
				}
				else
				{
					this.MensajeError(Reprogramacion);
				}
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

		private void MiCalendario_SelectionChanged(object sender, EventArgs e)
		{
			int year = this.MiCalendario.SelectedDate.Year;
			DateTime now = DateAndTime.Now;
			if (DateTime.Compare(this.MiCalendario.SelectedDate, DateAndTime.Now) > 0 & year == now.Year)
			{
				this.txtDate.Text = Strings.Format(this.MiCalendario.SelectedDate, "dddd, dd 'de' MMMM 'de' yyyy");
				this.lblError.Visible = false;
				this.MiCalendario.Visible = false;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROREP"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else
			{
				if (!this.IsPostBack)
				{
					this.Configuracion();
				}
				this.lstFechas = new List<DateTime>();
			}
		}

		private bool ValidarDatos()
		{
			bool ValidarDatos;
			this.lblError.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				if (((DataTable)this.Session["Grilla"]).Rows.Count <= 0)
				{
					this.MensajeError("Debe escoger al menos un subdepósito para el conteo");
					ValidarDatos = false;
				}
				else if (!this.oFactory.ValidarHora(Conversions.ToInteger(this.cmbHoraInicio.SelectedValue), Conversions.ToInteger(this.cmbHoraFin.SelectedValue), Conversions.ToInteger(this.cmbHoraAP.SelectedValue)))
				{
					this.MensajeError("La hora fin no puede ser mayor que la hora inicio");
					ValidarDatos = false;
				}
				else
				{
					ValidarDatos = true;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ValidarDatos = false;
				ProjectData.ClearProjectError();
			}
			return ValidarDatos;
		}
	}
}