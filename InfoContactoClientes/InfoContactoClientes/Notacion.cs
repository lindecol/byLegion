using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace InfoContactoClientes
{
    class Notacion
    {
        public int Id { get; set; }
        public string NombreNotacion { get; set; }

        public static List<Notacion> CargarNotaciones()
        {
            string strSQl = "select '-1' as id, 'Seleccione...' as nombreNotacion from dual union select codde01 as id, deta101  as nombreNotacion from M_TABDES where codta01 = 944 order by 1 ";
            List<Notacion> lista = new List<Notacion>();
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Notacion nota = new Notacion()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        NombreNotacion = (reader["nombreNotacion"].ToString())
                    };
                    lista.Add(nota);
                }
                command.Connection.Close();
            }
            return lista;
        }
    }
}
