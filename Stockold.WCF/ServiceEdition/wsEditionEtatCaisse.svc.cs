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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatCaisse" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatCaisse.svc ou wsEditionEtatCaisse.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatCaisse : IwsEditionEtatCaisse
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatCaisseWSBLL clsEditionEtatCaisseWSBLL = new clsEditionEtatCaisseWSBLL();

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
        public List<HT_Stock.BOJ.clsEditionEtatCaisse> pvgInsertIntoDatasetEtatBrouillard(List<HT_Stock.BOJ.clsEditionEtatCaisse> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatCaisses = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
                //--TEST CONTRAINTE
                clsEditionEtatCaisses = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse1 = new Stock.BOJ.clsEditionEtatCaisse();


                foreach (HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisseDTO in Objet)
                {
                    clsEditionEtatCaisse1.AG_CODEAGENCE = clsEditionEtatCaisseDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatCaisse1.EN_CODEENTREPOT = clsEditionEtatCaisseDTO.EN_CODEENTREPOT.ToString();

                    clsEditionEtatCaisse1.OP_CODEOPERATEUREDITION = clsEditionEtatCaisseDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatCaisse1.DATEDEBUT = clsEditionEtatCaisseDTO.DATEDEBUT.ToString();
                    clsEditionEtatCaisse1.DATEFIN = clsEditionEtatCaisseDTO.DATEFIN.ToString();
                    clsEditionEtatCaisse1.MR_CODEMODEREGLEMENT = clsEditionEtatCaisseDTO.MR_CODEMODEREGLEMENT.ToString();
                    clsEditionEtatCaisse1.ET_TYPEETAT = clsEditionEtatCaisseDTO.ET_TYPEETAT.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatBrouillard(clsDonnee, clsEditionEtatCaisse1, clsObjetEnvoi);
                clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                        //clsEditionEtatCaisse.ET_INDEX = row["ET_INDEX"].ToString();
                        //clsEditionEtatCaisse.ET_LIBELLEEditionEtatCaisse = row["ET_LIBELLEEditionEtatCaisse"].ToString();
                      

                        clsEditionEtatCaisse.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();

                        clsEditionEtatCaisse.MR_CODEMODEREGLEMENT = row["MR_CODEMODEREGLEMENT"].ToString();
                        clsEditionEtatCaisse.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();


                        clsEditionEtatCaisse.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                        clsEditionEtatCaisse.MV_NUMPIECE = row["MV_NUMPIECE"].ToString();
                        clsEditionEtatCaisse.NO_CODENATUREOPERATION1 = row["NO_CODENATUREOPERATION1"].ToString();
                        clsEditionEtatCaisse.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsEditionEtatCaisse.MV_MONTANTDEBIT = (row["MV_MONTANTDEBIT"].ToString() != "") ? double.Parse(row["MV_MONTANTDEBIT"].ToString()) : 0;
                        clsEditionEtatCaisse.MV_MONTANTCREDIT = (row["MV_MONTANTCREDIT"].ToString() != "") ? double.Parse(row["MV_MONTANTCREDIT"].ToString()) : 0;
                        clsEditionEtatCaisse.MV_DATEPIECE = (row["MV_DATEPIECE"].ToString() != "") ? DateTime.Parse(row["MV_DATEPIECE"].ToString()).ToShortDateString().Replace("/", "-") : "";

                        clsEditionEtatCaisse.MV_ANNULATIONPIECE = row["MV_ANNULATIONPIECE"].ToString();
                        clsEditionEtatCaisse.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
                        clsEditionEtatCaisse.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                        clsEditionEtatCaisse.MV_NOMTIERS = row["MV_NOMTIERS"].ToString();
                        clsEditionEtatCaisse.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                        clsEditionEtatCaisse.MV_SOLDEPRECEDENT = (row["MV_SOLDEPRECEDENT"].ToString() != "") ? double.Parse(row["MV_SOLDEPRECEDENT"].ToString()) : 0;
                        clsEditionEtatCaisse.MV_NUMSEQUENCE = row["MV_NUMSEQUENCE"].ToString();
                        clsEditionEtatCaisse.MV_SOLDE = (row["MV_SOLDE"].ToString() != "") ? double.Parse(row["MV_SOLDE"].ToString()): 0;
                        clsEditionEtatCaisse.NUMEROBORDEREAU1 = row["NUMEROBORDEREAU1"].ToString();
                        clsEditionEtatCaisse.MV_SOLDEFINAL = (row["MV_SOLDEFINAL"].ToString() != "") ? double.Parse(row["MV_SOLDEFINAL"].ToString()) : 0;
                        clsEditionEtatCaisse.MS_NUMSEQUENCE = row["MS_NUMSEQUENCE"].ToString();
                        clsEditionEtatCaisse.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsEditionEtatCaisse.MC_SOLDEPRECEDENT = (row["MC_SOLDEPRECEDENT"].ToString() != "") ? double.Parse(row["MC_SOLDEPRECEDENT"].ToString()) :0;
                        clsEditionEtatCaisse.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsEditionEtatCaisse.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsEditionEtatCaisse.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsEditionEtatCaisse.MR_LIBELLE = row["MR_LIBELLE"].ToString();
                        clsEditionEtatCaisse.TOTALCAISSE = (row["TOTALCAISSE"].ToString() != "") ? double.Parse(row["TOTALCAISSE"].ToString()) : 0;
                        clsEditionEtatCaisse.TOTALBANQUE = (row["TOTALBANQUE"].ToString() != "") ? double.Parse(row["TOTALBANQUE"].ToString()) : 0;
                        clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatCaisses;
    }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatCaisse> pvgInsertIntoDatasetEtatGdLivre(List<HT_Stock.BOJ.clsEditionEtatCaisse> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatCaisses = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
                //--TEST CONTRAINTE
                clsEditionEtatCaisses = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse1 = new Stock.BOJ.clsEditionEtatCaisse();


                foreach (HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisseDTO in Objet)
                {

                    // "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TP_CODETYPETIERS", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@PL_NUMCOMPTE1", "@PL_NUMCOMPTE2",
                    //"@PL_NUMCOMPTETIERS", "@MR_CODEMODEREGLEMENT", "@NO_CODENATUREOPERATION", "@JO_CODEJOURNAL", "@MV_STATUTGLVRE", "@OP_CODEOPERATEUR", "@GP_CODEGROUPE", 
                    //"@PY_CODEPAYS", "@NT_CODENATURETIERS", "@TYPEETAT", "@CODEDECRYPTAGE"


                    clsEditionEtatCaisse1.AG_CODEAGENCE = clsEditionEtatCaisseDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatCaisse1.EN_CODEENTREPOT = clsEditionEtatCaisseDTO.EN_CODEENTREPOT.ToString();

                    clsEditionEtatCaisse1.TP_CODETYPETIERS = clsEditionEtatCaisseDTO.TP_CODETYPETIERS.ToString();
                    clsEditionEtatCaisse1.OP_CODEOPERATEUREDITION = clsEditionEtatCaisseDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatCaisse1.DATEDEBUT = clsEditionEtatCaisseDTO.DATEDEBUT.ToString();
                    clsEditionEtatCaisse1.DATEFIN = clsEditionEtatCaisseDTO.DATEFIN.ToString();
                    clsEditionEtatCaisse1.PL_NUMCOMPTE1 = clsEditionEtatCaisseDTO.PL_NUMCOMPTE1.ToString();
                    clsEditionEtatCaisse1.PL_NUMCOMPTE2 = clsEditionEtatCaisseDTO.PL_NUMCOMPTE2.ToString();
                    clsEditionEtatCaisse1.PL_NUMCOMPTETIERS = clsEditionEtatCaisseDTO.PL_NUMCOMPTETIERS.ToString();
                    clsEditionEtatCaisse1.MR_CODEMODEREGLEMENT = clsEditionEtatCaisseDTO.MR_CODEMODEREGLEMENT.ToString();
                    clsEditionEtatCaisse1.NO_CODENATUREOPERATION = clsEditionEtatCaisseDTO.NO_CODENATUREOPERATION.ToString();
                    clsEditionEtatCaisse1.JO_CODEJOURNAL = clsEditionEtatCaisseDTO.JO_CODEJOURNAL.ToString();
                    clsEditionEtatCaisse1.MV_STATUTGLVRE = clsEditionEtatCaisseDTO.MV_STATUTGLVRE.ToString();
                    clsEditionEtatCaisse1.OP_CODEOPERATEUR = clsEditionEtatCaisseDTO.OP_CODEOPERATEUR.ToString();
                    clsEditionEtatCaisse1.GP_CODEGROUPE = clsEditionEtatCaisseDTO.GP_CODEGROUPE.ToString();
                    clsEditionEtatCaisse1.PY_CODEPAYS = clsEditionEtatCaisseDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatCaisse1.NT_CODENATURETIERS = clsEditionEtatCaisseDTO.NT_CODENATURETIERS.ToString();
                    clsEditionEtatCaisse1.ET_TYPEETAT = clsEditionEtatCaisseDTO.ET_TYPEETAT.ToString();


                    clsObjetEnvoi.OE_A = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatGdLivre(clsDonnee, clsEditionEtatCaisse1, clsObjetEnvoi);
                clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                        //clsEditionEtatCaisse.ET_INDEX = row["ET_INDEX"].ToString();
                        //clsEditionEtatCaisse.ET_LIBELLEEditionEtatCaisse = row["ET_LIBELLEEditionEtatCaisse"].ToString();


                    clsEditionEtatCaisse.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsEditionEtatCaisse.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                    clsEditionEtatCaisse.AG_BOITEPOSTAL = row["AG_BOITEPOSTAL"].ToString();
                    clsEditionEtatCaisse.AG_TELEPHONE = row["AG_TELEPHONE"].ToString();
                    clsEditionEtatCaisse.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsEditionEtatCaisse.EN_NUMENTREPOT = row["EN_NUMENTREPOT"].ToString();
                    clsEditionEtatCaisse.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                    clsEditionEtatCaisse.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                    clsEditionEtatCaisse.MV_DATEPIECE = row["MV_DATEPIECE"].ToString();
                    clsEditionEtatCaisse.MV_NUMPIECE = row["MV_NUMPIECE"].ToString();
                    clsEditionEtatCaisse.MV_NUMEROPIECE = row["MV_NUMEROPIECE"].ToString();
                    clsEditionEtatCaisse.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    clsEditionEtatCaisse.MS_REFPIECE = row["MS_REFPIECE"].ToString();
                    clsEditionEtatCaisse.MS_NUMSEQUENCE = row["MS_NUMSEQUENCE"].ToString();
                    clsEditionEtatCaisse.MS_DATEPIECE = row["MS_DATEPIECE"].ToString();
                    clsEditionEtatCaisse.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
                    clsEditionEtatCaisse.JO_JOURNALCODE = row["JO_JOURNALCODE"].ToString();
                    clsEditionEtatCaisse.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsEditionEtatCaisse.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
                    clsEditionEtatCaisse.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                    clsEditionEtatCaisse.MV_NOMTIERS = row["MV_NOMTIERS"].ToString();
                    clsEditionEtatCaisse.MV_MONTANTDEBIT = (row["MV_MONTANTDEBIT"].ToString() != "") ? double.Parse(row["MV_MONTANTDEBIT"].ToString()) : 0;//row["MV_MONTANTDEBIT"].ToString();
                        clsEditionEtatCaisse.MV_MONTANTCREDIT = (row["MV_MONTANTCREDIT"].ToString() != "") ? double.Parse(row["MV_MONTANTCREDIT"].ToString()) : 0;// row["MV_MONTANTCREDIT"].ToString();
                        clsEditionEtatCaisse.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsEditionEtatCaisse.MC_SOLDE = (row["MC_SOLDE"].ToString() != "") ? double.Parse(row["MC_SOLDE"].ToString()) : 0;// row["MC_SOLDE"].ToString();
                        clsEditionEtatCaisse.JO_LIBELLE = row["JO_LIBELLE"].ToString();
                    clsEditionEtatCaisse.MV_NUMSEQUENCE = row["MV_NUMSEQUENCE"].ToString();
                    clsEditionEtatCaisse.MC_SOLDEPRECEDENT = (row["MC_SOLDEPRECEDENT"].ToString() != "") ? double.Parse(row["MC_SOLDEPRECEDENT"].ToString()) : 0;//row["MC_SOLDEPRECEDENT"].ToString();
                        clsEditionEtatCaisse.CO_CODECOMPTE = row["CO_CODECOMPTE"].ToString();
                    clsEditionEtatCaisse.CO_NUMEROSEQUENCE = row["CO_NUMEROSEQUENCE"].ToString();
                    clsEditionEtatCaisse.CL_CODECLIENT = row["CL_CODECLIENT"].ToString();
                    clsEditionEtatCaisse.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                    clsEditionEtatCaisse.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                    clsEditionEtatCaisse.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                    clsEditionEtatCaisse.PS_ABREVIATION = row["PS_ABREVIATION"].ToString();
                    clsEditionEtatCaisse.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                    clsEditionEtatCaisse.OP_LOGIN = row["OP_LOGIN"].ToString();
                    clsEditionEtatCaisse.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsEditionEtatCaisse.NO_CODENATUREOPERATION1 = row["NO_CODENATUREOPERATION1"].ToString();
                    clsEditionEtatCaisse.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsEditionEtatCaisse.MV_SOLDE = (row["MV_SOLDE"].ToString() != "") ? double.Parse(row["MV_SOLDE"].ToString()) : 0;//row["MV_SOLDE"].ToString();
                        clsEditionEtatCaisse.COCHER = row["COCHER"].ToString();
                    clsEditionEtatCaisse.LT_CODELETTRAGE = row["LT_CODELETTRAGE"].ToString();
                    clsEditionEtatCaisse.LT_LIBELLELETTRAGE = row["LT_LIBELLELETTRAGE"].ToString();
                    clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatCaisses;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatCaisse> pvgInsertIntoDatasetEtatResultat(List<HT_Stock.BOJ.clsEditionEtatCaisse> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatCaisses = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
                //--TEST CONTRAINTE
                clsEditionEtatCaisses = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse1 = new Stock.BOJ.clsEditionEtatCaisse();


                foreach (HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisseDTO in Objet)
                {


                    // "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TP_CODETYPETIERS", "@DATEDEBUT", "@DATEFIN", "@PL_NUMCOMPTE1", "@PL_NUMCOMPTE2",
                    //"@PL_NUMCOMPTETIERS", "@PL_OPTION", "@OP_CODEOPERATEUREDITION", "@GP_CODEGROUPE", "@PY_CODEPAYS", "@NT_CODENATURETIERS", "@ET_TYPEETAT", "@CODEDECRYPTAGE"

                    clsEditionEtatCaisse1.AG_CODEAGENCE = clsEditionEtatCaisseDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatCaisse1.EN_CODEENTREPOT = clsEditionEtatCaisseDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatCaisse1.TP_CODETYPETIERS = clsEditionEtatCaisseDTO.TP_CODETYPETIERS.ToString();
                    clsEditionEtatCaisse1.DATEDEBUT = clsEditionEtatCaisseDTO.DATEDEBUT.ToString();
                    clsEditionEtatCaisse1.DATEFIN = clsEditionEtatCaisseDTO.DATEFIN.ToString();
                    clsEditionEtatCaisse1.PL_NUMCOMPTE1 = clsEditionEtatCaisseDTO.PL_NUMCOMPTE1.ToString();
                    clsEditionEtatCaisse1.PL_NUMCOMPTE2 = clsEditionEtatCaisseDTO.PL_NUMCOMPTE2.ToString();
                    clsEditionEtatCaisse1.PL_NUMCOMPTETIERS = clsEditionEtatCaisseDTO.PL_NUMCOMPTETIERS.ToString();
                    clsEditionEtatCaisse1.PL_OPTION = clsEditionEtatCaisseDTO.PL_OPTION.ToString();
                    clsEditionEtatCaisse1.OP_CODEOPERATEUREDITION = clsEditionEtatCaisseDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatCaisse1.GP_CODEGROUPE = clsEditionEtatCaisseDTO.GP_CODEGROUPE.ToString();
                    clsEditionEtatCaisse1.PY_CODEPAYS = clsEditionEtatCaisseDTO.PY_CODEPAYS.ToString();
                    clsEditionEtatCaisse1.NT_CODENATURETIERS = clsEditionEtatCaisseDTO.NT_CODENATURETIERS.ToString();
                    clsEditionEtatCaisse1.ET_TYPEETAT = clsEditionEtatCaisseDTO.ET_TYPEETAT.ToString();

                    clsObjetEnvoi.OE_A = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatResultat(clsDonnee, clsEditionEtatCaisse1, clsObjetEnvoi);
                clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                        //clsEditionEtatCaisse.ET_INDEX = row["ET_INDEX"].ToString();
                        //clsEditionEtatCaisse.ET_LIBELLEEditionEtatCaisse = row["ET_LIBELLEEditionEtatCaisse"].ToString();


                        clsEditionEtatCaisse.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsEditionEtatCaisse.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                        clsEditionEtatCaisse.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsEditionEtatCaisse.EN_NUMENTREPOT = row["EN_NUMENTREPOT"].ToString();
                        clsEditionEtatCaisse.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsEditionEtatCaisse.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                        clsEditionEtatCaisse.PL_COMPTECOLLECTIF = row["PL_COMPTECOLLECTIF"].ToString();
                        clsEditionEtatCaisse.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsEditionEtatCaisse.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsEditionEtatCaisse.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsEditionEtatCaisse.MV_DATEPIECE = row["MV_DATEPIECE"].ToString();
                        clsEditionEtatCaisse.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsEditionEtatCaisse.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsEditionEtatCaisse.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                        clsEditionEtatCaisse.PL_TYPECOMPTE = row["PL_TYPECOMPTE"].ToString();
                        clsEditionEtatCaisse.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBIT = (row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString()) : 0;// row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDIT = (row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString()) : 0;//row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURS = (row["PL_MONTANTPERIODEDEBITENCOURS"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEDEBITENCOURS"].ToString()) : 0;//row["PL_MONTANTPERIODEDEBITENCOURS"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURS = (row["PL_MONTANTPERIODECREDITENCOURS"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODECREDITENCOURS"].ToString()) : 0;//row["PL_MONTANTPERIODECREDITENCOURS"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBIT = (row["PL_MONTANTSOLDEFINALDEBIT"].ToString() != "") ? double.Parse(row["PL_MONTANTSOLDEFINALDEBIT"].ToString()) : 0;//row["PL_MONTANTSOLDEFINALDEBIT"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDIT = (row["PL_MONTANTSOLDEFINALCREDIT"].ToString() != "") ? double.Parse(row["PL_MONTANTSOLDEFINALCREDIT"].ToString()) : 0;//row["PL_MONTANTSOLDEFINALCREDIT"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = (row["PL_MONTANTPERIODEPRECEDENTDEBITTOTAL"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTDEBITTOTAL"].ToString()) : 0;//row["PL_MONTANTPERIODEPRECEDENTDEBITTOTAL"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = (row["PL_MONTANTPERIODEPRECEDENTCREDITTOTAL"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTCREDITTOTAL"].ToString()) : 0;//row["PL_MONTANTPERIODEPRECEDENTCREDITTOTAL"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURSTOTAL = (row["PL_MONTANTPERIODEDEBITENCOURSTOTAL"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEDEBITENCOURSTOTAL"].ToString()) : 0;//row["PL_MONTANTPERIODEDEBITENCOURSTOTAL"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURSTOTAL = (row["PL_MONTANTPERIODECREDITENCOURSTOTAL"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODECREDITENCOURSTOTAL"].ToString()) : 0;//row["PL_MONTANTPERIODECREDITENCOURSTOTAL"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBITTOTAL = (row["PL_MONTANTSOLDEFINALDEBITTOTAL"].ToString() != "") ? double.Parse(row["PL_MONTANTSOLDEFINALDEBITTOTAL"].ToString()) : 0;//row["PL_MONTANTSOLDEFINALDEBITTOTAL"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDITTOTAL = (row["PL_MONTANTSOLDEFINALCREDITTOTAL"].ToString() != "") ? double.Parse(row["PL_MONTANTSOLDEFINALCREDITTOTAL"].ToString()) : 0;//row["PL_MONTANTSOLDEFINALCREDITTOTAL"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBITGESTION = (row["PL_MONTANTPERIODEPRECEDENTDEBITGESTION"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTDEBITGESTION"].ToString()) : 0;//row["PL_MONTANTPERIODEPRECEDENTDEBITGESTION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDITGESTION = (row["PL_MONTANTPERIODEPRECEDENTCREDITGESTION"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTCREDITGESTION"].ToString()) : 0;//row["PL_MONTANTPERIODEPRECEDENTCREDITGESTION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURSGESTION = (row["PL_MONTANTPERIODEDEBITENCOURSGESTION"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEDEBITENCOURSGESTION"].ToString()) : 0;//row["PL_MONTANTPERIODEDEBITENCOURSGESTION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURSGESTION = row["PL_MONTANTPERIODECREDITENCOURSGESTION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBITGESTION = row["PL_MONTANTSOLDEFINALDEBITGESTION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDITGESTION = row["PL_MONTANTSOLDEFINALCREDITGESTION"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTDEBITBILAN = row["PL_MONTANTPERIODEPRECEDENTDEBITBILAN"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEPRECEDENTCREDITBILAN = row["PL_MONTANTPERIODEPRECEDENTCREDITBILAN"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODEDEBITENCOURSBILAN = row["PL_MONTANTPERIODEDEBITENCOURSBILAN"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTPERIODECREDITENCOURSBILAN = row["PL_MONTANTPERIODECREDITENCOURSBILAN"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALDEBITBILAN = row["PL_MONTANTSOLDEFINALDEBITBILAN"].ToString();
                        clsEditionEtatCaisse.PL_MONTANTSOLDEFINALCREDITBILAN = row["PL_MONTANTSOLDEFINALCREDITBILAN"].ToString();
                        clsEditionEtatCaisse.PL_TOTALCHARGEFINPERIODE = row["PL_TOTALCHARGEFINPERIODE"].ToString();
                        clsEditionEtatCaisse.PL_TOTALPRODUITFINPERIODE = row["PL_TOTALPRODUITFINPERIODE"].ToString();
                        clsEditionEtatCaisse.PL_RESULTATNETPROVISOIRE = row["PL_RESULTATNETPROVISOIRE"].ToString();
                        clsEditionEtatCaisse.PL_TOTALCOMPTEGESTION = row["PL_TOTALCOMPTEGESTION"].ToString();
                        clsEditionEtatCaisse.PL_TOTALCOMPTEBILAN = row["PL_TOTALCOMPTEBILAN"].ToString();
                        clsEditionEtatCaisse.COMPTAPAR_SENS_CODE = row["COMPTAPAR_SENS_CODE"].ToString();
                        clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatCaisses;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatCaisse> pvgInsertIntoDatasetEtatPointPrestations(List<HT_Stock.BOJ.clsEditionEtatCaisse> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatCaisses = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
                //--TEST CONTRAINTE
                clsEditionEtatCaisses = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatCaisses[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatCaisses;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse1 = new Stock.BOJ.clsEditionEtatCaisse();


                foreach (HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisseDTO in Objet)
                {
                    clsEditionEtatCaisse1.AG_CODEAGENCE = clsEditionEtatCaisseDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatCaisse1.EN_CODEENTREPOT = clsEditionEtatCaisseDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatCaisse1.TP_CODETYPETIERS = clsEditionEtatCaisseDTO.TP_CODETYPETIERS.ToString();
                    clsEditionEtatCaisse1.DATEDEBUT = clsEditionEtatCaisseDTO.DATEDEBUT.ToString();
                    clsEditionEtatCaisse1.DATEFIN = clsEditionEtatCaisseDTO.DATEFIN.ToString();
                    clsEditionEtatCaisse1.OP_CODEOPERATEUREDITION = clsEditionEtatCaisseDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatCaisse1.GP_CODEGROUPE = clsEditionEtatCaisseDTO.GP_CODEGROUPE.ToString();
                    clsEditionEtatCaisse1.NT_CODENATURETIERS = clsEditionEtatCaisseDTO.NT_CODENATURETIERS.ToString();
                    clsEditionEtatCaisse1.TI_IDTIERSMEDECIN = clsEditionEtatCaisseDTO.TI_IDTIERSMEDECIN.ToString();
                    clsEditionEtatCaisse1.ET_TYPEETAT = clsEditionEtatCaisseDTO.ET_TYPEETAT.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatCaisseDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatPointPrestations(clsDonnee, clsEditionEtatCaisse1, clsObjetEnvoi);
                clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                        //clsEditionEtatCaisse.ET_INDEX = row["ET_INDEX"].ToString();
                        //clsEditionEtatCaisse.ET_LIBELLEEditionEtatCaisse = row["ET_LIBELLEEditionEtatCaisse"].ToString();
                      

                        clsEditionEtatCaisse.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();

                        clsEditionEtatCaisse.MR_CODEMODEREGLEMENT = row["MR_CODEMODEREGLEMENT"].ToString();
                        clsEditionEtatCaisse.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();


                        clsEditionEtatCaisse.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                        clsEditionEtatCaisse.MV_NUMPIECE = row["MV_NUMPIECE"].ToString();
                        clsEditionEtatCaisse.NO_CODENATUREOPERATION1 = row["NO_CODENATUREOPERATION1"].ToString();
                        clsEditionEtatCaisse.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsEditionEtatCaisse.MV_MONTANTDEBIT = row["MV_MONTANTDEBIT"].ToString();
                        clsEditionEtatCaisse.MV_MONTANTCREDIT = row["MV_MONTANTCREDIT"].ToString();
                        clsEditionEtatCaisse.MV_DATEPIECE = row["MV_DATEPIECE"].ToString();

                        clsEditionEtatCaisse.MV_ANNULATIONPIECE = row["MV_ANNULATIONPIECE"].ToString();
                        clsEditionEtatCaisse.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
                        clsEditionEtatCaisse.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                        clsEditionEtatCaisse.MV_NOMTIERS = row["MV_NOMTIERS"].ToString();
                        clsEditionEtatCaisse.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                        clsEditionEtatCaisse.MV_SOLDEPRECEDENT = row["MV_SOLDEPRECEDENT"].ToString();
                        clsEditionEtatCaisse.MV_NUMSEQUENCE = row["MV_NUMSEQUENCE"].ToString();
                        clsEditionEtatCaisse.MV_SOLDE = row["MV_SOLDE"].ToString();
                        clsEditionEtatCaisse.NUMEROBORDEREAU1 = row["NUMEROBORDEREAU1"].ToString();
                        clsEditionEtatCaisse.MV_SOLDEFINAL = row["MV_SOLDEFINAL"].ToString();
                        clsEditionEtatCaisse.MS_NUMSEQUENCE = row["MS_NUMSEQUENCE"].ToString();
                        clsEditionEtatCaisse.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsEditionEtatCaisse.MC_SOLDEPRECEDENT = row["MC_SOLDEPRECEDENT"].ToString();
                        clsEditionEtatCaisse.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsEditionEtatCaisse.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsEditionEtatCaisse.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                        clsEditionEtatCaisse.MR_LIBELLE = row["MR_LIBELLE"].ToString();
                        clsEditionEtatCaisse.TOTALCAISSE = row["TOTALCAISSE"].ToString();
                        clsEditionEtatCaisse.TOTALBANQUE = row["TOTALBANQUE"].ToString();
                        clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatCaisses;
        }

    }
}
