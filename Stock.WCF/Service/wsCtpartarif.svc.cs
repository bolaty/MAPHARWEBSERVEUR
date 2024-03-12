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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpartarif" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpartarif.svc ou wsCtpartarif.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpartarif : IwsCtpartarif
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpartarifWSBLL clsCtpartarifWSBLL = new clsCtpartarifWSBLL();

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
        public List<HT_Stock.BOJ.clsCtpartarif> pvgAjouter(List<HT_Stock.BOJ.clsCtpartarif> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartarifs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
                //--TEST CONTRAINTE
                clsCtpartarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartarif clsCtpartarifDTO in Objet)
                {
                    Stock.BOJ.clsCtpartarif clsCtpartarif = new Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.TA_CODETARIF = clsCtpartarifDTO.TA_CODETARIF.ToString();
                    clsCtpartarif.TA_LIBELLETARIF = clsCtpartarifDTO.TA_LIBELLETARIF.ToString();
                    clsObjetEnvoi.OE_A = clsCtpartarifDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartarifDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpartarifWSBLL.pvgAjouter(clsDonnee, clsCtpartarif, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                clsCtpartarifs.Add(clsCtpartarif);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                clsCtpartarifs.Add(clsCtpartarif);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartarifs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartarif> pvgModifier(List<HT_Stock.BOJ.clsCtpartarif> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartarifs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
                //--TEST CONTRAINTE
                clsCtpartarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartarif clsCtpartarifDTO in Objet)
                {
                    Stock.BOJ.clsCtpartarif clsCtpartarif = new Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.TA_CODETARIF = clsCtpartarifDTO.TA_CODETARIF.ToString();
                    clsCtpartarif.TA_LIBELLETARIF = clsCtpartarifDTO.TA_LIBELLETARIF.ToString();
                    clsObjetEnvoi.OE_A = clsCtpartarifDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartarifDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpartarifDTO.TA_CODETARIF };
                    clsObjetRetour.SetValue(true, clsCtpartarifWSBLL.pvgModifier(clsDonnee, clsCtpartarif, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                clsCtpartarifs.Add(clsCtpartarif);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                clsCtpartarifs.Add(clsCtpartarif);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartarifs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartarif> pvgSupprimer(List<HT_Stock.BOJ.clsCtpartarif> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartarifs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
                //--TEST CONTRAINTE
                clsCtpartarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TA_CODETARIF };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpartarifWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                clsCtpartarifs.Add(clsCtpartarif);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
                clsCtpartarifs.Add(clsCtpartarif);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartarifs;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtpartarif> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpartarif> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtpartarifs = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
            //    //--TEST CONTRAINTE
            //    clsCtpartarifs = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartarifWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.TA_CODETARIF = row["TA_CODETARIF"].ToString();
                    clsCtpartarif.TA_LIBELLETARIF = row["TA_LIBELLETARIF"].ToString();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartarifs.Add(clsCtpartarif);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
            clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            clsCtpartarifs.Add(clsCtpartarif);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
            clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            clsCtpartarifs.Add(clsCtpartarif);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartarifs;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartarif> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpartarif> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtpartarifs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
        //    //--TEST CONTRAINTE
        //    clsCtpartarifs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartarifs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartarifWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                    clsCtpartarif.TA_CODETARIF = row["TA_CODETARIF"].ToString();
                    clsCtpartarif.TA_LIBELLETARIF = row["TA_LIBELLETARIF"].ToString();
                    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartarif.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartarifs.Add(clsCtpartarif);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartarifs.Add(clsCtpartarif);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
            clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            clsCtpartarifs.Add(clsCtpartarif);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
            clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            clsCtpartarifs.Add(clsCtpartarif);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpartarifs;
    }


        
    }
}
