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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOperateurdroitagence" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOperateurdroitagence.svc ou wsOperateurdroitagence.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOperateurdroitagence : IwsOperateurdroitagence
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOperateurdroitagenceWSBLL clsOperateurdroitagenceWSBLL = new clsOperateurdroitagenceWSBLL();

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
        public List<HT_Stock.BOJ.clsOperateurdroitagence> pvgAjouter(List<HT_Stock.BOJ.clsOperateurdroitagence> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitagences = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
                //--TEST CONTRAINTE
                clsOperateurdroitagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagenceDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.OP_CODEOPERATEUR = clsOperateurdroitagenceDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitagence.AG_CODEAGENCE = clsOperateurdroitagenceDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitagenceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsOperateurdroitagenceWSBLL.pvgAjouter(clsDonnee, clsOperateurdroitagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitagences;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitagence> pvgAjouterdroit(List<HT_Stock.BOJ.clsOperateurdroitagence> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitagences = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
                //--TEST CONTRAINTE
                clsOperateurdroitagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagenceAjout=new List<BOJ.clsOperateurdroitagence>();
                List<Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagenceSuppression = new List<BOJ.clsOperateurdroitagence>();
                foreach (HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagenceDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.AG_CODEAGENCE = clsOperateurdroitagenceDTO.AG_CODEAGENCE;
                    clsOperateurdroitagence.OP_CODEOPERATEUR = clsOperateurdroitagenceDTO.OP_CODEOPERATEUR;
                    clsOperateurdroitagence.COCHER = clsOperateurdroitagenceDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsOperateurdroitagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitagenceDTO.clsObjetEnvoi.OE_Y;
                    clsOperateurdroitagenceAjout.Add(clsOperateurdroitagence);

                }


                clsObjetRetour.SetValue(true, clsOperateurdroitagenceWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitagenceAjout, clsOperateurdroitagenceSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitagences;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitagence> pvgModifier(List<HT_Stock.BOJ.clsOperateurdroitagence> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitagences = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
                //--TEST CONTRAINTE
                clsOperateurdroitagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagenceDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.OP_CODEOPERATEUR = clsOperateurdroitagenceDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitagence.AG_CODEAGENCE = clsOperateurdroitagenceDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitagenceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurdroitagenceDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurdroitagenceWSBLL.pvgModifier(clsDonnee, clsOperateurdroitagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitagences;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitagence> pvgSupprimer(List<HT_Stock.BOJ.clsOperateurdroitagence> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitagences = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
                //--TEST CONTRAINTE
                clsOperateurdroitagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOperateurdroitagenceWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitagences;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOperateurdroitagence> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOperateurdroitagence> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitagences = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
                //--TEST CONTRAINTE
                clsOperateurdroitagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitagenceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsOperateurdroitagence.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                    clsOperateurdroitagence.COCHER = row["COCHER"].ToString();
                    clsOperateurdroitagence.MODIFICATION = row["MODIFICATION"].ToString();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
            clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
            clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitagences;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitagence> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOperateurdroitagence> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsOperateurdroitagences = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
        //    //--TEST CONTRAINTE
        //    clsOperateurdroitagences = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitagences;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitagenceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                    clsOperateurdroitagence.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsOperateurdroitagence.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitagences.Add(clsOperateurdroitagence);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
            clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
            clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOperateurdroitagences;
    }


        
    }
}
