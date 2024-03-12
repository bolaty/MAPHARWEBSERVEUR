using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapararticlecompteplancomptable
	{
		#region VARIABLES LOCALES

		private string _TO_CODEOPERATION = "";
		private string _CP_CODEOPERATIONLIBELLECPTE = "";
		private string _AR_CODEARTICLE = "";
		private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
		#endregion

		#region ACCESSEURS

		public string TO_CODEOPERATION
		{
			get { return _TO_CODEOPERATION; }
			set {  _TO_CODEOPERATION = value; }
		}

		public string CP_CODEOPERATIONLIBELLECPTE
		{
			get { return _CP_CODEOPERATIONLIBELLECPTE; }
			set {  _CP_CODEOPERATIONLIBELLECPTE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}
        public string PL_NUMCOMPTE
		{
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsPhapararticlecompteplancomptable(){}
        public clsPhapararticlecompteplancomptable(string TO_CODEOPERATION, string CP_CODEOPERATIONLIBELLECPTE, string AR_CODEARTICLE, string PL_CODENUMCOMPTE, string PL_NUMCOMPTE)
		{
			this.TO_CODEOPERATION = TO_CODEOPERATION;
			this.CP_CODEOPERATIONLIBELLECPTE = CP_CODEOPERATIONLIBELLECPTE;
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.PL_CODENUMCOMPTE = PL_CODENUMCOMPTE;
            this.PL_NUMCOMPTE = PL_NUMCOMPTE;

		}
		public clsPhapararticlecompteplancomptable(clsPhapararticlecompteplancomptable clsPhapararticlecompteplancomptable)
		{
			this.TO_CODEOPERATION = clsPhapararticlecompteplancomptable.TO_CODEOPERATION;
			this.CP_CODEOPERATIONLIBELLECPTE = clsPhapararticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE;
			this.AR_CODEARTICLE = clsPhapararticlecompteplancomptable.AR_CODEARTICLE;
			this.PL_CODENUMCOMPTE = clsPhapararticlecompteplancomptable.PL_CODENUMCOMPTE;
            this.PL_NUMCOMPTE = clsPhapararticlecompteplancomptable.PL_NUMCOMPTE;

		}

		#endregion

	}
}
