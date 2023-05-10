using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPaquete
{
	public class ErrorDispositivo : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("lblError")]
		private Label _lblError;

		[AccessedThroughProperty("btnInicio")]
		private Button _btnInicio;

		protected virtual Button btnInicio
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnInicio;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._btnInicio != null)
				{
					ErrorDispositivo errorDispositivo = this;
					this._btnInicio.Click -= new EventHandler(errorDispositivo.btnInicio_Click);
				}
				this._btnInicio = value;
				if (this._btnInicio != null)
				{
					ErrorDispositivo errorDispositivo1 = this;
					this._btnInicio.Click += new EventHandler(errorDispositivo1.btnInicio_Click);
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

		[DebuggerNonUserCode]
		static ErrorDispositivo()
		{
			ErrorDispositivo.__ENCList = new ArrayList();
		}

		[DebuggerNonUserCode]
		public ErrorDispositivo()
		{
			ErrorDispositivo errorDispositivo = this;
			base.Load += new EventHandler(errorDispositivo.Page_Load);
			ArrayList _ENCList = ErrorDispositivo.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ErrorDispositivo.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			this.Response.Redirect(ConfigurationManager.AppSettings["PaginaInicioDispositivo"]);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.lblError.Text = this.Request.QueryString["mensaje"];
		}
	}
}