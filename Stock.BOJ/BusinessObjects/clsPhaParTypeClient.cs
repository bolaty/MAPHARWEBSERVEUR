using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhapartypeclient
	{

        private string _TP_CODETYPECLIENT = "";
		private string _TP_LIBELLE = "";
		private string _TP_DESCRIPTION = "";



        public string TP_CODETYPECLIENT
		{
			get { return _TP_CODETYPECLIENT; }
			set { _TP_CODETYPECLIENT = value; }
		}
		public string TP_LIBELLE
		{
			get { return _TP_LIBELLE; }
			set { _TP_LIBELLE = value; }
		}
		public string TP_DESCRIPTION
		{
			get { return _TP_DESCRIPTION; }
			set { _TP_DESCRIPTION = value; }
		}



        public clsPhapartypeclient() {} 

		public clsPhapartypeclient(string TP_CODETYPECLIENT,string TP_LIBELLE,string TP_DESCRIPTION)
		{
			this.TP_CODETYPECLIENT = TP_CODETYPECLIENT;
			this.TP_LIBELLE = TP_LIBELLE;
			this.TP_DESCRIPTION = TP_DESCRIPTION;
		}

		public clsPhapartypeclient(clsPhapartypeclient clsPhapartypeclient)
		{
			TP_CODETYPECLIENT = clsPhapartypeclient.TP_CODETYPECLIENT;
			TP_LIBELLE = clsPhapartypeclient.TP_LIBELLE;
			TP_DESCRIPTION = clsPhapartypeclient.TP_DESCRIPTION;
		}
        }
}