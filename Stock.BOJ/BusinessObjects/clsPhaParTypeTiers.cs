using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhapartypetiers
	{

        private string _TP_CODETYPETIERS = "";
		private string _TP_LIBELLE = "";
		private string _TP_DESCRIPTION = "";



        public string TP_CODETYPETIERS
		{
			get { return _TP_CODETYPETIERS; }
			set { _TP_CODETYPETIERS = value; }
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



        public clsPhapartypetiers() {} 

		public clsPhapartypetiers(string TP_CODETYPETIERS,string TP_LIBELLE,string TP_DESCRIPTION)
		{
			this.TP_CODETYPETIERS = TP_CODETYPETIERS;
			this.TP_LIBELLE = TP_LIBELLE;
			this.TP_DESCRIPTION = TP_DESCRIPTION;
		}

		public clsPhapartypetiers(clsPhapartypetiers clsPhapartypetiers)
		{
			TP_CODETYPETIERS = clsPhapartypetiers.TP_CODETYPETIERS;
			TP_LIBELLE = clsPhapartypetiers.TP_LIBELLE;
			TP_DESCRIPTION = clsPhapartypetiers.TP_DESCRIPTION;
		}
        }
}