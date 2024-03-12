using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsClientexoneretaxe : clsEntitieBase
    {

        private string _CA_CLIENTEXONERETAXE = "";
		private string _CA_CLIENTEXONERETAXELIBELLE = "";



        public string CA_CLIENTEXONERETAXE
		{
			get { return _CA_CLIENTEXONERETAXE; }
			set { _CA_CLIENTEXONERETAXE = value; }
		}
		public string CA_CLIENTEXONERETAXELIBELLE
		{
			get { return _CA_CLIENTEXONERETAXELIBELLE; }
			set { _CA_CLIENTEXONERETAXELIBELLE = value; }
		}
      


        public clsClientexoneretaxe() {}

        public clsClientexoneretaxe(clsClientexoneretaxe clsClientexoneretaxe)
        {
            CA_CLIENTEXONERETAXE = clsClientexoneretaxe.CA_CLIENTEXONERETAXE;
            CA_CLIENTEXONERETAXELIBELLE = clsClientexoneretaxe.CA_CLIENTEXONERETAXELIBELLE;
        }


    }
}