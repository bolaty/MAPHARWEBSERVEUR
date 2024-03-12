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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistresituationdossier" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistresituationdossier.svc ou wsCtsinistresituationdossier.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistresituationdossier : IwsCtsinistresituationdossier
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistresituationdossierWSBLL clsCtsinistresituationdossierWSBLL = new clsCtsinistresituationdossierWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistresituationdossier> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresituationdossiers = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
                //--TEST CONTRAINTE
                clsCtsinistresituationdossiers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SI_CODESINISTRE };
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistresituationdossierWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);


                foreach (HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossierDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.SI_CODESINISTRE = clsCtsinistresituationdossierDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = clsCtsinistresituationdossierDTO.SD_CODESITUATIONDOSSIER.ToString();
                    clsCtsinistresituationdossier.SI_DATESAISIE =DateTime.Parse( clsCtsinistresituationdossierDTO.SI_DATESAISIE.ToString());
                    clsCtsinistresituationdossier.OP_CODEOPERATEUR = clsCtsinistresituationdossierDTO.OP_CODEOPERATEUR.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistresituationdossierDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistresituationdossierDTO.clsObjetEnvoi.OE_Y;

                    if(clsCtsinistresituationdossierDTO.COCHER.ToString()=="O")
                    clsObjetRetour.SetValue(true, clsCtsinistresituationdossierWSBLL.pvgAjouter(clsDonnee, clsCtsinistresituationdossier, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresituationdossiers;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> pvgModifier(List<HT_Stock.BOJ.clsCtsinistresituationdossier> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresituationdossiers = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
                //--TEST CONTRAINTE
                clsCtsinistresituationdossiers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossierDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.SI_CODESINISTRE = clsCtsinistresituationdossierDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = clsCtsinistresituationdossierDTO.SD_CODESITUATIONDOSSIER.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistresituationdossierDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistresituationdossierDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistresituationdossierDTO.SI_CODESINISTRE };
                    clsObjetRetour.SetValue(true, clsCtsinistresituationdossierWSBLL.pvgModifier(clsDonnee, clsCtsinistresituationdossier, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresituationdossiers;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistresituationdossier> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresituationdossiers = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
                //--TEST CONTRAINTE
                clsCtsinistresituationdossiers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SI_CODESINISTRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistresituationdossierWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresituationdossiers;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinistresituationdossier> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistresituationdossier> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresituationdossiers = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
                //--TEST CONTRAINTE
                clsCtsinistresituationdossiers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].SI_CODESINISTRE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistresituationdossierWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = row["SD_CODESITUATIONDOSSIER"].ToString();
                    clsCtsinistresituationdossier.SD_LIBELLESITUATIONDOSSIER = row["SD_LIBELLESITUATIONDOSSIER"].ToString();
                    if (row["SI_DATESAISIE"].ToString()!="")
                    clsCtsinistresituationdossier.SI_DATESAISIE =DateTime.Parse( row["SI_DATESAISIE"].ToString()).ToShortDateString().Replace("/","-");
                    clsCtsinistresituationdossier.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        if (row["COCHER"].ToString() != "O")
                            clsCtsinistresituationdossier.SI_DATESAISIE = "";


                    clsCtsinistresituationdossier.COCHER = row["COCHER"].ToString();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresituationdossiers;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistresituationdossier> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinistresituationdossiers = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
        //    //--TEST CONTRAINTE
        //    clsCtsinistresituationdossiers = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistresituationdossiers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresituationdossiers;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistresituationdossierWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                    clsCtsinistresituationdossier.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = row["SD_CODESITUATIONDOSSIER"].ToString();
                    clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistresituationdossiers;
    }


        
    }
}
