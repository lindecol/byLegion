using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ControlPaquete.wsPraxair
{
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	public class MaestraCorreosGeneralCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] results;

		/// <remarks />
		public DataSet Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		internal MaestraCorreosGeneralCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
		{
			this.results = results;
		}
	}
}