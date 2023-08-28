using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

namespace FacturacionNETV2
{
	internal class clsConexion
	{
		private DbConnection _con;

		private DbTransaction _trans;

		public clsConexion()
		{
			this.GetDBConnection(false);
		}

		public clsConexion(bool bnlTrans)
		{
			this.GetDBConnection(true);
			if (bnlTrans)
			{
				this._trans = this._con.BeginTransaction();
			}
		}

		public void AddInParameter(ref OracleCommand com, string nombre, DbType tipo, object valor)
		{
			DbParameter length = com.CreateParameter();
			length.Size = valor.ToString().Length;
			length.ParameterName = nombre;
			length.Direction = ParameterDirection.Input;
			length.DbType = tipo;
			length.Value = valor;
			com.Parameters.Add(length);
		}

		public void AddOutParameterCursor(ref OracleCommand com)
		{
			OracleParameter oracleParameter = new OracleParameter()
			{
				ParameterName = "cur_OUT",
				Direction = ParameterDirection.Output,
				OracleType = OracleType.Cursor
			};
			com.Parameters.Add(oracleParameter);
		}

		public void CommitTransaction()
		{
			this._trans.Commit();
			this._con.Close();
		}

		public DataSet ExecuteDataSet(ref OracleCommand com)
		{
			this.AddOutParameterCursor(ref com);
			if (this._trans != null)
			{
				com.Transaction = (OracleTransaction)this._trans;
			}
			OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(com);
			DataSet dataSet = new DataSet();
			oracleDataAdapter.Fill(dataSet);
			return dataSet;
		}

		public void ExecuteNonQuery(ref OracleCommand com)
		{
			if (this._trans != null)
			{
				com.Transaction = (OracleTransaction)this._trans;
			}
			com.ExecuteNonQuery();
		}

		public OracleCommand GetDbComando(string _Proc, clsConexion.TipoComm _Tipo)
		{
			OracleCommand oracleCommand = new OracleCommand()
			{
				Connection = (OracleConnection)this._con
			};
			switch (_Tipo)
			{
				case clsConexion.TipoComm.StoreProcedure:
				{
					oracleCommand.CommandType = CommandType.StoredProcedure;
					break;
				}
				case clsConexion.TipoComm.Function:
				{
					oracleCommand.CommandType = CommandType.Text;
					break;
				}
			}
			oracleCommand.CommandText = _Proc;
			return oracleCommand;
		}

		private void GetDBConnection(bool bnlTrans)
		{
			this._con = DatabaseFactory.CreateDatabase("Conexion").CreateConnection();
			string str = this.NuevaCadena(string.Concat(this._con.ConnectionString, ";Max Pool Size=250;Min Pool Size=0;Pooling='true'"));
			this._con.Close();
			this._con.ConnectionString = str;
			this._con.Open();
			if (!bnlTrans)
			{
				this._con.Close();
			}
		}

		private string NuevaCadena(string cadena)
		{
			int i;
			string str = "";
			string[] strArrays = cadena.Split(new char[] { ';' });
			for (i = 0; i < (int)strArrays.Length; i++)
			{
				if (strArrays[i].IndexOf("User Id") >= 0)
				{
					strArrays[i] = string.Concat("User Id=", clsParametros.ObjParm.Usuario);
				}
				if (strArrays[i].IndexOf("Password") >= 0)
				{
					strArrays[i] = string.Concat("Password=", clsParametros.ObjParm.Password);
				}
				if (strArrays[i].IndexOf("Data Source") >= 0)
				{
					strArrays[i] = string.Concat("Data Source=", clsParametros.ObjParm.NombreConexion);
				}
			}
			for (i = 0; i < (int)strArrays.Length; i++)
			{
				str = string.Concat(str, strArrays[i], ";");
			}
			return str;
		}

		public void RollBackTransaction()
		{
			this._trans.Rollback();
			this._con.Close();
		}

		public enum TipoComm
		{
			StoreProcedure = 1,
			Function = 2
		}
	}
}