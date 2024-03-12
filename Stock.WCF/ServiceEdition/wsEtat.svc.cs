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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEtat" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEtat.svc ou wsEtat.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEtat : IwsEtat
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEtatWSBLL clsEtatWSBLL = new clsEtatWSBLL();

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
        public List<HT_Stock.BOJ.clsEtat> pvgAjouter(List<HT_Stock.BOJ.clsEtat> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEtats = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
                //--TEST CONTRAINTE
                clsEtats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsEtat clsEtatDTO in Objet)
                {
                    Stock.BOJ.clsEtat clsEtat = new Stock.BOJ.clsEtat();
                    clsEtat.ET_INDEX = clsEtatDTO.ET_INDEX.ToString();
                    clsEtat.ET_LIBELLEETAT = clsEtatDTO.ET_LIBELLEETAT.ToString();
                    clsObjetEnvoi.OE_A = clsEtatDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEtatDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgAjouter(clsDonnee, clsEtat), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEtat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEtats.Add(clsEtat);
                }
                else
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEtat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsEtats.Add(clsEtat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                clsEtats.Add(clsEtat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                clsEtats.Add(clsEtat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEtats;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEtat> pvgModifier(List<HT_Stock.BOJ.clsEtat> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEtats = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
                //--TEST CONTRAINTE
                clsEtats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsEtat clsEtatDTO in Objet)
                {
                    Stock.BOJ.clsEtat clsEtat = new Stock.BOJ.clsEtat();
                    clsEtat.ET_INDEX = clsEtatDTO.ET_INDEX.ToString();
                    clsEtat.ET_LIBELLEETAT = clsEtatDTO.ET_LIBELLEETAT.ToString();
                    clsObjetEnvoi.OE_A = clsEtatDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEtatDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsEtatDTO.ET_INDEX };
                    clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgModifier(clsDonnee, clsEtat, clsObjetEnvoi.OE_PARAM), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEtat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEtats.Add(clsEtat);
                }
                else
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEtat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsEtats.Add(clsEtat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                clsEtats.Add(clsEtat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                clsEtats.Add(clsEtat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEtats;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEtat> pvgSupprimer(List<HT_Stock.BOJ.clsEtat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEtats = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
                //--TEST CONTRAINTE
                clsEtats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].ET_INDEX };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi.OE_PARAM), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEtat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsEtats.Add(clsEtat);
                }
                else
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEtat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsEtats.Add(clsEtat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                clsEtats.Add(clsEtat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEtats = new List<HT_Stock.BOJ.clsEtat>();
                clsEtats.Add(clsEtat);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEtats;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsEtat> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsEtat> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEtats = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
                //--TEST CONTRAINTE
                clsEtats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].ET_NOMGROUPE, Objet[0].OP_CODEOPERATEUR, Objet[0].ET_AFFICHER, Objet[0].OD_APERCU };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEtatWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.ET_INDEX = row["ET_INDEX"].ToString();
                    clsEtat.ET_LIBELLEETAT = row["ET_LIBELLEETAT"].ToString();
                    clsEtat.ET_AFFICHER = row["ET_AFFICHER"].ToString();
                    clsEtat.ET_DOSSIER = row["ET_DOSSIER"].ToString();
                    //clsEtat.ET_IMPRIMER = row["ET_IMPRIMER"].ToString();
                    clsEtat.ET_NOMETAT = row["ET_NOMETAT"].ToString();
                    //clsEtat.ET_NOMETAT1 = row["ET_NOMETAT1"].ToString();
                    //clsEtat.ET_NOMETAT2 = row["ET_NOMETAT2"].ToString();
                    clsEtat.ET_NOMGROUPE = row["ET_NOMGROUPE"].ToString();
                    clsEtat.ET_TYPEETAT = row["ET_TYPEETAT"].ToString();



                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEtat.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEtats.Add(clsEtat);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEtat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEtats.Add(clsEtat);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEtat.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            clsEtats.Add(clsEtat);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEtat.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            clsEtats.Add(clsEtat);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsEtats;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEtat> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsEtat> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsEtats = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
        //    //--TEST CONTRAINTE
        //    clsEtats = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsEtats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEtats;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
           // DataSet = clsEtatWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                    clsEtat.ET_INDEX = row["ET_INDEX"].ToString();
                    clsEtat.ET_LIBELLEETAT = row["ET_LIBELLEETAT"].ToString();
                    clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                    clsEtat.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEtat.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEtats.Add(clsEtat);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEtat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEtats.Add(clsEtat);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEtat.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            clsEtats.Add(clsEtat);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEtat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEtat.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            clsEtats.Add(clsEtat);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEtats;
    }


        
    }
}
