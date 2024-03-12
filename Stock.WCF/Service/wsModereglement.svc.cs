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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsModereglement" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsModereglement.svc ou wsModereglement.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsModereglement : IwsModereglement
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsModereglementWSBLL clsModereglementWSBLL = new clsModereglementWSBLL();

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
        public List<HT_Stock.BOJ.clsModereglement> pvgAjouter(List<HT_Stock.BOJ.clsModereglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsModereglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
                //--TEST CONTRAINTE
                clsModereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsModereglement clsModereglementDTO in Objet)
                {
                    Stock.BOJ.clsModereglement clsModereglement = new Stock.BOJ.clsModereglement();
                    clsModereglement.MR_CODEMODEREGLEMENT = clsModereglementDTO.MR_CODEMODEREGLEMENT.ToString();
                    clsModereglement.MR_LIBELLE = clsModereglementDTO.MR_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsModereglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsModereglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsModereglementWSBLL.pvgAjouter(clsDonnee, clsModereglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsModereglements.Add(clsModereglement);
                }
                else
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsModereglements.Add(clsModereglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                clsModereglements.Add(clsModereglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                clsModereglements.Add(clsModereglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsModereglements;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsModereglement> pvgModifier(List<HT_Stock.BOJ.clsModereglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsModereglements = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
                //--TEST CONTRAINTE
                clsModereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsModereglement clsModereglementDTO in Objet)
                {
                    Stock.BOJ.clsModereglement clsModereglement = new Stock.BOJ.clsModereglement();
                    clsModereglement.MR_CODEMODEREGLEMENT = clsModereglementDTO.MR_CODEMODEREGLEMENT.ToString();
                    clsModereglement.MR_LIBELLE = clsModereglementDTO.MR_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsModereglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsModereglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsModereglementDTO.MR_CODEMODEREGLEMENT };
                    clsObjetRetour.SetValue(true, clsModereglementWSBLL.pvgModifier(clsDonnee, clsModereglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsModereglements.Add(clsModereglement);
                }
                else
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsModereglements.Add(clsModereglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                clsModereglements.Add(clsModereglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                clsModereglements.Add(clsModereglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsModereglements;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsModereglement> pvgSupprimer(List<HT_Stock.BOJ.clsModereglement> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsModereglements = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
                //--TEST CONTRAINTE
                clsModereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].MR_CODEMODEREGLEMENT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsModereglementWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsModereglements.Add(clsModereglement);
                }
                else
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsModereglements.Add(clsModereglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                clsModereglements.Add(clsModereglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
                clsModereglements.Add(clsModereglement);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsModereglements;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsModereglement> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsModereglement> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsModereglements = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
            //    //--TEST CONTRAINTE
            //    clsModereglements = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsModereglementWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.MR_CODEMODEREGLEMENT = row["MR_CODEMODEREGLEMENT"].ToString();
                    clsModereglement.MR_LIBELLE = row["MR_LIBELLE"].ToString();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsModereglements.Add(clsModereglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsModereglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsModereglements.Add(clsModereglement);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsModereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            clsModereglements.Add(clsModereglement);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsModereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            clsModereglements.Add(clsModereglement);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsModereglements;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsModereglement> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsModereglement> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsModereglements = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
        //    //--TEST CONTRAINTE
        //    clsModereglements = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsModereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsModereglements;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsModereglementWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                    clsModereglement.MR_CODEMODEREGLEMENT = row["MR_CODEMODEREGLEMENT"].ToString();
                    clsModereglement.MR_LIBELLE = row["MR_LIBELLE"].ToString();
                    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsModereglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsModereglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsModereglements.Add(clsModereglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsModereglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsModereglements.Add(clsModereglement);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsModereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            clsModereglements.Add(clsModereglement);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsModereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsModereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            clsModereglements.Add(clsModereglement);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsModereglements;
    }


        
    }
}
