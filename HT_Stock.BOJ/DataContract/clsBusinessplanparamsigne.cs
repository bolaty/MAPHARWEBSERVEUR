using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsBusinessplanparamsigne
	{
		#region VARIABLES LOCALES

		private string _PS_CODESIGNE = "";
		private string _PS_ABREGE = "";
		private string _PS_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PS_CODESIGNE
		{
			get { return _PS_CODESIGNE; }
			set {  _PS_CODESIGNE = value; }
		}

		public string PS_ABREGE
		{
			get { return _PS_ABREGE; }
			set {  _PS_ABREGE = value; }
		}

		public string PS_LIBELLE
		{
			get { return _PS_LIBELLE; }
			set {  _PS_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamsigne(){}
		public clsBusinessplanparamsigne( string PS_CODESIGNE,string PS_ABREGE,string PS_LIBELLE)
		{
			this.PS_CODESIGNE = PS_CODESIGNE;
			this.PS_ABREGE = PS_ABREGE;
			this.PS_LIBELLE = PS_LIBELLE;
		}
		public clsBusinessplanparamsigne(clsBusinessplanparamsigne clsBusinessplanparamsigne)
		{
			this.PS_CODESIGNE = clsBusinessplanparamsigne.PS_CODESIGNE;
			this.PS_ABREGE = clsBusinessplanparamsigne.PS_ABREGE;
			this.PS_LIBELLE = clsBusinessplanparamsigne.PS_LIBELLE;
		}

		#endregion

	}
}
