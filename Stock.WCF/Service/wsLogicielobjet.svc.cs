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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjet" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjet.svc ou wsLogicielobjet.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjet : IwsLogicielobjet
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjetWSBLL clsLogicielobjetWSBLL = new clsLogicielobjetWSBLL();

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
        public List<HT_Stock.BOJ.clsLogicielobjet> pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjets = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
                //--TEST CONTRAINTE
                clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjet clsLogicielobjetDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjet clsLogicielobjet = new Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.OB_CODEOBJET = clsLogicielobjetDTO.OB_CODEOBJET.ToString();
                    clsLogicielobjet.OB_NOMOBJET = clsLogicielobjetDTO.OB_NOMOBJET.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjetDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjetDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjetWSBLL.pvgAjouter(clsDonnee, clsLogicielobjet, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                clsLogicielobjets.Add(clsLogicielobjet);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                clsLogicielobjets.Add(clsLogicielobjet);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjets;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjet> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjets = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
                //--TEST CONTRAINTE
                clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjet clsLogicielobjetDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjet clsLogicielobjet = new Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.OB_CODEOBJET = clsLogicielobjetDTO.OB_CODEOBJET.ToString();
                    clsLogicielobjet.OB_NOMOBJET = clsLogicielobjetDTO.OB_NOMOBJET.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjetDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjetDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjetDTO.OB_CODEOBJET };
                    clsObjetRetour.SetValue(true, clsLogicielobjetWSBLL.pvgModifier(clsDonnee, clsLogicielobjet, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                clsLogicielobjets.Add(clsLogicielobjet);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                clsLogicielobjets.Add(clsLogicielobjet);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjets;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjet> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjets = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
                //--TEST CONTRAINTE
                clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OB_CODEOBJET };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjetWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                clsLogicielobjets.Add(clsLogicielobjet);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
                clsLogicielobjets.Add(clsLogicielobjet);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjets;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsLogicielobjet> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogicielobjets = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            //    //--TEST CONTRAINTE
            //    clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                    clsLogicielobjet.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjet.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
                    clsLogicielobjet.OT_CODETYPEOBJET = row["OT_CODETYPEOBJET"].ToString();
                    clsLogicielobjet.LO_CODELOGICIEL = row["LO_CODELOGICIEL"].ToString();
                    clsLogicielobjet.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjet.LO_CODELOGICIEL = row["LO_CODELOGICIEL"].ToString();
                    clsLogicielobjet.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjet.OB_STATUT = row["OB_STATUT"].ToString();
                    clsLogicielobjet.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();


                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjets.Add(clsLogicielobjet);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjets;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjet> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjets = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
                //--TEST CONTRAINTE
                clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            }
        if(Objet[0].OT_CODETYPEOBJET!="2")
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL };
        else
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OT_CODETYPEOBJET, Objet[0].LO_CODELOGICIEL,"" };
            DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                        //OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET
                    clsLogicielobjet.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                    clsLogicielobjet.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjet.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjets.Add(clsLogicielobjet);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjets;
    }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjet> pvgChargerDansDataSetPourComboOP(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjets = TestChampObligatoireListe1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
                //--TEST CONTRAINTE
                clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            }

            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL,Objet[0].OB_CODEOBJET, "" };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                        //OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET
                    clsLogicielobjet.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                    clsLogicielobjet.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjet.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjets.Add(clsLogicielobjet);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjets;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjet> pvgChargerDansDataSetPourComboEcrandroit(List<HT_Stock.BOJ.clsLogicielobjet> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogicielobjets = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            //    //--TEST CONTRAINTE
            //    clsLogicielobjets = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjets[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjets;
            //}

            //clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetWSBLL.pvgChargerDansDataSetPourComboEcrandroit(clsDonnee, clsObjetEnvoi);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                        //OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET
                    clsLogicielobjet.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjet.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjet.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
                    clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjet.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjets.Add(clsLogicielobjet);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjets.Add(clsLogicielobjet);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            clsLogicielobjets.Add(clsLogicielobjet);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjets;
    }
        
    }
}
