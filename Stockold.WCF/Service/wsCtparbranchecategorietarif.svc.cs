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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparbranchecategorietarif" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparbranchecategorietarif.svc ou wsCtparbranchecategorietarif.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparbranchecategorietarif : IwsCtparbranchecategorietarif
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparbranchecategorietarifWSBLL clsCtparbranchecategorietarifWSBLL = new clsCtparbranchecategorietarifWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> pvgAjouter(List<HT_Stock.BOJ.clsCtparbranchecategorietarif> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranchecategorietarifs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
                //--TEST CONTRAINTE
                clsCtparbranchecategorietarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarifDTO in Objet)
                {
                    Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.AU_CODECATEGORIE =int.Parse(clsCtparbranchecategorietarifDTO.AU_CODECATEGORIE.ToString());
                    clsCtparbranchecategorietarif.CB_IDBRANCHE =int.Parse( clsCtparbranchecategorietarifDTO.CB_IDBRANCHE.ToString());
                    clsObjetEnvoi.OE_A = clsCtparbranchecategorietarifDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparbranchecategorietarifDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparbranchecategorietarifWSBLL.pvgAjouter(clsDonnee, clsCtparbranchecategorietarif, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranchecategorietarifs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> pvgModifier(List<HT_Stock.BOJ.clsCtparbranchecategorietarif> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranchecategorietarifs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
                //--TEST CONTRAINTE
                clsCtparbranchecategorietarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarifDTO in Objet)
                {
                    Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.AU_CODECATEGORIE =int.Parse( clsCtparbranchecategorietarifDTO.AU_CODECATEGORIE.ToString());
                    clsCtparbranchecategorietarif.CB_IDBRANCHE = int.Parse(clsCtparbranchecategorietarifDTO.CB_IDBRANCHE.ToString());
                    clsObjetEnvoi.OE_A = clsCtparbranchecategorietarifDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparbranchecategorietarifDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparbranchecategorietarifDTO.AU_CODECATEGORIE };
                    clsObjetRetour.SetValue(true, clsCtparbranchecategorietarifWSBLL.pvgModifier(clsDonnee, clsCtparbranchecategorietarif, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranchecategorietarifs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> pvgSupprimer(List<HT_Stock.BOJ.clsCtparbranchecategorietarif> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranchecategorietarifs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
                //--TEST CONTRAINTE
                clsCtparbranchecategorietarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AU_CODECATEGORIE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparbranchecategorietarifWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranchecategorietarifs;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparbranchecategorietarif> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparbranchecategorietarifs = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
                //--TEST CONTRAINTE
                clsCtparbranchecategorietarifs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
            }

            //"@CB_IDBRANCHE", "@TYPEETAT"
            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].CB_IDBRANCHE,"01" };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparbranchecategorietarifWSBLL.pvgChargerDansDataSetSelonBranche(clsDonnee, clsObjetEnvoi);
            clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
                    clsCtparbranchecategorietarif.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
                    clsCtparbranchecategorietarif.AU_LIBELLECATEGORIE = row["AU_LIBELLECATEGORIE"].ToString();


                    clsCtparbranchecategorietarif.TA_CODETARIF = row["TA_CODETARIF"].ToString();
                    clsCtparbranchecategorietarif.TA_LIBELLETARIF = row["TA_LIBELLETARIF"].ToString();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
            clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
            clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparbranchecategorietarifs;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparbranchecategorietarif> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparbranchecategorietarifs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
        //    //--TEST CONTRAINTE
        //    clsCtparbranchecategorietarifs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparbranchecategorietarifs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparbranchecategorietarifs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparbranchecategorietarifWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                    clsCtparbranchecategorietarif.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
                    clsCtparbranchecategorietarif.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
                    clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
            clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
            clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparbranchecategorietarifs;
    }


        
    }
}
