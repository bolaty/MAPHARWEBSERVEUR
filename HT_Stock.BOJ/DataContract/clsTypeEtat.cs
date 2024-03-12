using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsTypeEtat : clsEntitieBase
    {

        private string _TE_CODETYPEETAT = "";
		private string _TE_LIBELLETYPEETAT = "";



        public string TE_CODETYPEETAT
		{
			get { return _TE_CODETYPEETAT; }
			set { _TE_CODETYPEETAT = value; }
		}
		public string TE_LIBELLETYPEETAT
		{
			get { return _TE_LIBELLETYPEETAT; }
			set { _TE_LIBELLETYPEETAT = value; }
		}
      


        public clsTypeEtat() {}

        public clsTypeEtat(clsTypeEtat clsTypeEtat)
        {
            TE_CODETYPEETAT = clsTypeEtat.TE_CODETYPEETAT;
            TE_LIBELLETYPEETAT = clsTypeEtat.TE_LIBELLETYPEETAT;
        }


    }
}