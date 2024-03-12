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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontratdemandecreation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontratdemandecreation.svc ou wsCtcontratdemandecreation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontratdemandecreation : IwsCtcontratdemandecreation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratdemandecreationWSBLL clsCtcontratdemandecreationWSBLL = new clsCtcontratdemandecreationWSBLL();

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
        public string pvgAjouter(List<HT_Stock.BOJ.clsCtcontratdemandecreation> Objet)
        {

            DataSet DataSet = new DataSet();

            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";
            string AG_CODEAGENCE = "";
            string TI_IDTIERS = "";
            string vlpRQ_CODERISQUE = "";

            DateTime DE_DATESAISIE =DateTime.Parse( "01/01/1900");


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }

           
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreationDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new Stock.BOJ.clsCtcontratdemandecreation();
                    clsCtcontratdemandecreation.DE_CODEDEMANADE = "0";// clsCtcontratdemandecreationDTO.DE_CODEDEMANADE.ToString();
                    AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
                    TI_IDTIERS = clsCtcontratdemandecreationDTO.TI_IDTIERS.ToString();
                    clsCtcontratdemandecreation.AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratdemandecreation.RQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
                    vlpRQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
                    clsCtcontratdemandecreation.DE_DATESAISIE =DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATESAISIE.ToString());
                    DE_DATESAISIE =DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATESAISIE.ToString());
                    clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEVALIDATION.ToString());
                    clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsCtcontratdemandecreationDTO.TI_IDTIERSASSUREUR.ToString();
                    clsCtcontratdemandecreation.TI_IDTIERS = clsCtcontratdemandecreationDTO.TI_IDTIERS.ToString();
                    clsCtcontratdemandecreation.CA_CODECONTRAT = clsCtcontratdemandecreationDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratdemandecreation.DE_DATEANNULATION =DateTime.Parse( "01/01/1900");// clsCtcontratdemandecreationDTO.CA_CODECONTRAT.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratdemandecreationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratdemandecreationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtcontratdemandecreationWSBLL.pvgAjouter(clsDonnee, clsCtcontratdemandecreation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    string AG_EMAIL = "";
                    string AG_EMAILMOTDEPASSE = "";
                    DataSet DataSet1 = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE };
                    clsAgenceWSBLL clsAgenceWSBLL  = new clsAgenceWSBLL();
                    DataSet = clsAgenceWSBLL.pvgChargerDansDataSetAgence(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        AG_EMAIL = row["AG_EMAIL"].ToString();
                        AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                    }

                    string OP_TELEPHONE = "";
                    string OP_EMAIL = "";
                    string OP_CODEOPERATEUR = "";
                    DataSet1 = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE };
                    clsOperateurWSBLL clsOperateurWSBLL = new clsOperateurWSBLL();
                    DataSet = clsOperateurWSBLL.pvgChargerDansDataSetOP_GESTIONNAIRE(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        OP_TELEPHONE = row["OP_TELEPHONE"].ToString();
                        OP_EMAIL = row["OP_EMAIL"].ToString();
                        OP_CODEOPERATEUR = row["OP_GESTIONNAIRE"].ToString();
                    }

                    string TI_NUMTIERS = "";
                    string TI_DENOMINATION = "";

                    string TI_TELEPHONE = "";
                    string EN_CODEENTREPOT = "";

                     DataSet1 = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, TI_IDTIERS };
                    clsPhatiersWSBLL clsPhatiersWSBLL = new clsPhatiersWSBLL();
                    DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetAssure(clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();

                    }

                    clsObjetEnvoi.OE_PARAM = new string[] { vlpRQ_CODERISQUE };
                    clsCtparrisqueassuranceWSBLL clsCtparrisqueassuranceWSBLL = new clsCtparrisqueassuranceWSBLL();
                    Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new Stock.BOJ.clsCtparrisqueassurance();
                    clsCtparrisqueassurance = clsCtparrisqueassuranceWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);


                    BOJ.clsParams clsParams = new BOJ.clsParams();
                    if (TI_TELEPHONE != "")
                    {

                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        //if (CL_CONTACT.Length == 10)
                        //    CL_CONTACT = "00225" + CL_CONTACT;
                        string CL_IDCLIENT = "";
                        string SL_MESSAGECLIENT = "#CT:" + clsCtparrisqueassurance.RQ_LIBELLERISQUE ;// clsParams.SMSTEXT;
                        string SL_RESULTATAPI = "";
                        string SL_MESSAGEAPI = "";
                        string SL_MESSAGE = "";

                        //clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebmotpasseoublieListe[0].AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT, clsMiccomptewebmotpasseoublieListe[0].OP_CODEOPERATEUR, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, "", CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);

                        //clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string SM_TELEPHONE, string OP_CODEOPERATEUR, DateTime SM_DATEPIECE, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2
                        clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, Objet[0].AG_CODEAGENCE, EN_CODEENTREPOT, "compte", "FrmClientPhysique", TI_TELEPHONE, OP_CODEOPERATEUR, DE_DATESAISIE, "", TI_IDTIERS, "", SL_MESSAGECLIENT, "0004", "0", DE_DATESAISIE.ToShortDateString(), "0", "", "N", "0", "", "");


                        SL_RESULTATAPI = clsParams.SL_RESULTAT;
                        SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                        if (clsParams.SL_RESULTAT == "FALSE") SL_MESSAGE = SL_MESSAGE + " " + SL_MESSAGEAPI;



                    }




                    if (OP_EMAIL.Contains("@") && AG_EMAIL.Contains("@") && CheckForInternetConnection())
                    {
                        string SL_MESSAGEOBJET = "Notification: Nouvelle demande de contrat";
                        string SL_MESSAGECLIENT = "L'assuré "+ TI_NUMTIERS+"-"+ TI_DENOMINATION+" Souhaite renouveller son contrat .";

                        string pvgTitre = SL_MESSAGEOBJET;
                        string vppMessage = SL_MESSAGECLIENT + " ";
                        string vppMailExpediteur = AG_EMAIL;
                        string vppMotDePasseExpediteur = AG_EMAILMOTDEPASSE;
                        string vppMailRecepteur = OP_EMAIL;
                        string vppCheminCompletFichierEnvoyer1 = "";
                        string vppCheminCompletFichierEnvoyer2 = "";
                        string vppCheminCompletFichierEnvoyer3 = "";

                        sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);

                    }


                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                    
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                    
                }



            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
                
            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgModifier(List<HT_Stock.BOJ.clsCtcontratdemandecreation> Objet)
        {

            DataSet DataSet = new DataSet();

            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreationDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new Stock.BOJ.clsCtcontratdemandecreation();
                    clsCtcontratdemandecreation.DE_CODEDEMANADE = clsCtcontratdemandecreationDTO.DE_CODEDEMANADE.ToString();
                    clsCtcontratdemandecreation.AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratdemandecreation.RQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
                    clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATESAISIE.ToString());
                    clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEVALIDATION.ToString());
                    clsCtcontratdemandecreation.DE_DATEANNULATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEANNULATION.ToString());
                    clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsCtcontratdemandecreationDTO.TI_IDTIERSASSUREUR.ToString();
                    clsCtcontratdemandecreation.TI_IDTIERS = clsCtcontratdemandecreationDTO.TI_IDTIERS.ToString();
                    clsCtcontratdemandecreation.CA_CODECONTRAT = clsCtcontratdemandecreationDTO.CA_CODECONTRAT.ToString();

                    clsObjetEnvoi.OE_A = clsCtcontratdemandecreationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratdemandecreationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratdemandecreationDTO.DE_CODEDEMANADE };
                    clsObjetRetour.SetValue(true, clsCtcontratdemandecreationWSBLL.pvgModifier(clsDonnee, clsCtcontratdemandecreation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }



            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgAnnulation(List<HT_Stock.BOJ.clsCtcontratdemandecreation> Objet)
        {

            DataSet DataSet = new DataSet();

            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireAnnulation(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreationDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new Stock.BOJ.clsCtcontratdemandecreation();
                    clsCtcontratdemandecreation.DE_CODEDEMANADE = clsCtcontratdemandecreationDTO.DE_CODEDEMANADE.ToString();
                    clsCtcontratdemandecreation.AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratdemandecreation.RQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
                    clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse("01/01/1900");
                    clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse("01/01/1900");
                    clsCtcontratdemandecreation.DE_DATEANNULATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEANNULATION.ToString());
                    clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = "0";
                    clsCtcontratdemandecreation.TI_IDTIERS = "0";
                    clsCtcontratdemandecreation.CA_CODECONTRAT = "0";
                    clsCtcontratdemandecreation.TYPEOPERATION = "4";
                    clsObjetEnvoi.OE_A = clsCtcontratdemandecreationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratdemandecreationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratdemandecreationDTO.DE_CODEDEMANADE };
                    clsObjetRetour.SetValue(true, clsCtcontratdemandecreationWSBLL.pvgUpdateAnnulationDemande(clsDonnee, clsCtcontratdemandecreation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }



            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgSupprimer(List<HT_Stock.BOJ.clsCtcontratdemandecreation> Objet)
        {

            DataSet DataSet = new DataSet();

            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }


            clsObjetEnvoi.OE_PARAM = new string[] {Objet[0].AG_CODEAGENCE, Objet[0].DE_CODEDEMANADE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratdemandecreationWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
            
                    
                }



            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return   json;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontratdemandecreation> Objet)
            {

            DataSet DataSet = new DataSet();

            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }

                if (string.IsNullOrEmpty(Objet[0].RQ_CODERISQUE)) Objet[0].RQ_CODERISQUE = "";
                if (string.IsNullOrEmpty(Objet[0].TYPEOPERATION)) Objet[0].TYPEOPERATION = "";
                clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE ,Objet[0].DATEDEBUT,Objet[0].DATEFIN,Objet[0].RQ_CODERISQUE,Objet[0].TI_NUMTIERS, Objet[0].TYPEOPERATION, };


            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratdemandecreationWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["SL_CODEMESSAGE"] = "00";
                        DataSet.Tables[0].Rows[i]["SL_RESULTAT"] = "TRUE";
                        DataSet.Tables[0].Rows[i]["SL_MESSAGE"] = "Opération réalisée avec succès !!!";

                    }

                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
            else
            {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Aucun enregistrement trouvé !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                


            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return json;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratdemandecreation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtcontratdemandecreation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtcontratdemandecreations = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratdemandecreations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratdemandecreations;
        //    //--TEST CONTRAINTE
        //    clsCtcontratdemandecreations = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratdemandecreations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratdemandecreations;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratdemandecreationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
                    clsCtcontratdemandecreation.DE_CODEDEMANADE = row["DE_CODEDEMANADE"].ToString();
                    clsCtcontratdemandecreation.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratdemandecreation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratdemandecreation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratdemandecreation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratdemandecreation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratdemandecreation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratdemandecreation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
            clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratdemandecreation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratdemandecreation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratdemandecreation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
            clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratdemandecreation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratdemandecreation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratdemandecreation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratdemandecreations;
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
