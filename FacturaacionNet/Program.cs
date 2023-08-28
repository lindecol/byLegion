using System;
using System.Windows.Forms;

namespace FacturacionNET
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			if (clsParametros.InicioAplicacion(args, ""))
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new frmGeneraNC());
			}
		}
	}
}