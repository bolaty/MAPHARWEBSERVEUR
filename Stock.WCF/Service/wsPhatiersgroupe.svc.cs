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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhatiersgroupe" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhatiersgroupe.svc ou wsPhatiersgroupe.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhatiersgroupe : IwsPhatiersgroupe
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhatiersgroupeWSBLL clsPhatiersgroupeWSBLL = new clsPhatiersgroupeWSBLL();

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
        public List<HT_Stock.BOJ.clsPhatiersgroupe> pvgAjouter(List<HT_Stock.BOJ.clsPhatiersgroupe> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersgroupes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
                //--TEST CONTRAINTE
                clsPhatiersgroupes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupeDTO in Objet)
                {
                    Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.GP_CODEGROUPE = clsPhatiersgroupeDTO.GP_CODEGROUPE.ToString();
                    clsPhatiersgroupe.GP_LIBELLE = clsPhatiersgroupeDTO.GP_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhatiersgroupeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhatiersgroupeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhatiersgroupeWSBLL.pvgAjouter(clsDonnee, clsPhatiersgroupe, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersgroupes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiersgroupe> pvgModifier(List<HT_Stock.BOJ.clsPhatiersgroupe> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersgroupes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
                //--TEST CONTRAINTE
                clsPhatiersgroupes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupeDTO in Objet)
                {
                    Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.GP_CODEGROUPE = clsPhatiersgroupeDTO.GP_CODEGROUPE.ToString();
                    clsPhatiersgroupe.GP_LIBELLE = clsPhatiersgroupeDTO.GP_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhatiersgroupeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhatiersgroupeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhatiersgroupeDTO.GP_CODEGROUPE };
                    clsObjetRetour.SetValue(true, clsPhatiersgroupeWSBLL.pvgModifier(clsDonnee, clsPhatiersgroupe, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersgroupes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiersgroupe> pvgSupprimer(List<HT_Stock.BOJ.clsPhatiersgroupe> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersgroupes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
                //--TEST CONTRAINTE
                clsPhatiersgroupes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].GP_CODEGROUPE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhatiersgroupeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersgroupes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhatiersgroupe> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhatiersgroupe> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhatiersgroupes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
            //    //--TEST CONTRAINTE
            //    clsPhatiersgroupes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
            //}

            if (string.IsNullOrEmpty(Objet[0].GP_LIBELLE))
                Objet[0].GP_LIBELLE = "";
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].GP_LIBELLE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhatiersgroupeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                    clsPhatiersgroupe.GP_LIBELLE = row["GP_LIBELLE"].ToString();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersgroupes;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiersgroupe> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhatiersgroupe> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhatiersgroupes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
        //    //--TEST CONTRAINTE
        //    clsPhatiersgroupes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhatiersgroupes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersgroupes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhatiersgroupeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                    clsPhatiersgroupe.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                    clsPhatiersgroupe.GP_LIBELLE = row["GP_LIBELLE"].ToString();
                    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhatiersgroupes.Add(clsPhatiersgroupe);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhatiersgroupes;
    }


        
    }
}
