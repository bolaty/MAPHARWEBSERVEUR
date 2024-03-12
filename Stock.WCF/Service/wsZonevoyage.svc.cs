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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsZonevoyage" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsZonevoyage.svc ou wsZonevoyage.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsZonevoyage : IwsZonevoyage
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsZonevoyageWSBLL clsZonevoyageWSBLL = new clsZonevoyageWSBLL();

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
        public List<HT_Stock.BOJ.clsZonevoyage> pvgAjouter(List<HT_Stock.BOJ.clsZonevoyage> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZonevoyages = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
                //--TEST CONTRAINTE
                clsZonevoyages = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsZonevoyage clsZonevoyageDTO in Objet)
                {
                    Stock.BOJ.clsZonevoyage clsZonevoyage = new Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.ZM_CODEZONEVOYAGE = clsZonevoyageDTO.ZM_CODEZONEVOYAGE.ToString();
                    clsZonevoyage.ZM_NOMZONEVOYAGE = clsZonevoyageDTO.ZM_NOMZONEVOYAGE.ToString();
                    clsObjetEnvoi.OE_A = clsZonevoyageDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsZonevoyageDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsZonevoyageWSBLL.pvgAjouter(clsDonnee, clsZonevoyage, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }
                else
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                clsZonevoyages.Add(clsZonevoyage);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                clsZonevoyages.Add(clsZonevoyage);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZonevoyages;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZonevoyage> pvgModifier(List<HT_Stock.BOJ.clsZonevoyage> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZonevoyages = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
                //--TEST CONTRAINTE
                clsZonevoyages = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsZonevoyage clsZonevoyageDTO in Objet)
                {
                    Stock.BOJ.clsZonevoyage clsZonevoyage = new Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.ZM_CODEZONEVOYAGE = clsZonevoyageDTO.ZM_CODEZONEVOYAGE.ToString();
                    clsZonevoyage.ZM_NOMZONEVOYAGE = clsZonevoyageDTO.ZM_NOMZONEVOYAGE.ToString();
                    clsObjetEnvoi.OE_A = clsZonevoyageDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsZonevoyageDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsZonevoyageDTO.ZM_CODEZONEVOYAGE };
                    clsObjetRetour.SetValue(true, clsZonevoyageWSBLL.pvgModifier(clsDonnee, clsZonevoyage, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }
                else
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                clsZonevoyages.Add(clsZonevoyage);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                clsZonevoyages.Add(clsZonevoyage);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZonevoyages;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZonevoyage> pvgSupprimer(List<HT_Stock.BOJ.clsZonevoyage> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZonevoyages = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
                //--TEST CONTRAINTE
                clsZonevoyages = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].ZM_CODEZONEVOYAGE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsZonevoyageWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }
                else
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                clsZonevoyages.Add(clsZonevoyage);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
                clsZonevoyages.Add(clsZonevoyage);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZonevoyages;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsZonevoyage> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsZonevoyage> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsZonevoyages = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
            //    //--TEST CONTRAINTE
            //    clsZonevoyages = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsZonevoyageWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.ZM_CODEZONEVOYAGE = row["ZM_CODEZONEVOYAGE"].ToString();
                    clsZonevoyage.ZM_NOMZONEVOYAGE = row["ZM_NOMZONEVOYAGE"].ToString();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }
            }
            else
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsZonevoyages.Add(clsZonevoyage);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonevoyage.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            clsZonevoyages.Add(clsZonevoyage);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonevoyage.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            clsZonevoyages.Add(clsZonevoyage);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsZonevoyages;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZonevoyage> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsZonevoyage> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsZonevoyages = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
        //    //--TEST CONTRAINTE
        //    clsZonevoyages = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsZonevoyages[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonevoyages;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsZonevoyageWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                    clsZonevoyage.ZM_CODEZONEVOYAGE = row["ZM_CODEZONEVOYAGE"].ToString();
                    clsZonevoyage.ZM_NOMZONEVOYAGE = row["ZM_NOMZONEVOYAGE"].ToString();
                    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonevoyage.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsZonevoyages.Add(clsZonevoyage);
                }
            }
            else
            {
                HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsZonevoyages.Add(clsZonevoyage);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonevoyage.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            clsZonevoyages.Add(clsZonevoyage);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonevoyage.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            clsZonevoyages.Add(clsZonevoyage);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsZonevoyages;
    }


        
    }
}
