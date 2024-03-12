using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparcode
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _CL_CODE = "";
		private string _AR_CODEARTICLE = "";
		private string _CL_NUMCLE = "";
		private string _CL_NUMALARME = "";
		private string _CL_NUMAUTORADION = "";
        private string _OP_CODEOPERATEUR = "";
		#endregion

		#region ACCESSEURS
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
		public string CL_CODE
		{
			get { return _CL_CODE; }
			set {  _CL_CODE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string CL_NUMCLE
		{
			get { return _CL_NUMCLE; }
			set {  _CL_NUMCLE = value; }
		}

		public string CL_NUMALARME
		{
			get { return _CL_NUMALARME; }
			set {  _CL_NUMALARME = value; }
		}

		public string CL_NUMAUTORADION
		{
			get { return _CL_NUMAUTORADION; }
			set {  _CL_NUMAUTORADION = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhaparcode(){}
		
		public clsPhaparcode(clsPhaparcode clsPhaparcode)
		{
            this.AG_CODEAGENCE = clsPhaparcode.AG_CODEAGENCE;
			this.CL_CODE = clsPhaparcode.CL_CODE;
			this.AR_CODEARTICLE = clsPhaparcode.AR_CODEARTICLE;
			this.CL_NUMCLE = clsPhaparcode.CL_NUMCLE;
			this.CL_NUMALARME = clsPhaparcode.CL_NUMALARME;
			this.CL_NUMAUTORADION = clsPhaparcode.CL_NUMAUTORADION;
            this.OP_CODEOPERATEUR = clsPhaparcode.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
