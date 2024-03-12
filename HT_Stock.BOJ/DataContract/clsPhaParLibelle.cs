using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparlibelle
	{

        private string _PL_CODEPARAMETRE = "";
		private string _PL_LIBELLE = "";
		private string _PL_ECRAN = "";
		private string _PL_TABLE = "";
		private string _PL_CHAMPS = "";



        public string PL_CODEPARAMETRE
		{
			get { return _PL_CODEPARAMETRE; }
			set { _PL_CODEPARAMETRE = value; }
		}
		public string PL_LIBELLE
		{
			get { return _PL_LIBELLE; }
			set { _PL_LIBELLE = value; }
		}
		public string PL_ECRAN
		{
			get { return _PL_ECRAN; }
			set { _PL_ECRAN = value; }
		}
		public string PL_TABLE
		{
			get { return _PL_TABLE; }
			set { _PL_TABLE = value; }
		}
		public string PL_CHAMPS
		{
			get { return _PL_CHAMPS; }
			set { _PL_CHAMPS = value; }
		}



        public clsPhaparlibelle() {} 

		public clsPhaparlibelle(string PL_CODEPARAMETRE,string PL_LIBELLE,string PL_ECRAN,string PL_TABLE,string PL_CHAMPS)
		{
			this.PL_CODEPARAMETRE = PL_CODEPARAMETRE;
			this.PL_LIBELLE = PL_LIBELLE;
			this.PL_ECRAN = PL_ECRAN;
			this.PL_TABLE = PL_TABLE;
			this.PL_CHAMPS = PL_CHAMPS;
		}

		public clsPhaparlibelle(clsPhaparlibelle clsPhaparlibelle)
		{
			PL_CODEPARAMETRE = clsPhaparlibelle.PL_CODEPARAMETRE;
			PL_LIBELLE = clsPhaparlibelle.PL_LIBELLE;
			PL_ECRAN = clsPhaparlibelle.PL_ECRAN;
			PL_TABLE = clsPhaparlibelle.PL_TABLE;
			PL_CHAMPS = clsPhaparlibelle.PL_CHAMPS;
		}
        }
}