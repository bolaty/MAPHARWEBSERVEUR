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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhanaturefamilleoperation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhanaturefamilleoperation.svc ou wsPhanaturefamilleoperation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhanaturefamilleoperation : IwsPhanaturefamilleoperation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhanaturefamilleoperationWSBLL clsPhanaturefamilleoperationWSBLL = new clsPhanaturefamilleoperationWSBLL();

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
        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> pvgAjouter(List<HT_Stock.BOJ.clsPhanaturefamilleoperation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhanaturefamilleoperations = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
                //--TEST CONTRAINTE
                clsPhanaturefamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperationDTO in Objet)
                {
                    Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION = clsPhanaturefamilleoperationDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = clsPhanaturefamilleoperationDTO.NF_LIBELLENATUREFAMILLEOPERATION1.ToString();
                    clsObjetEnvoi.OE_A = clsPhanaturefamilleoperationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhanaturefamilleoperationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhanaturefamilleoperationWSBLL.pvgAjouter(clsDonnee, clsPhanaturefamilleoperation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhanaturefamilleoperations;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> pvgModifier(List<HT_Stock.BOJ.clsPhanaturefamilleoperation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhanaturefamilleoperations = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
                //--TEST CONTRAINTE
                clsPhanaturefamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperationDTO in Objet)
                {
                    Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION = clsPhanaturefamilleoperationDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = clsPhanaturefamilleoperationDTO.NF_LIBELLENATUREFAMILLEOPERATION1.ToString();
                    clsObjetEnvoi.OE_A = clsPhanaturefamilleoperationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhanaturefamilleoperationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhanaturefamilleoperationDTO.NF_CODENATUREFAMILLEOPERATION };
                    clsObjetRetour.SetValue(true, clsPhanaturefamilleoperationWSBLL.pvgModifier(clsDonnee, clsPhanaturefamilleoperation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhanaturefamilleoperations;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> pvgSupprimer(List<HT_Stock.BOJ.clsPhanaturefamilleoperation> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhanaturefamilleoperations = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
                //--TEST CONTRAINTE
                clsPhanaturefamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NF_CODENATUREFAMILLEOPERATION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhanaturefamilleoperationWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhanaturefamilleoperations;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhanaturefamilleoperation> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhanaturefamilleoperations = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            //    //--TEST CONTRAINTE
            //    clsPhanaturefamilleoperations = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhanaturefamilleoperationWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION = row["NF_CODENATUREFAMILLEOPERATION"].ToString();
                    clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = row["NF_LIBELLENATUREFAMILLEOPERATION1"].ToString();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
            clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
            clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhanaturefamilleoperations;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhanaturefamilleoperation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhanaturefamilleoperations = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            //    //--TEST CONTRAINTE
            //    clsPhanaturefamilleoperations = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhanaturefamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhanaturefamilleoperations;
            //}

            if (!string.IsNullOrEmpty(Objet[0].TYPEOPERATION))
                clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].TYPEOPERATION};
            else
                clsObjetEnvoi.OE_PARAM = new string[] {};

            DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhanaturefamilleoperationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                    clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION = row["NF_CODENATUREFAMILLEOPERATION"].ToString();
                    clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = row["NF_LIBELLENATUREFAMILLEOPERATION1"].ToString();
                    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
            clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
            clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhanaturefamilleoperations;
    }


        
    }
}
