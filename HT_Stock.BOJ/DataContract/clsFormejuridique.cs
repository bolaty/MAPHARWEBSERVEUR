using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsFormejuridique
	{

        private string _FM_CODEFORMEJURIDIQUE = "";
		private string _FM_FORMEJURIDIQUECODE = "";
		private string _FM_LIBELLE = "";



        public string FM_CODEFORMEJURIDIQUE
		{
			get { return _FM_CODEFORMEJURIDIQUE; }
			set { _FM_CODEFORMEJURIDIQUE = value; }
		}
		public string FM_FORMEJURIDIQUECODE
		{
			get { return _FM_FORMEJURIDIQUECODE; }
			set { _FM_FORMEJURIDIQUECODE = value; }
		}
		public string FM_LIBELLE
		{
			get { return _FM_LIBELLE; }
			set { _FM_LIBELLE = value; }
		}



        public clsFormejuridique() {} 

		public clsFormejuridique(string FM_CODEFORMEJURIDIQUE,string FM_FORMEJURIDIQUECODE,string FM_LIBELLE)
		{
			this.FM_CODEFORMEJURIDIQUE = FM_CODEFORMEJURIDIQUE;
			this.FM_FORMEJURIDIQUECODE = FM_FORMEJURIDIQUECODE;
			this.FM_LIBELLE = FM_LIBELLE;
		}

		public clsFormejuridique(clsFormejuridique clsFormejuridique)
		{
			FM_CODEFORMEJURIDIQUE = clsFormejuridique.FM_CODEFORMEJURIDIQUE;
			FM_FORMEJURIDIQUECODE = clsFormejuridique.FM_FORMEJURIDIQUECODE;
			FM_LIBELLE = clsFormejuridique.FM_LIBELLE;
		}
        }
}