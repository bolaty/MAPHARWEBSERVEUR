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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsMicbudgetparampostebudgetairenature" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsMicbudgetparampostebudgetairenature.svc ou wsMicbudgetparampostebudgetairenature.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsMicbudgetparampostebudgetairenature : IwsMicbudgetparampostebudgetairenature
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsMicbudgetparampostebudgetairenatureWSBLL clsMicbudgetparampostebudgetairenatureWSBLL = new clsMicbudgetparampostebudgetairenatureWSBLL();

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
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> pvgAjouter(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
               // clsMicbudgetparampostebudgetairenatures = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
                //--TEST CONTRAINTE
           //     clsMicbudgetparampostebudgetairenatures = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenatureDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetairenatureDTO.BN_CODENATUREPOSTEBUDGETAIRE.ToString();
                    clsMicbudgetparampostebudgetairenature.BN_LIBELLE = clsMicbudgetparampostebudgetairenatureDTO.BN_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparampostebudgetairenatureDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparampostebudgetairenatureDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsMicbudgetparampostebudgetairenatureWSBLL.pvgAjouter(clsDonnee, clsMicbudgetparampostebudgetairenature, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetairenatures;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> pvgModifier(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
              //  clsMicbudgetparampostebudgetairenatures = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
                //--TEST CONTRAINTE
             //   clsMicbudgetparampostebudgetairenatures = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenatureDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetairenatureDTO.BN_CODENATUREPOSTEBUDGETAIRE.ToString();
                    clsMicbudgetparampostebudgetairenature.BN_LIBELLE = clsMicbudgetparampostebudgetairenatureDTO.BN_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparampostebudgetairenatureDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparampostebudgetairenatureDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsMicbudgetparampostebudgetairenatureDTO.BN_CODENATUREPOSTEBUDGETAIRE };
                    clsObjetRetour.SetValue(true, clsMicbudgetparampostebudgetairenatureWSBLL.pvgModifier(clsDonnee, clsMicbudgetparampostebudgetairenature, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetairenatures;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> pvgSupprimer(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
              //  clsMicbudgetparampostebudgetairenatures = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
                //--TEST CONTRAINTE
              //  clsMicbudgetparampostebudgetairenatures = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BN_CODENATUREPOSTEBUDGETAIRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsMicbudgetparampostebudgetairenatureWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetairenatures;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsMicbudgetparampostebudgetairenatures = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
            //    //--TEST CONTRAINTE
            //    clsMicbudgetparampostebudgetairenatures = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparampostebudgetairenatureWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE = row["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetairenature.BN_LIBELLE = row["BN_LIBELLE"].ToString();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparampostebudgetairenatures;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsMicbudgetparampostebudgetairenatures = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
        //    //--TEST CONTRAINTE
        //    clsMicbudgetparampostebudgetairenatures = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMicbudgetparampostebudgetairenatures[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparampostebudgetairenatures;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparampostebudgetairenatureWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                    clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE = row["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetairenature.BN_LIBELLE = row["BN_LIBELLE"].ToString();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparampostebudgetairenature.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparampostebudgetairenatures = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetairenature>();
            clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsMicbudgetparampostebudgetairenatures;
    }


        
    }
}
