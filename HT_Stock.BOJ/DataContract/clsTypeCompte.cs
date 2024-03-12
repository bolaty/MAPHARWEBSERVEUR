using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsTypeCompte : clsEntitieBase
    {

        private string _PL_TYPECOMPTE = "";
		private string _PL_TYPECOMPTELIBELLE = "";



        public string PL_TYPECOMPTE
		{
			get { return _PL_TYPECOMPTE; }
			set { _PL_TYPECOMPTE = value; }
		}
		public string PL_TYPECOMPTELIBELLE
		{
			get { return _PL_TYPECOMPTELIBELLE; }
			set { _PL_TYPECOMPTELIBELLE = value; }
		}
      


        public clsTypeCompte() {}

        public clsTypeCompte(clsTypeCompte clsTypeCompte)
        {
            PL_TYPECOMPTE = clsTypeCompte.PL_TYPECOMPTE;
            PL_TYPECOMPTELIBELLE = clsTypeCompte.PL_TYPECOMPTELIBELLE;
        }


    }
}