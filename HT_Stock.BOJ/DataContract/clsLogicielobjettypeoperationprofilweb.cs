using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsLogicielobjettypeoperationprofilweb : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PO_CODEPROFILWEB = "";
		private string _FO_CODEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";

		private string _LO_ACTIF = "";
        private string _COCHER = "";
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string PO_CODEPROFILWEB
		{
			get { return _PO_CODEPROFILWEB; }
			set {  _PO_CODEPROFILWEB = value; }
		}

		public string FO_CODEFAMILLEOPERATION
		{
			get { return _FO_CODEFAMILLEOPERATION; }
			set {  _FO_CODEFAMILLEOPERATION = value; }
		}


        public string NF_CODENATUREFAMILLEOPERATION
        {
        get { return _NF_CODENATUREFAMILLEOPERATION; }
        set { _NF_CODENATUREFAMILLEOPERATION = value; }
        }

		public string LO_ACTIF
		{
			get { return _LO_ACTIF; }
			set {  _LO_ACTIF = value; }
		}
        public string COCHER
		{
            get { return _COCHER; }
            set { _COCHER = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsLogicielobjettypeoperationprofilweb(){}
      
		public clsLogicielobjettypeoperationprofilweb(clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb)
		{
			this.AG_CODEAGENCE = clsLogicielobjettypeoperationprofilweb.AG_CODEAGENCE;
			this.PO_CODEPROFILWEB = clsLogicielobjettypeoperationprofilweb.PO_CODEPROFILWEB;
			this.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationprofilweb.FO_CODEFAMILLEOPERATION;

            this.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationprofilweb.NF_CODENATUREFAMILLEOPERATION;
			this.LO_ACTIF = clsLogicielobjettypeoperationprofilweb.LO_ACTIF;
            this.COCHER = clsLogicielobjettypeoperationprofilweb.COCHER;
		}

		#endregion

	}
}
