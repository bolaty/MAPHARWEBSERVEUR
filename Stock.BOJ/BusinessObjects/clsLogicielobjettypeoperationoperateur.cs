using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLogicielobjettypeoperationoperateur
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUR = "";
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

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
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

		public clsLogicielobjettypeoperationoperateur(){}
       
		public clsLogicielobjettypeoperationoperateur(clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur)
		{
			this.AG_CODEAGENCE = clsLogicielobjettypeoperationoperateur.AG_CODEAGENCE;
			this.OP_CODEOPERATEUR = clsLogicielobjettypeoperationoperateur.OP_CODEOPERATEUR;
			this.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION;
            this.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION;
			this.LO_ACTIF = clsLogicielobjettypeoperationoperateur.LO_ACTIF;
            this.COCHER = clsLogicielobjettypeoperationoperateur.COCHER;
		}

		#endregion

	}
}
