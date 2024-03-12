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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsTypeoperateur" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsTypeoperateur.svc ou wsTypeoperateur.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsTypeoperateur : IwsTypeoperateur
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsTypeoperateurWSBLL clsTypeoperateurWSBLL = new clsTypeoperateurWSBLL();

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
        public List<HT_Stock.BOJ.clsTypeoperateur> pvgAjouter(List<HT_Stock.BOJ.clsTypeoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypeoperateurs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
                //--TEST CONTRAINTE
                clsTypeoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsTypeoperateur clsTypeoperateurDTO in Objet)
                {
                    Stock.BOJ.clsTypeoperateur clsTypeoperateur = new Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.TO_CODETYPEOERATEUR = clsTypeoperateurDTO.TO_CODETYPEOERATEUR.ToString();
                    clsTypeoperateur.TO_LIBELLE = clsTypeoperateurDTO.TO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsTypeoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsTypeoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsTypeoperateurWSBLL.pvgAjouter(clsDonnee, clsTypeoperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                clsTypeoperateurs.Add(clsTypeoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                clsTypeoperateurs.Add(clsTypeoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypeoperateurs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypeoperateur> pvgModifier(List<HT_Stock.BOJ.clsTypeoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypeoperateurs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
                //--TEST CONTRAINTE
                clsTypeoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsTypeoperateur clsTypeoperateurDTO in Objet)
                {
                    Stock.BOJ.clsTypeoperateur clsTypeoperateur = new Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.TO_CODETYPEOERATEUR = clsTypeoperateurDTO.TO_CODETYPEOERATEUR.ToString();
                    clsTypeoperateur.TO_LIBELLE = clsTypeoperateurDTO.TO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsTypeoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsTypeoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsTypeoperateurDTO.TO_CODETYPEOERATEUR };
                    clsObjetRetour.SetValue(true, clsTypeoperateurWSBLL.pvgModifier(clsDonnee, clsTypeoperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                clsTypeoperateurs.Add(clsTypeoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                clsTypeoperateurs.Add(clsTypeoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypeoperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypeoperateur> pvgSupprimer(List<HT_Stock.BOJ.clsTypeoperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsTypeoperateurs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
                //--TEST CONTRAINTE
                clsTypeoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TO_CODETYPEOERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsTypeoperateurWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                clsTypeoperateurs.Add(clsTypeoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
                clsTypeoperateurs.Add(clsTypeoperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsTypeoperateurs;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsTypeoperateur> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsTypeoperateur> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsTypeoperateurs = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
            //    //--TEST CONTRAINTE
            //    clsTypeoperateurs = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsTypeoperateurWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.TO_CODETYPEOERATEUR = row["TO_CODETYPEOERATEUR"].ToString();
                    clsTypeoperateur.TO_LIBELLE = row["TO_LIBELLE"].ToString();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypeoperateurs.Add(clsTypeoperateur);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            clsTypeoperateurs.Add(clsTypeoperateur);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            clsTypeoperateurs.Add(clsTypeoperateur);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsTypeoperateurs;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsTypeoperateur> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsTypeoperateur> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsTypeoperateurs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
        //    //--TEST CONTRAINTE
        //    clsTypeoperateurs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypeoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeoperateurs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsTypeoperateurWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                    clsTypeoperateur.TO_CODETYPEOERATEUR = row["TO_CODETYPEOERATEUR"].ToString();
                    clsTypeoperateur.TO_LIBELLE = row["TO_LIBELLE"].ToString();
                    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypeoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypeoperateurs.Add(clsTypeoperateur);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypeoperateurs.Add(clsTypeoperateur);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            clsTypeoperateurs.Add(clsTypeoperateur);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            clsTypeoperateurs.Add(clsTypeoperateur);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsTypeoperateurs;
    }


        
    }
}
