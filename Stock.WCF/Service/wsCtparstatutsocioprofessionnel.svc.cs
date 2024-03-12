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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparstatutsocioprofessionnel" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparstatutsocioprofessionnel.svc ou wsCtparstatutsocioprofessionnel.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparstatutsocioprofessionnel : IwsCtparstatutsocioprofessionnel
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparstatutsocioprofessionnelWSBLL clsCtparstatutsocioprofessionnelWSBLL = new clsCtparstatutsocioprofessionnelWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> pvgAjouter(List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparstatutsocioprofessionnels = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
                //--TEST CONTRAINTE
                clsCtparstatutsocioprofessionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnelDTO in Objet)
                {
                    Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF = clsCtparstatutsocioprofessionnelDTO.ST_CODESTATUTSOCIOPROF.ToString();
                    clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = clsCtparstatutsocioprofessionnelDTO.ST_LIBELLESTATUTSOCIOPROF1.ToString();
                    clsObjetEnvoi.OE_A = clsCtparstatutsocioprofessionnelDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparstatutsocioprofessionnelDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparstatutsocioprofessionnelWSBLL.pvgAjouter(clsDonnee, clsCtparstatutsocioprofessionnel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparstatutsocioprofessionnels;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> pvgModifier(List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparstatutsocioprofessionnels = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
                //--TEST CONTRAINTE
                clsCtparstatutsocioprofessionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnelDTO in Objet)
                {
                    Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF = clsCtparstatutsocioprofessionnelDTO.ST_CODESTATUTSOCIOPROF.ToString();
                    clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = clsCtparstatutsocioprofessionnelDTO.ST_LIBELLESTATUTSOCIOPROF1.ToString();
                    clsObjetEnvoi.OE_A = clsCtparstatutsocioprofessionnelDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparstatutsocioprofessionnelDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparstatutsocioprofessionnelDTO.ST_CODESTATUTSOCIOPROF };
                    clsObjetRetour.SetValue(true, clsCtparstatutsocioprofessionnelWSBLL.pvgModifier(clsDonnee, clsCtparstatutsocioprofessionnel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparstatutsocioprofessionnels;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> pvgSupprimer(List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparstatutsocioprofessionnels = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
                //--TEST CONTRAINTE
                clsCtparstatutsocioprofessionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].ST_CODESTATUTSOCIOPROF };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparstatutsocioprofessionnelWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparstatutsocioprofessionnels;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparstatutsocioprofessionnels = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
            //    //--TEST CONTRAINTE
            //    clsCtparstatutsocioprofessionnels = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparstatutsocioprofessionnelWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF = row["ST_CODESTATUTSOCIOPROF"].ToString();
                    clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = row["ST_LIBELLESTATUTSOCIOPROF1"].ToString();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparstatutsocioprofessionnels;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparstatutsocioprofessionnels = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
        //    //--TEST CONTRAINTE
        //    clsCtparstatutsocioprofessionnels = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparstatutsocioprofessionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparstatutsocioprofessionnels;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparstatutsocioprofessionnelWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                    clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF = row["ST_CODESTATUTSOCIOPROF"].ToString();
                    clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = row["ST_LIBELLESTATUTSOCIOPROF1"].ToString();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparstatutsocioprofessionnels;
    }


        
    }
}
