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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsService.svc ou wsService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsService : IwsService
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsServiceWSBLL clsServiceWSBLL = new clsServiceWSBLL();

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
        public List<HT_Stock.BOJ.clsService> pvgAjouter(List<HT_Stock.BOJ.clsService> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsServices = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
                //--TEST CONTRAINTE
                clsServices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsService clsServiceDTO in Objet)
                {
                    Stock.BOJ.clsService clsService = new Stock.BOJ.clsService();
                    clsService.SR_CODESERVICE = clsServiceDTO.SR_CODESERVICE.ToString();
                    clsService.SR_LIBELLE = clsServiceDTO.SR_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsServiceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsServiceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsServiceWSBLL.pvgAjouter(clsDonnee, clsService, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsServices = new List<HT_Stock.BOJ.clsService>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsService.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsServices.Add(clsService);
                }
                else
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsService.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsServices.Add(clsService);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                clsServices.Add(clsService);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                clsServices.Add(clsService);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsServices;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsService> pvgModifier(List<HT_Stock.BOJ.clsService> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsServices = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
                //--TEST CONTRAINTE
                clsServices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsService clsServiceDTO in Objet)
                {
                    Stock.BOJ.clsService clsService = new Stock.BOJ.clsService();
                    clsService.SR_CODESERVICE = clsServiceDTO.SR_CODESERVICE.ToString();
                    clsService.SR_LIBELLE = clsServiceDTO.SR_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsServiceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsServiceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsServiceDTO.SR_CODESERVICE };
                    clsObjetRetour.SetValue(true, clsServiceWSBLL.pvgModifier(clsDonnee, clsService, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsServices = new List<HT_Stock.BOJ.clsService>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsService.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsServices.Add(clsService);
                }
                else
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsService.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsServices.Add(clsService);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                clsServices.Add(clsService);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                clsServices.Add(clsService);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsServices;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsService> pvgSupprimer(List<HT_Stock.BOJ.clsService> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsServices = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
                //--TEST CONTRAINTE
                clsServices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SR_CODESERVICE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsServiceWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsService.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsServices.Add(clsService);
                }
                else
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsService.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsServices.Add(clsService);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                clsServices.Add(clsService);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsServices = new List<HT_Stock.BOJ.clsService>();
                clsServices.Add(clsService);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsServices;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsService> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsService> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsServices = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
            //    //--TEST CONTRAINTE
            //    clsServices = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsServiceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsServices = new List<HT_Stock.BOJ.clsService>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();
                    clsService.SR_LIBELLE = row["SR_LIBELLE"].ToString();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsService.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsServices.Add(clsService);
                }
            }
            else
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsService.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsServices.Add(clsService);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
            clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsService.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsServices = new List<HT_Stock.BOJ.clsService>();
            clsServices.Add(clsService);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
            clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsService.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsServices = new List<HT_Stock.BOJ.clsService>();
            clsServices.Add(clsService);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsServices;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsService> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsService> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsServices = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
        //    //--TEST CONTRAINTE
        //    clsServices = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsServices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsServices;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsServiceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsServices = new List<HT_Stock.BOJ.clsService>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                    clsService.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();
                    clsService.SR_LIBELLE = row["SR_LIBELLE"].ToString();
                    clsService.clsObjetRetour = new Common.clsObjetRetour();
                    clsService.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsService.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsServices.Add(clsService);
                }
            }
            else
            {
                HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsService.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsServices.Add(clsService);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
            clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsService.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsServices = new List<HT_Stock.BOJ.clsService>();
            clsServices.Add(clsService);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
            clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsService.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsService.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsServices = new List<HT_Stock.BOJ.clsService>();
            clsServices.Add(clsService);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsServices;
    }


        
    }
}
