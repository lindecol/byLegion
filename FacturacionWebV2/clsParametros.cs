using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FacturacionNETV2
{
	internal class clsParametros
	{
		public const long NoMaxRegistros = 65000L;

		public static clsParametros ObjParm;

		private string _Agencia;

		private string _Usuario;

		private string _Password;

		private string _Empresa;

		private string _Grupo;

		private string _NombreConexion;

		private string _IdUsuario;

		private string _Modulo;

		private string _DirReports;

		public string Agencia
		{
			get
			{
				return this._Agencia;
			}
			set
			{
				this._Agencia = value;
			}
		}

		public string DirReports
		{
			get
			{
				return this._DirReports;
			}
			set
			{
				this._DirReports = value;
			}
		}

		public string Empresa
		{
			get
			{
				return this._Empresa;
			}
			set
			{
				this._Empresa = value;
			}
		}

		public string Grupo
		{
			get
			{
				return this._Grupo;
			}
			set
			{
				this._Grupo = value;
			}
		}

		public string IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				this._IdUsuario = value;
			}
		}

		public string Modulo
		{
			get
			{
				return this._Modulo;
			}
			set
			{
				this._Modulo = value;
			}
		}

		public string NombreConexion
		{
			get
			{
				return this._NombreConexion;
			}
			set
			{
				this._NombreConexion = value;
			}
		}

		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				this._Password = value;
			}
		}

		public string Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				this._Usuario = value;
			}
		}

		public clsParametros()
		{
		}

		private void CambiarConexion()
		{
			try
			{
				Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				ConnectionStringsSection connectionStrings = configuration.ConnectionStrings;
				ConnectionStringSettings connectionStringSetting = new ConnectionStringSettings("Conexion", string.Concat("Data Source=", clsParametros.ObjParm.NombreConexion, ";Persist Security Info=true;User Id=PRAXLOGIN;Password=PRAXLOGIN;Unicode=true"), "System.Data.OracleClient");
				connectionStrings.ConnectionStrings.Add(connectionStringSetting);
				configuration.Save(ConfigurationSaveMode.Modified);
			}
			catch (Exception exception)
			{
			}
		}

		public void FuncionUsuario(ref ToolStrip ts)
		{
			OracleCommand dbComando;
			clsConexion _clsConexion = new clsConexion();
			try
			{
				dbComando = _clsConexion.GetDbComando("PKG_REPORTES.PRC_FUNCION_USUARIO", clsConexion.TipoComm.StoreProcedure);
				_clsConexion.AddInParameter(ref dbComando, "P_USUARIO", DbType.Int64, clsParametros.ObjParm.IdUsuario);
				_clsConexion.AddInParameter(ref dbComando, "P_MODULO", DbType.String, clsParametros.ObjParm.Modulo);
				foreach (DataRow row in _clsConexion.ExecuteDataSet(ref dbComando).Tables[0].Rows)
				{
					foreach (ToolStripSplitButton item in ts.Items)
					{
						if ((item.Tag == null ? false : item.Tag.ToString() == row.ItemArray[0].ToString()))
						{
							item.Visible = true;
						}
					}
				}
			}
			finally
			{
				_clsConexion = null;
				dbComando = null;
			}
		}

		public string GetKeyConfiguracionOxigenos(string sFile, string sSection, string sKey)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int windowsDirectory = (int)clsParametros.GetWindowsDirectory(stringBuilder, 255);
			string str = Path.Combine(stringBuilder.ToString(0, windowsDirectory), sFile);
			return this.IniGet(str, sSection, sKey, "");
		}

		[DllImport("Kernel32.dll", CharSet=CharSet.Auto, ExactSpelling=false)]
		public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString, int nSize, string lpFileName);

		[DllImport("Kernel32.dll", CharSet=CharSet.Auto, ExactSpelling=false)]
		public static extern int GetPrivateProfileString(string lpAppName, int lpKeyName, string lpDefault, string lpReturnedString, int nSize, string lpFileName);

		[DllImport("kernel32.dll", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
		public static extern uint GetWindowsDirectory(StringBuilder lpBuffer, uint uSize);

		public static bool InicioAplicacion(string[] args, string strModulo)
		{
			bool flag;
			clsParametros.ObjParm = new clsParametros();
			if (!((int)args.Length).Equals(0))
			{
				if (((int)args.Length).Equals(1))
				{
					string[] strArrays = args[0].Split(new char[] { ',' });
					clsParametros.ObjParm.InitPatametros(strArrays[5], strArrays[0], strArrays[2], strArrays[6], strArrays[3], strArrays[4], clsParametros.ObjParm.GetKeyConfiguracionOxigenos("CS2000.INI", "CS2000", "NmbBD"), clsParametros.ObjParm.GetKeyConfiguracionOxigenos("CS2000.INI", "CS2000", "DirReports"), strModulo);
				}
				else if (((int)args.Length).Equals(8))
				{
					clsParametros.ObjParm.InitPatametros(args[5], args[0], args[2], args[7], args[3], args[4], clsParametros.ObjParm.GetKeyConfiguracionOxigenos("CS2000.INI", "CS2000", "NmbBD"), clsParametros.ObjParm.GetKeyConfiguracionOxigenos("CS2000.INI", "CS2000", "DirReports"), strModulo);
				}
				else if (((int)args.Length).Equals(7))
				{
					clsParametros.ObjParm.InitPatametros(args[5], args[0], args[2], args[6], args[3], args[4], clsParametros.ObjParm.GetKeyConfiguracionOxigenos("CS2000.INI", "CS2000", "NmbBD"), clsParametros.ObjParm.GetKeyConfiguracionOxigenos("CS2000.INI", "CS2000", "DirReports"), strModulo);
				}
				flag = true;
			}
			else
			{
				MessageBox.Show("Parámetro(s) de la línea de comandos incorrecto(s)  \nComuníquese con Mesa e Ayuda", "Error de Inicio", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				flag = false;
			}
			return flag;
		}

		public string IniGet(string sFileName, string sSection, string sKeyName, string sDefault)
		{
			string str;
			string str1 = new string(' ', 255);
			int privateProfileString = clsParametros.GetPrivateProfileString(sSection, sKeyName, sDefault, str1, str1.Length, sFileName);
			str = (privateProfileString != 0 ? str1.Substring(0, privateProfileString) : sDefault);
			return str;
		}

		private void InitPatametros(string p_Agencia, string p_Usuario, string p_Usrid, string p_Pwd, string p_Grupo, string p_Empresa, string p_Conexion, string p_DirReports, string p_Modulo)
		{
			clsParametros.ObjParm.Agencia = p_Agencia.PadLeft(5, '0');
			clsParametros.ObjParm.Usuario = p_Usuario.Replace(",", "");
			clsParametros.ObjParm.Password = p_Pwd;
			clsParametros.ObjParm.Grupo = p_Grupo;
			clsParametros.ObjParm.Empresa = p_Empresa;
			clsParametros.ObjParm.NombreConexion = p_Conexion;
			clsParametros.ObjParm.IdUsuario = p_Usrid.Replace(",", "").Trim();
			clsParametros.ObjParm.Modulo = p_Modulo;
			clsParametros.ObjParm.DirReports = p_DirReports;
			this.CambiarConexion();
		}

		public enum CamComm
		{
			UsrNmb,
			PasPrx,
			UsrId,
			Grpecid,
			EmpId,
			Scrid,
			PasDb1,
			PasDb2
		}
	}
}