

using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
    public class clsPhatiers 
    {

        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";

        private string _TI_IDTIERS = "";
        private string _TI_IDTIERSPRINCIPAL = "";
        private string _NT_CODENATURETYPETIERS = "";
        private string _FN_CODEFAMILLENATURETIERS = "";
        private string _NT_CODENATURETIERS = "";
        private string _PY_CODEPAYS = "";
        private string _VL_CODEVILLE = "";
        private string _TI_SIEGE = "";
        private string _SX_CODESEXE = "";
        private string _FM_CODEFORMEJURIDIQUE = "";
        //private string _SM_CODESITUATIONMATRIMONIALE = "";
        //private string _PF_CODEPROFESSION = "";
        private string _AC_CODEACTIVITE = "";
        private string _TP_CODETYPETIERS = "";
        private string _TC_CODECOMPTETYPETIERS = "";
        private string _TI_NUMTIERS = "";
        private DateTime _TI_DATENAISSANCE = DateTime.Parse("01/01/1900");
        private string _TI_DENOMINATION = "";
        private string _TI_DESCRIPTIONTIERS = "";
        private string _TI_ADRESSEPOSTALE = "";
        private string _TI_ADRESSEGEOGRAPHIQUE = "";
        private string _TI_TELEPHONE = "";
        private string _TI_FAX = "";
        private string _TI_SITEWEB = "";
        private string _TI_EMAIL = "";
        private string _TI_GERANT = "";
        private string _TI_STATUT = "N";
        private DateTime _TI_DATESAISIE = DateTime.Parse("01/01/1900");
        private DateTime _TI_DATEDEPART = DateTime.Parse("01/01/1900");
        private string _TI_ASDI = "N";
        private string _TI_TVA = "O";
        private int _TI_STATUTDOUTEUX = 0;
        private double _TI_PLAFONDCREDIT = 0;
        private string _TI_NUMCPTECONTIBUABLE = "";
        private string _OP_CODEOPERATEUR = "";
        private Byte[] _TI_PHOTO = null;
        private Byte[] _TI_SIGNATURE = null;
        private string _TYPEOPERATION = "";
        private string _PL_NUMCOMPTE = "";
        private double _TI_TAUXREMISE = 0;
        private string _CU_CODECASUTILISATION = "";
        private string _TI_NUMEROAGREMENT = "";
        private double _TI_TAUXDECLARATION = 0;
        private string _GP_CODEGROUPE = "";
        private string _TI_MANDATAIRE = "";
        private string _TI_USAGER = "";
        private string _IN_CODEINGREDIENT = "";
        private string _TI_ESCOMPTE = "N";
        private string _ZN_CODEZONE = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _TI_DATESAISIE1 = "";
        private string _TI_DATESAISIE2 = "";
        private string _SC_CODESECTION = "";
        private string _RE_CODEREGIMEIMPOSITION = "";
        private string _SP_CODESPECIALITE = "";
        private string _QU_CODEQUARTIER = "";
        private string _CO_CODECOMMUNE = "";
        private string _PF_CODEPROFESSION = "";
        private string _TI_LIEUNAISSANCE = "";
        private string _TI_NUMEROAXA = "";
        private string _TI_NUMWHATSAPP = "";
        private string _PY_CODEPAYSORIGINE = "";
        private string _TI_NUMEROASSUREUR = "";
        private string _TI_NOMINTERLOCUTEUR = "";

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

        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }

        public string TI_IDTIERSPRINCIPAL
        {
            get { return _TI_IDTIERSPRINCIPAL; }
            set { _TI_IDTIERSPRINCIPAL = value; }
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
        public string TI_SIEGE
        {
            get { return _TI_SIEGE; }
            set { _TI_SIEGE = value; }
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

        public string TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
        public DateTime TI_DATENAISSANCE
        {
            get { return _TI_DATENAISSANCE; }
            set { _TI_DATENAISSANCE = value; }
        }
        public string TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }
        public string TI_DESCRIPTIONTIERS
        {
            get { return _TI_DESCRIPTIONTIERS; }
            set { _TI_DESCRIPTIONTIERS = value; }
        }
        public string TI_ADRESSEPOSTALE
        {
            get { return _TI_ADRESSEPOSTALE; }
            set { _TI_ADRESSEPOSTALE = value; }
        }
        public string TI_ADRESSEGEOGRAPHIQUE
        {
            get { return _TI_ADRESSEGEOGRAPHIQUE; }
            set { _TI_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string TI_TELEPHONE
        {
            get { return _TI_TELEPHONE; }
            set { _TI_TELEPHONE = value; }
        }
        public string TI_FAX
        {
            get { return _TI_FAX; }
            set { _TI_FAX = value; }
        }
        public string TI_SITEWEB
        {
            get { return _TI_SITEWEB; }
            set { _TI_SITEWEB = value; }
        }
        public string TI_EMAIL
        {
            get { return _TI_EMAIL; }
            set { _TI_EMAIL = value; }
        }
        public string TI_GERANT
        {
            get { return _TI_GERANT; }
            set { _TI_GERANT = value; }
        }
        public string TI_STATUT
        {
            get { return _TI_STATUT; }
            set { _TI_STATUT = value; }
        }
        public DateTime TI_DATESAISIE
        {
            get { return _TI_DATESAISIE; }
            set { _TI_DATESAISIE = value; }
        }

        public DateTime TI_DATEDEPART
        {
            get { return _TI_DATEDEPART; }
            set { _TI_DATEDEPART = value; }
        }


        public string TI_ASDI
        {
            get { return _TI_ASDI; }
            set { _TI_ASDI = value; }
        }
        public string TI_TVA
        {
            get { return _TI_TVA; }
            set { _TI_TVA = value; }
        }
        public int TI_STATUTDOUTEUX
        {
            get { return _TI_STATUTDOUTEUX; }
            set { _TI_STATUTDOUTEUX = value; }
        }
        public double TI_PLAFONDCREDIT
        {
            get { return _TI_PLAFONDCREDIT; }
            set { _TI_PLAFONDCREDIT = value; }
        }
        public string TI_NUMCPTECONTIBUABLE
        {
            get { return _TI_NUMCPTECONTIBUABLE; }
            set { _TI_NUMCPTECONTIBUABLE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public Byte[] TI_PHOTO
        {
            get { return _TI_PHOTO; }
            set { _TI_PHOTO = value; }
        }

        public Byte[] TI_SIGNATURE
        {
            get { return _TI_SIGNATURE; }
            set { _TI_SIGNATURE = value; }
        }


        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public double TI_TAUXREMISE
        {
            get { return _TI_TAUXREMISE; }
            set { _TI_TAUXREMISE = value; }
        }

        public string CU_CODECASUTILISATION
        {
            get { return _CU_CODECASUTILISATION; }
            set { _CU_CODECASUTILISATION = value; }
        }
        public string TI_NUMEROAGREMENT
        {
            get { return _TI_NUMEROAGREMENT; }
            set { _TI_NUMEROAGREMENT = value; }
        }

        public double TI_TAUXDECLARATION
        {
            get { return _TI_TAUXDECLARATION; }
            set { _TI_TAUXDECLARATION = value; }
        }

        public string GP_CODEGROUPE
        {
            get { return _GP_CODEGROUPE; }
            set { _GP_CODEGROUPE = value; }
        }

        public string TI_MANDATAIRE
        {
            get { return _TI_MANDATAIRE; }
            set { _TI_MANDATAIRE = value; }
        }

        public string TI_USAGER
        {
            get { return _TI_USAGER; }
            set { _TI_USAGER = value; }
        }

        public string IN_CODEINGREDIENT
        {
            get { return _IN_CODEINGREDIENT; }
            set { _IN_CODEINGREDIENT = value; }
        }

        public string TI_ESCOMPTE
        {
            get { return _TI_ESCOMPTE; }
            set { _TI_ESCOMPTE = value; }
        }
        public string ZN_CODEZONE
        {
            get { return _ZN_CODEZONE; }
            set { _ZN_CODEZONE = value; }
        }
        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }
        public string TI_DATESAISIE1
        {
            get { return _TI_DATESAISIE1; }
            set { _TI_DATESAISIE1 = value; }
        }
        public string TI_DATESAISIE2
        {
            get { return _TI_DATESAISIE2; }
            set { _TI_DATESAISIE2 = value; }
        }
        public string SC_CODESECTION
        {
            get { return _SC_CODESECTION; }
            set { _SC_CODESECTION = value; }
        }


        public string RE_CODEREGIMEIMPOSITION
        {
            get { return _RE_CODEREGIMEIMPOSITION; }
            set { _RE_CODEREGIMEIMPOSITION = value; }
        }
        public string SP_CODESPECIALITE
        {
            get { return _SP_CODESPECIALITE; }
            set { _SP_CODESPECIALITE = value; }
        }
        public string QU_CODEQUARTIER
        {
            get { return _QU_CODEQUARTIER; }
            set { _QU_CODEQUARTIER = value; }
        }
        public string CO_CODECOMMUNE
        {
            get { return _CO_CODECOMMUNE; }
            set { _CO_CODECOMMUNE = value; }
        }


        public string PF_CODEPROFESSION
        {
            get { return _PF_CODEPROFESSION; }
            set { _PF_CODEPROFESSION = value; }
        }
       
        public string TI_LIEUNAISSANCE
        {
            get { return _TI_LIEUNAISSANCE; }
            set { _TI_LIEUNAISSANCE = value; }
        }
        public string TI_NUMEROAXA
        {
            get { return _TI_NUMEROAXA; }
            set { _TI_NUMEROAXA = value; }
        }
        public string TI_NUMWHATSAPP
        {
            get { return _TI_NUMWHATSAPP; }
            set { _TI_NUMWHATSAPP = value; }
        }
        public string PY_CODEPAYSORIGINE
        {
            get { return _PY_CODEPAYSORIGINE; }
            set { _PY_CODEPAYSORIGINE = value; }
        }
        public string TI_NUMEROASSUREUR
        {
            get { return _TI_NUMEROASSUREUR; }
            set { _TI_NUMEROASSUREUR = value; }
        }
        public string TI_NOMINTERLOCUTEUR
        {
            get { return _TI_NOMINTERLOCUTEUR; }
            set { _TI_NOMINTERLOCUTEUR = value; }
        }
        public clsPhatiers() { }

       

        public clsPhatiers(clsPhatiers clsPhatiers)
        {
            AG_CODEAGENCE = clsPhatiers.AG_CODEAGENCE;
            EN_CODEENTREPOT = clsPhatiers.EN_CODEENTREPOT;

            TI_IDTIERS = clsPhatiers.TI_IDTIERS;
            TI_IDTIERSPRINCIPAL = clsPhatiers.TI_IDTIERSPRINCIPAL;
            NT_CODENATURETYPETIERS = clsPhatiers.NT_CODENATURETYPETIERS;
            FN_CODEFAMILLENATURETIERS = clsPhatiers.FN_CODEFAMILLENATURETIERS;
            NT_CODENATURETIERS = clsPhatiers.NT_CODENATURETIERS;
            PY_CODEPAYS = clsPhatiers.PY_CODEPAYS;
            VL_CODEVILLE = clsPhatiers.VL_CODEVILLE;
            TI_SIEGE = clsPhatiers.TI_SIEGE;

            SX_CODESEXE = clsPhatiers.SX_CODESEXE;
            FM_CODEFORMEJURIDIQUE = clsPhatiers.FM_CODEFORMEJURIDIQUE;
            //SM_CODESITUATIONMATRIMONIALE = clsPhatiers.SM_CODESITUATIONMATRIMONIALE;
            //PF_CODEPROFESSION = clsPhatiers.PF_CODEPROFESSION;
            AC_CODEACTIVITE = clsPhatiers.AC_CODEACTIVITE;
            TP_CODETYPETIERS = clsPhatiers.TP_CODETYPETIERS;
            TC_CODECOMPTETYPETIERS = clsPhatiers.TC_CODECOMPTETYPETIERS;
            TI_NUMTIERS = clsPhatiers.TI_NUMTIERS;
            TI_DATENAISSANCE = clsPhatiers.TI_DATENAISSANCE;
            TI_DENOMINATION = clsPhatiers.TI_DENOMINATION;
            TI_DESCRIPTIONTIERS = clsPhatiers.TI_DESCRIPTIONTIERS;
            TI_ADRESSEPOSTALE = clsPhatiers.TI_ADRESSEPOSTALE;
            TI_ADRESSEGEOGRAPHIQUE = clsPhatiers.TI_ADRESSEGEOGRAPHIQUE;
            TI_TELEPHONE = clsPhatiers.TI_TELEPHONE;
            TI_FAX = clsPhatiers.TI_FAX;
            TI_SITEWEB = clsPhatiers.TI_SITEWEB;
            TI_EMAIL = clsPhatiers.TI_EMAIL;
            TI_GERANT = clsPhatiers.TI_GERANT;
            TI_STATUT = clsPhatiers.TI_STATUT;
            TI_DATESAISIE = clsPhatiers.TI_DATESAISIE;
            TI_DATEDEPART = clsPhatiers.TI_DATEDEPART;
            TI_ASDI = clsPhatiers.TI_ASDI;
            TI_TVA = clsPhatiers.TI_TVA;
            TI_STATUTDOUTEUX = clsPhatiers.TI_STATUTDOUTEUX;
            TI_PLAFONDCREDIT = clsPhatiers.TI_PLAFONDCREDIT;
            TI_NUMCPTECONTIBUABLE = clsPhatiers.TI_NUMCPTECONTIBUABLE;
            OP_CODEOPERATEUR = clsPhatiers.OP_CODEOPERATEUR;
            TI_PHOTO = clsPhatiers.TI_PHOTO;
            TI_SIGNATURE = clsPhatiers.TI_SIGNATURE;
            TYPEOPERATION = clsPhatiers.TYPEOPERATION;
            PL_NUMCOMPTE = clsPhatiers.PL_NUMCOMPTE;
            TI_TAUXREMISE = clsPhatiers.TI_TAUXREMISE;
            CU_CODECASUTILISATION = clsPhatiers.CU_CODECASUTILISATION;
            TI_NUMEROAGREMENT = clsPhatiers.TI_NUMEROAGREMENT;
            TI_TAUXDECLARATION = clsPhatiers.TI_TAUXDECLARATION;
            GP_CODEGROUPE = clsPhatiers.GP_CODEGROUPE;
            TI_MANDATAIRE = clsPhatiers.TI_MANDATAIRE;
            TI_USAGER = clsPhatiers.TI_USAGER;
            IN_CODEINGREDIENT = clsPhatiers.IN_CODEINGREDIENT;
            TI_ESCOMPTE = clsPhatiers.TI_ESCOMPTE;
            ZN_CODEZONE = clsPhatiers.ZN_CODEZONE;
            PL_CODENUMCOMPTE = clsPhatiers.PL_CODENUMCOMPTE;
            TI_DATESAISIE1 = clsPhatiers.TI_DATESAISIE1;
            TI_DATESAISIE2 = clsPhatiers.TI_DATESAISIE2;
            SC_CODESECTION = clsPhatiers.SC_CODESECTION;
            RE_CODEREGIMEIMPOSITION = clsPhatiers.RE_CODEREGIMEIMPOSITION;
            SP_CODESPECIALITE = clsPhatiers.SP_CODESPECIALITE;
            QU_CODEQUARTIER = clsPhatiers.QU_CODEQUARTIER;
            CO_CODECOMMUNE = clsPhatiers.CO_CODECOMMUNE;
            PF_CODEPROFESSION = clsPhatiers.PF_CODEPROFESSION;
            TI_LIEUNAISSANCE = clsPhatiers.TI_LIEUNAISSANCE;
            TI_NUMEROAXA = clsPhatiers.TI_NUMEROAXA;
            TI_NUMWHATSAPP = clsPhatiers.TI_NUMWHATSAPP;
            PY_CODEPAYSORIGINE = clsPhatiers.PY_CODEPAYSORIGINE;
            TI_NUMEROASSUREUR = clsPhatiers.TI_NUMEROASSUREUR;
            TI_NOMINTERLOCUTEUR = clsPhatiers.TI_NOMINTERLOCUTEUR;

        }
    }
}