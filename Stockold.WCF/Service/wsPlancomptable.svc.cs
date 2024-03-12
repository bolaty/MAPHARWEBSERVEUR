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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPlancomptable" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPlancomptable.svc ou wsPlancomptable.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPlancomptable : IwsPlancomptable
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPlancomptableWSBLL clsPlancomptableWSBLL = new clsPlancomptableWSBLL();

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
        public List<HT_Stock.BOJ.clsPlancomptable> pvgAjouter(List<HT_Stock.BOJ.clsPlancomptable> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptables = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
                //--TEST CONTRAINTE
                clsPlancomptables = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPlancomptable clsPlancomptableDTO in Objet)
                {
                    Stock.BOJ.clsPlancomptable clsPlancomptable = new Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.PL_CODENUMCOMPTE = clsPlancomptableDTO.PL_CODENUMCOMPTE.ToString();
                    clsPlancomptable.PL_LIBELLE = clsPlancomptableDTO.PL_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPlancomptableDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPlancomptableDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPlancomptableWSBLL.pvgAjouter(clsDonnee, clsPlancomptable, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
                else
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                clsPlancomptables.Add(clsPlancomptable);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                clsPlancomptables.Add(clsPlancomptable);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptables;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPlancomptable> pvgModifier(List<HT_Stock.BOJ.clsPlancomptable> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptables = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
                //--TEST CONTRAINTE
                clsPlancomptables = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPlancomptable clsPlancomptableDTO in Objet)
                {
                    Stock.BOJ.clsPlancomptable clsPlancomptable = new Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.PL_CODENUMCOMPTE = clsPlancomptableDTO.PL_CODENUMCOMPTE.ToString();
                    clsPlancomptable.PL_LIBELLE = clsPlancomptableDTO.PL_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPlancomptableDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPlancomptableDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPlancomptableDTO.PL_CODENUMCOMPTE };
                    clsObjetRetour.SetValue(true, clsPlancomptableWSBLL.pvgModifier(clsDonnee, clsPlancomptable, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
                else
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                clsPlancomptables.Add(clsPlancomptable);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                clsPlancomptables.Add(clsPlancomptable);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptables;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPlancomptable> pvgSupprimer(List<HT_Stock.BOJ.clsPlancomptable> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptables = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
                //--TEST CONTRAINTE
                clsPlancomptables = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PL_CODENUMCOMPTE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPlancomptableWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
                else
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                clsPlancomptables.Add(clsPlancomptable);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                clsPlancomptables.Add(clsPlancomptable);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptables;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPlancomptable> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPlancomptable> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPlancomptables = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            //    //--TEST CONTRAINTE
            //    clsPlancomptables = TestTestContrainteListe();
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            //}

            Objet[0].SO_CODESOCIETE = "0001";
            Objet[0].PL_TYPECOMPTE = "I";

            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].SO_CODESOCIETE, Objet[0].PL_NUMCOMPTE, Objet[0].PL_TYPECOMPTE, Objet[0].NC_CODENATURECOMPTE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptableWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                    clsPlancomptable.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                    clsPlancomptable.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptables.Add(clsPlancomptable);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptables;
            }

            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPlancomptable> pvgChargerDansDataSetCpteCharge(List<HT_Stock.BOJ.clsPlancomptable> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPlancomptables = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            //    //--TEST CONTRAINTE
            //    clsPlancomptables = TestTestContrainteListe();
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            //}


            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptableWSBLL.pvgChargerDansDataSetCpteCharge(clsDonnee, clsObjetEnvoi);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.NO_ABREVIATION = row["NO_ABREVIATION"].ToString();
                    clsPlancomptable.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                    clsPlancomptable.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                    clsPlancomptable.NO_MONTANT = row["NO_MONTANT"].ToString();
                    clsPlancomptable.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsPlancomptable.NO_PREFIXECOMPTE = row["NO_PREFIXECOMPTE"].ToString();
                    clsPlancomptable.NO_SENS = row["NO_SENS"].ToString();
                    clsPlancomptable.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                    clsPlancomptable.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();

                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptables.Add(clsPlancomptable);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptables;
            }




            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPlancomptable> pvgChargerDansDataSetOperation(List<HT_Stock.BOJ.clsPlancomptable> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptables = TestChampObligatoireListeTres(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
                ////--TEST CONTRAINTE
                //clsPlancomptables = TestTestContrainteListe();
                ////--VERIFICATION DU RESULTAT DU TEST
                //if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            }

            Objet[0].SO_CODESOCIETE = "0001";
            Objet[0].PL_TYPECOMPTE = "I";
            //"@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@FO_CODEFAMILLEOPERATION", "@NF_CODENATUREFAMILLEOPERATION"
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].FO_CODEFAMILLEOPERATION, Objet[0].NF_CODENATUREFAMILLEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptableWSBLL.pvgChargerDansDataSetOperation(clsDonnee, clsObjetEnvoi);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                    clsPlancomptable.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsPlancomptable.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsPlancomptable.NO_SENS = row["NO_SENS"].ToString();
                    clsPlancomptable.NO_PREFIXECOMPTE = row["NO_PREFIXECOMPTE"].ToString();
                    clsPlancomptable.NO_REFPIECE = row["NO_REFPIECE"].ToString();
                    clsPlancomptable.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                    clsPlancomptable.COCHER = row["COCHER"].ToString();
                    clsPlancomptable.NO_ABREVIATION = row["NO_ABREVIATION"].ToString();
                    clsPlancomptable.NO_MONTANT = row["NO_MONTANT"].ToString();
                    clsPlancomptable.PL_CODENUMCOMPTECONTREPARTIE = row["PL_CODENUMCOMPTECONTREPARTIE"].ToString();
                    clsPlancomptable.PL_NUMCOMPTECONTREPARTIE = row["PL_NUMCOMPTECONTREPARTIE"].ToString();
                    clsPlancomptable.NO_NUMEROORDRE = row["NO_NUMEROORDRE"].ToString();
                    clsPlancomptable.NO_MODIFIERMONTANT = row["NO_MODIFIERMONTANT"].ToString();
                    clsPlancomptable.NC_CODENATURECOMPTE1 = row["NC_CODENATURECOMPTE1"].ToString();
                    clsPlancomptable.NC_CODENATURECOMPTECONTREPARTIE = row["NC_CODENATURECOMPTECONTREPARTIE"].ToString();
                    clsPlancomptable.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptables.Add(clsPlancomptable);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptables;
            }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPlancomptable> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPlancomptable> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPlancomptables = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
        //    //--TEST CONTRAINTE
        //    clsPlancomptables = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].SO_CODESOCIETE = "0001" };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptableWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                    clsPlancomptable.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptable.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptables.Add(clsPlancomptable);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptables.Add(clsPlancomptable);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptable.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            clsPlancomptables.Add(clsPlancomptable);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPlancomptables;
    }


        
    }
}
