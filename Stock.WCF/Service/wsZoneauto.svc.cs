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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsZoneauto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsZoneauto.svc ou wsZoneauto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsZoneauto : IwsZoneauto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsZoneautoWSBLL clsZoneautoWSBLL = new clsZoneautoWSBLL();

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
        public List<HT_Stock.BOJ.clsZoneauto> pvgAjouter(List<HT_Stock.BOJ.clsZoneauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZoneautos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
                //--TEST CONTRAINTE
                clsZoneautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsZoneauto clsZoneautoDTO in Objet)
                {
                    Stock.BOJ.clsZoneauto clsZoneauto = new Stock.BOJ.clsZoneauto();
                    clsZoneauto.ZA_CODEZONEAUTO = clsZoneautoDTO.ZA_CODEZONEAUTO.ToString();
                    clsZoneauto.ZA_NOMZONEAUTO = clsZoneautoDTO.ZA_NOMZONEAUTO.ToString();
                    clsObjetEnvoi.OE_A = clsZoneautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsZoneautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsZoneautoWSBLL.pvgAjouter(clsDonnee, clsZoneauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZoneautos.Add(clsZoneauto);
                }
                else
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZoneautos.Add(clsZoneauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                clsZoneautos.Add(clsZoneauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                clsZoneautos.Add(clsZoneauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZoneautos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZoneauto> pvgModifier(List<HT_Stock.BOJ.clsZoneauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZoneautos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
                //--TEST CONTRAINTE
                clsZoneautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsZoneauto clsZoneautoDTO in Objet)
                {
                    Stock.BOJ.clsZoneauto clsZoneauto = new Stock.BOJ.clsZoneauto();
                    clsZoneauto.ZA_CODEZONEAUTO = clsZoneautoDTO.ZA_CODEZONEAUTO.ToString();
                    clsZoneauto.ZA_NOMZONEAUTO = clsZoneautoDTO.ZA_NOMZONEAUTO.ToString();
                    clsObjetEnvoi.OE_A = clsZoneautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsZoneautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsZoneautoDTO.ZA_CODEZONEAUTO };
                    clsObjetRetour.SetValue(true, clsZoneautoWSBLL.pvgModifier(clsDonnee, clsZoneauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZoneautos.Add(clsZoneauto);
                }
                else
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZoneautos.Add(clsZoneauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                clsZoneautos.Add(clsZoneauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                clsZoneautos.Add(clsZoneauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZoneautos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZoneauto> pvgSupprimer(List<HT_Stock.BOJ.clsZoneauto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsZoneautos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
                //--TEST CONTRAINTE
                clsZoneautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].ZA_CODEZONEAUTO };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsZoneautoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsZoneautos.Add(clsZoneauto);
                }
                else
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsZoneautos.Add(clsZoneauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                clsZoneautos.Add(clsZoneauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
                clsZoneautos.Add(clsZoneauto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsZoneautos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsZoneauto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsZoneauto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsZoneautos = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
            //    //--TEST CONTRAINTE
            //    clsZoneautos = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsZoneautoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
                    clsZoneauto.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsZoneautos.Add(clsZoneauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsZoneautos.Add(clsZoneauto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
            clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZoneauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            clsZoneautos.Add(clsZoneauto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
            clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZoneauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            clsZoneautos.Add(clsZoneauto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsZoneautos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsZoneauto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsZoneauto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsZoneautos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
        //    //--TEST CONTRAINTE
        //    clsZoneautos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsZoneautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsZoneautos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsZoneautoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                    clsZoneauto.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
                    clsZoneauto.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
                    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsZoneauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsZoneautos.Add(clsZoneauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsZoneautos.Add(clsZoneauto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
            clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZoneauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            clsZoneautos.Add(clsZoneauto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
            clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsZoneauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            clsZoneautos.Add(clsZoneauto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsZoneautos;
    }


        
    }
}
