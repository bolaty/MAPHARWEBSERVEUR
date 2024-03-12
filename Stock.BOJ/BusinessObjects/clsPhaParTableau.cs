using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhapartableau
	{

        private string _TB_CODETABLEAU = "";
		private string _TB_LIBELLE = "";
		private string _TB_DESCRIPTION = "";



        public string TB_CODETABLEAU
		{
			get { return _TB_CODETABLEAU; }
			set { _TB_CODETABLEAU = value; }
		}
		public string TB_LIBELLE
		{
			get { return _TB_LIBELLE; }
			set { _TB_LIBELLE = value; }
		}
		public string TB_DESCRIPTION
		{
			get { return _TB_DESCRIPTION; }
			set { _TB_DESCRIPTION = value; }
		}



        public clsPhapartableau() {} 

		public clsPhapartableau(string TB_CODETABLEAU,string TB_LIBELLE,string TB_DESCRIPTION)
		{
			this.TB_CODETABLEAU = TB_CODETABLEAU;
			this.TB_LIBELLE = TB_LIBELLE;
			this.TB_DESCRIPTION = TB_DESCRIPTION;
		}

		public clsPhapartableau(clsPhapartableau clsPhapartableau)
		{
			TB_CODETABLEAU = clsPhapartableau.TB_CODETABLEAU;
			TB_LIBELLE = clsPhapartableau.TB_LIBELLE;
			TB_DESCRIPTION = clsPhapartableau.TB_DESCRIPTION;
		}
        }
}