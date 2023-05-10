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
	/// Clase Bloqueo.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class Bloqueo : System.Web.UI.Page
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

		[AccessedThroughProperty("grCierre")]
		private GridView _grCierre;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual GridView grCierre
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grCierre;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grCierre != null)
				{
					Bloqueo bloqueo = this;
					this._grCierre.SelectedIndexChanged -= new EventHandler(bloqueo.grCierre_SelectedIndexChanged);
				}
				this._grCierre = value;
				if (this._grCierre != null)
				{
					Bloqueo bloqueo1 = this;
					this._grCierre.SelectedIndexChanged += new EventHandler(bloqueo1.grCierre_SelectedIndexChanged);
				}
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
		static Bloqueo()
		{
			Bloqueo.__ENCList = new ArrayList();
		}

		public Bloqueo()
		{
			Bloqueo bloqueo = this;
			base.Load += new EventHandler(bloqueo.Page_Load);
			ArrayList _ENCList = Bloqueo.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Bloqueo.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void BloquearConteo(int Codigo)
		{
			this.lblError.Visible = false;
			try
			{
				string BloquearConteo = this.wsData.BloquearRegistroConteo(Conversions.ToString(this.Session["Conexion"]), Codigo, Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), "B");
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(BloquearConteo, "", false) == 0)
				{
					this.CrearGrilla();
				}
				else
				{
					this.MensajeError(BloquearConteo);
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CrearGrilla()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearCierre = this.wsData.CrearCierre(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), "A", "P", Conversions.ToString(this.Session["Agencia"]));
				if (CrearCierre.Tables[0].Rows.Count <= 0)
				{
					this.grCierre.DataSource = null;
					this.grCierre.DataBind();
				}
				else
				{
					this.grCierre.DataSource = CrearCierre.Tables[0];
					this.grCierre.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grCierre_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				GridViewRow item = this.grCierre.Rows[this.grCierre.SelectedIndex];
				this.BloquearConteo(Conversions.ToInteger(item.Cells[0].Text));
				item = null;
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
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEBLO"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.CrearGrilla();
			}
		}
	}
}