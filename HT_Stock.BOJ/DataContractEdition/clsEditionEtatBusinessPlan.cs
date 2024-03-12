using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatBusinessPlan
	{

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _OP_CODEOPERATEUR = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";

        private string _EX_EXERCICE = "";
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

       public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
		}
        public clsEditionEtatBusinessPlan() {} 

		

		public clsEditionEtatBusinessPlan(clsEditionEtatBusinessPlan clsEditionEtatBusinessPlan)
		{
			AG_CODEAGENCE = clsEditionEtatBusinessPlan.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatBusinessPlan.EN_CODEENTREPOT;
			OP_CODEOPERATEUREDITION = clsEditionEtatBusinessPlan.OP_CODEOPERATEUREDITION;
            OP_CODEOPERATEUR = clsEditionEtatBusinessPlan.OP_CODEOPERATEUR;
            DATEDEBUT = clsEditionEtatBusinessPlan.DATEDEBUT;
            DATEFIN = clsEditionEtatBusinessPlan.DATEFIN;
            ET_TYPEETAT = clsEditionEtatBusinessPlan.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatBusinessPlan.ET_TYPERETOURS;
            EX_EXERCICE = clsEditionEtatBusinessPlan.EX_EXERCICE;

		}
        }
}