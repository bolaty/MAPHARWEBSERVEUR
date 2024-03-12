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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsRegimeimposition" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsRegimeimposition.svc ou wsRegimeimposition.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsRegimeimposition : IwsRegimeimposition
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsRegimeimpositionWSBLL clsRegimeimpositionWSBLL = new clsRegimeimpositionWSBLL();

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
        public List<HT_Stock.BOJ.clsRegimeimposition> pvgAjouter(List<HT_Stock.BOJ.clsRegimeimposition> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsRegimeimpositions = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
                //--TEST CONTRAINTE
                clsRegimeimpositions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsRegimeimposition clsRegimeimpositionDTO in Objet)
                {
                    Stock.BOJ.clsRegimeimposition clsRegimeimposition = new Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.RE_CODEREGIMEIMPOSITION = clsRegimeimpositionDTO.RE_CODEREGIMEIMPOSITION.ToString();
                    clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = clsRegimeimpositionDTO.RE_LIBELLEREGIMEIMPOSITION.ToString();
                    clsObjetEnvoi.OE_A = clsRegimeimpositionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsRegimeimpositionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsRegimeimpositionWSBLL.pvgAjouter(clsDonnee, clsRegimeimposition, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }
                else
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                clsRegimeimpositions.Add(clsRegimeimposition);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                clsRegimeimpositions.Add(clsRegimeimposition);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsRegimeimpositions;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsRegimeimposition> pvgModifier(List<HT_Stock.BOJ.clsRegimeimposition> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsRegimeimpositions = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
                //--TEST CONTRAINTE
                clsRegimeimpositions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsRegimeimposition clsRegimeimpositionDTO in Objet)
                {
                    Stock.BOJ.clsRegimeimposition clsRegimeimposition = new Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.RE_CODEREGIMEIMPOSITION = clsRegimeimpositionDTO.RE_CODEREGIMEIMPOSITION.ToString();
                    clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = clsRegimeimpositionDTO.RE_LIBELLEREGIMEIMPOSITION.ToString();
                    clsObjetEnvoi.OE_A = clsRegimeimpositionDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsRegimeimpositionDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsRegimeimpositionDTO.RE_CODEREGIMEIMPOSITION };
                    clsObjetRetour.SetValue(true, clsRegimeimpositionWSBLL.pvgModifier(clsDonnee, clsRegimeimposition, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }
                else
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                clsRegimeimpositions.Add(clsRegimeimposition);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                clsRegimeimpositions.Add(clsRegimeimposition);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsRegimeimpositions;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsRegimeimposition> pvgSupprimer(List<HT_Stock.BOJ.clsRegimeimposition> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsRegimeimpositions = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
                //--TEST CONTRAINTE
                clsRegimeimpositions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].RE_CODEREGIMEIMPOSITION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsRegimeimpositionWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }
                else
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                clsRegimeimpositions.Add(clsRegimeimposition);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
                clsRegimeimpositions.Add(clsRegimeimposition);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsRegimeimpositions;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsRegimeimposition> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsRegimeimposition> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsRegimeimpositions = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
            //    //--TEST CONTRAINTE
            //    clsRegimeimpositions = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsRegimeimpositionWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.RE_CODEREGIMEIMPOSITION = row["RE_CODEREGIMEIMPOSITION"].ToString();
                    clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = row["RE_LIBELLEREGIMEIMPOSITION"].ToString();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }
            }
            else
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsRegimeimpositions.Add(clsRegimeimposition);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
            clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            clsRegimeimpositions.Add(clsRegimeimposition);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
            clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            clsRegimeimpositions.Add(clsRegimeimposition);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsRegimeimpositions;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsRegimeimposition> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsRegimeimposition> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsRegimeimpositions = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
        //    //--TEST CONTRAINTE
        //    clsRegimeimpositions = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsRegimeimpositions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsRegimeimpositions;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsRegimeimpositionWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                    clsRegimeimposition.RE_CODEREGIMEIMPOSITION = row["RE_CODEREGIMEIMPOSITION"].ToString();
                    clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = row["RE_LIBELLEREGIMEIMPOSITION"].ToString();
                    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsRegimeimposition.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsRegimeimpositions.Add(clsRegimeimposition);
                }
            }
            else
            {
                HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsRegimeimpositions.Add(clsRegimeimposition);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
            clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            clsRegimeimpositions.Add(clsRegimeimposition);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
            clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            clsRegimeimpositions.Add(clsRegimeimposition);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsRegimeimpositions;
    }


        
    }
}
