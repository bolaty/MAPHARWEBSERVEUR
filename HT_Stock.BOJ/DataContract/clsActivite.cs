using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsActivite : clsEntitieBase
    {

        private string _AC_CODEACTIVITE = "";
		private string _AC_LIBELLE = "";
        private string _AC_NUMEROORDRE = "0";


        public string AC_CODEACTIVITE
		{
			get { return _AC_CODEACTIVITE; }
			set { _AC_CODEACTIVITE = value; }
		}
		public string AC_LIBELLE
		{
			get { return _AC_LIBELLE; }
			set { _AC_LIBELLE = value; }
		}
        public string AC_NUMEROORDRE
		{
            get { return _AC_NUMEROORDRE; }
            set { _AC_NUMEROORDRE = value; }
		}


        public clsActivite() {}

        public clsActivite(string AC_CODEACTIVITE, string AC_LIBELLE, string AC_NUMEROORDRE)
		{
			this.AC_CODEACTIVITE = AC_CODEACTIVITE;
			this.AC_LIBELLE = AC_LIBELLE;
            this.AC_NUMEROORDRE = AC_NUMEROORDRE;

		}

		public clsActivite(clsActivite clsActivite)
		{
			AC_CODEACTIVITE = clsActivite.AC_CODEACTIVITE;
			AC_LIBELLE = clsActivite.AC_LIBELLE;
            AC_NUMEROORDRE = clsActivite.AC_NUMEROORDRE;

		}
        }



}