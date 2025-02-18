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
using Stock.BOJ;
using System.Web.Script.Serialization;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatAssurance" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatAssurance.svc ou wsEditionEtatAssurance.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatAssurance : IwsEditionEtatAssurance
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatAssuranceWSBLL clsEditionEtatAssuranceWSBLL = new clsEditionEtatAssuranceWSBLL();

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
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceTableauGestionCommission(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }



                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssuranceTableauGestionCommission(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    //string CA_CODECONTRAT = "0";
                    //int idx = 0;
                    //foreach (DataRow row in DataSet.Tables[0].Rows)
                    //{
                    //    if (idx == 0)
                    //        CA_CODECONTRAT = "''" + row["CA_CODECONTRAT"].ToString() + "''";
                    //    if (idx > 0)
                    //        CA_CODECONTRAT = CA_CODECONTRAT + "," + "''" + row["CA_CODECONTRAT"].ToString() + "''";
                    //    idx = 1;

                    //}
                    //DataSet DataSetSE = new DataSet();
                    //clsEditionEtatAssurance1.CA_CODECONTRAT = CA_CODECONTRAT;
                    //clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIMESE";
                    //DataSetSE = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                    //for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    //{
                    //    DataSet.Tables[0].Rows[i]["MONTANTESPECE"] = DataSetSE.Tables[0].Rows[0]["MONTANTESPECE"];
                    //}


                    string reportPath = "~/Etats/ASSURANCE/"; //+ Objet[0].ET_DOSSIER
                    string reportFileName = Objet[0].NOMETAT;
                    string exportFilename = "";
                    string URL_ETAT = "";
                    //string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                    //DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);





                }


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssurance(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }


                if (clsEditionEtatAssurance1.ET_TYPEETAT == "ASTABGESTION")
                    DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssuranceTableauGestion(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);
                else
                    DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    if (clsEditionEtatAssurance1.ET_TYPEETAT != "ASAVIEGRIMELISTE")
                    {
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                            //clsEditionEtatAssurance.ET_INDEX = row["ET_INDEX"].ToString();
                            //clsEditionEtatAssurance.ET_LIBELLEEditionEtatAssurance = row["ET_LIBELLEEditionEtatAssurance"].ToString();

                            clsEditionEtatAssurance.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            //clsEditionEtatAssurance.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                            clsEditionEtatAssurance.IDF = row["IDF"].ToString();
                            clsEditionEtatAssurance.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                            clsEditionEtatAssurance.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                            clsEditionEtatAssurance.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                            clsEditionEtatAssurance.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();


                            if (row["CA_DATEEFFET"].ToString() != "")
                                clsEditionEtatAssurance.CA_DATEEFFET = DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString();
                            else
                                clsEditionEtatAssurance.CA_DATEEFFET = "";


                            if (row["CA_DATEECHEANCE"].ToString() != "")
                                clsEditionEtatAssurance.CA_DATEECHEANCE = DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString();
                            else
                                clsEditionEtatAssurance.CA_DATEECHEANCE = "";


                            //clsEditionEtatAssurance.CA_DATEEFFET = row["CA_DATEEFFET"].ToString();
                            //clsEditionEtatAssurance.CA_DATEECHEANCE = row["CA_DATEECHEANCE"].ToString();
                            clsEditionEtatAssurance.CA_NOMINTERLOCUTEUR = row["CA_NOMINTERLOCUTEUR"].ToString();
                            clsEditionEtatAssurance.CA_CONTACTINTERLOCUTEUR = row["CA_CONTACTINTERLOCUTEUR"].ToString();
                            clsEditionEtatAssurance.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                            clsEditionEtatAssurance.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                            clsEditionEtatAssurance.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                            clsEditionEtatAssurance.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                            clsEditionEtatAssurance.DESIGNATION = row["DESIGNATION"].ToString();
                            clsEditionEtatAssurance.PRIME = (row["PRIME"].ToString() != "") ? double.Parse(row["PRIME"].ToString()) : 0;// row["PRIME"].ToString();
                            clsEditionEtatAssurance.PERIODEGARANTIE = row["PERIODEGARANTIE"].ToString();
                            clsEditionEtatAssurance.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
                            clsEditionEtatAssurance.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
                            clsEditionEtatAssurance.DATEDEPOT = row["DATEDEPOT"].ToString();
                            clsEditionEtatAssurance.MONTANT = (row["MONTANT"].ToString() != "") ? double.Parse(row["MONTANT"].ToString()) : 0;// row["MONTANT"].ToString();
                            clsEditionEtatAssurance.MONTANTRESTAPAYER = (row["MONTANTRESTAPAYER"].ToString() != "") ? double.Parse(row["MONTANTRESTAPAYER"].ToString()) : 0;//row["MONTANTRESTAPAYER"].ToString();
                            clsEditionEtatAssurance.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
                            clsEditionEtatAssurance.ZM_CODEZONEMALADIE = row["ZM_CODEZONEMALADIE"].ToString();
                            clsEditionEtatAssurance.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
                            clsEditionEtatAssurance.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
                            clsEditionEtatAssurance.CA_IMMATRICULATION = row["CA_IMMATRICULATION"].ToString();
                            clsEditionEtatAssurance.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                            clsEditionEtatAssurance.ZN_NOMZONE = row["ZN_NOMZONE"].ToString();
                            clsEditionEtatAssurance.NS_LIBELLENATURESINISTRE = row["NS_LIBELLENATURESINISTRE"].ToString();
                            clsEditionEtatAssurance.SI_DATESINISTRE = row["SI_DATESINISTRE"].ToString();
                            clsEditionEtatAssurance.SI_DOCUMENTTRANSMIS = row["SI_DOCUMENTTRANSMIS"].ToString();
                            clsEditionEtatAssurance.SI_DATETRANSMISSIONSINISTRE = row["SI_DATETRANSMISSIONSINISTRE"].ToString();
                            clsEditionEtatAssurance.SI_MONTANTPREJUDICE = (row["SI_MONTANTPREJUDICE"].ToString() != "") ? double.Parse(row["SI_MONTANTPREJUDICE"].ToString()) : 0;// row["SI_MONTANTPREJUDICE"].ToString();
                            clsEditionEtatAssurance.SI_NUMSINISTRE = row["SI_NUMSINISTRE"].ToString();
                            clsEditionEtatAssurance.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsEditionEtatAssurance.EP_DENOMMINATIONEXPERTNOMME = row["EP_DENOMMINATIONEXPERTNOMME"].ToString();
                            clsEditionEtatAssurance.SD_DESCRIPTIONEVENEMENT = row["SD_DESCRIPTIONEVENEMENT"].ToString();
                            clsEditionEtatAssurance.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                            clsEditionEtatAssurance.TI_EMAIL = row["TI_EMAIL"].ToString();
                            clsEditionEtatAssurance.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsEditionEtatAssurance.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                            clsEditionEtatAssurance.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
                            clsEditionEtatAssurance.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
                            clsEditionEtatAssurance.CH_NOMDUDEPOSANT = row["CH_NOMDUDEPOSANT"].ToString();
                            clsEditionEtatAssurance.CH_TELEPHONEDEPOSANT = row["CH_TELEPHONEDEPOSANT"].ToString();
                            clsEditionEtatAssurance.GR_LIBELLEGARENTIEPRIME = row["GR_LIBELLEGARENTIEPRIME"].ToString();
                            if (row["MONTANTCOMMISSION_A_PAYER"].ToString() != "")
                                clsEditionEtatAssurance.MONTANTCOMMISSION_A_PAYER = double.Parse(row["MONTANTCOMMISSION_A_PAYER"].ToString());
                            else
                                clsEditionEtatAssurance.MONTANTCOMMISSION_A_PAYER = 0;
                            if (row["MONTANTCOMMISSIONPAYER"].ToString() != "")
                                clsEditionEtatAssurance.MONTANTCOMMISSIONPAYER = double.Parse(row["MONTANTCOMMISSIONPAYER"].ToString());
                            else
                                clsEditionEtatAssurance.MONTANTCOMMISSIONPAYER = 0;
                            if (row["MONTANTCOMMISSION_RESTANT_A_PAYER"].ToString() != "")
                                clsEditionEtatAssurance.MONTANTCOMMISSION_RESTANT_A_PAYER = double.Parse(row["MONTANTCOMMISSION_RESTANT_A_PAYER"].ToString());
                            else
                                clsEditionEtatAssurance.MONTANTCOMMISSION_RESTANT_A_PAYER = 0;
                            //clsEditionEtatAssurance.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();


                            if (row["CH_DATESAISIECHEQUE"].ToString() != "")
                                clsEditionEtatAssurance.CH_DATESAISIECHEQUE = DateTime.Parse(row["CH_DATESAISIECHEQUE"].ToString()).ToShortDateString();
                            else
                                clsEditionEtatAssurance.CH_DATESAISIECHEQUE = "";



                            if (row["CH_VALEURCHEQUE"].ToString() != "")
                                clsEditionEtatAssurance.CH_VALEURCHEQUE = double.Parse(row["CH_VALEURCHEQUE"].ToString());
                            else
                                clsEditionEtatAssurance.CH_VALEURCHEQUE = 0;

                            if (row["CH_DATEVALIDATIONCHEQUE"].ToString() != "")
                                clsEditionEtatAssurance.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(row["CH_DATEVALIDATIONCHEQUE"].ToString()).ToShortDateString();
                            else
                                clsEditionEtatAssurance.CH_DATEVALIDATIONCHEQUE = "";

                            if (row["MONTANTCHEQUE"].ToString() != "")
                                clsEditionEtatAssurance.MONTANTCHEQUE = double.Parse(row["MONTANTCHEQUE"].ToString());
                            else
                                clsEditionEtatAssurance.MONTANTCHEQUE = 0;
                            if (row["MONTANTESPECE"].ToString() != "")
                                clsEditionEtatAssurance.MONTANTESPECE = double.Parse(row["MONTANTESPECE"].ToString());
                            else
                                clsEditionEtatAssurance.MONTANTESPECE = 0;



                            if (clsEditionEtatAssurance1.ET_TYPEETAT == "ASTABGESTION")
                            {
                                clsEditionEtatAssurance.TOTALFACTURE = (row["TOTALFACTURE"].ToString() != "") ? double.Parse(row["TOTALFACTURE"].ToString()) : 0;
                                clsEditionEtatAssurance.TOTALFACTUREREGLE = (row["TOTALFACTUREREGLE"].ToString() != "") ? double.Parse(row["TOTALFACTUREREGLE"].ToString()) : 0;
                                clsEditionEtatAssurance.TOTALFACTURERESTANTAREGLE = (row["TOTALFACTURERESTANTAREGLE"].ToString() != "") ? double.Parse(row["TOTALFACTURERESTANTAREGLE"].ToString()) : 0;
                                clsEditionEtatAssurance.TOTALPRIMESPOLICE = (row["TOTALPRIMESPOLICE"].ToString() != "") ? double.Parse(row["TOTALPRIMESPOLICE"].ToString()) : 0;
                                clsEditionEtatAssurance.TOTALPRIMEREGLES = (row["TOTALPRIMEREGLES"].ToString() != "") ? double.Parse(row["TOTALPRIMEREGLES"].ToString()) : 0;
                                clsEditionEtatAssurance.TOTALRESTAPAYER = (row["TOTALRESTAPAYER"].ToString() != "") ? double.Parse(row["TOTALRESTAPAYER"].ToString()) : 0;

                            }







                            clsEditionEtatAssurance.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                            clsEditionEtatAssurance.TA_LIBLLETYPEAFFAIRES = row["TA_LIBLLETYPEAFFAIRES"].ToString();
                            clsEditionEtatAssurance.CA_OBSERVATION = row["CA_OBSERVATION"].ToString();
                            clsEditionEtatAssurance.TI_NUMEROAXA = row["TI_NUMEROAXA"].ToString();
                            clsEditionEtatAssurance.TI_NUMTIERSCOMMERCIAL = row["TI_NUMTIERSCOMMERCIAL"].ToString();
                            clsEditionEtatAssurance.TI_DENOMINATIONCOMMERCIAL = row["TI_DENOMINATIONCOMMERCIAL"].ToString();
                            clsEditionEtatAssurance.TVH_LIBELE = row["TVH_LIBELE"].ToString();
                            clsEditionEtatAssurance.EX_EXERCICE = row["EX_EXERCICE"].ToString();
                            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                        }
                    }
                    else
                    {
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                            clsEditionEtatAssurance.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                            clsEditionEtatAssurance.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                            clsEditionEtatAssurance.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                            clsEditionEtatAssurance.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                        }

                    }
                }


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
    //    public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssurance(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
    //     {

    //    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    //    List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
           
    //    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    //    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    //    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    //    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    //        for (int Idx = 0; Idx < Objet.Count; Idx++)
    //        {
    //            //--TEST DES CHAMPS OBLIGATOIRES
    //            clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
    //            //--VERIFICATION DU RESULTAT DU TEST
    //            if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
    //            //--TEST CONTRAINTE
    //            clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
    //            //--VERIFICATION DU RESULTAT DU TEST
    //            if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
    //        }


    //        clsObjetEnvoi.OE_PARAM= new string[] {};
    //    DataSet DataSet = new DataSet();

    //    try
    //    {
    //        clsDonnee.pvgConnectionBase();
    //            Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


    //            foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
    //            {
    //                clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
    //                clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
    //                clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
    //                clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
    //                clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
    //                clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
    //                clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
    //                clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
    //                clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
    //                clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
    //                clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
    //                clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
    //                clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
    //                clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
    //                clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
    //                clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
    //                clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
    //                clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
    //                clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
    //                clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();
    //                clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
    //                clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


    //            }

                


    //            DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

    //            clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
    //        if (DataSet.Tables[0].Rows.Count > 0)
    //        {

    //                if (clsEditionEtatAssurance1.ET_TYPEETAT != "ASAVIEGRIMELISTE")
    //                {
    //                    foreach (DataRow row in DataSet.Tables[0].Rows)
    //                    {
    //                        HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
    //                        //clsEditionEtatAssurance.ET_INDEX = row["ET_INDEX"].ToString();
    //                        //clsEditionEtatAssurance.ET_LIBELLEEditionEtatAssurance = row["ET_LIBELLEEditionEtatAssurance"].ToString();

    //                        clsEditionEtatAssurance.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
    //                        //clsEditionEtatAssurance.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
    //                        clsEditionEtatAssurance.IDF = row["IDF"].ToString();
    //                        clsEditionEtatAssurance.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
    //                        clsEditionEtatAssurance.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
    //                        clsEditionEtatAssurance.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
    //                        clsEditionEtatAssurance.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();


    //                        if (row["CA_DATEEFFET"].ToString() != "")
    //                            clsEditionEtatAssurance.CA_DATEEFFET = DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString();
    //                        else
    //                            clsEditionEtatAssurance.CA_DATEEFFET = "";


    //                        if (row["CA_DATEECHEANCE"].ToString() != "")
    //                            clsEditionEtatAssurance.CA_DATEECHEANCE = DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString();
    //                        else
    //                            clsEditionEtatAssurance.CA_DATEECHEANCE = "";


    //                        //clsEditionEtatAssurance.CA_DATEEFFET = row["CA_DATEEFFET"].ToString();
    //                        //clsEditionEtatAssurance.CA_DATEECHEANCE = row["CA_DATEECHEANCE"].ToString();
    //                        clsEditionEtatAssurance.CA_NOMINTERLOCUTEUR = row["CA_NOMINTERLOCUTEUR"].ToString();
    //                        clsEditionEtatAssurance.CA_CONTACTINTERLOCUTEUR = row["CA_CONTACTINTERLOCUTEUR"].ToString();
    //                        clsEditionEtatAssurance.TI_IDTIERS = row["TI_IDTIERS"].ToString();
    //                        clsEditionEtatAssurance.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
    //                        clsEditionEtatAssurance.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
    //                        clsEditionEtatAssurance.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
    //                        clsEditionEtatAssurance.DESIGNATION = row["DESIGNATION"].ToString();
    //                        clsEditionEtatAssurance.PRIME = (row["PRIME"].ToString() != "") ? double.Parse(row["PRIME"].ToString()) : 0;// row["PRIME"].ToString();
    //                        clsEditionEtatAssurance.PERIODEGARANTIE = row["PERIODEGARANTIE"].ToString();
    //                        clsEditionEtatAssurance.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
    //                        clsEditionEtatAssurance.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
    //                        clsEditionEtatAssurance.DATEDEPOT = row["DATEDEPOT"].ToString();
    //                        clsEditionEtatAssurance.MONTANT = (row["MONTANT"].ToString() != "") ? double.Parse(row["MONTANT"].ToString()) : 0;// row["MONTANT"].ToString();
    //                        clsEditionEtatAssurance.MONTANTRESTAPAYER = (row["MONTANTRESTAPAYER"].ToString() != "") ? double.Parse(row["MONTANTRESTAPAYER"].ToString()) : 0;//row["MONTANTRESTAPAYER"].ToString();
    //                        clsEditionEtatAssurance.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
    //                        clsEditionEtatAssurance.ZM_CODEZONEMALADIE = row["ZM_CODEZONEMALADIE"].ToString();
    //                        clsEditionEtatAssurance.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
    //                        clsEditionEtatAssurance.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
    //                        clsEditionEtatAssurance.CA_IMMATRICULATION = row["CA_IMMATRICULATION"].ToString();
    //                        clsEditionEtatAssurance.CO_LIBELLE = row["CO_LIBELLE"].ToString();
    //                        clsEditionEtatAssurance.ZN_NOMZONE = row["ZN_NOMZONE"].ToString();
    //                        clsEditionEtatAssurance.NS_LIBELLENATURESINISTRE = row["NS_LIBELLENATURESINISTRE"].ToString();
    //                        clsEditionEtatAssurance.SI_DATESINISTRE = row["SI_DATESINISTRE"].ToString();
    //                        clsEditionEtatAssurance.SI_DOCUMENTTRANSMIS = row["SI_DOCUMENTTRANSMIS"].ToString();
    //                        clsEditionEtatAssurance.SI_DATETRANSMISSIONSINISTRE = row["SI_DATETRANSMISSIONSINISTRE"].ToString();
    //                        clsEditionEtatAssurance.SI_MONTANTPREJUDICE = (row["SI_MONTANTPREJUDICE"].ToString() != "") ? double.Parse(row["SI_MONTANTPREJUDICE"].ToString()) : 0;// row["SI_MONTANTPREJUDICE"].ToString();
    //                        clsEditionEtatAssurance.SI_NUMSINISTRE = row["SI_NUMSINISTRE"].ToString();
    //                        clsEditionEtatAssurance.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
    //                        clsEditionEtatAssurance.EP_DENOMMINATIONEXPERTNOMME = row["EP_DENOMMINATIONEXPERTNOMME"].ToString();
    //                        clsEditionEtatAssurance.SD_DESCRIPTIONEVENEMENT = row["SD_DESCRIPTIONEVENEMENT"].ToString();
    //                        clsEditionEtatAssurance.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
    //                        clsEditionEtatAssurance.TI_EMAIL = row["TI_EMAIL"].ToString();
    //                        clsEditionEtatAssurance.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
    //                        clsEditionEtatAssurance.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
    //                        clsEditionEtatAssurance.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
    //                        clsEditionEtatAssurance.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
    //                        clsEditionEtatAssurance.CH_NOMDUDEPOSANT = row["CH_NOMDUDEPOSANT"].ToString();
    //                        clsEditionEtatAssurance.CH_TELEPHONEDEPOSANT = row["CH_TELEPHONEDEPOSANT"].ToString();
    //                        clsEditionEtatAssurance.GR_LIBELLEGARENTIEPRIME = row["GR_LIBELLEGARENTIEPRIME"].ToString();
    //                        if (row["MONTANTCOMMISSION_A_PAYER"].ToString() != "")
    //                            clsEditionEtatAssurance.MONTANTCOMMISSION_A_PAYER = double.Parse(row["MONTANTCOMMISSION_A_PAYER"].ToString());
    //                        else
    //                            clsEditionEtatAssurance.MONTANTCOMMISSION_A_PAYER = 0;
    //                        if (row["MONTANTCOMMISSIONPAYER"].ToString() != "")
    //                            clsEditionEtatAssurance.MONTANTCOMMISSIONPAYER = double.Parse(row["MONTANTCOMMISSIONPAYER"].ToString());
    //                        else
    //                            clsEditionEtatAssurance.MONTANTCOMMISSIONPAYER = 0;
    //                        if (row["MONTANTCOMMISSION_RESTANT_A_PAYER"].ToString() != "")
    //                            clsEditionEtatAssurance.MONTANTCOMMISSION_RESTANT_A_PAYER = double.Parse(row["MONTANTCOMMISSION_RESTANT_A_PAYER"].ToString());
    //                        else
    //                            clsEditionEtatAssurance.MONTANTCOMMISSION_RESTANT_A_PAYER = 0;
    //                        //clsEditionEtatAssurance.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();


    //                        if (row["CH_DATESAISIECHEQUE"].ToString() != "")
    //                            clsEditionEtatAssurance.CH_DATESAISIECHEQUE = DateTime.Parse(row["CH_DATESAISIECHEQUE"].ToString()).ToShortDateString();
    //                        else
    //                            clsEditionEtatAssurance.CH_DATESAISIECHEQUE = "";



    //                        if (row["CH_VALEURCHEQUE"].ToString() != "")
    //                            clsEditionEtatAssurance.CH_VALEURCHEQUE = double.Parse(row["CH_VALEURCHEQUE"].ToString());
    //                        else
    //                            clsEditionEtatAssurance.CH_VALEURCHEQUE = 0;

    //                        if (row["CH_DATEVALIDATIONCHEQUE"].ToString() != "")
    //                            clsEditionEtatAssurance.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(row["CH_DATEVALIDATIONCHEQUE"].ToString()).ToShortDateString();
    //                        else
    //                            clsEditionEtatAssurance.CH_DATEVALIDATIONCHEQUE = "";

    //                        if (row["MONTANTCHEQUE"].ToString() != "")
    //                            clsEditionEtatAssurance.MONTANTCHEQUE = double.Parse(row["MONTANTCHEQUE"].ToString());
    //                        else
    //                            clsEditionEtatAssurance.MONTANTCHEQUE = 0;
    //                        if (row["MONTANTESPECE"].ToString() != "")
    //                            clsEditionEtatAssurance.MONTANTESPECE = double.Parse(row["MONTANTESPECE"].ToString());
    //                        else
    //                            clsEditionEtatAssurance.MONTANTESPECE = 0;

    //                        clsEditionEtatAssurance.AB_LIBELLE = row["AB_LIBELLE"].ToString();
    //                        clsEditionEtatAssurance.TA_LIBLLETYPEAFFAIRES = row["TA_LIBLLETYPEAFFAIRES"].ToString();
    //                        clsEditionEtatAssurance.CA_OBSERVATION = row["CA_OBSERVATION"].ToString();
    //                        clsEditionEtatAssurance.TI_NUMEROAXA = row["TI_NUMEROAXA"].ToString();
    //                        clsEditionEtatAssurance.TI_NUMTIERSCOMMERCIAL = row["TI_NUMTIERSCOMMERCIAL"].ToString();
    //                        clsEditionEtatAssurance.TI_DENOMINATIONCOMMERCIAL = row["TI_DENOMINATIONCOMMERCIAL"].ToString();
    //                        clsEditionEtatAssurance.TVH_LIBELE = row["TVH_LIBELE"].ToString();
    //                        clsEditionEtatAssurance.EX_EXERCICE = row["EX_EXERCICE"].ToString();
    //                        clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
    //                        clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
    //                        clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
    //                        clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
    //                        clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
    //                    }
    //                }
    //                else
    //                {
    //                    foreach (DataRow row in DataSet.Tables[0].Rows)
    //                    {
    //                        HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
    //                        clsEditionEtatAssurance.TI_IDTIERS = row["TI_IDTIERS"].ToString();
    //                        clsEditionEtatAssurance.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
    //                        clsEditionEtatAssurance.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
    //                        clsEditionEtatAssurance.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
    //                        clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
    //                        clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
    //                        clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
    //                        clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
    //                        clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
    //                    }

    //                }
    //                }

            
    //        else
    //        {
    //            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
    //            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
    //            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
    //            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
    //            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    //            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
    //        }
                


    //    }
    //    catch (SqlException SQLEx)
    //    {
    //        HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
    //        clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
    //        clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
    //        clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    //        clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT ="FALSE";
    //        //Execution du log
    //        Log.Error(SQLEx.Message, null);
    //        clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
    //        clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
    //    }
    //    catch (Exception SQLEx)
    //    {
    //        HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
    //        clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
    //        clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
    //        clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    //        clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT ="FALSE";
    //        //Execution du log
    //        Log.Error(SQLEx.Message, null);
    //        clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
    //        clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
    //    }


    //    finally
    //    {
    //        clsDonnee.pvgDeConnectionBase();
    //    }
    //    return clsEditionEtatAssurances;
    //}



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceEncaissementCheque(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }




                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssuranceEncaissementCheque(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    //string CA_CODECONTRAT = "0";
                    //int idx = 0;
                    //foreach (DataRow row in DataSet.Tables[0].Rows)
                    //{
                    //    if (idx == 0)
                    //        CA_CODECONTRAT = "''" + row["CA_CODECONTRAT"].ToString() + "''";
                    //    if (idx > 0)
                    //        CA_CODECONTRAT = CA_CODECONTRAT + "," + "''" + row["CA_CODECONTRAT"].ToString() + "''";
                    //    idx = 1;

                    //}
                    //DataSet DataSetSE = new DataSet();
                    //clsEditionEtatAssurance1.CA_CODECONTRAT = CA_CODECONTRAT;
                    //clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIMESE";
                    //DataSetSE = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                    //for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    //{
                    //    DataSet.Tables[0].Rows[i]["MONTANTESPECE"] = DataSetSE.Tables[0].Rows[0]["MONTANTESPECE"];
                    //}


                    string reportPath = "~/Etats/"; //+ Objet[0].ET_DOSSIER
                    string reportFileName = Objet[0].NOMETAT;
                    string exportFilename = "";
                    string URL_ETAT = "";
                    //string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                    //DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet,  Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);





                }


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceAppercu(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = "";// clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }




                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    string reportPath = "~/Etats/ASSURANCE";
                    string reportFileName = "EtatVentilleAffaireNouvelles.rpt";
                    string exportFilename = "";
                    string URL_ETAT = "";
                    //string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                    //DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);





                }


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }






        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceAvisReglementPrime(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListeAvisReglementPrime(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIME";// clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();

                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }

                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                 string   CA_CODECONTRAT = "0";
                    int idx = 0;
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        if (idx == 0)
                            CA_CODECONTRAT = "''" + row["CA_CODECONTRAT"].ToString() + "''";
                        if (idx > 0)
                            CA_CODECONTRAT = CA_CODECONTRAT + "," + "''" + row["CA_CODECONTRAT"].ToString() + "''";
                        idx = 1;

                    }
                    DataSet DataSetSE = new DataSet();
                    clsEditionEtatAssurance1.CA_CODECONTRAT= CA_CODECONTRAT;
                    clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIMESE";
                    DataSetSE = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["MONTANTESPECE"] = DataSetSE.Tables[0].Rows[0]["MONTANTESPECE"];
                    }



                    ////++++++++++++++++++++++++++++++
                    // DataSetSE = new DataSet();

                    //DataTable dt = new DataTable("TABLE");
                    //dt.Columns.Add(new DataColumn("IDF", typeof(int)));
                    //dt.Columns.Add(new DataColumn("CA_NUMPOLICE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_IDTIERS", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_NUMTIERS", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_DENOMINATION", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_TELEPHONE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CA_DATEEFFET", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("CA_DATEECHEANCE", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("CH_DATESAISIECHEQUE", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("CH_REFCHEQUE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_VALEURCHEQUE", typeof(double)));
                    //dt.Columns.Add(new DataColumn("CH_NOMTIREUR", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_NOMTIRE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_NOMDUDEPOSANT", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_TELEPHONEDEPOSANT", typeof(string)));
                    //dt.Columns.Add(new DataColumn("AG_CODEAGENCE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_DATEVALIDATIONCHEQUE", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("TYPEDONNE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("BQ_RAISONSOCIAL", typeof(string)));
                    //dt.Columns.Add(new DataColumn("SOURCEDONNE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("PRIME", typeof(double)));
                    //dt.Columns.Add(new DataColumn("MONTANTESPECE", typeof(double)));
                    //dt.Columns.Add(new DataColumn("MONTANTCHEQUE", typeof(double)));
                    ////for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    ////{
                    //    DataRow dr = dt.NewRow();
                    //    dr["IDF"] = "1";
                    //    dr["CA_NUMPOLICE"] = "ATLA";
                    //    dr["TI_IDTIERS"] = "1";
                    //    dr["TI_NUMTIERS"] = "1";
                    //    dr["TI_DENOMINATION"] = "1";
                    //    dr["TI_TELEPHONE"] = "1";
                    //    dr["CA_DATEEFFET"] = DateTime.Parse("18/02/2022");
                    //    dr["CA_DATEECHEANCE"] = DateTime.Parse("18/02/2022");
                    //    dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                    //    dr["CH_REFCHEQUE"] = "1";
                    //    dr["CH_VALEURCHEQUE"] = "1000";
                    //    dr["CH_NOMTIREUR"] = "1000";
                    //    dr["CH_NOMTIRE"] = "1000";
                    //    dr["CH_NOMDUDEPOSANT"] = "1000";
                    //    dr["CH_TELEPHONEDEPOSANT"] = "1000";
                    //    dr["AG_CODEAGENCE"] = "1000";
                    //    dr["CH_DATEVALIDATIONCHEQUE"] = DateTime.Parse("18/02/2022");
                    //    dr["TYPEDONNE"] = "SE";
                    //    dr["BQ_RAISONSOCIAL"] = "1000";
                    //    dr["SOURCEDONNE"] = "DIF";
                    //    dr["PRIME"] = "1000";
                    //    dr["MONTANTESPECE"] = "1000";
                    //    dr["MONTANTCHEQUE"] = "1000";
                    //    //dr["MONTANT"] = DataSet.Tables[0].Rows[i]["MONTANT"];
                    //    //dr["CA_NUMPOLICE"] = DataSet.Tables[0].Rows[i]["CA_NUMPOLICE"].ToString();
                    //    //dr["CA_DATEEFFET"] = DataSet.Tables[0].Rows[i]["CA_DATEEFFET"];
                    //    //dr["PRIME"] = DataSet.Tables[0].Rows[i]["PRIME"];
                    //    //dr["AG_CODEAGENCE"] = DataSet.Tables[0].Rows[i]["AG_CODEAGENCE"].ToString();
                    //    //dr["TI_DENOMINATION"] = DataSet.Tables[0].Rows[i]["TI_DENOMINATION"].ToString();
                    //    //dr["TI_NUMTIERS"] = DataSet.Tables[0].Rows[i]["TI_NUMTIERS"].ToString();
                    //    //dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                    //    //dr["CA_NOMINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_NOMINTERLOCUTEUR"].ToString();
                    //    //dr["CA_DATEECHEANCE"] = DataSet.Tables[0].Rows[i]["CA_DATEECHEANCE"];
                    //    //dr["CA_CONTACTINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_CONTACTINTERLOCUTEUR"].ToString();
                    //    //dr["RQ_LIBELLERISQUE"] = DataSet.Tables[0].Rows[i]["RQ_LIBELLERISQUE"].ToString();

                    //    dt.Rows.Add(dr);



                    ////}


                    //DataSetSE.Tables.Add(dt);
                    ////+++++++++++++++++++++++++++++










                    string reportPath = "~/Etats/"; //+ Objet[0].ET_DOSSIER
                    string reportFileName = Objet[0].ET_NOMETAT;
                    string exportFilename = "";
                    string URL_ETAT = "";
                    string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                    DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, vppFichierSousEtat, vppDataSetSousEtat, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);



                   

                }


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceAnnuler(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListeAvisReglementPrime(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIME";// clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();

                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }

                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssuranceAnnuler(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    string CA_CODECONTRAT = "0";
                    int idx = 0;
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        if (idx == 0)
                            CA_CODECONTRAT = "''" + row["CA_CODECONTRAT"].ToString() + "''";
                        if (idx > 0)
                            CA_CODECONTRAT = CA_CODECONTRAT + "," + "''" + row["CA_CODECONTRAT"].ToString() + "''";
                        idx = 1;

                    }
                    DataSet DataSetSE = new DataSet();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = CA_CODECONTRAT;
                    clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIMESE";
                    DataSetSE = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["MONTANTESPECE"] = DataSetSE.Tables[0].Rows[0]["MONTANTESPECE"];
                    }



                    ////++++++++++++++++++++++++++++++
                    // DataSetSE = new DataSet();

                    //DataTable dt = new DataTable("TABLE");
                    //dt.Columns.Add(new DataColumn("IDF", typeof(int)));
                    //dt.Columns.Add(new DataColumn("CA_NUMPOLICE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_IDTIERS", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_NUMTIERS", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_DENOMINATION", typeof(string)));
                    //dt.Columns.Add(new DataColumn("TI_TELEPHONE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CA_DATEEFFET", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("CA_DATEECHEANCE", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("CH_DATESAISIECHEQUE", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("CH_REFCHEQUE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_VALEURCHEQUE", typeof(double)));
                    //dt.Columns.Add(new DataColumn("CH_NOMTIREUR", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_NOMTIRE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_NOMDUDEPOSANT", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_TELEPHONEDEPOSANT", typeof(string)));
                    //dt.Columns.Add(new DataColumn("AG_CODEAGENCE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("CH_DATEVALIDATIONCHEQUE", typeof(DateTime)));
                    //dt.Columns.Add(new DataColumn("TYPEDONNE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("BQ_RAISONSOCIAL", typeof(string)));
                    //dt.Columns.Add(new DataColumn("SOURCEDONNE", typeof(string)));
                    //dt.Columns.Add(new DataColumn("PRIME", typeof(double)));
                    //dt.Columns.Add(new DataColumn("MONTANTESPECE", typeof(double)));
                    //dt.Columns.Add(new DataColumn("MONTANTCHEQUE", typeof(double)));
                    ////for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    ////{
                    //    DataRow dr = dt.NewRow();
                    //    dr["IDF"] = "1";
                    //    dr["CA_NUMPOLICE"] = "ATLA";
                    //    dr["TI_IDTIERS"] = "1";
                    //    dr["TI_NUMTIERS"] = "1";
                    //    dr["TI_DENOMINATION"] = "1";
                    //    dr["TI_TELEPHONE"] = "1";
                    //    dr["CA_DATEEFFET"] = DateTime.Parse("18/02/2022");
                    //    dr["CA_DATEECHEANCE"] = DateTime.Parse("18/02/2022");
                    //    dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                    //    dr["CH_REFCHEQUE"] = "1";
                    //    dr["CH_VALEURCHEQUE"] = "1000";
                    //    dr["CH_NOMTIREUR"] = "1000";
                    //    dr["CH_NOMTIRE"] = "1000";
                    //    dr["CH_NOMDUDEPOSANT"] = "1000";
                    //    dr["CH_TELEPHONEDEPOSANT"] = "1000";
                    //    dr["AG_CODEAGENCE"] = "1000";
                    //    dr["CH_DATEVALIDATIONCHEQUE"] = DateTime.Parse("18/02/2022");
                    //    dr["TYPEDONNE"] = "SE";
                    //    dr["BQ_RAISONSOCIAL"] = "1000";
                    //    dr["SOURCEDONNE"] = "DIF";
                    //    dr["PRIME"] = "1000";
                    //    dr["MONTANTESPECE"] = "1000";
                    //    dr["MONTANTCHEQUE"] = "1000";
                    //    //dr["MONTANT"] = DataSet.Tables[0].Rows[i]["MONTANT"];
                    //    //dr["CA_NUMPOLICE"] = DataSet.Tables[0].Rows[i]["CA_NUMPOLICE"].ToString();
                    //    //dr["CA_DATEEFFET"] = DataSet.Tables[0].Rows[i]["CA_DATEEFFET"];
                    //    //dr["PRIME"] = DataSet.Tables[0].Rows[i]["PRIME"];
                    //    //dr["AG_CODEAGENCE"] = DataSet.Tables[0].Rows[i]["AG_CODEAGENCE"].ToString();
                    //    //dr["TI_DENOMINATION"] = DataSet.Tables[0].Rows[i]["TI_DENOMINATION"].ToString();
                    //    //dr["TI_NUMTIERS"] = DataSet.Tables[0].Rows[i]["TI_NUMTIERS"].ToString();
                    //    //dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                    //    //dr["CA_NOMINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_NOMINTERLOCUTEUR"].ToString();
                    //    //dr["CA_DATEECHEANCE"] = DataSet.Tables[0].Rows[i]["CA_DATEECHEANCE"];
                    //    //dr["CA_CONTACTINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_CONTACTINTERLOCUTEUR"].ToString();
                    //    //dr["RQ_LIBELLERISQUE"] = DataSet.Tables[0].Rows[i]["RQ_LIBELLERISQUE"].ToString();

                    //    dt.Rows.Add(dr);



                    ////}


                    //DataSetSE.Tables.Add(dt);
                    ////+++++++++++++++++++++++++++++

                    string reportPath = "~/Etats/"; //+ Objet[0].ET_DOSSIER
                    string reportFileName = Objet[0].ET_NOMETAT;
                    string exportFilename = "";
                    string URL_ETAT = "";
                    string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                    DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, vppFichierSousEtat, vppDataSetSousEtat, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);





                }


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceReglementAnnuler(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListeAvisReglementPrimeAnnuler(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIMESE";// clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCLIENT = clsEditionEtatAssuranceDTO.TI_IDTIERSCLIENT.ToString();
                    clsEditionEtatAssurance1.EX_EXERCICE = clsEditionEtatAssuranceDTO.EX_EXERCICE.ToString();

                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }

                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssuranceAnnuler(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    string reportPath = "~/Etats/"; //+ Objet[0].ET_DOSSIER
                    string reportFileName = Objet[0].ET_NOMETAT;
                    string exportFilename = "";
                    string URL_ETAT = "";
                    //string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                    //DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);





                }

                //if (DataSet.Tables[0].Rows.Count > 0)
                //{

                //    string CA_CODECONTRAT = "0";
                //    int idx = 0;
                //    foreach (DataRow row in DataSet.Tables[0].Rows)
                //    {
                //        if (idx == 0)
                //            CA_CODECONTRAT = "''" + row["CA_CODECONTRAT"].ToString() + "''";
                //        if (idx > 0)
                //            CA_CODECONTRAT = CA_CODECONTRAT + "," + "''" + row["CA_CODECONTRAT"].ToString() + "''";
                //        idx = 1;

                //    }
                //    DataSet DataSetSE = new DataSet();
                //    clsEditionEtatAssurance1.CA_CODECONTRAT = CA_CODECONTRAT;
                //    clsEditionEtatAssurance1.ET_TYPEETAT = "ASAVIEGRIMESE";
                //    DataSetSE = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);

                //    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                //    {
                //        DataSet.Tables[0].Rows[i]["MONTANTESPECE"] = DataSetSE.Tables[0].Rows[0]["MONTANTESPECE"];
                //    }



                //    ////++++++++++++++++++++++++++++++
                //    // DataSetSE = new DataSet();

                //    //DataTable dt = new DataTable("TABLE");
                //    //dt.Columns.Add(new DataColumn("IDF", typeof(int)));
                //    //dt.Columns.Add(new DataColumn("CA_NUMPOLICE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("TI_IDTIERS", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("TI_NUMTIERS", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("TI_DENOMINATION", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("TI_TELEPHONE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("CA_DATEEFFET", typeof(DateTime)));
                //    //dt.Columns.Add(new DataColumn("CA_DATEECHEANCE", typeof(DateTime)));
                //    //dt.Columns.Add(new DataColumn("CH_DATESAISIECHEQUE", typeof(DateTime)));
                //    //dt.Columns.Add(new DataColumn("CH_REFCHEQUE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("CH_VALEURCHEQUE", typeof(double)));
                //    //dt.Columns.Add(new DataColumn("CH_NOMTIREUR", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("CH_NOMTIRE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("CH_NOMDUDEPOSANT", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("CH_TELEPHONEDEPOSANT", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("AG_CODEAGENCE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("CH_DATEVALIDATIONCHEQUE", typeof(DateTime)));
                //    //dt.Columns.Add(new DataColumn("TYPEDONNE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("BQ_RAISONSOCIAL", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("SOURCEDONNE", typeof(string)));
                //    //dt.Columns.Add(new DataColumn("PRIME", typeof(double)));
                //    //dt.Columns.Add(new DataColumn("MONTANTESPECE", typeof(double)));
                //    //dt.Columns.Add(new DataColumn("MONTANTCHEQUE", typeof(double)));
                //    ////for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                //    ////{
                //    //    DataRow dr = dt.NewRow();
                //    //    dr["IDF"] = "1";
                //    //    dr["CA_NUMPOLICE"] = "ATLA";
                //    //    dr["TI_IDTIERS"] = "1";
                //    //    dr["TI_NUMTIERS"] = "1";
                //    //    dr["TI_DENOMINATION"] = "1";
                //    //    dr["TI_TELEPHONE"] = "1";
                //    //    dr["CA_DATEEFFET"] = DateTime.Parse("18/02/2022");
                //    //    dr["CA_DATEECHEANCE"] = DateTime.Parse("18/02/2022");
                //    //    dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                //    //    dr["CH_REFCHEQUE"] = "1";
                //    //    dr["CH_VALEURCHEQUE"] = "1000";
                //    //    dr["CH_NOMTIREUR"] = "1000";
                //    //    dr["CH_NOMTIRE"] = "1000";
                //    //    dr["CH_NOMDUDEPOSANT"] = "1000";
                //    //    dr["CH_TELEPHONEDEPOSANT"] = "1000";
                //    //    dr["AG_CODEAGENCE"] = "1000";
                //    //    dr["CH_DATEVALIDATIONCHEQUE"] = DateTime.Parse("18/02/2022");
                //    //    dr["TYPEDONNE"] = "SE";
                //    //    dr["BQ_RAISONSOCIAL"] = "1000";
                //    //    dr["SOURCEDONNE"] = "DIF";
                //    //    dr["PRIME"] = "1000";
                //    //    dr["MONTANTESPECE"] = "1000";
                //    //    dr["MONTANTCHEQUE"] = "1000";
                //    //    //dr["MONTANT"] = DataSet.Tables[0].Rows[i]["MONTANT"];
                //    //    //dr["CA_NUMPOLICE"] = DataSet.Tables[0].Rows[i]["CA_NUMPOLICE"].ToString();
                //    //    //dr["CA_DATEEFFET"] = DataSet.Tables[0].Rows[i]["CA_DATEEFFET"];
                //    //    //dr["PRIME"] = DataSet.Tables[0].Rows[i]["PRIME"];
                //    //    //dr["AG_CODEAGENCE"] = DataSet.Tables[0].Rows[i]["AG_CODEAGENCE"].ToString();
                //    //    //dr["TI_DENOMINATION"] = DataSet.Tables[0].Rows[i]["TI_DENOMINATION"].ToString();
                //    //    //dr["TI_NUMTIERS"] = DataSet.Tables[0].Rows[i]["TI_NUMTIERS"].ToString();
                //    //    //dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                //    //    //dr["CA_NOMINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_NOMINTERLOCUTEUR"].ToString();
                //    //    //dr["CA_DATEECHEANCE"] = DataSet.Tables[0].Rows[i]["CA_DATEECHEANCE"];
                //    //    //dr["CA_CONTACTINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_CONTACTINTERLOCUTEUR"].ToString();
                //    //    //dr["RQ_LIBELLERISQUE"] = DataSet.Tables[0].Rows[i]["RQ_LIBELLERISQUE"].ToString();

                //    //    dt.Rows.Add(dr);



                //    ////}


                //    //DataSetSE.Tables.Add(dt);
                //    ////+++++++++++++++++++++++++++++

                //    string reportPath = "~/Etats/"; //+ Objet[0].ET_DOSSIER
                //    string reportFileName = Objet[0].ET_NOMETAT;
                //    string exportFilename = "";
                //    string URL_ETAT = "";
                //    string[] vppFichierSousEtat = new string[] { "EtatReglementPrime.rpt" };
                //    DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                //    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, vppFichierSousEtat, vppDataSetSousEtat, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                //    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                //    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                //    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                //    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                //    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                //    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                //    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);





                //}


                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceTESTETAT(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.ZN_CODEZONECOMMERCIAL = clsEditionEtatAssuranceDTO.ZN_CODEZONECOMMERCIAL.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }

                DataSet DataSetSE = new DataSet();

                DataTable dt = new DataTable("TABLE");
                dt.Columns.Add(new DataColumn("MV_REFERENCEPIECE", typeof(string)));
                dt.Columns.Add(new DataColumn("BQ_RAISONSOCIAL", typeof(string)));
                dt.Columns.Add(new DataColumn("DATEDEPOT", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("MONTANT", typeof(double)));
                dt.Columns.Add(new DataColumn("CA_NUMPOLICE", typeof(string)));
                dt.Columns.Add(new DataColumn("CA_DATEEFFET", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("PRIME", typeof(double)));
                dt.Columns.Add(new DataColumn("AG_CODEAGENCE", typeof(string)));
                dt.Columns.Add(new DataColumn("TI_DENOMINATION", typeof(string)));
                dt.Columns.Add(new DataColumn("TI_NUMTIERS", typeof(string)));
                dt.Columns.Add(new DataColumn("CH_DATESAISIECHEQUE", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("CA_NOMINTERLOCUTEUR", typeof(string)));
                dt.Columns.Add(new DataColumn("CA_DATEECHEANCE", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("CA_CONTACTINTERLOCUTEUR", typeof(string)));
                dt.Columns.Add(new DataColumn("RQ_LIBELLERISQUE", typeof(string)));


                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);


                for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["MV_REFERENCEPIECE"] = DataSet.Tables[0].Rows[i]["MV_REFERENCEPIECE"].ToString();
                    dr["BQ_RAISONSOCIAL"] = "ATLA";
                    dr["DATEDEPOT"] = DateTime.Parse("18/02/2022");
                    dr["MONTANT"] = DataSet.Tables[0].Rows[i]["MONTANT"];
                    dr["CA_NUMPOLICE"] = DataSet.Tables[0].Rows[i]["CA_NUMPOLICE"].ToString();
                    dr["CA_DATEEFFET"] = DataSet.Tables[0].Rows[i]["CA_DATEEFFET"];
                    dr["PRIME"] = DataSet.Tables[0].Rows[i]["PRIME"];
                    dr["AG_CODEAGENCE"] = DataSet.Tables[0].Rows[i]["AG_CODEAGENCE"].ToString();
                    dr["TI_DENOMINATION"] = DataSet.Tables[0].Rows[i]["TI_DENOMINATION"].ToString();
                    dr["TI_NUMTIERS"] = DataSet.Tables[0].Rows[i]["TI_NUMTIERS"].ToString();
                    dr["CH_DATESAISIECHEQUE"] = DateTime.Parse("18/02/2022");
                    dr["CA_NOMINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_NOMINTERLOCUTEUR"].ToString();
                    dr["CA_DATEECHEANCE"] = DataSet.Tables[0].Rows[i]["CA_DATEECHEANCE"];
                    dr["CA_CONTACTINTERLOCUTEUR"] = DataSet.Tables[0].Rows[i]["CA_CONTACTINTERLOCUTEUR"].ToString();
                    dr["RQ_LIBELLERISQUE"] = DataSet.Tables[0].Rows[i]["RQ_LIBELLERISQUE"].ToString();

                    dt.Rows.Add(dr);



                }


                DataSetSE.Tables.Add(dt);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    string reportPath = "~/Etats/" + Objet[0].ET_DOSSIER;
                    string reportFileName = Objet[0].ET_NOMETAT;
                    string exportFilename = "";
                    string URL_ETAT = "";
                    string[] vppFichierSousEtat = new string[] { "SituationCompteClientTestSE.rpt" };
                    DataSet[] vppDataSetSousEtat = new DataSet[] { DataSetSE };
                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport(reportPath, reportFileName, exportFilename, DataSet, vppFichierSousEtat, vppDataSetSousEtat, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.URL_ETAT = URL_ETAT;
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                    
                }
                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatAssurances;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatSynoptique(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListeSynoptique(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatSynoptique(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                       
                        clsEditionEtatAssurance.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                        clsEditionEtatAssurance.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                        clsEditionEtatAssurance.TI_IDTIERSCOMMERCIAL = row["TI_IDTIERSCOMMERCIAL"].ToString();
                        clsEditionEtatAssurance.TI_NUMTIERSCOMMERCIAL = row["TI_NUMTIERSCOMMERCIAL"].ToString();
                        clsEditionEtatAssurance.TI_DENOMINATIONCOMMERCIAL = row["TI_DENOMINATIONCOMMERCIAL"].ToString();

                        if (row["CHIFFREAFFAIRE"].ToString() != "")
                            clsEditionEtatAssurance.CHIFFREAFFAIRE = double.Parse(row["CHIFFREAFFAIRE"].ToString());
                        if (row["RENOUVELLEMENT"].ToString() != "")
                            clsEditionEtatAssurance.RENOUVELLEMENT = double.Parse(row["RENOUVELLEMENT"].ToString());
                        if (row["AFFAIRENOUVELLE"].ToString() != "")
                            clsEditionEtatAssurance.AFFAIRENOUVELLE = double.Parse(row["AFFAIRENOUVELLE"].ToString());

                        clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatAssurances;
    }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public object pvgInsertIntoDatasetEtatAssuranceTest(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            object TEST = new object();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatAssurances = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
                //--TEST CONTRAINTE
                clsEditionEtatAssurances = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatAssurances[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatAssurances;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance1 = new Stock.BOJ.clsEditionEtatAssurance();


                foreach (HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssuranceDTO in Objet)
                {
                    clsEditionEtatAssurance1.AG_CODEAGENCE = clsEditionEtatAssuranceDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatAssurance1.EN_CODEENTREPOT = clsEditionEtatAssuranceDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatAssurance1.CA_CODECONTRAT = clsEditionEtatAssuranceDTO.CA_CODECONTRAT.ToString();
                    clsEditionEtatAssurance1.DATEDEBUT = clsEditionEtatAssuranceDTO.DATEDEBUT.ToString();
                    clsEditionEtatAssurance1.DATEFIN = clsEditionEtatAssuranceDTO.DATEFIN.ToString();
                    clsEditionEtatAssurance1.OP_CODEOPERATEUREDITION = clsEditionEtatAssuranceDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatAssurance1.RQ_CODERISQUE = clsEditionEtatAssuranceDTO.RQ_CODERISQUE.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERS = clsEditionEtatAssuranceDTO.TI_IDTIERS.ToString();
                    clsEditionEtatAssurance1.TI_IDTIERSCOMMERCIAL = clsEditionEtatAssuranceDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsEditionEtatAssurance1.PY_CODEPAYS = clsEditionEtatAssuranceDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatAssurance1.VL_CODEVILLE = clsEditionEtatAssuranceDTO.VL_CODEVILLE.ToString();
                    clsEditionEtatAssurance1.CO_CODECOMMUNE = clsEditionEtatAssuranceDTO.CO_CODECOMMUNE.ToString();
                    clsEditionEtatAssurance1.ZA_CODEZONEAUTO = clsEditionEtatAssuranceDTO.ZA_CODEZONEAUTO.ToString();
                    clsEditionEtatAssurance1.NS_CODENATURESINISTRE = clsEditionEtatAssuranceDTO.NS_CODENATURESINISTRE.ToString();
                    clsEditionEtatAssurance1.TA_CODETYPEAFFAIRES = clsEditionEtatAssuranceDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsEditionEtatAssurance1.CT_CODESTAUT = clsEditionEtatAssuranceDTO.CT_CODESTAUT.ToString();
                    clsEditionEtatAssurance1.ET_TYPEETAT = clsEditionEtatAssuranceDTO.ET_TYPEETAT.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatAssuranceDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatAssuranceWSBLL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance1, clsObjetEnvoi);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    //TEST= DataTableToJSON(DataSet.Tables[0]);

                   // TEST=DataTableToJSONWithJavaScriptSerializer(DataSet.Tables[0]);
                    TEST= DataTableToJSONWithStringBuilder(DataSet.Tables[0]);


                }
                else
                {
                    HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);

                
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return TEST;
        }


        public static object DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(list);
        }


        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }


    }
}
