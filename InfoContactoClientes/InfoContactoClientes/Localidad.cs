using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace InfoContactoClientes
{
    class Localidad
    {
        public int Id { get; set; }
        public string NombreLocalidad { get; set; }

        public static List<Localidad> CargarLocalidades() {
            List<Localidad> salida = new List<Localidad>();

            string strSQl = "select '-1' as id, 'Seleccione... ' as nombreLocalidad from dual union select codde01 as id, deta101 as nombreLocalidad from M_TABDES where codta01 = 100 order by 1 ";
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Localidad loca = new Localidad()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        NombreLocalidad = (reader["nombreLocalidad"].ToString())
                    };
                    salida.Add(loca);
                }
                command.Connection.Close();
            }
            return salida;
        }
    }
}
