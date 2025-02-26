﻿using System;
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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogiciel" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogiciel.svc ou wsLogiciel.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogiciel : IwsLogiciel
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielWSBLL clsLogicielWSBLL = new clsLogicielWSBLL();

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
        public List<HT_Stock.BOJ.clsLogiciel> pvgAjouter(List<HT_Stock.BOJ.clsLogiciel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogiciels = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
                //--TEST CONTRAINTE
                clsLogiciels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogiciel clsLogicielDTO in Objet)
                {
                    Stock.BOJ.clsLogiciel clsLogiciel = new Stock.BOJ.clsLogiciel();
                    clsLogiciel.LO_CODELOGICIEL = clsLogicielDTO.LO_CODELOGICIEL.ToString();
                    clsLogiciel.LO_LIBELLE = clsLogicielDTO.LO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielWSBLL.pvgAjouter(clsDonnee, clsLogiciel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogiciels.Add(clsLogiciel);
                }
                else
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogiciels.Add(clsLogiciel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                clsLogiciels.Add(clsLogiciel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                clsLogiciels.Add(clsLogiciel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogiciels;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogiciel> pvgModifier(List<HT_Stock.BOJ.clsLogiciel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogiciels = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
                //--TEST CONTRAINTE
                clsLogiciels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogiciel clsLogicielDTO in Objet)
                {
                    Stock.BOJ.clsLogiciel clsLogiciel = new Stock.BOJ.clsLogiciel();
                    clsLogiciel.LO_CODELOGICIEL = clsLogicielDTO.LO_CODELOGICIEL.ToString();
                    clsLogiciel.LO_LIBELLE = clsLogicielDTO.LO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielDTO.LO_CODELOGICIEL };
                    clsObjetRetour.SetValue(true, clsLogicielWSBLL.pvgModifier(clsDonnee, clsLogiciel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogiciels.Add(clsLogiciel);
                }
                else
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogiciels.Add(clsLogiciel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                clsLogiciels.Add(clsLogiciel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                clsLogiciels.Add(clsLogiciel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogiciels;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogiciel> pvgSupprimer(List<HT_Stock.BOJ.clsLogiciel> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogiciels = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
                //--TEST CONTRAINTE
                clsLogiciels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].LO_CODELOGICIEL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogiciels.Add(clsLogiciel);
                }
                else
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogiciels.Add(clsLogiciel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                clsLogiciels.Add(clsLogiciel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
                clsLogiciels.Add(clsLogiciel);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogiciels;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsLogiciel> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogiciel> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogiciels = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
            //    //--TEST CONTRAINTE
            //    clsLogiciels = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.LO_CODELOGICIEL = row["LO_CODELOGICIEL"].ToString();
                    clsLogiciel.LO_LIBELLE = row["LO_LIBELLE"].ToString();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogiciels.Add(clsLogiciel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogiciels.Add(clsLogiciel);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogiciel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            clsLogiciels.Add(clsLogiciel);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogiciel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            clsLogiciels.Add(clsLogiciel);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsLogiciels;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogiciel> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogiciel> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsLogiciels = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
        //    //--TEST CONTRAINTE
        //    clsLogiciels = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogiciels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogiciels;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                    clsLogiciel.LO_CODELOGICIEL = row["LO_CODELOGICIEL"].ToString();
                    clsLogiciel.LO_LIBELLE = row["LO_LIBELLE"].ToString();
                    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogiciel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogiciels.Add(clsLogiciel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogiciels.Add(clsLogiciel);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogiciel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            clsLogiciels.Add(clsLogiciel);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogiciel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            clsLogiciels.Add(clsLogiciel);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogiciels;
    }


        
    }
}
