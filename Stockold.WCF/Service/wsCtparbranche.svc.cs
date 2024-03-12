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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparbranche" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparbranche.svc ou wsCtparbranche.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparbranche : IwsCtparbranche
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparbrancheWSBLL clsCtparbrancheWSBLL = new clsCtparbrancheWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparbranche> pvgAjouter(List<HT_Stock.BOJ.clsCtparbranche> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranches = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
                //--TEST CONTRAINTE
                clsCtparbranches = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparbranche clsCtparbrancheDTO in Objet)
                {
                    Stock.BOJ.clsCtparbranche clsCtparbranche = new Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.CB_IDBRANCHE = clsCtparbrancheDTO.CB_IDBRANCHE.ToString();
                    clsCtparbranche.CB_LIBELLEBRANCHE = clsCtparbrancheDTO.CB_LIBELLEBRANCHE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparbrancheDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparbrancheDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparbrancheWSBLL.pvgAjouter(clsDonnee, clsCtparbranche, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                clsCtparbranches.Add(clsCtparbranche);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                clsCtparbranches.Add(clsCtparbranche);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranches;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparbranche> pvgModifier(List<HT_Stock.BOJ.clsCtparbranche> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranches = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
                //--TEST CONTRAINTE
                clsCtparbranches = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparbranche clsCtparbrancheDTO in Objet)
                {
                    Stock.BOJ.clsCtparbranche clsCtparbranche = new Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.CB_IDBRANCHE = clsCtparbrancheDTO.CB_IDBRANCHE.ToString();
                    clsCtparbranche.CB_LIBELLEBRANCHE = clsCtparbrancheDTO.CB_LIBELLEBRANCHE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparbrancheDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparbrancheDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparbrancheDTO.CB_IDBRANCHE };
                    clsObjetRetour.SetValue(true, clsCtparbrancheWSBLL.pvgModifier(clsDonnee, clsCtparbranche, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                clsCtparbranches.Add(clsCtparbranche);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                clsCtparbranches.Add(clsCtparbranche);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranches;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparbranche> pvgSupprimer(List<HT_Stock.BOJ.clsCtparbranche> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranches = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
                //--TEST CONTRAINTE
                clsCtparbranches = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CB_IDBRANCHE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparbrancheWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                clsCtparbranches.Add(clsCtparbranche);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
                clsCtparbranches.Add(clsCtparbranche);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranches;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparbranche> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparbranche> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparbranches = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
            //    //--TEST CONTRAINTE
            //    clsCtparbranches = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparbrancheWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
                    clsCtparbranche.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparbranches.Add(clsCtparbranche);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranche.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            clsCtparbranches.Add(clsCtparbranche);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranche.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            clsCtparbranches.Add(clsCtparbranche);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranches;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparbranche> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparbranche> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparbranches = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
        //    //--TEST CONTRAINTE
        //    clsCtparbranches = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparbranches[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranches;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparbrancheWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                    clsCtparbranche.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
                    clsCtparbranche.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranche.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparbranches.Add(clsCtparbranche);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparbranches.Add(clsCtparbranche);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranche.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            clsCtparbranches.Add(clsCtparbranche);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranche.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            clsCtparbranches.Add(clsCtparbranche);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparbranches;
    }


        
    }
}
