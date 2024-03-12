using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEditionEtatStock : clsEntitieBase
    {
        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _TP_CODETYPETIERS = "";
        private string _ET_TYPELISTE= "";
        private string _OP_CODEOPERATEUREDITION = "";
        private string _GP_CODEGROUPE = "";
        private string _PY_CODEPAYS = "";   
        private string _NT_CODENATURETIERS = "";
        private string _ET_TYPEETAT = "";

        //private string _AG_CODEAGENCE = "";
        private string _MS_NUMPIECE = "";
        private string _MS_NUMSEQUENCE = "";
        private string _NUMEROBORDEREAU = "";
        private string _MK_DATEPIECE = "";
        private string _MS_DATEPIECE = "";
        private string _CL_NUMCLIENT = "";
        private string _CL_DENOMINATION = "";
        private string _CL_TELEPHONE = "";
        private string _CL_ADRESSEGEOGRAPHIQUE = "";

        private string _FR_MATRICULE = "";
        private string _FR_DENOMINATION = "";
        private string _FR_TELEPHONE = "";
        private string _FR_ADRESSEGEOGRAPHIQUE = "";

        private string _TI_IDTIERS = "";
        private string _TI_NUMTIERS = "";
        private string _TI_DENOMINATION = "";
        private string _TI_TELEPHONE = "";
        private string _TI_ADRESSEGEOGRAPHIQUE = "";


        private double _MK_MONTANT =0;
        private double _MK_MONTANTTOTALREMISE = 0;
        private double _MK_MONTANTTRANSPORT = 0;
        private double _MK_MONTANTVERSE =0;

        private double _MS_MONTANT = 0;
        private double _MS_MONTANTTOTALREMISE = 0;
        private double _MS_MONTANTTRANSPORT =0;
        private double _MS_MONTANTVERSE = 0;
        private double _MD_QUANTITESORTIE = 0;
        private double _LV_QUANTITELIVRER = 0;
        private string _ZC_CODE = "";

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

        public string GP_CODEGROUPE
		{
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
		}

    

        public string ET_TYPELISTE
		{
            get { return _ET_TYPELISTE; }
            set { _ET_TYPELISTE= value; }
		}

        public string NT_CODENATURETIERS
		{
            get { return _NT_CODENATURETIERS; }
            set { _NT_CODENATURETIERS = value; }
		}
       
        public string ET_TYPEETAT
		{
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
		}

      
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }


        public string MS_NUMPIECE
        {
            get { return _MS_NUMPIECE; }
            set { _MS_NUMPIECE = value; }
        }

        public string MS_NUMSEQUENCE
        {
            get { return _MS_NUMSEQUENCE; }
            set { _MS_NUMSEQUENCE = value; }
        }
        public string NUMEROBORDEREAU
        {
            get { return _NUMEROBORDEREAU; }
            set { _NUMEROBORDEREAU = value; }
        }
        public string MK_DATEPIECE
        {
            get { return _MK_DATEPIECE; }
            set { _MK_DATEPIECE = value; }
        }
        public string MS_DATEPIECE
        {
            get { return _MS_DATEPIECE; }
            set { _MS_DATEPIECE = value; }
        }

        public string CL_NUMCLIENT
        {
            get { return _CL_NUMCLIENT; }
            set { _CL_NUMCLIENT = value; }
        }

        public string CL_DENOMINATION
        {
            get { return _CL_DENOMINATION; }
            set { _CL_DENOMINATION = value; }
        }

        public string CL_TELEPHONE
        {
            get { return _CL_TELEPHONE; }
            set { _CL_TELEPHONE = value; }
        }

        public string CL_ADRESSEGEOGRAPHIQUE
        {
            get { return _CL_ADRESSEGEOGRAPHIQUE; }
            set { _CL_ADRESSEGEOGRAPHIQUE = value; }
        }

        public string FR_MATRICULE
        {
            get { return _FR_MATRICULE; }
            set { _FR_MATRICULE = value; }
        }

        public string FR_DENOMINATION
        {
            get { return _FR_DENOMINATION; }
            set { _FR_DENOMINATION = value; }
        }

        public string FR_TELEPHONE
        {
            get { return _FR_TELEPHONE; }
            set { _FR_TELEPHONE = value; }
        }

        public string FR_ADRESSEGEOGRAPHIQUE
        {
            get { return _FR_ADRESSEGEOGRAPHIQUE; }
            set { _FR_ADRESSEGEOGRAPHIQUE = value; }
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

        public string TI_TELEPHONE
        {
            get { return _TI_TELEPHONE; }
            set { _TI_TELEPHONE = value; }
        }

        public string TI_ADRESSEGEOGRAPHIQUE
        {
            get { return _TI_ADRESSEGEOGRAPHIQUE; }
            set { _TI_ADRESSEGEOGRAPHIQUE = value; }
        }

        public double MK_MONTANT
        {
            get { return _MK_MONTANT; }
            set { _MK_MONTANT = value; }
        }

        public double MK_MONTANTTOTALREMISE
        {
            get { return _MK_MONTANTTOTALREMISE; }
            set { _MK_MONTANTTOTALREMISE = value; }
        }

        public double MK_MONTANTTRANSPORT
        {
            get { return _MK_MONTANTTRANSPORT; }
            set { _MK_MONTANTTRANSPORT = value; }
        }


        public double MK_MONTANTVERSE
        {
            get { return _MK_MONTANTVERSE; }
            set { _MK_MONTANTVERSE = value; }
        }
        public double MS_MONTANT
        {
            get { return _MS_MONTANT; }
            set { _MS_MONTANT = value; }
        }

        public double MS_MONTANTTOTALREMISE
        {
            get { return _MS_MONTANTTOTALREMISE; }
            set { _MS_MONTANTTOTALREMISE = value; }
        }

        public double MS_MONTANTTRANSPORT
        {
            get { return _MS_MONTANTTRANSPORT; }
            set { _MS_MONTANTTRANSPORT = value; }
        }

        public double MS_MONTANTVERSE
        {
            get { return _MS_MONTANTVERSE; }
            set { _MS_MONTANTVERSE = value; }
        }

        public double MD_QUANTITESORTIE
        {
            get { return _MD_QUANTITESORTIE; }
            set { _MD_QUANTITESORTIE = value; }
        }

        public double LV_QUANTITELIVRER
        {
            get { return _LV_QUANTITELIVRER; }
            set { _LV_QUANTITELIVRER = value; }
        }
        public string ZC_CODE
        {
            get { return _ZC_CODE; }
            set { _ZC_CODE = value; }
        }

        public clsEditionEtatStock() {} 

		

		public clsEditionEtatStock(clsEditionEtatStock clsEditionEtatStock)
		{
			AG_CODEAGENCE = clsEditionEtatStock.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsEditionEtatStock.EN_CODEENTREPOT;
            TP_CODETYPETIERS = clsEditionEtatStock.TP_CODETYPETIERS;
			OP_CODEOPERATEUREDITION = clsEditionEtatStock.OP_CODEOPERATEUREDITION;
            GP_CODEGROUPE = clsEditionEtatStock.GP_CODEGROUPE;
            ET_TYPELISTE= clsEditionEtatStock.ET_TYPELISTE;
            NT_CODENATURETIERS = clsEditionEtatStock.NT_CODENATURETIERS;
            ET_TYPEETAT = clsEditionEtatStock.ET_TYPEETAT;
            PY_CODEPAYS = clsEditionEtatStock.PY_CODEPAYS;

            AG_CODEAGENCE = clsEditionEtatStock.AG_CODEAGENCE;
            MS_NUMPIECE = clsEditionEtatStock.MS_NUMPIECE;
            MS_NUMSEQUENCE = clsEditionEtatStock.MS_NUMSEQUENCE;
            NUMEROBORDEREAU = clsEditionEtatStock.NUMEROBORDEREAU;
            MK_DATEPIECE = clsEditionEtatStock.MK_DATEPIECE;
            MS_DATEPIECE = clsEditionEtatStock.MS_DATEPIECE;
            CL_NUMCLIENT = clsEditionEtatStock.CL_NUMCLIENT;
            CL_DENOMINATION = clsEditionEtatStock.CL_DENOMINATION;
            CL_TELEPHONE = clsEditionEtatStock.CL_TELEPHONE;
            CL_ADRESSEGEOGRAPHIQUE = clsEditionEtatStock.CL_ADRESSEGEOGRAPHIQUE;

            FR_MATRICULE = clsEditionEtatStock.FR_MATRICULE;
            FR_DENOMINATION = clsEditionEtatStock.FR_DENOMINATION;
            FR_TELEPHONE = clsEditionEtatStock.FR_TELEPHONE;
            FR_ADRESSEGEOGRAPHIQUE = clsEditionEtatStock.FR_ADRESSEGEOGRAPHIQUE;

            TI_IDTIERS=clsEditionEtatStock.TI_IDTIERS ;
            TI_NUMTIERS=clsEditionEtatStock.TI_NUMTIERS;
            TI_DENOMINATION=clsEditionEtatStock.TI_DENOMINATION;
            TI_TELEPHONE=clsEditionEtatStock.TI_TELEPHONE;
            TI_ADRESSEGEOGRAPHIQUE=clsEditionEtatStock.TI_ADRESSEGEOGRAPHIQUE;


            MK_MONTANT=clsEditionEtatStock.MK_MONTANT;
            MK_MONTANTTOTALREMISE=clsEditionEtatStock.MK_MONTANTTOTALREMISE;
            MK_MONTANTTRANSPORT=clsEditionEtatStock.MK_MONTANTTRANSPORT;
            MK_MONTANTVERSE=clsEditionEtatStock.MK_MONTANTVERSE;

            MS_MONTANT=clsEditionEtatStock.MS_MONTANT ;
            MS_MONTANTTOTALREMISE=clsEditionEtatStock.MS_MONTANTTOTALREMISE;
            MS_MONTANTTRANSPORT=clsEditionEtatStock.MS_MONTANTTRANSPORT;
            MS_MONTANTVERSE=clsEditionEtatStock.MS_MONTANTVERSE ;
            MD_QUANTITESORTIE=clsEditionEtatStock.MD_QUANTITESORTIE;
            LV_QUANTITELIVRER=clsEditionEtatStock.LV_QUANTITELIVRER;
            ZC_CODE = clsEditionEtatStock.ZC_CODE;

        }
        }
}