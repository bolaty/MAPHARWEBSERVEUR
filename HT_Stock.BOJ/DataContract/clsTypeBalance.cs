using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsTypeBalance : clsEntitieBase
    {

        private string _TB_CODETYPEBALANCE = "";
		private string _TB_TYPEBALANCELIBELLE = "";



        public string TB_CODETYPEBALANCE
		{
			get { return _TB_CODETYPEBALANCE; }
			set { _TB_CODETYPEBALANCE = value; }
		}
		public string TB_TYPEBALANCELIBELLE
		{
			get { return _TB_TYPEBALANCELIBELLE; }
			set { _TB_TYPEBALANCELIBELLE = value; }
		}
      


        public clsTypeBalance() {}

        public clsTypeBalance(clsTypeBalance clsTypeBalance)
        {
            TB_CODETYPEBALANCE = clsTypeBalance.TB_CODETYPEBALANCE;
            TB_TYPEBALANCELIBELLE = clsTypeBalance.TB_TYPEBALANCELIBELLE;
        }


    }
}