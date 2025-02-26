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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhaparnaturetypearticle" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhaparnaturetypearticle.svc ou wsPhaparnaturetypearticle.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhaparnaturetypearticle : IwsPhaparnaturetypearticle
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparnaturetypearticleWSBLL clsPhaparnaturetypearticleWSBLL = new clsPhaparnaturetypearticleWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> pvgAjouter(List<HT_Stock.BOJ.clsPhaparnaturetypearticle> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetypearticles = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
                //--TEST CONTRAINTE
                clsPhaparnaturetypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticleDTO in Objet)
                {
                    Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE = clsPhaparnaturetypearticleDTO.NT_CODENATURETYPEARTICLE.ToString();
                    clsPhaparnaturetypearticle.NT_LIBELLE = clsPhaparnaturetypearticleDTO.NT_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparnaturetypearticleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparnaturetypearticleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhaparnaturetypearticleWSBLL.pvgAjouter(clsDonnee, clsPhaparnaturetypearticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetypearticles;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> pvgModifier(List<HT_Stock.BOJ.clsPhaparnaturetypearticle> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetypearticles = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
                //--TEST CONTRAINTE
                clsPhaparnaturetypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticleDTO in Objet)
                {
                    Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE = clsPhaparnaturetypearticleDTO.NT_CODENATURETYPEARTICLE.ToString();
                    clsPhaparnaturetypearticle.NT_LIBELLE = clsPhaparnaturetypearticleDTO.NT_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparnaturetypearticleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparnaturetypearticleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhaparnaturetypearticleDTO.NT_CODENATURETYPEARTICLE };
                    clsObjetRetour.SetValue(true, clsPhaparnaturetypearticleWSBLL.pvgModifier(clsDonnee, clsPhaparnaturetypearticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetypearticles;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> pvgSupprimer(List<HT_Stock.BOJ.clsPhaparnaturetypearticle> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetypearticles = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
                //--TEST CONTRAINTE
                clsPhaparnaturetypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NT_CODENATURETYPEARTICLE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhaparnaturetypearticleWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetypearticles;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhaparnaturetypearticle> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhaparnaturetypearticles = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
            //    //--TEST CONTRAINTE
            //    clsPhaparnaturetypearticles = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparnaturetypearticleWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE = row["NT_CODENATURETYPEARTICLE"].ToString();
                    clsPhaparnaturetypearticle.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetypearticles;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> pvgChargerDansDataSetPourComboModeGestion(List<HT_Stock.BOJ.clsPhaparnaturetypearticle> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetypearticles = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
                //--TEST CONTRAINTE
                clsPhaparnaturetypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetypearticles;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].PP_CODEMODEGESTION };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparnaturetypearticleWSBLL.pvgChargerDansDataSetPourComboModeGestion(clsDonnee, clsObjetEnvoi);
            clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                    clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE = row["NT_CODENATURETYPEARTICLE"].ToString();
                    clsPhaparnaturetypearticle.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                    clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparnaturetypearticles;
    }


        
    }
}
