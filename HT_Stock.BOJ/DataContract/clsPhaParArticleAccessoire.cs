using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhapararticleaccessoire
	{

        private string _AR_CODEARTICLE1 = "";
		private string _AR_CODEARTICLE2 = "";
        private double  _AR_QUANTITE = 0;

        public string AR_CODEARTICLE1
		{
			get { return _AR_CODEARTICLE1; }
			set { _AR_CODEARTICLE1 = value; }
		}
		public string AR_CODEARTICLE2
		{
			get { return _AR_CODEARTICLE2; }
			set { _AR_CODEARTICLE2 = value; }
		}
        public double AR_QUANTITE
		{
            get { return _AR_QUANTITE; }
            set { _AR_QUANTITE = value; }
		}



        public clsPhapararticleaccessoire() {}

        public clsPhapararticleaccessoire(string AR_CODEARTICLE1, string AR_CODEARTICLE2, double AR_QUANTITE)
		{
			this.AR_CODEARTICLE1 = AR_CODEARTICLE1;
			this.AR_CODEARTICLE2 = AR_CODEARTICLE2;
            this.AR_QUANTITE = AR_QUANTITE;
		}

		public clsPhapararticleaccessoire(clsPhapararticleaccessoire clsPhapararticleaccessoire)
		{
			AR_CODEARTICLE1 = clsPhapararticleaccessoire.AR_CODEARTICLE1;
			AR_CODEARTICLE2 = clsPhapararticleaccessoire.AR_CODEARTICLE2;
            AR_QUANTITE = clsPhapararticleaccessoire.AR_QUANTITE;
		}
        }
}