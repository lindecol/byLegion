using AjaxControlToolkit;
using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
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
	public class motivoAnulacion : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("txtDescripcion")]
		private TextBox _txtDescripcion;

		[AccessedThroughProperty("chkActivo")]
		private CheckBox _chkActivo;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("grAnulacion")]
		private GridView _grAnulacion;

		[AccessedThroughProperty("FilteredTextBoxExtender4")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender4;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual CheckBox chkActivo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkActivo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkActivo = value;
			}
		}

		protected virtual FilteredTextBoxExtender FilteredTextBoxExtender4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._FilteredTextBoxExtender4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FilteredTextBoxExtender4 = value;
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
					motivoAnulacion _motivoAnulacion = this;
					this._grAnulacion.SelectedIndexChanged -= new EventHandler(_motivoAnulacion.grAnulacion_SelectedIndexChanged);
				}
				this._grAnulacion = value;
				if (this._grAnulacion != null)
				{
					motivoAnulacion _motivoAnulacion1 = this;
					this._grAnulacion.SelectedIndexChanged += new EventHandler(_motivoAnulacion1.grAnulacion_SelectedIndexChanged);
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
					motivoAnulacion _motivoAnulacion = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(_motivoAnulacion.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					motivoAnulacion _motivoAnulacion1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(_motivoAnulacion1.ibGuardar_Click);
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

		protected virtual TextBox txtDescripcion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtDescripcion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtDescripcion = value;
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
		static motivoAnulacion()
		{
			motivoAnulacion.__ENCList = new ArrayList();
		}

		public motivoAnulacion()
		{
			motivoAnulacion _motivoAnulacion = this;
			base.Load += new EventHandler(_motivoAnulacion.Page_Load);
			ArrayList _ENCList = motivoAnulacion.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				motivoAnulacion.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CargarDatos(string Codigo, string Descripcion, string Estado)
		{
			try
			{
				this.lblError.Visible = false;
				this.txtDescripcion.Text = Descripcion;
				this.chkActivo.Visible = true;
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Estado, "Activo", false) != 0)
				{
					this.chkActivo.Checked = false;
				}
				else
				{
					this.chkActivo.Checked = true;
				}
				this.Session["Codigo"] = Codigo;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void CrearGrilla()
		{
			try
			{
				this.lblError.Visible = false;
				DataSet CrearMotivoAnulacion = this.wsData.CrearMotivoAnulacion(Conversions.ToString(this.Session["Conexion"]));
				if (CrearMotivoAnulacion.Tables[0].Rows.Count > 0)
				{
					this.grAnulacion.DataSource = CrearMotivoAnulacion.Tables[0];
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
			GridViewRow item = this.grAnulacion.Rows[this.grAnulacion.SelectedIndex];
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(item.Cells[2].Text, "Activo", false) != 0)
			{
				this.LimpiarControles();
			}
			else
			{
				this.CargarDatos(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
			}
			item = null;
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.SincronizarRegistro();
		}

		private void LimpiarControles()
		{
			this.txtDescripcion.Text = "";
			this.chkActivo.Checked = false;
			this.chkActivo.Visible = false;
			this.Session["Codigo"] = "";
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARMAN"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.CrearGrilla();
			}
		}

		private void SincronizarRegistro()
		{
			try
			{
				this.lblError.Visible = false;
				string text = this.txtDescripcion.Text;
				char[] chrArray = new char[] { ' ' };
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text.TrimEnd(chrArray), "", false) != 0)
				{
					string SincronizarMotivoAnulacion = "";
					if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.Session["Codigo"], "", false))
					{
						string Estado = "";
						Estado = (!this.chkActivo.Checked ? "I" : "A");
						SincronizarMotivoAnulacion = this.wsData.ActualizarMotivoAnulacion(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Codigo"]), this.txtDescripcion.Text, Estado, Conversions.ToString(this.Session["UsuarioRegistro"]));
					}
					else
					{
						SincronizarMotivoAnulacion = this.wsData.InsertarMotivoAnulacion(Conversions.ToString(this.Session["Conexion"]), this.txtDescripcion.Text, Conversions.ToString(this.Session["UsuarioRegistro"]));
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(SincronizarMotivoAnulacion, "", false) == 0)
					{
						this.CrearGrilla();
					}
					else
					{
						this.MensajeError(SincronizarMotivoAnulacion);
					}
					this.LimpiarControles();
				}
				else
				{
					this.MensajeError("Debe digitar una descripción");
					this.txtDescripcion.Focus();
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