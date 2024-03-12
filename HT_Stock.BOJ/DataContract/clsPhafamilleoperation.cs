using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhafamilleoperation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _FO_CODEFAMILLEOPERATION = "";
		private string _FO_LIBELLEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";
		private string _FO_NUMEROORDRE = "0";
		private string _FO_STATUT = "";
		private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUR = "";
		private string _COCHER = "";
		private string _NF_LIBELLENATUREFAMILLEOPERATION = "";
        //{Objet[0].AG_CODEAGENCE,Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].OP_CODEOPERATEUR

        #endregion

        #region ACCESSEURS

        public string FO_CODEFAMILLEOPERATION
		{
			get { return _FO_CODEFAMILLEOPERATION; }
			set {  _FO_CODEFAMILLEOPERATION = value; }
		}

		public string FO_LIBELLEFAMILLEOPERATION
		{
			get { return _FO_LIBELLEFAMILLEOPERATION; }
			set {  _FO_LIBELLEFAMILLEOPERATION = value; }
		}

        public string NF_CODENATUREFAMILLEOPERATION
        {
	        get { return _NF_CODENATUREFAMILLEOPERATION; }
	        set { _NF_CODENATUREFAMILLEOPERATION = value; }
        }

		public string FO_NUMEROORDRE
		{
			get { return _FO_NUMEROORDRE; }
			set {  _FO_NUMEROORDRE = value; }
		}

		public string FO_STATUT
		{
			get { return _FO_STATUT; }
			set {  _FO_STATUT = value; }
		}
		public string AG_CODEAGENCE
        {
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}

		public string OP_CODEOPERATEUR
        {
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
        public string COCHER
        {
	        get { return _COCHER; }
	        set { _COCHER = value; }
        }
        public string NF_LIBELLENATUREFAMILLEOPERATION
        {
	        get { return _NF_LIBELLENATUREFAMILLEOPERATION; }
	        set { _NF_LIBELLENATUREFAMILLEOPERATION = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsPhafamilleoperation(){}
		
		public clsPhafamilleoperation(clsPhafamilleoperation clsPhafamilleoperation)
		{
			this.FO_CODEFAMILLEOPERATION = clsPhafamilleoperation.FO_CODEFAMILLEOPERATION;
			this.FO_LIBELLEFAMILLEOPERATION = clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION;
            this.NF_CODENATUREFAMILLEOPERATION = clsPhafamilleoperation.NF_CODENATUREFAMILLEOPERATION;
			this.FO_NUMEROORDRE = clsPhafamilleoperation.FO_NUMEROORDRE;
			this.FO_STATUT = clsPhafamilleoperation.FO_STATUT;
			this.AG_CODEAGENCE = clsPhafamilleoperation.AG_CODEAGENCE;
			this.OP_CODEOPERATEUR = clsPhafamilleoperation.OP_CODEOPERATEUR;
			this.COCHER = clsPhafamilleoperation.COCHER;
			this.NF_LIBELLENATUREFAMILLEOPERATION = clsPhafamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION;

		}

		#endregion

	}
}
