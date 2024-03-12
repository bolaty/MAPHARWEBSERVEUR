using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparcasutilisationtiers
	{
		#region VARIABLES LOCALES

		private string _CU_CODECASUTILISATION = "";
		private string _CU_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string CU_CODECASUTILISATION
		{
			get { return _CU_CODECASUTILISATION; }
			set {  _CU_CODECASUTILISATION = value; }
		}

		public string CU_LIBELLE
		{
			get { return _CU_LIBELLE; }
			set {  _CU_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparcasutilisationtiers(){}
		public clsPhaparcasutilisationtiers( string CU_CODECASUTILISATION,string CU_LIBELLE)
		{
			this.CU_CODECASUTILISATION = CU_CODECASUTILISATION;
			this.CU_LIBELLE = CU_LIBELLE;
		}
		public clsPhaparcasutilisationtiers(clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers)
		{
			this.CU_CODECASUTILISATION = clsPhaparcasutilisationtiers.CU_CODECASUTILISATION;
			this.CU_LIBELLE = clsPhaparcasutilisationtiers.CU_LIBELLE;
		}

		#endregion

	}
}
