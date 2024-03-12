using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartypearticleoperationparametre
	{
		#region VARIABLES LOCALES

		private string _TO_CODEOPERATIONPARAMETRE = "";
		private string _TO_CODEOPERATION = "";
		private string _CP_CODEOPERATIONLIBELLECPTE = "";

		#endregion

		#region ACCESSEURS

		public string TO_CODEOPERATIONPARAMETRE
		{
			get { return _TO_CODEOPERATIONPARAMETRE; }
			set {  _TO_CODEOPERATIONPARAMETRE = value; }
		}

		public string TO_CODEOPERATION
		{
			get { return _TO_CODEOPERATION; }
			set {  _TO_CODEOPERATION = value; }
		}

		public string CP_CODEOPERATIONLIBELLECPTE
		{
			get { return _CP_CODEOPERATIONLIBELLECPTE; }
			set {  _CP_CODEOPERATIONLIBELLECPTE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypearticleoperationparametre(){}
		public clsPhapartypearticleoperationparametre( string TO_CODEOPERATIONPARAMETRE,string TO_CODEOPERATION,string CP_CODEOPERATIONLIBELLECPTE)
		{
			this.TO_CODEOPERATIONPARAMETRE = TO_CODEOPERATIONPARAMETRE;
			this.TO_CODEOPERATION = TO_CODEOPERATION;
			this.CP_CODEOPERATIONLIBELLECPTE = CP_CODEOPERATIONLIBELLECPTE;
		}
		public clsPhapartypearticleoperationparametre(clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre)
		{
			this.TO_CODEOPERATIONPARAMETRE = clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE;
			this.TO_CODEOPERATION = clsPhapartypearticleoperationparametre.TO_CODEOPERATION;
			this.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE;
		}

		#endregion

	}
}
