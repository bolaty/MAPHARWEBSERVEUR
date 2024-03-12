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

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEdition" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEdition.svc ou wsEdition.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEdition : IwsEdition
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionWSBLL clsEditionWSBLL = new clsEditionWSBLL();
        private string vppDateDebut = "";
        private string  vppDateFin = "";
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



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEdition> pvgInsertIntoDatasetExercice(List<HT_Stock.BOJ.clsEdition> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsEditions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
        //    //--TEST CONTRAINTE
        //    clsEditions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
        //}


        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsEditionWSBLL.pvgInsertIntoDatasetExercice(clsDonnee, clsObjetEnvoi);
        clsEditions = new List<HT_Stock.BOJ.clsEdition>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                //clsEdition.AG_CODEAGENCE = row["AG_CODEAGENCE "].ToString();
                clsEdition.EX_EXERCICE = row["EX_EXERCICE"].ToString();
                //clsEdition.JT_DATEJOURNEETRAVAIL = row["JT_DATEJOURNEETRAVAIL"].ToString();
                //clsEdition.EX_DATEDEBUT = row["EX_DATEDEBUT"].ToString();
                //clsEdition.EX_DATEFIN = row["EX_DATEFIN"].ToString();
                //clsEdition.EX_DESCEXERCICE = row["EX_DESCEXERCICE"].ToString();
                //clsEdition.EX_ETATEXERCICE = row["EX_ETATEXERCICE"].ToString();
                //clsEdition.EX_DATESAISIE = row["EX_DATESAISIE"].ToString();
                //clsEdition.EX_DATEDEBUTBILAN = row["EX_DATEDEBUTBILAN"].ToString();
                //clsEdition.EX_DATEFINBILAN = row["EX_DATEFINBILAN"].ToString();
                //clsEdition.EX_DATEAFFECTATIONRESULTAT = row["EX_DATEAFFECTATIONRESULTAT"].ToString();

                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEdition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsEditions.Add(clsEdition);
            }
        }
        else
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsEdition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsEditions.Add(clsEdition);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
        clsEdition.clsObjetRetour = new Common.clsObjetRetour();
        clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsEditions = new List<HT_Stock.BOJ.clsEdition>();
        clsEditions.Add(clsEdition);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
        clsEdition.clsObjetRetour = new Common.clsObjetRetour();
        clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsEditions = new List<HT_Stock.BOJ.clsEdition>();
        clsEditions.Add(clsEdition);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsEditions;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEdition> pvgInsertIntoDatasetPeriodicite(List<HT_Stock.BOJ.clsEdition> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsEditions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
        //    //--TEST CONTRAINTE
        //    clsEditions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEditionWSBLL.pvgInsertIntoDatasetPeriodicite(clsDonnee, clsObjetEnvoi);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                    clsEdition.PE_CODEPERIODICITE = row["PE_CODEPERIODICITE"].ToString();
                    clsEdition.PE_LIBELLE = row["PE_LIBELLE"].ToString();
                    clsEdition.PE_ABREVIATION = row["PE_ABREVIATION"].ToString();
                    clsEdition.PE_UNITE = row["PE_UNITE"].ToString();
                    clsEdition.PE_PERIODICITE = row["PE_PERIODICITE"].ToString();
                    clsEdition.PE_MULTIPLE = row["PE_MULTIPLE"].ToString();
                    clsEdition.PE_PRODUCTIONETATFINANCIER = row["PE_PRODUCTIONETATFINANCIER"].ToString();
                    clsEdition.PE_PROCEDUREAUTOMATIQUE = row["PE_PROCEDUREAUTOMATIQUE"].ToString();
                    clsEdition.PE_ORDREVIREMENT = row["PE_ORDREVIREMENT"].ToString();
                    clsEdition.PE_NUMEROORDRE = row["PE_NUMEROORDRE"].ToString();
                    clsEdition.PE_ACTIF = row["PE_ACTIF"].ToString();
                        //private string _PE_CODEPERIODICITE = "";
                        //private string _PE_LIBELLE = "";
                        //private string _PE_ABREVIATION = "";
                        //private string _PE_UNITE = "";
                        //private string _PE_PERIODICITE = "";
                        //private string _PE_MULTIPLE = "";
                        //private string _PE_PRODUCTIONETATFINANCIER = "";
                        //private string _PE_PROCEDUREAUTOMATIQUE = "";
                        //private string _PE_ORDREVIREMENT = "";
                        //private string _PE_NUMEROORDRE = "";
                        //private string _PE_ACTIF = "";




                        clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                    clsEdition.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEdition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditions.Add(clsEdition);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditions.Add(clsEdition);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditions;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEdition> pvgInsertIntoDatasetZone(List<HT_Stock.BOJ.clsEdition> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsEditions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
        //    //--TEST CONTRAINTE
        //    clsEditions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEditionWSBLL.pvgInsertIntoDatasetZone(clsDonnee, clsObjetEnvoi);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                    clsEdition.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                    clsEdition.ZN_NOMZONE = row["ZN_NOMZONE"].ToString();
                    clsEdition.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
                    clsEdition.ZN_DESCRIPTION = row["ZN_DESCRIPTION"].ToString();
                    
                        //ZN_CODEZONE,ZN_NOMZONE,SO_CODESOCIETE,ZN_DESCRIPTION




                        clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                    clsEdition.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEdition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditions.Add(clsEdition);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditions.Add(clsEdition);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditions;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEdition> pvgChargerDansDataSetPourComboAgenceEdition(List<HT_Stock.BOJ.clsEdition> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditions = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
                //--TEST CONTRAINTE
                clsEditions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].EX_EXERCICE,Objet[0].SO_CODESOCIETE,Objet[0].ZN_CODEZONE, Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEditionWSBLL.pvgChargerDansDataSetPourComboAgenceEdition(clsDonnee, clsObjetEnvoi);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                    clsEdition.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsEdition.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                    clsEdition.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                  
                    
                        //ZN_CODEZONE,ZN_NOMZONE,SO_CODESOCIETE,ZN_DESCRIPTION




                        clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                    clsEdition.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEdition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditions.Add(clsEdition);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditions.Add(clsEdition);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditions;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEdition> pvgPeriodicite(List<HT_Stock.BOJ.clsEdition> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditions = TestChampObligatoireListePeriodicite(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
                //--TEST CONTRAINTE
                clsEditions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].PE_CODEPERIODICITE};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEditionWSBLL.pvgPeriodicite(clsDonnee, clsObjetEnvoi);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                    clsEdition.MO_CODEMOIS = row["MO_CODEMOIS"].ToString();
                    clsEdition.MO_LIBELLE = row["MO_LIBELLE"].ToString();
                  
                    
                        //ZN_CODEZONE,ZN_NOMZONE,SO_CODESOCIETE,ZN_DESCRIPTION




                        clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                    clsEdition.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEdition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditions.Add(clsEdition);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditions.Add(clsEdition);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditions;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEdition> pvgPeriodiciteDateDebutFin(List<HT_Stock.BOJ.clsEdition> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditions = TestChampObligatoireListePeriodiciteDateFin(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
                //--TEST CONTRAINTE
                clsEditions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditions;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].EX_EXERCICE, Objet[0].MO_CODEMOIS,    Objet[0].PE_CODEPERIODICITE};
            DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEditionWSBLL.pvgPeriodiciteDateDebutFin(clsDonnee, clsObjetEnvoi);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();

                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].EX_EXERCICE, Objet[0].MO_CODEMOIS, Objet[0].PE_CODEPERIODICITE,"" };
                pvgPeriodiciteDateDebutFin(DateTime.Parse( Objet[0].JT_DATEJOURNEETRAVAIL), DataSet, clsObjetEnvoi.OE_PARAM);

                HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
                clsEdition.MO_DATEDEBUT = vppDateDebut ;
                clsEdition.MO_DATEFIN = vppDateFin;

                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "00";
                clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                clsEditions.Add(clsEdition);


            //    if (DataSet.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow row in DataSet.Tables[0].Rows)
            //    {
            //        HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            //        clsEdition.MO_DATEDEBUT = row["MO_DATEDEBUT"].ToString();
            //        clsEdition.MO_DATEFIN = row["MO_DATEFIN"].ToString();
                  
                    
            //            //ZN_CODEZONE,ZN_NOMZONE,SO_CODESOCIETE,ZN_DESCRIPTION




            //            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            //        clsEdition.clsObjetRetour.SL_CODEMESSAGE ="00";
            //        clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
            //        clsEdition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
            //        clsEditions.Add(clsEdition);
            //    }
            //}
            //else
            //{
            //    HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            //    clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            //    clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            //    clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEdition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            //    clsEditions.Add(clsEdition);
            //}
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEdition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEdition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            clsEditions.Add(clsEdition);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditions;
        }



        public void pvgPeriodiciteDateDebutFin(DateTime JT_DATEJOURNEETRAVAIL, DataSet vlpDataSet, params string[] vppCritere)
        {
            vppDateDebut = vppDateFin = "";
            //DataSet vlpDataSet = new DataSet();
            //vlpDataSet = pvgPeriodiciteDateDebutFin(pvpRecuperationParametreObjet(new clsObjetEnvoi(), vppCritere)).OR_DATASET;
            if (vlpDataSet.Tables.Count > 0)
            {
                if (vlpDataSet.Tables[0].Rows.Count > 0)
                {
                    vppDateDebut = DateTime.Parse(vlpDataSet.Tables[0].Rows[0][0].ToString()).ToShortDateString();
                    if (vppCritere[3] == "")
                    {
                        if (DateTime.Parse(vlpDataSet.Tables[0].Rows[0][1].ToString()) > JT_DATEJOURNEETRAVAIL)
                        {
                            vppDateFin = JT_DATEJOURNEETRAVAIL.ToShortDateString();
                        }
                        else
                        {
                            vppDateFin = DateTime.Parse(vlpDataSet.Tables[0].Rows[0][1].ToString()).ToShortDateString();
                        }
                    }
                    else
                        vppDateFin = DateTime.Parse(vlpDataSet.Tables[0].Rows[0][1].ToString()).ToShortDateString();
                }
            }
        }


    }
}
