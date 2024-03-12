using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLogicielobjettypeoperationprofil
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PO_CODEPROFIL = "";
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

		public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set {  _PO_CODEPROFIL = value; }
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

		public clsLogicielobjettypeoperationprofil(){}
      
		public clsLogicielobjettypeoperationprofil(clsLogicielobjettypeoperationprofil clsLogicielobjettypeoperationprofil)
		{
			this.AG_CODEAGENCE = clsLogicielobjettypeoperationprofil.AG_CODEAGENCE;
			this.PO_CODEPROFIL = clsLogicielobjettypeoperationprofil.PO_CODEPROFIL;
			this.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationprofil.FO_CODEFAMILLEOPERATION;

            this.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationprofil.NF_CODENATUREFAMILLEOPERATION;
			this.LO_ACTIF = clsLogicielobjettypeoperationprofil.LO_ACTIF;
            this.COCHER = clsLogicielobjettypeoperationprofil.COCHER;
		}

		#endregion

	}
}
