using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsOperateurdroitphaparentrepot
	{
		#region VARIABLES LOCALES

		private string _OP_CODEOPERATEUR = "";
		private string _EN_CODEENTREPOT = "";
        private string _COCHER = "";
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

		#endregion

		#region INSTANCIATEURS

		public clsOperateurdroitphaparentrepot(){}
		public clsOperateurdroitphaparentrepot( string OP_CODEOPERATEUR,string EN_CODEENTREPOT)
		{
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
		}
		public clsOperateurdroitphaparentrepot(clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot)
		{
			this.OP_CODEOPERATEUR = clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR;
			this.EN_CODEENTREPOT = clsOperateurdroitphaparentrepot.EN_CODEENTREPOT;
            this.COCHER = clsOperateurdroitphaparentrepot.COCHER;

		}

		#endregion

	}
}