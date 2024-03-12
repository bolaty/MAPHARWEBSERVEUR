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
                    clsPlancomptable.SO_CODESOCIETE = clsPlancomptableDTO.SO_CODESOCIETE.ToString();
                    clsPlancomptable.NC_CODENATURECOMPTE = clsPlancomptableDTO.NC_CODENATURECOMPTE.ToString();
                    clsPlancomptable.PL_NUMCOMPTE = clsPlancomptableDTO.PL_NUMCOMPTE.ToString();
                    clsPlancomptable.COMPTAPAR_SENS_CODE = clsPlancomptableDTO.COMPTAPAR_SENS_CODE.ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsPlancomptableDTO.PL_TYPECOMPTE.ToString();
                    clsPlancomptable.PL_COMPTECOLLECTIF = clsPlancomptableDTO.PL_COMPTECOLLECTIF.ToString();
                    clsPlancomptable.PL_ACTIF = clsPlancomptableDTO.PL_ACTIF.ToString();
                    clsPlancomptable.PL_FOCUSTIERS = clsPlancomptableDTO.PL_FOCUSTIERS.ToString();
                    clsPlancomptable.PL_SAISIE_ANALYTIQUE = clsPlancomptableDTO.PL_SAISIE_ANALYTIQUE.ToString();
                    clsPlancomptable.TS_CODE = clsPlancomptableDTO.TS_CODE.ToString();
                    clsPlancomptable.PL_NOMBRELIGNE = clsPlancomptableDTO.PL_NOMBRELIGNE.ToString();
                    clsPlancomptable.PLAN_REPORTING_CODE = clsPlancomptableDTO.PLAN_REPORTING_CODE.ToString();
                    clsPlancomptable.PL_COMPTEEXCEDANT = clsPlancomptableDTO.PL_COMPTEEXCEDANT.ToString();
                    clsPlancomptable.PL_COMPTEDEFICIT = clsPlancomptableDTO.PL_COMPTEDEFICIT.ToString();
                    clsPlancomptable.PL_AFFICHERSURECRANDROIT = clsPlancomptableDTO.PL_AFFICHERSURECRANDROIT.ToString();
                    if(clsPlancomptableDTO.TYPEOPERATION!="")
                    clsPlancomptable.TYPEOPERATION =int.Parse(clsPlancomptableDTO.TYPEOPERATION.ToString());



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
                    clsPlancomptable.SO_CODESOCIETE = clsPlancomptableDTO.SO_CODESOCIETE.ToString();
                    clsPlancomptable.NC_CODENATURECOMPTE = clsPlancomptableDTO.NC_CODENATURECOMPTE.ToString();
                    clsPlancomptable.PL_NUMCOMPTE = clsPlancomptableDTO.PL_NUMCOMPTE.ToString();
                    clsPlancomptable.COMPTAPAR_SENS_CODE = clsPlancomptableDTO.COMPTAPAR_SENS_CODE.ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsPlancomptableDTO.PL_TYPECOMPTE.ToString();
                    clsPlancomptable.PL_COMPTECOLLECTIF = clsPlancomptableDTO.PL_COMPTECOLLECTIF.ToString();
                    clsPlancomptable.PL_ACTIF = clsPlancomptableDTO.PL_ACTIF.ToString();
                    clsPlancomptable.PL_FOCUSTIERS = clsPlancomptableDTO.PL_FOCUSTIERS.ToString();
                    clsPlancomptable.PL_SAISIE_ANALYTIQUE = clsPlancomptableDTO.PL_SAISIE_ANALYTIQUE.ToString();
                    clsPlancomptable.TS_CODE = clsPlancomptableDTO.TS_CODE.ToString();
                    clsPlancomptable.PL_NOMBRELIGNE = clsPlancomptableDTO.PL_NOMBRELIGNE.ToString();
                    clsPlancomptable.PLAN_REPORTING_CODE = clsPlancomptableDTO.PLAN_REPORTING_CODE.ToString();
                    clsPlancomptable.PL_COMPTEEXCEDANT = clsPlancomptableDTO.PL_COMPTEEXCEDANT.ToString();
                    clsPlancomptable.PL_COMPTEDEFICIT = clsPlancomptableDTO.PL_COMPTEDEFICIT.ToString();
                    clsPlancomptable.PL_AFFICHERSURECRANDROIT = clsPlancomptableDTO.PL_AFFICHERSURECRANDROIT.ToString();
                    if (clsPlancomptableDTO.TYPEOPERATION != "")
                        clsPlancomptable.TYPEOPERATION = int.Parse(clsPlancomptableDTO.TYPEOPERATION.ToString());

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


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SO_CODESOCIETE, Objet[0].PL_CODENUMCOMPTE };
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

                string vlpMessage = (SQLEx.Number == 547) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
                if (SQLEx.Number != 547) vlpMessage = SQLEx.Message;

                HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = vlpMessage;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(vlpMessage, null);
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

            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SO_CODESOCIETE, Objet[0].PL_NUMCOMPTE, Objet[0].PL_TYPECOMPTE, Objet[0].NC_CODENATURECOMPTE };
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
                        clsPlancomptable.PL_FOCUSTIERS = row["PL_FOCUSTIERS"].ToString();
                        clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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
        public List<HT_Stock.BOJ.clsPlancomptable> pvgChargerDansDataSetComptesCollectifs(List<HT_Stock.BOJ.clsPlancomptable> Objet)
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
                clsPlancomptables = TestChampObligatoireCompteCollectif(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
                //--TEST CONTRAINTE
               // clsPlancomptables = TestTestContrainteListe();
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            }

            Objet[0].SO_CODESOCIETE = "0001";
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SO_CODESOCIETE, Objet[0].PL_NUMCOMPTE };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsPlancomptableWSBLL.pvgChargerDansDataSetComptesCollectifs(clsDonnee, clsObjetEnvoi);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                        //clsPlancomptable.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        //clsPlancomptable.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                        //clsPlancomptable.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                        clsPlancomptable.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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
        public List<HT_Stock.BOJ.clsPlancomptable> pvgChargerDansDataSetTousLesComptes(List<HT_Stock.BOJ.clsPlancomptable> Objet)
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
                clsPlancomptables = TestChampObligatoireListTousLesComptes(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
                //--TEST CONTRAINTE
                //clsPlancomptables = TestTestContrainteListe();
                //--VERIFICATION DU RESULTAT DU TEST
                //if (clsPlancomptables[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptables;
            }

            Objet[0].SO_CODESOCIETE = "0001";
            Objet[0].PL_TYPECOMPTE = "I";

            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SO_CODESOCIETE };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsPlancomptableWSBLL.pvgChargerDansDataSetTousLesComptes(clsDonnee, clsObjetEnvoi);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                        clsPlancomptable.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsPlancomptable.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
                        clsPlancomptable.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                        clsPlancomptable.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsPlancomptable.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                        clsPlancomptable.PL_COMPTECOLLECTIF = row["PL_COMPTECOLLECTIF"].ToString();

                        if (row["PL_REPORTDEBIT"].ToString() != "")
                            clsPlancomptable.PL_REPORTDEBIT = double.Parse(row["PL_REPORTDEBIT"].ToString());
                        else
                            clsPlancomptable.PL_REPORTDEBIT = 0;

                        if (row["PL_REPORTCREDIT"].ToString() != "")
                            clsPlancomptable.PL_REPORTCREDIT = double.Parse(row["PL_REPORTCREDIT"].ToString());
                        else
                            clsPlancomptable.PL_REPORTCREDIT = 0;

                        if (row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString() != "")
                            clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = 0;

                        if (row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString() != "")
                            clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = 0;


                        if (row["PL_MONTANTPERIODEDEBITENCOURS"].ToString() != "")
                            clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(row["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = 0;

                        if (row["PL_MONTANTPERIODEDEBITENCOURS"].ToString() != "")
                            clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(row["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = 0;

                        if (row["PL_MONTANTPERIODECREDITENCOURS"].ToString() != "")
                            clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(row["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = 0;

                        if (row["PL_MONTANTSOLDEFINALDEBIT"].ToString() != "")
                            clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(row["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = 0;

                        if (row["PL_MONTANTSOLDEFINALCREDIT"].ToString() != "")
                            clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(row["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                        else
                            clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = 0;


                        clsPlancomptable.PL_SENS = row["PL_SENS"].ToString();
                        clsPlancomptable.PL_TYPECOMPTE = row["PL_TYPECOMPTE"].ToString();
                        clsPlancomptable.PL_ACTIF = row["PL_ACTIF"].ToString();
                        clsPlancomptable.PL_COMPTELIE = row["PL_COMPTELIE"].ToString();
                        clsPlancomptable.PL_FOCUSTIERS = row["PL_FOCUSTIERS"].ToString();
                        clsPlancomptable.PL_SAISIE_ANALYTIQUE = row["PL_SAISIE_ANALYTIQUE"].ToString();
                        clsPlancomptable.PL_COMPTEPRINCIPAL = row["PL_COMPTEPRINCIPAL"].ToString();
                        clsPlancomptable.TS_CODE = row["TS_CODE"].ToString();
                        clsPlancomptable.PL_NOMBRELIGNE = row["PL_NOMBRELIGNE"].ToString();
                        clsPlancomptable.PLAN_REPORTING_CODE = row["PLAN_REPORTING_CODE"].ToString();
                        clsPlancomptable.PL_COMPTEEXCEDANT = row["PL_COMPTEEXCEDANT"].ToString();
                        clsPlancomptable.PL_COMPTEDEFICIT = row["PL_COMPTEDEFICIT"].ToString();
                        clsPlancomptable.COMPTAPAR_SENS_CODE = row["COMPTAPAR_SENS_CODE"].ToString();
                        clsPlancomptable.PL_AFFICHERSURECRANDROIT = row["PL_AFFICHERSURECRANDROIT"].ToString();

                        clsPlancomptable.PL_TYPECOMPTELIBELLE = clsPlancomptable.PL_TYPECOMPTE == "C" ? "COLLECTIF" : "INDIVIDUEL" ;
                        clsPlancomptable.PL_ACTIFLIBELLE = clsPlancomptable.PL_ACTIF == "O" ? "ACTIF" : "NON ACTIF";
                        clsPlancomptable.PLAN_RERPORTING_INTITULE = row["PLAN_RERPORTING_INTITULE"].ToString();
                        clsPlancomptable.TS_LIBELLE = row["TS_LIBELLE"].ToString();
                        clsPlancomptable.COMPTAPAR_SENS_LIBELLE = row["PL_SENS"].ToString();


                        //clsPlancomptable.PLAN_RERPORTING_INTITULE = row["PLAN_RERPORTING_INTITULE"].ToString();

                        //clsPlancomptable.COMPTAPAR_SENS_CODE = clsPlancomptable.COMPTAPAR_SENS_CODE == "C" ? 1 : 0;

                        //

                        //clsPlancomptable.TS_LIBELLE = clsPlancomptable.TS_CODE == "C" ? 0 : 1;

                        //cpsDevComboBox4.SelectedIndex = clsPlancomptable.PL_ACTIF == "O" ? 0 : 1;




                        //private string _PL_TYPECOMPTELIBELLE = "";
                        //private string _PL_ACTIFLIBELLE = "";
                        //private string _PLAN_RERPORTING_INTITULE = "";
                        //private string _TS_LIBELLE = "";
                        //private string _NC_LIBELLENATURECOMPTE = "";
                        //private string _COMPTAPAR_SENS_LIBELLE = "";


                        clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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


            clsObjetEnvoi.OE_PARAM = new string[] { };
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
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].FO_CODEFAMILLEOPERATION, Objet[0].NF_CODENATUREFAMILLEOPERATION };
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
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SO_CODESOCIETE = "0001" };
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
                        clsPlancomptable.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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
        public List<HT_Stock.BOJ.clsPlancomptable> pvgGenerationCpteCollectif(List<HT_Stock.BOJ.clsPlancomptable> Objet)
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


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SO_CODESOCIETE = "0001" };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsPlancomptableWSBLL.pvgGenerationCpteCollectif(clsDonnee, clsObjetEnvoi);
                clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();

                string[] vlpChamp = new string[] { "SL_CODEMESSAGE", "SL_RESULTAT", "SL_MESSAGE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp[i]);
                }
                DataSet.Tables[0].Rows.Add("00", "TRUE", "Opération réalisée avec succès !!!");
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
                        clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                        clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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

    }
}
