using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Factory;
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
	/// Clase Anulacion.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class Anulacion : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("txtConteo")]
		private TextBox _txtConteo;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("cmbMotivo")]
		private DropDownList _cmbMotivo;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("grAnulacion")]
		private GridView _grAnulacion;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual DropDownList cmbMotivo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbMotivo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbMotivo = value;
			}
		}

		protected virtual GridView grAnulacion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grAnulacion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grAnulacion != null)
				{
					Anulacion anulacion = this;
					this._grAnulacion.SelectedIndexChanged -= new EventHandler(anulacion.grAnulacion_SelectedIndexChanged);
				}
				this._grAnulacion = value;
				if (this._grAnulacion != null)
				{
					Anulacion anulacion1 = this;
					this._grAnulacion.SelectedIndexChanged += new EventHandler(anulacion1.grAnulacion_SelectedIndexChanged);
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
					Anulacion anulacion = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(anulacion.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					Anulacion anulacion1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(anulacion1.ibGuardar_Click);
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

		protected virtual TextBox txtConteo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtConteo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtConteo = value;
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
		static Anulacion()
		{
			Anulacion.__ENCList = new ArrayList();
		}

		public Anulacion()
		{
			Anulacion anulacion = this;
			base.Load += new EventHandler(anulacion.Page_Load);
			ArrayList _ENCList = Anulacion.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Anulacion.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CargarDatos(string Programacion)
		{
			this.lblError.Visible = false;
			try
			{
				this.txtConteo.Visible = true;
				this.cmbMotivo.Visible = true;
				this.ibGuardar.Visible = true;
				this.txtConteo.Text = Programacion;
				this.txtConteo.Enabled = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarMotivos()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet ConsultarMotivos = this.wsData.CargarMotivoAnulacion(Conversions.ToString(this.Session["Conexion"]));
				if (ConsultarMotivos.Tables[0].Rows.Count > 0)
				{
					this.cmbMotivo.DataSource = ConsultarMotivos.Tables[0];
					this.cmbMotivo.DataBind();
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
				DataSet CrearAnulacion = this.wsData.CrearCierre(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), "P", "P", Conversions.ToString(this.Session["Agencia"]));
				if (CrearAnulacion.Tables[0].Rows.Count <= 0)
				{
					this.grAnulacion.DataSource = null;
					this.grAnulacion.DataBind();
				}
				else
				{
					this.grAnulacion.DataSource = CrearAnulacion.Tables[0];
					this.grAnulacion.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grAnulacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckBox c = (CheckBox)this.grAnulacion.Rows[0].Cells[0].FindControl("cbEstado");
			GridViewRow item = this.grAnulacion.Rows[this.grAnulacion.SelectedIndex];
			this.CargarDatos(item.Cells[0].Text);
			item = null;
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.SincronizarRegistro();
		}

		private void LimpiarControles()
		{
			this.txtConteo.Text = "";
			this.cmbMotivo.SelectedIndex = 0;
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROANU"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.CrearGrilla();
				this.CargarMotivos();
			}
		}

		private void SincronizarRegistro()
		{
			this.lblError.Visible = false;
			try
			{
				List<int> lstAnula = new List<int>();
				string SincronizarAnulacion = "";
				int count = checked(this.grAnulacion.Rows.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					if (((CheckBox)this.grAnulacion.Rows[i].Cells[0].FindControl("cbEstado")).Checked)
					{
						lstAnula.Add(Conversions.ToInteger(this.grAnulacion.Rows[i].Cells[0].Text));
					}
				}
				if (lstAnula.Count > 0)
				{
					int num = checked(lstAnula.Count - 1);
					int i = 0;
					while (i <= num)
					{
						SincronizarAnulacion = this.wsData.AnularConteo(Conversions.ToString(this.Session["Conexion"]), lstAnula[i], Conversions.ToInteger(this.cmbMotivo.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]));
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(SincronizarAnulacion, "", false) == 0)
						{
							i = checked(i + 1);
						}
						else
						{
							this.MensajeError(SincronizarAnulacion);
							break;
						}
					}
					this.CrearGrilla();
					this.LimpiarControles();
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtConteo.Text, "", false) == 0)
				{
					this.MensajeError("Debe seleccionar un conteo a anular");
				}
				else
				{
					SincronizarAnulacion = this.wsData.AnularConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtConteo.Text), Conversions.ToInteger(this.cmbMotivo.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]));
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(SincronizarAnulacion, "", false) != 0)
					{
						this.MensajeError(SincronizarAnulacion);
					}
					this.CrearGrilla();
					this.LimpiarControles();
				}
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