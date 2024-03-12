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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjettypeoperationoperateur" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjettypeoperationoperateur.svc ou wsLogicielobjettypeoperationoperateur.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjettypeoperationoperateur : IwsLogicielobjettypeoperationoperateur
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjettypeoperationoperateurWSBLL clsLogicielobjettypeoperationoperateurWSBLL = new clsLogicielobjettypeoperationoperateurWSBLL();

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
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeoperationoperateurs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateurDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationoperateurDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationoperateurDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeoperationoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeoperationoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationoperateurWSBLL.pvgAjouter(clsDonnee, clsLogicielobjettypeoperationoperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeoperationoperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgAjouterListe(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeoperationoperateurs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            List<Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurss = new List<BOJ.clsLogicielobjettypeoperationoperateur>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateurDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.AG_CODEAGENCE = clsLogicielobjettypeoperationoperateurDTO.AG_CODEAGENCE;
                    clsLogicielobjettypeoperationoperateur.OP_CODEOPERATEUR = clsLogicielobjettypeoperationoperateurDTO.OP_CODEOPERATEUR;
                    clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationoperateurDTO.FO_CODEFAMILLEOPERATION;
                    clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationoperateurDTO.NF_CODENATUREFAMILLEOPERATION;
                    clsLogicielobjettypeoperationoperateur.LO_ACTIF = "O"; 
                    clsLogicielobjettypeoperationoperateur.COCHER = clsLogicielobjettypeoperationoperateurDTO.COCHER;

                    clsObjetEnvoi.OE_A = clsLogicielobjettypeoperationoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeoperationoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeoperationoperateurDTO.AG_CODEAGENCE, clsLogicielobjettypeoperationoperateurDTO.OP_CODEOPERATEUR, clsLogicielobjettypeoperationoperateurDTO.NF_CODENATUREFAMILLEOPERATION };
                    clsLogicielobjettypeoperationoperateurss.Add(clsLogicielobjettypeoperationoperateur);



                }


                clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationoperateurWSBLL.pvgAjouterListe(clsDonnee, clsLogicielobjettypeoperationoperateurss, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeoperationoperateurs;
        }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeoperationoperateurs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateurDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationoperateurDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationoperateurDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeoperationoperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeoperationoperateurDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeoperationoperateurDTO.FO_CODEFAMILLEOPERATION };
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationoperateurWSBLL.pvgModifier(clsDonnee, clsLogicielobjettypeoperationoperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeoperationoperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeoperationoperateurs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].FO_CODEFAMILLEOPERATION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationoperateurWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeoperationoperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsLogicielobjettypeoperationoperateurs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
        //    //--TEST CONTRAINTE
        //    clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsLogicielobjettypeoperationoperateurWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
        clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION = row["NF_CODENATUREFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
        }
        else
        {
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
        clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
        clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeoperationoperateurs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgChargerDansDataSetOperateurDroit(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeoperationoperateurs = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].NF_CODENATUREFAMILLEOPERATION,Objet[0].OP_CODEOPERATEUR};
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsLogicielobjettypeoperationoperateurWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
        clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeoperationoperateur.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeoperationoperateur.FO_STATUT = row["FO_STATUT"].ToString();
                clsLogicielobjettypeoperationoperateur.COCHER = row["COCHER"].ToString();
                clsLogicielobjettypeoperationoperateur.FO_NUMEROORDRE = row["FO_NUMEROORDRE"].ToString();

                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
        }
        else
        {
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
        clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
        clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeoperationoperateurs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsLogicielobjettypeoperationoperateurs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
        //    //--TEST CONTRAINTE
        //    clsLogicielobjettypeoperationoperateurs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeoperationoperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationoperateurs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeoperationoperateurWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                    clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION = row["NF_CODENATUREFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeoperationoperateurs;
    }


        
    }
}
