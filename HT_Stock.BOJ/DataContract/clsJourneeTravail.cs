using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsJourneetravail : clsEntitieBase
    {

        private string _AG_CODEAGENCE = "";
		private string _JT_DATEJOURNEETRAVAIL = "";
		private string _JT_STATUT = "";
		private string _OP_CODEOPERATEUR = "";
		private string _EX_EXERCICE = "";


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string JT_DATEJOURNEETRAVAIL
		{
			get { return _JT_DATEJOURNEETRAVAIL; }
			set { _JT_DATEJOURNEETRAVAIL = value; }
		}
		public string JT_STATUT
		{
			get { return _JT_STATUT; }
			set { _JT_STATUT = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
        public string EX_EXERCICE
        {
	        get { return _EX_EXERCICE; }
	        set { _EX_EXERCICE = value; }
        }


        public clsJourneetravail() {} 



		public clsJourneetravail(clsJourneetravail clsJourneetravail)
		{
			AG_CODEAGENCE = clsJourneetravail.AG_CODEAGENCE;
			JT_DATEJOURNEETRAVAIL = clsJourneetravail.JT_DATEJOURNEETRAVAIL;
			JT_STATUT = clsJourneetravail.JT_STATUT;
			OP_CODEOPERATEUR = clsJourneetravail.OP_CODEOPERATEUR;
            EX_EXERCICE = clsJourneetravail.EX_EXERCICE;

		}
        }
}