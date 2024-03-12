using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparresume
	{
		#region VARIABLES LOCALES

		private string _RE_CODERESUME = "";
		private string _RE_LIBELLERESUME = "";
		private string _RE_ACTIF = "";
		private int _RE_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string RE_CODERESUME
		{
			get { return _RE_CODERESUME; }
			set {  _RE_CODERESUME = value; }
		}

		public string RE_LIBELLERESUME
		{
			get { return _RE_LIBELLERESUME; }
			set {  _RE_LIBELLERESUME = value; }
		}

		public string RE_ACTIF
		{
			get { return _RE_ACTIF; }
			set {  _RE_ACTIF = value; }
		}

		public int RE_NUMEROORDRE
		{
			get { return _RE_NUMEROORDRE; }
			set {  _RE_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparresume(){}
		public clsCtparresume( string RE_CODERESUME,string RE_LIBELLERESUME,string RE_ACTIF,int RE_NUMEROORDRE)
		{
			this.RE_CODERESUME = RE_CODERESUME;
			this.RE_LIBELLERESUME = RE_LIBELLERESUME;
			this.RE_ACTIF = RE_ACTIF;
			this.RE_NUMEROORDRE = RE_NUMEROORDRE;
		}
		public clsCtparresume(clsCtparresume clsCtparresume)
		{
			this.RE_CODERESUME = clsCtparresume.RE_CODERESUME;
			this.RE_LIBELLERESUME = clsCtparresume.RE_LIBELLERESUME;
			this.RE_ACTIF = clsCtparresume.RE_ACTIF;
			this.RE_NUMEROORDRE = clsCtparresume.RE_NUMEROORDRE;
		}

		#endregion

	}
}
