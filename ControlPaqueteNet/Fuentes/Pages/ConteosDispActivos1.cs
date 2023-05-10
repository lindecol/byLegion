using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
	public class ConteosDispActivos1 : System.Web.UI.Page
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

		[AccessedThroughProperty("lblPropiedad")]
		private Label _lblPropiedad;

		[AccessedThroughProperty("cmbPropiedad")]
		private DropDownList _cmbPropiedad;

		[AccessedThroughProperty("lblFamilia")]
		private Label _lblFamilia;

		[AccessedThroughProperty("txtFamilia")]
		private TextBox _txtFamilia;

		[AccessedThroughProperty("lblCantidad")]
		private Label _lblCantidad;

		[AccessedThroughProperty("txtCantidad")]
		private TextBox _txtCantidad;

		[AccessedThroughProperty("ibAtras")]
		private ImageButton _ibAtras;

		[AccessedThroughProperty("ibActivoPropio")]
		private ImageButton _ibActivoPropio;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

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
					ConteosDispActivos1 conteosDispActivos1 = this;
					this._cmbPropiedad.SelectedIndexChanged -= new EventHandler(conteosDispActivos1.cmbPropiedad_SelectedIndexChanged);
				}
				this._cmbPropiedad = value;
				if (this._cmbPropiedad != null)
				{
					ConteosDispActivos1 conteosDispActivos11 = this;
					this._cmbPropiedad.SelectedIndexChanged += new EventHandler(conteosDispActivos11.cmbPropiedad_SelectedIndexChanged);
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

		protected virtual ImageButton ibActivoPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibActivoPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibActivoPropio != null)
				{
					ConteosDispActivos1 conteosDispActivos1 = this;
					this._ibActivoPropio.Click -= new ImageClickEventHandler(conteosDispActivos1.ibActivoPropio_Click);
				}
				this._ibActivoPropio = value;
				if (this._ibActivoPropio != null)
				{
					ConteosDispActivos1 conteosDispActivos11 = this;
					this._ibActivoPropio.Click += new ImageClickEventHandler(conteosDispActivos11.ibActivoPropio_Click);
				}
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
					ConteosDispActivos1 conteosDispActivos1 = this;
					this._ibAtras.Click -= new ImageClickEventHandler(conteosDispActivos1.ibAtras_Click);
				}
				this._ibAtras = value;
				if (this._ibAtras != null)
				{
					ConteosDispActivos1 conteosDispActivos11 = this;
					this._ibAtras.Click += new ImageClickEventHandler(conteosDispActivos11.ibAtras_Click);
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
					ConteosDispActivos1 conteosDispActivos1 = this;
					this._txtSerial.TextChanged -= new EventHandler(conteosDispActivos1.txtSerial_TextChanged);
				}
				this._txtSerial = value;
				if (this._txtSerial != null)
				{
					ConteosDispActivos1 conteosDispActivos11 = this;
					this._txtSerial.TextChanged += new EventHandler(conteosDispActivos11.txtSerial_TextChanged);
				}
			}
		}

		[DebuggerNonUserCode]
		static ConteosDispActivos1()
		{
			ConteosDispActivos1.__ENCList = new ArrayList();
		}

		public ConteosDispActivos1()
		{
			ConteosDispActivos1 conteosDispActivos1 = this;
			base.Load += new EventHandler(conteosDispActivos1.Page_Load);
			ArrayList _ENCList = ConteosDispActivos1.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ConteosDispActivos1.__ENCList.Add(new WeakReference(this));
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
			if (this.cmbPropiedad.SelectedIndex != 1)
			{
				this.lblFamilia.Text = "Familia";
			}
			else
			{
				this.lblFamilia.Text = "Código";
			}
		}

		private void ibActivoPropio_Click(object sender, ImageClickEventArgs e)
		{
			char[] chrArray;
			this.lblError.Visible = false;
			try
			{
				if (this.lblAnular.Visible)
				{
					if (!this.rbSiAnula.Checked)
					{
						this.MensajeError("Operación exitósa");
					}
					else
					{
						string RegistrarConteo = this.wsData.ConsultarConteo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), this.txtSerial.Text, "B", Conversions.ToString(this.Session["UsuarioRegistro"]));
						chrArray = new char[] { '-' };
						string[] Vector = RegistrarConteo.Split(chrArray);
						if (Conversions.ToDouble(Vector[0]) == 0)
						{
							this.MensajeError(Vector[1]);
						}
						else
						{
							this.MensajeError(Vector[1]);
						}
					}
					this.cmbPropiedad.SelectedIndex = 0;
					this.txtSerial.Text = "";
					this.txtFamilia.Text = "";
					this.txtCantidad.Text = "";
					this.lblAnular.Visible = false;
					this.rbSiAnula.Visible = false;
					this.rbNoAnula.Visible = false;
				}
				else if (Operators.CompareString(this.txtFamilia.Text, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de activo");
				}
				else if (Operators.CompareString(this.txtCantidad.Text, "", false) == 0)
				{
					this.MensajeError("La cantidad no puede ser vacío");
				}
				else if (Conversions.ToInteger(this.txtCantidad.Text) >= 0)
				{
					string str = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), checked((int)Conversions.ToLong(this.txtFamilia.Text)), this.cmbPropiedad.SelectedValue);
					chrArray = new char[] { '-' };
					string[] vector = str.Split(chrArray);
					if (Conversions.ToDouble(vector[0]) != 0)
					{
						this.MensajeError(string.Concat(vector[0], "-", vector[1]));
					}
					else
					{
						string str1 = this.wsData.GuardarActivosPocket(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "AP", Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToLong(this.txtFamilia.Text), Conversions.ToInteger(this.txtCantidad.Text), this.cmbPropiedad.SelectedValue);
						chrArray = new char[] { '-' };
						string[] Registro = str1.Split(chrArray);
						if (Conversions.ToDouble(Registro[0]) == 0)
						{
							this.cmbPropiedad.SelectedIndex = 0;
							this.txtFamilia.Text = "";
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
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
			this.txtSerial.Focus();
		}

		private void ibAtras_Click(object sender, ImageClickEventArgs e)
		{
			this.Response.Redirect("ConsultaConteos.aspx");
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
			if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Conteo"], "", false))
			{
				this.Response.Redirect("ErrorDispositivo.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEREG"), "1", false) != 0)
			{
				this.Response.Redirect("ErrorDispositivo.aspx?mensaje=No está autorizado el ingreso");
			}
			else
			{
				if (!this.Page.IsPostBack)
				{
					this.lblConteo.Text = Conversions.ToString(Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]));
				}
				this.txtCantidad.Attributes.Add("OnKeyPress", "return esInteger(event)");
				this.txtFamilia.Attributes.Add("OnKeyPress", "return esInteger(event)");
				this.txtSerial.Focus();
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
				if (Operators.CompareString(Vector[2], "S", false) != 0)
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