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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhamouvementStock" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhamouvementStock.svc ou wsPhamouvementStock.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhamouvementStock : IwsPhamouvementStock
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhamouvementStockWSBLL clsPhamouvementStockWSBLL = new clsPhamouvementStockWSBLL();

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
        public List<HT_Stock.BOJ.clsPhamouvementStock> pvgAjouter(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementStocks = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
                //--TEST CONTRAINTE
                clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStockDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.MS_NUMPIECE = clsPhamouvementStockDTO.MS_NUMPIECE.ToString();
                    clsPhamouvementStock.MS_LIBOPERA = clsPhamouvementStockDTO.MS_LIBOPERA.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementStockDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementStockDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhamouvementStockWSBLL.pvgAjouter(clsDonnee, clsPhamouvementStock, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementStocks;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementStock> pvgModifier(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementStocks = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
                //--TEST CONTRAINTE
                clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStockDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.MS_NUMPIECE = clsPhamouvementStockDTO.MS_NUMPIECE.ToString();
                    clsPhamouvementStock.MS_LIBOPERA = clsPhamouvementStockDTO.MS_LIBOPERA.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementStockDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementStockDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementStockDTO.MS_NUMPIECE };
                    clsObjetRetour.SetValue(true, clsPhamouvementStockWSBLL.pvgModifier(clsDonnee, clsPhamouvementStock, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementStocks;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementStock> pvgSupprimer(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementStocks = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
                //--TEST CONTRAINTE
                clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].MS_NUMPIECE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhamouvementStockWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementStocks;
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementStock> pvgAnnulationFactureMaphar(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementStocks = TestChampObligatoireAnnulerFactureMaphar(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
                //--TEST CONTRAINTE
                clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            }

            Stock.BOJ.clsPhamouvementStock clsPhamouvementStock1 = new Stock.BOJ.clsPhamouvementStock();
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].MS_NUMPIECE };
            clsPhamouvementStock1 = clsPhamouvementStockWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            Objet[0].MS_DATESAISIE = clsPhamouvementStock1.MS_DATEPIECE.ToShortDateString() ;

            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].MS_NUMPIECE , Objet[0].CA_DATESAISIE, Objet[0].MS_DATESAISIE,  Objet[0].TYPEOPERATION, Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhamouvementStockWSBLL.pvgAnnulationApprovisionnementVente(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementStocks;
        }








        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementStock> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhamouvementStocks = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            //    //--TEST CONTRAINTE
            //    clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementStockWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    clsPhamouvementStock.MS_LIBOPERA = row["MS_LIBOPERA"].ToString();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementStocks;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhamouvementStock> pvgInsertIntoDatasetAppro(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementStocks = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
                //--TEST CONTRAINTE
                clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE,Objet[0].MS_NUMPIECE,Objet[0].DATEDEBUT, Objet[0].DATEFIN,Objet[0].TI_NUMTIERS,Objet[0].TI_DENOMINATION,Objet[0].MS_ANNULATIONPIECE,Objet[0].TYPEOPERATION,Objet[0].TP_CODETYPETIERS,Objet[0].OP_CODEOPERATEUR,Objet[0].NT_CODENATURETYPEARTICLE,Objet[0].CO_NUMCOMMERCIAL,Objet[0].CO_NOMPRENOM,Objet[0].NT_CODENATURETIERS,Objet[0].NO_CODENATUREOPERATION,Objet[0].AR_CODEARTICLE1,Objet[0].GP_CODEGROUPE,Objet[0].TYPELISTE,Objet[0].CO_CODECONSULTATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementStockWSBLL.pvgInsertIntoDatasetAppro(clsDonnee, clsObjetEnvoi);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();


                        clsPhamouvementStock.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsPhamouvementStock.MS_NUMPIECE1 = row["MS_NUMPIECE1"].ToString();
                        clsPhamouvementStock.MK_NUMPIECE = row["MK_NUMPIECE"].ToString();
                        clsPhamouvementStock.MS_DATEPIECE = row["MS_DATEPIECE"].ToString();
                        clsPhamouvementStock.MS_NUMSEQUENCE = row["MS_NUMSEQUENCE"].ToString();
                        clsPhamouvementStock.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsPhamouvementStock.MS_REFPIECE = row["MS_REFPIECE"].ToString();
                        clsPhamouvementStock.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                        clsPhamouvementStock.MS_LIBOPERA = row["MS_LIBOPERA"].ToString();
                        clsPhamouvementStock.MONTANTTTCPLUSAIRSI = row["MONTANTTTCPLUSAIRSI"].ToString();
                        clsPhamouvementStock.MS_TAUXREMISE = row["MS_TAUXREMISE"].ToString();
                        clsPhamouvementStock.MS_MONTANTTOTALREMISE = row["MS_MONTANTTOTALREMISE"].ToString();
                        clsPhamouvementStock.MS_MONTANTTRANSPORT = row["MS_MONTANTTRANSPORT"].ToString();
                        clsPhamouvementStock.MS_MONTANTVERSE = row["MS_MONTANTVERSE"].ToString();
                        clsPhamouvementStock.MS_DELAILIVRAISON = row["MS_DELAILIVRAISON"].ToString();





                        clsPhamouvementStock.MS_DATELIVRAISON = row["MS_DATELIVRAISON"].ToString();
                        clsPhamouvementStock.MS_DATEFACTURE = row["MS_DATEFACTURE"].ToString();
                        clsPhamouvementStock.MS_DATECLOTURE = row["MS_DATECLOTURE"].ToString();
                        clsPhamouvementStock.MS_DATESAISIE = row["MS_DATESAISIE"].ToString();
                        clsPhamouvementStock.MS_MONTANTECHEANCE = row["MS_MONTANTECHEANCE"].ToString();
                        clsPhamouvementStock.MS_DATEDEBUTREGLEMENT = row["MS_DATEDEBUTREGLEMENT"].ToString();
                        clsPhamouvementStock.MS_DUREEVALIDITE = row["MS_DUREEVALIDITE"].ToString();
                        clsPhamouvementStock.MS_CONDITIONREGLEMENT = row["MS_CONDITIONREGLEMENT"].ToString();
                        clsPhamouvementStock.MS_SITUATIONFACTURE = row["MS_SITUATIONFACTURE"].ToString();
                        clsPhamouvementStock.MS_TAUXTVA  = row["MS_TAUXTVA"].ToString();
                        clsPhamouvementStock.MS_TAUXASDI = row["MS_TAUXASDI"].ToString();
                        clsPhamouvementStock.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsPhamouvementStock.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsPhamouvementStock.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        clsPhamouvementStock.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsPhamouvementStock.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                        clsPhamouvementStock.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsPhamouvementStock.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                        clsPhamouvementStock.MS_DATERENDEZVOUS = row["MS_DATERENDEZVOUS"].ToString();
                        clsPhamouvementStock.MS_MONTANTVERSE1 = row["MS_MONTANTVERSE1"].ToString();
                        clsPhamouvementStock.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsPhamouvementStock.CO_IDCOMMERCIAL = row["CO_IDCOMMERCIAL"].ToString();
                        clsPhamouvementStock.CO_NUMCOMMERCIAL = row["CO_NUMCOMMERCIAL"].ToString();
                        clsPhamouvementStock.TI_PLAFONDCREDIT = row["TI_PLAFONDCREDIT"].ToString();
                        clsPhamouvementStock.CO_NOMPRENOM = row["CO_NOMPRENOM"].ToString();
                        clsPhamouvementStock.MR_CODEMODEREGLEMENT = row["MR_CODEMODEREGLEMENT"].ToString();
                        clsPhamouvementStock.TI_ASDI = row["TI_ASDI"].ToString();
                        clsPhamouvementStock.TI_TVA = row["TI_TVA"].ToString();
                        clsPhamouvementStock.MS_DATEDEBUTFABRICATION = row["MS_DATEDEBUTFABRICATION"].ToString();
                        clsPhamouvementStock.MS_HEUREDEBUTFABRICATION = row["MS_HEUREDEBUTFABRICATION"].ToString();
                        clsPhamouvementStock.MS_DATEFINFABRICATION = row["MS_DATEFINFABRICATION"].ToString();
                        clsPhamouvementStock.MS_HEUREFINFABRICATION = row["MS_HEUREFINFABRICATION"].ToString();
                        clsPhamouvementStock.MS_DATEDEPART = row["MS_DATEDEPART"].ToString();
                        clsPhamouvementStock.MS_HEUREDEBUT = row["MS_HEUREDEBUT"].ToString();
                        clsPhamouvementStock.MS_HEUREFIN = row["MS_HEUREFIN"].ToString();
                        clsPhamouvementStock.EM_CODEEMBALLAGE = row["EM_CODEEMBALLAGE"].ToString();
                        clsPhamouvementStock.MS_TAUXHUMIDITE = row["MS_TAUXHUMIDITE"].ToString();
                        clsPhamouvementStock.MS_REMARQUE = row["MS_REMARQUE"].ToString();
                        clsPhamouvementStock.TR_IDTRANSPORTEUR = row["TR_IDTRANSPORTEUR"].ToString();
                        clsPhamouvementStock.CH_IDCHAUFFEUR = row["CH_IDCHAUFFEUR"].ToString();
                        clsPhamouvementStock.MS_NUMERIMMATRICULATION = row["MS_NUMERIMMATRICULATION"].ToString();
                        clsPhamouvementStock.NT_CODENATURETYPEARTICLE = row["NT_CODENATURETYPEARTICLE"].ToString();
                        clsPhamouvementStock.COCHER = row["COCHER"].ToString();
                        clsPhamouvementStock.MS_RESTAMONTANTVERSE = row["MS_RESTAMONTANTVERSE"].ToString();
                        clsPhamouvementStock.MS_TAUXASSURANCE = row["MS_TAUXASSURANCE"].ToString();
                        clsPhamouvementStock.MS_MONTANTASSURANCE = row["MS_MONTANTASSURANCE"].ToString();
                        clsPhamouvementStock.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                        clsPhamouvementStock.MS_NUMPIECECALCULAVOIR = row["MS_NUMPIECECALCULAVOIR"].ToString();
                        clsPhamouvementStock.MS_VOSREFERENCES = row["MS_VOSREFERENCES"].ToString();
                        clsPhamouvementStock.SR_MONTANTCREDIT = row["SR_MONTANTCREDIT"].ToString();



                    //    clsPhamouvementStock.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    //clsPhamouvementStock.MS_LIBOPERA = row["MS_LIBOPERA"].ToString();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementStocks;
            }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementStock> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementStock> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhamouvementStocks = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
        //    //--TEST CONTRAINTE
        //    clsPhamouvementStocks = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementStocks;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementStockWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                    clsPhamouvementStock.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    clsPhamouvementStock.MS_LIBOPERA = row["MS_LIBOPERA"].ToString();
                    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            clsPhamouvementStocks.Add(clsPhamouvementStock);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            clsPhamouvementStocks.Add(clsPhamouvementStock);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementStocks;
    }


        
    }
}
