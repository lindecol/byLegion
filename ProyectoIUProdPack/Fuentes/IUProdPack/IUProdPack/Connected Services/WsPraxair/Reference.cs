﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IUProdPack.WsPraxair {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WsPraxair.ServiceSoap")]
    public interface ServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgenciasUsuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet AgenciasUsuario(int p_Usrid, int p_Grupo, int p_empid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgenciasUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> AgenciasUsuarioAsync(int p_Usrid, int p_Grupo, int p_empid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EmpresasUsuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet EmpresasUsuario(int p_Usrid, int p_Grupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EmpresasUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> EmpresasUsuarioAsync(int p_Usrid, int p_Grupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GruposUsuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GruposUsuario(int p_Usrid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GruposUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GruposUsuarioAsync(int p_Usrid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DivisionesUsuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet DivisionesUsuario(int p_Usrid, int p_Grupo, int p_Empid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DivisionesUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> DivisionesUsuarioAsync(int p_Usrid, int p_Grupo, int p_Empid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModulosUsuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ModulosUsuario(int p_Usrid, int p_Padre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModulosUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ModulosUsuarioAsync(int p_Usrid, int p_Padre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BaseEmpresa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string BaseEmpresa(int p_Grupo, int p_Empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BaseEmpresa", ReplyAction="*")]
        System.Threading.Tasks.Task<string> BaseEmpresaAsync(int p_Grupo, int p_Empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/datosUsuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string datosUsuario(string p_Usrnmb, int p_TipoRetorno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/datosUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<string> datosUsuarioAsync(string p_Usrnmb, int p_TipoRetorno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/usuarioFuncion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string usuarioFuncion(int p_usrid, string p_Funcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/usuarioFuncion", ReplyAction="*")]
        System.Threading.Tasks.Task<string> usuarioFuncionAsync(int p_usrid, string p_Funcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/usuarioValido", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string usuarioValido(string p_Usrnmb, string p_Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/usuarioValido", ReplyAction="*")]
        System.Threading.Tasks.Task<string> usuarioValidoAsync(string p_Usrnmb, string p_Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MaestraCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet MaestraCorreos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MaestraCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> MaestraCorreosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MaestraCorreosGeneral", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet MaestraCorreosGeneral();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MaestraCorreosGeneral", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> MaestraCorreosGeneralAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ParametrosEncCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ParametrosEncCorreos(string p_NombreServicio, int p_IdCorreo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ParametrosEncCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ParametrosEncCorreosAsync(string p_NombreServicio, int p_IdCorreo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ParametrosDetCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ParametrosDetCorreos(string p_NombreServicio, int p_IdCorreo, string p_Parametro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ParametrosDetCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/valorParametrosDetCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string valorParametrosDetCorreos(string p_NombreServicio, int p_IdCorreo, string p_Parametro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/valorParametrosDetCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task<string> valorParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DatosCorreo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet DatosCorreo(string p_NombreServicio, int p_IdCorreo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DatosCorreo", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> DatosCorreoAsync(string p_NombreServicio, int p_IdCorreo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ejecutaProcedimiento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ejecutaProcedimiento(string p_NombreServicio, string p_Procedimiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ejecutaProcedimiento", ReplyAction="*")]
        System.Threading.Tasks.Task ejecutaProcedimientoAsync(string p_NombreServicio, string p_Procedimiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Encriptar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Encriptar(string p_Cadena, int p_Opc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Encriptar", ReplyAction="*")]
        System.Threading.Tasks.Task<string> EncriptarAsync(string p_Cadena, int p_Opc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DesEncriptar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DesEncriptar(string p_Cadena, int p_Opc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DesEncriptar", ReplyAction="*")]
        System.Threading.Tasks.Task<string> DesEncriptarAsync(string p_Cadena, int p_Opc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/descripcionGrupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string descripcionGrupo(int pGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/descripcionGrupo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> descripcionGrupoAsync(int pGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/descripcionEmpresa", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string descripcionEmpresa(int pEmpid, int pGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/descripcionEmpresa", ReplyAction="*")]
        System.Threading.Tasks.Task<string> descripcionEmpresaAsync(int pEmpid, int pGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/descripcionAgencia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string descripcionAgencia(int pEmpid, int pGrupo, string pAgencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/descripcionAgencia", ReplyAction="*")]
        System.Threading.Tasks.Task<string> descripcionAgenciaAsync(int pEmpid, int pGrupo, string pAgencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OlvidoContrasena", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void OlvidoContrasena(string pUsrmb);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OlvidoContrasena", ReplyAction="*")]
        System.Threading.Tasks.Task OlvidoContrasenaAsync(string pUsrmb);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CambioContrasena", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void CambioContrasena(int pUsrid, string pContrasena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CambioContrasena", ReplyAction="*")]
        System.Threading.Tasks.Task CambioContrasenaAsync(int pUsrid, string pContrasena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarMaestraCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void InsertarMaestraCorreos(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarMaestraCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task InsertarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarMaestraCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ModificarMaestraCorreos(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarMaestraCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task ModificarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarMaestraCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void EliminarMaestraCorreos(int p_IdCorreo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarMaestraCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task EliminarMaestraCorreosAsync(int p_IdCorreo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarDetalleCorreos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void EliminarDetalleCorreos(int p_IdCorreo, int pIdParametro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarDetalleCorreos", ReplyAction="*")]
        System.Threading.Tasks.Task EliminarDetalleCorreosAsync(int p_IdCorreo, int pIdParametro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarDetalleCorreo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void InsertarDetalleCorreo(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarDetalleCorreo", ReplyAction="*")]
        System.Threading.Tasks.Task InsertarDetalleCorreoAsync(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/valorCache", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string valorCache(string p_Pais, string p_Comp, string p_Valor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/valorCache", ReplyAction="*")]
        System.Threading.Tasks.Task<string> valorCacheAsync(string p_Pais, string p_Comp, string p_Valor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Pais", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Pais();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Pais", ReplyAction="*")]
        System.Threading.Tasks.Task<string> PaisAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadenaEntrada", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CadenaEntrada(string pCadenaEntrada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadenaEntrada", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CadenaEntradaAsync(string pCadenaEntrada);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceSoapChannel : IUProdPack.WsPraxair.ServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<IUProdPack.WsPraxair.ServiceSoap>, IUProdPack.WsPraxair.ServiceSoap {
        
        public ServiceSoapClient() {
        }
        
        public ServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet AgenciasUsuario(int p_Usrid, int p_Grupo, int p_empid) {
            return base.Channel.AgenciasUsuario(p_Usrid, p_Grupo, p_empid);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AgenciasUsuarioAsync(int p_Usrid, int p_Grupo, int p_empid) {
            return base.Channel.AgenciasUsuarioAsync(p_Usrid, p_Grupo, p_empid);
        }
        
        public System.Data.DataSet EmpresasUsuario(int p_Usrid, int p_Grupo) {
            return base.Channel.EmpresasUsuario(p_Usrid, p_Grupo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> EmpresasUsuarioAsync(int p_Usrid, int p_Grupo) {
            return base.Channel.EmpresasUsuarioAsync(p_Usrid, p_Grupo);
        }
        
        public System.Data.DataSet GruposUsuario(int p_Usrid) {
            return base.Channel.GruposUsuario(p_Usrid);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GruposUsuarioAsync(int p_Usrid) {
            return base.Channel.GruposUsuarioAsync(p_Usrid);
        }
        
        public System.Data.DataSet DivisionesUsuario(int p_Usrid, int p_Grupo, int p_Empid) {
            return base.Channel.DivisionesUsuario(p_Usrid, p_Grupo, p_Empid);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> DivisionesUsuarioAsync(int p_Usrid, int p_Grupo, int p_Empid) {
            return base.Channel.DivisionesUsuarioAsync(p_Usrid, p_Grupo, p_Empid);
        }
        
        public System.Data.DataSet ModulosUsuario(int p_Usrid, int p_Padre) {
            return base.Channel.ModulosUsuario(p_Usrid, p_Padre);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ModulosUsuarioAsync(int p_Usrid, int p_Padre) {
            return base.Channel.ModulosUsuarioAsync(p_Usrid, p_Padre);
        }
        
        public string BaseEmpresa(int p_Grupo, int p_Empresa) {
            return base.Channel.BaseEmpresa(p_Grupo, p_Empresa);
        }
        
        public System.Threading.Tasks.Task<string> BaseEmpresaAsync(int p_Grupo, int p_Empresa) {
            return base.Channel.BaseEmpresaAsync(p_Grupo, p_Empresa);
        }
        
        public string datosUsuario(string p_Usrnmb, int p_TipoRetorno) {
            return base.Channel.datosUsuario(p_Usrnmb, p_TipoRetorno);
        }
        
        public System.Threading.Tasks.Task<string> datosUsuarioAsync(string p_Usrnmb, int p_TipoRetorno) {
            return base.Channel.datosUsuarioAsync(p_Usrnmb, p_TipoRetorno);
        }
        
        public string usuarioFuncion(int p_usrid, string p_Funcion) {
            return base.Channel.usuarioFuncion(p_usrid, p_Funcion);
        }
        
        public System.Threading.Tasks.Task<string> usuarioFuncionAsync(int p_usrid, string p_Funcion) {
            return base.Channel.usuarioFuncionAsync(p_usrid, p_Funcion);
        }
        
        public string usuarioValido(string p_Usrnmb, string p_Password) {
            return base.Channel.usuarioValido(p_Usrnmb, p_Password);
        }
        
        public System.Threading.Tasks.Task<string> usuarioValidoAsync(string p_Usrnmb, string p_Password) {
            return base.Channel.usuarioValidoAsync(p_Usrnmb, p_Password);
        }
        
        public System.Data.DataSet MaestraCorreos() {
            return base.Channel.MaestraCorreos();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> MaestraCorreosAsync() {
            return base.Channel.MaestraCorreosAsync();
        }
        
        public System.Data.DataSet MaestraCorreosGeneral() {
            return base.Channel.MaestraCorreosGeneral();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> MaestraCorreosGeneralAsync() {
            return base.Channel.MaestraCorreosGeneralAsync();
        }
        
        public System.Data.DataSet ParametrosEncCorreos(string p_NombreServicio, int p_IdCorreo) {
            return base.Channel.ParametrosEncCorreos(p_NombreServicio, p_IdCorreo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ParametrosEncCorreosAsync(string p_NombreServicio, int p_IdCorreo) {
            return base.Channel.ParametrosEncCorreosAsync(p_NombreServicio, p_IdCorreo);
        }
        
        public System.Data.DataSet ParametrosDetCorreos(string p_NombreServicio, int p_IdCorreo, string p_Parametro) {
            return base.Channel.ParametrosDetCorreos(p_NombreServicio, p_IdCorreo, p_Parametro);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro) {
            return base.Channel.ParametrosDetCorreosAsync(p_NombreServicio, p_IdCorreo, p_Parametro);
        }
        
        public string valorParametrosDetCorreos(string p_NombreServicio, int p_IdCorreo, string p_Parametro) {
            return base.Channel.valorParametrosDetCorreos(p_NombreServicio, p_IdCorreo, p_Parametro);
        }
        
        public System.Threading.Tasks.Task<string> valorParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro) {
            return base.Channel.valorParametrosDetCorreosAsync(p_NombreServicio, p_IdCorreo, p_Parametro);
        }
        
        public System.Data.DataSet DatosCorreo(string p_NombreServicio, int p_IdCorreo) {
            return base.Channel.DatosCorreo(p_NombreServicio, p_IdCorreo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> DatosCorreoAsync(string p_NombreServicio, int p_IdCorreo) {
            return base.Channel.DatosCorreoAsync(p_NombreServicio, p_IdCorreo);
        }
        
        public void ejecutaProcedimiento(string p_NombreServicio, string p_Procedimiento) {
            base.Channel.ejecutaProcedimiento(p_NombreServicio, p_Procedimiento);
        }
        
        public System.Threading.Tasks.Task ejecutaProcedimientoAsync(string p_NombreServicio, string p_Procedimiento) {
            return base.Channel.ejecutaProcedimientoAsync(p_NombreServicio, p_Procedimiento);
        }
        
        public string Encriptar(string p_Cadena, int p_Opc) {
            return base.Channel.Encriptar(p_Cadena, p_Opc);
        }
        
        public System.Threading.Tasks.Task<string> EncriptarAsync(string p_Cadena, int p_Opc) {
            return base.Channel.EncriptarAsync(p_Cadena, p_Opc);
        }
        
        public string DesEncriptar(string p_Cadena, int p_Opc) {
            return base.Channel.DesEncriptar(p_Cadena, p_Opc);
        }
        
        public System.Threading.Tasks.Task<string> DesEncriptarAsync(string p_Cadena, int p_Opc) {
            return base.Channel.DesEncriptarAsync(p_Cadena, p_Opc);
        }
        
        public string descripcionGrupo(int pGrupo) {
            return base.Channel.descripcionGrupo(pGrupo);
        }
        
        public System.Threading.Tasks.Task<string> descripcionGrupoAsync(int pGrupo) {
            return base.Channel.descripcionGrupoAsync(pGrupo);
        }
        
        public string descripcionEmpresa(int pEmpid, int pGrupo) {
            return base.Channel.descripcionEmpresa(pEmpid, pGrupo);
        }
        
        public System.Threading.Tasks.Task<string> descripcionEmpresaAsync(int pEmpid, int pGrupo) {
            return base.Channel.descripcionEmpresaAsync(pEmpid, pGrupo);
        }
        
        public string descripcionAgencia(int pEmpid, int pGrupo, string pAgencia) {
            return base.Channel.descripcionAgencia(pEmpid, pGrupo, pAgencia);
        }
        
        public System.Threading.Tasks.Task<string> descripcionAgenciaAsync(int pEmpid, int pGrupo, string pAgencia) {
            return base.Channel.descripcionAgenciaAsync(pEmpid, pGrupo, pAgencia);
        }
        
        public void OlvidoContrasena(string pUsrmb) {
            base.Channel.OlvidoContrasena(pUsrmb);
        }
        
        public System.Threading.Tasks.Task OlvidoContrasenaAsync(string pUsrmb) {
            return base.Channel.OlvidoContrasenaAsync(pUsrmb);
        }
        
        public void CambioContrasena(int pUsrid, string pContrasena) {
            base.Channel.CambioContrasena(pUsrid, pContrasena);
        }
        
        public System.Threading.Tasks.Task CambioContrasenaAsync(int pUsrid, string pContrasena) {
            return base.Channel.CambioContrasenaAsync(pUsrid, pContrasena);
        }
        
        public void InsertarMaestraCorreos(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo) {
            base.Channel.InsertarMaestraCorreos(p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo);
        }
        
        public System.Threading.Tasks.Task InsertarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo) {
            return base.Channel.InsertarMaestraCorreosAsync(p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo);
        }
        
        public void ModificarMaestraCorreos(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo) {
            base.Channel.ModificarMaestraCorreos(p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo, pActivo);
        }
        
        public System.Threading.Tasks.Task ModificarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo) {
            return base.Channel.ModificarMaestraCorreosAsync(p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo, pActivo);
        }
        
        public void EliminarMaestraCorreos(int p_IdCorreo) {
            base.Channel.EliminarMaestraCorreos(p_IdCorreo);
        }
        
        public System.Threading.Tasks.Task EliminarMaestraCorreosAsync(int p_IdCorreo) {
            return base.Channel.EliminarMaestraCorreosAsync(p_IdCorreo);
        }
        
        public void EliminarDetalleCorreos(int p_IdCorreo, int pIdParametro) {
            base.Channel.EliminarDetalleCorreos(p_IdCorreo, pIdParametro);
        }
        
        public System.Threading.Tasks.Task EliminarDetalleCorreosAsync(int p_IdCorreo, int pIdParametro) {
            return base.Channel.EliminarDetalleCorreosAsync(p_IdCorreo, pIdParametro);
        }
        
        public void InsertarDetalleCorreo(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo) {
            base.Channel.InsertarDetalleCorreo(pIdCorreo, pGrupo, pEmpid, pIdParametro, pIdDetalle, pNmbDetalle, pValor, pCampo);
        }
        
        public System.Threading.Tasks.Task InsertarDetalleCorreoAsync(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo) {
            return base.Channel.InsertarDetalleCorreoAsync(pIdCorreo, pGrupo, pEmpid, pIdParametro, pIdDetalle, pNmbDetalle, pValor, pCampo);
        }
        
        public string valorCache(string p_Pais, string p_Comp, string p_Valor) {
            return base.Channel.valorCache(p_Pais, p_Comp, p_Valor);
        }
        
        public System.Threading.Tasks.Task<string> valorCacheAsync(string p_Pais, string p_Comp, string p_Valor) {
            return base.Channel.valorCacheAsync(p_Pais, p_Comp, p_Valor);
        }
        
        public string Pais() {
            return base.Channel.Pais();
        }
        
        public System.Threading.Tasks.Task<string> PaisAsync() {
            return base.Channel.PaisAsync();
        }
        
        public string CadenaEntrada(string pCadenaEntrada) {
            return base.Channel.CadenaEntrada(pCadenaEntrada);
        }
        
        public System.Threading.Tasks.Task<string> CadenaEntradaAsync(string pCadenaEntrada) {
            return base.Channel.CadenaEntradaAsync(pCadenaEntrada);
        }
    }
}
