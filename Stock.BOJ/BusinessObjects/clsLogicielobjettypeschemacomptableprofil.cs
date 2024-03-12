using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLogicielobjettypeschemacomptableprofil
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PO_CODEPROFIL = "";
		private string _NO_CODENATUREOPERATION = "";
		private string _FO_CODEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";

		private string _LB_ACTIF = "";
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

		public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set {  _NO_CODENATUREOPERATION = value; }
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

		public string LB_ACTIF
		{
			get { return _LB_ACTIF; }
			set {  _LB_ACTIF = value; }
		}
        public string COCHER
		{
            get { return _COCHER; }
            set { _COCHER = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsLogicielobjettypeschemacomptableprofil(){}
      
		public clsLogicielobjettypeschemacomptableprofil(clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil)
		{
			this.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableprofil.AG_CODEAGENCE;
			this.PO_CODEPROFIL = clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL;
			this.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION;
			this.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION;
            this.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofil.NF_CODENATUREFAMILLEOPERATION;

			this.LB_ACTIF = clsLogicielobjettypeschemacomptableprofil.LB_ACTIF;
            this.COCHER = clsLogicielobjettypeschemacomptableprofil.COCHER;

		}

		#endregion

	}
}
