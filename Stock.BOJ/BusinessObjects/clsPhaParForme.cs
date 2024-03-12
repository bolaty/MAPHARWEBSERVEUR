using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhaparforme
	{

        private string _FO_CODEFORME = "";
		private string _FO_LIBELLE = "";



        public string FO_CODEFORME
		{
			get { return _FO_CODEFORME; }
			set { _FO_CODEFORME = value; }
		}
		public string FO_LIBELLE
		{
			get { return _FO_LIBELLE; }
			set { _FO_LIBELLE = value; }
		}



        public clsPhaparforme() {} 

		public clsPhaparforme(string FO_CODEFORME,string FO_LIBELLE)
		{
			this.FO_CODEFORME = FO_CODEFORME;
			this.FO_LIBELLE = FO_LIBELLE;
		}

		public clsPhaparforme(clsPhaparforme clsPhaparforme)
		{
			FO_CODEFORME = clsPhaparforme.FO_CODEFORME;
			FO_LIBELLE = clsPhaparforme.FO_LIBELLE;
		}
        }
}