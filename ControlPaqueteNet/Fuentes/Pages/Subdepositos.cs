using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Factory;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
	/// Clase Subdepositos.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class Subdepositos : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("UpdateProgress1")]
		private UpdateProgress _UpdateProgress1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("cmbSucursal")]
		private DropDownList _cmbSucursal;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("cmbSector")]
		private DropDownList _cmbSector;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("cmbSubdeposito")]
		private DropDownList _cmbSubdeposito;

		[AccessedThroughProperty("chkCierraPapeleria")]
		private CheckBox _chkCierraPapeleria;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("grSubdeposito")]
		private GridView _grSubdeposito;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual CheckBox chkCierraPapeleria
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkCierraPapeleria;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkCierraPapeleria = value;
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
					Subdepositos subdeposito = this;
					this._cmbSector.SelectedIndexChanged -= new EventHandler(subdeposito.cmbSector_SelectedIndexChanged);
				}
				this._cmbSector = value;
				if (this._cmbSector != null)
				{
					Subdepositos subdeposito1 = this;
					this._cmbSector.SelectedIndexChanged += new EventHandler(subdeposito1.cmbSector_SelectedIndexChanged);
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
				this._cmbSubdeposito = value;
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
					Subdepositos subdeposito = this;
					this._cmbSucursal.SelectedIndexChanged -= new EventHandler(subdeposito.cmbSucursal_SelectedIndexChanged);
				}
				this._cmbSucursal = value;
				if (this._cmbSucursal != null)
				{
					Subdepositos subdeposito1 = this;
					this._cmbSucursal.SelectedIndexChanged += new EventHandler(subdeposito1.cmbSucursal_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grSubdeposito
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grSubdeposito;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grSubdeposito != null)
				{
					Subdepositos subdeposito = this;
					this._grSubdeposito.SelectedIndexChanged -= new EventHandler(subdeposito.grSucursal_SelectedIndexChanged);
				}
				this._grSubdeposito = value;
				if (this._grSubdeposito != null)
				{
					Subdepositos subdeposito1 = this;
					this._grSubdeposito.SelectedIndexChanged += new EventHandler(subdeposito1.grSucursal_SelectedIndexChanged);
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
					Subdepositos subdeposito = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(subdeposito.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					Subdepositos subdeposito1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(subdeposito1.ibGuardar_Click);
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

		protected virtual UpdateProgress UpdateProgress1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._UpdateProgress1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._UpdateProgress1 = value;
			}
		}

		[DebuggerNonUserCode]
		static Subdepositos()
		{
			Subdepositos.__ENCList = new ArrayList();
		}

		public Subdepositos()
		{
			Subdepositos subdeposito = this;
			base.Load += new EventHandler(subdeposito.Page_Load);
			ArrayList _ENCList = Subdepositos.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Subdepositos.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CargarSectores()
		{
			try
			{
				this.lblError.Visible = false;
				this.cmbSector.Items.Clear();
				this.cmbSector.DataSource = null;
				this.cmbSector.DataBind();
				this.cmbSector.Items.Add("");
				DataSet ConsultarSectores = this.wsData.CrearSectoresSubdepositos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
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

		private void CargarSubdepositos()
		{
			try
			{
				this.lblError.Visible = false;
				this.cmbSubdeposito.Items.Clear();
				this.cmbSubdeposito.DataSource = null;
				this.cmbSubdeposito.DataBind();
				this.cmbSubdeposito.Items.Add("");
				DataSet ConsultarSubdepositos = this.wsData.ConsultarSubdepositos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue));
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

		private void CargarSucursales()
		{
			try
			{
				this.lblError.Visible = false;
				DataSet ConsultarSucursales = this.wsData.ConsultarSucursales(Conversions.ToString(this.Session["Conexion"]), 0, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
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

		public void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CargarSubdepositos();
			this.CrearGrilla(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue);
		}

		public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CargarSectores();
			this.CargarSubdepositos();
			this.CrearGrilla(Conversions.ToInteger(this.cmbSucursal.SelectedValue), "");
		}

		public void CrearGrilla(int sucursal, string sector)
		{
			if (sucursal != -1)
			{
				try
				{
					this.lblError.Visible = false;
					DataSet CrearSubdepositos = this.wsData.CrearSubdepositoSector(Conversions.ToString(this.Session["Conexion"]), sucursal, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), sector);
					this.grSubdeposito.DataSource = CrearSubdepositos.Tables[0];
					this.grSubdeposito.DataBind();
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					this.MensajeError(exception.Message);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void EliminarRegistro(int Sucursal, string Sector, int Secuencia)
		{
			try
			{
				this.lblError.Visible = false;
				string EliminarSubdeposito = this.wsData.EliminarSubdepositoSector(Conversions.ToString(this.Session["Conexion"]), Sucursal, Sector, Secuencia, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(EliminarSubdeposito, "", false) == 0)
				{
					this.CrearGrilla(Sucursal, Sector);
				}
				else
				{
					this.MensajeError(EliminarSubdeposito);
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grSucursal_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.EliminarRegistro(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue, Conversions.ToInteger(this.grSubdeposito.Rows[this.grSubdeposito.SelectedIndex].Cells[0].Text));
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.InsertarRegistro();
		}

		private void InsertarRegistro()
		{
			this.lblError.Visible = false;
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cmbSucursal.Text, "", false) == 0)
			{
				this.MensajeError("Debe seleccionar una sucursal");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cmbSector.Text, "", false) != 0)
			{
				try
				{
					int ControlaPapeleria = Conversions.ToInteger(Interaction.IIf(this.chkCierraPapeleria.Checked, 1, 0));
					string InsertarSubdeposito = this.wsData.InsertarSubdepositoSector(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue, Conversions.ToInteger(this.cmbSubdeposito.SelectedValue), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["UsuarioRegistro"]), ControlaPapeleria);
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(InsertarSubdeposito, "", false) == 0)
					{
						this.CrearGrilla(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue);
					}
					else
					{
						this.MensajeError(InsertarSubdeposito);
					}
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					this.MensajeError(exception.Message);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				this.MensajeError("Debe seleccionar un sector");
			}
		}

		private void MensajeError(string mensaje)
		{
			this.lblError.Visible = true;
			this.lblError.Text = mensaje;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARSUB"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.CargarSucursales();
				this.CrearGrilla(-1, "");
			}
		}
	}
}