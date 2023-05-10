using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Specialized;
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
	/// Clase pagCierrePapeleria.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class pagCierrePapeleria : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("lblIdconteo")]
		private Label _lblIdconteo;

		[AccessedThroughProperty("ibAtras")]
		private ImageButton _ibAtras;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("grRutasPendientes")]
		private GridView _grRutasPendientes;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("gdPapeleriaNoDigitada")]
		private GridView _gdPapeleriaNoDigitada;

		[AccessedThroughProperty("lblError1")]
		private Label _lblError1;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual GridView gdPapeleriaNoDigitada
		{
			[DebuggerNonUserCode]
			get
			{
				return this._gdPapeleriaNoDigitada;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._gdPapeleriaNoDigitada = value;
			}
		}

		protected virtual GridView grRutasPendientes
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grRutasPendientes;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._grRutasPendientes = value;
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
					pagCierrePapeleria pagCierrePapelerium = this;
					this._ibAtras.Click -= new ImageClickEventHandler(pagCierrePapelerium.ibAtras_Click);
				}
				this._ibAtras = value;
				if (this._ibAtras != null)
				{
					pagCierrePapeleria pagCierrePapelerium1 = this;
					this._ibAtras.Click += new ImageClickEventHandler(pagCierrePapelerium1.ibAtras_Click);
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
					pagCierrePapeleria pagCierrePapelerium = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(pagCierrePapelerium.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					pagCierrePapeleria pagCierrePapelerium1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(pagCierrePapelerium1.ibGuardar_Click);
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

		protected virtual Label lblError1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblError1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblError1 = value;
			}
		}

		protected virtual Label lblIdconteo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblIdconteo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblIdconteo = value;
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

		[DebuggerNonUserCode]
		static pagCierrePapeleria()
		{
			pagCierrePapeleria.__ENCList = new ArrayList();
		}

		public pagCierrePapeleria()
		{
			pagCierrePapeleria pagCierrePapelerium = this;
			base.Load += new EventHandler(pagCierrePapelerium.Page_Load);
			ArrayList _ENCList = pagCierrePapeleria.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				pagCierrePapeleria.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		/// <summary>
		/// Proceso para grabar el cierre de papeleria
		/// </summary>
		/// <remarks></remarks>
		private void grabar()
		{
			DataRow drfila;
			TextBox txtJustificacion = new TextBox();
			DataTable dtRutas = new DataTable("Rutas");
			DataTable dtPapeleria = new DataTable("Papeleria");
			try
			{
				this.lblError.Visible = false;
				this.lblError.Text = "";
				int idCierre = Convert.ToInt32(this.lblIdconteo.Text);
				dtRutas.Columns.Add("ID_CONSECUTIVO");
				dtRutas.Columns.Add("P_JUSTIFICACION");
				int count = checked(this.grRutasPendientes.Rows.Count - 1);
				for (int fila = 0; fila <= count; fila = checked(fila + 1))
				{
					txtJustificacion = (TextBox)this.grRutasPendientes.Rows[fila].FindControl("txtJustificacion");
					drfila = dtRutas.NewRow();
					drfila["ID_CONSECUTIVO"] = this.grRutasPendientes.Rows[fila].Cells[0].Text;
					drfila["P_JUSTIFICACION"] = txtJustificacion.Text;
					dtRutas.Rows.Add(drfila);
				}
				dtPapeleria.Columns.Add("ID_CONSECUTIVO");
				dtPapeleria.Columns.Add("P_DOC");
				dtPapeleria.Columns.Add("P_JUSTIFICACION");
				int num = checked(this.grRutasPendientes.Rows.Count - 1);
				for (int fila = 0; fila <= num; fila = checked(fila + 1))
				{
					txtJustificacion = (TextBox)this.grRutasPendientes.Rows[fila].FindControl("txtJustificacion");
					drfila = dtPapeleria.NewRow();
					drfila["ID_CONSECUTIVO"] = this.grRutasPendientes.Rows[fila].Cells[0].Text;
					drfila["P_DOC"] = this.grRutasPendientes.Rows[fila].Cells[5].Text;
					drfila["P_JUSTIFICACION"] = txtJustificacion.Text;
					dtPapeleria.Rows.Add(drfila);
				}
				this.wsData.CerrarPapeleria(Conversions.ToString(this.Session["Conexion"]), idCierre, Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), dtRutas, dtPapeleria);
				this.Response.Redirect("Apertura.aspx");
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Exception ex = exception;
				this.lblError.Visible = true;
				this.lblError.Text = ex.Message;
				ProjectData.ClearProjectError();
			}
		}

		protected void ibAtras_Click(object sender, ImageClickEventArgs e)
		{
			this.Response.Redirect("Apertura.aspx");
		}

		protected void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			if (this.validar())
			{
				this.grabar();
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (this.Request.QueryString.Count != 0)
			{
				this.lblIdconteo.Text = this.Request.QueryString["id_cierre"];
				if (this.lblIdconteo.Text.Equals("0"))
				{
					this.Response.Redirect("Error.aspx?mensaje=No ha seleccionado cierre");
				}
				if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
				{
					this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEAPE"), "1", false) != 0)
				{
					this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
				}
				else if (!this.IsPostBack)
				{
					this.ProcesosCierre();
				}
			}
			else
			{
				this.Response.Redirect("Error.aspx?mensaje=No ha seleccionado cierre");
			}
		}

		public void PapeleriaNoDigitada(int idCierre)
		{
			this.gdPapeleriaNoDigitada.DataSource = this.wsData.PapeleriaNoDigitada(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), idCierre).Tables[0];
			this.gdPapeleriaNoDigitada.DataBind();
		}

		public void ProcesosCierre()
		{
			int idCierre = Convert.ToInt32(this.lblIdconteo.Text);
			this.rutasNoRendidas(idCierre);
			this.PapeleriaNoDigitada(idCierre);
		}

		public void rutasNoRendidas(int idCierre)
		{
			this.grRutasPendientes.DataSource = this.wsData.RutasNoRendidas(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]), idCierre).Tables[0];
			this.grRutasPendientes.DataBind();
		}

		private bool validar()
		{
			bool validar;
			TextBox txtJustificacion = new TextBox();
			this.lblError.Text = "";
			this.lblError1.Text = "";
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			int count = checked(this.grRutasPendientes.Rows.Count - 1);
			int fila = 0;
			while (true)
			{
				if (fila > count)
				{
					int num = checked(this.gdPapeleriaNoDigitada.Rows.Count - 1);
					int fila = 0;
					while (fila <= num)
					{
						if (!((TextBox)this.gdPapeleriaNoDigitada.Rows[fila].FindControl("txtJustificacion")).Text.Trim().Length.Equals(0))
						{
							fila = checked(fila + 1);
						}
						else
						{
							this.lblError1.Text = "Debe justificar toda la papeleria!!!";
							this.lblError1.Visible = true;
							validar = false;
							return validar;
						}
					}
					validar = true;
					break;
				}
				else if (!((TextBox)this.grRutasPendientes.Rows[fila].FindControl("txtJustificacion")).Text.Trim().Length.Equals(0))
				{
					fila = checked(fila + 1);
				}
				else
				{
					this.lblError.Text = "Debe justificar toda las rutas!!!";
					this.lblError.Visible = true;
					validar = false;
					break;
				}
			}
			return validar;
		}
	}
}