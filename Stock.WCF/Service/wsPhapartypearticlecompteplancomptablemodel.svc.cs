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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypearticlecompteplancomptablemodel" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypearticlecompteplancomptablemodel.svc ou wsPhapartypearticlecompteplancomptablemodel.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypearticlecompteplancomptablemodel : IwsPhapartypearticlecompteplancomptablemodel
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypearticlecompteplancomptablemodelWSBLL clsPhapartypearticlecompteplancomptablemodelWSBLL = new clsPhapartypearticlecompteplancomptablemodelWSBLL();

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
        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> pvgAjouter(List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticlecompteplancomptablemodels = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
                //--TEST CONTRAINTE
                clsPhapartypearticlecompteplancomptablemodels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodelDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticlecompteplancomptablemodelDTO.CP_CODEOPERATIONLIBELLECPTE.ToString();
                    clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = clsPhapartypearticlecompteplancomptablemodelDTO.TO_CODEOPERATIONPARAMETRE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypearticlecompteplancomptablemodelDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypearticlecompteplancomptablemodelDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhapartypearticlecompteplancomptablemodelWSBLL.pvgAjouter(clsDonnee, clsPhapartypearticlecompteplancomptablemodel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticlecompteplancomptablemodels;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> pvgModifier(List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            List<Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodelss = new List<Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticlecompteplancomptablemodels = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
                //--TEST CONTRAINTE
                clsPhapartypearticlecompteplancomptablemodels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodelDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE = clsPhapartypearticlecompteplancomptablemodelDTO.PL_CODENUMCOMPTE.ToString();
                    clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = clsPhapartypearticlecompteplancomptablemodelDTO.TO_CODEOPERATIONPARAMETRE.ToString();
                    clsPhapartypearticlecompteplancomptablemodel.PL_NUMCOMPTE = clsPhapartypearticlecompteplancomptablemodelDTO.PL_NUMCOMPTE.ToString();
                    clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = clsPhapartypearticlecompteplancomptablemodelDTO.CP_CODEOPERATIONLIBELLECPTE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypearticlecompteplancomptablemodelDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypearticlecompteplancomptablemodelDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhapartypearticlecompteplancomptablemodelDTO.CP_CODEOPERATIONLIBELLECPTE };
                    clsPhapartypearticlecompteplancomptablemodelss.Add(clsPhapartypearticlecompteplancomptablemodel);

                }
                clsObjetRetour.SetValue(true, clsPhapartypearticlecompteplancomptablemodelWSBLL.pvgModifierListe(clsDonnee, clsPhapartypearticlecompteplancomptablemodelss, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticlecompteplancomptablemodels;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> pvgSupprimer(List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticlecompteplancomptablemodels = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
                //--TEST CONTRAINTE
                clsPhapartypearticlecompteplancomptablemodels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].CP_CODEOPERATIONLIBELLECPTE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhapartypearticlecompteplancomptablemodelWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticlecompteplancomptablemodels;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhapartypearticlecompteplancomptablemodels = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
            //    //--TEST CONTRAINTE
            //    clsPhapartypearticlecompteplancomptablemodels = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypearticlecompteplancomptablemodelWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = row["CP_CODEOPERATIONLIBELLECPTE"].ToString();
                    clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = row["TO_CODEOPERATIONPARAMETRE"].ToString();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticlecompteplancomptablemodels;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhapartypearticlecompteplancomptablemodels = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
        //    //--TEST CONTRAINTE
        //    clsPhapartypearticlecompteplancomptablemodels = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypearticlecompteplancomptablemodels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticlecompteplancomptablemodels;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypearticlecompteplancomptablemodelWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                    clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = row["CP_CODEOPERATIONLIBELLECPTE"].ToString();
                    clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = row["TO_CODEOPERATIONPARAMETRE"].ToString();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypearticlecompteplancomptablemodels;
    }


        
    }
}
