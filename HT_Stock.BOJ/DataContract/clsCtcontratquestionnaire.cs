using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratquestionnaire : clsEntitieBase
    {
		#region VARIABLES LOCALES
		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _QE_CODEQUESTIONNAIRE = "";
        private string _QE_LIBELLEQUESTIONNAIRE = "";
        private string _DC_CODEDOCUMENT = "";
		private string _CQ_VALEUR1 = "";
		private string _CQ_VALEUR2 = "";
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS


		public string AG_CODEAGENCE
        {
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string EN_CODEENTREPOT
        {
			get { return _EN_CODEENTREPOT; }
			set { _EN_CODEENTREPOT = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string QE_CODEQUESTIONNAIRE
		{
			get { return _QE_CODEQUESTIONNAIRE; }
			set {  _QE_CODEQUESTIONNAIRE = value; }
		}
		public string DC_CODEDOCUMENT
        {
			get { return _DC_CODEDOCUMENT; }
			set { _DC_CODEDOCUMENT = value; }
		}
		public string CQ_VALEUR1
		{
			get { return _CQ_VALEUR1; }
			set {  _CQ_VALEUR1 = value; }
		}

		public string CQ_VALEUR2
		{
			get { return _CQ_VALEUR2; }
			set {  _CQ_VALEUR2 = value; }
		}
		public string OP_CODEOPERATEUR
        {
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}

        public string QE_LIBELLEQUESTIONNAIRE
        {
	        get { return _QE_LIBELLEQUESTIONNAIRE; }
	        set { _QE_LIBELLEQUESTIONNAIRE = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCtcontratquestionnaire(){}
		
		public clsCtcontratquestionnaire(clsCtcontratquestionnaire clsCtcontratquestionnaire)
		{


            this.AG_CODEAGENCE = clsCtcontratquestionnaire.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsCtcontratquestionnaire.EN_CODEENTREPOT;
            this.CA_CODECONTRAT = clsCtcontratquestionnaire.CA_CODECONTRAT;
			this.QE_CODEQUESTIONNAIRE = clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE;
			this.DC_CODEDOCUMENT = clsCtcontratquestionnaire.DC_CODEDOCUMENT;
			this.CQ_VALEUR1 = clsCtcontratquestionnaire.CQ_VALEUR1;
			this.CQ_VALEUR2 = clsCtcontratquestionnaire.CQ_VALEUR2;
			this.OP_CODEOPERATEUR = clsCtcontratquestionnaire.OP_CODEOPERATEUR;
			this.QE_LIBELLEQUESTIONNAIRE = clsCtcontratquestionnaire.QE_LIBELLEQUESTIONNAIRE;
		}

		#endregion

	}
}
