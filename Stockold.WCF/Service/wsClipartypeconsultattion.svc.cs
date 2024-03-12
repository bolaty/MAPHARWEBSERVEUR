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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsClipartypeconsultattion" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsClipartypeconsultattion.svc ou wsClipartypeconsultattion.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsClipartypeconsultattion : IwsClipartypeconsultattion
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsClipartypeconsultattionWSBLL clsClipartypeconsultattionWSBLL = new clsClipartypeconsultattionWSBLL();

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
        public List<HT_Stock.BOJ.clsClipartypeconsultattion> pvgAjouter(List<HT_Stock.BOJ.clsClipartypeconsultattion> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsClipartypeconsultattions = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
                //--TEST CONTRAINTE
                clsClipartypeconsultattions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattionDTO in Objet)
                {
                    Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.TY_CODETYPECONSULTATION = clsClipartypeconsultattionDTO.TY_CODETYPECONSULTATION.ToString();
                    clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = clsClipartypeconsultattionDTO.TY_LIBELLETYPECONSULTATION.ToString();
                    clsObjetEnvoi.OE_A = clsClipartypeconsultattionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsClipartypeconsultattionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsClipartypeconsultattionWSBLL.pvgAjouter(clsDonnee, clsClipartypeconsultattion, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }
                else
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartypeconsultattions;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsClipartypeconsultattion> pvgModifier(List<HT_Stock.BOJ.clsClipartypeconsultattion> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsClipartypeconsultattions = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
                //--TEST CONTRAINTE
                clsClipartypeconsultattions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattionDTO in Objet)
                {
                    Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.TY_CODETYPECONSULTATION = clsClipartypeconsultattionDTO.TY_CODETYPECONSULTATION.ToString();
                    clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = clsClipartypeconsultattionDTO.TY_LIBELLETYPECONSULTATION.ToString();
                    clsObjetEnvoi.OE_A = clsClipartypeconsultattionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsClipartypeconsultattionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsClipartypeconsultattionDTO.TY_CODETYPECONSULTATION };
                    clsObjetRetour.SetValue(true, clsClipartypeconsultattionWSBLL.pvgModifier(clsDonnee, clsClipartypeconsultattion, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }
                else
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartypeconsultattions;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsClipartypeconsultattion> pvgSupprimer(List<HT_Stock.BOJ.clsClipartypeconsultattion> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsClipartypeconsultattions = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
                //--TEST CONTRAINTE
                clsClipartypeconsultattions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TY_CODETYPECONSULTATION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsClipartypeconsultattionWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }
                else
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartypeconsultattions;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsClipartypeconsultattion> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsClipartypeconsultattion> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsClipartypeconsultattions = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
            //    //--TEST CONTRAINTE
            //    clsClipartypeconsultattions = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsClipartypeconsultattionWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.TY_CODETYPECONSULTATION = row["TY_CODETYPECONSULTATION"].ToString();
                    clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = row["TY_LIBELLETYPECONSULTATION"].ToString();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }
            }
            else
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsClipartypeconsultattions;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsClipartypeconsultattion> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsClipartypeconsultattion> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsClipartypeconsultattions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
        //    //--TEST CONTRAINTE
        //    clsClipartypeconsultattions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClipartypeconsultattions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypeconsultattions;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsClipartypeconsultattionWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                    clsClipartypeconsultattion.TY_CODETYPECONSULTATION = row["TY_CODETYPECONSULTATION"].ToString();
                    clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = row["TY_LIBELLETYPECONSULTATION"].ToString();
                    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                }
            }
            else
            {
                HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsClipartypeconsultattions;
    }


        
    }
}
