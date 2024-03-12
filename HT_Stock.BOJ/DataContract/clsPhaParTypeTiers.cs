using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhapartypetiers : clsEntitieBase
    {

        private string _TP_CODETYPETIERS = "";
		private string _TP_LIBELLE = "";
		private string _TP_DESCRIPTION = "";
		private string _MG_CODEMODEGESTION = "";
		private string _EC_CODECRAN = "";

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
		public string MG_CODEMODEGESTION
        {
			get { return _MG_CODEMODEGESTION; }
			set { _MG_CODEMODEGESTION = value; }
		}
		public string EC_CODECRAN
        {
			get { return _EC_CODECRAN; }
			set { _EC_CODECRAN = value; }
		}

        public clsPhapartypetiers() {} 


		public clsPhapartypetiers(clsPhapartypetiers clsPhapartypetiers)
		{
			TP_CODETYPETIERS = clsPhapartypetiers.TP_CODETYPETIERS;
			TP_LIBELLE = clsPhapartypetiers.TP_LIBELLE;
			TP_DESCRIPTION = clsPhapartypetiers.TP_DESCRIPTION;
            MG_CODEMODEGESTION = clsPhapartypetiers.MG_CODEMODEGESTION;
            EC_CODECRAN = clsPhapartypetiers.EC_CODECRAN;
		}
        }
}