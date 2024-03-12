using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using HT_Stock.BOJ;
using Stock.WSTOOLS;
using log4net;
using System.Reflection;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Stock.WSBLL;
using System.Data;
using HT_Stock.BOJ;
using Stock.BOJ;
using System.Net.Mail;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistre.svc ou wsCtsinistre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistre : IwsCtsinistre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistreWSBLL clsCtsinistreWSBLL = new clsCtsinistreWSBLL();

        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }

        //Déclaration du log
        log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            string AG_CODEAGENCE = "";
            string TI_IDTIERS = "";
            string CA_CODECONTRAT = "";
            string vlpSI_DATESAISIE = "";
            string vlpOP_CODEOPERATEUR = "";
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            string vlpSI_CODESINISTRERETOUR = "";

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistre clsCtsinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistre clsCtsinistre = new Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = clsCtsinistreDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistre.AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistre.EN_CODEENTREPOT = clsCtsinistreDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistre.NS_CODENATURESINISTRE = clsCtsinistreDTO.NS_CODENATURESINISTRE.ToString();
                    clsCtsinistre.CA_CODECONTRAT = clsCtsinistreDTO.CA_CODECONTRAT.ToString();
                    clsCtsinistre.SI_NUMSINISTRE = clsCtsinistreDTO.SI_NUMSINISTRE.ToString();
                    clsCtsinistre.SI_DATESAISIE = DateTime.Parse(clsCtsinistreDTO.SI_DATESAISIE.ToString());
                    vlpSI_DATESAISIE = DateTime.Parse(clsCtsinistreDTO.SI_DATESAISIE.ToString()).ToShortDateString();
                    clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESINISTRE.ToString());
                    clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_HEURESINISTRE.ToString());
                    clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NOMPRENOMSCONDUCTEURSINISTRE.ToString();
                    clsCtsinistre.CO_CODECOMMUNE = clsCtsinistreDTO.CO_CODECOMMUNE.ToString();
                    clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = clsCtsinistreDTO.SI_ADRESSEGEOGRPHIQUESINISTRE.ToString();
                    clsCtsinistre.SI_DESCRIPTIONSINISTRE = clsCtsinistreDTO.SI_DESCRIPTIONSINISTRE.ToString();
                    clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString());
                    clsCtsinistre.OP_CODEOPERATEUR = clsCtsinistreDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistre.SI_DOCUMENTTRANSMIS = clsCtsinistreDTO.SI_DOCUMENTTRANSMIS.ToString();
                    clsCtsinistre.SI_MONTANTPREJUDICE = double.Parse(clsCtsinistreDTO.SI_MONTANTPREJUDICE.ToString());
                    clsCtsinistre.EP_CODEEXPERTNOMME = clsCtsinistreDTO.EP_CODEEXPERTNOMME.ToString();
                    clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEEXPERTNOMMESINISTRE.ToString());


                    clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE = clsCtsinistreDTO.SI_TELEPHONECONDUCTEURSINISTRE;
                    clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NUMWHATSAPPCONDUCTEURSINISTRE;

                    if(clsCtsinistreDTO.SI_DATENAISSANCECONDUCTEURSINISTRE!="")
                    clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATENAISSANCECONDUCTEURSINISTRE);
                    else
                        clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE= DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NUMPERMISCONDUCTEURSINISTRE;

                    if (clsCtsinistreDTO.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE != "")
                        clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE);
                    else
                        clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = DateTime.Parse("01/01/1900");

                    if (clsCtsinistreDTO.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE != "")
                        clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE);
                    else
                        clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_IMMATRICULATIONVEHICULE = clsCtsinistreDTO.SI_IMMATRICULATIONVEHICULE;




                    clsCtsinistre.SI_MARQUEVEHICULE = clsCtsinistreDTO.SI_MARQUEVEHICULE;
                    clsCtsinistre.SI_NOMETCONTACTSVICTIMES = clsCtsinistreDTO.SI_NOMETCONTACTSVICTIMES;
                    clsCtsinistre.SI_AILEARRIEREDROIT = clsCtsinistreDTO.SI_AILEARRIEREDROIT;
                    clsCtsinistre.SI_AILEARRIEREGAUCHE = clsCtsinistreDTO.SI_AILEARRIEREGAUCHE;
                    clsCtsinistre.SI_PARCHOCAVANT = clsCtsinistreDTO.SI_PARCHOCAVANT;
                    clsCtsinistre.SI_PARCHOCARRIERE = clsCtsinistreDTO.SI_PARCHOCARRIERE;
                    clsCtsinistre.SI_LATERALGAUCHE = clsCtsinistreDTO.SI_LATERALGAUCHE;
                    clsCtsinistre.SI_LATERALDROIT = clsCtsinistreDTO.SI_LATERALDROIT;



                    clsCtsinistre.SI_CAPOTMOTEUR = clsCtsinistreDTO.SI_CAPOTMOTEUR;
                    clsCtsinistre.SI_AUTRES = clsCtsinistreDTO.SI_AUTRES;
                    clsCtsinistre.SI_REPARATEUR = clsCtsinistreDTO.SI_REPARATEUR;
                    clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE = clsCtsinistreDTO.SI_NOMBREBLESSESVEHICULEASSURE;
                    clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE = clsCtsinistreDTO.SI_NOMBREDECESVEHICULEASSURE;
                    clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS = clsCtsinistreDTO.SI_NOMBREBLESSESVEHICULETIERS;
                    clsCtsinistre.SI_NOMBREDECESVEHICULETIERS = clsCtsinistreDTO.SI_NOMBREDECESVEHICULETIERS;
                    clsCtsinistre.SI_PVCONSTATPOLICE = clsCtsinistreDTO.SI_PVCONSTATPOLICE;
                    clsCtsinistre.SI_PVGENDARMERIE = clsCtsinistreDTO.SI_PVGENDARMERIE;
                    clsCtsinistre.SI_PVAMIABLE = clsCtsinistreDTO.SI_PVAMIABLE;
                    clsCtsinistre.SI_UNITE = clsCtsinistreDTO.SI_UNITE;
                    clsCtsinistre.SI_NOMAGENT = clsCtsinistreDTO.SI_NOMAGENT;
                    clsCtsinistre.SI_TELPHONEAGENT = clsCtsinistreDTO.SI_TELPHONEAGENT;
                    clsCtsinistre.SI_HUSSIER = clsCtsinistreDTO.SI_HUSSIER;

                    AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE;
                    CA_CODECONTRAT = clsCtsinistreDTO.CA_CODECONTRAT;

                    clsObjetEnvoi.OE_A = clsCtsinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistreDTO.clsObjetEnvoi.OE_Y;
                    vlpSI_CODESINISTRERETOUR = clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgAjouter(clsDonnee, clsCtsinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE).OR_STRING;

                }
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {

                    string AG_EMAIL = "";
                    string AG_EMAILMOTDEPASSE = "";
                    DataSet DataSet = new DataSet();
                    DataSet DataSet1 = new DataSet();
                    DataSet DataSetASSUREUR = new DataSet();

                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE };
                    clsAgenceWSBLL clsAgenceWSBLL = new clsAgenceWSBLL();
                    DataSet = clsAgenceWSBLL.pvgChargerDansDataSetAgence(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        AG_EMAIL = row["AG_EMAIL"].ToString();
                        AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                    }

                    //string OP_TELEPHONE = "";
                    //string OP_EMAIL = "";
                    //DataSet1 = new DataSet();
                    //clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE };
                    //clsOperateurWSBLL clsOperateurWSBLL = new clsOperateurWSBLL();
                    //DataSet = clsOperateurWSBLL.pvgChargerDansDataSetOP_GESTIONNAIRE(clsDonnee, clsObjetEnvoi);
                    //foreach (DataRow row in DataSet.Tables[0].Rows)
                    //{
                    //    OP_TELEPHONE = row["OP_TELEPHONE"].ToString();
                    //    OP_EMAIL = row["OP_EMAIL"].ToString();
                    //}


                    //string OP_TELEPHONE = "";
                    string TI_EMAILASSUREUR = "";
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, CA_CODECONTRAT };
                    clsPhatiersWSBLL clsPhatiersWSBLL = new clsPhatiersWSBLL();
                    DataSetASSUREUR = clsPhatiersWSBLL.pvgChargerDansDataSetAssureur(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSetASSUREUR.Tables[0].Rows)
                    {
                        TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        TI_EMAILASSUREUR = row["TI_EMAILASSUREUR"].ToString();
                    }




                    string TI_NUMTIERS = "";
                    string TI_DENOMINATION = "";
                    string TI_TELEPHONE = "";
                    string EN_CODEENTREPOT = "";
                    DataSet1 = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, TI_IDTIERS };
                     clsPhatiersWSBLL = new clsPhatiersWSBLL();
                    DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetAssure(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        TI_DENOMINATION = row["TI_DENOMINATION"].ToString();

                        TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        vlpOP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    }




                    BOJ.clsParams clsParams = new BOJ.clsParams();
                    if (TI_TELEPHONE != "")
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        //if (CL_CONTACT.Length == 10)
                        //    CL_CONTACT = "00225" + CL_CONTACT;
                        string CL_IDCLIENT = "";
                        string SL_MESSAGECLIENT = ".";// "PO:" + clsCtcontrat.CA_NUMPOLICE + "#DE:" + clsCtcontrat.CA_DATEEFFET.ToShortDateString() + "#DC:" + clsCtcontrat.CA_DATEECHEANCE.ToShortDateString();// clsParams.SMSTEXT;
                        string SL_RESULTATAPI = "";
                        string SL_MESSAGEAPI = "";
                        string SL_MESSAGE = "";

                        //clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebmotpasseoublieListe[0].AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT, clsMiccomptewebmotpasseoublieListe[0].OP_CODEOPERATEUR, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, "", CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);

                        //clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string SM_TELEPHONE, string OP_CODEOPERATEUR, DateTime SM_DATEPIECE, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee,AG_CODEAGENCE, EN_CODEENTREPOT, "compte", "FrmClientPhysique", TI_TELEPHONE, vlpOP_CODEOPERATEUR,DateTime.Parse( vlpSI_DATESAISIE), "", TI_IDTIERS, "", SL_MESSAGECLIENT, "0009", "0", vlpSI_DATESAISIE, "0", "", "N", "0", "", "");


                        SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") SL_MESSAGE = SL_MESSAGE + " " + SL_MESSAGEAPI;



                    }
                        
                    
                    //=====







                    if (TI_EMAILASSUREUR.Contains("@") && AG_EMAIL.Contains("@") && CheckForInternetConnection())
                    {
                        string SL_MESSAGEOBJET = "Notification: Nouvelle déclaration de sinistre";
                        string SL_MESSAGECLIENT = "L'assuré " + TI_NUMTIERS + "-" + TI_DENOMINATION + " vient de faire une déclaration de sinistre .";

                        string pvgTitre = SL_MESSAGEOBJET;
                        string vppMessage = SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = AG_EMAIL;
                        string vppMotDePasseExpediteur = AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = TI_EMAILASSUREUR;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);

                    }



                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.SI_CODESINISTRE = vlpSI_CODESINISTRERETOUR;
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgModifier(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistre clsCtsinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistre clsCtsinistre = new Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = clsCtsinistreDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistre.AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistre.EN_CODEENTREPOT = clsCtsinistreDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistre.NS_CODENATURESINISTRE = clsCtsinistreDTO.NS_CODENATURESINISTRE.ToString();
                    clsCtsinistre.CA_CODECONTRAT = clsCtsinistreDTO.CA_CODECONTRAT.ToString();
                    clsCtsinistre.SI_NUMSINISTRE = clsCtsinistreDTO.SI_NUMSINISTRE.ToString();
                    clsCtsinistre.SI_DATESAISIE = DateTime.Parse(clsCtsinistreDTO.SI_DATESAISIE.ToString());
                    clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESINISTRE.ToString());
                    clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_HEURESINISTRE.ToString());
                    clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NOMPRENOMSCONDUCTEURSINISTRE.ToString();
                    clsCtsinistre.CO_CODECOMMUNE = clsCtsinistreDTO.CO_CODECOMMUNE.ToString();
                    clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = clsCtsinistreDTO.SI_ADRESSEGEOGRPHIQUESINISTRE.ToString();
                    clsCtsinistre.SI_DESCRIPTIONSINISTRE = clsCtsinistreDTO.SI_DESCRIPTIONSINISTRE.ToString();
                    clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString());
                    clsCtsinistre.OP_CODEOPERATEUR = clsCtsinistreDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistre.SI_DOCUMENTTRANSMIS = clsCtsinistreDTO.SI_DOCUMENTTRANSMIS.ToString();
                    clsCtsinistre.SI_MONTANTPREJUDICE = double.Parse(clsCtsinistreDTO.SI_MONTANTPREJUDICE.ToString());
                    clsCtsinistre.EP_CODEEXPERTNOMME = clsCtsinistreDTO.EP_CODEEXPERTNOMME.ToString();
                    clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEEXPERTNOMMESINISTRE.ToString());
                    clsCtsinistre.TYPEOPERATION = int.Parse(clsCtsinistreDTO.TYPEOPERATION.ToString());


                    clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE = clsCtsinistreDTO.SI_TELEPHONECONDUCTEURSINISTRE;
                    clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NUMWHATSAPPCONDUCTEURSINISTRE;
                    clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATENAISSANCECONDUCTEURSINISTRE);
                    clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NUMPERMISCONDUCTEURSINISTRE;
                    clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE);
                    clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE);
                    clsCtsinistre.SI_IMMATRICULATIONVEHICULE = clsCtsinistreDTO.SI_IMMATRICULATIONVEHICULE;




                    clsCtsinistre.SI_MARQUEVEHICULE = clsCtsinistreDTO.SI_MARQUEVEHICULE;
                    clsCtsinistre.SI_NOMETCONTACTSVICTIMES = clsCtsinistreDTO.SI_NOMETCONTACTSVICTIMES;
                    clsCtsinistre.SI_AILEARRIEREDROIT = clsCtsinistreDTO.SI_AILEARRIEREDROIT;
                    clsCtsinistre.SI_AILEARRIEREGAUCHE = clsCtsinistreDTO.SI_AILEARRIEREGAUCHE;
                    clsCtsinistre.SI_PARCHOCAVANT = clsCtsinistreDTO.SI_PARCHOCAVANT;
                    clsCtsinistre.SI_PARCHOCARRIERE = clsCtsinistreDTO.SI_PARCHOCARRIERE;
                    clsCtsinistre.SI_LATERALGAUCHE = clsCtsinistreDTO.SI_LATERALGAUCHE;
                    clsCtsinistre.SI_LATERALDROIT = clsCtsinistreDTO.SI_LATERALDROIT;



                    clsCtsinistre.SI_CAPOTMOTEUR = clsCtsinistreDTO.SI_CAPOTMOTEUR;
                    clsCtsinistre.SI_AUTRES = clsCtsinistreDTO.SI_AUTRES;
                    clsCtsinistre.SI_REPARATEUR = clsCtsinistreDTO.SI_REPARATEUR;
                    clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE = clsCtsinistreDTO.SI_NOMBREBLESSESVEHICULEASSURE;
                    clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE = clsCtsinistreDTO.SI_NOMBREDECESVEHICULEASSURE;
                    clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS = clsCtsinistreDTO.SI_NOMBREBLESSESVEHICULETIERS;
                    clsCtsinistre.SI_NOMBREDECESVEHICULETIERS = clsCtsinistreDTO.SI_NOMBREDECESVEHICULETIERS;
                    clsCtsinistre.SI_PVCONSTATPOLICE = clsCtsinistreDTO.SI_PVCONSTATPOLICE;
                    clsCtsinistre.SI_PVGENDARMERIE = clsCtsinistreDTO.SI_PVGENDARMERIE;
                    clsCtsinistre.SI_PVAMIABLE = clsCtsinistreDTO.SI_PVAMIABLE;
                    clsCtsinistre.SI_UNITE = clsCtsinistreDTO.SI_UNITE;
                    clsCtsinistre.SI_NOMAGENT = clsCtsinistreDTO.SI_NOMAGENT;
                    clsCtsinistre.SI_TELPHONEAGENT = clsCtsinistreDTO.SI_TELPHONEAGENT;
                    clsCtsinistre.SI_HUSSIER = clsCtsinistreDTO.SI_HUSSIER;

                    clsObjetEnvoi.OE_A = clsCtsinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistreDTO.SI_CODESINISTRE };
                    clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgModifier(clsDonnee, clsCtsinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }


        public List<HT_Stock.BOJ.clsCtsinistre> pvgMiseAjourStatutContrat(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireUpdateStatut(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }

            Stock.BOJ.clsCtsinistre clsCtsinistre1 = new Stock.BOJ.clsCtsinistre();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsCtsinistregarantie> clsCtsinistregaranties = new List<BOJ.clsCtsinistregarantie>();
            //List<Stock.BOJ.clsCtsinistreprime> clsCtsinistreprimes = new List<BOJ.clsCtsinistreprime>();
            //List<Stock.BOJ.clsCtsinistrereduction> clsCtsinistrereductions = new List<BOJ.clsCtsinistrereduction>();
            //List<Stock.BOJ.clsCtsinistreayantdroit> clsCtsinistreayantdroits = new List<BOJ.clsCtsinistreayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistre clsCtsinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistre clsCtsinistre = new Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = clsCtsinistreDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistre.AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistre.EN_CODEENTREPOT = clsCtsinistreDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistre.OP_CODEOPERATEUR = clsCtsinistreDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = (clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_DATEVALIDATIONSINISTRE = (clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_DATESUSPENSIONSINISTRE = (clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_DATECLOTURESINISTRE = (clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString()) : DateTime.Parse("01/01/1900");

                    clsCtsinistre.SI_MONTANTPREJUDICEVALIDER = double.Parse(clsCtsinistreDTO.SI_MONTANTPREJUDICEVALIDER.ToString());
                    clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER =clsCtsinistreDTO.OP_CODEOPERATEURSAISIEMONTANTVALIDER.ToString();
                    clsCtsinistre.SI_DATESAISIEMONTANTVALIDER = (clsCtsinistreDTO.SI_DATESAISIEMONTANTVALIDER.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATESAISIEMONTANTVALIDER.ToString()) : DateTime.Parse("01/01/1900");




                    clsCtsinistre.TYPEOPERATION = int.Parse(clsCtsinistreDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtsinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistreDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgModifier(clsDonnee, clsCtsinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SI_CODESINISTRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].CA_NUMPOLICE, Objet[0].CA_CODECONTRAT, Objet[0].NS_CODENATURESINISTRE, Objet[0].SI_NUMSINISTRE, Objet[0].TI_NUMTIERS, Objet[0].TI_DENOMINATION, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsCtsinistreWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                        clsCtsinistre.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                        clsCtsinistre.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsCtsinistre.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsCtsinistre.NS_CODENATURESINISTRE = row["NS_CODENATURESINISTRE"].ToString();
                        clsCtsinistre.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                        clsCtsinistre.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                        clsCtsinistre.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                        clsCtsinistre.SI_NUMSINISTRE = row["SI_NUMSINISTRE"].ToString();
                        clsCtsinistre.SI_DATESAISIE = (row["SI_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["SI_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATESAISIE = (clsCtsinistre.SI_DATESAISIE != "01-01-1900") ? clsCtsinistre.SI_DATESAISIE : "";
                        clsCtsinistre.SI_DATESINISTRE = (row["SI_DATESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATESINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATESINISTRE = (clsCtsinistre.SI_DATESINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATESINISTRE : "";
                        clsCtsinistre.SI_HEURESINISTRE = (row["SI_HEURESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_HEURESINISTRE"].ToString()).ToShortTimeString() : "";
                        clsCtsinistre.SI_HEURESINISTRE = (clsCtsinistre.SI_HEURESINISTRE != "01-01-1900") ? clsCtsinistre.SI_HEURESINISTRE : "";
                        clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = row["SI_NOMPRENOMSCONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                        clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = row["SI_ADRESSEGEOGRPHIQUESINISTRE"].ToString();
                        clsCtsinistre.SI_DESCRIPTIONSINISTRE = row["SI_DESCRIPTIONSINISTRE"].ToString();
                        clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = (row["SI_DATETRANSMISSIONSINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATETRANSMISSIONSINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = (clsCtsinistre.SI_DATETRANSMISSIONSINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATETRANSMISSIONSINISTRE : "";
                        clsCtsinistre.SI_DATEVALIDATIONSINISTRE = (row["SI_DATEVALIDATIONSINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATEVALIDATIONSINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATEVALIDATIONSINISTRE = (clsCtsinistre.SI_DATEVALIDATIONSINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATEVALIDATIONSINISTRE : "";
                        clsCtsinistre.SI_DATESUSPENSIONSINISTRE = (row["SI_DATESUSPENSIONSINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATESUSPENSIONSINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATESUSPENSIONSINISTRE = (clsCtsinistre.SI_DATESUSPENSIONSINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATESUSPENSIONSINISTRE : "";
                        clsCtsinistre.SI_DATECLOTURESINISTRE = (row["SI_DATECLOTURESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATECLOTURESINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATECLOTURESINISTRE = (clsCtsinistre.SI_DATECLOTURESINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATECLOTURESINISTRE : "";
                        clsCtsinistre.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsCtsinistre.SI_DOCUMENTTRANSMIS = row["SI_DOCUMENTTRANSMIS"].ToString();
                        clsCtsinistre.SI_MONTANTPREJUDICE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["SI_MONTANTPREJUDICE"].ToString()).ToString(), "M");// row["SI_MONTANTPREJUDICE"].ToString();

                        clsCtsinistre.SI_MONTANTPREJUDICEREMBOURSE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["SI_MONTANTPREJUDICEREMBOURSE"].ToString()).ToString(), "M");
                        clsCtsinistre.SI_SOLDE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["SI_SOLDE"].ToString()).ToString(), "M");
                        clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER = row["OP_CODEOPERATEURSAISIEMONTANTVALIDER"].ToString();


                        clsCtsinistre.EP_CODEEXPERTNOMME = row["EP_CODEEXPERTNOMME"].ToString();
                        clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = (row["SI_DATEEXPERTNOMMESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATEEXPERTNOMMESINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = (clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE : "";
                        clsCtsinistre.SI_NOMBRECONTRAT = int.Parse(row["SI_NOMBRECONTRAT"].ToString()).ToString();
                        clsCtsinistre.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                        clsCtsinistre.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                        clsCtsinistre.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                        clsCtsinistre.NS_LIBELLENATURESINISTRE = row["NS_LIBELLENATURESINISTRE"].ToString();
                        clsCtsinistre.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                        clsCtsinistre.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                        clsCtsinistre.SI_MONTANTPREJUDICENF = Double.Parse(row["SI_MONTANTPREJUDICE"].ToString()).ToString();
                        clsCtsinistre.SI_MONTANTPREJUDICEVALIDERNF = Double.Parse(row["SI_MONTANTPREJUDICEVALIDER"].ToString()).ToString();
                        clsCtsinistre.SI_MONTANTPREJUDICEVALIDER = Double.Parse(row["SI_MONTANTPREJUDICEVALIDER"].ToString()).ToString();

                        clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE = row["SI_TELEPHONECONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE = row["SI_NUMWHATSAPPCONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE = row["SI_DATENAISSANCECONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE = row["SI_NUMPERMISCONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = row["SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = row["SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE"].ToString();
                        clsCtsinistre.SI_IMMATRICULATIONVEHICULE = row["SI_IMMATRICULATIONVEHICULE"].ToString();
                        clsCtsinistre.SI_MARQUEVEHICULE = row["SI_MARQUEVEHICULE"].ToString();
                        clsCtsinistre.SI_NOMETCONTACTSVICTIMES = row["SI_NOMETCONTACTSVICTIMES"].ToString();
                        clsCtsinistre.SI_AILEARRIEREDROIT = row["SI_AILEARRIEREDROIT"].ToString();
                        clsCtsinistre.SI_AILEARRIEREGAUCHE = row["SI_AILEARRIEREGAUCHE"].ToString();
                        clsCtsinistre.SI_PARCHOCAVANT = row["SI_PARCHOCAVANT"].ToString();
                        clsCtsinistre.SI_PARCHOCARRIERE = row["SI_PARCHOCARRIERE"].ToString();
                        clsCtsinistre.SI_LATERALGAUCHE = row["SI_LATERALGAUCHE"].ToString();
                        clsCtsinistre.SI_LATERALDROIT = row["SI_LATERALDROIT"].ToString();
                        clsCtsinistre.SI_CAPOTMOTEUR = row["SI_CAPOTMOTEUR"].ToString();
                        clsCtsinistre.SI_AUTRES = row["SI_AUTRES"].ToString();
                        clsCtsinistre.SI_REPARATEUR = row["SI_REPARATEUR"].ToString();
                        clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE = row["SI_NOMBREBLESSESVEHICULEASSURE"].ToString();
                        clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE = row["SI_NOMBREDECESVEHICULEASSURE"].ToString();
                        clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS = row["SI_NOMBREBLESSESVEHICULETIERS"].ToString();
                        clsCtsinistre.SI_NOMBREDECESVEHICULETIERS = row["SI_NOMBREDECESVEHICULETIERS"].ToString();
                        clsCtsinistre.SI_PVCONSTATPOLICE = row["SI_PVCONSTATPOLICE"].ToString();
                        clsCtsinistre.SI_PVGENDARMERIE = row["SI_PVGENDARMERIE"].ToString();
                        clsCtsinistre.SI_PVAMIABLE = row["SI_PVAMIABLE"].ToString();
                        clsCtsinistre.SI_UNITE = row["SI_UNITE"].ToString();
                        clsCtsinistre.SI_NOMAGENT = row["SI_NOMAGENT"].ToString();
                        clsCtsinistre.SI_TELPHONEAGENT = row["SI_TELPHONEAGENT"].ToString();
                        clsCtsinistre.SI_HUSSIER = row["SI_HUSSIER"].ToString();


                        clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsCtsinistres.Add(clsCtsinistre);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgInsertIntoDatasetEtatConsultation(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireListeReleve(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }

            //@AG_CODEAGENCE,@EN_CODEENTREPOT, @MATRICULE,@MS_NUMPIECE,@MC_DATEPIECE1, @MC_DATEPIECE2,@DATEJOURNEE,@TYPEETAT,@OP_CODEOPERATEUREDITION,@NO_CODENATUREOPERATION,
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].TI_NUMTIERS, Objet[0].MS_NUMPIECE, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].DATEJOURNEE, Objet[0].TYPEOPERATION, Objet[0].OP_CODEOPERATEUR, Objet[0].NO_CODENATUREOPERATION, Objet[0].CA_CODECONTRAT };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsEditionEtatClientFournisseurWSBLL clsEditionEtatClientFournisseurWSBLL = new clsEditionEtatClientFournisseurWSBLL();
                DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatConsultation(clsDonnee, clsObjetEnvoi);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

                        clsCtsinistre.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsCtsinistre.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsCtsinistre.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        clsCtsinistre.TI_ADRESSEPOSTALE = row["TI_ADRESSEPOSTALE"].ToString();
                        clsCtsinistre.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsCtsinistre.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                        clsCtsinistre.SOLDEPRECEDENT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["SOLDEPRECEDENT"].ToString()).ToString(), "M");
                        clsCtsinistre.MONTANTFACTUREINITIAL = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MONTANTFACTUREINITIAL"].ToString()).ToString(), "M");
                        clsCtsinistre.MONTANTVERSE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MONTANTVERSE"].ToString()).ToString(), "M");
                        clsCtsinistre.MV_SOLDEFINAL = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_SOLDEFINAL"].ToString()).ToString(), "M");

                        clsCtsinistre.MV_DATEPIECE = (row["MV_DATEPIECE"].ToString() != "") ? DateTime.Parse(row["MV_DATEPIECE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtsinistre.MV_DATEPIECE = (clsCtsinistre.MV_DATEPIECE != "01-01-1900") ? clsCtsinistre.MV_DATEPIECE : "";
                        clsCtsinistre.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsCtsinistre.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                        clsCtsinistre.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
                        clsCtsinistre.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                        clsCtsinistre.MV_MONTANTDEBIT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_MONTANTDEBIT"].ToString()).ToString(), "M");
                        clsCtsinistre.MV_MONTANTCREDIT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_MONTANTCREDIT"].ToString()).ToString(), "M");
                        clsCtsinistre.MV_SOLDE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_SOLDE"].ToString()).ToString(), "M");
                        clsCtsinistre.REMISE = Double.Parse(row["REMISE"].ToString());


                        clsCtsinistre.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                        clsCtsinistre.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                        clsCtsinistre.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                        clsCtsinistre.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                        if (row["CA_DATEEFFET"].ToString() != "")
                            clsCtsinistre.CA_DATEEFFET = DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString();
                        if (row["CA_DATEECHEANCE"].ToString() != "")
                            clsCtsinistre.CA_DATEECHEANCE = DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString();

                        clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsCtsinistres.Add(clsCtsinistre);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtsinistres = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            //    //--TEST CONTRAINTE
            //    clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            //}


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsCtsinistreWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                        clsCtsinistre.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                        clsCtsinistre.SI_NUMSINISTRE = row["SI_NUMSINISTRE"].ToString();
                        clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsCtsinistres.Add(clsCtsinistre);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
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

    }
}
