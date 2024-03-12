using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsTVA : clsEntitieBase
    {

        private string _TI_TVA = "";
		private string _TI_TVALIBELLE = "";



        public string TI_TVA
		{
			get { return _TI_TVA; }
			set { _TI_TVA = value; }
		}
		public string TI_TVALIBELLE
		{
			get { return _TI_TVALIBELLE; }
			set { _TI_TVALIBELLE = value; }
		}
      


        public clsTVA() {}

        public clsTVA(clsTVA clsTVA)
        {
            TI_TVA = clsTVA.TI_TVA;
            TI_TVALIBELLE = clsTVA.TI_TVALIBELLE;
        }


    }
}