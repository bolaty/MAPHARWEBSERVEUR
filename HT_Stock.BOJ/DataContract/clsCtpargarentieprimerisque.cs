using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtpargarentieprimerisque : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _GR_CODEGARENTIEPRIME = "";
		private string _RQ_CODERISQUE = "";
        private string _GR_LIBELLEGARENTIEPRIME = "";

        #endregion

        #region ACCESSEURS

        public string GR_CODEGARENTIEPRIME
		{
			get { return _GR_CODEGARENTIEPRIME; }
			set {  _GR_CODEGARENTIEPRIME = value; }
		}

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

        public string GR_LIBELLEGARENTIEPRIME
        {
            get { return _GR_LIBELLEGARENTIEPRIME; }
            set { _GR_LIBELLEGARENTIEPRIME = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsCtpargarentieprimerisque(){}

		public clsCtpargarentieprimerisque(clsCtpargarentieprimerisque clsCtpargarentieprimerisque)
		{
			this.GR_CODEGARENTIEPRIME = clsCtpargarentieprimerisque.GR_CODEGARENTIEPRIME;
			this.RQ_CODERISQUE = clsCtpargarentieprimerisque.RQ_CODERISQUE;
            this.GR_LIBELLEGARENTIEPRIME = clsCtpargarentieprimerisque.GR_LIBELLEGARENTIEPRIME;
        }

		#endregion

	}
}
