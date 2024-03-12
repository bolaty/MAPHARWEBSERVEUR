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
using System.Net.Mail;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsMiccomptewebmotpasseoublie" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsMiccomptewebmotpasseoublie.svc ou wsMiccomptewebmotpasseoublie.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsMiccomptewebmotpasseoublie : IwsMiccomptewebmotpasseoublie
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsMiccomptewebmotpasseoublieWSBLL clsMiccomptewebmotpasseoublieWSBLL = new clsMiccomptewebmotpasseoublieWSBLL();

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
        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> pvgAjouter(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMiccomptewebmotpasseoublies = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
                //--TEST CONTRAINTE
                clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieDTO in Objet)
                {
                    Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublieDTO.RP_NUMSEQUENCE.ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieDTO.RP_CODEVALIDATION.ToString();
                    clsObjetEnvoi.OE_A = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsMiccomptewebmotpasseoublieWSBLL.pvgAjouter(clsDonnee, clsMiccomptewebmotpasseoublie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }
                else
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> pvgModifier(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMiccomptewebmotpasseoublies = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
                //--TEST CONTRAINTE
                clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieDTO in Objet)
                {
                    Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublieDTO.RP_NUMSEQUENCE.ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieDTO.RP_CODEVALIDATION.ToString();
                    clsObjetEnvoi.OE_A = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsMiccomptewebmotpasseoublieDTO.RP_NUMSEQUENCE };
                    clsObjetRetour.SetValue(true, clsMiccomptewebmotpasseoublieWSBLL.pvgModifier(clsDonnee, clsMiccomptewebmotpasseoublie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }
                else
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> pvgSupprimer(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMiccomptewebmotpasseoublies = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
                //--TEST CONTRAINTE
                clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].RP_NUMSEQUENCE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsMiccomptewebmotpasseoublieWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }
                else
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsMiccomptewebmotpasseoublies = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            //    //--TEST CONTRAINTE
            //    clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMiccomptewebmotpasseoublieWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = row["RP_NUMSEQUENCE"].ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = row["RP_CODEVALIDATION"].ToString();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsMiccomptewebmotpasseoublies = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
        //    //--TEST CONTRAINTE
        //    clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMiccomptewebmotpasseoublieWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = row["RP_NUMSEQUENCE"].ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = row["RP_CODEVALIDATION"].ToString();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsMiccomptewebmotpasseoublies;
    }



       



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /// 
       // List<clsMiccomptewebmotpasseoublie>
        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> pvgUserForgotPassword(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMiccomptewebmotpasseoublies = TestChampObligatoireMotDePasseOublier(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
                //--TEST CONTRAINTE
                clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieDTO in Objet)
                {
                    Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublieDTO.RP_NUMSEQUENCE.ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieDTO.RP_CODEVALIDATION.ToString();
                    clsObjetEnvoi.OE_A = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_Y;

                    List<BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublieListe = new List<BOJ.clsMiccomptewebmotpasseoublie>();

                    clsMiccomptewebmotpasseoublieListe = clsMiccomptewebmotpasseoublieWSBLL.pvgSelectDataSetUserForgotPassword(clsDonnee, clsMiccomptewebmotpasseoublieDTO.LG_CODELANGUE, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT, clsMiccomptewebmotpasseoublieDTO.CL_CODECLIENT, clsMiccomptewebmotpasseoublieDTO.TYPEOPERATION);
                    clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                    foreach (BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieBOJ in clsMiccomptewebmotpasseoublieListe)
                    {
                        HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieDTO1 = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                        
                        clsMiccomptewebmotpasseoublieDTO1.TI_IDTIERS = clsMiccomptewebmotpasseoublieBOJ.TI_IDTIERS;
                        clsMiccomptewebmotpasseoublieDTO1.PV_CODEPOINTVENTE = clsMiccomptewebmotpasseoublieBOJ.PV_CODEPOINTVENTE;
                        clsMiccomptewebmotpasseoublieDTO1.RP_DATE = clsMiccomptewebmotpasseoublieBOJ.RP_DATE.ToShortDateString().Replace(" /", "-");
                        clsMiccomptewebmotpasseoublieDTO1.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieBOJ.RP_CODEVALIDATION;
                        clsMiccomptewebmotpasseoublieDTO1.RP_HEURE = clsMiccomptewebmotpasseoublieBOJ.RP_HEURE.ToShortTimeString();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour = new Common.clsObjetRetour();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieDTO1.TI_IDTIERS = clsMiccomptewebmotpasseoublieBOJ.TI_IDTIERS;
                        clsMiccomptewebmotpasseoublieDTO1.RP_DATE = clsMiccomptewebmotpasseoublieBOJ.RP_DATE.ToShortDateString().Replace(" /", "-");
                        clsMiccomptewebmotpasseoublieDTO1.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieBOJ.RP_CODEVALIDATION;
                        clsMiccomptewebmotpasseoublieDTO1.RP_HEURE = clsMiccomptewebmotpasseoublieBOJ.RP_HEURE.ToShortTimeString();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_MESSAGE = clsMiccomptewebmotpasseoublieBOJ.SL_MESSAGE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_MESSAGEOBJET = clsMiccomptewebmotpasseoublieBOJ.SL_MESSAGEOBJET.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.AG_EMAIL = clsMiccomptewebmotpasseoublieBOJ.AG_EMAIL.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.AG_EMAILMOTDEPASSE = clsMiccomptewebmotpasseoublieBOJ.AG_EMAILMOTDEPASSE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_MESSAGECLIENT = clsMiccomptewebmotpasseoublieBOJ.SL_MESSAGECLIENT.ToString();
                        //clsMiccomptewebmotpasseoublie.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
                        clsMiccomptewebmotpasseoublieDTO1.OB_NOMOBJET = "FrmOperateur";// Dataset.Tables["TABLE"].Rows[Idx]["OB_NOMOBJET"].ToString();




                        clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublieDTO1);
                    }
                    
                    //clsObjetRetour.SetValue(true, clsMiccomptewebmotpasseoublieWSBLL.pvgAjouter(clsDonnee, clsMiccomptewebmotpasseoublie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                    clsMiccomptewebmotpasseoublieDTO.AG_CODEAGENCE = "1000";

                    if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "TRUE")
                    {
                        
                        if (clsMiccomptewebmotpasseoublieDTO.CL_CONTACT != "" && !clsMiccomptewebmotpasseoublieDTO.CL_CONTACT.Contains("@"))
                        {

                            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                            //if (CL_CONTACT.Length == 10)
                            //    CL_CONTACT = "00225" + CL_CONTACT;
                            string CL_IDCLIENT = "";
                            BOJ.clsParams clsParams = new BOJ.clsParams();
                            //clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebmotpasseoublieListe[0].AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT, clsMiccomptewebmotpasseoublieListe[0].OP_CODEOPERATEUR, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, "", CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);
                            clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple(clsDonnee, clsMiccomptewebmotpasseoublieDTO.AG_CODEAGENCE, clsMiccomptewebmotpasseoublies[0].OB_NOMOBJET, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT,clsMiccomptewebmotpasseoublies[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublies[0].TI_IDTIERS, clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0003", clsMiccomptewebmotpasseoublieListe[0].RP_DATE, "0", "", "");


                            clsMiccomptewebmotpasseoublies[0].SL_RESULTATAPI = clsParams.SL_RESULTAT;
                            clsMiccomptewebmotpasseoublies[0].SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                            if (clsParams.SL_RESULTAT == "FALSE") clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGE + " " + clsParams.SL_MESSAGE;



                        }


                        if (clsMiccomptewebmotpasseoublieDTO.CL_CONTACT.Contains("@") && CheckForInternetConnection())
                        {

                            string pvgTitre = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGEOBJET;
                            string vppMessage = clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT + " ";
                            string vppMailExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAIL;
                            string vppMotDePasseExpediteur = clsMiccomptewebmotpasseoublieListe[0].AG_EMAILMOTDEPASSE;
                            string vppMailRecepteur = clsMiccomptewebmotpasseoublieDTO.CL_CONTACT;
                            string vppCheminCompletFichierEnvoyer1 = "";
                            string vppCheminCompletFichierEnvoyer2 = "";
                            string vppCheminCompletFichierEnvoyer3 = "";

                            sendmail(pvgTitre, vppMessage, vppMailExpediteur, vppMotDePasseExpediteur, vppMailRecepteur, vppCheminCompletFichierEnvoyer1, vppCheminCompletFichierEnvoyer2, vppCheminCompletFichierEnvoyer3);

                        }



                    }
                    //clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        //HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie1 = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                        //clsMiccomptewebmotpasseoublie1.clsObjetRetour = new Common.clsObjetRetour();
                        //clsMiccomptewebmotpasseoublie1.clsObjetRetour.SL_CODEMESSAGE = "00";
                        //clsMiccomptewebmotpasseoublie1.clsObjetRetour.SL_RESULTAT = "TRUE";
                        //clsMiccomptewebmotpasseoublie1.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        //clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie1);
                    }
                    else
                    {
                        HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie1 = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                        clsMiccomptewebmotpasseoublie1.clsObjetRetour = new Common.clsObjetRetour();
                        clsMiccomptewebmotpasseoublie1.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsMiccomptewebmotpasseoublie1.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsMiccomptewebmotpasseoublie1.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                        clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie1);
                    }



                }
            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /// 
        // List<clsMiccomptewebmotpasseoublie>
        public List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> pvgUserNewPassword(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
        {

            
            List <Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMiccomptewebmotpasseoublies = TestChampObligatoireUserNewPassword(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
                ////--TEST CONTRAINTE
                //clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
                ////--VERIFICATION DU RESULTAT DU TEST
                //if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieDTO in Objet)
                {
                    Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublieDTO.RP_NUMSEQUENCE.ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieDTO.RP_CODEVALIDATION.ToString();
                    clsObjetEnvoi.OE_A = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_Y;

                    List<BOJ.clsMiccomptewebUserNewPassword> clsMiccomptewebmotpasseoublieListe = new List<BOJ.clsMiccomptewebUserNewPassword>();
                    //(Objet[0].DATEJOURNEE,Objet[0].SL_MOTDEPASSE,Objet[0].RP_CODEVALIDATION,Objet[0].RP_DATE,Objet[0].RP_HEURE,Objet[0].SL_VERSIONAPK,Objet[0].LG_CODELANGUE, Objet[0].OS_MACADRESSE,Objet[0].TYPEOPERATION)

                    //clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSE, string RP_CODEVALIDATION, string RP_DATE, string RP_HEURE, string TYPEOPERATION
                    clsMiccomptewebmotpasseoublieListe = clsMiccomptewebmotpasseoublieWSBLL.pvgUserNewPassword(clsDonnee, clsMiccomptewebmotpasseoublieDTO.LG_CODELANGUE, clsMiccomptewebmotpasseoublieDTO.SL_MOTDEPASSE, clsMiccomptewebmotpasseoublieDTO.RP_CODEVALIDATION, clsMiccomptewebmotpasseoublieDTO.RP_DATE, clsMiccomptewebmotpasseoublieDTO.RP_HEURE, clsMiccomptewebmotpasseoublieDTO.TYPEOPERATION);
                    
                    foreach (BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublieBOJ in clsMiccomptewebmotpasseoublieListe)
                    {
                        HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublieDTO1 = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();


                        clsMiccomptewebmotpasseoublieDTO1.AG_CODEAGENCE = clsMiccomptewebmotpasseoublieBOJ.AG_CODEAGENCE.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.AG_RAISONSOCIAL = clsMiccomptewebmotpasseoublieBOJ.AG_RAISONSOCIAL.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.AG_TELEPHONE = clsMiccomptewebmotpasseoublieBOJ.AG_TELEPHONE.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.AG_BOITEPOSTAL = clsMiccomptewebmotpasseoublieBOJ.AG_BOITEPOSTAL.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.CL_IDCLIENT = clsMiccomptewebmotpasseoublieBOJ.CL_IDCLIENT.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.OP_CODEOPERATEUR = clsMiccomptewebmotpasseoublieBOJ.CL_IDCLIENT.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.OP_NOMPRENOM = clsMiccomptewebmotpasseoublieBOJ.CL_NOMCLIENT.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.tel = clsMiccomptewebmotpasseoublieBOJ.CL_TELEPHONE.ToString();
                        //clsMiccomptewebmotpasseoublieDTO1.RP_EMAIL = clsMiccomptewebmotpasseoublieBOJ.CL_EMAIL.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour = new Common.clsObjetRetour();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_MESSAGE = clsMiccomptewebmotpasseoublieBOJ.SL_MESSAGE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_LOGIN = clsMiccomptewebmotpasseoublieBOJ.SL_LOGIN.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_MOTDEPASSE = clsMiccomptewebmotpasseoublieBOJ.SL_MOTPASSE.ToString();
                        clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublieDTO1);
                    }

                }
            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /// 
        // List<clsMiccomptewebmotpasseoublie>
        public List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> pvgUserUpdatePassword(List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMiccomptewebmotpasseoublies = TestChampObligatoireUpdateMotDePasse(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
                //--TEST CONTRAINTE
                //clsMiccomptewebmotpasseoublies = TestTestContrainteListe(Objet[Idx]);
                ////--VERIFICATION DU RESULTAT DU TEST
                //if (clsMiccomptewebmotpasseoublies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMiccomptewebmotpasseoublies;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublieDTO in Objet)
                {
                    Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new Stock.BOJ.clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = clsMiccomptewebmotpasseoublieDTO.RP_NUMSEQUENCE.ToString();
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsMiccomptewebmotpasseoublieDTO.RP_CODEVALIDATION.ToString();
                    clsObjetEnvoi.OE_A = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMiccomptewebmotpasseoublieDTO.clsObjetEnvoi.OE_Y;

                    List<BOJ.clsMiccomptewebUserNewPassword> clsMiccomptewebmotpasseoublieListe = new List<BOJ.clsMiccomptewebUserNewPassword>();
                  //  string LG_CODELANGUE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW
                    

                    if (clsMiccomptewebmotpasseoublieDTO.TYPEOPERATION == "04")
                        clsMiccomptewebmotpasseoublieListe = clsMiccomptewebmotpasseoublieWSBLL.pvgUserUpdatePassword(clsDonnee, clsMiccomptewebmotpasseoublieDTO.LG_CODELANGUE, clsMiccomptewebmotpasseoublieDTO.SL_MOTPASSEOLD, clsMiccomptewebmotpasseoublieDTO.SL_LOGINOLD, clsMiccomptewebmotpasseoublieDTO.SL_MOTPASSENEW, clsMiccomptewebmotpasseoublieDTO.SL_LOGINNEW);
                    else
                        clsMiccomptewebmotpasseoublieListe = clsMiccomptewebmotpasseoublieWSBLL.pvgUserUpdatePasswordClient(clsDonnee, clsMiccomptewebmotpasseoublieDTO.LG_CODELANGUE, clsMiccomptewebmotpasseoublieDTO.SL_MOTPASSEOLD, clsMiccomptewebmotpasseoublieDTO.SL_LOGINOLD, clsMiccomptewebmotpasseoublieDTO.SL_MOTPASSENEW, clsMiccomptewebmotpasseoublieDTO.SL_LOGINNEW);

                    clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
                    foreach (BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublieBOJ in clsMiccomptewebmotpasseoublieListe)
                    {
                        HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublieDTO1 = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();


                        clsMiccomptewebmotpasseoublieDTO1.AG_CODEAGENCE = clsMiccomptewebmotpasseoublieBOJ.AG_CODEAGENCE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.AG_RAISONSOCIAL = clsMiccomptewebmotpasseoublieBOJ.AG_RAISONSOCIAL.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.AG_TELEPHONE = clsMiccomptewebmotpasseoublieBOJ.AG_TELEPHONE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.AG_BOITEPOSTAL = clsMiccomptewebmotpasseoublieBOJ.AG_BOITEPOSTAL.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.CL_IDCLIENT = clsMiccomptewebmotpasseoublieBOJ.CL_IDCLIENT.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.OP_CODEOPERATEUR = clsMiccomptewebmotpasseoublieBOJ.CL_IDCLIENT.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.OP_NOMPRENOM = clsMiccomptewebmotpasseoublieBOJ.OP_NOMPRENOM.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.OP_TELEPHONE = clsMiccomptewebmotpasseoublieBOJ.OP_TELEPHONE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.OP_EMAIL = clsMiccomptewebmotpasseoublieBOJ.OP_EMAIL.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_MESSAGE = clsMiccomptewebmotpasseoublieBOJ.SL_MESSAGE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_LOGIN = clsMiccomptewebmotpasseoublieBOJ.SL_LOGIN.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.SL_MOTPASSE = clsMiccomptewebmotpasseoublieBOJ.SL_MOTPASSE.ToString();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour = new Common.clsObjetRetour();
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebmotpasseoublieBOJ.SL_RESULTAT;
                        clsMiccomptewebmotpasseoublieDTO1.clsObjetRetour.SL_MESSAGE = clsMiccomptewebmotpasseoublieBOJ.SL_MESSAGE.ToString();

                        clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublieDTO1);
                    }

                    
                }
            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMiccomptewebmotpasseoublies;
        }






        //public clsMiccomptewebUserNewPassword pvgUserUpdatePassword(string DATEJOURNEE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string TYPEOPERATEUR, string OS_MACADRESSE)

        //{
        //    clsObjetRetour clsObjetRetour = new clsObjetRetour();

        //    clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
        //    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        //    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //    List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswordListe = new List<clsMiccomptewebUserNewPassword>();
        //    clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
        //    List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
        //    bool vlpTest = false;

        //    if (string.IsNullOrEmpty(LG_CODELANGUE))
        //    {
        //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
        //        clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();




        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (string.IsNullOrEmpty(TYPEOPERATEUR))
        //    {
        //        clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();


        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (string.IsNullOrEmpty(SL_VERSIONAPK))
        //    {
        //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
        //        clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();




        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }




        //    if (string.IsNullOrEmpty(SL_MOTPASSEOLD))
        //    {
        //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
        //        clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();




        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0022", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(OS_MACADRESSE))
        //    {

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(SL_LOGINOLD))
        //    {
        //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
        //        clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0023", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(SL_MOTPASSENEW))
        //    {
        //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
        //        clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0024", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }
        //    if (string.IsNullOrEmpty(SL_LOGINNEW))
        //    {
        //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
        //        clsMiccomptewebResultat clsMiccomptewebResultat1 = new clsMiccomptewebResultat();


        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0025", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }



        //    //, CL_NOMUTILISATEUR  , CL_MOTDEPASSE  ,SL_CLESESSION,

        //    if (string.IsNullOrEmpty(SL_LOGIN))
        //    {

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0003", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(SL_MOTDEPASSE))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(SL_CLESESSION))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0005", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }



        //    try
        //    {
        //        //clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        //        //clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        //        //clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        //clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //        clsDonnee.pvgDemarrerTransaction();


        //        //----VERIFICATION DE LA CLE DE SESSION
        //        //List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();
        //        string vlpTypeOperation = "03";
        //        if (TYPEOPERATEUR != "04") vlpTypeOperation = "01";
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, SL_LOGIN, SL_MOTDEPASSE, SL_CLESESSION, SL_VERSIONAPK, vlpTypeOperation);

        //        if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
        //        {
        //            clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //            clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //            clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //            clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //            return clsMiccomptewebUserNewPasswordListe[0];
        //        }
        //        //--
        //        //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

        //        if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
        //        {
        //            clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //            clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //            clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //            clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //            return clsMiccomptewebUserNewPasswordListe[0];
        //        }
        //        if (TYPEOPERATEUR == "04")
        //            clsMiccomptewebUserNewPasswordListe = clsTontinewebWSBLL.pvgUserUpdatePassword(clsDonnee, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW);
        //        else
        //            clsMiccomptewebUserNewPasswordListe = clsTontinewebWSBLL.pvgUserUpdatePasswordClient(clsDonnee, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW);

        //    }
        //    catch (SqlException SQLEx)
        //    {

        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //    }
        //    catch (Exception SQLEx)
        //    {

        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //    }
        //    finally
        //    {
        //        //if (vlpTest == false)
        //        clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
        //    }


        //    return clsMiccomptewebUserNewPasswordListe[0];
        //}

        //public clsMiccomptewebUserNewPassword pvgUserNewPassword(string DATEJOURNEE, string SL_MOTPASSE, string RP_CODEVALIDATION, string RP_DATE, string RP_HEURE, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string TYPEOPERATION)
        //{
        //    bool vlpTest = false;
        //    HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

        //    HT_Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new HT_Stock.BOJ.clsObjetEnvoi();
        //    List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswordListe = new List<clsMiccomptewebUserNewPassword>();
        //    clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
        //    List<clsMiccomptewebResultat> clsMiccomptewebResultat = new List<clsMiccomptewebResultat>();

        //    if (string.IsNullOrEmpty(LG_CODELANGUE))
        //    {

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0255", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }
        //    //if (string.IsNullOrEmpty(TYPEOPERATEUR))
        //    //{
        //    //    clsMiccomptewebUserLogin clsMiccomptewebUserLogin1 = new clsMiccomptewebUserLogin();


        //    //    //----EXEPTION
        //    //    clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //    //    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //    //    clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0236", "01");
        //    //    clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //    //    clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //    //    clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //    //    clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //    //    return clsMiccomptewebUserNewPasswordListe[0];
        //    // }

        //    if (string.IsNullOrEmpty(OS_MACADRESSE))
        //    {

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0241", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (string.IsNullOrEmpty(SL_VERSIONAPK))
        //    {

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0001", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);
        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (string.IsNullOrEmpty(SL_MOTPASSE))
        //    {

        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0004", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(RP_CODEVALIDATION))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0013", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    if (string.IsNullOrEmpty(RP_DATE))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0014", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (!clsDate.ClasseDate.pvgTestSiDate1(RP_DATE))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0015", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (string.IsNullOrEmpty(RP_HEURE))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0016", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (string.IsNullOrEmpty(TYPEOPERATION))
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0006", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }


        //    if (TYPEOPERATION != "01" && TYPEOPERATION != "02")
        //    {
        //        //----EXEPTION
        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0034", "01");
        //        clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //        return clsMiccomptewebUserNewPasswordListe[0];
        //    }

        //    try
        //    {
        //        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        //        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //        clsDonnee.pvgDemarrerTransaction();

        //        //----

        //        clsTontinewebWSBLL clsTontinewebWSBLL = new clsTontinewebWSBLL();
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaCledeSession(clsDonnee, LG_CODELANGUE, "", "", "", SL_VERSIONAPK, "02");

        //        if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
        //        {

        //            clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //            clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //            clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //            clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //            return clsMiccomptewebUserNewPasswordListe[0];
        //        }

        //        //----VERIFICATION DE LA LICENCE DE L'UTILISATEUR
        //        clsMiccomptewebResultat = clsTontinewebWSBLL.pvgValidationdelaLicence(clsDonnee, LG_CODELANGUE, OS_MACADRESSE, "01");

        //        if (clsMiccomptewebResultat[0].SL_RESULTAT == "FALSE")
        //        {
        //            clsMiccomptewebUserNewPassword.SL_CODEMESSAGE = clsMiccomptewebResultat[0].SL_CODEMESSAGE;
        //            clsMiccomptewebUserNewPassword.SL_RESULTAT = clsMiccomptewebResultat[0].SL_RESULTAT;
        //            clsMiccomptewebUserNewPassword.SL_MESSAGE = clsMiccomptewebResultat[0].SL_MESSAGE;
        //            clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //            return clsMiccomptewebUserNewPasswordListe[0];
        //        }

        //        clsMiccomptewebUserNewPasswordListe = clsTontinewebWSBLL.pvgUserNewPassword(clsDonnee, LG_CODELANGUE, SL_MOTPASSE, RP_CODEVALIDATION, RP_DATE, RP_HEURE, TYPEOPERATION);


        //    }
        //    catch (SqlException SQLEx)
        //    {
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //    }
        //    catch (Exception SQLEx)
        //    {
        //        clsMiccomptewebUserNewPassword.SL_RESULTAT = "FALSE";
        //        clsMiccomptewebUserNewPassword.SL_MESSAGE = SQLEx.Message;
        //        clsMiccomptewebUserNewPasswordListe.Add(clsMiccomptewebUserNewPassword);

        //    }
        //    finally
        //    {
        //        //if (vlpTest == false)
        //        clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
        //    }


        //    return clsMiccomptewebUserNewPasswordListe[0];
        //}



        //Envoi de mail
        public void sendmail(string pvgTitre, string vppMessage, string vppMailExpediteur, string vppMotDePasseExpediteur, string vppMailRecepteur, string vppCheminCompletFichierEnvoyer1, string vppCheminCompletFichierEnvoyer2, string vppCheminCompletFichierEnvoyer3)
        {
            try
            {
                ////-I-Préparation du fichier
                //ReportDocument cryRpt;

                ////string pdfFile = "c:\\csharp.net-informations.pdf";
                //string pdfFile = vppCheminCompletFichierPDFEnvoyer;
                //cryRpt = new ReportDocument();
                //string PATH = Application.StartupPath + "\\Etats\\" + vappFichier;
                //cryRpt.Load(PATH);
                //cryRpt.SetDataSource(vappTable.Tables[0]);
                //for (int Idx = 0; Idx < vappNomFormule.GetLength(0); Idx++)
                //{
                //    string vlpNomFormule = vappNomFormule[Idx].ToString();
                //    string vlpValeurFormule = vappValeurFormule[Idx].ToString();
                //    cryRpt.DataDefinition.FormulaFields[vlpNomFormule].Text = "'" + vlpValeurFormule.Replace("'", "''") + "'";

                //}

                //CrystalReportViewer crystalReportViewer1 = new CrystalReportViewer();
                //crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.Refresh();

                ////-II-Exportation du fichier
                //ExportOptions CrExportOptions;
                //DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                //PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                //CrDiskFileDestinationOptions.DiskFileName = pdfFile;
                //CrExportOptions = cryRpt.ExportOptions;
                //CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                //CrExportOptions.FormatOptions = CrFormatTypeOptions;
                //cryRpt.Export();

                //-III-Envoi du fichier par mail
                System.Net.Mail.MailMessage mm = null;
                //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false && clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailRecepteur) != false)
                mm = new System.Net.Mail.MailMessage(vppMailExpediteur, vppMailRecepteur);
                // Contenu du message
                if (mm != null)
                {
                    mm.Subject = pvgTitre;
                    mm.Body = vppMessage;
                }
                //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false && clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailRecepteur2) != false)
                //    mm.CC.Add(vppMailRecepteur2);

                //Ajoute des fichiers joints
                if (vppCheminCompletFichierEnvoyer1 != "")
                    mm.Attachments.Add(new Attachment(vppCheminCompletFichierEnvoyer1));
                if (vppCheminCompletFichierEnvoyer2 != "")
                    mm.Attachments.Add(new Attachment(vppCheminCompletFichierEnvoyer2));
                if (vppCheminCompletFichierEnvoyer3 != "")
                    mm.Attachments.Add(new Attachment(vppCheminCompletFichierEnvoyer3));

                // Sending message
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);

                if (vppMailExpediteur != null)
                {
                    // Le compte credentials
                    //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false)
                    sc.Credentials = new NetworkCredential(vppMailExpediteur, vppMotDePasseExpediteur, "");
                    sc.EnableSsl = true;

                    // Envoie du message
                    try
                    {
                        //if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(vppMailExpediteur) != false)
                        sc.Send(mm);
                        // MessageBox.Show("Message sent");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error: " + ex.Message);
                    }
                }




                ////

                ////SmtpMail.SmtpServer.Insert(587,"smtp.gmail.com");
                ////System.Web.Mail.MailMessage Msg = new System.Web.Mail.MailMessage();
                ////Msg.To = "d.baz1008@gmail.com";
                ////Msg.From = "d.baz1008@gmail.com";
                ////Msg.Subject = "Crystal Report Attachment ";
                ////Msg.Body = "Crystal Report Attachment ";
                ////Msg.Attachments.Add(new MailAttachment(pdfFile));
                ////System.Web.Mail.SmtpMail.Send(Msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                //XtraMessageBox.Show("Impossible de se connecter a internet !!! ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


    }
}
