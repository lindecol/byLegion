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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ControlPaquete
{
	/// 	<summary>
	/// Clase ConteoDispMixto.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class ConteoDispMixto : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("form1")]
		private HtmlForm _form1;

		[AccessedThroughProperty("txtSerial")]
		private TextBox _txtSerial;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("lblConteo")]
		private Label _lblConteo;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("lblAnular")]
		private Label _lblAnular;

		[AccessedThroughProperty("rbSiAnula")]
		private RadioButton _rbSiAnula;

		[AccessedThroughProperty("rbNoAnula")]
		private RadioButton _rbNoAnula;

		[AccessedThroughProperty("lblPropiedad")]
		private Label _lblPropiedad;

		[AccessedThroughProperty("cmbPropiedad")]
		private DropDownList _cmbPropiedad;

		[AccessedThroughProperty("lblTipo")]
		private Label _lblTipo;

		[AccessedThroughProperty("cmbTipo")]
		private DropDownList _cmbTipo;

		[AccessedThroughProperty("lblCodigo")]
		private Label _lblCodigo;

		[AccessedThroughProperty("txtCodigo")]
		private TextBox _txtCodigo;

		[AccessedThroughProperty("lblCantidad")]
		private Label _lblCantidad;

		[AccessedThroughProperty("txtCantidad")]
		private TextBox _txtCantidad;

		[AccessedThroughProperty("lblCapacidad")]
		private Label _lblCapacidad;

		[AccessedThroughProperty("cmbCapacidadProducto")]
		private DropDownList _cmbCapacidadProducto;

		[AccessedThroughProperty("ibAtras")]
		private ImageButton _ibAtras;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual DropDownList cmbCapacidadProducto
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbCapacidadProducto;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbCapacidadProducto = value;
			}
		}

		protected virtual DropDownList cmbPropiedad
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbPropiedad;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbPropiedad != null)
				{
					ConteoDispMixto conteoDispMixto = this;
					this._cmbPropiedad.SelectedIndexChanged -= new EventHandler(conteoDispMixto.cmbPropiedad_SelectedIndexChanged);
				}
				this._cmbPropiedad = value;
				if (this._cmbPropiedad != null)
				{
					ConteoDispMixto conteoDispMixto1 = this;
					this._cmbPropiedad.SelectedIndexChanged += new EventHandler(conteoDispMixto1.cmbPropiedad_SelectedIndexChanged);
				}
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
				if (this._cmbTipo != null)
				{
					ConteoDispMixto conteoDispMixto = this;
					this._cmbTipo.SelectedIndexChanged -= new EventHandler(conteoDispMixto.cmbTipo_SelectedIndexChanged);
				}
				this._cmbTipo = value;
				if (this._cmbTipo != null)
				{
					ConteoDispMixto conteoDispMixto1 = this;
					this._cmbTipo.SelectedIndexChanged += new EventHandler(conteoDispMixto1.cmbTipo_SelectedIndexChanged);
				}
			}
		}

		protected virtual HtmlForm form1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._form1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._form1 = value;
			}
		}

		protected virtual ImageButton ibAtras
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibAtras;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibAtras != null)
				{
					ConteoDispMixto conteoDispMixto = this;
					this._ibAtras.Click -= new ImageClickEventHandler(conteoDispMixto.ibAtras_Click);
				}
				this._ibAtras = value;
				if (this._ibAtras != null)
				{
					ConteoDispMixto conteoDispMixto1 = this;
					this._ibAtras.Click += new ImageClickEventHandler(conteoDispMixto1.ibAtras_Click);
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
					ConteoDispMixto conteoDispMixto = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(conteoDispMixto.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					ConteoDispMixto conteoDispMixto1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(conteoDispMixto1.ibGuardar_Click);
				}
			}
		}

		protected virtual Label lblAnular
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblAnular;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblAnular = value;
			}
		}

		protected virtual Label lblCantidad
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblCantidad;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCantidad = value;
			}
		}

		protected virtual Label lblCapacidad
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblCapacidad;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCapacidad = value;
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

		protected virtual Label lblConteo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblConteo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblConteo = value;
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

		protected virtual Label lblPropiedad
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblPropiedad;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPropiedad = value;
			}
		}

		protected virtual Label lblTipo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblTipo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblTipo = value;
			}
		}

		protected virtual Panel Panel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel1 = value;
			}
		}

		protected virtual RadioButton rbNoAnula
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbNoAnula;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbNoAnula = value;
			}
		}

		protected virtual RadioButton rbSiAnula
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbSiAnula;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbSiAnula = value;
			}
		}

		protected virtual TextBox txtCantidad
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtCantidad;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtCantidad = value;
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
				if (this._txtCodigo != null)
				{
					ConteoDispMixto conteoDispMixto = this;
					this._txtCodigo.TextChanged -= new EventHandler(conteoDispMixto.txtCodigo_TextChanged);
				}
				this._txtCodigo = value;
				if (this._txtCodigo != null)
				{
					ConteoDispMixto conteoDispMixto1 = this;
					this._txtCodigo.TextChanged += new EventHandler(conteoDispMixto1.txtCodigo_TextChanged);
				}
			}
		}

		protected virtual TextBox txtSerial
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtSerial;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._txtSerial != null)
				{
					ConteoDispMixto conteoDispMixto = this;
					this._txtSerial.TextChanged -= new EventHandler(conteoDispMixto.txtSerial_TextChanged);
				}
				this._txtSerial = value;
				if (this._txtSerial != null)
				{
					ConteoDispMixto conteoDispMixto1 = this;
					this._txtSerial.TextChanged += new EventHandler(conteoDispMixto1.txtSerial_TextChanged);
				}
			}
		}

		[DebuggerNonUserCode]
		static ConteoDispMixto()
		{
			ConteoDispMixto.__ENCList = new ArrayList();
		}

		public ConteoDispMixto()
		{
			ConteoDispMixto conteoDispMixto = this;
			base.Load += new EventHandler(conteoDispMixto.Page_Load);
			ArrayList _ENCList = ConteoDispMixto.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ConteoDispMixto.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbTipo.SelectedIndex != 1)
			{
				this.lblCodigo.Text = "Código";
			}
			else if (this.cmbPropiedad.SelectedIndex != 0)
			{
				this.lblCodigo.Text = "Código";
			}
			else
			{
				this.lblCodigo.Text = "Familia";
			}
		}

		private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbTipo.SelectedIndex != 0)
			{
				if (this.cmbPropiedad.SelectedIndex != 0)
				{
					this.lblCodigo.Text = "Código";
				}
				else
				{
					this.lblCodigo.Text = "Familia";
				}
				this.lblCapacidad.Visible = false;
				this.cmbCapacidadProducto.Visible = false;
			}
			else
			{
				this.lblCodigo.Text = "Código";
			}
			this.txtCodigo.Text = "";
			this.txtCantidad.Text = "";
		}

		private void ibAtras_Click(object sender, ImageClickEventArgs e)
		{
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
			{
				this.Response.Redirect("ConsultaConteos.aspx");
			}
		}

		private void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			char[] chrArray;
			this.lblError.Visible = false;
			try
			{
				if (this.lblAnular.Visible)
				{
					if (this.rbSiAnula.Checked)
					{
						string RegistrarConteo = this.wsData.ConsultarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.txtSerial.Text, "B", Conversions.ToString(this.Session["UsuarioRegistro"]));
						chrArray = new char[] { '-' };
						string[] Vector = RegistrarConteo.Split(chrArray);
						if (Conversions.ToDouble(Vector[0]) != 0)
						{
							this.MensajeError(Vector[1]);
						}
					}
					this.txtSerial.Text = "";
					this.txtCodigo.Text = "";
					this.txtCantidad.Text = "";
					this.lblCapacidad.Visible = false;
					this.cmbCapacidadProducto.Visible = false;
					this.cmbPropiedad.SelectedIndex = 0;
					this.MensajeError("Operación exitósa");
				}
				else
				{
					string propiedad = "";
					propiedad = (this.cmbPropiedad.SelectedIndex != 0 ? "A" : "P");
					if (this.cmbTipo.SelectedIndex != 0)
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
						{
							this.MensajeError("Debe digitar un código de activo");
						}
						else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
						{
							this.MensajeError("La cantidad no puede ser vacío");
						}
						else if (Conversions.ToInteger(this.txtCantidad.Text) >= 0)
						{
							string str = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), checked((int)Conversions.ToLong(this.txtCodigo.Text)), propiedad);
							chrArray = new char[] { '-' };
							string[] vector = str.Split(chrArray);
							if (Conversions.ToDouble(vector[0]) != 0)
							{
								this.cmbPropiedad.SelectedIndex = 0;
								this.txtCodigo.Text = "";
								this.txtCantidad.Text = "";
								this.MensajeError(string.Concat(vector[0], "-", vector[1]));
							}
							else
							{
								string str1 = this.wsData.GuardarActivosPocket(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "AP", Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToLong(this.txtCodigo.Text), Conversions.ToInteger(this.txtCantidad.Text), this.cmbPropiedad.SelectedValue);
								chrArray = new char[] { '-' };
								string[] Registro = str1.Split(chrArray);
								if (Conversions.ToDouble(Registro[0]) == 0)
								{
									this.cmbPropiedad.SelectedIndex = 0;
									this.txtCodigo.Text = "";
									this.txtCantidad.Text = "";
									this.MensajeError(Registro[1]);
								}
								else
								{
									this.MensajeError(Registro[1]);
								}
							}
						}
						else
						{
							this.MensajeError("La cantidad debe ser mayor que 0");
						}
					}
					else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
					{
						this.MensajeError("Debe digitar un código de producto");
					}
					else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
					{
						this.MensajeError("Debe digitar una cantidad");
					}
					else if (Conversions.ToInteger(this.txtCantidad.Text) < 0)
					{
						this.MensajeError("La cantidad debe ser mayor que 0");
					}
					else if (this.cmbCapacidadProducto.SelectedIndex != 0)
					{
						string str2 = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), checked((int)Conversions.ToLong(this.txtCodigo.Text)));
						chrArray = new char[] { '-' };
						string[] vector = str2.Split(chrArray);
						if (Conversions.ToDouble(vector[0]) != 0)
						{
							this.cmbPropiedad.SelectedIndex = 0;
							this.txtCodigo.Text = "";
							this.txtCantidad.Text = "";
							this.MensajeError(string.Concat(vector[0], "-", vector[1]));
						}
						else
						{
							string str3 = this.wsData.GuardarProductosPocket(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "PP", Conversions.ToLong(this.txtCodigo.Text), Conversions.ToInteger(this.txtCantidad.Text), Conversions.ToDouble(this.cmbCapacidadProducto.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), propiedad);
							chrArray = new char[] { '-' };
							string[] Registro = str3.Split(chrArray);
							if (Conversions.ToDouble(Registro[0]) == 0)
							{
								this.txtCodigo.Text = "";
								this.txtCantidad.Text = "";
								this.lblCapacidad.Visible = false;
								this.cmbCapacidadProducto.Visible = false;
								this.MensajeError(Registro[1]);
							}
							else
							{
								this.MensajeError(Registro[1]);
							}
						}
					}
					else
					{
						this.MensajeError("Debe escoger una capacidad");
					}
				}
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
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conteo"], "", false))
			{
				this.Response.Redirect("ErrorDispositivo.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEREG"), "1", false) != 0)
			{
				this.Response.Redirect("ErrorDispositivo.aspx?mensaje=No está autorizado el ingreso");
			}
			else
			{
				if (!this.Page.IsPostBack)
				{
					this.lblConteo.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]));
				}
				this.txtCantidad.Attributes.Add("OnKeyPress", "return esInteger(event)");
				this.txtCodigo.Attributes.Add("OnKeyPress", "return esInteger(event)");
				this.txtSerial.Focus();
			}
		}

		private void txtCodigo_TextChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				if (this.cmbTipo.SelectedIndex == 0)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
					{
						this.MensajeError("Debe digitar un código de producto");
					}
					else
					{
						this.lblCapacidad.Visible = true;
						this.cmbCapacidadProducto.Visible = true;
						this.cmbCapacidadProducto.Items.Clear();
						this.cmbCapacidadProducto.DataSource = null;
						this.cmbCapacidadProducto.DataBind();
						this.cmbCapacidadProducto.Items.Add("");
						DataSet dtCapacidad = new DataSet();
						dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.txtCodigo.Text));
						if (dtCapacidad.Tables[0].Rows.Count <= 0)
						{
							this.MensajeError("Debe digitar un código válido de producto");
							this.lblCapacidad.Visible = false;
							this.cmbCapacidadProducto.Visible = false;
						}
						else
						{
							this.cmbCapacidadProducto.DataSource = dtCapacidad.Tables[0];
							this.cmbCapacidadProducto.DataBind();
						}
					}
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				this.lblCapacidad.Visible = false;
				this.cmbCapacidadProducto.Visible = false;
				ProjectData.ClearProjectError();
			}
		}

		private void txtSerial_TextChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			this.txtSerial.Enabled = false;
			try
			{
				string RegistrarConteo = this.wsData.ConsultarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.txtSerial.Text, "C", Conversions.ToString(this.Session["UsuarioRegistro"]));
				string[] Vector = RegistrarConteo.Split(new char[] { '-' });
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Vector[2], "S", false) == 0)
				{
					this.lblAnular.Visible = true;
					this.rbSiAnula.Visible = true;
					this.rbNoAnula.Visible = true;
				}
				else if (Conversions.ToDouble(Vector[0]) == 0)
				{
					this.MensajeError(Vector[1]);
				}
				else
				{
					this.MensajeError(Vector[1]);
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
			this.txtSerial.Text = "";
			this.txtSerial.Enabled = true;
		}
	}
}