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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhaparentrepot" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhaparentrepot.svc ou wsPhaparentrepot.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhaparentrepot : IwsPhaparentrepot
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparentrepotWSBLL clsPhaparentrepotWSBLL = new clsPhaparentrepotWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparentrepot> pvgAjouter(List<HT_Stock.BOJ.clsPhaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparentrepots = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
                //--TEST CONTRAINTE
                clsPhaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.EN_CODEENTREPOT = clsPhaparentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsPhaparentrepot.EN_DENOMINATION = clsPhaparentrepotDTO.EN_DENOMINATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhaparentrepotWSBLL.pvgAjouter(clsDonnee, clsPhaparentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparentrepots;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparentrepot> pvgModifier(List<HT_Stock.BOJ.clsPhaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparentrepots = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
                //--TEST CONTRAINTE
                clsPhaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.EN_CODEENTREPOT = clsPhaparentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsPhaparentrepot.EN_DENOMINATION = clsPhaparentrepotDTO.EN_DENOMINATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhaparentrepotDTO.EN_CODEENTREPOT };
                    clsObjetRetour.SetValue(true, clsPhaparentrepotWSBLL.pvgModifier(clsDonnee, clsPhaparentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparentrepots;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparentrepot> pvgSupprimer(List<HT_Stock.BOJ.clsPhaparentrepot> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparentrepots = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
                //--TEST CONTRAINTE
                clsPhaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].EN_CODEENTREPOT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhaparentrepotWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparentrepots;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhaparentrepot> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhaparentrepot> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhaparentrepots = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            //    //--TEST CONTRAINTE
            //    clsPhaparentrepots = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparentrepotWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsPhaparentrepot.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            clsPhaparentrepots.Add(clsPhaparentrepot);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            clsPhaparentrepots.Add(clsPhaparentrepot);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparentrepots;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparentrepot> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhaparentrepot> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparentrepots = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
                //--TEST CONTRAINTE
                clsPhaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparentrepotWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsPhaparentrepot.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            clsPhaparentrepots.Add(clsPhaparentrepot);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            clsPhaparentrepots.Add(clsPhaparentrepot);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparentrepots;
    }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparentrepot> pvgChargerDansDataSetPourComboEdition(List<HT_Stock.BOJ.clsPhaparentrepot> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparentrepots = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
                //--TEST CONTRAINTE
                clsPhaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparentrepots;
            }

            
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsPhaparentrepotWSBLL.pvgChargerDansDataSetPourComboEdition(clsDonnee, clsObjetEnvoi);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                        clsPhaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsPhaparentrepot.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsPhaparentrepots.Add(clsPhaparentrepot);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                    clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsPhaparentrepots.Add(clsPhaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
                clsPhaparentrepots.Add(clsPhaparentrepot);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparentrepots;
        }

    }
}
