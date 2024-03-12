using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCliconsultation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CO_CODECONSULTATION = "";
		private string _AG_CODEAGENCE = "";
		private string _SR_CODESERVICE = "";
		private string _TY_CODETYPECONSULTATION = "";
		private string _MD_CODEMODEADMISSION = "";
		private string _MS_CODEMODESORTIE = "";
		private string _TI_IDTIERSPATIENT = "";
		private string _TI_IDTIERSMEDECIN = "";
		private string _CO_CODECONSULTATION1 = "";
		private string _OP_CODEOPERATEUR = "";
		private string _TI_IDTIERSASSUREUR = "";
		private string _AP_CODEPRODUIT = "";
		private string _CO_NUMERODOSSIER = "";
		private string _CO_DATEDECONSULTATION = "01-01-1900";
		private string _CO_DATEEXPIRATIONCONSULTATION = "01-01-1900";
		private string _CO_MOTIFCONSULTATION = "";
		private string _CO_AUTRESINFORMATIONS = "";
		private string _CO_TAUXASSURANCE = "0";
		private string _CO_MONTANTASSURANCE = "0";
		private string _CO_DATESAISIE = "01-01/1900";
		private string _CO_DESCRIPTIONREPRESENTANT = "";
		private string _CO_CONTACTREPRESENTANT = "";
		private string _CO_DATESORTIE ="01-01-1900";
		private string _CO_TAUXMEDECIN = "0";
		private string _CO_MONTANTMEDECIN = "0";

        private string _TI_NUMTIERSMEDECIN = "";
        private string _TI_DENOMINATIONMEDECIN = "";
        private string _TI_TELEPHONEMEDECIN = "";
        private string _TI_NUMTIERSPATIENT = "";
        private string _TI_DENOMINATIONPATIENT = "";
        private string _TI_TELEPHONEPATIENT = "";

        private string _MD_LIBELLEMODEADMISSION = "";
        private string _TY_LIBELLETYPECONSULTATION = "";
        private string _SR_LIBELLE = "";
		#endregion

		#region ACCESSEURS

		public string CO_CODECONSULTATION
		{
			get { return _CO_CODECONSULTATION; }
			set {  _CO_CODECONSULTATION = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public string TY_CODETYPECONSULTATION
		{
			get { return _TY_CODETYPECONSULTATION; }
			set {  _TY_CODETYPECONSULTATION = value; }
		}

		public string MD_CODEMODEADMISSION
		{
			get { return _MD_CODEMODEADMISSION; }
			set {  _MD_CODEMODEADMISSION = value; }
		}

		public string MS_CODEMODESORTIE
		{
			get { return _MS_CODEMODESORTIE; }
			set {  _MS_CODEMODESORTIE = value; }
		}

		public string TI_IDTIERSPATIENT
		{
			get { return _TI_IDTIERSPATIENT; }
			set {  _TI_IDTIERSPATIENT = value; }
		}

		public string TI_IDTIERSMEDECIN
		{
			get { return _TI_IDTIERSMEDECIN; }
			set {  _TI_IDTIERSMEDECIN = value; }
		}

		public string CO_CODECONSULTATION1
		{
			get { return _CO_CODECONSULTATION1; }
			set {  _CO_CODECONSULTATION1 = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string TI_IDTIERSASSUREUR
		{
			get { return _TI_IDTIERSASSUREUR; }
			set {  _TI_IDTIERSASSUREUR = value; }
		}

        public string AP_CODEPRODUIT
        {
	        get { return _AP_CODEPRODUIT; }
	        set { _AP_CODEPRODUIT = value; }
        }


		public string CO_NUMERODOSSIER
		{
			get { return _CO_NUMERODOSSIER; }
			set {  _CO_NUMERODOSSIER = value; }
		}

		public string CO_DATEDECONSULTATION
		{
			get { return _CO_DATEDECONSULTATION; }
			set {  _CO_DATEDECONSULTATION = value; }
		}

		public string CO_DATEEXPIRATIONCONSULTATION
		{
			get { return _CO_DATEEXPIRATIONCONSULTATION; }
			set {  _CO_DATEEXPIRATIONCONSULTATION = value; }
		}

		public string CO_MOTIFCONSULTATION
		{
			get { return _CO_MOTIFCONSULTATION; }
			set {  _CO_MOTIFCONSULTATION = value; }
		}

		public string CO_AUTRESINFORMATIONS
		{
			get { return _CO_AUTRESINFORMATIONS; }
			set {  _CO_AUTRESINFORMATIONS = value; }
		}

		public string CO_TAUXASSURANCE
		{
			get { return _CO_TAUXASSURANCE; }
			set {  _CO_TAUXASSURANCE = value; }
		}

		public string CO_MONTANTASSURANCE
		{
			get { return _CO_MONTANTASSURANCE; }
			set {  _CO_MONTANTASSURANCE = value; }
		}

		public string CO_DATESAISIE
		{
			get { return _CO_DATESAISIE; }
			set {  _CO_DATESAISIE = value; }
		}

		public string CO_DESCRIPTIONREPRESENTANT
		{
			get { return _CO_DESCRIPTIONREPRESENTANT; }
			set {  _CO_DESCRIPTIONREPRESENTANT = value; }
		}

		public string CO_CONTACTREPRESENTANT
		{
			get { return _CO_CONTACTREPRESENTANT; }
			set {  _CO_CONTACTREPRESENTANT = value; }
		}

		public string CO_DATESORTIE
		{
			get { return _CO_DATESORTIE; }
			set {  _CO_DATESORTIE = value; }
		}

		public string CO_TAUXMEDECIN
		{
			get { return _CO_TAUXMEDECIN; }
			set {  _CO_TAUXMEDECIN = value; }
		}

		public string CO_MONTANTMEDECIN
		{
			get { return _CO_MONTANTMEDECIN; }
			set {  _CO_MONTANTMEDECIN = value; }
		}

        public string TI_NUMTIERSMEDECIN
        {
	        get { return _TI_NUMTIERSMEDECIN; }
	        set { _TI_NUMTIERSMEDECIN = value; }
        }

        public string TI_DENOMINATIONMEDECIN
        {
	        get { return _TI_DENOMINATIONMEDECIN; }
	        set { _TI_DENOMINATIONMEDECIN = value; }
        }

        public string TI_TELEPHONEMEDECIN
        {
	        get { return _TI_TELEPHONEMEDECIN; }
	        set { _TI_TELEPHONEMEDECIN = value; }
        }

        public string TI_NUMTIERSPATIENT
        {
	        get { return _TI_NUMTIERSPATIENT; }
	        set { _TI_NUMTIERSPATIENT = value; }
        }
        public string TI_DENOMINATIONPATIENT
        {
	        get { return _TI_DENOMINATIONPATIENT; }
	        set { _TI_DENOMINATIONPATIENT = value; }
        }

        public string TI_TELEPHONEPATIENT
        {
	        get { return _TI_TELEPHONEPATIENT; }
	        set { _TI_TELEPHONEPATIENT = value; }
        }

        public string MD_LIBELLEMODEADMISSION
        {
	        get { return _MD_LIBELLEMODEADMISSION; }
	        set { _MD_LIBELLEMODEADMISSION = value; }
        }
        public string TY_LIBELLETYPECONSULTATION
        {
	        get { return _TY_LIBELLETYPECONSULTATION; }
	        set { _TY_LIBELLETYPECONSULTATION = value; }
        }
        public string SR_LIBELLE
        {
	        get { return _SR_LIBELLE; }
	        set { _SR_LIBELLE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsCliconsultation(){}
		
		public clsCliconsultation(clsCliconsultation clsCliconsultation)
		{
			this.CO_CODECONSULTATION = clsCliconsultation.CO_CODECONSULTATION;
			this.AG_CODEAGENCE = clsCliconsultation.AG_CODEAGENCE;
			this.SR_CODESERVICE = clsCliconsultation.SR_CODESERVICE;
			this.TY_CODETYPECONSULTATION = clsCliconsultation.TY_CODETYPECONSULTATION;
			this.MD_CODEMODEADMISSION = clsCliconsultation.MD_CODEMODEADMISSION;
			this.MS_CODEMODESORTIE = clsCliconsultation.MS_CODEMODESORTIE;
			this.TI_IDTIERSPATIENT = clsCliconsultation.TI_IDTIERSPATIENT;
			this.TI_IDTIERSMEDECIN = clsCliconsultation.TI_IDTIERSMEDECIN;
			this.CO_CODECONSULTATION1 = clsCliconsultation.CO_CODECONSULTATION1;
			this.OP_CODEOPERATEUR = clsCliconsultation.OP_CODEOPERATEUR;
			this.TI_IDTIERSASSUREUR = clsCliconsultation.TI_IDTIERSASSUREUR;
			this.AP_CODEPRODUIT = clsCliconsultation.AP_CODEPRODUIT;
			this.CO_NUMERODOSSIER = clsCliconsultation.CO_NUMERODOSSIER;
			this.CO_DATEDECONSULTATION = clsCliconsultation.CO_DATEDECONSULTATION;
			this.CO_DATEEXPIRATIONCONSULTATION = clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION;
			this.CO_MOTIFCONSULTATION = clsCliconsultation.CO_MOTIFCONSULTATION;
			this.CO_AUTRESINFORMATIONS = clsCliconsultation.CO_AUTRESINFORMATIONS;
			this.CO_TAUXASSURANCE = clsCliconsultation.CO_TAUXASSURANCE;
			this.CO_MONTANTASSURANCE = clsCliconsultation.CO_MONTANTASSURANCE;
			this.CO_DATESAISIE = clsCliconsultation.CO_DATESAISIE;
			this.CO_DESCRIPTIONREPRESENTANT = clsCliconsultation.CO_DESCRIPTIONREPRESENTANT;
			this.CO_CONTACTREPRESENTANT = clsCliconsultation.CO_CONTACTREPRESENTANT;
			this.CO_DATESORTIE = clsCliconsultation.CO_DATESORTIE;
			this.CO_TAUXMEDECIN = clsCliconsultation.CO_TAUXMEDECIN;
			this.CO_MONTANTMEDECIN = clsCliconsultation.CO_MONTANTMEDECIN;
            this.TI_NUMTIERSMEDECIN = clsCliconsultation.TI_NUMTIERSMEDECIN;
            this.TI_DENOMINATIONMEDECIN = clsCliconsultation.TI_DENOMINATIONMEDECIN;
            this.TI_TELEPHONEMEDECIN = clsCliconsultation.TI_TELEPHONEMEDECIN;
            this.TI_NUMTIERSPATIENT = clsCliconsultation.TI_NUMTIERSPATIENT;
            this.TI_DENOMINATIONPATIENT = clsCliconsultation.TI_DENOMINATIONPATIENT;
            this.TI_TELEPHONEPATIENT = clsCliconsultation.TI_TELEPHONEPATIENT;
            this.MD_LIBELLEMODEADMISSION = clsCliconsultation.MD_LIBELLEMODEADMISSION;
            this.TY_LIBELLETYPECONSULTATION = clsCliconsultation.TY_LIBELLETYPECONSULTATION;
            this.SR_LIBELLE = clsCliconsultation.SR_LIBELLE;




            //private string _TI_NUMTIERSMEDECIN = "";
            //private string _TI_DENOMINATIONMEDECIN = "";
            //private string _TI_TELEPHONEMEDECIN = "";
            //private string _TI_NUMTIERSPATIENT = "";
            //private string _TI_DENOMINATIONPATIENT = "";
            //private string _TI_TELEPHONEPATIENT = "";
        }

        #endregion

    }
}
