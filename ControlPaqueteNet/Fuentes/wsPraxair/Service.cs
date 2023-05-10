using ControlPaquete.My;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace ControlPaquete.wsPraxair
{
	/// <remarks />
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	[WebServiceBinding(Name="ServiceSoap", Namespace="http://tempuri.org/")]
	public class Service : SoapHttpClientProtocol
	{
		private static ArrayList __ENCList;

		private SendOrPostCallback AgenciasUsuarioOperationCompleted;

		private SendOrPostCallback EmpresasUsuarioOperationCompleted;

		private SendOrPostCallback GruposUsuarioOperationCompleted;

		private SendOrPostCallback DivisionesUsuarioOperationCompleted;

		private SendOrPostCallback ModulosUsuarioOperationCompleted;

		private SendOrPostCallback BaseEmpresaOperationCompleted;

		private SendOrPostCallback datosUsuarioOperationCompleted;

		private SendOrPostCallback usuarioFuncionOperationCompleted;

		private SendOrPostCallback usuarioValidoOperationCompleted;

		private SendOrPostCallback MaestraCorreosOperationCompleted;

		private SendOrPostCallback MaestraCorreosGeneralOperationCompleted;

		private SendOrPostCallback ParametrosEncCorreosOperationCompleted;

		private SendOrPostCallback ParametrosDetCorreosOperationCompleted;

		private SendOrPostCallback valorParametrosDetCorreosOperationCompleted;

		private SendOrPostCallback DatosCorreoOperationCompleted;

		private SendOrPostCallback ejecutaProcedimientoOperationCompleted;

		private SendOrPostCallback EncriptarOperationCompleted;

		private SendOrPostCallback DesEncriptarOperationCompleted;

		private SendOrPostCallback descripcionGrupoOperationCompleted;

		private SendOrPostCallback descripcionEmpresaOperationCompleted;

		private SendOrPostCallback descripcionAgenciaOperationCompleted;

		private SendOrPostCallback OlvidoContrasenaOperationCompleted;

		private SendOrPostCallback CambioContrasenaOperationCompleted;

		private SendOrPostCallback InsertarMaestraCorreosOperationCompleted;

		private SendOrPostCallback ModificarMaestraCorreosOperationCompleted;

		private SendOrPostCallback EliminarMaestraCorreosOperationCompleted;

		private SendOrPostCallback EliminarDetalleCorreosOperationCompleted;

		private SendOrPostCallback InsertarDetalleCorreoOperationCompleted;

		private SendOrPostCallback valorCacheOperationCompleted;

		private SendOrPostCallback PaisOperationCompleted;

		private SendOrPostCallback CadenaEntradaOperationCompleted;

		private bool useDefaultCredentialsSetExplicitly;

		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				if ((!this.IsLocalFileSystemWebService(base.Url) || this.useDefaultCredentialsSetExplicitly || this.IsLocalFileSystemWebService(value) ? false : true))
				{
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}

		public new bool UseDefaultCredentials
		{
			get
			{
				return base.UseDefaultCredentials;
			}
			set
			{
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		[DebuggerNonUserCode]
		static Service()
		{
			ControlPaquete.wsPraxair.Service.__ENCList = new ArrayList();
		}

		/// <remarks />
		public Service()
		{
			ArrayList _ENCList = ControlPaquete.wsPraxair.Service.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ControlPaquete.wsPraxair.Service.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.Url = MySettings.Default.ControlPaquete_wsPraxair_Service;
			if (!this.IsLocalFileSystemWebService(this.Url))
			{
				this.useDefaultCredentialsSetExplicitly = true;
			}
			else
			{
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			}
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/AgenciasUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet AgenciasUsuario(int p_Usrid, int p_Grupo, int p_empid)
		{
			object[] pUsrid = new object[] { p_Usrid, p_Grupo, p_empid };
			return (DataSet)this.Invoke("AgenciasUsuario", pUsrid)[0];
		}

		public void AgenciasUsuarioAsync(int p_Usrid, int p_Grupo, int p_empid)
		{
			this.AgenciasUsuarioAsync(p_Usrid, p_Grupo, p_empid, null);
		}

		/// <remarks />
		public void AgenciasUsuarioAsync(int p_Usrid, int p_Grupo, int p_empid, object userState)
		{
			if (this.AgenciasUsuarioOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.AgenciasUsuarioOperationCompleted = new SendOrPostCallback(service.OnAgenciasUsuarioOperationCompleted);
			}
			object[] pUsrid = new object[] { p_Usrid, p_Grupo, p_empid };
			this.InvokeAsync("AgenciasUsuario", pUsrid, this.AgenciasUsuarioOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/BaseEmpresa", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string BaseEmpresa(int p_Grupo, int p_Empresa)
		{
			object[] pGrupo = new object[] { p_Grupo, p_Empresa };
			object[] results = this.Invoke("BaseEmpresa", pGrupo);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void BaseEmpresaAsync(int p_Grupo, int p_Empresa)
		{
			this.BaseEmpresaAsync(p_Grupo, p_Empresa, null);
		}

		public void BaseEmpresaAsync(int p_Grupo, int p_Empresa, object userState)
		{
			if (this.BaseEmpresaOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.BaseEmpresaOperationCompleted = new SendOrPostCallback(service.OnBaseEmpresaOperationCompleted);
			}
			object[] pGrupo = new object[] { p_Grupo, p_Empresa };
			this.InvokeAsync("BaseEmpresa", pGrupo, this.BaseEmpresaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CadenaEntrada", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string CadenaEntrada(string pCadenaEntrada)
		{
			object[] objArray = new object[] { pCadenaEntrada };
			object[] results = this.Invoke("CadenaEntrada", objArray);
			return Conversions.ToString(results[0]);
		}

		public void CadenaEntradaAsync(string pCadenaEntrada)
		{
			this.CadenaEntradaAsync(pCadenaEntrada, null);
		}

		/// <remarks />
		public void CadenaEntradaAsync(string pCadenaEntrada, object userState)
		{
			if (this.CadenaEntradaOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.CadenaEntradaOperationCompleted = new SendOrPostCallback(service.OnCadenaEntradaOperationCompleted);
			}
			object[] objArray = new object[] { pCadenaEntrada };
			this.InvokeAsync("CadenaEntrada", objArray, this.CadenaEntradaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CambioContrasena", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void CambioContrasena(int pUsrid, string pContrasena)
		{
			object[] objArray = new object[] { pUsrid, pContrasena };
			this.Invoke("CambioContrasena", objArray);
		}

		public void CambioContrasenaAsync(int pUsrid, string pContrasena)
		{
			this.CambioContrasenaAsync(pUsrid, pContrasena, null);
		}

		/// <remarks />
		public void CambioContrasenaAsync(int pUsrid, string pContrasena, object userState)
		{
			if (this.CambioContrasenaOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.CambioContrasenaOperationCompleted = new SendOrPostCallback(service.OnCambioContrasenaOperationCompleted);
			}
			object[] objArray = new object[] { pUsrid, pContrasena };
			this.InvokeAsync("CambioContrasena", objArray, this.CambioContrasenaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		public new void CancelAsync(object userState)
		{
			base.CancelAsync(RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/DatosCorreo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet DatosCorreo(string p_NombreServicio, int p_IdCorreo)
		{
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo };
			return (DataSet)this.Invoke("DatosCorreo", pNombreServicio)[0];
		}

		public void DatosCorreoAsync(string p_NombreServicio, int p_IdCorreo)
		{
			this.DatosCorreoAsync(p_NombreServicio, p_IdCorreo, null);
		}

		/// <remarks />
		public void DatosCorreoAsync(string p_NombreServicio, int p_IdCorreo, object userState)
		{
			if (this.DatosCorreoOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.DatosCorreoOperationCompleted = new SendOrPostCallback(service.OnDatosCorreoOperationCompleted);
			}
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo };
			this.InvokeAsync("DatosCorreo", pNombreServicio, this.DatosCorreoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/datosUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string datosUsuario(string p_Usrnmb, int p_TipoRetorno)
		{
			object[] pUsrnmb = new object[] { p_Usrnmb, p_TipoRetorno };
			object[] results = this.Invoke("datosUsuario", pUsrnmb);
			return Conversions.ToString(results[0]);
		}

		public void datosUsuarioAsync(string p_Usrnmb, int p_TipoRetorno)
		{
			this.datosUsuarioAsync(p_Usrnmb, p_TipoRetorno, null);
		}

		/// <remarks />
		public void datosUsuarioAsync(string p_Usrnmb, int p_TipoRetorno, object userState)
		{
			if (this.datosUsuarioOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.datosUsuarioOperationCompleted = new SendOrPostCallback(service.OndatosUsuarioOperationCompleted);
			}
			object[] pUsrnmb = new object[] { p_Usrnmb, p_TipoRetorno };
			this.InvokeAsync("datosUsuario", pUsrnmb, this.datosUsuarioOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/descripcionAgencia", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string descripcionAgencia(int pEmpid, int pGrupo, string pAgencia)
		{
			object[] objArray = new object[] { pEmpid, pGrupo, pAgencia };
			object[] results = this.Invoke("descripcionAgencia", objArray);
			return Conversions.ToString(results[0]);
		}

		public void descripcionAgenciaAsync(int pEmpid, int pGrupo, string pAgencia)
		{
			this.descripcionAgenciaAsync(pEmpid, pGrupo, pAgencia, null);
		}

		/// <remarks />
		public void descripcionAgenciaAsync(int pEmpid, int pGrupo, string pAgencia, object userState)
		{
			if (this.descripcionAgenciaOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.descripcionAgenciaOperationCompleted = new SendOrPostCallback(service.OndescripcionAgenciaOperationCompleted);
			}
			object[] objArray = new object[] { pEmpid, pGrupo, pAgencia };
			this.InvokeAsync("descripcionAgencia", objArray, this.descripcionAgenciaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/descripcionEmpresa", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string descripcionEmpresa(int pEmpid, int pGrupo)
		{
			object[] objArray = new object[] { pEmpid, pGrupo };
			object[] results = this.Invoke("descripcionEmpresa", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void descripcionEmpresaAsync(int pEmpid, int pGrupo)
		{
			this.descripcionEmpresaAsync(pEmpid, pGrupo, null);
		}

		public void descripcionEmpresaAsync(int pEmpid, int pGrupo, object userState)
		{
			if (this.descripcionEmpresaOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.descripcionEmpresaOperationCompleted = new SendOrPostCallback(service.OndescripcionEmpresaOperationCompleted);
			}
			object[] objArray = new object[] { pEmpid, pGrupo };
			this.InvokeAsync("descripcionEmpresa", objArray, this.descripcionEmpresaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/descripcionGrupo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string descripcionGrupo(int pGrupo)
		{
			object[] objArray = new object[] { pGrupo };
			object[] results = this.Invoke("descripcionGrupo", objArray);
			return Conversions.ToString(results[0]);
		}

		public void descripcionGrupoAsync(int pGrupo)
		{
			this.descripcionGrupoAsync(pGrupo, null);
		}

		/// <remarks />
		public void descripcionGrupoAsync(int pGrupo, object userState)
		{
			if (this.descripcionGrupoOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.descripcionGrupoOperationCompleted = new SendOrPostCallback(service.OndescripcionGrupoOperationCompleted);
			}
			object[] objArray = new object[] { pGrupo };
			this.InvokeAsync("descripcionGrupo", objArray, this.descripcionGrupoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/DesEncriptar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string DesEncriptar(string p_Cadena, int p_Opc)
		{
			object[] pCadena = new object[] { p_Cadena, p_Opc };
			object[] results = this.Invoke("DesEncriptar", pCadena);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void DesEncriptarAsync(string p_Cadena, int p_Opc)
		{
			this.DesEncriptarAsync(p_Cadena, p_Opc, null);
		}

		public void DesEncriptarAsync(string p_Cadena, int p_Opc, object userState)
		{
			if (this.DesEncriptarOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.DesEncriptarOperationCompleted = new SendOrPostCallback(service.OnDesEncriptarOperationCompleted);
			}
			object[] pCadena = new object[] { p_Cadena, p_Opc };
			this.InvokeAsync("DesEncriptar", pCadena, this.DesEncriptarOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/DivisionesUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet DivisionesUsuario(int p_Usrid, int p_Grupo, int p_Empid)
		{
			object[] pUsrid = new object[] { p_Usrid, p_Grupo, p_Empid };
			return (DataSet)this.Invoke("DivisionesUsuario", pUsrid)[0];
		}

		/// <remarks />
		public void DivisionesUsuarioAsync(int p_Usrid, int p_Grupo, int p_Empid)
		{
			this.DivisionesUsuarioAsync(p_Usrid, p_Grupo, p_Empid, null);
		}

		public void DivisionesUsuarioAsync(int p_Usrid, int p_Grupo, int p_Empid, object userState)
		{
			if (this.DivisionesUsuarioOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.DivisionesUsuarioOperationCompleted = new SendOrPostCallback(service.OnDivisionesUsuarioOperationCompleted);
			}
			object[] pUsrid = new object[] { p_Usrid, p_Grupo, p_Empid };
			this.InvokeAsync("DivisionesUsuario", pUsrid, this.DivisionesUsuarioOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ejecutaProcedimiento", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void ejecutaProcedimiento(string p_NombreServicio, string p_Procedimiento)
		{
			object[] pNombreServicio = new object[] { p_NombreServicio, p_Procedimiento };
			this.Invoke("ejecutaProcedimiento", pNombreServicio);
		}

		/// <remarks />
		public void ejecutaProcedimientoAsync(string p_NombreServicio, string p_Procedimiento)
		{
			this.ejecutaProcedimientoAsync(p_NombreServicio, p_Procedimiento, null);
		}

		public void ejecutaProcedimientoAsync(string p_NombreServicio, string p_Procedimiento, object userState)
		{
			if (this.ejecutaProcedimientoOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.ejecutaProcedimientoOperationCompleted = new SendOrPostCallback(service.OnejecutaProcedimientoOperationCompleted);
			}
			object[] pNombreServicio = new object[] { p_NombreServicio, p_Procedimiento };
			this.InvokeAsync("ejecutaProcedimiento", pNombreServicio, this.ejecutaProcedimientoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/EliminarDetalleCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void EliminarDetalleCorreos(int p_IdCorreo, int pIdParametro)
		{
			object[] pIdCorreo = new object[] { p_IdCorreo, pIdParametro };
			this.Invoke("EliminarDetalleCorreos", pIdCorreo);
		}

		public void EliminarDetalleCorreosAsync(int p_IdCorreo, int pIdParametro)
		{
			this.EliminarDetalleCorreosAsync(p_IdCorreo, pIdParametro, null);
		}

		/// <remarks />
		public void EliminarDetalleCorreosAsync(int p_IdCorreo, int pIdParametro, object userState)
		{
			if (this.EliminarDetalleCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.EliminarDetalleCorreosOperationCompleted = new SendOrPostCallback(service.OnEliminarDetalleCorreosOperationCompleted);
			}
			object[] pIdCorreo = new object[] { p_IdCorreo, pIdParametro };
			this.InvokeAsync("EliminarDetalleCorreos", pIdCorreo, this.EliminarDetalleCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/EliminarMaestraCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void EliminarMaestraCorreos(int p_IdCorreo)
		{
			object[] pIdCorreo = new object[] { p_IdCorreo };
			this.Invoke("EliminarMaestraCorreos", pIdCorreo);
		}

		/// <remarks />
		public void EliminarMaestraCorreosAsync(int p_IdCorreo)
		{
			this.EliminarMaestraCorreosAsync(p_IdCorreo, null);
		}

		public void EliminarMaestraCorreosAsync(int p_IdCorreo, object userState)
		{
			if (this.EliminarMaestraCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.EliminarMaestraCorreosOperationCompleted = new SendOrPostCallback(service.OnEliminarMaestraCorreosOperationCompleted);
			}
			object[] pIdCorreo = new object[] { p_IdCorreo };
			this.InvokeAsync("EliminarMaestraCorreos", pIdCorreo, this.EliminarMaestraCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/EmpresasUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet EmpresasUsuario(int p_Usrid, int p_Grupo)
		{
			object[] pUsrid = new object[] { p_Usrid, p_Grupo };
			return (DataSet)this.Invoke("EmpresasUsuario", pUsrid)[0];
		}

		/// <remarks />
		public void EmpresasUsuarioAsync(int p_Usrid, int p_Grupo)
		{
			this.EmpresasUsuarioAsync(p_Usrid, p_Grupo, null);
		}

		public void EmpresasUsuarioAsync(int p_Usrid, int p_Grupo, object userState)
		{
			if (this.EmpresasUsuarioOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.EmpresasUsuarioOperationCompleted = new SendOrPostCallback(service.OnEmpresasUsuarioOperationCompleted);
			}
			object[] pUsrid = new object[] { p_Usrid, p_Grupo };
			this.InvokeAsync("EmpresasUsuario", pUsrid, this.EmpresasUsuarioOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/Encriptar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string Encriptar(string p_Cadena, int p_Opc)
		{
			object[] pCadena = new object[] { p_Cadena, p_Opc };
			object[] results = this.Invoke("Encriptar", pCadena);
			return Conversions.ToString(results[0]);
		}

		public void EncriptarAsync(string p_Cadena, int p_Opc)
		{
			this.EncriptarAsync(p_Cadena, p_Opc, null);
		}

		/// <remarks />
		public void EncriptarAsync(string p_Cadena, int p_Opc, object userState)
		{
			if (this.EncriptarOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.EncriptarOperationCompleted = new SendOrPostCallback(service.OnEncriptarOperationCompleted);
			}
			object[] pCadena = new object[] { p_Cadena, p_Opc };
			this.InvokeAsync("Encriptar", pCadena, this.EncriptarOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/GruposUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet GruposUsuario(int p_Usrid)
		{
			object[] pUsrid = new object[] { p_Usrid };
			return (DataSet)this.Invoke("GruposUsuario", pUsrid)[0];
		}

		public void GruposUsuarioAsync(int p_Usrid)
		{
			this.GruposUsuarioAsync(p_Usrid, null);
		}

		/// <remarks />
		public void GruposUsuarioAsync(int p_Usrid, object userState)
		{
			if (this.GruposUsuarioOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.GruposUsuarioOperationCompleted = new SendOrPostCallback(service.OnGruposUsuarioOperationCompleted);
			}
			object[] pUsrid = new object[] { p_Usrid };
			this.InvokeAsync("GruposUsuario", pUsrid, this.GruposUsuarioOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/InsertarDetalleCorreo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void InsertarDetalleCorreo(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo)
		{
			object[] objArray = new object[] { pIdCorreo, pGrupo, pEmpid, pIdParametro, pIdDetalle, pNmbDetalle, pValor, pCampo };
			this.Invoke("InsertarDetalleCorreo", objArray);
		}

		/// <remarks />
		public void InsertarDetalleCorreoAsync(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo)
		{
			this.InsertarDetalleCorreoAsync(pIdCorreo, pGrupo, pEmpid, pIdParametro, pIdDetalle, pNmbDetalle, pValor, pCampo, null);
		}

		public void InsertarDetalleCorreoAsync(int pIdCorreo, int pGrupo, int pEmpid, int pIdParametro, int pIdDetalle, string pNmbDetalle, string pValor, string pCampo, object userState)
		{
			if (this.InsertarDetalleCorreoOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.InsertarDetalleCorreoOperationCompleted = new SendOrPostCallback(service.OnInsertarDetalleCorreoOperationCompleted);
			}
			object[] objArray = new object[] { pIdCorreo, pGrupo, pEmpid, pIdParametro, pIdDetalle, pNmbDetalle, pValor, pCampo };
			this.InvokeAsync("InsertarDetalleCorreo", objArray, this.InsertarDetalleCorreoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/InsertarMaestraCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void InsertarMaestraCorreos(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo)
		{
			object[] pIdCorreo = new object[] { p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo };
			this.Invoke("InsertarMaestraCorreos", pIdCorreo);
		}

		/// <remarks />
		public void InsertarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo)
		{
			this.InsertarMaestraCorreosAsync(p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo, null);
		}

		public void InsertarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, object userState)
		{
			if (this.InsertarMaestraCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.InsertarMaestraCorreosOperationCompleted = new SendOrPostCallback(service.OnInsertarMaestraCorreosOperationCompleted);
			}
			object[] pIdCorreo = new object[] { p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo };
			this.InvokeAsync("InsertarMaestraCorreos", pIdCorreo, this.InsertarMaestraCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		private bool IsLocalFileSystemWebService(string url)
		{
			bool IsLocalFileSystemWebService;
			if ((url == null || (object)url == (object)string.Empty ? false : true))
			{
				System.Uri wsUri = new System.Uri(url);
				IsLocalFileSystemWebService = ((wsUri.Port < 1024 || string.Compare(wsUri.Host, "localHost", StringComparison.OrdinalIgnoreCase) != 0 ? true : false) ? false : true);
			}
			else
			{
				IsLocalFileSystemWebService = false;
			}
			return IsLocalFileSystemWebService;
		}

		[SoapDocumentMethod("http://tempuri.org/MaestraCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet MaestraCorreos()
		{
			object[] results = this.Invoke("MaestraCorreos", new object[0]);
			return (DataSet)results[0];
		}

		/// <remarks />
		public void MaestraCorreosAsync()
		{
			this.MaestraCorreosAsync(null);
		}

		public void MaestraCorreosAsync(object userState)
		{
			if (this.MaestraCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.MaestraCorreosOperationCompleted = new SendOrPostCallback(service.OnMaestraCorreosOperationCompleted);
			}
			this.InvokeAsync("MaestraCorreos", new object[0], this.MaestraCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/MaestraCorreosGeneral", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet MaestraCorreosGeneral()
		{
			object[] results = this.Invoke("MaestraCorreosGeneral", new object[0]);
			return (DataSet)results[0];
		}

		public void MaestraCorreosGeneralAsync()
		{
			this.MaestraCorreosGeneralAsync(null);
		}

		/// <remarks />
		public void MaestraCorreosGeneralAsync(object userState)
		{
			if (this.MaestraCorreosGeneralOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.MaestraCorreosGeneralOperationCompleted = new SendOrPostCallback(service.OnMaestraCorreosGeneralOperationCompleted);
			}
			this.InvokeAsync("MaestraCorreosGeneral", new object[0], this.MaestraCorreosGeneralOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ModificarMaestraCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void ModificarMaestraCorreos(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo)
		{
			object[] pIdCorreo = new object[] { p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo, pActivo };
			this.Invoke("ModificarMaestraCorreos", pIdCorreo);
		}

		public void ModificarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo)
		{
			this.ModificarMaestraCorreosAsync(p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo, pActivo, null);
		}

		/// <remarks />
		public void ModificarMaestraCorreosAsync(int p_IdCorreo, string pDescCorreo, string pOrigenDatos, int pGrupo, int pEmpid, decimal pPeriodo, int pActivo, object userState)
		{
			if (this.ModificarMaestraCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.ModificarMaestraCorreosOperationCompleted = new SendOrPostCallback(service.OnModificarMaestraCorreosOperationCompleted);
			}
			object[] pIdCorreo = new object[] { p_IdCorreo, pDescCorreo, pOrigenDatos, pGrupo, pEmpid, pPeriodo, pActivo };
			this.InvokeAsync("ModificarMaestraCorreos", pIdCorreo, this.ModificarMaestraCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ModulosUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ModulosUsuario(int p_Usrid, int p_Padre)
		{
			object[] pUsrid = new object[] { p_Usrid, p_Padre };
			return (DataSet)this.Invoke("ModulosUsuario", pUsrid)[0];
		}

		public void ModulosUsuarioAsync(int p_Usrid, int p_Padre)
		{
			this.ModulosUsuarioAsync(p_Usrid, p_Padre, null);
		}

		/// <remarks />
		public void ModulosUsuarioAsync(int p_Usrid, int p_Padre, object userState)
		{
			if (this.ModulosUsuarioOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.ModulosUsuarioOperationCompleted = new SendOrPostCallback(service.OnModulosUsuarioOperationCompleted);
			}
			object[] pUsrid = new object[] { p_Usrid, p_Padre };
			this.InvokeAsync("ModulosUsuario", pUsrid, this.ModulosUsuarioOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/OlvidoContrasena", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void OlvidoContrasena(string pUsrmb)
		{
			object[] objArray = new object[] { pUsrmb };
			this.Invoke("OlvidoContrasena", objArray);
		}

		/// <remarks />
		public void OlvidoContrasenaAsync(string pUsrmb)
		{
			this.OlvidoContrasenaAsync(pUsrmb, null);
		}

		public void OlvidoContrasenaAsync(string pUsrmb, object userState)
		{
			if (this.OlvidoContrasenaOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.OlvidoContrasenaOperationCompleted = new SendOrPostCallback(service.OnOlvidoContrasenaOperationCompleted);
			}
			object[] objArray = new object[] { pUsrmb };
			this.InvokeAsync("OlvidoContrasena", objArray, this.OlvidoContrasenaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		private void OnAgenciasUsuarioOperationCompleted(object arg)
		{
			if (this.AgenciasUsuarioCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				AgenciasUsuarioCompletedEventHandler agenciasUsuarioCompletedEventHandler = this.AgenciasUsuarioCompleted;
				if (agenciasUsuarioCompletedEventHandler != null)
				{
					agenciasUsuarioCompletedEventHandler(this, new AgenciasUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnBaseEmpresaOperationCompleted(object arg)
		{
			if (this.BaseEmpresaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				BaseEmpresaCompletedEventHandler baseEmpresaCompletedEventHandler = this.BaseEmpresaCompleted;
				if (baseEmpresaCompletedEventHandler != null)
				{
					baseEmpresaCompletedEventHandler(this, new BaseEmpresaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCadenaEntradaOperationCompleted(object arg)
		{
			if (this.CadenaEntradaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CadenaEntradaCompletedEventHandler cadenaEntradaCompletedEventHandler = this.CadenaEntradaCompleted;
				if (cadenaEntradaCompletedEventHandler != null)
				{
					cadenaEntradaCompletedEventHandler(this, new CadenaEntradaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCambioContrasenaOperationCompleted(object arg)
		{
			if (this.CambioContrasenaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CambioContrasenaCompletedEventHandler cambioContrasenaCompletedEventHandler = this.CambioContrasenaCompleted;
				if (cambioContrasenaCompletedEventHandler != null)
				{
					cambioContrasenaCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnDatosCorreoOperationCompleted(object arg)
		{
			if (this.DatosCorreoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				DatosCorreoCompletedEventHandler datosCorreoCompletedEventHandler = this.DatosCorreoCompleted;
				if (datosCorreoCompletedEventHandler != null)
				{
					datosCorreoCompletedEventHandler(this, new DatosCorreoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OndatosUsuarioOperationCompleted(object arg)
		{
			if (this.datosUsuarioCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				datosUsuarioCompletedEventHandler _datosUsuarioCompletedEventHandler = this.datosUsuarioCompleted;
				if (_datosUsuarioCompletedEventHandler != null)
				{
					_datosUsuarioCompletedEventHandler(this, new datosUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OndescripcionAgenciaOperationCompleted(object arg)
		{
			if (this.descripcionAgenciaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				descripcionAgenciaCompletedEventHandler _descripcionAgenciaCompletedEventHandler = this.descripcionAgenciaCompleted;
				if (_descripcionAgenciaCompletedEventHandler != null)
				{
					_descripcionAgenciaCompletedEventHandler(this, new descripcionAgenciaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OndescripcionEmpresaOperationCompleted(object arg)
		{
			if (this.descripcionEmpresaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				descripcionEmpresaCompletedEventHandler _descripcionEmpresaCompletedEventHandler = this.descripcionEmpresaCompleted;
				if (_descripcionEmpresaCompletedEventHandler != null)
				{
					_descripcionEmpresaCompletedEventHandler(this, new descripcionEmpresaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OndescripcionGrupoOperationCompleted(object arg)
		{
			if (this.descripcionGrupoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				descripcionGrupoCompletedEventHandler _descripcionGrupoCompletedEventHandler = this.descripcionGrupoCompleted;
				if (_descripcionGrupoCompletedEventHandler != null)
				{
					_descripcionGrupoCompletedEventHandler(this, new descripcionGrupoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnDesEncriptarOperationCompleted(object arg)
		{
			if (this.DesEncriptarCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				DesEncriptarCompletedEventHandler desEncriptarCompletedEventHandler = this.DesEncriptarCompleted;
				if (desEncriptarCompletedEventHandler != null)
				{
					desEncriptarCompletedEventHandler(this, new DesEncriptarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnDivisionesUsuarioOperationCompleted(object arg)
		{
			if (this.DivisionesUsuarioCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				DivisionesUsuarioCompletedEventHandler divisionesUsuarioCompletedEventHandler = this.DivisionesUsuarioCompleted;
				if (divisionesUsuarioCompletedEventHandler != null)
				{
					divisionesUsuarioCompletedEventHandler(this, new DivisionesUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnejecutaProcedimientoOperationCompleted(object arg)
		{
			if (this.ejecutaProcedimientoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ejecutaProcedimientoCompletedEventHandler _ejecutaProcedimientoCompletedEventHandler = this.ejecutaProcedimientoCompleted;
				if (_ejecutaProcedimientoCompletedEventHandler != null)
				{
					_ejecutaProcedimientoCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnEliminarDetalleCorreosOperationCompleted(object arg)
		{
			if (this.EliminarDetalleCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				EliminarDetalleCorreosCompletedEventHandler eliminarDetalleCorreosCompletedEventHandler = this.EliminarDetalleCorreosCompleted;
				if (eliminarDetalleCorreosCompletedEventHandler != null)
				{
					eliminarDetalleCorreosCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnEliminarMaestraCorreosOperationCompleted(object arg)
		{
			if (this.EliminarMaestraCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				EliminarMaestraCorreosCompletedEventHandler eliminarMaestraCorreosCompletedEventHandler = this.EliminarMaestraCorreosCompleted;
				if (eliminarMaestraCorreosCompletedEventHandler != null)
				{
					eliminarMaestraCorreosCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnEmpresasUsuarioOperationCompleted(object arg)
		{
			if (this.EmpresasUsuarioCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				EmpresasUsuarioCompletedEventHandler empresasUsuarioCompletedEventHandler = this.EmpresasUsuarioCompleted;
				if (empresasUsuarioCompletedEventHandler != null)
				{
					empresasUsuarioCompletedEventHandler(this, new EmpresasUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnEncriptarOperationCompleted(object arg)
		{
			if (this.EncriptarCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				EncriptarCompletedEventHandler encriptarCompletedEventHandler = this.EncriptarCompleted;
				if (encriptarCompletedEventHandler != null)
				{
					encriptarCompletedEventHandler(this, new EncriptarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGruposUsuarioOperationCompleted(object arg)
		{
			if (this.GruposUsuarioCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GruposUsuarioCompletedEventHandler gruposUsuarioCompletedEventHandler = this.GruposUsuarioCompleted;
				if (gruposUsuarioCompletedEventHandler != null)
				{
					gruposUsuarioCompletedEventHandler(this, new GruposUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarDetalleCorreoOperationCompleted(object arg)
		{
			if (this.InsertarDetalleCorreoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarDetalleCorreoCompletedEventHandler insertarDetalleCorreoCompletedEventHandler = this.InsertarDetalleCorreoCompleted;
				if (insertarDetalleCorreoCompletedEventHandler != null)
				{
					insertarDetalleCorreoCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarMaestraCorreosOperationCompleted(object arg)
		{
			if (this.InsertarMaestraCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarMaestraCorreosCompletedEventHandler insertarMaestraCorreosCompletedEventHandler = this.InsertarMaestraCorreosCompleted;
				if (insertarMaestraCorreosCompletedEventHandler != null)
				{
					insertarMaestraCorreosCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnMaestraCorreosGeneralOperationCompleted(object arg)
		{
			if (this.MaestraCorreosGeneralCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				MaestraCorreosGeneralCompletedEventHandler maestraCorreosGeneralCompletedEventHandler = this.MaestraCorreosGeneralCompleted;
				if (maestraCorreosGeneralCompletedEventHandler != null)
				{
					maestraCorreosGeneralCompletedEventHandler(this, new MaestraCorreosGeneralCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnMaestraCorreosOperationCompleted(object arg)
		{
			if (this.MaestraCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				MaestraCorreosCompletedEventHandler maestraCorreosCompletedEventHandler = this.MaestraCorreosCompleted;
				if (maestraCorreosCompletedEventHandler != null)
				{
					maestraCorreosCompletedEventHandler(this, new MaestraCorreosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnModificarMaestraCorreosOperationCompleted(object arg)
		{
			if (this.ModificarMaestraCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ModificarMaestraCorreosCompletedEventHandler modificarMaestraCorreosCompletedEventHandler = this.ModificarMaestraCorreosCompleted;
				if (modificarMaestraCorreosCompletedEventHandler != null)
				{
					modificarMaestraCorreosCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnModulosUsuarioOperationCompleted(object arg)
		{
			if (this.ModulosUsuarioCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ModulosUsuarioCompletedEventHandler modulosUsuarioCompletedEventHandler = this.ModulosUsuarioCompleted;
				if (modulosUsuarioCompletedEventHandler != null)
				{
					modulosUsuarioCompletedEventHandler(this, new ModulosUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnOlvidoContrasenaOperationCompleted(object arg)
		{
			if (this.OlvidoContrasenaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				OlvidoContrasenaCompletedEventHandler olvidoContrasenaCompletedEventHandler = this.OlvidoContrasenaCompleted;
				if (olvidoContrasenaCompletedEventHandler != null)
				{
					olvidoContrasenaCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnPaisOperationCompleted(object arg)
		{
			if (this.PaisCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				PaisCompletedEventHandler paisCompletedEventHandler = this.PaisCompleted;
				if (paisCompletedEventHandler != null)
				{
					paisCompletedEventHandler(this, new PaisCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnParametrosDetCorreosOperationCompleted(object arg)
		{
			if (this.ParametrosDetCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ParametrosDetCorreosCompletedEventHandler parametrosDetCorreosCompletedEventHandler = this.ParametrosDetCorreosCompleted;
				if (parametrosDetCorreosCompletedEventHandler != null)
				{
					parametrosDetCorreosCompletedEventHandler(this, new ParametrosDetCorreosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnParametrosEncCorreosOperationCompleted(object arg)
		{
			if (this.ParametrosEncCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ParametrosEncCorreosCompletedEventHandler parametrosEncCorreosCompletedEventHandler = this.ParametrosEncCorreosCompleted;
				if (parametrosEncCorreosCompletedEventHandler != null)
				{
					parametrosEncCorreosCompletedEventHandler(this, new ParametrosEncCorreosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnusuarioFuncionOperationCompleted(object arg)
		{
			if (this.usuarioFuncionCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				usuarioFuncionCompletedEventHandler _usuarioFuncionCompletedEventHandler = this.usuarioFuncionCompleted;
				if (_usuarioFuncionCompletedEventHandler != null)
				{
					_usuarioFuncionCompletedEventHandler(this, new usuarioFuncionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnusuarioValidoOperationCompleted(object arg)
		{
			if (this.usuarioValidoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				usuarioValidoCompletedEventHandler _usuarioValidoCompletedEventHandler = this.usuarioValidoCompleted;
				if (_usuarioValidoCompletedEventHandler != null)
				{
					_usuarioValidoCompletedEventHandler(this, new usuarioValidoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnvalorCacheOperationCompleted(object arg)
		{
			if (this.valorCacheCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				valorCacheCompletedEventHandler _valorCacheCompletedEventHandler = this.valorCacheCompleted;
				if (_valorCacheCompletedEventHandler != null)
				{
					_valorCacheCompletedEventHandler(this, new valorCacheCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnvalorParametrosDetCorreosOperationCompleted(object arg)
		{
			if (this.valorParametrosDetCorreosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				valorParametrosDetCorreosCompletedEventHandler _valorParametrosDetCorreosCompletedEventHandler = this.valorParametrosDetCorreosCompleted;
				if (_valorParametrosDetCorreosCompletedEventHandler != null)
				{
					_valorParametrosDetCorreosCompletedEventHandler(this, new valorParametrosDetCorreosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		[SoapDocumentMethod("http://tempuri.org/Pais", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string Pais()
		{
			object[] results = this.Invoke("Pais", new object[0]);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void PaisAsync()
		{
			this.PaisAsync(null);
		}

		public void PaisAsync(object userState)
		{
			if (this.PaisOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.PaisOperationCompleted = new SendOrPostCallback(service.OnPaisOperationCompleted);
			}
			this.InvokeAsync("Pais", new object[0], this.PaisOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ParametrosDetCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ParametrosDetCorreos(string p_NombreServicio, int p_IdCorreo, string p_Parametro)
		{
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo, p_Parametro };
			return (DataSet)this.Invoke("ParametrosDetCorreos", pNombreServicio)[0];
		}

		public void ParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro)
		{
			this.ParametrosDetCorreosAsync(p_NombreServicio, p_IdCorreo, p_Parametro, null);
		}

		/// <remarks />
		public void ParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro, object userState)
		{
			if (this.ParametrosDetCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.ParametrosDetCorreosOperationCompleted = new SendOrPostCallback(service.OnParametrosDetCorreosOperationCompleted);
			}
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo, p_Parametro };
			this.InvokeAsync("ParametrosDetCorreos", pNombreServicio, this.ParametrosDetCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ParametrosEncCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ParametrosEncCorreos(string p_NombreServicio, int p_IdCorreo)
		{
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo };
			return (DataSet)this.Invoke("ParametrosEncCorreos", pNombreServicio)[0];
		}

		/// <remarks />
		public void ParametrosEncCorreosAsync(string p_NombreServicio, int p_IdCorreo)
		{
			this.ParametrosEncCorreosAsync(p_NombreServicio, p_IdCorreo, null);
		}

		public void ParametrosEncCorreosAsync(string p_NombreServicio, int p_IdCorreo, object userState)
		{
			if (this.ParametrosEncCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.ParametrosEncCorreosOperationCompleted = new SendOrPostCallback(service.OnParametrosEncCorreosOperationCompleted);
			}
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo };
			this.InvokeAsync("ParametrosEncCorreos", pNombreServicio, this.ParametrosEncCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/usuarioFuncion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string usuarioFuncion(int p_usrid, string p_Funcion)
		{
			object[] pUsrid = new object[] { p_usrid, p_Funcion };
			object[] results = this.Invoke("usuarioFuncion", pUsrid);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void usuarioFuncionAsync(int p_usrid, string p_Funcion)
		{
			this.usuarioFuncionAsync(p_usrid, p_Funcion, null);
		}

		public void usuarioFuncionAsync(int p_usrid, string p_Funcion, object userState)
		{
			if (this.usuarioFuncionOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.usuarioFuncionOperationCompleted = new SendOrPostCallback(service.OnusuarioFuncionOperationCompleted);
			}
			object[] pUsrid = new object[] { p_usrid, p_Funcion };
			this.InvokeAsync("usuarioFuncion", pUsrid, this.usuarioFuncionOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/usuarioValido", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string usuarioValido(string p_Usrnmb, string p_Password)
		{
			object[] pUsrnmb = new object[] { p_Usrnmb, p_Password };
			object[] results = this.Invoke("usuarioValido", pUsrnmb);
			return Conversions.ToString(results[0]);
		}

		public void usuarioValidoAsync(string p_Usrnmb, string p_Password)
		{
			this.usuarioValidoAsync(p_Usrnmb, p_Password, null);
		}

		/// <remarks />
		public void usuarioValidoAsync(string p_Usrnmb, string p_Password, object userState)
		{
			if (this.usuarioValidoOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.usuarioValidoOperationCompleted = new SendOrPostCallback(service.OnusuarioValidoOperationCompleted);
			}
			object[] pUsrnmb = new object[] { p_Usrnmb, p_Password };
			this.InvokeAsync("usuarioValido", pUsrnmb, this.usuarioValidoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/valorCache", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string valorCache(string p_Pais, string p_Comp, string p_Valor)
		{
			object[] pPais = new object[] { p_Pais, p_Comp, p_Valor };
			object[] results = this.Invoke("valorCache", pPais);
			return Conversions.ToString(results[0]);
		}

		public void valorCacheAsync(string p_Pais, string p_Comp, string p_Valor)
		{
			this.valorCacheAsync(p_Pais, p_Comp, p_Valor, null);
		}

		/// <remarks />
		public void valorCacheAsync(string p_Pais, string p_Comp, string p_Valor, object userState)
		{
			if (this.valorCacheOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.valorCacheOperationCompleted = new SendOrPostCallback(service.OnvalorCacheOperationCompleted);
			}
			object[] pPais = new object[] { p_Pais, p_Comp, p_Valor };
			this.InvokeAsync("valorCache", pPais, this.valorCacheOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/valorParametrosDetCorreos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string valorParametrosDetCorreos(string p_NombreServicio, int p_IdCorreo, string p_Parametro)
		{
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo, p_Parametro };
			object[] results = this.Invoke("valorParametrosDetCorreos", pNombreServicio);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void valorParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro)
		{
			this.valorParametrosDetCorreosAsync(p_NombreServicio, p_IdCorreo, p_Parametro, null);
		}

		public void valorParametrosDetCorreosAsync(string p_NombreServicio, int p_IdCorreo, string p_Parametro, object userState)
		{
			if (this.valorParametrosDetCorreosOperationCompleted == null)
			{
				ControlPaquete.wsPraxair.Service service = this;
				this.valorParametrosDetCorreosOperationCompleted = new SendOrPostCallback(service.OnvalorParametrosDetCorreosOperationCompleted);
			}
			object[] pNombreServicio = new object[] { p_NombreServicio, p_IdCorreo, p_Parametro };
			this.InvokeAsync("valorParametrosDetCorreos", pNombreServicio, this.valorParametrosDetCorreosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		public event AgenciasUsuarioCompletedEventHandler AgenciasUsuarioCompleted;

		/// <remarks />
		public event BaseEmpresaCompletedEventHandler BaseEmpresaCompleted;

		public event CadenaEntradaCompletedEventHandler CadenaEntradaCompleted;

		public event CambioContrasenaCompletedEventHandler CambioContrasenaCompleted;

		public event DatosCorreoCompletedEventHandler DatosCorreoCompleted;

		public event datosUsuarioCompletedEventHandler datosUsuarioCompleted;

		public event descripcionAgenciaCompletedEventHandler descripcionAgenciaCompleted;

		/// <remarks />
		public event descripcionEmpresaCompletedEventHandler descripcionEmpresaCompleted;

		public event descripcionGrupoCompletedEventHandler descripcionGrupoCompleted;

		/// <remarks />
		public event DesEncriptarCompletedEventHandler DesEncriptarCompleted;

		/// <remarks />
		public event DivisionesUsuarioCompletedEventHandler DivisionesUsuarioCompleted;

		/// <remarks />
		public event ejecutaProcedimientoCompletedEventHandler ejecutaProcedimientoCompleted;

		public event EliminarDetalleCorreosCompletedEventHandler EliminarDetalleCorreosCompleted;

		/// <remarks />
		public event EliminarMaestraCorreosCompletedEventHandler EliminarMaestraCorreosCompleted;

		/// <remarks />
		public event EmpresasUsuarioCompletedEventHandler EmpresasUsuarioCompleted;

		public event EncriptarCompletedEventHandler EncriptarCompleted;

		public event GruposUsuarioCompletedEventHandler GruposUsuarioCompleted;

		/// <remarks />
		public event InsertarDetalleCorreoCompletedEventHandler InsertarDetalleCorreoCompleted;

		/// <remarks />
		public event InsertarMaestraCorreosCompletedEventHandler InsertarMaestraCorreosCompleted;

		/// <remarks />
		public event MaestraCorreosCompletedEventHandler MaestraCorreosCompleted;

		public event MaestraCorreosGeneralCompletedEventHandler MaestraCorreosGeneralCompleted;

		public event ModificarMaestraCorreosCompletedEventHandler ModificarMaestraCorreosCompleted;

		public event ModulosUsuarioCompletedEventHandler ModulosUsuarioCompleted;

		/// <remarks />
		public event OlvidoContrasenaCompletedEventHandler OlvidoContrasenaCompleted;

		/// <remarks />
		public event PaisCompletedEventHandler PaisCompleted;

		public event ParametrosDetCorreosCompletedEventHandler ParametrosDetCorreosCompleted;

		/// <remarks />
		public event ParametrosEncCorreosCompletedEventHandler ParametrosEncCorreosCompleted;

		/// <remarks />
		public event usuarioFuncionCompletedEventHandler usuarioFuncionCompleted;

		public event usuarioValidoCompletedEventHandler usuarioValidoCompleted;

		public event valorCacheCompletedEventHandler valorCacheCompleted;

		/// <remarks />
		public event valorParametrosDetCorreosCompletedEventHandler valorParametrosDetCorreosCompleted;
	}
}