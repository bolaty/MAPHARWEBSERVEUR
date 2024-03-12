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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparquestionnairedocumentrisqueassuranceliaison" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparquestionnairedocumentrisqueassuranceliaison.svc ou wsCtparquestionnairedocumentrisqueassuranceliaison.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparquestionnairedocumentrisqueassuranceliaison : IwsCtparquestionnairedocumentrisqueassuranceliaison
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL = new clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgAjouter(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaisonDTO in Objet)
                {
                    Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.DC_CODEDOCUMENT.ToString();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.RQ_CODERISQUE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL.pvgAjouter(clsDonnee, clsCtparquestionnairedocumentrisqueassuranceliaison, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgModifier(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaisonDTO in Objet)
                {
                    Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.DC_CODEDOCUMENT.ToString();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.RQ_CODERISQUE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparquestionnairedocumentrisqueassuranceliaisonDTO.DC_CODEDOCUMENT };
                    clsObjetRetour.SetValue(true, clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL.pvgModifier(clsDonnee, clsCtparquestionnairedocumentrisqueassuranceliaison, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgSupprimer(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].DC_CODEDOCUMENT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparquestionnairedocumentrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].RQ_CODERISQUE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT = row["DC_CODEDOCUMENT"].ToString();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.DC_LIBELLEDOCUMENT = row["DC_LIBELLEDOCUMENT"].ToString();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparquestionnairedocumentrisqueassuranceliaisons = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
        //    //--TEST CONTRAINTE
        //    clsCtparquestionnairedocumentrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparquestionnairedocumentrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnairedocumentrisqueassuranceliaisons;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparquestionnairedocumentrisqueassuranceliaisonWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT = row["DC_CODEDOCUMENT"].ToString();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparquestionnairedocumentrisqueassuranceliaisons;
    }


        
    }
}
