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
	public class Etiquetas : System.Web.UI.Page
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

		[AccessedThroughProperty("txtLongitud")]
		private TextBox _txtLongitud;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("cmbTipo")]
		private DropDownList _cmbTipo;

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

		[AccessedThroughProperty("grEtiqueta")]
		private GridView _grEtiqueta;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

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

		protected virtual DropDownList cmbTipo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbTipo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbTipo = value;
			}
		}

		protected virtual GridView grEtiqueta
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grEtiqueta;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grEtiqueta != null)
				{
					Etiquetas etiqueta = this;
					this._grEtiqueta.SelectedIndexChanged -= new EventHandler(etiqueta.grEtiqueta_SelectedIndexChanged);
				}
				this._grEtiqueta = value;
				if (this._grEtiqueta != null)
				{
					Etiquetas etiqueta1 = this;
					this._grEtiqueta.SelectedIndexChanged += new EventHandler(etiqueta1.grEtiqueta_SelectedIndexChanged);
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
					Etiquetas etiqueta = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(etiqueta.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					Etiquetas etiqueta1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(etiqueta1.ibGuardar_Click);
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

		protected virtual TextBox txtLongitud
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtLongitud;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtLongitud = value;
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
		static Etiquetas()
		{
			Etiquetas.__ENCList = new ArrayList();
		}

		public Etiquetas()
		{
			Etiquetas etiqueta = this;
			base.Load += new EventHandler(etiqueta.Page_Load);
			ArrayList _ENCList = Etiquetas.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Etiquetas.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CargarDatos(string Longitud, string TipoEtiqueta, string Descripcion, string Estado)
		{
			try
			{
				this.lblError.Visible = false;
				this.txtLongitud.Text = Longitud;
				this.cmbTipo.Text = TipoEtiqueta;
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
				this.txtLongitud.Enabled = false;
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
			try
			{
				this.lblError.Visible = false;
				DataSet CrearEtiqueta = this.wsData.CrearEtiqueta(Conversions.ToString(this.Session["Conexion"]));
				if (CrearEtiqueta.Tables[0].Rows.Count > 0)
				{
					this.grEtiqueta.DataSource = CrearEtiqueta.Tables[0];
					this.grEtiqueta.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Exception ex = exception;
				this.MensajeError(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(string.Concat(ex.Message, " Conexión: "), this.Session["Conexion"])));
				ProjectData.ClearProjectError();
			}
		}

		private void grEtiqueta_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow item = this.grEtiqueta.Rows[this.grEtiqueta.SelectedIndex];
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(item.Cells[3].Text, "Activo", false) != 0)
			{
				this.LimpiarControles();
			}
			else
			{
				this.CargarDatos(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text, item.Cells[3].Text);
			}
			item = null;
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.SincronizarRegistro();
		}

		private void LimpiarControles()
		{
			this.txtLongitud.Text = "";
			this.cmbTipo.SelectedValue = "A";
			this.txtDescripcion.Text = "";
			this.chkActivo.Checked = false;
			this.chkActivo.Visible = false;
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARETI"), "1", false) != 0)
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
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtDescripcion.Text, "", false) == 0)
				{
					this.MensajeError("Debe digitar una descripción");
					this.txtDescripcion.Focus();
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtLongitud.Text, "", false) == 0)
				{
					this.MensajeError("Debe digitar la longitud de la etiqueta");
					this.txtLongitud.Focus();
				}
				else if (Conversions.ToInteger(this.txtLongitud.Text) > 0)
				{
					string SincronizarEtiqueta = "";
					if (!this.txtLongitud.Enabled)
					{
						string Estado = "";
						Estado = (!this.chkActivo.Checked ? "I" : "A");
						SincronizarEtiqueta = this.wsData.ActualizarEtiqueta(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtLongitud.Text), this.cmbTipo.SelectedValue, this.txtDescripcion.Text, Estado, Conversions.ToString(this.Session["UsuarioRegistro"]));
					}
					else
					{
						SincronizarEtiqueta = this.wsData.InsertarEtiqueta(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtLongitud.Text), this.cmbTipo.SelectedValue, this.txtDescripcion.Text, Conversions.ToString(this.Session["UsuarioRegistro"]));
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(SincronizarEtiqueta, "", false) == 0)
					{
						this.CrearGrilla();
					}
					else
					{
						this.MensajeError(SincronizarEtiqueta);
					}
					this.txtLongitud.Enabled = true;
					this.LimpiarControles();
				}
				else
				{
					this.MensajeError("La longitud de la etiqueta debe ser mayor que 0");
					this.txtLongitud.Focus();
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