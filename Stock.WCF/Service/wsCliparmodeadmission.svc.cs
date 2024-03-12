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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCliparmodeadmission" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCliparmodeadmission.svc ou wsCliparmodeadmission.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCliparmodeadmission : IwsCliparmodeadmission
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCliparmodeadmissionWSBLL clsCliparmodeadmissionWSBLL = new clsCliparmodeadmissionWSBLL();

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
        public List<HT_Stock.BOJ.clsCliparmodeadmission> pvgAjouter(List<HT_Stock.BOJ.clsCliparmodeadmission> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliparmodeadmissions = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
                //--TEST CONTRAINTE
                clsCliparmodeadmissions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmissionDTO in Objet)
                {
                    Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.MD_CODEMODEADMISSION = clsCliparmodeadmissionDTO.MD_CODEMODEADMISSION.ToString();
                    clsCliparmodeadmission.MD_LIBELLEMODEADMISSION = clsCliparmodeadmissionDTO.MD_LIBELLEMODEADMISSION.ToString();
                    clsObjetEnvoi.OE_A = clsCliparmodeadmissionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCliparmodeadmissionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCliparmodeadmissionWSBLL.pvgAjouter(clsDonnee, clsCliparmodeadmission, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }
                else
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodeadmissions;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliparmodeadmission> pvgModifier(List<HT_Stock.BOJ.clsCliparmodeadmission> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliparmodeadmissions = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
                //--TEST CONTRAINTE
                clsCliparmodeadmissions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmissionDTO in Objet)
                {
                    Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.MD_CODEMODEADMISSION = clsCliparmodeadmissionDTO.MD_CODEMODEADMISSION.ToString();
                    clsCliparmodeadmission.MD_LIBELLEMODEADMISSION = clsCliparmodeadmissionDTO.MD_LIBELLEMODEADMISSION.ToString();
                    clsObjetEnvoi.OE_A = clsCliparmodeadmissionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCliparmodeadmissionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCliparmodeadmissionDTO.MD_CODEMODEADMISSION };
                    clsObjetRetour.SetValue(true, clsCliparmodeadmissionWSBLL.pvgModifier(clsDonnee, clsCliparmodeadmission, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }
                else
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodeadmissions;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliparmodeadmission> pvgSupprimer(List<HT_Stock.BOJ.clsCliparmodeadmission> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliparmodeadmissions = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
                //--TEST CONTRAINTE
                clsCliparmodeadmissions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].MD_CODEMODEADMISSION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCliparmodeadmissionWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }
                else
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodeadmissions;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCliparmodeadmission> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCliparmodeadmission> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCliparmodeadmissions = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
            //    //--TEST CONTRAINTE
            //    clsCliparmodeadmissions = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliparmodeadmissionWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.MD_CODEMODEADMISSION = row["MD_CODEMODEADMISSION"].ToString();
                    clsCliparmodeadmission.MD_LIBELLEMODEADMISSION = row["MD_LIBELLEMODEADMISSION"].ToString();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
            clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
            clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodeadmissions;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliparmodeadmission> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCliparmodeadmission> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCliparmodeadmissions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
        //    //--TEST CONTRAINTE
        //    clsCliparmodeadmissions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCliparmodeadmissions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodeadmissions;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliparmodeadmissionWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                    clsCliparmodeadmission.MD_CODEMODEADMISSION = row["MD_CODEMODEADMISSION"].ToString();
                    clsCliparmodeadmission.MD_LIBELLEMODEADMISSION = row["MD_LIBELLEMODEADMISSION"].ToString();
                    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
            clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
            clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCliparmodeadmissions;
    }


        
    }
}
