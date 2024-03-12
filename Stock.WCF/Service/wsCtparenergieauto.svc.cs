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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparenergieauto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparenergieauto.svc ou wsCtparenergieauto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparenergieauto : IwsCtparenergieauto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparenergieautoWSBLL clsCtparenergieautoWSBLL = new clsCtparenergieautoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparenergieauto> pvgAjouter(List<HT_Stock.BOJ.clsCtparenergieauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparenergieautos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
                //--TEST CONTRAINTE
                clsCtparenergieautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieautoDTO in Objet)
                {
                    Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.EN_CODEENERGIE = clsCtparenergieautoDTO.EN_CODEENERGIE.ToString();
                    clsCtparenergieauto.EN_LIBELLEENERGIE = clsCtparenergieautoDTO.EN_LIBELLEENERGIE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparenergieautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparenergieautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparenergieautoWSBLL.pvgAjouter(clsDonnee, clsCtparenergieauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparenergieautos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparenergieauto> pvgModifier(List<HT_Stock.BOJ.clsCtparenergieauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparenergieautos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
                //--TEST CONTRAINTE
                clsCtparenergieautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieautoDTO in Objet)
                {
                    Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.EN_CODEENERGIE = clsCtparenergieautoDTO.EN_CODEENERGIE.ToString();
                    clsCtparenergieauto.EN_LIBELLEENERGIE = clsCtparenergieautoDTO.EN_LIBELLEENERGIE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparenergieautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparenergieautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparenergieautoDTO.EN_CODEENERGIE };
                    clsObjetRetour.SetValue(true, clsCtparenergieautoWSBLL.pvgModifier(clsDonnee, clsCtparenergieauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparenergieautos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparenergieauto> pvgSupprimer(List<HT_Stock.BOJ.clsCtparenergieauto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparenergieautos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
                //--TEST CONTRAINTE
                clsCtparenergieautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].EN_CODEENERGIE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparenergieautoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparenergieautos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparenergieauto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparenergieauto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparenergieautos = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
            //    //--TEST CONTRAINTE
            //    clsCtparenergieautos = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparenergieautoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.EN_CODEENERGIE = row["EN_CODEENERGIE"].ToString();
                    clsCtparenergieauto.EN_LIBELLEENERGIE = row["EN_LIBELLEENERGIE"].ToString();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            clsCtparenergieautos.Add(clsCtparenergieauto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            clsCtparenergieautos.Add(clsCtparenergieauto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparenergieautos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparenergieauto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparenergieauto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparenergieautos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
        //    //--TEST CONTRAINTE
        //    clsCtparenergieautos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparenergieautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparenergieautos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparenergieautoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                    clsCtparenergieauto.EN_CODEENERGIE = row["EN_CODEENERGIE"].ToString();
                    clsCtparenergieauto.EN_LIBELLEENERGIE = row["EN_LIBELLEENERGIE"].ToString();
                    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparenergieautos.Add(clsCtparenergieauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparenergieautos.Add(clsCtparenergieauto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            clsCtparenergieautos.Add(clsCtparenergieauto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            clsCtparenergieautos.Add(clsCtparenergieauto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparenergieautos;
    }


        
    }
}
