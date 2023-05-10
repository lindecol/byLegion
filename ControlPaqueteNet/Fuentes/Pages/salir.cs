using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ControlPaquete
{
	public class salir : System.Web.UI.Page
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("form1")]
		private HtmlForm _form1;

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

		[DebuggerNonUserCode]
		static salir()
		{
			salir.__ENCList = new ArrayList();
		}

		[DebuggerNonUserCode]
		public salir()
		{
			salir _salir = this;
			base.Load += new EventHandler(_salir.Page_Load);
			ArrayList _ENCList = salir.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				salir.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			ClientScriptManager csm = this.Page.ClientScript;
			if (!csm.IsStartupScriptRegistered(this.GetType(), "winClose"))
			{
				csm.RegisterStartupScript(this.GetType(), "winClose", "window.close();", true);
			}
		}
	}
}