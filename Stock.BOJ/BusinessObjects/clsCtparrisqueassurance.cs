using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparrisqueassurance
	{
		#region VARIABLES LOCALES

		private string _RQ_CODERISQUE = "";
		private string _RQ_LIBELLERISQUE = "";
		private string _RQ_ACTIF = "";
		private int _RQ_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public string RQ_LIBELLERISQUE
		{
			get { return _RQ_LIBELLERISQUE; }
			set {  _RQ_LIBELLERISQUE = value; }
		}

		public string RQ_ACTIF
		{
			get { return _RQ_ACTIF; }
			set {  _RQ_ACTIF = value; }
		}

		public int RQ_NUMEROORDRE
		{
			get { return _RQ_NUMEROORDRE; }
			set {  _RQ_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparrisqueassurance(){}
		public clsCtparrisqueassurance( string RQ_CODERISQUE,string RQ_LIBELLERISQUE,string RQ_ACTIF,int RQ_NUMEROORDRE)
		{
			this.RQ_CODERISQUE = RQ_CODERISQUE;
			this.RQ_LIBELLERISQUE = RQ_LIBELLERISQUE;
			this.RQ_ACTIF = RQ_ACTIF;
			this.RQ_NUMEROORDRE = RQ_NUMEROORDRE;
		}
		public clsCtparrisqueassurance(clsCtparrisqueassurance clsCtparrisqueassurance)
		{
			this.RQ_CODERISQUE = clsCtparrisqueassurance.RQ_CODERISQUE;
			this.RQ_LIBELLERISQUE = clsCtparrisqueassurance.RQ_LIBELLERISQUE;
			this.RQ_ACTIF = clsCtparrisqueassurance.RQ_ACTIF;
			this.RQ_NUMEROORDRE = clsCtparrisqueassurance.RQ_NUMEROORDRE;
		}

		#endregion

	}
}
