using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ControlPaquete.wsPackage
{
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	public class UltimoConteoCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] results;

		/// <remarks />
		public int Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return Conversions.ToInteger(this.results[0]);
			}
		}

		internal UltimoConteoCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
		{
			this.results = results;
		}
	}
}