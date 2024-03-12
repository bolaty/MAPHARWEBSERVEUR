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

using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjetweb" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjetweb.svc ou wsLogicielobjetweb.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjetweb : IwsLogicielobjetweb
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjetwebWSBLL clsLogicielobjetwebWSBLL = new clsLogicielobjetwebWSBLL();

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
        public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjetwebs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
                //--TEST CONTRAINTE
                clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.OB_CODEOBJET = clsLogicielobjetwebDTO.OB_CODEOBJET.ToString();
                    clsLogicielobjetweb.OB_NOMOBJET = clsLogicielobjetwebDTO.OB_NOMOBJET.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjetwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjetwebDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjetwebWSBLL.pvgAjouter(clsDonnee, clsLogicielobjetweb, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjetwebs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjetwebs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
                //--TEST CONTRAINTE
                clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.OB_CODEOBJET = clsLogicielobjetwebDTO.OB_CODEOBJET.ToString();
                    clsLogicielobjetweb.OB_NOMOBJET = clsLogicielobjetwebDTO.OB_NOMOBJET.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjetwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjetwebDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjetwebDTO.OB_CODEOBJET };
                    clsObjetRetour.SetValue(true, clsLogicielobjetwebWSBLL.pvgModifier(clsDonnee, clsLogicielobjetweb, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjetwebs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjetwebs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
                //--TEST CONTRAINTE
                clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OB_CODEOBJET };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjetwebWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjetwebs;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogicielobjetwebs = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            //    //--TEST CONTRAINTE
            //    clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetwebWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                    clsLogicielobjetweb.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjetweb.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
                    clsLogicielobjetweb.OT_CODETYPEOBJET = row["OT_CODETYPEOBJET"].ToString();
                    clsLogicielobjetweb.LO_CODELOGICIEL = row["LO_CODELOGICIEL"].ToString();
                    clsLogicielobjetweb.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjetweb.LO_CODELOGICIEL = row["LO_CODELOGICIEL"].ToString();
                    clsLogicielobjetweb.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjetweb.OB_STATUT = row["OB_STATUT"].ToString();
                    clsLogicielobjetweb.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();


                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjetwebs;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjetwebs = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
                //--TEST CONTRAINTE
                clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            }
        if(Objet[0].OT_CODETYPEOBJET!="2")
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL };
        else
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OT_CODETYPEOBJET, Objet[0].LO_CODELOGICIEL,"" };
            DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetwebWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                        //OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET
                    clsLogicielobjetweb.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                    clsLogicielobjetweb.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjetweb.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjetwebs;
    }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgChargerDansDataSetPourComboOP(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjetwebs = TestChampObligatoireListe1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
                //--TEST CONTRAINTE
                clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            }



            if(Objet[0].OT_CODETYPEOBJET!="2")
                clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL,Objet[0].OB_CODEOBJET, "" };
            else
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OT_CODETYPEOBJET, Objet[0].LO_CODELOGICIEL, Objet[0].OB_CODEOBJET};

            DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetwebWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                        //OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET
                    clsLogicielobjetweb.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                    clsLogicielobjetweb.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjetweb.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjetwebs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjetweb> pvgChargerDansDataSetPourComboEcrandroit(List<HT_Stock.BOJ.clsLogicielobjetweb> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogicielobjetwebs = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            //    //--TEST CONTRAINTE
            //    clsLogicielobjetwebs = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsLogicielobjetwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjetwebs;
            //}

            //clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjetwebWSBLL.pvgChargerDansDataSetPourComboEcrandroit(clsDonnee, clsObjetEnvoi);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                        //OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET
                    clsLogicielobjetweb.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsLogicielobjetweb.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsLogicielobjetweb.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
                    clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjetwebs;
    }
        
    }
}
