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

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsMicbudgetparampostebudgetaire" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsMicbudgetparampostebudgetaire.svc ou wsMicbudgetparampostebudgetaire.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsMicbudgetparampostebudgetaire : IwsMicbudgetparampostebudgetaire
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsMicbudgetparampostebudgetaireWSBLL clsMicbudgetparampostebudgetaireWSBLL = new clsMicbudgetparampostebudgetaireWSBLL();

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
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> pvgAjouter(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparampostebudgetaires = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
                //--TEST CONTRAINTE
                clsMicbudgetparampostebudgetaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaireDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.BT_CODETYPEBUDGET = clsMicbudgetparampostebudgetaireDTO.BT_CODETYPEBUDGET.ToString();
                    clsMicbudgetparampostebudgetaire.BG_LIBELLE = clsMicbudgetparampostebudgetaireDTO.BG_LIBELLE.ToString();
                    clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = clsMicbudgetparampostebudgetaireDTO.BD_CODETYPEBUDGETDETAIL.ToString();
                    clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetaireDTO.BN_CODENATUREPOSTEBUDGETAIRE.ToString();
                    clsMicbudgetparampostebudgetaire.SR_CODESERVICE = clsMicbudgetparampostebudgetaireDTO.SR_CODESERVICE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparampostebudgetaireDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparampostebudgetaireDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsMicbudgetparampostebudgetaireWSBLL.pvgAjouter(clsDonnee, clsMicbudgetparampostebudgetaire, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetaires;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> pvgModifier(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparampostebudgetaires = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
                //--TEST CONTRAINTE
                clsMicbudgetparampostebudgetaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaireDTO in Objet)
                   
                {
                    Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetaireDTO.BG_CODEPOSTEBUDGETAIRE.ToString();
                    clsMicbudgetparampostebudgetaire.BT_CODETYPEBUDGET = clsMicbudgetparampostebudgetaireDTO.BT_CODETYPEBUDGET.ToString();
                    clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = clsMicbudgetparampostebudgetaireDTO.BD_CODETYPEBUDGETDETAIL.ToString();
                    clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetaireDTO.BN_CODENATUREPOSTEBUDGETAIRE.ToString();
                    clsMicbudgetparampostebudgetaire.SR_CODESERVICE = clsMicbudgetparampostebudgetaireDTO.SR_CODESERVICE.ToString();
                    clsMicbudgetparampostebudgetaire.BG_LIBELLE = clsMicbudgetparampostebudgetaireDTO.BG_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparampostebudgetaireDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparampostebudgetaireDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsMicbudgetparampostebudgetaireDTO.BG_CODEPOSTEBUDGETAIRE };
                    clsObjetRetour.SetValue(true, clsMicbudgetparampostebudgetaireWSBLL.pvgModifier(clsDonnee, clsMicbudgetparampostebudgetaire, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetaires;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> pvgSupprimer(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparampostebudgetaires = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
                //--TEST CONTRAINTE
                clsMicbudgetparampostebudgetaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BG_CODEPOSTEBUDGETAIRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsMicbudgetparampostebudgetaireWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetaires;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsMicbudgetparampostebudgetaires = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
            //    //--TEST CONTRAINTE
            //    clsMicbudgetparampostebudgetaires = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
            //}


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BG_CODEPOSTEBUDGETAIRE, Objet[0].BG_LIBELLE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparampostebudgetaireWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE = row["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetaire.BG_LIBELLE = row["BG_LIBELLE"].ToString();
                    clsMicbudgetparampostebudgetaire.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();
                        clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = row["BD_CODETYPEBUDGETDETAIL"].ToString();
                        clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = row["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                        clsMicbudgetparampostebudgetaire.BT_LIBELLE = row["BT_LIBELLE"].ToString();
                        clsMicbudgetparampostebudgetaire.BD_LIBELLE = row["BD_LIBELLE"].ToString();
                        clsMicbudgetparampostebudgetaire.BN_LIBELLE = row["BN_LIBELLE"].ToString();
                        clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetaires;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsMicbudgetparampostebudgetaires = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
        //    //--TEST CONTRAINTE
        //    clsMicbudgetparampostebudgetaires = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMicbudgetparampostebudgetaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetaires;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparampostebudgetaireWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                   
                        clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE = row["BG_CODEPOSTEBUDGETAIRE"].ToString();
                        clsMicbudgetparampostebudgetaire.BG_LIBELLE = row["BG_LIBELLE"].ToString();
                        //clsMicbudgetparampostebudgetaire.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();
                        //clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = row["BD_CODETYPEBUDGETDETAIL"].ToString();
                        //clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = row["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                        //clsMicbudgetparampostebudgetaire.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();
                        clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsMicbudgetparampostebudgetaires;
    }


        
    }
}
