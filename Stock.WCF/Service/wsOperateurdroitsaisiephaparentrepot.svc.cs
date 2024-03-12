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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOperateurdroitsaisiephaparentrepot" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOperateurdroitsaisiephaparentrepot.svc ou wsOperateurdroitsaisiephaparentrepot.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOperateurdroitsaisiephaparentrepot : IwsOperateurdroitsaisiephaparentrepot
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOperateurdroitsaisiephaparentrepotWSBLL clsOperateurdroitsaisiephaparentrepotWSBLL = new clsOperateurdroitsaisiephaparentrepotWSBLL();

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
        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> pvgAjouter(List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitsaisiephaparentrepots = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitsaisiephaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR = clsOperateurdroitsaisiephaparentrepotDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = clsOperateurdroitsaisiephaparentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitsaisiephaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitsaisiephaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsOperateurdroitsaisiephaparentrepotWSBLL.pvgAjouter(clsDonnee, clsOperateurdroitsaisiephaparentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitsaisiephaparentrepots;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> pvgAjouterdroit(List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitsaisiephaparentrepots = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitsaisiephaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepotAjout=new List<BOJ.clsOperateurdroitsaisiephaparentrepot>();
                List<Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepotSuppression = new List<BOJ.clsOperateurdroitsaisiephaparentrepot>();
                foreach (HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = clsOperateurdroitsaisiephaparentrepotDTO.EN_CODEENTREPOT;
                    clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR = clsOperateurdroitsaisiephaparentrepotDTO.OP_CODEOPERATEUR;
                    clsOperateurdroitsaisiephaparentrepot.COCHER = clsOperateurdroitsaisiephaparentrepotDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsOperateurdroitsaisiephaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitsaisiephaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsOperateurdroitsaisiephaparentrepotAjout.Add(clsOperateurdroitsaisiephaparentrepot);

                }


                clsObjetRetour.SetValue(true, clsOperateurdroitsaisiephaparentrepotWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitsaisiephaparentrepotAjout, clsOperateurdroitsaisiephaparentrepotSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitsaisiephaparentrepots;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> pvgModifier(List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitsaisiephaparentrepots = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitsaisiephaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR = clsOperateurdroitsaisiephaparentrepotDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = clsOperateurdroitsaisiephaparentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitsaisiephaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitsaisiephaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurdroitsaisiephaparentrepotDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurdroitsaisiephaparentrepotWSBLL.pvgModifier(clsDonnee, clsOperateurdroitsaisiephaparentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitsaisiephaparentrepots;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> pvgSupprimer(List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitsaisiephaparentrepots = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitsaisiephaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOperateurdroitsaisiephaparentrepotWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitsaisiephaparentrepots;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitsaisiephaparentrepots = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitsaisiephaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitsaisiephaparentrepotWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsOperateurdroitsaisiephaparentrepot.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                    clsOperateurdroitsaisiephaparentrepot.COCHER = row["COCHER"].ToString();
                    clsOperateurdroitsaisiephaparentrepot.MODIFICATION = row["MODIFICATION"].ToString();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitsaisiephaparentrepots;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsOperateurdroitsaisiephaparentrepots = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
        //    //--TEST CONTRAINTE
        //    clsOperateurdroitsaisiephaparentrepots = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitsaisiephaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitsaisiephaparentrepots;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitsaisiephaparentrepotWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                    clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOperateurdroitsaisiephaparentrepots;
    }


        
    }
}
