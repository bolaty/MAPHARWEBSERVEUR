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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsSexe" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsSexe.svc ou wsSexe.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsSexe : IwsSexe
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsSexeWSBLL clsSexeWSBLL = new clsSexeWSBLL();

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
        public List<HT_Stock.BOJ.clsSexe> pvgAjouter(List<HT_Stock.BOJ.clsSexe> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsSexes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
                //--TEST CONTRAINTE
                clsSexes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsSexe clsSexeDTO in Objet)
                {
                    Stock.BOJ.clsSexe clsSexe = new Stock.BOJ.clsSexe();
                    clsSexe.SX_CODESEXE = clsSexeDTO.SX_CODESEXE.ToString();
                    clsSexe.SX_LIBELLE = clsSexeDTO.SX_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsSexeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsSexeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsSexeWSBLL.pvgAjouter(clsDonnee, clsSexe, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSexe.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsSexes.Add(clsSexe);
                }
                else
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsSexe.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsSexes.Add(clsSexe);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                clsSexes.Add(clsSexe);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                clsSexes.Add(clsSexe);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsSexes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsSexe> pvgModifier(List<HT_Stock.BOJ.clsSexe> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsSexes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
                //--TEST CONTRAINTE
                clsSexes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsSexe clsSexeDTO in Objet)
                {
                    Stock.BOJ.clsSexe clsSexe = new Stock.BOJ.clsSexe();
                    clsSexe.SX_CODESEXE = clsSexeDTO.SX_CODESEXE.ToString();
                    clsSexe.SX_LIBELLE = clsSexeDTO.SX_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsSexeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsSexeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsSexeDTO.SX_CODESEXE };
                    clsObjetRetour.SetValue(true, clsSexeWSBLL.pvgModifier(clsDonnee, clsSexe, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSexe.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsSexes.Add(clsSexe);
                }
                else
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsSexe.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsSexes.Add(clsSexe);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                clsSexes.Add(clsSexe);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                clsSexes.Add(clsSexe);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsSexes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsSexe> pvgSupprimer(List<HT_Stock.BOJ.clsSexe> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsSexes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
                //--TEST CONTRAINTE
                clsSexes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SX_CODESEXE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsSexeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSexe.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsSexes.Add(clsSexe);
                }
                else
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsSexe.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsSexes.Add(clsSexe);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                clsSexes.Add(clsSexe);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSexes = new List<HT_Stock.BOJ.clsSexe>();
                clsSexes.Add(clsSexe);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsSexes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsSexe> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsSexe> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsSexes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
            //    //--TEST CONTRAINTE
            //    clsSexes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsSexeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                    clsSexe.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSexe.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsSexes.Add(clsSexe);
                }
            }
            else
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsSexe.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsSexes.Add(clsSexe);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
            clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSexe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            clsSexes.Add(clsSexe);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
            clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSexe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            clsSexes.Add(clsSexe);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsSexes;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsSexe> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsSexe> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsSexes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
        //    //--TEST CONTRAINTE
        //    clsSexes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsSexes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSexes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsSexeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                    clsSexe.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                    clsSexe.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                    clsSexe.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSexe.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsSexes.Add(clsSexe);
                }
            }
            else
            {
                HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsSexe.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsSexes.Add(clsSexe);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
            clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSexe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            clsSexes.Add(clsSexe);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
            clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSexe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSexe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            clsSexes.Add(clsSexe);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsSexes;
    }


        
    }
}
