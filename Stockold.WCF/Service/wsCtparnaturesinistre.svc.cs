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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparnaturesinistre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparnaturesinistre.svc ou wsCtparnaturesinistre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparnaturesinistre : IwsCtparnaturesinistre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparnaturesinistreWSBLL clsCtparnaturesinistreWSBLL = new clsCtparnaturesinistreWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparnaturesinistre> pvgAjouter(List<HT_Stock.BOJ.clsCtparnaturesinistre> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparnaturesinistres = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
                //--TEST CONTRAINTE
                clsCtparnaturesinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.NS_CODENATURESINISTRE = clsCtparnaturesinistreDTO.NS_CODENATURESINISTRE.ToString();
                    clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = clsCtparnaturesinistreDTO.NS_LIBELLENATURESINISTRE.ToString();
                    clsCtparnaturesinistre.NS_ACTIF = clsCtparnaturesinistreDTO.NS_ACTIF.ToString();
                    clsObjetEnvoi.OE_A = clsCtparnaturesinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparnaturesinistreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparnaturesinistreWSBLL.pvgAjouter(clsDonnee, clsCtparnaturesinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparnaturesinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparnaturesinistre> pvgModifier(List<HT_Stock.BOJ.clsCtparnaturesinistre> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparnaturesinistres = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
                //--TEST CONTRAINTE
                clsCtparnaturesinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.NS_CODENATURESINISTRE = clsCtparnaturesinistreDTO.NS_CODENATURESINISTRE.ToString();
                    clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = clsCtparnaturesinistreDTO.NS_LIBELLENATURESINISTRE.ToString();
                    clsCtparnaturesinistre.NS_ACTIF = clsCtparnaturesinistreDTO.NS_ACTIF.ToString();
                    clsObjetEnvoi.OE_A = clsCtparnaturesinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparnaturesinistreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparnaturesinistreDTO.NS_CODENATURESINISTRE };
                    clsObjetRetour.SetValue(true, clsCtparnaturesinistreWSBLL.pvgModifier(clsDonnee, clsCtparnaturesinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparnaturesinistres;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparnaturesinistre> pvgSupprimer(List<HT_Stock.BOJ.clsCtparnaturesinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparnaturesinistres = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
                //--TEST CONTRAINTE
                clsCtparnaturesinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NS_CODENATURESINISTRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparnaturesinistreWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparnaturesinistres;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparnaturesinistre> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparnaturesinistre> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparnaturesinistres = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
            //    //--TEST CONTRAINTE
            //    clsCtparnaturesinistres = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparnaturesinistreWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.NS_CODENATURESINISTRE = row["NS_CODENATURESINISTRE"].ToString();
                    clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = row["NS_LIBELLENATURESINISTRE"].ToString();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
            clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
            clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparnaturesinistres;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparnaturesinistre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparnaturesinistre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparnaturesinistres = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
        //    //--TEST CONTRAINTE
        //    clsCtparnaturesinistres = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparnaturesinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparnaturesinistres;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparnaturesinistreWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                    clsCtparnaturesinistre.NS_CODENATURESINISTRE = row["NS_CODENATURESINISTRE"].ToString();
                    clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = row["NS_LIBELLENATURESINISTRE"].ToString();
                    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
            clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
            clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparnaturesinistres;
    }


        
    }
}
