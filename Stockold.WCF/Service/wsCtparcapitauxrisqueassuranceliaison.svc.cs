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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparcapitauxrisqueassuranceliaison" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparcapitauxrisqueassuranceliaison.svc ou wsCtparcapitauxrisqueassuranceliaison.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparcapitauxrisqueassuranceliaison : IwsCtparcapitauxrisqueassuranceliaison
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparcapitauxrisqueassuranceliaisonWSBLL clsCtparcapitauxrisqueassuranceliaisonWSBLL = new clsCtparcapitauxrisqueassuranceliaisonWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> pvgAjouter(List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcapitauxrisqueassuranceliaisons = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparcapitauxrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaisonDTO in Objet)
                {
                    Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX = clsCtparcapitauxrisqueassuranceliaisonDTO.CP_CODECAPITAUX.ToString();
                    //clsCtparcapitauxrisqueassuranceliaison.CP_LIBELLECAPITAUX = clsCtparcapitauxrisqueassuranceliaisonDTO.CP_LIBELLECAPITAUX.ToString();
                    clsObjetEnvoi.OE_A = clsCtparcapitauxrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparcapitauxrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparcapitauxrisqueassuranceliaisonWSBLL.pvgAjouter(clsDonnee, clsCtparcapitauxrisqueassuranceliaison, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcapitauxrisqueassuranceliaisons;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> pvgModifier(List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcapitauxrisqueassuranceliaisons = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparcapitauxrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaisonDTO in Objet)
                {
                    Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX = clsCtparcapitauxrisqueassuranceliaisonDTO.CP_CODECAPITAUX.ToString();
                    //clsCtparcapitauxrisqueassuranceliaison.CP_LIBELLECAPITAUX = clsCtparcapitauxrisqueassuranceliaisonDTO.CP_LIBELLECAPITAUX.ToString();
                    clsObjetEnvoi.OE_A = clsCtparcapitauxrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparcapitauxrisqueassuranceliaisonDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparcapitauxrisqueassuranceliaisonDTO.CP_CODECAPITAUX };
                    clsObjetRetour.SetValue(true, clsCtparcapitauxrisqueassuranceliaisonWSBLL.pvgModifier(clsDonnee, clsCtparcapitauxrisqueassuranceliaison, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcapitauxrisqueassuranceliaisons;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> pvgSupprimer(List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcapitauxrisqueassuranceliaisons = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparcapitauxrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CP_CODECAPITAUX };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparcapitauxrisqueassuranceliaisonWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcapitauxrisqueassuranceliaisons;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcapitauxrisqueassuranceliaisons = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
                //--TEST CONTRAINTE
                clsCtparcapitauxrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].RQ_CODERISQUE};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparcapitauxrisqueassuranceliaisonWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX = row["CP_CODECAPITAUX"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.CP_LIBELLECAPITAUX = row["CP_LIBELLECAPITAUX"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.CC_CAPITAUX = row["CC_CAPITAUX"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.CC_PRIMES = row["CC_PRIMES"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.CC_TAUX = row["CC_TAUX"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.CC_LIBELLE = row["CC_LIBELLE"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcapitauxrisqueassuranceliaisons;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparcapitauxrisqueassuranceliaisons = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
        //    //--TEST CONTRAINTE
        //    clsCtparcapitauxrisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparcapitauxrisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcapitauxrisqueassuranceliaisons;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparcapitauxrisqueassuranceliaisonWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                    clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX = row["CP_CODECAPITAUX"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.CP_LIBELLECAPITAUX = row["CP_LIBELLECAPITAUX"].ToString();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparcapitauxrisqueassuranceliaisons;
    }


        
    }
}
