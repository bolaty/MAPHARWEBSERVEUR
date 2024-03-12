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


        
    }
}
