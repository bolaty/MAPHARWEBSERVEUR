using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsSENS : clsEntitieBase
    {

        private string _NO_SENS = "";
		private string _NO_SENSLIBELLE = "";



        public string NO_SENS
		{
			get { return _NO_SENS; }
			set { _NO_SENS = value; }
		}
		public string NO_SENSLIBELLE
		{
			get { return _NO_SENSLIBELLE; }
			set { _NO_SENSLIBELLE = value; }
		}
      


        public clsSENS() {}

        public clsSENS(clsSENS clsSENS)
        {
            NO_SENS = clsSENS.NO_SENS;
            NO_SENSLIBELLE = clsSENS.NO_SENSLIBELLE;
        }


    }
}