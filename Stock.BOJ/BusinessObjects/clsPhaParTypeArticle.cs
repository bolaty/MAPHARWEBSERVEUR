using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhapartypearticle
	{

        private string _TA_CODETYPEARTICLE = "";
		private string _TA_LIBELLE = "";
        private string _NT_CODENATURETYPEARTICLE = "";


        public string TA_CODETYPEARTICLE
		{
			get { return _TA_CODETYPEARTICLE; }
			set { _TA_CODETYPEARTICLE = value; }
		}
		public string TA_LIBELLE
		{
			get { return _TA_LIBELLE; }
			set { _TA_LIBELLE = value; }
		}
        public string NT_CODENATURETYPEARTICLE
		{
            get { return _NT_CODENATURETYPEARTICLE; }
            set { _NT_CODENATURETYPEARTICLE = value; }
		}


        public clsPhapartypearticle() {} 

		public clsPhapartypearticle(string TA_CODETYPEARTICLE,string TA_LIBELLE)
		{
			this.TA_CODETYPEARTICLE = TA_CODETYPEARTICLE;
			this.TA_LIBELLE = TA_LIBELLE;
            this.NT_CODENATURETYPEARTICLE = NT_CODENATURETYPEARTICLE;
		}

		public clsPhapartypearticle(clsPhapartypearticle clsPhapartypearticle)
		{
			TA_CODETYPEARTICLE = clsPhapartypearticle.TA_CODETYPEARTICLE;
            TA_LIBELLE = clsPhapartypearticle.TA_LIBELLE;
            NT_CODENATURETYPEARTICLE = clsPhapartypearticle.NT_CODENATURETYPEARTICLE;
		}
        }
}