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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsTypejournal" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsTypejournal.svc ou wsTypejournal.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsTypejournal : IwsTypejournal
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsTypejournalWSBLL clsTypejournalWSBLL = new clsTypejournalWSBLL();

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
        public List<HT_Stock.BOJ.clsTypejournal> pvgAjouter(List<HT_Stock.BOJ.clsTypejournal> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypejournals = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
                //--TEST CONTRAINTE
                clsTypejournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsTypejournal clsTypejournalDTO in Objet)
                {
                    Stock.BOJ.clsTypejournal clsTypejournal = new Stock.BOJ.clsTypejournal();
                    clsTypejournal.TJ_CODETYPEJOURNAL = clsTypejournalDTO.TJ_CODETYPEJOURNAL.ToString();
                    clsTypejournal.TJ_LIBELLE = clsTypejournalDTO.TJ_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsTypejournalDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsTypejournalDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsTypejournalWSBLL.pvgAjouter(clsDonnee, clsTypejournal, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypejournals.Add(clsTypejournal);
                }
                else
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypejournals.Add(clsTypejournal);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                clsTypejournals.Add(clsTypejournal);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                clsTypejournals.Add(clsTypejournal);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypejournals;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypejournal> pvgModifier(List<HT_Stock.BOJ.clsTypejournal> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypejournals = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
                //--TEST CONTRAINTE
                clsTypejournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsTypejournal clsTypejournalDTO in Objet)
                {
                    Stock.BOJ.clsTypejournal clsTypejournal = new Stock.BOJ.clsTypejournal();
                    clsTypejournal.TJ_CODETYPEJOURNAL = clsTypejournalDTO.TJ_CODETYPEJOURNAL.ToString();
                    clsTypejournal.TJ_LIBELLE = clsTypejournalDTO.TJ_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsTypejournalDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsTypejournalDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsTypejournalDTO.TJ_CODETYPEJOURNAL };
                    clsObjetRetour.SetValue(true, clsTypejournalWSBLL.pvgModifier(clsDonnee, clsTypejournal, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypejournals.Add(clsTypejournal);
                }
                else
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypejournals.Add(clsTypejournal);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                clsTypejournals.Add(clsTypejournal);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                clsTypejournals.Add(clsTypejournal);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypejournals;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypejournal> pvgSupprimer(List<HT_Stock.BOJ.clsTypejournal> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypejournals = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
                //--TEST CONTRAINTE
                clsTypejournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TJ_CODETYPEJOURNAL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsTypejournalWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypejournals.Add(clsTypejournal);
                }
                else
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypejournals.Add(clsTypejournal);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                clsTypejournals.Add(clsTypejournal);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
                clsTypejournals.Add(clsTypejournal);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypejournals;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsTypejournal> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsTypejournal> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsTypejournals = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
            //    //--TEST CONTRAINTE
            //    clsTypejournals = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsTypejournalWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.TJ_CODETYPEJOURNAL = row["TJ_CODETYPEJOURNAL"].ToString();
                    clsTypejournal.TJ_LIBELLE = row["TJ_LIBELLE"].ToString();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypejournals.Add(clsTypejournal);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypejournals.Add(clsTypejournal);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
            clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypejournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            clsTypejournals.Add(clsTypejournal);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
            clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypejournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            clsTypejournals.Add(clsTypejournal);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsTypejournals;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypejournal> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsTypejournal> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsTypejournals = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
        //    //--TEST CONTRAINTE
        //    clsTypejournals = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypejournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypejournals;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsTypejournalWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                    clsTypejournal.TJ_CODETYPEJOURNAL = row["TJ_CODETYPEJOURNAL"].ToString();
                    clsTypejournal.TJ_LIBELLE = row["TJ_LIBELLE"].ToString();
                    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypejournal.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypejournals.Add(clsTypejournal);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypejournals.Add(clsTypejournal);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
            clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypejournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            clsTypejournals.Add(clsTypejournal);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
            clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypejournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            clsTypejournals.Add(clsTypejournal);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsTypejournals;
    }


        
    }
}
