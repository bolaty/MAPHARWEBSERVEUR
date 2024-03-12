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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatOutilsSecurite" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatOutilsSecurite.svc ou wsEditionEtatOutilsSecurite.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatOutilsSecurite : IwsEditionEtatOutilsSecurite
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatOutilsSecuriteWSBLL clsEditionEtatOutilsSecuriteWSBLL = new clsEditionEtatOutilsSecuriteWSBLL();

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
        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> pvgInsertIntoDatasetEtatOperateur(List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            List<Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecuritesBOJ = new List<Stock.BOJ.clsEditionEtatOutilsSecurite>();
            Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new Stock.BOJ.clsEditionEtatOutilsSecurite();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatOutilsSecurites = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatOutilsSecurites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatOutilsSecurites;
                //--TEST CONTRAINTE
                clsEditionEtatOutilsSecurites = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatOutilsSecurites[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatOutilsSecurites;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                // Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite1 = new Stock.BOJ.clsEditionEtatOutilsSecurite();




                foreach (HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecuriteDTO in Objet)
                {
                    clsEditionEtatOutilsSecurite.AG_CODEAGENCE = clsEditionEtatOutilsSecuriteDTO.AG_CODEAGENCE;
                    clsEditionEtatOutilsSecurite.EN_CODEENTREPOT = clsEditionEtatOutilsSecuriteDTO.EN_CODEENTREPOT;
                    clsEditionEtatOutilsSecurite.MS_DATERENDEZVOUS1 = clsEditionEtatOutilsSecuriteDTO.DATEDEBUT;
                    clsEditionEtatOutilsSecurite.MS_DATERENDEZVOUS2 = clsEditionEtatOutilsSecuriteDTO.DATEFIN;
                    clsEditionEtatOutilsSecurite.ET_TYPEETAT = clsEditionEtatOutilsSecuriteDTO.ET_TYPEETAT;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsEditionEtatOutilsSecuriteDTO.AG_CODEAGENCE, clsEditionEtatOutilsSecuriteDTO.EN_CODEENTREPOT, clsEditionEtatOutilsSecuriteDTO.MS_DATERENDEZVOUS1, clsEditionEtatOutilsSecuriteDTO.MS_DATERENDEZVOUS2, clsEditionEtatOutilsSecuriteDTO.ET_TYPEETAT };
                    clsObjetEnvoi.OE_A = clsEditionEtatOutilsSecuriteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatOutilsSecuriteDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatOutilsSecuriteWSBLL.pvgInsertIntoDatasetEtatOperateur(clsDonnee, clsEditionEtatOutilsSecurite, clsObjetEnvoi);
                clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite1 = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();

                        clsEditionEtatOutilsSecurite1.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsEditionEtatOutilsSecurite1.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsEditionEtatOutilsSecurite1.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                        clsEditionEtatOutilsSecurite1.PO_CODEPROFIL = row["PO_CODEPROFIL"].ToString();
                        clsEditionEtatOutilsSecurite1.TO_CODETYPEOERATEUR = row["TO_CODETYPEOERATEUR"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_CODENUMCOMPTECOFFREFORT = row["PL_CODENUMCOMPTECOFFREFORT"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_NUMCOMPTECOFFREFORT = row["PL_NUMCOMPTECOFFREFORT"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_LOGIN = row["OP_LOGIN"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_MOTPASSE = row["OP_MOTPASSE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_ACTIF = row["OP_ACTIF"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_TELEPHONE = row["OP_TELEPHONE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_EMAIL = row["OP_EMAIL"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_JOURNEEOUVERTE = row["OP_JOURNEEOUVERTE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_GESTIONNAIRE = row["OP_GESTIONNAIRE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_CAISSIER = row["OP_CAISSIER"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_DATESAISIE = (row["OP_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["OP_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "01-01-1900";
                        clsEditionEtatOutilsSecurite1.PO_LIBELLE = row["PO_LIBELLE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_IMPRESSIONAUTOMATIQUE = row["OP_IMPRESSIONAUTOMATIQUE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_MONTANTTOTALENCAISSEAUTORISE = row["OP_MONTANTTOTALENCAISSEAUTORISE"].ToString();
                        clsEditionEtatOutilsSecurite1.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsEditionEtatOutilsSecurite1.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsEditionEtatOutilsSecurite1.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsEditionEtatOutilsSecurite1.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsEditionEtatOutilsSecurite1.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_CODENUMCOMPTECLT = row["PL_CODENUMCOMPTECLT"].ToString();
                        clsEditionEtatOutilsSecurite1.PL_NUMCOMPTECLT = row["PL_NUMCOMPTECLT"].ToString();
                        clsEditionEtatOutilsSecurite1.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                        clsEditionEtatOutilsSecurite1.TI_TVA = row["TI_TVA"].ToString();
                        clsEditionEtatOutilsSecurite1.TI_ASDI = row["TI_ASDI"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_EXTOURNE = row["OP_EXTOURNE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_CREATIONJOURNE = row["OP_CREATIONJOURNE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_FERMETUREJOURNE = row["OP_FERMETUREJOURNE"].ToString();
                        clsEditionEtatOutilsSecurite1.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_CREATIONPROFILE = row["OP_CREATIONPROFILE"].ToString();
                        clsEditionEtatOutilsSecurite1.OP_CREATIONOPERATEUR = row["OP_CREATIONOPERATEUR"].ToString();
                        clsEditionEtatOutilsSecurite1.clsObjetRetour = new Common.clsObjetRetour();
                        clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite1);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite1 = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();
                    clsEditionEtatOutilsSecurite1.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite1);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite1 = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();
                clsEditionEtatOutilsSecurite1.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite1);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite1 = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();
                clsEditionEtatOutilsSecurite1.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatOutilsSecurite1.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite1);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatOutilsSecurites;
        }

       

    }
}
