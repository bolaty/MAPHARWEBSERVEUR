using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsStatutCompte : clsEntitieBase
    {

        private string _PL_ACTIF = "";
		private string _PL_ACTIFLIBELLE = "";



        public string PL_ACTIF
		{
			get { return _PL_ACTIF; }
			set { _PL_ACTIF = value; }
		}
		public string PL_ACTIFLIBELLE
		{
			get { return _PL_ACTIFLIBELLE; }
			set { _PL_ACTIFLIBELLE = value; }
		}
      


        public clsStatutCompte() {}

        public clsStatutCompte(clsStatutCompte clsStatutCompte)
        {
            PL_ACTIF = clsStatutCompte.PL_ACTIF;
            PL_ACTIFLIBELLE = clsStatutCompte.PL_ACTIFLIBELLE;
        }


    }
}