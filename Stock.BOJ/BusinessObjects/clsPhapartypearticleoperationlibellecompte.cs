using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartypearticleoperationlibellecompte
	{
		#region VARIABLES LOCALES

		private string _CP_CODEOPERATIONLIBELLECPTE = "";
		private string _CP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string CP_CODEOPERATIONLIBELLECPTE
		{
			get { return _CP_CODEOPERATIONLIBELLECPTE; }
			set {  _CP_CODEOPERATIONLIBELLECPTE = value; }
		}

		public string CP_LIBELLE
		{
			get { return _CP_LIBELLE; }
			set {  _CP_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypearticleoperationlibellecompte(){}
		public clsPhapartypearticleoperationlibellecompte( string CP_CODEOPERATIONLIBELLECPTE,string CP_LIBELLE)
		{
			this.CP_CODEOPERATIONLIBELLECPTE = CP_CODEOPERATIONLIBELLECPTE;
			this.CP_LIBELLE = CP_LIBELLE;
		}
		public clsPhapartypearticleoperationlibellecompte(clsPhapartypearticleoperationlibellecompte clsPhapartypearticleoperationlibellecompte)
		{
			this.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticleoperationlibellecompte.CP_CODEOPERATIONLIBELLECPTE;
			this.CP_LIBELLE = clsPhapartypearticleoperationlibellecompte.CP_LIBELLE;
		}

		#endregion

	}
}
