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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpartypeoccupant" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpartypeoccupant.svc ou wsCtpartypeoccupant.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpartypeoccupant : IwsCtpartypeoccupant
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpartypeoccupantWSBLL clsCtpartypeoccupantWSBLL = new clsCtpartypeoccupantWSBLL();

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
        public List<HT_Stock.BOJ.clsCtpartypeoccupant> pvgAjouter(List<HT_Stock.BOJ.clsCtpartypeoccupant> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartypeoccupants = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
                //--TEST CONTRAINTE
                clsCtpartypeoccupants = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupantDTO in Objet)
                {
                    Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.OC_CODETYPEOCCUPANT = clsCtpartypeoccupantDTO.OC_CODETYPEOCCUPANT.ToString();
                    clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = clsCtpartypeoccupantDTO.OC_LIBLLETYPEOCCUPANT.ToString();
                    clsObjetEnvoi.OE_A = clsCtpartypeoccupantDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartypeoccupantDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpartypeoccupantWSBLL.pvgAjouter(clsDonnee, clsCtpartypeoccupant, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypeoccupants;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartypeoccupant> pvgModifier(List<HT_Stock.BOJ.clsCtpartypeoccupant> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartypeoccupants = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
                //--TEST CONTRAINTE
                clsCtpartypeoccupants = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupantDTO in Objet)
                {
                    Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.OC_CODETYPEOCCUPANT = clsCtpartypeoccupantDTO.OC_CODETYPEOCCUPANT.ToString();
                    clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = clsCtpartypeoccupantDTO.OC_LIBLLETYPEOCCUPANT.ToString();
                    clsObjetEnvoi.OE_A = clsCtpartypeoccupantDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartypeoccupantDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpartypeoccupantDTO.OC_CODETYPEOCCUPANT };
                    clsObjetRetour.SetValue(true, clsCtpartypeoccupantWSBLL.pvgModifier(clsDonnee, clsCtpartypeoccupant, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypeoccupants;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartypeoccupant> pvgSupprimer(List<HT_Stock.BOJ.clsCtpartypeoccupant> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartypeoccupants = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
                //--TEST CONTRAINTE
                clsCtpartypeoccupants = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OC_CODETYPEOCCUPANT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpartypeoccupantWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypeoccupants;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtpartypeoccupant> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpartypeoccupant> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtpartypeoccupants = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
            //    //--TEST CONTRAINTE
            //    clsCtpartypeoccupants = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartypeoccupantWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.OC_CODETYPEOCCUPANT = row["OC_CODETYPEOCCUPANT"].ToString();
                    clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = row["OC_LIBLLETYPEOCCUPANT"].ToString();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypeoccupants;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartypeoccupant> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpartypeoccupant> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtpartypeoccupants = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
        //    //--TEST CONTRAINTE
        //    clsCtpartypeoccupants = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartypeoccupants[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypeoccupants;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartypeoccupantWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                    clsCtpartypeoccupant.OC_CODETYPEOCCUPANT = row["OC_CODETYPEOCCUPANT"].ToString();
                    clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = row["OC_LIBLLETYPEOCCUPANT"].ToString();
                    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpartypeoccupants;
    }


        
    }
}
