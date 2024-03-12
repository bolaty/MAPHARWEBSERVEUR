using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhapartypearticlecompteplancomptablemodel : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CP_CODEOPERATIONLIBELLECPTE = "";
		private string _TO_CODEOPERATIONPARAMETRE = "";
		private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
		#endregion

		#region ACCESSEURS

		public string CP_CODEOPERATIONLIBELLECPTE
		{
			get { return _CP_CODEOPERATIONLIBELLECPTE; }
			set {  _CP_CODEOPERATIONLIBELLECPTE = value; }
		}

		public string TO_CODEOPERATIONPARAMETRE
		{
			get { return _TO_CODEOPERATIONPARAMETRE; }
			set {  _TO_CODEOPERATIONPARAMETRE = value; }
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

		public clsPhapartypearticlecompteplancomptablemodel(){}
		
		public clsPhapartypearticlecompteplancomptablemodel(clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel)
		{
			this.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE;
			this.TO_CODEOPERATIONPARAMETRE = clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE;
			this.PL_CODENUMCOMPTE = clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE;
            this.PL_NUMCOMPTE = clsPhapartypearticlecompteplancomptablemodel.PL_NUMCOMPTE;

		}

		#endregion

	}
}
