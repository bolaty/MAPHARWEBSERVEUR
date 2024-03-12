using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpargarentieprime
	{
		#region VARIABLES LOCALES

		private string _GR_CODEGARENTIEPRIME = "";
		private string _GR_LIBELLEGARENTIEPRIME = "";
		private string _GR_ACTIFPRIME = "";
		private int _GR_NUMEROORDREPRIME = 0;

		#endregion

		#region ACCESSEURS

		public string GR_CODEGARENTIEPRIME
		{
			get { return _GR_CODEGARENTIEPRIME; }
			set {  _GR_CODEGARENTIEPRIME = value; }
		}

		public string GR_LIBELLEGARENTIEPRIME
		{
			get { return _GR_LIBELLEGARENTIEPRIME; }
			set {  _GR_LIBELLEGARENTIEPRIME = value; }
		}

		public string GR_ACTIFPRIME
		{
			get { return _GR_ACTIFPRIME; }
			set {  _GR_ACTIFPRIME = value; }
		}

		public int GR_NUMEROORDREPRIME
		{
			get { return _GR_NUMEROORDREPRIME; }
			set {  _GR_NUMEROORDREPRIME = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpargarentieprime(){}
		public clsCtpargarentieprime( string GR_CODEGARENTIEPRIME,string GR_LIBELLEGARENTIEPRIME,string GR_ACTIFPRIME,int GR_NUMEROORDREPRIME)
		{
			this.GR_CODEGARENTIEPRIME = GR_CODEGARENTIEPRIME;
			this.GR_LIBELLEGARENTIEPRIME = GR_LIBELLEGARENTIEPRIME;
			this.GR_ACTIFPRIME = GR_ACTIFPRIME;
			this.GR_NUMEROORDREPRIME = GR_NUMEROORDREPRIME;
		}
		public clsCtpargarentieprime(clsCtpargarentieprime clsCtpargarentieprime)
		{
			this.GR_CODEGARENTIEPRIME = clsCtpargarentieprime.GR_CODEGARENTIEPRIME;
			this.GR_LIBELLEGARENTIEPRIME = clsCtpargarentieprime.GR_LIBELLEGARENTIEPRIME;
			this.GR_ACTIFPRIME = clsCtpargarentieprime.GR_ACTIFPRIME;
			this.GR_NUMEROORDREPRIME = clsCtpargarentieprime.GR_NUMEROORDREPRIME;
		}

		#endregion

	}
}
