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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhatiers" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhatiers.svc ou wsPhatiers.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhatiers : IwsPhatiers
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhatiersWSBLL clsPhatiersWSBLL = new clsPhatiersWSBLL();

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


        public List<HT_Stock.BOJ.clsPhatiers> pvgAjouter(List<HT_Stock.BOJ.clsPhatiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatierss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                //--TEST CONTRAINTE
                clsPhatierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
            }

            Stock.BOJ.clsPhatiers clsPhatiers1 = new Stock.BOJ.clsPhatiers();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsPhatiersgarantie> clsPhatiersgaranties = new List<BOJ.clsPhatiersgarantie>();
            //List<Stock.BOJ.clsPhatiersprime> clsPhatiersprimes = new List<BOJ.clsPhatiersprime>();
            //List<Stock.BOJ.clsPhatiersreduction> clsPhatiersreductions = new List<BOJ.clsPhatiersreduction>();
            //List<Stock.BOJ.clsPhatiersayantdroit> clsPhatiersayantdroits = new List<BOJ.clsPhatiersayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhatiers clsPhatiersDTO in Objet)
                {

                     Byte[] TI_PHOTO = null;
                     Byte[] TI_SIGNATURE = null;

                    if (clsPhatiersDTO.TI_PHOTO != "")
                     TI_PHOTO = System.Convert.FromBase64String(clsPhatiersDTO.TI_PHOTO);
                    if(clsPhatiersDTO.TI_SIGNATURE!="")
                     TI_SIGNATURE = System.Convert.FromBase64String(clsPhatiersDTO.TI_SIGNATURE);
                    Stock.BOJ.clsPhatiers clsPhatiers = new Stock.BOJ.clsPhatiers();
                    clsPhatiers.AG_CODEAGENCE = clsPhatiersDTO.AG_CODEAGENCE.ToString();
                    clsPhatiers.EN_CODEENTREPOT = clsPhatiersDTO.EN_CODEENTREPOT.ToString();
                    clsPhatiers.TI_IDTIERS = clsPhatiersDTO.TI_IDTIERS.ToString();
                    clsPhatiers.TI_IDTIERSPRINCIPAL = clsPhatiersDTO.TI_IDTIERSPRINCIPAL.ToString() ;
                    clsPhatiers.NT_CODENATURETYPETIERS = clsPhatiersDTO.NT_CODENATURETYPETIERS.ToString();
                    clsPhatiers.NT_CODENATURETIERS = clsPhatiersDTO.NT_CODENATURETIERS.ToString();
                    clsPhatiers.VL_CODEVILLE = clsPhatiersDTO.VL_CODEVILLE.ToString();
                    clsPhatiers.TI_SIEGE = clsPhatiersDTO.TI_SIEGE.ToString();
                    clsPhatiers.SX_CODESEXE = clsPhatiersDTO.SX_CODESEXE.ToString();
                    clsPhatiers.FM_CODEFORMEJURIDIQUE = clsPhatiersDTO.FM_CODEFORMEJURIDIQUE.ToString();
                    clsPhatiers.AC_CODEACTIVITE = clsPhatiersDTO.AC_CODEACTIVITE.ToString();
                    clsPhatiers.TP_CODETYPETIERS = clsPhatiersDTO.TP_CODETYPETIERS.ToString() ;
                    clsPhatiers.OP_CODEOPERATEUR = clsPhatiersDTO.OP_CODEOPERATEUR.ToString();
                    clsPhatiers.TC_CODECOMPTETYPETIERS = clsPhatiersDTO.TC_CODECOMPTETYPETIERS.ToString();
                    clsPhatiers.TI_NUMTIERS = clsPhatiersDTO.TI_NUMTIERS.ToString();
                    clsPhatiers.TI_DATENAISSANCE =DateTime.Parse(clsPhatiersDTO.TI_DATENAISSANCE.ToString());
                    clsPhatiers.TI_DENOMINATION = clsPhatiersDTO.TI_DENOMINATION.ToString();
                    clsPhatiers.TI_DESCRIPTIONTIERS = clsPhatiersDTO.TI_DESCRIPTIONTIERS.ToString();
                    clsPhatiers.TI_ADRESSEPOSTALE = clsPhatiersDTO.TI_ADRESSEPOSTALE.ToString();
                    clsPhatiers.TI_ADRESSEGEOGRAPHIQUE = clsPhatiersDTO.TI_ADRESSEGEOGRAPHIQUE.ToString();
                    clsPhatiers.TI_TELEPHONE = clsPhatiersDTO.TI_TELEPHONE.ToString();
                    clsPhatiers.TI_FAX = clsPhatiersDTO.TI_FAX.ToString();
                    clsPhatiers.TI_SITEWEB = clsPhatiersDTO.TI_SITEWEB.ToString();
                    clsPhatiers.TI_EMAIL = clsPhatiersDTO.TI_EMAIL.ToString();
                    clsPhatiers.TI_GERANT = clsPhatiersDTO.TI_GERANT.ToString();
                    clsPhatiers.TI_STATUT = clsPhatiersDTO.TI_STATUT.ToString();
                    clsPhatiers.TI_DATESAISIE =DateTime.Parse(clsPhatiersDTO.TI_DATESAISIE.ToString());
                    clsPhatiers.TI_ASDI = clsPhatiersDTO.TI_ASDI.ToString();
                    clsPhatiers.TI_TVA = clsPhatiersDTO.TI_TVA.ToString();
                    clsPhatiers.TI_STATUTDOUTEUX =int.Parse(clsPhatiersDTO.TI_STATUTDOUTEUX.ToString());
                    clsPhatiers.TI_PLAFONDCREDIT = double.Parse(clsPhatiersDTO.TI_PLAFONDCREDIT.ToString());
                    clsPhatiers.TI_NUMCPTECONTIBUABLE =clsPhatiersDTO.TI_NUMCPTECONTIBUABLE.ToString();
                    clsPhatiers.OP_CODEOPERATEUR = clsPhatiersDTO.OP_CODEOPERATEUR.ToString();
                    clsPhatiers.TI_DATEDEPART = (clsPhatiersDTO.TI_DATEDEPART.ToString() != "") ? DateTime.Parse(clsPhatiersDTO.TI_DATEDEPART.ToString()) : DateTime.Parse("01/01/1900");
                    clsPhatiers.TI_PHOTO = TI_PHOTO;
                    clsPhatiers.TI_SIGNATURE =TI_SIGNATURE;
                    clsPhatiers.PL_NUMCOMPTE = clsPhatiersDTO.PL_NUMCOMPTE.ToString();

                    clsPhatiers.TI_TAUXREMISE = float.Parse(clsPhatiersDTO.TI_TAUXREMISE.ToString());
                    clsPhatiers.CU_CODECASUTILISATION = clsPhatiersDTO.CU_CODECASUTILISATION.ToString() ;
                    clsPhatiers.TI_NUMEROAGREMENT = clsPhatiersDTO.TI_NUMEROAGREMENT.ToString() ;
                    clsPhatiers.TI_TAUXDECLARATION =double.Parse(clsPhatiersDTO.TI_TAUXDECLARATION.ToString()) ;
                    clsPhatiers.GP_CODEGROUPE = clsPhatiersDTO.GP_CODEGROUPE.ToString();
                    clsPhatiers.TI_MANDATAIRE = clsPhatiersDTO.TI_MANDATAIRE.ToString();
                    clsPhatiers.TI_USAGER = clsPhatiersDTO.TI_USAGER.ToString() ;
                    clsPhatiers.IN_CODEINGREDIENT = clsPhatiersDTO.IN_CODEINGREDIENT.ToString();

                    clsPhatiers.TI_ESCOMPTE = clsPhatiersDTO.TI_ESCOMPTE.ToString();
                    clsPhatiers.ZN_CODEZONE = clsPhatiersDTO.ZN_CODEZONE.ToString();
                    clsPhatiers.RE_CODEREGIMEIMPOSITION = clsPhatiersDTO.RE_CODEREGIMEIMPOSITION.ToString();
                    clsPhatiers.SP_CODESPECIALITE = clsPhatiersDTO.SP_CODESPECIALITE.ToString();
                    clsPhatiers.QU_CODEQUARTIER = clsPhatiersDTO.QU_CODEQUARTIER.ToString();
                    clsPhatiers.PF_CODEPROFESSION = clsPhatiersDTO.PF_CODEPROFESSION.ToString();
                    clsPhatiers.TI_LIEUNAISSANCE = clsPhatiersDTO.TI_LIEUNAISSANCE.ToString();
                    //clsPhatiers.TI_NUMTIERSRETOUR = clsPhatiersDTO.TI_NUMTIERSRETOUR.ToString();
                    clsPhatiers.TYPEOPERATION = clsPhatiersDTO.TYPEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhatiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhatiersDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsPhatiersWSBLL.pvgAjouter(clsDonnee, clsPhatiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatierss.Add(clsPhatiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatierss.Add(clsPhatiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatierss;
        }


        public List<HT_Stock.BOJ.clsPhatiers> pvgSupprimer(List<HT_Stock.BOJ.clsPhatiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatierss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                //--TEST CONTRAINTE
                clsPhatierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE,  Objet[0].TI_IDTIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhatiersWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatierss.Add(clsPhatiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatierss.Add(clsPhatiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatierss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiers> pvgChargerDansDataSetTiers(List<HT_Stock.BOJ.clsPhatiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatierss = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                //--TEST CONTRAINTE
                clsPhatierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
            }

      
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].TI_STATUT, Objet[0].TI_NUMTIERS, Objet[0].TI_DENOMINATION, Objet[0].TI_DATESAISIE1, Objet[0].TI_DATESAISIE2, Objet[0].TP_CODETYPETIERS, Objet[0].SC_CODESECTION, Objet[0].TI_CLTVENTCAISSE, Objet[0].OP_CODEOPERATEUR,Objet[0].AP_CODEPRODUIT, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetTiers(clsDonnee, clsObjetEnvoi);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {


                        string TI_PHOTOBASE64 = "";
                        string TI_SIGNATUREBASE64 = "";

                        HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                        clsPhatiers.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsPhatiers.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                        clsPhatiers.CU_CODECASUTILISATION = row["CU_CODECASUTILISATION"].ToString();
                        clsPhatiers.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                        clsPhatiers.IN_CODEINGREDIENT = row["IN_CODEINGREDIENT"].ToString();
                        clsPhatiers.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                        clsPhatiers.NT_CODENATURETYPETIERS = row["NT_CODENATURETYPETIERS"].ToString();
                        clsPhatiers.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsPhatiers.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsPhatiers.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsPhatiers.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                        clsPhatiers.RE_CODEREGIMEIMPOSITION = row["RE_CODEREGIMEIMPOSITION"].ToString();
                        clsPhatiers.SC_CODESECTION = row["SC_CODESECTION"].ToString();
                        clsPhatiers.SP_CODESPECIALITE = row["SP_CODESPECIALITE"].ToString();
                        clsPhatiers.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                        clsPhatiers.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                        clsPhatiers.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsPhatiers.TI_ADRESSEPOSTALE = row["TI_ADRESSEPOSTALE"].ToString();
                        clsPhatiers.TI_ASDI = row["TI_ASDI"].ToString();

                        if (row["TI_DATENAISSANCE"].ToString()!="")
                             clsPhatiers.TI_DATENAISSANCE =DateTime.Parse(row["TI_DATENAISSANCE"].ToString()).ToShortDateString();
                        if (row["TI_DATEDEPART"].ToString() != "")
                            clsPhatiers.TI_DATEDEPART = DateTime.Parse(row["TI_DATEDEPART"].ToString()).ToShortDateString();
                        if (row["TI_DATESAISIE"].ToString() != "")
                            clsPhatiers.TI_DATESAISIE = DateTime.Parse(row["TI_DATESAISIE"].ToString()).ToShortDateString();

                        clsPhatiers.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsPhatiers.TI_DESCRIPTIONTIERS = row["TI_DESCRIPTIONTIERS"].ToString();
                        clsPhatiers.TI_EMAIL = row["TI_EMAIL"].ToString();
                        clsPhatiers.TI_ESCOMPTE = row["TI_ESCOMPTE"].ToString();
                        clsPhatiers.TI_FAX = row["TI_FAX"].ToString();
                        clsPhatiers.TI_GERANT = row["TI_GERANT"].ToString();
                        clsPhatiers.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsPhatiers.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsPhatiers.ZN_NOMZONE = row["ZN_NOMZONE"].ToString();
                        clsPhatiers.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                        clsPhatiers.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsPhatiers.TI_PLAFONDCREDIT = row["TI_PLAFONDCREDIT"].ToString();
                        clsPhatiers.TI_TAUXREMISE = row["TI_TAUXREMISE"].ToString();

                        //+++++++++++DEBUT PHOTO&SIGNATURE
                            clsPhatiersphotoWSBLL clsPhatiersphotoWSBLL = new clsPhatiersphotoWSBLL();
                            Stock.BOJ.clsPhatiersphoto clsPhatiersphotoAffichage = new Stock.BOJ.clsPhatiersphoto();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsPhatiers.AG_CODEAGENCE, clsPhatiers.TI_IDTIERS };
                            clsPhatiersphotoAffichage = clsPhatiersphotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                            if(clsPhatiersphotoAffichage!=null)
                            {
                            if (clsPhatiersphotoAffichage.TI_PHOTO!=null)
                                TI_PHOTOBASE64 = Convert.ToBase64String(clsPhatiersphotoAffichage.TI_PHOTO);
                            if (clsPhatiersphotoAffichage.TI_SIGNATURE != null)
                                TI_SIGNATUREBASE64 = Convert.ToBase64String(clsPhatiersphotoAffichage.TI_SIGNATURE);
                            }
                        clsPhatiers.TI_PHOTO = TI_PHOTOBASE64;
                        clsPhatiers.TI_SIGNATURE = TI_SIGNATUREBASE64;
                        //+++++++++++FIN PHOTO&SIGNATURE






                        clsPhatiers.TI_IDTIERSPRINCIPAL = row["TI_IDTIERSPRINCIPAL"].ToString();
                        clsPhatiers.TI_MANDATAIRE = row["TI_MANDATAIRE"].ToString();
                        clsPhatiers.TI_NUMCPTECONTIBUABLE = row["TI_NUMCPTECONTIBUABLE"].ToString();
                        clsPhatiers.TI_NUMEROAGREMENT = row["TI_NUMEROAGREMENT"].ToString();
                        clsPhatiers.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        if (row["TI_PLAFONDCREDIT"].ToString() != "")
                            clsPhatiers.TI_PLAFONDCREDIT = Double.Parse(row["TI_PLAFONDCREDIT"].ToString()).ToString();
                        else
                            clsPhatiers.TI_PLAFONDCREDIT = "0";

                        clsPhatiers.TI_SIEGE = row["TI_SIEGE"].ToString();
                        clsPhatiers.TI_SITEWEB = row["TI_SITEWEB"].ToString();
                        clsPhatiers.TI_STATUT = row["TI_STATUT"].ToString();
                        clsPhatiers.TI_STATUTDOUTEUX = row["TI_STATUTDOUTEUX"].ToString();
                        if (row["TI_TAUXDECLARATION"].ToString() != "")
                            clsPhatiers.TI_TAUXDECLARATION = Double.Parse(row["TI_TAUXDECLARATION"].ToString()).ToString();
                        else
                            clsPhatiers.TI_TAUXDECLARATION = "0";

                        if (row["TI_TAUXREMISE"].ToString() != "")
                            clsPhatiers.TI_TAUXREMISE = Double.Parse(row["TI_TAUXREMISE"].ToString()).ToString();
                        else
                            clsPhatiers.TI_TAUXREMISE = "0";
                        clsPhatiers.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        clsPhatiers.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                        clsPhatiers.TI_LIEUNAISSANCE = row["TI_LIEUNAISSANCE"].ToString();
                        clsPhatiers.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                        clsPhatiers.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsPhatiers.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                        clsPhatiers.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                        clsPhatiers.AC_LIBELLE = row["AC_LIBELLE"].ToString();
                        clsPhatiers.CU_LIBELLE = row["CU_LIBELLE"].ToString();
                        clsPhatiers.RE_LIBELLEREGIMEIMPOSITION = row["RE_LIBELLEREGIMEIMPOSITION"].ToString();
                        clsPhatiers.SP_LIBELLESPECIALITE = row["SP_LIBELLESPECIALITE"].ToString();
                        clsPhatiers.GP_LIBELLE = row["GP_LIBELLE"].ToString();
                        clsPhatiers.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                        clsPhatiers.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                        clsPhatiers.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                        clsPhatiers.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                        clsPhatiers.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                        clsPhatiers.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                        clsPhatiers.TC_LIBELLE = row["TC_LIBELLE"].ToString();

                        clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhatiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                        clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPhatiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                        clsPhatierss.Add(clsPhatiers);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsPhatierss.Add(clsPhatiers);
                }
                


            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }

        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            clsPhatierss.Add(clsPhatiers);
        }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatierss;
        }

            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhatiers> pvgChargerRechercheTiersparNom(List<HT_Stock.BOJ.clsPhatiers> Objet)
            {

                List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
                List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
           
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


                for (int Idx = 0; Idx < Objet.Count; Idx++)
                {
                    //--TEST DES CHAMPS OBLIGATOIRES
                    clsPhatierss = TestChampObligatoireListe(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                    //--TEST CONTRAINTE
                    clsPhatierss = TestTestContrainteListe(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                }

           
                clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].TI_NUMTIERS, Objet[0].TI_DENOMINATION, Objet[0].TP_CODETYPETIERS,   Objet[0].SC_CODESECTION,  Objet[0].TI_CLTVENTCAISSE};
                DataSet DataSet = new DataSet();

                try
                {
                    clsDonnee.pvgConnectionBase();
                    DataSet = clsPhatiersWSBLL.pvgChargerRechercheTiersparNom(clsDonnee, clsObjetEnvoi);
                    clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                    if (DataSet.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {


                            string TI_PHOTOBASE64 = "";
                            string TI_SIGNATUREBASE64 = "";

                            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                            clsPhatiers.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsPhatiers.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                            clsPhatiers.CU_CODECASUTILISATION = row["CU_CODECASUTILISATION"].ToString();
                            clsPhatiers.GP_CODEGROUPE = row["GP_CODEGROUPE"].ToString();
                            //clsPhatiers.IN_CODEINGREDIENT = row["IN_CODEINGREDIENT"].ToString();
                            clsPhatiers.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                            clsPhatiers.NT_CODENATURETYPETIERS = row["NT_CODENATURETYPETIERS"].ToString();
                            clsPhatiers.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                            clsPhatiers.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                            clsPhatiers.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                            clsPhatiers.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                            //clsPhatiers.RE_CODEREGIMEIMPOSITION = row["RE_CODEREGIMEIMPOSITION"].ToString();
                            //clsPhatiers.SC_CODESECTION = row["SC_CODESECTION"].ToString();
                            //clsPhatiers.SP_CODESPECIALITE = row["SP_CODESPECIALITE"].ToString();
                            //clsPhatiers.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                            //clsPhatiers.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                            //clsPhatiers.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsPhatiers.TI_ADRESSEPOSTALE = row["TI_ADRESSEPOSTALE"].ToString();
                            clsPhatiers.TI_ASDI = row["TI_ASDI"].ToString();

                            if (row["TI_DATENAISSANCE"].ToString()!="")
                                    clsPhatiers.TI_DATENAISSANCE =DateTime.Parse(row["TI_DATENAISSANCE"].ToString()).ToShortDateString();
                            if (row["TI_DATEDEPART"].ToString() != "")
                                clsPhatiers.TI_DATEDEPART = DateTime.Parse(row["TI_DATEDEPART"].ToString()).ToShortDateString();
                            if (row["TI_DATESAISIE"].ToString() != "")
                                clsPhatiers.TI_DATESAISIE = DateTime.Parse(row["TI_DATESAISIE"].ToString()).ToShortDateString();

                            clsPhatiers.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                            clsPhatiers.TI_DESCRIPTIONTIERS = row["TI_DESCRIPTIONTIERS"].ToString();
                            //clsPhatiers.TI_EMAIL = row["TI_EMAIL"].ToString();
                            //clsPhatiers.TI_ESCOMPTE = row["TI_ESCOMPTE"].ToString();
                            //clsPhatiers.TI_FAX = row["TI_FAX"].ToString();
                            //clsPhatiers.TI_GERANT = row["TI_GERANT"].ToString();
                            clsPhatiers.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                            ////+++++++++++DEBUT PHOTO&SIGNATURE
                            //    clsPhatiersphotoWSBLL clsPhatiersphotoWSBLL = new clsPhatiersphotoWSBLL();
                            //    Stock.BOJ.clsPhatiersphoto clsPhatiersphotoAffichage = new Stock.BOJ.clsPhatiersphoto();
                            //    clsObjetEnvoi.OE_PARAM = new string[] { clsPhatiers.AG_CODEAGENCE, clsPhatiers.TI_IDTIERS };
                            //    clsPhatiersphotoAffichage = clsPhatiersphotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                            //    if(clsPhatiersphotoAffichage!=null)
                            //    {
                            //    if (clsPhatiersphotoAffichage.TI_PHOTO!=null)
                            //        TI_PHOTOBASE64 = Convert.ToBase64String(clsPhatiersphotoAffichage.TI_PHOTO);
                            //    if (clsPhatiersphotoAffichage.TI_SIGNATURE != null)
                            //        TI_SIGNATUREBASE64 = Convert.ToBase64String(clsPhatiersphotoAffichage.TI_SIGNATURE);
                            //    }
                            //clsPhatiers.TI_PHOTO = TI_PHOTOBASE64;
                            //clsPhatiers.TI_SIGNATURE = TI_SIGNATUREBASE64;
                            ////+++++++++++FIN PHOTO&SIGNATURE






                            clsPhatiers.TI_IDTIERSPRINCIPAL = row["TI_IDTIERSPRINCIPAL"].ToString();
                            //clsPhatiers.TI_MANDATAIRE = row["TI_MANDATAIRE"].ToString();
                            //clsPhatiers.TI_NUMCPTECONTIBUABLE = row["TI_NUMCPTECONTIBUABLE"].ToString();
                            //clsPhatiers.TI_NUMEROAGREMENT = row["TI_NUMEROAGREMENT"].ToString();
                            clsPhatiers.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                            if (row["TI_PLAFONDCREDIT"].ToString() != "")
                                clsPhatiers.TI_PLAFONDCREDIT = Double.Parse(row["TI_PLAFONDCREDIT"].ToString()).ToString();
                            else
                                clsPhatiers.TI_PLAFONDCREDIT = "0";

                            //clsPhatiers.TI_SIEGE = row["TI_SIEGE"].ToString();
                            //clsPhatiers.TI_SITEWEB = row["TI_SITEWEB"].ToString();
                            //clsPhatiers.TI_STATUT = row["TI_STATUT"].ToString();
                            //clsPhatiers.TI_STATUTDOUTEUX = row["TI_STATUTDOUTEUX"].ToString();
                            //if (row["TI_TAUXDECLARATION"].ToString() != "")
                            //    clsPhatiers.TI_TAUXDECLARATION = Double.Parse(row["TI_TAUXDECLARATION"].ToString()).ToString();
                            //else
                            //    clsPhatiers.TI_TAUXDECLARATION = "0";

                            if (row["TI_TAUXREMISE"].ToString() != "")
                                clsPhatiers.TI_TAUXREMISE = Double.Parse(row["TI_TAUXREMISE"].ToString()).ToString();
                            else
                                clsPhatiers.TI_TAUXREMISE = "0";
                            clsPhatiers.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                            //clsPhatiers.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                            //clsPhatiers.TI_LIEUNAISSANCE = row["TI_LIEUNAISSANCE"].ToString();
                            //clsPhatiers.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                            //clsPhatiers.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                            //clsPhatiers.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                            //clsPhatiers.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                            //clsPhatiers.AC_LIBELLE = row["AC_LIBELLE"].ToString();
                            //clsPhatiers.CU_LIBELLE = row["CU_LIBELLE"].ToString();
                            //clsPhatiers.RE_LIBELLEREGIMEIMPOSITION = row["RE_LIBELLEREGIMEIMPOSITION"].ToString();
                            //clsPhatiers.SP_LIBELLESPECIALITE = row["SP_LIBELLESPECIALITE"].ToString();
                            //clsPhatiers.GP_LIBELLE = row["GP_LIBELLE"].ToString();
                            clsPhatiers.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                            //clsPhatiers.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                            //clsPhatiers.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                            //clsPhatiers.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                            //clsPhatiers.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                            //clsPhatiers.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                            //clsPhatiers.TC_LIBELLE = row["TC_LIBELLE"].ToString();

                            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                            clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsPhatiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                            clsPhatierss.Add(clsPhatiers);
                        }
                    }
                    else
                    {
                        HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                        clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsPhatiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                        clsPhatierss.Add(clsPhatiers);
                    }
                


                }
                catch (SqlException SQLEx)
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhatiers.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                    clsPhatierss.Add(clsPhatiers);
                }

            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }


                finally
                {
                    clsDonnee.pvgDeConnectionBase();
                }
                return clsPhatierss;
            }




    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsPhatiers> pvgChargerDansDataSetPourComboSelonNaturetypetiers(List<HT_Stock.BOJ.clsPhatiers> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsPhatierss = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
            //--TEST CONTRAINTE
            clsPhatierss = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NT_CODENATURETYPETIERS };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee, clsObjetEnvoi);
            clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                    clsPhatiers.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                    clsPhatiers.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhatierss.Add(clsPhatiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhatierss.Add(clsPhatiers);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            clsPhatierss.Add(clsPhatiers);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            clsPhatierss.Add(clsPhatiers);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhatierss;
    }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiers> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhatiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatierss = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                //--TEST CONTRAINTE
                clsPhatierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NT_CODENATURETYPETIERS };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                        clsPhatiers.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsPhatiers.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsPhatiers.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPhatiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsPhatierss.Add(clsPhatiers);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsPhatierss.Add(clsPhatiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatierss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiers> pvgSoldeGlobalReglement(List<HT_Stock.BOJ.clsPhatiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatierss = TestChampObligatoireListeSolde(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
                //--TEST CONTRAINTE
                clsPhatierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatierss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].TI_NUMTIERS, Objet[0].DATEDEBUT };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                string vlpSolde = "0";
                clsPhamouvementstockreglementcommercialWSBLL clsPhamouvementstockreglementcommercialWSBLL = new clsPhamouvementstockreglementcommercialWSBLL();
                vlpSolde=clsPhamouvementstockreglementcommercialWSBLL.pvgSoldeGlobalReglement(clsDonnee, clsObjetEnvoi);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                if (vlpSolde != "")
                {
                    
                        HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                        clsPhatiers.SOLDE = vlpSolde;
                        clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPhatiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsPhatierss.Add(clsPhatiers);

                }
                else
                {
                    HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                    clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsPhatierss.Add(clsPhatiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
                clsPhatierss.Add(clsPhatiers);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatierss;
        }



    }
}
