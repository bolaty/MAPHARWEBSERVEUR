using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhainput
	{
		#region VARIABLES LOCALES

		private string _IN_CODETYPEARTICLE = "";
		private string _IN_LIBELLE = "";
		private int _IN_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string IN_CODETYPEARTICLE
		{
			get { return _IN_CODETYPEARTICLE; }
			set {  _IN_CODETYPEARTICLE = value; }
		}

		public string IN_LIBELLE
		{
			get { return _IN_LIBELLE; }
			set {  _IN_LIBELLE = value; }
		}

		public int IN_NUMEROORDRE
		{
			get { return _IN_NUMEROORDRE; }
			set {  _IN_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhainput(){}
		public clsPhainput( string IN_CODETYPEARTICLE,string IN_LIBELLE,int IN_NUMEROORDRE)
		{
			this.IN_CODETYPEARTICLE = IN_CODETYPEARTICLE;
			this.IN_LIBELLE = IN_LIBELLE;
			this.IN_NUMEROORDRE = IN_NUMEROORDRE;
		}
		public clsPhainput(clsPhainput clsPhainput)
		{
			this.IN_CODETYPEARTICLE = clsPhainput.IN_CODETYPEARTICLE;
			this.IN_LIBELLE = clsPhainput.IN_LIBELLE;
			this.IN_NUMEROORDRE = clsPhainput.IN_NUMEROORDRE;
		}

		#endregion

	}
}
