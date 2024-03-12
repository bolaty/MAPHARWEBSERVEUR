

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
    public class clsPhaclient
    {

        private string _AG_CODEAGENCE = "";
        private string _CL_IDCLIENT = "";
        private string _SX_CODESEXE = "";
        private string _SM_CODESITUATIONMATRIMONIALE = "";
        private string _PF_CODEPROFESSION = "";
        private string _AC_CODEACTIVITE = "";
        private string _TP_CODETYPECLIENT = "";
        private string _CL_NUMCLIENT = "";
        private DateTime _CL_DATENAISSANCE = DateTime.Parse("01/01/1900");
        private string _CL_DENOMINATION = "";
        private string _CL_DESCRIPTIONCLIENT = "";
        private string _CL_ADRESSEPOSTALE = "";
        private string _CL_ADRESSEGEOGRAPHIQUE = "";
        private string _CL_TELEPHONE = "";
        private string _CL_FAX = "";
        private string _CL_SITEWEB = "";
        private string _CL_EMAIL = "";
        private string _CL_GERANT = "";
        private string _CL_STATUT = "N";
        private DateTime _CL_DATESAISIE = DateTime.Parse("01/01/1900");
        private DateTime _CL_DATEDEPART = DateTime.Parse("01/01/1900");
        private string _CL_ASDI = "N";
        private string _CL_TVA = "O";
        private int _CL_STATUTDOUTEUX = 0;
        private double _CL_PLAFONDCREDIT = 0;
        private string _CL_NUMCPTECONTIBUABLE = "";
        private string _OP_CODEOPERATEUR = "";
        private Byte[] _PH_PHOTO = null;
        private string _TYPEOPERATION = "";
        private string _PL_NUMCOMPTE = "";
        private double _CL_TAUXREMISE = 0;

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }
        public string SX_CODESEXE
        {
            get { return _SX_CODESEXE; }
            set { _SX_CODESEXE = value; }
        }
        public string SM_CODESITUATIONMATRIMONIALE
        {
            get { return _SM_CODESITUATIONMATRIMONIALE; }
            set { _SM_CODESITUATIONMATRIMONIALE = value; }
        }
        public string PF_CODEPROFESSION
        {
            get { return _PF_CODEPROFESSION; }
            set { _PF_CODEPROFESSION = value; }
        }
        public string AC_CODEACTIVITE
        {
            get { return _AC_CODEACTIVITE; }
            set { _AC_CODEACTIVITE = value; }
        }
        public string TP_CODETYPECLIENT
        {
            get { return _TP_CODETYPECLIENT; }
            set { _TP_CODETYPECLIENT = value; }
        }
        public string CL_NUMCLIENT
        {
            get { return _CL_NUMCLIENT; }
            set { _CL_NUMCLIENT = value; }
        }
        public DateTime CL_DATENAISSANCE
        {
            get { return _CL_DATENAISSANCE; }
            set { _CL_DATENAISSANCE = value; }
        }
        public string CL_DENOMINATION
        {
            get { return _CL_DENOMINATION; }
            set { _CL_DENOMINATION = value; }
        }
        public string CL_DESCRIPTIONCLIENT
        {
            get { return _CL_DESCRIPTIONCLIENT; }
            set { _CL_DESCRIPTIONCLIENT = value; }
        }
        public string CL_ADRESSEPOSTALE
        {
            get { return _CL_ADRESSEPOSTALE; }
            set { _CL_ADRESSEPOSTALE = value; }
        }
        public string CL_ADRESSEGEOGRAPHIQUE
        {
            get { return _CL_ADRESSEGEOGRAPHIQUE; }
            set { _CL_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string CL_TELEPHONE
        {
            get { return _CL_TELEPHONE; }
            set { _CL_TELEPHONE = value; }
        }
        public string CL_FAX
        {
            get { return _CL_FAX; }
            set { _CL_FAX = value; }
        }
        public string CL_SITEWEB
        {
            get { return _CL_SITEWEB; }
            set { _CL_SITEWEB = value; }
        }
        public string CL_EMAIL
        {
            get { return _CL_EMAIL; }
            set { _CL_EMAIL = value; }
        }
        public string CL_GERANT
        {
            get { return _CL_GERANT; }
            set { _CL_GERANT = value; }
        }
        public string CL_STATUT
        {
            get { return _CL_STATUT; }
            set { _CL_STATUT = value; }
        }
        public DateTime CL_DATESAISIE
        {
            get { return _CL_DATESAISIE; }
            set { _CL_DATESAISIE = value; }
        }

        public DateTime CL_DATEDEPART
        {
            get { return _CL_DATEDEPART; }
            set { _CL_DATEDEPART = value; }
        }


        public string CL_ASDI
        {
            get { return _CL_ASDI; }
            set { _CL_ASDI = value; }
        }
        public string CL_TVA
        {
            get { return _CL_TVA; }
            set { _CL_TVA = value; }
        }
        public int CL_STATUTDOUTEUX
        {
            get { return _CL_STATUTDOUTEUX; }
            set { _CL_STATUTDOUTEUX = value; }
        }
        public double CL_PLAFONDCREDIT
        {
            get { return _CL_PLAFONDCREDIT; }
            set { _CL_PLAFONDCREDIT = value; }
        }
        public string CL_NUMCPTECONTIBUABLE
        {
            get { return _CL_NUMCPTECONTIBUABLE; }
            set { _CL_NUMCPTECONTIBUABLE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public Byte[] PH_PHOTO
        {
            get { return _PH_PHOTO; }
            set { _PH_PHOTO = value; }
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
        public double CL_TAUXREMISE
        {
            get { return _CL_TAUXREMISE; }
            set { _CL_TAUXREMISE = value; }
        }

        public clsPhaclient() { }

        public clsPhaclient(string AG_CODEAGENCE, string CL_IDCLIENT, string SX_CODESEXE, string SM_CODESITUATIONMATRIMONIALE, string PF_CODEPROFESSION, string AC_CODEACTIVITE, string TP_CODETYPECLIENT, string CL_NUMCLIENT, DateTime CL_DATENAISSANCE, string CL_DENOMINATION, string CL_DESCRIPTIONCLIENT, string CL_ADRESSEPOSTALE, string CL_ADRESSEGEOGRAPHIQUE, string CL_TELEPHONE, string CL_FAX, string CL_SITEWEB, string CL_EMAIL, string CL_GERANT, string CL_STATUT, DateTime CL_DATESAISIE, DateTime CL_DATEDEPART, string CL_ASDI, string CL_TVA, int CL_STATUTDOUTEUX, double CL_PLAFONDCREDIT, string CL_NUMCPTECONTIBUABLE, string OP_CODEOPERATEUR, byte[] PH_PHOTO, string PL_NUMCOMPTE, double CL_TAUXREMISE)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.CL_IDCLIENT = CL_IDCLIENT;
            this.SX_CODESEXE = SX_CODESEXE;
            this.SM_CODESITUATIONMATRIMONIALE = SM_CODESITUATIONMATRIMONIALE;
            this.PF_CODEPROFESSION = PF_CODEPROFESSION;
            this.AC_CODEACTIVITE = AC_CODEACTIVITE;
            this.TP_CODETYPECLIENT = TP_CODETYPECLIENT;
            this.CL_NUMCLIENT = CL_NUMCLIENT;
            this.CL_DATENAISSANCE = CL_DATENAISSANCE;
            this.CL_DENOMINATION = CL_DENOMINATION;
            this.CL_DESCRIPTIONCLIENT = CL_DESCRIPTIONCLIENT;
            this.CL_ADRESSEPOSTALE = CL_ADRESSEPOSTALE;
            this.CL_ADRESSEGEOGRAPHIQUE = CL_ADRESSEGEOGRAPHIQUE;
            this.CL_TELEPHONE = CL_TELEPHONE;
            this.CL_FAX = CL_FAX;
            this.CL_SITEWEB = CL_SITEWEB;
            this.CL_EMAIL = CL_EMAIL;
            this.CL_GERANT = CL_GERANT;
            this.CL_STATUT = CL_STATUT;
            this.CL_DATESAISIE = CL_DATESAISIE;
            this.CL_DATEDEPART = CL_DATEDEPART;
            this.CL_ASDI = CL_ASDI;
            this.CL_TVA = CL_TVA;
            this.CL_STATUTDOUTEUX = CL_STATUTDOUTEUX;
            this.CL_PLAFONDCREDIT = CL_PLAFONDCREDIT;
            this.CL_NUMCPTECONTIBUABLE = CL_NUMCPTECONTIBUABLE;
            this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
            this.PH_PHOTO = PH_PHOTO;
            this.TYPEOPERATION = TYPEOPERATION;
            this.PL_NUMCOMPTE = PL_NUMCOMPTE;
            this.CL_TAUXREMISE = CL_TAUXREMISE;

        }

        public clsPhaclient(clsPhaclient clsPhaclient)
        {
            AG_CODEAGENCE = clsPhaclient.AG_CODEAGENCE;
            CL_IDCLIENT = clsPhaclient.CL_IDCLIENT;
            SX_CODESEXE = clsPhaclient.SX_CODESEXE;
            SM_CODESITUATIONMATRIMONIALE = clsPhaclient.SM_CODESITUATIONMATRIMONIALE;
            PF_CODEPROFESSION = clsPhaclient.PF_CODEPROFESSION;
            AC_CODEACTIVITE = clsPhaclient.AC_CODEACTIVITE;
            TP_CODETYPECLIENT = clsPhaclient.TP_CODETYPECLIENT;
            CL_NUMCLIENT = clsPhaclient.CL_NUMCLIENT;
            CL_DATENAISSANCE = clsPhaclient.CL_DATENAISSANCE;
            CL_DENOMINATION = clsPhaclient.CL_DENOMINATION;
            CL_DESCRIPTIONCLIENT = clsPhaclient.CL_DESCRIPTIONCLIENT;
            CL_ADRESSEPOSTALE = clsPhaclient.CL_ADRESSEPOSTALE;
            CL_ADRESSEGEOGRAPHIQUE = clsPhaclient.CL_ADRESSEGEOGRAPHIQUE;
            CL_TELEPHONE = clsPhaclient.CL_TELEPHONE;
            CL_FAX = clsPhaclient.CL_FAX;
            CL_SITEWEB = clsPhaclient.CL_SITEWEB;
            CL_EMAIL = clsPhaclient.CL_EMAIL;
            CL_GERANT = clsPhaclient.CL_GERANT;
            CL_STATUT = clsPhaclient.CL_STATUT;
            CL_DATESAISIE = clsPhaclient.CL_DATESAISIE;
            CL_DATEDEPART = clsPhaclient.CL_DATEDEPART;
            CL_ASDI = clsPhaclient.CL_ASDI;
            CL_TVA = clsPhaclient.CL_TVA;
            CL_STATUTDOUTEUX = clsPhaclient.CL_STATUTDOUTEUX;
            CL_PLAFONDCREDIT = clsPhaclient.CL_PLAFONDCREDIT;
            CL_NUMCPTECONTIBUABLE = clsPhaclient.CL_NUMCPTECONTIBUABLE;
            OP_CODEOPERATEUR = clsPhaclient.OP_CODEOPERATEUR;
            PH_PHOTO = clsPhaclient.PH_PHOTO;
            TYPEOPERATION = clsPhaclient.TYPEOPERATION;
            PL_NUMCOMPTE = clsPhaclient.PL_NUMCOMPTE;
            CL_TAUXREMISE = clsPhaclient.CL_TAUXREMISE;

        }
    }
}