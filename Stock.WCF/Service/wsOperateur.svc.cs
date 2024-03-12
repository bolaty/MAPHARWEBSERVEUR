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
using System.Web;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOperateur" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOperateur.svc ou wsOperateur.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOperateur : IwsOperateur
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOperateurWSBLL clsOperateurWSBLL = new clsOperateurWSBLL();

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
    public List<HT_Stock.BOJ.clsOperateur> pvgChargerDansDataSetLOGIN(List<HT_Stock.BOJ.clsOperateur> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();

            string vlpEX_EXERCICE = "";



            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsOperateurs = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            //--TEST CONTRAINTE
            clsOperateurs = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
        }
            //Objet[0].OP_MOTPASSE = "123";
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].OP_LOGIN,Objet[0].OP_MOTPASSE,Objet[0].TYPEOPERATION };
        DataSet DataSet = new DataSet();


        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurWSBLL.pvgChargerDansDataSetLOGIN(clsDonnee, clsObjetEnvoi);
            clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {

                   Stock.BOJ.clsParametre clsParametre = new Stock.BOJ.clsParametre();
                    clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi1 = new Stock.BOJ.clsObjetEnvoi();
                    string[] stringArray2 = { "URLS" };
                    clsObjetEnvoi1.OE_PARAM = stringArray2;
                    string URLDOC = @clsParametreWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi1).PP_VALEUR;


                    foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();

                    //if (Objet[0].TYPEOPERATION == "01")
                    //{
                            clsOperateur.OP_CODEOPERATEUR = row["CL_IDCLIENT"].ToString();
                            clsOperateur.OP_NOMPRENOM = row["CL_NOMCLIENT"].ToString();
                            clsOperateur.OP_TELEPHONE = row["CL_TELEPHONE"].ToString();
                            clsOperateur.OP_EMAIL = row["CL_EMAIL"].ToString();
                            clsOperateur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsOperateur.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                            clsOperateur.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
                            clsOperateur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                            clsOperateur.PL_CODENUMCOMPTECOFFREFORT = row["PL_CODENUMCOMPTECOFFREFORT"].ToString();
                            clsOperateur.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                            clsOperateur.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                            clsOperateur.PL_NUMCOMPTECOFFREFORT = row["PL_NUMCOMPTECOFFREFORT"].ToString();
                        clsOperateur.PP_LONGUEUR_DES_COMPTES_IMPUTABLES = row["PP_LONGUEUR_DES_COMPTES_IMPUTABLES"].ToString();
                        clsOperateur.EX_DATEDEBUT = row["EX_DATEDEBUT"].ToString();
                            clsOperateur.SL_NOMBRECONNECTION = row["SL_NOMBRECONNECTION"].ToString();
                            clsOperateur.SL_CLESESSION = row["SL_CLESESSION"].ToString();
                            clsOperateur.SL_URL_NOTIFICATION = row["SL_URL_NOTIFICATION"].ToString();
                            clsOperateur.SL_API_KEY = row["SL_API_KEY"].ToString();
                            clsOperateur.SL_SITE_ID = row["SL_SITE_ID"].ToString();
                            clsOperateur.TK_TOKEN = row["TK_TOKEN"].ToString();
                            clsOperateur.SL_MESSAGECLIENT = row["SL_MESSAGECLIENT"].ToString();
                            clsOperateur.SL_MESSAGEOBJET = row["SL_MESSAGEOBJET"].ToString();
                            clsOperateur.CL_CODECLIENT = row["CL_CODECLIENT"].ToString();
                            clsOperateur.OP_LOGIN = row["SL_LOGIN"].ToString();
                            clsOperateur.OP_MOTPASSE = row["SL_MOTPASSE"].ToString();
                            clsOperateur.PY_CODEPAYS_REF = row["PY_CODEPAYS_REF"].ToString();
                            clsOperateur.VL_CODEVILLE_REF = row["VL_CODEVILLE_REF"].ToString();


                        //private string _PY_CODEPAYS_REF = "";
                        //private string _VL_CODEVILLE_REF = "";

                        clsOperateur.OP_CODEOPERATEURGESTIONNAIRE = row["OP_CODEOPERATEURGESTIONNAIRE"].ToString();
                            clsOperateur.URL_DOC_SINISTRES_AUTOMOBILE = URLDOC + "Fiche_de_declaration_Auto.pdf";
                            clsOperateur.URL_DOC_SINISTRES_RISQUE = URLDOC + "Fiche_de_declaration_R_D.pdf";

                        //private string _EX_DATEDEBUT = "";
                        //private string _SL_NOMBRECONNECTION = "";
                        //private string _SL_CLESESSION = "";
                        //private string _SL_URL_NOTIFICATION = "";
                        //private string _SL_API_KEY = "";
                        //private string _SL_SITE_ID = "";
                        //private string _TK_TOKEN = "";
                        //private string _SL_MESSAGECLIENT = "";
                        //private string _SL_MESSAGEOBJET = "";


                        //}
                        //if (Objet[0].TYPEOPERATION == "02")
                        //{
                        //        clsOperateur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        //        clsOperateur.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        //        clsOperateur.OP_TELEPHONE = row["OP_TELEPHONE"].ToString();
                        //        clsOperateur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        //        clsOperateur.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        //        clsOperateur.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
                        //        clsOperateur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        //        clsOperateur.PL_CODENUMCOMPTECOFFREFORT = row["PL_CODENUMCOMPTECOFFREFORT"].ToString();
                        //        clsOperateur.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                        //        clsOperateur.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        //        clsOperateur.PL_NUMCOMPTECOFFREFORT = row["PL_NUMCOMPTECOFFREFORT"].ToString();
                        //    }


                        //=========Debut Agence encours
                        clsAgenceWSBLL clsAgenceWSBLL = new clsAgenceWSBLL();

                        List<HT_Stock.BOJ.clsAgence> clsAgences = new List<HT_Stock.BOJ.clsAgence>();
                        DataSet DataSetAgence = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsOperateur.SO_CODESOCIETE, clsOperateur.AG_CODEAGENCE };
                        DataSetAgence = clsAgenceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                        if (DataSetAgence.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rowAgence in DataSetAgence.Tables[0].Rows)
                            {
                                HT_Stock.BOJ.clsAgence clsAgence = new HT_Stock.BOJ.clsAgence();
                                clsAgence.AG_CODEAGENCE = rowAgence["AG_CODEAGENCE"].ToString();
                                clsAgence.AG_RAISONSOCIAL = rowAgence["AG_RAISONSOCIAL"].ToString();
                                clsAgence.AG_TELEPHONE = rowAgence["AG_TELEPHONE"].ToString();
                                clsAgence.AG_BOITEPOSTAL = rowAgence["AG_BOITEPOSTAL"].ToString();
                                clsAgence.AG_EMAIL = rowAgence["AG_EMAIL"].ToString();
                                clsAgence.OP_CODEOPERATEUR = rowAgence["OP_CODEOPERATEUR"].ToString();
                                clsAgence.ENTETE1 = clsAgence.AG_RAISONSOCIAL;
                                clsAgence.ENTETE2= clsAgence.AG_BOITEPOSTAL;
                                clsAgence.ENTETE3 = clsAgence.AG_TELEPHONE;
                                clsAgence.ENTETE4 = clsAgence.AG_EMAIL;



                                clsAgences.Add(clsAgence);
                            }
                        }
                        //=========Fin Agence encours

                       

                        //=========Debut Exo encours
                        clsExerciceWSBLL clsExerciceWSBLL = new clsExerciceWSBLL();
                        List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                        DataSet DataSetEXO = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsOperateur.AG_CODEAGENCE };
                        DataSetEXO = clsExerciceWSBLL.pvgChargerDansDataSetExerciceEncours(clsDonnee, clsObjetEnvoi);
                        if (DataSetEXO.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rowEXO in DataSetEXO.Tables[0].Rows)
                            {
                                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                                clsExercice.AG_CODEAGENCE = rowEXO["AG_CODEAGENCE"].ToString();
                                clsExercice.EX_EXERCICE = rowEXO["EX_EXERCICE"].ToString();
                                vlpEX_EXERCICE = rowEXO["EX_EXERCICE"].ToString();
                                clsExercice.JT_DATEJOURNEETRAVAIL = rowEXO["JT_DATEJOURNEETRAVAIL"].ToString();
                                clsExercice.EX_DATEDEBUT = rowEXO["EX_DATEDEBUT"].ToString();
                                clsExercice.EX_DATEFIN = rowEXO["EX_DATEDEBUT"].ToString();
                                clsExercice.EX_DESCEXERCICE = rowEXO["EX_DESCEXERCICE"].ToString();
                                clsExercice.EX_ETATEXERCICE = rowEXO["EX_ETATEXERCICE"].ToString();
                                clsExercice.EX_DATESAISIE = rowEXO["EX_DATESAISIE"].ToString();
                                clsExercice.JT_DATEDEBUTPREMIEREXERCICE = clsExerciceWSBLL.pvgValeurScalaireRequeteMin1(clsDonnee, clsObjetEnvoi);
                                clsExercice.JT_DATEDEBUTPREMIEREXERCICE = DateTime.Parse(clsExercice.JT_DATEDEBUTPREMIEREXERCICE).ToShortDateString();
                                clsExercice.EX_DATEAFFECTATIONRESULTAT = rowEXO["EX_DATEAFFECTATIONRESULTAT"].ToString();
                                clsExercices.Add(clsExercice);
                            }
                        }
                        //=========Fin Exo encours

                        //=========Debut Journee encours
                        clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();

                        List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();

                        DataSet DataSetJOURNEE = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsOperateur.AG_CODEAGENCE, vlpEX_EXERCICE };
                        DataSetJOURNEE = clsJourneetravailWSBLL.pvgChargerDansDataSetJourneeEncours(clsDonnee, clsObjetEnvoi);
                        if (DataSetJOURNEE.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rowJOURNEE in DataSetJOURNEE.Tables[0].Rows)
                            {
                                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                                clsJourneetravail.AG_CODEAGENCE = rowJOURNEE["AG_CODEAGENCE"].ToString();
                                clsJourneetravail.JT_DATEJOURNEETRAVAIL = (rowJOURNEE["JT_DATEJOURNEETRAVAIL"].ToString() != "") ? DateTime.Parse(rowJOURNEE["JT_DATEJOURNEETRAVAIL"].ToString()).ToShortDateString().Replace("/", "-") : "";
                                clsJourneetravail.JT_STATUT = rowJOURNEE["JT_STATUT"].ToString();
                                clsJourneetravail.OP_CODEOPERATEUR = rowJOURNEE["OP_CODEOPERATEUR"].ToString();
                                clsJourneetravails.Add(clsJourneetravail);
                            }
                        }
                        //=========Fin Journee encours

                        clsOperateur.clsAgences = clsAgences;
                        clsOperateur.clsJourneetravails=clsJourneetravails;
                        clsOperateur.clsExercices = clsExercices;
                        clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                        clsOperateur.clsObjetRetour.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();
                        clsOperateur.clsObjetRetour.SL_RESULTAT = row["SL_RESULTAT"].ToString();
                        clsOperateur.clsObjetRetour.SL_MESSAGE = row["SL_MESSAGE"].ToString();
                        clsOperateurs.Add(clsOperateur);
                }

                    
                }
            else
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "Login ou mot de passe invalide !!!";
                clsOperateurs.Add(clsOperateur);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            clsOperateurs.Add(clsOperateur);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            
            clsOperateurs.Add(clsOperateur);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
            
            return clsOperateurs;
    }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgAjouter(List<HT_Stock.BOJ.clsOperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateur clsOperateurDTO in Objet)
                {
                    Stock.BOJ.clsOperateurphoto clsOperateurphoto = new Stock.BOJ.clsOperateurphoto();
                    Byte[] OH_PHOTO = null;
                    Byte[] OH_SIGNATURE = null;
                    if (clsOperateurDTO.OH_PHOTO != "")
                        OH_PHOTO = System.Convert.FromBase64String(clsOperateurDTO.OH_PHOTO);
                    if (clsOperateurDTO.OH_SIGNATURE != "")
                        OH_SIGNATURE = System.Convert.FromBase64String(clsOperateurDTO.OH_SIGNATURE);


                    Stock.BOJ.clsOperateur clsOperateur = new Stock.BOJ.clsOperateur();
                    clsOperateur.SO_CODESOCIETE = clsOperateurDTO.SO_CODESOCIETE.ToString();
                    clsOperateur.AG_CODEAGENCE = clsOperateurDTO.AG_CODEAGENCE.ToString();
                    clsOperateur.PO_CODEPROFIL = clsOperateurDTO.PO_CODEPROFIL.ToString();
                    clsOperateur.TO_CODETYPEOERATEUR = clsOperateurDTO.TO_CODETYPEOERATEUR.ToString();
                    clsOperateur.PL_CODENUMCOMPTE = clsOperateurDTO.PL_CODENUMCOMPTE.ToString();
                    clsOperateur.PL_CODENUMCOMPTECOFFREFORT = clsOperateurDTO.PL_CODENUMCOMPTECOFFREFORT.ToString();
                    
                    clsOperateur.PL_NUMCOMPTE = clsOperateurDTO.PL_NUMCOMPTE.ToString();
                    clsOperateur.PL_NUMCOMPTECOFFREFORT = clsOperateurDTO.PL_NUMCOMPTECOFFREFORT.ToString();


                    clsOperateur.OP_NOMPRENOM = clsOperateurDTO.OP_NOMPRENOM.ToString();
                    clsOperateur.OP_LOGIN = clsOperateurDTO.OP_LOGIN.ToString();
                    clsOperateur.OP_MOTPASSE = clsOperateurDTO.OP_MOTPASSE.ToString();
                    clsOperateur.OP_ACTIF = clsOperateurDTO.OP_ACTIF.ToString();
                    clsOperateur.OP_TELEPHONE = clsOperateurDTO.OP_TELEPHONE.ToString();
                    clsOperateur.OP_EMAIL = clsOperateurDTO.OP_EMAIL.ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = clsOperateurDTO.OP_JOURNEEOUVERTE.ToString();
                    clsOperateur.OP_DATESAISIE =DateTime.Parse(clsOperateurDTO.OP_DATESAISIE.ToString());
                    clsOperateur.OP_GESTIONNAIRE = clsOperateurDTO.OP_GESTIONNAIRE.ToString();
                    clsOperateur.OP_CAISSIER = clsOperateurDTO.OP_CAISSIER.ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUE = clsOperateurDTO.OP_IMPRESSIONAUTOMATIQUE.ToString();
                    clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE =double.Parse(clsOperateurDTO.OP_MONTANTTOTALENCAISSEAUTORISE.ToString());
                    clsOperateur.EN_CODEENTREPOT = clsOperateurDTO.EN_CODEENTREPOT.ToString();
                    clsOperateur.TI_IDTIERS = clsOperateurDTO.TI_IDTIERS.ToString();
                    clsOperateur.OP_EXTOURNE = clsOperateurDTO.OP_EXTOURNE.ToString();
                    clsOperateur.OP_CREATIONJOURNE = clsOperateurDTO.OP_CREATIONJOURNE.ToString();
                    clsOperateur.OP_FERMETUREJOURNE = clsOperateurDTO.OP_FERMETUREJOURNE.ToString();
                    clsOperateur.SR_CODESERVICE = clsOperateurDTO.SR_CODESERVICE.ToString();
                    clsOperateur.OP_CREATIONPROFILE = clsOperateurDTO.OP_CREATIONPROFILE.ToString();
                    clsOperateur.OP_CREATIONOPERATEUR = clsOperateurDTO.OP_CREATIONOPERATEUR.ToString();
                    clsOperateur.OP_SELECTIONOPERATEURAPPRO = clsOperateurDTO.OP_SELECTIONOPERATEURAPPRO.ToString();
                    clsOperateur.OP_SELECTIONOPERATEURVENTE = clsOperateurDTO.OP_SELECTIONOPERATEURVENTE.ToString();
                    clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD = clsOperateurDTO.OP_CONTREPARTIEAUTOMATIQUEOD.ToString();
                    clsOperateur.OP_CODEOPERATEUR = clsOperateurDTO.OP_CODEOPERATEUR.ToString();

                    clsOperateurphoto.OH_PHOTO = OH_PHOTO;
                    clsOperateurphoto.OH_SIGNATURE = OH_SIGNATURE;

                    clsObjetEnvoi.OE_A = clsOperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurDTO.clsObjetEnvoi.OE_Y;
                    //pvgAjouterOperateurPhoto(clsDonnee clsDonnee, clsOperateur clsOperateur, clsOperateurphoto clsOperateurphoto, clsObjetEnvoi clsObjetEnvoi)

                    clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgAjouterOperateurPhoto(clsDonnee, clsOperateur, clsOperateurphoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                    //clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgAjouter(clsDonnee, clsOperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurs.Add(clsOperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgModifierOP_MOTPASSE(List<HT_Stock.BOJ.clsOperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurs = TestChampObligatoireChangerMotDePasse(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateur clsOperateurDTO in Objet)
                {
                    Stock.BOJ.clsOperateurphoto clsOperateurphoto = new Stock.BOJ.clsOperateurphoto();

                    Stock.BOJ.clsOperateur clsOperateur = new Stock.BOJ.clsOperateur();
                    clsOperateur.AG_CODEAGENCE = clsOperateurDTO.AG_CODEAGENCE.ToString();
                    clsOperateur.OP_CODEOPERATEUR = clsOperateurDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateur.OP_MOTPASSE = clsOperateurDTO.OP_MOTPASSE.ToString();

                    clsObjetEnvoi.OE_A = clsOperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurDTO.clsObjetEnvoi.OE_Y;
                    //pvgAjouterOperateurPhoto(clsDonnee clsDonnee, clsOperateur clsOperateur, clsOperateurphoto clsOperateurphoto, clsObjetEnvoi clsObjetEnvoi)

                    clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgModifierOP_MOTPASSE(clsDonnee, clsOperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                    //clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgAjouter(clsDonnee, clsOperateur, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurs.Add(clsOperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgModifier(List<HT_Stock.BOJ.clsOperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateur clsOperateurDTO in Objet)
                {
                    Stock.BOJ.clsOperateurphoto clsOperateurphoto = new Stock.BOJ.clsOperateurphoto();
                    Byte[] OH_PHOTO = null;
                    Byte[] OH_SIGNATURE = null;
                    if (clsOperateurDTO.OH_PHOTO != "")
                        OH_PHOTO = System.Convert.FromBase64String(clsOperateurDTO.OH_PHOTO);
                    if (clsOperateurDTO.OH_SIGNATURE != "")
                        OH_SIGNATURE = System.Convert.FromBase64String(clsOperateurDTO.OH_SIGNATURE);


                    Stock.BOJ.clsOperateur clsOperateur = new Stock.BOJ.clsOperateur();
                    clsOperateur.SO_CODESOCIETE = clsOperateurDTO.SO_CODESOCIETE.ToString();
                    clsOperateur.AG_CODEAGENCE = clsOperateurDTO.AG_CODEAGENCE.ToString();
                    clsOperateur.PO_CODEPROFIL = clsOperateurDTO.PO_CODEPROFIL.ToString();
                    clsOperateur.TO_CODETYPEOERATEUR = clsOperateurDTO.TO_CODETYPEOERATEUR.ToString();
                    clsOperateur.PL_CODENUMCOMPTE = clsOperateurDTO.PL_CODENUMCOMPTE.ToString();
                    clsOperateur.PL_CODENUMCOMPTECOFFREFORT = clsOperateurDTO.PL_CODENUMCOMPTECOFFREFORT.ToString();


                    clsOperateur.PL_NUMCOMPTE = clsOperateurDTO.PL_NUMCOMPTE.ToString();
                    clsOperateur.PL_NUMCOMPTECOFFREFORT = clsOperateurDTO.PL_NUMCOMPTECOFFREFORT.ToString();

                    clsOperateur.OP_NOMPRENOM = clsOperateurDTO.OP_NOMPRENOM.ToString();
                    clsOperateur.OP_LOGIN = clsOperateurDTO.OP_LOGIN.ToString();
                    clsOperateur.OP_MOTPASSE = clsOperateurDTO.OP_MOTPASSE.ToString();
                    clsOperateur.OP_ACTIF = clsOperateurDTO.OP_ACTIF.ToString();
                    clsOperateur.OP_TELEPHONE = clsOperateurDTO.OP_TELEPHONE.ToString();
                    clsOperateur.OP_EMAIL = clsOperateurDTO.OP_EMAIL.ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = clsOperateurDTO.OP_JOURNEEOUVERTE.ToString();
                    clsOperateur.OP_DATESAISIE = DateTime.Parse(clsOperateurDTO.OP_DATESAISIE.ToString());
                    clsOperateur.OP_GESTIONNAIRE = clsOperateurDTO.OP_GESTIONNAIRE.ToString();
                    clsOperateur.OP_CAISSIER = clsOperateurDTO.OP_CAISSIER.ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUE = clsOperateurDTO.OP_IMPRESSIONAUTOMATIQUE.ToString();
                    clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE = double.Parse(clsOperateurDTO.OP_MONTANTTOTALENCAISSEAUTORISE.ToString());
                    clsOperateur.EN_CODEENTREPOT = clsOperateurDTO.EN_CODEENTREPOT.ToString();
                    clsOperateur.TI_IDTIERS = clsOperateurDTO.TI_IDTIERS.ToString();
                    clsOperateur.OP_EXTOURNE = clsOperateurDTO.OP_EXTOURNE.ToString();
                    clsOperateur.OP_CREATIONJOURNE = clsOperateurDTO.OP_CREATIONJOURNE.ToString();
                    clsOperateur.OP_FERMETUREJOURNE = clsOperateurDTO.OP_FERMETUREJOURNE.ToString();
                    clsOperateur.SR_CODESERVICE = clsOperateurDTO.SR_CODESERVICE.ToString();
                    clsOperateur.OP_CREATIONPROFILE = clsOperateurDTO.OP_CREATIONPROFILE.ToString();
                    clsOperateur.OP_CREATIONOPERATEUR = clsOperateurDTO.OP_CREATIONOPERATEUR.ToString();
                    clsOperateur.OP_SELECTIONOPERATEURAPPRO = clsOperateurDTO.OP_SELECTIONOPERATEURAPPRO.ToString();
                    clsOperateur.OP_SELECTIONOPERATEURVENTE = clsOperateurDTO.OP_SELECTIONOPERATEURVENTE.ToString();
                    clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD = clsOperateurDTO.OP_CONTREPARTIEAUTOMATIQUEOD.ToString();
                    clsOperateur.OP_CODEOPERATEUR = clsOperateurDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurphoto.OH_PHOTO = OH_PHOTO;
                    clsOperateurphoto.OH_SIGNATURE = OH_SIGNATURE;

                    clsObjetEnvoi.OE_A = clsOperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurDTO.clsObjetEnvoi.OE_Y;
                   // clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgModifierOperateurPhoto(clsDonnee, clsOperateur,  clsOperateurphoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurs.Add(clsOperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgModifierOperateurPhoto(List<HT_Stock.BOJ.clsOperateur> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateur clsOperateurDTO in Objet)
                {
                    Stock.BOJ.clsOperateurphoto clsOperateurphoto = new Stock.BOJ.clsOperateurphoto();
                    Byte[] OH_PHOTO = null;
                    Byte[] OH_SIGNATURE = null;
                    if (clsOperateurDTO.OH_PHOTO != "")
                        OH_PHOTO = System.Convert.FromBase64String(clsOperateurDTO.OH_PHOTO);
                    if (clsOperateurDTO.OH_SIGNATURE != "")
                        OH_SIGNATURE = System.Convert.FromBase64String(clsOperateurDTO.OH_SIGNATURE);


                    Stock.BOJ.clsOperateur clsOperateur = new Stock.BOJ.clsOperateur();
                    clsOperateur.AG_CODEAGENCE = clsOperateurDTO.AG_CODEAGENCE.ToString();
                    clsOperateur.PO_CODEPROFIL = clsOperateurDTO.PO_CODEPROFIL.ToString();
                    clsOperateur.TO_CODETYPEOERATEUR = clsOperateurDTO.TO_CODETYPEOERATEUR.ToString();
                    clsOperateur.PL_CODENUMCOMPTE = clsOperateurDTO.PL_CODENUMCOMPTE.ToString();
                    clsOperateur.PL_CODENUMCOMPTECOFFREFORT = clsOperateurDTO.PL_CODENUMCOMPTECOFFREFORT.ToString();
                    clsOperateur.OP_NOMPRENOM = clsOperateurDTO.OP_NOMPRENOM.ToString();
                    clsOperateur.OP_LOGIN = clsOperateurDTO.OP_LOGIN.ToString();
                    clsOperateur.OP_MOTPASSE = clsOperateurDTO.OP_MOTPASSE.ToString();
                    clsOperateur.OP_ACTIF = clsOperateurDTO.OP_ACTIF.ToString();
                    clsOperateur.OP_TELEPHONE = clsOperateurDTO.OP_TELEPHONE.ToString();
                    clsOperateur.OP_EMAIL = clsOperateurDTO.OP_EMAIL.ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = clsOperateurDTO.OP_JOURNEEOUVERTE.ToString();
                    clsOperateur.OP_DATESAISIE = DateTime.Parse(clsOperateurDTO.OP_DATESAISIE.ToString());
                    clsOperateur.OP_GESTIONNAIRE = clsOperateurDTO.OP_GESTIONNAIRE.ToString();
                    clsOperateur.OP_CAISSIER = clsOperateurDTO.OP_CAISSIER.ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUE = clsOperateurDTO.OP_IMPRESSIONAUTOMATIQUE.ToString();
                    clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE = double.Parse(clsOperateurDTO.OP_MONTANTTOTALENCAISSEAUTORISE.ToString());
                    clsOperateur.EN_CODEENTREPOT = clsOperateurDTO.EN_CODEENTREPOT.ToString();
                    clsOperateur.TI_IDTIERS = clsOperateurDTO.TI_IDTIERS.ToString();
                    clsOperateur.OP_EXTOURNE = clsOperateurDTO.OP_EXTOURNE.ToString();
                    clsOperateur.OP_CREATIONJOURNE = clsOperateurDTO.OP_CREATIONJOURNE.ToString();
                    clsOperateur.OP_FERMETUREJOURNE = clsOperateurDTO.OP_FERMETUREJOURNE.ToString();
                    clsOperateur.SR_CODESERVICE = clsOperateurDTO.SR_CODESERVICE.ToString();
                    clsOperateur.OP_CREATIONPROFILE = clsOperateurDTO.OP_CREATIONPROFILE.ToString();
                    clsOperateur.OP_CREATIONOPERATEUR = clsOperateurDTO.OP_CREATIONOPERATEUR.ToString();
                    clsOperateur.OP_SELECTIONOPERATEURAPPRO = clsOperateurDTO.OP_SELECTIONOPERATEURAPPRO.ToString();
                    clsOperateur.OP_SELECTIONOPERATEURVENTE = clsOperateurDTO.OP_SELECTIONOPERATEURVENTE.ToString();
                    clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD = clsOperateurDTO.OP_CONTREPARTIEAUTOMATIQUEOD.ToString();
                    clsOperateur.OP_CODEOPERATEUR = clsOperateurDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurphoto.OH_PHOTO = OH_PHOTO;
                    clsOperateurphoto.OH_SIGNATURE = OH_SIGNATURE;

                    clsObjetEnvoi.OE_A = clsOperateurDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurDTO.clsObjetEnvoi.OE_Y;

                    clsObjetEnvoi.OE_PARAM = new string[] {clsOperateurDTO.EN_CODEENTREPOT ,clsOperateurDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgModifierOperateurPhoto(clsDonnee, clsOperateur,  clsOperateurphoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurs.Add(clsOperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgSupprimer(List<HT_Stock.BOJ.clsOperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR ,Objet[0].AG_CODEAGENCE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOperateurWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurs.Add(clsOperateur);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurs = TestChampObligatoireListe2(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] {Objet[0].AG_CODEAGENCE ,Objet[0].EN_CODEENTREPOT };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsOperateurWSBLL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        string OH_PHOTOBASE64 = "";
                        string OH_SIGNATUREBASE64 = "";


                        HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                        clsOperateur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsOperateur.PO_CODEPROFIL = row["PO_CODEPROFIL"].ToString();
                        clsOperateur.TO_CODETYPEOERATEUR = row["TO_CODETYPEOERATEUR"].ToString();
                        clsOperateur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsOperateur.PL_CODENUMCOMPTECOFFREFORT = row["PL_CODENUMCOMPTECOFFREFORT"].ToString();
                        clsOperateur.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsOperateur.OP_LOGIN = row["OP_LOGIN"].ToString();
                        clsOperateur.OP_MOTPASSE = row["OP_MOTPASSE"].ToString();
                        clsOperateur.OP_ACTIF = row["OP_ACTIF"].ToString();
                        clsOperateur.OP_TELEPHONE = row["OP_TELEPHONE"].ToString();
                        clsOperateur.OP_EMAIL = row["OP_EMAIL"].ToString();
                        clsOperateur.OP_JOURNEEOUVERTE = row["OP_JOURNEEOUVERTE"].ToString();
                        clsOperateur.OP_DATESAISIE = DateTime.Parse(row["OP_DATESAISIE"].ToString()).ToShortDateString();
                        clsOperateur.OP_GESTIONNAIRE = row["OP_GESTIONNAIRE"].ToString();
                        clsOperateur.OP_CAISSIER = row["OP_CAISSIER"].ToString();
                        clsOperateur.OP_IMPRESSIONAUTOMATIQUE = row["OP_IMPRESSIONAUTOMATIQUE"].ToString();
                        clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE = double.Parse(row["OP_MONTANTTOTALENCAISSEAUTORISE"].ToString()).ToString();
                        clsOperateur.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsOperateur.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsOperateur.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsOperateur.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();

                        clsOperateur.OP_EXTOURNE = row["OP_EXTOURNE"].ToString();
                        clsOperateur.OP_CREATIONJOURNE = row["OP_CREATIONJOURNE"].ToString();
                        clsOperateur.OP_FERMETUREJOURNE = row["OP_FERMETUREJOURNE"].ToString();
                        clsOperateur.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();
                        clsOperateur.OP_CREATIONPROFILE = row["OP_CREATIONPROFILE"].ToString();
                        clsOperateur.OP_CREATIONOPERATEUR = row["OP_CREATIONOPERATEUR"].ToString();
                        clsOperateur.OP_SELECTIONOPERATEURAPPRO = row["OP_SELECTIONOPERATEURAPPRO"].ToString();
                        clsOperateur.OP_SELECTIONOPERATEURVENTE = row["OP_SELECTIONOPERATEURVENTE"].ToString();
                        clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD = row["OP_CONTREPARTIEAUTOMATIQUEOD"].ToString();
                        clsOperateur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();

                        clsOperateur.PO_LIBELLE = row["PO_LIBELLE"].ToString();
                        clsOperateur.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsOperateur.SR_LIBELLE = row["SR_LIBELLE"].ToString();
                        clsOperateur.TO_LIBELLE = row["TO_LIBELLE"].ToString();
                        clsOperateur.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsOperateur.PL_NUMCOMPTECOFFREFORT = row["PL_NUMCOMPTECOFFREFORT"].ToString();


                        //+++++++++++DEBUT PHOTO&SIGNATURE
                        clsOperateurphotoWSBLL clsOperateurphotoWSBLL = new clsOperateurphotoWSBLL();
                        Stock.BOJ.clsOperateurphoto clsOperateurphotoAffichage = new Stock.BOJ.clsOperateurphoto();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsOperateur.AG_CODEAGENCE, clsOperateur.OP_CODEOPERATEUR };
                        clsOperateurphotoAffichage = clsOperateurphotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                        if (clsOperateurphotoAffichage != null)
                        {
                            if (clsOperateurphotoAffichage.OH_PHOTO != null)
                                OH_PHOTOBASE64 = Convert.ToBase64String(clsOperateurphotoAffichage.OH_PHOTO);
                            if (clsOperateurphotoAffichage.OH_SIGNATURE != null)
                                OH_SIGNATUREBASE64 = Convert.ToBase64String(clsOperateurphotoAffichage.OH_SIGNATURE);
                        }
                        clsOperateur.OH_PHOTO = OH_PHOTOBASE64;
                        clsOperateur.OH_SIGNATURE = OH_SIGNATUREBASE64;
                        //+++++++++++FIN PHOTO&SIGNATURE

                        clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                        clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsOperateurs.Add(clsOperateur);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                 clsOperateurs = TestChampObligatoireCombo(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                  clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                 if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsOperateurWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {

                        HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                        clsOperateur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsOperateur.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                        clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsOperateurs.Add(clsOperateur);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateur> pvgChargerDansDataSetOperateurEntrepot(List<HT_Stock.BOJ.clsOperateur> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                 clsOperateurs = TestChampObligatoireListeEntrepot(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
                //--TEST CONTRAINTE
                  clsOperateurs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                 if (clsOperateurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE ,Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsOperateurWSBLL.pvgChargerDansDataSetOperateurEntrepot(clsDonnee, clsObjetEnvoi);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {

                        HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                        clsOperateur.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsOperateur.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsOperateur.COCHER = row["COCHER"].ToString();

                        clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                        clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOperateur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsOperateurs.Add(clsOperateur);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOperateurs.Add(clsOperateur);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
                clsOperateurs.Add(clsOperateur);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurs;
        }



    }
}
