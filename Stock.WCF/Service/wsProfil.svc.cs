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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsProfil" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsProfil.svc ou wsProfil.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsProfil : IwsProfil
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsProfilWSBLL clsProfilWSBLL = new clsProfilWSBLL();

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
        public List<HT_Stock.BOJ.clsProfil> pvgAjouter(List<HT_Stock.BOJ.clsProfil> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsProfils = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
                //--TEST CONTRAINTE
                clsProfils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsProfil clsProfilDTO in Objet)
                {
                    Stock.BOJ.clsProfil clsProfil = new Stock.BOJ.clsProfil();
                    clsProfil.PO_CODEPROFIL = clsProfilDTO.PO_CODEPROFIL.ToString();
                    clsProfil.PO_LIBELLE = clsProfilDTO.PO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsProfilDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsProfilWSBLL.pvgAjouter(clsDonnee, clsProfil, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsProfils.Add(clsProfil);
                }
                else
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsProfil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsProfils.Add(clsProfil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                clsProfils.Add(clsProfil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                clsProfils.Add(clsProfil);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsProfils;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsProfil> pvgModifier(List<HT_Stock.BOJ.clsProfil> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsProfils = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
                //--TEST CONTRAINTE
                clsProfils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsProfil clsProfilDTO in Objet)
                {
                    Stock.BOJ.clsProfil clsProfil = new Stock.BOJ.clsProfil();
                    clsProfil.PO_CODEPROFIL = clsProfilDTO.PO_CODEPROFIL.ToString();
                    clsProfil.PO_LIBELLE = clsProfilDTO.PO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsProfilDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsProfilDTO.PO_CODEPROFIL };
                    clsObjetRetour.SetValue(true, clsProfilWSBLL.pvgModifier(clsDonnee, clsProfil, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsProfils.Add(clsProfil);
                }
                else
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsProfil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsProfils.Add(clsProfil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                clsProfils.Add(clsProfil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                clsProfils.Add(clsProfil);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsProfils;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsProfil> pvgSupprimer(List<HT_Stock.BOJ.clsProfil> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsProfils = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
                //--TEST CONTRAINTE
                clsProfils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFIL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsProfilWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsProfils.Add(clsProfil);
                }
                else
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsProfil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsProfils.Add(clsProfil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                clsProfils.Add(clsProfil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsProfils = new List<HT_Stock.BOJ.clsProfil>();
                clsProfils.Add(clsProfil);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsProfils;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsProfil> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsProfil> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsProfils = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            //    //--TEST CONTRAINTE
            //    clsProfils = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].PO_LIBELLE ,""};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.PO_CODEPROFIL = row["PO_CODEPROFIL"].ToString();
                    clsProfil.PO_LIBELLE = row["PO_LIBELLE"].ToString();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfil.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfils.Add(clsProfil);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfil.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfils.Add(clsProfil);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            clsProfils.Add(clsProfil);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            clsProfils.Add(clsProfil);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsProfils;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsProfil> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsProfil> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsProfils = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            //    //--TEST CONTRAINTE
            //    clsProfils = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsProfils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfils;
            //}

            if (string.IsNullOrEmpty(Objet[0].PO_LIBELLE))
                Objet[0].PO_LIBELLE = "";

            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].PO_LIBELLE,"" };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                    clsProfil.PO_CODEPROFIL = row["PO_CODEPROFIL"].ToString();
                    clsProfil.PO_LIBELLE = row["PO_LIBELLE"].ToString();
                    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfil.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfil.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfils.Add(clsProfil);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfil.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfils.Add(clsProfil);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            clsProfils.Add(clsProfil);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            clsProfils.Add(clsProfil);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsProfils;
    }


        
    }
}
