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
using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsSmsout" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsSmsout.svc ou wsSmsout.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsSmsout : IwsSmsout
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();

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
        public List<HT_Stock.BOJ.clsSmsout> pvgAjouter(List<HT_Stock.BOJ.clsSmsout> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsSmsouts = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
                //--TEST CONTRAINTE
                clsSmsouts = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsSmsout clsSmsoutDTO in Objet)
                {
                    Stock.BOJ.clsSmsout clsSmsout = new Stock.BOJ.clsSmsout();
                    clsSmsout.AG_CODEAGENCE = clsSmsoutDTO.AG_CODEAGENCE.ToString();
                    clsSmsout.SM_DATEPIECE = clsSmsoutDTO.SM_DATEPIECE.ToString();

                    clsSmsout.SM_NUMPIECE = clsSmsoutDTO.SM_NUMPIECE.ToString();
                    clsSmsout.SM_NUMSEQUENCE = clsSmsoutDTO.SM_NUMSEQUENCE.ToString();
                    clsSmsout.CO_CODECOMPTE = clsSmsoutDTO.CO_CODECOMPTE.ToString();
                    clsSmsout.SM_MESSAGE = clsSmsoutDTO.SM_MESSAGE.ToString();
                    clsSmsout.SM_TELEPHONE = clsSmsoutDTO.SM_TELEPHONE.ToString();
                    clsSmsout.SM_STATUT = clsSmsoutDTO.SM_STATUT.ToString();
                    clsSmsout.SM_DATESAISIE = DateTime.Parse(clsSmsoutDTO.SM_DATESAISIE);

                    clsObjetEnvoi.OE_A = clsSmsoutDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsSmsoutDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsSmsoutWSBLL.pvgAjouter(clsDonnee, clsSmsout, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsSmsouts.Add(clsSmsout);
                }
                else
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsSmsouts.Add(clsSmsout);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                clsSmsouts.Add(clsSmsout);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                clsSmsouts.Add(clsSmsout);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsSmsouts;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsSmsout> pvgModifier(List<HT_Stock.BOJ.clsSmsout> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsSmsouts = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
                //--TEST CONTRAINTE
                clsSmsouts = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsSmsout clsSmsoutDTO in Objet)
                {
                    Stock.BOJ.clsSmsout clsSmsout = new Stock.BOJ.clsSmsout();
                    clsSmsout.AG_CODEAGENCE = clsSmsoutDTO.AG_CODEAGENCE.ToString();
                    clsSmsout.SM_DATEPIECE = clsSmsoutDTO.SM_DATEPIECE.ToString();

                    clsSmsout.SM_NUMPIECE = clsSmsoutDTO.SM_NUMPIECE.ToString();
                    clsSmsout.SM_NUMSEQUENCE = clsSmsoutDTO.SM_NUMSEQUENCE.ToString();
                    clsSmsout.CO_CODECOMPTE = clsSmsoutDTO.CO_CODECOMPTE.ToString();
                    clsSmsout.SM_MESSAGE = clsSmsoutDTO.SM_MESSAGE.ToString();
                    clsSmsout.SM_TELEPHONE = clsSmsoutDTO.SM_TELEPHONE.ToString();
                    clsSmsout.SM_STATUT = clsSmsoutDTO.SM_STATUT.ToString();
                    clsSmsout.SM_DATESAISIE = DateTime.Parse(clsSmsoutDTO.SM_DATESAISIE);

                    clsObjetEnvoi.OE_A = clsSmsoutDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsSmsoutDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsSmsoutDTO.AG_CODEAGENCE };
                    clsObjetEnvoi.OE_PARAM = new string[] { clsSmsoutDTO.SM_DATEPIECE };
                    clsObjetRetour.SetValue(true, clsSmsoutWSBLL.pvgModifier(clsDonnee, clsSmsout, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsSmsouts.Add(clsSmsout);
                }
                else
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsSmsouts.Add(clsSmsout);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                clsSmsouts.Add(clsSmsout);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                clsSmsouts.Add(clsSmsout);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsSmsouts;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsSmsout> pvgSupprimer(List<HT_Stock.BOJ.clsSmsout> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsSmsouts = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
                //--TEST CONTRAINTE
                clsSmsouts = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE };
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SM_DATEPIECE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsSmsoutWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsSmsouts.Add(clsSmsout);
                }
                else
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsSmsouts.Add(clsSmsout);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                clsSmsouts.Add(clsSmsout);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
                clsSmsouts.Add(clsSmsout);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsSmsouts;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsSmsout> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsSmsout> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsSmsouts = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
            //    //--TEST CONTRAINTE
            //    clsSmsouts = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsSmsoutWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsSmsout.SM_DATEPIECE = row["SM_DATEPIECE"].ToString();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsSmsouts.Add(clsSmsout);
                }
            }
            else
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsSmsout.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsSmsouts.Add(clsSmsout);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
            clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
            clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSmsout.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            clsSmsouts.Add(clsSmsout);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
            clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
            clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSmsout.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            clsSmsouts.Add(clsSmsout);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsSmsouts;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsSmsout> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsSmsout> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsSmsouts = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
        //    //--TEST CONTRAINTE
        //    clsSmsouts = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsSmsouts[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsSmsouts;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsSmsoutWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                    clsSmsout.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsSmsout.SM_DATEPIECE = row["SM_DATEPIECE"].ToString();
                    clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                    clsSmsout.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsSmsout.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsSmsouts.Add(clsSmsout);
                }
            }
            else
            {
                HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsSmsout.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsSmsout.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsSmsouts.Add(clsSmsout);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
            clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
            clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSmsout.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            clsSmsouts.Add(clsSmsout);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
            clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
            clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsSmsout.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsSmsout.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            clsSmsouts.Add(clsSmsout);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsSmsouts;
    }


        
    }
}
