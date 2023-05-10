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
	public class Apertura : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("grApertura")]
		private GridView _grApertura;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual GridView grApertura
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grApertura;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grApertura != null)
				{
					Apertura apertura = this;
					this._grApertura.RowEditing -= new GridViewEditEventHandler(apertura.grApertura_RowEditing);
					Apertura apertura1 = this;
					this._grApertura.SelectedIndexChanged -= new EventHandler(apertura1.grReprogramacion_SelectedIndexChanged);
				}
				this._grApertura = value;
				if (this._grApertura != null)
				{
					Apertura apertura2 = this;
					this._grApertura.RowEditing += new GridViewEditEventHandler(apertura2.grApertura_RowEditing);
					Apertura apertura3 = this;
					this._grApertura.SelectedIndexChanged += new EventHandler(apertura3.grReprogramacion_SelectedIndexChanged);
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
		static Apertura()
		{
			Apertura.__ENCList = new ArrayList();
		}

		public Apertura()
		{
			Apertura apertura = this;
			base.Load += new EventHandler(apertura.Page_Load);
			ArrayList _ENCList = Apertura.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Apertura.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void AbrirConteo(int Codigo)
		{
			this.lblError.Visible = false;
			try
			{
				string AperturaConteo = this.wsData.AbrirConteo(Conversions.ToString(this.Session["Conexion"]), Codigo, Conversions.ToString(this.Session["UsuarioRegistro"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToString(this.Session["Agencia"]));
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(AperturaConteo, "", false) == 0)
				{
					this.CrearGrilla();
				}
				else
				{
					this.MensajeError(AperturaConteo);
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
				DataSet CrearApertura = this.wsData.CrearCierre(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.Session["Usuario"]), "P", "A", Conversions.ToString(this.Session["Agencia"]));
				if (CrearApertura.Tables[0].Rows.Count <= 0)
				{
					this.grApertura.DataSource = null;
					this.grApertura.DataBind();
				}
				else
				{
					this.grApertura.DataSource = CrearApertura.Tables[0];
					this.grApertura.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void grApertura_DataBound(object sender, EventArgs e)
		{
			int count = checked(this.grApertura.Rows.Count - 1);
			for (int fila = 0; fila <= count; fila = checked(fila + 1))
			{
				ImageButton objCerrar = new ImageButton();
				ImageButton objAbrirConteo = new ImageButton();
				objCerrar = (ImageButton)this.grApertura.Rows[fila].FindControl("imgCerrarpapeleria");
				objCerrar.PostBackUrl = string.Concat("pagCierrePapeleria.aspx?id_cierre=", this.grApertura.Rows[fila].Cells[0].Text);
				objAbrirConteo = (ImageButton)this.grApertura.Rows[fila].FindControl("imgAbrirConteo");
				objAbrirConteo.OnClientClick = this.grApertura.Rows[fila].Cells[0].Text;
				if (this.grApertura.Rows[fila].Cells[3].Text.Equals("P"))
				{
					objCerrar.Enabled = true;
					objAbrirConteo.Enabled = false;
				}
				else if (this.grApertura.Rows[fila].Cells[3].Text.Equals("D"))
				{
					objCerrar.Enabled = false;
					objAbrirConteo.Enabled = true;
				}
			}
		}

		private void grApertura_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridViewRow item = this.grApertura.Rows[e.NewEditIndex];
			this.Session["Conteo"] = item.Cells[0].Text;
			this.Session["TipoConteo"] = item.Cells[1].Text;
			this.Session["FechaInicio"] = item.Cells[2].Text;
			this.Response.Redirect("DetalleApertura.aspx");
			item = null;
		}

		private void grReprogramacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				GridViewRow item = this.grApertura.Rows[this.grApertura.SelectedIndex];
				item = null;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void imgAbrirConteo_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton objAbrirConteo = new ImageButton();
			this.AbrirConteo(Convert.ToInt32(((ImageButton)sender).OnClientClick));
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
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEAPE"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else if (!this.Page.IsPostBack)
			{
				this.CrearGrilla();
			}
		}
	}
}