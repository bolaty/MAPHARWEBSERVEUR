using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsASDI : clsEntitieBase
    {

        private string _TI_ASDI = "";
		private string _TI_ASDILIBELLE = "";



        public string TI_ASDI
		{
			get { return _TI_ASDI; }
			set { _TI_ASDI = value; }
		}
		public string TI_ASDILIBELLE
		{
			get { return _TI_ASDILIBELLE; }
			set { _TI_ASDILIBELLE = value; }
		}
      


        public clsASDI() {}

        public clsASDI(clsASDI clsASDI)
        {
            TI_ASDI = clsASDI.TI_ASDI;
            TI_ASDILIBELLE = clsASDI.TI_ASDILIBELLE;
        }


    }
}