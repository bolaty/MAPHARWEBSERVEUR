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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontratquestionnaire" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontratquestionnaire.svc ou wsCtcontratquestionnaire.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontratquestionnaire : IwsCtcontratquestionnaire
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratquestionnaireWSBLL clsCtcontratquestionnaireWSBLL = new clsCtcontratquestionnaireWSBLL();

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
        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> pvgAjouter(List<HT_Stock.BOJ.clsCtcontratquestionnaire> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratquestionnaires = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
                //--TEST CONTRAINTE
                clsCtcontratquestionnaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CA_CODECONTRAT, Objet[0].DC_CODEDOCUMENT };
                clsObjetRetour.SetValue(true, clsCtcontratquestionnaireWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);

                foreach (HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaireDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.CA_CODECONTRAT = clsCtcontratquestionnaireDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE = clsCtcontratquestionnaireDTO.QE_CODEQUESTIONNAIRE.ToString();
                    clsCtcontratquestionnaire.DC_CODEDOCUMENT = clsCtcontratquestionnaireDTO.DC_CODEDOCUMENT.ToString();
                    clsCtcontratquestionnaire.CQ_VALEUR1 = clsCtcontratquestionnaireDTO.CQ_VALEUR1.ToString();
                    clsCtcontratquestionnaire.CQ_VALEUR2 = clsCtcontratquestionnaireDTO.CQ_VALEUR2.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratquestionnaireDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratquestionnaireDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtcontratquestionnaireWSBLL.pvgAjouter(clsDonnee, clsCtcontratquestionnaire, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratquestionnaires;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> pvgModifier(List<HT_Stock.BOJ.clsCtcontratquestionnaire> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratquestionnaires = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
                //--TEST CONTRAINTE
                clsCtcontratquestionnaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaireDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.CA_CODECONTRAT = clsCtcontratquestionnaireDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE = clsCtcontratquestionnaireDTO.QE_CODEQUESTIONNAIRE.ToString();
                    clsCtcontratquestionnaire.CQ_VALEUR1 = clsCtcontratquestionnaireDTO.CQ_VALEUR1.ToString();
                    clsCtcontratquestionnaire.CQ_VALEUR2 = clsCtcontratquestionnaireDTO.CQ_VALEUR2.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratquestionnaireDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratquestionnaireDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratquestionnaireDTO.CA_CODECONTRAT };
                    clsObjetRetour.SetValue(true, clsCtcontratquestionnaireWSBLL.pvgModifier(clsDonnee, clsCtcontratquestionnaire, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratquestionnaires;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> pvgSupprimer(List<HT_Stock.BOJ.clsCtcontratquestionnaire> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratquestionnaires = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
                //--TEST CONTRAINTE
                clsCtcontratquestionnaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CA_CODECONTRAT, Objet[0].QE_CODEQUESTIONNAIRE};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratquestionnaireWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratquestionnaires;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontratquestionnaire> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontratquestionnaire> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratquestionnaires = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
                //--TEST CONTRAINTE
                clsCtcontratquestionnaires = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].CA_CODECONTRAT, Objet[0].DC_CODEDOCUMENT, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratquestionnaireWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                    clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE = row["QE_CODEQUESTIONNAIRE"].ToString();
                    clsCtcontratquestionnaire.QE_LIBELLEQUESTIONNAIRE = row["QE_LIBELLEQUESTIONNAIRE"].ToString();
                    clsCtcontratquestionnaire.CQ_VALEUR1 = row["CQ_VALEUR1"].ToString();
                    clsCtcontratquestionnaire.CQ_VALEUR2 = row["CQ_VALEUR2"].ToString();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratquestionnaires;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtcontratquestionnaire> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtcontratquestionnaires = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
        //    //--TEST CONTRAINTE
        //    clsCtcontratquestionnaires = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratquestionnaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratquestionnaires;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratquestionnaireWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                    clsCtcontratquestionnaire.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                    clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE = row["QE_CODEQUESTIONNAIRE"].ToString();
                    clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratquestionnaires;
    }


        
    }
}
