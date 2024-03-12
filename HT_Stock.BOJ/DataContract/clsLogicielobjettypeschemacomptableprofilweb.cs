using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsLogicielobjettypeschemacomptableprofilweb : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PO_CODEPROFILWEB = "";
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

		public string PO_CODEPROFILWEB
		{
			get { return _PO_CODEPROFILWEB; }
			set {  _PO_CODEPROFILWEB = value; }
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

		public clsLogicielobjettypeschemacomptableprofilweb(){}
      
		public clsLogicielobjettypeschemacomptableprofilweb(clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb)
		{
			this.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE;
			this.PO_CODEPROFILWEB = clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB;
			this.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION;
			this.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION;
            this.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilweb.NF_CODENATUREFAMILLEOPERATION;

			this.LB_ACTIF = clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF;
            this.COCHER = clsLogicielobjettypeschemacomptableprofilweb.COCHER;
            this.PL_CODENUMCOMPTE = clsLogicielobjettypeschemacomptableprofilweb.PL_CODENUMCOMPTE;
            this.NO_LIBELLE = clsLogicielobjettypeschemacomptableprofilweb.NO_LIBELLE;
            this.PL_NUMCOMPTE = clsLogicielobjettypeschemacomptableprofilweb.PL_NUMCOMPTE;
            this.NO_SENS = clsLogicielobjettypeschemacomptableprofilweb.NO_SENS;
            this.NO_PREFIXECOMPTE = clsLogicielobjettypeschemacomptableprofilweb.NO_PREFIXECOMPTE;
            this.NO_REFPIECE = clsLogicielobjettypeschemacomptableprofilweb.NO_REFPIECE;
            this.NC_CODENATURECOMPTE = clsLogicielobjettypeschemacomptableprofilweb.NC_CODENATURECOMPTE;
            this.NO_ABREVIATION = clsLogicielobjettypeschemacomptableprofilweb.NO_ABREVIATION;
            this.NO_MONTANT = clsLogicielobjettypeschemacomptableprofilweb.NO_MONTANT;
            this.NO_NUMEROORDRE = clsLogicielobjettypeschemacomptableprofilweb.NO_NUMEROORDRE;
            this.FO_LIBELLEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilweb.FO_LIBELLEFAMILLEOPERATION;
		}

		#endregion

	}
}
