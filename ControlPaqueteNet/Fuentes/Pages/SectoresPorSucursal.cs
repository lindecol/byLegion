using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Factory;
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
	/// Clase SectoresPorSucursal.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class SectoresPorSucursal : System.Web.UI.Page
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

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("grSucursal")]
		private GridView _grSucursal;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

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
				this._cmbSector = value;
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
					SectoresPorSucursal sectoresPorSucursal = this;
					this._cmbSucursal.SelectedIndexChanged -= new EventHandler(sectoresPorSucursal.cmbSucursal_SelectedIndexChanged);
				}
				this._cmbSucursal = value;
				if (this._cmbSucursal != null)
				{
					SectoresPorSucursal sectoresPorSucursal1 = this;
					this._cmbSucursal.SelectedIndexChanged += new EventHandler(sectoresPorSucursal1.cmbSucursal_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grSucursal
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grSucursal;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grSucursal != null)
				{
					SectoresPorSucursal sectoresPorSucursal = this;
					this._grSucursal.SelectedIndexChanged -= new EventHandler(sectoresPorSucursal.grSucursal_SelectedIndexChanged);
				}
				this._grSucursal = value;
				if (this._grSucursal != null)
				{
					SectoresPorSucursal sectoresPorSucursal1 = this;
					this._grSucursal.SelectedIndexChanged += new EventHandler(sectoresPorSucursal1.grSucursal_SelectedIndexChanged);
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
					SectoresPorSucursal sectoresPorSucursal = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(sectoresPorSucursal.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					SectoresPorSucursal sectoresPorSucursal1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(sectoresPorSucursal1.ibGuardar_Click);
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
		static SectoresPorSucursal()
		{
			SectoresPorSucursal.__ENCList = new ArrayList();
		}

		public SectoresPorSucursal()
		{
			SectoresPorSucursal sectoresPorSucursal = this;
			base.Load += new EventHandler(sectoresPorSucursal.Page_Load);
			ArrayList _ENCList = SectoresPorSucursal.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				SectoresPorSucursal.__ENCList.Add(new WeakReference(this));
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
				DataSet ConsultarSectores = this.wsData.CargarSectores(Conversions.ToString(this.Session["Conexion"]));
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

		public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CrearGrilla(this.cmbSucursal.SelectedValue);
		}

		public void CrearGrilla(string sucursal)
		{
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sucursal, "", false) != 0)
			{
				try
				{
					this.lblError.Visible = false;
					DataSet CrearSucursales = this.wsData.CrearSectorSucursal(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(sucursal), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
					this.grSucursal.DataSource = CrearSucursales.Tables[0];
					this.grSucursal.DataBind();
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					this.MensajeError(exception.Message);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void EliminarRegistro(int Sucursal, string Sector)
		{
			try
			{
				this.lblError.Visible = false;
				string EliminarSucursal = this.wsData.EliminarSucursal(Conversions.ToString(this.Session["Conexion"]), Sucursal, Sector, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(EliminarSucursal, "", false) == 0)
				{
					this.CrearGrilla(this.cmbSucursal.SelectedValue);
				}
				else
				{
					this.MensajeError(EliminarSucursal);
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
			this.EliminarRegistro(Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.grSucursal.Rows[this.grSucursal.SelectedIndex].Cells[0].Text);
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.InsertarRegistro();
		}

		private void InsertarRegistro()
		{
			this.lblError.Visible = false;
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cmbSucursal.Text, "", false) != 0)
			{
				try
				{
					string InsertarSucursal = this.wsData.InsertarSucursal(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), this.cmbSector.SelectedValue, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["UsuarioRegistro"]));
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(InsertarSucursal, "", false) == 0)
					{
						this.CrearGrilla(this.cmbSucursal.SelectedValue);
					}
					else
					{
						this.MensajeError(InsertarSucursal);
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
				this.MensajeError("Debe seleccionar una sucursal");
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARSESU"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.CargarSucursales();
				this.CargarSectores();
				this.CrearGrilla("");
			}
		}
	}
}