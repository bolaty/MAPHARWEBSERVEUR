using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsTypeListe : clsEntitieBase
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
      


        public clsTypeListe() {}

        public clsTypeListe(clsTypeListe clsTypeListe)
        {
            RS_CODERUBRIQUE = clsTypeListe.RS_CODERUBRIQUE;
            RS_LIBELLE = clsTypeListe.RS_LIBELLE;
        }


    }
}