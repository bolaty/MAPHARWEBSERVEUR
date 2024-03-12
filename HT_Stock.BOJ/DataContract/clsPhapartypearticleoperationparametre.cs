using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhapartypearticleoperationparametre : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TO_CODEOPERATIONPARAMETRE = "";
		private string _TO_CODEOPERATION = "";
		private string _CP_CODEOPERATIONLIBELLECPTE = "";
		private string _CP_LIBELLE = "";
		private string _PL_NUMCOMPTE = "";


        #endregion

        #region ACCESSEURS

        public string TO_CODEOPERATIONPARAMETRE
		{
			get { return _TO_CODEOPERATIONPARAMETRE; }
			set {  _TO_CODEOPERATIONPARAMETRE = value; }
		}

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
		public string CP_LIBELLE
        {
			get { return _CP_LIBELLE; }
			set { _CP_LIBELLE = value; }
		}
		public string PL_NUMCOMPTE
        {
			get { return _PL_NUMCOMPTE; }
			set { _PL_NUMCOMPTE = value; }
		}




        #endregion

        #region INSTANCIATEURS

        public clsPhapartypearticleoperationparametre(){}

		public clsPhapartypearticleoperationparametre(clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre)
		{
			this.TO_CODEOPERATIONPARAMETRE = clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE;
			this.TO_CODEOPERATION = clsPhapartypearticleoperationparametre.TO_CODEOPERATION;
			this.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE;
			this.CP_LIBELLE = clsPhapartypearticleoperationparametre.CP_LIBELLE;
			this.PL_NUMCOMPTE = clsPhapartypearticleoperationparametre.PL_NUMCOMPTE;

            //clsPhapartypearticleoperationparametre.CP_LIBELLE = row["CP_LIBELLE"].ToString();
            //clsPhapartypearticleoperationparametre.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();

        }

        #endregion

    }
}
