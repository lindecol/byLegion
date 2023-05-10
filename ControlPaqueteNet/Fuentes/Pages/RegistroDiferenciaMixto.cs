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
	public class RegistroDiferenciaMixto : System.Web.UI.Page
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

		[AccessedThroughProperty("UpdateProgress1")]
		private UpdateProgress _UpdateProgress1;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("lblCodigo")]
		private Label _lblCodigo;

		[AccessedThroughProperty("txtCodigo")]
		private TextBox _txtCodigo;

		[AccessedThroughProperty("lblDiferencia")]
		private Label _lblDiferencia;

		[AccessedThroughProperty("cmbDiferencia")]
		private DropDownList _cmbDiferencia;

		[AccessedThroughProperty("grProductos")]
		private GridView _grProductos;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("lblCodigopart")]
		private Label _lblCodigopart;

		[AccessedThroughProperty("txtCodigoPart")]
		private TextBox _txtCodigoPart;

		[AccessedThroughProperty("lblDiferenciaPart")]
		private Label _lblDiferenciaPart;

		[AccessedThroughProperty("cmbDiferenciaPart")]
		private DropDownList _cmbDiferenciaPart;

		[AccessedThroughProperty("grProductosParticulares")]
		private GridView _grProductosParticulares;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("lblFamilia")]
		private Label _lblFamilia;

		[AccessedThroughProperty("txtFamilia")]
		private TextBox _txtFamilia;

		[AccessedThroughProperty("lblDifPropio")]
		private Label _lblDifPropio;

		[AccessedThroughProperty("cmbDifPropio")]
		private DropDownList _cmbDifPropio;

		[AccessedThroughProperty("grActivoPropio")]
		private GridView _grActivoPropio;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("lblFamAjeno")]
		private Label _lblFamAjeno;

		[AccessedThroughProperty("txtFamAjeno")]
		private TextBox _txtFamAjeno;

		[AccessedThroughProperty("lblDifAjeno")]
		private Label _lblDifAjeno;

		[AccessedThroughProperty("cmbDifAjeno")]
		private DropDownList _cmbDifAjeno;

		[AccessedThroughProperty("grActivoAjeno")]
		private GridView _grActivoAjeno;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual DropDownList cmbDifAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbDifAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbDifAjeno != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._cmbDifAjeno.SelectedIndexChanged -= new EventHandler(registroDiferenciaMixto.cmbDifAjeno_SelectedIndexChanged);
				}
				this._cmbDifAjeno = value;
				if (this._cmbDifAjeno != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._cmbDifAjeno.SelectedIndexChanged += new EventHandler(registroDiferenciaMixto1.cmbDifAjeno_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbDiferencia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbDiferencia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbDiferencia != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._cmbDiferencia.SelectedIndexChanged -= new EventHandler(registroDiferenciaMixto.cmbDiferencia_SelectedIndexChanged);
				}
				this._cmbDiferencia = value;
				if (this._cmbDiferencia != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._cmbDiferencia.SelectedIndexChanged += new EventHandler(registroDiferenciaMixto1.cmbDiferencia_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbDiferenciaPart
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbDiferenciaPart;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbDiferenciaPart = value;
			}
		}

		protected virtual DropDownList cmbDifPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbDifPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbDifPropio != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._cmbDifPropio.SelectedIndexChanged -= new EventHandler(registroDiferenciaMixto.cmbDifPropio_SelectedIndexChanged);
				}
				this._cmbDifPropio = value;
				if (this._cmbDifPropio != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._cmbDifPropio.SelectedIndexChanged += new EventHandler(registroDiferenciaMixto1.cmbDifPropio_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grActivoAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grActivoAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grActivoAjeno != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._grActivoAjeno.SelectedIndexChanged -= new EventHandler(registroDiferenciaMixto.grActivoAjeno_SelectedIndexChanged);
				}
				this._grActivoAjeno = value;
				if (this._grActivoAjeno != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._grActivoAjeno.SelectedIndexChanged += new EventHandler(registroDiferenciaMixto1.grActivoAjeno_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grActivoPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grActivoPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grActivoPropio != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._grActivoPropio.SelectedIndexChanged -= new EventHandler(registroDiferenciaMixto.grActivoPropio_SelectedIndexChanged);
				}
				this._grActivoPropio = value;
				if (this._grActivoPropio != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._grActivoPropio.SelectedIndexChanged += new EventHandler(registroDiferenciaMixto1.grActivoPropio_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grProductos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grProductos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grProductos != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._grProductos.SelectedIndexChanged -= new EventHandler(registroDiferenciaMixto.grProductos_SelectedIndexChanged);
				}
				this._grProductos = value;
				if (this._grProductos != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._grProductos.SelectedIndexChanged += new EventHandler(registroDiferenciaMixto1.grProductos_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grProductosParticulares
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grProductosParticulares;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._grProductosParticulares = value;
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
					RegistroDiferenciaMixto registroDiferenciaMixto = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(registroDiferenciaMixto.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					RegistroDiferenciaMixto registroDiferenciaMixto1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(registroDiferenciaMixto1.ibGuardar_Click);
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

		protected virtual Label Label5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
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

		protected virtual Label lblCodigo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblCodigo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCodigo = value;
			}
		}

		protected virtual Label lblCodigopart
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblCodigopart;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCodigopart = value;
			}
		}

		protected virtual Label lblDifAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblDifAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDifAjeno = value;
			}
		}

		protected virtual Label lblDiferencia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblDiferencia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDiferencia = value;
			}
		}

		protected virtual Label lblDiferenciaPart
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblDiferenciaPart;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDiferenciaPart = value;
			}
		}

		protected virtual Label lblDifPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblDifPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDifPropio = value;
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

		protected virtual Label lblFamAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblFamAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblFamAjeno = value;
			}
		}

		protected virtual Label lblFamilia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblFamilia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblFamilia = value;
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

		protected virtual TextBox txtCodigoPart
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtCodigoPart;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtCodigoPart = value;
			}
		}

		protected virtual TextBox txtFamAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtFamAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtFamAjeno = value;
			}
		}

		protected virtual TextBox txtFamilia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtFamilia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtFamilia = value;
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
		static RegistroDiferenciaMixto()
		{
			RegistroDiferenciaMixto.__ENCList = new ArrayList();
		}

		public RegistroDiferenciaMixto()
		{
			RegistroDiferenciaMixto registroDiferenciaMixto = this;
			base.Load += new EventHandler(registroDiferenciaMixto.Page_Load);
			ArrayList _ENCList = RegistroDiferenciaMixto.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				RegistroDiferenciaMixto.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void ActualizarGrillaActivoAjeno(int CodigoActivo, string Diferencia)
		{
			this.lblError.Visible = false;
			try
			{
				this.Session["ActivosAjenos"] = this.oFactory.ActualizarGrillaActivosDiferencia((DataTable)this.Session["ActivosAjenos"], CodigoActivo, Diferencia);
				this.grActivoAjeno.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosAjenos"]);
				this.grActivoAjeno.DataBind();
				this.cmbDifAjeno.SelectedIndex = -1;
				this.lblFamAjeno.Visible = false;
				this.txtFamAjeno.Visible = false;
				this.lblDifAjeno.Visible = false;
				this.cmbDifAjeno.Visible = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ActualizarGrillaActivoPropio(int CodigoActivo, string Diferencia)
		{
			this.lblError.Visible = false;
			try
			{
				this.Session["ActivosPropios"] = this.oFactory.ActualizarGrillaActivosDiferencia((DataTable)this.Session["ActivosPropios"], CodigoActivo, Diferencia);
				this.grActivoPropio.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosPropios"]);
				this.grActivoPropio.DataBind();
				this.cmbDifPropio.SelectedIndex = -1;
				this.lblFamilia.Visible = false;
				this.txtFamilia.Visible = false;
				this.lblDifPropio.Visible = false;
				this.cmbDifPropio.Visible = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ActualizarGrillaProducto(int CodigoProducto, string Diferencia)
		{
			this.lblError.Visible = false;
			try
			{
				this.Session["Productos"] = this.oFactory.ActualizarGrillaActivosDiferencia((DataTable)this.Session["Productos"], CodigoProducto, Diferencia);
				this.grProductos.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Productos"]);
				this.grProductos.DataBind();
				this.cmbDiferencia.SelectedIndex = -1;
				this.lblCodigo.Visible = false;
				this.txtCodigo.Visible = false;
				this.lblDiferencia.Visible = false;
				this.cmbDiferencia.Visible = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ActualizarGrillaProductoPart(int CodigoProducto, string Diferencia)
		{
			this.lblError.Visible = false;
			try
			{
				this.Session["ProductosParticulares"] = this.oFactory.ActualizarGrillaActivosDiferencia((DataTable)this.Session["ProductosParticulares"], CodigoProducto, Diferencia);
				this.grProductosParticulares.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductosParticulares"]);
				this.grProductosParticulares.DataBind();
				this.cmbDiferenciaPart.SelectedIndex = -1;
				this.lblCodigopart.Visible = false;
				this.txtCodigoPart.Visible = false;
				this.lblDiferenciaPart.Visible = false;
				this.cmbDiferenciaPart.Visible = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarDiferencias()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
				if (ConsultarDiferencias.Tables[0].Rows.Count > 0)
				{
					this.cmbDiferencia.DataSource = ConsultarDiferencias.Tables[0];
					this.cmbDiferencia.DataBind();
					this.cmbDiferenciaPart.DataSource = ConsultarDiferencias.Tables[0];
					this.cmbDiferenciaPart.DataBind();
					this.cmbDifPropio.DataSource = ConsultarDiferencias.Tables[0];
					this.cmbDifPropio.DataBind();
					this.cmbDifAjeno.DataSource = ConsultarDiferencias.Tables[0];
					this.cmbDifAjeno.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CerrarConteo(int Codigo)
		{
			this.lblError.Visible = false;
			try
			{
				string CerrarConteo = this.wsData.CerrarConteo(Conversions.ToString(this.Session["Conexion"]), Codigo, Conversions.ToString(this.Session["UsuarioRegistro"]));
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(CerrarConteo, "", false) != 0)
				{
					this.MensajeError(CerrarConteo);
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void cmbDifAjeno_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbDifAjeno.Items[this.cmbDifAjeno.SelectedIndex].Text.Length <= 11)
			{
				this.ActualizarGrillaActivoAjeno(Conversions.ToInteger(this.txtFamAjeno.Text), this.cmbDifAjeno.Items[this.cmbDifAjeno.SelectedIndex].Text);
			}
			else
			{
				this.ActualizarGrillaActivoAjeno(Conversions.ToInteger(this.txtFamAjeno.Text), this.cmbDifAjeno.Items[this.cmbDifAjeno.SelectedIndex].Text.Substring(0, 12));
			}
		}

		public void cmbDiferencia_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbDiferencia.Items[this.cmbDiferencia.SelectedIndex].Text.Length <= 11)
			{
				this.ActualizarGrillaProducto(Conversions.ToInteger(this.txtCodigo.Text), this.cmbDiferencia.Items[this.cmbDiferencia.SelectedIndex].Text);
			}
			else
			{
				this.ActualizarGrillaProducto(Conversions.ToInteger(this.txtCodigo.Text), this.cmbDiferencia.Items[this.cmbDiferencia.SelectedIndex].Text.Substring(0, 12));
			}
		}

		protected void cmbDiferenciaPart_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbDiferenciaPart.Items[this.cmbDiferenciaPart.SelectedIndex].Text.Length <= 11)
			{
				this.ActualizarGrillaProductoPart(Conversions.ToInteger(this.txtCodigoPart.Text), this.cmbDiferenciaPart.Items[this.cmbDiferenciaPart.SelectedIndex].Text);
			}
			else
			{
				this.ActualizarGrillaProductoPart(Conversions.ToInteger(this.txtCodigoPart.Text), this.cmbDiferenciaPart.Items[this.cmbDiferenciaPart.SelectedIndex].Text.Substring(0, 12));
			}
		}

		public void cmbDifPropio_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbDifPropio.Items[this.cmbDifPropio.SelectedIndex].Text.Length <= 11)
			{
				this.ActualizarGrillaActivoPropio(Conversions.ToInteger(this.txtFamilia.Text), this.cmbDifPropio.Items[this.cmbDifPropio.SelectedIndex].Text);
			}
			else
			{
				this.ActualizarGrillaActivoPropio(Conversions.ToInteger(this.txtFamilia.Text), this.cmbDifPropio.Items[this.cmbDifPropio.SelectedIndex].Text.Substring(0, 12));
			}
		}

		private void Configuracion()
		{
			this.lblError.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				this.lblSubtitulo.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
				this.CargarDiferencias();
				dt = new DataTable();
				dt.Columns.Add(new DataColumn("CODIGO_CONTEO", typeof(int)));
				dt.Columns.Add(new DataColumn("FECHA_CONTEO", typeof(DateTime)));
				dt.Columns.Add(new DataColumn("ID_ACTIVO_PRODUCTO", typeof(int)));
				dt.Columns.Add(new DataColumn("TIPO_ARTICULO", typeof(string)));
				dt.Columns.Add(new DataColumn("NOMBRE_ARTICULO", typeof(string)));
				dt.Columns.Add(new DataColumn("CANTIDAD_CONTEO", typeof(int)));
				dt.Columns.Add(new DataColumn("VOLUMEN", typeof(double)));
				dt.Columns.Add(new DataColumn("PROPIEDAD_CONTEO", typeof(string)));
				dt.Columns.Add(new DataColumn("CANTIDAD_SISTEMA", typeof(int)));
				dt.Columns.Add(new DataColumn("CAPACIDAD_SISTEMA", typeof(double)));
				dt.Columns.Add(new DataColumn("DIFERENCIA_ACTIVO", typeof(double)));
				dt.Columns.Add(new DataColumn("DIFERENCIA_PRODUCTO", typeof(double)));
				dt.Columns.Add(new DataColumn("CODIGO_MOTIVO_DIFERENCIA", typeof(int)));
				this.Session["Productos"] = dt;
				this.Session["ProductosParticulares"] = dt;
				this.Session["ActivosPropios"] = dt;
				this.Session["ActivosAjenos"] = dt;
				this.CrearGrillaProductos();
				this.CrearGrillaProductosPart();
				this.CrearGrillaActivosPropios();
				this.CrearGrillaActivosAjenos();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void CrearGrillaActivosAjenos()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearActivosAjenos = this.wsData.ConsultarDiferencias(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), "A", "A");
				if (CrearActivosAjenos.Tables[0].Rows.Count > 0)
				{
					this.grActivoAjeno.DataSource = CrearActivosAjenos.Tables[0];
					this.grActivoAjeno.DataBind();
				}
				this.Session["ActivosAjenos"] = CrearActivosAjenos.Tables[0];
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void CrearGrillaActivosPropios()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearActivosPropios = this.wsData.ConsultarDiferencias(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), "A", "P");
				if (CrearActivosPropios.Tables[0].Rows.Count > 0)
				{
					this.grActivoPropio.DataSource = CrearActivosPropios.Tables[0];
					this.grActivoPropio.DataBind();
				}
				this.Session["ActivosPropios"] = CrearActivosPropios.Tables[0];
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void CrearGrillaProductos()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearProductos = this.wsData.ConsultarDiferencias(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), "P", "P");
				if (CrearProductos.Tables[0].Rows.Count > 0)
				{
					this.grProductos.DataSource = CrearProductos.Tables[0];
					this.grProductos.DataBind();
				}
				this.Session["Productos"] = CrearProductos.Tables[0];
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void CrearGrillaProductosPart()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet CrearProductos = this.wsData.ConsultarDiferencias(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToString(this.Session["UsuarioRegistro"]), "P", "A");
				if (CrearProductos.Tables[0].Rows.Count > 0)
				{
					this.grProductosParticulares.DataSource = CrearProductos.Tables[0];
					this.grProductosParticulares.DataBind();
				}
				this.Session["ProductosParticulares"] = CrearProductos.Tables[0];
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void grActivoAjeno_DataBound(object sender, EventArgs e)
		{
			DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
			int count = checked(this.grActivoAjeno.Rows.Count - 1);
			for (int index = 0; index <= count; index = checked(index + 1))
			{
				DropDownList objCombo = (DropDownList)this.grActivoAjeno.Rows[index].FindControl("cmbDiferenciaActAjeno");
				objCombo.DataSource = ConsultarDiferencias.Tables[0];
				objCombo.DataBind();
			}
		}

		private void grActivoAjeno_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				this.lblFamAjeno.Visible = true;
				this.txtFamAjeno.Visible = true;
				this.lblDifAjeno.Visible = true;
				this.cmbDifAjeno.Visible = true;
				GridViewRow item = this.grActivoAjeno.Rows[this.grActivoAjeno.SelectedIndex];
				this.txtFamAjeno.Text = item.Cells[0].Text;
				item = null;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void grActivoPropio_DataBound(object sender, EventArgs e)
		{
			DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
			int count = checked(this.grActivoPropio.Rows.Count - 1);
			for (int index = 0; index <= count; index = checked(index + 1))
			{
				DropDownList objCombo = (DropDownList)this.grActivoPropio.Rows[index].FindControl("cmbDiferenciaActPro");
				objCombo.DataSource = ConsultarDiferencias.Tables[0];
				objCombo.DataBind();
			}
		}

		private void grActivoPropio_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				this.lblFamilia.Visible = true;
				this.txtFamilia.Visible = true;
				this.lblDifPropio.Visible = true;
				this.cmbDifPropio.Visible = true;
				GridViewRow item = this.grActivoPropio.Rows[this.grActivoPropio.SelectedIndex];
				this.txtFamilia.Text = item.Cells[0].Text;
				item = null;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void grProductos_DataBound(object sender, EventArgs e)
		{
			DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
			int count = checked(this.grProductos.Rows.Count - 1);
			for (int index = 0; index <= count; index = checked(index + 1))
			{
				DropDownList objCombo = (DropDownList)this.grProductos.Rows[index].FindControl("cmbDiferenciaProdProp");
				objCombo.DataSource = ConsultarDiferencias.Tables[0];
				objCombo.DataBind();
			}
		}

		private void grProductos_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				this.lblCodigo.Visible = true;
				this.txtCodigo.Visible = true;
				this.lblDiferencia.Visible = true;
				this.cmbDiferencia.Visible = true;
				GridViewRow item = this.grProductos.Rows[this.grProductos.SelectedIndex];
				this.txtCodigo.Text = item.Cells[0].Text;
				item = null;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void grProductosParticulares_DataBound(object sender, EventArgs e)
		{
			DataSet ConsultarDiferencias = this.wsData.CargarMotivosDiferencias(Conversions.ToString(this.Session["Conexion"]));
			int count = checked(this.grProductosParticulares.Rows.Count - 1);
			for (int index = 0; index <= count; index = checked(index + 1))
			{
				DropDownList objCombo = (DropDownList)this.grProductosParticulares.Rows[index].FindControl("cmbDiferenciaPart");
				objCombo.DataSource = ConsultarDiferencias.Tables[0];
				objCombo.DataBind();
			}
		}

		protected void grProductosParticulares_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				this.lblCodigopart.Visible = true;
				this.txtCodigoPart.Visible = true;
				this.lblDiferenciaPart.Visible = true;
				this.cmbDiferenciaPart.Visible = true;
				GridViewRow item = this.grProductosParticulares.Rows[this.grProductosParticulares.SelectedIndex];
				this.txtCodigoPart.Text = item.Cells[0].Text;
				item = null;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void GuardarMixto()
		{
			DropDownList objCombo;
			this.lblError.Visible = false;
			try
			{
				DataTable dtProductos = new DataTable();
				dtProductos = ((DataTable)this.Session["Productos"]).Copy();
				DataTable dtProductosPart = new DataTable();
				dtProductosPart = ((DataTable)this.Session["ProductosParticulares"]).Copy();
				DataTable dtAjenos = new DataTable();
				dtAjenos = ((DataTable)this.Session["ActivosAjenos"]).Copy();
				DataTable dtPropios = new DataTable();
				dtPropios = ((DataTable)this.Session["ActivosPropios"]).Copy();
				if (!(dtProductos.Rows.Count > 0 | dtAjenos.Rows.Count > 0 | dtPropios.Rows.Count > 0))
				{
					this.CerrarConteo(Conversions.ToInteger(this.Session["Conteo"]));
					this.Response.Redirect("ConteosDiferencia.aspx");
				}
				else
				{
					int count = checked(this.grProductos.Rows.Count - 1);
					for (int index = 0; index <= count; index = checked(index + 1))
					{
						objCombo = (DropDownList)this.grProductos.Rows[index].FindControl("cmbDiferenciaProdProp");
						dtProductos = this.oFactory.ActualizarGrillaActivosDiferencia(dtProductos, Conversions.ToInteger(this.grProductos.Rows[index].Cells[0].Text), objCombo.SelectedItem.Text);
					}
					int num = checked(dtProductos.Rows.Count - 1);
					int i = 0;
					while (i <= num)
					{
						if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtProductos.Rows[i][12], "0", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtProductos.Rows[i][12], " ", false))))
						{
							i = checked(i + 1);
						}
						else
						{
							this.MensajeError("Existen diferencias por justificar");
							return;
						}
					}
					int count1 = checked(this.grProductosParticulares.Rows.Count - 1);
					for (int index = 0; index <= count1; index = checked(index + 1))
					{
						objCombo = (DropDownList)this.grProductosParticulares.Rows[index].FindControl("cmbDiferenciaPart");
						dtProductosPart = this.oFactory.ActualizarGrillaActivosDiferencia(dtProductosPart, Conversions.ToInteger(this.grProductosParticulares.Rows[index].Cells[0].Text), objCombo.SelectedItem.Text);
					}
					int num1 = checked(dtProductosPart.Rows.Count - 1);
					int i = 0;
					while (i <= num1)
					{
						if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtProductosPart.Rows[i][12], "0", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtProductosPart.Rows[i][12], " ", false))))
						{
							i = checked(i + 1);
						}
						else
						{
							this.MensajeError("Existen diferencias por justificar");
							return;
						}
					}
					int count2 = checked(this.grActivoPropio.Rows.Count - 1);
					for (int index = 0; index <= count2; index = checked(index + 1))
					{
						objCombo = (DropDownList)this.grActivoPropio.Rows[index].FindControl("cmbDiferenciaActPro");
						dtPropios = this.oFactory.ActualizarGrillaActivosDiferencia(dtPropios, Conversions.ToInteger(this.grActivoPropio.Rows[index].Cells[0].Text), objCombo.SelectedItem.Text);
					}
					int num2 = checked(dtPropios.Rows.Count - 1);
					int i = 0;
					while (i <= num2)
					{
						if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtPropios.Rows[i][12], "0", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtPropios.Rows[i][12], " ", false))))
						{
							i = checked(i + 1);
						}
						else
						{
							this.MensajeError("Existen diferencias por justificar");
							return;
						}
					}
					int count3 = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int index = 0; index <= count3; index = checked(index + 1))
					{
						objCombo = (DropDownList)this.grActivoAjeno.Rows[index].FindControl("cmbDiferenciaActAjeno");
						dtAjenos = this.oFactory.ActualizarGrillaActivosDiferencia(dtAjenos, Conversions.ToInteger(this.grActivoAjeno.Rows[index].Cells[0].Text), objCombo.SelectedItem.Text);
					}
					int num3 = checked(dtAjenos.Rows.Count - 1);
					int i = 0;
					while (i <= num3)
					{
						if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtAjenos.Rows[i][12], "0", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dtAjenos.Rows[i][12], " ", false))))
						{
							i = checked(i + 1);
						}
						else
						{
							this.MensajeError("Existen diferencias por justificar");
							return;
						}
					}
					DataSet ds1 = new DataSet();
					ds1.Tables.Add(dtProductos);
					DataSet ds4 = new DataSet();
					ds4.Tables.Add(dtProductosPart);
					DataSet ds2 = new DataSet();
					ds2.Tables.Add(dtPropios);
					DataSet ds3 = new DataSet();
					ds3.Tables.Add(dtAjenos);
					string Registro = this.wsData.InsertarDiferenciaMixto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToString(this.Session["UsuarioRegistro"]), ds1, ds2, ds3, ds4);
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Registro, "", false) == 0)
					{
						this.CerrarConteo(Conversions.ToInteger(this.Session["Conteo"]));
						this.Response.Redirect("ConteosDiferencia.aspx");
					}
					else
					{
						this.MensajeError(Registro);
					}
				}
				return;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
				return;
			}
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.GuardarMixto();
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEJUS"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.Configuracion();
			}
		}
	}
}