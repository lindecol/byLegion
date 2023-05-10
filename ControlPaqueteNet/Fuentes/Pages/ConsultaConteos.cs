using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
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
	/// Clase ConsultaConteos.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class ConsultaConteos : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("grConteos")]
		private GridView _grConteos;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("ibSalir")]
		private ImageButton _ibSalir;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual GridView grConteos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grConteos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grConteos != null)
				{
					ConsultaConteos consultaConteo = this;
					this._grConteos.SelectedIndexChanged -= new EventHandler(consultaConteo.grConteos_SelectedIndexChanged);
				}
				this._grConteos = value;
				if (this._grConteos != null)
				{
					ConsultaConteos consultaConteo1 = this;
					this._grConteos.SelectedIndexChanged += new EventHandler(consultaConteo1.grConteos_SelectedIndexChanged);
				}
			}
		}

		protected virtual ImageButton ibSalir
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibSalir;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibSalir != null)
				{
					ConsultaConteos consultaConteo = this;
					this._ibSalir.Click -= new ImageClickEventHandler(consultaConteo.ibSalir_Click);
				}
				this._ibSalir = value;
				if (this._ibSalir != null)
				{
					ConsultaConteos consultaConteo1 = this;
					this._ibSalir.Click += new ImageClickEventHandler(consultaConteo1.ibSalir_Click);
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

		[DebuggerNonUserCode]
		static ConsultaConteos()
		{
			ConsultaConteos.__ENCList = new ArrayList();
		}

		public ConsultaConteos()
		{
			ConsultaConteos consultaConteo = this;
			base.Load += new EventHandler(consultaConteo.Page_Load);
			ArrayList _ENCList = ConsultaConteos.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ConsultaConteos.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		public void CrearGrilla()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearProgramacion = this.wsData.CrearProgramacion(Conversions.ToString(this.Session["Conexion"]), "A", Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), Conversions.ToString(this.Session["Agencia"]));
				if (CrearProgramacion.Tables[0].Rows.Count > 0)
				{
					this.grConteos.DataSource = CrearProgramacion.Tables[0];
					this.grConteos.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grConteos_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow item = this.grConteos.Rows[this.grConteos.SelectedIndex];
			this.Session["Conteo"] = item.Cells[0].Text;
			string text = item.Cells[1].Text;
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text, "ACTIVOS", false) == 0)
			{
				this.Response.Redirect("ConteosDispActivos.aspx");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text, "PRODUCTO", false) == 0)
			{
				this.Response.Redirect("ConteosDispProductos.aspx");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text, "MIXTO", false) == 0)
			{
				this.Response.Redirect("ConteosDispMixto.aspx");
			}
			item = null;
		}

		private void ibSalir_Click(object sender, ImageClickEventArgs e)
		{
			this.Response.Redirect("ErrorDispositivo.aspx?mensaje=Sesión Cerrada Exitósamente");
		}

		private void InicioAplicacion(string pDatos)
		{
			string[] Cadena = pDatos.Split(new char[] { ',' });
			this.Session["UsuarioRegistro"] = Cadena[0];
			this.Session["Password"] = Cadena[1];
			this.Session["Usuario"] = Cadena[2];
			this.Session["Grupo"] = Cadena[3];
			this.Session["Empresa"] = Cadena[4];
			this.Session["Agencia"] = Cadena[5];
			this.Session["PasswordBd"] = Cadena[6];
			this.Session["Conexion"] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(string.Concat(this.objSeg.BaseEmpresa(Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"])), ";"), this.Session["UsuarioRegistro"]), ";"), this.Session["PasswordBd"]);
		}

		private void MensajeError(string mensaje)
		{
			this.lblError.Visible = true;
			this.lblError.Text = mensaje;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			string p_Datos = "";
			if (this.Request.QueryString.Count != 0)
			{
				try
				{
					p_Datos = this.objSeg.DesEncriptar(this.Request.QueryString["ID"].ToString(), 2);
					this.InicioAplicacion(p_Datos);
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
				this.Session["UsuarioRegistro"] = ConfigurationManager.AppSettings["UsuarioRegistro"];
				this.Session["Usuario"] = ConfigurationManager.AppSettings["Usuario"];
				this.Session["Grupo"] = ConfigurationManager.AppSettings["Grupo"];
				this.Session["Empresa"] = ConfigurationManager.AppSettings["Empresa"];
				this.Session["Agencia"] = ConfigurationManager.AppSettings["Agencia"];
				HttpSessionState session = this.Session;
				string[] item = new string[] { ConfigurationManager.AppSettings["Data"], ";", ConfigurationManager.AppSettings["UsuarioBD"], ";", ConfigurationManager.AppSettings["PassBD"] };
				session["Conexion"] = string.Concat(item);
			}
			if (!this.Page.IsPostBack)
			{
				this.CrearGrilla();
			}
		}
	}
}