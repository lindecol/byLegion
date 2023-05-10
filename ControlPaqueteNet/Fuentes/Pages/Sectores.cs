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
	public class Sectores : System.Web.UI.Page
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

		[AccessedThroughProperty("txtCodigo")]
		private TextBox _txtCodigo;

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

		[AccessedThroughProperty("grSectores")]
		private GridView _grSectores;

		[AccessedThroughProperty("FilteredTextBoxExtender1")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender1;

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

		protected virtual FilteredTextBoxExtender FilteredTextBoxExtender1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._FilteredTextBoxExtender1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FilteredTextBoxExtender1 = value;
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

		protected virtual GridView grSectores
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grSectores;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grSectores != null)
				{
					Sectores sectore = this;
					this._grSectores.SelectedIndexChanged -= new EventHandler(sectore.grSectores_SelectedIndexChanged);
				}
				this._grSectores = value;
				if (this._grSectores != null)
				{
					Sectores sectore1 = this;
					this._grSectores.SelectedIndexChanged += new EventHandler(sectore1.grSectores_SelectedIndexChanged);
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
					Sectores sectore = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(sectore.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					Sectores sectore1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(sectore1.ibGuardar_Click);
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

		protected virtual TextBox txtCodigo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtCodigo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtCodigo = value;
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
		static Sectores()
		{
			Sectores.__ENCList = new ArrayList();
		}

		public Sectores()
		{
			Sectores sectore = this;
			base.Load += new EventHandler(sectore.Page_Load);
			ArrayList _ENCList = Sectores.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Sectores.__ENCList.Add(new WeakReference(this));
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
				this.txtCodigo.Text = Codigo;
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
				this.txtCodigo.Enabled = false;
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
				DataSet CrearSectores = this.wsData.Sectores(Conversions.ToString(this.Session["Conexion"]));
				if (CrearSectores.Tables[0].Rows.Count > 0)
				{
					this.grSectores.DataSource = CrearSectores.Tables[0];
					this.grSectores.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grSectores_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow item = this.grSectores.Rows[this.grSectores.SelectedIndex];
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
			this.txtCodigo.Text = "";
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PARSEC"), "1", false) != 0)
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
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código");
					this.txtCodigo.Focus();
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtDescripcion.Text, "", false) != 0)
				{
					string SincronizarSectores = "";
					if (!this.txtCodigo.Enabled)
					{
						string Estado = "";
						Estado = (!this.chkActivo.Checked ? "I" : "A");
						SincronizarSectores = this.wsData.ActualizarSectores(Conversions.ToString(this.Session["Conexion"]), this.txtCodigo.Text, Estado, this.txtDescripcion.Text, Conversions.ToString(this.Session["UsuarioRegistro"]));
					}
					else
					{
						SincronizarSectores = this.wsData.InsertarSectores(Conversions.ToString(this.Session["Conexion"]), this.txtCodigo.Text, this.txtDescripcion.Text, Conversions.ToString(this.Session["UsuarioRegistro"]));
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(SincronizarSectores, "", false) == 0)
					{
						this.CrearGrilla();
					}
					else
					{
						this.MensajeError(SincronizarSectores);
					}
					this.txtCodigo.Enabled = true;
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