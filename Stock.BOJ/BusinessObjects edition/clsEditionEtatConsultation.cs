using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatConsultation
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@DATEDEBUT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _TP_CODETYPETIERS = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _OP_CODEOPERATEUR = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";
        private string _TI_IDTIERSPATIENT= "";
        private string _TI_IDTIERSMEDECIN = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";

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

        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }

		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}

        public string OP_CODEOPERATEUR
		{
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
		}
        public string DATEDEBUT
		{
            get { return _DATEDEBUT; }
            set { _DATEDEBUT = value; }
		}
        public string DATEFIN
		{
            get { return _DATEFIN; }
            set { _DATEFIN = value; }
		}
        public string TI_IDTIERSPATIENT
		{
            get { return _TI_IDTIERSPATIENT; }
            set { _TI_IDTIERSPATIENT = value; }
		}
        public string TI_IDTIERSMEDECIN
		{
            get { return _TI_IDTIERSMEDECIN; }
            set { _TI_IDTIERSMEDECIN = value; }
		}
      
        public string ET_TYPEETAT
		{
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
		}
        public string ET_TYPERETOURS
		{
            get { return _ET_TYPERETOURS; }
            set { _ET_TYPERETOURS = value; }
		}

      
        public clsEditionEtatConsultation() {} 

		

		public clsEditionEtatConsultation(clsEditionEtatConsultation clsEditionEtatConsultation)
		{
			this.AG_CODEAGENCE = clsEditionEtatConsultation.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsEditionEtatConsultation.EN_CODEENTREPOT;
            this.TP_CODETYPETIERS = clsEditionEtatConsultation.TP_CODETYPETIERS;
            this.OP_CODEOPERATEUREDITION = clsEditionEtatConsultation.OP_CODEOPERATEUREDITION;
            this.OP_CODEOPERATEUR = clsEditionEtatConsultation.OP_CODEOPERATEUR;
            this.DATEDEBUT = clsEditionEtatConsultation.DATEDEBUT;
            this.DATEFIN = clsEditionEtatConsultation.DATEFIN;
            this.TI_IDTIERSPATIENT = clsEditionEtatConsultation.TI_IDTIERSPATIENT;
            this.TI_IDTIERSMEDECIN = clsEditionEtatConsultation.TI_IDTIERSMEDECIN;
            this.ET_TYPEETAT = clsEditionEtatConsultation.ET_TYPEETAT;
            this.ET_TYPERETOURS = clsEditionEtatConsultation.ET_TYPERETOURS;
            

		}
        }
}