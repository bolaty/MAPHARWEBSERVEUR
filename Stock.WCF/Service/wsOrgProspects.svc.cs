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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOrgProspects" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOrgProspects.svc ou wsOrgProspects.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOrgProspects : IwsOrgProspects
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOrgProspectsWSBLL clsOrgProspectsWSBLL = new clsOrgProspectsWSBLL();

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


        public List<HT_Stock.BOJ.clsOrgProspects> pvgAjouter(List<HT_Stock.BOJ.clsOrgProspects> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                //--TEST CONTRAINTE
                clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
            }

            Stock.BOJ.clsOrgProspects clsOrgProspects1 = new Stock.BOJ.clsOrgProspects();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsOrgProspectsgarantie> clsOrgProspectsgaranties = new List<BOJ.clsOrgProspectsgarantie>();
            //List<Stock.BOJ.clsOrgProspectsprime> clsOrgProspectsprimes = new List<BOJ.clsOrgProspectsprime>();
            //List<Stock.BOJ.clsOrgProspectsreduction> clsOrgProspectsreductions = new List<BOJ.clsOrgProspectsreduction>();
            //List<Stock.BOJ.clsOrgProspectsayantdroit> clsOrgProspectsayantdroits = new List<BOJ.clsOrgProspectsayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOrgProspects clsOrgProspectsDTO in Objet)
                {

                     Byte[] PR_PHOTO = null;
                     Byte[] PR_SIGNATURE = null;

                    if (clsOrgProspectsDTO.PR_PHOTO != "")
                     PR_PHOTO = System.Convert.FromBase64String(clsOrgProspectsDTO.PR_PHOTO);
                    if(clsOrgProspectsDTO.PR_SIGNATURE!="")
                     PR_SIGNATURE = System.Convert.FromBase64String(clsOrgProspectsDTO.PR_SIGNATURE);
                    Stock.BOJ.clsOrgProspects clsOrgProspects = new Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.AG_CODEAGENCE = clsOrgProspectsDTO.AG_CODEAGENCE.ToString();
                    clsOrgProspects.EN_CODEENTREPOT = clsOrgProspectsDTO.EN_CODEENTREPOT.ToString();
                    clsOrgProspects.PR_IDTIERS = clsOrgProspectsDTO.PR_IDTIERS.ToString();
                    clsOrgProspects.PR_IDTIERSPRINCIPAL = clsOrgProspectsDTO.PR_IDTIERSPRINCIPAL.ToString() ;
                    clsOrgProspects.NT_CODENATURETYPETIERS = clsOrgProspectsDTO.NT_CODENATURETYPETIERS.ToString();
                    clsOrgProspects.NT_CODENATURETIERS = clsOrgProspectsDTO.NT_CODENATURETIERS.ToString();
                    clsOrgProspects.VL_CODEVILLE = clsOrgProspectsDTO.VL_CODEVILLE.ToString();
                    clsOrgProspects.PY_CODEPAYS = clsOrgProspectsDTO.PY_CODEPAYS.ToString();
                    clsOrgProspects.PR_SIEGE = clsOrgProspectsDTO.PR_SIEGE.ToString();
                    clsOrgProspects.SX_CODESEXE = clsOrgProspectsDTO.SX_CODESEXE.ToString();
                    clsOrgProspects.FM_CODEFORMEJURIDIQUE = clsOrgProspectsDTO.FM_CODEFORMEJURIDIQUE.ToString();
                    clsOrgProspects.AC_CODEACTIVITE = clsOrgProspectsDTO.AC_CODEACTIVITE.ToString();
                    clsOrgProspects.TP_CODETYPETIERS = clsOrgProspectsDTO.TP_CODETYPETIERS.ToString() ;
                    clsOrgProspects.OP_CODEOPERATEUR = clsOrgProspectsDTO.OP_CODEOPERATEUR.ToString();
                    clsOrgProspects.TC_CODECOMPTETYPETIERS = clsOrgProspectsDTO.TC_CODECOMPTETYPETIERS.ToString();
                    clsOrgProspects.PR_NUMTIERS = clsOrgProspectsDTO.PR_NUMTIERS.ToString();
                    clsOrgProspects.PR_DATENAISSANCE =DateTime.Parse(clsOrgProspectsDTO.PR_DATENAISSANCE.ToString());
                    clsOrgProspects.PR_DENOMINATION = clsOrgProspectsDTO.PR_DENOMINATION.ToString();
                    clsOrgProspects.PR_DESCRIPTIONTIERS = clsOrgProspectsDTO.PR_DESCRIPTIONTIERS.ToString();
                    clsOrgProspects.PR_ADRESSEPOSTALE = clsOrgProspectsDTO.PR_ADRESSEPOSTALE.ToString();
                    clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = clsOrgProspectsDTO.PR_ADRESSEGEOGRAPHIQUE.ToString();
                    clsOrgProspects.PR_TELEPHONE = clsOrgProspectsDTO.PR_TELEPHONE.ToString();
                    clsOrgProspects.PR_FAX = clsOrgProspectsDTO.PR_FAX.ToString();
                    clsOrgProspects.PR_SITEWEB = clsOrgProspectsDTO.PR_SITEWEB.ToString();
                    clsOrgProspects.PR_EMAIL = clsOrgProspectsDTO.PR_EMAIL.ToString();
                    clsOrgProspects.PR_GERANT = clsOrgProspectsDTO.PR_GERANT.ToString();
                    clsOrgProspects.PR_STATUT = clsOrgProspectsDTO.PR_STATUT.ToString();
                    clsOrgProspects.PR_DATESAISIE =DateTime.Parse(clsOrgProspectsDTO.PR_DATESAISIE.ToString());
                    clsOrgProspects.PR_ASDI = clsOrgProspectsDTO.PR_ASDI.ToString();
                    clsOrgProspects.PR_TVA = clsOrgProspectsDTO.PR_TVA.ToString();
                    clsOrgProspects.PR_STATUTDOUTEUX =int.Parse(clsOrgProspectsDTO.PR_STATUTDOUTEUX.ToString());
                    clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(clsOrgProspectsDTO.PR_PLAFONDCREDIT.ToString());
                    clsOrgProspects.PR_NUMCPTECONTIBUABLE =clsOrgProspectsDTO.PR_NUMCPTECONTIBUABLE.ToString();
                    clsOrgProspects.OP_CODEOPERATEUR = clsOrgProspectsDTO.OP_CODEOPERATEUR.ToString();
                    clsOrgProspects.PR_DATEDEPART = (clsOrgProspectsDTO.PR_DATEDEPART.ToString() != "") ? DateTime.Parse(clsOrgProspectsDTO.PR_DATEDEPART.ToString()) : DateTime.Parse("01/01/1900");
                    clsOrgProspects.PR_PHOTO = PR_PHOTO;
                    clsOrgProspects.PR_SIGNATURE =PR_SIGNATURE;
                    clsOrgProspects.PL_NUMCOMPTE = clsOrgProspectsDTO.PL_NUMCOMPTE.ToString();

                    clsOrgProspects.PR_TAUXREMISE = float.Parse(clsOrgProspectsDTO.PR_TAUXREMISE.ToString());
                    clsOrgProspects.CU_CODECASUTILISATION = clsOrgProspectsDTO.CU_CODECASUTILISATION.ToString() ;
                    clsOrgProspects.PR_NUMEROAGREMENT = clsOrgProspectsDTO.PR_NUMEROAGREMENT.ToString() ;
                    clsOrgProspects.PR_TAUXDECLARATION =double.Parse(clsOrgProspectsDTO.PR_TAUXDECLARATION.ToString()) ;
                    clsOrgProspects.GP_CODEGROUPE = clsOrgProspectsDTO.GP_CODEGROUPE.ToString();
                    clsOrgProspects.PR_MANDATAIRE = clsOrgProspectsDTO.PR_MANDATAIRE.ToString();
                    clsOrgProspects.PR_USAGER = clsOrgProspectsDTO.PR_USAGER.ToString() ;
                    clsOrgProspects.IN_CODEINGREDIENT = clsOrgProspectsDTO.IN_CODEINGREDIENT.ToString();

                    clsOrgProspects.PR_ESCOMPTE = clsOrgProspectsDTO.PR_ESCOMPTE.ToString();
                    //clsOrgProspects.ZN_CODEZONE = clsOrgProspectsDTO.ZN_CODEZONE.ToString();
                    //clsOrgProspects.RE_CODEREGIMEIMPOSITION = clsOrgProspectsDTO.RE_CODEREGIMEIMPOSITION.ToString();
                    //clsOrgProspects.SP_CODESPECIALITE = clsOrgProspectsDTO.SP_CODESPECIALITE.ToString();
                    //clsOrgProspects.QU_CODEQUARTIER = clsOrgProspectsDTO.QU_CODEQUARTIER.ToString();
                    //clsOrgProspects.PF_CODEPROFESSION = clsOrgProspectsDTO.PF_CODEPROFESSION.ToString();
                    //clsOrgProspects.PR_LIEUNAISSANCE = clsOrgProspectsDTO.PR_LIEUNAISSANCE.ToString();
                    //clsOrgProspects.PR_NUMTIERSRETOUR = clsOrgProspectsDTO.PR_NUMTIERSRETOUR.ToString();
                    clsOrgProspects.TYPEOPERATION = clsOrgProspectsDTO.TYPEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsOrgProspectsDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOrgProspectsDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsOrgProspectsWSBLL.pvgAjouter(clsDonnee, clsOrgProspects, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectss;
        }


        public List<HT_Stock.BOJ.clsOrgProspects> pvgSupprimer(List<HT_Stock.BOJ.clsOrgProspects> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                //--TEST CONTRAINTE
                clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE,  Objet[0].PR_IDTIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOrgProspectsWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOrgProspects> pvgChargerDansDataSetTiers(List<HT_Stock.BOJ.clsOrgProspects> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectss = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                //--TEST CONTRAINTE
                clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
            }

      
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].PR_STATUT, Objet[0].PR_NUMTIERS, Objet[0].PR_DENOMINATION, Objet[0].PR_DATESAISIE1, Objet[0].PR_DATESAISIE2, Objet[0].TP_CODETYPETIERS, Objet[0].SC_CODESECTION, Objet[0].PR_CLTVENTCAISSE, Objet[0].OP_CODEOPERATEUR,Objet[0].AP_CODEPRODUIT, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsOrgProspectsWSBLL.pvgChargerDansDataSetTiers(clsDonnee, clsObjetEnvoi);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {


                        string PR_PHOTOBASE64 = "";
                        string PR_SIGNATUREBASE64 = "";

                        HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                        clsOrgProspects.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsOrgProspects.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                        clsOrgProspects.CU_CODECASUTILISATION = row["CU_CODECASUTILISATION"].ToString();
                        clsOrgProspects.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                        clsOrgProspects.IN_CODEINGREDIENT = row["IN_CODEINGREDIENT"].ToString();
                        clsOrgProspects.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                        clsOrgProspects.NT_CODENATURETYPETIERS = row["NT_CODENATURETYPETIERS"].ToString();
                        clsOrgProspects.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        //clsOrgProspects.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsOrgProspects.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsOrgProspects.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                        //clsOrgProspects.RE_CODEREGIMEIMPOSITION = row["RE_CODEREGIMEIMPOSITION"].ToString();
                        clsOrgProspects.SC_CODESECTION = row["SC_CODESECTION"].ToString();
                       // clsOrgProspects.SP_CODESPECIALITE = row["SP_CODESPECIALITE"].ToString();
                        clsOrgProspects.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                        clsOrgProspects.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                        clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = row["PR_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsOrgProspects.PR_ADRESSEPOSTALE = row["PR_ADRESSEPOSTALE"].ToString();
                        clsOrgProspects.PR_ASDI = row["PR_ASDI"].ToString();

                        clsOrgProspects.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                        clsOrgProspects.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                        clsOrgProspects.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                        clsOrgProspects.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                        clsOrgProspects.VL_LIBELLE = row["VL_LIBELLE"].ToString();

                        if (row["PR_DATENAISSANCE"].ToString()!="")
                             clsOrgProspects.PR_DATENAISSANCE =DateTime.Parse(row["PR_DATENAISSANCE"].ToString()).ToShortDateString();
                        if (row["PR_DATEDEPART"].ToString() != "")
                            clsOrgProspects.PR_DATEDEPART = DateTime.Parse(row["PR_DATEDEPART"].ToString()).ToShortDateString();
                        if (row["PR_DATESAISIE"].ToString() != "")
                            clsOrgProspects.PR_DATESAISIE = DateTime.Parse(row["PR_DATESAISIE"].ToString()).ToShortDateString();

                        clsOrgProspects.PR_DENOMINATION = row["PR_DENOMINATION"].ToString();
                        clsOrgProspects.PR_DESCRIPTIONTIERS = row["PR_DESCRIPTIONTIERS"].ToString();
                        clsOrgProspects.PR_EMAIL = row["PR_EMAIL"].ToString();
                        clsOrgProspects.PR_ESCOMPTE = row["PR_ESCOMPTE"].ToString();
                        clsOrgProspects.PR_FAX = row["PR_FAX"].ToString();
                        clsOrgProspects.PR_GERANT = row["PR_GERANT"].ToString();
                        clsOrgProspects.PR_IDTIERS = row["PR_IDTIERS"].ToString();
                        clsOrgProspects.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        //clsOrgProspects.ZN_NOMZONE = row["ZN_NOMZONE"].ToString();
                        //clsOrgProspects.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                        clsOrgProspects.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsOrgProspects.PR_PLAFONDCREDIT = row["PR_PLAFONDCREDIT"].ToString();
                        clsOrgProspects.PR_TAUXREMISE = row["PR_TAUXREMISE"].ToString();

                        ////+++++++++++DEBUT PHOTO&SIGNATURE
                        //    clsOrgProspectsPhotoWSBLL clsOrgProspectsPhotoWSBLL = new clsOrgProspectsPhotoWSBLL();
                        //    Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhotoAffichage = new Stock.BOJ.clsOrgProspectsPhoto();
                        //    clsObjetEnvoi.OE_PARAM = new string[] { clsOrgProspects.AG_CODEAGENCE, clsOrgProspects.PR_IDTIERS };
                        //    clsOrgProspectsPhotoAffichage = clsOrgProspectsPhotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                        //    if(clsOrgProspectsPhotoAffichage!=null)
                        //    {
                        //    if (clsOrgProspectsPhotoAffichage.PR_PHOTO!=null)
                        //        PR_PHOTOBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_PHOTO);
                        //    if (clsOrgProspectsPhotoAffichage.PR_SIGNATURE != null)
                        //        PR_SIGNATUREBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_SIGNATURE);
                        //    }
                        //clsOrgProspects.PR_PHOTO = PR_PHOTOBASE64;
                        //clsOrgProspects.PR_SIGNATURE = PR_SIGNATUREBASE64;
                        ////+++++++++++FIN PHOTO&SIGNATURE






                        clsOrgProspects.PR_IDTIERSPRINCIPAL = row["PR_IDTIERSPRINCIPAL"].ToString();
                        clsOrgProspects.PR_MANDATAIRE = row["PR_MANDATAIRE"].ToString();
                        clsOrgProspects.PR_NUMCPTECONTIBUABLE = row["PR_NUMCPTECONTIBUABLE"].ToString();
                        clsOrgProspects.PR_NUMEROAGREMENT = row["PR_NUMEROAGREMENT"].ToString();
                        clsOrgProspects.PR_NUMTIERS = row["PR_NUMTIERS"].ToString();
                        if (row["PR_PLAFONDCREDIT"].ToString() != "")
                            clsOrgProspects.PR_PLAFONDCREDIT = Double.Parse(row["PR_PLAFONDCREDIT"].ToString()).ToString();
                        else
                            clsOrgProspects.PR_PLAFONDCREDIT = "0";

                        clsOrgProspects.PR_SIEGE = row["PR_SIEGE"].ToString();
                        clsOrgProspects.PR_SITEWEB = row["PR_SITEWEB"].ToString();
                        clsOrgProspects.PR_STATUT = row["PR_STATUT"].ToString();
                        clsOrgProspects.PR_STATUTDOUTEUX = row["PR_STATUTDOUTEUX"].ToString();
                        if (row["PR_TAUXDECLARATION"].ToString() != "")
                            clsOrgProspects.PR_TAUXDECLARATION = Double.Parse(row["PR_TAUXDECLARATION"].ToString()).ToString();
                        else
                            clsOrgProspects.PR_TAUXDECLARATION = "0";

                        if (row["PR_TAUXREMISE"].ToString() != "")
                            clsOrgProspects.PR_TAUXREMISE = Double.Parse(row["PR_TAUXREMISE"].ToString()).ToString();
                        else
                            clsOrgProspects.PR_TAUXREMISE = "0";
                        clsOrgProspects.PR_TELEPHONE = row["PR_TELEPHONE"].ToString();
                        //clsOrgProspects.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                        //clsOrgProspects.PR_LIEUNAISSANCE = row["PR_LIEUNAISSANCE"].ToString();
                        //clsOrgProspects.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                        clsOrgProspects.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsOrgProspects.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                        clsOrgProspects.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                        clsOrgProspects.AC_LIBELLE = row["AC_LIBELLE"].ToString();
                        clsOrgProspects.CU_LIBELLE = row["CU_LIBELLE"].ToString();
                        clsOrgProspects.RE_LIBELLEREGIMEIMPOSITION = row["RE_LIBELLEREGIMEIMPOSITION"].ToString();
                        clsOrgProspects.SP_LIBELLESPECIALITE = row["SP_LIBELLESPECIALITE"].ToString();
                        clsOrgProspects.GP_LIBELLE = row["GP_LIBELLE"].ToString();
                        clsOrgProspects.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                        clsOrgProspects.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                        clsOrgProspects.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                        clsOrgProspects.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                        clsOrgProspects.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                        clsOrgProspects.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                        clsOrgProspects.TC_LIBELLE = row["TC_LIBELLE"].ToString();

                        clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                        clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE ="00";
                        clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOrgProspects.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                        clsOrgProspectss.Add(clsOrgProspects);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }
                


            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }

        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            clsOrgProspectss.Add(clsOrgProspects);
        }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectss;
        }

            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOrgProspects> pvgChargerPhotoPropect(List<HT_Stock.BOJ.clsOrgProspects> Objet)
            {

                List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
                List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
           
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


                for (int Idx = 0; Idx < Objet.Count; Idx++)
                {
                    //--TEST DES CHAMPS OBLIGATOIRES
                    clsOrgProspectss = TestChampObligatoirePhotoProspect(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                    //--TEST CONTRAINTE
                    clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                }

      
                clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].PR_STATUT, Objet[0].PR_NUMTIERS, Objet[0].PR_DENOMINATION, Objet[0].PR_DATESAISIE1, Objet[0].PR_DATESAISIE2, Objet[0].TP_CODETYPETIERS, Objet[0].SC_CODESECTION, Objet[0].PR_CLTVENTCAISSE, Objet[0].OP_CODEOPERATEUR,Objet[0].AP_CODEPRODUIT, Objet[0].TYPEOPERATION };
                DataSet DataSet = new DataSet();

                try
                {
                    clsDonnee.pvgConnectionBase();
                    DataSet = clsOrgProspectsWSBLL.pvgChargerDansDataSetTiers(clsDonnee, clsObjetEnvoi);
                    clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                    if (DataSet.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {


                            string PR_PHOTOBASE64 = "";
                            string PR_SIGNATUREBASE64 = "";

                            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                            clsOrgProspects.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsOrgProspects.PR_IDTIERS = row["PR_IDTIERS"].ToString();
                            clsOrgProspects.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();

                        //+++++++++++DEBUT PHOTO&SIGNATURE
                        clsOrgProspectsPhotoWSBLL clsOrgProspectsPhotoWSBLL = new clsOrgProspectsPhotoWSBLL();
                        Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhotoAffichage = new Stock.BOJ.clsOrgProspectsPhoto();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsOrgProspects.AG_CODEAGENCE, clsOrgProspects.PR_IDTIERS };
                        clsOrgProspectsPhotoAffichage = clsOrgProspectsPhotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                        if (clsOrgProspectsPhotoAffichage != null)
                        {
                            if (clsOrgProspectsPhotoAffichage.PR_PHOTO != null)
                                PR_PHOTOBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_PHOTO);
                            if (clsOrgProspectsPhotoAffichage.PR_SIGNATURE != null)
                                PR_SIGNATUREBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_SIGNATURE);
                        }
                        clsOrgProspects.PR_PHOTO = PR_PHOTOBASE64;
                        clsOrgProspects.PR_SIGNATURE = PR_SIGNATUREBASE64;
                        //+++++++++++FIN PHOTO&SIGNATURE

                        clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                        clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE ="00";
                        clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOrgProspects.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                        clsOrgProspectss.Add(clsOrgProspects);
                        }
                    }
                    else
                    {
                        HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                        clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                        clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                        clsOrgProspectss.Add(clsOrgProspects);
                    }
                


                }
                catch (SqlException SQLEx)
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                    clsOrgProspectss.Add(clsOrgProspects);
                }

            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }


                finally
                {
                    clsDonnee.pvgDeConnectionBase();
                }
                return clsOrgProspectss;
            }




            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOrgProspects> pvgChargerRechercheTiersparNom(List<HT_Stock.BOJ.clsOrgProspects> Objet)
            {

                List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
                List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
           
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


                for (int Idx = 0; Idx < Objet.Count; Idx++)
                {
                    //--TEST DES CHAMPS OBLIGATOIRES
                    clsOrgProspectss = TestChampObligatoireListe(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                    //--TEST CONTRAINTE
                    clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].PR_NUMTIERS, Objet[0].PR_DENOMINATION, Objet[0].TP_CODETYPETIERS };//,   Objet[0].SC_CODESECTION,  Objet[0].PR_CLTVENTCAISSE};
                DataSet DataSet = new DataSet();

                try
                {
                    clsDonnee.pvgConnectionBase();
                    DataSet = clsOrgProspectsWSBLL.pvgChargerRechercheTiersparNom(clsDonnee, clsObjetEnvoi);
                    clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                    if (DataSet.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {


                            string PR_PHOTOBASE64 = "";
                            string PR_SIGNATUREBASE64 = "";

                            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                            clsOrgProspects.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsOrgProspects.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                            clsOrgProspects.CU_CODECASUTILISATION = row["CU_CODECASUTILISATION"].ToString();
                            clsOrgProspects.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                            //clsOrgProspects.IN_CODEINGREDIENT = row["IN_CODEINGREDIENT"].ToString();
                            clsOrgProspects.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                            clsOrgProspects.NT_CODENATURETYPETIERS = row["NT_CODENATURETYPETIERS"].ToString();
                            clsOrgProspects.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                            //clsOrgProspects.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                            clsOrgProspects.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                            clsOrgProspects.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                            //clsOrgProspects.RE_CODEREGIMEIMPOSITION = row["RE_CODEREGIMEIMPOSITION"].ToString();
                            //clsOrgProspects.SC_CODESECTION = row["SC_CODESECTION"].ToString();
                            //clsOrgProspects.SP_CODESPECIALITE = row["SP_CODESPECIALITE"].ToString();
                            //clsOrgProspects.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                            //clsOrgProspects.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                            //clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = row["PR_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsOrgProspects.PR_ADRESSEPOSTALE = row["PR_ADRESSEPOSTALE"].ToString();
                            clsOrgProspects.PR_ASDI = row["PR_ASDI"].ToString();

                            if (row["PR_DATENAISSANCE"].ToString()!="")
                                    clsOrgProspects.PR_DATENAISSANCE =DateTime.Parse(row["PR_DATENAISSANCE"].ToString()).ToShortDateString();
                            if (row["PR_DATEDEPART"].ToString() != "")
                                clsOrgProspects.PR_DATEDEPART = DateTime.Parse(row["PR_DATEDEPART"].ToString()).ToShortDateString();
                            if (row["PR_DATESAISIE"].ToString() != "")
                                clsOrgProspects.PR_DATESAISIE = DateTime.Parse(row["PR_DATESAISIE"].ToString()).ToShortDateString();

                            clsOrgProspects.PR_DENOMINATION = row["PR_DENOMINATION"].ToString();
                            clsOrgProspects.PR_DESCRIPTIONTIERS = row["PR_DESCRIPTIONTIERS"].ToString();
                            //clsOrgProspects.PR_EMAIL = row["PR_EMAIL"].ToString();
                            //clsOrgProspects.PR_ESCOMPTE = row["PR_ESCOMPTE"].ToString();
                            //clsOrgProspects.PR_FAX = row["PR_FAX"].ToString();
                            //clsOrgProspects.PR_GERANT = row["PR_GERANT"].ToString();
                            clsOrgProspects.PR_IDTIERS = row["PR_IDTIERS"].ToString();
                            ////+++++++++++DEBUT PHOTO&SIGNATURE
                            //    clsOrgProspectsPhotoWSBLL clsOrgProspectsPhotoWSBLL = new clsOrgProspectsPhotoWSBLL();
                            //    Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhotoAffichage = new Stock.BOJ.clsOrgProspectsPhoto();
                            //    clsObjetEnvoi.OE_PARAM = new string[] { clsOrgProspects.AG_CODEAGENCE, clsOrgProspects.PR_IDTIERS };
                            //    clsOrgProspectsPhotoAffichage = clsOrgProspectsPhotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                            //    if(clsOrgProspectsPhotoAffichage!=null)
                            //    {
                            //    if (clsOrgProspectsPhotoAffichage.PR_PHOTO!=null)
                            //        PR_PHOTOBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_PHOTO);
                            //    if (clsOrgProspectsPhotoAffichage.PR_SIGNATURE != null)
                            //        PR_SIGNATUREBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_SIGNATURE);
                            //    }
                            //clsOrgProspects.PR_PHOTO = PR_PHOTOBASE64;
                            //clsOrgProspects.PR_SIGNATURE = PR_SIGNATUREBASE64;
                            ////+++++++++++FIN PHOTO&SIGNATURE






                            clsOrgProspects.PR_IDTIERSPRINCIPAL = row["PR_IDTIERSPRINCIPAL"].ToString();
                            //clsOrgProspects.PR_MANDATAIRE = row["PR_MANDATAIRE"].ToString();
                            //clsOrgProspects.PR_NUMCPTECONTIBUABLE = row["PR_NUMCPTECONTIBUABLE"].ToString();
                            //clsOrgProspects.PR_NUMEROAGREMENT = row["PR_NUMEROAGREMENT"].ToString();
                            clsOrgProspects.PR_NUMTIERS = row["PR_NUMTIERS"].ToString();
                            if (row["PR_PLAFONDCREDIT"].ToString() != "")
                                clsOrgProspects.PR_PLAFONDCREDIT = Double.Parse(row["PR_PLAFONDCREDIT"].ToString()).ToString();
                            else
                                clsOrgProspects.PR_PLAFONDCREDIT = "0";

                            //clsOrgProspects.PR_SIEGE = row["PR_SIEGE"].ToString();
                            //clsOrgProspects.PR_SITEWEB = row["PR_SITEWEB"].ToString();
                            //clsOrgProspects.PR_STATUT = row["PR_STATUT"].ToString();
                            //clsOrgProspects.PR_STATUTDOUTEUX = row["PR_STATUTDOUTEUX"].ToString();
                            //if (row["PR_TAUXDECLARATION"].ToString() != "")
                            //    clsOrgProspects.PR_TAUXDECLARATION = Double.Parse(row["PR_TAUXDECLARATION"].ToString()).ToString();
                            //else
                            //    clsOrgProspects.PR_TAUXDECLARATION = "0";

                            if (row["PR_TAUXREMISE"].ToString() != "")
                                clsOrgProspects.PR_TAUXREMISE = Double.Parse(row["PR_TAUXREMISE"].ToString()).ToString();
                            else
                                clsOrgProspects.PR_TAUXREMISE = "0";
                            clsOrgProspects.PR_TELEPHONE = row["PR_TELEPHONE"].ToString();
                            //clsOrgProspects.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                            //clsOrgProspects.PR_LIEUNAISSANCE = row["PR_LIEUNAISSANCE"].ToString();
                            //clsOrgProspects.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                            //clsOrgProspects.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                            //clsOrgProspects.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                            //clsOrgProspects.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                            //clsOrgProspects.AC_LIBELLE = row["AC_LIBELLE"].ToString();
                            //clsOrgProspects.CU_LIBELLE = row["CU_LIBELLE"].ToString();
                            //clsOrgProspects.RE_LIBELLEREGIMEIMPOSITION = row["RE_LIBELLEREGIMEIMPOSITION"].ToString();
                            //clsOrgProspects.SP_LIBELLESPECIALITE = row["SP_LIBELLESPECIALITE"].ToString();
                            //clsOrgProspects.GP_LIBELLE = row["GP_LIBELLE"].ToString();
                            clsOrgProspects.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                            //clsOrgProspects.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                            //clsOrgProspects.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                            //clsOrgProspects.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                            //clsOrgProspects.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                            //clsOrgProspects.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                            //clsOrgProspects.TC_LIBELLE = row["TC_LIBELLE"].ToString();

                            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE ="00";
                            clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsOrgProspects.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                            clsOrgProspectss.Add(clsOrgProspects);
                        }
                    }
                    else
                    {
                        HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                        clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                        clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                        clsOrgProspectss.Add(clsOrgProspects);
                    }
                


                }
                catch (SqlException SQLEx)
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                    clsOrgProspectss.Add(clsOrgProspects);
                }

            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }


                finally
                {
                    clsDonnee.pvgDeConnectionBase();
                }
                return clsOrgProspectss;
            }




    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsOrgProspects> pvgChargerDansDataSetPourComboSelonNaturetypetiers(List<HT_Stock.BOJ.clsOrgProspects> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsOrgProspectss = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
            //--TEST CONTRAINTE
            clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NT_CODENATURETYPETIERS };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOrgProspectsWSBLL.pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee, clsObjetEnvoi);
            clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.PR_IDTIERS = row["PR_IDTIERS"].ToString();
                    clsOrgProspects.PR_DENOMINATION = row["PR_DENOMINATION"].ToString();
                    clsOrgProspects.PR_NUMTIERS = row["PR_NUMTIERS"].ToString();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOrgProspectss.Add(clsOrgProspects);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            clsOrgProspectss.Add(clsOrgProspects);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspects.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            clsOrgProspectss.Add(clsOrgProspects);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOrgProspectss;
    }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOrgProspects> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOrgProspects> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectss = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                //--TEST CONTRAINTE
                clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NT_CODENATURETYPETIERS };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsOrgProspectsWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                        clsOrgProspects.PR_IDTIERS = row["PR_IDTIERS"].ToString();
                        clsOrgProspects.PR_DENOMINATION = row["PR_DENOMINATION"].ToString();
                        clsOrgProspects.PR_NUMTIERS = row["PR_NUMTIERS"].ToString();
                        clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                        clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsOrgProspectss.Add(clsOrgProspects);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOrgProspects> pvgSoldeGlobalReglement(List<HT_Stock.BOJ.clsOrgProspects> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectss = TestChampObligatoireListeSolde(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
                //--TEST CONTRAINTE
                clsOrgProspectss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].PR_NUMTIERS, Objet[0].DATEDEBUT };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                string vlpSolde = "0";
                clsPhamouvementstockreglementcommercialWSBLL clsPhamouvementstockreglementcommercialWSBLL = new clsPhamouvementstockreglementcommercialWSBLL();
                vlpSolde=clsPhamouvementstockreglementcommercialWSBLL.pvgSoldeGlobalReglement(clsDonnee, clsObjetEnvoi);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                if (vlpSolde != "")
                {
                    
                        HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                        //clsOrgProspects.SOLDE = vlpSolde;
                        clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                        clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsOrgProspectss.Add(clsOrgProspects);

                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                    clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOrgProspectss.Add(clsOrgProspects);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
                clsOrgProspectss.Add(clsOrgProspects);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectss;
        }



    }
}
