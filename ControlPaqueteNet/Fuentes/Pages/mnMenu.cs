using System;
using System.Diagnostics;
using System.Web.UI;

namespace ControlPaquete
{
	/// 	<summary>
	/// Clase mnMenu.
	/// </summary>
	/// 	<remarks>
	/// Clase generada automáticamente.
	/// </remarks>
	public class mnMenu : UserControl
	{
		[DebuggerNonUserCode]
		public mnMenu()
		{
			mnMenu _mnMenu = this;
			base.Load += new EventHandler(_mnMenu.Page_Load);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}
	}
}