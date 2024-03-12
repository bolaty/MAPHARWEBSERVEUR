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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparquestionnaireliaisondocument" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparquestionnaireliaisondocument.svc ou wsCtparquestionnaireliaisondocument.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparquestionnaireliaisondocument : IwsCtparquestionnaireliaisondocument
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparquestionnaireliaisondocumentWSBLL clsCtparquestionnaireliaisondocumentWSBLL = new clsCtparquestionnaireliaisondocumentWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> pvgAjouter(List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnaireliaisondocuments = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
                //--TEST CONTRAINTE
                clsCtparquestionnaireliaisondocuments = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocumentDTO in Objet)
                {
                    Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT = clsCtparquestionnaireliaisondocumentDTO.DC_CODEDOCUMENT.ToString();
                    clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE =int.Parse( clsCtparquestionnaireliaisondocumentDTO.QE_CODEQUESTIONNAIRE.ToString());
                    clsObjetEnvoi.OE_A = clsCtparquestionnaireliaisondocumentDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparquestionnaireliaisondocumentDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparquestionnaireliaisondocumentWSBLL.pvgAjouter(clsDonnee, clsCtparquestionnaireliaisondocument, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnaireliaisondocuments;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> pvgModifier(List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnaireliaisondocuments = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
                //--TEST CONTRAINTE
                clsCtparquestionnaireliaisondocuments = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocumentDTO in Objet)
                {
                    Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT = clsCtparquestionnaireliaisondocumentDTO.DC_CODEDOCUMENT.ToString();
                    clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE =int.Parse( clsCtparquestionnaireliaisondocumentDTO.QE_CODEQUESTIONNAIRE.ToString());
                    clsObjetEnvoi.OE_A = clsCtparquestionnaireliaisondocumentDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparquestionnaireliaisondocumentDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparquestionnaireliaisondocumentDTO.DC_CODEDOCUMENT };
                    clsObjetRetour.SetValue(true, clsCtparquestionnaireliaisondocumentWSBLL.pvgModifier(clsDonnee, clsCtparquestionnaireliaisondocument, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnaireliaisondocuments;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> pvgSupprimer(List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnaireliaisondocuments = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
                //--TEST CONTRAINTE
                clsCtparquestionnaireliaisondocuments = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].DC_CODEDOCUMENT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparquestionnaireliaisondocumentWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnaireliaisondocuments;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparquestionnaireliaisondocuments = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
                //--TEST CONTRAINTE
                clsCtparquestionnaireliaisondocuments = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].DC_CODEDOCUMENT };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparquestionnaireliaisondocumentWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT = row["DC_CODEDOCUMENT"].ToString();
                    clsCtparquestionnaireliaisondocument.DC_LIBELLEDOCUMENT = row["DC_LIBELLEDOCUMENT"].ToString();
                    clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE = row["QE_CODEQUESTIONNAIRE"].ToString();
                    clsCtparquestionnaireliaisondocument.QE_LIBELLEQUESTIONNAIRE = row["QE_LIBELLEQUESTIONNAIRE"].ToString();
                    clsCtparquestionnaireliaisondocument.CQ_VALEUR1 = row["CQ_VALEUR1"].ToString();
                    clsCtparquestionnaireliaisondocument.CQ_VALEUR2 = row["CQ_VALEUR2"].ToString();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparquestionnaireliaisondocuments;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparquestionnaireliaisondocuments = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
        //    //--TEST CONTRAINTE
        //    clsCtparquestionnaireliaisondocuments = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparquestionnaireliaisondocuments[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparquestionnaireliaisondocuments;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparquestionnaireliaisondocumentWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                    clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT = row["DC_CODEDOCUMENT"].ToString();
                    clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE = row["QE_CODEQUESTIONNAIRE"].ToString();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparquestionnaireliaisondocuments;
    }


        
    }
}
