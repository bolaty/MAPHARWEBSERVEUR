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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsTypevehicule" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsTypevehicule.svc ou wsTypevehicule.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsTypevehicule : IwsTypevehicule
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsTypevehiculeWSBLL clsTypevehiculeWSBLL = new clsTypevehiculeWSBLL();

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
        public List<HT_Stock.BOJ.clsTypevehicule> pvgAjouter(List<HT_Stock.BOJ.clsTypevehicule> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypevehicules = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
                //--TEST CONTRAINTE
                clsTypevehicules = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsTypevehicule clsTypevehiculeDTO in Objet)
                {
                    Stock.BOJ.clsTypevehicule clsTypevehicule = new Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.TVH_CODETYPE = clsTypevehiculeDTO.TVH_CODETYPE.ToString();
                    clsTypevehicule.TVH_LIBELE = clsTypevehiculeDTO.TVH_LIBELE.ToString();
                    clsObjetEnvoi.OE_A = clsTypevehiculeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsTypevehiculeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsTypevehiculeWSBLL.pvgAjouter(clsDonnee, clsTypevehicule, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }
                else
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                clsTypevehicules.Add(clsTypevehicule);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                clsTypevehicules.Add(clsTypevehicule);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypevehicules;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypevehicule> pvgModifier(List<HT_Stock.BOJ.clsTypevehicule> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypevehicules = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
                //--TEST CONTRAINTE
                clsTypevehicules = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsTypevehicule clsTypevehiculeDTO in Objet)
                {
                    Stock.BOJ.clsTypevehicule clsTypevehicule = new Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.TVH_CODETYPE = clsTypevehiculeDTO.TVH_CODETYPE.ToString();
                    clsTypevehicule.TVH_LIBELE = clsTypevehiculeDTO.TVH_LIBELE.ToString();
                    clsObjetEnvoi.OE_A = clsTypevehiculeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsTypevehiculeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsTypevehiculeDTO.TVH_CODETYPE };
                    clsObjetRetour.SetValue(true, clsTypevehiculeWSBLL.pvgModifier(clsDonnee, clsTypevehicule, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }
                else
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                clsTypevehicules.Add(clsTypevehicule);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                clsTypevehicules.Add(clsTypevehicule);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypevehicules;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypevehicule> pvgSupprimer(List<HT_Stock.BOJ.clsTypevehicule> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypevehicules = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
                //--TEST CONTRAINTE
                clsTypevehicules = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TVH_CODETYPE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsTypevehiculeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }
                else
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                clsTypevehicules.Add(clsTypevehicule);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
                clsTypevehicules.Add(clsTypevehicule);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypevehicules;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsTypevehicule> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsTypevehicule> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsTypevehicules = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
            //    //--TEST CONTRAINTE
            //    clsTypevehicules = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsTypevehiculeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.TVH_CODETYPE = row["TVH_CODETYPE"].ToString();
                    clsTypevehicule.TVH_LIBELE = row["TVH_LIBELE"].ToString();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypevehicules.Add(clsTypevehicule);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
            clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypevehicule.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            clsTypevehicules.Add(clsTypevehicule);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
            clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypevehicule.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            clsTypevehicules.Add(clsTypevehicule);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsTypevehicules;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypevehicule> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsTypevehicule> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsTypevehicules = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
        //    //--TEST CONTRAINTE
        //    clsTypevehicules = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypevehicules[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypevehicules;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsTypevehiculeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                    clsTypevehicule.TVH_CODETYPE = row["TVH_CODETYPE"].ToString();
                    clsTypevehicule.TVH_LIBELE = row["TVH_LIBELE"].ToString();
                    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypevehicule.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypevehicules.Add(clsTypevehicule);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypevehicules.Add(clsTypevehicule);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
            clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypevehicule.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            clsTypevehicules.Add(clsTypevehicule);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
            clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypevehicule.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            clsTypevehicules.Add(clsTypevehicule);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsTypevehicules;
    }


        
    }
}
