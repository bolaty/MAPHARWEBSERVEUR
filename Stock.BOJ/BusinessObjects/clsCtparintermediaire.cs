using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparintermediaire
	{
		#region VARIABLES LOCALES

		private string _IT_CODEINTERMEDIAIRE = "";
		private string _IT_DENOMMINATION = "";
		private string _IT_ACTIF = "";
		private int _IT_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string IT_CODEINTERMEDIAIRE
		{
			get { return _IT_CODEINTERMEDIAIRE; }
			set {  _IT_CODEINTERMEDIAIRE = value; }
		}

		public string IT_DENOMMINATION
		{
			get { return _IT_DENOMMINATION; }
			set {  _IT_DENOMMINATION = value; }
		}

		public string IT_ACTIF
		{
			get { return _IT_ACTIF; }
			set {  _IT_ACTIF = value; }
		}

		public int IT_NUMEROORDRE
		{
			get { return _IT_NUMEROORDRE; }
			set {  _IT_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparintermediaire(){}
		public clsCtparintermediaire( string IT_CODEINTERMEDIAIRE,string IT_DENOMMINATION,string IT_ACTIF,int IT_NUMEROORDRE)
		{
			this.IT_CODEINTERMEDIAIRE = IT_CODEINTERMEDIAIRE;
			this.IT_DENOMMINATION = IT_DENOMMINATION;
			this.IT_ACTIF = IT_ACTIF;
			this.IT_NUMEROORDRE = IT_NUMEROORDRE;
		}
		public clsCtparintermediaire(clsCtparintermediaire clsCtparintermediaire)
		{
			this.IT_CODEINTERMEDIAIRE = clsCtparintermediaire.IT_CODEINTERMEDIAIRE;
			this.IT_DENOMMINATION = clsCtparintermediaire.IT_DENOMMINATION;
			this.IT_ACTIF = clsCtparintermediaire.IT_ACTIF;
			this.IT_NUMEROORDRE = clsCtparintermediaire.IT_NUMEROORDRE;
		}

		#endregion

	}
}
