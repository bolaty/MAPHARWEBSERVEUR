using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsLogicielobjettypeschemacomptableoperateur : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUR = "";
		private string _NO_CODENATUREOPERATION = "";
		private string _FO_CODEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";
		private string _LB_ACTIF = "";
        private string _COCHER = "";
        private string _FO_LIBELLEFAMILLEOPERATION = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _NO_LIBELLE = "";
        private string _PL_NUMCOMPTE = "";
        private string _NO_SENS = "";
        private string _NO_PREFIXECOMPTE = "";
        private string _NO_REFPIECE = "";
        private string _NC_CODENATURECOMPTE = "";
        private string _NO_ABREVIATION = "";
        private string _NO_MONTANT = "0";
        private string _RS_LIBELLE = "";
        private string _RS_CODERUBRIQUE = "";
        private string _RS_SENS = "";
        private string _RS_PREFIXECOMPTE = "";
        private string _RS_REFPIECE = "";
        private string _RS_ABREVIATION = "";
        private string _RS_MONTANT = "0";
        private string _RS_NUMEROORDRE = "0";
        //clsLogicielobjettypeschemacomptableoperateur.RS_LIBELLE = row["RS_LIBELLE"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_CODERUBRIQUE = row["RS_CODERUBRIQUE"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_SENS = row["RS_SENS"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_PREFIXECOMPTE = row["RS_PREFIXECOMPTE"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_REFPIECE = row["RS_REFPIECE"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.COCHER = row["COCHER"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_ABREVIATION = row["RS_ABREVIATION"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_MONTANT = row["RS_MONTANT"].ToString();
        //clsLogicielobjettypeschemacomptableoperateur.RS_NUMEROORDRE = row["RS_NUMEROORDRE"].ToString();



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

        public string FO_LIBELLEFAMILLEOPERATION
        {
            get { return _FO_LIBELLEFAMILLEOPERATION; }
            set { _FO_LIBELLEFAMILLEOPERATION = value; }
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

    public string RS_LIBELLE
        {
    get { return _RS_LIBELLE; }
    set { _RS_LIBELLE = value; }
    }
    public string RS_CODERUBRIQUE
        {
    get { return _RS_CODERUBRIQUE; }
    set { _RS_CODERUBRIQUE = value; }
    }
    public string RS_SENS
        {
    get { return _RS_SENS; }
    set { _RS_SENS = value; }
    }

    public string RS_PREFIXECOMPTE
        {
    get { return _RS_PREFIXECOMPTE; }
    set { _RS_PREFIXECOMPTE = value; }
    }
    public string RS_REFPIECE
        {
    get { return _RS_REFPIECE; }
    set { _RS_REFPIECE = value; }
    }

    public string RS_ABREVIATION
        {
    get { return _RS_ABREVIATION; }
    set { _RS_ABREVIATION = value; }
    }
    public string RS_MONTANT
        {
    get { return _RS_MONTANT; }
    set { _RS_MONTANT = value; }
    }
    public string RS_NUMEROORDRE
        {
    get { return _RS_NUMEROORDRE; }
    set { _RS_NUMEROORDRE = value; }
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
            this.FO_LIBELLEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateur.FO_LIBELLEFAMILLEOPERATION;
            this.PL_CODENUMCOMPTE = clsLogicielobjettypeschemacomptableoperateur.PL_CODENUMCOMPTE;
            this.NO_LIBELLE = clsLogicielobjettypeschemacomptableoperateur.NO_LIBELLE;
            this.PL_NUMCOMPTE = clsLogicielobjettypeschemacomptableoperateur.PL_NUMCOMPTE;
            this.NO_SENS = clsLogicielobjettypeschemacomptableoperateur.NO_SENS;
            this.NO_PREFIXECOMPTE = clsLogicielobjettypeschemacomptableoperateur.NO_PREFIXECOMPTE;
            this.NO_REFPIECE = clsLogicielobjettypeschemacomptableoperateur.NO_REFPIECE;
            this.NC_CODENATURECOMPTE = clsLogicielobjettypeschemacomptableoperateur.NC_CODENATURECOMPTE;
            this.NC_CODENATURECOMPTE = clsLogicielobjettypeschemacomptableoperateur.NC_CODENATURECOMPTE;
            this.NO_ABREVIATION = clsLogicielobjettypeschemacomptableoperateur.NO_ABREVIATION;
            this.NO_MONTANT = clsLogicielobjettypeschemacomptableoperateur.NO_MONTANT;
            this.RS_LIBELLE = clsLogicielobjettypeschemacomptableoperateur.RS_LIBELLE;
            this.RS_CODERUBRIQUE = clsLogicielobjettypeschemacomptableoperateur.RS_CODERUBRIQUE;
            this.RS_SENS = clsLogicielobjettypeschemacomptableoperateur.RS_SENS;
            this.RS_PREFIXECOMPTE = clsLogicielobjettypeschemacomptableoperateur.RS_PREFIXECOMPTE;
            this.RS_REFPIECE = clsLogicielobjettypeschemacomptableoperateur.RS_REFPIECE;
            this.RS_ABREVIATION = clsLogicielobjettypeschemacomptableoperateur.RS_ABREVIATION;
            this.RS_MONTANT = clsLogicielobjettypeschemacomptableoperateur.RS_MONTANT;
            this.RS_NUMEROORDRE = clsLogicielobjettypeschemacomptableoperateur.RS_NUMEROORDRE;


		}

		#endregion

	}
}
