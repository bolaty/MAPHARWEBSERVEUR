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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparusageauto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparusageauto.svc ou wsCtparusageauto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparusageauto : IwsCtparusageauto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparusageautoWSBLL clsCtparusageautoWSBLL = new clsCtparusageautoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparusageauto> pvgAjouter(List<HT_Stock.BOJ.clsCtparusageauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparusageautos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
                //--TEST CONTRAINTE
                clsCtparusageautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparusageauto clsCtparusageautoDTO in Objet)
                {
                    Stock.BOJ.clsCtparusageauto clsCtparusageauto = new Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.US_CODEUSAGE = clsCtparusageautoDTO.US_CODEUSAGE.ToString();
                    clsCtparusageauto.US_LIBELLEUSAGE = clsCtparusageautoDTO.US_LIBELLEUSAGE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparusageautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparusageautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparusageautoWSBLL.pvgAjouter(clsDonnee, clsCtparusageauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                clsCtparusageautos.Add(clsCtparusageauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                clsCtparusageautos.Add(clsCtparusageauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparusageautos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparusageauto> pvgModifier(List<HT_Stock.BOJ.clsCtparusageauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparusageautos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
                //--TEST CONTRAINTE
                clsCtparusageautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparusageauto clsCtparusageautoDTO in Objet)
                {
                    Stock.BOJ.clsCtparusageauto clsCtparusageauto = new Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.US_CODEUSAGE = clsCtparusageautoDTO.US_CODEUSAGE.ToString();
                    clsCtparusageauto.US_LIBELLEUSAGE = clsCtparusageautoDTO.US_LIBELLEUSAGE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparusageautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparusageautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparusageautoDTO.US_CODEUSAGE };
                    clsObjetRetour.SetValue(true, clsCtparusageautoWSBLL.pvgModifier(clsDonnee, clsCtparusageauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                clsCtparusageautos.Add(clsCtparusageauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                clsCtparusageautos.Add(clsCtparusageauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparusageautos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparusageauto> pvgSupprimer(List<HT_Stock.BOJ.clsCtparusageauto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparusageautos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
                //--TEST CONTRAINTE
                clsCtparusageautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].US_CODEUSAGE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparusageautoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                clsCtparusageautos.Add(clsCtparusageauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
                clsCtparusageautos.Add(clsCtparusageauto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparusageautos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparusageauto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparusageauto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparusageautos = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
            //    //--TEST CONTRAINTE
            //    clsCtparusageautos = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparusageautoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.US_CODEUSAGE = row["US_CODEUSAGE"].ToString();
                    clsCtparusageauto.US_LIBELLEUSAGE = row["US_LIBELLEUSAGE"].ToString();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparusageautos.Add(clsCtparusageauto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            clsCtparusageautos.Add(clsCtparusageauto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            clsCtparusageautos.Add(clsCtparusageauto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparusageautos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparusageauto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparusageauto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparusageautos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
        //    //--TEST CONTRAINTE
        //    clsCtparusageautos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparusageautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparusageautos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparusageautoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                    clsCtparusageauto.US_CODEUSAGE = row["US_CODEUSAGE"].ToString();
                    clsCtparusageauto.US_LIBELLEUSAGE = row["US_LIBELLEUSAGE"].ToString();
                    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparusageauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparusageautos.Add(clsCtparusageauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparusageautos.Add(clsCtparusageauto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            clsCtparusageautos.Add(clsCtparusageauto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            clsCtparusageautos.Add(clsCtparusageauto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparusageautos;
    }


        
    }
}
