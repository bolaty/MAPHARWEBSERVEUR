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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsZonemaladie" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsZonemaladie.svc ou wsZonemaladie.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsZonemaladie : IwsZonemaladie
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsZonemaladieWSBLL clsZonemaladieWSBLL = new clsZonemaladieWSBLL();

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
        public List<HT_Stock.BOJ.clsZonemaladie> pvgAjouter(List<HT_Stock.BOJ.clsZonemaladie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZonemaladies = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
                //--TEST CONTRAINTE
                clsZonemaladies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsZonemaladie clsZonemaladieDTO in Objet)
                {
                    Stock.BOJ.clsZonemaladie clsZonemaladie = new Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.ZM_CODEZONEMALADIE = clsZonemaladieDTO.ZM_CODEZONEMALADIE.ToString();
                    clsZonemaladie.ZM_NOMZONEMALADIE = clsZonemaladieDTO.ZM_NOMZONEMALADIE.ToString();
                    clsObjetEnvoi.OE_A = clsZonemaladieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsZonemaladieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsZonemaladieWSBLL.pvgAjouter(clsDonnee, clsZonemaladie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }
                else
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                clsZonemaladies.Add(clsZonemaladie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                clsZonemaladies.Add(clsZonemaladie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZonemaladies;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZonemaladie> pvgModifier(List<HT_Stock.BOJ.clsZonemaladie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZonemaladies = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
                //--TEST CONTRAINTE
                clsZonemaladies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsZonemaladie clsZonemaladieDTO in Objet)
                {
                    Stock.BOJ.clsZonemaladie clsZonemaladie = new Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.ZM_CODEZONEMALADIE = clsZonemaladieDTO.ZM_CODEZONEMALADIE.ToString();
                    clsZonemaladie.ZM_NOMZONEMALADIE = clsZonemaladieDTO.ZM_NOMZONEMALADIE.ToString();
                    clsObjetEnvoi.OE_A = clsZonemaladieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsZonemaladieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsZonemaladieDTO.ZM_CODEZONEMALADIE };
                    clsObjetRetour.SetValue(true, clsZonemaladieWSBLL.pvgModifier(clsDonnee, clsZonemaladie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }
                else
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                clsZonemaladies.Add(clsZonemaladie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                clsZonemaladies.Add(clsZonemaladie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZonemaladies;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZonemaladie> pvgSupprimer(List<HT_Stock.BOJ.clsZonemaladie> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZonemaladies = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
                //--TEST CONTRAINTE
                clsZonemaladies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].ZM_CODEZONEMALADIE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsZonemaladieWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }
                else
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                clsZonemaladies.Add(clsZonemaladie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
                clsZonemaladies.Add(clsZonemaladie);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZonemaladies;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsZonemaladie> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsZonemaladie> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsZonemaladies = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
            //    //--TEST CONTRAINTE
            //    clsZonemaladies = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsZonemaladieWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.ZM_CODEZONEMALADIE = row["ZM_CODEZONEMALADIE"].ToString();
                    clsZonemaladie.ZM_NOMZONEMALADIE = row["ZM_NOMZONEMALADIE"].ToString();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsZonemaladies.Add(clsZonemaladie);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
            clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonemaladie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            clsZonemaladies.Add(clsZonemaladie);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
            clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonemaladie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            clsZonemaladies.Add(clsZonemaladie);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsZonemaladies;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZonemaladie> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsZonemaladie> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsZonemaladies = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
        //    //--TEST CONTRAINTE
        //    clsZonemaladies = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsZonemaladies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZonemaladies;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsZonemaladieWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                    clsZonemaladie.ZM_CODEZONEMALADIE = row["ZM_CODEZONEMALADIE"].ToString();
                    clsZonemaladie.ZM_NOMZONEMALADIE = row["ZM_NOMZONEMALADIE"].ToString();
                    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZonemaladie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsZonemaladies.Add(clsZonemaladie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsZonemaladies.Add(clsZonemaladie);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
            clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonemaladie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            clsZonemaladies.Add(clsZonemaladie);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
            clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZonemaladie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            clsZonemaladies.Add(clsZonemaladie);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsZonemaladies;
    }


        
    }
}