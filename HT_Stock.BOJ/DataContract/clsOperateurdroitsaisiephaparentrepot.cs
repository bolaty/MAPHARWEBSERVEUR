using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsOperateurdroitsaisiephaparentrepot : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _OP_CODEOPERATEUR = "";
		private string _EN_CODEENTREPOT = "";
        private string _COCHER = "";
        private string _EN_DENOMINATION = "";
        private string _MODIFICATION = "";
        #endregion

        #region ACCESSEURS

        public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}
        public string COCHER
		{
            get { return _COCHER; }
            set { _COCHER = value; }
		}
        public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; }
        }
        public string MODIFICATION
        {
            get { return _MODIFICATION; }
            set { _MODIFICATION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsOperateurdroitsaisiephaparentrepot(){}

		public clsOperateurdroitsaisiephaparentrepot(clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot)
		{
			this.OP_CODEOPERATEUR = clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR;
			this.EN_CODEENTREPOT = clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT;
            this.COCHER = clsOperateurdroitsaisiephaparentrepot.COCHER;
            this.EN_DENOMINATION = clsOperateurdroitsaisiephaparentrepot.EN_DENOMINATION;
            this.MODIFICATION = clsOperateurdroitsaisiephaparentrepot.MODIFICATION;

        }

		#endregion

	}
}
