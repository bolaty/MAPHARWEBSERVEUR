using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsProfilwebdroitagence : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _PO_CODEPROFILWEB = "";
		private string _AG_CODEAGENCE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _COCHER = "";
        #endregion

        #region ACCESSEURS

        public string PO_CODEPROFILWEB
		{
			get { return _PO_CODEPROFILWEB; }
			set {  _PO_CODEPROFILWEB = value; }
		}

		public string COCHER
        {
			get { return _COCHER; }
			set { _COCHER = value; }
		}
        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        #endregion

        #region INSTANCIATEURS

        public clsProfilwebdroitagence(){}
		public clsProfilwebdroitagence( string PO_CODEPROFILWEB,string AG_CODEAGENCE, string AG_RAISONSOCIAL, string COCHER)
		{
			this.PO_CODEPROFILWEB = PO_CODEPROFILWEB;
			this.AG_CODEAGENCE = AG_CODEAGENCE; 
            this.AG_RAISONSOCIAL = AG_RAISONSOCIAL;
            this.COCHER = COCHER;
        }
		public clsProfilwebdroitagence(clsProfilwebdroitagence clsProfilwebdroitagence)
		{
			this.PO_CODEPROFILWEB = clsProfilwebdroitagence.PO_CODEPROFILWEB;
			this.AG_CODEAGENCE = clsProfilwebdroitagence.AG_CODEAGENCE;
            this.AG_RAISONSOCIAL = clsProfilwebdroitagence.AG_RAISONSOCIAL;
            this.COCHER = clsProfilwebdroitagence.COCHER;
        }

		#endregion

	}
}
