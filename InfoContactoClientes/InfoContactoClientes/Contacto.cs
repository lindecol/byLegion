using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace InfoContactoClientes
{
   public class Contacto
    {
        public int Id { get; set; }
        public string codi_cli { get; set; }
        public string NombreContacto { get; set; }
        public int IdTipoContacto { get; set; }
        public string TipoContacto { get; set; }
        public string Email { get; set; }
        public DateTime FechaCumpleanos { get; set; }
        public string Telefono { get; set; }
        public string Telefono_info_adicional { get; set; }
        public string HabeasData { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }

        public int Ciudad {
            get;set;
        }
        public int Localidad {
            get;
            set; 
        }
        public string Direccion { get; set; }
        public int Parentezco { get; set; }
        public string NombreCiudad { get; set; }
        public string NombreLocalidad { get; set; }
        public string NombreParentezco { get; set; }

        public string FechaModificacion { get; set; }


    }


    public static class ContactoDao
    {
        public static List<Contacto> ConsultarContactos(string codigoCLiente)
        {
            string strSQl = @"select 
                            a.id,
                            codi_cli,
                            id_tipo_contacto,
                            b.descripcion tipo_contacto_desc,
                            email,
                             nvl(fecha_cumpleanos,sysdate) fecha_cumpleanos,
                            telefono,
                            telefono_info_adicional,
                            FECHA_MODIFICACION as fecha_modificacion,
                            nombre_contacto,
                            habeasdata,
                            NVL(id_ciudad, 0) AS id_ciudad ,
                            tipo_identificacion, numero_identificacion,
                            a.Direccion,
                            nvl(a.id_Localidad,0) as id_Localidad,
                            nvl(a.id_Parentezco,0) as id_Parentezco,
                            CIUD.nombreCiudad, LOCAL.nombreLocalidad, PAREN.nombreParentezco
                            from CTB_TIPO_CONTACTO_CLIENTE a
                            inner join CTB_TIPO_CONTACTO b on a.id_tipo_contacto = b.id
                            left join (SELECT ciuid as id, ciunmb as nombreCiudad FROM CS_CIUDAD) CIUD ON (a.id_ciudad = CIUD.id)
                            left join (select codde01 as id, deta101 as nombreLocalidad from M_TABDES where codta01 = 100 order by 1) LOCAL ON (a.id_localidad = LOCAL.id)
                            left join (select codde01 as id, deta101  as nombreParentezco from M_TABDES where codta01 = 115 order by 1) PAREN ON (a.id_Parentezco = PAREN.id)
                            where codi_cli = :p_codi_cli and estado=1";
            List<Contacto> lista = new List<Contacto>();
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);
            db.AddInParameter(command, "p_codi_cli", System.Data.DbType.String, codigoCLiente);


            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Contacto hist = new Contacto
                    {
                        codi_cli = (reader["codi_cli"].ToString()),
                        Email = (reader["email"].ToString()),
                        FechaCumpleanos = DateTime.Parse(reader["fecha_cumpleanos"].ToString()),
                        Id = int.Parse(reader["id"].ToString()),
                        IdTipoContacto = int.Parse(reader["id_tipo_contacto"].ToString()),
                        NombreContacto = (reader["nombre_contacto"].ToString()),
                        Telefono = (reader["telefono"].ToString()),
                        TipoContacto =  (reader["tipo_contacto_desc"].ToString()),
                        Telefono_info_adicional= (reader["Telefono_info_adicional"].ToString()),
                        HabeasData = (reader["habeasdata"].ToString()) ,
                        NumeroIdentificacion= (reader["numero_identificacion"].ToString()),
                        TipoIdentificacion= (reader["tipo_identificacion"].ToString()),
                        Ciudad = int.Parse(reader["id_ciudad"].ToString()),
                        Localidad = int.Parse(reader["id_Localidad"].ToString()),
                        Parentezco = int.Parse(reader["id_Parentezco"].ToString()),
                        Direccion = reader["Direccion"].ToString(),
                        NombreCiudad = reader["nombreCiudad"].ToString(),
                        NombreLocalidad = reader["nombreLocalidad"].ToString(),
                        NombreParentezco = reader["nombreParentezco"].ToString(),
                        FechaModificacion = reader["fecha_modificacion"].ToString()
                };

                    lista.Add(hist);
                }
                command.Connection.Close();
            }
            return lista;

        }

        public static string mensajeError = "";

        public static void InsertarContacto(Contacto cn)
        {
            
            try
            {
                string strsql = @"
                                INSERT INTO CTB_TIPO_CONTACTO_CLIENTE(
                                CODI_CLI,
                                ID_TIPO_CONTACTO,
                                EMAIL,
                                FECHA_CUMPLEANOS,
                                TELEFONO,
                                FECHA_CREACION,
                                FECHA_MODIFICACION,
                                USUARIO_CREACION,
                                USUARIO_MODIFICACION,
                                NOMBRE_CONTACTO,
                                ESTADO,
                                Telefono_info_adicional,
                                habeasdata,
                                tipo_identificacion, 
                                numero_identificacion,
                                id_ciudad,
                                id_localidad,
                                direccion,
                                id_parentezco
                                )
                                VALUES
                                (
                                :CODI_CLI,
                                :ID_TIPO_CONTACTO,
                                :EMAIL,
                                :FECHA_CUMPLEANOS,
                                :TELEFONO,
                                :FECHA_CREACION,
                                :FECHA_MODIFICACION,
                                :USUARIO_CREACION,
                                :USUARIO_MODIFICACION,
                                :NOMBRE_CONTACTO,
                                :ESTADO,
                                :Telefono_info_adicional,
                                :habeasdata,
                                :tipo_identificacion, 
                                :numero_identificacion,
                                :id_ciudad,
                                :id_localidad,
                                :direccion,
                                :id_parentezco
                                )";

                DbCommand command;
                Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
                command = db.GetSqlStringCommand(strsql);
                db.AddInParameter(command, "CODI_CLI", System.Data.DbType.String, cn.codi_cli);
                db.AddInParameter(command, "ID_TIPO_CONTACTO", System.Data.DbType.Int64, cn.IdTipoContacto);
                db.AddInParameter(command, "EMAIL", System.Data.DbType.String, cn.Email);
                db.AddInParameter(command, "FECHA_CUMPLEANOS", System.Data.DbType.Date, cn.FechaCumpleanos);
                db.AddInParameter(command, "TELEFONO", System.Data.DbType.String, cn.Telefono);
                db.AddInParameter(command, "FECHA_CREACION", System.Data.DbType.Date, DateTime.Now);
                db.AddInParameter(command, "FECHA_MODIFICACION", System.Data.DbType.Date, DateTime.Now);
                db.AddInParameter(command, "USUARIO_CREACION", System.Data.DbType.String, ParametrosIniciales.Usuario);
                db.AddInParameter(command, "USUARIO_MODIFICACION", System.Data.DbType.String, ParametrosIniciales.Usuario);
                db.AddInParameter(command, "NOMBRE_CONTACTO", System.Data.DbType.String, cn.NombreContacto);
                db.AddInParameter(command, "ESTADO", System.Data.DbType.Int32, 1);
                db.AddInParameter(command, "Telefono_info_adicional", System.Data.DbType.String, cn.Telefono);
                db.AddInParameter(command, "habeasdata", System.Data.DbType.String, cn.HabeasData);
                db.AddInParameter(command, "tipo_identificacion", System.Data.DbType.String, (cn.TipoIdentificacion));
                db.AddInParameter(command, "numero_identificacion", System.Data.DbType.String, cn.NumeroIdentificacion);
                
                if (cn.Ciudad != 0)
                    db.AddInParameter(command, "id_ciudad", System.Data.DbType.Int32, cn.Ciudad);
                else
                    db.AddInParameter(command, "id_ciudad", System.Data.DbType.Int32, DBNull.Value);

                if (cn.Localidad != 0)
                    db.AddInParameter(command, "id_localidad", System.Data.DbType.Int32, cn.Localidad);
                else
                    db.AddInParameter(command, "id_localidad", System.Data.DbType.Int32, DBNull.Value );

                if (!cn.Direccion.Equals(string.Empty))
                    db.AddInParameter(command, "direccion", System.Data.DbType.String, cn.Direccion);
                else
                    db.AddInParameter(command, "direccion", System.Data.DbType.String, DBNull.Value);

                if (cn.Parentezco != 0)
                    db.AddInParameter(command, "id_parentezco", System.Data.DbType.Int32, cn.Parentezco);
                else
                    db.AddInParameter(command, "id_parentezco", System.Data.DbType.Int32, DBNull.Value);

                db.ExecuteNonQuery(command);
                command.Connection.Close();
                mensajeError = "Registro almacenado con éxito";
            }
            catch (Exception ex) {
                mensajeError = ex.ToString();
            }
        }


        public static List<TIpoIdentificacion> ConsultarTipoIdentificacion()
        {
            var tiposPermitidos = System.Configuration.ConfigurationManager.AppSettings["TipoPermitidos"];
            //string strSQl = "SELECT '-1' as TIPO, 'Seleccione...' as DESCRIPCION  from dual union ";
            string strSQl = @"select CODDE01 TIPO,DETA101 DESCRIPCION from m_tabdes  where CODTA01=92 and codde01 in (" + tiposPermitidos + ") ";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);


            List<TIpoIdentificacion> lista = new List<TIpoIdentificacion>();
            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    TIpoIdentificacion hist = new TIpoIdentificacion
                    {
                         Descripcion= (reader["DESCRIPCION"].ToString()),
                          Tipo = (reader["TIPO"].ToString())
                          
                    };
                    lista.Add(hist);
                }
                command.Connection.Close();
            }
            return lista;



        }

        public static void ActualizarContacto(Contacto cn)
        {

            string strSql = @"                            update CTB_TIPO_CONTACTO_CLIENTE
                            set                            
                            ID_TIPO_CONTACTO=:ID_TIPO_CONTACTO,
                            EMAIL=:EMAIL,
                            FECHA_CUMPLEANOS=:FECHA_CUMPLEANOS,
                            TELEFONO=:TELEFONO,                            
                            FECHA_MODIFICACION=:FECHA_MODIFICACION,
                            USUARIO_MODIFICACION=:USUARIO_MODIFICACION,
                            NOMBRE_CONTACTO=:NOMBRE_CONTACTO,
                            habeasdata=:habeasdata,
                            Telefono_info_adicional=:Telefono_info_adicional,
                            tipo_identificacion=:tipo_identificacion,
                            id_Ciudad = :ID_CIUDAD,
                            id_Localidad = :ID_LOCALIDAD,
                            Direccion = :DIRECCION,
                            id_Parentezco = :ID_PARENTEZCO,
                            numero_identificacion=:numero_identificacion
                            where id=:id";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSql);          
            db.AddInParameter(command, "ID_TIPO_CONTACTO", System.Data.DbType.Int64, cn.IdTipoContacto);
            db.AddInParameter(command, "EMAIL", System.Data.DbType.String, cn.Email);
            db.AddInParameter(command, "FECHA_CUMPLEANOS", System.Data.DbType.Date, cn.FechaCumpleanos);
            db.AddInParameter(command, "TELEFONO", System.Data.DbType.String, cn.Telefono);         ;
            db.AddInParameter(command, "FECHA_MODIFICACION", System.Data.DbType.Date, DateTime.Now);
       
            db.AddInParameter(command, "USUARIO_MODIFICACION", System.Data.DbType.String, ParametrosIniciales.Usuario);
            db.AddInParameter(command, "NOMBRE_CONTACTO", System.Data.DbType.String, cn.NombreContacto);         
            db.AddInParameter(command, "id", System.Data.DbType.Int32, cn.Id);
            db.AddInParameter(command, "Telefono_info_adicional", System.Data.DbType.String, cn.Telefono_info_adicional);
            db.AddInParameter(command, "habeasdata", System.Data.DbType.String, cn.HabeasData);
            db.AddInParameter(command, "numero_identificacion", System.Data.DbType.String, cn.NumeroIdentificacion);
            db.AddInParameter(command, "tipo_identificacion", System.Data.DbType.String, cn.TipoIdentificacion);

            if (cn.Ciudad != 0)
                db.AddInParameter(command, "ID_CIUDAD", System.Data.DbType.Int32, cn.Ciudad);
            else
                db.AddInParameter(command, "ID_CIUDAD", System.Data.DbType.Int32, DBNull.Value);

            if (cn.Localidad != 0)
                db.AddInParameter(command, "ID_LOCALIDAD", System.Data.DbType.Int32, cn.Localidad);
            else
                db.AddInParameter(command, "ID_LOCALIDAD", System.Data.DbType.Int32, DBNull.Value);

            if (!cn.Direccion.Equals(string.Empty))
                db.AddInParameter(command, "DIRECCION", System.Data.DbType.String, cn.Direccion);
            else
                db.AddInParameter(command, "DIRECCION", System.Data.DbType.String, DBNull.Value);

            if (cn.Parentezco != 0)
                db.AddInParameter(command, "ID_PARENTEZCO", System.Data.DbType.Int32, cn.Parentezco);
            else
                db.AddInParameter(command, "ID_PARENTEZCO", System.Data.DbType.Int32, DBNull.Value);




            db.ExecuteNonQuery(command);
            command.Connection.Close();


        }

        public static void InactivarContacto(Contacto cn)
        {

            string strSql = @"     update CTB_TIPO_CONTACTO_CLIENTE
                           set estado=2
                           where id=:id";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSql);

            db.AddInParameter(command, "id", System.Data.DbType.Int32, cn.Id);



            db.ExecuteNonQuery(command);
            command.Connection.Close();

        }
    }

    
}
