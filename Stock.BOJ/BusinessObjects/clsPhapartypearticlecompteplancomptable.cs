using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartypearticlecompteplancomptable
	{
		#region VARIABLES LOCALES

		private string _TA_CODETYPEARTICLE = "";
		private string _TO_CODEOPERATIONPARAMETRE = "";
		private double _PL_CODENUMCOMPTE = 0;
        private string _PL_NUMCOMPTE = "";
        private string _TO_CODEOPERATION = "";
        private string _CP_CODEOPERATIONLIBELLECPTE = "";
        private int _TYPEOPERATION = 0;
		#endregion

		#region ACCESSEURS

		public string TA_CODETYPEARTICLE
		{
			get { return _TA_CODETYPEARTICLE; }
			set {  _TA_CODETYPEARTICLE = value; }
		}

		public string TO_CODEOPERATIONPARAMETRE
		{
			get { return _TO_CODEOPERATIONPARAMETRE; }
			set {  _TO_CODEOPERATIONPARAMETRE = value; }
		}

		public double PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}
        public string PL_NUMCOMPTE
    {
        get { return _PL_NUMCOMPTE; }
        set { _PL_NUMCOMPTE = value; }
    }
        public string TO_CODEOPERATION
    {
        get { return _TO_CODEOPERATION; }
        set { _TO_CODEOPERATION = value; }
    }
    public string CP_CODEOPERATIONLIBELLECPTE
    {
    get { return _CP_CODEOPERATIONLIBELLECPTE; }
    set { _CP_CODEOPERATIONLIBELLECPTE = value; }
    }

    public int TYPEOPERATION
    {
        get { return _TYPEOPERATION; }
        set { _TYPEOPERATION = value; }
    }


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypearticlecompteplancomptable(){}
		
		public clsPhapartypearticlecompteplancomptable(clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable)
		{
			this.TA_CODETYPEARTICLE = clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE;
			this.TO_CODEOPERATIONPARAMETRE = clsPhapartypearticlecompteplancomptable.TO_CODEOPERATIONPARAMETRE;
			this.PL_CODENUMCOMPTE = clsPhapartypearticlecompteplancomptable.PL_CODENUMCOMPTE;
            this.PL_NUMCOMPTE = clsPhapartypearticlecompteplancomptable.PL_NUMCOMPTE;
            this.TO_CODEOPERATION = clsPhapartypearticlecompteplancomptable.TO_CODEOPERATION;
            this.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE;
            this.TYPEOPERATION = clsPhapartypearticlecompteplancomptable.TYPEOPERATION;

		}

		#endregion

	}
}
