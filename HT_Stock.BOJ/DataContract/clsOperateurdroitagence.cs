using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsOperateurdroitagence : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _OP_CODEOPERATEUR = "";
		private string _AG_CODEAGENCE = "";
        private string _COCHER = "";
        private string _AG_RAISONSOCIAL = "";
        private string _MODIFICATION = "";

		#endregion

		#region ACCESSEURS

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
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
        public string MODIFICATION
        {
            get { return _MODIFICATION; }
            set { _MODIFICATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsOperateurdroitagence(){}
	
		public clsOperateurdroitagence(clsOperateurdroitagence clsOperateurdroitagence)
		{
			this.OP_CODEOPERATEUR = clsOperateurdroitagence.OP_CODEOPERATEUR;
			this.AG_CODEAGENCE = clsOperateurdroitagence.AG_CODEAGENCE;
            this.COCHER = clsOperateurdroitagence.COCHER;
            this.AG_RAISONSOCIAL = clsOperateurdroitagence.AG_RAISONSOCIAL;
            this.MODIFICATION = clsOperateurdroitagence.MODIFICATION;
		}

		#endregion

	}
}
