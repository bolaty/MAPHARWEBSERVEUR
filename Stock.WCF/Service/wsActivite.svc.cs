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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsActivite" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsActivite.svc ou wsActivite.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsActivite : IwsActivite
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsActiviteWSBLL clsActiviteWSBLL = new clsActiviteWSBLL();

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
        public List<HT_Stock.BOJ.clsActivite> pvgAjouter(List<HT_Stock.BOJ.clsActivite> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsActivites = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
                //--TEST CONTRAINTE
                clsActivites = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsActivite clsActiviteDTO in Objet)
                {
                    Stock.BOJ.clsActivite clsActivite = new Stock.BOJ.clsActivite();
                    clsActivite.AC_CODEACTIVITE = clsActiviteDTO.AC_CODEACTIVITE.ToString();
                    clsActivite.AC_LIBELLE = clsActiviteDTO.AC_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsActiviteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsActiviteDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsActiviteWSBLL.pvgAjouter(clsDonnee, clsActivite, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsActivites.Add(clsActivite);
                }
                else
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsActivites.Add(clsActivite);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsActivites;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsActivite> pvgModifier(List<HT_Stock.BOJ.clsActivite> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsActivites = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
                //--TEST CONTRAINTE
                clsActivites = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsActivite clsActiviteDTO in Objet)
                {
                    Stock.BOJ.clsActivite clsActivite = new Stock.BOJ.clsActivite();
                    clsActivite.AC_CODEACTIVITE = clsActiviteDTO.AC_CODEACTIVITE.ToString();
                    clsActivite.AC_LIBELLE = clsActiviteDTO.AC_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsActiviteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsActiviteDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsActiviteDTO.AC_CODEACTIVITE };
                    clsObjetRetour.SetValue(true, clsActiviteWSBLL.pvgModifier(clsDonnee, clsActivite, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsActivites.Add(clsActivite);
                }
                else
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsActivites.Add(clsActivite);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsActivites;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsActivite> pvgSupprimer(List<HT_Stock.BOJ.clsActivite> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsActivites = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
                //--TEST CONTRAINTE
                clsActivites = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AC_CODEACTIVITE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsActiviteWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsActivites.Add(clsActivite);
                }
                else
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsActivites.Add(clsActivite);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsActivites;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsActivite> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsActivite> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsActivites = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            //    //--TEST CONTRAINTE
            //    clsActivites = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            //}


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsActiviteWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                        clsActivite.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                        clsActivite.AC_LIBELLE = row["AC_LIBELLE"].ToString();
                        clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                        clsActivite.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsActivite.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsActivites.Add(clsActivite);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsActivites.Add(clsActivite);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsActivites;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsActivite> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsActivite> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsActivites = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            //    //--TEST CONTRAINTE
            //    clsActivites = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsActivites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsActivites;
            //}


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsActiviteWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                        clsActivite.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                        clsActivite.AC_LIBELLE = row["AC_LIBELLE"].ToString();
                        clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                        clsActivite.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsActivite.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsActivites.Add(clsActivite);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                    clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsActivite.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsActivites.Add(clsActivite);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsActivite.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsActivites = new List<HT_Stock.BOJ.clsActivite>();
                clsActivites.Add(clsActivite);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsActivites;
        }



    }
}
