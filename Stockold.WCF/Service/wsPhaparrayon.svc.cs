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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhaparrayon" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhaparrayon.svc ou wsPhaparrayon.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhaparrayon : IwsPhaparrayon
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparrayonWSBLL clsPhaparrayonWSBLL = new clsPhaparrayonWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparrayon> pvgAjouter(List<HT_Stock.BOJ.clsPhaparrayon> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparrayons = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
                //--TEST CONTRAINTE
                clsPhaparrayons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparrayon clsPhaparrayonDTO in Objet)
                {
                    Stock.BOJ.clsPhaparrayon clsPhaparrayon = new Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.RY_CODERAYON = clsPhaparrayonDTO.RY_CODERAYON.ToString();
                    clsPhaparrayon.RY_LIBELLE = clsPhaparrayonDTO.RY_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparrayonDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparrayonDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhaparrayonWSBLL.pvgAjouter(clsDonnee, clsPhaparrayon, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                clsPhaparrayons.Add(clsPhaparrayon);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                clsPhaparrayons.Add(clsPhaparrayon);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparrayons;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparrayon> pvgModifier(List<HT_Stock.BOJ.clsPhaparrayon> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparrayons = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
                //--TEST CONTRAINTE
                clsPhaparrayons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparrayon clsPhaparrayonDTO in Objet)
                {
                    Stock.BOJ.clsPhaparrayon clsPhaparrayon = new Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.RY_CODERAYON = clsPhaparrayonDTO.RY_CODERAYON.ToString();
                    clsPhaparrayon.RY_LIBELLE = clsPhaparrayonDTO.RY_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparrayonDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparrayonDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhaparrayonDTO.RY_CODERAYON };
                    clsObjetRetour.SetValue(true, clsPhaparrayonWSBLL.pvgModifier(clsDonnee, clsPhaparrayon, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                clsPhaparrayons.Add(clsPhaparrayon);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                clsPhaparrayons.Add(clsPhaparrayon);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparrayons;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparrayon> pvgSupprimer(List<HT_Stock.BOJ.clsPhaparrayon> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparrayons = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
                //--TEST CONTRAINTE
                clsPhaparrayons = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].RY_CODERAYON };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhaparrayonWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                clsPhaparrayons.Add(clsPhaparrayon);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
                clsPhaparrayons.Add(clsPhaparrayon);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparrayons;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhaparrayon> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhaparrayon> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhaparrayons = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
            //    //--TEST CONTRAINTE
            //    clsPhaparrayons = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparrayonWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.RY_CODERAYON = row["RY_CODERAYON"].ToString();
                    clsPhaparrayon.RY_LIBELLE = row["RY_LIBELLE"].ToString();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparrayons.Add(clsPhaparrayon);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
            clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            clsPhaparrayons.Add(clsPhaparrayon);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
            clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            clsPhaparrayons.Add(clsPhaparrayon);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparrayons;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparrayon> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhaparrayon> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhaparrayons = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
        //    //--TEST CONTRAINTE
        //    clsPhaparrayons = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparrayons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparrayons;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparrayonWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                    clsPhaparrayon.RY_CODERAYON = row["RY_CODERAYON"].ToString();
                    clsPhaparrayon.RY_LIBELLE = row["RY_LIBELLE"].ToString();
                    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparrayon.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparrayons.Add(clsPhaparrayon);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparrayons.Add(clsPhaparrayon);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
            clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            clsPhaparrayons.Add(clsPhaparrayon);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
            clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            clsPhaparrayons.Add(clsPhaparrayon);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparrayons;
    }


        
    }
}
