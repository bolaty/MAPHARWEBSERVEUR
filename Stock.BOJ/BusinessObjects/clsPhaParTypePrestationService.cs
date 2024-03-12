using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhapartypeprestationservice
	{

        private string _TP_CODETYPEPRESTATION = "";
		private string _TP_LIBELLE = "";



        public string TP_CODETYPEPRESTATION
		{
			get { return _TP_CODETYPEPRESTATION; }
			set { _TP_CODETYPEPRESTATION = value; }
		}
		public string TP_LIBELLE
		{
			get { return _TP_LIBELLE; }
			set { _TP_LIBELLE = value; }
		}



        public clsPhapartypeprestationservice() {} 

		public clsPhapartypeprestationservice(string TP_CODETYPEPRESTATION,string TP_LIBELLE)
		{
			this.TP_CODETYPEPRESTATION = TP_CODETYPEPRESTATION;
			this.TP_LIBELLE = TP_LIBELLE;
		}

		public clsPhapartypeprestationservice(clsPhapartypeprestationservice clsPhapartypeprestationservice)
		{
			TP_CODETYPEPRESTATION = clsPhapartypeprestationservice.TP_CODETYPEPRESTATION;
			TP_LIBELLE = clsPhapartypeprestationservice.TP_LIBELLE;
		}
        }
}