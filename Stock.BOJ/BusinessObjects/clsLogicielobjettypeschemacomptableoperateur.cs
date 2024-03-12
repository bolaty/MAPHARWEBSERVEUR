using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLogicielobjettypeschemacomptableoperateur
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUR = "";
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

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
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

		public clsLogicielobjettypeschemacomptableoperateur(){}
      
		public clsLogicielobjettypeschemacomptableoperateur(clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur)
		{
			this.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableoperateur.AG_CODEAGENCE;
			this.OP_CODEOPERATEUR = clsLogicielobjettypeschemacomptableoperateur.OP_CODEOPERATEUR;
			this.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableoperateur.NO_CODENATUREOPERATION;
			this.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION;
            this.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateur.NF_CODENATUREFAMILLEOPERATION;
			this.LB_ACTIF = clsLogicielobjettypeschemacomptableoperateur.LB_ACTIF;
            this.COCHER = clsLogicielobjettypeschemacomptableoperateur.COCHER;

		}

		#endregion

	}
}
