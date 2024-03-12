using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatOutilsSecurite
	{


    //    @AG_CODEAGENCE varchar(7000),	
    //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
    //@TP_CODETYPECLIENT varchar(700),
    //@ET_TYPEETAT AS varchar(50),



        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _MS_DATERENDEZVOUS1 = "";
        private string _MS_DATERENDEZVOUS2= "";
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



		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}
       

        public string MS_DATERENDEZVOUS1
		{
            get { return _MS_DATERENDEZVOUS1; }
            set { _MS_DATERENDEZVOUS1 = value; }
		}
       public string MS_DATERENDEZVOUS2
		{
            get { return _MS_DATERENDEZVOUS2; }
            set { _MS_DATERENDEZVOUS2 = value; }
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
       
        public clsEditionEtatOutilsSecurite() {} 

		

		public clsEditionEtatOutilsSecurite(clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite)
		{
			AG_CODEAGENCE = clsEditionEtatOutilsSecurite.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatOutilsSecurite.EN_CODEENTREPOT;
			OP_CODEOPERATEUREDITION = clsEditionEtatOutilsSecurite.OP_CODEOPERATEUREDITION;
            MS_DATERENDEZVOUS1 = clsEditionEtatOutilsSecurite.MS_DATERENDEZVOUS1;
            MS_DATERENDEZVOUS2 = clsEditionEtatOutilsSecurite.MS_DATERENDEZVOUS2;
            ET_TYPEETAT = clsEditionEtatOutilsSecurite.ET_TYPEETAT;



		}
        }
}