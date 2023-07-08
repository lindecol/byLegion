using Newtonsoft.Json;
using SoftManagement.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TransferenciasZF.Data;

namespace TransferenciaZonaFrancaV2
{
    public partial class DocumentoTransferenciaSinFact : System.Web.UI.Page
    {
        private static int iGrupoId;

        private static int iDocumentoID;

        public int bandera;


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void BorrarRegistroLoteSerie(string IdSerial, string Usuario, string ConectarA)
        {
            (new Mensaje()).IdError = "01";
            (new Producto()).BorrarRegistroLoteSerie(IdSerial, Usuario, ConectarA, "I");
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static decimal BuscarFactorVta(int IdEmpresa, string Codigo, string ConectarA)
        {
            Producto producto = new Producto()
            {
                Codigo = Codigo
            };
            return producto.BuscarFactorVta(IdEmpresa, Codigo, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static int CambiarSession()
        {
            return 1;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static float CantidadProductosEnRampa(int IdEmpresa, string Codigo, string EsPropio, string EsLleno, string Capacidad, string Agencia, string ConectarA, int SubDep)
        {
            Producto producto = new Producto()
            {
                Codigo = Codigo
            };
            float CantidaRampa = producto.CantidadProductosEnRampa(SubDep, Agencia, Agencia, DocumentoTransferenciaSinFact.iGrupoId, Codigo, IdEmpresa, EsPropio, EsLleno, ConectarA);
            return CantidaRampa;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Producto> Cilindros_a_transferir(string Usuario, string ConectarA)
        {
            List<Producto> lista = new List<Producto>();
            return (
                from o in (new Producto()).Cilindros_a_transferir(Usuario, "I", ConectarA)
                select new Producto()
                {
                    Codigo = o.Codigo,
                    Descripcion = o.Descripcion,
                    Capacidad = o.Capacidad,
                    Cantidad = o.Cantidad,
                    asignacion = o.asignacion,
                    Observaciones = o.Observaciones
                }).ToList<Producto>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static string ConsultarArticuloPorCodigo(string CodigoProducto, int IdEmpresa, string ConectarA)
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> orders = (new Producto()).ConsultarArticuloPorCodigo(IdEmpresa, CodigoProducto, ConectarA);
            var grid = new
            {
                page = 1,
                records = orders.Count<Producto>(),
                total = orders.Count<Producto>(),
                rows =
                from item in orders
                select new { cell = new string[] { item.Codigo, item.Descripcion } }
            };
            return JsonConvert.SerializeObject(grid);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static string ConsultarArticuloPorNombre(string CodigoProducto, int IdEmpresa, string ConectarA)
        {
            List<Producto> lista = new List<Producto>();
            List<Producto> orders = (new Producto()).ConsultarArticuloPorNombre(IdEmpresa, CodigoProducto, ConectarA);
            var grid = new
            {
                page = 1,
                records = orders.Count<Producto>(),
                total = orders.Count<Producto>(),
                rows =
                from item in orders
                select new { cell = new string[] { item.Codigo, item.Descripcion } }
            };
            return JsonConvert.SerializeObject(grid);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Producto> ConsultarCargueAutomaticoZF(int IdEmpresa, string Ruta, string Usuario, string Agencia, string ConectarA)
        {
            List<Producto> productos = new List<Producto>();
            Producto Itemscargue = new Producto();
            return Itemscargue.ConsultarCargueAutomaticoZF(IdEmpresa, Usuario.Trim(), Agencia, Ruta, ConectarA, "I");
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Producto> ConsultarCargueAutomaticoZFSerialLote(string Usuario, string ConectarA)
        {
            List<Producto> lista = new List<Producto>();
            return (
                from o in (new Producto()).ConsultarCargueAutomaticoZFSerialLote(Usuario, "I", ConectarA)
                select new Producto()
                {
                    SerialPrax = o.SerialPrax,
                    Codigo = o.Codigo,
                    Lote = o.Lote
                }).ToList<Producto>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static string ConsultarConductorPorNombre(string Nombre, int IdEmpresa, string ConectarA)
        {
            List<Ruta> lista = new List<Ruta>();
            List<Ruta> orders = (new Ruta()).ConsultarConductorPorNombre(IdEmpresa, Nombre, ConectarA);
            var grid = new
            {
                page = 1,
                records = orders.Count<Ruta>(),
                total = orders.Count<Ruta>(),
                rows =
                from item in orders
                select new { cell = new string[] { item.CodigoConductor, item.NombreConductor } }
            };
            return JsonConvert.SerializeObject(grid);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Producto> ConsultarLotePorSerial(string Serial, string ConectarA)
        {
            List<Producto> productos = new List<Producto>();
            return (new Producto()).ConsultarLotePorSerial(Serial, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> ConsultarProducto(int IdEmpresa, string Codigo, string ConectarA)
        {
            Producto Producto_ = new Producto()
            {
                Codigo = Codigo,
                EmpresaId = IdEmpresa,
                NombreBD = ConectarA
            };
            List<IEntity> lista = new List<IEntity>();
            return Producto_.Consultar();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Producto> ConsultarSerialLote(string Usuario, string ConectarA)
        {
            List<Producto> lista = new List<Producto>();
            return (
                from o in (new Producto()).ConsultarSerialLote(Usuario, "I", ConectarA)
                select new Producto()
                {
                    SerialPrax = o.SerialPrax,
                    Codigo = o.Codigo,
                    Lote = o.Lote
                }).ToList<Producto>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> ConsultarTubo(int IdEmpresa, string Secuencia, string ConectarA)
        {
            Tubo tubo = new Tubo()
            {
                Secuencia = Secuencia,
                Idempresa = IdEmpresa,
                NombreBD = ConectarA
            };
            List<IEntity> lista = new List<IEntity>();
            return tubo.Consultar();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Ruta> DatosConductor(int IdEmpresa, string CodigoConductor, string ConectarA)
        {
            List<Ruta> rutas = new List<Ruta>();
            return (new Ruta()).DatosCondcutor(IdEmpresa, CodigoConductor, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminaDetalleTemporalInicial(int TempIdEmpresa, string Usuario, string ConectarA)
        {
            (new Talonario()).EliminarDatosTemporalesIniciales(TempIdEmpresa, Usuario.Trim(), ConectarA, "I");
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EliminarProductoGrillaPropia(Producto registro, string Usuario, int IdEmpresa, string ConectarA, string Doc)
        {
            (new Mensaje()).IdError = "01";
            registro.EliminarProductoGrillaPropia(registro.Codigo, registro.Volumen, registro.EsPropio, IdEmpresa, registro.Secuencia, registro.Tubo, Usuario.Trim(), ConectarA, registro.Capacidad, Doc);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool EsProductoLoteable(int IdEmpresa, string CodigoProducto, string ConectarA)
        {
            return (new Producto()).EsProductoLoteable(IdEmpresa, CodigoProducto, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool EsRutaRampa(int IdEmpresa, string CodigoRuta, string Agencia, string ConectarA)
        {
            Ruta ruta = new Ruta();
            return ruta.EsRutaRampa(IdEmpresa, Agencia, CodigoRuta, DocumentoTransferenciaSinFact.iGrupoId, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool EsVehiculoValido(int IdEmpresa, string PlacaVehiculo, string ConectarA)
        {
            return (new Ruta()).EsVehiculoValido(IdEmpresa, PlacaVehiculo, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static string FacturaGenerada(int IdEmpresa, string comprobante, string Agencia, string ConectarA)
        {
            return (new Documento()).FacturaGenerada(IdEmpresa, Agencia, comprobante, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool GasStockeable(int IdEmpresa, string CodigoProducto, string ConectarA)
        {
            return (new Producto()).GasStockeable(IdEmpresa, CodigoProducto, DocumentoTransferenciaSinFact.iGrupoId, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void GrabarAsignacion(string producto, decimal capacidad, string Usuario, string ConectarA, int Asign, string Observacion)
        {
            (new Mensaje()).IdError = "01";
            Producto grabarLote = new Producto();
            grabarLote.GrabarAsignacion(producto, capacidad, Usuario, ConectarA, "I", Asign, Observacion);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje GrabarDetalleTemporal(Producto registro, string Usuario, int IdEmpresa, string ConectarA)
        {
            Mensaje mensaje = new Mensaje()
            {
                IdError = "01"
            };
            if (!registro.GrabarDetalleTemporal(registro, IdEmpresa, Usuario.Trim(), ConectarA))
            {
                mensaje.IdError = "02";
            }
            return mensaje;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje GrabarDetalleTemporalAgenos(Producto registro, string ModoCargue, string Usuario, int IdEmpresa, string ConectarA, string Doc)
        {
            Mensaje mensaje = new Mensaje()
            {
                IdError = "01"
            };
            if (!registro.GrabarDetalleTemporalAgenos(registro, IdEmpresa, Usuario.Trim(), ConectarA, ModoCargue, Doc))
            {
                mensaje.IdError = "02";
            }
            return mensaje;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void GrabarSerialLoteTemp(string IdSerial, string sLote, string Usuario, string ConectarA, string producto)
        {
            (new Mensaje()).IdError = "01";
            (new Producto()).GrabarSerialLoteTemp(IdSerial, sLote, Usuario, ConectarA, "I", producto);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string RecargarPagina = Convert.ToString(this.Session["contador"]);
                int iSubdepositoId = 0;
                if (RecargarPagina == string.Empty)
                {
                    if (this.Session["SESSION_EMPRESA"] == null)
                    {
                        base.Response.Redirect("Default.aspx");
                    }
                    this.Session.Add("contador", 1);
                    Label str = this.lblIdEmpresa;
                    int num = Convert.ToInt32(this.Session["SESSION_EMPRESA"]);
                    str.Text = num.ToString();
                    string strAgencia = Convert.ToString(this.Session["SESSION_AGENCIA"]);
                    this.lblAgencia1.Text = Convert.ToString(this.Session["SESSION_AGENCIA"]);
                    this.lblNombreUsuario.Text = this.Session["SESSION_USUARIO"].ToString();
                    this.hdUsuario.Value = this.Session["SESSION_USUARIO"].ToString();
                    DocumentoTransferenciaSinFact.iGrupoId = 1;
                    DocumentoTransferenciaSinFact.iDocumentoID = 21;
                    if (this.lblIdEmpresa.Text == "21")
                    {
                        this.txtPedidos.Visible = false;
                    }
                    Empresa Emp = new Empresa();
                    string Conectar_a = Emp.ConsultarConexion(this.lblIdEmpresa.Text.Trim());
                    this.Session.Add("CONECTAR_A", Conectar_a);
                    this.lblBd.Text = Conectar_a;
                    this.hdIdEmpresa.Value = this.lblIdEmpresa.Text.Trim();
                    this.hdIdSucursal.Value = this.lblAgencia1.Text.Trim();
                    Empresa empresa = new Empresa();
                    if (empresa.ConsultarMultipleSesion(this.lblIdEmpresa.Text.ToString(), this.lblNombreUsuario.Text.Trim(), Conectar_a, "I"))
                    {
                        base.Response.Redirect("SesionMultiple.aspx");
                        return;
                    }
                    this.cmbEmpresaOrigen.Value = empresa.ConsultarEmpresaPorId(this.lblIdEmpresa.Text.ToString(), Conectar_a);
                    this.cmbEmpresaDestino.LLenarComboLista(empresa.Consultar(), "Nombre", "EmpId");
                    Sucursal sucursal = new Sucursal();
                    this.txtSucursalOrigen.Value = sucursal.ConsultarSucursalPorId(this.lblIdEmpresa.Text.ToString(), strAgencia, Conectar_a);
                    this.hdSubdepositoSucursal.Value = sucursal.ConsultarSubdepositoLogueo(this.lblIdEmpresa.Text.ToString(), strAgencia, Conectar_a);
                    if (this.hdSubdepositoSucursal.Value != string.Empty)
                    {
                        iSubdepositoId = Convert.ToInt32(this.hdSubdepositoSucursal.Value.ToString());
                    }
                    this.lblSubdeposito.Text = iSubdepositoId.ToString();
                    Talonario clsTalonario = new Talonario()
                    {
                        GrupoId = DocumentoTransferenciaSinFact.iGrupoId,
                        EmpresaId = Convert.ToInt32(this.lblIdEmpresa.Text.ToString()),
                        Sucursal = strAgencia,
                        DocumentoId = DocumentoTransferenciaSinFact.iDocumentoID,
                        TipoRetorno = 2,
                        Prefijo = strAgencia,
                        ConexionEmpresa = Conectar_a
                    };
                    List<IEntity> lista = new List<IEntity>();
                    lista = clsTalonario.Consultar();
                    if (lista.Count <= 0)
                    {
                        this.txtTalonario.Value = string.Empty;
                    }
                    else
                    {
                        this.txtTalonario.Value = ((Talonario)lista[0]).Prefijo;
                    }
                    clsTalonario.EliminarDatosTemporales(Convert.ToInt32(this.lblIdEmpresa.Text.ToString()), this.lblNombreUsuario.Text.Trim(), Conectar_a, "I");
                    this.txtFecha.Value = DateTime.Now.ToString("dd/MM/yyyy");
                    return;
                }
                int TempContador = Convert.ToInt32(this.Session["contador"]) + 1;
                if (TempContador == 3)
                {
                    this.Session.Add("contador", "");
                    return;
                }
                this.Session.Add("contador", TempContador);
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje ProcesarTransaferencia(Documento registro, string Usuario, int IdEmpresa, string Agencia, string ConectarA)
        {
            Talonario clsTalonario = new Talonario()
            {
                GrupoId = DocumentoTransferenciaSinFact.iGrupoId,
                EmpresaId = IdEmpresa,
                Sucursal = Agencia,
                DocumentoId = DocumentoTransferenciaSinFact.iDocumentoID,
                TipoRetorno = 2,
                Prefijo = Agencia,
                ConexionEmpresa = ConectarA
            };
            List<IEntity> entities = new List<IEntity>();
            string strNumeroDocumento = clsTalonario.NumeroRemitoSiguiente(clsTalonario, Usuario);
            Mensaje mensaje = new Mensaje();
            string MsjProceso = "";
            if (strNumeroDocumento.Trim() == "0")
            {
                mensaje.IdError = "02";
                MsjProceso = "No se genero el consecutivo de remito, no hay disponibilidad de talonarios, comuniquese con el área de distribución para habilitación";
            }
            else if (strNumeroDocumento == string.Empty)
            {
                mensaje.IdError = "02";
                MsjProceso = "No se genero el consecutivo de remito, no hay disponibilidad de talonarios, comuniquese con el área de distribución para habilitación";
            }
            else
            {
                MsjProceso = registro.InsertarTransferencia(registro, Usuario.Trim(), ConectarA, strNumeroDocumento, "N");
            }
            if (MsjProceso.Trim() != "0")
            {
                mensaje.IdError = "02";
                mensaje.MensajeError = MsjProceso;
            }
            else
            {
                mensaje.IdError = "01";
                mensaje.MensajeError = "";
                mensaje.ValorRetornado = strNumeroDocumento;
            }
            return mensaje;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> RutasPorSucursal(int IdEmpresa, string Codigo, string Agencia, string ConectarA)
        {
            Ruta ruta = new Ruta()
            {
                EmpresaId = IdEmpresa,
                Sucursal = Agencia,
                Codigo = Codigo,
                NombreBD = ConectarA
            };
            List<IEntity> lista = new List<IEntity>();
            return ruta.Consultar();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Ruta> RutaTieneAlmacen(int IdEmpresa, string CodigoRuta, string Agencia, string ConectarA)
        {
            List<Ruta> rutas = new List<Ruta>();
            Ruta ruta = new Ruta();
            return ruta.RutaTieneAlmacen(IdEmpresa, Agencia, CodigoRuta, DocumentoTransferenciaSinFact.iGrupoId, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<IEntity> SucursalesPorEmpresa(int IdEmpresa, string ConectarA)
        {
            List<IEntity> lista = new List<IEntity>();
            if (IdEmpresa == 1)
            {
                return null;
            }
            Sucursal sucursal = new Sucursal()
            {
                SucursalId = IdEmpresa,
                NombreBD = ConectarA
            };
            return sucursal.Consultar();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static string TotalCilindrosSerieLote(string ConectarA)
        {
            return (new Producto()).TotalCilindrosSerieLote(ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static double ValidarCantidadStock(int IdEmpresa, int Subdeposito, string Producto, string Usuario, string ConectarA)
        {
            TransferenciasZF.Data.Producto producto = new TransferenciasZF.Data.Producto();
            double CantidadStock = producto.ValidarCantidadStock(IdEmpresa, Subdeposito, Producto, Usuario.Trim(), ConectarA, "I");
            return CantidadStock;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ValidarCapacidad(int IdEmpresa, int IdArticulo, double Capacidad, string ConectarA)
        {
            return (new Producto()).ValidarCapacidad(IdEmpresa, IdArticulo, Capacidad, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static Mensaje ValidarCargueOBC(int IdEmpresa, string Usuario, string Agencia, string ConectarA, int SubDep)
        {
            Mensaje mensaje = new Mensaje();
            ProductoDao producto = new ProductoDao();
            string strEstadoTubo = producto.ValidarCargueOBC(IdEmpresa, ConectarA, Usuario.Trim(), Agencia, SubDep);
            mensaje.IdError = "01";
            mensaje.MensajeError = strEstadoTubo.Trim();
            if (mensaje.MensajeError == string.Empty)
            {
                mensaje.MensajeError = "0";
            }
            return mensaje;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<Documento> ValidarFacturaPreviaExiste(string Factura, string ConectarA)
        {
            List<Documento> lista = new List<Documento>();
            return (new Documento()).ValidarFacturaPreviaExiste(Factura, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ValidarPedidos(string Pedidos, string Sucursal, string ConectarA)
        {
            return (new Documento()).ValidarPedidos(Pedidos, Sucursal, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ValidarSiHayInventarioAbierto(int IdEmpresa, string Agencia, string ConectarA)
        {
            return (new Documento()).ValidarSiHayInventarioAbierto(IdEmpresa, Agencia, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ValidarSiTieneCod_Facturacion(int IdEmpresa, string Producto, string ConectarA)
        {
            return (new Documento()).ValidarSiTieneCod_Facturacion(IdEmpresa, Producto, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ValidarSiTieneListaPrecios(int IdEmpresa, string Cliente, string Producto, string ConectarA)
        {
            return (new Documento()).ValidarSiTieneListaPrecios(IdEmpresa, Cliente, Producto, ConectarA);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static bool ValidarTotalConFactPrevia(string Usuario, string Factura, string ConectarA)
        {
            Documento DocP = new Documento();
            bool ValidarTotalConFactPrevia = DocP.ValidarTotalConFactPrevia(Usuario.Trim(), Factura.Trim(), ConectarA);
            return ValidarTotalConFactPrevia;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static int VerificarEstadoLLenoVacio(int IdEmpresa, string Cliente, string Tubo, string ConectarA)
        {
            int iEstadoTubo = 0;
            iEstadoTubo = ((new ProductoDao()).VerificarEstadoLLenoVacio(IdEmpresa, Cliente, Tubo, ConectarA) != "L" ? 0 : 1);
            return iEstadoTubo;
        }
    }
}