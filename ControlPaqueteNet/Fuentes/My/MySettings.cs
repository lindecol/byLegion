using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ControlPaquete.My
{
	[CompilerGenerated]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
	internal sealed class MySettings : ApplicationSettingsBase
	{
		private static MySettings defaultInstance;

		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("http://localhost:1766/WsControlPaquete/Service.asmx")]
		[SpecialSetting(SpecialSetting.WebServiceUrl)]
		public string ControlPaquete_wsPackage_Package
		{
			get
			{
				return Conversions.ToString(this["ControlPaquete_wsPackage_Package"]);
			}
		}

		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("http://10.104.8.6/WsPraxair/Service.asmx")]
		[SpecialSetting(SpecialSetting.WebServiceUrl)]
		public string ControlPaquete_wsPraxair_Service
		{
			get
			{
				return Conversions.ToString(this["ControlPaquete_wsPraxair_Service"]);
			}
		}

		public static MySettings Default
		{
			get
			{
				return MySettings.defaultInstance;
			}
		}

		static MySettings()
		{
			MySettings.defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
		}

		[DebuggerNonUserCode]
		public MySettings()
		{
		}
	}
}