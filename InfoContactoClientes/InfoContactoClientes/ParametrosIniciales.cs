using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace InfoContactoClientes
{
    public static class ParametrosIniciales
    {
        public static string CodigoCliente { get; set; }
        public static string Modulo { get; set; }
        public static string TIpoCliente { get; set; }
        public static string Usuario { get; set; }
        public static List<TipoContacto> TiposContactos { get; set; }


        public static void CargarTipoContactos()
        {
            var exclusion = System.Configuration.ConfigurationManager.AppSettings["ExlusionTD"];
            string strSQl = "SELECT -1 as ID, 'Seleccione...' as DESCRIPCION, NULL AS TIPO_CLIENTE  from dual union ";
            strSQl += "select ID, DESCRIPCION, TIPO_CLIENTE from CTB_TIPO_CONTACTO WHERE TIPO_CLIENTE =:P_TIPO_CLIENTE AND ID NOT IN (" + exclusion + ") ";
            List<TipoContacto> lista = new List<TipoContacto>();
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);
            db.AddInParameter(command, "P_TIPO_CLIENTE", System.Data.DbType.String, TIpoCliente);


            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    TipoContacto hist = new TipoContacto
                    {
                        Descripcion = (reader["Descripcion"].ToString()),
                        IdTipoContacto = int.Parse(reader["ID"].ToString()),
                        TipoCliente = (reader["TIPO_CLIENTE"].ToString()),

                    };
                    lista.Add(hist);
                }
                command.Connection.Close();
            }
            TiposContactos = lista;

        }


        public static bool ValidarCorreo(string mail)
        {

            if (!string.IsNullOrEmpty(mail))
            {
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!reg.IsMatch(mail))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }


        //public static void setTipoCliente()
        //{
        //    string retorno = "";
        //    string strSQL = @"select count(*) valor
        //                            from m_df01
        //                    where 1 = 1
        //                            AND coseguro_cli = 'S'
        //                            AND principal_cli = 'N'
        //                            AND CLIENT_CLI =:P_CLIENT_CLI ";

        //    DbCommand command;
        //    Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
        //    command = db.GetSqlStringCommand(strSQL);
        //    db.AddInParameter(command, "P_CLIENT_CLI", System.Data.DbType.String, CodigoCliente);


        //    using (IDataReader reader = db.ExecuteReader(command))
        //    {
        //        while (reader.Read())
        //        {

        //            retorno = int.Parse(reader["valor"].ToString()) == 1? "M":"I" ;

        //        }
        //        command.Connection.Close();
        //    }
        //    TIpoCliente = retorno;

        //}

        public static void setTipoCliente()
        {
            int retornoI = 0;
            int retornoM = 0;

            retornoI = EsTipoClienteIndistrial();

            if (retornoI == 1)
                TIpoCliente = "I";
            else
            {
                retornoM = EsTipoClienteMedicial();
                if (retornoM == 1)
                    TIpoCliente = "M";
                else
                    TIpoCliente = "";
            }
        }

        public static int EsTipoClienteIndistrial()
        {
            int retorno = 0;
            string strSQL = @"select count(*) valor
                                    from m_df01
                            where 1 = 1
                                    AND coseguro_cli = 'N'
                                    AND principal_cli = 'N'
                                    AND CLIENT_CLI =:P_CLIENT_CLI ";

            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQL);
            db.AddInParameter(command, "P_CLIENT_CLI", System.Data.DbType.String, CodigoCliente);


            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {

                    retorno = int.Parse(reader["valor"].ToString());

                }
                command.Connection.Close();
            }
            return retorno;
        }

        public static int EsTipoClienteMedicial()
        {
            int retorno = 0;
            string strSQL = @"select count(*) valor
                                    from m_df01
                            where 1 = 1
                                    AND coseguro_cli = 'S'
                                    AND principal_cli = 'N'
                                    AND CLIENT_CLI =:P_CLIENT_CLI ";

            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQL);
            db.AddInParameter(command, "P_CLIENT_CLI", System.Data.DbType.String, CodigoCliente);


            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {

                    retorno = int.Parse(reader["valor"].ToString());

                }
                command.Connection.Close();
            }
            return retorno;
        }

    }
}
