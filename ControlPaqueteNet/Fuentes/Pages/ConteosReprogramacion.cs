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
	public class ConteosReprogramacion : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("grReprogramacion")]
		private GridView _grReprogramacion;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual GridView grReprogramacion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grReprogramacion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grReprogramacion != null)
				{
					ConteosReprogramacion conteosReprogramacion = this;
					this._grReprogramacion.SelectedIndexChanged -= new EventHandler(conteosReprogramacion.grReprogramacion_SelectedIndexChanged);
				}
				this._grReprogramacion = value;
				if (this._grReprogramacion != null)
				{
					ConteosReprogramacion conteosReprogramacion1 = this;
					this._grReprogramacion.SelectedIndexChanged += new EventHandler(conteosReprogramacion1.grReprogramacion_SelectedIndexChanged);
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

		[DebuggerNonUserCode]
		static ConteosReprogramacion()
		{
			ConteosReprogramacion.__ENCList = new ArrayList();
		}

		public ConteosReprogramacion()
		{
			ConteosReprogramacion conteosReprogramacion = this;
			base.Load += new EventHandler(conteosReprogramacion.Page_Load);
			ArrayList _ENCList = ConteosReprogramacion.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ConteosReprogramacion.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		public void CrearGrilla()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearProgramacion = this.wsData.CrearProgramacion(Conversions.ToString(this.Session["Conexion"]), "P", Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), Conversions.ToString(this.Session["Agencia"]));
				if (CrearProgramacion.Tables[0].Rows.Count > 0)
				{
					this.grReprogramacion.DataSource = CrearProgramacion.Tables[0];
					this.grReprogramacion.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grReprogramacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				GridViewRow item = this.grReprogramacion.Rows[this.grReprogramacion.SelectedIndex];
				this.Session["Conteo"] = item.Cells[0].Text;
				this.Session["TipoConteo"] = item.Cells[1].Text;
				this.Session["FechaInicio"] = item.Cells[2].Text;
				this.Session["HoraInicio"] = item.Cells[3].Text;
				this.Session["HoraFin"] = item.Cells[4].Text;
				this.Session["Encargado"] = item.Cells[5].Text;
				item = null;
				this.Response.Redirect("ReprogramacionConteo.aspx");
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROREP"), "1", false) != 0)
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