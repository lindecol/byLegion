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
	public class RegistroManualMixtos : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("lblSubtitulo")]
		private Label _lblSubtitulo;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("cmbProductos")]
		private DropDownList _cmbProductos;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("UpdateProgress1")]
		private UpdateProgress _UpdateProgress1;

		[AccessedThroughProperty("lblCodigo")]
		private Label _lblCodigo;

		[AccessedThroughProperty("txtCodigo")]
		private TextBox _txtCodigo;

		[AccessedThroughProperty("lblPropiedad")]
		private Label _lblPropiedad;

		[AccessedThroughProperty("cmbPropiedad")]
		private DropDownList _cmbPropiedad;

		[AccessedThroughProperty("lblCapacidad")]
		private Label _lblCapacidad;

		[AccessedThroughProperty("cmbCapacidadProducto")]
		private DropDownList _cmbCapacidadProducto;

		[AccessedThroughProperty("lblCantidad")]
		private Label _lblCantidad;

		[AccessedThroughProperty("txtCantidad")]
		private TextBox _txtCantidad;

		[AccessedThroughProperty("ibProducto")]
		private ImageButton _ibProducto;

		[AccessedThroughProperty("lblError1")]
		private Label _lblError1;

		[AccessedThroughProperty("lblProductosPropios")]
		private Label _lblProductosPropios;

		[AccessedThroughProperty("grProducto")]
		private GridView _grProducto;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("grdProductoAjenos")]
		private GridView _grdProductoAjenos;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("cmbActivoPropio")]
		private DropDownList _cmbActivoPropio;

		[AccessedThroughProperty("lblFamilia")]
		private Label _lblFamilia;

		[AccessedThroughProperty("txtFamilia")]
		private TextBox _txtFamilia;

		[AccessedThroughProperty("lblCantidadPropio")]
		private Label _lblCantidadPropio;

		[AccessedThroughProperty("txtCantidadPropio")]
		private TextBox _txtCantidadPropio;

		[AccessedThroughProperty("ibActivoPropio")]
		private ImageButton _ibActivoPropio;

		[AccessedThroughProperty("lblError2")]
		private Label _lblError2;

		[AccessedThroughProperty("grActivoPropio")]
		private GridView _grActivoPropio;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

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

		[AccessedThroughProperty("ibActivoAjeno")]
		private ImageButton _ibActivoAjeno;

		[AccessedThroughProperty("lblError3")]
		private Label _lblError3;

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

		[AccessedThroughProperty("FilteredTextBoxExtender5")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender5;

		[AccessedThroughProperty("FilteredTextBoxExtender6")]
		private FilteredTextBoxExtender _FilteredTextBoxExtender6;

		private ControlPaquete.wsPackage.Service wsData;

		private Utilidades oFactory;

		private ControlPaquete.wsPraxair.Service objSeg;

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
					RegistroManualMixtos registroManualMixto = this;
					this._cmbActivoAjeno.SelectedIndexChanged -= new EventHandler(registroManualMixto.cmbActivoAjeno_SelectedIndexChanged);
				}
				this._cmbActivoAjeno = value;
				if (this._cmbActivoAjeno != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._cmbActivoAjeno.SelectedIndexChanged += new EventHandler(registroManualMixto1.cmbActivoAjeno_SelectedIndexChanged);
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
					RegistroManualMixtos registroManualMixto = this;
					this._cmbActivoPropio.SelectedIndexChanged -= new EventHandler(registroManualMixto.cmbActivoPropio_SelectedIndexChanged);
				}
				this._cmbActivoPropio = value;
				if (this._cmbActivoPropio != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._cmbActivoPropio.SelectedIndexChanged += new EventHandler(registroManualMixto1.cmbActivoPropio_SelectedIndexChanged);
				}
			}
		}

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

		protected virtual DropDownList cmbProductos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbProductos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbProductos != null)
				{
					RegistroManualMixtos registroManualMixto = this;
					this._cmbProductos.SelectedIndexChanged -= new EventHandler(registroManualMixto.cmbProductos_SelectedIndexChanged);
				}
				this._cmbProductos = value;
				if (this._cmbProductos != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._cmbProductos.SelectedIndexChanged += new EventHandler(registroManualMixto1.cmbProductos_SelectedIndexChanged);
				}
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
				this._cmbPropiedad = value;
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

		protected virtual FilteredTextBoxExtender FilteredTextBoxExtender5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._FilteredTextBoxExtender5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FilteredTextBoxExtender5 = value;
			}
		}

		protected virtual FilteredTextBoxExtender FilteredTextBoxExtender6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._FilteredTextBoxExtender6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FilteredTextBoxExtender6 = value;
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

		protected virtual GridView grdProductoAjenos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grdProductoAjenos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._grdProductoAjenos = value;
			}
		}

		protected virtual GridView grProducto
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grProducto;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._grProducto = value;
			}
		}

		protected virtual ImageButton ibActivoAjeno
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibActivoAjeno;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibActivoAjeno != null)
				{
					RegistroManualMixtos registroManualMixto = this;
					this._ibActivoAjeno.Click -= new ImageClickEventHandler(registroManualMixto.ibActivoAjeno_Click);
				}
				this._ibActivoAjeno = value;
				if (this._ibActivoAjeno != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._ibActivoAjeno.Click += new ImageClickEventHandler(registroManualMixto1.ibActivoAjeno_Click);
				}
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
					RegistroManualMixtos registroManualMixto = this;
					this._ibActivoPropio.Click -= new ImageClickEventHandler(registroManualMixto.ibActivoPropio_Click);
				}
				this._ibActivoPropio = value;
				if (this._ibActivoPropio != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._ibActivoPropio.Click += new ImageClickEventHandler(registroManualMixto1.ibActivoPropio_Click);
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
					RegistroManualMixtos registroManualMixto = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(registroManualMixto.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(registroManualMixto1.ibGuardar_Click);
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
					RegistroManualMixtos registroManualMixto = this;
					this._ibProducto.Click -= new ImageClickEventHandler(registroManualMixto.ibProducto_Click);
				}
				this._ibProducto = value;
				if (this._ibProducto != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._ibProducto.Click += new ImageClickEventHandler(registroManualMixto1.ibProducto_Click);
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

		protected virtual Label lblCantidadPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblCantidadPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCantidadPropio = value;
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

		protected virtual Label lblError3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblError3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblError3 = value;
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

		protected virtual Label lblProductosPropios
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblProductosPropios;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblProductosPropios = value;
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

		protected virtual TextBox txtCantidadPropio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtCantidadPropio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtCantidadPropio = value;
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
					RegistroManualMixtos registroManualMixto = this;
					this._txtCodigo.TextChanged -= new EventHandler(registroManualMixto.txtCodigo_TextChanged);
				}
				this._txtCodigo = value;
				if (this._txtCodigo != null)
				{
					RegistroManualMixtos registroManualMixto1 = this;
					this._txtCodigo.TextChanged += new EventHandler(registroManualMixto1.txtCodigo_TextChanged);
				}
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
		static RegistroManualMixtos()
		{
			RegistroManualMixtos.__ENCList = new ArrayList();
		}

		public RegistroManualMixtos()
		{
			RegistroManualMixtos registroManualMixto = this;
			base.Load += new EventHandler(registroManualMixto.Page_Load);
			ArrayList _ENCList = RegistroManualMixtos.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				RegistroManualMixtos.__ENCList.Add(new WeakReference(this));
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
			this.lblError3.Visible = false;
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
					return;
				}
				else if (!this.oFactory.SoloNumeros(Cantidad))
				{
					this.MensajeError("La cantidad debe ser un número");
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
			this.lblError3.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(CodigoActivo, "", false) == 0)
				{
					this.MensajeError("Debe diitar un código de familia");
					return;
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Cantidad, "", false) == 0)
				{
					this.MensajeError("Debe digitar una cantidad");
					return;
				}
				else if (!this.oFactory.SoloNumeros(Cantidad))
				{
					this.MensajeError("La cantidad debe ser un número");
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
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
						dt.Rows[i][4] = Texto.Text;
					}
					bool band = false;
					int num = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.grActivoPropio.Rows[i].Cells[0].Text, CodigoActivo, false) == 0)
						{
							Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
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
							TextBox x = (TextBox)this.grActivoPropio.Rows[checked(this.grActivoPropio.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilaPropio");
							x.Text = Cantidad;
						}
					}
					int count1 = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count1; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
						Texto.Text = Conversions.ToString(dt.Rows[i][4]);
					}
					this.txtFamilia.Text = "";
					this.txtCantidadPropio.Text = "";
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ActualizarGrillaProducto(string CodigoProducto, string Cantidad, string Capacidad, string Propiedad)
		{
			CheckBox Cmb;
			TextBox Text;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(CodigoProducto, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de producto");
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Cantidad, "", false) == 0)
				{
					this.MensajeError("Debe digitar una cantidad");
				}
				else if (Conversions.ToDouble(Cantidad) < 0)
				{
					this.MensajeError("La capacidad debe ser mayor o igual que 0");
				}
				else
				{
					DataTable dt = new DataTable();
					dt = (DataTable)this.Session["Producto"];
					int count = checked(this.grProducto.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
						dt.Rows[i][2] = Text.Text;
						Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
						if (!Cmb.Checked)
						{
							dt.Rows[i][4] = "A";
						}
						else
						{
							dt.Rows[i][4] = "P";
						}
					}
					bool band = false;
					DataTable dtCapacidad = new DataTable();
					bool EsPropio = false;
					int num = checked(this.grProducto.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						EsPropio = (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Propiedad, "P", false) != 0 ? false : true);
						Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
						if (Conversions.ToInteger(this.grProducto.Rows[i].Cells[0].Text) == Conversions.ToInteger(CodigoProducto) & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.grProducto.Rows[i].Cells[3].Text, Capacidad, false) == 0 & Cmb.Checked == EsPropio)
						{
							Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
							Text.Text = Cantidad;
							dt.Rows[i][2] = Cantidad;
							band = true;
						}
					}
					if (!band)
					{
						DataRow dr = dt.NewRow();
						string[] vector = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(CodigoProducto)).Split(new char[] { '-' });
						if (Conversions.ToDouble(vector[0]) != 0)
						{
							this.MensajeError(string.Concat(vector[0], "-", vector[1]));
						}
						else
						{
							dr[0] = CodigoProducto;
							dr[1] = vector[2];
							dr[2] = Cantidad;
							dr[3] = Capacidad;
							dr[4] = Propiedad;
							dt.Rows.Add(dr);
							this.Session["Producto"] = dt;
							this.grProducto.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Producto"]);
							this.grProducto.DataBind();
							Text = (TextBox)this.grProducto.Rows[checked(this.grProducto.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilla");
							Text.Text = Cantidad;
							CheckBox c = (CheckBox)this.grProducto.Rows[checked(this.grProducto.Rows.Count - 1)].Cells[4].FindControl("cbEstado");
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Propiedad, "P", false) != 0)
							{
								c.Checked = false;
							}
							else
							{
								c.Checked = true;
							}
						}
					}
					int count1 = checked(this.grProducto.Rows.Count - 1);
					for (int i = 0; i <= count1; i = checked(i + 1))
					{
						Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
						Text.Text = Conversions.ToString(dt.Rows[i][2]);
						Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
						if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
						{
							Cmb.Checked = false;
						}
						else
						{
							Cmb.Checked = true;
						}
					}
					this.txtCodigo.Text = "";
					this.txtCantidad.Text = "";
					this.cmbPropiedad.SelectedIndex = 0;
					this.lblPropiedad.Visible = false;
					this.cmbPropiedad.Visible = false;
					this.lblCapacidad.Visible = false;
					this.cmbCapacidadProducto.Visible = false;
					this.lblCantidad.Visible = false;
					this.txtCantidad.Visible = false;
					this.ibProducto.Visible = false;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ActualizarGrillaProductoPart(string CodigoProducto, string Cantidad, string Capacidad, string Propiedad)
		{
			CheckBox Cmb;
			TextBox Text;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(CodigoProducto, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de producto");
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Cantidad, "", false) == 0)
				{
					this.MensajeError("Debe digitar una cantidad");
				}
				else if (Conversions.ToDouble(Cantidad) < 0)
				{
					this.MensajeError("La capacidad debe ser mayor o igual que 0");
				}
				else
				{
					DataTable dt = new DataTable();
					dt = (DataTable)this.Session["ProductoParticulares"];
					int count = checked(this.grdProductoAjenos.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
						dt.Rows[i][2] = Text.Text;
						Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
						if (!Cmb.Checked)
						{
							dt.Rows[i][4] = "A";
						}
						else
						{
							dt.Rows[i][4] = "P";
						}
					}
					bool band = false;
					DataTable dtCapacidad = new DataTable();
					bool EsPropio = false;
					int num = checked(this.grdProductoAjenos.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						EsPropio = (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Propiedad, "P", false) != 0 ? false : true);
						Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
						if (Conversions.ToInteger(this.grdProductoAjenos.Rows[i].Cells[0].Text) == Conversions.ToInteger(CodigoProducto) & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.grdProductoAjenos.Rows[i].Cells[3].Text, Capacidad, false) == 0 & Cmb.Checked == EsPropio)
						{
							Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
							Text.Text = Cantidad;
							dt.Rows[i][2] = Cantidad;
							band = true;
						}
					}
					if (!band)
					{
						DataRow dr = dt.NewRow();
						string[] vector = this.wsData.NombreProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(CodigoProducto)).Split(new char[] { '-' });
						if (Conversions.ToDouble(vector[0]) != 0)
						{
							this.MensajeError(string.Concat(vector[0], "-", vector[1]));
						}
						else
						{
							dr[0] = CodigoProducto;
							dr[1] = vector[2];
							dr[2] = Cantidad;
							dr[3] = Capacidad;
							dr[4] = Propiedad;
							dt.Rows.Add(dr);
							this.Session["ProductoParticulares"] = dt;
							this.grdProductoAjenos.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductoParticulares"]);
							this.grdProductoAjenos.DataBind();
							Text = (TextBox)this.grdProductoAjenos.Rows[checked(this.grdProductoAjenos.Rows.Count - 1)].Cells[2].FindControl("txtCantidadGrilla");
							Text.Text = Cantidad;
							CheckBox c = (CheckBox)this.grdProductoAjenos.Rows[checked(this.grdProductoAjenos.Rows.Count - 1)].Cells[4].FindControl("cbEstado");
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Propiedad, "P", false) != 0)
							{
								c.Checked = false;
							}
							else
							{
								c.Checked = true;
							}
						}
					}
					int count1 = checked(this.grdProductoAjenos.Rows.Count - 1);
					for (int i = 0; i <= count1; i = checked(i + 1))
					{
						Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
						Text.Text = Conversions.ToString(dt.Rows[i][2]);
						Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
						if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
						{
							Cmb.Checked = false;
						}
						else
						{
							Cmb.Checked = true;
						}
					}
					this.txtCodigo.Text = "";
					this.txtCantidad.Text = "";
					this.cmbPropiedad.SelectedIndex = 0;
					this.lblPropiedad.Visible = false;
					this.cmbPropiedad.Visible = false;
					this.lblCapacidad.Visible = false;
					this.cmbCapacidadProducto.Visible = false;
					this.lblCantidad.Visible = false;
					this.txtCantidad.Visible = false;
					this.ibProducto.Visible = false;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarActivosAjenos()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				DataSet ConsultarActivosAjenos = new DataSet();
				ConsultarActivosAjenos = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
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
			this.lblError3.Visible = false;
			try
			{
				DataSet ConsultarActivosPropios = new DataSet();
				ConsultarActivosPropios = this.wsData.CrearActivos(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
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

		private void CargarGrilla()
		{
			CheckBox Cmb;
			TextBox Text;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				DataTable dtCapacidad = new DataTable();
				DataSet ConsultarProductos = new DataSet();
				DataSet ConsultarProductosParticulares = new DataSet();
				ConsultarProductos = this.wsData.CrearProductosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
				ConsultarProductosParticulares = this.wsData.CrearProductosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
				if (ConsultarProductos.Tables[0].Rows.Count > 0)
				{
					this.grProducto.DataSource = ConsultarProductos.Tables[0];
					this.grProducto.DataBind();
					int count = checked(this.grProducto.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
						Text.Attributes.Add("OnKeyPress", "return esInteger(event)");
						Text.Text = Conversions.ToString(ConsultarProductos.Tables[0].Rows[i][2]);
						Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
						if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(ConsultarProductos.Tables[0].Rows[i][4], "P", false))
						{
							Cmb.Checked = true;
						}
					}
					this.Session["Producto"] = ConsultarProductos.Tables[0];
				}
				if (ConsultarProductosParticulares.Tables[0].Rows.Count > 0)
				{
					this.grdProductoAjenos.DataSource = ConsultarProductosParticulares.Tables[0];
					this.grdProductoAjenos.DataBind();
					int num = checked(this.grdProductoAjenos.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
						Text.Attributes.Add("OnKeyPress", "return esInteger(event)");
						Text.Text = Conversions.ToString(ConsultarProductosParticulares.Tables[0].Rows[i][2]);
						Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[4].FindControl("cbEstado");
						if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(ConsultarProductosParticulares.Tables[0].Rows[i][4], "P", false))
						{
							Cmb.Checked = true;
						}
					}
					this.Session["ProductoParticulares"] = ConsultarProductosParticulares.Tables[0];
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarProductos()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				DataSet ConsultarProductos = new DataSet();
				ConsultarProductos = this.wsData.CrearProductosCombo(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]));
				if (ConsultarProductos.Tables[0].Rows.Count > 0)
				{
					this.cmbProductos.DataSource = ConsultarProductos.Tables[0];
					this.cmbProductos.DataBind();
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

		public void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				if (!(this.cmbProductos.SelectedIndex != 0 & this.cmbPropiedad.SelectedIndex == 0))
				{
					this.lblCodigo.Visible = true;
					this.txtCodigo.Visible = true;
					this.lblPropiedad.Visible = false;
					this.cmbPropiedad.Visible = false;
					this.lblCapacidad.Visible = false;
					this.cmbCapacidadProducto.Visible = false;
					this.lblCantidad.Visible = false;
					this.txtCantidad.Visible = false;
					this.ibProducto.Visible = false;
				}
				else
				{
					this.txtCodigo.Text = this.cmbProductos.SelectedValue;
					this.lblCodigo.Visible = false;
					this.txtCodigo.Visible = false;
					this.lblPropiedad.Visible = true;
					this.cmbPropiedad.Visible = true;
					this.lblCapacidad.Visible = true;
					this.cmbCapacidadProducto.Visible = true;
					this.lblCantidad.Visible = true;
					this.txtCantidad.Visible = true;
					this.ibProducto.Visible = true;
					DataSet dtCapacidad = new DataSet();
					dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.cmbProductos.SelectedValue));
					if (dtCapacidad.Tables[0].Rows.Count > 0)
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
				this.lblCodigo.Visible = true;
				this.txtCodigo.Visible = true;
				this.lblPropiedad.Visible = false;
				this.cmbPropiedad.Visible = false;
				this.lblCapacidad.Visible = false;
				this.cmbCapacidadProducto.Visible = false;
				this.lblCantidad.Visible = false;
				this.txtCantidad.Visible = false;
				this.ibProducto.Visible = false;
				ProjectData.ClearProjectError();
			}
		}

		private void Configuracion()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				this.lblSubtitulo.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("Conteo: ", this.Session["Conteo"]), " --- Tipo: "), this.Session["TipoConteo"]), " --- Fecha: "), this.Session["FechaInicio"]));
				this.CargarProductos();
				DataTable dtGrilla = new DataTable();
				dtGrilla.Columns.Add(new DataColumn("CODIGO_PRODUCTO", typeof(string)));
				dtGrilla.Columns.Add(new DataColumn("NOMBRE_PRODUCTO", typeof(string)));
				dtGrilla.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
				dtGrilla.Columns.Add(new DataColumn("CAPACIDAD", typeof(double)));
				dtGrilla.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
				dtGrilla.Columns.Add(new DataColumn("INDICADOR_CUENTA_CORRIENTE", typeof(string)));
				this.Session["Producto"] = dtGrilla;
				this.Session["ProductoParticulares"] = dtGrilla;
				this.CargarGrilla();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void ConfiguracionActivos()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
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
			this.lblError3.Visible = false;
			try
			{
				DataSet CrearActivosAjenos = new DataSet();
				CrearActivosAjenos = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "A");
				if (CrearActivosAjenos.Tables[0].Rows.Count > 0)
				{
					this.grActivoAjeno.DataSource = CrearActivosAjenos;
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
			this.lblError3.Visible = false;
			try
			{
				DataSet CrearActivosPropios = new DataSet();
				CrearActivosPropios = this.wsData.CrearActivosGrilla(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "P");
				if (CrearActivosPropios.Tables[0].Rows.Count > 0)
				{
					this.grActivoPropio.DataSource = CrearActivosPropios.Tables[0];
					this.grActivoPropio.DataBind();
					int count = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
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

		private void GuardarMixto()
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				if (!(this.grProducto.Rows.Count > 0 | this.grdProductoAjenos.Rows.Count > 0 | this.grActivoAjeno.Rows.Count > 0 | this.grActivoPropio.Rows.Count > 0))
				{
					this.MensajeError("No se han registrado ni productos ni activos");
				}
				else
				{
					DataSet dsProducto = new DataSet();
					DataSet dsProductoAjeno = new DataSet();
					DataSet dsActivoAjeno = new DataSet();
					DataSet dsActivoPropio = new DataSet();
					DataTable dtProducto = new DataTable();
					DataTable dtProductoAjeno = new DataTable();
					DataTable dtActivoAjeno = new DataTable();
					DataTable dtActivoPropio = new DataTable();
					dtProducto.Columns.Add(new DataColumn("CODIGO", typeof(string)));
					dtProducto.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
					dtProducto.Columns.Add(new DataColumn("CAPACIDAD", typeof(string)));
					dtProducto.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
					dtProductoAjeno.Columns.Add(new DataColumn("CODIGO", typeof(string)));
					dtProductoAjeno.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
					dtProductoAjeno.Columns.Add(new DataColumn("CAPACIDAD", typeof(string)));
					dtProductoAjeno.Columns.Add(new DataColumn("PROPIEDAD", typeof(string)));
					dtActivoAjeno.Columns.Add(new DataColumn("CODIGO", typeof(string)));
					dtActivoAjeno.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
					dtActivoPropio.Columns.Add(new DataColumn("FAMILIA", typeof(string)));
					dtActivoPropio.Columns.Add(new DataColumn("CANTIDAD", typeof(string)));
					int count = checked(this.grProducto.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						DataRow dr = dtProducto.NewRow();
						dr[0] = this.grProducto.Rows[i].Cells[0].Text;
						TextBox Texto = (TextBox)this.grProducto.Rows[i].FindControl("txtCantidadGrilla");
						dr[1] = Texto.Text;
						dr[2] = this.grProducto.Rows[i].Cells[2].Text;
						dr[3] = "P";
						dtProducto.Rows.Add(dr);
					}
					dsProducto.Tables.Add(dtProducto);
					int num = checked(this.grdProductoAjenos.Rows.Count - 1);
					for (int i = 0; i <= num; i = checked(i + 1))
					{
						DataRow dr = dtProductoAjeno.NewRow();
						dr[0] = this.grdProductoAjenos.Rows[i].Cells[0].Text;
						TextBox Texto = (TextBox)this.grdProductoAjenos.Rows[i].FindControl("txtCantidadGrilla");
						dr[1] = Texto.Text;
						dr[2] = this.grdProductoAjenos.Rows[i].Cells[2].Text;
						dr[3] = "A";
						dtProductoAjeno.Rows.Add(dr);
					}
					dsProductoAjeno.Tables.Add(dtProductoAjeno);
					int count1 = checked(this.grActivoAjeno.Rows.Count - 1);
					for (int i = 0; i <= count1; i = checked(i + 1))
					{
						DataRow dr = dtActivoAjeno.NewRow();
						dr[0] = this.grActivoAjeno.Rows[i].Cells[0].Text;
						TextBox Texto = (TextBox)this.grActivoAjeno.Rows[i].Cells[2].FindControl("txtCantidadGrilaAjeno");
						dr[1] = Texto.Text;
						dtActivoAjeno.Rows.Add(dr);
					}
					dsActivoAjeno.Tables.Add(dtActivoAjeno);
					int num1 = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= num1; i = checked(i + 1))
					{
						DataRow dr = dtActivoPropio.NewRow();
						dr[0] = this.grActivoPropio.Rows[i].Cells[0].Text;
						TextBox Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
						dr[1] = Texto.Text;
						dtActivoPropio.Rows.Add(dr);
					}
					dsActivoPropio.Tables.Add(dtActivoPropio);
					string Registro = this.wsData.GuardarMixto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), "N", "P", Conversions.ToString(this.Session["UsuarioRegistro"]), dsProducto, dsActivoAjeno, dsActivoPropio, dsProductoAjeno);
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

		public void ibActivoAjeno_Click(object sender, ImageClickEventArgs e)
		{
			if (this.cmbActivoAjeno.SelectedIndex == 0)
			{
				this.ActualizarGrillaActivoAjeno(this.txtFamAjeno.Text, this.txtCantAjeno.Text);
			}
			else
			{
				this.InsertarEnGrillaActivoAjeno();
			}
		}

		public void ibActivoPropio_Click(object sender, ImageClickEventArgs e)
		{
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
			{
				this.ActualizarGrillaActivoPropio(this.txtFamilia.Text, this.txtCantidadPropio.Text);
			}
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			this.GuardarMixto();
		}

		public void ibProducto_Click(object sender, ImageClickEventArgs e)
		{
			if (!this.cmbCapacidadProducto.Visible)
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cmbPropiedad.SelectedValue, "P", false) != 0)
				{
					this.InsertarEnGrillaProductosPart();
				}
				else
				{
					this.InsertarEnGrillaProductos();
				}
				this.lblCodigo.Visible = true;
				this.txtCodigo.Visible = true;
				this.lblPropiedad.Visible = false;
				this.cmbPropiedad.Visible = false;
				this.lblCapacidad.Visible = false;
				this.cmbCapacidadProducto.Visible = false;
				this.lblCantidad.Visible = false;
				this.txtCantidad.Visible = false;
				this.ibProducto.Visible = false;
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cmbPropiedad.SelectedValue, "P", false) != 0)
			{
				this.ActualizarGrillaProductoPart(this.txtCodigo.Text, this.txtCantidad.Text, this.cmbCapacidadProducto.SelectedValue, this.cmbPropiedad.SelectedValue);
			}
			else
			{
				this.ActualizarGrillaProducto(this.txtCodigo.Text, this.txtCantidad.Text, this.cmbCapacidadProducto.SelectedValue, this.cmbPropiedad.SelectedValue);
			}
		}

		private void InsertarEnGrillaActivoAjeno()
		{
			TextBox Texto;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
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
			this.lblError3.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["ActivosPropios"];
				if (!this.oFactory.ExisteFilaEnGrillaActivos(dt, Conversions.ToInteger(this.cmbActivoPropio.SelectedValue)))
				{
					int count = checked(this.grActivoPropio.Rows.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
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
						Texto = (TextBox)this.grActivoPropio.Rows[i].Cells[2].FindControl("txtCantidadGrilaPropio");
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

		private void InsertarEnGrillaProductos()
		{
			CheckBox Cmb;
			TextBox Text;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["Producto"];
				int count = checked(this.grProducto.Rows.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
					dt.Rows[i][2] = Text.Text;
					Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
					if (!Cmb.Checked)
					{
						dt.Rows[i][4] = "A";
					}
					else
					{
						dt.Rows[i][4] = "P";
					}
				}
				DataRow dr = dt.NewRow();
				dr[0] = this.cmbProductos.SelectedValue;
				dr[1] = this.cmbProductos.Items[this.cmbProductos.SelectedIndex].Text;
				dr[2] = 0;
				dr[3] = this.cmbCapacidadProducto.SelectedValue;
				dr[4] = "A";
				dt.Rows.Add(dr);
				this.Session["Producto"] = dt;
				this.grProducto.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Producto"]);
				this.grProducto.DataBind();
				int num = checked(this.grProducto.Rows.Count - 1);
				for (int i = 0; i <= num; i = checked(i + 1))
				{
					Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
					Text.Text = Conversions.ToString(dt.Rows[i][2]);
					Cmb = (CheckBox)this.grProducto.Rows[i].Cells[3].FindControl("cbEstado");
					if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
					{
						Cmb.Checked = false;
					}
					else
					{
						Cmb.Checked = true;
					}
				}
				this.cmbProductos.SelectedIndex = -1;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void InsertarEnGrillaProductosPart()
		{
			CheckBox Cmb;
			TextBox Text;
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["ProductoParticulares"];
				int count = checked(this.grProducto.Rows.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					Text = (TextBox)this.grProducto.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
					dt.Rows[i][2] = Text.Text;
					Cmb = (CheckBox)this.grProducto.Rows[i].Cells[4].FindControl("cbEstado");
					if (!Cmb.Checked)
					{
						dt.Rows[i][4] = "A";
					}
					else
					{
						dt.Rows[i][4] = "P";
					}
				}
				DataRow dr = dt.NewRow();
				dr[0] = this.cmbProductos.SelectedValue;
				dr[1] = this.cmbProductos.Items[this.cmbProductos.SelectedIndex].Text;
				dr[2] = 0;
				dr[3] = this.cmbCapacidadProducto.SelectedValue;
				dr[4] = "A";
				dt.Rows.Add(dr);
				this.Session["ProductoParticulares"] = dt;
				this.grdProductoAjenos.DataSource = RuntimeHelpers.GetObjectValue(this.Session["ProductoParticulares"]);
				this.grdProductoAjenos.DataBind();
				int num = checked(this.grdProductoAjenos.Rows.Count - 1);
				for (int i = 0; i <= num; i = checked(i + 1))
				{
					Text = (TextBox)this.grdProductoAjenos.Rows[i].Cells[2].FindControl("txtCantidadGrilla");
					Text.Text = Conversions.ToString(dt.Rows[i][2]);
					Cmb = (CheckBox)this.grdProductoAjenos.Rows[i].Cells[3].FindControl("cbEstado");
					if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dt.Rows[i][4], "P", false))
					{
						Cmb.Checked = false;
					}
					else
					{
						Cmb.Checked = true;
					}
				}
				this.cmbProductos.SelectedIndex = -1;
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
			this.lblError3.Visible = true;
			this.lblError.Text = mensaje;
			this.lblError1.Text = mensaje;
			this.lblError2.Text = mensaje;
			this.lblError3.Text = mensaje;
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
				this.ConfiguracionActivos();
			}
		}

		private void txtCodigo_TextChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			this.lblError1.Visible = false;
			this.lblError2.Visible = false;
			this.lblError3.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCodigo.Text, "", false) == 0)
				{
					this.MensajeError("Debe digitar un código de producto");
				}
				else
				{
					string[] indicador = this.wsData.IndicadorCuentaCorriente(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.txtCodigo.Text)).Split(new char[] { '-' });
					if (Conversions.ToDouble(indicador[0]) == 0)
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(indicador[2], "S", false) == 0)
						{
							this.lblPropiedad.Visible = true;
							this.cmbPropiedad.Visible = true;
						}
						this.lblCapacidad.Visible = true;
						this.cmbCapacidadProducto.Visible = true;
						this.lblCantidad.Visible = true;
						this.txtCantidad.Visible = true;
						this.ibProducto.Visible = true;
						DataSet dtCapacidad = new DataSet();
						dtCapacidad = this.wsData.CapacidadesProducto(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Conteo"]), Conversions.ToInteger(this.txtCodigo.Text));
						if (dtCapacidad.Tables[0].Rows.Count <= 0)
						{
							this.lblPropiedad.Visible = false;
							this.cmbPropiedad.Visible = false;
							this.lblCapacidad.Visible = false;
							this.cmbCapacidadProducto.Visible = false;
							this.lblCantidad.Visible = false;
							this.txtCantidad.Visible = false;
							this.ibProducto.Visible = false;
						}
						else
						{
							this.cmbCapacidadProducto.DataSource = dtCapacidad.Tables[0];
							this.cmbCapacidadProducto.DataBind();
						}
					}
					else
					{
						this.MensajeError(string.Concat(indicador[0], "-", indicador[1]));
						return;
					}
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				this.lblPropiedad.Visible = false;
				this.cmbPropiedad.Visible = false;
				this.lblCapacidad.Visible = false;
				this.cmbCapacidadProducto.Visible = false;
				this.lblCantidad.Visible = false;
				this.txtCantidad.Visible = false;
				this.ibProducto.Visible = false;
				ProjectData.ClearProjectError();
			}
		}
	}
}