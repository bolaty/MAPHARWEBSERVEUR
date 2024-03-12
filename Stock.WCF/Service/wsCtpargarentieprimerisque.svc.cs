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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpargarentieprimerisque" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpargarentieprimerisque.svc ou wsCtpargarentieprimerisque.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpargarentieprimerisque : IwsCtpargarentieprimerisque
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpargarentieprimerisqueWSBLL clsCtpargarentieprimerisqueWSBLL = new clsCtpargarentieprimerisqueWSBLL();

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
        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> pvgAjouter(List<HT_Stock.BOJ.clsCtpargarentieprimerisque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargarentieprimerisques = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
                //--TEST CONTRAINTE
                clsCtpargarentieprimerisques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisqueDTO in Objet)
                {
                    Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.RQ_CODERISQUE = clsCtpargarentieprimerisqueDTO.RQ_CODERISQUE.ToString();
                    clsCtpargarentieprimerisque.GR_CODEGARENTIEPRIME = clsCtpargarentieprimerisqueDTO.GR_CODEGARENTIEPRIME.ToString();
                    clsObjetEnvoi.OE_A = clsCtpargarentieprimerisqueDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpargarentieprimerisqueDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpargarentieprimerisqueWSBLL.pvgAjouter(clsDonnee, clsCtpargarentieprimerisque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargarentieprimerisques;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> pvgModifier(List<HT_Stock.BOJ.clsCtpargarentieprimerisque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargarentieprimerisques = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
                //--TEST CONTRAINTE
                clsCtpargarentieprimerisques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisqueDTO in Objet)
                {
                    Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.RQ_CODERISQUE = clsCtpargarentieprimerisqueDTO.RQ_CODERISQUE.ToString();
                    clsCtpargarentieprimerisque.GR_CODEGARENTIEPRIME = clsCtpargarentieprimerisqueDTO.GR_CODEGARENTIEPRIME.ToString();
                    clsObjetEnvoi.OE_A = clsCtpargarentieprimerisqueDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpargarentieprimerisqueDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpargarentieprimerisqueDTO.RQ_CODERISQUE };
                    clsObjetRetour.SetValue(true, clsCtpargarentieprimerisqueWSBLL.pvgModifier(clsDonnee, clsCtpargarentieprimerisque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargarentieprimerisques;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> pvgSupprimer(List<HT_Stock.BOJ.clsCtpargarentieprimerisque> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargarentieprimerisques = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
                //--TEST CONTRAINTE
                clsCtpargarentieprimerisques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].RQ_CODERISQUE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpargarentieprimerisqueWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargarentieprimerisques;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpargarentieprimerisque> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtpargarentieprimerisques = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
            //    //--TEST CONTRAINTE
            //    clsCtpargarentieprimerisques = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpargarentieprimerisqueWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtpargarentieprimerisque.GR_CODEGARENTIEPRIME = row["GR_CODEGARENTIEPRIME"].ToString();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargarentieprimerisques;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpargarentieprimerisque> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargarentieprimerisques = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
                //--TEST CONTRAINTE
                clsCtpargarentieprimerisques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargarentieprimerisques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarentieprimerisques;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].RQ_CODERISQUE};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpargarentieprimerisqueWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                    clsCtpargarentieprimerisque.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtpargarentieprimerisque.GR_CODEGARENTIEPRIME = row["GR_CODEGARENTIEPRIME"].ToString();
                    clsCtpargarentieprimerisque.GR_LIBELLEGARENTIEPRIME = row["GR_LIBELLEGARENTIEPRIME"].ToString();
                    clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpargarentieprimerisques;
    }


        
    }
}
