using AjaxControlToolkit;
using ControlPaquete.wsPackage;
using ControlPaquete.wsPraxair;
using Factory;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
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
	/// Clase ProgramacionConteo.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class ProgramacionConteo : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("ScriptManager1")]
		private System.Web.UI.ScriptManager _ScriptManager1;

		[AccessedThroughProperty("UpdatePanel1")]
		private UpdatePanel _UpdatePanel1;

		[AccessedThroughProperty("lblTitulo")]
		private Label _lblTitulo;

		[AccessedThroughProperty("UpdateProgress1")]
		private UpdateProgress _UpdateProgress1;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("txtDate")]
		private TextBox _txtDate;

		[AccessedThroughProperty("ibCalendario")]
		private ImageButton _ibCalendario;

		[AccessedThroughProperty("calendarButtonExtender")]
		private CalendarExtender _calendarButtonExtender;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("cmbHoraInicio")]
		private DropDownList _cmbHoraInicio;

		[AccessedThroughProperty("cmbHora")]
		private DropDownList _cmbHora;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("cmbHoraFin")]
		private DropDownList _cmbHoraFin;

		[AccessedThroughProperty("cmbHoraAP")]
		private DropDownList _cmbHoraAP;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("cmbTipoProgramacion")]
		private DropDownList _cmbTipoProgramacion;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("cmbUsuario")]
		private DropDownList _cmbUsuario;

		[AccessedThroughProperty("chkMail")]
		private CheckBox _chkMail;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("cmbSucursal")]
		private DropDownList _cmbSucursal;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("cmbSector")]
		private DropDownList _cmbSector;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("cmbSubdeposito")]
		private DropDownList _cmbSubdeposito;

		[AccessedThroughProperty("grConteo")]
		private GridView _grConteo;

		[AccessedThroughProperty("tbProgramacion")]
		private TabContainer _tbProgramacion;

		[AccessedThroughProperty("TabPanel1")]
		private TabPanel _TabPanel1;

		[AccessedThroughProperty("TabPanel2")]
		private TabPanel _TabPanel2;

		[AccessedThroughProperty("rbDia1")]
		private RadioButton _rbDia1;

		[AccessedThroughProperty("txtDia")]
		private TextBox _txtDia;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("rbDia2")]
		private RadioButton _rbDia2;

		[AccessedThroughProperty("TabPanel3")]
		private TabPanel _TabPanel3;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("txtSemana")]
		private TextBox _txtSemana;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("chkDomingo")]
		private CheckBox _chkDomingo;

		[AccessedThroughProperty("chkLunes")]
		private CheckBox _chkLunes;

		[AccessedThroughProperty("chkMartes")]
		private CheckBox _chkMartes;

		[AccessedThroughProperty("chkMiercoles")]
		private CheckBox _chkMiercoles;

		[AccessedThroughProperty("chkJueves")]
		private CheckBox _chkJueves;

		[AccessedThroughProperty("chkViernes")]
		private CheckBox _chkViernes;

		[AccessedThroughProperty("chkSabado")]
		private CheckBox _chkSabado;

		[AccessedThroughProperty("TabPanel4")]
		private TabPanel _TabPanel4;

		[AccessedThroughProperty("rbMes1")]
		private RadioButton _rbMes1;

		[AccessedThroughProperty("txtDiaMes")]
		private TextBox _txtDiaMes;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("txtMes")]
		private TextBox _txtMes;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("rbMes2")]
		private RadioButton _rbMes2;

		[AccessedThroughProperty("cmbDiaMensual")]
		private DropDownList _cmbDiaMensual;

		[AccessedThroughProperty("cmbTipo")]
		private DropDownList _cmbTipo;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("txtMesDia")]
		private TextBox _txtMesDia;

		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		[AccessedThroughProperty("TabPanel5")]
		private TabPanel _TabPanel5;

		[AccessedThroughProperty("CalendarRepetitiva")]
		private Calendar _CalendarRepetitiva;

		[AccessedThroughProperty("grRepetitiva")]
		private GridView _grRepetitiva;

		[AccessedThroughProperty("rbActual")]
		private RadioButton _rbActual;

		[AccessedThroughProperty("rbFecha")]
		private RadioButton _rbFecha;

		[AccessedThroughProperty("txtFinaliza")]
		private TextBox _txtFinaliza;

		[AccessedThroughProperty("ibFinaliza")]
		private ImageButton _ibFinaliza;

		[AccessedThroughProperty("CalendarExtender1")]
		private CalendarExtender _CalendarExtender1;

		[AccessedThroughProperty("chkFestivos")]
		private CheckBox _chkFestivos;

		[AccessedThroughProperty("MisFechas")]
		private Calendar _MisFechas;

		[AccessedThroughProperty("ibGuardar")]
		private ImageButton _ibGuardar;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("grErrores")]
		private GridView _grErrores;

		[AccessedThroughProperty("ibConfirmar")]
		private ImageButton _ibConfirmar;

		[AccessedThroughProperty("ibEliminar")]
		private ImageButton _ibEliminar;

		private List<DateTime> lstFechas;

		private Utilidades oFactory;

		private ControlPaquete.wsPackage.Service wsData;

		private ControlPaquete.wsPraxair.Service objSeg;

		protected virtual CalendarExtender calendarButtonExtender
		{
			[DebuggerNonUserCode]
			get
			{
				return this._calendarButtonExtender;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._calendarButtonExtender = value;
			}
		}

		protected virtual CalendarExtender CalendarExtender1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CalendarExtender1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CalendarExtender1 = value;
			}
		}

		protected virtual Calendar CalendarRepetitiva
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CalendarRepetitiva;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._CalendarRepetitiva != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._CalendarRepetitiva.SelectionChanged -= new EventHandler(programacionConteo.CalendarRepetitiva_SelectionChanged);
				}
				this._CalendarRepetitiva = value;
				if (this._CalendarRepetitiva != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._CalendarRepetitiva.SelectionChanged += new EventHandler(programacionConteo1.CalendarRepetitiva_SelectionChanged);
				}
			}
		}

		protected virtual CheckBox chkDomingo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkDomingo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkDomingo = value;
			}
		}

		protected virtual CheckBox chkFestivos
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkFestivos;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkFestivos = value;
			}
		}

		protected virtual CheckBox chkJueves
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkJueves;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkJueves = value;
			}
		}

		protected virtual CheckBox chkLunes
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkLunes;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkLunes = value;
			}
		}

		protected virtual CheckBox chkMail
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkMail;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkMail = value;
			}
		}

		protected virtual CheckBox chkMartes
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkMartes;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkMartes = value;
			}
		}

		protected virtual CheckBox chkMiercoles
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkMiercoles;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkMiercoles = value;
			}
		}

		protected virtual CheckBox chkSabado
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkSabado;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkSabado = value;
			}
		}

		protected virtual CheckBox chkViernes
		{
			[DebuggerNonUserCode]
			get
			{
				return this._chkViernes;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkViernes = value;
			}
		}

		protected virtual DropDownList cmbDiaMensual
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbDiaMensual;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbDiaMensual = value;
			}
		}

		protected virtual DropDownList cmbHora
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHora;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHora = value;
			}
		}

		protected virtual DropDownList cmbHoraAP
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHoraAP;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHoraAP = value;
			}
		}

		protected virtual DropDownList cmbHoraFin
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHoraFin;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHoraFin = value;
			}
		}

		protected virtual DropDownList cmbHoraInicio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbHoraInicio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbHoraInicio = value;
			}
		}

		protected virtual DropDownList cmbSector
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbSector;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbSector != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._cmbSector.SelectedIndexChanged -= new EventHandler(programacionConteo.cmbSector_SelectedIndexChanged);
				}
				this._cmbSector = value;
				if (this._cmbSector != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._cmbSector.SelectedIndexChanged += new EventHandler(programacionConteo1.cmbSector_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbSubdeposito
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbSubdeposito;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbSubdeposito != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._cmbSubdeposito.SelectedIndexChanged -= new EventHandler(programacionConteo.cmbSubdeposito_SelectedIndexChanged);
				}
				this._cmbSubdeposito = value;
				if (this._cmbSubdeposito != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._cmbSubdeposito.SelectedIndexChanged += new EventHandler(programacionConteo1.cmbSubdeposito_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbSucursal
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbSucursal;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbSucursal != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._cmbSucursal.SelectedIndexChanged -= new EventHandler(programacionConteo.cmbSucursal_SelectedIndexChanged);
				}
				this._cmbSucursal = value;
				if (this._cmbSucursal != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._cmbSucursal.SelectedIndexChanged += new EventHandler(programacionConteo1.cmbSucursal_SelectedIndexChanged);
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
				this._cmbTipo = value;
			}
		}

		protected virtual DropDownList cmbTipoProgramacion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbTipoProgramacion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmbTipoProgramacion != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._cmbTipoProgramacion.SelectedIndexChanged -= new EventHandler(programacionConteo.cmbTipoProgramacion_SelectedIndexChanged);
				}
				this._cmbTipoProgramacion = value;
				if (this._cmbTipoProgramacion != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._cmbTipoProgramacion.SelectedIndexChanged += new EventHandler(programacionConteo1.cmbTipoProgramacion_SelectedIndexChanged);
				}
			}
		}

		protected virtual DropDownList cmbUsuario
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmbUsuario;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmbUsuario = value;
			}
		}

		protected virtual GridView grConteo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grConteo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grConteo != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._grConteo.SelectedIndexChanged -= new EventHandler(programacionConteo.grConteo_SelectedIndexChanged);
				}
				this._grConteo = value;
				if (this._grConteo != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._grConteo.SelectedIndexChanged += new EventHandler(programacionConteo1.grConteo_SelectedIndexChanged);
				}
			}
		}

		protected virtual GridView grErrores
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grErrores;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._grErrores = value;
			}
		}

		protected virtual GridView grRepetitiva
		{
			[DebuggerNonUserCode]
			get
			{
				return this._grRepetitiva;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._grRepetitiva != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._grRepetitiva.SelectedIndexChanged -= new EventHandler(programacionConteo.grRepetitiva_SelectedIndexChanged);
				}
				this._grRepetitiva = value;
				if (this._grRepetitiva != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._grRepetitiva.SelectedIndexChanged += new EventHandler(programacionConteo1.grRepetitiva_SelectedIndexChanged);
				}
			}
		}

		protected virtual ImageButton ibCalendario
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibCalendario;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ibCalendario = value;
			}
		}

		protected virtual ImageButton ibConfirmar
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibConfirmar;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibConfirmar != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._ibConfirmar.Click -= new ImageClickEventHandler(programacionConteo.ibConfirmar_Click);
				}
				this._ibConfirmar = value;
				if (this._ibConfirmar != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._ibConfirmar.Click += new ImageClickEventHandler(programacionConteo1.ibConfirmar_Click);
				}
			}
		}

		protected virtual ImageButton ibEliminar
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibEliminar;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ibEliminar != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._ibEliminar.Click -= new ImageClickEventHandler(programacionConteo.ibEliminar_Click);
				}
				this._ibEliminar = value;
				if (this._ibEliminar != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._ibEliminar.Click += new ImageClickEventHandler(programacionConteo1.ibEliminar_Click);
				}
			}
		}

		protected virtual ImageButton ibFinaliza
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ibFinaliza;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ibFinaliza = value;
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
					ProgramacionConteo programacionConteo = this;
					this._ibGuardar.Click -= new ImageClickEventHandler(programacionConteo.ibGuardar_Click);
				}
				this._ibGuardar = value;
				if (this._ibGuardar != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._ibGuardar.Click += new ImageClickEventHandler(programacionConteo1.ibGuardar_Click);
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

		protected virtual Label Label10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label10 = value;
			}
		}

		protected virtual Label Label11
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label11 = value;
			}
		}

		protected virtual Label Label12
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label12 = value;
			}
		}

		protected virtual Label Label13
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label13;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label13 = value;
			}
		}

		protected virtual Label Label14
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label14;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label14 = value;
			}
		}

		protected virtual Label Label15
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label15;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label15 = value;
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

		protected virtual Label Label4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
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

		protected virtual Label Label7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		protected virtual Label Label8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
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

		protected virtual Calendar MisFechas
		{
			[DebuggerNonUserCode]
			get
			{
				return this._MisFechas;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._MisFechas != null)
				{
					ProgramacionConteo programacionConteo = this;
					this._MisFechas.VisibleMonthChanged -= new MonthChangedEventHandler(programacionConteo.MisFechas_VisibleMonthChanged);
				}
				this._MisFechas = value;
				if (this._MisFechas != null)
				{
					ProgramacionConteo programacionConteo1 = this;
					this._MisFechas.VisibleMonthChanged += new MonthChangedEventHandler(programacionConteo1.MisFechas_VisibleMonthChanged);
				}
			}
		}

		protected virtual RadioButton rbActual
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbActual;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbActual = value;
			}
		}

		protected virtual RadioButton rbDia1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbDia1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbDia1 = value;
			}
		}

		protected virtual RadioButton rbDia2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbDia2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbDia2 = value;
			}
		}

		protected virtual RadioButton rbFecha
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbFecha;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbFecha = value;
			}
		}

		protected virtual RadioButton rbMes1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbMes1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbMes1 = value;
			}
		}

		protected virtual RadioButton rbMes2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._rbMes2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rbMes2 = value;
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

		protected virtual TabPanel TabPanel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPanel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPanel1 = value;
			}
		}

		protected virtual TabPanel TabPanel2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPanel2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPanel2 = value;
			}
		}

		protected virtual TabPanel TabPanel3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPanel3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPanel3 = value;
			}
		}

		protected virtual TabPanel TabPanel4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPanel4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPanel4 = value;
			}
		}

		protected virtual TabPanel TabPanel5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPanel5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPanel5 = value;
			}
		}

		protected virtual TabContainer tbProgramacion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbProgramacion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._tbProgramacion = value;
			}
		}

		protected virtual TextBox txtDate
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtDate;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtDate = value;
			}
		}

		protected virtual TextBox txtDia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtDia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtDia = value;
			}
		}

		protected virtual TextBox txtDiaMes
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtDiaMes;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtDiaMes = value;
			}
		}

		protected virtual TextBox txtFinaliza
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtFinaliza;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtFinaliza = value;
			}
		}

		protected virtual TextBox txtMes
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtMes;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtMes = value;
			}
		}

		protected virtual TextBox txtMesDia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtMesDia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtMesDia = value;
			}
		}

		protected virtual TextBox txtSemana
		{
			[DebuggerNonUserCode]
			get
			{
				return this._txtSemana;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtSemana = value;
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
		static ProgramacionConteo()
		{
			ProgramacionConteo.__ENCList = new ArrayList();
		}

		public ProgramacionConteo()
		{
			ProgramacionConteo programacionConteo = this;
			base.Load += new EventHandler(programacionConteo.Page_Load);
			ArrayList _ENCList = ProgramacionConteo.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ProgramacionConteo.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.oFactory = new Utilidades();
			this.wsData = new ControlPaquete.wsPackage.Service();
			this.objSeg = new ControlPaquete.wsPraxair.Service();
		}

		private void CalendarRepetitiva_SelectionChanged(object sender, EventArgs e)
		{
			this.InsertarGrillaRepetitiva();
		}

		private void CargarSectores(int sucursal)
		{
			this.lblError.Visible = false;
			try
			{
				this.cmbSector.Items.Clear();
				this.cmbSector.DataSource = null;
				this.cmbSector.DataBind();
				this.cmbSector.Items.Add("");
				DataSet ConsultarSectores = this.wsData.CrearSectores(Conversions.ToString(this.Session["Conexion"]), sucursal, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (ConsultarSectores.Tables[0].Rows.Count > 0)
				{
					this.cmbSector.DataSource = ConsultarSectores.Tables[0];
					this.cmbSector.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarSubdepositos(int Sucursal)
		{
			this.lblError.Visible = false;
			try
			{
				this.cmbSubdeposito.Items.Clear();
				this.cmbSubdeposito.DataSource = null;
				this.cmbSubdeposito.DataBind();
				this.cmbSubdeposito.Items.Add("");
				DataSet ConsultarSubdepositos = this.wsData.ConsultarSubdepositosConfigurados(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Sucursal);
				if (ConsultarSubdepositos.Tables[0].Rows.Count > 0)
				{
					this.cmbSubdeposito.DataSource = ConsultarSubdepositos.Tables[0];
					this.cmbSubdeposito.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarSucursales()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet ConsultarSucursales = this.wsData.ConsultarSucursales(Conversions.ToString(this.Session["Conexion"]), 0, Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (ConsultarSucursales.Tables[0].Rows.Count > 0)
				{
					this.cmbSucursal.DataSource = ConsultarSucursales.Tables[0];
					this.cmbSucursal.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CargarUsuarios()
		{
			this.lblError.Visible = false;
			try
			{
				DataSet ConsultarUsuarios = this.wsData.ObtenerUsuarios(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]));
				if (ConsultarUsuarios.Tables[0].Rows.Count > 0)
				{
					this.cmbUsuario.DataSource = ConsultarUsuarios.Tables[0];
					this.cmbUsuario.DataBind();
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblError.Visible = false;
			this.InsertarEnGrilla(string.Concat(this.cmbSucursal.SelectedValue, "-", this.cmbSucursal.Items[this.cmbSucursal.SelectedIndex].Text), string.Concat(this.cmbSector.SelectedValue, "-", this.cmbSector.Items[this.cmbSector.SelectedIndex].Text), "");
		}

		public void cmbSubdeposito_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.lblError.Visible = false;
				string[] vector = this.wsData.ObtenerSectorSubdeposito(Conversions.ToString(this.Session["Conexion"]), Conversions.ToInteger(this.Session["Grupo"]), Conversions.ToInteger(this.Session["Empresa"]), Conversions.ToInteger(this.cmbSucursal.SelectedValue), Conversions.ToInteger(this.cmbSubdeposito.SelectedValue)).Split(new char[] { '|' });
				if (Conversions.ToDouble(vector[0]) != 0)
				{
					this.MensajeError(string.Concat(vector[0], "-", vector[1]));
				}
				else
				{
					this.InsertarEnGrilla(string.Concat(this.cmbSucursal.SelectedValue, "-", this.cmbSucursal.Items[this.cmbSucursal.SelectedIndex].Text), vector[2], string.Concat(this.cmbSubdeposito.SelectedValue, "-", this.cmbSubdeposito.Items[this.cmbSubdeposito.SelectedIndex].Text));
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		public void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CargarSectores(Conversions.ToInteger(this.cmbSucursal.SelectedValue));
			this.CargarSubdepositos(Conversions.ToInteger(this.cmbSucursal.SelectedValue));
		}

		public void cmbTipoProgramacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = (DataTable)this.Session["Grilla"];
			dt.Rows.Clear();
			this.grConteo.DataSource = dt;
			this.grConteo.DataBind();
			this.Session["Grilla"] = dt;
			string selectedValue = this.cmbTipoProgramacion.SelectedValue;
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(selectedValue, "A", false) == 0)
			{
				this.cmbSector.Enabled = true;
				this.cmbSubdeposito.Enabled = false;
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(selectedValue, "P", false) == 0)
			{
				this.cmbSector.Enabled = false;
				this.cmbSubdeposito.Enabled = true;
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(selectedValue, "M", false) != 0)
			{
				this.cmbSector.Enabled = false;
				this.cmbSubdeposito.Enabled = false;
			}
			else
			{
				this.cmbSector.Enabled = false;
				this.cmbSubdeposito.Enabled = true;
			}
		}

		private void Configuracion()
		{
			this.lblError.Visible = false;
			try
			{
				this.tbProgramacion.ActiveTabIndex = 0;
				this.CargarSucursales();
				this.CargarUsuarios();
				DataTable dt = new DataTable();
				dt.Columns.Add(new DataColumn("NombreSucursal", typeof(string)));
				dt.Columns.Add(new DataColumn("NombreSector", typeof(string)));
				dt.Columns.Add(new DataColumn("NombreSubdeposito", typeof(string)));
				this.Session["Grilla"] = dt;
				DataTable dtFecha = new DataTable();
				dtFecha.Columns.Add(new DataColumn("Fecha", typeof(string)));
				this.Session["Fecha"] = dtFecha;
				List<DateTime> lstFechas = new List<DateTime>();
				this.Session["Calendario"] = lstFechas;
				this.Session["SucursalesConteo"] = lstFechas;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void Controles(bool Estado)
		{
			this.txtDate.Enabled = Estado;
			this.ibCalendario.Enabled = Estado;
			this.cmbHoraInicio.Enabled = Estado;
			this.cmbHoraAP.Enabled = Estado;
			this.cmbHoraFin.Enabled = Estado;
			this.cmbHora.Enabled = Estado;
			this.cmbTipoProgramacion.Enabled = Estado;
			this.cmbUsuario.Enabled = Estado;
			this.cmbSucursal.Enabled = Estado;
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cmbTipoProgramacion.SelectedValue, "A", false) != 0)
			{
				this.cmbSubdeposito.Enabled = Estado;
			}
			else
			{
				this.cmbSector.Enabled = Estado;
			}
			this.grConteo.Enabled = Estado;
			this.tbProgramacion.Enabled = Estado;
			this.rbActual.Enabled = Estado;
			this.rbFecha.Enabled = Estado;
			this.txtFinaliza.Enabled = Estado;
			this.ibFinaliza.Enabled = Estado;
			this.MisFechas.Enabled = Estado;
			this.ibGuardar.Enabled = Estado;
		}

		private void EliminarGrillaRepetitiva(DateTime Fecha)
		{
			this.lblError.Visible = false;
			try
			{
				this.Session["Fecha"] = this.oFactory.EliminarFilaEnGrillaProgramacion((DataTable)this.Session["Fecha"], Conversions.ToString(Fecha));
				this.grRepetitiva.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Fecha"]);
				this.grRepetitiva.DataBind();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void EliminarRegistro(string Sucursal, string Sector, string Subdep)
		{
			this.lblError.Visible = false;
			try
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Subdep, "&nbsp;", false) == 0)
				{
					Subdep = "";
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Sector, "&nbsp;", false) == 0)
				{
					Sector = "";
				}
				this.Session["Grilla"] = this.oFactory.EliminarFilaEnGrillaProgramacion((DataTable)this.Session["Grilla"], Sucursal, Sector, Subdep);
				this.grConteo.DataSource = RuntimeHelpers.GetObjectValue(this.Session["Grilla"]);
				this.grConteo.DataBind();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void grConteo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow item = this.grConteo.Rows[this.grConteo.SelectedIndex];
			this.EliminarRegistro(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
			item = null;
		}

		private void grRepetitiva_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.EliminarGrillaRepetitiva(Conversions.ToDate(this.grRepetitiva.Rows[this.grRepetitiva.SelectedIndex].Cells[0].Text));
		}

		public void ibConfirmar_Click(object sender, ImageClickEventArgs e)
		{
			DateTime fechaFin;
			IEnumerator enumerator = null;
			this.ibConfirmar.Visible = false;
			this.ibEliminar.Visible = false;
			this.grErrores.DataSource = null;
			this.grErrores.DataBind();
			this.Controles(true);
			if (!this.rbActual.Checked)
			{
				fechaFin = Conversions.ToDate(this.txtFinaliza.Text);
			}
			else
			{
				DateTime now = DateAndTime.Now;
				fechaFin = Conversions.ToDate(string.Concat("31/12/", Conversions.ToString(now.Year)));
			}
			switch (this.tbProgramacion.ActiveTabIndex)
			{
				case 0:
				{
					this.lstFechas.Add(Conversions.ToDate(this.txtDate.Text));
					break;
				}
				case 1:
				{
					this.lstFechas = this.oFactory.GenerarDiaria(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbDia1.Checked, Conversions.ToDouble(this.txtDia.Text));
					break;
				}
				case 2:
				{
					this.lstFechas = this.oFactory.GenerarSemanal(Conversions.ToDate(this.txtDate.Text), fechaFin, this.chkDomingo.Checked, this.chkLunes.Checked, this.chkMartes.Checked, this.chkMiercoles.Checked, this.chkJueves.Checked, this.chkViernes.Checked, this.chkSabado.Checked, Conversions.ToDouble(this.txtSemana.Text));
					break;
				}
				case 3:
				{
					this.lstFechas = this.oFactory.GenerarMensual(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbMes1.Checked, Conversions.ToInteger(this.txtDiaMes.Text), Conversions.ToDouble(this.txtMes.Text), Conversions.ToInteger(this.cmbDiaMensual.SelectedValue), Conversions.ToInteger(this.cmbTipo.SelectedValue));
					break;
				}
				case 4:
				{
					DataTable dtRepetitiva = new DataTable();
					dtRepetitiva = (DataTable)this.Session["Fecha"];
					try
					{
						enumerator = dtRepetitiva.Rows.GetEnumerator();
						while (enumerator.MoveNext())
						{
							DataRow r = (DataRow)enumerator.Current;
							if (DateTime.Compare(Conversions.ToDate(r[0]), Conversions.ToDate(this.txtDate.Text)) >= 0 & DateTime.Compare(Conversions.ToDate(r[0]), fechaFin) <= 0)
							{
								this.lstFechas.Add(Conversions.ToDate(r[0]));
							}
						}
						break;
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					break;
				}
			}
			this.InsertarRegistro(true);
		}

		public void ibEliminar_Click(object sender, ImageClickEventArgs e)
		{
			this.ibConfirmar.Visible = false;
			this.ibEliminar.Visible = false;
			this.grErrores.DataSource = null;
			this.grErrores.DataBind();
			this.Controles(true);
			this.Response.Redirect("ConteosReprogramacion.aspx");
		}

		public void ibGuardar_Click(object sender, ImageClickEventArgs e)
		{
			DateTime fechaFin;
			IEnumerator enumerator = null;
			if (this.ValidarDatos())
			{
				this.lblError.Visible = false;
				try
				{
					if (!this.rbActual.Checked)
					{
						fechaFin = Conversions.ToDate(this.txtFinaliza.Text);
					}
					else
					{
						DateTime now = DateAndTime.Now;
						fechaFin = Conversions.ToDate(string.Concat("31/12/", Conversions.ToString(now.Year)));
					}
					switch (this.tbProgramacion.ActiveTabIndex)
					{
						case 0:
						{
							this.lstFechas.Add(Conversions.ToDate(this.txtDate.Text));
							break;
						}
						case 1:
						{
							this.lstFechas = this.oFactory.GenerarDiaria(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbDia1.Checked, Conversions.ToDouble(this.txtDia.Text));
							break;
						}
						case 2:
						{
							this.lstFechas = this.oFactory.GenerarSemanal(Conversions.ToDate(this.txtDate.Text), fechaFin, this.chkDomingo.Checked, this.chkLunes.Checked, this.chkMartes.Checked, this.chkMiercoles.Checked, this.chkJueves.Checked, this.chkViernes.Checked, this.chkSabado.Checked, Conversions.ToDouble(this.txtSemana.Text));
							break;
						}
						case 3:
						{
							this.lstFechas = this.oFactory.GenerarMensual(Conversions.ToDate(this.txtDate.Text), fechaFin, this.rbMes1.Checked, Conversions.ToInteger(this.txtDiaMes.Text), Conversions.ToDouble(this.txtMes.Text), Conversions.ToInteger(this.cmbDiaMensual.SelectedValue), Conversions.ToInteger(this.cmbTipo.SelectedValue));
							break;
						}
						case 4:
						{
							DataTable dtRepetitiva = new DataTable();
							dtRepetitiva = (DataTable)this.Session["Fecha"];
							try
							{
								enumerator = dtRepetitiva.Rows.GetEnumerator();
								while (enumerator.MoveNext())
								{
									DataRow r = (DataRow)enumerator.Current;
									if (DateTime.Compare(Conversions.ToDate(r[0]), Conversions.ToDate(this.txtDate.Text)) >= 0 & DateTime.Compare(Conversions.ToDate(r[0]), fechaFin) <= 0)
									{
										this.lstFechas.Add(Conversions.ToDate(r[0]));
									}
								}
								break;
							}
							finally
							{
								if (enumerator is IDisposable)
								{
									(enumerator as IDisposable).Dispose();
								}
							}
							break;
						}
					}
					this.InsertarRegistro(false);
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					this.MensajeError(exception.Message);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void InsertarEnGrilla(string Sucursal, string Sector, string Subdep)
		{
			this.lblError.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["Grilla"];
				if (!this.oFactory.ExisteFilaEnGrillaProgramacion(dt, Sucursal, Sector, Subdep))
				{
					DataRow dr = dt.NewRow();
					dr[0] = Sucursal;
					dr[1] = Sector;
					dr[2] = Subdep;
					dt.Rows.Add(dr);
					this.Session["Grilla"] = dt;
					this.grConteo.DataSource = dt;
					this.grConteo.DataBind();
				}
				this.cmbSubdeposito.Text = "";
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void InsertarGrillaRepetitiva()
		{
			this.lblError.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["Fecha"];
				if (!this.oFactory.ExisteFilaEnGrillaProgramacion(dt, Conversions.ToString(this.CalendarRepetitiva.SelectedDate)))
				{
					int year = this.CalendarRepetitiva.SelectedDate.Year;
					DateTime now = DateAndTime.Now;
					if (DateTime.Compare(this.CalendarRepetitiva.SelectedDate, DateAndTime.Now) > 0 & year == now.Year)
					{
						DataRow dr = dt.NewRow();
						dr[0] = Strings.Format(this.CalendarRepetitiva.SelectedDate, "dd/MM/yyyy");
						dt.Rows.Add(dr);
						this.Session["Fecha"] = dt;
						this.grRepetitiva.DataSource = dt;
						this.grRepetitiva.DataBind();
					}
				}
				this.CalendarRepetitiva.SelectedDates.Clear();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void InsertarRegistro(bool Confirmacion)
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator1 = null;
			IEnumerator enumerator2 = null;
			this.lblError.Visible = false;
			try
			{
				int UltimoConteo = this.wsData.UltimoConteo(Conversions.ToString(this.Session["Conexion"]));
				List<string> lstSucursales = new List<string>();
				DataTable dt = new DataTable();
				dt = ((DataTable)this.Session["Grilla"]).Copy();
				try
				{
					enumerator = dt.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow dr = (DataRow)enumerator.Current;
						if (!lstSucursales.Contains(Conversions.ToString(dr[0])))
						{
							lstSucursales.Add(Conversions.ToString(dr[0]));
						}
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				DataSet ds = new DataSet();
				ds.Tables.Add(dt);
				string Programacion = this.wsData.ProgramarConteo(Conversions.ToString(this.Session["Conexion"]), this.lstFechas.ToArray(), string.Concat(this.cmbHoraInicio.Items[this.cmbHoraInicio.SelectedIndex].Text, " ", this.cmbHora.Items[this.cmbHora.SelectedIndex].Text), string.Concat(this.cmbHoraFin.Items[this.cmbHoraFin.SelectedIndex].Text, " ", this.cmbHoraAP.Items[this.cmbHoraAP.SelectedIndex].Text), this.cmbTipoProgramacion.SelectedValue, Conversions.ToInteger(this.cmbUsuario.SelectedValue), this.chkMail.Checked, false, Conversions.ToString(this.tbProgramacion.ActiveTabIndex), Conversions.ToString(this.Session["UsuarioRegistro"]), ds, lstSucursales.ToArray(), Confirmacion);
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Programacion, "", false) == 0)
				{
					DataSet dataS = new DataSet();
					dataS = this.wsData.ObtenerConteos(Conversions.ToString(this.Session["Conexion"]), UltimoConteo);
					List<DateTime> lstFechas = new List<DateTime>();
					try
					{
						enumerator2 = dataS.Tables[0].Rows.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							DataRow dr = (DataRow)enumerator2.Current;
							DateTime Fecha = Conversions.ToDate(dr[0]);
							this.MisFechas.SelectedDates.Add(Fecha);
							lstFechas.Add(Fecha);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					this.Session["Calendario"] = lstFechas;
				}
				else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Programacion.Substring(0, 1), ".", false) == 0)
				{
					string[] VectorErrores = Programacion.Split(new char[] { '|' });
					dt = new DataTable();
					dt.Columns.Add(new DataColumn("Error", typeof(string)));
					int length = checked(checked((int)VectorErrores.Length) - 2);
					for (int i = 0; i <= length; i = checked(i + 1))
					{
						DataRow dr = dt.NewRow();
						dr[0] = VectorErrores[i];
						dt.Rows.Add(dr);
					}
					this.grErrores.DataSource = dt;
					this.grErrores.DataBind();
					this.Controles(false);
					this.ibConfirmar.Visible = true;
					this.ibEliminar.Visible = true;
					DataSet dataS = new DataSet();
					dataS = this.wsData.ObtenerConteos(Conversions.ToString(this.Session["Conexion"]), UltimoConteo);
					List<DateTime> lstFechas = new List<DateTime>();
					try
					{
						enumerator1 = dataS.Tables[0].Rows.GetEnumerator();
						while (enumerator1.MoveNext())
						{
							DataRow dr = (DataRow)enumerator1.Current;
							DateTime Fecha = Conversions.ToDate(dr[0]);
							this.MisFechas.SelectedDates.Add(Fecha);
							lstFechas.Add(Fecha);
						}
					}
					finally
					{
						if (enumerator1 is IDisposable)
						{
							(enumerator1 as IDisposable).Dispose();
						}
					}
					this.Session["Calendario"] = lstFechas;
				}
				else
				{
					this.MensajeError(Programacion);
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

		private void MisFechas_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
		{
			List<DateTime> lstFechas = new List<DateTime>();
			lstFechas = (List<DateTime>)this.Session["Calendario"];
			int count = checked(lstFechas.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				this.MisFechas.SelectedDates.Add(lstFechas[i]);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.wsData.Credentials = CredentialCache.DefaultCredentials;
			this.objSeg.Credentials = CredentialCache.DefaultCredentials;
			if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.Session["Conexion"], "", false))
			{
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.objSeg.usuarioFuncion(Conversions.ToInteger(this.Session["Usuario"]), "CP_PROPRO"), "1", false) != 0)
			{
				this.Response.Redirect("Error.aspx?mensaje=No está autorizado el ingreso");
			}
			else
			{
				if (!this.IsPostBack)
				{
					this.Configuracion();
					this.MisFechas.SelectedDates.Clear();
				}
				this.lstFechas = new List<DateTime>();
			}
		}

		private bool ValidarDatos()
		{
			bool ValidarDatos;
			this.lblError.Visible = false;
			try
			{
				DataTable dt = new DataTable();
				dt = (DataTable)this.Session["Grilla"];
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtDate.Text, "", false) == 0)
				{
					this.MensajeError("Debe escoger una fecha de inicio");
					this.txtDate.Focus();
				}
				else if (DateTime.Compare(Conversions.ToDate(this.txtDate.Text), DateAndTime.Now) <= 0)
				{
					this.MensajeError("La fecha de inicio debe ser mayor que el día de hoy");
					this.txtDate.Focus();
				}
				else if (!this.oFactory.ValidarHora(Conversions.ToInteger(this.cmbHoraInicio.SelectedValue), Conversions.ToInteger(this.cmbHoraFin.SelectedValue), Conversions.ToInteger(this.cmbHoraAP.SelectedValue)))
				{
					this.MensajeError("La hora fin debe ser mayor que la hora inicio");
					this.cmbHoraInicio.Focus();
				}
				else if (dt.Rows.Count < 1)
				{
					this.MensajeError("Debe escoger al menos un subdepósito para el conteo");
					this.cmbSucursal.Focus();
				}
				else if (!this.rbActual.Checked & !this.rbFecha.Checked)
				{
					this.MensajeError("Debe seleccionar cuando terminará la programación del conteo");
					this.rbActual.Focus();
				}
				else if (!(this.rbFecha.Checked & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFinaliza.Text, "", false) == 0))
				{
					switch (this.tbProgramacion.ActiveTabIndex)
					{
						case 0:
						{
							this.lblError.Visible = false;
							ValidarDatos = true;
							return ValidarDatos;
						}
						case 1:
						{
							if (!(this.rbDia1.Checked | this.rbDia2.Checked))
							{
								this.MensajeError("Debe escoger el tipo de programación para el día");
							}
							else if (!this.rbDia1.Checked)
							{
								this.lblError.Visible = false;
								ValidarDatos = true;
								return ValidarDatos;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtDia.Text, "", false) == 0)
							{
								this.MensajeError("Debe escoger el intervalo de días");
							}
							else if (!this.oFactory.SoloNumeros(this.txtDia.Text))
							{
								this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
							}
							else if (!(Conversions.ToDouble(this.txtDia.Text) < 1 | Conversions.ToDouble(this.txtDia.Text) > 31))
							{
								this.lblError.Visible = false;
								ValidarDatos = true;
								return ValidarDatos;
							}
							else
							{
								this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
							}
							break;
						}
						case 2:
						{
							if (!(this.chkDomingo.Checked | this.chkLunes.Checked | this.chkMartes.Checked | this.chkMiercoles.Checked | this.chkJueves.Checked | this.chkViernes.Checked | this.chkSabado.Checked))
							{
								this.MensajeError("Debe escoger el intervalo de semanas");
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtSemana.Text, "", false) == 0)
							{
								this.MensajeError("Debe escoger el intervalo de semanas");
							}
							else if (!this.oFactory.SoloNumeros(this.txtSemana.Text))
							{
								this.MensajeError("El intervalo de semanas debe ser numérico y en el rango de 1 a 4");
							}
							else if (!(Conversions.ToInteger(this.txtSemana.Text) < 1 | Conversions.ToInteger(this.txtSemana.Text) > 4))
							{
								this.lblError.Visible = false;
								ValidarDatos = true;
								return ValidarDatos;
							}
							else
							{
								this.MensajeError("El intervalo de semanas debe ser numérico y en el rango de 1 a 4");
							}
							break;
						}
						case 3:
						{
							if (!(this.rbMes1.Checked | this.rbMes2.Checked))
							{
								this.MensajeError("Debe escoger el tipo de programación para el mes");
							}
							else if (!this.rbMes1.Checked)
							{
								if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtMesDia.Text, "", false) == 0)
								{
									this.MensajeError("Debe escoger el intervalo de meses");
								}
								else if (!this.oFactory.SoloNumeros(this.txtMesDia.Text))
								{
									this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
								}
								else if (!(Conversions.ToDouble(this.txtMesDia.Text) < 1 | Conversions.ToDouble(this.txtMesDia.Text) > 12))
								{
									this.lblError.Visible = false;
									ValidarDatos = true;
									return ValidarDatos;
								}
								else
								{
									this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
								}
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtDiaMes.Text, "", false) == 0)
							{
								this.MensajeError("Debe escoger el intervalo de días");
							}
							else if (!this.oFactory.SoloNumeros(this.txtDiaMes.Text))
							{
								this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
							}
							else if (Conversions.ToDouble(this.txtDiaMes.Text) < 1 | Conversions.ToDouble(this.txtDiaMes.Text) > 31)
							{
								this.MensajeError("El intervalo de días debe ser numérico y en el rango de 1 a 31");
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtMes.Text, "", false) == 0)
							{
								this.MensajeError("Debe escoger el intervalo de meses");
							}
							else if (!this.oFactory.SoloNumeros(this.txtMes.Text))
							{
								this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
							}
							else if (!(Conversions.ToDouble(this.txtMes.Text) < 1 | Conversions.ToDouble(this.txtMes.Text) > 12))
							{
								this.lblError.Visible = false;
								ValidarDatos = true;
								return ValidarDatos;
							}
							else
							{
								this.MensajeError("El intervalo de meses debe ser numérico y en el rango de 1 a 12");
							}
							break;
						}
						case 4:
						{
							DataTable dtRepetitiva = new DataTable();
							if (((DataTable)this.Session["Fecha"]).Rows.Count >= 1)
							{
								this.lblError.Visible = false;
								ValidarDatos = true;
								return ValidarDatos;
							}
							else
							{
								this.MensajeError("Debe escoger al menos una fecha en la que se ejecutará la programación");
								break;
							}
						}
					}
				}
				else
				{
					this.MensajeError("Debe escoger la fecha en la cual finalizará el conteo");
					this.txtFinaliza.Focus();
				}
				ValidarDatos = false;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.MensajeError(exception.Message);
				ValidarDatos = false;
				ProjectData.ClearProjectError();
			}
			return ValidarDatos;
		}
	}
}