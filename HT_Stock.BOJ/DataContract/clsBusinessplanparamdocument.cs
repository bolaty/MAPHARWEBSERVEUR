using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsBusinessplanparamdocument
	{
		#region VARIABLES LOCALES

		private string _PB_CODEDOCUMENT = "";
		private string _PB_LIBELLE = "";
		private int _PB_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string PB_CODEDOCUMENT
		{
			get { return _PB_CODEDOCUMENT; }
			set {  _PB_CODEDOCUMENT = value; }
		}

		public string PB_LIBELLE
		{
			get { return _PB_LIBELLE; }
			set {  _PB_LIBELLE = value; }
		}

		public int PB_NUMEROORDRE
		{
			get { return _PB_NUMEROORDRE; }
			set {  _PB_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamdocument(){}
		public clsBusinessplanparamdocument( string PB_CODEDOCUMENT,string PB_LIBELLE,int PB_NUMEROORDRE)
		{
			this.PB_CODEDOCUMENT = PB_CODEDOCUMENT;
			this.PB_LIBELLE = PB_LIBELLE;
			this.PB_NUMEROORDRE = PB_NUMEROORDRE;
		}
		public clsBusinessplanparamdocument(clsBusinessplanparamdocument clsBusinessplanparamdocument)
		{
			this.PB_CODEDOCUMENT = clsBusinessplanparamdocument.PB_CODEDOCUMENT;
			this.PB_LIBELLE = clsBusinessplanparamdocument.PB_LIBELLE;
			this.PB_NUMEROORDRE = clsBusinessplanparamdocument.PB_NUMEROORDRE;
		}

		#endregion

	}
}
