using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsStatutgrandlivre : clsEntitieBase
    {

        private string _ST_STATUTCODE= "";
		private string _ST_STATUTLIBELLE = "";



        public string ST_STATUTCODE
		{
			get { return _ST_STATUTCODE; }
			set { _ST_STATUTCODE= value; }
		}
		public string ST_STATUTLIBELLE
		{
			get { return _ST_STATUTLIBELLE; }
			set { _ST_STATUTLIBELLE = value; }
		}
      


        public clsStatutgrandlivre() {}

        public clsStatutgrandlivre(clsStatutgrandlivre clsStatutgrandlivre)
        {
            ST_STATUTCODE= clsStatutgrandlivre.ST_STATUTCODE;
            ST_STATUTLIBELLE = clsStatutgrandlivre.ST_STATUTLIBELLE;
        }


    }
}