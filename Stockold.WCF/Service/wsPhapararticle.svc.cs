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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapararticle" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapararticle.svc ou wsPhapararticle.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapararticle : IwsPhapararticle
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapararticleWSBLL clsPhapararticleWSBLL = new clsPhapararticleWSBLL();

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
        public List<HT_Stock.BOJ.clsPhapararticle> pvgAjouter(List<HT_Stock.BOJ.clsPhapararticle> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapararticles = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
                //--TEST CONTRAINTE
                clsPhapararticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapararticle clsPhapararticleDTO in Objet)
                {
                    Stock.BOJ.clsPhapararticle clsPhapararticle = new Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.AR_CODEARTICLE = clsPhapararticleDTO.AR_CODEARTICLE.ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = clsPhapararticleDTO.AR_NOMCOMMERCIALE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapararticleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapararticleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgAjouter(clsDonnee, clsPhapararticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                clsPhapararticles.Add(clsPhapararticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                clsPhapararticles.Add(clsPhapararticle);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapararticles;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapararticle> pvgModifier(List<HT_Stock.BOJ.clsPhapararticle> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapararticles = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
                //--TEST CONTRAINTE
                clsPhapararticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapararticle clsPhapararticleDTO in Objet)
                {
                    Stock.BOJ.clsPhapararticle clsPhapararticle = new Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.AR_CODEARTICLE = clsPhapararticleDTO.AR_CODEARTICLE.ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = clsPhapararticleDTO.AR_NOMCOMMERCIALE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapararticleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapararticleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhapararticleDTO.AR_CODEARTICLE };
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgModifier(clsDonnee, clsPhapararticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                clsPhapararticles.Add(clsPhapararticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                clsPhapararticles.Add(clsPhapararticle);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapararticles;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapararticle> pvgSupprimer(List<HT_Stock.BOJ.clsPhapararticle> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapararticles = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
                //--TEST CONTRAINTE
                clsPhapararticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AR_CODEARTICLE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                clsPhapararticles.Add(clsPhapararticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
                clsPhapararticles.Add(clsPhapararticle);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapararticles;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhapararticle> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhapararticle> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhapararticles = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
            //    //--TEST CONTRAINTE
            //    clsPhapararticles = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapararticleWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.AR_CODEARTICLE = row["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = row["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapararticles.Add(clsPhapararticle);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapararticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            clsPhapararticles.Add(clsPhapararticle);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapararticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            clsPhapararticles.Add(clsPhapararticle);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapararticles;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapararticle> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapararticle> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapararticles = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
                //--TEST CONTRAINTE
                clsPhapararticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapararticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapararticles;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].TA_CODETYPEARTICLE,"" };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapararticleWSBLL.pvgChargerDansDataSetPourComboProduitFini(clsDonnee, clsObjetEnvoi);
            clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                    clsPhapararticle.AR_CODEARTICLE = row["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = row["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapararticle.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapararticles.Add(clsPhapararticle);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapararticles.Add(clsPhapararticle);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapararticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            clsPhapararticles.Add(clsPhapararticle);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapararticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            clsPhapararticles.Add(clsPhapararticle);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapararticles;
    }


        
    }
}
