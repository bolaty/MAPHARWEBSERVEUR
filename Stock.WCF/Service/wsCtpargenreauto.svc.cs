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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpargenreauto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpargenreauto.svc ou wsCtpargenreauto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpargenreauto : IwsCtpargenreauto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpargenreautoWSBLL clsCtpargenreautoWSBLL = new clsCtpargenreautoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtpargenreauto> pvgAjouter(List<HT_Stock.BOJ.clsCtpargenreauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargenreautos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
                //--TEST CONTRAINTE
                clsCtpargenreautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreautoDTO in Objet)
                {
                    Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.GE_CODEGENRE = clsCtpargenreautoDTO.GE_CODEGENRE.ToString();
                    clsCtpargenreauto.GE_LIBELLEGENRE = clsCtpargenreautoDTO.GE_LIBELLEGENRE.ToString();
                    clsObjetEnvoi.OE_A = clsCtpargenreautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpargenreautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpargenreautoWSBLL.pvgAjouter(clsDonnee, clsCtpargenreauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargenreautos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpargenreauto> pvgModifier(List<HT_Stock.BOJ.clsCtpargenreauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargenreautos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
                //--TEST CONTRAINTE
                clsCtpargenreautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreautoDTO in Objet)
                {
                    Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.GE_CODEGENRE = clsCtpargenreautoDTO.GE_CODEGENRE.ToString();
                    clsCtpargenreauto.GE_LIBELLEGENRE = clsCtpargenreautoDTO.GE_LIBELLEGENRE.ToString();
                    clsObjetEnvoi.OE_A = clsCtpargenreautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpargenreautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpargenreautoDTO.GE_CODEGENRE };
                    clsObjetRetour.SetValue(true, clsCtpargenreautoWSBLL.pvgModifier(clsDonnee, clsCtpargenreauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargenreautos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpargenreauto> pvgSupprimer(List<HT_Stock.BOJ.clsCtpargenreauto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpargenreautos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
                //--TEST CONTRAINTE
                clsCtpargenreautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].GE_CODEGENRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpargenreautoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargenreautos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtpargenreauto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpargenreauto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtpargenreautos = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
            //    //--TEST CONTRAINTE
            //    clsCtpargenreautos = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpargenreautoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.GE_CODEGENRE = row["GE_CODEGENRE"].ToString();
                    clsCtpargenreauto.GE_LIBELLEGENRE = row["GE_LIBELLEGENRE"].ToString();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
            clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            clsCtpargenreautos.Add(clsCtpargenreauto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
            clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            clsCtpargenreautos.Add(clsCtpargenreauto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpargenreautos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpargenreauto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpargenreauto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtpargenreautos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
        //    //--TEST CONTRAINTE
        //    clsCtpargenreautos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpargenreautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargenreautos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpargenreautoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                    clsCtpargenreauto.GE_CODEGENRE = row["GE_CODEGENRE"].ToString();
                    clsCtpargenreauto.GE_LIBELLEGENRE = row["GE_LIBELLEGENRE"].ToString();
                    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpargenreautos.Add(clsCtpargenreauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpargenreautos.Add(clsCtpargenreauto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
            clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            clsCtpargenreautos.Add(clsCtpargenreauto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
            clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            clsCtpargenreautos.Add(clsCtpargenreauto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpargenreautos;
    }


        
    }
}
