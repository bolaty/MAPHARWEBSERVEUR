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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsBanque" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsBanque.svc ou wsBanque.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsBanque : IwsBanque
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsBanqueWSBLL clsBanqueWSBLL = new clsBanqueWSBLL();

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
        public List<HT_Stock.BOJ.clsBanque> pvgAjouter(List<HT_Stock.BOJ.clsBanque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanques = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
                //--TEST CONTRAINTE
                clsBanques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsBanque clsBanqueDTO in Objet)
                {
                    Stock.BOJ.clsBanque clsBanque = new Stock.BOJ.clsBanque();
                    clsBanque.BQ_CODEBANQUE = clsBanqueDTO.BQ_CODEBANQUE.ToString();
                    clsBanque.BQ_SIGLE = clsBanqueDTO.BQ_SIGLE.ToString();
                    clsBanque.BQ_RAISONSOCIAL = clsBanqueDTO.BQ_RAISONSOCIAL.ToString();
                    clsObjetEnvoi.OE_A = clsBanqueDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsBanqueDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsBanqueWSBLL.pvgAjouter(clsDonnee, clsBanque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBanques.Add(clsBanque);
                }
                else
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBanque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBanques.Add(clsBanque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                clsBanques.Add(clsBanque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                clsBanques.Add(clsBanque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBanques;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBanque> pvgModifier(List<HT_Stock.BOJ.clsBanque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanques = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
                //--TEST CONTRAINTE
                clsBanques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsBanque clsBanqueDTO in Objet)
                {
                    Stock.BOJ.clsBanque clsBanque = new Stock.BOJ.clsBanque();
                    clsBanque.BQ_CODEBANQUE = clsBanqueDTO.BQ_CODEBANQUE.ToString();
                    clsBanque.BQ_SIGLE = clsBanqueDTO.BQ_SIGLE.ToString();
                    clsBanque.BQ_RAISONSOCIAL = clsBanqueDTO.BQ_RAISONSOCIAL.ToString();
                    clsObjetEnvoi.OE_A = clsBanqueDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsBanqueDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsBanqueDTO.BQ_CODEBANQUE };
                    clsObjetRetour.SetValue(true, clsBanqueWSBLL.pvgModifier(clsDonnee, clsBanque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBanques.Add(clsBanque);
                }
                else
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBanque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBanques.Add(clsBanque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                clsBanques.Add(clsBanque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                clsBanques.Add(clsBanque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBanques;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBanque> pvgSupprimer(List<HT_Stock.BOJ.clsBanque> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanques = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
                //--TEST CONTRAINTE
                clsBanques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BQ_CODEBANQUE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsBanqueWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBanques.Add(clsBanque);
                }
                else
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBanque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBanques.Add(clsBanque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                clsBanques.Add(clsBanque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanques = new List<HT_Stock.BOJ.clsBanque>();
                clsBanques.Add(clsBanque);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBanques;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsBanque> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsBanque> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsBanques = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
            //    //--TEST CONTRAINTE
            //    clsBanques = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsBanqueWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
                    clsBanque.BQ_BANQUECODE = row["BQ_BANQUECODE"].ToString();
                    clsBanque.BQ_SIGLE = row["BQ_SIGLE"].ToString();
                    clsBanque.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsBanques.Add(clsBanque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsBanque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsBanques.Add(clsBanque);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            clsBanques.Add(clsBanque);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            clsBanques.Add(clsBanque);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsBanques;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBanque> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsBanque> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsBanques = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
        //    //--TEST CONTRAINTE
        //    clsBanques = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsBanques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanques;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsBanqueWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                    clsBanque.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
                    clsBanque.BQ_SIGLE = row["BQ_RAISONSOCIAL"].ToString();
                    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsBanques.Add(clsBanque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsBanque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsBanques.Add(clsBanque);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            clsBanques.Add(clsBanque);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            clsBanques.Add(clsBanque);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsBanques;
    }


        
    }
}
