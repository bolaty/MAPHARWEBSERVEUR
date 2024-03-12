using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhaparunite
	{

        private string _UN_CODEUNITE = "";
		private string _UN_LIBELLE = "";
        private string _UN_FLAG = "";

        public string UN_CODEUNITE
		{
			get { return _UN_CODEUNITE; }
			set { _UN_CODEUNITE = value; }
		}
		public string UN_LIBELLE
		{
			get { return _UN_LIBELLE; }
			set { _UN_LIBELLE = value; }
		}

        public string UN_FLAG
        {
            get { return _UN_FLAG; }
            set { _UN_FLAG = value; }
        }

        public clsPhaparunite() {} 

		public clsPhaparunite(string UN_CODEUNITE,string UN_LIBELLE)
		{
			this.UN_CODEUNITE = UN_CODEUNITE;
			this.UN_LIBELLE = UN_LIBELLE;
            this.UN_FLAG = UN_FLAG;


		}

		public clsPhaparunite(clsPhaparunite clsPhaparunite)
		{
			UN_CODEUNITE = clsPhaparunite.UN_CODEUNITE;
			UN_LIBELLE = clsPhaparunite.UN_LIBELLE;
            UN_FLAG = clsPhaparunite.UN_FLAG;


		}
        }
}