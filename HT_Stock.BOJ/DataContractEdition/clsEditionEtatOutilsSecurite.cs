using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEditionEtatOutilsSecurite : clsEntitieBase
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
        private string _OP_CODEOPERATEUR = "";
        private string _AG_RAISONSOCIAL = "";
        private string _PO_CODEPROFIL = "";
        private string _TO_CODETYPEOERATEUR = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
        private string _PL_CODENUMCOMPTECOFFREFORT = "";
        private string _PL_NUMCOMPTECOFFREFORT = "";
        private string _PL_LIBELLE = "";
        private string _OP_NOMPRENOM = "";
        private string _OP_MOTPASSE = "";
        private string _OP_ACTIF = "";
        private string _OP_TELEPHONE = "";
        private string _OP_EMAIL = "";
        private string _OP_JOURNEEOUVERTE = "";
        private string _OP_GESTIONNAIRE = "";
        private string _OP_CAISSIER = "";
        private string _OP_DATESAISIE = "";
        private string _PO_LIBELLE = "";
        private string _OP_IMPRESSIONAUTOMATIQUE = "";
        private string _OP_MONTANTTOTALENCAISSEAUTORISE = "";
        private string _EN_DENOMINATION = "";
        private string _TI_IDTIERS = "";
        private string _TI_NUMTIERS = "";
        private string _TI_DENOMINATION = "";
        private string _PL_CODENUMCOMPTECLT = "";
        private string _PL_NUMCOMPTECLT = "";
        private string _NT_CODENATURETIERS = "";
        private string _TI_TVA = "";
        private string _TI_ASDI = "";
        private string _OP_EXTOURNE = "";
        private string _OP_CREATIONJOURNE = "";
        private string _OP_FERMETUREJOURNE = "";
        private string _SR_CODESERVICE = "";
        private string _OP_CREATIONPROFILE = "";
        private string _OP_CREATIONOPERATEUR = "";
 


        //PO_LIBELLE = clsEditionEtatOutilsSecurite.PO_LIBELLE;
        //    OP_IMPRESSIONAUTOMATIQUE = clsEditionEtatOutilsSecurite.OP_IMPRESSIONAUTOMATIQUE;
        //    OP_MONTANTTOTALENCAISSEAUTORISE = clsEditionEtatOutilsSecurite.OP_MONTANTTOTALENCAISSEAUTORISE;
        //    EN_DENOMINATION = clsEditionEtatOutilsSecurite.EN_DENOMINATION;
        //    TI_IDTIERS = clsEditionEtatOutilsSecurite.TI_IDTIERS;
        //    TI_NUMTIERS = clsEditionEtatOutilsSecurite.TI_NUMTIERS;
        //    TI_DENOMINATION = clsEditionEtatOutilsSecurite.TI_DENOMINATION;
        //    PL_CODENUMCOMPTECLT = clsEditionEtatOutilsSecurite.PL_CODENUMCOMPTECLT;
        //    PL_NUMCOMPTECLT = clsEditionEtatOutilsSecurite.PL_NUMCOMPTECLT;
        //    NT_CODENATURETIERS = clsEditionEtatOutilsSecurite.NT_CODENATURETIERS;
        //    TI_TVA = clsEditionEtatOutilsSecurite.TI_TVA;
        //    TI_ASDI = clsEditionEtatOutilsSecurite.TI_ASDI;
        //    OP_EXTOURNE = clsEditionEtatOutilsSecurite.OP_EXTOURNE;
        //    OP_CREATIONJOURNE = clsEditionEtatOutilsSecurite.OP_CREATIONJOURNE;
        //    OP_FERMETUREJOURNE = clsEditionEtatOutilsSecurite.OP_FERMETUREJOURNE;
        //    SR_CODESERVICE = clsEditionEtatOutilsSecurite.SR_CODESERVICE;
        //    OP_CREATIONPROFILE = clsEditionEtatOutilsSecurite.OP_CREATIONPROFILE;
        //    OP_CREATIONOPERATEUR = clsEditionEtatOutilsSecurite.OP_CREATIONOPERATEUR; 

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
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
		}   
        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
		}          
        public string PO_CODEPROFIL
        {
            get { return _PO_CODEPROFIL; }
            set { _PO_CODEPROFIL = value; }
        }           
        public string TO_CODETYPEOERATEUR
        {
            get { return _TO_CODETYPEOERATEUR; }
            set { _TO_CODETYPEOERATEUR = value; }
        }           
        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }          
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }   
        public string PL_CODENUMCOMPTECOFFREFORT
        {
            get { return _PL_CODENUMCOMPTECOFFREFORT; }
            set { _PL_CODENUMCOMPTECOFFREFORT = value; }
        }         
        public string PL_NUMCOMPTECOFFREFORT
        {
            get { return _PL_NUMCOMPTECOFFREFORT; }
            set { _PL_NUMCOMPTECOFFREFORT = value; }
        }          
        public string PL_LIBELLE
        {
            get { return _PL_LIBELLE; }
            set { _PL_LIBELLE = value; }
        }      
        public string OP_NOMPRENOM
        {
            get { return _OP_NOMPRENOM; }
            set { _OP_NOMPRENOM = value; }
        }           
        public string OP_MOTPASSE
        {
            get { return _OP_MOTPASSE; }
            set { _OP_MOTPASSE = value; }
        }          
        public string OP_ACTIF
        {
            get { return _OP_ACTIF; }
            set { _OP_ACTIF = value; }
        }           
        public string OP_TELEPHONE
        {
            get { return _OP_TELEPHONE; }
            set { _OP_TELEPHONE = value; }
        }   
        public string OP_EMAIL
        {
            get { return _OP_EMAIL; }
            set { _OP_EMAIL = value; }
        }         
        public string OP_JOURNEEOUVERTE
        {
            get { return _OP_JOURNEEOUVERTE; }
            set { _OP_JOURNEEOUVERTE = value; }
        }           
        public string OP_GESTIONNAIRE
        {
            get { return _OP_GESTIONNAIRE; }
            set { _OP_GESTIONNAIRE = value; }
        }         
        public string OP_CAISSIER
        {
            get { return _OP_CAISSIER; }
            set { _OP_CAISSIER = value; }
        }         
        public string OP_DATESAISIE
        {
            get { return _OP_DATESAISIE; }
            set { _OP_DATESAISIE = value; }
        }
        public string PO_LIBELLE
        {
            get { return _PO_LIBELLE; }
            set { _PO_LIBELLE = value; }
        }
        public string OP_IMPRESSIONAUTOMATIQUE
        {
            get { return _OP_IMPRESSIONAUTOMATIQUE; }
            set { _OP_IMPRESSIONAUTOMATIQUE = value; }
        }
        public string OP_MONTANTTOTALENCAISSEAUTORISE
        {
            get { return _OP_MONTANTTOTALENCAISSEAUTORISE; }
            set { _OP_MONTANTTOTALENCAISSEAUTORISE = value; }
        }
        public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; }
        }
        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }
        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
        public string TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }

        public string PL_CODENUMCOMPTECLT
        {
            get { return _PL_CODENUMCOMPTECLT; }
            set { _PL_CODENUMCOMPTECLT = value; }
        }
        public string PL_NUMCOMPTECLT
        {
            get { return _PL_NUMCOMPTECLT; }
            set { _PL_NUMCOMPTECLT = value; }
        }
        public string NT_CODENATURETIERS
        {
            get { return _NT_CODENATURETIERS; }
            set { _NT_CODENATURETIERS = value; }
        }
        public string TI_TVA
        {
            get { return _TI_TVA; }
            set { _TI_TVA = value; }
        }
        public string TI_ASDI
        {
            get { return _TI_ASDI; }
            set { _TI_ASDI = value; }
        }
        public string OP_EXTOURNE
        {
            get { return _OP_EXTOURNE; }
            set { _OP_EXTOURNE = value; }
        }
        public string OP_CREATIONJOURNE
        {
            get { return _OP_CREATIONJOURNE; }
            set { _OP_CREATIONJOURNE = value; }
        }
        public string OP_FERMETUREJOURNE
        {
            get { return _OP_FERMETUREJOURNE; }
            set { _OP_FERMETUREJOURNE = value; }
        }
        public string SR_CODESERVICE
        {
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
        }
        public string OP_CREATIONPROFILE
        {
            get { return _OP_CREATIONPROFILE; }
            set { _OP_CREATIONPROFILE = value; }
        }
        public string OP_CREATIONOPERATEUR
        {
            get { return _OP_CREATIONOPERATEUR; }
            set { _OP_CREATIONOPERATEUR = value; }
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
            OP_CODEOPERATEUR = clsEditionEtatOutilsSecurite.OP_CODEOPERATEUR;
            AG_RAISONSOCIAL = clsEditionEtatOutilsSecurite.AG_RAISONSOCIAL;
            PO_CODEPROFIL = clsEditionEtatOutilsSecurite.PO_CODEPROFIL;
            TO_CODETYPEOERATEUR = clsEditionEtatOutilsSecurite.TO_CODETYPEOERATEUR;
            PL_CODENUMCOMPTE = clsEditionEtatOutilsSecurite.PL_CODENUMCOMPTE;
            PL_NUMCOMPTE = clsEditionEtatOutilsSecurite.PL_NUMCOMPTE;
            PL_CODENUMCOMPTECOFFREFORT = clsEditionEtatOutilsSecurite.PL_CODENUMCOMPTECOFFREFORT;
            PL_NUMCOMPTECOFFREFORT = clsEditionEtatOutilsSecurite.PL_NUMCOMPTECOFFREFORT;
            PL_LIBELLE = clsEditionEtatOutilsSecurite.PL_LIBELLE;
            OP_NOMPRENOM = clsEditionEtatOutilsSecurite.OP_NOMPRENOM;
            OP_MOTPASSE = clsEditionEtatOutilsSecurite.OP_MOTPASSE;
            OP_ACTIF = clsEditionEtatOutilsSecurite.OP_ACTIF;
            OP_TELEPHONE = clsEditionEtatOutilsSecurite.OP_TELEPHONE;
            OP_EMAIL = clsEditionEtatOutilsSecurite.OP_EMAIL;
            OP_JOURNEEOUVERTE = clsEditionEtatOutilsSecurite.OP_JOURNEEOUVERTE;
            OP_GESTIONNAIRE = clsEditionEtatOutilsSecurite.OP_GESTIONNAIRE;
            OP_CAISSIER = clsEditionEtatOutilsSecurite.OP_CAISSIER;
            OP_DATESAISIE = clsEditionEtatOutilsSecurite.OP_DATESAISIE;
            PO_LIBELLE = clsEditionEtatOutilsSecurite.PO_LIBELLE;
            OP_IMPRESSIONAUTOMATIQUE = clsEditionEtatOutilsSecurite.OP_IMPRESSIONAUTOMATIQUE;
            OP_MONTANTTOTALENCAISSEAUTORISE = clsEditionEtatOutilsSecurite.OP_MONTANTTOTALENCAISSEAUTORISE;
            EN_DENOMINATION = clsEditionEtatOutilsSecurite.EN_DENOMINATION;
            TI_IDTIERS = clsEditionEtatOutilsSecurite.TI_IDTIERS;
            TI_NUMTIERS = clsEditionEtatOutilsSecurite.TI_NUMTIERS;
            TI_DENOMINATION = clsEditionEtatOutilsSecurite.TI_DENOMINATION;
            PL_CODENUMCOMPTECLT = clsEditionEtatOutilsSecurite.PL_CODENUMCOMPTECLT;
            PL_NUMCOMPTECLT = clsEditionEtatOutilsSecurite.PL_NUMCOMPTECLT;
            NT_CODENATURETIERS = clsEditionEtatOutilsSecurite.NT_CODENATURETIERS;
            TI_TVA = clsEditionEtatOutilsSecurite.TI_TVA;
            TI_ASDI = clsEditionEtatOutilsSecurite.TI_ASDI;
            OP_EXTOURNE = clsEditionEtatOutilsSecurite.OP_EXTOURNE;
            OP_CREATIONJOURNE = clsEditionEtatOutilsSecurite.OP_CREATIONJOURNE;
            OP_FERMETUREJOURNE = clsEditionEtatOutilsSecurite.OP_FERMETUREJOURNE;
            SR_CODESERVICE = clsEditionEtatOutilsSecurite.SR_CODESERVICE;
            OP_CREATIONPROFILE = clsEditionEtatOutilsSecurite.OP_CREATIONPROFILE;
            OP_CREATIONOPERATEUR = clsEditionEtatOutilsSecurite.OP_CREATIONOPERATEUR;
		}
        }
}