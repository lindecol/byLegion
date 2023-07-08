using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace InfoContactoClientes
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string NombreCiudad { get; set; }

        public static List<Ciudad> CargarCiudades()
        {
            string strSQl = "select -1 as id, 'Seleccione...' nombreCiudad from dual union SELECT ciuid as id, ciunmb as nombreCiudad FROM CS_CIUDAD ";
            List<Ciudad> lista = new List<Ciudad>();
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Ciudad ciud = new Ciudad()
                    {
                        Id = int.Parse(reader["ID"].ToString()),
                        NombreCiudad = (reader["nombreCiudad"].ToString())
                    };
                    lista.Add(ciud);
                }
                command.Connection.Close();
            }
            return lista;
        }




    }
}
