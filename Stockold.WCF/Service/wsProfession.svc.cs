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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsProfession" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsProfession.svc ou wsProfession.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsProfession : IwsProfession
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsProfessionWSBLL clsProfessionWSBLL = new clsProfessionWSBLL();

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
        public List<HT_Stock.BOJ.clsProfession> pvgAjouter(List<HT_Stock.BOJ.clsProfession> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsProfessions = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
                //--TEST CONTRAINTE
                clsProfessions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsProfession clsProfessionDTO in Objet)
                {
                    Stock.BOJ.clsProfession clsProfession = new Stock.BOJ.clsProfession();
                    clsProfession.PF_CODEPROFESSION = clsProfessionDTO.PF_CODEPROFESSION.ToString();
                    clsProfession.PF_LIBELLE = clsProfessionDTO.PF_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsProfessionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfessionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsProfessionWSBLL.pvgAjouter(clsDonnee, clsProfession, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfession.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsProfessions.Add(clsProfession);
                }
                else
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsProfession.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsProfessions.Add(clsProfession);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                clsProfessions.Add(clsProfession);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                clsProfessions.Add(clsProfession);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsProfessions;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsProfession> pvgModifier(List<HT_Stock.BOJ.clsProfession> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsProfessions = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
                //--TEST CONTRAINTE
                clsProfessions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsProfession clsProfessionDTO in Objet)
                {
                    Stock.BOJ.clsProfession clsProfession = new Stock.BOJ.clsProfession();
                    clsProfession.PF_CODEPROFESSION = clsProfessionDTO.PF_CODEPROFESSION.ToString();
                    clsProfession.PF_LIBELLE = clsProfessionDTO.PF_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsProfessionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfessionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsProfessionDTO.PF_CODEPROFESSION };
                    clsObjetRetour.SetValue(true, clsProfessionWSBLL.pvgModifier(clsDonnee, clsProfession, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfession.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsProfessions.Add(clsProfession);
                }
                else
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsProfession.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsProfessions.Add(clsProfession);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                clsProfessions.Add(clsProfession);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                clsProfessions.Add(clsProfession);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsProfessions;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsProfession> pvgSupprimer(List<HT_Stock.BOJ.clsProfession> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsProfessions = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
                //--TEST CONTRAINTE
                clsProfessions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PF_CODEPROFESSION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsProfessionWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfession.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsProfessions.Add(clsProfession);
                }
                else
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsProfession.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsProfessions.Add(clsProfession);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                clsProfessions.Add(clsProfession);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
                clsProfessions.Add(clsProfession);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsProfessions;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsProfession> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsProfession> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsProfessions = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
            //    //--TEST CONTRAINTE
            //    clsProfessions = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfessionWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                    clsProfession.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfession.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfessions.Add(clsProfession);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfession.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfessions.Add(clsProfession);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfession.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            clsProfessions.Add(clsProfession);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfession.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            clsProfessions.Add(clsProfession);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsProfessions;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsProfession> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsProfession> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsProfessions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
        //    //--TEST CONTRAINTE
        //    clsProfessions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfessions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfessions;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfessionWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                    clsProfession.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                    clsProfession.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfession.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfession.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfessions.Add(clsProfession);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfession.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfessions.Add(clsProfession);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfession.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            clsProfessions.Add(clsProfession);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfession.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfession.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            clsProfessions.Add(clsProfession);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsProfessions;
    }


        
    }
}
