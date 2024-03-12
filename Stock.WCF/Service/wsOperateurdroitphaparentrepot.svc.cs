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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOperateurdroitphaparentrepot" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOperateurdroitphaparentrepot.svc ou wsOperateurdroitphaparentrepot.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOperateurdroitphaparentrepot : IwsOperateurdroitphaparentrepot
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOperateurdroitphaparentrepotWSBLL clsOperateurdroitphaparentrepotWSBLL = new clsOperateurdroitphaparentrepotWSBLL();

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
        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> pvgAjouter(List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitphaparentrepots = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitphaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR = clsOperateurdroitphaparentrepotDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitphaparentrepot.EN_CODEENTREPOT = clsOperateurdroitphaparentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitphaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitphaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsOperateurdroitphaparentrepotWSBLL.pvgAjouter(clsDonnee, clsOperateurdroitphaparentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitphaparentrepots;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> pvgAjouterdroit(List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitphaparentrepots = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitphaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepotAjout=new List<BOJ.clsOperateurdroitphaparentrepot>();
                List<Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepotSuppression = new List<BOJ.clsOperateurdroitphaparentrepot>();
                foreach (HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.EN_CODEENTREPOT = clsOperateurdroitphaparentrepotDTO.EN_CODEENTREPOT;
                    clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR = clsOperateurdroitphaparentrepotDTO.OP_CODEOPERATEUR;
                    clsOperateurdroitphaparentrepot.COCHER = clsOperateurdroitphaparentrepotDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsOperateurdroitphaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitphaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsOperateurdroitphaparentrepotAjout.Add(clsOperateurdroitphaparentrepot);

                }


                clsObjetRetour.SetValue(true, clsOperateurdroitphaparentrepotWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitphaparentrepotAjout, clsOperateurdroitphaparentrepotSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitphaparentrepots;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> pvgModifier(List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitphaparentrepots = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitphaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepotDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR = clsOperateurdroitphaparentrepotDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitphaparentrepot.EN_CODEENTREPOT = clsOperateurdroitphaparentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitphaparentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitphaparentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurdroitphaparentrepotDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurdroitphaparentrepotWSBLL.pvgModifier(clsDonnee, clsOperateurdroitphaparentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitphaparentrepots;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> pvgSupprimer(List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitphaparentrepots = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitphaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOperateurdroitphaparentrepotWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitphaparentrepots;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitphaparentrepots = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
                //--TEST CONTRAINTE
                clsOperateurdroitphaparentrepots = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitphaparentrepotWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsOperateurdroitphaparentrepot.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                    clsOperateurdroitphaparentrepot.COCHER = row["COCHER"].ToString();
                    clsOperateurdroitphaparentrepot.MODIFICATION = row["MODIFICATION"].ToString();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
            clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
            clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitphaparentrepots;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsOperateurdroitphaparentrepots = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
        //    //--TEST CONTRAINTE
        //    clsOperateurdroitphaparentrepots = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitphaparentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitphaparentrepots;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitphaparentrepotWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                    clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsOperateurdroitphaparentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
            clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
            clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOperateurdroitphaparentrepots;
    }


        
    }
}
