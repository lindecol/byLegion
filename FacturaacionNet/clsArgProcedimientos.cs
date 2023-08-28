using System;
using System.Data;

namespace FacturacionNET
{
	internal class clsArgProcedimientos
	{
		private DbType _Type;

		private string _nomParam;

		private string _valStrParam;

		private int _valIntParam;

		public string nomParam
		{
			get
			{
				return this._nomParam;
			}
			set
			{
				this._nomParam = value;
			}
		}

		public DbType Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		public string valStrParam
		{
			get
			{
				return this._valStrParam;
			}
			set
			{
				this._valStrParam = value;
			}
		}

		public clsArgProcedimientos(DbType p_Type, string p_nomParam, string p_valPram)
		{
			this.Type = p_Type;
			this.nomParam = p_nomParam;
			this.valStrParam = p_valPram;
		}
	}
}