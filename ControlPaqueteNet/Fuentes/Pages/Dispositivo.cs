using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ControlPaquete
{
	/// 	<summary>
	/// Clase Dispositivo.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class Dispositivo : System.Web.UI.MasterPage
	{
		private static ArrayList __ENCList;

		[AccessedThroughProperty("Head1")]
		private HtmlHead _Head1;

		[AccessedThroughProperty("form1")]
		private HtmlForm _form1;

		[AccessedThroughProperty("ContentPlaceHolder1")]
		private ContentPlaceHolder _ContentPlaceHolder1;

		[AccessedThroughProperty("Image1")]
		private Image _Image1;

		[AccessedThroughProperty("ContentPlaceHolder2")]
		private ContentPlaceHolder _ContentPlaceHolder2;

		[AccessedThroughProperty("ContentPlaceHolder3")]
		private ContentPlaceHolder _ContentPlaceHolder3;

		[AccessedThroughProperty("Image2")]
		private Image _Image2;

		protected virtual ContentPlaceHolder ContentPlaceHolder1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ContentPlaceHolder1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ContentPlaceHolder1 = value;
			}
		}

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

		protected virtual ContentPlaceHolder ContentPlaceHolder3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ContentPlaceHolder3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ContentPlaceHolder3 = value;
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

		protected virtual Image Image1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Image1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Image1 = value;
			}
		}

		protected virtual Image Image2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Image2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Image2 = value;
			}
		}

		[DebuggerNonUserCode]
		static Dispositivo()
		{
			Dispositivo.__ENCList = new ArrayList();
		}

		[DebuggerNonUserCode]
		public Dispositivo()
		{
			Dispositivo dispositivo = this;
			base.Load += new EventHandler(dispositivo.Page_Load);
			ArrayList _ENCList = Dispositivo.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				Dispositivo.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}
	}
}