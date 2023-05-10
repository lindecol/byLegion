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
	/// Clase ConteosDispProductos1.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class ConteosDispProductos1 : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("form1")]
		private HtmlForm _form1;

		[AccessedThroughProperty("txtSerial")]
		private TextBox _txtSerial;

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

		[AccessedThroughProperty("ibProducto")]
		private ImageButton _ibProducto;

		private ControlPaquete.wsPackage.Service wsData;

		private int Count;

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
					ConteosDispProductos1 conteosDispProductos1 = this;
					this._ibAtras.Click -= new ImageClickEventHandler(conteosDispProductos1.ibAtras_Click);
				}
				this._ibAtras = value;
				if (this._ibAtras != null)
				{
					ConteosDispProductos1 conteosDispProductos11 = this;
					this._ibAtras.Click += new ImageClickEventHandler(conteosDispProductos11.ibAtras_Click);
				}
			}
		}

		protected virtual ImageButton ibProducto
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibProducto;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibProducto != null)
				{
					ConteosDispProductos1 conteosDispProductos1 = this;
					this._ibProducto.Click -= new ImageClickEventHandler(conteosDispProductos1.ibProducto_Click);
				}
				this._ibProducto = value;
				if (this._ibProducto != null)
				{
					ConteosDispProductos1 conteosDispProductos11 = this;
					this._ibProducto.Click += new ImageClickEventHandler(conteosDispProductos11.ibProducto_Click);
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
					ConteosDispProductos1 conteosDispProductos1 = this;
					this._txtCodigo.TextChanged -= new EventHandler(conteosDispProductos1.txtCodigo_TextChanged);
				}
				this._txtCodigo = value;
				if (this._txtCodigo != null)
				{
					ConteosDispProductos1 conteosDispProductos11 = this;
					this._txtCodigo.TextChanged += new EventHandler(conteosDispProductos11.txtCodigo_TextChanged);
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
					ConteosDispProductos1 conteosDispProductos1 = this;
					this._txtSerial.TextChanged -= new EventHandler(conteosDispProductos1.txtSerial_TextChanged);
				}
				this._txtSerial = value;
				if (this._txtSerial != null)
				{
					ConteosDispProductos1 conteosDispProductos11 = this;
					this._txtSerial.TextChanged += new EventHandler(conteosDispProductos11.txtSerial_TextChanged);
				}
			}
		}

		[DebuggerNonUserCode]
		static ConteosDispProductos1()
		{
			ConteosDispProductos1.__ENCList = new ArrayList();
		}

		public ConteosDispProductos1()
		{
			ConteosDispProductos1 conteosDispProductos1 = this;
			base.Load += new EventHandler(conteosDispProductos1.Page_Load);
			ArrayList _ENCList = ConteosDispProductos1.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ConteosDispProductos1.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.Count = 0;
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void ibAtras_Click(object sender, ImageClickEventArgs e)
		{
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
			{
				this.Response.Redirect("ConsultaConteos.aspx");
			}
		}

		private void ibProducto_Click(object sender, ImageClickEventArgs e)
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
					this.lblAnular.Visible = false;
					this.rbSiAnula.Visible = false;
					this.rbNoAnula.Visible = false;
					this.MensajeError("Operación exitósa");
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
				else if (this.Count != 1)
				{
					string str = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), checked((int)Conversions.ToLong(this.txtCodigo.Text)));
					chrArray = new char[] { '-' };
					string[] vector = str.Split(chrArray);
					if (Conversions.ToDouble(vector[0]) != 0)
					{
						this.MensajeError(string.Concat(vector[0], "-", vector[1]));
					}
					else
					{
						string str1 = this.wsData.GuardarProductosPocket(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "PP", Conversions.ToLong(this.txtCodigo.Text), Conversions.ToInteger(this.txtCantidad.Text), Conversions.ToDouble(this.cmbCapacidadProducto.SelectedValue), Conversions.ToString(this.Session["UsuarioRegistro"]), "A");
						chrArray = new char[] { '-' };
						string[] Registro = str1.Split(chrArray);
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
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
			this.txtSerial.Focus();
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
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de producto");
				}
				else
				{
					this.Count = checked(this.Count + 1);
					this.lblCapacidad.Visible = true;
					this.cmbCapacidadProducto.Visible = true;
					DataSet dtCapacidad = new DataSet();
					dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.txtCodigo.Text));
					this.cmbCapacidadProducto.Items.Clear();
					this.cmbCapacidadProducto.DataSource = null;
					this.cmbCapacidadProducto.DataBind();
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
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Vector[2], "S", false) != 0)
				{
					if (Conversions.ToDouble(Vector[0]) == 0)
					{
						this.MensajeError(Vector[1]);
					}
					else
					{
						this.MensajeError(Vector[1]);
					}
					this.txtSerial.Text = "";
				}
				else
				{
					this.lblAnular.Visible = true;
					this.rbSiAnula.Visible = true;
					this.rbNoAnula.Visible = true;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
			this.txtSerial.Enabled = true;
			this.txtSerial.Focus();
		}
	}
}