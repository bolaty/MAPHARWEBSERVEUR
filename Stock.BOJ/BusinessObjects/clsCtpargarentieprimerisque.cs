using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpargarentieprimerisque
	{
		#region VARIABLES LOCALES

		private string _GR_CODEGARENTIEPRIME = "";
		private string _RQ_CODERISQUE = "";

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


		#endregion

		#region INSTANCIATEURS

		public clsCtpargarentieprimerisque(){}
		public clsCtpargarentieprimerisque( string GR_CODEGARENTIEPRIME,string RQ_CODERISQUE)
		{
			this.GR_CODEGARENTIEPRIME = GR_CODEGARENTIEPRIME;
			this.RQ_CODERISQUE = RQ_CODERISQUE;
		}
		public clsCtpargarentieprimerisque(clsCtpargarentieprimerisque clsCtpargarentieprimerisque)
		{
			this.GR_CODEGARENTIEPRIME = clsCtpargarentieprimerisque.GR_CODEGARENTIEPRIME;
			this.RQ_CODERISQUE = clsCtpargarentieprimerisque.RQ_CODERISQUE;
		}

		#endregion

	}
}
