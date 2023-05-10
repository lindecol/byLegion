using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ControlPaquete.wsPackage
{
	/// <remarks />
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	public class InsertarDiferenciaActivosCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] results;

		public string Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return Conversions.ToString(this.results[0]);
			}
		}

		internal InsertarDiferenciaActivosCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
		{
			this.results = results;
		}
	}
}