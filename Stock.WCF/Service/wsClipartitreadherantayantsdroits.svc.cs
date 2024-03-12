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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsClipartitreadherantayantsdroits" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsClipartitreadherantayantsdroits.svc ou wsClipartitreadherantayantsdroits.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsClipartitreadherantayantsdroits : IwsClipartitreadherantayantsdroits
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsClipartitreadherantayantsdroitsWSBLL clsClipartitreadherantayantsdroitsWSBLL = new clsClipartitreadherantayantsdroitsWSBLL();

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
        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> pvgAjouter(List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsClipartitreadherantayantsdroitss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
                //--TEST CONTRAINTE
                clsClipartitreadherantayantsdroitss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroitsDTO in Objet)
                {
                    Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT = clsClipartitreadherantayantsdroitsDTO.TA_CODETITREAYANTDROIT.ToString();
                    clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = clsClipartitreadherantayantsdroitsDTO.TA_LIBELLETITREAYANTDROIT.ToString();
                    clsObjetEnvoi.OE_A = clsClipartitreadherantayantsdroitsDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsClipartitreadherantayantsdroitsDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsClipartitreadherantayantsdroitsWSBLL.pvgAjouter(clsDonnee, clsClipartitreadherantayantsdroits, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }
                else
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartitreadherantayantsdroitss;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> pvgModifier(List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsClipartitreadherantayantsdroitss = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
                //--TEST CONTRAINTE
                clsClipartitreadherantayantsdroitss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroitsDTO in Objet)
                {
                    Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT = clsClipartitreadherantayantsdroitsDTO.TA_CODETITREAYANTDROIT.ToString();
                    clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = clsClipartitreadherantayantsdroitsDTO.TA_LIBELLETITREAYANTDROIT.ToString();
                    clsObjetEnvoi.OE_A = clsClipartitreadherantayantsdroitsDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsClipartitreadherantayantsdroitsDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsClipartitreadherantayantsdroitsDTO.TA_CODETITREAYANTDROIT };
                    clsObjetRetour.SetValue(true, clsClipartitreadherantayantsdroitsWSBLL.pvgModifier(clsDonnee, clsClipartitreadherantayantsdroits, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }
                else
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartitreadherantayantsdroitss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> pvgSupprimer(List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsClipartitreadherantayantsdroitss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
                //--TEST CONTRAINTE
                clsClipartitreadherantayantsdroitss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TA_CODETITREAYANTDROIT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsClipartitreadherantayantsdroitsWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }
                else
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartitreadherantayantsdroitss;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsClipartitreadherantayantsdroitss = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
            //    //--TEST CONTRAINTE
            //    clsClipartitreadherantayantsdroitss = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsClipartitreadherantayantsdroitsWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT = row["TA_CODETITREAYANTDROIT"].ToString();
                    clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = row["TA_LIBELLETITREAYANTDROIT"].ToString();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }
            }
            else
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartitreadherantayantsdroitss;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsClipartitreadherantayantsdroitss = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
        //    //--TEST CONTRAINTE
        //    clsClipartitreadherantayantsdroitss = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClipartitreadherantayantsdroitss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartitreadherantayantsdroitss;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsClipartitreadherantayantsdroitsWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                    clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT = row["TA_CODETITREAYANTDROIT"].ToString();
                    clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = row["TA_LIBELLETITREAYANTDROIT"].ToString();
                    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                }
            }
            else
            {
                HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsClipartitreadherantayantsdroitss;
    }


        
    }
}
