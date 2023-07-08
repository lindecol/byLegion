using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace InfoContactoClientes
{
    class Parentezco
    {
        public int Id { get; set; }
        public string NombreParentezco { get; set; }

        public static List<Parentezco> CargarParemtezco()
        {
            string strSQl = "select '-1' as id, 'Seleccione...' as nombreParentezco from dual union select codde01 as id, deta101  as nombreParentezco from M_TABDES where codta01 = 115 order by 1 ";
            List<Parentezco> lista = new List<Parentezco>();
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Parentezco pare = new Parentezco()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        NombreParentezco = (reader["nombreParentezco"].ToString())
                    };
                    lista.Add(pare);
                }
                command.Connection.Close();
            }
            return lista;
        }
    }
}
