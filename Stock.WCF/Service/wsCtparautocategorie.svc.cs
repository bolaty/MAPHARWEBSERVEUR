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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparautocategorie" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparautocategorie.svc ou wsCtparautocategorie.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparautocategorie : IwsCtparautocategorie
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparautocategorieWSBLL clsCtparautocategorieWSBLL = new clsCtparautocategorieWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparautocategorie> pvgAjouter(List<HT_Stock.BOJ.clsCtparautocategorie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparautocategories = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
                //--TEST CONTRAINTE
                clsCtparautocategories = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorieDTO in Objet)
                {
                    Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.AU_CODECATEGORIE = clsCtparautocategorieDTO.AU_CODECATEGORIE.ToString();
                    clsCtparautocategorie.AU_LIBELLECATEGORIE = clsCtparautocategorieDTO.AU_LIBELLECATEGORIE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparautocategorieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparautocategorieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparautocategorieWSBLL.pvgAjouter(clsDonnee, clsCtparautocategorie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                clsCtparautocategories.Add(clsCtparautocategorie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                clsCtparautocategories.Add(clsCtparautocategorie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparautocategories;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparautocategorie> pvgModifier(List<HT_Stock.BOJ.clsCtparautocategorie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparautocategories = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
                //--TEST CONTRAINTE
                clsCtparautocategories = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorieDTO in Objet)
                {
                    Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.AU_CODECATEGORIE = clsCtparautocategorieDTO.AU_CODECATEGORIE.ToString();
                    clsCtparautocategorie.AU_LIBELLECATEGORIE = clsCtparautocategorieDTO.AU_LIBELLECATEGORIE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparautocategorieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparautocategorieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparautocategorieDTO.AU_CODECATEGORIE };
                    clsObjetRetour.SetValue(true, clsCtparautocategorieWSBLL.pvgModifier(clsDonnee, clsCtparautocategorie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                clsCtparautocategories.Add(clsCtparautocategorie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                clsCtparautocategories.Add(clsCtparautocategorie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparautocategories;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparautocategorie> pvgSupprimer(List<HT_Stock.BOJ.clsCtparautocategorie> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparautocategories = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
                //--TEST CONTRAINTE
                clsCtparautocategories = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AU_CODECATEGORIE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparautocategorieWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                clsCtparautocategories.Add(clsCtparautocategorie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
                clsCtparautocategories.Add(clsCtparautocategorie);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparautocategories;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparautocategorie> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparautocategorie> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparautocategories = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
            //    //--TEST CONTRAINTE
            //    clsCtparautocategories = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparautocategorieWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
                    clsCtparautocategorie.AU_LIBELLECATEGORIE = row["AU_LIBELLECATEGORIE"].ToString();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparautocategories.Add(clsCtparautocategorie);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
            clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            clsCtparautocategories.Add(clsCtparautocategorie);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
            clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            clsCtparautocategories.Add(clsCtparautocategorie);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparautocategories;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparautocategorie> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparautocategorie> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparautocategories = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
        //    //--TEST CONTRAINTE
        //    clsCtparautocategories = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparautocategories[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparautocategories;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparautocategorieWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                    clsCtparautocategorie.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
                    clsCtparautocategorie.AU_LIBELLECATEGORIE = row["AU_LIBELLECATEGORIE"].ToString();
                    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparautocategories.Add(clsCtparautocategorie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparautocategories.Add(clsCtparautocategorie);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
            clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            clsCtparautocategories.Add(clsCtparautocategorie);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
            clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            clsCtparautocategories.Add(clsCtparautocategorie);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparautocategories;
    }


        
    }
}
