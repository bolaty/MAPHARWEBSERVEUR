using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsProfilweb : clsEntitieBase
    {

        private string _PO_CODEPROFILWEB = "";
		private string _PO_LIBELLE = "";



        public string PO_CODEPROFILWEB
		{
			get { return _PO_CODEPROFILWEB; }
			set { _PO_CODEPROFILWEB = value; }
		}
		public string PO_LIBELLE
		{
			get { return _PO_LIBELLE; }
			set { _PO_LIBELLE = value; }
		}



        public clsProfilweb() {} 

		public clsProfilweb(string PO_CODEPROFILWEB,string PO_LIBELLE)
		{
			this.PO_CODEPROFILWEB = PO_CODEPROFILWEB;
			this.PO_LIBELLE = PO_LIBELLE;
		}

		public clsProfilweb(clsProfilweb clsProfilweb)
		{
			PO_CODEPROFILWEB = clsProfilweb.PO_CODEPROFILWEB;
			PO_LIBELLE = clsProfilweb.PO_LIBELLE;
		}
        }
}