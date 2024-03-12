using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsOption : clsEntitieBase
    {

        private string _RS_CODERUBRIQUE = "";
		private string _RS_LIBELLE = "";

        public string RS_CODERUBRIQUE
        {
			get { return _RS_CODERUBRIQUE; }
			set { _RS_CODERUBRIQUE = value; }
		}
		public string RS_LIBELLE
		{
			get { return _RS_LIBELLE; }
			set { _RS_LIBELLE = value; }
		}
      


        public clsOption() {}

        public clsOption(clsOption clsOption)
        {
            RS_CODERUBRIQUE = clsOption.RS_CODERUBRIQUE;
            RS_LIBELLE = clsOption.RS_LIBELLE;
        }


    }
}