using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IUProdPack
{
    public class clsConstantes
    {
        public clsConstantes()
        {

        }

        public const string usuario = "usuario";

        public const string password = "password";

        public const string idusuario = "idusuario";

        public const string grupo = "grupo";

        public const string empresa = "empresa";

        public const string agencia = "agencia";

        public const string passwordbd = "passwordbd";

        public const string conexion = "conexion";

        public const string ID_ENTRADA = "ID_ENTRADA";

        public const string ID_TRANSACCION = "ID_TRANSACCION";

        public const string ruta = "ruta";

        public const string numguia = "numguia";

        public const string fecha = "fecha";

        public const string tienecierre = "tienecierre";

        public const string CABEZOTE = "CABEZOTE";

        public const string CHOFER = "CHOFER";

        public const string pedido = "pedido";

        public const string producto = "producto";

        public const string codigotabla = "codigotabla";

        public const string datostabla = "datostabla";

        public const string campostabla = "campostabla";

        public const string CODDE01 = "CODDE01";

        public const string DETA101 = "DETA101";

        public const string DETA201 = "DETA201";

        public const string DETA301 = "DETA301";

        public const string DETA401 = "DETA401";

        public const string FEMOVI3002 = "FEMOVI3002";

        public const string HOMOVI3002 = "HOMOVI3002";

        public const string CODUSU3002 = "CODUSU3002";

        public const string CUENTA_TAB = "CUENTA_TAB";

        public const string ANALIT_TAB = "ANALIT_TAB";

        public const string ARCC___TAB = "ARCC___TAB";

        public const string DETA501 = "DETA501";

        public const string DETA601 = "DETA601";

        public const string DETA701 = "DETA701";

        public const string ROWID = "row_id";

        public const string INSERTAR = "i";

        public const string ACTUALIZAR = "u";

        public const string msjcreadocorrectamente = "Registro creado correctamente";

        public const string msjactualizadocrrectam = "Registro actualizado correctamente";

        public const string msjeliminadocorrectame = "Registro eliminado correctamente";

        public const string msjnocreadocorrectamen = "No se pudo crear el registro";

        public const string msjnoactualizadocorrec = "No se pudo actualizar el registro";

        public const string msjnoeliminadocorrecta = "No se pudo eliminar el registro";

        public const string preguneliminarregistro = "Esta seguro de eliminar el registro?";

        public const string msjvalorrequerido_____ = "Valor requerido";

        public const string msjsinpermisosconsulta = "No tiene permisos para consultar datos";

        public const string msjsinpermisosinsercio = "No tiene permisos para registrar datos";

        public const string msjsinpermisoseliminac = "No tiene permisos para eliminar datos";

        public const string msjsinpermisosactualiz = "No tiene permisos para actualizar datos";

        public const string msjvlrnumericoobligato = "Ingrese un valor numérico";

        public const string msjvlrnumericonovalido = "No es un valor numérico";

        public const string msjvlrfechaobligatorio = "Seleccione una fecha";

        public const string msjvlrfechanovalido___ = "Fecha no valida";

        public const string VARCHAR2 = "VARCHAR2";

        public const string NUMBER = "NUMBER";

        public const string DATE = "DATE";

        public const string NULO = "S";

        public const string NONULO = "N";

        public const string MODIFICABLE = "S";

        public const string NOMODIFICABLE = "S";

        public const string NOMBRE_CAMPO_LOGICO = "nombre_campo_logico";

        public const string NOMBRE_CAMPO_FISICO = "nombre_campo_fisico";

        public const string TAMANIO_CAMPO = "tamanio_campo";

        public const string NULOCAMPO = "nulo";

        public const string DECIMALES = "decimales";

        public const string MODIFICABLECAMPO = "modificable";

        public const string TIPODATO = "tipodato";

        public const string MASCARA = "mascara";

        public const string FORMATOFECHADEFAULT = "dd/MM/yyyy";

        public const string MASCARAFECHADEFAULT = "99/99/9999";

        public const string PERMISOCONSULTA = "consulta";

        public const string PERMISOINSERCION = "creacion";

        public const string PERMISOELIMINACION = "eliminacion";

        public const string PERMISOACTUALIZACION = "actualizacion";

        public const string INICIOBOLD = "<B>";

        public const string FINBOLD = "</B>";

        public const string NOESBUSQUEDA = "N";

        public const string ESBUSQUEDA = "S";

        public const string MSJANULACIONCORRECTA = "Anulación de pedido completada con éxito";

        public const string MSJRECHAZOANULACIONOK = "La solicitud de anulación fue rechazada con éxito";

        public const string MSJANULACIONNOCORRECTA = "No fue posible anular el pedidocomuniquese con el administrador del sistema";

        public const string MSJRECHAZONOCORRECTO = "No se pudo rechazar la anulación, comuniquese con el administrador del sistema";

        public const string MSJCAMBIODEESTADOCORRECTO = "El estado del pedido fue cambiado correctamente";

        public const string MSJCAMBIODEESTADOINCORRECTO = "Imposible cambiar el estado del pedido, comuniquese con el administrador del sistema";

        public const string MSJCAMBIODEHORACORRECTO = "La hora fue cambiada correctamente";

        public const string MSJCAMBIODEHORAINCORRECTO = "Imposible cambiar la hora del pedido, comuniquese con el administrador del sistema";

        public const string MSJFECHAERRADA = "La hora ingresada no es valida, recuerde que el valor de hora debe estar entre 00 y 23 y el valor de minutos entre 00 y 59";

        public const string MSJREEMPLAZOCORRECTO = "Reemplazo de pedido realizado correctamente";

        public const string MSJREEMPLAZOINCORRECTO = "Imposible reemplazar el pedido, por favor comuniquese con el administrador del sistema";

        public const string MSJCREAPEDIDOPREVCORRECTO = "El pedido fue creado correctamente para la proxima fecha de entrega";

        public const string MSJCREAPEDIDOPREVINCORRECTO = "Imposible crear el pedido para la proxima fecha";

        public const string MSJNOREGISTROCIERRE = "Imposible realizar el cierre de ruta, por favor consulte con el administrador del sistema";

        public const string MSJOKREGISTROCIERRE = "Cierre de ruta creado correctamente";

        public const string MSJERRORESDETALLECIERRE = "Existieron errores durante el registro de detalles del cierre, por favor consulte con el administrador del sistema";

        public const string MSJOKDETALLECIERRE = "Las justificaciones se crearon correctamente. Cierre de ruta finalizado con éxito";

        public const string MSJJUSTIFICAR = "Justifique el cierre de los pedidos listados a continuación";

        public const string MSJASIGNARUTAOK = "Asignación de pedido a ruta completado con éxito";

        public const string MSJASIGNARUTAERR = "No se pudo completar la asignación del pedido a ruta, verifique si la ruta a la que se quiere asignar el pedido cuenta con las existencias o el espacio respectivo";

        public const string MSJNOCAPAENTREGA = "La ruta no tiene producto disponible";

        public const string MSJNOCAPARECOLEC = "La ruta no tiene capacidad de recolección";

        public const string MSJESCENARIOREGISTRADOOK = "Escenario Registrado Correctamente.";

        public const string MSJESCENARIONOREGISTRADO = "No fue posible almacenar el escenario. consulte con el administrador del sistema";

        public const string MSJESCENARIOACTUALIZADOOK = "Escenario Registrado Correctamente.";

        public const string MSJESCENARIONOACTUALIZADO = "No fue posible almacenar el escenario. consulte con el administrador del sistema";

        public const string MSJASOCIACIONDETESCENARI = "Asociación Realizada Correctamente";

        public const string MSJVALIDACIONORIGENDESTI = "Debe seleccionar un campo origen y un campo destino para asociar";

        public const string MSJERRORASOCIACIONDETESC = "No fue posible almacenar la configuración.  consulte con el administrador del sistema";

        public const string MSJPARAMELIMREGCORRECTAM = "Registro de parametro de eliminación realizado con éxito";

        public const string MSJPARAMELIMREGNOCORRECT = "No fue posible almacenar al parametro de eliminación. consulte con el administrador del sistema";

        public const string OPELIMINACONFIGURACION = "ELIMINACONFIG";

        public const string OPELIMINACIONPARAMELIMIN = "ELIMINAPARAMELIM";

        public const string OPEELIMINACIONESCENARIO = "ELIMINAESCENARIO";

        public const string MSJNOSEPUEDEGUARDARPARAMELIM = "Seleccione un campo, un operador e ingrese un nombre de campo para poder guardar";

        public const string MODOFORMULARIOCREACION = "NUEVO";

        public const string MODOFORMULARIOACTUALIZ = "MODIFICA";

        public const string MSJFECMAYOIGUALAFECACTUAL = "La fecha de inicio debe ser mayor o igual a la fecha actual y la fecha fin deben ser superiores a la fecha actual";

        public const string MSJFECFINSUPFECINICIO = "La fecha fin debe ser superior a la fecha de inicio";

        public const string CODIGOESTADOMOVIL = "CODIGOESTADOMOVIL";

        public const string DESCRIPCIONESTADOMOVIL = "DESCRIPCIONESTADOMOVIL";

        public const string MOVILONLINE = "A";

        public const string MOVILOFFLINE = "I";

        public const string IDCIERRE = "IDCIERRE";

        public static int PedidoAtendidoParcial
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ATENDIDOPARCIAL"]);
            }
        }

        public static int PedidoComunicado
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["COMUNICADO"]);
            }
        }

        public static int PedidoComunicado1
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["COMUNICADO1"]);
            }
        }

        public static int PedidoComunicado2
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["COMUNICADO2"]);
            }
        }

        public static int PedidoNoComunicado
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["NOCOMUNICADO"]);
            }
        }

        public static int PedidoNoComunicado1
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["NOCOMUNICADO1"]);
            }
        }

        public static string ManejoExcepciones(Exception ex)
        {
            string str = "";
            int num = 0;
            int num1 = 0;
            try
            {
                num = ex.Message.IndexOf("ORA-");
                if (num < 2)
                {
                    num = ex.Message.IndexOf(":");
                    if (num < 1)
                    {
                        num = ex.Message.IndexOf("");
                        str = ex.Message.Substring(num).Trim();
                    }
                    else
                    {
                        str = ex.Message.Substring(num).Trim();
                        num1 = str.IndexOf(".");
                        if (num1 < 1)
                        {
                            num = ex.Message.IndexOf(".");
                            str = ex.Message.Substring(0, num).Trim();
                        }
                        else
                        {
                            str = str.Substring(0, num1).Trim();
                        }
                    }
                }
                else
                {
                    str = ex.Message.Substring(num + 10).Trim();
                    num1 = str.IndexOf("ORA-");
                    str = str.Substring(0, num1).Trim();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                str = string.Concat("Excepcion controlando msg.", exception.Message.Substring(0, 30));
            }
            return str;
        }
    }
}