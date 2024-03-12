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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinitreexpertnomme" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinitreexpertnomme.svc ou wsCtsinitreexpertnomme.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinitreexpertnomme : IwsCtsinitreexpertnomme
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinitreexpertnommeWSBLL clsCtsinitreexpertnommeWSBLL = new clsCtsinitreexpertnommeWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> pvgAjouter(List<HT_Stock.BOJ.clsCtsinitreexpertnomme> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinitreexpertnommes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
                //--TEST CONTRAINTE
                clsCtsinitreexpertnommes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnommeDTO in Objet)
                {
                    Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME = clsCtsinitreexpertnommeDTO.EP_CODEEXPERTNOMME.ToString();
                    clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = clsCtsinitreexpertnommeDTO.EP_DENOMMINATIONEXPERTNOMME.ToString();
                    clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME = clsCtsinitreexpertnommeDTO.EP_CONTACTEXPERTNOMME.ToString();
                    clsCtsinitreexpertnomme.EP_DATESAISIE =DateTime.Parse(clsCtsinitreexpertnommeDTO.EP_DATESAISIE.ToString());
                    clsCtsinitreexpertnomme.OP_CODEOPERATEUR = clsCtsinitreexpertnommeDTO.OP_CODEOPERATEUR.ToString();

                    clsObjetEnvoi.OE_A = clsCtsinitreexpertnommeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinitreexpertnommeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtsinitreexpertnommeWSBLL.pvgAjouter(clsDonnee, clsCtsinitreexpertnomme, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinitreexpertnommes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> pvgModifier(List<HT_Stock.BOJ.clsCtsinitreexpertnomme> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinitreexpertnommes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
                //--TEST CONTRAINTE
                clsCtsinitreexpertnommes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnommeDTO in Objet)
                {
                    Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME = clsCtsinitreexpertnommeDTO.EP_CODEEXPERTNOMME.ToString();
                    clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = clsCtsinitreexpertnommeDTO.EP_DENOMMINATIONEXPERTNOMME.ToString();
                    clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME = clsCtsinitreexpertnommeDTO.EP_CONTACTEXPERTNOMME.ToString();
                    clsCtsinitreexpertnomme.EP_DATESAISIE = DateTime.Parse(clsCtsinitreexpertnommeDTO.EP_DATESAISIE.ToString());
                    clsCtsinitreexpertnomme.OP_CODEOPERATEUR = clsCtsinitreexpertnommeDTO.OP_CODEOPERATEUR.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinitreexpertnommeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinitreexpertnommeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinitreexpertnommeDTO.EP_CODEEXPERTNOMME };
                    clsObjetRetour.SetValue(true, clsCtsinitreexpertnommeWSBLL.pvgModifier(clsDonnee, clsCtsinitreexpertnomme, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinitreexpertnommes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinitreexpertnomme> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinitreexpertnommes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
                //--TEST CONTRAINTE
                clsCtsinitreexpertnommes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].EP_CODEEXPERTNOMME };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinitreexpertnommeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinitreexpertnommes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinitreexpertnomme> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtsinitreexpertnommes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
            //    //--TEST CONTRAINTE
            //    clsCtsinitreexpertnommes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinitreexpertnommeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME = row["EP_CODEEXPERTNOMME"].ToString();
                    clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = row["EP_DENOMMINATIONEXPERTNOMME"].ToString();
                    clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME = row["EP_CONTACTEXPERTNOMME"].ToString();
                    clsCtsinitreexpertnomme.EP_DATESAISIE =DateTime.Parse(row["EP_DATESAISIE"].ToString()).ToShortDateString();
                    clsCtsinitreexpertnomme.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();

                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
            clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
            clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinitreexpertnommes;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinitreexpertnomme> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinitreexpertnommes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
        //    //--TEST CONTRAINTE
        //    clsCtsinitreexpertnommes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinitreexpertnommes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinitreexpertnommes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinitreexpertnommeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                    clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME = row["EP_CODEEXPERTNOMME"].ToString();
                    clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = row["EP_DENOMMINATIONEXPERTNOMME"].ToString();
                    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
            clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
            clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinitreexpertnommes;
    }


        
    }
}
