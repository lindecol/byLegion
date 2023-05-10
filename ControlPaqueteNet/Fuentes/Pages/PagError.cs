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
	public class PagError : System.Web.UI.Page
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
					PagError pagError = this;
					this._btnInicio.Click -= new EventHandler(pagError.btnInicio_Click);
				}
				this._btnInicio = value;
				if (this._btnInicio != null)
				{
					PagError pagError1 = this;
					this._btnInicio.Click += new EventHandler(pagError1.btnInicio_Click);
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
		static PagError()
		{
			PagError.__ENCList = new ArrayList();
		}

		[DebuggerNonUserCode]
		public PagError()
		{
			PagError pagError = this;
			base.Load += new EventHandler(pagError.Page_Load);
			ArrayList _ENCList = PagError.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				PagError.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			this.Response.Redirect(ConfigurationManager.AppSettings["PaginaInicio"]);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.lblError.Text = this.Request.QueryString["mensaje"];
		}
	}
}