using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparrayon : clsEntitieBase
    {

        private string _RY_CODERAYON = "";
		private string _RY_LIBELLE = "";



        public string RY_CODERAYON
		{
			get { return _RY_CODERAYON; }
			set { _RY_CODERAYON = value; }
		}
		public string RY_LIBELLE
		{
			get { return _RY_LIBELLE; }
			set { _RY_LIBELLE = value; }
		}



        public clsPhaparrayon() {} 

		public clsPhaparrayon(string RY_CODERAYON,string RY_LIBELLE)
		{
			this.RY_CODERAYON = RY_CODERAYON;
			this.RY_LIBELLE = RY_LIBELLE;
		}

		public clsPhaparrayon(clsPhaparrayon clsPhaparrayon)
		{
			RY_CODERAYON = clsPhaparrayon.RY_CODERAYON;
			RY_LIBELLE = clsPhaparrayon.RY_LIBELLE;
		}


        }
}