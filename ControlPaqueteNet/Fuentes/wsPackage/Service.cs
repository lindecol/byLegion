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

namespace ControlPaquete.wsPackage
{
	/// <remarks />
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	[WebServiceBinding(Name="ServiceSoap", Namespace="http://tempuri.org/")]
	public class Service : SoapHttpClientProtocol
	{
		private static ArrayList __ENCList;

		private SendOrPostCallback HelloWorldOperationCompleted;

		private SendOrPostCallback AnularConteoOperationCompleted;

		private SendOrPostCallback AbrirConteoOperationCompleted;

		private SendOrPostCallback BloquearConteoOperationCompleted;

		private SendOrPostCallback BloquearRegistroConteoOperationCompleted;

		private SendOrPostCallback CerrarConteoOperationCompleted;

		private SendOrPostCallback CrearCierreOperationCompleted;

		private SendOrPostCallback ConsultarFestivosOperationCompleted;

		private SendOrPostCallback GenerarFestivosOperationCompleted;

		private SendOrPostCallback CargarMotivosDiferenciasOperationCompleted;

		private SendOrPostCallback ConsultarDiferenciasOperationCompleted;

		private SendOrPostCallback InsertarDiferenciaActivosOperationCompleted;

		private SendOrPostCallback InsertarDiferenciaProductosOperationCompleted;

		private SendOrPostCallback InsertarDiferenciaMixtoOperationCompleted;

		private SendOrPostCallback ConsultarConteoOperationCompleted;

		private SendOrPostCallback CrearEtiquetaOperationCompleted;

		private SendOrPostCallback InsertarEtiquetaOperationCompleted;

		private SendOrPostCallback ActualizarEtiquetaOperationCompleted;

		private SendOrPostCallback CargarMotivoAnulacionOperationCompleted;

		private SendOrPostCallback CrearMotivoAnulacionOperationCompleted;

		private SendOrPostCallback InsertarMotivoAnulacionOperationCompleted;

		private SendOrPostCallback ActualizarMotivoAnulacionOperationCompleted;

		private SendOrPostCallback CrearMotivoDiferenciaOperationCompleted;

		private SendOrPostCallback InsertarMotivoDiferenciaOperationCompleted;

		private SendOrPostCallback ActualizarMotivoDiferenciaOperationCompleted;

		private SendOrPostCallback CrearProgramacionOperationCompleted;

		private SendOrPostCallback ObtenerUsuariosOperationCompleted;

		private SendOrPostCallback ProgramarConteoOperationCompleted;

		private SendOrPostCallback ObtenerSectorSubdepositoOperationCompleted;

		private SendOrPostCallback ObtenerConteosOperationCompleted;

		private SendOrPostCallback UltimoConteoOperationCompleted;

		private SendOrPostCallback GuardarActivosPocketOperationCompleted;

		private SendOrPostCallback CargarActivoCapacidadOperationCompleted;

		private SendOrPostCallback CrearActivosOperationCompleted;

		private SendOrPostCallback CrearActivosGrillaOperationCompleted;

		private SendOrPostCallback NombreActivoOperationCompleted;

		private SendOrPostCallback GuardarActivosOperationCompleted;

		private SendOrPostCallback GuardarProductosPocketOperationCompleted;

		private SendOrPostCallback GuardarProductosOperationCompleted;

		private SendOrPostCallback CrearProductosComboOperationCompleted;

		private SendOrPostCallback CrearProductosGrillaOperationCompleted;

		private SendOrPostCallback CapacidadesProductoOperationCompleted;

		private SendOrPostCallback NombreProductoOperationCompleted;

		private SendOrPostCallback GuardarMixtoOperationCompleted;

		private SendOrPostCallback IndicadorCuentaCorrienteOperationCompleted;

		private SendOrPostCallback ReprogramarConteoOperationCompleted;

		private SendOrPostCallback ObtenerDatosConteoOperationCompleted;

		private SendOrPostCallback ObtenerSubdepositosConteoOperationCompleted;

		private SendOrPostCallback CargarSectoresOperationCompleted;

		private SendOrPostCallback SectoresOperationCompleted;

		private SendOrPostCallback CrearSectoresOperationCompleted;

		private SendOrPostCallback CrearSectoresSubdepositosOperationCompleted;

		private SendOrPostCallback InsertarSectoresOperationCompleted;

		private SendOrPostCallback ActualizarSectoresOperationCompleted;

		private SendOrPostCallback ConsultarSubdepositosOperationCompleted;

		private SendOrPostCallback ConsultarSubdepositosConfiguradosOperationCompleted;

		private SendOrPostCallback CrearSubdepositoSectorOperationCompleted;

		private SendOrPostCallback EliminarSubdepositoSectorOperationCompleted;

		private SendOrPostCallback InsertarSubdepositoSectorOperationCompleted;

		private SendOrPostCallback ConsultarSucursalesOperationCompleted;

		private SendOrPostCallback CrearSectorSucursalOperationCompleted;

		private SendOrPostCallback CrearSucursalOperationCompleted;

		private SendOrPostCallback EliminarSucursalOperationCompleted;

		private SendOrPostCallback InsertarSucursalOperationCompleted;

		private SendOrPostCallback RutasNoRendidasOperationCompleted;

		private SendOrPostCallback PapeleriaNoDigitadaOperationCompleted;

		private SendOrPostCallback CerrarPapeleriaOperationCompleted;

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
			ControlPaquete.wsPackage.Service.__ENCList = new ArrayList();
		}

		/// <remarks />
		public Service()
		{
			ArrayList _ENCList = ControlPaquete.wsPackage.Service.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				ControlPaquete.wsPackage.Service.__ENCList.Add(new WeakReference(this));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
			this.Url = MySettings.Default.ControlPaquete_wsPackage_Package;
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
		[SoapDocumentMethod("http://tempuri.org/AbrirConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string AbrirConteo(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal)
		{
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			object[] results = this.Invoke("AbrirConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		public void AbrirConteoAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal)
		{
			this.AbrirConteoAsync(strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, null);
		}

		/// <remarks />
		public void AbrirConteoAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, object userState)
		{
			if (this.AbrirConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.AbrirConteoOperationCompleted = new SendOrPostCallback(service.OnAbrirConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			this.InvokeAsync("AbrirConteo", objArray, this.AbrirConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ActualizarEtiqueta", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ActualizarEtiqueta(string strConnection, int Longitud, string TipoEtiqueta, string Descripcion, string Estado, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Longitud, TipoEtiqueta, Descripcion, Estado, Usuario };
			object[] results = this.Invoke("ActualizarEtiqueta", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void ActualizarEtiquetaAsync(string strConnection, int Longitud, string TipoEtiqueta, string Descripcion, string Estado, string Usuario)
		{
			this.ActualizarEtiquetaAsync(strConnection, Longitud, TipoEtiqueta, Descripcion, Estado, Usuario, null);
		}

		public void ActualizarEtiquetaAsync(string strConnection, int Longitud, string TipoEtiqueta, string Descripcion, string Estado, string Usuario, object userState)
		{
			if (this.ActualizarEtiquetaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ActualizarEtiquetaOperationCompleted = new SendOrPostCallback(service.OnActualizarEtiquetaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Longitud, TipoEtiqueta, Descripcion, Estado, Usuario };
			this.InvokeAsync("ActualizarEtiqueta", objArray, this.ActualizarEtiquetaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ActualizarMotivoAnulacion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ActualizarMotivoAnulacion(string strConnection, int CodigoAnulacion, string Descripcion, string Estado, string Usuario)
		{
			object[] objArray = new object[] { strConnection, CodigoAnulacion, Descripcion, Estado, Usuario };
			object[] results = this.Invoke("ActualizarMotivoAnulacion", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void ActualizarMotivoAnulacionAsync(string strConnection, int CodigoAnulacion, string Descripcion, string Estado, string Usuario)
		{
			this.ActualizarMotivoAnulacionAsync(strConnection, CodigoAnulacion, Descripcion, Estado, Usuario, null);
		}

		public void ActualizarMotivoAnulacionAsync(string strConnection, int CodigoAnulacion, string Descripcion, string Estado, string Usuario, object userState)
		{
			if (this.ActualizarMotivoAnulacionOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ActualizarMotivoAnulacionOperationCompleted = new SendOrPostCallback(service.OnActualizarMotivoAnulacionOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoAnulacion, Descripcion, Estado, Usuario };
			this.InvokeAsync("ActualizarMotivoAnulacion", objArray, this.ActualizarMotivoAnulacionOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ActualizarMotivoDiferencia", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ActualizarMotivoDiferencia(string strConnection, int CodigoDiferencia, string Descripcion, string Estado, string Usuario)
		{
			object[] objArray = new object[] { strConnection, CodigoDiferencia, Descripcion, Estado, Usuario };
			object[] results = this.Invoke("ActualizarMotivoDiferencia", objArray);
			return Conversions.ToString(results[0]);
		}

		public void ActualizarMotivoDiferenciaAsync(string strConnection, int CodigoDiferencia, string Descripcion, string Estado, string Usuario)
		{
			this.ActualizarMotivoDiferenciaAsync(strConnection, CodigoDiferencia, Descripcion, Estado, Usuario, null);
		}

		/// <remarks />
		public void ActualizarMotivoDiferenciaAsync(string strConnection, int CodigoDiferencia, string Descripcion, string Estado, string Usuario, object userState)
		{
			if (this.ActualizarMotivoDiferenciaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ActualizarMotivoDiferenciaOperationCompleted = new SendOrPostCallback(service.OnActualizarMotivoDiferenciaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoDiferencia, Descripcion, Estado, Usuario };
			this.InvokeAsync("ActualizarMotivoDiferencia", objArray, this.ActualizarMotivoDiferenciaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ActualizarSectores", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ActualizarSectores(string strConnection, string CodigoSector, string Estado, string Descripcion, string Usuario)
		{
			object[] objArray = new object[] { strConnection, CodigoSector, Estado, Descripcion, Usuario };
			object[] results = this.Invoke("ActualizarSectores", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void ActualizarSectoresAsync(string strConnection, string CodigoSector, string Estado, string Descripcion, string Usuario)
		{
			this.ActualizarSectoresAsync(strConnection, CodigoSector, Estado, Descripcion, Usuario, null);
		}

		public void ActualizarSectoresAsync(string strConnection, string CodigoSector, string Estado, string Descripcion, string Usuario, object userState)
		{
			if (this.ActualizarSectoresOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ActualizarSectoresOperationCompleted = new SendOrPostCallback(service.OnActualizarSectoresOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoSector, Estado, Descripcion, Usuario };
			this.InvokeAsync("ActualizarSectores", objArray, this.ActualizarSectoresOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/AnularConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string AnularConteo(string strConnection, int Conteo, int MotivoAnulacion, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Conteo, MotivoAnulacion, Usuario };
			object[] results = this.Invoke("AnularConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void AnularConteoAsync(string strConnection, int Conteo, int MotivoAnulacion, string Usuario)
		{
			this.AnularConteoAsync(strConnection, Conteo, MotivoAnulacion, Usuario, null);
		}

		public void AnularConteoAsync(string strConnection, int Conteo, int MotivoAnulacion, string Usuario, object userState)
		{
			if (this.AnularConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.AnularConteoOperationCompleted = new SendOrPostCallback(service.OnAnularConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, MotivoAnulacion, Usuario };
			this.InvokeAsync("AnularConteo", objArray, this.AnularConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/BloquearConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string BloquearConteo(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal)
		{
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			object[] results = this.Invoke("BloquearConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void BloquearConteoAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal)
		{
			this.BloquearConteoAsync(strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, null);
		}

		public void BloquearConteoAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, object userState)
		{
			if (this.BloquearConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.BloquearConteoOperationCompleted = new SendOrPostCallback(service.OnBloquearConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			this.InvokeAsync("BloquearConteo", objArray, this.BloquearConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/BloquearRegistroConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string BloquearRegistroConteo(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, string Tarea)
		{
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, Tarea };
			object[] results = this.Invoke("BloquearRegistroConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		public void BloquearRegistroConteoAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, string Tarea)
		{
			this.BloquearRegistroConteoAsync(strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, Tarea, null);
		}

		/// <remarks />
		public void BloquearRegistroConteoAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, string Tarea, object userState)
		{
			if (this.BloquearRegistroConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.BloquearRegistroConteoOperationCompleted = new SendOrPostCallback(service.OnBloquearRegistroConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, Tarea };
			this.InvokeAsync("BloquearRegistroConteo", objArray, this.BloquearRegistroConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		public new void CancelAsync(object userState)
		{
			base.CancelAsync(RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CapacidadesProducto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CapacidadesProducto(string strConnection, int Conteo, int CodigoProducto)
		{
			object[] objArray = new object[] { strConnection, Conteo, CodigoProducto };
			return (DataSet)this.Invoke("CapacidadesProducto", objArray)[0];
		}

		/// <remarks />
		public void CapacidadesProductoAsync(string strConnection, int Conteo, int CodigoProducto)
		{
			this.CapacidadesProductoAsync(strConnection, Conteo, CodigoProducto, null);
		}

		public void CapacidadesProductoAsync(string strConnection, int Conteo, int CodigoProducto, object userState)
		{
			if (this.CapacidadesProductoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CapacidadesProductoOperationCompleted = new SendOrPostCallback(service.OnCapacidadesProductoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, CodigoProducto };
			this.InvokeAsync("CapacidadesProducto", objArray, this.CapacidadesProductoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CargarActivoCapacidad", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CargarActivoCapacidad(string strConnection, int CodigoActivo)
		{
			object[] objArray = new object[] { strConnection, CodigoActivo };
			return (DataSet)this.Invoke("CargarActivoCapacidad", objArray)[0];
		}

		public void CargarActivoCapacidadAsync(string strConnection, int CodigoActivo)
		{
			this.CargarActivoCapacidadAsync(strConnection, CodigoActivo, null);
		}

		/// <remarks />
		public void CargarActivoCapacidadAsync(string strConnection, int CodigoActivo, object userState)
		{
			if (this.CargarActivoCapacidadOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CargarActivoCapacidadOperationCompleted = new SendOrPostCallback(service.OnCargarActivoCapacidadOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoActivo };
			this.InvokeAsync("CargarActivoCapacidad", objArray, this.CargarActivoCapacidadOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CargarMotivoAnulacion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CargarMotivoAnulacion(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("CargarMotivoAnulacion", objArray)[0];
		}

		public void CargarMotivoAnulacionAsync(string strConnection)
		{
			this.CargarMotivoAnulacionAsync(strConnection, null);
		}

		/// <remarks />
		public void CargarMotivoAnulacionAsync(string strConnection, object userState)
		{
			if (this.CargarMotivoAnulacionOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CargarMotivoAnulacionOperationCompleted = new SendOrPostCallback(service.OnCargarMotivoAnulacionOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("CargarMotivoAnulacion", objArray, this.CargarMotivoAnulacionOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CargarMotivosDiferencias", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CargarMotivosDiferencias(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("CargarMotivosDiferencias", objArray)[0];
		}

		/// <remarks />
		public void CargarMotivosDiferenciasAsync(string strConnection)
		{
			this.CargarMotivosDiferenciasAsync(strConnection, null);
		}

		public void CargarMotivosDiferenciasAsync(string strConnection, object userState)
		{
			if (this.CargarMotivosDiferenciasOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CargarMotivosDiferenciasOperationCompleted = new SendOrPostCallback(service.OnCargarMotivosDiferenciasOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("CargarMotivosDiferencias", objArray, this.CargarMotivosDiferenciasOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CargarSectores", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CargarSectores(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("CargarSectores", objArray)[0];
		}

		public void CargarSectoresAsync(string strConnection)
		{
			this.CargarSectoresAsync(strConnection, null);
		}

		/// <remarks />
		public void CargarSectoresAsync(string strConnection, object userState)
		{
			if (this.CargarSectoresOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CargarSectoresOperationCompleted = new SendOrPostCallback(service.OnCargarSectoresOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("CargarSectores", objArray, this.CargarSectoresOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CerrarConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string CerrarConteo(string strConnection, int Conteo, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Conteo, Usuario };
			object[] results = this.Invoke("CerrarConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void CerrarConteoAsync(string strConnection, int Conteo, string Usuario)
		{
			this.CerrarConteoAsync(strConnection, Conteo, Usuario, null);
		}

		public void CerrarConteoAsync(string strConnection, int Conteo, string Usuario, object userState)
		{
			if (this.CerrarConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CerrarConteoOperationCompleted = new SendOrPostCallback(service.OnCerrarConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Usuario };
			this.InvokeAsync("CerrarConteo", objArray, this.CerrarConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CerrarPapeleria", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public void CerrarPapeleria(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, DataTable dtRutas, DataTable dtPapeleria)
		{
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, dtRutas, dtPapeleria };
			this.Invoke("CerrarPapeleria", objArray);
		}

		public void CerrarPapeleriaAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, DataTable dtRutas, DataTable dtPapeleria)
		{
			this.CerrarPapeleriaAsync(strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, dtRutas, dtPapeleria, null);
		}

		/// <remarks />
		public void CerrarPapeleriaAsync(string strConnection, int Conteo, string Usuario, int CodigoGrupo, int CodigoEmpresa, string CodigoSucursal, DataTable dtRutas, DataTable dtPapeleria, object userState)
		{
			if (this.CerrarPapeleriaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CerrarPapeleriaOperationCompleted = new SendOrPostCallback(service.OnCerrarPapeleriaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Usuario, CodigoGrupo, CodigoEmpresa, CodigoSucursal, dtRutas, dtPapeleria };
			this.InvokeAsync("CerrarPapeleria", objArray, this.CerrarPapeleriaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ConsultarConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ConsultarConteo(string strConnection, int CodigoConteo, string Serial, string Tarea, string Usuario)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, Serial, Tarea, Usuario };
			object[] results = this.Invoke("ConsultarConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		public void ConsultarConteoAsync(string strConnection, int CodigoConteo, string Serial, string Tarea, string Usuario)
		{
			this.ConsultarConteoAsync(strConnection, CodigoConteo, Serial, Tarea, Usuario, null);
		}

		/// <remarks />
		public void ConsultarConteoAsync(string strConnection, int CodigoConteo, string Serial, string Tarea, string Usuario, object userState)
		{
			if (this.ConsultarConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ConsultarConteoOperationCompleted = new SendOrPostCallback(service.OnConsultarConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, Serial, Tarea, Usuario };
			this.InvokeAsync("ConsultarConteo", objArray, this.ConsultarConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ConsultarDiferencias", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ConsultarDiferencias(string strConnection, int Conteo, string Usuario, string Tipo, string Propiedad)
		{
			object[] objArray = new object[] { strConnection, Conteo, Usuario, Tipo, Propiedad };
			return (DataSet)this.Invoke("ConsultarDiferencias", objArray)[0];
		}

		public void ConsultarDiferenciasAsync(string strConnection, int Conteo, string Usuario, string Tipo, string Propiedad)
		{
			this.ConsultarDiferenciasAsync(strConnection, Conteo, Usuario, Tipo, Propiedad, null);
		}

		/// <remarks />
		public void ConsultarDiferenciasAsync(string strConnection, int Conteo, string Usuario, string Tipo, string Propiedad, object userState)
		{
			if (this.ConsultarDiferenciasOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ConsultarDiferenciasOperationCompleted = new SendOrPostCallback(service.OnConsultarDiferenciasOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Usuario, Tipo, Propiedad };
			this.InvokeAsync("ConsultarDiferencias", objArray, this.ConsultarDiferenciasOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ConsultarFestivos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ConsultarFestivos(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("ConsultarFestivos", objArray)[0];
		}

		/// <remarks />
		public void ConsultarFestivosAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			this.ConsultarFestivosAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, null);
		}

		public void ConsultarFestivosAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.ConsultarFestivosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ConsultarFestivosOperationCompleted = new SendOrPostCallback(service.OnConsultarFestivosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("ConsultarFestivos", objArray, this.ConsultarFestivosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ConsultarSubdepositos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ConsultarSubdepositos(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal)
		{
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			return (DataSet)this.Invoke("ConsultarSubdepositos", objArray)[0];
		}

		public void ConsultarSubdepositosAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal)
		{
			this.ConsultarSubdepositosAsync(strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal, null);
		}

		/// <remarks />
		public void ConsultarSubdepositosAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal, object userState)
		{
			if (this.ConsultarSubdepositosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ConsultarSubdepositosOperationCompleted = new SendOrPostCallback(service.OnConsultarSubdepositosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			this.InvokeAsync("ConsultarSubdepositos", objArray, this.ConsultarSubdepositosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ConsultarSubdepositosConfigurados", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ConsultarSubdepositosConfigurados(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal)
		{
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			return (DataSet)this.Invoke("ConsultarSubdepositosConfigurados", objArray)[0];
		}

		/// <remarks />
		public void ConsultarSubdepositosConfiguradosAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal)
		{
			this.ConsultarSubdepositosConfiguradosAsync(strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal, null);
		}

		public void ConsultarSubdepositosConfiguradosAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal, object userState)
		{
			if (this.ConsultarSubdepositosConfiguradosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ConsultarSubdepositosConfiguradosOperationCompleted = new SendOrPostCallback(service.OnConsultarSubdepositosConfiguradosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal };
			this.InvokeAsync("ConsultarSubdepositosConfigurados", objArray, this.ConsultarSubdepositosConfiguradosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ConsultarSucursales", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ConsultarSucursales(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("ConsultarSucursales", objArray)[0];
		}

		/// <remarks />
		public void ConsultarSucursalesAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			this.ConsultarSucursalesAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, null);
		}

		public void ConsultarSucursalesAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.ConsultarSucursalesOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ConsultarSucursalesOperationCompleted = new SendOrPostCallback(service.OnConsultarSucursalesOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("ConsultarSucursales", objArray, this.ConsultarSucursalesOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearActivos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearActivos(string strConnection, int Conteo, string TipoActivo)
		{
			object[] objArray = new object[] { strConnection, Conteo, TipoActivo };
			return (DataSet)this.Invoke("CrearActivos", objArray)[0];
		}

		/// <remarks />
		public void CrearActivosAsync(string strConnection, int Conteo, string TipoActivo)
		{
			this.CrearActivosAsync(strConnection, Conteo, TipoActivo, null);
		}

		public void CrearActivosAsync(string strConnection, int Conteo, string TipoActivo, object userState)
		{
			if (this.CrearActivosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearActivosOperationCompleted = new SendOrPostCallback(service.OnCrearActivosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, TipoActivo };
			this.InvokeAsync("CrearActivos", objArray, this.CrearActivosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearActivosGrilla", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearActivosGrilla(string strConnection, int CodigoConteo, string TipoActivo)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, TipoActivo };
			return (DataSet)this.Invoke("CrearActivosGrilla", objArray)[0];
		}

		public void CrearActivosGrillaAsync(string strConnection, int CodigoConteo, string TipoActivo)
		{
			this.CrearActivosGrillaAsync(strConnection, CodigoConteo, TipoActivo, null);
		}

		/// <remarks />
		public void CrearActivosGrillaAsync(string strConnection, int CodigoConteo, string TipoActivo, object userState)
		{
			if (this.CrearActivosGrillaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearActivosGrillaOperationCompleted = new SendOrPostCallback(service.OnCrearActivosGrillaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, TipoActivo };
			this.InvokeAsync("CrearActivosGrilla", objArray, this.CrearActivosGrillaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearCierre", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearCierre(string strConnection, int CodigoGrupo, int CodigoEmpresa, int Encargado, string Estado, string Tarea, string Sucursal)
		{
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, Encargado, Estado, Tarea, Sucursal };
			return (DataSet)this.Invoke("CrearCierre", objArray)[0];
		}

		public void CrearCierreAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int Encargado, string Estado, string Tarea, string Sucursal)
		{
			this.CrearCierreAsync(strConnection, CodigoGrupo, CodigoEmpresa, Encargado, Estado, Tarea, Sucursal, null);
		}

		/// <remarks />
		public void CrearCierreAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int Encargado, string Estado, string Tarea, string Sucursal, object userState)
		{
			if (this.CrearCierreOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearCierreOperationCompleted = new SendOrPostCallback(service.OnCrearCierreOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, Encargado, Estado, Tarea, Sucursal };
			this.InvokeAsync("CrearCierre", objArray, this.CrearCierreOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearEtiqueta", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearEtiqueta(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("CrearEtiqueta", objArray)[0];
		}

		/// <remarks />
		public void CrearEtiquetaAsync(string strConnection)
		{
			this.CrearEtiquetaAsync(strConnection, null);
		}

		public void CrearEtiquetaAsync(string strConnection, object userState)
		{
			if (this.CrearEtiquetaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearEtiquetaOperationCompleted = new SendOrPostCallback(service.OnCrearEtiquetaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("CrearEtiqueta", objArray, this.CrearEtiquetaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearMotivoAnulacion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearMotivoAnulacion(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("CrearMotivoAnulacion", objArray)[0];
		}

		/// <remarks />
		public void CrearMotivoAnulacionAsync(string strConnection)
		{
			this.CrearMotivoAnulacionAsync(strConnection, null);
		}

		public void CrearMotivoAnulacionAsync(string strConnection, object userState)
		{
			if (this.CrearMotivoAnulacionOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearMotivoAnulacionOperationCompleted = new SendOrPostCallback(service.OnCrearMotivoAnulacionOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("CrearMotivoAnulacion", objArray, this.CrearMotivoAnulacionOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearMotivoDiferencia", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearMotivoDiferencia(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("CrearMotivoDiferencia", objArray)[0];
		}

		public void CrearMotivoDiferenciaAsync(string strConnection)
		{
			this.CrearMotivoDiferenciaAsync(strConnection, null);
		}

		/// <remarks />
		public void CrearMotivoDiferenciaAsync(string strConnection, object userState)
		{
			if (this.CrearMotivoDiferenciaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearMotivoDiferenciaOperationCompleted = new SendOrPostCallback(service.OnCrearMotivoDiferenciaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("CrearMotivoDiferencia", objArray, this.CrearMotivoDiferenciaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearProductosCombo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearProductosCombo(string strConnection, int Conteo)
		{
			object[] objArray = new object[] { strConnection, Conteo };
			return (DataSet)this.Invoke("CrearProductosCombo", objArray)[0];
		}

		/// <remarks />
		public void CrearProductosComboAsync(string strConnection, int Conteo)
		{
			this.CrearProductosComboAsync(strConnection, Conteo, null);
		}

		public void CrearProductosComboAsync(string strConnection, int Conteo, object userState)
		{
			if (this.CrearProductosComboOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearProductosComboOperationCompleted = new SendOrPostCallback(service.OnCrearProductosComboOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo };
			this.InvokeAsync("CrearProductosCombo", objArray, this.CrearProductosComboOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearProductosGrilla", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearProductosGrilla(string strConnection, int Conteo, string Propiedad)
		{
			object[] objArray = new object[] { strConnection, Conteo, Propiedad };
			return (DataSet)this.Invoke("CrearProductosGrilla", objArray)[0];
		}

		public void CrearProductosGrillaAsync(string strConnection, int Conteo, string Propiedad)
		{
			this.CrearProductosGrillaAsync(strConnection, Conteo, Propiedad, null);
		}

		/// <remarks />
		public void CrearProductosGrillaAsync(string strConnection, int Conteo, string Propiedad, object userState)
		{
			if (this.CrearProductosGrillaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearProductosGrillaOperationCompleted = new SendOrPostCallback(service.OnCrearProductosGrillaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, Propiedad };
			this.InvokeAsync("CrearProductosGrilla", objArray, this.CrearProductosGrillaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearProgramacion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearProgramacion(string strConnection, string EstadoConteo, int CodigoGrupo, int CodigoEmpresa, int Encargado, string Sucursal)
		{
			object[] objArray = new object[] { strConnection, EstadoConteo, CodigoGrupo, CodigoEmpresa, Encargado, Sucursal };
			return (DataSet)this.Invoke("CrearProgramacion", objArray)[0];
		}

		/// <remarks />
		public void CrearProgramacionAsync(string strConnection, string EstadoConteo, int CodigoGrupo, int CodigoEmpresa, int Encargado, string Sucursal)
		{
			this.CrearProgramacionAsync(strConnection, EstadoConteo, CodigoGrupo, CodigoEmpresa, Encargado, Sucursal, null);
		}

		public void CrearProgramacionAsync(string strConnection, string EstadoConteo, int CodigoGrupo, int CodigoEmpresa, int Encargado, string Sucursal, object userState)
		{
			if (this.CrearProgramacionOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearProgramacionOperationCompleted = new SendOrPostCallback(service.OnCrearProgramacionOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, EstadoConteo, CodigoGrupo, CodigoEmpresa, Encargado, Sucursal };
			this.InvokeAsync("CrearProgramacion", objArray, this.CrearProgramacionOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearSectores", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearSectores(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("CrearSectores", objArray)[0];
		}

		public void CrearSectoresAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			this.CrearSectoresAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, null);
		}

		/// <remarks />
		public void CrearSectoresAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.CrearSectoresOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearSectoresOperationCompleted = new SendOrPostCallback(service.OnCrearSectoresOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("CrearSectores", objArray, this.CrearSectoresOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearSectoresSubdepositos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearSectoresSubdepositos(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("CrearSectoresSubdepositos", objArray)[0];
		}

		/// <remarks />
		public void CrearSectoresSubdepositosAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			this.CrearSectoresSubdepositosAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, null);
		}

		public void CrearSectoresSubdepositosAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.CrearSectoresSubdepositosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearSectoresSubdepositosOperationCompleted = new SendOrPostCallback(service.OnCrearSectoresSubdepositosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("CrearSectoresSubdepositos", objArray, this.CrearSectoresSubdepositosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearSectorSucursal", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearSectorSucursal(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("CrearSectorSucursal", objArray)[0];
		}

		public void CrearSectorSucursalAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			this.CrearSectorSucursalAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, null);
		}

		/// <remarks />
		public void CrearSectorSucursalAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.CrearSectorSucursalOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearSectorSucursalOperationCompleted = new SendOrPostCallback(service.OnCrearSectorSucursalOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("CrearSectorSucursal", objArray, this.CrearSectorSucursalOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/CrearSubdepositoSector", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearSubdepositoSector(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, string Sector)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, Sector };
			return (DataSet)this.Invoke("CrearSubdepositoSector", objArray)[0];
		}

		public void CrearSubdepositoSectorAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, string Sector)
		{
			this.CrearSubdepositoSectorAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, Sector, null);
		}

		/// <remarks />
		public void CrearSubdepositoSectorAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, string Sector, object userState)
		{
			if (this.CrearSubdepositoSectorOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearSubdepositoSectorOperationCompleted = new SendOrPostCallback(service.OnCrearSubdepositoSectorOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, Sector };
			this.InvokeAsync("CrearSubdepositoSector", objArray, this.CrearSubdepositoSectorOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/CrearSucursal", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet CrearSucursal(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("CrearSucursal", objArray)[0];
		}

		/// <remarks />
		public void CrearSucursalAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa)
		{
			this.CrearSucursalAsync(strConnection, Sucursal, CodigoGrupo, CodigoEmpresa, null);
		}

		public void CrearSucursalAsync(string strConnection, int Sucursal, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.CrearSucursalOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.CrearSucursalOperationCompleted = new SendOrPostCallback(service.OnCrearSucursalOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("CrearSucursal", objArray, this.CrearSucursalOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/EliminarSubdepositoSector", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string EliminarSubdepositoSector(string strConnection, int Sucursal, string Sector, int Secuencia, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, Sector, Secuencia, CodigoGrupo, CodigoEmpresa };
			object[] results = this.Invoke("EliminarSubdepositoSector", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void EliminarSubdepositoSectorAsync(string strConnection, int Sucursal, string Sector, int Secuencia, int CodigoGrupo, int CodigoEmpresa)
		{
			this.EliminarSubdepositoSectorAsync(strConnection, Sucursal, Sector, Secuencia, CodigoGrupo, CodigoEmpresa, null);
		}

		public void EliminarSubdepositoSectorAsync(string strConnection, int Sucursal, string Sector, int Secuencia, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.EliminarSubdepositoSectorOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.EliminarSubdepositoSectorOperationCompleted = new SendOrPostCallback(service.OnEliminarSubdepositoSectorOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, Sector, Secuencia, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("EliminarSubdepositoSector", objArray, this.EliminarSubdepositoSectorOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/EliminarSucursal", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string EliminarSucursal(string strConnection, int Sucursal, string Sector, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, Sucursal, Sector, CodigoGrupo, CodigoEmpresa };
			object[] results = this.Invoke("EliminarSucursal", objArray);
			return Conversions.ToString(results[0]);
		}

		public void EliminarSucursalAsync(string strConnection, int Sucursal, string Sector, int CodigoGrupo, int CodigoEmpresa)
		{
			this.EliminarSucursalAsync(strConnection, Sucursal, Sector, CodigoGrupo, CodigoEmpresa, null);
		}

		/// <remarks />
		public void EliminarSucursalAsync(string strConnection, int Sucursal, string Sector, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.EliminarSucursalOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.EliminarSucursalOperationCompleted = new SendOrPostCallback(service.OnEliminarSucursalOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, Sector, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("EliminarSucursal", objArray, this.EliminarSucursalOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/GenerarFestivos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GenerarFestivos(string strConnection, bool esFestivoSabado, bool chkSabado, bool esFestivoDomingo, bool chkDomingo, int Sucursal, string Usuario, DateTime[] Fechas, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, esFestivoSabado, chkSabado, esFestivoDomingo, chkDomingo, Sucursal, Usuario, Fechas, CodigoGrupo, CodigoEmpresa };
			object[] results = this.Invoke("GenerarFestivos", objArray);
			return Conversions.ToString(results[0]);
		}

		public void GenerarFestivosAsync(string strConnection, bool esFestivoSabado, bool chkSabado, bool esFestivoDomingo, bool chkDomingo, int Sucursal, string Usuario, DateTime[] Fechas, int CodigoGrupo, int CodigoEmpresa)
		{
			this.GenerarFestivosAsync(strConnection, esFestivoSabado, chkSabado, esFestivoDomingo, chkDomingo, Sucursal, Usuario, Fechas, CodigoGrupo, CodigoEmpresa, null);
		}

		/// <remarks />
		public void GenerarFestivosAsync(string strConnection, bool esFestivoSabado, bool chkSabado, bool esFestivoDomingo, bool chkDomingo, int Sucursal, string Usuario, DateTime[] Fechas, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.GenerarFestivosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.GenerarFestivosOperationCompleted = new SendOrPostCallback(service.OnGenerarFestivosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, esFestivoSabado, chkSabado, esFestivoDomingo, chkDomingo, Sucursal, Usuario, Fechas, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("GenerarFestivos", objArray, this.GenerarFestivosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/GuardarActivos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GuardarActivos(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtAjenos, DataSet dtPropios)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtAjenos, dtPropios };
			object[] results = this.Invoke("GuardarActivos", objArray);
			return Conversions.ToString(results[0]);
		}

		public void GuardarActivosAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtAjenos, DataSet dtPropios)
		{
			this.GuardarActivosAsync(strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtAjenos, dtPropios, null);
		}

		/// <remarks />
		public void GuardarActivosAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtAjenos, DataSet dtPropios, object userState)
		{
			if (this.GuardarActivosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.GuardarActivosOperationCompleted = new SendOrPostCallback(service.OnGuardarActivosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtAjenos, dtPropios };
			this.InvokeAsync("GuardarActivos", objArray, this.GuardarActivosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/GuardarActivosPocket", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GuardarActivosPocket(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, long CodigoActivo, int Cantidad, string Propiedad)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, CodigoActivo, Cantidad, Propiedad };
			object[] results = this.Invoke("GuardarActivosPocket", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void GuardarActivosPocketAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, long CodigoActivo, int Cantidad, string Propiedad)
		{
			this.GuardarActivosPocketAsync(strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, CodigoActivo, Cantidad, Propiedad, null);
		}

		public void GuardarActivosPocketAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, long CodigoActivo, int Cantidad, string Propiedad, object userState)
		{
			if (this.GuardarActivosPocketOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.GuardarActivosPocketOperationCompleted = new SendOrPostCallback(service.OnGuardarActivosPocketOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, CodigoActivo, Cantidad, Propiedad };
			this.InvokeAsync("GuardarActivosPocket", objArray, this.GuardarActivosPocketOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/GuardarMixto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GuardarMixto(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtProducto, DataSet dtAjenos, DataSet dtPropios, DataSet dtProductoAjeno)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtProducto, dtAjenos, dtPropios, dtProductoAjeno };
			object[] results = this.Invoke("GuardarMixto", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void GuardarMixtoAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtProducto, DataSet dtAjenos, DataSet dtPropios, DataSet dtProductoAjeno)
		{
			this.GuardarMixtoAsync(strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtProducto, dtAjenos, dtPropios, dtProductoAjeno, null);
		}

		public void GuardarMixtoAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtProducto, DataSet dtAjenos, DataSet dtPropios, DataSet dtProductoAjeno, object userState)
		{
			if (this.GuardarMixtoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.GuardarMixtoOperationCompleted = new SendOrPostCallback(service.OnGuardarMixtoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtProducto, dtAjenos, dtPropios, dtProductoAjeno };
			this.InvokeAsync("GuardarMixto", objArray, this.GuardarMixtoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/GuardarProductos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GuardarProductos(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtProducto, DataSet dtProductoPart)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtProducto, dtProductoPart };
			object[] results = this.Invoke("GuardarProductos", objArray);
			return Conversions.ToString(results[0]);
		}

		public void GuardarProductosAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtProducto, DataSet dtProductoPart)
		{
			this.GuardarProductosAsync(strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtProducto, dtProductoPart, null);
		}

		/// <remarks />
		public void GuardarProductosAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, string Usuario, DataSet dtProducto, DataSet dtProductoPart, object userState)
		{
			if (this.GuardarProductosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.GuardarProductosOperationCompleted = new SendOrPostCallback(service.OnGuardarProductosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, Usuario, dtProducto, dtProductoPart };
			this.InvokeAsync("GuardarProductos", objArray, this.GuardarProductosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/GuardarProductosPocket", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GuardarProductosPocket(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, long CodigoProducto, int Cantidad, double Capacidad, string Usuario, string Propiedad)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, CodigoProducto, Cantidad, Capacidad, Usuario, Propiedad };
			object[] results = this.Invoke("GuardarProductosPocket", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void GuardarProductosPocketAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, long CodigoProducto, int Cantidad, double Capacidad, string Usuario, string Propiedad)
		{
			this.GuardarProductosPocketAsync(strConnection, CodigoConteo, Contenido, TipoDetalle, CodigoProducto, Cantidad, Capacidad, Usuario, Propiedad, null);
		}

		public void GuardarProductosPocketAsync(string strConnection, int CodigoConteo, string Contenido, string TipoDetalle, long CodigoProducto, int Cantidad, double Capacidad, string Usuario, string Propiedad, object userState)
		{
			if (this.GuardarProductosPocketOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.GuardarProductosPocketOperationCompleted = new SendOrPostCallback(service.OnGuardarProductosPocketOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, Contenido, TipoDetalle, CodigoProducto, Cantidad, Capacidad, Usuario, Propiedad };
			this.InvokeAsync("GuardarProductosPocket", objArray, this.GuardarProductosPocketOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string HelloWorld()
		{
			object[] results = this.Invoke("HelloWorld", new object[0]);
			return Conversions.ToString(results[0]);
		}

		public void HelloWorldAsync()
		{
			this.HelloWorldAsync(null);
		}

		/// <remarks />
		public void HelloWorldAsync(object userState)
		{
			if (this.HelloWorldOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.HelloWorldOperationCompleted = new SendOrPostCallback(service.OnHelloWorldOperationCompleted);
			}
			this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/IndicadorCuentaCorriente", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string IndicadorCuentaCorriente(string strConnection, int CodigoProducto)
		{
			object[] objArray = new object[] { strConnection, CodigoProducto };
			object[] results = this.Invoke("IndicadorCuentaCorriente", objArray);
			return Conversions.ToString(results[0]);
		}

		public void IndicadorCuentaCorrienteAsync(string strConnection, int CodigoProducto)
		{
			this.IndicadorCuentaCorrienteAsync(strConnection, CodigoProducto, null);
		}

		/// <remarks />
		public void IndicadorCuentaCorrienteAsync(string strConnection, int CodigoProducto, object userState)
		{
			if (this.IndicadorCuentaCorrienteOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.IndicadorCuentaCorrienteOperationCompleted = new SendOrPostCallback(service.OnIndicadorCuentaCorrienteOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoProducto };
			this.InvokeAsync("IndicadorCuentaCorriente", objArray, this.IndicadorCuentaCorrienteOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/InsertarDiferenciaActivos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarDiferenciaActivos(string strConnection, string Usuario, DataSet ds1, DataSet ds2)
		{
			object[] objArray = new object[] { strConnection, Usuario, ds1, ds2 };
			object[] results = this.Invoke("InsertarDiferenciaActivos", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void InsertarDiferenciaActivosAsync(string strConnection, string Usuario, DataSet ds1, DataSet ds2)
		{
			this.InsertarDiferenciaActivosAsync(strConnection, Usuario, ds1, ds2, null);
		}

		public void InsertarDiferenciaActivosAsync(string strConnection, string Usuario, DataSet ds1, DataSet ds2, object userState)
		{
			if (this.InsertarDiferenciaActivosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarDiferenciaActivosOperationCompleted = new SendOrPostCallback(service.OnInsertarDiferenciaActivosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Usuario, ds1, ds2 };
			this.InvokeAsync("InsertarDiferenciaActivos", objArray, this.InsertarDiferenciaActivosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/InsertarDiferenciaMixto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarDiferenciaMixto(string strConnection, string Usuario, DataSet ds1, DataSet ds2, DataSet ds3, DataSet ds4)
		{
			object[] objArray = new object[] { strConnection, Usuario, ds1, ds2, ds3, ds4 };
			object[] results = this.Invoke("InsertarDiferenciaMixto", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void InsertarDiferenciaMixtoAsync(string strConnection, string Usuario, DataSet ds1, DataSet ds2, DataSet ds3, DataSet ds4)
		{
			this.InsertarDiferenciaMixtoAsync(strConnection, Usuario, ds1, ds2, ds3, ds4, null);
		}

		public void InsertarDiferenciaMixtoAsync(string strConnection, string Usuario, DataSet ds1, DataSet ds2, DataSet ds3, DataSet ds4, object userState)
		{
			if (this.InsertarDiferenciaMixtoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarDiferenciaMixtoOperationCompleted = new SendOrPostCallback(service.OnInsertarDiferenciaMixtoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Usuario, ds1, ds2, ds3, ds4 };
			this.InvokeAsync("InsertarDiferenciaMixto", objArray, this.InsertarDiferenciaMixtoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/InsertarDiferenciaProductos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarDiferenciaProductos(string strConnection, string Usuario, DataSet ds)
		{
			object[] objArray = new object[] { strConnection, Usuario, ds };
			object[] results = this.Invoke("InsertarDiferenciaProductos", objArray);
			return Conversions.ToString(results[0]);
		}

		public void InsertarDiferenciaProductosAsync(string strConnection, string Usuario, DataSet ds)
		{
			this.InsertarDiferenciaProductosAsync(strConnection, Usuario, ds, null);
		}

		/// <remarks />
		public void InsertarDiferenciaProductosAsync(string strConnection, string Usuario, DataSet ds, object userState)
		{
			if (this.InsertarDiferenciaProductosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarDiferenciaProductosOperationCompleted = new SendOrPostCallback(service.OnInsertarDiferenciaProductosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Usuario, ds };
			this.InvokeAsync("InsertarDiferenciaProductos", objArray, this.InsertarDiferenciaProductosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/InsertarEtiqueta", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarEtiqueta(string strConnection, int Longitud, string TipoEtiqueta, string Descripcion, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Longitud, TipoEtiqueta, Descripcion, Usuario };
			object[] results = this.Invoke("InsertarEtiqueta", objArray);
			return Conversions.ToString(results[0]);
		}

		public void InsertarEtiquetaAsync(string strConnection, int Longitud, string TipoEtiqueta, string Descripcion, string Usuario)
		{
			this.InsertarEtiquetaAsync(strConnection, Longitud, TipoEtiqueta, Descripcion, Usuario, null);
		}

		/// <remarks />
		public void InsertarEtiquetaAsync(string strConnection, int Longitud, string TipoEtiqueta, string Descripcion, string Usuario, object userState)
		{
			if (this.InsertarEtiquetaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarEtiquetaOperationCompleted = new SendOrPostCallback(service.OnInsertarEtiquetaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Longitud, TipoEtiqueta, Descripcion, Usuario };
			this.InvokeAsync("InsertarEtiqueta", objArray, this.InsertarEtiquetaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/InsertarMotivoAnulacion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarMotivoAnulacion(string strConnection, string Descripcion, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Descripcion, Usuario };
			object[] results = this.Invoke("InsertarMotivoAnulacion", objArray);
			return Conversions.ToString(results[0]);
		}

		public void InsertarMotivoAnulacionAsync(string strConnection, string Descripcion, string Usuario)
		{
			this.InsertarMotivoAnulacionAsync(strConnection, Descripcion, Usuario, null);
		}

		/// <remarks />
		public void InsertarMotivoAnulacionAsync(string strConnection, string Descripcion, string Usuario, object userState)
		{
			if (this.InsertarMotivoAnulacionOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarMotivoAnulacionOperationCompleted = new SendOrPostCallback(service.OnInsertarMotivoAnulacionOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Descripcion, Usuario };
			this.InvokeAsync("InsertarMotivoAnulacion", objArray, this.InsertarMotivoAnulacionOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/InsertarMotivoDiferencia", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarMotivoDiferencia(string strConnection, string Descripcion, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Descripcion, Usuario };
			object[] results = this.Invoke("InsertarMotivoDiferencia", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void InsertarMotivoDiferenciaAsync(string strConnection, string Descripcion, string Usuario)
		{
			this.InsertarMotivoDiferenciaAsync(strConnection, Descripcion, Usuario, null);
		}

		public void InsertarMotivoDiferenciaAsync(string strConnection, string Descripcion, string Usuario, object userState)
		{
			if (this.InsertarMotivoDiferenciaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarMotivoDiferenciaOperationCompleted = new SendOrPostCallback(service.OnInsertarMotivoDiferenciaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Descripcion, Usuario };
			this.InvokeAsync("InsertarMotivoDiferencia", objArray, this.InsertarMotivoDiferenciaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/InsertarSectores", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarSectores(string strConnection, string CodigoSector, string Descripcion, string Usuario)
		{
			object[] objArray = new object[] { strConnection, CodigoSector, Descripcion, Usuario };
			object[] results = this.Invoke("InsertarSectores", objArray);
			return Conversions.ToString(results[0]);
		}

		public void InsertarSectoresAsync(string strConnection, string CodigoSector, string Descripcion, string Usuario)
		{
			this.InsertarSectoresAsync(strConnection, CodigoSector, Descripcion, Usuario, null);
		}

		/// <remarks />
		public void InsertarSectoresAsync(string strConnection, string CodigoSector, string Descripcion, string Usuario, object userState)
		{
			if (this.InsertarSectoresOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarSectoresOperationCompleted = new SendOrPostCallback(service.OnInsertarSectoresOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoSector, Descripcion, Usuario };
			this.InvokeAsync("InsertarSectores", objArray, this.InsertarSectoresOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/InsertarSubdepositoSector", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarSubdepositoSector(string strConnection, int Sucursal, string Sector, int Subdeposito, int CodigoGrupo, int CodigoEmpresa, string Usuario, int ControlaPapeleria)
		{
			object[] objArray = new object[] { strConnection, Sucursal, Sector, Subdeposito, CodigoGrupo, CodigoEmpresa, Usuario, ControlaPapeleria };
			object[] results = this.Invoke("InsertarSubdepositoSector", objArray);
			return Conversions.ToString(results[0]);
		}

		public void InsertarSubdepositoSectorAsync(string strConnection, int Sucursal, string Sector, int Subdeposito, int CodigoGrupo, int CodigoEmpresa, string Usuario, int ControlaPapeleria)
		{
			this.InsertarSubdepositoSectorAsync(strConnection, Sucursal, Sector, Subdeposito, CodigoGrupo, CodigoEmpresa, Usuario, ControlaPapeleria, null);
		}

		/// <remarks />
		public void InsertarSubdepositoSectorAsync(string strConnection, int Sucursal, string Sector, int Subdeposito, int CodigoGrupo, int CodigoEmpresa, string Usuario, int ControlaPapeleria, object userState)
		{
			if (this.InsertarSubdepositoSectorOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarSubdepositoSectorOperationCompleted = new SendOrPostCallback(service.OnInsertarSubdepositoSectorOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, Sector, Subdeposito, CodigoGrupo, CodigoEmpresa, Usuario, ControlaPapeleria };
			this.InvokeAsync("InsertarSubdepositoSector", objArray, this.InsertarSubdepositoSectorOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/InsertarSucursal", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string InsertarSucursal(string strConnection, int Sucursal, string Sector, int CodigoGrupo, int CodigoEmpresa, string Usuario)
		{
			object[] objArray = new object[] { strConnection, Sucursal, Sector, CodigoGrupo, CodigoEmpresa, Usuario };
			object[] results = this.Invoke("InsertarSucursal", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void InsertarSucursalAsync(string strConnection, int Sucursal, string Sector, int CodigoGrupo, int CodigoEmpresa, string Usuario)
		{
			this.InsertarSucursalAsync(strConnection, Sucursal, Sector, CodigoGrupo, CodigoEmpresa, Usuario, null);
		}

		public void InsertarSucursalAsync(string strConnection, int Sucursal, string Sector, int CodigoGrupo, int CodigoEmpresa, string Usuario, object userState)
		{
			if (this.InsertarSucursalOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.InsertarSucursalOperationCompleted = new SendOrPostCallback(service.OnInsertarSucursalOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Sucursal, Sector, CodigoGrupo, CodigoEmpresa, Usuario };
			this.InvokeAsync("InsertarSucursal", objArray, this.InsertarSucursalOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
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

		[SoapDocumentMethod("http://tempuri.org/NombreActivo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string NombreActivo(string strConnection, int Codigo, string Propiedad)
		{
			object[] objArray = new object[] { strConnection, Codigo, Propiedad };
			object[] results = this.Invoke("NombreActivo", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void NombreActivoAsync(string strConnection, int Codigo, string Propiedad)
		{
			this.NombreActivoAsync(strConnection, Codigo, Propiedad, null);
		}

		public void NombreActivoAsync(string strConnection, int Codigo, string Propiedad, object userState)
		{
			if (this.NombreActivoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.NombreActivoOperationCompleted = new SendOrPostCallback(service.OnNombreActivoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Codigo, Propiedad };
			this.InvokeAsync("NombreActivo", objArray, this.NombreActivoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/NombreProducto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string NombreProducto(string strConnection, int Conteo, int CodigoProducto)
		{
			object[] objArray = new object[] { strConnection, Conteo, CodigoProducto };
			object[] results = this.Invoke("NombreProducto", objArray);
			return Conversions.ToString(results[0]);
		}

		public void NombreProductoAsync(string strConnection, int Conteo, int CodigoProducto)
		{
			this.NombreProductoAsync(strConnection, Conteo, CodigoProducto, null);
		}

		/// <remarks />
		public void NombreProductoAsync(string strConnection, int Conteo, int CodigoProducto, object userState)
		{
			if (this.NombreProductoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.NombreProductoOperationCompleted = new SendOrPostCallback(service.OnNombreProductoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, Conteo, CodigoProducto };
			this.InvokeAsync("NombreProducto", objArray, this.NombreProductoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ObtenerConteos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ObtenerConteos(string strConnection, int CodigoConteo)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo };
			return (DataSet)this.Invoke("ObtenerConteos", objArray)[0];
		}

		/// <remarks />
		public void ObtenerConteosAsync(string strConnection, int CodigoConteo)
		{
			this.ObtenerConteosAsync(strConnection, CodigoConteo, null);
		}

		public void ObtenerConteosAsync(string strConnection, int CodigoConteo, object userState)
		{
			if (this.ObtenerConteosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ObtenerConteosOperationCompleted = new SendOrPostCallback(service.OnObtenerConteosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo };
			this.InvokeAsync("ObtenerConteos", objArray, this.ObtenerConteosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ObtenerDatosConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ObtenerDatosConteo(string strConnection, int CodigoConteo)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo };
			return (DataSet)this.Invoke("ObtenerDatosConteo", objArray)[0];
		}

		public void ObtenerDatosConteoAsync(string strConnection, int CodigoConteo)
		{
			this.ObtenerDatosConteoAsync(strConnection, CodigoConteo, null);
		}

		/// <remarks />
		public void ObtenerDatosConteoAsync(string strConnection, int CodigoConteo, object userState)
		{
			if (this.ObtenerDatosConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ObtenerDatosConteoOperationCompleted = new SendOrPostCallback(service.OnObtenerDatosConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo };
			this.InvokeAsync("ObtenerDatosConteo", objArray, this.ObtenerDatosConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ObtenerSectorSubdeposito", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ObtenerSectorSubdeposito(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal, int CodigoSubdeposito)
		{
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal, CodigoSubdeposito };
			object[] results = this.Invoke("ObtenerSectorSubdeposito", objArray);
			return Conversions.ToString(results[0]);
		}

		public void ObtenerSectorSubdepositoAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal, int CodigoSubdeposito)
		{
			this.ObtenerSectorSubdepositoAsync(strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal, CodigoSubdeposito, null);
		}

		/// <remarks />
		public void ObtenerSectorSubdepositoAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, int CodigoSucursal, int CodigoSubdeposito, object userState)
		{
			if (this.ObtenerSectorSubdepositoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ObtenerSectorSubdepositoOperationCompleted = new SendOrPostCallback(service.OnObtenerSectorSubdepositoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa, CodigoSucursal, CodigoSubdeposito };
			this.InvokeAsync("ObtenerSectorSubdeposito", objArray, this.ObtenerSectorSubdepositoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ObtenerSubdepositosConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ObtenerSubdepositosConteo(string strConnection, int CodigoConteo, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("ObtenerSubdepositosConteo", objArray)[0];
		}

		/// <remarks />
		public void ObtenerSubdepositosConteoAsync(string strConnection, int CodigoConteo, int CodigoGrupo, int CodigoEmpresa)
		{
			this.ObtenerSubdepositosConteoAsync(strConnection, CodigoConteo, CodigoGrupo, CodigoEmpresa, null);
		}

		public void ObtenerSubdepositosConteoAsync(string strConnection, int CodigoConteo, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.ObtenerSubdepositosConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ObtenerSubdepositosConteoOperationCompleted = new SendOrPostCallback(service.OnObtenerSubdepositosConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("ObtenerSubdepositosConteo", objArray, this.ObtenerSubdepositosConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/ObtenerUsuarios", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet ObtenerUsuarios(string strConnection, int CodigoGrupo, int CodigoEmpresa)
		{
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa };
			return (DataSet)this.Invoke("ObtenerUsuarios", objArray)[0];
		}

		public void ObtenerUsuariosAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa)
		{
			this.ObtenerUsuariosAsync(strConnection, CodigoGrupo, CodigoEmpresa, null);
		}

		/// <remarks />
		public void ObtenerUsuariosAsync(string strConnection, int CodigoGrupo, int CodigoEmpresa, object userState)
		{
			if (this.ObtenerUsuariosOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ObtenerUsuariosOperationCompleted = new SendOrPostCallback(service.OnObtenerUsuariosOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoGrupo, CodigoEmpresa };
			this.InvokeAsync("ObtenerUsuarios", objArray, this.ObtenerUsuariosOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		private void OnAbrirConteoOperationCompleted(object arg)
		{
			if (this.AbrirConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				AbrirConteoCompletedEventHandler abrirConteoCompletedEventHandler = this.AbrirConteoCompleted;
				if (abrirConteoCompletedEventHandler != null)
				{
					abrirConteoCompletedEventHandler(this, new AbrirConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnActualizarEtiquetaOperationCompleted(object arg)
		{
			if (this.ActualizarEtiquetaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ActualizarEtiquetaCompletedEventHandler actualizarEtiquetaCompletedEventHandler = this.ActualizarEtiquetaCompleted;
				if (actualizarEtiquetaCompletedEventHandler != null)
				{
					actualizarEtiquetaCompletedEventHandler(this, new ActualizarEtiquetaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnActualizarMotivoAnulacionOperationCompleted(object arg)
		{
			if (this.ActualizarMotivoAnulacionCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ActualizarMotivoAnulacionCompletedEventHandler actualizarMotivoAnulacionCompletedEventHandler = this.ActualizarMotivoAnulacionCompleted;
				if (actualizarMotivoAnulacionCompletedEventHandler != null)
				{
					actualizarMotivoAnulacionCompletedEventHandler(this, new ActualizarMotivoAnulacionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnActualizarMotivoDiferenciaOperationCompleted(object arg)
		{
			if (this.ActualizarMotivoDiferenciaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ActualizarMotivoDiferenciaCompletedEventHandler actualizarMotivoDiferenciaCompletedEventHandler = this.ActualizarMotivoDiferenciaCompleted;
				if (actualizarMotivoDiferenciaCompletedEventHandler != null)
				{
					actualizarMotivoDiferenciaCompletedEventHandler(this, new ActualizarMotivoDiferenciaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnActualizarSectoresOperationCompleted(object arg)
		{
			if (this.ActualizarSectoresCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ActualizarSectoresCompletedEventHandler actualizarSectoresCompletedEventHandler = this.ActualizarSectoresCompleted;
				if (actualizarSectoresCompletedEventHandler != null)
				{
					actualizarSectoresCompletedEventHandler(this, new ActualizarSectoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnAnularConteoOperationCompleted(object arg)
		{
			if (this.AnularConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				AnularConteoCompletedEventHandler anularConteoCompletedEventHandler = this.AnularConteoCompleted;
				if (anularConteoCompletedEventHandler != null)
				{
					anularConteoCompletedEventHandler(this, new AnularConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnBloquearConteoOperationCompleted(object arg)
		{
			if (this.BloquearConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				BloquearConteoCompletedEventHandler bloquearConteoCompletedEventHandler = this.BloquearConteoCompleted;
				if (bloquearConteoCompletedEventHandler != null)
				{
					bloquearConteoCompletedEventHandler(this, new BloquearConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnBloquearRegistroConteoOperationCompleted(object arg)
		{
			if (this.BloquearRegistroConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				BloquearRegistroConteoCompletedEventHandler bloquearRegistroConteoCompletedEventHandler = this.BloquearRegistroConteoCompleted;
				if (bloquearRegistroConteoCompletedEventHandler != null)
				{
					bloquearRegistroConteoCompletedEventHandler(this, new BloquearRegistroConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCapacidadesProductoOperationCompleted(object arg)
		{
			if (this.CapacidadesProductoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CapacidadesProductoCompletedEventHandler capacidadesProductoCompletedEventHandler = this.CapacidadesProductoCompleted;
				if (capacidadesProductoCompletedEventHandler != null)
				{
					capacidadesProductoCompletedEventHandler(this, new CapacidadesProductoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCargarActivoCapacidadOperationCompleted(object arg)
		{
			if (this.CargarActivoCapacidadCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CargarActivoCapacidadCompletedEventHandler cargarActivoCapacidadCompletedEventHandler = this.CargarActivoCapacidadCompleted;
				if (cargarActivoCapacidadCompletedEventHandler != null)
				{
					cargarActivoCapacidadCompletedEventHandler(this, new CargarActivoCapacidadCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCargarMotivoAnulacionOperationCompleted(object arg)
		{
			if (this.CargarMotivoAnulacionCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CargarMotivoAnulacionCompletedEventHandler cargarMotivoAnulacionCompletedEventHandler = this.CargarMotivoAnulacionCompleted;
				if (cargarMotivoAnulacionCompletedEventHandler != null)
				{
					cargarMotivoAnulacionCompletedEventHandler(this, new CargarMotivoAnulacionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCargarMotivosDiferenciasOperationCompleted(object arg)
		{
			if (this.CargarMotivosDiferenciasCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CargarMotivosDiferenciasCompletedEventHandler cargarMotivosDiferenciasCompletedEventHandler = this.CargarMotivosDiferenciasCompleted;
				if (cargarMotivosDiferenciasCompletedEventHandler != null)
				{
					cargarMotivosDiferenciasCompletedEventHandler(this, new CargarMotivosDiferenciasCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCargarSectoresOperationCompleted(object arg)
		{
			if (this.CargarSectoresCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CargarSectoresCompletedEventHandler cargarSectoresCompletedEventHandler = this.CargarSectoresCompleted;
				if (cargarSectoresCompletedEventHandler != null)
				{
					cargarSectoresCompletedEventHandler(this, new CargarSectoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCerrarConteoOperationCompleted(object arg)
		{
			if (this.CerrarConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CerrarConteoCompletedEventHandler cerrarConteoCompletedEventHandler = this.CerrarConteoCompleted;
				if (cerrarConteoCompletedEventHandler != null)
				{
					cerrarConteoCompletedEventHandler(this, new CerrarConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCerrarPapeleriaOperationCompleted(object arg)
		{
			if (this.CerrarPapeleriaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CerrarPapeleriaCompletedEventHandler cerrarPapeleriaCompletedEventHandler = this.CerrarPapeleriaCompleted;
				if (cerrarPapeleriaCompletedEventHandler != null)
				{
					cerrarPapeleriaCompletedEventHandler(this, new AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnConsultarConteoOperationCompleted(object arg)
		{
			if (this.ConsultarConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ConsultarConteoCompletedEventHandler consultarConteoCompletedEventHandler = this.ConsultarConteoCompleted;
				if (consultarConteoCompletedEventHandler != null)
				{
					consultarConteoCompletedEventHandler(this, new ConsultarConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnConsultarDiferenciasOperationCompleted(object arg)
		{
			if (this.ConsultarDiferenciasCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ConsultarDiferenciasCompletedEventHandler consultarDiferenciasCompletedEventHandler = this.ConsultarDiferenciasCompleted;
				if (consultarDiferenciasCompletedEventHandler != null)
				{
					consultarDiferenciasCompletedEventHandler(this, new ConsultarDiferenciasCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnConsultarFestivosOperationCompleted(object arg)
		{
			if (this.ConsultarFestivosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ConsultarFestivosCompletedEventHandler consultarFestivosCompletedEventHandler = this.ConsultarFestivosCompleted;
				if (consultarFestivosCompletedEventHandler != null)
				{
					consultarFestivosCompletedEventHandler(this, new ConsultarFestivosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnConsultarSubdepositosConfiguradosOperationCompleted(object arg)
		{
			if (this.ConsultarSubdepositosConfiguradosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ConsultarSubdepositosConfiguradosCompletedEventHandler consultarSubdepositosConfiguradosCompletedEventHandler = this.ConsultarSubdepositosConfiguradosCompleted;
				if (consultarSubdepositosConfiguradosCompletedEventHandler != null)
				{
					consultarSubdepositosConfiguradosCompletedEventHandler(this, new ConsultarSubdepositosConfiguradosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnConsultarSubdepositosOperationCompleted(object arg)
		{
			if (this.ConsultarSubdepositosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ConsultarSubdepositosCompletedEventHandler consultarSubdepositosCompletedEventHandler = this.ConsultarSubdepositosCompleted;
				if (consultarSubdepositosCompletedEventHandler != null)
				{
					consultarSubdepositosCompletedEventHandler(this, new ConsultarSubdepositosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnConsultarSucursalesOperationCompleted(object arg)
		{
			if (this.ConsultarSucursalesCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ConsultarSucursalesCompletedEventHandler consultarSucursalesCompletedEventHandler = this.ConsultarSucursalesCompleted;
				if (consultarSucursalesCompletedEventHandler != null)
				{
					consultarSucursalesCompletedEventHandler(this, new ConsultarSucursalesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearActivosGrillaOperationCompleted(object arg)
		{
			if (this.CrearActivosGrillaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearActivosGrillaCompletedEventHandler crearActivosGrillaCompletedEventHandler = this.CrearActivosGrillaCompleted;
				if (crearActivosGrillaCompletedEventHandler != null)
				{
					crearActivosGrillaCompletedEventHandler(this, new CrearActivosGrillaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearActivosOperationCompleted(object arg)
		{
			if (this.CrearActivosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearActivosCompletedEventHandler crearActivosCompletedEventHandler = this.CrearActivosCompleted;
				if (crearActivosCompletedEventHandler != null)
				{
					crearActivosCompletedEventHandler(this, new CrearActivosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearCierreOperationCompleted(object arg)
		{
			if (this.CrearCierreCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearCierreCompletedEventHandler crearCierreCompletedEventHandler = this.CrearCierreCompleted;
				if (crearCierreCompletedEventHandler != null)
				{
					crearCierreCompletedEventHandler(this, new CrearCierreCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearEtiquetaOperationCompleted(object arg)
		{
			if (this.CrearEtiquetaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearEtiquetaCompletedEventHandler crearEtiquetaCompletedEventHandler = this.CrearEtiquetaCompleted;
				if (crearEtiquetaCompletedEventHandler != null)
				{
					crearEtiquetaCompletedEventHandler(this, new CrearEtiquetaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearMotivoAnulacionOperationCompleted(object arg)
		{
			if (this.CrearMotivoAnulacionCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearMotivoAnulacionCompletedEventHandler crearMotivoAnulacionCompletedEventHandler = this.CrearMotivoAnulacionCompleted;
				if (crearMotivoAnulacionCompletedEventHandler != null)
				{
					crearMotivoAnulacionCompletedEventHandler(this, new CrearMotivoAnulacionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearMotivoDiferenciaOperationCompleted(object arg)
		{
			if (this.CrearMotivoDiferenciaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearMotivoDiferenciaCompletedEventHandler crearMotivoDiferenciaCompletedEventHandler = this.CrearMotivoDiferenciaCompleted;
				if (crearMotivoDiferenciaCompletedEventHandler != null)
				{
					crearMotivoDiferenciaCompletedEventHandler(this, new CrearMotivoDiferenciaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearProductosComboOperationCompleted(object arg)
		{
			if (this.CrearProductosComboCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearProductosComboCompletedEventHandler crearProductosComboCompletedEventHandler = this.CrearProductosComboCompleted;
				if (crearProductosComboCompletedEventHandler != null)
				{
					crearProductosComboCompletedEventHandler(this, new CrearProductosComboCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearProductosGrillaOperationCompleted(object arg)
		{
			if (this.CrearProductosGrillaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearProductosGrillaCompletedEventHandler crearProductosGrillaCompletedEventHandler = this.CrearProductosGrillaCompleted;
				if (crearProductosGrillaCompletedEventHandler != null)
				{
					crearProductosGrillaCompletedEventHandler(this, new CrearProductosGrillaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearProgramacionOperationCompleted(object arg)
		{
			if (this.CrearProgramacionCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearProgramacionCompletedEventHandler crearProgramacionCompletedEventHandler = this.CrearProgramacionCompleted;
				if (crearProgramacionCompletedEventHandler != null)
				{
					crearProgramacionCompletedEventHandler(this, new CrearProgramacionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearSectoresOperationCompleted(object arg)
		{
			if (this.CrearSectoresCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearSectoresCompletedEventHandler crearSectoresCompletedEventHandler = this.CrearSectoresCompleted;
				if (crearSectoresCompletedEventHandler != null)
				{
					crearSectoresCompletedEventHandler(this, new CrearSectoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearSectoresSubdepositosOperationCompleted(object arg)
		{
			if (this.CrearSectoresSubdepositosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearSectoresSubdepositosCompletedEventHandler crearSectoresSubdepositosCompletedEventHandler = this.CrearSectoresSubdepositosCompleted;
				if (crearSectoresSubdepositosCompletedEventHandler != null)
				{
					crearSectoresSubdepositosCompletedEventHandler(this, new CrearSectoresSubdepositosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearSectorSucursalOperationCompleted(object arg)
		{
			if (this.CrearSectorSucursalCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearSectorSucursalCompletedEventHandler crearSectorSucursalCompletedEventHandler = this.CrearSectorSucursalCompleted;
				if (crearSectorSucursalCompletedEventHandler != null)
				{
					crearSectorSucursalCompletedEventHandler(this, new CrearSectorSucursalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearSubdepositoSectorOperationCompleted(object arg)
		{
			if (this.CrearSubdepositoSectorCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearSubdepositoSectorCompletedEventHandler crearSubdepositoSectorCompletedEventHandler = this.CrearSubdepositoSectorCompleted;
				if (crearSubdepositoSectorCompletedEventHandler != null)
				{
					crearSubdepositoSectorCompletedEventHandler(this, new CrearSubdepositoSectorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnCrearSucursalOperationCompleted(object arg)
		{
			if (this.CrearSucursalCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				CrearSucursalCompletedEventHandler crearSucursalCompletedEventHandler = this.CrearSucursalCompleted;
				if (crearSucursalCompletedEventHandler != null)
				{
					crearSucursalCompletedEventHandler(this, new CrearSucursalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnEliminarSubdepositoSectorOperationCompleted(object arg)
		{
			if (this.EliminarSubdepositoSectorCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				EliminarSubdepositoSectorCompletedEventHandler eliminarSubdepositoSectorCompletedEventHandler = this.EliminarSubdepositoSectorCompleted;
				if (eliminarSubdepositoSectorCompletedEventHandler != null)
				{
					eliminarSubdepositoSectorCompletedEventHandler(this, new EliminarSubdepositoSectorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnEliminarSucursalOperationCompleted(object arg)
		{
			if (this.EliminarSucursalCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				EliminarSucursalCompletedEventHandler eliminarSucursalCompletedEventHandler = this.EliminarSucursalCompleted;
				if (eliminarSucursalCompletedEventHandler != null)
				{
					eliminarSucursalCompletedEventHandler(this, new EliminarSucursalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGenerarFestivosOperationCompleted(object arg)
		{
			if (this.GenerarFestivosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GenerarFestivosCompletedEventHandler generarFestivosCompletedEventHandler = this.GenerarFestivosCompleted;
				if (generarFestivosCompletedEventHandler != null)
				{
					generarFestivosCompletedEventHandler(this, new GenerarFestivosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGuardarActivosOperationCompleted(object arg)
		{
			if (this.GuardarActivosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GuardarActivosCompletedEventHandler guardarActivosCompletedEventHandler = this.GuardarActivosCompleted;
				if (guardarActivosCompletedEventHandler != null)
				{
					guardarActivosCompletedEventHandler(this, new GuardarActivosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGuardarActivosPocketOperationCompleted(object arg)
		{
			if (this.GuardarActivosPocketCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GuardarActivosPocketCompletedEventHandler guardarActivosPocketCompletedEventHandler = this.GuardarActivosPocketCompleted;
				if (guardarActivosPocketCompletedEventHandler != null)
				{
					guardarActivosPocketCompletedEventHandler(this, new GuardarActivosPocketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGuardarMixtoOperationCompleted(object arg)
		{
			if (this.GuardarMixtoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GuardarMixtoCompletedEventHandler guardarMixtoCompletedEventHandler = this.GuardarMixtoCompleted;
				if (guardarMixtoCompletedEventHandler != null)
				{
					guardarMixtoCompletedEventHandler(this, new GuardarMixtoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGuardarProductosOperationCompleted(object arg)
		{
			if (this.GuardarProductosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GuardarProductosCompletedEventHandler guardarProductosCompletedEventHandler = this.GuardarProductosCompleted;
				if (guardarProductosCompletedEventHandler != null)
				{
					guardarProductosCompletedEventHandler(this, new GuardarProductosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnGuardarProductosPocketOperationCompleted(object arg)
		{
			if (this.GuardarProductosPocketCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				GuardarProductosPocketCompletedEventHandler guardarProductosPocketCompletedEventHandler = this.GuardarProductosPocketCompleted;
				if (guardarProductosPocketCompletedEventHandler != null)
				{
					guardarProductosPocketCompletedEventHandler(this, new GuardarProductosPocketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnHelloWorldOperationCompleted(object arg)
		{
			if (this.HelloWorldCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				HelloWorldCompletedEventHandler helloWorldCompletedEventHandler = this.HelloWorldCompleted;
				if (helloWorldCompletedEventHandler != null)
				{
					helloWorldCompletedEventHandler(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnIndicadorCuentaCorrienteOperationCompleted(object arg)
		{
			if (this.IndicadorCuentaCorrienteCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				IndicadorCuentaCorrienteCompletedEventHandler indicadorCuentaCorrienteCompletedEventHandler = this.IndicadorCuentaCorrienteCompleted;
				if (indicadorCuentaCorrienteCompletedEventHandler != null)
				{
					indicadorCuentaCorrienteCompletedEventHandler(this, new IndicadorCuentaCorrienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarDiferenciaActivosOperationCompleted(object arg)
		{
			if (this.InsertarDiferenciaActivosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarDiferenciaActivosCompletedEventHandler insertarDiferenciaActivosCompletedEventHandler = this.InsertarDiferenciaActivosCompleted;
				if (insertarDiferenciaActivosCompletedEventHandler != null)
				{
					insertarDiferenciaActivosCompletedEventHandler(this, new InsertarDiferenciaActivosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarDiferenciaMixtoOperationCompleted(object arg)
		{
			if (this.InsertarDiferenciaMixtoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarDiferenciaMixtoCompletedEventHandler insertarDiferenciaMixtoCompletedEventHandler = this.InsertarDiferenciaMixtoCompleted;
				if (insertarDiferenciaMixtoCompletedEventHandler != null)
				{
					insertarDiferenciaMixtoCompletedEventHandler(this, new InsertarDiferenciaMixtoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarDiferenciaProductosOperationCompleted(object arg)
		{
			if (this.InsertarDiferenciaProductosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarDiferenciaProductosCompletedEventHandler insertarDiferenciaProductosCompletedEventHandler = this.InsertarDiferenciaProductosCompleted;
				if (insertarDiferenciaProductosCompletedEventHandler != null)
				{
					insertarDiferenciaProductosCompletedEventHandler(this, new InsertarDiferenciaProductosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarEtiquetaOperationCompleted(object arg)
		{
			if (this.InsertarEtiquetaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarEtiquetaCompletedEventHandler insertarEtiquetaCompletedEventHandler = this.InsertarEtiquetaCompleted;
				if (insertarEtiquetaCompletedEventHandler != null)
				{
					insertarEtiquetaCompletedEventHandler(this, new InsertarEtiquetaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarMotivoAnulacionOperationCompleted(object arg)
		{
			if (this.InsertarMotivoAnulacionCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarMotivoAnulacionCompletedEventHandler insertarMotivoAnulacionCompletedEventHandler = this.InsertarMotivoAnulacionCompleted;
				if (insertarMotivoAnulacionCompletedEventHandler != null)
				{
					insertarMotivoAnulacionCompletedEventHandler(this, new InsertarMotivoAnulacionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarMotivoDiferenciaOperationCompleted(object arg)
		{
			if (this.InsertarMotivoDiferenciaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarMotivoDiferenciaCompletedEventHandler insertarMotivoDiferenciaCompletedEventHandler = this.InsertarMotivoDiferenciaCompleted;
				if (insertarMotivoDiferenciaCompletedEventHandler != null)
				{
					insertarMotivoDiferenciaCompletedEventHandler(this, new InsertarMotivoDiferenciaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarSectoresOperationCompleted(object arg)
		{
			if (this.InsertarSectoresCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarSectoresCompletedEventHandler insertarSectoresCompletedEventHandler = this.InsertarSectoresCompleted;
				if (insertarSectoresCompletedEventHandler != null)
				{
					insertarSectoresCompletedEventHandler(this, new InsertarSectoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarSubdepositoSectorOperationCompleted(object arg)
		{
			if (this.InsertarSubdepositoSectorCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarSubdepositoSectorCompletedEventHandler insertarSubdepositoSectorCompletedEventHandler = this.InsertarSubdepositoSectorCompleted;
				if (insertarSubdepositoSectorCompletedEventHandler != null)
				{
					insertarSubdepositoSectorCompletedEventHandler(this, new InsertarSubdepositoSectorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnInsertarSucursalOperationCompleted(object arg)
		{
			if (this.InsertarSucursalCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				InsertarSucursalCompletedEventHandler insertarSucursalCompletedEventHandler = this.InsertarSucursalCompleted;
				if (insertarSucursalCompletedEventHandler != null)
				{
					insertarSucursalCompletedEventHandler(this, new InsertarSucursalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnNombreActivoOperationCompleted(object arg)
		{
			if (this.NombreActivoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				NombreActivoCompletedEventHandler nombreActivoCompletedEventHandler = this.NombreActivoCompleted;
				if (nombreActivoCompletedEventHandler != null)
				{
					nombreActivoCompletedEventHandler(this, new NombreActivoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnNombreProductoOperationCompleted(object arg)
		{
			if (this.NombreProductoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				NombreProductoCompletedEventHandler nombreProductoCompletedEventHandler = this.NombreProductoCompleted;
				if (nombreProductoCompletedEventHandler != null)
				{
					nombreProductoCompletedEventHandler(this, new NombreProductoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnObtenerConteosOperationCompleted(object arg)
		{
			if (this.ObtenerConteosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ObtenerConteosCompletedEventHandler obtenerConteosCompletedEventHandler = this.ObtenerConteosCompleted;
				if (obtenerConteosCompletedEventHandler != null)
				{
					obtenerConteosCompletedEventHandler(this, new ObtenerConteosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnObtenerDatosConteoOperationCompleted(object arg)
		{
			if (this.ObtenerDatosConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ObtenerDatosConteoCompletedEventHandler obtenerDatosConteoCompletedEventHandler = this.ObtenerDatosConteoCompleted;
				if (obtenerDatosConteoCompletedEventHandler != null)
				{
					obtenerDatosConteoCompletedEventHandler(this, new ObtenerDatosConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnObtenerSectorSubdepositoOperationCompleted(object arg)
		{
			if (this.ObtenerSectorSubdepositoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ObtenerSectorSubdepositoCompletedEventHandler obtenerSectorSubdepositoCompletedEventHandler = this.ObtenerSectorSubdepositoCompleted;
				if (obtenerSectorSubdepositoCompletedEventHandler != null)
				{
					obtenerSectorSubdepositoCompletedEventHandler(this, new ObtenerSectorSubdepositoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnObtenerSubdepositosConteoOperationCompleted(object arg)
		{
			if (this.ObtenerSubdepositosConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ObtenerSubdepositosConteoCompletedEventHandler obtenerSubdepositosConteoCompletedEventHandler = this.ObtenerSubdepositosConteoCompleted;
				if (obtenerSubdepositosConteoCompletedEventHandler != null)
				{
					obtenerSubdepositosConteoCompletedEventHandler(this, new ObtenerSubdepositosConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnObtenerUsuariosOperationCompleted(object arg)
		{
			if (this.ObtenerUsuariosCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ObtenerUsuariosCompletedEventHandler obtenerUsuariosCompletedEventHandler = this.ObtenerUsuariosCompleted;
				if (obtenerUsuariosCompletedEventHandler != null)
				{
					obtenerUsuariosCompletedEventHandler(this, new ObtenerUsuariosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnPapeleriaNoDigitadaOperationCompleted(object arg)
		{
			if (this.PapeleriaNoDigitadaCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				PapeleriaNoDigitadaCompletedEventHandler papeleriaNoDigitadaCompletedEventHandler = this.PapeleriaNoDigitadaCompleted;
				if (papeleriaNoDigitadaCompletedEventHandler != null)
				{
					papeleriaNoDigitadaCompletedEventHandler(this, new PapeleriaNoDigitadaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnProgramarConteoOperationCompleted(object arg)
		{
			if (this.ProgramarConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ProgramarConteoCompletedEventHandler programarConteoCompletedEventHandler = this.ProgramarConteoCompleted;
				if (programarConteoCompletedEventHandler != null)
				{
					programarConteoCompletedEventHandler(this, new ProgramarConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnReprogramarConteoOperationCompleted(object arg)
		{
			if (this.ReprogramarConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				ReprogramarConteoCompletedEventHandler reprogramarConteoCompletedEventHandler = this.ReprogramarConteoCompleted;
				if (reprogramarConteoCompletedEventHandler != null)
				{
					reprogramarConteoCompletedEventHandler(this, new ReprogramarConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnRutasNoRendidasOperationCompleted(object arg)
		{
			if (this.RutasNoRendidasCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				RutasNoRendidasCompletedEventHandler rutasNoRendidasCompletedEventHandler = this.RutasNoRendidasCompleted;
				if (rutasNoRendidasCompletedEventHandler != null)
				{
					rutasNoRendidasCompletedEventHandler(this, new RutasNoRendidasCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnSectoresOperationCompleted(object arg)
		{
			if (this.SectoresCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				SectoresCompletedEventHandler sectoresCompletedEventHandler = this.SectoresCompleted;
				if (sectoresCompletedEventHandler != null)
				{
					sectoresCompletedEventHandler(this, new SectoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		private void OnUltimoConteoOperationCompleted(object arg)
		{
			if (this.UltimoConteoCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				UltimoConteoCompletedEventHandler ultimoConteoCompletedEventHandler = this.UltimoConteoCompleted;
				if (ultimoConteoCompletedEventHandler != null)
				{
					ultimoConteoCompletedEventHandler(this, new UltimoConteoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, RuntimeHelpers.GetObjectValue(invokeArgs.UserState)));
				}
			}
		}

		[SoapDocumentMethod("http://tempuri.org/PapeleriaNoDigitada", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet PapeleriaNoDigitada(string strConnection, int pGrupo, int pEmpid, string pAgencia, int pIdConteo)
		{
			object[] objArray = new object[] { strConnection, pGrupo, pEmpid, pAgencia, pIdConteo };
			return (DataSet)this.Invoke("PapeleriaNoDigitada", objArray)[0];
		}

		/// <remarks />
		public void PapeleriaNoDigitadaAsync(string strConnection, int pGrupo, int pEmpid, string pAgencia, int pIdConteo)
		{
			this.PapeleriaNoDigitadaAsync(strConnection, pGrupo, pEmpid, pAgencia, pIdConteo, null);
		}

		public void PapeleriaNoDigitadaAsync(string strConnection, int pGrupo, int pEmpid, string pAgencia, int pIdConteo, object userState)
		{
			if (this.PapeleriaNoDigitadaOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.PapeleriaNoDigitadaOperationCompleted = new SendOrPostCallback(service.OnPapeleriaNoDigitadaOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, pGrupo, pEmpid, pAgencia, pIdConteo };
			this.InvokeAsync("PapeleriaNoDigitada", objArray, this.PapeleriaNoDigitadaOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ProgramarConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ProgramarConteo(string strConnection, DateTime[] lstFechas, string HoraInicio, string HoraFin, string TipoConteo, int Encargado, bool EnviaCorreo, bool ConFestivos, string Periodicidad, string Usuario, DataSet ds, string[] lstSucursales, bool Confirmacion)
		{
			object[] objArray = new object[] { strConnection, lstFechas, HoraInicio, HoraFin, TipoConteo, Encargado, EnviaCorreo, ConFestivos, Periodicidad, Usuario, ds, lstSucursales, Confirmacion };
			object[] results = this.Invoke("ProgramarConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void ProgramarConteoAsync(string strConnection, DateTime[] lstFechas, string HoraInicio, string HoraFin, string TipoConteo, int Encargado, bool EnviaCorreo, bool ConFestivos, string Periodicidad, string Usuario, DataSet ds, string[] lstSucursales, bool Confirmacion)
		{
			this.ProgramarConteoAsync(strConnection, lstFechas, HoraInicio, HoraFin, TipoConteo, Encargado, EnviaCorreo, ConFestivos, Periodicidad, Usuario, ds, lstSucursales, Confirmacion, null);
		}

		public void ProgramarConteoAsync(string strConnection, DateTime[] lstFechas, string HoraInicio, string HoraFin, string TipoConteo, int Encargado, bool EnviaCorreo, bool ConFestivos, string Periodicidad, string Usuario, DataSet ds, string[] lstSucursales, bool Confirmacion, object userState)
		{
			if (this.ProgramarConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ProgramarConteoOperationCompleted = new SendOrPostCallback(service.OnProgramarConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, lstFechas, HoraInicio, HoraFin, TipoConteo, Encargado, EnviaCorreo, ConFestivos, Periodicidad, Usuario, ds, lstSucursales, Confirmacion };
			this.InvokeAsync("ProgramarConteo", objArray, this.ProgramarConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/ReprogramarConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string ReprogramarConteo(string strConnection, int CodigoConteo, DateTime FechaInicio, string HoraInicio, string HoraFin, string TipoConteo, int Encargado, string Usuario, DataSet dt)
		{
			object[] objArray = new object[] { strConnection, CodigoConteo, FechaInicio, HoraInicio, HoraFin, TipoConteo, Encargado, Usuario, dt };
			object[] results = this.Invoke("ReprogramarConteo", objArray);
			return Conversions.ToString(results[0]);
		}

		/// <remarks />
		public void ReprogramarConteoAsync(string strConnection, int CodigoConteo, DateTime FechaInicio, string HoraInicio, string HoraFin, string TipoConteo, int Encargado, string Usuario, DataSet dt)
		{
			this.ReprogramarConteoAsync(strConnection, CodigoConteo, FechaInicio, HoraInicio, HoraFin, TipoConteo, Encargado, Usuario, dt, null);
		}

		public void ReprogramarConteoAsync(string strConnection, int CodigoConteo, DateTime FechaInicio, string HoraInicio, string HoraFin, string TipoConteo, int Encargado, string Usuario, DataSet dt, object userState)
		{
			if (this.ReprogramarConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.ReprogramarConteoOperationCompleted = new SendOrPostCallback(service.OnReprogramarConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, CodigoConteo, FechaInicio, HoraInicio, HoraFin, TipoConteo, Encargado, Usuario, dt };
			this.InvokeAsync("ReprogramarConteo", objArray, this.ReprogramarConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/RutasNoRendidas", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet RutasNoRendidas(string strConnection, int pGrupo, int pEmpid, string pAgencia, int pIdConteo)
		{
			object[] objArray = new object[] { strConnection, pGrupo, pEmpid, pAgencia, pIdConteo };
			return (DataSet)this.Invoke("RutasNoRendidas", objArray)[0];
		}

		public void RutasNoRendidasAsync(string strConnection, int pGrupo, int pEmpid, string pAgencia, int pIdConteo)
		{
			this.RutasNoRendidasAsync(strConnection, pGrupo, pEmpid, pAgencia, pIdConteo, null);
		}

		/// <remarks />
		public void RutasNoRendidasAsync(string strConnection, int pGrupo, int pEmpid, string pAgencia, int pIdConteo, object userState)
		{
			if (this.RutasNoRendidasOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.RutasNoRendidasOperationCompleted = new SendOrPostCallback(service.OnRutasNoRendidasOperationCompleted);
			}
			object[] objArray = new object[] { strConnection, pGrupo, pEmpid, pAgencia, pIdConteo };
			this.InvokeAsync("RutasNoRendidas", objArray, this.RutasNoRendidasOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		[SoapDocumentMethod("http://tempuri.org/Sectores", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public DataSet Sectores(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			return (DataSet)this.Invoke("Sectores", objArray)[0];
		}

		/// <remarks />
		public void SectoresAsync(string strConnection)
		{
			this.SectoresAsync(strConnection, null);
		}

		public void SectoresAsync(string strConnection, object userState)
		{
			if (this.SectoresOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.SectoresOperationCompleted = new SendOrPostCallback(service.OnSectoresOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("Sectores", objArray, this.SectoresOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		/// <remarks />
		[SoapDocumentMethod("http://tempuri.org/UltimoConteo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public int UltimoConteo(string strConnection)
		{
			object[] objArray = new object[] { strConnection };
			object[] results = this.Invoke("UltimoConteo", objArray);
			return Conversions.ToInteger(results[0]);
		}

		public void UltimoConteoAsync(string strConnection)
		{
			this.UltimoConteoAsync(strConnection, null);
		}

		/// <remarks />
		public void UltimoConteoAsync(string strConnection, object userState)
		{
			if (this.UltimoConteoOperationCompleted == null)
			{
				ControlPaquete.wsPackage.Service service = this;
				this.UltimoConteoOperationCompleted = new SendOrPostCallback(service.OnUltimoConteoOperationCompleted);
			}
			object[] objArray = new object[] { strConnection };
			this.InvokeAsync("UltimoConteo", objArray, this.UltimoConteoOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
		}

		public event AbrirConteoCompletedEventHandler AbrirConteoCompleted;

		/// <remarks />
		public event ActualizarEtiquetaCompletedEventHandler ActualizarEtiquetaCompleted;

		/// <remarks />
		public event ActualizarMotivoAnulacionCompletedEventHandler ActualizarMotivoAnulacionCompleted;

		public event ActualizarMotivoDiferenciaCompletedEventHandler ActualizarMotivoDiferenciaCompleted;

		/// <remarks />
		public event ActualizarSectoresCompletedEventHandler ActualizarSectoresCompleted;

		/// <remarks />
		public event AnularConteoCompletedEventHandler AnularConteoCompleted;

		/// <remarks />
		public event BloquearConteoCompletedEventHandler BloquearConteoCompleted;

		public event BloquearRegistroConteoCompletedEventHandler BloquearRegistroConteoCompleted;

		/// <remarks />
		public event CapacidadesProductoCompletedEventHandler CapacidadesProductoCompleted;

		public event CargarActivoCapacidadCompletedEventHandler CargarActivoCapacidadCompleted;

		public event CargarMotivoAnulacionCompletedEventHandler CargarMotivoAnulacionCompleted;

		/// <remarks />
		public event CargarMotivosDiferenciasCompletedEventHandler CargarMotivosDiferenciasCompleted;

		public event CargarSectoresCompletedEventHandler CargarSectoresCompleted;

		/// <remarks />
		public event CerrarConteoCompletedEventHandler CerrarConteoCompleted;

		public event CerrarPapeleriaCompletedEventHandler CerrarPapeleriaCompleted;

		public event ConsultarConteoCompletedEventHandler ConsultarConteoCompleted;

		public event ConsultarDiferenciasCompletedEventHandler ConsultarDiferenciasCompleted;

		/// <remarks />
		public event ConsultarFestivosCompletedEventHandler ConsultarFestivosCompleted;

		public event ConsultarSubdepositosCompletedEventHandler ConsultarSubdepositosCompleted;

		/// <remarks />
		public event ConsultarSubdepositosConfiguradosCompletedEventHandler ConsultarSubdepositosConfiguradosCompleted;

		/// <remarks />
		public event ConsultarSucursalesCompletedEventHandler ConsultarSucursalesCompleted;

		/// <remarks />
		public event CrearActivosCompletedEventHandler CrearActivosCompleted;

		public event CrearActivosGrillaCompletedEventHandler CrearActivosGrillaCompleted;

		public event CrearCierreCompletedEventHandler CrearCierreCompleted;

		/// <remarks />
		public event CrearEtiquetaCompletedEventHandler CrearEtiquetaCompleted;

		/// <remarks />
		public event CrearMotivoAnulacionCompletedEventHandler CrearMotivoAnulacionCompleted;

		public event CrearMotivoDiferenciaCompletedEventHandler CrearMotivoDiferenciaCompleted;

		/// <remarks />
		public event CrearProductosComboCompletedEventHandler CrearProductosComboCompleted;

		public event CrearProductosGrillaCompletedEventHandler CrearProductosGrillaCompleted;

		/// <remarks />
		public event CrearProgramacionCompletedEventHandler CrearProgramacionCompleted;

		public event CrearSectoresCompletedEventHandler CrearSectoresCompleted;

		/// <remarks />
		public event CrearSectoresSubdepositosCompletedEventHandler CrearSectoresSubdepositosCompleted;

		public event CrearSectorSucursalCompletedEventHandler CrearSectorSucursalCompleted;

		public event CrearSubdepositoSectorCompletedEventHandler CrearSubdepositoSectorCompleted;

		/// <remarks />
		public event CrearSucursalCompletedEventHandler CrearSucursalCompleted;

		/// <remarks />
		public event EliminarSubdepositoSectorCompletedEventHandler EliminarSubdepositoSectorCompleted;

		public event EliminarSucursalCompletedEventHandler EliminarSucursalCompleted;

		public event GenerarFestivosCompletedEventHandler GenerarFestivosCompleted;

		public event GuardarActivosCompletedEventHandler GuardarActivosCompleted;

		/// <remarks />
		public event GuardarActivosPocketCompletedEventHandler GuardarActivosPocketCompleted;

		/// <remarks />
		public event GuardarMixtoCompletedEventHandler GuardarMixtoCompleted;

		public event GuardarProductosCompletedEventHandler GuardarProductosCompleted;

		/// <remarks />
		public event GuardarProductosPocketCompletedEventHandler GuardarProductosPocketCompleted;

		public event HelloWorldCompletedEventHandler HelloWorldCompleted;

		public event IndicadorCuentaCorrienteCompletedEventHandler IndicadorCuentaCorrienteCompleted;

		/// <remarks />
		public event InsertarDiferenciaActivosCompletedEventHandler InsertarDiferenciaActivosCompleted;

		/// <remarks />
		public event InsertarDiferenciaMixtoCompletedEventHandler InsertarDiferenciaMixtoCompleted;

		public event InsertarDiferenciaProductosCompletedEventHandler InsertarDiferenciaProductosCompleted;

		public event InsertarEtiquetaCompletedEventHandler InsertarEtiquetaCompleted;

		public event InsertarMotivoAnulacionCompletedEventHandler InsertarMotivoAnulacionCompleted;

		/// <remarks />
		public event InsertarMotivoDiferenciaCompletedEventHandler InsertarMotivoDiferenciaCompleted;

		public event InsertarSectoresCompletedEventHandler InsertarSectoresCompleted;

		public event InsertarSubdepositoSectorCompletedEventHandler InsertarSubdepositoSectorCompleted;

		/// <remarks />
		public event InsertarSucursalCompletedEventHandler InsertarSucursalCompleted;

		/// <remarks />
		public event NombreActivoCompletedEventHandler NombreActivoCompleted;

		public event NombreProductoCompletedEventHandler NombreProductoCompleted;

		/// <remarks />
		public event ObtenerConteosCompletedEventHandler ObtenerConteosCompleted;

		public event ObtenerDatosConteoCompletedEventHandler ObtenerDatosConteoCompleted;

		public event ObtenerSectorSubdepositoCompletedEventHandler ObtenerSectorSubdepositoCompleted;

		/// <remarks />
		public event ObtenerSubdepositosConteoCompletedEventHandler ObtenerSubdepositosConteoCompleted;

		public event ObtenerUsuariosCompletedEventHandler ObtenerUsuariosCompleted;

		/// <remarks />
		public event PapeleriaNoDigitadaCompletedEventHandler PapeleriaNoDigitadaCompleted;

		/// <remarks />
		public event ProgramarConteoCompletedEventHandler ProgramarConteoCompleted;

		/// <remarks />
		public event ReprogramarConteoCompletedEventHandler ReprogramarConteoCompleted;

		public event RutasNoRendidasCompletedEventHandler RutasNoRendidasCompleted;

		/// <remarks />
		public event SectoresCompletedEventHandler SectoresCompleted;

		public event UltimoConteoCompletedEventHandler UltimoConteoCompleted;
	}
}