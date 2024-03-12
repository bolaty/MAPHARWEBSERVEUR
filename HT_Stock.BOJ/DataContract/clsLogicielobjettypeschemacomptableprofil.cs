using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsLogicielobjettypeschemacomptableprofil : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PO_CODEPROFIL = "";
		private string _NO_CODENATUREOPERATION = "";
		private string _FO_CODEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";
        private string _FO_LIBELLEFAMILLEOPERATION = "";
		private string _LB_ACTIF = "";
        private string _COCHER = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _NO_LIBELLE = "";
        private string _PL_NUMCOMPTE = "";
        private string _NO_SENS = "";
        private string _NO_PREFIXECOMPTE = "";
        private string _NO_REFPIECE = "";
        private string _NC_CODENATURECOMPTE = "";
        private string _NO_ABREVIATION = "";
        private string _NO_MONTANT = "0";
        private string _NO_NUMEROORDRE = "0";
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
        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }
        public string NO_LIBELLE
        {
            get { return _NO_LIBELLE; }
            set { _NO_LIBELLE = value; }
        }
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public string NO_SENS
        {
            get { return _NO_SENS; }
            set { _NO_SENS = value; }
        }

        public string NO_PREFIXECOMPTE
        {
            get { return _NO_PREFIXECOMPTE; }
            set { _NO_PREFIXECOMPTE = value; }
        }
        public string NO_REFPIECE
        {
            get { return _NO_REFPIECE; }
            set { _NO_REFPIECE = value; }
        }
        public string NC_CODENATURECOMPTE
        {
            get { return _NC_CODENATURECOMPTE; }
            set { _NC_CODENATURECOMPTE = value; }
        }
        public string NO_ABREVIATION
        {
            get { return _NO_ABREVIATION; }
            set { _NO_ABREVIATION = value; }
        }

        public string NO_MONTANT
        {
            get { return _NO_MONTANT; }
            set { _NO_MONTANT = value; }
        }
        public string NO_NUMEROORDRE
        {
            get { return _NO_NUMEROORDRE; }
            set { _NO_NUMEROORDRE = value; }
        }
        public string FO_LIBELLEFAMILLEOPERATION
        {
            get { return _FO_LIBELLEFAMILLEOPERATION; }
            set { _FO_LIBELLEFAMILLEOPERATION = value; }
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
            this.PL_CODENUMCOMPTE = clsLogicielobjettypeschemacomptableprofil.PL_CODENUMCOMPTE;
            this.NO_LIBELLE = clsLogicielobjettypeschemacomptableprofil.NO_LIBELLE;
            this.PL_NUMCOMPTE = clsLogicielobjettypeschemacomptableprofil.PL_NUMCOMPTE;
            this.NO_SENS = clsLogicielobjettypeschemacomptableprofil.NO_SENS;
            this.NO_PREFIXECOMPTE = clsLogicielobjettypeschemacomptableprofil.NO_PREFIXECOMPTE;
            this.NO_REFPIECE = clsLogicielobjettypeschemacomptableprofil.NO_REFPIECE;
            this.NC_CODENATURECOMPTE = clsLogicielobjettypeschemacomptableprofil.NC_CODENATURECOMPTE;
            this.NO_ABREVIATION = clsLogicielobjettypeschemacomptableprofil.NO_ABREVIATION;
            this.NO_MONTANT = clsLogicielobjettypeschemacomptableprofil.NO_MONTANT;
            this.NO_NUMEROORDRE = clsLogicielobjettypeschemacomptableprofil.NO_NUMEROORDRE;
            this.FO_LIBELLEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofil.FO_LIBELLEFAMILLEOPERATION;
		}

		#endregion

	}
}
