

using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
    public class clsOrgProspects : clsEntitieBase
    {

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";

        private string _PR_IDTIERS = "";
        private string _PR_IDTIERSPRINCIPAL = "";
        private string _NT_CODENATURETYPETIERS = "";
        private string _FN_CODEFAMILLENATURETIERS = "";
        private string _NT_CODENATURETIERS = "";
        private string _PY_CODEPAYS = "";
        private string _VL_CODEVILLE = "";
        private string _PR_SIEGE = "";
        private string _SX_CODESEXE = "";
        private string _FM_CODEFORMEJURIDIQUE = "";
        //private string _SM_CODESITUATIONMATRIMONIALE = "";
        //private string _PF_CODEPROFESSION = "";
        private string _AC_CODEACTIVITE = "";
        private string _TP_CODETYPETIERS = "";
        private string _TC_CODECOMPTETYPETIERS = "";
        private string _PR_NUMTIERS = "";
        private string _PR_DATENAISSANCE = "01-01-1900";
        private string _PR_DENOMINATION = "";
        private string _PR_DESCRIPTIONTIERS = "";
        private string _PR_ADRESSEPOSTALE = "";
        private string _PR_ADRESSEGEOGRAPHIQUE = "";
        private string _PR_TELEPHONE = "";
        private string _PR_FAX = "";
        private string _PR_SITEWEB = "";
        private string _PR_EMAIL = "";
        private string _PR_GERANT = "";
        private string _PR_STATUT = "N";
        private string _PR_DATESAISIE = "01-01-1900";
        private string _PR_DATEDEPART = "01-01-1900";
        private string _PR_ASDI = "N";
        private string _PR_TVA = "O";
        private string _PR_STATUTDOUTEUX = "0";
        private string _PR_PLAFONDCREDIT = "0";
        private string _PR_NUMCPTECONTIBUABLE = "";
        private string _OP_CODEOPERATEUR = "";
        private string _PR_PHOTO = "";
        private string _PR_SIGNATURE = "";
        //private string _TYPEOPERATION = "";
        private string _PL_NUMCOMPTE = "";
        private string _PR_TAUXREMISE = "0";
        private string _CU_CODECASUTILISATION = "";
        private string _PR_NUMEROAGREMENT = "";
        private string _PR_TAUXDECLARATION = "0";
        private string _GP_CODEGROUPE = "";
        private string _PR_MANDATAIRE = "";
        private string _PR_USAGER = "";
        private string _IN_CODEINGREDIENT = "";
        private string _PR_ESCOMPTE = "N";
        private string _PR_DATESAISIE1 = "";
        private string _PR_DATESAISIE2 = "";
        private string _SC_CODESECTION = "";
        private string _PR_CLTVENTCAISSE = "";
        private string _AP_CODEPRODUIT = "";

        private string _PF_CODEPROFESSION = "";
        private string _PF_LIBELLE = "";
        private string _TI_LIEUNAISSANCE = "";


        private string _OP_NOMPRENOM = "";
        private string _SX_LIBELLE = "";
        private string _TC_LIBELLE = "";
        private string _AC_LIBELLE = "";
        private string _CU_LIBELLE = "";
        private string _RE_LIBELLEREGIMEIMPOSITION = "";
        private string _SP_LIBELLESPECIALITE = "";
        private string _GP_LIBELLE = "";
        private string _TP_LIBELLE = "";
        private string _NT_LIBELLE = "";
        private string _PY_LIBELLE = "";
        private string _VL_LIBELLE = "";
        private string _EN_DENOMINATION = "";
        private string _ZN_NOMZONE = "";



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

        public string PR_IDTIERS
        {
            get { return _PR_IDTIERS; }
            set { _PR_IDTIERS = value; }
        }

        public string PR_IDTIERSPRINCIPAL
        {
            get { return _PR_IDTIERSPRINCIPAL; }
            set { _PR_IDTIERSPRINCIPAL = value; }
        }

        public string NT_CODENATURETYPETIERS
        {
            get { return _NT_CODENATURETYPETIERS; }
            set { _NT_CODENATURETYPETIERS = value; }
        }


        public string FN_CODEFAMILLENATURETIERS
        {
            get { return _FN_CODEFAMILLENATURETIERS; }
            set { _FN_CODEFAMILLENATURETIERS = value; }
        }
        public string NT_CODENATURETIERS
        {
            get { return _NT_CODENATURETIERS; }
            set { _NT_CODENATURETIERS = value; }
        }
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string VL_CODEVILLE
        {
            get { return _VL_CODEVILLE; }
            set { _VL_CODEVILLE = value; }
        }
        public string PR_SIEGE
        {
            get { return _PR_SIEGE; }
            set { _PR_SIEGE = value; }
        }
        public string SX_CODESEXE
        {
            get { return _SX_CODESEXE; }
            set { _SX_CODESEXE = value; }
        }

        public string FM_CODEFORMEJURIDIQUE
        {
            get { return _FM_CODEFORMEJURIDIQUE; }
            set { _FM_CODEFORMEJURIDIQUE = value; }
        }
        //public string SM_CODESITUATIONMATRIMONIALE
        //{
        //    get { return _SM_CODESITUATIONMATRIMONIALE; }
        //    set { _SM_CODESITUATIONMATRIMONIALE = value; }
        //}
        //public string PF_CODEPROFESSION
        //{
        //    get { return _PF_CODEPROFESSION; }
        //    set { _PF_CODEPROFESSION = value; }
        //}
        public string AC_CODEACTIVITE
        {
            get { return _AC_CODEACTIVITE; }
            set { _AC_CODEACTIVITE = value; }
        }
        public string TP_CODETYPETIERS
        {
            get { return _TP_CODETYPETIERS; }
            set { _TP_CODETYPETIERS = value; }
        }

        public string TC_CODECOMPTETYPETIERS
        {
            get { return _TC_CODECOMPTETYPETIERS; }
            set { _TC_CODECOMPTETYPETIERS = value; }
        }

        public string PR_NUMTIERS
        {
            get { return _PR_NUMTIERS; }
            set { _PR_NUMTIERS = value; }
        }
        public string PR_DATENAISSANCE
        {
            get { return _PR_DATENAISSANCE; }
            set { _PR_DATENAISSANCE = value; }
        }
        public string PR_DENOMINATION
        {
            get { return _PR_DENOMINATION; }
            set { _PR_DENOMINATION = value; }
        }
        public string PR_DESCRIPTIONTIERS
        {
            get { return _PR_DESCRIPTIONTIERS; }
            set { _PR_DESCRIPTIONTIERS = value; }
        }
        public string PR_ADRESSEPOSTALE
        {
            get { return _PR_ADRESSEPOSTALE; }
            set { _PR_ADRESSEPOSTALE = value; }
        }
        public string PR_ADRESSEGEOGRAPHIQUE
        {
            get { return _PR_ADRESSEGEOGRAPHIQUE; }
            set { _PR_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string PR_TELEPHONE
        {
            get { return _PR_TELEPHONE; }
            set { _PR_TELEPHONE = value; }
        }
        public string PR_FAX
        {
            get { return _PR_FAX; }
            set { _PR_FAX = value; }
        }
        public string PR_SITEWEB
        {
            get { return _PR_SITEWEB; }
            set { _PR_SITEWEB = value; }
        }
        public string PR_EMAIL
        {
            get { return _PR_EMAIL; }
            set { _PR_EMAIL = value; }
        }
        public string PR_GERANT
        {
            get { return _PR_GERANT; }
            set { _PR_GERANT = value; }
        }
        public string PR_STATUT
        {
            get { return _PR_STATUT; }
            set { _PR_STATUT = value; }
        }
        public string PR_DATESAISIE
        {
            get { return _PR_DATESAISIE; }
            set { _PR_DATESAISIE = value; }
        }

        public string PR_DATEDEPART
        {
            get { return _PR_DATEDEPART; }
            set { _PR_DATEDEPART = value; }
        }


        public string PR_ASDI
        {
            get { return _PR_ASDI; }
            set { _PR_ASDI = value; }
        }
        public string PR_TVA
        {
            get { return _PR_TVA; }
            set { _PR_TVA = value; }
        }
        public string PR_STATUTDOUTEUX
        {
            get { return _PR_STATUTDOUTEUX; }
            set { _PR_STATUTDOUTEUX = value; }
        }
        public string PR_PLAFONDCREDIT
        {
            get { return _PR_PLAFONDCREDIT; }
            set { _PR_PLAFONDCREDIT = value; }
        }
        public string PR_NUMCPTECONTIBUABLE
        {
            get { return _PR_NUMCPTECONTIBUABLE; }
            set { _PR_NUMCPTECONTIBUABLE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string PR_PHOTO
        {
            get { return _PR_PHOTO; }
            set { _PR_PHOTO = value; }
        }

        public string PR_SIGNATURE
        {
            get { return _PR_SIGNATURE; }
            set { _PR_SIGNATURE = value; }
        }


        //public string TYPEOPERATION
        //{
        //    get { return _TYPEOPERATION; }
        //    set { _TYPEOPERATION = value; }
        //}
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public string PR_TAUXREMISE
        {
            get { return _PR_TAUXREMISE; }
            set { _PR_TAUXREMISE = value; }
        }

        public string CU_CODECASUTILISATION
        {
            get { return _CU_CODECASUTILISATION; }
            set { _CU_CODECASUTILISATION = value; }
        }
        public string PR_NUMEROAGREMENT
        {
            get { return _PR_NUMEROAGREMENT; }
            set { _PR_NUMEROAGREMENT = value; }
        }

        public string PR_TAUXDECLARATION
        {
            get { return _PR_TAUXDECLARATION; }
            set { _PR_TAUXDECLARATION = value; }
        }

        public string GP_CODEGROUPE
        {
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
        }

        public string PR_MANDATAIRE
        {
            get { return _PR_MANDATAIRE; }
            set { _PR_MANDATAIRE = value; }
        }

        public string PR_USAGER
        {
            get { return _PR_USAGER; }
            set { _PR_USAGER = value; }
        }

        public string IN_CODEINGREDIENT
        {
            get { return _IN_CODEINGREDIENT; }
            set { _IN_CODEINGREDIENT = value; }
        }

        public string PR_ESCOMPTE
        {
            get { return _PR_ESCOMPTE; }
            set { _PR_ESCOMPTE = value; }
        }
        public string PR_DATESAISIE1
        {
            get { return _PR_DATESAISIE1; }
            set { _PR_DATESAISIE1 = value; }
        }
        public string PR_DATESAISIE2
        {
            get { return _PR_DATESAISIE2; }
            set { _PR_DATESAISIE2 = value; }
        }
        public string SC_CODESECTION
        {
            get { return _SC_CODESECTION; }
            set { _SC_CODESECTION = value; }
        }
        public string PR_CLTVENTCAISSE
        {
            get { return _PR_CLTVENTCAISSE; }
            set { _PR_CLTVENTCAISSE = value; }
        }
        public string AP_CODEPRODUIT
        {
            get { return _AP_CODEPRODUIT; }
            set { _AP_CODEPRODUIT = value; }
        }


        public string PF_CODEPROFESSION
        {
            get { return _PF_CODEPROFESSION; }
            set { _PF_CODEPROFESSION = value; }
        }
        public string PF_LIBELLE
        {
            get { return _PF_LIBELLE; }
            set { _PF_LIBELLE = value; }
        }
        public string TI_LIEUNAISSANCE
        {
            get { return _TI_LIEUNAISSANCE; }
            set { _TI_LIEUNAISSANCE = value; }
        }
        public string OP_NOMPRENOM
        {
            get { return _OP_NOMPRENOM; }
            set { _OP_NOMPRENOM = value; }
        }
        public string SX_LIBELLE
        {
            get { return _SX_LIBELLE; }
            set { _SX_LIBELLE = value; }
        }
        public string TC_LIBELLE
        {
            get { return _TC_LIBELLE; }
            set { _TC_LIBELLE = value; }
        }
        public string AC_LIBELLE
        {
            get { return _AC_LIBELLE; }
            set { _AC_LIBELLE = value; }
        }
        public string CU_LIBELLE
        {
            get { return _CU_LIBELLE; }
            set { _CU_LIBELLE = value; }
        }
        public string RE_LIBELLEREGIMEIMPOSITION
        {
            get { return _RE_LIBELLEREGIMEIMPOSITION; }
            set { _RE_LIBELLEREGIMEIMPOSITION = value; }
        }
        public string SP_LIBELLESPECIALITE
        {
            get { return _SP_LIBELLESPECIALITE; }
            set { _SP_LIBELLESPECIALITE = value; }
        }
        public string GP_LIBELLE
        {
            get { return _GP_LIBELLE; }
            set { _GP_LIBELLE = value; }
        }
        public string TP_LIBELLE
        {
            get { return _TP_LIBELLE; }
            set { _TP_LIBELLE = value; }
        }
        public string NT_LIBELLE
        {
            get { return _NT_LIBELLE; }
            set { _NT_LIBELLE = value; }
        }
        public string PY_LIBELLE
        {
            get { return _PY_LIBELLE; }
            set { _PY_LIBELLE = value; }
        }
        public string VL_LIBELLE
        {
            get { return _VL_LIBELLE; }
            set { _VL_LIBELLE = value; }
        }
        public string EN_DENOMINATION
        {
            get { return _EN_DENOMINATION; }
            set { _EN_DENOMINATION = value; }
        }

        public string ZN_NOMZONE
        {
            get { return _ZN_NOMZONE; }
            set { _ZN_NOMZONE = value; }
        }


        public clsOrgProspects() { }

       

        public clsOrgProspects(clsOrgProspects clsOrgProspects)
        {
            AG_CODEAGENCE = clsOrgProspects.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsOrgProspects.EN_CODEENTREPOT;

            PR_IDTIERS = clsOrgProspects.PR_IDTIERS;
            PR_IDTIERSPRINCIPAL = clsOrgProspects.PR_IDTIERSPRINCIPAL;
            NT_CODENATURETYPETIERS = clsOrgProspects.NT_CODENATURETYPETIERS;
            FN_CODEFAMILLENATURETIERS = clsOrgProspects.FN_CODEFAMILLENATURETIERS;
            NT_CODENATURETIERS = clsOrgProspects.NT_CODENATURETIERS;
            PY_CODEPAYS = clsOrgProspects.PY_CODEPAYS;
            VL_CODEVILLE = clsOrgProspects.VL_CODEVILLE;
            PR_SIEGE = clsOrgProspects.PR_SIEGE;

            SX_CODESEXE = clsOrgProspects.SX_CODESEXE;
            FM_CODEFORMEJURIDIQUE = clsOrgProspects.FM_CODEFORMEJURIDIQUE;
            //SM_CODESITUATIONMATRIMONIALE = clsOrgProspects.SM_CODESITUATIONMATRIMONIALE;
            //PF_CODEPROFESSION = clsOrgProspects.PF_CODEPROFESSION;
            AC_CODEACTIVITE = clsOrgProspects.AC_CODEACTIVITE;
            TP_CODETYPETIERS = clsOrgProspects.TP_CODETYPETIERS;
            TC_CODECOMPTETYPETIERS = clsOrgProspects.TC_CODECOMPTETYPETIERS;
            PR_NUMTIERS = clsOrgProspects.PR_NUMTIERS;
            PR_DATENAISSANCE = clsOrgProspects.PR_DATENAISSANCE;
            PR_DENOMINATION = clsOrgProspects.PR_DENOMINATION;
            PR_DESCRIPTIONTIERS = clsOrgProspects.PR_DESCRIPTIONTIERS;
            PR_ADRESSEPOSTALE = clsOrgProspects.PR_ADRESSEPOSTALE;
            PR_ADRESSEGEOGRAPHIQUE = clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE;
            PR_TELEPHONE = clsOrgProspects.PR_TELEPHONE;
            PR_FAX = clsOrgProspects.PR_FAX;
            PR_SITEWEB = clsOrgProspects.PR_SITEWEB;
            PR_EMAIL = clsOrgProspects.PR_EMAIL;
            PR_GERANT = clsOrgProspects.PR_GERANT;
            PR_STATUT = clsOrgProspects.PR_STATUT;
            PR_DATESAISIE = clsOrgProspects.PR_DATESAISIE;
            PR_DATEDEPART = clsOrgProspects.PR_DATEDEPART;
            PR_ASDI = clsOrgProspects.PR_ASDI;
            PR_TVA = clsOrgProspects.PR_TVA;
            PR_STATUTDOUTEUX = clsOrgProspects.PR_STATUTDOUTEUX;
            PR_PLAFONDCREDIT = clsOrgProspects.PR_PLAFONDCREDIT;
            PR_NUMCPTECONTIBUABLE = clsOrgProspects.PR_NUMCPTECONTIBUABLE;
            OP_CODEOPERATEUR = clsOrgProspects.OP_CODEOPERATEUR;
            PR_PHOTO = clsOrgProspects.PR_PHOTO;
            PR_SIGNATURE = clsOrgProspects.PR_SIGNATURE;
            TYPEOPERATION = clsOrgProspects.TYPEOPERATION;
            PL_NUMCOMPTE = clsOrgProspects.PL_NUMCOMPTE;
            PR_TAUXREMISE = clsOrgProspects.PR_TAUXREMISE;
            CU_CODECASUTILISATION = clsOrgProspects.CU_CODECASUTILISATION;
            PR_NUMEROAGREMENT = clsOrgProspects.PR_NUMEROAGREMENT;
            PR_TAUXDECLARATION = clsOrgProspects.PR_TAUXDECLARATION;
            GP_CODEGROUPE = clsOrgProspects.GP_CODEGROUPE;
            PR_MANDATAIRE = clsOrgProspects.PR_MANDATAIRE;
            PR_USAGER = clsOrgProspects.PR_USAGER;
            IN_CODEINGREDIENT = clsOrgProspects.IN_CODEINGREDIENT;
            PR_ESCOMPTE = clsOrgProspects.PR_ESCOMPTE;
            PR_DATESAISIE1 = clsOrgProspects.PR_DATESAISIE1;
            PR_DATESAISIE2 = clsOrgProspects.PR_DATESAISIE2;
            SC_CODESECTION = clsOrgProspects.SC_CODESECTION;
            PR_CLTVENTCAISSE = clsOrgProspects.PR_CLTVENTCAISSE;
            AP_CODEPRODUIT = clsOrgProspects.AP_CODEPRODUIT;

            PF_CODEPROFESSION = clsOrgProspects.PF_CODEPROFESSION;
            PF_LIBELLE = clsOrgProspects.PF_LIBELLE;
            TI_LIEUNAISSANCE = clsOrgProspects.TI_LIEUNAISSANCE;
            OP_NOMPRENOM = clsOrgProspects.OP_NOMPRENOM;
            SX_LIBELLE = clsOrgProspects.SX_LIBELLE;
            TC_LIBELLE = clsOrgProspects.TC_LIBELLE;
            AC_LIBELLE = clsOrgProspects.AC_LIBELLE;
            CU_LIBELLE = clsOrgProspects.CU_LIBELLE;
            RE_LIBELLEREGIMEIMPOSITION = clsOrgProspects.RE_LIBELLEREGIMEIMPOSITION;
            SP_LIBELLESPECIALITE = clsOrgProspects.SP_LIBELLESPECIALITE;
            TP_LIBELLE = clsOrgProspects.TP_LIBELLE;
            NT_LIBELLE = clsOrgProspects.NT_LIBELLE;
            PY_LIBELLE = clsOrgProspects.PY_LIBELLE;
            VL_LIBELLE = clsOrgProspects.VL_LIBELLE;
            EN_DENOMINATION = clsOrgProspects.EN_DENOMINATION;
            ZN_NOMZONE = clsOrgProspects.ZN_NOMZONE;


        }
    }
}