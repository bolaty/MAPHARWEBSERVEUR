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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhaparcasutilisationtiers" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhaparcasutilisationtiers.svc ou wsPhaparcasutilisationtiers.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhaparcasutilisationtiers : IwsPhaparcasutilisationtiers
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparcasutilisationtiersWSBLL clsPhaparcasutilisationtiersWSBLL = new clsPhaparcasutilisationtiersWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> pvgAjouter(List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparcasutilisationtierss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
                //--TEST CONTRAINTE
                clsPhaparcasutilisationtierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiersDTO in Objet)
                {
                    Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.CU_CODECASUTILISATION = clsPhaparcasutilisationtiersDTO.CU_CODECASUTILISATION.ToString();
                    clsPhaparcasutilisationtiers.CU_LIBELLE = clsPhaparcasutilisationtiersDTO.CU_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparcasutilisationtiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparcasutilisationtiersDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhaparcasutilisationtiersWSBLL.pvgAjouter(clsDonnee, clsPhaparcasutilisationtiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparcasutilisationtierss;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> pvgModifier(List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparcasutilisationtierss = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
                //--TEST CONTRAINTE
                clsPhaparcasutilisationtierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiersDTO in Objet)
                {
                    Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.CU_CODECASUTILISATION = clsPhaparcasutilisationtiersDTO.CU_CODECASUTILISATION.ToString();
                    clsPhaparcasutilisationtiers.CU_LIBELLE = clsPhaparcasutilisationtiersDTO.CU_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparcasutilisationtiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparcasutilisationtiersDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhaparcasutilisationtiersDTO.CU_CODECASUTILISATION };
                    clsObjetRetour.SetValue(true, clsPhaparcasutilisationtiersWSBLL.pvgModifier(clsDonnee, clsPhaparcasutilisationtiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparcasutilisationtierss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> pvgSupprimer(List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparcasutilisationtierss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
                //--TEST CONTRAINTE
                clsPhaparcasutilisationtierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CU_CODECASUTILISATION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhaparcasutilisationtiersWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparcasutilisationtierss;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhaparcasutilisationtierss = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
            //    //--TEST CONTRAINTE
            //    clsPhaparcasutilisationtierss = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparcasutilisationtiersWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.CU_CODECASUTILISATION = row["CU_CODECASUTILISATION"].ToString();
                    clsPhaparcasutilisationtiers.CU_LIBELLE = row["CU_LIBELLE"].ToString();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
            clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
            clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparcasutilisationtierss;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhaparcasutilisationtierss = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
        //    //--TEST CONTRAINTE
        //    clsPhaparcasutilisationtierss = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparcasutilisationtierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparcasutilisationtierss;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparcasutilisationtiersWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                    clsPhaparcasutilisationtiers.CU_CODECASUTILISATION = row["CU_CODECASUTILISATION"].ToString();
                    clsPhaparcasutilisationtiers.CU_LIBELLE = row["CU_LIBELLE"].ToString();
                    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
            clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
            clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparcasutilisationtierss;
    }


        
    }
}
