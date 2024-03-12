using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsProfilwebdroitagence
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

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
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
        #endregion

        #region INSTANCIATEURS

        public clsProfilwebdroitagence(){}
		public clsProfilwebdroitagence( string PO_CODEPROFILWEB,string AG_CODEAGENCE, string COCHER, string AG_RAISONSOCIAL)
		{
			this.PO_CODEPROFILWEB = PO_CODEPROFILWEB;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.COCHER = COCHER;
            this.AG_RAISONSOCIAL = AG_RAISONSOCIAL;
        }
		public clsProfilwebdroitagence(clsProfilwebdroitagence clsProfilwebdroitagence)
		{
			this.PO_CODEPROFILWEB = clsProfilwebdroitagence.PO_CODEPROFILWEB;
			this.AG_CODEAGENCE = clsProfilwebdroitagence.AG_CODEAGENCE;
            this.COCHER = clsProfilwebdroitagence.COCHER;
            this.AG_RAISONSOCIAL = clsProfilwebdroitagence.AG_RAISONSOCIAL;
        }

		#endregion

	}
}
