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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparconditionpermis" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparconditionpermis.svc ou wsCtparconditionpermis.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparconditionpermis : IwsCtparconditionpermis
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparconditionpermisWSBLL clsCtparconditionpermisWSBLL = new clsCtparconditionpermisWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparconditionpermis> pvgAjouter(List<HT_Stock.BOJ.clsCtparconditionpermis> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparconditionpermiss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
                //--TEST CONTRAINTE
                clsCtparconditionpermiss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermisDTO in Objet)
                {
                    Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.CD_CODECONDITION = clsCtparconditionpermisDTO.CD_CODECONDITION.ToString();
                    clsCtparconditionpermis.CD_LIBELLECONDITION = clsCtparconditionpermisDTO.CD_LIBELLECONDITION.ToString();
                    clsObjetEnvoi.OE_A = clsCtparconditionpermisDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparconditionpermisDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparconditionpermisWSBLL.pvgAjouter(clsDonnee, clsCtparconditionpermis, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparconditionpermiss;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparconditionpermis> pvgModifier(List<HT_Stock.BOJ.clsCtparconditionpermis> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparconditionpermiss = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
                //--TEST CONTRAINTE
                clsCtparconditionpermiss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermisDTO in Objet)
                {
                    Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.CD_CODECONDITION = clsCtparconditionpermisDTO.CD_CODECONDITION.ToString();
                    clsCtparconditionpermis.CD_LIBELLECONDITION = clsCtparconditionpermisDTO.CD_LIBELLECONDITION.ToString();
                    clsObjetEnvoi.OE_A = clsCtparconditionpermisDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparconditionpermisDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparconditionpermisDTO.CD_CODECONDITION };
                    clsObjetRetour.SetValue(true, clsCtparconditionpermisWSBLL.pvgModifier(clsDonnee, clsCtparconditionpermis, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparconditionpermiss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparconditionpermis> pvgSupprimer(List<HT_Stock.BOJ.clsCtparconditionpermis> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparconditionpermiss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
                //--TEST CONTRAINTE
                clsCtparconditionpermiss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CD_CODECONDITION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparconditionpermisWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparconditionpermiss;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparconditionpermis> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparconditionpermis> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparconditionpermiss = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
            //    //--TEST CONTRAINTE
            //    clsCtparconditionpermiss = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparconditionpermisWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.CD_CODECONDITION = row["CD_CODECONDITION"].ToString();
                    clsCtparconditionpermis.CD_LIBELLECONDITION = row["CD_LIBELLECONDITION"].ToString();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparconditionpermiss;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparconditionpermis> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparconditionpermis> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparconditionpermiss = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
        //    //--TEST CONTRAINTE
        //    clsCtparconditionpermiss = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparconditionpermiss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparconditionpermiss;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparconditionpermisWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                    clsCtparconditionpermis.CD_CODECONDITION = row["CD_CODECONDITION"].ToString();
                    clsCtparconditionpermis.CD_LIBELLECONDITION = row["CD_LIBELLECONDITION"].ToString();
                    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparconditionpermiss;
    }


        
    }
}