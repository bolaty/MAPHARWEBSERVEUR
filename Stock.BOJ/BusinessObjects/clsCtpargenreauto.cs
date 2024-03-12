using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpargenreauto
	{
		#region VARIABLES LOCALES

		private string _GE_CODEGENRE = "";
		private string _GE_LIBELLEGENRE = "";
		private string _GE_ACTIF = "";
		private int _GE_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string GE_CODEGENRE
		{
			get { return _GE_CODEGENRE; }
			set {  _GE_CODEGENRE = value; }
		}

		public string GE_LIBELLEGENRE
		{
			get { return _GE_LIBELLEGENRE; }
			set {  _GE_LIBELLEGENRE = value; }
		}

		public string GE_ACTIF
		{
			get { return _GE_ACTIF; }
			set {  _GE_ACTIF = value; }
		}

		public int GE_NUMEROORDRE
		{
			get { return _GE_NUMEROORDRE; }
			set {  _GE_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpargenreauto(){}
		public clsCtpargenreauto( string GE_CODEGENRE,string GE_LIBELLEGENRE,string GE_ACTIF,int GE_NUMEROORDRE)
		{
			this.GE_CODEGENRE = GE_CODEGENRE;
			this.GE_LIBELLEGENRE = GE_LIBELLEGENRE;
			this.GE_ACTIF = GE_ACTIF;
			this.GE_NUMEROORDRE = GE_NUMEROORDRE;
		}
		public clsCtpargenreauto(clsCtpargenreauto clsCtpargenreauto)
		{
			this.GE_CODEGENRE = clsCtpargenreauto.GE_CODEGENRE;
			this.GE_LIBELLEGENRE = clsCtpargenreauto.GE_LIBELLEGENRE;
			this.GE_ACTIF = clsCtpargenreauto.GE_ACTIF;
			this.GE_NUMEROORDRE = clsCtpargenreauto.GE_NUMEROORDRE;
		}

		#endregion

	}
}
