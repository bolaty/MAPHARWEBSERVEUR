using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparcoeficientcout
	{
		#region VARIABLES LOCALES

		private string _CF_CODECOEFICIENT = "";
		private string _NT_CODENATURETIERS = "";
		private double _CF_COUTCOEFICIENT = 0;

		#endregion

		#region ACCESSEURS

		public string CF_CODECOEFICIENT
		{
			get { return _CF_CODECOEFICIENT; }
			set {  _CF_CODECOEFICIENT = value; }
		}

		public string NT_CODENATURETIERS
		{
			get { return _NT_CODENATURETIERS; }
			set {  _NT_CODENATURETIERS = value; }
		}

		public double CF_COUTCOEFICIENT
		{
			get { return _CF_COUTCOEFICIENT; }
			set {  _CF_COUTCOEFICIENT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparcoeficientcout(){}
		public clsCliparcoeficientcout( string CF_CODECOEFICIENT,string NT_CODENATURETIERS,double CF_COUTCOEFICIENT)
		{
			this.CF_CODECOEFICIENT = CF_CODECOEFICIENT;
			this.NT_CODENATURETIERS = NT_CODENATURETIERS;
			this.CF_COUTCOEFICIENT = CF_COUTCOEFICIENT;
		}
		public clsCliparcoeficientcout(clsCliparcoeficientcout clsCliparcoeficientcout)
		{
			this.CF_CODECOEFICIENT = clsCliparcoeficientcout.CF_CODECOEFICIENT;
			this.NT_CODENATURETIERS = clsCliparcoeficientcout.NT_CODENATURETIERS;
			this.CF_COUTCOEFICIENT = clsCliparcoeficientcout.CF_COUTCOEFICIENT;
		}

		#endregion

	}
}
