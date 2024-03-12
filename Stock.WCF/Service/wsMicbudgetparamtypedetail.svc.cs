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

using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsMicbudgetparamtypedetail" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsMicbudgetparamtypedetail.svc ou wsMicbudgetparamtypedetail.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsMicbudgetparamtypedetail : IwsMicbudgetparamtypedetail
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsMicbudgetparamtypedetailWSBLL clsMicbudgetparamtypedetailWSBLL = new clsMicbudgetparamtypedetailWSBLL();

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
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> pvgAjouter(List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypedetails = TestChampObligatoireInsert1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypedetails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetailDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET = clsMicbudgetparamtypedetailDTO.BT_CODETYPEBUDGET.ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = clsMicbudgetparamtypedetailDTO.BD_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparamtypedetailDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparamtypedetailDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsMicbudgetparamtypedetailWSBLL.pvgAjouter(clsDonnee, clsMicbudgetparamtypedetail, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypedetails;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> pvgModifier(List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypedetails = TestChampObligatoireUpdate1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypedetails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetailDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET = clsMicbudgetparamtypedetailDTO.BT_CODETYPEBUDGET.ToString();
                    clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL = clsMicbudgetparamtypedetailDTO.BD_CODETYPEBUDGETDETAIL.ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = clsMicbudgetparamtypedetailDTO.BD_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparamtypedetailDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparamtypedetailDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsMicbudgetparamtypedetailDTO.BD_CODETYPEBUDGETDETAIL };
                    clsObjetRetour.SetValue(true, clsMicbudgetparamtypedetailWSBLL.pvgModifier(clsDonnee, clsMicbudgetparamtypedetail, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypedetails;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> pvgSupprimer(List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypedetails = TestChampObligatoireDelete1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypedetails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BT_CODETYPEBUDGET, Objet[0].BD_CODETYPEBUDGETDETAIL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsMicbudgetparamtypedetailWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypedetails;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypedetails = TestChampObligatoireListe1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypedetails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].BT_CODETYPEBUDGET, Objet[0].BD_CODETYPEBUDGETDETAIL, Objet[0].BD_LIBELLE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparamtypedetailWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL = row["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = row["BD_LIBELLE"].ToString();
                    clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtypedetail.BT_LIBELLE = row["BT_LIBELLE"].ToString();

                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypedetails;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsMicbudgetparamtypedetails = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
        //    //--TEST CONTRAINTE
        //    clsMicbudgetparamtypedetails = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsMicbudgetparamtypedetails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypedetails;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparamtypedetailWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL = row["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = row["BD_LIBELLE"].ToString();
                    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsMicbudgetparamtypedetails;
    }


        
    }
}
