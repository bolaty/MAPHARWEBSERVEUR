using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsProfil
	{

        private string _PO_CODEPROFIL = "";
		private string _PO_LIBELLE = "";



        public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set { _PO_CODEPROFIL = value; }
		}
		public string PO_LIBELLE
		{
			get { return _PO_LIBELLE; }
			set { _PO_LIBELLE = value; }
		}



        public clsProfil() {} 

		public clsProfil(string PO_CODEPROFIL,string PO_LIBELLE)
		{
			this.PO_CODEPROFIL = PO_CODEPROFIL;
			this.PO_LIBELLE = PO_LIBELLE;
		}

		public clsProfil(clsProfil clsProfil)
		{
			PO_CODEPROFIL = clsProfil.PO_CODEPROFIL;
			PO_LIBELLE = clsProfil.PO_LIBELLE;
		}
        }
}