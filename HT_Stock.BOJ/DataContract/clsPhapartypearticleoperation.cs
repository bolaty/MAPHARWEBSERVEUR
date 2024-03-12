using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhapartypearticleoperation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TO_CODEOPERATION = "";
		private string _TO_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TO_CODEOPERATION
		{
			get { return _TO_CODEOPERATION; }
			set {  _TO_CODEOPERATION = value; }
		}

		public string TO_LIBELLE
		{
			get { return _TO_LIBELLE; }
			set {  _TO_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypearticleoperation(){}
		public clsPhapartypearticleoperation( string TO_CODEOPERATION,string TO_LIBELLE)
		{
			this.TO_CODEOPERATION = TO_CODEOPERATION;
			this.TO_LIBELLE = TO_LIBELLE;
		}
		public clsPhapartypearticleoperation(clsPhapartypearticleoperation clsPhapartypearticleoperation)
		{
			this.TO_CODEOPERATION = clsPhapartypearticleoperation.TO_CODEOPERATION;
			this.TO_LIBELLE = clsPhapartypearticleoperation.TO_LIBELLE;
		}

		#endregion

	}
}
