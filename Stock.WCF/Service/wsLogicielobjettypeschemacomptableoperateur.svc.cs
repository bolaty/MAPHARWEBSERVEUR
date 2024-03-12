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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjettypeschemacomptableoperateur" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjettypeschemacomptableoperateur.svc ou wsLogicielobjettypeschemacomptableoperateur.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjettypeschemacomptableoperateur : IwsLogicielobjettypeschemacomptableoperateur
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjettypeschemacomptableoperateurWSBLL clsLogicielobjettypeschemacomptableoperateurWSBLL = new clsLogicielobjettypeschemacomptableoperateurWSBLL();

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
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateurDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.OP_CODEOPERATEUR = clsLogicielobjettypeschemacomptableoperateurDTO.OP_CODEOPERATEUR.ToString();
                    clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateurDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgAjouter(clsDonnee, clsLogicielobjettypeschemacomptableoperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableoperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgAjouterdroit(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurAjout=new List<BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                List<Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurSuppression = new List<BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateurDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();

                    clsLogicielobjettypeschemacomptableoperateur.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableoperateurDTO.AG_CODEAGENCE;
                    clsLogicielobjettypeschemacomptableoperateur.OP_CODEOPERATEUR = clsLogicielobjettypeschemacomptableoperateurDTO.OP_CODEOPERATEUR;
                    clsLogicielobjettypeschemacomptableoperateur.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableoperateurDTO.NO_CODENATUREOPERATION;
                    clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateurDTO.FO_CODEFAMILLEOPERATION;
                    clsLogicielobjettypeschemacomptableoperateur.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateurDTO.NF_CODENATUREFAMILLEOPERATION;

                    clsLogicielobjettypeschemacomptableoperateur.LB_ACTIF = "O"; //vppGrille.GetDataRow(vppIndex)["TC_CODETYPETIERS"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.COCHER = clsLogicielobjettypeschemacomptableoperateurDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] {clsLogicielobjettypeschemacomptableoperateurDTO.AG_CODEAGENCE, clsLogicielobjettypeschemacomptableoperateurDTO.OP_CODEOPERATEUR, clsLogicielobjettypeschemacomptableoperateurDTO.NF_CODENATUREFAMILLEOPERATION, clsLogicielobjettypeschemacomptableoperateurDTO.FO_CODEFAMILLEOPERATION };
                    clsLogicielobjettypeschemacomptableoperateurAjout.Add(clsLogicielobjettypeschemacomptableoperateur);

                }
              
                List<Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurss = new List<BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgAjouterListe(clsDonnee, clsLogicielobjettypeschemacomptableoperateurAjout, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableoperateurs;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateurDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.OP_CODEOPERATEUR = clsLogicielobjettypeschemacomptableoperateurDTO.OP_CODEOPERATEUR.ToString();
                    clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableoperateurDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeschemacomptableoperateurDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgModifier(clsDonnee, clsLogicielobjettypeschemacomptableoperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableoperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableoperateurs;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.COCHER = row["COCHER"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableoperateurs;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgChargerDansDataSetOperateurDroit(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
            //--TEST CONTRAINTE
            clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
        }

           // "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@OP_CODEOPERATEUR"
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE,Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].FO_CODEFAMILLEOPERATION,Objet[0].OP_CODEOPERATEUR };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
        clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_CODERUBRIQUE = row["RS_CODERUBRIQUE"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_SENS = row["RS_SENS"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_PREFIXECOMPTE = row["RS_PREFIXECOMPTE"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_REFPIECE = row["RS_REFPIECE"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableoperateur.COCHER = row["COCHER"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_ABREVIATION = row["RS_ABREVIATION"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_MONTANT = row["RS_MONTANT"].ToString();
                //clsLogicielobjettypeschemacomptableoperateur.RS_NUMEROORDRE = row["RS_NUMEROORDRE"].ToString();


                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
        }
        else
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
        clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
        clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeschemacomptableoperateurs;
        }







        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsLogicielobjettypeschemacomptableoperateurs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
        //    //--TEST CONTRAINTE
        //    clsLogicielobjettypeschemacomptableoperateurs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeschemacomptableoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableoperateurs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeschemacomptableoperateurWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                    clsLogicielobjettypeschemacomptableoperateur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeschemacomptableoperateurs;
    }


        
    }
}
