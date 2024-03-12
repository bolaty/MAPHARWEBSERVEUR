using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

using TontineMobile.BOJ;
using TontineMobile.WSBLL;
using TontineMobile.WSTOOLS;
using WEB.WSTOOLS;

namespace TontineMobile.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "TontinewebClasse" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez TontinewebClasse.svc ou TontinewebClasse.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class TontinewebClasse : ITontinewebClasse
    {

        private clsDonnee _clsDonnee = new clsDonnee();
        private clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        Controllers.LogController Logger = new Controllers.LogController();

      
        

        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


      

        public clsResultatOperation1 pvgVersementTontine(string DATEJOURNEE, string AG_CODEAGENCE, string TE_CODESMSTYPEOPERATION, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE,  string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string MC_NOMTIERS, string PI_CODEPIECE, string MC_NUMPIECETIERS, string MONTANT, string SM_TELEPHONE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string SIGNATURE, string TYPEOPERATION,string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE)
        {



                string MI_CODEMISE = "";
              clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            if (string.IsNullOrEmpty(LG_CODELANGUE)) LG_CODELANGUE = "fr";

            if (string.IsNullOrEmpty(MC_NOMTIERS)) MC_NOMTIERS = "";
            if (string.IsNullOrEmpty(PI_CODEPIECE)) PI_CODEPIECE = "";
            if (string.IsNullOrEmpty(MC_NUMPIECETIERS)) MC_NUMPIECETIERS = "";

            if (string.IsNullOrEmpty(TYPEOPERATEUR)) TYPEOPERATEUR = "03";


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(EJ_CODEEPARGNANTJOURNALIER))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }



            //if (string.IsNullOrEmpty(CA_CODECARNET))
            //{
            //    clsResultatOperation clsResultatOperation = new clsResultatOperation();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0156", "01");
            //    clsResultatOperation.TW_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultatOperation.TW_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultatOperation.TW_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultatOperationListe.Add(clsResultatOperation);

            //    return clsResultatOperationListe[0];
            //}


            if (string.IsNullOrEmpty(CT_CODECARTE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0157", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];

            }



            if (string.IsNullOrEmpty(MC_NOMTIERS))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0202", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(OP_CODEOPERATEUR) && TYPEOPERATEUR=="03")
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0203", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }
            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }
            if (string.IsNullOrEmpty(TE_CODESMSTYPEOPERATION))
            {
                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0230", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            //if (string.IsNullOrEmpty(PI_CODEPIECE))
            //{
            //    //----EXEPTION
            //    clsResultatOperation clsResultatOperation = new clsResultatOperation();
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0006", "01");
            //    clsResultatOperation.TW_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultatOperation.TW_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultatOperation.TW_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultatOperationListe.Add(clsResultatOperation);

            //    return clsResultatOperationListe[0];
            //}




            if (TYPEOPERATION == "02")
            {
                if (string.IsNullOrEmpty(MI_CODEMISE))
                {
                    //----EXEPTION
                    clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0231", "01");
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                if (string.IsNullOrEmpty(ST_STICKERCODE1))
                {
                    //----EXEPTION
                    clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0232", "01");
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                if (string.IsNullOrEmpty(ST_STICKERCODE2))
                {
                    //----EXEPTION
                    clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0233", "01");
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }





            }
            //string MI_CODEMISE, string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string PI_CODEPIECE, string MC_NOMTIERS, string MC_NUMPIECETIERS


            if (string.IsNullOrEmpty(MONTANT))
            {

                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0059", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];

            }
            if (!clsChaineCaractere.ClasseChaineCaractere.isDigit(MONTANT))
            {

                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0060", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);
                return clsResultatOperationListe[0];


            }







            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                //----VERIFICATION DE LA CLE DE SESSION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, TYPEOPERATEUR);

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsResultatOperationListe.Add(clsResultatOperation);

                //    return clsResultatOperationListe[0];
                //}
                //--
                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2,  MC_NOMTIERS,  PI_CODEPIECE,  MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR,  SIGNATURE, TYPEOPERATION);





                if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && clsResultatOperationListe[0].ENVOISMS == "1")
                {
                    if (clsResultatOperationListe[0].CL_TELEPHONE != "")
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        clsParams clsParams = new clsParams();
                        TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                        clsResultatOperationListe[0].SL_LIBELLE1 = "C";
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatOperationListe[0].PV_CODEPOINTVENTE, clsResultatOperationListe[0].CO_CODECOMPTE, clsResultatOperationListe[0].OB_NOMOBJET, clsResultatOperationListe[0].CL_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsResultatOperationListe[0].MC_DATEPIECE), "", clsResultatOperationListe[0].CL_IDCLIENT, "", clsResultatOperationListe[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", clsResultatOperationListe[0].SL_LIBELLE1, clsResultatOperationListe[0].SL_LIBELLE2);

                        clsResultatOperationListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsResultatOperationListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsResultatOperationListe[0].SL_MESSAGE = clsResultatOperationListe[0].SL_MESSAGE + " " + clsResultatOperationListe[0].SL_MESSAGEAPI;




                    }


                    if (clsResultatOperationListe[0].EJ_EMAIL != "")
                    {

                        string pvgTitre = clsResultatOperationListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = clsResultatOperationListe[0].AG_EMAIL;
                        string vppMotDePasseExpediteur = clsResultatOperationListe[0].AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = clsResultatOperationListe[0].EJ_EMAIL;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                    }

                }







                //if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && CheckForInternetConnection() && clsResultatOperationListe[0].ENVOISMS=="1")
                //{
                //    //SM_TELEPHONE = "22547839553";
                //    if (SM_TELEPHONE != "")
                //        SendMessage(clsResultatOperationListe[0].SL_MESSAGE, "", SM_TELEPHONE, AG_CODEAGENCE);

                //}



            }

            catch (SqlException SQLEx)
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsResultatOperation.SL_RESULTAT = "FALSE";
                clsResultatOperation.SL_MESSAGE = SQLEx.Message;
                clsResultatOperationListe.Add(clsResultatOperation);
            }
            catch (Exception e)
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsResultatOperation.SL_RESULTAT = "FALSE";
                clsResultatOperation.SL_MESSAGE = e.Message;
                clsResultatOperationListe.Add(clsResultatOperation);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsResultatOperationListe[0];

        }

        public clsResultatOperation1 pvgVersementTontineDiffere(List<clsParametreVersementdiffere> Objet)
        {


            clsResultatOperation1 clsMiccomptewebmotpasseoublieListe = new clsResultatOperation1();
            int vlpTest = 0;
            foreach (clsParametreVersementdiffere clsParametreVersementdiffereDTO in Objet)
            {
                clsDonnee = new clsDonnee();
                //SqlConnection vogObjetConnexionLocal = new SqlConnection();
                //clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //if (vlpTest == 0)
                //{
                //    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //    vogObjetConnexionLocal = clsDonnee.vogObjetConnexionLocal;
                //}

                //else
                //    clsDonnee.vogObjetConnexionLocal = vogObjetConnexionLocal;
                //vlpTest = 1;
                clsMiccomptewebmotpasseoublieListe = pvgVersementTontine(clsParametreVersementdiffereDTO.DATEJOURNEE, clsParametreVersementdiffereDTO.AG_CODEAGENCE, clsParametreVersementdiffereDTO.TE_CODESMSTYPEOPERATION, clsParametreVersementdiffereDTO.EJ_CODEEPARGNANTJOURNALIER, clsParametreVersementdiffereDTO.CT_CODECARTE, clsParametreVersementdiffereDTO.STICKER, clsParametreVersementdiffereDTO.ST_STICKERCODE1, clsParametreVersementdiffereDTO.ST_STICKERCODE2, clsParametreVersementdiffereDTO.MC_NOMTIERS, clsParametreVersementdiffereDTO.PI_CODEPIECE, clsParametreVersementdiffereDTO.MC_NUMPIECETIERS, clsParametreVersementdiffereDTO.MONTANT, clsParametreVersementdiffereDTO.SM_TELEPHONE, clsParametreVersementdiffereDTO.OP_CODEOPERATEUR, clsParametreVersementdiffereDTO.SL_LOGIN, clsParametreVersementdiffereDTO.SL_MOTDEPASSE, clsParametreVersementdiffereDTO.SL_CLESESSION, clsParametreVersementdiffereDTO.SL_VERSIONAPK, clsParametreVersementdiffereDTO.SIGNATURE, clsParametreVersementdiffereDTO.TYPEOPERATION, clsParametreVersementdiffereDTO.TYPEOPERATEUR, clsParametreVersementdiffereDTO.LG_CODELANGUE, clsParametreVersementdiffereDTO.OS_MACADRESSE);
            }
            return clsMiccomptewebmotpasseoublieListe;


        }
        public clsResultatOperation1 pvgVersementTontineMobile(string DATEJOURNEE, string AG_CODEAGENCE, string TE_CODESMSTYPEOPERATION, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE, string MI_CODEMISE, string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string MC_NOMTIERS, string PI_CODEPIECE, string MC_NUMPIECETIERS, string MONTANT, string SM_TELEPHONE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string SIGNATURE, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE)
        {

            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            if (string.IsNullOrEmpty(LG_CODELANGUE)) LG_CODELANGUE = "fr";

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(EJ_CODEEPARGNANTJOURNALIER))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }



            //if (string.IsNullOrEmpty(CA_CODECARNET))
            //{
            //    clsResultatOperation clsResultatOperation = new clsResultatOperation();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0156", "01");
            //    clsResultatOperation.TW_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultatOperation.TW_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultatOperation.TW_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultatOperationListe.Add(clsResultatOperation);

            //    return clsResultatOperationListe[0];
            //}


            if (string.IsNullOrEmpty(CT_CODECARTE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0157", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];

            }



            if (string.IsNullOrEmpty(MC_NOMTIERS))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0202", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0203", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }
            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }
            if (string.IsNullOrEmpty(TE_CODESMSTYPEOPERATION))
            {
                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0230", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];
            }


            //if (string.IsNullOrEmpty(PI_CODEPIECE))
            //{
            //    //----EXEPTION
            //    clsResultatOperation clsResultatOperation = new clsResultatOperation();
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0006", "01");
            //    clsResultatOperation.TW_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultatOperation.TW_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultatOperation.TW_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultatOperationListe.Add(clsResultatOperation);

            //    return clsResultatOperationListe[0];
            //}




            if (TYPEOPERATION == "02")
            {
                if (string.IsNullOrEmpty(MI_CODEMISE))
                {
                    //----EXEPTION
                    clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0231", "01");
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                if (string.IsNullOrEmpty(ST_STICKERCODE1))
                {
                    //----EXEPTION
                    clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0232", "01");
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                if (string.IsNullOrEmpty(ST_STICKERCODE2))
                {
                    //----EXEPTION
                    clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0233", "01");
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }





            }
            //string MI_CODEMISE, string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string PI_CODEPIECE, string MC_NOMTIERS, string MC_NUMPIECETIERS


            if (string.IsNullOrEmpty(MONTANT))
            {

                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0059", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);

                return clsResultatOperationListe[0];

            }
            if (!clsChaineCaractere.ClasseChaineCaractere.isDigit(MONTANT))
            {

                //----EXEPTION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0060", "01");
                clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultatOperationListe.Add(clsResultatOperation);
                return clsResultatOperationListe[0];


            }







            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                //----VERIFICATION DE LA CLE DE SESSION
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                //--
                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsResultatOperation.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultatOperation.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultatOperation.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultatOperationListe.Add(clsResultatOperation);

                    return clsResultatOperationListe[0];
                }

                clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2, MC_NOMTIERS, PI_CODEPIECE, MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR,  SIGNATURE, TYPEOPERATION);



                if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && TE_CODESMSTYPEOPERATION == "16")
                {
                    if (clsResultatOperationListe[0].CL_TELEPHONE != "")
                    {


                        //--
                        List<clsCinetpay> clsCinetpays = new List<clsCinetpay>();
                        clsCinetpaytoken clsCinetpaytoken = new clsCinetpaytoken();
                        //clsCinetpaytoken.Apikey = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";
                        //clsCinetpaytoken.Password = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_P"));//"@merveille241";

                        clsParametre clsParametre = new clsParametre();
                        clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                        clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                        string[] stringArray = { "CIT_K" };
                        clsObjetEnvoi1.OE_PARAM = stringArray;
                        clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                        clsCinetpaytoken.Apikey = clsParametre.PP_VALEUR;// clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";

                        clsParametre = new clsParametre();
                        clsParametreWSBLL = new clsParametreWSBLL();
                        clsObjetEnvoi1 = new clsObjetEnvoi();
                        string[] stringArray1 = { "CIT_P" };
                        clsObjetEnvoi1.OE_PARAM = stringArray1;
                        clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                        clsCinetpaytoken.Password = clsParametre.PP_VALEUR;//"@merveille241";


                        if (IsNetworkConnected())
                            clsCinetpays = pvgDemendetoken(clsCinetpaytoken);


                        //--
                        List<clsResultat> clsResultats = new List<clsResultat>();

                        clsResultat clsResultat = new clsResultat();
                        List<clsDataContact> clsDataContacts = new List<clsDataContact>();
                        List<clsCinetpayContact> listclsCinetpayContact = new List<clsCinetpayContact>();
                        clsCinetpayContact clsCinetpayContact = new clsCinetpayContact();
                        clsDataToken clsDataTokens = new clsDataToken();
                        clsDataTokens = clsCinetpays[0].data;
                        clsCinetpayContact.email = "";// SO_EMAIL;
                        clsCinetpayContact.prefix = "225";
                        clsCinetpayContact.phone = SM_TELEPHONE;
                        clsCinetpayContact.name = clsResultats[0].SL_NOM;
                        clsCinetpayContact.surname = clsResultats[0].SL_PRENOMS;
                        listclsCinetpayContact.Add(clsCinetpayContact);


                        try
                        {
                            //if (IsNetworkConnected())
                            //    clsDataContacts = pvgAddContact(listclsCinetpayContact, clsDataTokens);
                        }
                        catch { }


                        //--

                        if (clsDataContacts.Count == 0)
                        {
                            clsResultats = new List<clsResultat>();
                            clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                            clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                            clsResultat.SL_MESSAGE = "Le service n'est pas disponible (00) !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                            clsResultats.Add(clsResultat);
                            try
                            {
                                throw new Exception("Le service n'est pas disponible (00) !!!");
                            }
                            catch { }
                        }








                    }

                }

                if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && clsResultatOperationListe[0].ENVOISMS == "1")
                {
                    if (clsResultatOperationListe[0].CL_TELEPHONE != "")
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        clsParams clsParams = new clsParams();
                        TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                        clsResultatOperationListe[0].SL_LIBELLE1 = "C";
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatOperationListe[0].PV_CODEPOINTVENTE, clsResultatOperationListe[0].CO_CODECOMPTE, clsResultatOperationListe[0].OB_NOMOBJET, clsResultatOperationListe[0].CL_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsResultatOperationListe[0].MC_DATEPIECE), "", clsResultatOperationListe[0].CL_IDCLIENT, "", clsResultatOperationListe[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", clsResultatOperationListe[0].SL_LIBELLE1, clsResultatOperationListe[0].SL_LIBELLE2);

                        clsResultatOperationListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsResultatOperationListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsResultatOperationListe[0].SL_MESSAGE = clsResultatOperationListe[0].SL_MESSAGE + " " + clsResultatOperationListe[0].SL_MESSAGEAPI;




                    }

                    if (clsResultatOperationListe[0].EJ_EMAIL != "")
                    {

                        string pvgTitre = clsResultatOperationListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = clsResultatOperationListe[0].AG_EMAIL;
                        string vppMotDePasseExpediteur = clsResultatOperationListe[0].AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = clsResultatOperationListe[0].EJ_EMAIL;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                    }

                }







                //if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && CheckForInternetConnection() && clsResultatOperationListe[0].ENVOISMS=="1")
                //{
                //    //SM_TELEPHONE = "22547839553";
                //    if (SM_TELEPHONE != "")
                //        SendMessage(clsResultatOperationListe[0].SL_MESSAGE, "", SM_TELEPHONE, AG_CODEAGENCE);

                //}



            }

            catch (SqlException SQLEx)
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsResultatOperation.SL_RESULTAT = "FALSE";
                clsResultatOperation.SL_MESSAGE = SQLEx.Message;
                clsResultatOperationListe.Add(clsResultatOperation);
            }
            catch (Exception e)
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                clsResultatOperation.SL_RESULTAT = "FALSE";
                clsResultatOperation.SL_MESSAGE = e.Message;
                clsResultatOperationListe.Add(clsResultatOperation);

            }


            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsResultatOperationListe[0];

        }


        public List<clsTontinewebUserTransaction> pvgUserTransaction(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string OP_CODEOPERATEUR, string CL_IDCLIENT, string MB_IDTIERS, string MC_DATEPIECE1, string MC_DATEPIECE2, string MC_NBRELIGNE, string CT_IDCARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();





            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontinewebUserTransaction> clsTontinewebUserTransactionListe = new List<clsTontinewebUserTransaction>();
            clsTontinewebUserTransaction clsTontinewebUserTransaction = new clsTontinewebUserTransaction();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }



            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }



            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR) && string.IsNullOrEmpty(CL_IDCLIENT) && string.IsNullOrEmpty(MB_IDTIERS))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0028", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }



            if (string.IsNullOrEmpty(CL_CODECLIENT))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(CT_IDCARTE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0257", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));



            if (string.IsNullOrEmpty(MC_DATEPIECE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0030", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(MC_DATEPIECE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0031", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(MC_DATEPIECE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0032", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(MC_DATEPIECE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0033", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (TontineMobile.WSTOOLS.clsChaineCaractere.ClasseChaineCaractere.isLetter(MC_NBRELIGNE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }




            if (string.IsNullOrEmpty(MC_NBRELIGNE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }




            if (MC_NBRELIGNE == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            //1-Recuperation de tous les comptes repondant aux critères spécifés sur l'écran,pour leur edition de releve.
            List<clsMiccompte> clsMiccomptes = new List<clsMiccompte>();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            clsMiccomptes = clsTontinewebWSBLL.pvgSelectPourReleveCompte(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT);

            string vlpCO_CODECOMPTE = "";
            for (int Idx = 0; Idx < clsMiccomptes.Count; Idx++)
            {
                vlpCO_CODECOMPTE = clsMiccomptes[Idx].CO_CODECOMPTE;
            }

            if (string.IsNullOrEmpty(vlpCO_CODECOMPTE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0278", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //  clsDonnee.pvgDemarrerTransaction();
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                    return clsTontinewebUserTransactionListe;
                }

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                    return clsTontinewebUserTransactionListe;
                }
                //--
                //clsTontinewebUserTransactionListe = clsTontinewebWSBLL.pvgUserTransactionDEMO(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, CL_IDCLIENT, MB_IDTIERS, CL_CODECLIENT, MC_DATEPIECE1, MC_DATEPIECE2, int.Parse(MC_NBRELIGNE));





                clsTontinewebUserTransactionListe = clsTontinewebWSBLL.pvgUserTransaction(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, CL_IDCLIENT, MB_IDTIERS, CL_CODECLIENT, vlpCO_CODECOMPTE, MC_DATEPIECE1, MC_DATEPIECE2, int.Parse(MC_NBRELIGNE), CT_IDCARTE);


            }
            catch (SqlException SQLEx)
            {
                clsTontinewebUserTransaction.SL_RESULTAT = "FALSE";
                clsTontinewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);
            }
            catch (Exception e)
            {
                clsTontinewebUserTransaction.SL_RESULTAT = "FALSE";
                clsTontinewebUserTransaction.SL_MESSAGE = e.Message;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

            }

            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontinewebUserTransactionListe;
        }

        public List<clsTontinewebUserTransaction> pvgUserTransactionClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string OP_CODEOPERATEUR, string CL_IDCLIENT, string MB_IDTIERS, string MC_DATEPIECE1, string MC_DATEPIECE2, string MC_NBRELIGNE, string CT_IDCARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();





            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontinewebUserTransaction> clsTontinewebUserTransactionListe = new List<clsTontinewebUserTransaction>();
            clsTontinewebUserTransaction clsTontinewebUserTransaction = new clsTontinewebUserTransaction();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }



            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }
            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR) && string.IsNullOrEmpty(CL_IDCLIENT) && string.IsNullOrEmpty(MB_IDTIERS))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0028", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }



            if (string.IsNullOrEmpty(CL_CODECLIENT))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(CT_IDCARTE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0257", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));



            if (string.IsNullOrEmpty(MC_DATEPIECE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0030", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(MC_DATEPIECE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0031", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(MC_DATEPIECE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0032", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(MC_DATEPIECE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0033", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (TontineMobile.WSTOOLS.clsChaineCaractere.ClasseChaineCaractere.isLetter(MC_NBRELIGNE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }




            if (string.IsNullOrEmpty(MC_NBRELIGNE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }




            if (MC_NBRELIGNE == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            //1-Recuperation de tous les comptes repondant aux critères spécifés sur l'écran,pour leur edition de releve.
            List<clsMiccompte> clsMiccomptes = new List<clsMiccompte>();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            clsMiccomptes = clsTontinewebWSBLL.pvgSelectPourReleveCompte(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT);

            string vlpCO_CODECOMPTE = "";
            for (int Idx = 0; Idx < clsMiccomptes.Count; Idx++)
            {
                vlpCO_CODECOMPTE = clsMiccomptes[Idx].CO_CODECOMPTE;
            }

            if (string.IsNullOrEmpty(vlpCO_CODECOMPTE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0278", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //  clsDonnee.pvgDemarrerTransaction();
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                    return clsTontinewebUserTransactionListe;
                }

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                    return clsTontinewebUserTransactionListe;
                }
                //--
                //clsTontinewebUserTransactionListe = clsTontinewebWSBLL.pvgUserTransactionDEMO(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, CL_IDCLIENT, MB_IDTIERS, CL_CODECLIENT, MC_DATEPIECE1, MC_DATEPIECE2, int.Parse(MC_NBRELIGNE));


                clsTontinewebUserTransactionListe = clsTontinewebWSBLL.pvgUserTransaction(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, CL_IDCLIENT, MB_IDTIERS, CL_CODECLIENT, vlpCO_CODECOMPTE, MC_DATEPIECE1, MC_DATEPIECE2, int.Parse(MC_NBRELIGNE), CT_IDCARTE);


            }
            catch (SqlException SQLEx)
            {
                clsTontinewebUserTransaction.SL_RESULTAT = "FALSE";
                clsTontinewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);
            }
            catch (Exception e)
            {
                clsTontinewebUserTransaction.SL_RESULTAT = "FALSE";
                clsTontinewebUserTransaction.SL_MESSAGE = e.Message;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);
            }

            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontinewebUserTransactionListe;
        }


        public List<clsTontinewebUserTransaction> pvgBrouillard(string DATEJOURNEE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontinewebUserTransaction> clsTontinewebUserTransactionListe = new List<clsTontinewebUserTransaction>();
            clsTontinewebUserTransaction clsTontinewebUserTransaction = new clsTontinewebUserTransaction();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }
            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0028", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }







            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0030", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0031", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0032", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0033", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }


            //if (ZenithMobile.WSTOOLS.clsChaineCaractere.ClasseChaineCaractere.isLetter(MC_NBRELIGNE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0007", "01");
            //    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

            //    return clsTontinewebUserTransactionListe;
            //}




            //if (string.IsNullOrEmpty(MC_NBRELIGNE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0007", "01");
            //    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

            //    return clsTontinewebUserTransactionListe;
            //}




            //if (MC_NBRELIGNE == "0")
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0007", "01");
            //    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

            //    return clsTontinewebUserTransactionListe;
            //}


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                return clsTontinewebUserTransactionListe;
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //  clsDonnee.pvgDemarrerTransaction();
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                    return clsTontinewebUserTransactionListe;
                }
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);

                    return clsTontinewebUserTransactionListe;
                }
                clsTontinewebUserTransactionListe = clsTontinewebWSBLL.pvgBrouillard(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, DATEJOURNEE);


            }
            catch (SqlException SQLEx)
            {
                clsTontinewebUserTransaction.SL_RESULTAT = "FALSE";
                clsTontinewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);
            }
            catch (Exception e)
            {
                clsTontinewebUserTransaction.SL_RESULTAT = "FALSE";
                clsTontinewebUserTransaction.SL_MESSAGE = e.Message;
                clsTontinewebUserTransactionListe.Add(clsTontinewebUserTransaction);
            }

            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontinewebUserTransactionListe;
        }


        public clsClient pvgVerificationClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string OP_CODEOPERATEUR, string LG_CODELANGUE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsClient> clsMiccomptewebUserLogin = new List<clsClient>();

            string TYPEOPERATION = TYPEOPERATEUR;

            if (string.IsNullOrEmpty(TYPEOPERATION))
                TYPEOPERATION = "02";
            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsClient clsMiccomptewebUserLogin1 = new clsClient();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le type opération est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }















            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgVerificationClient(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT, OP_CODEOPERATEUR, LG_CODELANGUE, TYPEOPERATION);
            }
            catch (SqlException SQLEx)
            {

                clsClient clsMiccomptewebUserLogin1 = new clsClient();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsClient clsMiccomptewebUserLogin1 = new clsClient();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }

            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }




        public clsMiccomptewebUserLogin pvgUserLogin(string SL_LOGIN, string SL_MOTPASSE, string SL_VERSIONAPK, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            //Logger.EcrireDansFichierLog("pvgUserLogin", "Appel de la procédure de connexion");
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogin = new List<clsMiccomptewebUserLogin>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;


                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le type opération est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, "", "", "", SL_VERSIONAPK, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {

                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;


                    //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                    //clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }
                //--
                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }


                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgChargerAPartirDataSet(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTPASSE, TYPEOPERATEUR);

                if (clsMiccomptewebUserLogin[0].SL_RESULTAT == "TRUE")
                {

                    if (clsMiccomptewebUserLogin[0].CL_TELEPHONE != "" && clsMiccomptewebUserLogin[0].SL_NOMBRECONNECTION != 0)
                    {


                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        //if (CL_CONTACT.Length == 10)
                        //    CL_CONTACT = "00225" + CL_CONTACT;
                        string CL_IDCLIENT = "";
                        clsParams clsParams = new clsParams();
                        //string CL_TELEPHONE,  string SMSTEXT,   string SM_DATEEMISSIONSMS,string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2
                        clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple(clsDonnee, clsMiccomptewebUserLogin[0].CL_TELEPHONE, clsMiccomptewebUserLogin[0].SL_MESSAGECLIENT, DateTime.Parse(clsMiccomptewebUserLogin[0].JT_DATEJOURNEETRAVAIL), "0", clsMiccomptewebUserLogin[0].SL_LIBELLE1, clsMiccomptewebUserLogin[0].SL_LIBELLE2);
                        clsMiccomptewebUserLogin[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsMiccomptewebUserLogin[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebUserLogin[0].SL_MESSAGE = clsMiccomptewebUserLogin[0].SL_MESSAGE + " " + clsMiccomptewebUserLogin[0].SL_MESSAGEAPI;




                        //clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        //clsParams clsParams = new clsParams();
                        //String TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                        //String SL_LIBELLE1 = "C";
                        //String SL_LIBELLE2 = "";
                        //clsMiccomptewebResultat.SL_MESSAGECLIENT = "Merci de bien vouloir recevoir votre code de validation : " + clsMiccomptewebUserLogin[0].TK_TOKEN;
                        //clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebUserLogin[0].AG_CODEAGENCE, clsMiccomptewebUserLogin[0].PV_CODEPOINTVENTE, clsMiccomptewebUserLogin[0].CO_CODECOMPTE, clsMiccomptewebUserLogin[0].OB_NOMOBJET, clsMiccomptewebUserLogin[0].CL_TELEPHONE, clsMiccomptewebUserLogin[0].OP_CODEOPERATEUR, DateTime.Parse(clsMiccomptewebUserLogin[0].JT_DATEJOURNEETRAVAIL), "", clsMiccomptewebUserLogin[0].CL_IDCLIENT, "", clsMiccomptewebUserLogin[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", SL_LIBELLE1, SL_LIBELLE2);

                        //clsMiccomptewebResultat.SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        //clsMiccomptewebResultat.SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        //if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE + " " + clsMiccomptewebResultat.SL_MESSAGEAPI;





                    }


                    if (clsMiccomptewebUserLogin[0].CL_EMAIL != "" && clsMiccomptewebUserLogin[0].SL_NOMBRECONNECTION != 0)
                    {
                        string AG_EMAIL = "";
                        string AG_EMAILMOTDEPASSE = "";
                        DataSet DataSet = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsMiccomptewebUserLogin[0].AG_CODEAGENCE };
                        DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetAgence(clsDonnee, clsObjetEnvoi);
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            AG_EMAIL = row["AG_EMAIL"].ToString();
                            AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                        }

                        string pvgTitre = clsMiccomptewebUserLogin[0].SL_MESSAGEOBJET;// clsResultatOperationListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsMiccomptewebUserLogin[0].SL_MESSAGECLIENT;// clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = AG_EMAIL;
                        string vppMotDePasseExpediteur = AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = clsMiccomptewebUserLogin[0].CL_EMAIL;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                    }




                    //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<BOJ.clsMiccomptewebResultat>();

                    //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgVerificationMotdePasse(clsMiccomptewebUserLogin[0].SL_MOTPASSE, SL_MOTPASSE);

                    //if (clsMiccomptewebResultat[0].SL_RESULTAT=="FALSE")
                    //{

                    //    List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogin2 = new List<BOJ.clsMiccomptewebUserLogin>();
                    //    clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new BOJ.clsMiccomptewebUserLogin();
                    //    clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                    //    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                    //    clsMiccomptewebUserLogin2.Add(clsMiccomptewebUserLogin1);

                    //    return new JavaScriptSerializer().Serialize(clsMiccomptewebUserLogin2);
                    //}



                }
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                Logger.EcrireDansFichierLog("pvgUserLogin", SQLEx.Message);
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                Logger.EcrireDansFichierLog("pvgUserLogin", SQLEx.Message);
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                // Logger.EcrireDansFichierLog("pvgUserLogin", "FIN Appel de la procédure de connexion");

                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }

        public clsMiccomptewebUserLogin pvgUserLoginDeconnection(string DATEJOURNEE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogin = new List<clsMiccomptewebUserLogin>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le type opération est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgUserLoginDeconnection(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTPASSE, TYPEOPERATEUR);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }

        public clsMiccomptewebmotpasseoublie pvgUserForgotPassword(string DATEJOURNEE, string CL_CONTACT, string CL_CODECLIENT, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string TYPEOPERATION)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublieListe = new List<clsMiccomptewebmotpasseoublie>();

            //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();

            clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            bool vlpTest = false;

            if (string.IsNullOrEmpty(CL_CODECLIENT))
                CL_CODECLIENT = "";

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }




            if (string.IsNullOrEmpty(CL_CONTACT))
            {


                clsMiccomptewebmotpasseoublie.CL_IDCLIENT = "";
                clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse("01/01/1900").ToShortDateString();
                clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = "";
                clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse("01/01/1900").ToShortDateString();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (CL_CONTACT.Replace(" ", "") != CL_CONTACT)
            {


                clsMiccomptewebmotpasseoublie.CL_IDCLIENT = "";
                clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse("01/01/1900").ToShortDateString();
                clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = "";
                clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse("01/01/1900").ToShortDateString();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (CL_CONTACT.Replace("-", "") != CL_CONTACT)
            {

                clsMiccomptewebmotpasseoublie.CL_IDCLIENT = "";
                clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse("01/01/1900").ToShortDateString();
                clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = "";
                clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse("01/01/1900").ToShortDateString();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);


                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);


                return clsMiccomptewebmotpasseoublieListe[0];
            }



            if (TYPEOPERATION != "03" && TYPEOPERATION != "04")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }



            if (string.IsNullOrEmpty(CL_CODECLIENT) && TYPEOPERATION == "04")
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le code client doit être renseigné !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);


                return clsMiccomptewebmotpasseoublieListe[0];
            }





            if (CL_CONTACT.Replace("/", "") != CL_CONTACT)
            {

                clsMiccomptewebmotpasseoublie.CL_IDCLIENT = "";
                clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse("01/01/1900").ToShortDateString();
                clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = "";
                clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse("01/01/1900").ToShortDateString();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);


                return clsMiccomptewebmotpasseoublieListe[0];
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, "", "", "", SL_VERSIONAPK, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {

                    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    //clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                    //clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                    return clsMiccomptewebmotpasseoublieListe[0];
                }

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                    return clsMiccomptewebmotpasseoublieListe[0];
                }

                clsMiccomptewebmotpasseoublieListe = clsTontinewebWSBLL.pvgSelectDataSetUserForgotPassword(clsDonnee, LG_CODELANGUE, CL_CONTACT, CL_CODECLIENT, TYPEOPERATION);



                string AG_CODEAGENCE = "1000";

                if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE")
                {

                    if (CL_CONTACT != "" && !CL_CONTACT.Contains("@"))
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        //if (CL_CONTACT.Length == 10)
                        //    CL_CONTACT = "00225" + CL_CONTACT;
                        string CL_IDCLIENT = "";
                        clsParams clsParams = new clsParams();
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebmotpasseoublieListe[0].AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, CL_CONTACT, clsMiccomptewebmotpasseoublieListe[0].OP_CODEOPERATEUR, DateTime.Parse(clsMiccomptewebmotpasseoublieListe[0].RP_DATE), "", CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);
                        clsMiccomptewebmotpasseoublieListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE + " " + clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEAPI;



                    }


                    if (CL_CONTACT.Contains("@") && CheckForInternetConnection())
                    {

                        string pvgTitre = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAIL;
                        string vppMotDePasseExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = CL_CONTACT;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);

                    }



                }


            }
            catch (SqlException SQLEx)
            {
                if (clsMiccomptewebmotpasseoublieListe.Count > 0)
                {
                    clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE = SQLEx.Message;
                }
                else
                {
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = SQLEx.Message;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                }
            }
            catch (Exception SQLEx)
            {
                if (clsMiccomptewebmotpasseoublieListe.Count > 0)
                {
                    clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE = SQLEx.Message;
                }
                else
                {
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = SQLEx.Message;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                }
            }


            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebmotpasseoublieListe[0];
        }

        public clsMiccomptewebUserNewPassword pvgUserUpdatePassword(string DATEJOURNEE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string TYPEOPERATEUR, string OS_MACADRESSE)

        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswordListe = new List<clsMiccomptewebUserNewPassword>();
            clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();




                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();




                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }




            if (string.IsNullOrEmpty(SL_MOTPASSEOLD))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();




                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0022", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(SL_LOGINOLD))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0023", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(SL_MOTPASSENEW))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0024", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }
            if (string.IsNullOrEmpty(SL_LOGINNEW))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0025", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }



            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }



            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                string vlpTypeOperation = "03";
                if (TYPEOPERATEUR != "04") vlpTypeOperation = "01";
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, vlpTypeOperation);

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                    return clsMiccomptewebUserNewPasswordListe[0];
                }
                //--
                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                    return clsMiccomptewebUserNewPasswordListe[0];
                }
                if (TYPEOPERATEUR == "04")
                    clsMiccomptewebUserNewPasswordListe = clsTontinewebWSBLL.pvgUserUpdatePassword(clsDonnee, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW);
                else
                    clsMiccomptewebUserNewPasswordListe = clsTontinewebWSBLL.pvgUserUpdatePasswordClient(clsDonnee, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW);

            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebUserNewPasswordListe[0];
        }

        public clsMiccomptewebUserNewPassword pvgUserNewPassword(string DATEJOURNEE, string SL_MOTPASSE, string RP_CODEVALIDATION, string RP_DATE, string RP_HEURE, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string TYPEOPERATION)
        {
            bool vlpTest = false;
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswordListe = new List<clsMiccomptewebUserNewPassword>();
            clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
                return clsMiccomptewebUserNewPasswordListe[0];
            }
            //if (string.IsNullOrEmpty(TYPEOPERATEUR))
            //{
            //    clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
            //    clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
            //    return clsMiccomptewebUserNewPasswordListe[0];
            // }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(RP_CODEVALIDATION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0013", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            if (string.IsNullOrEmpty(RP_DATE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(RP_DATE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (string.IsNullOrEmpty(RP_HEURE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0016", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }


            if (TYPEOPERATION != "01" && TYPEOPERATION != "02")
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                return clsMiccomptewebUserNewPasswordListe[0];
            }

            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----

                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, "", "", "", SL_VERSIONAPK, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {

                    clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                    return clsMiccomptewebUserNewPasswordListe[0];
                }

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

                    return clsMiccomptewebUserNewPasswordListe[0];
                }

                clsMiccomptewebUserNewPasswordListe = clsTontinewebWSBLL.pvgUserNewPassword(clsDonnee, LG_CODELANGUE, SL_MOTPASSE, RP_CODEVALIDATION, RP_DATE, RP_HEURE, TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebUserNewPasswordListe[0];
        }




        public clsTelephoneoperateur pvgTelephoneoperateur(string DATEJOURNEE, string AG_CODEAGENCE, string OS_MACADRESSE, string OS_CODEVALIDATION, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTelephoneoperateur> clsTelephoneoperateurListe = new List<clsTelephoneoperateur>();
            clsTelephoneoperateur clsMiccomptewebUserTransaction = new clsTelephoneoperateur();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            bool vlpTest = false;



            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }
            //if (string.IsNullOrEmpty(AG_CODEAGENCE))
            //{
            //    clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0027", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }

            if (TYPEOPERATION != "01" && TYPEOPERATION != "02")
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }

            if (TYPEOPERATION == "01" && string.IsNullOrEmpty(OS_CODEVALIDATION))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0013", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }


            if (TYPEOPERATION == "02" && string.IsNullOrEmpty(OS_MACADRESSE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }

            //if (string.IsNullOrEmpty(SL_LOGIN))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0003", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}

            //if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0004", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}

            //if (string.IsNullOrEmpty(SL_CLESESSION))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0005", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //  clsDonnee.pvgDemarrerTransaction();
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                //    return clsTelephoneoperateurListe;
                //}
                //--


                clsTelephoneoperateurListe = clsTontinewebWSBLL.pvgTelephoneoperateur(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OS_MACADRESSE, OS_CODEVALIDATION, TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebUserTransaction.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebUserTransaction.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTelephoneoperateurListe[0];
        }



        public clsTelephoneoperateur pvgTelephoneoperateurCreationcpte(string DATEJOURNEE, string AG_CODEAGENCE, string OS_MACADRESSE, string OS_CODEVALIDATION, string OS_TELEPHONE, string OP_CODEOPERATEUR, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTelephoneoperateur> clsTelephoneoperateurListe = new List<clsTelephoneoperateur>();
            clsTelephoneoperateur clsMiccomptewebUserTransaction = new clsTelephoneoperateur();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            bool vlpTest = false;


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }




            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }
            //if (string.IsNullOrEmpty(AG_CODEAGENCE))
            //{
            //    clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0027", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }

            if (TYPEOPERATION != "01")
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }

            //if (TYPEOPERATION == "01" && string.IsNullOrEmpty(OS_CODEVALIDATION))
            //{
            //    clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0013", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}





            OP_CODEOPERATEUR = "";

            //if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            //{
            //    clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0028", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }

            if (string.IsNullOrEmpty(OS_TELEPHONE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0240", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                return clsTelephoneoperateurListe[0];
            }


            if (OS_TELEPHONE.Replace(" ", "") != OS_TELEPHONE)
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
                return clsTelephoneoperateurListe[0];
            }

            if (OS_TELEPHONE.Replace("-", "") != OS_TELEPHONE)
            {
                List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
                return clsTelephoneoperateurListe[0];
            }


            if (OS_TELEPHONE.Replace("/", "") != OS_TELEPHONE)
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
                return clsTelephoneoperateurListe[0];
            }




            //if (string.IsNullOrEmpty(SL_LOGIN))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0003", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}

            //if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0004", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}

            //if (string.IsNullOrEmpty(SL_CLESESSION))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, "MSB0005", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

            //    return clsTelephoneoperateurListe;
            //}



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //  clsDonnee.pvgDemarrerTransaction();
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);

                //    return clsTelephoneoperateurListe;
                //}
                //--


                clsTelephoneoperateurListe = clsTontinewebWSBLL.pvgTelephoneoperateurCreationcpte(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OS_MACADRESSE, OS_CODEVALIDATION, OS_TELEPHONE, OP_CODEOPERATEUR, TYPEOPERATION);

                //if (clsTelephoneoperateurListe[0].SL_RESULTAT == "TRUE" && CheckForInternetConnection())
                //{
                //    if (OS_TELEPHONE != "")
                //        SendMessage(clsTelephoneoperateurListe[0].SL_SMSOPERATEUR, "225", OS_TELEPHONE, AG_CODEAGENCE);

                //}

                if (clsTelephoneoperateurListe[0].SL_RESULTAT == "TRUE")
                {

                    clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                    if (OS_TELEPHONE.Length == 8)
                        OS_TELEPHONE = "00225" + OS_TELEPHONE;
                    string CL_IDCLIENT = "";
                    clsParams clsParams = new clsParams();
                    clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsTelephoneoperateurListe[0].AG_CODEAGENCE, clsTelephoneoperateurListe[0].PV_CODEPOINTVENTE, clsTelephoneoperateurListe[0].CO_CODECOMPTE, clsTelephoneoperateurListe[0].OB_NOMOBJET, OS_TELEPHONE, clsTelephoneoperateurListe[0].OP_CODEOPERATEUR, DateTime.Parse(clsTelephoneoperateurListe[0].OP_DATEOPERATION), "", CL_IDCLIENT, "", clsTelephoneoperateurListe[0].SL_SMSOPERATEUR, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsTelephoneoperateurListe[0].SL_LIBELLE1, clsTelephoneoperateurListe[0].SL_LIBELLE2);
                    clsTelephoneoperateurListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                    clsTelephoneoperateurListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                    if (clsParams.SL_RESULTAT == "FALSE") clsTelephoneoperateurListe[0].SL_MESSAGE = clsTelephoneoperateurListe[0].SL_MESSAGE + " " + clsTelephoneoperateurListe[0].SL_MESSAGEAPI;
                }






            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebUserTransaction.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebUserTransaction.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsTelephoneoperateurListe.Add(clsMiccomptewebUserTransaction);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTelephoneoperateurListe[0];
        }




        public clsMiccomptewebmotpasseoublie pvgCreationClientTontine(string DATEJOURNEE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string CO_CODECOMMUNE, string EJ_ADRESSEGEOGRAPHIQUE, string PY_CODEPAYSNATIONALITE, string SM_CODESITUATIONMATRIMONIALE, string PF_CODEPROFESSION, string PI_CODEPIECE, string EJ_BOITEPOSTALE, string EJ_NOMEPARGNANTJOURNALIER, string EJ_PRENOMEPARGNANTJOURNALIER, string EJ_DATENAISSANCE, string EJ_LIEUNAISSANCE, string EJ_TELEPHONE, string EJ_FAX, string EJ_EMAIL, string EJ_SITEWEB, string EJ_NUMPIECE, string EJ_DATEEXPIRATIONPIECE, string EJ_REGIMEMATRIMONIALE, string EJ_NBENFANT, string CM_IDCOMMERCIAL, string MI_VALEUR, string EJ_LONGITUDELATIITUDE, string TYPEOPERATION,  string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();

            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;

            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

           

            List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublieListe = new List<clsMiccomptewebmotpasseoublie>();

            clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(EJ_LONGITUDELATIITUDE)) EJ_LONGITUDELATIITUDE = "0";
            if (string.IsNullOrEmpty(EJ_NBENFANT)) EJ_NBENFANT = "0";


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(EJ_NOMEPARGNANTJOURNALIER))
            {

                //----EXEPTION  
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0066", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(EJ_PRENOMEPARGNANTJOURNALIER))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0067", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }




            if (string.IsNullOrEmpty(EJ_DATENAISSANCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(EJ_DATENAISSANCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];

            }


            if (string.IsNullOrEmpty(DATEJOURNEE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];

            }



            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];

            }


            if (string.IsNullOrEmpty(EJ_TELEPHONE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (EJ_TELEPHONE.Replace(" ", "") != EJ_TELEPHONE)
            {
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (EJ_TELEPHONE.Replace("-", "") != EJ_TELEPHONE)
            {

                List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (EJ_TELEPHONE.Replace("/", "") != EJ_TELEPHONE)
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            //if (string.IsNullOrEmpty(MB_EMAIL))
            //{



            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le contact est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}

            if (string.IsNullOrEmpty(EJ_LIEUNAISSANCE))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0081", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            //if (string.IsNullOrEmpty(EJ_NUMPIECE))
            //{


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0080", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}

            //if (string.IsNullOrEmpty(EJ_NUMPIECE))
            //{



            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0080", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}

            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(EJ_REGIMEMATRIMONIALE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0082", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            //if (string.IsNullOrEmpty(PI_CODEPIECE))
            //{



            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0083", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}


            if (string.IsNullOrEmpty(PY_CODEPAYSNATIONALITE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0084", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(EJ_ADRESSEGEOGRAPHIQUE))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0085", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }






            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            //if (string.IsNullOrEmpty(CL_REGISTRECOMMERCE))
            //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le régistre de commerce  est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}


            //if (string.IsNullOrEmpty(CL_NUMEROCOMPTECONTRIBUABLE))
            //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le numero compte contribualble est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}

            if (string.IsNullOrEmpty(CO_CODECOMMUNE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0072", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(PF_CODEPROFESSION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0086", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (TYPEOPERATION != "01")
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(CM_IDCOMMERCIAL))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0268", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }



            if (string.IsNullOrEmpty(SM_CODESITUATIONMATRIMONIALE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0087", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }//if (string.IsNullOrEmpty(CL_CAPITAL))
             //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le capital est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}
            //if (WSTOOLS.clsChaineCaractere.ClasseChaineCaractere.isLetter(CL_CAPITAL))
            //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "saisissez un nombre dans la zone de capital !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}

            if (string.IsNullOrEmpty(EJ_NBENFANT))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0270", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }
            if (clsChaineCaractere.ClasseChaineCaractere.isLetter(EJ_NBENFANT))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0271", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }






            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                    return clsMiccomptewebmotpasseoublieListe[0];
                }

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                    return clsMiccomptewebmotpasseoublieListe[0];
                }


                EJ_ADRESSEGEOGRAPHIQUE = EJ_ADRESSEGEOGRAPHIQUE.ToUpper();
                EJ_BOITEPOSTALE = EJ_BOITEPOSTALE.ToUpper();
                EJ_NOMEPARGNANTJOURNALIER = EJ_NOMEPARGNANTJOURNALIER.ToUpper();
                EJ_PRENOMEPARGNANTJOURNALIER = EJ_PRENOMEPARGNANTJOURNALIER.ToUpper();
                EJ_LIEUNAISSANCE = EJ_LIEUNAISSANCE.ToUpper();
                EJ_SITEWEB = EJ_SITEWEB.ToUpper();
                EJ_NUMPIECE = EJ_NUMPIECE.ToUpper();
                EJ_REGIMEMATRIMONIALE = EJ_REGIMEMATRIMONIALE.ToUpper();

                clsMiccomptewebmotpasseoublieListe = clsTontinewebWSBLL.pvgCreationClientTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, CO_CODECOMMUNE, EJ_ADRESSEGEOGRAPHIQUE, PY_CODEPAYSNATIONALITE, SM_CODESITUATIONMATRIMONIALE, PF_CODEPROFESSION, PI_CODEPIECE, EJ_BOITEPOSTALE, EJ_NOMEPARGNANTJOURNALIER, EJ_PRENOMEPARGNANTJOURNALIER, DATEJOURNEE, EJ_DATENAISSANCE, EJ_LIEUNAISSANCE, EJ_TELEPHONE, EJ_FAX, EJ_EMAIL, EJ_SITEWEB, EJ_NUMPIECE, EJ_DATEEXPIRATIONPIECE, EJ_REGIMEMATRIMONIALE, EJ_NBENFANT, CM_IDCOMMERCIAL, MI_VALEUR, EJ_LONGITUDELATIITUDE, TYPEOPERATION);





                if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE")
                {
                    if (EJ_TELEPHONE != "")
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        if (EJ_TELEPHONE.Length == 8)
                            EJ_TELEPHONE = "00225" + EJ_TELEPHONE;
                        //clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE = "0022547839553";// + clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE;
                        //TE_CODESMSTYPEOPERATION = string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                        clsParams clsParams = new clsParams();
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, EJ_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsMiccomptewebmotpasseoublieListe[0].RP_DATE), "", clsMiccomptewebmotpasseoublieListe[0].CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0008", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);
                        clsMiccomptewebmotpasseoublieListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE + " " + clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEAPI;




                    }
                    if (EJ_EMAIL != "" && clsMiccomptewebmotpasseoublieListe[0].AG_EMAIL != "" && clsMiccomptewebmotpasseoublieListe[0].AG_EMAILMOTDEPASSE != "")
                    {

                        string pvgTitre = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAIL;
                        string vppMotDePasseExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = EJ_EMAIL;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                    }



                }

                //if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE" && CheckForInternetConnection())
                //{
                //    if (EJ_TELEPHONE != "")
                //        SendMessage(clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "225", EJ_TELEPHONE, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, clsMiccomptewebmotpasseoublieListe[0].RP_NUMSEQUENCE, "OK");

                //}

                //if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE" && !CheckForInternetConnection())
                //{
                //    if (EJ_TELEPHONE != "")
                //        SendMessage(clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "225", EJ_TELEPHONE, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, clsMiccomptewebmotpasseoublieListe[0].RP_NUMSEQUENCE, "OK");

                //}


            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            }
            finally
            {
                if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebmotpasseoublieListe[0];
        }

        public clsMiccomptewebmotpasseoublie pvgCreationClientTontineDiffere(List<clsParametreClientdiffere> Objet)
        {
            

            clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieListe = new clsMiccomptewebmotpasseoublie();
            int vlpTest = 0;
            foreach (clsParametreClientdiffere clsParametreClientdiffereDTO in Objet)
            {
                clsDonnee = new clsDonnee();
                SqlConnection vogObjetConnexionLocal = new SqlConnection();
                clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //if (vlpTest == 0)
                //{
                //    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //    vogObjetConnexionLocal = clsDonnee.vogObjetConnexionLocal;
                //}

                //else
                //    clsDonnee.vogObjetConnexionLocal = vogObjetConnexionLocal;
                //vlpTest = 1;
               clsMiccomptewebmotpasseoublieListe =pvgCreationClientTontineBis(clsParametreClientdiffereDTO.DATEJOURNEE, clsParametreClientdiffereDTO.AG_CODEAGENCE, clsParametreClientdiffereDTO.OP_CODEOPERATEUR, clsParametreClientdiffereDTO.CO_CODECOMMUNE, clsParametreClientdiffereDTO.EJ_ADRESSEGEOGRAPHIQUE, clsParametreClientdiffereDTO.PY_CODEPAYSNATIONALITE, clsParametreClientdiffereDTO.SM_CODESITUATIONMATRIMONIALE, clsParametreClientdiffereDTO.PF_CODEPROFESSION, clsParametreClientdiffereDTO.PI_CODEPIECE, clsParametreClientdiffereDTO.EJ_BOITEPOSTALE, clsParametreClientdiffereDTO.EJ_NOMEPARGNANTJOURNALIER, clsParametreClientdiffereDTO.EJ_PRENOMEPARGNANTJOURNALIER, clsParametreClientdiffereDTO.EJ_DATENAISSANCE, clsParametreClientdiffereDTO.EJ_LIEUNAISSANCE, clsParametreClientdiffereDTO.EJ_TELEPHONE, clsParametreClientdiffereDTO.EJ_FAX, clsParametreClientdiffereDTO.EJ_EMAIL, clsParametreClientdiffereDTO.EJ_SITEWEB, clsParametreClientdiffereDTO.EJ_NUMPIECE, clsParametreClientdiffereDTO.EJ_DATEEXPIRATIONPIECE, clsParametreClientdiffereDTO.EJ_REGIMEMATRIMONIALE, clsParametreClientdiffereDTO.EJ_NBENFANT, clsParametreClientdiffereDTO.CM_IDCOMMERCIAL, clsParametreClientdiffereDTO.MI_VALEUR, clsParametreClientdiffereDTO.EJ_LONGITUDELATIITUDE, clsParametreClientdiffereDTO.TYPEOPERATION, clsParametreClientdiffereDTO.SL_LOGIN, clsParametreClientdiffereDTO.SL_MOTDEPASSE, clsParametreClientdiffereDTO.SL_CLESESSION, clsParametreClientdiffereDTO.SL_VERSIONAPK, clsParametreClientdiffereDTO.LG_CODELANGUE, clsParametreClientdiffereDTO.OS_MACADRESSE, clsDonnee, clsObjetEnvoi);
                if (clsMiccomptewebmotpasseoublieListe.SL_RESULTAT == "TRUE")
                {
                    clsDonnee = new clsDonnee();
                    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                    clsTontinewebWSBLL.pvgUploadPhotoSignature(clsDonnee, clsParametreClientdiffereDTO.PHOTO, clsParametreClientdiffereDTO.SIGNATURE, clsMiccomptewebmotpasseoublieListe.CL_CODECLIENT, clsMiccomptewebmotpasseoublieListe.CL_CODECLIENT, clsParametreClientdiffereDTO.LG_CODELANGUE);
                }
                   

            }
            return clsMiccomptewebmotpasseoublieListe;


        }


        public clsMiccomptewebmotpasseoublie pvgCreationClientTontineBis(string DATEJOURNEE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string CO_CODECOMMUNE, string EJ_ADRESSEGEOGRAPHIQUE, string PY_CODEPAYSNATIONALITE, string SM_CODESITUATIONMATRIMONIALE, string PF_CODEPROFESSION, string PI_CODEPIECE, string EJ_BOITEPOSTALE, string EJ_NOMEPARGNANTJOURNALIER, string EJ_PRENOMEPARGNANTJOURNALIER, string EJ_DATENAISSANCE, string EJ_LIEUNAISSANCE, string EJ_TELEPHONE, string EJ_FAX, string EJ_EMAIL, string EJ_SITEWEB, string EJ_NUMPIECE, string EJ_DATEEXPIRATIONPIECE, string EJ_REGIMEMATRIMONIALE, string EJ_NBENFANT, string CM_IDCOMMERCIAL, string MI_VALEUR, string EJ_LONGITUDELATIITUDE, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            //clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();

            //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;

            //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;



            List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublieListe = new List<clsMiccomptewebmotpasseoublie>();

            clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(EJ_LONGITUDELATIITUDE)) EJ_LONGITUDELATIITUDE = "0";
            if (string.IsNullOrEmpty(EJ_NBENFANT)) EJ_NBENFANT = "0";

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(EJ_NOMEPARGNANTJOURNALIER))
            {

                //----EXEPTION  
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0066", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(EJ_PRENOMEPARGNANTJOURNALIER))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0067", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }




            if (string.IsNullOrEmpty(EJ_DATENAISSANCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(EJ_DATENAISSANCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];

            }


            if (string.IsNullOrEmpty(DATEJOURNEE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];

            }



            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsResultatOperation1 clsResultatOperation = new clsResultatOperation1();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];

            }


            if (string.IsNullOrEmpty(EJ_TELEPHONE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (EJ_TELEPHONE.Replace(" ", "") != EJ_TELEPHONE)
            {
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (EJ_TELEPHONE.Replace("-", "") != EJ_TELEPHONE)
            {

                List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (EJ_TELEPHONE.Replace("/", "") != EJ_TELEPHONE)
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            //if (string.IsNullOrEmpty(MB_EMAIL))
            //{



            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le contact est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}

            if (string.IsNullOrEmpty(EJ_LIEUNAISSANCE))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0081", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            //if (string.IsNullOrEmpty(EJ_NUMPIECE))
            //{


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0080", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}

            //if (string.IsNullOrEmpty(EJ_NUMPIECE))
            //{



            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0080", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}

            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(EJ_REGIMEMATRIMONIALE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0082", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            //if (string.IsNullOrEmpty(PI_CODEPIECE))
            //{



            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0083", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}


            if (string.IsNullOrEmpty(PY_CODEPAYSNATIONALITE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0084", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(EJ_ADRESSEGEOGRAPHIQUE))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0085", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }






            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            //if (string.IsNullOrEmpty(CL_REGISTRECOMMERCE))
            //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le régistre de commerce  est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}


            //if (string.IsNullOrEmpty(CL_NUMEROCOMPTECONTRIBUABLE))
            //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le numero compte contribualble est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}

            if (string.IsNullOrEmpty(CO_CODECOMMUNE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0072", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(PF_CODEPROFESSION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0086", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (TYPEOPERATION != "01")
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(CM_IDCOMMERCIAL))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0268", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }



            if (string.IsNullOrEmpty(SM_CODESITUATIONMATRIMONIALE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0087", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }//if (string.IsNullOrEmpty(CL_CAPITAL))
             //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "Le capital est obligatoire !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}
            //if (WSTOOLS.clsChaineCaractere.ClasseChaineCaractere.isLetter(CL_CAPITAL))
            //{

            //    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();

            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = "saisissez un nombre dans la zone de capital !!!";
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return new JavaScriptSerializer().Serialize(clsMiccomptewebmotpasseoublieListe[0]);
            //}

            if (string.IsNullOrEmpty(EJ_NBENFANT))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0270", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }
            if (clsChaineCaractere.ClasseChaineCaractere.isLetter(EJ_NBENFANT))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0271", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublieListe[0];
            }


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                return clsMiccomptewebmotpasseoublieListe[0];
            }






            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                    return clsMiccomptewebmotpasseoublieListe[0];
                }

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);

                    return clsMiccomptewebmotpasseoublieListe[0];
                }


                EJ_ADRESSEGEOGRAPHIQUE = EJ_ADRESSEGEOGRAPHIQUE.ToUpper();
                EJ_BOITEPOSTALE = EJ_BOITEPOSTALE.ToUpper();
                EJ_NOMEPARGNANTJOURNALIER = EJ_NOMEPARGNANTJOURNALIER.ToUpper();
                EJ_PRENOMEPARGNANTJOURNALIER = EJ_PRENOMEPARGNANTJOURNALIER.ToUpper();
                EJ_LIEUNAISSANCE = EJ_LIEUNAISSANCE.ToUpper();
                EJ_SITEWEB = EJ_SITEWEB.ToUpper();
                EJ_NUMPIECE = EJ_NUMPIECE.ToUpper();
                EJ_REGIMEMATRIMONIALE = EJ_REGIMEMATRIMONIALE.ToUpper();

                clsMiccomptewebmotpasseoublieListe = clsTontinewebWSBLL.pvgCreationClientTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, CO_CODECOMMUNE, EJ_ADRESSEGEOGRAPHIQUE, PY_CODEPAYSNATIONALITE, SM_CODESITUATIONMATRIMONIALE, PF_CODEPROFESSION, PI_CODEPIECE, EJ_BOITEPOSTALE, EJ_NOMEPARGNANTJOURNALIER, EJ_PRENOMEPARGNANTJOURNALIER, DATEJOURNEE, EJ_DATENAISSANCE, EJ_LIEUNAISSANCE, EJ_TELEPHONE, EJ_FAX, EJ_EMAIL, EJ_SITEWEB, EJ_NUMPIECE, EJ_DATEEXPIRATIONPIECE, EJ_REGIMEMATRIMONIALE, EJ_NBENFANT, CM_IDCOMMERCIAL, MI_VALEUR, EJ_LONGITUDELATIITUDE, TYPEOPERATION);





                if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE")
                {
                    if (EJ_TELEPHONE != "")
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        if (EJ_TELEPHONE.Length == 8)
                            EJ_TELEPHONE = "00225" + EJ_TELEPHONE;
                        //clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE = "0022547839553";// + clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE;
                        //TE_CODESMSTYPEOPERATION = string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                        clsParams clsParams = new clsParams();
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, EJ_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsMiccomptewebmotpasseoublieListe[0].RP_DATE), "", clsMiccomptewebmotpasseoublieListe[0].CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0008", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);
                        clsMiccomptewebmotpasseoublieListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE + " " + clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEAPI;




                    }
                    if (EJ_EMAIL != "" && clsMiccomptewebmotpasseoublieListe[0].AG_EMAIL != "" && clsMiccomptewebmotpasseoublieListe[0].AG_EMAILMOTDEPASSE != "")
                    {

                        string pvgTitre = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAIL;
                        string vppMotDePasseExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = EJ_EMAIL;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                    }



                }

                //if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE" && CheckForInternetConnection())
                //{
                //    if (EJ_TELEPHONE != "")
                //        SendMessage(clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "225", EJ_TELEPHONE, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, clsMiccomptewebmotpasseoublieListe[0].RP_NUMSEQUENCE, "OK");

                //}

                //if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "TRUE" && !CheckForInternetConnection())
                //{
                //    if (EJ_TELEPHONE != "")
                //        SendMessage(clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "225", EJ_TELEPHONE, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, clsMiccomptewebmotpasseoublieListe[0].RP_NUMSEQUENCE, "OK");

                //}


            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebmotpasseoublie.SL_RESULTAT = "FALSE";
                clsMiccomptewebmotpasseoublie.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            }
            finally
            {
                if (clsMiccomptewebmotpasseoublieListe[0].SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebmotpasseoublieListe[0];
        }



        public List<clsReedition> pvgReedition(string DATEJOURNEE, string AG_CODEAGENCE, string MC_DATEPIECE, string MC_NUMPIECE, string CL_TELEPHONE, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsReedition> clsMiccomptewebUserTransactionListe = new List<clsReedition>();
            clsReedition clsMiccomptewebUserTransaction = new clsReedition();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            bool vlpTest = false;
            if (string.IsNullOrEmpty(TYPEOPERATION))
                TYPEOPERATION = "01";
            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(MC_NUMPIECE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0258", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }

            MC_NUMPIECE = MC_NUMPIECE.Replace(" ", "");
            if (!clsChaineCaractere.ClasseChaineCaractere.isDigit(MC_NUMPIECE))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0261", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
                return clsMiccomptewebUserTransactionListe;
            }


            //string CL_TELEPHONE, string TYPEOPERATION,
            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
                return clsMiccomptewebUserTransactionListe;
            }
            if (string.IsNullOrEmpty(CL_TELEPHONE) && TYPEOPERATION=="02")
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = "Le téléphone est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
                return clsMiccomptewebUserTransactionListe;
            }


            if (string.IsNullOrEmpty(MC_DATEPIECE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
                return clsMiccomptewebUserTransactionListe;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(MC_DATEPIECE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
                return clsMiccomptewebUserTransactionListe;

            }





            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }
            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }


            //if (string.IsNullOrEmpty(NUMEROBORDEREAU))
            //{
            //    //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee,LG_CODELANGUE, "MSB0152", "01");
            //    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

            //    return clsMiccomptewebUserTransactionListe;
            //}

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                return clsMiccomptewebUserTransactionListe;
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                //  clsDonnee.pvgDemarrerTransaction();
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                    return clsMiccomptewebUserTransactionListe;
                }
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebUserTransaction.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserTransaction.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserTransaction.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);

                    return clsMiccomptewebUserTransactionListe;
                }

                clsMiccomptewebUserTransactionListe = clsTontinewebWSBLL.pvgReedition(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, SL_LOGIN, SL_MOTDEPASSE);

                if (clsMiccomptewebUserTransactionListe[0].SL_RESULTAT == "TRUE" && TYPEOPERATION == "02")
                {


                    if (CL_TELEPHONE != "" && !CL_TELEPHONE.Contains("@"))
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        string CL_IDCLIENT = "";
                        clsParams clsParams = new clsParams();
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsMiccomptewebUserTransactionListe[0].PV_CODEPOINTVENTE, clsMiccomptewebUserTransactionListe[0].CO_CODECOMPTE, clsMiccomptewebUserTransactionListe[0].OB_NOMOBJET, CL_TELEPHONE, clsMiccomptewebUserTransactionListe[0].OP_CODEOPERATEUR, DateTime.Parse(clsMiccomptewebUserTransactionListe[0].MC_DATEPIECE), "", CL_IDCLIENT, "", clsMiccomptewebUserTransactionListe[0].SL_MESSAGECLIENT, "0023", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebUserTransactionListe[0].SL_LIBELLE1, clsMiccomptewebUserTransactionListe[0].SL_LIBELLE2);
                        clsMiccomptewebUserTransactionListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        clsMiccomptewebUserTransactionListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebUserTransactionListe[0].SL_MESSAGE = clsMiccomptewebUserTransactionListe[0].SL_MESSAGE + " " + clsMiccomptewebUserTransactionListe[0].SL_MESSAGEAPI;



                    }


                    if (CL_TELEPHONE.Contains("@") && CheckForInternetConnection())
                    {
                        string AG_EMAIL = "";
                        string AG_EMAILMOTDEPASSE = "";
                        DataSet DataSet = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] {AG_CODEAGENCE };
                        DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetAgence(clsDonnee, clsObjetEnvoi);
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            AG_EMAIL = row["AG_EMAIL"].ToString();
                            AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                        }

                        string pvgTitre = "Réédition";// clsMiccomptewebUserTransactionListe[0].SL_MESSAGEOBJET;
                        string vppMessage = clsMiccomptewebUserTransactionListe[0].SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = AG_EMAIL;
                        string vppMotDePasseExpediteur = AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = CL_TELEPHONE;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);

                    }




                    //if (CL_TELEPHONE != "")
                    //{

                    //    clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                    //    if (CL_TELEPHONE.Length == 8)
                    //        CL_TELEPHONE = "00225" + CL_TELEPHONE;
                    //    string CL_IDCLIENT = "";
                    //    clsParams clsParams = new clsParams();
                    //    clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsMiccomptewebUserTransactionListe[0].PV_CODEPOINTVENTE, clsMiccomptewebUserTransactionListe[0].CO_CODECOMPTE, clsMiccomptewebUserTransactionListe[0].OB_NOMOBJET, CL_TELEPHONE, clsMiccomptewebUserTransactionListe[0].OP_CODEOPERATEUR, DateTime.Parse(clsMiccomptewebUserTransactionListe[0].MC_DATEPIECE), "", CL_IDCLIENT, "", clsMiccomptewebUserTransactionListe[0].SL_MESSAGECLIENT, "0023", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebUserTransactionListe[0].SL_LIBELLE1, clsMiccomptewebUserTransactionListe[0].SL_LIBELLE2);
                    //    clsMiccomptewebUserTransactionListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                    //    clsMiccomptewebUserTransactionListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                    //    if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebUserTransactionListe[0].SL_MESSAGE = clsMiccomptewebUserTransactionListe[0].SL_MESSAGE + " " + clsMiccomptewebUserTransactionListe[0].SL_MESSAGEAPI;
                    //}

                }


            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebUserTransaction.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebUserTransaction.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserTransaction.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserTransactionListe.Add(clsMiccomptewebUserTransaction);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebUserTransactionListe;
        }

        public List<clsTontineCarnet> pvgCarnetsClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontineCarnet> clsTontineCarnets = new List<clsTontineCarnet>();
            clsTontineCarnet clsTontineCarnet1 = new clsTontineCarnet();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR)) OP_CODEOPERATEUR = "";
            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;


            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }



            if (string.IsNullOrEmpty(CL_CODECLIENT))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }

            CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarnets.Add(clsTontineCarnet1);

                return clsTontineCarnets;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCarnets.Add(clsTontineCarnet1);

                    return clsTontineCarnets;

                }
                //--
                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarnet1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarnet1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarnet1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCarnets.Add(clsTontineCarnet1);

                    return clsTontineCarnets;
                }


                clsTontineCarnets = clsTontinewebWSBLL.pvgSelectCarnetsClient(clsDonnee, AG_CODEAGENCE, LG_CODELANGUE, CL_CODECLIENT, OP_CODEOPERATEUR);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontineCarnets;
        }


        public List<clsTontineCarte> pvgSelectCarteCarnet(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT,string CT_CODECARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR, string CM_IDCOMMERCIAL, string TYPEOPERATION)
        {


            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontineCarte> clsTontineCartes = new List<clsTontineCarte>();
            clsTontineCarte clsTontineCarte1 = new clsTontineCarte();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR)) OP_CODEOPERATEUR = "";
            if (string.IsNullOrEmpty(CT_CODECARTE)) CT_CODECARTE = "";
            if (string.IsNullOrEmpty(TYPEOPERATION)) TYPEOPERATION = "01";
            if (string.IsNullOrEmpty(CM_IDCOMMERCIAL)) CM_IDCOMMERCIAL = "";
            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;

            }

            if (TYPEOPERATION == "02" && string.IsNullOrEmpty(CM_IDCOMMERCIAL))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = "Le commercial doit être renseigné !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;


            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;


            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }



            if (TYPEOPERATION != "02" && string.IsNullOrEmpty(CL_CODECLIENT))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }
            if (TYPEOPERATION != "02")
            CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCartes.Add(clsTontineCarte1);

                    return clsTontineCartes;

                }
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCartes.Add(clsTontineCarte1);

                    return clsTontineCartes;
                }

                clsTontineCartes = clsTontinewebWSBLL.pvgSelectCarteCarnet(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT, CT_CODECARTE, DATEJOURNEE, LG_CODELANGUE, OP_CODEOPERATEUR,  CM_IDCOMMERCIAL,  TYPEOPERATION);
                

            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }

            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontineCartes;
        }


        public List<clsTontineCarte> pvgSelectCarteCarnetClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT,string CT_CODECARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR, string CM_IDCOMMERCIAL, string TYPEOPERATION)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontineCarte> clsTontineCartes = new List<clsTontineCarte>();
            clsTontineCarte clsTontineCarte1 = new clsTontineCarte();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR)) OP_CODEOPERATEUR = "";
            if (string.IsNullOrEmpty(CT_CODECARTE)) CT_CODECARTE = "";
            if (string.IsNullOrEmpty(TYPEOPERATION)) TYPEOPERATION = "01";
            if (string.IsNullOrEmpty(CM_IDCOMMERCIAL)) CM_IDCOMMERCIAL = "";

            if(CT_CODECARTE!="")
            CT_CODECARTE = string.Format("{0:00000000}", double.Parse(CT_CODECARTE));

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }




            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;

            }

            if (TYPEOPERATION=="02" && string.IsNullOrEmpty(CM_IDCOMMERCIAL))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = "Le commercial doit être renseigné !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;


            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;


            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;

                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (TYPEOPERATION != "02" && string.IsNullOrEmpty(CL_CODECLIENT))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }
            if(TYPEOPERATION != "02")
            CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCartes.Add(clsTontineCarte1);

                    return clsTontineCartes;

                }
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCartes.Add(clsTontineCarte1);

                    return clsTontineCartes;
                }

                clsTontineCartes = clsTontinewebWSBLL.pvgSelectCarteCarnet(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT, CT_CODECARTE, DATEJOURNEE, LG_CODELANGUE, OP_CODEOPERATEUR,  CM_IDCOMMERCIAL,  TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontineCartes;
        }



        public List<clsTontineCarte> pvgSituationportefeuilleclient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CT_CODECARTE,string CM_IDCOMMERCIAL, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontineCarte> clsTontineCartes = new List<clsTontineCarte>();
            clsTontineCarte clsTontineCarte1 = new clsTontineCarte();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();


            if (string.IsNullOrEmpty(OP_CODEOPERATEUR)) OP_CODEOPERATEUR = "";
            if (string.IsNullOrEmpty(CT_CODECARTE)) CT_CODECARTE = "";
            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0027", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;

            }



            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;


            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(CM_IDCOMMERCIAL))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontineCarte1.SL_CODEMESSAGE = "Le commercial doit être renseigné !!!";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            //if (string.IsNullOrEmpty(CL_CODECLIENT))
            //{
            //    //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0155", "01");
            //    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTontineCartes.Add(clsTontineCarte1);

            //    return clsTontineCartes;
            //}
            if (!string.IsNullOrEmpty(CL_CODECLIENT))
                CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));
            else
                CL_CODECLIENT = "";
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCartes.Add(clsTontineCarte1);

                return clsTontineCartes;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCartes.Add(clsTontineCarte1);

                    return clsTontineCartes;

                }
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontineCartes.Add(clsTontineCarte1);

                    return clsTontineCartes;
                }

                clsTontineCartes = clsTontinewebWSBLL.pvgSituationportefeuilleclient(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT, CT_CODECARTE, DATEJOURNEE, CM_IDCOMMERCIAL, LG_CODELANGUE, OP_CODEOPERATEUR);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }

            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontineCartes;
        }





        public List<clsListedesclients> pvgListeDesClients(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CL_TELEPHONE, string CL_NOMCLIENT, string CL_PRENOMCLIENT, string DATEJOURNEE1, string DATEJOURNEE2, string NOMBRELIGNE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string ET_TYPEETAT, string LG_CODELANGUE, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsListedesclients> clsListedesclientss = new List<clsListedesclients>();
            clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            clsListedesclients clsListedesclients = new clsListedesclients();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE1))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0030", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0031", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0032", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0033", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (DateTime.Parse(DATEJOURNEE1) > DateTime.Parse(DATEJOURNEE2))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0065", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }




            if (clsChaineCaractere.ClasseChaineCaractere.isLetter(NOMBRELIGNE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }




            if (string.IsNullOrEmpty(NOMBRELIGNE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }




            if (NOMBRELIGNE == "0")
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }




            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }



            if (string.IsNullOrEmpty(ET_TYPEETAT))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (ET_TYPEETAT != "04" && ET_TYPEETAT != "05")
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }





            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsListedesclientss.Add(clsListedesclients);

                    return clsListedesclientss;
                }


                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsListedesclientss.Add(clsListedesclients);

                    return clsListedesclientss;
                }


                clsListedesclientss = clsTontinewebWSBLL.pvgListeDesClients(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, CL_CODECLIENT, CL_TELEPHONE, CL_NOMCLIENT, CL_PRENOMCLIENT, DATEJOURNEE1, DATEJOURNEE2, int.Parse(NOMBRELIGNE), OP_CODEOPERATEUR, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, ET_TYPEETAT);


            }
            catch (SqlException SQLEx)
            {

                clsListedesclients.SL_RESULTAT = "FALSE";
                clsListedesclients.SL_MESSAGE = SQLEx.Message;
                clsListedesclientss.Add(clsListedesclients);
            }
            catch (Exception SQLEx)
            {

                clsListedesclients.SL_RESULTAT = "FALSE";
                clsListedesclients.SL_MESSAGE = SQLEx.Message;
                clsListedesclientss.Add(clsListedesclients);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsListedesclientss;
        }

        public List<clsTransactiontontine> pvgListeDesTransactionTontine(string DATEJOURNEE,  string AG_CODEAGENCE, string CL_CODECLIENT, string CL_TELEPHONE, string CT_CODECARTE,  string DATEJOURNEE1, string DATEJOURNEE2, string ET_TYPEETAT, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK,  string LG_CODELANGUE, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTransactiontontine> clsListedesclientss = new List<clsTransactiontontine>();
            clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            clsTransactiontontine clsListedesclients = new clsTransactiontontine();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE1))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0030", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0031", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0032", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0033", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (DateTime.Parse(DATEJOURNEE1) > DateTime.Parse(DATEJOURNEE2))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0065", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }




            //if (clsChaineCaractere.ClasseChaineCaractere.isLetter(NOMBRELIGNE))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);

            //    return clsListedesclientss;
            //}




            //if (string.IsNullOrEmpty(NOMBRELIGNE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);
            //    return clsListedesclientss;
            //}




            //if (NOMBRELIGNE == "0")
            //{


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);
            //    return clsListedesclientss;
            //}




            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }



            if (string.IsNullOrEmpty(ET_TYPEETAT))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            //if (ET_TYPEETAT != "04")
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);

            //    return clsListedesclientss;
            //}





            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsListedesclientss.Add(clsListedesclients);

                //    return clsListedesclientss;
                //}


                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsListedesclientss.Add(clsListedesclients);

                    return clsListedesclientss;
                }


                clsListedesclientss = clsTontinewebWSBLL.pvgListeDesTransactionTontine(clsDonnee,  LG_CODELANGUE,  AG_CODEAGENCE,  CL_CODECLIENT,  CL_TELEPHONE,  CT_CODECARTE,   DATEJOURNEE1,  DATEJOURNEE2,  ET_TYPEETAT);


            }
            catch (SqlException SQLEx)
            {

                clsListedesclients.SL_RESULTAT = "FALSE";
                clsListedesclients.SL_MESSAGE = SQLEx.Message;
                clsListedesclientss.Add(clsListedesclients);
            }
            catch (Exception SQLEx)
            {

                clsListedesclients.SL_RESULTAT = "FALSE";
                clsListedesclients.SL_MESSAGE = SQLEx.Message;
                clsListedesclientss.Add(clsListedesclients);
            }

            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsListedesclientss;
        }


        public List<clsTransactiontontine> pvgListeDesVirementTontine(string DATEJOURNEE,  string AG_CODEAGENCE, string CL_CODECLIENT,  string CT_CODECARTE,  string DATEJOURNEE1, string DATEJOURNEE2, string ET_TYPEETAT, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK,  string LG_CODELANGUE, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTransactiontontine> clsListedesclientss = new List<clsTransactiontontine>();
            clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            clsTransactiontontine clsListedesclients = new clsTransactiontontine();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);
                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE1))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0030", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (string.IsNullOrEmpty(DATEJOURNEE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0031", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE1))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0032", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE2))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0033", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            if (DateTime.Parse(DATEJOURNEE1) > DateTime.Parse(DATEJOURNEE2))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0065", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }




            //if (clsChaineCaractere.ClasseChaineCaractere.isLetter(NOMBRELIGNE))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);

            //    return clsListedesclientss;
            //}




            //if (string.IsNullOrEmpty(NOMBRELIGNE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);
            //    return clsListedesclientss;
            //}




            //if (NOMBRELIGNE == "0")
            //{


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);
            //    return clsListedesclientss;
            //}




            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }



            if (string.IsNullOrEmpty(ET_TYPEETAT))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsListedesclientss.Add(clsListedesclients);

                return clsListedesclientss;
            }


            //if (ET_TYPEETAT != "04")
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
            //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsListedesclientss.Add(clsListedesclients);

            //    return clsListedesclientss;
            //}





            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsListedesclientss.Add(clsListedesclients);

                //    return clsListedesclientss;
                //}


                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsListedesclients.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsListedesclients.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsListedesclients.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsListedesclientss.Add(clsListedesclients);

                    return clsListedesclientss;
                }


                clsListedesclientss = clsTontinewebWSBLL.pvgListeDesVirementTontine(clsDonnee,  LG_CODELANGUE,  AG_CODEAGENCE,  CL_CODECLIENT,   CT_CODECARTE,   DATEJOURNEE1,  DATEJOURNEE2,  ET_TYPEETAT);


            }
            catch (SqlException SQLEx)
            {

                clsListedesclients.SL_RESULTAT = "FALSE";
                clsListedesclients.SL_MESSAGE = SQLEx.Message;
                clsListedesclientss.Add(clsListedesclients);
            }
            catch (Exception SQLEx)
            {

                clsListedesclients.SL_RESULTAT = "FALSE";
                clsListedesclients.SL_MESSAGE = SQLEx.Message;
                clsListedesclientss.Add(clsListedesclients);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsListedesclientss;
        }


        public List<clsReseau> pvgReseau(string DATEJOURNEE, string NOMBRELIGNE, string CL_ADRESSEGEOGRAPHIQUE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {

            bool vlpTest = false;
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsReseau> clsReseau = new List<clsReseau>();
            clsReseau clsReseau1 = new clsReseau();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();



            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //----EXEPTION
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsReseau.Add(clsReseau1);
                return clsReseau;

            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsReseau.Add(clsReseau1);
                return clsReseau;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsReseau.Add(clsReseau1);
                return clsReseau;
            }





            if (clsChaineCaractere.ClasseChaineCaractere.isLetter(NOMBRELIGNE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }




            if (string.IsNullOrEmpty(NOMBRELIGNE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }





            if (NOMBRELIGNE == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0007", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }




            if (string.IsNullOrEmpty(CL_ADRESSEGEOGRAPHIQUE))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0008", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }


            if (CL_ADRESSEGEOGRAPHIQUE.Length < 3)
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0009", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }





            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsReseau.Add(clsReseau1);

                return clsReseau;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "01");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsReseau.Add(clsReseau1);

                    return clsReseau;
                }


                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsReseau1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsReseau1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsReseau1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsReseau.Add(clsReseau1);

                    return clsReseau;
                }

                clsReseau = clsTontinewebWSBLL.pvgReseau(clsDonnee, int.Parse(NOMBRELIGNE), CL_ADRESSEGEOGRAPHIQUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION);


            }
            catch (SqlException SQLEx)
            {
                //clsReseau clsReseau = new BOJ.clsReseau();
                clsReseau1.SL_RESULTAT = "FALSE";
                clsReseau1.SL_MESSAGE = SQLEx.Message;
                clsReseau.Add(clsReseau1);

            }
            catch (Exception SQLEx)
            {
                //clsReseau clsReseau = new BOJ.clsReseau();
                clsReseau1.SL_RESULTAT = "FALSE";
                clsReseau1.SL_MESSAGE = SQLEx.Message;
                clsReseau.Add(clsReseau1);

            }
            finally
            {
                //if (vlpTest = false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReseau;
        }




        public List<clsPieceidentite> pvgChargerDansDataSetPourComboPieceidentite(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsPieceidentite> clsPieceidentite = new List<clsPieceidentite>();
            clsPieceidentite clsPieceidentite1 = new clsPieceidentite();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPieceidentite.Add(clsPieceidentite1);

                return clsPieceidentite;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPieceidentite.Add(clsPieceidentite1);

                return clsPieceidentite;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPieceidentite.Add(clsPieceidentite1);

                return clsPieceidentite;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPieceidentite.Add(clsPieceidentite1);

                return clsPieceidentite;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPieceidentite.Add(clsPieceidentite1);

                return clsPieceidentite;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPieceidentite.Add(clsPieceidentite1);

                return clsPieceidentite;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                ////----VERIFICATION DE LA CLE DE SESSION
                ////List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsPieceidentite.Add(clsPieceidentite1);

                //    return clsPieceidentite;
                //}
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsPieceidentite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsPieceidentite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsPieceidentite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsPieceidentite.Add(clsPieceidentite1);

                    return clsPieceidentite;
                }


                clsPieceidentite = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboPieceidentite(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsPieceidentite;
        }


        public List<clsTontinemise> pvgChargerDansDataSetPourComboMise(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontinemise> clsTontinemise = new List<clsTontinemise>();
            clsTontinemise clsTontinemise1 = new clsTontinemise();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinemise.Add(clsTontinemise1);

                return clsTontinemise;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinemise.Add(clsTontinemise1);

                return clsTontinemise;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinemise.Add(clsTontinemise1);

                return clsTontinemise;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinemise.Add(clsTontinemise1);

                return clsTontinemise;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinemise.Add(clsTontinemise1);

                return clsTontinemise;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontinemise.Add(clsTontinemise1);

                return clsTontinemise;
            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();



                ////----VERIFICATION DE LA CLE DE SESSION
                ////List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTontinemise.Add(clsTontinemise1);

                //    return clsTontinemise;
                //}
                //--

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "02");

                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsTontinemise1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsTontinemise1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsTontinemise1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsTontinemise.Add(clsTontinemise1);

                    return clsTontinemise;
                }

                clsTontinemise = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboMise(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontinemise;
        }

        //Envoi de mail
        public void sendmail(string pvgTitre, string vppMessage, string vppMailExpediteur, string vppMotDePasseExpediteur, string vppMailRecepteur, string vppCheminCompletFichierEnvoyer1, string vppCheminCompletFichierEnvoyer2, string vppCheminCompletFichierEnvoyer3)
        {
            try
            {
                ////-I-Préparation du fichier
                //ReportDocument cryRpt;

                ////string pdfFile = "c:\\csharp.net-informations.pdf";
                //string pdfFile = vppCheminCompletFichierPDFEnvoyer;
                //cryRpt = new ReportDocument();
                //string PATH = Application.StartupPath + "\\Etats\\" + vappFichier;
                //cryRpt.Load(PATH);
                //cryRpt.SetDataSource(vappTable.Tables[0]);
                //for (int Idx = 0; Idx < vappNomFormule.GetLength(0); Idx++)
                //{
                //    string vlpNomFormule = vappNomFormule[Idx].ToString();
                //    string vlpValeurFormule = vappValeurFormule[Idx].ToString();
                //    cryRpt.DataDefinition.FormulaFields[vlpNomFormule].Text = "'" + vlpValeurFormule.Replace("'", "''") + "'";

                //}

                //CrystalReportViewer crystalReportViewer1 = new CrystalReportViewer();
                //crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.Refresh();

                ////-II-Exportation du fichier
                //ExportOptions CrExportOptions;
                //DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                //PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                //CrDiskFileDestinationOptions.DiskFileName = pdfFile;
                //CrExportOptions = cryRpt.ExportOptions;
                //CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                //CrExportOptions.FormatOptions = CrFormatTypeOptions;
                //cryRpt.Export();

                //-III-Envoi du fichier par mail
                System.Net.Mail.MailMessage mm = null;
                //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false && clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailRecepteur) != false)
                mm = new System.Net.Mail.MailMessage(vppMailExpediteur, vppMailRecepteur);
                // Contenu du message
                if (mm != null)
                {
                    mm.Subject = pvgTitre;
                    mm.Body = vppMessage;
                }
                //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false && clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailRecepteur2) != false)
                //    mm.CC.Add(vppMailRecepteur2);

                //Ajoute des fichiers joints
                if (vppCheminCompletFichierEnvoyer1 != "")
                    mm.Attachments.Add(new Attachment(vppCheminCompletFichierEnvoyer1));
                if (vppCheminCompletFichierEnvoyer2 != "")
                    mm.Attachments.Add(new Attachment(vppCheminCompletFichierEnvoyer2));
                if (vppCheminCompletFichierEnvoyer3 != "")
                    mm.Attachments.Add(new Attachment(vppCheminCompletFichierEnvoyer3));

                // Sending message
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);

                if (vppMailExpediteur != null)
                {
                    // Le compte credentials
                    //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false)
                    sc.Credentials = new NetworkCredential(vppMailExpediteur, vppMotDePasseExpediteur, "");
                    sc.EnableSsl = true;

                    // Envoie du message
                    try
                    {
                        //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false)
                        sc.Send(mm);
                        // MessageBox.Show("Message sent");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error: " + ex.Message);
                    }
                }




                ////

                ////SmtpMail.SmtpServer.Insert(587,"smtp.gmail.com");
                ////System.Web.Mail.MailMessage Msg = new System.Web.Mail.MailMessage();
                ////Msg.To = "d.baz1008@gmail.com";
                ////Msg.From = "d.baz1008@gmail.com";
                ////Msg.Subject = "Crystal Report Attachment ";
                ////Msg.Body = "Crystal Report Attachment ";
                ////Msg.Attachments.Add(new MailAttachment(pdfFile));
                ////System.Web.Mail.SmtpMail.Send(Msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                //XtraMessageBox.Show("Impossible de se connecter a internet !!! ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<clsActivite> pvgChargerDansDataSetPourComboActivite(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsActivite> clsActivite = new List<clsActivite>();
            clsActivite clsActivite1 = new clsActivite();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();


            //JArray array = new JArray();
            //array.Add("Manual text");
            //array.Add(new DateTime(2000, 5, 23));

            //JObject o = new JObject();
            //o["MyArray"] = array;

            //string json = o.ToString();
            // {
            //   "MyArray": [
            //     "Manual text",
            //     "2000-05-23T00:00:00"
            //   ]
            // }



            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsActivite.Add(clsActivite1);

                //var json = JsonConvert.SerializeObject(clsActivite);

                //array.Add(clsActivite1.SL_CODEMESSAGE);
                //array.Add(clsActivite1.SL_RESULTAT);
                //array.Add(clsActivite1.SL_MESSAGE);

                //JObject o = new JObject();
                //o["MyArray"] = array;

                //string json = o.ToString();
                //var json = JsonConvert.SerializeObject(new
                //{
                //    operations = clsActivite
                //});


                return clsActivite;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsActivite.Add(clsActivite1);
                return clsActivite;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsActivite.Add(clsActivite1);

                //var json = JsonConvert.SerializeObject(clsActivite);

                //array.Add(clsActivite1.SL_CODEMESSAGE);
                //array.Add(clsActivite1.SL_RESULTAT);
                //array.Add(clsActivite1.SL_MESSAGE);

                //JObject o = new JObject();
                //o["MyArray"] = array;

                //string json = o.ToString();
                //var json = JsonConvert.SerializeObject(new
                //{
                //    operations = clsActivite
                //});


                return clsActivite;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsActivite.Add(clsActivite1);


                //var json = JsonConvert.SerializeObject(clsActivite);
                //array.Add(clsActivite1.SL_CODEMESSAGE);
                //array.Add(clsActivite1.SL_RESULTAT);
                //array.Add(clsActivite1.SL_MESSAGE);

                //JObject o = new JObject();
                //o["MyArray"] = array;

                //string json = o.ToString();


                //var json = JsonConvert.SerializeObject(new
                //{
                //    operations = clsActivite
                //});
                return clsActivite;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsActivite.Add(clsActivite1);

                //var json = JsonConvert.SerializeObject(clsActivite);

                //array.Add(clsActivite1.SL_CODEMESSAGE);
                //array.Add(clsActivite1.SL_RESULTAT);
                //array.Add(clsActivite1.SL_MESSAGE);

                //JObject o = new JObject();
                //o["MyArray"] = array;

                //string json = o.ToString();


                ////var json = JsonConvert.SerializeObject(new
                ////{
                ////    operations = clsActivite
                ////});
                return clsActivite;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsActivite.Add(clsActivite1);

                //array.Add(clsActivite1.SL_CODEMESSAGE);
                //array.Add(clsActivite1.SL_RESULTAT);
                //array.Add(clsActivite1.SL_MESSAGE);

                //JObject o = new JObject();
                //o["MyArray"] = array;

                //string json = o.ToString();


                //var json = JsonConvert.SerializeObject(clsActivite);


                //var json = JsonConvert.SerializeObject(new
                //{
                //    operations = clsActivite
                //});
                return clsActivite;
            }




            bool vlpTest = false;

            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");


                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsActivite1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsActivite1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsActivite1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsActivite.Add(clsActivite1);

                //    //var json = JsonConvert.SerializeObject(clsActivite);

                //    //array.Add(clsActivite1.SL_CODEMESSAGE);
                //    //array.Add(clsActivite1.SL_RESULTAT);
                //    //array.Add(clsActivite1.SL_MESSAGE);

                //    //JObject o = new JObject();
                //    //o["MyArray"] = array;

                //    //string json = o.ToString();


                //    //var json = JsonConvert.SerializeObject(new
                //    //{
                //    //    operations = clsActivite
                //    //});
                //    return clsActivite;
                //}
                //--


                clsActivite = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboActivite(clsDonnee, LG_CODELANGUE);

                //string json1 = JsonConvert.SerializeObject(clsActivite);
            }
            catch (SqlException SQLEx)
            {
                //clsActivite.SL_RESULTAT = "FALSE";
                //clsReseau1.SL_MESSAGE = SQLEx.Message;
                //clsReseau.Add(clsReseau1);

                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                //clsActivite.SL_RESULTAT = "FALSE";
                //clsReseau1.SL_MESSAGE = SQLEx.Message;
                //clsReseau.Add(clsReseau1);

                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                //if (vlpTest == false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            ////var json1 = JsonConvert.SerializeObject(new
            ////{
            ////    operations = clsActivite
            ////});
            //var RESULTA=JsonConvert.SerializeObject(clsActivite);
            return clsActivite;
        }

        public List<clsCommune> pvgChargerDansDataSetPourComboCommune(string DATEJOURNEE, string VL_CODEVILLE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsCommune> clsCommune = new List<clsCommune>();
            clsCommune clsCommune1 = new clsCommune();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            if (string.IsNullOrEmpty(VL_CODEVILLE)) VL_CODEVILLE = "";
            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsCommune.Add(clsCommune1);
                return clsCommune;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsCommune.Add(clsCommune1);
                return clsCommune;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsCommune.Add(clsCommune1);
                return clsCommune;
            }

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsCommune.Add(clsCommune1);

                return clsCommune;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsCommune.Add(clsCommune1);

                return clsCommune;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsCommune.Add(clsCommune1);

                return clsCommune;
            }

            //if (string.IsNullOrEmpty( VL_CODEVILLE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
            //    clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsCommune1.SL_MESSAGE = "La ville est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsCommune.Add(clsCommune1);

            //    return clsCommune;
            //}


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsCommune.Add(clsCommune1);

                //    return clsCommune;
                //}
                //--


                clsCommune = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboCommune(clsDonnee, LG_CODELANGUE, VL_CODEVILLE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsCommune;
        }

        public List<clsMiccommercial> pvgChargerDansDataSetPourComboCommercial(string DATEJOURNEE, string TYPEOPERATION,string CM_IDCOMMERCIAL, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccommercial> clsMiccommercial = new List<clsMiccommercial>();
            clsMiccommercial clsMiccommercial1 = new clsMiccommercial();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(TYPEOPERATION))
                TYPEOPERATION = "01";

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccommercial.Add(clsMiccommercial1);
                return clsMiccommercial;
            }

            if (TYPEOPERATION=="02" && string.IsNullOrEmpty(CM_IDCOMMERCIAL))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = "Le commercial à exclure doit être renseigné !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccommercial.Add(clsMiccommercial1);
                return clsMiccommercial;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccommercial.Add(clsMiccommercial1);
                return clsMiccommercial;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccommercial.Add(clsMiccommercial1);
                return clsMiccommercial;
            }

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccommercial.Add(clsMiccommercial1);

                return clsMiccommercial;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccommercial.Add(clsMiccommercial1);

                return clsMiccommercial;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsMiccommercial1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccommercial1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccommercial1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccommercial.Add(clsMiccommercial1);

                return clsMiccommercial;
            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsCommune1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsCommune1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsCommune1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsCommune.Add(clsCommune1);

                //    return clsCommune;
                //}
                //--


                clsMiccommercial = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboCommercial(clsDonnee, LG_CODELANGUE, TYPEOPERATION, CM_IDCOMMERCIAL);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccommercial;
        }



        public List<clsSituationmatrimoniale> pvgChargerDansDataSetPourComboSituationMatrimoniale(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsSituationmatrimoniale> clsSituationmatrimoniale = new List<clsSituationmatrimoniale>();
            clsSituationmatrimoniale clsSituationmatrimoniale1 = new clsSituationmatrimoniale();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,
            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                return clsSituationmatrimoniale;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                return clsSituationmatrimoniale;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                return clsSituationmatrimoniale;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                return clsSituationmatrimoniale;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                return clsSituationmatrimoniale;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                return clsSituationmatrimoniale;
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsSituationmatrimoniale1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsSituationmatrimoniale1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsSituationmatrimoniale1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsSituationmatrimoniale.Add(clsSituationmatrimoniale1);

                //    return clsSituationmatrimoniale;
                //}
                //--


                clsSituationmatrimoniale = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboSituationMatrimoniale(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsSituationmatrimoniale;
        }



        public List<clsPays> pvgChargerDansDataSetPourComboPays(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsPays> clsPays = new List<clsPays>();
            clsPays clsPays1 = new clsPays();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPays.Add(clsPays1);

                return clsPays;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPays.Add(clsPays1);

                return clsPays;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPays.Add(clsPays1);

                return clsPays;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPays.Add(clsPays1);

                return clsPays;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPays.Add(clsPays1);

                return clsPays;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsPays.Add(clsPays1);

                return clsPays;
            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsPays1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsPays1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsPays1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsPays.Add(clsPays1);

                //    return clsPays;
                //}
                //--


                clsPays = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboPays(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsPays;
        }




        public List<clsSexe> pvgChargerDansDataSetPourComboSexe(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsSexe> clsSexe = new List<clsSexe>();
            clsSexe clsSexe1 = new clsSexe();




            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSexe.Add(clsSexe1);

                return clsSexe;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSexe.Add(clsSexe1);

                return clsSexe;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSexe.Add(clsSexe1);

                return clsSexe;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSexe.Add(clsSexe1);

                return clsSexe;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSexe.Add(clsSexe1);

                return clsSexe;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsSexe.Add(clsSexe1);

                return clsSexe;

            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsSexe1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsSexe1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsSexe1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsSexe.Add(clsSexe1);

                //    return clsSexe;
                //}
                //--



                clsSexe = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboSexe(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsSexe;
        }


        public List<clsTontineCarte> pvgChargerDansDataSetPourComboCartes(string EJ_IDEPARGNANTJOURNALIER,  string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTontineCarte> clsTontineCarte = new List<clsTontineCarte>();
            clsTontineCarte clsTontineCarte1 = new clsTontineCarte();




            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;
            }
            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTontineCarte.Add(clsTontineCarte1);

                return clsTontineCarte;

            }


            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsTontineCarte1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTontineCarte1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTontineCarte1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTontineCarte.Add(clsTontineCarte1);

                //    return clsTontineCarte;
                //}
                //--



                clsTontineCarte = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboCartes(clsDonnee,  EJ_IDEPARGNANTJOURNALIER,  LG_CODELANGUE,  TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTontineCarte;
        }



        public List<clsVille> pvgChargerDansDataSetPourComboVille(string DATEJOURNEE,string PY_CODEPAYS, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsVille> clsVille = new List<clsVille>();
            clsVille clsVille1 = new clsVille();

            if (string.IsNullOrEmpty(PY_CODEPAYS)) PY_CODEPAYS = "";


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsVille.Add(clsVille1);

                return clsVille;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsVille.Add(clsVille1);

                return clsVille;
            }

            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsVille.Add(clsVille1);

                return clsVille;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsVille.Add(clsVille1);

                return clsVille;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsVille.Add(clsVille1);

                return clsVille;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsVille.Add(clsVille1);

                return clsVille;

            }

            //if (string.IsNullOrEmpty(PY_CODEPAYS))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
            //    clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsVille1.SL_MESSAGE = "Le pays est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsVille.Add(clsVille1);

            //    return clsVille;

            //}





            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsVille1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsVille.Add(clsVille1);

                //    return clsVille;
                //}
                //--


                clsVille = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboVille(clsDonnee, LG_CODELANGUE, PY_CODEPAYS);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsVille;
        }


        public List<clsMicpointvente> pvgChargerDansDataSetPourComboPointVente(string DATEJOURNEE,string AG_CODEAGENCE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMicpointvente> clsMicpointventes = new List<clsMicpointvente>();
            clsMicpointvente clsMicpointvente = new clsMicpointvente();



            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();



            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsMicpointvente.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMicpointvente.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMicpointvente.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMicpointventes.Add(clsMicpointvente);

                return clsMicpointventes;

            }

            //if (string.IsNullOrEmpty(PY_CODEPAYS))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
            //    clsVille1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsVille1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsVille1.SL_MESSAGE = "Le pays est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsVille.Add(clsVille1);

            //    return clsVille;

            //}





            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                DataSet DataSet = new DataSet();
                //clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE};
                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboPointVente(clsDonnee, AG_CODEAGENCE);
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        clsMicpointvente = new clsMicpointvente();
                        clsMicpointvente.PV_CODEPOINTVENTE = row["PV_CODEPOINTVENTE"].ToString();
                        clsMicpointvente.PV_RAISONSOCIAL = row["PV_RAISONSOCIAL"].ToString();
                        clsMicpointvente.SL_CODEMESSAGE = "00";
                        clsMicpointvente.SL_RESULTAT = "TRUE";
                        clsMicpointvente.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsMicpointventes.Add(clsMicpointvente);

                    }
                }
                else
                {
                    clsMicpointvente.SL_CODEMESSAGE = "00";
                    clsMicpointvente.SL_RESULTAT = "FALSE";
                    clsMicpointvente.SL_MESSAGE = "Aucun élément trouvé !!!";
                    clsMicpointventes.Add(clsMicpointvente);
                }





            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMicpointventes;
        }



        public List<clsProfession> pvgChargerDansDataSetPourComboProfession(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsProfession> clsProfession = new List<clsProfession>();
            clsProfession clsProfession1 = new clsProfession();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsProfession.Add(clsProfession1);

                return clsProfession;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsProfession.Add(clsProfession1);

                return clsProfession;
            }


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsProfession.Add(clsProfession1);

                return clsProfession;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsProfession.Add(clsProfession1);

                return clsProfession;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsProfession.Add(clsProfession1);

                return clsProfession;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsProfession.Add(clsProfession1);

                return clsProfession;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsProfession1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsProfession1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsProfession1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsProfession.Add(clsProfession1);

                //    return clsProfession;
                //}
                //--



                clsProfession = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboProfession(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsProfession;
        }



        public List<clsFormejuridique> pvgChargerDansDataSetPourComboFormjuridique(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsFormejuridique> clsFormejuridique = new List<clsFormejuridique>();
            clsFormejuridique clsFormejuridique1 = new clsFormejuridique();
            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsFormejuridique.Add(clsFormejuridique1);

                return clsFormejuridique;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsFormejuridique.Add(clsFormejuridique1);

                return clsFormejuridique;
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsFormejuridique.Add(clsFormejuridique1);

                return clsFormejuridique;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsFormejuridique.Add(clsFormejuridique1);

                return clsFormejuridique;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsFormejuridique.Add(clsFormejuridique1);

                return clsFormejuridique;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsFormejuridique.Add(clsFormejuridique1);

                return clsFormejuridique;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsFormejuridique1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsFormejuridique1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsFormejuridique1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsFormejuridique.Add(clsFormejuridique1);

                //    return clsFormejuridique;
                //}
                //--



                clsFormejuridique = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboFormjuridique(clsDonnee, LG_CODELANGUE);


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsFormejuridique;
        }




        public clsMiccomptewebResultat pvgComptabilisationImpression(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CT_CODECARTE, string DI_DATEIMPRESSION, string OP_CODEOPERATEUR, string LG_CODELANGUE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            List<clsMiccomptewebResultat> clsMiccomptewebUserLogin = new List<clsMiccomptewebResultat>();

            string TYPEOPERATION = "03";

            if (string.IsNullOrEmpty(DI_DATEIMPRESSION))
            {
                DI_DATEIMPRESSION = "01/01/1900";
            }



            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];

            }





            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le type opération est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(CT_CODECARTE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0157", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(CL_CODECLIENT))
            {
                CL_CODECLIENT = "0";
            }
            CL_CODECLIENT = string.Format("{0:00000000}", double.Parse(CL_CODECLIENT));

            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgComptabilisationImpression(clsDonnee, AG_CODEAGENCE, CL_CODECLIENT, CT_CODECARTE, DATEJOURNEE, DI_DATEIMPRESSION, OP_CODEOPERATEUR, LG_CODELANGUE, TYPEOPERATION);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }

        public clsMiccomptewebResultat pvgCreationCarteTontine(string LG_CODELANGUE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string EJ_IDEPARGNANTJOURNALIER, string DATEJOURNEE, string CM_IDCOMMERCIAL, string MI_VALEUR, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            List<clsMiccomptewebResultat> clsMiccomptewebUserLogin = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = "Le client est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];

            }


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgCreationCarteTontine(clsDonnee,  LG_CODELANGUE,  AG_CODEAGENCE,  OP_CODEOPERATEUR,  EJ_IDEPARGNANTJOURNALIER, DATEJOURNEE,  CM_IDCOMMERCIAL, MI_VALEUR,  TYPEOPERATION);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }



        public clsMiccomptewebResultat pvgCreationCarteTontineDiffere(List<clsParametreCartediffere> Objet)
        {
            clsMiccomptewebResultat clsMiccomptewebmotpasseoublieListe = new clsMiccomptewebResultat();
            foreach (clsParametreCartediffere clsParametreCartediffereDTO in Objet)
            {
                clsDonnee = new clsDonnee();
                clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsMiccomptewebmotpasseoublieListe = pvgCreationCarteTontineBis(clsParametreCartediffereDTO.LG_CODELANGUE, clsParametreCartediffereDTO.AG_CODEAGENCE, clsParametreCartediffereDTO.OP_CODEOPERATEUR, clsParametreCartediffereDTO.EJ_IDEPARGNANTJOURNALIER, clsParametreCartediffereDTO.DATEJOURNEE, clsParametreCartediffereDTO.CM_IDCOMMERCIAL, clsParametreCartediffereDTO.MI_VALEUR, clsParametreCartediffereDTO.SL_LOGIN, clsParametreCartediffereDTO.SL_MOTPASSE, clsParametreCartediffereDTO.OS_MACADRESSE, clsParametreCartediffereDTO.TYPEOPERATION, clsDonnee, clsObjetEnvoi);
            }
            return clsMiccomptewebmotpasseoublieListe;


        }


        public clsMiccomptewebResultat pvgCreationCarteTontineBis(string LG_CODELANGUE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string EJ_IDEPARGNANTJOURNALIER, string DATEJOURNEE, string CM_IDCOMMERCIAL, string MI_VALEUR, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION, clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            //clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            List<clsMiccomptewebResultat> clsMiccomptewebUserLogin = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = "Le client est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];

            }


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgCreationCarteTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, OP_CODEOPERATEUR, EJ_IDEPARGNANTJOURNALIER, DATEJOURNEE, CM_IDCOMMERCIAL, MI_VALEUR, TYPEOPERATION);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }


        public clsMiccomptewebResultat pvgTransfertPortefeuilleClientTontine(string LG_CODELANGUE, string AG_CODEAGENCE, string CM_IDCOMMERCIALINITIAL, string CM_IDCOMMERCIALFINAL, string OP_CODEOPERATEUR, string DATEJOURNEE, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            List<clsMiccomptewebResultat> clsMiccomptewebUserLogin = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(CM_IDCOMMERCIALINITIAL))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = "Le commercial initial est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(CM_IDCOMMERCIALFINAL))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = "Le commercial final est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];

            }


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgTransfertPortefeuilleClientTontine(clsDonnee,  LG_CODELANGUE,  AG_CODEAGENCE,  CM_IDCOMMERCIALINITIAL,  CM_IDCOMMERCIALFINAL,  OP_CODEOPERATEUR,  DATEJOURNEE,  TYPEOPERATION);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }

        public clsMiccomptewebResultat pvgActivationDesactivationClientTontine(string LG_CODELANGUE, string AG_CODEAGENCE, string EJ_IDEPARGNANTJOURNALIER, string OP_CODEOPERATEUR, string DATEJOURNEE, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION)
            {
                clsObjetRetour clsObjetRetour = new clsObjetRetour();
                List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                bool vlpTest = false;
                clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


                List<clsMiccomptewebResultat> clsMiccomptewebUserLogin = new List<clsMiccomptewebResultat>();

                if (string.IsNullOrEmpty(AG_CODEAGENCE))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }

                if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = "Le client est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }

                if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = "L'opérateur est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }               


                if (string.IsNullOrEmpty(DATEJOURNEE))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }

                if (!WEB.WSTOOLS.clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
                {

                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }


                clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsObjetEnvoi.OE_A = AG_CODEAGENCE;
                clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
                if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];

                }


                if (string.IsNullOrEmpty(LG_CODELANGUE))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }


                if (string.IsNullOrEmpty(OS_MACADRESSE))
                {

                    //----EXEPTION
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }


                if (string.IsNullOrEmpty(SL_LOGIN))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                    //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                    //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }


                if (string.IsNullOrEmpty(SL_MOTPASSE))
                {
                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();

                    //----EXEPTION
                    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                    clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                    //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                    //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le mot de passe est obligatoire !!!";

                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                    return clsMiccomptewebUserLogin[0];
                }


                try
                {
                    //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                    //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                    //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                    clsDonnee.pvgDemarrerTransaction();
                    clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgActivationDesactivationClientTontine(clsDonnee,  LG_CODELANGUE,  AG_CODEAGENCE,  EJ_IDEPARGNANTJOURNALIER,  OP_CODEOPERATEUR,  DATEJOURNEE,  TYPEOPERATION);
                }
                catch (SqlException SQLEx)
                {

                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                    clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                    clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                    vlpTest = true;
                }
                catch (Exception SQLEx)
                {

                    clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                    clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                    clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                    clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                    vlpTest = true;
                }
                finally
                {
                    //if (vlpTest==false)
                    clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
                }
                return clsMiccomptewebUserLogin[0];
            }



        public clsHttoken pvgDemandeToken(string LG_CODELANGUE, string AG_CODEAGENCE, string TK_TOKEN,string TK_CODETYPEOPERATION, string EJ_IDEPARGNANTJOURNALIER, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsHttoken clsHttoken = new clsHttoken();

            //clsNumeroMobileMappe clsNumeroMobileMappe = new clsNumeroMobileMappe();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }
            if (string.IsNullOrEmpty(TK_CODETYPEOPERATION))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = "Le type opération n'est pas correct !!!";//clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }

            if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = "Le client est obligatoire !!!";//clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }






            //if (TYPEOPERATION != "0" && TYPEOPERATION != "1")
            //{

            //    clsHttoken.SL_RESULTAT = "FALSE";
            //    clsHttoken.SL_MESSAGE = "Le type opération n'est pas correct !!!";
            //    clsHttoken.SL_CODEMESSAGE = "00";
            //    return clsHttoken;
            //}


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsHttoken;
            }






            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsHttoken.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    return clsHttoken;
                }


                clsHttoken = clsTontinewebWSBLL.pvgDemandeToken(clsDonnee, AG_CODEAGENCE, TK_TOKEN,  TK_CODETYPEOPERATION,  EJ_IDEPARGNANTJOURNALIER, TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsHttoken.SL_RESULTAT = "FALSE";
                clsHttoken.SL_MESSAGE = SQLEx.Message;
            }
            catch (Exception SQLEx)
            {
                clsHttoken.SL_RESULTAT = "FALSE";
                clsHttoken.SL_MESSAGE = SQLEx.Message;
            }
            finally
            {
                if (clsHttoken.SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsHttoken;
        }

        public clsMiccomptewebResultat pvgCreationDetailFacture(string DATEJOURNEE, string AG_CODEAGENCE, string NO_CODENATUREVIREMENT, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE, string MI_CODEMISE, string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string MC_NOMTIERS, string PI_CODEPIECE, string MC_NUMPIECETIERS, string MONTANT, string SM_TELEPHONE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string TYPEOPERATION, string SIGNATURE,  string TO_VALIDEROPERATIONENCOURS,  string DT_NUMEROTRANSACTION,string TK_TOKEN,string SO_CODESOUSCRIPTION, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsMiccomptewebResultat clsMiccomptewebResultat = new clsMiccomptewebResultat();

            if (string.IsNullOrEmpty(TO_VALIDEROPERATIONENCOURS)) TO_VALIDEROPERATIONENCOURS = "N";

            string DT_REFERENCE=".";
            string DT_DESIGNATION=".";
            string DT_QUANTITE="1";
            string DT_PU= MONTANT;
            string DT_TOTALARTICLE= MONTANT;
            string DT_TOTALFACTURE= MONTANT;
            string PY_CODESTATUT="01";
            string DT_DATEVALIDATION = "01/01/1900";
            //string NO_CODENATUREVIREMENT = TE_CODESMSTYPEOPERATION;
            string DT_NOMTIERS = MC_NOMTIERS;
           string DT_NUMPIECETIERS = MC_NUMPIECETIERS;


            string DT_NUMEROFACTURE = "";
            if(TYPEOPERATION=="0" || TYPEOPERATION == "5")
            DT_NUMEROTRANSACTION = System.Guid.NewGuid().ToString();

            //clsNumeroMobileMappe clsNumeroMobileMappe = new clsNumeroMobileMappe();

            List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }
            //if (string.IsNullOrEmpty(TK_CODETYPEOPERATION))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsHttoken.SL_RESULTAT = "Le type opération n'est pas correct !!!";//clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    return clsHttoken;
            //}
            
            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }
            if (string.IsNullOrEmpty(EJ_CODEEPARGNANTJOURNALIER) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = "Le client est obligatoire !!!";//clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }







            //if (TYPEOPERATION != "0" && TYPEOPERATION != "1")
            //{

            //    clsHttoken.SL_RESULTAT = "FALSE";
            //    clsHttoken.SL_MESSAGE = "Le type opération n'est pas correct !!!";
            //    clsHttoken.SL_CODEMESSAGE = "00";
            //    return clsHttoken;
            //}


            if (string.IsNullOrEmpty(DT_NUMEROTRANSACTION) && (TYPEOPERATION == "3" ||  TYPEOPERATION == "4"  ||  TYPEOPERATION == "6" ))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le code de la transaction est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(TK_TOKEN) && ( TYPEOPERATION == "3" || TYPEOPERATION == "6"))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le code de validation est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }



            if (string.IsNullOrEmpty(SO_CODESOUSCRIPTION) && (TYPEOPERATION == "5" || TYPEOPERATION == "6"))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le code de souscription est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(SM_TELEPHONE) && (TYPEOPERATION == "0" || TYPEOPERATION=="5"  || TYPEOPERATION=="6"  ))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le numéro de téléphone est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }
            //if (string.IsNullOrEmpty(PI_CODEPIECE) && ( TYPEOPERATION=="5"))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "La pièce est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(MC_NUMPIECETIERS) && ( TYPEOPERATION=="5"))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "Le numéro de pièce est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}
            //if (string.IsNullOrEmpty(SL_LOGIN))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(SL_CLESESSION))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}






            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultats[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                    return clsMiccomptewebResultat;
                }



                //----VERIFICATION DE TOKEN
                if((TYPEOPERATION == "3" || TYPEOPERATION == "6"))
                {
                    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgValidationdeTOKEN(clsDonnee, LG_CODELANGUE, DT_NUMEROTRANSACTION, TK_TOKEN, "01");
                    if (clsMiccomptewebResultats[0].SL_RESULTAT == "FALSE")
                    {
                        clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                        clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                        clsMiccomptewebResultat.SL_MESSAGE = "Le code de validation n'est pas correct !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                        return clsMiccomptewebResultat;
                    }
                }
                





                if (TYPEOPERATION=="3" || TYPEOPERATION=="4")
                {
                    DataSet DataSet = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                    DataSet=clsTontinewebWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATIONTONTINE(clsDonnee, clsObjetEnvoi);


                    if(DataSet.Tables[0].Rows.Count==0)
                    {
                        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                        clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                        return clsMiccomptewebResultat;
                    }

                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
                        //AG_CODEAGENCE= row["AC_CODEACTIVITE"].ToString();
                        string    TE_CODESMSTYPEOPERATION = NO_CODENATUREVIREMENT;
                        //EJ_CODEEPARGNANTJOURNALIER = row["AC_CODEACTIVITE"].ToString();
                        //CT_CODECARTE = row["CT_CODECARTE"].ToString();
                        MI_CODEMISE = row["MI_CODEMISE"].ToString();
                        STICKER = "";
                        ST_STICKERCODE1 = "";
                        ST_STICKERCODE2 = "";
                        MC_NOMTIERS = row["DT_NOMTIERS"].ToString();
                        PI_CODEPIECE = row["PI_CODEPIECE"].ToString();
                        MC_NUMPIECETIERS = row["DT_NUMPIECETIERS"].ToString();
                        MONTANT =double.Parse( row["DT_PU"].ToString()).ToString();
                        if (TYPEOPERATION == "4")
                            CT_CODECARTE = row["CT_CODECARTE"].ToString();
                        OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        //SM_TELEPHONE = row["AC_CODEACTIVITE"].ToString();
                        //DATEJOURNEE, 
                        //OP_CODEOPERATEUR


                       clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2, MC_NOMTIERS, PI_CODEPIECE, MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR,  SIGNATURE, TYPEOPERATION);
                        foreach (clsResultatOperation1 clsResultatOperation1 in clsResultatOperationListe)
                        {


                            if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && clsResultatOperationListe[0].ENVOISMS == "1")
                            {
                                if (clsResultatOperationListe[0].CL_TELEPHONE != "")
                                {

                                    clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                    clsParams clsParams = new clsParams();
                                    TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                                    clsResultatOperationListe[0].SL_LIBELLE1 = "C";
                                    clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatOperationListe[0].PV_CODEPOINTVENTE, clsResultatOperationListe[0].CO_CODECOMPTE, clsResultatOperationListe[0].OB_NOMOBJET, clsResultatOperationListe[0].CL_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsResultatOperationListe[0].MC_DATEPIECE), "", clsResultatOperationListe[0].CL_IDCLIENT, "", clsResultatOperationListe[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", clsResultatOperationListe[0].SL_LIBELLE1, clsResultatOperationListe[0].SL_LIBELLE2);

                                    clsResultatOperationListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                                    clsResultatOperationListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                                    if (clsParams.SL_RESULTAT == "FALSE") clsResultatOperationListe[0].SL_MESSAGE = clsResultatOperationListe[0].SL_MESSAGE + " " + clsResultatOperationListe[0].SL_MESSAGEAPI;




                                }


                                if (clsResultatOperationListe[0].EJ_EMAIL != "")
                                {

                                    string pvgTitre = clsResultatOperationListe[0].SL_MESSAGEOBJET;
                                    string vppMessage = clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                                    string vppMailExpediteur = clsResultatOperationListe[0].AG_EMAIL;
                                    string vppMotDePasseExpediteur = clsResultatOperationListe[0].AG_EMAILMOTDEPASSE;
                                    string vppMailRecepteur = clsResultatOperationListe[0].EJ_EMAIL;
                                    string vppCheminCompletFichierEnvoyer1 = "";
                                    string vppCheminCompletFichierEnvoyer2 = "";
                                    string vppCheminCompletFichierEnvoyer3 = "";

                                    sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                                }

                            }




                            if (clsResultatOperation1.SL_RESULTAT == "TRUE")
                            {
                                clsMobiledetailoperationtontine clsMobiledetailoperationtontine = new clsMobiledetailoperationtontine();
                                clsMobiledetailoperationtontine.AG_CODEAGENCE = AG_CODEAGENCE;
                                clsMobiledetailoperationtontine.DT_DATEVALIDATION = DATEJOURNEE;
                                string[]  vppCritere = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                                clsTontinewebWSBLL.pvgUpdateStatutOperation( clsDonnee,  clsMobiledetailoperationtontine,  vppCritere);

                                clsResultatOperation1.clsReeditions = clsResultatOperationListe[0].clsReeditions;
                            }

                            clsMiccomptewebResultat.clsReeditions = clsResultatOperation1.clsReeditions;
                            clsMiccomptewebResultat.SL_CODEMESSAGE = clsResultatOperation1.SL_CODEMESSAGE;
                            clsMiccomptewebResultat.SL_RESULTAT = clsResultatOperation1.SL_RESULTAT;   
                            clsMiccomptewebResultat.SL_MESSAGE = clsResultatOperation1.SL_MESSAGE;                             

                        }
                        
                    }
                }
                else
                    
                    if (TYPEOPERATION == "6")//====================Début Transfert carte vars mobile
                    {
                    DataSet DataSet = new DataSet();
                    DataSet DataSet1 = new DataSet();
                    String URLNOT = "";
                    String SO_TELEPHONE = "";
                    String PY_CODEPOSTALE = "";
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                    DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATIONTONTINE(clsDonnee, clsObjetEnvoi);

                   


                    if (DataSet.Tables[0].Rows.Count == 0)
                    {
                        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                        clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                        return clsMiccomptewebResultat;
                    }

                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
                        //AG_CODEAGENCE= row["AC_CODEACTIVITE"].ToString();
                        string TE_CODESMSTYPEOPERATION = NO_CODENATUREVIREMENT;
                        //EJ_CODEEPARGNANTJOURNALIER = row["AC_CODEACTIVITE"].ToString();
                        //CT_CODECARTE = row["CT_CODECARTE"].ToString();
                        MI_CODEMISE = row["MI_CODEMISE"].ToString();
                        STICKER = "";
                        ST_STICKERCODE1 = "";
                        ST_STICKERCODE2 = "";
                        MC_NOMTIERS = row["DT_NOMTIERS"].ToString();
                        PI_CODEPIECE = row["PI_CODEPIECE"].ToString();
                        MC_NUMPIECETIERS = row["DT_NUMPIECETIERS"].ToString();
                        MONTANT = double.Parse(row["DT_PU"].ToString()).ToString();

                    }


                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, SO_CODESOUSCRIPTION };
                    DataSet1 = clsTontinewebWSBLL.pvgChargerDansDataSetMOBILEDETAILSOUSCRIPTIONOPERATIONTONTINE(clsDonnee, clsObjetEnvoi);

                    foreach (DataRow row in DataSet1.Tables[0].Rows)
                    {
                        SO_TELEPHONE = row["SO_TELEPHONE"].ToString();
                        PY_CODEPOSTALE = row["PY_CODEPOSTALE"].ToString();
                    }


                    //--===================================================debut cinet
                    List<clsCinetpay> clsCinetpays = new List<clsCinetpay>();
                        clsCinetpaytoken clsCinetpaytoken = new clsCinetpaytoken();

                        clsParametre clsParametre = new clsParametre();
                        clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                        clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                        string[] stringArray = { "CIT_K" };
                        clsObjetEnvoi1.OE_PARAM = stringArray;
                        clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                        clsCinetpaytoken.Apikey = clsParametre.PP_VALEUR;// clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";

                        clsParametre = new clsParametre();
                        clsParametreWSBLL = new clsParametreWSBLL();
                        clsObjetEnvoi1 = new clsObjetEnvoi();
                        string[] stringArray1 = { "CIT_P" };
                        clsObjetEnvoi1.OE_PARAM = stringArray1;
                        clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                        clsCinetpaytoken.Password = clsParametre.PP_VALEUR;//"@merveille241";

                        clsParametre = new clsParametre();
                        clsParametreWSBLL = new clsParametreWSBLL();
                        clsObjetEnvoi1 = new clsObjetEnvoi();
                        string[] stringArray2 = { "URLNO" };
                        clsObjetEnvoi1.OE_PARAM = stringArray2;
                        clsParametre = clsParametreWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi1);
                        URLNOT = clsParametre.PP_VALEUR;//;


                    if (!CheckForInternetConnection())
                        {

                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "La connexion internet n'est pas disponible !!!";
                            try
                            {
                                throw new Exception("La connexion internet n'est pas disponible !!!");
                            }
                            catch { return clsMiccomptewebResultat; }
                            //

                        }
                        else
                        {
                            clsCinetpays = pvgDemendetoken(clsCinetpaytoken);
                        }


                        if (clsCinetpays.Count == 0)
                        {

                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "La demande de token a échoué !!!";
                            try
                            {
                                throw new Exception("Test Exception");
                            }
                            catch { return clsMiccomptewebResultat; }
                            //return clsResultatMobileTransactionMobileBankings[0];

                        }


                        //--
                        List<clsCinetpayMoneyContac> ListclsCinetpayMoneyContac = new List<clsCinetpayMoneyContac>();
                        clsCinetpayMoneyContac clsCinetpayMoneyContac = new clsCinetpayMoneyContac();
                        List<clsDataTransferts> clsDataTransferts = new List<clsDataTransferts>();
                        clsDataToken clsDataTokens = new clsDataToken();
                        clsDataTokens = clsCinetpays[0].data;

                        //private string _SL_TELEPHONE = "";
                        //private string _SL_INDICATIF = "";
                        //private string _SL_MONTANTOPERATION = "";
                        //private string _SL_URLNOTIFICATION = "";

                        //--part client
                        clsCinetpayMoneyContac = new clsCinetpayMoneyContac();

                        clsCinetpayMoneyContac.prefix = PY_CODEPOSTALE;// clsMiccomptewebResultat.SL_INDICATIF;
                                                                 //if (SM_TELEPHONE.Length > 10)
                                                                 //    clsCinetpayMoneyContac.phone = clsMiccomptewebResultat.SM_TELEPHONE.Substring(3, 8);
                                                                 //else
                        clsCinetpayMoneyContac.phone = SO_TELEPHONE;// clsMiccomptewebResultat.SL_TELEPHONE;
                                                                    //clsCinetpayMoneyContac.phone = "47839553";// clsCinetpayMoneyContac.phone = "47839553";
                                                                    //"47839553";//
                        clsCinetpayMoneyContac.amount = MONTANT;// clsMiccomptewebResultat.SL_MONTANTOPERATION.ToString();
                        clsCinetpayMoneyContac.client_transaction_id = DT_NUMEROTRANSACTION;
                        clsCinetpayMoneyContac.notify_url = URLNOT;// clsMiccomptewebResultat.SL_URLNOTIFICATION;
                        ListclsCinetpayMoneyContac.Add(clsCinetpayMoneyContac);

                        if (!CheckForInternetConnection())
                        {

                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "La connexion internet n'est pas disponible !!!";



                            try
                            {
                                throw new Exception("La connexion internet n'est pas disponible !!!");
                            }
                            catch
                            { return clsMiccomptewebResultat; }


                        }



                        //==============================================================transfert carte vers mobile

                        clsDataTransferts = pvgAddTransfert(ListclsCinetpayMoneyContac, clsDataTokens);

                        if (clsDataTransferts.Count == 0)
                        {

                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "Echec du service de transfert (00) !!!";
                            try
                            {
                                throw new Exception("Echec du service de transfert (00) !!!");
                            }
                            catch { return clsMiccomptewebResultat; }
                        }


                        if (clsDataTransferts[0].message == "OPERATION_SUCCES")
                        {


                            if (TYPEOPERATION == "6")
                            {
                                DataSet = new DataSet();
                                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATIONTONTINE(clsDonnee, clsObjetEnvoi);


                                if (DataSet.Tables[0].Rows.Count == 0)
                                {
                                    clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                                    clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                                    clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                                    return clsMiccomptewebResultat;
                                }

                                foreach (DataRow row in DataSet.Tables[0].Rows)
                                {
                                    List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
                                    //AG_CODEAGENCE= row["AC_CODEACTIVITE"].ToString();
                                    string TE_CODESMSTYPEOPERATION = NO_CODENATUREVIREMENT;
                                    //EJ_CODEEPARGNANTJOURNALIER = row["AC_CODEACTIVITE"].ToString();
                                    //CT_CODECARTE = row["CT_CODECARTE"].ToString();
                                    MI_CODEMISE = row["MI_CODEMISE"].ToString();
                                    STICKER = "";
                                    ST_STICKERCODE1 = "";
                                    ST_STICKERCODE2 = "";
                                    MC_NOMTIERS = row["DT_NOMTIERS"].ToString();
                                    PI_CODEPIECE = row["PI_CODEPIECE"].ToString();
                                    MC_NUMPIECETIERS = row["DT_NUMPIECETIERS"].ToString();
                                    MONTANT = double.Parse(row["DT_PU"].ToString()).ToString();
                                    OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString().ToString();
                                    //SM_TELEPHONE = row["AC_CODEACTIVITE"].ToString();
                                    //DATEJOURNEE, 
                                    //OP_CODEOPERATEUR


                                    clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2, MC_NOMTIERS, PI_CODEPIECE, MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR, SIGNATURE, TYPEOPERATION);
                                    foreach (clsResultatOperation1 clsResultatOperation1 in clsResultatOperationListe)
                                    {

                                        if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && clsResultatOperationListe[0].ENVOISMS == "1")
                                        {
                                            if (clsResultatOperationListe[0].CL_TELEPHONE != "")
                                            {

                                                clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                                clsParams clsParams = new clsParams();
                                                TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                                                clsResultatOperationListe[0].SL_LIBELLE1 = "C";
                                                clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatOperationListe[0].PV_CODEPOINTVENTE, clsResultatOperationListe[0].CO_CODECOMPTE, clsResultatOperationListe[0].OB_NOMOBJET, clsResultatOperationListe[0].CL_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsResultatOperationListe[0].MC_DATEPIECE), "", clsResultatOperationListe[0].CL_IDCLIENT, "", clsResultatOperationListe[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", clsResultatOperationListe[0].SL_LIBELLE1, clsResultatOperationListe[0].SL_LIBELLE2);

                                                clsResultatOperationListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                                                clsResultatOperationListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                                                if (clsParams.SL_RESULTAT == "FALSE") clsResultatOperationListe[0].SL_MESSAGE = clsResultatOperationListe[0].SL_MESSAGE + " " + clsResultatOperationListe[0].SL_MESSAGEAPI;




                                            }


                                            if (clsResultatOperationListe[0].EJ_EMAIL != "")
                                            {

                                                string pvgTitre = clsResultatOperationListe[0].SL_MESSAGEOBJET;
                                                string vppMessage = clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                                                string vppMailExpediteur = clsResultatOperationListe[0].AG_EMAIL;
                                                string vppMotDePasseExpediteur = clsResultatOperationListe[0].AG_EMAILMOTDEPASSE;
                                                string vppMailRecepteur = clsResultatOperationListe[0].EJ_EMAIL;
                                                string vppCheminCompletFichierEnvoyer1 = "";
                                                string vppCheminCompletFichierEnvoyer2 = "";
                                                string vppCheminCompletFichierEnvoyer3 = "";

                                                sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                                            }

                                        }





                                        if (clsResultatOperation1.SL_RESULTAT == "TRUE")
                                        {
                                            clsMobiledetailoperationtontine clsMobiledetailoperationtontine = new clsMobiledetailoperationtontine();
                                            clsMobiledetailoperationtontine.AG_CODEAGENCE = AG_CODEAGENCE;
                                            clsMobiledetailoperationtontine.DT_DATEVALIDATION = DATEJOURNEE;
                                            string[] vppCritere = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                                            clsTontinewebWSBLL.pvgUpdateStatutOperation(clsDonnee, clsMobiledetailoperationtontine, vppCritere);


                                        }

                                        clsMiccomptewebResultat.SL_CODEMESSAGE = clsResultatOperation1.SL_CODEMESSAGE;
                                        clsMiccomptewebResultat.SL_RESULTAT = clsResultatOperation1.SL_RESULTAT;
                                        clsMiccomptewebResultat.SL_MESSAGE = clsResultatOperation1.SL_MESSAGE;

                                    }

                                }
                            }



                            //if (clsResultatMobileTransactionMobileBankings[0].ENVOISMS == "1")
                            //{


                            //if (clsResultatMobileTransactionMobileBankings[0].SL_RESULTAT == "TRUE")
                            //{
                            //    if (clsResultatMobileTransactionMobileBankings[0].CL_TELEPHONE != "")
                            //    {
                            //        //SendMessage(clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "225", CL_TELEPHONE, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, clsMiccomptewebmotpasseoublieListe[0].RP_NUMSEQUENCE, "OK");

                            //        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();


                            //        //0025    NULL SMS OPERATION MOBILE VERS COMPTE BANCAIRE C   O
                            //        //0026    NULL SMS OPERATION COMPTE BANCAIRE VERS MOBILE C   O
                            //        //0027    NULL SMS OPERATION CARTE BANCAIRE VERS COMPTE BANCAIRE   C O
                            //        //0028    NULL SMS OPERATION COMPTE BANCAIRE VERS CARTE BANCAIRE   C O


                            //        //if (clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE.Length == 8)
                            //        //    clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE ="00225"+clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE;
                            //        string TE_CODESMSTYPEOPERATION1 = "";
                            //        if (NO_CODENATUREVIREMENT == "0011")
                            //        {// SMS OPERATION MOBILE VERS COMPTE BANCAIRE
                            //            clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE1 = "C";
                            //            TE_CODESMSTYPEOPERATION1 = "0025";
                            //        }

                            //        if (NO_CODENATUREVIREMENT == "0012")
                            //        {// SMS OPERATION COMPTE BANCAIRE VERS MOBILE
                            //            clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE1 = "D";
                            //            TE_CODESMSTYPEOPERATION1 = "0026";
                            //        }


                            //        clsParams clsParams = new clsParams();
                            //        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatMobileTransactionMobileBankings[0].PV_CODEPOINTVENTE, CO_CODECOMPTE, clsResultatMobileTransactionMobileBankings[0].OB_NOMOBJET, clsResultatMobileTransactionMobileBankings[0].CL_TELEPHONE, clsResultatMobileTransactionMobileBankings[0].OP_CODEOPERATEUR, DateTime.Parse(clsResultatMobileTransactionMobileBankings[0].TW_DATESAISIE), "", CL_IDCLIENT, "", clsResultatMobileTransactionMobileBankings[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION1, "0", "01/01/1900", "0", "0", "N", "0", clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE1, clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE2);
                            //        clsResultatMobileTransactionMobileBankings[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                            //        clsResultatMobileTransactionMobileBankings[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                            //        if (clsParams.SL_RESULTAT == "FALSE") clsResultatMobileTransactionMobileBankings[0].SL_MESSAGE = clsResultatMobileTransactionMobileBankings[0].SL_MESSAGE + " " + clsResultatMobileTransactionMobileBankings[0].SL_MESSAGEAPI;

                            //    }

                            //}

                        }
                        else
                        {
                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "La connexion internet n'est pas disponible (00) !!!";
                            try
                            {
                                throw new Exception("Le service n'est pas disponible (00) !!!");
                            }
                            catch { return clsMiccomptewebResultat; }


                        }




                        //==================




                        //------------======================================================fin cinet
                    }//====================Fin Transfert carte vars mobile
                else
                {

                    string TK_CODETYPEOPERATION = "01";
                    string EJ_IDEPARGNANTJOURNALIER = "";
                    string EJ_TELEPHONE = "";
                    string EJ_EMAIL = "";
                    EJ_CODEEPARGNANTJOURNALIER = string.Format("{0:00000000}", double.Parse(EJ_CODEEPARGNANTJOURNALIER));
                    DataSet DataSet = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, EJ_CODEEPARGNANTJOURNALIER };
                    DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetEPARGNANTJOURNALIER(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        EJ_IDEPARGNANTJOURNALIER = row["EJ_IDEPARGNANTJOURNALIER"].ToString();
                        EJ_TELEPHONE = row["EJ_TELEPHONE"].ToString();
                        EJ_EMAIL = row["EJ_EMAIL"].ToString();

                        if(string.IsNullOrEmpty(PI_CODEPIECE) )
                            PI_CODEPIECE= row["PI_CODEPIECE"].ToString();
                        if(string.IsNullOrEmpty(DT_NUMPIECETIERS) )
                            DT_NUMPIECETIERS = row["EJ_NUMPIECE"].ToString();

                    }
                    clsHttoken clsHttoken = new clsHttoken();
                    clsHttoken = clsTontinewebWSBLL.pvgDemandeToken(clsDonnee, AG_CODEAGENCE, TK_TOKEN, TK_CODETYPEOPERATION, EJ_IDEPARGNANTJOURNALIER, "0");


                    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgCreationDetailFacture(clsDonnee, AG_CODEAGENCE, DT_NUMEROTRANSACTION, DT_NUMEROFACTURE, DT_REFERENCE, DT_DESIGNATION, DT_QUANTITE, DT_PU, DT_TOTALARTICLE, DT_TOTALFACTURE, PY_CODESTATUT, EJ_CODEEPARGNANTJOURNALIER, NO_CODENATUREVIREMENT, DT_DATEVALIDATION, PI_CODEPIECE, MI_CODEMISE, CT_CODECARTE, DT_NOMTIERS, DT_NUMPIECETIERS, SO_CODESOUSCRIPTION, clsHttoken.TK_TOKEN, OP_CODEOPERATEUR, TYPEOPERATION);
                    if (clsMiccomptewebResultat.SL_RESULTAT == "TRUE")
                    {
                       
                       

                        if (clsHttoken.SL_RESULTAT == "TRUE")
                        {


                            //if (TYPEOPERATION == "5")//====================Début Transfert carte vars mobile
                            //{
                            //    //--===================================================debut cinet
                            //    List<clsCinetpay> clsCinetpays = new List<clsCinetpay>();
                            //    clsCinetpaytoken clsCinetpaytoken = new clsCinetpaytoken();

                            //    clsParametre clsParametre = new clsParametre();
                            //    clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                            //    clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                            //    string[] stringArray = { "CIT_K" };
                            //    clsObjetEnvoi1.OE_PARAM = stringArray;
                            //    clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                            //    clsCinetpaytoken.Apikey = clsParametre.PP_VALEUR;// clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";

                            //    clsParametre = new clsParametre();
                            //    clsParametreWSBLL = new clsParametreWSBLL();
                            //    clsObjetEnvoi1 = new clsObjetEnvoi();
                            //    string[] stringArray1 = { "CIT_P" };
                            //    clsObjetEnvoi1.OE_PARAM = stringArray1;
                            //    clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                            //    clsCinetpaytoken.Password = clsParametre.PP_VALEUR;//"@merveille241";


                            //    if (!CheckForInternetConnection())
                            //    {

                            //        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            //        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            //        clsMiccomptewebResultat.SL_MESSAGE = "La connexion internet n'est pas disponible !!!";
                            //        try
                            //        {
                            //            throw new Exception("La connexion internet n'est pas disponible !!!");
                            //        }
                            //        catch { return clsMiccomptewebResultat; }
                            //        //

                            //    }
                            //    else
                            //    {
                            //        clsCinetpays = pvgDemendetoken(clsCinetpaytoken);
                            //    }


                            //    if (clsCinetpays.Count == 0)
                            //    {

                            //        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            //        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            //        clsMiccomptewebResultat.SL_MESSAGE = "La demande de token a échoué !!!";
                            //        try
                            //        {
                            //            throw new Exception("Test Exception");
                            //        }
                            //        catch { return clsMiccomptewebResultat; }
                            //        //return clsResultatMobileTransactionMobileBankings[0];

                            //    }


                            //    //--
                            //    List<clsCinetpayMoneyContac> ListclsCinetpayMoneyContac = new List<clsCinetpayMoneyContac>();
                            //    clsCinetpayMoneyContac clsCinetpayMoneyContac = new clsCinetpayMoneyContac();
                            //    List<clsDataTransferts> clsDataTransferts = new List<clsDataTransferts>();
                            //    clsDataToken clsDataTokens = new clsDataToken();
                            //    clsDataTokens = clsCinetpays[0].data;

                            //    //private string _SL_TELEPHONE = "";
                            //    //private string _SL_INDICATIF = "";
                            //    //private string _SL_MONTANTOPERATION = "";
                            //    //private string _SL_URLNOTIFICATION = "";

                            //    //--part client
                            //    clsCinetpayMoneyContac = new clsCinetpayMoneyContac();

                            //    clsCinetpayMoneyContac.prefix = clsMiccomptewebResultat.SL_INDICATIF;
                            //    //if (SM_TELEPHONE.Length > 10)
                            //    //    clsCinetpayMoneyContac.phone = clsMiccomptewebResultat.SM_TELEPHONE.Substring(3, 8);
                            //    //else
                            //        clsCinetpayMoneyContac.phone = clsMiccomptewebResultat.SL_TELEPHONE;
                            //    //clsCinetpayMoneyContac.phone = "47839553";// clsCinetpayMoneyContac.phone = "47839553";
                            //    //"47839553";//
                            //    clsCinetpayMoneyContac.amount = clsMiccomptewebResultat.SL_MONTANTOPERATION.ToString();
                            //    clsCinetpayMoneyContac.client_transaction_id = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                            //    clsCinetpayMoneyContac.notify_url = clsMiccomptewebResultat.SL_URLNOTIFICATION;
                            //    ListclsCinetpayMoneyContac.Add(clsCinetpayMoneyContac);

                            //    if (!CheckForInternetConnection())
                            //    {

                            //        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            //        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            //        clsMiccomptewebResultat.SL_MESSAGE = "La connexion internet n'est pas disponible !!!";



                            //        try
                            //        {
                            //            throw new Exception("La connexion internet n'est pas disponible !!!");
                            //        }
                            //        catch
                            //        { return clsMiccomptewebResultat; }


                            //    }



                            //    //==============================================================transfert carte vers mobile
                                
                            //        clsDataTransferts = pvgAddTransfert(ListclsCinetpayMoneyContac, clsDataTokens);

                            //        if (clsDataTransferts.Count == 0)
                            //        {

                            //            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            //            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            //            clsMiccomptewebResultat.SL_MESSAGE = "Echec du service de transfert (00) !!!";
                            //            try
                            //            {
                            //                throw new Exception("Echec du service de transfert (00) !!!");
                            //            }
                            //            catch { return clsMiccomptewebResultat; }
                            //        }


                            //    if (clsDataTransferts[0].message == "OPERATION_SUCCES")
                            //    {


                            //        if (TYPEOPERATION == "5")
                            //        {
                            //             DataSet = new DataSet();
                            //            clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, clsMiccomptewebResultat.SL_NUMEROTRANSACTION };
                            //            DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATIONTONTINE(clsDonnee, clsObjetEnvoi);


                            //            if (DataSet.Tables[0].Rows.Count == 0)
                            //            {
                            //                clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            //                clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            //                clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                            //                return clsMiccomptewebResultat;
                            //            }

                            //            foreach (DataRow row in DataSet.Tables[0].Rows)
                            //            {
                            //                List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
                            //                //AG_CODEAGENCE= row["AC_CODEACTIVITE"].ToString();
                            //                string TE_CODESMSTYPEOPERATION = NO_CODENATUREVIREMENT;
                            //                //EJ_CODEEPARGNANTJOURNALIER = row["AC_CODEACTIVITE"].ToString();
                            //                //CT_CODECARTE = row["CT_CODECARTE"].ToString();
                            //                MI_CODEMISE = row["MI_CODEMISE"].ToString();
                            //                STICKER = "";
                            //                ST_STICKERCODE1 = "";
                            //                ST_STICKERCODE2 = "";
                            //                MC_NOMTIERS = row["DT_NOMTIERS"].ToString();
                            //                PI_CODEPIECE = row["PI_CODEPIECE"].ToString();
                            //                MC_NUMPIECETIERS = row["DT_NUMPIECETIERS"].ToString();
                            //                MONTANT = double.Parse(row["DT_PU"].ToString()).ToString();
                            //                //SM_TELEPHONE = row["AC_CODEACTIVITE"].ToString();
                            //                //DATEJOURNEE, 
                            //                //OP_CODEOPERATEUR


                            //                clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2, MC_NOMTIERS, PI_CODEPIECE, MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR,  SIGNATURE, TYPEOPERATION);
                            //                foreach (clsResultatOperation1 clsResultatOperation1 in clsResultatOperationListe)
                            //                {

                            //                    if (clsResultatOperationListe[0].SL_RESULTAT == "TRUE" && clsResultatOperationListe[0].ENVOISMS == "1")
                            //                    {
                            //                        if (clsResultatOperationListe[0].CL_TELEPHONE != "")
                            //                        {

                            //                            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                            //                            clsParams clsParams = new clsParams();
                            //                            TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                            //                            clsResultatOperationListe[0].SL_LIBELLE1 = "C";
                            //                            clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatOperationListe[0].PV_CODEPOINTVENTE, clsResultatOperationListe[0].CO_CODECOMPTE, clsResultatOperationListe[0].OB_NOMOBJET, clsResultatOperationListe[0].CL_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(clsResultatOperationListe[0].MC_DATEPIECE), "", clsResultatOperationListe[0].CL_IDCLIENT, "", clsResultatOperationListe[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", clsResultatOperationListe[0].SL_LIBELLE1, clsResultatOperationListe[0].SL_LIBELLE2);

                            //                            clsResultatOperationListe[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                            //                            clsResultatOperationListe[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                            //                            if (clsParams.SL_RESULTAT == "FALSE") clsResultatOperationListe[0].SL_MESSAGE = clsResultatOperationListe[0].SL_MESSAGE + " " + clsResultatOperationListe[0].SL_MESSAGEAPI;




                            //                        }


                            //                        if (clsResultatOperationListe[0].EJ_EMAIL != "")
                            //                        {

                            //                            string pvgTitre = clsResultatOperationListe[0].SL_MESSAGEOBJET;
                            //                            string vppMessage = clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                            //                            string vppMailExpediteur = clsResultatOperationListe[0].AG_EMAIL;
                            //                            string vppMotDePasseExpediteur = clsResultatOperationListe[0].AG_EMAILMOTDEPASSE;
                            //                            string vppMailRecepteur = clsResultatOperationListe[0].EJ_EMAIL;
                            //                            string vppCheminCompletFichierEnvoyer1 = "";
                            //                            string vppCheminCompletFichierEnvoyer2 = "";
                            //                            string vppCheminCompletFichierEnvoyer3 = "";

                            //                            sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                            //                        }

                            //                    }





                            //                    if (clsResultatOperation1.SL_RESULTAT == "TRUE")
                            //                    {
                            //                        clsMobiledetailoperationtontine clsMobiledetailoperationtontine = new clsMobiledetailoperationtontine();
                            //                        clsMobiledetailoperationtontine.AG_CODEAGENCE = AG_CODEAGENCE;
                            //                        clsMobiledetailoperationtontine.DT_DATEVALIDATION = DATEJOURNEE;
                            //                        string[] vppCritere = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                            //                        clsTontinewebWSBLL.pvgUpdateStatutOperation(clsDonnee, clsMobiledetailoperationtontine, vppCritere);


                            //                    }

                            //                    clsMiccomptewebResultat.SL_CODEMESSAGE = clsResultatOperation1.SL_CODEMESSAGE;
                            //                    clsMiccomptewebResultat.SL_RESULTAT = clsResultatOperation1.SL_RESULTAT;
                            //                    clsMiccomptewebResultat.SL_MESSAGE = clsResultatOperation1.SL_MESSAGE;

                            //                }

                            //            }
                            //        }



                            //        //if (clsResultatMobileTransactionMobileBankings[0].ENVOISMS == "1")
                            //        //{


                            //        //if (clsResultatMobileTransactionMobileBankings[0].SL_RESULTAT == "TRUE")
                            //        //{
                            //        //    if (clsResultatMobileTransactionMobileBankings[0].CL_TELEPHONE != "")
                            //        //    {
                            //        //        //SendMessage(clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "225", CL_TELEPHONE, AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, clsMiccomptewebmotpasseoublieListe[0].RP_NUMSEQUENCE, "OK");

                            //        //        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();


                            //        //        //0025    NULL SMS OPERATION MOBILE VERS COMPTE BANCAIRE C   O
                            //        //        //0026    NULL SMS OPERATION COMPTE BANCAIRE VERS MOBILE C   O
                            //        //        //0027    NULL SMS OPERATION CARTE BANCAIRE VERS COMPTE BANCAIRE   C O
                            //        //        //0028    NULL SMS OPERATION COMPTE BANCAIRE VERS CARTE BANCAIRE   C O


                            //        //        //if (clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE.Length == 8)
                            //        //        //    clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE ="00225"+clsMiccomptewebmotpasseoublieListe[0].CL_TELEPHONE;
                            //        //        string TE_CODESMSTYPEOPERATION1 = "";
                            //        //        if (NO_CODENATUREVIREMENT == "0011")
                            //        //        {// SMS OPERATION MOBILE VERS COMPTE BANCAIRE
                            //        //            clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE1 = "C";
                            //        //            TE_CODESMSTYPEOPERATION1 = "0025";
                            //        //        }

                            //        //        if (NO_CODENATUREVIREMENT == "0012")
                            //        //        {// SMS OPERATION COMPTE BANCAIRE VERS MOBILE
                            //        //            clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE1 = "D";
                            //        //            TE_CODESMSTYPEOPERATION1 = "0026";
                            //        //        }


                            //        //        clsParams clsParams = new clsParams();
                            //        //        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsResultatMobileTransactionMobileBankings[0].PV_CODEPOINTVENTE, CO_CODECOMPTE, clsResultatMobileTransactionMobileBankings[0].OB_NOMOBJET, clsResultatMobileTransactionMobileBankings[0].CL_TELEPHONE, clsResultatMobileTransactionMobileBankings[0].OP_CODEOPERATEUR, DateTime.Parse(clsResultatMobileTransactionMobileBankings[0].TW_DATESAISIE), "", CL_IDCLIENT, "", clsResultatMobileTransactionMobileBankings[0].SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION1, "0", "01/01/1900", "0", "0", "N", "0", clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE1, clsResultatMobileTransactionMobileBankings[0].SL_LIBELLE2);
                            //        //        clsResultatMobileTransactionMobileBankings[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                            //        //        clsResultatMobileTransactionMobileBankings[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                            //        //        if (clsParams.SL_RESULTAT == "FALSE") clsResultatMobileTransactionMobileBankings[0].SL_MESSAGE = clsResultatMobileTransactionMobileBankings[0].SL_MESSAGE + " " + clsResultatMobileTransactionMobileBankings[0].SL_MESSAGEAPI;

                            //        //    }

                            //        //}

                            //    }
                            //    else
                            //    {
                            //        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            //        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            //        clsMiccomptewebResultat.SL_MESSAGE = "La connexion internet n'est pas disponible (00) !!!";
                            //        try
                            //        {
                            //            throw new Exception("Le service n'est pas disponible (00) !!!");
                            //        }
                            //        catch { return clsMiccomptewebResultat; }


                            //    }




                            //    //==================




                            //    //------------======================================================fin cinet
                            //}//====================Fin Transfert carte vars mobile




                           


                            if (EJ_TELEPHONE != "" )//&& (TYPEOPERATION != "0")
                            {

                                clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                clsParams clsParams = new clsParams();
                               String TE_CODESMSTYPEOPERATION = "0005";// string.Format("{0:0000}", double.Parse(TE_CODESMSTYPEOPERATION));
                                String SL_LIBELLE1 = "C";
                                String SL_LIBELLE2 = "";
                                clsMiccomptewebResultat.SL_MESSAGECLIENT = "Merci de bien vouloir recevoir votre code de validation : " + clsHttoken.TK_TOKEN;
                                clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, AG_CODEAGENCE, clsMiccomptewebResultat.PV_CODEPOINTVENTE, clsMiccomptewebResultat.CO_CODECOMPTE, clsMiccomptewebResultat.OB_NOMOBJET, EJ_TELEPHONE, OP_CODEOPERATEUR, DateTime.Parse(DATEJOURNEE), "", clsMiccomptewebResultat.CL_IDCLIENT, "", clsMiccomptewebResultat.SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", "01/01/1900", "0", "0", "N", "0", SL_LIBELLE1,SL_LIBELLE2);

                                clsMiccomptewebResultat.SL_RESULTATAPI = clsParams.SL_RESULTAT;
                                clsMiccomptewebResultat.SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                                if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE + " " + clsMiccomptewebResultat.SL_MESSAGEAPI;





                            }


                            if (EJ_EMAIL != ""   )//&&(TYPEOPERATION != "0")
                            {
                                string AG_EMAIL = "";
                                string AG_EMAILMOTDEPASSE = "";
                                DataSet = new DataSet();
                                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE };
                                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetAgence(clsDonnee, clsObjetEnvoi);
                                foreach (DataRow row in DataSet.Tables[0].Rows)
                                {
                                    AG_EMAIL = row["AG_EMAIL"].ToString();
                                    AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                                }

                                string pvgTitre = "Code de validation";// clsResultatOperationListe[0].SL_MESSAGEOBJET;
                                string vppMessage ="Merci de bien vouloir recevoir votre code de validation : "+ clsHttoken.TK_TOKEN;// clsResultatOperationListe[0].SL_MESSAGECLIENT + " ";
                                string vppMailExpediteur =AG_EMAIL;
                                string vppMotDePasseExpediteur = AG_EMAILMOTDEPASSE;
                                string vppMailRecepteur = EJ_EMAIL;
                                string vppCheminCompletFichierEnvoyer1 = "";
                                string vppCheminCompletFichierEnvoyer2 = "";
                                string vppCheminCompletFichierEnvoyer3 = "";

                                sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);




                            }

                        }


                    }
                }
               


            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                clsMiccomptewebResultat.SL_MESSAGE = SQLEx.Message;
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                clsMiccomptewebResultat.SL_MESSAGE = SQLEx.Message;
            }
            finally
            {
                if (clsMiccomptewebResultat.SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebResultat;
        }



        public List<clsOperateur> pvgChargerListOperateur(string DATEJOURNEE, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string OP_NOMPRENOM, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string TYPEOPERATION,  string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsOperateur clsOperateur = new clsOperateur();
            List<clsOperateur> clsOperateurs = new List<clsOperateur>();

            List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsOperateur.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsOperateur.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsOperateur.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsOperateur.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;
            }
            if (string.IsNullOrEmpty(PV_CODEPOINTVENTE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsOperateur.SL_MESSAGE = "Le point de vente doit être renseigné !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;
            }           

            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsOperateur.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;
            }
          


            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultats[0].SL_RESULTAT == "FALSE")
                {

                    clsOperateur.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                    clsOperateur.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                    clsOperateur.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                    clsOperateurs.Add(clsOperateur);
                    return clsOperateurs;
                }


                DataSet DataSet = new DataSet();
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, PV_CODEPOINTVENTE, OP_NOMPRENOM };
                DataSet = clsTontinewebWSBLL.pvgChargerListOperateur(clsDonnee, clsObjetEnvoi);
                if(DataSet.Tables[0].Rows.Count>0)
                {
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            clsOperateur = new clsOperateur();
                            clsOperateur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                            clsOperateur.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                            clsOperateur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsOperateur.PV_CODEPOINTVENTE = row["PV_CODEPOINTVENTE"].ToString();
                            clsOperateur.SL_CODEMESSAGE = "00";
                            clsOperateur.SL_RESULTAT = "TRUE";
                            clsOperateur.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsOperateurs.Add(clsOperateur);

                        }
                }
                else
                {
                    clsOperateur.SL_CODEMESSAGE = "00";
                    clsOperateur.SL_RESULTAT = "FALSE";
                    clsOperateur.SL_MESSAGE = "Aucun élément trouvé !!!";
                    clsOperateurs.Add(clsOperateur);
                }
               


            }
            catch (SqlException SQLEx)
            {

                clsOperateur.SL_CODEMESSAGE ="00";
                clsOperateur.SL_RESULTAT = "FALSE";
                clsOperateur.SL_MESSAGE = SQLEx.Message;
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {

                clsOperateur.SL_CODEMESSAGE = "00";
                clsOperateur.SL_RESULTAT = "FALSE";
                clsOperateur.SL_MESSAGE = SQLEx.Message;
                clsOperateurs.Add(clsOperateur);
            }
            finally
            {
                if (clsOperateurs[0].SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsOperateurs;
        }

        public clsMiccomptewebResultat pvgVirementDAV(string DATEJOURNEE, string AG_CODEAGENCE, string VR_NUMEROTRANSACTION, string VR_IDCOMPTESIG, string VR_NUMCOMPTESIG, string ID_CLIENTSIG, string VR_MONTANTTRANSACTION, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE,  string VR_NUMEROBORDEREAUSIG, string VR_NUMEROBORDEREAUTONTINE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsMiccomptewebResultat clsMiccomptewebResultat = new clsMiccomptewebResultat();

            //if (string.IsNullOrEmpty(TO_VALIDEROPERATIONENCOURS)) TO_VALIDEROPERATIONENCOURS = "N";

            string VR_DATEVALIDATION = "01/01/1900";
            string VR_DATETRANSMISSION = "01/01/1900";
            string VR_DATERECEPTION = "01/01/1900";



            if (TYPEOPERATION == "0" )
                VR_NUMEROTRANSACTION = System.Guid.NewGuid().ToString();

            //clsNumeroMobileMappe clsNumeroMobileMappe = new clsNumeroMobileMappe();

            List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }
            //if (string.IsNullOrEmpty(TK_CODETYPEOPERATION))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsHttoken.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsHttoken.SL_RESULTAT = "Le type opération n'est pas correct !!!";//clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsHttoken.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    return clsHttoken;
            //}

            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }
            if (string.IsNullOrEmpty(EJ_CODEEPARGNANTJOURNALIER) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le client est obligatoire !!!";//clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }


            if (string.IsNullOrEmpty(VR_IDCOMPTESIG) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "L'id du compte sig est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(VR_NUMCOMPTESIG) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le numéro du compte sig est obligatoire !!!";//clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }
            if (string.IsNullOrEmpty(ID_CLIENTSIG) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "L'id du client sig est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(VR_MONTANTTRANSACTION) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le montant  est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            if (string.IsNullOrEmpty(CT_CODECARTE) && TYPEOPERATION == "0")
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le code de la carte  est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            //if (TYPEOPERATION != "0" && TYPEOPERATION != "1")
            //{

            //    clsHttoken.SL_RESULTAT = "FALSE";
            //    clsHttoken.SL_MESSAGE = "Le type opération n'est pas correct !!!";
            //    clsHttoken.SL_CODEMESSAGE = "00";
            //    return clsHttoken;
            //}


            if (string.IsNullOrEmpty(VR_NUMEROTRANSACTION) && (TYPEOPERATION == "3" || TYPEOPERATION == "4"))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                clsMiccomptewebResultat.SL_MESSAGE = "Le code de la transaction est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
                return clsMiccomptewebResultat;
            }

            //if (string.IsNullOrEmpty(TK_TOKEN) && TYPEOPERATION == "3")
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "Le code de validation est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}



            //if (string.IsNullOrEmpty(SO_CODESOUSCRIPTION) && (TYPEOPERATION == "5"))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "Le code de souscription est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(SM_TELEPHONE) && (TYPEOPERATION == "0" || TYPEOPERATION == "5"))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "Le numéro de téléphone est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}
            //if (string.IsNullOrEmpty(PI_CODEPIECE) && (TYPEOPERATION == "5"))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "La pièce est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(MC_NUMPIECETIERS) && (TYPEOPERATION == "5"))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = "Le numéro de pièce est obligatoire !!!";// clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}
            //if (string.IsNullOrEmpty(SL_LOGIN))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}

            //if (string.IsNullOrEmpty(SL_CLESESSION))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultats = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
            //    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    return clsMiccomptewebResultat;
            //}






            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultats = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultats[0].SL_RESULTAT == "FALSE")
                {
                    clsMiccomptewebResultat.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                    clsMiccomptewebResultat.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                    clsMiccomptewebResultat.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                    return clsMiccomptewebResultat;
                }


                //clsMiccomptewebResultat clsResultatOperationListe = new clsMiccomptewebResultat();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgVirementDAV( clsDonnee,  AG_CODEAGENCE,  VR_NUMEROTRANSACTION,  VR_IDCOMPTESIG,  VR_NUMCOMPTESIG,  ID_CLIENTSIG,  VR_MONTANTTRANSACTION,  EJ_CODEEPARGNANTJOURNALIER,  VR_DATEVALIDATION,  CT_CODECARTE,  VR_DATETRANSMISSION,  VR_DATERECEPTION,  VR_NUMEROBORDEREAUSIG,  VR_NUMEROBORDEREAUTONTINE,  TYPEOPERATION);

                if(clsMiccomptewebResultat.SL_RESULTAT=="TRUE")//--Transmission
                {
                    clsMiccomptewebResultat clsMiccomptewebResultatTransmission = new clsMiccomptewebResultat();
                    TYPEOPERATION = "3";
                    VR_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                    VR_DATETRANSMISSION = DATEJOURNEE;
                    clsMiccomptewebResultatTransmission = clsTontinewebWSBLL.pvgVirementDAV(clsDonnee, AG_CODEAGENCE, VR_NUMEROTRANSACTION, VR_IDCOMPTESIG, VR_NUMCOMPTESIG, ID_CLIENTSIG, VR_MONTANTTRANSACTION, EJ_CODEEPARGNANTJOURNALIER, VR_DATEVALIDATION, CT_CODECARTE, VR_DATETRANSMISSION, VR_DATERECEPTION, VR_NUMEROBORDEREAUSIG, VR_NUMEROBORDEREAUTONTINE, TYPEOPERATION);

                    if (clsMiccomptewebResultatTransmission.SL_RESULTAT == "TRUE")//--Reception
                    {
                        clsMiccomptewebResultat clsMiccomptewebResultatReception = new clsMiccomptewebResultat();
                        TYPEOPERATION = "4";
                        VR_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                        VR_DATERECEPTION = DATEJOURNEE;
                        VR_NUMEROBORDEREAUSIG = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                        clsMiccomptewebResultatReception = clsTontinewebWSBLL.pvgVirementDAV(clsDonnee, AG_CODEAGENCE, VR_NUMEROTRANSACTION, VR_IDCOMPTESIG, VR_NUMCOMPTESIG, ID_CLIENTSIG, VR_MONTANTTRANSACTION, EJ_CODEEPARGNANTJOURNALIER, VR_DATEVALIDATION, CT_CODECARTE, VR_DATETRANSMISSION, VR_DATERECEPTION, VR_NUMEROBORDEREAUSIG, VR_NUMEROBORDEREAUTONTINE, TYPEOPERATION);


                        if (clsMiccomptewebResultatReception.SL_RESULTAT == "TRUE")//--Reception
                        {
                            List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();

                            string TE_CODESMSTYPEOPERATION = "16";
                            string MI_CODEMISE = "1";
                            string STICKER = "";
                            string ST_STICKERCODE1 = "";
                            string ST_STICKERCODE2 = "";
                            string MC_NOMTIERS = "lm";
                            string PI_CODEPIECE = "00001";
                            string MC_NUMPIECETIERS = "010101";
                            string MONTANT = VR_MONTANTTRANSACTION;
                            string SM_TELEPHONE = "";
                            string OP_CODEOPERATEUR = "100000010";
                            string SIGNATURE = "";
                             TYPEOPERATION = "03";
                            clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2, MC_NOMTIERS, PI_CODEPIECE, MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR, SIGNATURE, TYPEOPERATION);
                            if(clsResultatOperationListe[0].SL_RESULTAT=="TRUE")
                            {
                                clsMiccomptewebResultat clsMiccomptewebResultatComptabilisation = new clsMiccomptewebResultat();
                                TYPEOPERATION = "5";
                                VR_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                                VR_DATEVALIDATION = DATEJOURNEE;
                                VR_NUMEROBORDEREAUTONTINE = clsResultatOperationListe[0].NUMEROBORDEREAU;
                                clsMiccomptewebResultatComptabilisation = clsTontinewebWSBLL.pvgVirementDAV(clsDonnee, AG_CODEAGENCE, VR_NUMEROTRANSACTION, VR_IDCOMPTESIG, VR_NUMCOMPTESIG, ID_CLIENTSIG, VR_MONTANTTRANSACTION, EJ_CODEEPARGNANTJOURNALIER, VR_DATEVALIDATION, CT_CODECARTE, VR_DATETRANSMISSION, VR_DATERECEPTION, VR_NUMEROBORDEREAUSIG, VR_NUMEROBORDEREAUTONTINE, TYPEOPERATION);
                            }
                           
                        }


                    }
                }

                //if (TYPEOPERATION == "3" || TYPEOPERATION == "4")
                //{
                //    DataSet DataSet = new DataSet();
                //    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                //    DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATIONTONTINE(clsDonnee, clsObjetEnvoi);


                //    if (DataSet.Tables[0].Rows.Count == 0)
                //    {
                //        clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                //        clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                //        clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                //        return clsMiccomptewebResultat;
                //    }

                //    foreach (DataRow row in DataSet.Tables[0].Rows)
                //    {
                //        List<clsResultatOperation1> clsResultatOperationListe = new List<clsResultatOperation1>();
                //        //AG_CODEAGENCE= row["AC_CODEACTIVITE"].ToString();
                //        string TE_CODESMSTYPEOPERATION = NO_CODENATUREVIREMENT;
                //        //EJ_CODEEPARGNANTJOURNALIER = row["AC_CODEACTIVITE"].ToString();
                //        //CT_CODECARTE = row["CT_CODECARTE"].ToString();
                //        MI_CODEMISE = row["MI_CODEMISE"].ToString();
                //        STICKER = "";
                //        ST_STICKERCODE1 = "";
                //        ST_STICKERCODE2 = "";
                //        MC_NOMTIERS = row["DT_NOMTIERS"].ToString();
                //        PI_CODEPIECE = row["PI_CODEPIECE"].ToString();
                //        MC_NUMPIECETIERS = row["DT_NUMPIECETIERS"].ToString();
                //        MONTANT = double.Parse(row["DT_PU"].ToString()).ToString();
                //        //SM_TELEPHONE = row["AC_CODEACTIVITE"].ToString();
                //        //DATEJOURNEE, 
                //        //OP_CODEOPERATEUR


                //        clsResultatOperationListe = clsTontinewebWSBLL.pvgVersementTontine(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TE_CODESMSTYPEOPERATION, EJ_CODEEPARGNANTJOURNALIER, CT_CODECARTE, MI_CODEMISE, STICKER, ST_STICKERCODE1, ST_STICKERCODE2, MC_NOMTIERS, PI_CODEPIECE, MC_NUMPIECETIERS, MONTANT, SM_TELEPHONE, DATEJOURNEE, OP_CODEOPERATEUR, SIGNATURE, TYPEOPERATION);
                //        foreach (clsResultatOperation1 clsResultatOperation1 in clsResultatOperationListe)
                //        {
                //            if (clsResultatOperation1.SL_RESULTAT == "TRUE")
                //            {
                //                clsMobiledetailoperationtontine clsMobiledetailoperationtontine = new clsMobiledetailoperationtontine();
                //                clsMobiledetailoperationtontine.AG_CODEAGENCE = AG_CODEAGENCE;
                //                clsMobiledetailoperationtontine.DT_DATEVALIDATION = DATEJOURNEE;
                //                string[] vppCritere = new string[] { AG_CODEAGENCE, DT_NUMEROTRANSACTION };
                //                clsTontinewebWSBLL.pvgUpdateStatutOperation(clsDonnee, clsMobiledetailoperationtontine, vppCritere);


                //            }

                //            clsMiccomptewebResultat.SL_CODEMESSAGE = clsResultatOperation1.SL_CODEMESSAGE;
                //            clsMiccomptewebResultat.SL_RESULTAT = clsResultatOperation1.SL_RESULTAT;
                //            clsMiccomptewebResultat.SL_MESSAGE = clsResultatOperation1.SL_MESSAGE;

                //        }

                //    }
                //}




            }
            catch (SqlException SQLEx)
            {
                clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                clsMiccomptewebResultat.SL_MESSAGE = SQLEx.Message;
            }
            catch (Exception SQLEx)
            {
                clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                clsMiccomptewebResultat.SL_MESSAGE = SQLEx.Message;
            }
            finally
            {
                if (clsMiccomptewebResultat.SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsMiccomptewebResultat;
        }

        public clsResultat pvgSouscriptionMobileBanking(string LG_CODELANGUE, string AG_CODEAGENCE,  string SO_CODESOUSCRIPTION, string PY_CODEPAYS, string SO_TELEPHONE, string DATEJOURNEE, string SO_EMAIL, string SO_LIEURESIDENCE, string TYPEOPERATION, string TK_TOKEN,string EJ_IDEPARGNANTJOURNALIER,  string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<clsResultat> clsResultats = new List<clsResultat>();

            clsResultat clsResultat = new clsResultat();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "L'agence est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            //if (string.IsNullOrEmpty(CT_CODECARTE))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultat.SL_MESSAGE = "La carte est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}



            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];

            }

            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];

            }

            if (string.IsNullOrEmpty(SO_TELEPHONE))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (SO_TELEPHONE.Replace(" ", "") != SO_TELEPHONE)
            {
                clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (SO_TELEPHONE.Replace("-", "") != SO_TELEPHONE)
            {

                List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (SO_TELEPHONE.Replace("/", "") != SO_TELEPHONE)
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }



            if (TYPEOPERATION != "01" && TYPEOPERATION != "02")
            {

                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = "Le type opération n'est pas correct !!!";
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(SO_EMAIL) && TYPEOPERATION != "02")
            {

                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = "L'E-mail est obligatoire !!!";
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (string.IsNullOrEmpty(PY_CODEPAYS) && PY_CODEPAYS == "01")
            {

                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = "L'indicatif est obligatoire !!!";
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }



            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }




            if (string.IsNullOrEmpty(SO_LIEURESIDENCE) && TYPEOPERATION == "01")
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0085", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }






            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (string.IsNullOrEmpty(TK_TOKEN))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "Token invalide !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "Le code de l'épargnant est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }



            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsResultats.Add(clsResultat);
                //    return clsResultats[0];
                //}






                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultats.Add(clsResultat);
                    return clsResultats[0];
                }

                //----VERIFICATION DU TOKEN
                clsHttoken clsHttoken = new clsHttoken();
                clsHttoken = clsTontinewebWSBLL.pvgDemandeToken(clsDonnee, AG_CODEAGENCE, TK_TOKEN, "03",  EJ_IDEPARGNANTJOURNALIER, "2");
                if (clsHttoken.SL_RESULTAT == "FALSE")
                {
                    clsResultat.SL_CODEMESSAGE = clsHttoken.SL_CODEMESSAGE;
                    clsResultat.SL_RESULTAT = clsHttoken.SL_RESULTAT;
                    clsResultat.SL_MESSAGE = clsHttoken.SL_MESSAGE;
                    clsResultats.Add(clsResultat);
                    return clsResultats[0];
                }


                string CO_CODECOMPTE = "";
                DataSet DataSet = new DataSet();
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, EJ_IDEPARGNANTJOURNALIER };
                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetEPARGNANTJOURNALIERSelonId(clsDonnee, clsObjetEnvoi);
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    CO_CODECOMPTE = row["CO_CODECOMPTE"].ToString();
                }

                clsResultats = clsTontinewebWSBLL.pvgSouscriptionMobileBanking(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, CO_CODECOMPTE, SO_CODESOUSCRIPTION, PY_CODEPAYS, SO_TELEPHONE, DATEJOURNEE, SO_EMAIL, SO_LIEURESIDENCE,  EJ_IDEPARGNANTJOURNALIER, TYPEOPERATION);

                if (clsResultats[0].SL_RESULTAT == "TRUE" && TYPEOPERATION != "02")
                {
                    //--
                    List<clsCinetpay> clsCinetpays = new List<clsCinetpay>();
                    clsCinetpaytoken clsCinetpaytoken = new clsCinetpaytoken();
                    //clsCinetpaytoken.Apikey = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";
                    //clsCinetpaytoken.Password = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_P"));//"@merveille241";

                    clsParametre clsParametre = new clsParametre();
                    clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                    clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                    string[] stringArray = { "CIT_K" };
                    clsObjetEnvoi1.OE_PARAM = stringArray;
                    clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                    clsCinetpaytoken.Apikey = clsParametre.PP_VALEUR;// clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";

                    clsParametre = new clsParametre();
                    clsParametreWSBLL = new clsParametreWSBLL();
                    clsObjetEnvoi1 = new clsObjetEnvoi();
                    string[] stringArray1 = { "CIT_P" };
                    clsObjetEnvoi1.OE_PARAM = stringArray1;
                    clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                    clsCinetpaytoken.Password = clsParametre.PP_VALEUR;//"@merveille241";


                    if (IsNetworkConnected())
                        clsCinetpays = pvgDemendetoken(clsCinetpaytoken);

                    if (clsCinetpays.Count==0)
                    {
                        clsResultats = new List<clsResultat>();
                        clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                        clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                        clsResultat.SL_MESSAGE = "La demande de token a échoué !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                        clsResultats.Add(clsResultat);
                        try
                        {
                            throw new Exception("Test Exception");
                        }
                        catch {return clsResultats[0];}
                        //return clsResultatMobileTransactionMobileBankings[0];

                    }


                    //--
                    List<clsDataContact> clsDataContacts = new List<clsDataContact>();
                    List<clsCinetpayContact> listclsCinetpayContact = new List<clsCinetpayContact>();
                    clsCinetpayContact clsCinetpayContact = new clsCinetpayContact();
                    clsDataToken clsDataTokens = new clsDataToken();
                    clsDataTokens = clsCinetpays[0].data;
                    clsCinetpayContact.email = SO_EMAIL;
                    clsCinetpayContact.prefix = "225";
                    clsCinetpayContact.phone = SO_TELEPHONE;
                    clsCinetpayContact.name = clsResultats[0].SL_NOM;
                    clsCinetpayContact.surname = clsResultats[0].SL_PRENOMS;
                    listclsCinetpayContact.Add(clsCinetpayContact);
                    if (IsNetworkConnected())
                        clsDataContacts = pvgAddContact(listclsCinetpayContact, clsDataTokens);
                    //--

                    if (clsDataContacts.Count == 0)
                    {
                        clsResultats = new List<clsResultat>();
                        clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                        clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                        clsResultat.SL_MESSAGE = "Le service n'est pas disponible (00) !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                        clsResultats.Add(clsResultat);
                        try
                        {
                            throw new Exception("Le service n'est pas disponible (00) !!!");
                        }
                        catch { return clsResultats[0]; }
                    }



                }

                if (!CheckForInternetConnection())
                {
                    clsResultats = new List<clsResultat>();
                    clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultat.SL_MESSAGE = "La connexion internet n'est pas disponible !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultats.Add(clsResultat);
                    try
                    {
                        throw new Exception("Test Exception");
                    }
                    catch { }
                    //return clsResultatMobileTransactionMobileBankings[0];

                }






            }
            catch (SqlException SQLEx)
            {
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = SQLEx.Message;
                clsResultats.Add(clsResultat);
            }
            catch (Exception SQLEx)
            {
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = SQLEx.Message;
                clsResultats.Add(clsResultat);
            }
            finally
            {
                if (clsResultats[0].SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsResultats[0];
        }


        public clsResultat pvgSouscriptionVirementDAV(string LG_CODELANGUE, string AG_CODEAGENCE,  string EJ_IDEPARGNANTJOURNALIER, string ID_CLIENTSIG, string SO_CODESOUSCRIPTION, string DATEJOURNEE, string TYPEOPERATION, string TK_TOKEN, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<clsResultat> clsResultats = new List<clsResultat>();

            clsResultat clsResultat = new clsResultat();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "L'agence est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(ID_CLIENTSIG))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "Le code sig est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }



            if (string.IsNullOrEmpty(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];

            }

            clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];

            }

            //if (string.IsNullOrEmpty(SO_TELEPHONE))
            //{



            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
            //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}


            //if (SO_TELEPHONE.Replace(" ", "") != SO_TELEPHONE)
            //{
            //    clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
            //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}

            //if (SO_TELEPHONE.Replace("-", "") != SO_TELEPHONE)
            //{

            //    List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
            //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}


            //if (SO_TELEPHONE.Replace("/", "") != SO_TELEPHONE)
            //{


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
            //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}



            if (TYPEOPERATION != "01" && TYPEOPERATION != "02")
            {

                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = "Le type opération n'est pas correct !!!";
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            //if (string.IsNullOrEmpty(SO_EMAIL) && TYPEOPERATION != "02")
            //{

            //    clsResultat.SL_RESULTAT = "FALSE";
            //    clsResultat.SL_MESSAGE = "L'E-mail est obligatoire !!!";
            //    clsResultat.SL_CODEMESSAGE = "00";
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}


            //if (string.IsNullOrEmpty(PY_CODEPAYS) && PY_CODEPAYS == "01")
            //{

            //    clsResultat.SL_RESULTAT = "FALSE";
            //    clsResultat.SL_MESSAGE = "L'indicatif est obligatoire !!!";
            //    clsResultat.SL_CODEMESSAGE = "00";
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}



            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }




            //if (string.IsNullOrEmpty(SO_LIEURESIDENCE) && TYPEOPERATION == "01")
            //{


            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0085", "01");
            //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsResultats.Add(clsResultat);
            //    return clsResultats[0];
            //}

            if (string.IsNullOrEmpty(TYPEOPERATION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }






            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }


            if (string.IsNullOrEmpty(TK_TOKEN))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "Token invalide !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }

            if (string.IsNullOrEmpty(EJ_IDEPARGNANTJOURNALIER))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                clsResultat.SL_MESSAGE = "Le code de l'épargnant est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsResultats.Add(clsResultat);
                return clsResultats[0];
            }



            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsResultats.Add(clsResultat);
                //    return clsResultats[0];
                //}






                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsResultat.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsResultat.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsResultat.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsResultats.Add(clsResultat);
                    return clsResultats[0];
                }

                //----VERIFICATION DU TOKEN
                clsHttoken clsHttoken = new clsHttoken();
                clsHttoken = clsTontinewebWSBLL.pvgDemandeToken(clsDonnee, AG_CODEAGENCE, TK_TOKEN, "03",  EJ_IDEPARGNANTJOURNALIER, "2");
                if (clsHttoken.SL_RESULTAT == "FALSE")
                {
                    clsResultat.SL_CODEMESSAGE = clsHttoken.SL_CODEMESSAGE;
                    clsResultat.SL_RESULTAT = clsHttoken.SL_RESULTAT;
                    clsResultat.SL_MESSAGE = clsHttoken.SL_MESSAGE;
                    clsResultats.Add(clsResultat);
                    return clsResultats[0];
                }


                string CO_CODECOMPTE = "";
                DataSet DataSet = new DataSet();
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, EJ_IDEPARGNANTJOURNALIER };
                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetEPARGNANTJOURNALIERSelonId(clsDonnee, clsObjetEnvoi);
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    CO_CODECOMPTE = row["CO_CODECOMPTE"].ToString();
                }

                clsResultats = clsTontinewebWSBLL.pvgSouscriptionVirementDAV(clsDonnee,  LG_CODELANGUE,  AG_CODEAGENCE,  EJ_IDEPARGNANTJOURNALIER,  ID_CLIENTSIG,  SO_CODESOUSCRIPTION,  DATEJOURNEE,  TYPEOPERATION);

                //if (clsResultats[0].SL_RESULTAT == "TRUE" && TYPEOPERATION != "02")
                //{
                //    //--
                //    List<clsCinetpay> clsCinetpays = new List<clsCinetpay>();
                //    clsCinetpaytoken clsCinetpaytoken = new clsCinetpaytoken();
                //    //clsCinetpaytoken.Apikey = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";
                //    //clsCinetpaytoken.Password = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_P"));//"@merveille241";

                //    clsParametre clsParametre = new clsParametre();
                //    clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                //    clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                //    string[] stringArray = { "CIT_K" };
                //    clsObjetEnvoi1.OE_PARAM = stringArray;
                //    clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                //    clsCinetpaytoken.Apikey = clsParametre.PP_VALEUR;// clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";

                //    clsParametre = new clsParametre();
                //    clsParametreWSBLL = new clsParametreWSBLL();
                //    clsObjetEnvoi1 = new clsObjetEnvoi();
                //    string[] stringArray1 = { "CIT_P" };
                //    clsObjetEnvoi1.OE_PARAM = stringArray1;
                //    clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                //    clsCinetpaytoken.Password = clsParametre.PP_VALEUR;//"@merveille241";


                //    if (IsNetworkConnected())
                //        clsCinetpays = pvgDemendetoken(clsCinetpaytoken);

                //    if (clsCinetpays.Count==0)
                //    {
                //        clsResultats = new List<clsResultat>();
                //        clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //        clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                //        clsResultat.SL_MESSAGE = "La demande de token a échoué !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                //        clsResultats.Add(clsResultat);
                //        try
                //        {
                //            throw new Exception("Test Exception");
                //        }
                //        catch {return clsResultats[0];}
                //        //return clsResultatMobileTransactionMobileBankings[0];

                //    }


                //    ////--
                //    //List<clsDataContact> clsDataContacts = new List<clsDataContact>();
                //    //List<clsCinetpayContact> listclsCinetpayContact = new List<clsCinetpayContact>();
                //    //clsCinetpayContact clsCinetpayContact = new clsCinetpayContact();
                //    //clsDataToken clsDataTokens = new clsDataToken();
                //    //clsDataTokens = clsCinetpays[0].data;
                //    //clsCinetpayContact.email = SO_EMAIL;
                //    //clsCinetpayContact.prefix = "225";
                //    //clsCinetpayContact.phone = SO_TELEPHONE;
                //    //clsCinetpayContact.name = clsResultats[0].SL_NOM;
                //    //clsCinetpayContact.surname = clsResultats[0].SL_PRENOMS;
                //    //listclsCinetpayContact.Add(clsCinetpayContact);
                //    //if (IsNetworkConnected())
                //    //    clsDataContacts = pvgAddContact(listclsCinetpayContact, clsDataTokens);
                //    ////--

                //    //if (clsDataContacts.Count == 0)
                //    //{
                //    //    clsResultats = new List<clsResultat>();
                //    //    clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    //    clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                //    //    clsResultat.SL_MESSAGE = "Le service n'est pas disponible (00) !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                //    //    clsResultats.Add(clsResultat);
                //    //    try
                //    //    {
                //    //        throw new Exception("Le service n'est pas disponible (00) !!!");
                //    //    }
                //    //    catch { return clsResultats[0]; }
                //    //}



                //}

                //if (!CheckForInternetConnection())
                //{
                //    clsResultats = new List<clsResultat>();
                //    clsResultat.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsResultat.SL_RESULTAT = "FALSE";// clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsResultat.SL_MESSAGE = "La connexion internet n'est pas disponible !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsResultats.Add(clsResultat);
                //    try
                //    {
                //        throw new Exception("Test Exception");
                //    }
                //    catch { }
                //    //return clsResultatMobileTransactionMobileBankings[0];

                //}






            }
            catch (SqlException SQLEx)
            {
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = SQLEx.Message;
                clsResultats.Add(clsResultat);
            }
            catch (Exception SQLEx)
            {
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultat.SL_RESULTAT = "FALSE";
                clsResultat.SL_MESSAGE = SQLEx.Message;
                clsResultats.Add(clsResultat);
            }
            finally
            {
                if (clsResultats[0].SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsResultats[0];
        }




        public List<clsNumeroMobileMappe> pvgCompteMobileMappe(string LG_CODELANGUE, string AG_CODEAGENCE, string CO_CODECOMPTE, string CL_IDCLIENT,string CT_CODECARTE,string SO_TELEPHONE, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<clsNumeroMobileMappe> clsNumeroMobileMappes = new List<clsNumeroMobileMappe>();

            clsNumeroMobileMappe clsNumeroMobileMappe = new clsNumeroMobileMappe();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(CT_CODECARTE)) CT_CODECARTE = "";
            if (string.IsNullOrEmpty(SO_TELEPHONE)) SO_TELEPHONE = "";


            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }




            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = "L'agence est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }





            //if (string.IsNullOrEmpty(DATEJOURNEE) )
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];
            //}


            //if (!clsDate.ClasseDate.pvgTestSiDate1(DATEJOURNEE))
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];

            //}

            //clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
            //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //clsObjetEnvoi.OE_A = AG_CODEAGENCE;
            //clsObjetEnvoi.OE_J = DateTime.Parse(DATEJOURNEE);
            //if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
            //{
            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "GNE0076", "01");
            //    clsMiccomptewebmotpasseoublie.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsMiccomptewebmotpasseoublieListe.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublieListe[0];

            //}

            if (string.IsNullOrEmpty(CL_IDCLIENT))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = "Le code du client est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }
            if (string.IsNullOrEmpty(CT_CODECARTE) && TYPEOPERATION!="05"&& TYPEOPERATION!="06")
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = "Le code de la carte est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }
            if (string.IsNullOrEmpty(SO_TELEPHONE) && TYPEOPERATION=="06")
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0010", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = "Le numéro de téléphone est obligatoire !!!";//clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }



            //if (SO_TELEPHONE.Replace(" ", "") != SO_TELEPHONE)
            //{
            //clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

            ////----EXEPTION
            //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0011", "01");
            //    clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
            //    return clsNumeroMobileMappes;
            //}

            //if (SO_TELEPHONE.Replace("-", "") != SO_TELEPHONE && TYPEOPERATION == "02")
            //{

            //List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


            ////----EXEPTION
            //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
            //    clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
            //    return clsNumeroMobileMappes;
            //}


            //if (SO_TELEPHONE.Replace("/", "") != SO_TELEPHONE && TYPEOPERATION == "02")
            //{


            ////----EXEPTION
            //clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0012", "01");
            //    clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
            //    return clsNumeroMobileMappes;
            //}

            if (TYPEOPERATION != "01" && TYPEOPERATION != "02" && TYPEOPERATION != "03"&& TYPEOPERATION != "04" && TYPEOPERATION != "05" && TYPEOPERATION != "06")
            {

                clsNumeroMobileMappe.SL_RESULTAT = "FALSE";
                clsNumeroMobileMappe.SL_MESSAGE = "Le type opération n'est pas correct !!!";
                clsNumeroMobileMappe.SL_CODEMESSAGE = "00";
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }



            if (string.IsNullOrEmpty(CO_CODECOMPTE) && TYPEOPERATION == "01")
            {

                clsNumeroMobileMappe.SL_RESULTAT = "FALSE";
                clsNumeroMobileMappe.SL_MESSAGE = "Le compte est obligatoire !!!";
                clsNumeroMobileMappe.SL_CODEMESSAGE = "00";
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }







            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }






            if (string.IsNullOrEmpty(TYPEOPERATION))
            {



                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }






            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                return clsNumeroMobileMappes;
            }






            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                //clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{
                //    clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                //    return clsNumeroMobileMappes;
                //}






                //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");
                if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                {
                    clsNumeroMobileMappe.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                    clsNumeroMobileMappe.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                    clsNumeroMobileMappe.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                    clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
                    return clsNumeroMobileMappes;
                }


                clsNumeroMobileMappes = clsTontinewebWSBLL.pvgCompteMobileMappe(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, CO_CODECOMPTE, CL_IDCLIENT, CT_CODECARTE, SO_TELEPHONE, TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsNumeroMobileMappe.SL_RESULTAT = "FALSE";
                clsNumeroMobileMappe.SL_MESSAGE = SQLEx.Message;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
            }
            catch (Exception SQLEx)
            {
                clsNumeroMobileMappe.SL_RESULTAT = "FALSE";
                clsNumeroMobileMappe.SL_MESSAGE = SQLEx.Message;
                clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
            }
            finally
            {
                if (clsNumeroMobileMappes[0].SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsNumeroMobileMappes;
        }



        public static bool IsNetworkConnected()
        {
            bool connected = SystemInformation.Network;
            if (connected)
            {
                connected = false;
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT NetConnectionStatus FROM Win32_NetworkAdapter");
                foreach (System.Management.ManagementObject networkAdapter in searcher.Get())
                {
                    if (networkAdapter["NetConnectionStatus"] != null)
                    {
                        if (Convert.ToInt32(networkAdapter["NetConnectionStatus"]).Equals(2))
                        {
                            connected = true;
                            break;
                        }
                    }
                }
                searcher.Dispose();
            }
            return connected;
        }


        public clsMiccomptewebUserLogin pvgUploadPhotoSignature(string DATEJOURNEE, string PHOTO, string SIGNATURE, string NOMPHOTO, string NOMSIGNATURE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogin = new List<clsMiccomptewebUserLogin>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }



            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;


                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;


                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgUploadPhotoSignature(clsDonnee, PHOTO, SIGNATURE, NOMPHOTO, NOMSIGNATURE, LG_CODELANGUE);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }

        public clsMiccomptewebUserLogin pvgUploadSignature(string DATEJOURNEE, string SIGNATURE,  string NOMSIGNATURE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogin = new List<clsMiccomptewebUserLogin>();

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }



            if (string.IsNullOrEmpty(SL_LOGIN))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;

                //clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                //clsMiccomptewebUserLogin1.SL_MESSAGE ="Le login est obligatoire !!!";

                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(SL_MOTPASSE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;


                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(TYPEOPERATEUR))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;


                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }



            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgUploadSignature(clsDonnee, SIGNATURE, NOMSIGNATURE, LG_CODELANGUE);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }

        public clsInfoSouscriptionMobile pvgInfoSousCriptionMobile(string AG_CODEAGENCE, string SO_TELEPHONE, string LG_CODELANGUE, string TYPEOPERATION)//string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string CL_EMAIL, string CL_TELEPHONE
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
           clsInfoSouscriptionMobile clsInfoSouscriptionMobile = new clsInfoSouscriptionMobile();

            clsNumeroMobileMappe clsNumeroMobileMappe = new clsNumeroMobileMappe();

            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsInfoSouscriptionMobile.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsInfoSouscriptionMobile.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsInfoSouscriptionMobile.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsInfoSouscriptionMobile;
            }




            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsInfoSouscriptionMobile.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsInfoSouscriptionMobile.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsInfoSouscriptionMobile.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsInfoSouscriptionMobile;
            }


            if (string.IsNullOrEmpty(SO_TELEPHONE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsInfoSouscriptionMobile.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsInfoSouscriptionMobile.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsInfoSouscriptionMobile.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsInfoSouscriptionMobile;
            }


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {


                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsInfoSouscriptionMobile.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsInfoSouscriptionMobile.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsInfoSouscriptionMobile.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                return clsInfoSouscriptionMobile;
            }


            try
            {
                //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();


                //----
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();

                clsInfoSouscriptionMobile = clsTontinewebWSBLL.pvgInfoSousCriptionMobile(clsDonnee, AG_CODEAGENCE, SO_TELEPHONE, LG_CODELANGUE, TYPEOPERATION);


            }
            catch (SqlException SQLEx)
            {
                clsInfoSouscriptionMobile.SL_RESULTAT = "FALSE";
                clsInfoSouscriptionMobile.SL_MESSAGE = SQLEx.Message;
            }
            catch (Exception SQLEx)
            {
                clsInfoSouscriptionMobile.SL_RESULTAT = "FALSE";
                clsInfoSouscriptionMobile.SL_MESSAGE = SQLEx.Message;
            }
            finally
            {
                if (clsInfoSouscriptionMobile.SL_RESULTAT == "FALSE")
                {
                    clsObjetRetour.SetValue(false);
                }
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsInfoSouscriptionMobile;
        }



        public List<clsTypeoperation> pvgChargerDansDataSet1Billetage(string DATEJOURNEE, string AG_CODEAGENCE, string OB_NOMOBJET , string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTypeoperation> clsTypeoperation = new List<clsTypeoperation>();
            clsTypeoperation clsTypeoperation1 = new clsTypeoperation();


           


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(OB_NOMOBJET))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le nom de l'objet est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                 clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, OB_NOMOBJET };
                DataSet DataSet = new DataSet();

                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSet1Billetage(clsDonnee, clsObjetEnvoi);


                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        clsTypeoperation1 = new clsTypeoperation();
                        clsTypeoperation1.TO_CODETYPEOPERATION = row["TO_CODETYPEOPERATION"].ToString();
                        clsTypeoperation1.TO_LIBELLE = row["TO_LIBELLE"].ToString();
                        clsTypeoperation1.SL_CODEMESSAGE = "00";
                        clsTypeoperation1.SL_RESULTAT = "TRUE";
                        clsTypeoperation1.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsTypeoperation.Add(clsTypeoperation1);
                    }
                }
                else
                {
                    clsTypeoperation1.SL_CODEMESSAGE = "99";
                    clsTypeoperation1.SL_RESULTAT = "FALSE";
                    clsTypeoperation1.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsTypeoperation.Add(clsTypeoperation1);
                }


               // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation;
        }


        public List<clsTypeschemacomptable> pvgChargerDansDataSet3Operations(string DATEJOURNEE, string AG_CODEAGENCE, string OB_NOMOBJET ,string TO_CODETYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsTypeschemacomptable> clsTypeoperation = new List<clsTypeschemacomptable>();
            clsTypeschemacomptable clsTypeoperation1 = new clsTypeschemacomptable();


           


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(OB_NOMOBJET))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le nom de l'objet est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(TO_CODETYPEOPERATION))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, OB_NOMOBJET, SL_LOGIN, TO_CODETYPEOPERATION };
                DataSet DataSet = new DataSet();

                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSet3Operations(clsDonnee, clsObjetEnvoi);


                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        clsTypeoperation1 = new clsTypeschemacomptable();
                        clsTypeoperation1.TS_CODETYPESCHEMACOMPTABLE = row["TS_CODETYPESCHEMACOMPTABLE"].ToString();
                        clsTypeoperation1.TS_LIBELLE = row["TS_LIBELLE"].ToString();
                        clsTypeoperation1.TS_PREFIXECOMPTE = row["TS_PREFIXECOMPTE"].ToString();
                        clsTypeoperation1.SL_CODEMESSAGE = "00";
                        clsTypeoperation1.SL_RESULTAT = "TRUE";
                        clsTypeoperation1.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsTypeoperation.Add(clsTypeoperation1);
                    }
                }
                else
                {
                    clsTypeoperation1.SL_CODEMESSAGE = "99";
                    clsTypeoperation1.SL_RESULTAT = "FALSE";
                    clsTypeoperation1.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsTypeoperation.Add(clsTypeoperation1);
                }


                // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation;
        }



        public List<clsOperateur> pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(string DATEJOURNEE, string AG_CODEAGENCE,  string OP_JOURNEEOUVERTE,string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsOperateur> clsTypeoperation = new List<clsOperateur>();
            clsOperateur clsTypeoperation1 = new clsOperateur();


           


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(OP_CODEOPERATEUR))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le code de l'opérateur est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            //if (string.IsNullOrEmpty(OP_CAISSIER))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le statut caissier est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}




            if (string.IsNullOrEmpty(OP_JOURNEEOUVERTE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le statut journée ouverte est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE,  OP_JOURNEEOUVERTE, OP_CODEOPERATEUR };
                DataSet DataSet = new DataSet();

                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(clsDonnee, clsObjetEnvoi);


                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        clsTypeoperation1 = new clsOperateur();
                        clsTypeoperation1.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsTypeoperation1.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsTypeoperation1.SL_CODEMESSAGE = "00";
                        clsTypeoperation1.SL_RESULTAT = "TRUE";
                        clsTypeoperation1.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsTypeoperation.Add(clsTypeoperation1);
                    }
                }
                else
                {
                    clsTypeoperation1.SL_CODEMESSAGE = "99";
                    clsTypeoperation1.SL_RESULTAT = "FALSE";
                    clsTypeoperation1.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsTypeoperation.Add(clsTypeoperation1);
                }


                // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation;
        }



        public List<clsSchemacomptable> pvgChargerDansDataSetSC_SCHEMACOMPTABLECODE(string DATEJOURNEE, string AG_CODEAGENCE,  string OB_NOMOBJET, string SC_SCHEMACOMPTABLECODE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsSchemacomptable> clsTypeoperation = new List<clsSchemacomptable>();
            clsSchemacomptable clsTypeoperation1 = new clsSchemacomptable();


           


            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SC_SCHEMACOMPTABLECODE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le code du schema comptable est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            //if (string.IsNullOrEmpty(OP_CAISSIER))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le statut caissier est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}




            if (string.IsNullOrEmpty(OB_NOMOBJET))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le nom de l'objet est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, OB_NOMOBJET, SC_SCHEMACOMPTABLECODE };
                DataSet DataSet = new DataSet();

                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetSC_SCHEMACOMPTABLECODE(clsDonnee, clsObjetEnvoi);


                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        clsTypeoperation1 = new clsSchemacomptable();
                        clsTypeoperation1.SC_CODESCHEMACOMPTABLE = row["SC_CODESCHEMACOMPTABLE"].ToString();
                        clsTypeoperation1.SC_NUMEROORDRE = row["SC_NUMEROORDRE"].ToString();
                        clsTypeoperation1.TS_CODETYPESCHEMACOMPTABLE = row["TS_CODETYPESCHEMACOMPTABLE"].ToString();
                        clsTypeoperation1.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
                        clsTypeoperation1.CD_CODECONDITION = row["CD_CODECONDITION"].ToString();
                        clsTypeoperation1.ML_CODEMONTANTCALCULER = row["ML_CODEMONTANTCALCULER"].ToString();
                        //clsTypeoperation1.PS_CODESOUSPRODUIT = row["PS_CODESOUSPRODUIT"].ToString();
                        clsTypeoperation1.SC_SENS = row["SC_SENS"].ToString();
                        clsTypeoperation1.SC_COMPTABILISATIONJOURNAL = row["SC_COMPTABILISATIONJOURNAL"].ToString();
                        clsTypeoperation1.SC_MONTANTNUMERIQUE = row["SC_MONTANTNUMERIQUE"].ToString();
                        clsTypeoperation1.SC_BLOCAGECOMPTE = row["SC_BLOCAGECOMPTE"].ToString();
                        clsTypeoperation1.SC_LIGNECACHEE = row["SC_LIGNECACHEE"].ToString();
                        clsTypeoperation1.SC_AFFICHER = row["SC_AFFICHER"].ToString();
                        clsTypeoperation1.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsTypeoperation1.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsTypeoperation1.SC_LIBELLE = row["SC_LIBELLE"].ToString();
                        //clsTypeoperation1.MONTANT = row["MONTANT"].ToString();
                        clsTypeoperation1.TS_CODETYPESCHEMACOMPTABLESUIVANT = row["TS_CODETYPESCHEMACOMPTABLESUIVANT"].ToString();
                        clsTypeoperation1.SC_SENSBILLETAGE = row["SC_SENSBILLETAGE"].ToString();
                        clsTypeoperation1.SC_SCHEMACOMPTABLECODE = row["SC_SCHEMACOMPTABLECODE"].ToString();


                        clsTypeoperation1.SL_CODEMESSAGE = "00";
                        clsTypeoperation1.SL_RESULTAT = "TRUE";
                        clsTypeoperation1.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsTypeoperation.Add(clsTypeoperation1);
                    }
                }
                else
                {
                    clsTypeoperation1.SL_CODEMESSAGE = "99";
                    clsTypeoperation1.SL_RESULTAT = "FALSE";
                    clsTypeoperation1.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsTypeoperation.Add(clsTypeoperation1);
                }


                // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation;
        }



        public List<clsPlancomptable> pvgChargerDansDataSetPlancomptable(string DATEJOURNEE, string AG_CODEAGENCE,  string PL_NUMCOMPTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsPlancomptable> clsTypeoperation = new List<clsPlancomptable>();
            clsPlancomptable clsTypeoperation1 = new clsPlancomptable();

            string SO_CODESOCIETE = "0001";
            string PL_TYPECOMPTE = "I";



            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation;
            }

            //if (string.IsNullOrEmpty(SC_SCHEMACOMPTABLECODE))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le code du schema comptable est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}

            //if (string.IsNullOrEmpty(OP_CAISSIER))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le statut caissier est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}




            //if (string.IsNullOrEmpty(OB_NOMOBJET))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le nom de l'objet est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation;

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                    clsObjetEnvoi.OE_PARAM = new string[] { SO_CODESOCIETE, PL_NUMCOMPTE, PL_TYPECOMPTE };
                DataSet DataSet = new DataSet();

                DataSet = clsTontinewebWSBLL.pvgChargerDansDataSetPlancomptable(clsDonnee, clsObjetEnvoi);


                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        clsTypeoperation1 = new clsPlancomptable();
                        clsTypeoperation1.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsTypeoperation1.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsTypeoperation1.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                        clsTypeoperation1.SL_CODEMESSAGE = "00";
                        clsTypeoperation1.SL_RESULTAT = "TRUE";
                        clsTypeoperation1.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsTypeoperation.Add(clsTypeoperation1);
                    }
                }
                else
                {
                    clsTypeoperation1.SL_CODEMESSAGE = "99";
                    clsTypeoperation1.SL_RESULTAT = "FALSE";
                    clsTypeoperation1.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsTypeoperation.Add(clsTypeoperation1);
                }


                // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation;
        }


        public clsSchemacomptable pvgTableLabelSchemacomptable(string DATEJOURNEE, string AG_CODEAGENCE, string TS_CODETYPESCHEMACOMPTABLE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsSchemacomptable> clsTypeoperation = new List<clsSchemacomptable>();
            clsSchemacomptable clsTypeoperation1 = new clsSchemacomptable();





            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(TS_CODETYPESCHEMACOMPTABLE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = "Le code du type schema comptable est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation[0];
            }

            


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                clsObjetEnvoi.OE_PARAM = new string[] {TS_CODETYPESCHEMACOMPTABLE};
                DataSet DataSet = new DataSet();
                 clsTypeoperation1 = new clsSchemacomptable();
                clsTypeoperation1 = clsTontinewebWSBLL.pvgTableLabelSchemacomptable(clsDonnee, clsObjetEnvoi);
                clsTypeoperation.Add(clsTypeoperation1);

                
               


                // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            catch (Exception SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation[0];
        }




        public clsResultat pvgAjouterComptabilisation(clsObjetversement clsObjetversement, string DATEJOURNEE, string AG_CODEAGENCE,   string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsResultat> clsTypeoperation = new List<clsResultat>();
            clsResultat clsTypeoperation1 = new clsResultat();

            string SO_CODESOCIETE = "0001";
            string PL_TYPECOMPTE = "I";



            //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,


            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);
                return clsTypeoperation[0];
            }

            //if (string.IsNullOrEmpty(SC_SCHEMACOMPTABLECODE))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le code du schema comptable est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}

            //if (string.IsNullOrEmpty(OP_CAISSIER))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le statut caissier est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}




            //if (string.IsNullOrEmpty(OB_NOMOBJET))
            //{

            //    //----EXEPTION
            //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
            //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0074", "01");
            //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
            //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
            //    clsTypeoperation1.SL_MESSAGE = "Le nom de l'objet est obligatoire !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
            //    clsTypeoperation.Add(clsTypeoperation1);
            //    return clsTypeoperation;
            //}


            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebResultat clsMiccomptewebUserLogin1 = new clsMiccomptewebResultat();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }
            if (string.IsNullOrEmpty(SL_VERSIONAPK))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }


            if (string.IsNullOrEmpty(SL_LOGIN))
            {

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(SL_MOTDEPASSE))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];
            }

            if (string.IsNullOrEmpty(SL_CLESESSION))
            {
                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
                clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsTypeoperation.Add(clsTypeoperation1);

                return clsTypeoperation[0];

            }




            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();

                //----VERIFICATION DE LA CLE DE SESSION
                //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, "03");

                //if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
                //{

                //    clsTypeoperation1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                //    clsTypeoperation1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                //    clsTypeoperation1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                //    clsTypeoperation.Add(clsTypeoperation1);

                //    return clsTypeoperation;
                //}
                //--

                List<clsEtatmouvementacomptabiliser> clsEtatmouvementacomptabilisers1 = new List<clsEtatmouvementacomptabiliser>();
                List<clsEtatmouvementacomptabiliser> clsEtatmouvementacomptabilisers2 = new List<clsEtatmouvementacomptabiliser>();
                List<clsEtatmouvementacomptabiliser> clsEtatmouvementacomptabilisers3 = new List<clsEtatmouvementacomptabiliser>();
                List<clsBilletage> clsBilletages = new List<clsBilletage>();

                if (clsObjetversement.clsEtatmouvementacomptabilisers1 != null)
                foreach (clsEtatmouvementacomptabiliserDTO clsEtatmouvementacomptabilisers1DTO in clsObjetversement.clsEtatmouvementacomptabilisers1)
                {
                    clsEtatmouvementacomptabiliser clsEtatmouvementacomptabiliser1 = new clsEtatmouvementacomptabiliser();
                    if (clsEtatmouvementacomptabilisers1DTO.EM_DATEPIECE.ToString() != "")
                        clsEtatmouvementacomptabiliser1.EM_DATEPIECE =DateTime.Parse(clsEtatmouvementacomptabilisers1DTO.EM_DATEPIECE.ToString());
                    clsEtatmouvementacomptabiliser1.EM_NUMEROSEQUENCE = clsEtatmouvementacomptabilisers1DTO.EM_NUMEROSEQUENCE.ToString();
                    clsEtatmouvementacomptabiliser1.AG_CODEAGENCE = clsEtatmouvementacomptabilisers1DTO.AG_CODEAGENCE.ToString();
                    clsEtatmouvementacomptabiliser1.PV_CODEPOINTVENTE = clsEtatmouvementacomptabilisers1DTO.PV_CODEPOINTVENTE.ToString();
                    clsEtatmouvementacomptabiliser1.MB_IDTIERS = clsEtatmouvementacomptabilisers1DTO.MB_IDTIERS.ToString();
                    clsEtatmouvementacomptabiliser1.CO_CODECOMPTE = clsEtatmouvementacomptabilisers1DTO.CO_CODECOMPTE.ToString();
                    clsEtatmouvementacomptabiliser1.PL_CODENUMCOMPTE = clsEtatmouvementacomptabilisers1DTO.PL_CODENUMCOMPTE.ToString();
                    clsEtatmouvementacomptabiliser1.EM_REFERENCEPIECE = clsEtatmouvementacomptabilisers1DTO.EM_REFERENCEPIECE.ToString();
                    clsEtatmouvementacomptabiliser1.EM_LIBELLEOPERATION = clsEtatmouvementacomptabilisers1DTO.EM_LIBELLEOPERATION.ToString();
                    clsEtatmouvementacomptabiliser1.EM_NOMOBJET = clsEtatmouvementacomptabilisers1DTO.EM_NOMOBJET.ToString();
                    clsEtatmouvementacomptabiliser1.TS_CODETYPESCHEMACOMPTABLE = clsEtatmouvementacomptabilisers1DTO.TS_CODETYPESCHEMACOMPTABLE.ToString();
                    clsEtatmouvementacomptabiliser1.EM_SCHEMACOMPTABLECODE = clsEtatmouvementacomptabilisers1DTO.EM_SCHEMACOMPTABLECODE.ToString();
                    clsEtatmouvementacomptabiliser1.EM_SENSBILLETAGE = clsEtatmouvementacomptabilisers1DTO.EM_SENSBILLETAGE.ToString();
                    if(clsEtatmouvementacomptabilisers1DTO.EM_MONTANT.ToString()!="")
                    clsEtatmouvementacomptabiliser1.EM_MONTANT =double.Parse( clsEtatmouvementacomptabilisers1DTO.EM_MONTANT.ToString());
                    clsEtatmouvementacomptabiliser1.SC_LIGNECACHEE =clsEtatmouvementacomptabilisers1DTO.SC_LIGNECACHEE.ToString();
                    clsEtatmouvementacomptabiliser1.OP_CODEOPERATEUR = clsEtatmouvementacomptabilisers1DTO.OP_CODEOPERATEUR.ToString();
                    clsEtatmouvementacomptabiliser1.EM_NOMTIERS = clsEtatmouvementacomptabilisers1DTO.EM_NOMTIERS.ToString();
                    clsEtatmouvementacomptabiliser1.PI_CODEPIECE = clsEtatmouvementacomptabilisers1DTO.PI_CODEPIECE.ToString();
                    clsEtatmouvementacomptabiliser1.EM_NUMPIECETIERS = clsEtatmouvementacomptabilisers1DTO.EM_NUMPIECETIERS.ToString();
                    //--
                    clsEtatmouvementacomptabilisers1.Add(clsEtatmouvementacomptabiliser1);
                }

                if(clsObjetversement.clsEtatmouvementacomptabilisers2!=null)
                foreach (clsEtatmouvementacomptabiliserDTO clsEtatmouvementacomptabilisers2DTO in clsObjetversement.clsEtatmouvementacomptabilisers2)
                {
                    clsEtatmouvementacomptabiliser clsEtatmouvementacomptabiliser2 = new clsEtatmouvementacomptabiliser();
                    if (clsEtatmouvementacomptabilisers2DTO.EM_DATEPIECE.ToString() != "")
                        clsEtatmouvementacomptabiliser2.EM_DATEPIECE = DateTime.Parse(clsEtatmouvementacomptabilisers2DTO.EM_DATEPIECE.ToString());
                    clsEtatmouvementacomptabiliser2.EM_NUMEROSEQUENCE = clsEtatmouvementacomptabilisers2DTO.EM_NUMEROSEQUENCE.ToString();
                    clsEtatmouvementacomptabiliser2.AG_CODEAGENCE = clsEtatmouvementacomptabilisers2DTO.AG_CODEAGENCE.ToString();
                    clsEtatmouvementacomptabiliser2.PV_CODEPOINTVENTE = clsEtatmouvementacomptabilisers2DTO.PV_CODEPOINTVENTE.ToString();
                    clsEtatmouvementacomptabiliser2.MB_IDTIERS = clsEtatmouvementacomptabilisers2DTO.MB_IDTIERS.ToString();
                    clsEtatmouvementacomptabiliser2.CO_CODECOMPTE = clsEtatmouvementacomptabilisers2DTO.CO_CODECOMPTE.ToString();
                    clsEtatmouvementacomptabiliser2.PL_CODENUMCOMPTE = clsEtatmouvementacomptabilisers2DTO.PL_CODENUMCOMPTE.ToString();
                    clsEtatmouvementacomptabiliser2.EM_REFERENCEPIECE = clsEtatmouvementacomptabilisers2DTO.EM_REFERENCEPIECE.ToString();
                    clsEtatmouvementacomptabiliser2.EM_LIBELLEOPERATION = clsEtatmouvementacomptabilisers2DTO.EM_LIBELLEOPERATION.ToString();
                    clsEtatmouvementacomptabiliser2.EM_NOMOBJET = clsEtatmouvementacomptabilisers2DTO.EM_NOMOBJET.ToString();
                    clsEtatmouvementacomptabiliser2.TS_CODETYPESCHEMACOMPTABLE = clsEtatmouvementacomptabilisers2DTO.TS_CODETYPESCHEMACOMPTABLE.ToString();
                    clsEtatmouvementacomptabiliser2.EM_SCHEMACOMPTABLECODE = clsEtatmouvementacomptabilisers2DTO.EM_SCHEMACOMPTABLECODE.ToString();
                    clsEtatmouvementacomptabiliser2.EM_SENSBILLETAGE = clsEtatmouvementacomptabilisers2DTO.EM_SENSBILLETAGE.ToString();
                    if (clsEtatmouvementacomptabilisers2DTO.EM_MONTANT.ToString() != "")
                        clsEtatmouvementacomptabiliser2.EM_MONTANT = double.Parse(clsEtatmouvementacomptabilisers2DTO.EM_MONTANT.ToString());
                    clsEtatmouvementacomptabiliser2.SC_LIGNECACHEE = clsEtatmouvementacomptabilisers2DTO.SC_LIGNECACHEE.ToString();
                    clsEtatmouvementacomptabiliser2.OP_CODEOPERATEUR = clsEtatmouvementacomptabilisers2DTO.OP_CODEOPERATEUR.ToString();
                    clsEtatmouvementacomptabiliser2.EM_NOMTIERS = clsEtatmouvementacomptabilisers2DTO.EM_NOMTIERS.ToString();
                    clsEtatmouvementacomptabiliser2.PI_CODEPIECE = clsEtatmouvementacomptabilisers2DTO.PI_CODEPIECE.ToString();
                    clsEtatmouvementacomptabiliser2.EM_NUMPIECETIERS = clsEtatmouvementacomptabilisers2DTO.EM_NUMPIECETIERS.ToString();
                    //--
                    clsEtatmouvementacomptabilisers2.Add(clsEtatmouvementacomptabiliser2);
                }
                if (clsObjetversement.clsEtatmouvementacomptabilisers3 != null)
                foreach (clsEtatmouvementacomptabiliserDTO clsEtatmouvementacomptabilisers3DTO in clsObjetversement.clsEtatmouvementacomptabilisers3)
                {
                    clsEtatmouvementacomptabiliser clsEtatmouvementacomptabiliser3 = new clsEtatmouvementacomptabiliser();
                    if (clsEtatmouvementacomptabilisers3DTO.EM_DATEPIECE.ToString() != "")
                        clsEtatmouvementacomptabiliser3.EM_DATEPIECE = DateTime.Parse(clsEtatmouvementacomptabilisers3DTO.EM_DATEPIECE.ToString());
                    clsEtatmouvementacomptabiliser3.EM_NUMEROSEQUENCE = clsEtatmouvementacomptabilisers3DTO.EM_NUMEROSEQUENCE.ToString();
                    clsEtatmouvementacomptabiliser3.AG_CODEAGENCE = clsEtatmouvementacomptabilisers3DTO.AG_CODEAGENCE.ToString();
                    clsEtatmouvementacomptabiliser3.PV_CODEPOINTVENTE = clsEtatmouvementacomptabilisers3DTO.PV_CODEPOINTVENTE.ToString();
                    clsEtatmouvementacomptabiliser3.MB_IDTIERS = clsEtatmouvementacomptabilisers3DTO.MB_IDTIERS.ToString();
                    clsEtatmouvementacomptabiliser3.CO_CODECOMPTE = clsEtatmouvementacomptabilisers3DTO.CO_CODECOMPTE.ToString();
                    clsEtatmouvementacomptabiliser3.PL_CODENUMCOMPTE = clsEtatmouvementacomptabilisers3DTO.PL_CODENUMCOMPTE.ToString();
                    clsEtatmouvementacomptabiliser3.EM_REFERENCEPIECE = clsEtatmouvementacomptabilisers3DTO.EM_REFERENCEPIECE.ToString();
                    clsEtatmouvementacomptabiliser3.EM_LIBELLEOPERATION = clsEtatmouvementacomptabilisers3DTO.EM_LIBELLEOPERATION.ToString();
                    clsEtatmouvementacomptabiliser3.EM_NOMOBJET = clsEtatmouvementacomptabilisers3DTO.EM_NOMOBJET.ToString();
                    clsEtatmouvementacomptabiliser3.TS_CODETYPESCHEMACOMPTABLE = clsEtatmouvementacomptabilisers3DTO.TS_CODETYPESCHEMACOMPTABLE.ToString();
                    clsEtatmouvementacomptabiliser3.EM_SCHEMACOMPTABLECODE = clsEtatmouvementacomptabilisers3DTO.EM_SCHEMACOMPTABLECODE.ToString();
                    clsEtatmouvementacomptabiliser3.EM_SENSBILLETAGE = clsEtatmouvementacomptabilisers3DTO.EM_SENSBILLETAGE.ToString();
                    if (clsEtatmouvementacomptabilisers3DTO.EM_MONTANT.ToString() != "")
                        clsEtatmouvementacomptabiliser3.EM_MONTANT = double.Parse(clsEtatmouvementacomptabilisers3DTO.EM_MONTANT.ToString());
                    clsEtatmouvementacomptabiliser3.SC_LIGNECACHEE = clsEtatmouvementacomptabilisers3DTO.SC_LIGNECACHEE.ToString();
                    clsEtatmouvementacomptabiliser3.OP_CODEOPERATEUR = clsEtatmouvementacomptabilisers3DTO.OP_CODEOPERATEUR.ToString();
                    clsEtatmouvementacomptabiliser3.EM_NOMTIERS = clsEtatmouvementacomptabilisers3DTO.EM_NOMTIERS.ToString();
                    clsEtatmouvementacomptabiliser3.PI_CODEPIECE = clsEtatmouvementacomptabilisers3DTO.PI_CODEPIECE.ToString();
                    clsEtatmouvementacomptabiliser3.EM_NUMPIECETIERS = clsEtatmouvementacomptabilisers3DTO.EM_NUMPIECETIERS.ToString();
                    //--
                    clsEtatmouvementacomptabilisers3.Add(clsEtatmouvementacomptabiliser3);
                }

                if (clsObjetversement.clsBilletages != null)
                foreach (clsBilletageDTO clsBilletagesDTO in clsObjetversement.clsBilletages)
                {
                    clsBilletage clsBilletage = new clsBilletage();
                    clsBilletage.AG_CODEAGENCE = clsBilletagesDTO.AG_CODEAGENCE.ToString();
                    if (clsBilletagesDTO.MC_DATEPIECE.ToString() != "")
                        clsBilletage.MC_DATEPIECE = DateTime.Parse(clsBilletagesDTO.MC_DATEPIECE.ToString());
                    clsBilletage.MC_NUMPIECE = clsBilletagesDTO.MC_NUMPIECE.ToString();

                    clsBilletage.BI_NUMPIECE = clsBilletagesDTO.BI_NUMPIECE.ToString();
                    clsBilletage.BI_NUMSEQUENCE = clsBilletagesDTO.BI_NUMSEQUENCE.ToString();
                    clsBilletage.MC_NUMSEQUENCE = clsBilletagesDTO.MC_NUMSEQUENCE.ToString();
                    clsBilletage.CB_CODECOUPURE = clsBilletagesDTO.CB_CODECOUPURE.ToString();
                    clsBilletage.PL_CODENUMCOMPTE = clsBilletagesDTO.PL_CODENUMCOMPTE.ToString();
                    if (clsBilletagesDTO.BI_QUANTITEENTREE.ToString() != "")
                        clsBilletage.BI_QUANTITEENTREE =int.Parse(clsBilletagesDTO.BI_QUANTITEENTREE.ToString());
                    if (clsBilletagesDTO.BI_QUANTITESORTIE.ToString() != "")
                        clsBilletage.BI_QUANTITESORTIE = int.Parse(clsBilletagesDTO.BI_QUANTITESORTIE.ToString());
                    clsBilletage.TYPEOPERATION = clsBilletagesDTO.TYPEOPERATION.ToString();
                    //--
                    clsBilletages.Add(clsBilletage);
                }


                // clsObjetEnvoi.OE_PARAM = new string[] { SO_CODESOCIETE, PL_NUMCOMPTE, PL_TYPECOMPTE };
                DataSet DataSet = new DataSet();

                string vlpNumeroBorderau = "";

                vlpNumeroBorderau = clsTontinewebWSBLL.pvgAjouterComptabilisation(clsDonnee, clsEtatmouvementacomptabilisers1, clsEtatmouvementacomptabilisers2, clsEtatmouvementacomptabilisers3, clsBilletages, clsObjetEnvoi);


                if (vlpNumeroBorderau !="")
                {
                  
                        clsTypeoperation1 = new clsResultat();
                        clsTypeoperation1.SL_NUMEROBORDERAU = vlpNumeroBorderau;
                        clsTypeoperation1.SL_CODEMESSAGE = "00";
                        clsTypeoperation1.SL_RESULTAT = "TRUE";
                        clsTypeoperation1.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsTypeoperation.Add(clsTypeoperation1);
                    
                }
                else
                {
                    clsTypeoperation1.SL_CODEMESSAGE = "99";
                    clsTypeoperation1.SL_RESULTAT = "FALSE";
                    clsTypeoperation1.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsTypeoperation.Add(clsTypeoperation1);
                }


                // clsTypeoperation =3


            }
            catch (SqlException SQLEx)
            {

                clsTypeoperation1.SL_CODEMESSAGE = "99";
                clsTypeoperation1.SL_RESULTAT = "FALSE";
                clsTypeoperation1.SL_MESSAGE = SQLEx.Message+" !!!";
                clsTypeoperation.Add(clsTypeoperation1);

                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception e)
            {
                clsTypeoperation1.SL_CODEMESSAGE = "99";
                clsTypeoperation1.SL_RESULTAT = "FALSE";
                clsTypeoperation1.SL_MESSAGE = e.Message + " !!!";
                clsTypeoperation.Add(clsTypeoperation1);
                clsObjetRetour.SetValueMessage(false, e.Message);

            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsTypeoperation[0];
        }


        public clsMiccomptewebUserLogin pvgDownloadPhotoSignature(string DATEJOURNEE, string NOMIMAGE, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
            bool vlpTest = false;
            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogin = new List<clsMiccomptewebUserLogin>();

            LG_CODELANGUE = "fr";

            if (string.IsNullOrEmpty(LG_CODELANGUE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(OS_MACADRESSE))
            {

                //----EXEPTION
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }

            if (string.IsNullOrEmpty(NOMIMAGE))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0264", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (string.IsNullOrEmpty(TYPEOPERATION))
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }


            if (TYPEOPERATION != "01" && TYPEOPERATION != "02")
            {
                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();

                //----EXEPTION
                clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
                clsMiccomptewebUserLogin1.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                clsMiccomptewebUserLogin1.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
                clsMiccomptewebUserLogin1.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);

                return clsMiccomptewebUserLogin[0];
            }






            try
            {
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsMiccomptewebUserLogin = clsTontinewebWSBLL.pvgDownloadPhotoSignature(clsDonnee, NOMIMAGE, TYPEOPERATION, LG_CODELANGUE);
            }
            catch (SqlException SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            catch (Exception SQLEx)
            {

                clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();
                clsMiccomptewebUserLogin1.SL_RESULTAT = "FALSE";
                clsMiccomptewebUserLogin1.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebUserLogin.Add(clsMiccomptewebUserLogin1);
                vlpTest = true;
            }
            finally
            {
                //if (vlpTest==false)
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsMiccomptewebUserLogin[0];
        }



        //++++++++++++++++++++++++++++++++++CINET
        public List<clsCinetpay> pvgDemendetoken(clsCinetpaytoken clsCinetpaytoken)
        {
            clsCinetpay obj = new clsCinetpay();
            List<clsCinetpay> objList = new List<clsCinetpay>();
            try
            {


                var request = (HttpWebRequest)WebRequest.Create("https://client.cinetpay.com/v1/auth/login?lang=fr");
                StringBuilder postData = new StringBuilder();
                postData.Append("apikey=" + HttpUtility.UrlEncode(clsCinetpaytoken.Apikey) + "&");
                postData.Append("password=" + HttpUtility.UrlEncode(clsCinetpaytoken.Password) + "&");

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(postData);
                }
                //if (IsNetworkConnected())
                //{
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //  string NewISOmsg = responseString.Replace("\"", "");
                obj = JsonConvert.DeserializeObject<clsCinetpay>(responseString);
                objList.Add(obj);
                //}
                //else objList = null;

            }
            catch (Exception e)
            {
                var dat = e.Message;

            }


            //watch.Stop();
            // TempData["time"] = watch.ElapsedMilliseconds;
            return objList;
        }




        public List<clsDataContact> pvgAddContact(List<clsCinetpayContact> listclsCinetpayContact, clsDataToken clsDataTokens)
        {
            clsDataContact obj = new clsDataContact();
            List<clsDataContact> objList = new List<clsDataContact>();
            try
            {
                var token = clsDataTokens.token;

                var request = (HttpWebRequest)WebRequest.Create("https://client.cinetpay.com/v1/transfer/contact?token=" + token + "&lang=fr");
                StringBuilder postData = new StringBuilder();
                //postData.Append("token=" + HttpUtility.UrlEncode(token) + "&");
                //postData.Append("lang=" + HttpUtility.UrlEncode("fr") + "&");
                var json = JsonConvert.SerializeObject(listclsCinetpayContact);
                postData.Append("data=" + HttpUtility.UrlEncode(json));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                //for (int Idx = 0; Idx < listclsCinetpayContact.Count; Idx++)
                //{
                //    clsCinetpayContact uncontact = new clsCinetpayContact();
                //     uncontact.Prefix= listclsCinetpayContact[Idx].Prefix;
                //    uncontact.Phone = listclsCinetpayContact[Idx].Phone;
                //    uncontact.Name = listclsCinetpayContact[Idx].Name;
                //    uncontact.Surname = listclsCinetpayContact[Idx].Surname;
                //    uncontact.Email = listclsCinetpayContact[Idx].Email;

                //}

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(postData);
                }
                //if (IsNetworkConnected())
                //{
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var NewISOmsg = responseString;
                NewISOmsg = responseString.Replace("[[", "[");
                NewISOmsg = NewISOmsg.Replace("]]", "]");
                obj = JsonConvert.DeserializeObject<clsDataContact>(NewISOmsg);
                objList.Add(obj);
                //}
                //else objList = null;

            }
            catch (Exception e)
            {
                var dat = e.Message;

            }

            //watch.Stop();
            // TempData["time"] = watch.ElapsedMilliseconds;
            return objList;
        }


        public List<clsDataTransferts> pvgAddTransfert(List<clsCinetpayMoneyContac> ListclsCinetpayMoneyContac, clsDataToken clsDataTokens)
        {
            clsDataTransferts obj = new clsDataTransferts();
            List<clsDataTransferts> objList = new List<clsDataTransferts>();
            try
            {
                var token = clsDataTokens.token;

                var request = (HttpWebRequest)WebRequest.Create("https://client.cinetpay.com/v1/transfer/money/send/contact?token=" + token + "&lang=fr");


                StringBuilder postData = new StringBuilder();
                //postData.Append("token=" + HttpUtility.UrlEncode(token) );
                //postData.Append("&lang=" + HttpUtility.UrlEncode("fr") );
                var json = JsonConvert.SerializeObject(ListclsCinetpayMoneyContac);
                postData.Append("data=" + HttpUtility.UrlEncode(json));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                //request.AllowAutoRedirect = true;
                //request.Credentials = CredentialCache.DefaultCredentials;

                //for (int Idx = 0; Idx < listclsCinetpayContact.Count; Idx++)
                //{
                //    clsCinetpayContact uncontact = new clsCinetpayContact();
                //     uncontact.Prefix= listclsCinetpayContact[Idx].Prefix;
                //    uncontact.Phone = listclsCinetpayContact[Idx].Phone;
                //    uncontact.Name = listclsCinetpayContact[Idx].Name;
                //    uncontact.Surname = listclsCinetpayContact[Idx].Surname;
                //    uncontact.Email = listclsCinetpayContact[Idx].Email;

                //}

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                //System.Net.ServicePointManager.Expect100Continue = false;
                System.Net.ServicePointManager.Expect100Continue = false;



                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(postData);
                }
                //if (IsNetworkConnected())
                //{
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var NewISOmsg = responseString;
                NewISOmsg = responseString.Replace("[[", "[");
                NewISOmsg = NewISOmsg.Replace("]]", "]");
                //obj = JsonConvert.DeserializeObject<clsDataTransferts>(NewISOmsg);
                //objList.Add(obj);
                //}
                //else objList = null;

                obj = JsonConvert.DeserializeObject<clsDataTransferts>(NewISOmsg);
                objList.Add(obj);

            }
            catch (Exception e)
            {
                var dat = e.Message;

            }

            //watch.Stop();
            // TempData["time"] = watch.ElapsedMilliseconds;
            return objList;
        }
        //++++++++++++++++++++++++++++++++++


        public void SendMessage(string smsText, string indicatif, string recipientPhone, string AG_CODEAGENCE)
        {
            //string customerID ="03544";// clsSmsoperateurdetelephoniecompteclient.CL_IDCLINENT;// System.Configuration.ConfigurationManager.AppSettings["customerID"];
            //string userName ="kouassi";// clsSmsoperateurdetelephoniecompteclient.CL_NOMUTILISATEUR;// System.Configuration.ConfigurationManager.AppSettings["userName"];
            //string userPassword ="12345";// clsSmsoperateurdetelephoniecompteclient.CL_MOTDEPASSE;// System.Configuration.ConfigurationManager.AppSettings["userPassword"];
            //string originator ="CMEC";// clsSmsoperateurdetelephoniecompteclient.CL_EMETTEUR;// System.Configuration.ConfigurationManager.AppSettings["originator"];
            //string defDate ="19/06/2017";// clsDeclaration.vagJourneetravail.JT_DATEJOURNEETRAVAIL.ToString();//System.Configuration.ConfigurationManager.AppSettings["defDate"];//"AAAAMMMJJHHMMSS";
            //string blink ="false";// System.Configuration.ConfigurationManager.AppSettings["blink"];//"false";
            //string flash = "false";//System.Configuration.ConfigurationManager.AppSettings["flash"];//"false";
            //string Private ="false";// System.Configuration.ConfigurationManager.AppSettings["Private"]; //"true";




            string sURL;
            StreamReader objReader;


            List<clsSmsoperateurdetlephoniecompteclient> clsSmsoperateurdetlephoniecompteclients = new List<clsSmsoperateurdetlephoniecompteclient>();
            //clsSmsoperateurdetlephoniecompteclient = new clsSmsoperateurdetlephoniecompteclient();

            //clsSmsoperateurdetlephoniecompteclientWSBLL clsSmsoperateurdetlephoniecompteclientWSBLL = new WSBLL.clsSmsoperateurdetlephoniecompteclientWSBLL();
            //clsSmsoperateurdetlephoniecompteclient = clsTontinewebWSBLL.pvgListeTelephonie(clsDonnee, "");

            clsSmsoperateurdetlephoniecompteclients = clsTontinewebWSBLL.pvgListeCompteSms(clsDonnee, AG_CODEAGENCE);

            string userId = "193964";//clsSmsoperateurdetlephoniecompteclients[0].CL_IDCLINENT;//
            string senderId = "193965"; //clsSmsoperateurdetlephoniecompteclients[0].CL_NOMUTILISATEUR;
            string phone = indicatif + recipientPhone;
            smsText = smsText.Replace("l'", "l");
            //sURL = "http://smspro.mtn.ci/smspro/Soap/Messenger.asmx/HTTP_SendSms?customerID=" + customerID + "&userName=" + userName + "&userPassword=" + userPassword + "&originator=" + originator + "&messageType=Latin&defDate=&blink=" + blink + "&flash=" + flash + "&Private=" + Private + "&recipientPhone=" + recipientPhone + "&smsText=" + smsText;
            sURL = "http://www.sms365pro.com/api/1/sendsms/basic?userId=" + userId + "&senderId=" + senderId + "&phone=" + phone + "&content=" + smsText;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void SendMessage(string smsText, string indicatif, string recipientPhone, string AG_CODEAGENCE, string SM_DATEPIECE, string SM_NUMSEQUENCE, string SM_RAISONNONENVOISMS)
        {
            //string customerID ="03544";// clsSmsoperateurdetelephoniecompteclient.CL_IDCLINENT;// System.Configuration.ConfigurationManager.AppSettings["customerID"];
            //string userName ="kouassi";// clsSmsoperateurdetelephoniecompteclient.CL_NOMUTILISATEUR;// System.Configuration.ConfigurationManager.AppSettings["userName"];
            //string userPassword ="12345";// clsSmsoperateurdetelephoniecompteclient.CL_MOTDEPASSE;// System.Configuration.ConfigurationManager.AppSettings["userPassword"];
            //string originator ="CMEC";// clsSmsoperateurdetelephoniecompteclient.CL_EMETTEUR;// System.Configuration.ConfigurationManager.AppSettings["originator"];
            //string defDate ="19/06/2017";// clsDeclaration.vagJourneetravail.JT_DATEJOURNEETRAVAIL.ToString();//System.Configuration.ConfigurationManager.AppSettings["defDate"];//"AAAAMMMJJHHMMSS";
            //string blink ="false";// System.Configuration.ConfigurationManager.AppSettings["blink"];//"false";
            //string flash = "false";//System.Configuration.ConfigurationManager.AppSettings["flash"];//"false";
            //string Private ="false";// System.Configuration.ConfigurationManager.AppSettings["Private"]; //"true";


            List<clsSmsoperateurdetlephoniecompteclient> clsSmsoperateurdetlephoniecompteclients = new List<clsSmsoperateurdetlephoniecompteclient>();
            clsSmsoperateurdetlephoniecompteclients = clsTontinewebWSBLL.pvgListeCompteSms(clsDonnee, AG_CODEAGENCE);
            string API = clsSmsoperateurdetlephoniecompteclients[0].CL_TYPEURL;
            string userId = clsSmsoperateurdetlephoniecompteclients[0].CL_IDCLINENT;// "193964";
            string senderId = clsSmsoperateurdetlephoniecompteclients[0].CL_NOMUTILISATEUR;// "193965";
            string senderName = clsSmsoperateurdetlephoniecompteclients[0].CL_EMETTEUR;// 
            string phone = indicatif + recipientPhone;
            smsText = smsText.Replace("l'", "l");
            smsText = smsText.Replace("'", " ");
            smsText = smsText.Replace("é", "e");
            smsText = smsText.Replace("è", "e");
            smsText = smsText.Replace("ê", "e");
            string Authheader = clsSmsoperateurdetlephoniecompteclients[0].CL_NOMUTILISATEUR + ":" + clsSmsoperateurdetlephoniecompteclients[0].CL_MOTDEPASSE;
            Authheader = Base64Encode(Authheader);

            string customerID = clsSmsoperateurdetlephoniecompteclients[0].CL_IDCLINENT;// System.Configuration.ConfigurationManager.AppSettings["customerID"];
            string userName = clsSmsoperateurdetlephoniecompteclients[0].CL_NOMUTILISATEUR;// System.Configuration.ConfigurationManager.AppSettings["userName"];
            string userPassword = clsSmsoperateurdetlephoniecompteclients[0].CL_MOTDEPASSE;// System.Configuration.ConfigurationManager.AppSettings["userPassword"];
            string originator = clsSmsoperateurdetlephoniecompteclients[0].CL_EMETTEUR;// System.Configuration.ConfigurationManager.AppSettings["originator"];
                                                                                       //string defDate = clsDeclaration.vagJourneetravail.JT_DATEJOURNEETRAVAIL.ToString();//System.Configuration.ConfigurationManager.AppSettings["defDate"];//"AAAAMMMJJHHMMSS";
            string blink = System.Configuration.ConfigurationManager.AppSettings["blink"];//"false";
            string flash = System.Configuration.ConfigurationManager.AppSettings["flash"];//"false";
            string Private = System.Configuration.ConfigurationManager.AppSettings["Private"]; //"true";


            string Url = clsSmsoperateurdetlephoniecompteclients[0].CL_URL;
            Url = Url.Replace("*customerID*", customerID);
            Url = Url.Replace("*userName*", userName);
            Url = Url.Replace("*userPassword*", userPassword);
            Url = Url.Replace("*originator*", originator);

            Url = Url.Replace("*IdClient*", userName);
            Url = Url.Replace("*IdSender*", userPassword);


            //Url = Url.Replace("*blink*", blink);
            //Url = Url.Replace("*flash*", flash);
            //Url = Url.Replace("*Private*", Private);
            Url = Url.Replace("*recipientPhone*", phone);
            Url = Url.Replace("*smsText*", smsText);

            string sURL;

            StreamReader objReader;


            if (API == "RESTFUL")
            {

                //================================INFOBIP
                string webAddr = Url;// "https://api.infobip.com/sms/1/text/single";// ok
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);// ok
                httpWebRequest.ContentType = "application/json";// ok
                httpWebRequest.Accept = "application/json";// ok
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                //==========================================================================================================
                // Le login : TECHNOLOGYH
                //Le mot de passe : Dev1HoM6
                //TECHNOLOGYH:Dev1HoM6= (VEVDSE5PTE9HWUg6RGV2MUhvTTY=) c'est la combinaison du login et du mot de passe  . 
                //--le cryptage de cette combinaison peut se faire sur le site https://www.base64encode.org/ 
                //===========================================================================================================

                try
                {
                    httpWebRequest.Headers.Add("Authorization", " Basic " + Authheader);
                    httpWebRequest.Method = "POST";// ok

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"from\":\"" + senderName + "\", \"to\":\"" + phone + "\",\"text\":\"" + smsText + "\"}";
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();

                        //--
                        SM_RAISONNONENVOISMS = "OK";
                        clsTontinewebWSBLL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, "E", SM_RAISONNONENVOISMS);
                        //--

                        //return result;
                    }
                }

                catch (Exception ex)
                {
                    SM_RAISONNONENVOISMS = ex.ToString();
                    clsTontinewebWSBLL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, "N", SM_RAISONNONENVOISMS);
                    ex.ToString();
                }

            }



            if (API == "HTTP")
            {
                sURL = Url;

                //sURL = "http://www.sms365pro.com/api/1/sendsms/basic?userId=" + userId + "&senderId=" + senderId + "&phone=" + phone + "&content=" + smsText;
                //sURL = "http://africasmshub.mondialsms.net/api/api_http.php?username=" + userId + "&password=" + senderId + "&sender=CREDIT%20FEF&to=" + phone + "&text=" + smsText + "&type=text";
                //sURL = "http://smspro.mtn.ci/smspro/Soap/Messenger.asmx/HTTP_SendSms?customerID=" + customerID + "&userName=" + userName + "&userPassword=" + userPassword + "&originator=" + originator + "&messageType=Latin&defDate=&blink=" + blink + "&flash=" + flash + "&Private=" + Private + "&recipientPhone=" + recipientPhone + "&smsText=" + smsText;

                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                try
                {
                    Stream objStream;
                    objStream = wrGETURL.GetResponse().GetResponseStream();
                    objReader = new StreamReader(objStream);
                    objReader.Close();
                    //--
                    SM_RAISONNONENVOISMS = "OK";
                    clsTontinewebWSBLL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, "E", SM_RAISONNONENVOISMS);
                    //--


                }
                catch (Exception ex)
                {
                    SM_RAISONNONENVOISMS = ex.ToString();
                    clsTontinewebWSBLL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, "N", SM_RAISONNONENVOISMS);
                    ex.ToString();


                }
            }

            if (API == "HTTPS")
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                    //request.Method = "HEAD";
                    //request.AllowAutoRedirect = false;
                    request.Credentials = CredentialCache.DefaultCredentials;

                    // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
                    ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream resStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    string responseFromServer = reader.ReadToEnd();
                    //--
                    SM_RAISONNONENVOISMS = "OK";
                    clsTontinewebWSBLL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, "E", SM_RAISONNONENVOISMS);
                    //--


                }
                catch (Exception ex)
                {
                    SM_RAISONNONENVOISMS = ex.ToString();
                    clsTontinewebWSBLL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, "N", SM_RAISONNONENVOISMS);
                    ex.ToString();


                }
            }





        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



     
    }
}
