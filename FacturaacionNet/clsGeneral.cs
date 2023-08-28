using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace FacturacionNET
{
	internal class clsGeneral
	{
		public clsGeneral()
		{
		}

		public static Control ControlBuscar(string _tag, Panel _Panel)
		{
			Control control = new Control();
			foreach (Control control1 in _Panel.Controls)
			{
				if (control1.Tag != null)
				{
					if (control1.Tag.ToString().Length >= 3)
					{
						if (control1.Tag.ToString().Substring(0, 3).ToUpper() == _tag.ToUpper())
						{
							control = control1;
							break;
						}
					}
				}
				if (control1.HasChildren)
				{
					control = clsGeneral.ControlBuscar(_tag, control1 as Panel);
					if ((control == null ? false : control.Tag != null))
					{
						if (control.Tag.ToString().Substring(0, 3).ToUpper() == _tag.ToUpper())
						{
							break;
						}
					}
				}
			}
			return control;
		}

		public static DataTable EjecutarProcedure(string _Procedimiento, clsArgProcedimientos[] _objArgs)
		{
			OracleCommand dbComando;
			DataTable dataTable;
			clsConexion _clsConexion = new clsConexion();
			try
			{
				try
				{
					dbComando = _clsConexion.GetDbComando(_Procedimiento, clsConexion.TipoComm.StoreProcedure);
					if (_objArgs != null)
					{
						clsArgProcedimientos[] clsArgProcedimientosArray = _objArgs;
						for (int i = 0; i < (int)clsArgProcedimientosArray.Length; i++)
						{
							clsArgProcedimientos clsArgProcedimiento = clsArgProcedimientosArray[i];
							_clsConexion.AddInParameter(ref dbComando, clsArgProcedimiento.nomParam, clsArgProcedimiento.Type, clsArgProcedimiento.valStrParam);
						}
					}
					DataTable item = _clsConexion.ExecuteDataSet(ref dbComando).Tables[0];
					dataTable = item;
				}
				catch (Exception exception)
				{
					throw new Exception(string.Concat("Error al Generar el Reporte ", exception.Message));
				}
			}
			finally
			{
				dbComando = null;
				_clsConexion = null;
			}
			return dataTable;
		}

		public static void GrabarProcedure(string _Procedimiento, clsArgProcedimientos[] _objArgs)
		{
			OracleCommand dbComando;
			clsConexion _clsConexion = new clsConexion(true);
			try
			{
				try
				{
					dbComando = _clsConexion.GetDbComando(_Procedimiento, clsConexion.TipoComm.StoreProcedure);
					if (_objArgs != null)
					{
						clsArgProcedimientos[] clsArgProcedimientosArray = _objArgs;
						for (int i = 0; i < (int)clsArgProcedimientosArray.Length; i++)
						{
							clsArgProcedimientos clsArgProcedimiento = clsArgProcedimientosArray[i];
							_clsConexion.AddInParameter(ref dbComando, clsArgProcedimiento.nomParam, clsArgProcedimiento.Type, clsArgProcedimiento.valStrParam);
						}
					}
					_clsConexion.ExecuteNonQuery(ref dbComando);
					_clsConexion.CommitTransaction();
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					_clsConexion.RollBackTransaction();
					throw new Exception(string.Concat("Error al Generar el Reporte ", exception.Message));
				}
			}
			finally
			{
				dbComando = null;
				_clsConexion = null;
			}
		}

		public static void LlenarGrilla(ref DataGridView ctrGrid, DataTable dt)
		{
			int i;
			int num = 1;
			string str = "";
			bool flag = false;
			ctrGrid.Rows.Clear();
			ctrGrid.Columns.Clear();
			ctrGrid.Refresh();
			int str1 = 0;
			foreach (DataColumn column in dt.Columns)
			{
				DataGridViewColumn dataGridViewColumn = new DataGridViewColumn()
				{
					Name = column.Caption
				};
				str = (column.Caption.Length <= 5 ? column.Caption : column.Caption.Substring(0, 5));
				string str2 = str;
				if (str2 != null)
				{
					if (str2 == "INCHK")
					{
						dataGridViewColumn = new DataGridViewCheckBoxColumn()
						{
							CellTemplate = new DataGridViewCheckBoxCell(),
							Tag = column.Caption,
							ReadOnly = false
						};
						goto Label0;
					}
					else
					{
						if (str2 != "INTXT")
						{
							goto Label2;
						}
						dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
						dataGridViewColumn.Tag = string.Concat(column.Caption.Substring(0, 5), num.ToString());
						dataGridViewColumn.Name = column.Caption.Substring(6);
						dataGridViewColumn.ReadOnly = false;
						num++;
						goto Label0;
					}
				}
			Label2:
				if (flag)
				{
					dataGridViewColumn.Tag = "";
				}
				else
				{
					dataGridViewColumn.Tag = "ID";
					flag = true;
				}
				dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
				dataGridViewColumn.ReadOnly = true;
			Label0:
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
				ctrGrid.Columns.Add(dataGridViewColumn);
			}
			foreach (DataRow row in dt.Rows)
			{
				ctrGrid.Rows.Add();
				ctrGrid.Rows[str1].Cells[0].Value = false;
				if (clsGeneral.NoColumnaGrilla(ctrGrid, "INCHK") == ctrGrid.Columns.Count)
				{
					for (i = 0; i < dt.Columns.Count; i++)
					{
						ctrGrid.Rows[str1].Cells[i].Value = row.ItemArray[i].ToString();
					}
				}
				else if (!(dt.Columns[0].Caption == "INCHK"))
				{
					for (i = 0; i < dt.Columns.Count; i++)
					{
						ctrGrid.Rows[str1].Cells[i + 1].Value = row.ItemArray[i].ToString();
					}
				}
				else
				{
					if (row.ItemArray[0].ToString() == "S")
					{
						ctrGrid.Rows[str1].Cells[0].Value = true;
					}
					for (i = 0; i < dt.Columns.Count - 1; i++)
					{
						ctrGrid.Rows[str1].Cells[i + 1].Value = row.ItemArray[i + 1].ToString();
					}
				}
				str1++;
			}
			dt = null;
		}

		private static int NoColumnaGrilla(Control _ctrControl, string _tipGrilla)
		{
			int num;
			int num1 = 0;
			foreach (DataGridViewColumn column in (_ctrControl as DataGridView).Columns)
			{
				if (!(column.Tag.ToString() == _tipGrilla.ToString()))
				{
					num1++;
				}
				else
				{
					num = num1;
					return num;
				}
			}
			num = num1;
			return num;
		}

		public static string Valor_Control(Control ctrControl)
		{
			string str;
			try
			{
				string upper = ctrControl.Name.Substring(0, 3).ToUpper();
				if (upper != null)
				{
					if (upper == "DTP")
					{
						str = (ctrControl as DateTimePicker).Text.ToString();
						return str;
					}
					else if (upper == "CMB")
					{
						str = (ctrControl as ComboBox).SelectedValue.ToString();
						return str;
					}
					else if (upper == "MSK")
					{
						if (ctrControl.Text.Length != 0)
						{
							str = ctrControl.Text;
							return str;
						}
						else
						{
							str = "-";
							return str;
						}
					}
				}
				str = "";
			}
			catch (Exception exception)
			{
				str = "";
			}
			return str;
		}
	}
}