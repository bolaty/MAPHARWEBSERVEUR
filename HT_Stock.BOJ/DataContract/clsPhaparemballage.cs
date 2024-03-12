using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparemballage
	{
		#region VARIABLES LOCALES

		private string _EM_CODEEMBALLAGE = "";
		private string _EM_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string EM_CODEEMBALLAGE
		{
			get { return _EM_CODEEMBALLAGE; }
			set {  _EM_CODEEMBALLAGE = value; }
		}

		public string EM_LIBELLE
		{
			get { return _EM_LIBELLE; }
			set {  _EM_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparemballage(){}
		public clsPhaparemballage( string EM_CODEEMBALLAGE,string EM_LIBELLE)
		{
			this.EM_CODEEMBALLAGE = EM_CODEEMBALLAGE;
			this.EM_LIBELLE = EM_LIBELLE;
		}
		public clsPhaparemballage(clsPhaparemballage clsPhaparemballage)
		{
			this.EM_CODEEMBALLAGE = clsPhaparemballage.EM_CODEEMBALLAGE;
			this.EM_LIBELLE = clsPhaparemballage.EM_LIBELLE;
		}

		#endregion

	}
}
