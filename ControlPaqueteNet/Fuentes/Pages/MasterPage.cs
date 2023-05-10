using ControlPaquete.wsPraxair;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ControlPaquete
{
	public class MasterPage : System.Web.UI.MasterPage
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("Head1")]
		private HtmlHead _Head1;

		[AccessedThroughProperty("form1")]
		private HtmlForm _form1;

		[AccessedThroughProperty("lblPais")]
		private Label _lblPais;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("ImageButton1")]
		private ImageButton _ImageButton1;

		[AccessedThroughProperty("ContentPlaceHolder2")]
		private ContentPlaceHolder _ContentPlaceHolder2;

		[AccessedThroughProperty("MnMenu1")]
		private mnMenu _MnMenu1;

		[AccessedThroughProperty("ContentPlaceHolder4")]
		private ContentPlaceHolder _ContentPlaceHolder4;

		[AccessedThroughProperty("lblGrupo")]
		private Label _lblGrupo;

		[AccessedThroughProperty("lblEmpresa")]
		private Label _lblEmpresa;

		[AccessedThroughProperty("lblAgencia")]
		private Label _lblAgencia;

		protected virtual ContentPlaceHolder ContentPlaceHolder2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ContentPlaceHolder2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ContentPlaceHolder2 = value;
			}
		}

		protected virtual ContentPlaceHolder ContentPlaceHolder4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ContentPlaceHolder4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ContentPlaceHolder4 = value;
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

		protected virtual HtmlHead Head1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Head1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Head1 = value;
			}
		}

		protected virtual ImageButton ImageButton1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ImageButton1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._ImageButton1 != null)
				{
					ControlPaquete.MasterPage masterPage = this;
					this._ImageButton1.Click -= new ImageClickEventHandler(masterPage.ImageButton1_Click);
				}
				this._ImageButton1 = value;
				if (this._ImageButton1 != null)
				{
					ControlPaquete.MasterPage masterPage1 = this;
					this._ImageButton1.Click += new ImageClickEventHandler(masterPage1.ImageButton1_Click);
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

		protected virtual Label lblAgencia
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblAgencia;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblAgencia = value;
			}
		}

		protected virtual Label lblEmpresa
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblEmpresa;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblEmpresa = value;
			}
		}

		protected virtual Label lblGrupo
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblGrupo;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblGrupo = value;
			}
		}

		protected virtual Label lblPais
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblPais;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblPais = value;
			}
		}

		protected virtual mnMenu MnMenu1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._MnMenu1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._MnMenu1 = value;
			}
		}

		[DebuggerNonUserCode]
		static MasterPage()
		{
			ControlPaquete.MasterPage.__ENCList = new ArrayList();
		}

		[DebuggerNonUserCode]
		public MasterPage()
		{
			ControlPaquete.MasterPage masterPage = this;
			base.Load += new EventHandler(masterPage.Page_Load);
			ArrayList _ENCList = ControlPaquete.MasterPage.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ControlPaquete.MasterPage.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

		protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
		{
			this.Response.Redirect("salir.aspx");
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				this.lblPais.Text = "Colombia";
				object objSeg = new Service();
				string strPais = Conversions.ToString(NewLateBinding.LateGet(objSeg, null, "PAIS", new object[0], null, null, null));
				Label str = this.lblPais;
				object[] objectValue = new object[] { strPais, null, null };
				HttpSessionState session = this.Session;
				string str1 = "Empresa";
				objectValue[1] = RuntimeHelpers.GetObjectValue(session[str1]);
				objectValue[2] = "NOM_PAIS";
				object[] num = objectValue;
				bool[] flagArray = new bool[] { true, true, false };
				object obj = NewLateBinding.LateGet(objSeg, null, "valorcache", num, null, null, flagArray);
				if (flagArray[0])
				{
					strPais = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(num[0]), typeof(string));
				}
				if (flagArray[1])
				{
					session[str1] = RuntimeHelpers.GetObjectValue(num[1]);
				}
				str.Text = Conversions.ToString(obj);
				Label label2 = this.Label2;
				num = new object[] { this.Session["UsuarioRegistro"].ToString(), 6 };
				label2.Text = Conversions.ToString(Operators.AddObject("Usuario: ", NewLateBinding.LateGet(objSeg, null, "datosUsuario", num, null, null, null)));
				if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Grupo"], null, false))
				{
					this.lblGrupo.Visible = false;
				}
				else
				{
					Label label = this.lblGrupo;
					string str2 = string.Concat(string.Concat("Grupo: ", this.Session["Grupo"].ToString()), "- ");
					num = new object[] { Convert.ToInt32(this.Session["Grupo"].ToString()) };
					label.Text = Conversions.ToString(Operators.AddObject(str2, NewLateBinding.LateGet(objSeg, null, "descripcionGrupo", num, null, null, null)));
					this.lblGrupo.Visible = true;
				}
				if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Empresa"], null, false))
				{
					this.lblEmpresa.Visible = false;
				}
				else
				{
					Label label1 = this.lblEmpresa;
					string str3 = string.Concat(string.Concat("Empresa: ", this.Session["Empresa"].ToString()), "- ");
					num = new object[] { Convert.ToInt32(this.Session["Empresa"].ToString()), Convert.ToInt32(this.Session["Grupo"].ToString()) };
					label1.Text = Conversions.ToString(Operators.AddObject(str3, NewLateBinding.LateGet(objSeg, null, "descripcionEmpresa", num, null, null, null)));
					this.lblEmpresa.Visible = true;
				}
				if (!Operators.ConditionalCompareObjectNotEqual(this.Session["Agencia"], null, false))
				{
					this.lblAgencia.Visible = false;
				}
				else
				{
					Label label3 = this.lblAgencia;
					string str4 = string.Concat(string.Concat("Agencia: ", this.Session["Agencia"].ToString()), "- ");
					num = new object[] { Convert.ToInt32(this.Session["Empresa"].ToString()), Convert.ToInt32(this.Session["Grupo"].ToString()), this.Session["Agencia"].ToString() };
					label3.Text = Conversions.ToString(Operators.AddObject(str4, NewLateBinding.LateGet(objSeg, null, "descripcionAgencia", num, null, null, null)));
					this.lblAgencia.Visible = true;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				this.Response.Redirect("Error.aspx?mensaje=Se ha vencido la sesión, por favor coloque nuevamente su usuario y contraseña");
				ProjectData.ClearProjectError();
			}
		}
	}
}