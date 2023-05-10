using AjaxControlToolkit;
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
	public class RegistroManualActivos : System.Web.UI.Page
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

		[AccessedThroughProperty("LinkButton1")]
		private LinkButton _LinkButton1;

		[AccessedThroughProperty("lblError1")]
		private Label _lblError1;

		[AccessedThroughProperty("grActivoPropio")]
		private GridView _grActivoPropio;

		[AccessedThroughProperty("LinkButton2")]
		private LinkButton _LinkButton2;

		[AccessedThroughProperty("lblError2")]
		private Label _lblError2;

		[AccessedThroughProperty("grActivoAjeno")]
		private GridView _grActivoAjeno;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("FilteredTextBoxExtender1")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender1;

		[AccessedThroughProperty("FilteredTextBoxExtender2")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender2;

		[AccessedThroughProperty("FilteredTextBoxExtender3")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender3;

		[AccessedThroughProperty("FilteredTextBoxExtender4")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender4;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("cmbActivoPropio")]
		private DropDownList _cmbActivoPropio;

		[AccessedThroughProperty("lblFamilia")]
		private Label _lblFamilia;

		[AccessedThroughProperty("txtFamilia")]
		private TextBox _txtFamilia;

		[AccessedThroughProperty("lblCantidad")]
		private Label _lblCantidad;

		[AccessedThroughProperty("txtCantidad")]
		private TextBox _txtCantidad;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("CancelButton")]
		private Button _CancelButton;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("ModalPopupExtender")]
		private AjaxControlToolkit.ModalPopupExtender _ModalPopupExtender;

		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("cmbActivoAjeno")]
		private DropDownList _cmbActivoAjeno;

		[AccessedThroughProperty("lblFamAjeno")]
		private Label _lblFamAjeno;

		[AccessedThroughProperty("txtFamAjeno")]
		private TextBox _txtFamAjeno;

		[AccessedThroughProperty("lblCantAjeno")]
		private Label _lblCantAjeno;

		[AccessedThroughProperty("txtCantAjeno")]
		private TextBox _txtCantAjeno;

		[AccessedThroughProperty("AgregarAjenos")]
		private Button _AgregarAjenos;

		[AccessedThroughProperty("CancelarAjenos")]
		private Button _CancelarAjenos;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("ModalPopupExtender1")]
		private AjaxControlToolkit.ModalPopupExtender _ModalPopupExtender1;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual Button AgregarAjenos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._AgregarAjenos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._AgregarAjenos = value;
			}
		}

		protected virtual Button Button1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button1 = value;
			}
		}

		protected virtual Button CancelarAjenos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CancelarAjenos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CancelarAjenos = value;
			}
		}

		protected virtual Button CancelButton
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CancelButton;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CancelButton = value;
			}
		}

		protected virtual DropDownList cmbActivoAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbActivoAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbActivoAjeno != null)
				{
					RegistroManualActivos registroManualActivo = this;
					this._cmbActivoAjeno.SelectedIndexChanged -= new EventHandler(registroManualActivo.cmbActivoAjeno_SelectedIndexChanged);
				}
				this._cmbActivoAjeno = value;
				if (this._cmbActivoAjeno != null)
				{
					RegistroManualActivos registroManualActivo1 = this;
					this._cmbActivoAjeno.SelectedIndexChanged += new EventHandler(registroManualActivo1.cmbActivoAjeno_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbActivoPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbActivoPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbActivoPropio != null)
				{
					RegistroManualActivos registroManualActivo = this;
					this._cmbActivoPropio.SelectedIndexChanged -= new EventHandler(registroManualActivo.cmbActivoPropio_SelectedIndexChanged);
				}
				this._cmbActivoPropio = value;
				if (this._cmbActivoPropio != null)
				{
					RegistroManualActivos registroManualActivo1 = this;
					this._cmbActivoPropio.SelectedIndexChanged += new EventHandler(registroManualActivo1.cmbActivoPropio_SelectedIndexChanged);
				}
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

		protected virtual FilteredTextBoxExtender FilteredTextBoxExtender2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._FilteredTextBoxExtender2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FilteredTextBoxExtender2 = value;
			}
		}

		protected virtual FilteredTextBoxExtender FilteredTextBoxExtender3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._FilteredTextBoxExtender3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FilteredTextBoxExtender3 = value;
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
				this._grActivoAjeno = value;
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
				this._grActivoPropio = value;
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
					RegistroManualActivos registroManualActivo = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(registroManualActivo.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					RegistroManualActivos registroManualActivo1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(registroManualActivo1.ibGuardar_Click);
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

		protected virtual Label Label6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
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

		protected virtual Label lblCantAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblCantAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCantAjeno = value;
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

		protected virtual Label lblError2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblError2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblError2 = value;
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

		protected virtual LinkButton LinkButton1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LinkButton1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LinkButton1 = value;
			}
		}

		protected virtual LinkButton LinkButton2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LinkButton2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LinkButton2 = value;
			}
		}

		protected virtual AjaxControlToolkit.ModalPopupExtender ModalPopupExtender
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ModalPopupExtender;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ModalPopupExtender = value;
			}
		}

		protected virtual AjaxControlToolkit.ModalPopupExtender ModalPopupExtender1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ModalPopupExtender1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ModalPopupExtender1 = value;
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

		protected virtual Panel Panel2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel2 = value;
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

		protected virtual TextBox txtCantAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtCantAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtCantAjeno = value;
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

		[DebuggerNonUserCode]
		static RegistroManualActivos()
		{
			RegistroManualActivos.__ENCList = new ArrayList();
		}

		public RegistroManualActivos()
		{
			RegistroManualActivos registroManualActivo = this;
			base.Load += new EventHandler(registroManualActivo.Page_Load);
			ArrayList _ENCList = RegistroManualActivos.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				RegistroManualActivos.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.oFactory = new Utilidades();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void ActualizarGrillaActivoAjeno(string CodigoActivo, string Cantidad)
		{
			TextBox Texto;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(CodigoActivo, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de activo");
					return;
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Cantidad, "", false) == 0)
				{
					this.MensajeError("Debe digitar una cantidad");
				}
				else if (Conversions.ToInteger(Cantidad) < 0)
				{
					this.MensajeError("La cantidad debe ser mayor o igual que 0");
				}
				else
				{
					DataTable dt = new DataTable();
					dt = (DataTable)this.Session["ActivosAjenos"];
					int count = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						dt.Rows[i][4] = Texto.Text;
					}
					bool band = false;
					int num = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.grActivoAjeno.Rows[i].Cells[0].Text, CodigoActivo, false) == 0)
						{
							Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
							Texto.Text = Cantidad;
							dt.Rows[i][4] = Texto.Text;
							band = true;
						}
					}
					if (!band)
					{
						DataRow dr = dt.NewRow();
						string[] vector = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(CodigoActivo), "A").Split(new char[] { '-' });
						if (Conversions.ToDouble(vector[0]) != 0)
						{
							this.MensajeError(string.Concat(vector[0], "-", vector[1]));
						}
						else
						{
							dr[0] = CodigoActivo;
							dr[1] = vector[2];
							dr[2] = 0;
							dr[3] = 1;
							dr[4] = Cantidad;
							dt.Rows.Add(dr);
							this.Session["ActivosAjenos"] = dt;
							this.grActivoAjeno.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosAjenos"]);
							this.grActivoAjeno.DataBind();
							TextBox x = (TextBox)this.grActivoAjeno.Rows[checked(this.grActivoAjeno.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilaAjeno");
							x.Text = Cantidad;
						}
					}
					int count1 = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= count1; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						Texto.Text = Conversions.ToString(dt.Rows[i][4]);
					}
					this.txtFamAjeno.Text = "";
					this.txtCantAjeno.Text = "";
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ActualizarGrillaActivoPropio(string CodigoActivo, string Cantidad)
		{
			TextBox Texto;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(CodigoActivo, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de familia");
					return;
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Cantidad, "", false) == 0)
				{
					this.MensajeError("Debe digitar una cantidad");
				}
				else if (Conversions.ToInteger(Cantidad) < 0)
				{
					this.MensajeError("La cantidad debe ser mayor o igual que 0");
				}
				else
				{
					DataTable dt = new DataTable();
					dt = (DataTable)this.Session["ActivosPropios"];
					int count = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
						dt.Rows[i][4] = Texto.Text;
					}
					bool band = false;
					int num = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.grActivoPropio.Rows[i].Cells[0].Text, CodigoActivo, false) == 0)
						{
							Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
							Texto.Text = Cantidad;
							dt.Rows[i][4] = Texto.Text;
							band = true;
						}
					}
					if (!band)
					{
						DataRow dr = dt.NewRow();
						string[] vector = this.wsData.NombreActivo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(CodigoActivo), "P").Split(new char[] { '-' });
						if (Conversions.ToDouble(vector[0]) != 0)
						{
							this.MensajeError(string.Concat(vector[0], "-", vector[1]));
						}
						else
						{
							dr[0] = CodigoActivo;
							dr[1] = vector[2];
							dr[2] = 0;
							dr[3] = 1;
							dr[4] = Cantidad;
							dt.Rows.Add(dr);
							this.Session["ActivosPropios"] = dt;
							this.grActivoPropio.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosPropios"]);
							this.grActivoPropio.DataBind();
							TextBox x = (TextBox)this.grActivoPropio.Rows[checked(this.grActivoPropio.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrila");
							x.Text = Cantidad;
						}
					}
					int count1 = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count1; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
						Texto.Text = Conversions.ToString(dt.Rows[i][4]);
					}
					this.txtFamilia.Text = "";
					this.txtCantidad.Text = "";
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		protected void AgregarAjenos_Click(object sender, EventArgs e)
		{
			this.ModalPopupExtender1.Hide();
			if (this.cmbActivoAjeno.SelectedIndex == 0)
			{
				this.ActualizarGrillaActivoAjeno(this.txtFamAjeno.Text, this.txtCantAjeno.Text);
			}
			else
			{
				this.InsertarEnGrillaActivoAjeno();
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			this.ModalPopupExtender.Hide();
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFamAjeno.Text, "", false) == 0)
			{
				this.ActualizarGrillaActivoPropio(this.txtFamilia.Text, this.txtCantidad.Text);
			}
		}

		private void CargarActivosAjenos()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataSet ConsultarActivosAjenos = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
				if (ConsultarActivosAjenos.Tables[0].Rows.Count > 0)
				{
					this.cmbActivoAjeno.DataSource = ConsultarActivosAjenos.Tables[0];
					this.cmbActivoAjeno.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarActivosPropios()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataSet ConsultarActivosPropios = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
				if (ConsultarActivosPropios.Tables[0].Rows.Count > 0)
				{
					this.cmbActivoPropio.DataSource = ConsultarActivosPropios.Tables[0];
					this.cmbActivoPropio.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void cmbActivoAjeno_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbActivoAjeno.SelectedIndex == 0)
			{
				this.lblFamAjeno.Visible = true;
				this.txtFamAjeno.Visible = true;
				this.lblCantAjeno.Visible = true;
				this.txtCantAjeno.Visible = true;
			}
			else
			{
				this.lblFamAjeno.Visible = false;
				this.txtFamAjeno.Visible = false;
				this.lblCantAjeno.Visible = false;
				this.txtCantAjeno.Visible = false;
			}
		}

		public void cmbActivoPropio_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.InsertarEnGrillaActivoPropio();
		}

		private void Configuracion()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				this.lblSubtitulo.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
				this.CargarActivosPropios();
				this.CargarActivosAjenos();
				dt = new DataTable();
				dt.Columns.Add(new DataColumn("CODIGO_ACTIVO", typeof(int)));
				dt.Columns.Add(new DataColumn("NOMBRE_ACTIVO", typeof(string)));
				dt.Columns.Add(new DataColumn("CAPACIDAD", typeof(double)));
				dt.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
				dt.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
				this.Session["ActivosPropios"] = dt;
				this.Session["ActivosAjenos"] = dt;
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
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataSet CrearActivosAjenos = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
				if (CrearActivosAjenos.Tables[0].Rows.Count > 0)
				{
					this.grActivoAjeno.DataSource = CrearActivosAjenos.Tables[0];
					this.grActivoAjeno.DataBind();
					int count = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						TextBox Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						Texto.Attributes.Add("OnKeyPress", "return esInteger(event)");
						Texto.Text = Conversions.ToString(CrearActivosAjenos.Tables[0].Rows[i][4]);
					}
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
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataSet CrearActivosPropios = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
				if (CrearActivosPropios.Tables[0].Rows.Count > 0)
				{
					this.grActivoPropio.DataSource = CrearActivosPropios.Tables[0];
					this.grActivoPropio.DataBind();
					int count = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
						Texto.Attributes.Add("OnKeyPress", "return esInteger(event)");
						Texto.Text = Conversions.ToString(CrearActivosPropios.Tables[0].Rows[i][4]);
					}
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

		private void GuardarActivos()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				if (!(this.grActivoAjeno.Rows.Count > 0 | this.grActivoPropio.Rows.Count > 0))
				{
					this.MensajeError("No se han registrado activos");
				}
				else
				{
					DataSet dsActivoAjeno = new DataSet();
					DataSet dsActivoPropio = new DataSet();
					DataTable dtActivoAjeno = new DataTable();
					DataTable dtActivoPropio = new DataTable();
					dtActivoAjeno.Columns.Add(new DataColumn("CODIGO", typeof(string)));
					dtActivoAjeno.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
					dtActivoPropio.Columns.Add(new DataColumn("FAMILIA", typeof(string)));
					dtActivoPropio.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
					int count = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						DataRow dr = dtActivoAjeno.NewRow();
						dr[0] = this.grActivoAjeno.Rows[i].Cells[0].Text;
						TextBox Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						dr[1] = Texto.Text;
						dtActivoAjeno.Rows.Add(dr);
					}
					dsActivoAjeno.Tables.Add(dtActivoAjeno);
					int num = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						DataRow dr = dtActivoPropio.NewRow();
						dr[0] = this.grActivoPropio.Rows[i].Cells[0].Text;
						TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
						dr[1] = Texto.Text;
						dtActivoPropio.Rows.Add(dr);
					}
					dsActivoPropio.Tables.Add(dtActivoPropio);
					string Registro = "";
					Registro = this.wsData.GuardarActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "A", Conversions.ToString(this.Session["UsuarioRegistro"]), dsActivoAjeno, dsActivoPropio);
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Registro, "", false) == 0)
					{
						this.Response.Redirect("ConteosRegistro.aspx");
					}
					else
					{
						this.MensajeError(Registro);
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

		public void ibActivoPropio_Click(object sender, ImageClickEventArgs e)
		{
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFamAjeno.Text, "", false) == 0)
			{
				this.ActualizarGrillaActivoPropio(this.txtFamilia.Text, this.txtCantidad.Text);
			}
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.GuardarActivos();
		}

		private void InsertarEnGrillaActivoAjeno()
		{
			TextBox Texto;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["ActivosAjenos"];
				if (!this.oFactory.ExisteFilaEnGrillaActivos(dt, Conversions.ToInteger(this.cmbActivoAjeno.SelectedValue)))
				{
					int count = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						dt.Rows[i][4] = Texto.Text;
					}
					DataRow dr = dt.NewRow();
					dr[0] = this.cmbActivoAjeno.SelectedValue;
					dr[1] = this.cmbActivoAjeno.Items[this.cmbActivoAjeno.SelectedIndex].Text;
					dr[4] = 0;
					dr[3] = 2;
					dr[2] = 0;
					dt.Rows.Add(dr);
					this.Session["ActivosAjenos"] = dt;
					this.grActivoAjeno.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosAjenos"]);
					this.grActivoAjeno.DataBind();
					int num = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						Texto.Text = Conversions.ToString(dt.Rows[i][4]);
					}
				}
				this.cmbActivoAjeno.SelectedIndex = -1;
				this.lblFamAjeno.Visible = true;
				this.txtFamAjeno.Visible = true;
				this.lblCantAjeno.Visible = true;
				this.txtCantAjeno.Visible = true;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void InsertarEnGrillaActivoPropio()
		{
			TextBox Texto;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["ActivosPropios"];
				if (!this.oFactory.ExisteFilaEnGrillaActivos(dt, Conversions.ToInteger(this.cmbActivoPropio.SelectedValue)))
				{
					int count = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
						dt.Rows[i][2] = Texto.Text;
					}
					DataRow dr = dt.NewRow();
					dr[0] = this.cmbActivoPropio.SelectedValue;
					dr[1] = this.cmbActivoPropio.Items[this.cmbActivoPropio.SelectedIndex].Text;
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.oFactory.ObtenerFormatoDecimal(), ".", false) != 0)
					{
						dr[4] = "0,00";
					}
					else
					{
						dr[4] = "0.00";
					}
					dr[3] = 1;
					dr[2] = 0;
					dt.Rows.Add(dr);
					this.Session["ActivosPropios"] = dt;
					this.grActivoPropio.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ActivosPropios"]);
					this.grActivoPropio.DataBind();
					int num = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrila");
						Texto.Text = Conversions.ToString(dt.Rows[i][2]);
					}
				}
				this.cmbActivoPropio.SelectedIndex = -1;
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
			this.lblError1.Visible = true;
			this.lblError2.Visible = true;
			this.lblError.Text = mensaje;
			this.lblError1.Text = mensaje;
			this.lblError2.Text = mensaje;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PCEREG"), "1", false) != 0)
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