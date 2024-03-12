using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparenergieauto
	{
		#region VARIABLES LOCALES

		private string _EN_CODEENERGIE = "";
		private string _EN_LIBELLEENERGIE = "";
		private string _EN_ACTIF = "";
		private int _EN_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string EN_CODEENERGIE
		{
			get { return _EN_CODEENERGIE; }
			set {  _EN_CODEENERGIE = value; }
		}

		public string EN_LIBELLEENERGIE
		{
			get { return _EN_LIBELLEENERGIE; }
			set {  _EN_LIBELLEENERGIE = value; }
		}

		public string EN_ACTIF
		{
			get { return _EN_ACTIF; }
			set {  _EN_ACTIF = value; }
		}

		public int EN_NUMEROORDRE
		{
			get { return _EN_NUMEROORDRE; }
			set {  _EN_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparenergieauto(){}
		public clsCtparenergieauto( string EN_CODEENERGIE,string EN_LIBELLEENERGIE,string EN_ACTIF,int EN_NUMEROORDRE)
		{
			this.EN_CODEENERGIE = EN_CODEENERGIE;
			this.EN_LIBELLEENERGIE = EN_LIBELLEENERGIE;
			this.EN_ACTIF = EN_ACTIF;
			this.EN_NUMEROORDRE = EN_NUMEROORDRE;
		}
		public clsCtparenergieauto(clsCtparenergieauto clsCtparenergieauto)
		{
			this.EN_CODEENERGIE = clsCtparenergieauto.EN_CODEENERGIE;
			this.EN_LIBELLEENERGIE = clsCtparenergieauto.EN_LIBELLEENERGIE;
			this.EN_ACTIF = clsCtparenergieauto.EN_ACTIF;
			this.EN_NUMEROORDRE = clsCtparenergieauto.EN_NUMEROORDRE;
		}

		#endregion

	}
}
