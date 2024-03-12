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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontrat" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontrat.svc ou wsCtcontrat.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontrat : IwsCtcontrat
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratWSBLL clsCtcontratWSBLL = new clsCtcontratWSBLL();

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
        public List<HT_Stock.BOJ.clsCtcontrat> pvgMiseAjour(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            string vlpRQ_CODERISQUE = "";

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }

           Stock.BOJ.clsCtcontrat clsCtcontrat1 = new Stock.BOJ.clsCtcontrat();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            List<Stock.BOJ.clsCtcontratgarantie> clsCtcontratgaranties = new List<BOJ.clsCtcontratgarantie>();
            List<Stock.BOJ.clsCtcontratprime> clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();
            List<Stock.BOJ.clsCtcontratreduction> clsCtcontratreductions = new List<BOJ.clsCtcontratreduction>();
            List<Stock.BOJ.clsCtcontratayantdroit> clsCtcontratayantdroits = new List<BOJ.clsCtcontratayantdroit>();
            List<Stock.BOJ.clsCtcontratcapitaux> clsCtcontratcapitauxs = new List<BOJ.clsCtcontratcapitaux>();
            try
            {
                clsDonnee.pvgConnectionBase();
                //clsDonnee.pvgDemarrerTransaction();
                foreach (HT_Stock.BOJ.clsCtcontrat clsCtcontratDTO in Objet)
                {
                    Stock.BOJ.clsCtcontrat clsCtcontrat = new Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.CA_CODECONTRAT = clsCtcontratDTO.CA_CODECONTRAT.ToString();
                    clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontrat.CA_NUMPOLICE = clsCtcontratDTO.CA_NUMPOLICE.ToString();
                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.TI_IDTIERS = clsCtcontratDTO.TI_IDTIERS.ToString();
                    clsCtcontrat.IT_CODEINTERMEDIAIRE = clsCtcontratDTO.IT_CODEINTERMEDIAIRE.ToString();
                    clsCtcontrat.AP_CODETYPEAPPARTEMENT = clsCtcontratDTO.AP_CODETYPEAPPARTEMENT.ToString();
                    clsCtcontrat.OC_CODETYPEOCCUPANT = clsCtcontratDTO.OC_CODETYPEOCCUPANT.ToString();
                    clsCtcontrat.ZA_CODEZONEAUTO = clsCtcontratDTO.ZA_CODEZONEAUTO.ToString();
                    clsCtcontrat.CB_IDBRANCHE = clsCtcontratDTO.CB_IDBRANCHE.ToString();
                    clsCtcontrat.CA_DATEEFFET = (clsCtcontratDTO.CA_DATEEFFET.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEEFFET.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEECHEANCE = (clsCtcontratDTO.CA_DATEECHEANCE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEECHEANCE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    clsCtcontrat.CA_AVENANT = clsCtcontratDTO.CA_AVENANT.ToString();
                    clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = clsCtcontratDTO.CA_SITUATIONGEOGRAPHIQUE.ToString();
                    clsCtcontrat.CA_CONDITIONHABITUEL = clsCtcontratDTO.CA_CONDITIONHABITUEL.ToString();
                    clsCtcontrat.ST_CODESTATUTSOCIOPROF = clsCtcontratDTO.ST_CODESTATUTSOCIOPROF.ToString();
                    clsCtcontrat.AU_CODECATEGORIE = clsCtcontratDTO.AU_CODECATEGORIE.ToString();
                    clsCtcontrat.TA_CODETARIF = clsCtcontratDTO.TA_CODETARIF.ToString();
                    clsCtcontrat.US_CODEUSAGE = clsCtcontratDTO.US_CODEUSAGE.ToString();
                    clsCtcontrat.GE_CODEGENRE = clsCtcontratDTO.GE_CODEGENRE.ToString();
                    clsCtcontrat.TVH_CODETYPE = clsCtcontratDTO.TVH_CODETYPE.ToString();
                    clsCtcontrat.EN_CODEENERGIE = clsCtcontratDTO.EN_CODEENERGIE.ToString();
                    clsCtcontrat.CA_TAUX = float.Parse(clsCtcontratDTO.CA_TAUX.ToString());
                    clsCtcontrat.CA_TYPE = clsCtcontratDTO.CA_TYPE.ToString();
                    clsCtcontrat.CA_NUMSERIE = clsCtcontratDTO.CA_NUMSERIE.ToString();
                    clsCtcontrat.CA_IMMATRICULATION = clsCtcontratDTO.CA_IMMATRICULATION.ToString();
                    clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(clsCtcontratDTO.CA_PUISSANCEADMISE.ToString());
                    clsCtcontrat.CA_CHARGEUTILE = int.Parse(clsCtcontratDTO.CA_CHARGEUTILE.ToString());
                    clsCtcontrat.CA_NBREPLACE = int.Parse(clsCtcontratDTO.CA_NBREPLACE.ToString());
                    clsCtcontrat.CA_VALNEUVE = Double.Parse(clsCtcontratDTO.CA_VALNEUVE.ToString());
                    clsCtcontrat.CA_VALVENALE = Double.Parse(clsCtcontratDTO.CA_VALVENALE.ToString());
                    clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_CLIENTEXONERETAXE = clsCtcontratDTO.CA_CLIENTEXONERETAXE.ToString();
                    clsCtcontrat.TI_IDTIERSCOMMERCIAL = clsCtcontratDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    clsCtcontrat.TI_IDTIERSASSUREUR = clsCtcontratDTO.TI_IDTIERSASSUREUR.ToString();
                    clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                  
                    clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATESUSPENSION = (clsCtcontratDTO.CA_DATESUSPENSION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESUSPENSION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATECLOTURE = (clsCtcontratDTO.CA_DATECLOTURE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATECLOTURE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATERESILIATION = (clsCtcontratDTO.CA_DATERESILIATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATERESILIATION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_NOMINTERLOCUTEUR = clsCtcontratDTO.CA_NOMINTERLOCUTEUR.ToString();
                    clsCtcontrat.CA_CONTACTINTERLOCUTEUR = clsCtcontratDTO.CA_CONTACTINTERLOCUTEUR.ToString();
                    clsCtcontrat.DI_CODEDESIGNATION = clsCtcontratDTO.DI_CODEDESIGNATION.ToString();
                    clsCtcontrat.TA_CODETYPECONTRATSANTE = clsCtcontratDTO.TA_CODETYPECONTRATSANTE.ToString();
                    clsCtcontrat.CA_CODECONTRATSECONDAIRE = clsCtcontratDTO.CA_CODECONTRATSECONDAIRE.ToString();
                    clsCtcontrat.CA_GESA = clsCtcontratDTO.CA_GESA.ToString();
                    clsCtcontrat.CO_CODECOMMUNE = clsCtcontratDTO.CO_CODECOMMUNE.ToString();
                    clsCtcontrat.RQ_CODERISQUE = clsCtcontratDTO.RQ_CODERISQUE.ToString();
                    vlpRQ_CODERISQUE = clsCtcontratDTO.RQ_CODERISQUE.ToString();
                    clsCtcontrat.TA_CODETYPEAFFAIRES = clsCtcontratDTO.TA_CODETYPEAFFAIRES.ToString();
                    clsCtcontrat.MF_CODEMAINFORTE = clsCtcontratDTO.MF_CODEMAINFORTE.ToString();
                    clsCtcontrat.ZM_CODEZONEVOYAGE = clsCtcontratDTO.ZM_CODEZONEVOYAGE.ToString();
                    clsCtcontrat.CA_NOMBREPIECE =int.Parse(clsCtcontratDTO.CA_NOMBREPIECE.ToString());
                    clsCtcontrat.CA_SUPERFICIE = float.Parse(clsCtcontratDTO.CA_SUPERFICIE.ToString());
                    clsCtcontrat.CA_LOYERMENSUEL = double.Parse(clsCtcontratDTO.CA_LOYERMENSUEL.ToString());
                    clsCtcontrat.CA_DATENAISSANCE =DateTime.Parse(clsCtcontratDTO.CA_DATENAISSANCE.ToString());
                    clsCtcontrat.PF_CODEPROFESSION = clsCtcontratDTO.PF_CODEPROFESSION.ToString();
                    clsCtcontrat.CA_LIEUNAISSANCE = clsCtcontratDTO.CA_LIEUNAISSANCE.ToString();
                    clsCtcontrat.CD_CODECONDITION = clsCtcontratDTO.CD_CODECONDITION.ToString();
                    clsCtcontrat.CA_DUREEENMOIS =int.Parse(clsCtcontratDTO.CA_DUREEENMOIS.ToString());
                    clsCtcontrat.AC_SPORT = clsCtcontratDTO.AC_SPORT.ToString();
                    clsCtcontrat.CA_ADRESSE = clsCtcontratDTO.CA_ADRESSE.ToString();
                    clsCtcontrat.CA_NUMPASSEPORT = clsCtcontratDTO.CA_NUMPASSEPORT.ToString();
                    clsCtcontrat.PY_CODEPAYSDESTINATION = clsCtcontratDTO.PY_CODEPAYSDESTINATION.ToString();
                    clsCtcontrat.CA_DUREESEJOUR = int.Parse(clsCtcontratDTO.CA_DUREESEJOUR.ToString());
                    clsCtcontrat.CA_OPTION = clsCtcontratDTO.CA_OPTION.ToString();
                    clsCtcontrat.AU_CODETYPECONTRATAUTO = clsCtcontratDTO.AU_CODETYPECONTRATAUTO.ToString();
                    clsCtcontrat.TYPEOPERATION =int.Parse(clsCtcontratDTO.TYPEOPERATION.ToString());

                    clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT = (clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_CODECONTRATORIGINE = clsCtcontratDTO.CA_CODECONTRATORIGINE.ToString();
                    clsCtcontrat.GR_CODEGARENTIEPRIME = clsCtcontratDTO.GR_CODEGARENTIEPRIME.ToString();
                    clsCtcontrat.CA_OBSERVATION = clsCtcontratDTO.CA_OBSERVATION.ToString();
                    clsCtcontrat.DE_CODEDEMANADE = clsCtcontratDTO.DE_CODEDEMANADE.ToString();
                    clsCtcontrat.EX_EXERCICE = clsCtcontratDTO.EX_EXERCICE.ToString();
                    clsCtcontrat.AS_NUMEROASSUREUR = clsCtcontratDTO.AS_NUMEROASSUREUR.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsCtcontratgaranties = new List<BOJ.clsCtcontratgarantie>();
                    if (clsCtcontratDTO.clsCtcontratgaranties != null)
                    foreach (HT_Stock.BOJ.clsCtcontratgarantie clsCtcontratgarantieDTO in clsCtcontratDTO.clsCtcontratgaranties)
                    {
                        BOJ.clsCtcontratgarantie clsCtcontratgarantie = new BOJ.clsCtcontratgarantie();
                        clsCtcontratgarantie.AG_CODEAGENCE = clsCtcontratgarantieDTO.AG_CODEAGENCE;
                        clsCtcontratgarantie.CA_CODECONTRAT = clsCtcontratgarantieDTO.CA_CODECONTRAT;
                        clsCtcontratgarantie.CG_APRESREDUCTION = clsCtcontratgarantieDTO.CG_APRESREDUCTION;
                        clsCtcontratgarantie.CG_CAPITAUXASSURES =clsCtcontratgarantieDTO.CG_CAPITAUXASSURES;
                        clsCtcontratgarantie.CG_FRANCHISES = clsCtcontratgarantieDTO.CG_FRANCHISES.ToString();
                        clsCtcontratgarantie.CG_LIBELLE = clsCtcontratgarantieDTO.CG_LIBELLE;
                        clsCtcontratgarantie.CG_MONTANT = clsCtcontratgarantieDTO.CG_MONTANT;
                        clsCtcontratgarantie.CG_PRIMES = clsCtcontratgarantieDTO.CG_PRIMES;
                        clsCtcontratgarantie.CG_PRORATA = clsCtcontratgarantieDTO.CG_PRORATA;
                        clsCtcontratgarantie.CG_TAUX = float.Parse(clsCtcontratgarantieDTO.CG_TAUX);
                        clsCtcontratgarantie.EN_CODEENTREPOT = clsCtcontratgarantieDTO.EN_CODEENTREPOT;
                        clsCtcontratgarantie.GA_CODEGARANTIE = clsCtcontratgarantieDTO.GA_CODEGARANTIE;
                        clsCtcontratgarantie.CG_GARANTIE = clsCtcontratgarantieDTO.CG_GARANTIE;
                        clsCtcontratgaranties.Add(clsCtcontratgarantie);
                    }

                    //=====
                    clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();
                    if (clsCtcontratDTO.clsCtcontratprimes != null)
                    foreach (HT_Stock.BOJ.clsCtcontratprime clsCtcontratprimeDTO in clsCtcontratDTO.clsCtcontratprimes)
                    {
                        BOJ.clsCtcontratprime clsCtcontratprime = new BOJ.clsCtcontratprime();
                        clsCtcontratprime.AG_CODEAGENCE = clsCtcontratprimeDTO.AG_CODEAGENCE;
                        clsCtcontratprime.CA_CODECONTRAT = clsCtcontratprimeDTO.CA_CODECONTRAT;
                        clsCtcontratprime.CP_VALEUR =clsCtcontratprimeDTO.CP_VALEUR;
                        clsCtcontratprime.EN_CODEENTREPOT = clsCtcontratprimeDTO.EN_CODEENTREPOT;
                        clsCtcontratprime.RE_CODERESUME = clsCtcontratprimeDTO.RE_CODERESUME;
                        clsCtcontratprimes.Add(clsCtcontratprime);
                    }

                    //=====
                    clsCtcontratreductions = new List<BOJ.clsCtcontratreduction>();
                    if(clsCtcontratDTO.clsCtcontratreductions!=null)
                    foreach (HT_Stock.BOJ.clsCtcontratreduction clsCtcontratreductionDTO in clsCtcontratDTO.clsCtcontratreductions)
                    {
                        BOJ.clsCtcontratreduction clsCtcontratreduction = new BOJ.clsCtcontratreduction();
                        clsCtcontratreduction.AG_CODEAGENCE = clsCtcontratreductionDTO.AG_CODEAGENCE;
                        clsCtcontratreduction.EN_CODEENTREPOT = clsCtcontratreductionDTO.EN_CODEENTREPOT;
                        clsCtcontratreduction.CA_CODECONTRAT = clsCtcontratreductionDTO.CA_CODECONTRAT;
                        clsCtcontratreduction.RD_CODEREDUCTION = clsCtcontratreductionDTO.RD_CODEREDUCTION;
                        clsCtcontratreduction.RD_TAUX =float.Parse(clsCtcontratreductionDTO.RD_TAUX);
                        clsCtcontratreduction.RD_MONTANT = clsCtcontratreductionDTO.RD_MONTANT;

                        clsCtcontratreductions.Add(clsCtcontratreduction);
                    }
                    //=====
                    clsCtcontratayantdroits = new List<BOJ.clsCtcontratayantdroit>();
                    if(clsCtcontratDTO.clsCtcontratayantdroits != null)
                    foreach (HT_Stock.BOJ.clsCtcontratayantdroit clsCtcontratayantdroitDTO in clsCtcontratDTO.clsCtcontratayantdroits)
                    {
                        BOJ.clsCtcontratayantdroit clsCtcontratayantdroit = new BOJ.clsCtcontratayantdroit();
                            clsCtcontratayantdroit.AG_CODEAGENCE = clsCtcontratayantdroitDTO.AG_CODEAGENCE;
                            clsCtcontratayantdroit.EN_CODEENTREPOT = clsCtcontratayantdroitDTO.EN_CODEENTREPOT;
                            clsCtcontratayantdroit.CA_CODECONTRAT = clsCtcontratayantdroitDTO.CA_CODECONTRAT;
                            clsCtcontratayantdroit.AY_DENOMMINATIONAYANTDROIT = clsCtcontratayantdroitDTO.AY_DENOMMINATIONAYANTDROIT;
                            clsCtcontratayantdroit.AY_DATESAISIE =DateTime.Parse(clsCtcontratayantdroitDTO.AY_DATESAISIE);
                            clsCtcontratayantdroit.AY_INDEX = clsCtcontratayantdroitDTO.AY_INDEX;
                            clsCtcontratayantdroit.AY_DATECLOTURE = DateTime.Parse(clsCtcontratayantdroitDTO.AY_DATECLOTURE); 
                            clsCtcontratayantdroit.TA_CODETITREAYANTDROIT = clsCtcontratayantdroitDTO.TA_CODETITREAYANTDROIT;
                            clsCtcontratayantdroit.OP_CODEOPERATEUR = clsCtcontratayantdroitDTO.OP_CODEOPERATEUR;
                            clsCtcontratayantdroit.AY_TAUX =double.Parse( clsCtcontratayantdroitDTO.AY_TAUX);
                            clsCtcontratayantdroits.Add(clsCtcontratayantdroit);
                    }
                    //=====
                    clsCtcontratcapitauxs = new List<BOJ.clsCtcontratcapitaux>();
                    if(clsCtcontratDTO.clsCtcontratcapitauxs != null)
                    foreach (HT_Stock.BOJ.clsCtcontratcapitaux clsCtcontratcapitauxDTO in clsCtcontratDTO.clsCtcontratcapitauxs)
                    {
                        BOJ.clsCtcontratcapitaux clsCtcontratcapitaux = new BOJ.clsCtcontratcapitaux();
                            clsCtcontratcapitaux.AG_CODEAGENCE = clsCtcontratcapitauxDTO.AG_CODEAGENCE;
                            clsCtcontratcapitaux.EN_CODEENTREPOT = clsCtcontratcapitauxDTO.EN_CODEENTREPOT;
                            clsCtcontratcapitaux.CA_CODECONTRAT = clsCtcontratcapitauxDTO.CA_CODECONTRAT;
                            clsCtcontratcapitaux.CC_CAPITAUX =clsCtcontratcapitauxDTO.CC_CAPITAUX;
                            clsCtcontratcapitaux.CC_PRIMES =clsCtcontratcapitauxDTO.CC_PRIMES;
                             clsCtcontratcapitaux.CC_TAUX =float.Parse( clsCtcontratcapitauxDTO.CC_TAUX);   
                             clsCtcontratcapitaux.CP_CODECAPITAUX =clsCtcontratcapitauxDTO.CP_CODECAPITAUX;                              
                                                    
                            clsCtcontratcapitauxs.Add(clsCtcontratcapitaux);
                    }


                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjour(clsDonnee, clsCtcontrat, clsCtcontratgaranties, clsCtcontratprimes, clsCtcontratreductions, clsCtcontratayantdroits, clsCtcontratcapitauxs, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                    if (clsCtcontrat.TYPEOPERATION == 0)
                    {
                        if (clsObjetRetour.OR_BOOLEEN)
                        {

                            string TI_NUMTIERS = "";
                            string TI_DENOMINATION = "";

                            string TI_TELEPHONE = "";
                            string EN_CODEENTREPOT = "";

                            DataSet DataSet = new DataSet();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.TI_IDTIERS };
                            clsPhatiersWSBLL clsPhatiersWSBLL = new clsPhatiersWSBLL();
                            DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetAssure(clsDonnee, clsObjetEnvoi);
                            foreach (DataRow row in DataSet.Tables[0].Rows)
                            {
                                TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                                TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                                TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                                EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();

                            }

                            
                            clsObjetEnvoi.OE_PARAM = new string[] { vlpRQ_CODERISQUE };
                            clsCtparrisqueassuranceWSBLL clsCtparrisqueassuranceWSBLL = new clsCtparrisqueassuranceWSBLL();
                               Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new Stock.BOJ.clsCtparrisqueassurance();
                            clsCtparrisqueassurance = clsCtparrisqueassuranceWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                            BOJ.clsParams clsParams = new BOJ.clsParams();
                            if (TI_TELEPHONE != "")
                            {

                                clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                //if (CL_CONTACT.Length == 10)
                                //    CL_CONTACT = "00225" + CL_CONTACT;
                                string CL_IDCLIENT = "";
                                string SL_MESSAGECLIENT = "PO:" + clsCtcontrat.CA_NUMPOLICE + "#DE:" + clsCtcontrat.CA_DATEEFFET.ToShortDateString()+ "#DC:" + clsCtcontrat.CA_DATEECHEANCE.ToShortDateString()+ "#CT:" + clsCtparrisqueassurance.RQ_LIBELLERISQUE;// clsParams.SMSTEXT;
                                string SL_RESULTATAPI = "";
                                string SL_MESSAGEAPI = "";
                                string SL_MESSAGE = "";

                                //clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebmotpasseoublieListe[0].AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT, clsMiccomptewebmotpasseoublieListe[0].OP_CODEOPERATEUR, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, "", CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);

                                //clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string SM_TELEPHONE, string OP_CODEOPERATEUR, DateTime SM_DATEPIECE, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2
                                clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, Objet[0].AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, "compte", "FrmClientPhysique", TI_TELEPHONE, clsCtcontrat.OP_CODEOPERATEUR, clsCtcontrat.CA_DATESAISIE, "", clsCtcontrat.TI_IDTIERS, "", SL_MESSAGECLIENT, "0005", "0", clsCtcontrat.CA_DATESAISIE.ToShortDateString(), "0", "", "N", "0", "", "");


                                SL_RESULTATAPI = clsParams.SL_RESULTAT;
                                SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                                if (clsParams.SL_RESULTAT == "FALSE") SL_MESSAGE = SL_MESSAGE + " " + SL_MESSAGEAPI;



                            }
                        }
                    }
                    //=====

                    clsCtcontrat.CA_CODECONTRAT = clsObjetRetour.OR_STRING;
                    clsCtcontrat.CA_CODECONTRATORIGINE = clsCtcontratDTO.CA_CODECONTRATORIGINE.ToString();
                    clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();

                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATESUSPENSION = (clsCtcontratDTO.CA_DATESUSPENSION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESUSPENSION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATECLOTURE = (clsCtcontratDTO.CA_DATECLOTURE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATECLOTURE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATERESILIATION = (clsCtcontratDTO.CA_DATERESILIATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATERESILIATION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT = (clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.TYPEOPERATION = int.Parse("4");


                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjourStatutContrat(clsDonnee, clsCtcontrat, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
                //clsDonnee.pvgTerminerTransaction();

            }
            return clsCtcontrats;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontrat> pvgMiseAjourPrimeContrat(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireInsertModifficationPrime(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }

            Stock.BOJ.clsCtcontrat clsCtcontrat1 = new Stock.BOJ.clsCtcontrat();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            List<Stock.BOJ.clsCtcontratprime> clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();

            try
            {
                clsDonnee.pvgConnectionBase();
                //clsDonnee.pvgDemarrerTransaction();
                foreach (HT_Stock.BOJ.clsCtcontrat clsCtcontratDTO in Objet)
                {
                    Stock.BOJ.clsCtcontrat clsCtcontrat = new Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.CA_CODECONTRAT = clsCtcontratDTO.CA_CODECONTRAT.ToString();
                    clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontrat.CA_NUMPOLICE = clsCtcontratDTO.CA_NUMPOLICE.ToString();
                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();
                    if (clsCtcontratDTO.clsCtcontratprimes != null)
                        foreach (HT_Stock.BOJ.clsCtcontratprime clsCtcontratprimeDTO in clsCtcontratDTO.clsCtcontratprimes)
                        {
                            BOJ.clsCtcontratprime clsCtcontratprime = new BOJ.clsCtcontratprime();
                            clsCtcontratprime.AG_CODEAGENCE = clsCtcontratprimeDTO.AG_CODEAGENCE;
                            clsCtcontratprime.CA_CODECONTRAT = clsCtcontratprimeDTO.CA_CODECONTRAT;
                            clsCtcontratprime.CP_VALEUR = clsCtcontratprimeDTO.CP_VALEUR;
                            clsCtcontratprime.EN_CODEENTREPOT = clsCtcontratprimeDTO.EN_CODEENTREPOT;
                            clsCtcontratprime.RE_CODERESUME = clsCtcontratprimeDTO.RE_CODERESUME;
                            clsCtcontratprimes.Add(clsCtcontratprime);
                        }

                  
                   



                    clsPhamouvementStockWSBLL clsPhamouvementStockWSBLL = new clsPhamouvementStockWSBLL();
                    Stock.BOJ.clsPhamouvementStock clsPhamouvementStock1 = new Stock.BOJ.clsPhamouvementStock();
                    string vlpMS_DATESAISIE = clsCtcontrat.CA_DATESAISIE.ToShortDateString();
                    string vlpMS_DATEPIECE = "" ;
                    clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].MS_NUMPIECE };
                    clsPhamouvementStock1 = clsPhamouvementStockWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                    vlpMS_DATEPIECE = clsPhamouvementStock1.MS_DATEPIECE.ToShortDateString();

                     clsPhamouvementStockWSBLL = new clsPhamouvementStockWSBLL();
                    clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].MS_NUMPIECE, vlpMS_DATESAISIE, vlpMS_DATEPIECE, "P", Objet[0].OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsPhamouvementStockWSBLL.pvgAnnulationApprovisionnementVente(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);

                    //=====
                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjourPrimeContrat(clsDonnee, clsCtcontrat,  clsCtcontratprimes, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                    //=====

                    clsCtcontrat.CA_CODECONTRAT = clsObjetRetour.OR_STRING;



                    //+++++++++++++++++++++
                    //clsCtcontrat.CA_CODECONTRAT = clsObjetRetour.OR_STRING;
                    //clsCtcontrat.CA_CODECONTRATORIGINE = clsCtcontratDTO.CA_CODECONTRATORIGINE.ToString();
                    //clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    //clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();

                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATESUSPENSION = (clsCtcontratDTO.CA_DATESUSPENSION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESUSPENSION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATECLOTURE = (clsCtcontratDTO.CA_DATECLOTURE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATECLOTURE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATERESILIATION = (clsCtcontratDTO.CA_DATERESILIATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATERESILIATION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT = (clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.TYPEOPERATION = int.Parse("4");

                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjourStatutContrat(clsDonnee, clsCtcontrat, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                    //+++++++++++++++++++++






                }
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontrats;
        }

        public List<HT_Stock.BOJ.clsCtcontrat> pvgMiseAjourStatutContrat(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }

            Stock.BOJ.clsCtcontrat clsCtcontrat1 = new Stock.BOJ.clsCtcontrat();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsCtcontratgarantie> clsCtcontratgaranties = new List<BOJ.clsCtcontratgarantie>();
            //List<Stock.BOJ.clsCtcontratprime> clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();
            //List<Stock.BOJ.clsCtcontratreduction> clsCtcontratreductions = new List<BOJ.clsCtcontratreduction>();
            //List<Stock.BOJ.clsCtcontratayantdroit> clsCtcontratayantdroits = new List<BOJ.clsCtcontratayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontrat clsCtcontratDTO in Objet)
                {
                    Stock.BOJ.clsCtcontrat clsCtcontrat = new Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.CA_CODECONTRAT = clsCtcontratDTO.CA_CODECONTRAT.ToString();
                    clsCtcontrat.CA_CODECONTRATORIGINE = clsCtcontratDTO.CA_CODECONTRATORIGINE.ToString();
                    clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();
                    //clsCtcontrat.CA_NUMPOLICE = clsCtcontratDTO.CA_NUMPOLICE.ToString();
                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESAISIE.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.TI_IDTIERS = clsCtcontratDTO.TI_IDTIERS.ToString();
                    //clsCtcontrat.IT_CODEINTERMEDIAIRE = clsCtcontratDTO.IT_CODEINTERMEDIAIRE.ToString();
                    //clsCtcontrat.AP_CODETYPEAPPARTEMENT = clsCtcontratDTO.AP_CODETYPEAPPARTEMENT.ToString();
                    //clsCtcontrat.OC_CODETYPEOCCUPANT = clsCtcontratDTO.OC_CODETYPEOCCUPANT.ToString();
                    //clsCtcontrat.ZA_CODEZONEAUTO = clsCtcontratDTO.ZA_CODEZONEAUTO.ToString();
                    //clsCtcontrat.CB_IDBRANCHE = clsCtcontratDTO.CB_IDBRANCHE.ToString();
                    //clsCtcontrat.CA_DATEEFFET = (clsCtcontratDTO.CA_DATEEFFET.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEEFFET.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.CA_DATEECHEANCE = (clsCtcontratDTO.CA_DATEECHEANCE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEECHEANCE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    //clsCtcontrat.CA_AVENANT = clsCtcontratDTO.CA_AVENANT.ToString();
                    //clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = clsCtcontratDTO.CA_SITUATIONGEOGRAPHIQUE.ToString();
                    //clsCtcontrat.CA_CONDITIONHABITUEL = clsCtcontratDTO.CA_CONDITIONHABITUEL.ToString();
                    //clsCtcontrat.ST_CODESTATUTSOCIOPROF = clsCtcontratDTO.ST_CODESTATUTSOCIOPROF.ToString();
                    //clsCtcontrat.AU_CODECATEGORIE = clsCtcontratDTO.AU_CODECATEGORIE.ToString();
                    //clsCtcontrat.TA_CODETARIF = clsCtcontratDTO.TA_CODETARIF.ToString();
                    //clsCtcontrat.US_CODEUSAGE = clsCtcontratDTO.US_CODEUSAGE.ToString();
                    //clsCtcontrat.GE_CODEGENRE = clsCtcontratDTO.GE_CODEGENRE.ToString();
                    //clsCtcontrat.TVH_CODETYPE = clsCtcontratDTO.TVH_CODETYPE.ToString();
                    //clsCtcontrat.EN_CODEENERGIE = clsCtcontratDTO.EN_CODEENERGIE.ToString();
                    //clsCtcontrat.CA_TAUX = float.Parse(clsCtcontratDTO.CA_TAUX.ToString());
                    //clsCtcontrat.CA_TYPE = clsCtcontratDTO.CA_TYPE.ToString();
                    //clsCtcontrat.CA_NUMSERIE = clsCtcontratDTO.CA_NUMSERIE.ToString();
                    //clsCtcontrat.CA_IMMATRICULATION = clsCtcontratDTO.CA_IMMATRICULATION.ToString();
                    //clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(clsCtcontratDTO.CA_PUISSANCEADMISE.ToString());
                    //clsCtcontrat.CA_CHARGEUTILE = int.Parse(clsCtcontratDTO.CA_CHARGEUTILE.ToString());
                    //clsCtcontrat.CA_NBREPLACE = int.Parse(clsCtcontratDTO.CA_NBREPLACE.ToString());
                    //clsCtcontrat.CA_VALNEUVE = Double.Parse(clsCtcontratDTO.CA_VALNEUVE.ToString());
                    //clsCtcontrat.CA_VALVENALE = Double.Parse(clsCtcontratDTO.CA_VALVENALE.ToString());
                    //clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.CA_CLIENTEXONERETAXE = clsCtcontratDTO.CA_CLIENTEXONERETAXE.ToString();
                    //clsCtcontrat.TI_IDTIERSCOMMERCIAL = clsCtcontratDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    //clsCtcontrat.TI_IDTIERSASSUREUR = clsCtcontratDTO.TI_IDTIERSASSUREUR.ToString();

                    clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                    
                    //clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATESUSPENSION = (clsCtcontratDTO.CA_DATESUSPENSION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESUSPENSION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATECLOTURE = (clsCtcontratDTO.CA_DATECLOTURE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATECLOTURE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATERESILIATION = (clsCtcontratDTO.CA_DATERESILIATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATERESILIATION.ToString()) : DateTime.Parse("01/01/1900");

                    //clsCtcontrat.CA_NOMINTERLOCUTEUR = clsCtcontratDTO.CA_NOMINTERLOCUTEUR.ToString();
                    //clsCtcontrat.CA_CONTACTINTERLOCUTEUR = clsCtcontratDTO.CA_CONTACTINTERLOCUTEUR.ToString();
                    //clsCtcontrat.DI_CODEDESIGNATION = clsCtcontratDTO.DI_CODEDESIGNATION.ToString();
                    //clsCtcontrat.TA_CODETYPECONTRATSANTE = clsCtcontratDTO.TA_CODETYPECONTRATSANTE.ToString();
                    //clsCtcontrat.CA_CODECONTRATSECONDAIRE = clsCtcontratDTO.CA_CODECONTRATSECONDAIRE.ToString();
                    //clsCtcontrat.CA_GESA = clsCtcontratDTO.CA_GESA.ToString();
                    //clsCtcontrat.CO_CODECOMMUNE = clsCtcontratDTO.CO_CODECOMMUNE.ToString();
                    //clsCtcontrat.RQ_CODERISQUE = clsCtcontratDTO.RQ_CODERISQUE.ToString();
                    //clsCtcontrat.TA_CODETYPEAFFAIRES = clsCtcontratDTO.TA_CODETYPEAFFAIRES.ToString();
                    //clsCtcontrat.MF_CODEMAINFORTE = clsCtcontratDTO.MF_CODEMAINFORTE.ToString();
                    //clsCtcontrat.ZM_CODEZONEVOYAGE = clsCtcontratDTO.ZM_CODEZONEVOYAGE.ToString();

                    clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT = (clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString()) : DateTime.Parse("01/01/1900");



                    clsCtcontrat.TYPEOPERATION = int.Parse(clsCtcontratDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtcontratDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjourStatutContrat(clsDonnee, clsCtcontrat, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontrats;
        }

        public List<HT_Stock.BOJ.clsCtcontrat> pvgRenouvelementContrat(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireRenouvelement(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }

            Stock.BOJ.clsCtcontrat clsCtcontrat1 = new Stock.BOJ.clsCtcontrat();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsCtcontratgarantie> clsCtcontratgaranties = new List<BOJ.clsCtcontratgarantie>();
            //List<Stock.BOJ.clsCtcontratprime> clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();
            //List<Stock.BOJ.clsCtcontratreduction> clsCtcontratreductions = new List<BOJ.clsCtcontratreduction>();
            //List<Stock.BOJ.clsCtcontratayantdroit> clsCtcontratayantdroits = new List<BOJ.clsCtcontratayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontrat clsCtcontratDTO in Objet)
                {
                    Stock.BOJ.clsCtcontrat clsCtcontrat = new Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.CA_CODECONTRAT = clsCtcontratDTO.CA_CODECONTRAT.ToString();
                    clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();
                    //clsCtcontrat.CA_NUMPOLICE = clsCtcontratDTO.CA_NUMPOLICE.ToString();
                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.DATEJOURNEE.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.TI_IDTIERS = clsCtcontratDTO.TI_IDTIERS.ToString();
                    //clsCtcontrat.IT_CODEINTERMEDIAIRE = clsCtcontratDTO.IT_CODEINTERMEDIAIRE.ToString();
                    //clsCtcontrat.AP_CODETYPEAPPARTEMENT = clsCtcontratDTO.AP_CODETYPEAPPARTEMENT.ToString();
                    //clsCtcontrat.OC_CODETYPEOCCUPANT = clsCtcontratDTO.OC_CODETYPEOCCUPANT.ToString();
                    //clsCtcontrat.ZA_CODEZONEAUTO = clsCtcontratDTO.ZA_CODEZONEAUTO.ToString();
                    //clsCtcontrat.CB_IDBRANCHE = clsCtcontratDTO.CB_IDBRANCHE.ToString();
                    //clsCtcontrat.CA_DATEEFFET = (clsCtcontratDTO.CA_DATEEFFET.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEEFFET.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.CA_DATEECHEANCE = (clsCtcontratDTO.CA_DATEECHEANCE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEECHEANCE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    //clsCtcontrat.CA_AVENANT = clsCtcontratDTO.CA_AVENANT.ToString();
                    //clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = clsCtcontratDTO.CA_SITUATIONGEOGRAPHIQUE.ToString();
                    //clsCtcontrat.CA_CONDITIONHABITUEL = clsCtcontratDTO.CA_CONDITIONHABITUEL.ToString();
                    //clsCtcontrat.ST_CODESTATUTSOCIOPROF = clsCtcontratDTO.ST_CODESTATUTSOCIOPROF.ToString();
                    //clsCtcontrat.AU_CODECATEGORIE = clsCtcontratDTO.AU_CODECATEGORIE.ToString();
                    //clsCtcontrat.TA_CODETARIF = clsCtcontratDTO.TA_CODETARIF.ToString();
                    //clsCtcontrat.US_CODEUSAGE = clsCtcontratDTO.US_CODEUSAGE.ToString();
                    //clsCtcontrat.GE_CODEGENRE = clsCtcontratDTO.GE_CODEGENRE.ToString();
                    //clsCtcontrat.TVH_CODETYPE = clsCtcontratDTO.TVH_CODETYPE.ToString();
                    //clsCtcontrat.EN_CODEENERGIE = clsCtcontratDTO.EN_CODEENERGIE.ToString();
                    //clsCtcontrat.CA_TAUX = float.Parse(clsCtcontratDTO.CA_TAUX.ToString());
                    //clsCtcontrat.CA_TYPE = clsCtcontratDTO.CA_TYPE.ToString();
                    //clsCtcontrat.CA_NUMSERIE = clsCtcontratDTO.CA_NUMSERIE.ToString();
                    //clsCtcontrat.CA_IMMATRICULATION = clsCtcontratDTO.CA_IMMATRICULATION.ToString();
                    //clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(clsCtcontratDTO.CA_PUISSANCEADMISE.ToString());
                    //clsCtcontrat.CA_CHARGEUTILE = int.Parse(clsCtcontratDTO.CA_CHARGEUTILE.ToString());
                    //clsCtcontrat.CA_NBREPLACE = int.Parse(clsCtcontratDTO.CA_NBREPLACE.ToString());
                    //clsCtcontrat.CA_VALNEUVE = Double.Parse(clsCtcontratDTO.CA_VALNEUVE.ToString());
                    //clsCtcontrat.CA_VALVENALE = Double.Parse(clsCtcontratDTO.CA_VALVENALE.ToString());
                    //clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.CA_CLIENTEXONERETAXE = clsCtcontratDTO.CA_CLIENTEXONERETAXE.ToString();
                    //clsCtcontrat.TI_IDTIERSCOMMERCIAL = clsCtcontratDTO.TI_IDTIERSCOMMERCIAL.ToString();
                    //clsCtcontrat.TI_IDTIERSASSUREUR = clsCtcontratDTO.TI_IDTIERSASSUREUR.ToString();

                    clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                    
                    //clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATESUSPENSION = (clsCtcontratDTO.CA_DATESUSPENSION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESUSPENSION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATECLOTURE = (clsCtcontratDTO.CA_DATECLOTURE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATECLOTURE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATERESILIATION = (clsCtcontratDTO.CA_DATERESILIATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATERESILIATION.ToString()) : DateTime.Parse("01/01/1900");

                    //clsCtcontrat.CA_NOMINTERLOCUTEUR = clsCtcontratDTO.CA_NOMINTERLOCUTEUR.ToString();
                    //clsCtcontrat.CA_CONTACTINTERLOCUTEUR = clsCtcontratDTO.CA_CONTACTINTERLOCUTEUR.ToString();
                    //clsCtcontrat.DI_CODEDESIGNATION = clsCtcontratDTO.DI_CODEDESIGNATION.ToString();
                    //clsCtcontrat.TA_CODETYPECONTRATSANTE = clsCtcontratDTO.TA_CODETYPECONTRATSANTE.ToString();
                    //clsCtcontrat.CA_CODECONTRATSECONDAIRE = clsCtcontratDTO.CA_CODECONTRATSECONDAIRE.ToString();
                    //clsCtcontrat.CA_GESA = clsCtcontratDTO.CA_GESA.ToString();
                    //clsCtcontrat.CO_CODECOMMUNE = clsCtcontratDTO.CO_CODECOMMUNE.ToString();
                    //clsCtcontrat.RQ_CODERISQUE = clsCtcontratDTO.RQ_CODERISQUE.ToString();
                    //clsCtcontrat.TA_CODETYPEAFFAIRES = clsCtcontratDTO.TA_CODETYPEAFFAIRES.ToString();
                    //clsCtcontrat.MF_CODEMAINFORTE = clsCtcontratDTO.MF_CODEMAINFORTE.ToString();
                    //clsCtcontrat.ZM_CODEZONEVOYAGE = clsCtcontratDTO.ZM_CODEZONEVOYAGE.ToString();

                    // HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();

                    clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT = (clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString()) : DateTime.Parse("01/01/1900");


                    clsCtcontrat.TYPEOPERATION = int.Parse(clsCtcontratDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtcontratDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjourStatutContrat(clsDonnee, clsCtcontrat, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);

            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }


            return clsCtcontrats;
        }


        public List<HT_Stock.BOJ.clsCtcontrat> pvgSaisieObservation(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireSaisieObservation(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }

            Stock.BOJ.clsCtcontrat clsCtcontrat1 = new Stock.BOJ.clsCtcontrat();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsCtcontratgarantie> clsCtcontratgaranties = new List<BOJ.clsCtcontratgarantie>();
            //List<Stock.BOJ.clsCtcontratprime> clsCtcontratprimes = new List<BOJ.clsCtcontratprime>();
            //List<Stock.BOJ.clsCtcontratreduction> clsCtcontratreductions = new List<BOJ.clsCtcontratreduction>();
            //List<Stock.BOJ.clsCtcontratayantdroit> clsCtcontratayantdroits = new List<BOJ.clsCtcontratayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontrat clsCtcontratDTO in Objet)
                {
                    Stock.BOJ.clsCtcontrat clsCtcontrat = new Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.CA_CODECONTRAT = clsCtcontratDTO.CA_CODECONTRAT.ToString();
                    clsCtcontrat.AG_CODEAGENCE = clsCtcontratDTO.AG_CODEAGENCE.ToString();
                    clsCtcontrat.EN_CODEENTREPOT = clsCtcontratDTO.EN_CODEENTREPOT.ToString();
                    //clsCtcontrat.CA_NUMPOLICE = clsCtcontratDTO.CA_NUMPOLICE.ToString();
                    clsCtcontrat.CA_DATESAISIE = (clsCtcontratDTO.CA_DATESAISIE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.DATEJOURNEE.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.TI_IDTIERS = clsCtcontratDTO.TI_IDTIERS.ToString();
                    //clsCtcontrat.IT_CODEINTERMEDIAIRE = clsCtcontratDTO.IT_CODEINTERMEDIAIRE.ToString();
                    //clsCtcontrat.AP_CODETYPEAPPARTEMENT = clsCtcontratDTO.AP_CODETYPEAPPARTEMENT.ToString();
                    //clsCtcontrat.OC_CODETYPEOCCUPANT = clsCtcontratDTO.OC_CODETYPEOCCUPANT.ToString();
                    //clsCtcontrat.ZA_CODEZONEAUTO = clsCtcontratDTO.ZA_CODEZONEAUTO.ToString();
                    //clsCtcontrat.CB_IDBRANCHE = clsCtcontratDTO.CB_IDBRANCHE.ToString();
                    //clsCtcontrat.CA_DATEEFFET = (clsCtcontratDTO.CA_DATEEFFET.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEEFFET.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.CA_DATEECHEANCE = (clsCtcontratDTO.CA_DATEECHEANCE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEECHEANCE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.OP_CODEOPERATEUR = clsCtcontratDTO.OP_CODEOPERATEUR.ToString();
                    //clsCtcontrat.CA_AVENANT = clsCtcontratDTO.CA_AVENANT.ToString();
                    //clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = clsCtcontratDTO.CA_SITUATIONGEOGRAPHIQUE.ToString();
                    //clsCtcontrat.CA_CONDITIONHABITUEL = clsCtcontratDTO.CA_CONDITIONHABITUEL.ToString();
                    //clsCtcontrat.ST_CODESTATUTSOCIOPROF = clsCtcontratDTO.ST_CODESTATUTSOCIOPROF.ToString();
                    //clsCtcontrat.AU_CODECATEGORIE = clsCtcontratDTO.AU_CODECATEGORIE.ToString();
                    //clsCtcontrat.TA_CODETARIF = clsCtcontratDTO.TA_CODETARIF.ToString();
                    //clsCtcontrat.US_CODEUSAGE = clsCtcontratDTO.US_CODEUSAGE.ToString();
                    //clsCtcontrat.GE_CODEGENRE = clsCtcontratDTO.GE_CODEGENRE.ToString();
                    //clsCtcontrat.TVH_CODETYPE = clsCtcontratDTO.TVH_CODETYPE.ToString();
                    //clsCtcontrat.EN_CODEENERGIE = clsCtcontratDTO.EN_CODEENERGIE.ToString();
                    //clsCtcontrat.CA_TAUX = float.Parse(clsCtcontratDTO.CA_TAUX.ToString());
                    //clsCtcontrat.CA_TYPE = clsCtcontratDTO.CA_TYPE.ToString();
                    //clsCtcontrat.CA_NUMSERIE = clsCtcontratDTO.CA_NUMSERIE.ToString();
                    //clsCtcontrat.CA_IMMATRICULATION = clsCtcontratDTO.CA_IMMATRICULATION.ToString();
                    //clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(clsCtcontratDTO.CA_PUISSANCEADMISE.ToString());
                    //clsCtcontrat.CA_CHARGEUTILE = int.Parse(clsCtcontratDTO.CA_CHARGEUTILE.ToString());
                    //clsCtcontrat.CA_NBREPLACE = int.Parse(clsCtcontratDTO.CA_NBREPLACE.ToString());
                    //clsCtcontrat.CA_VALNEUVE = Double.Parse(clsCtcontratDTO.CA_VALNEUVE.ToString());
                    //clsCtcontrat.CA_VALVENALE = Double.Parse(clsCtcontratDTO.CA_VALVENALE.ToString());
                    //clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEMISECIRCULATION.ToString()) : DateTime.Parse("01/01/1900");
                    //clsCtcontrat.CA_CLIENTEXONERETAXE = clsCtcontratDTO.CA_CLIENTEXONERETAXE.ToString();
                    //clsCtcontrat.TI_IDTIERSCOMMERCIAL = clsCtcontratDTO.TI_IDTIERSCOMMERCIAL.ToString();
                   // clsCtcontrat.TI_IDTIERSASSUREUR = clsCtcontratDTO.TI_IDTIERSASSUREUR.ToString();

                    clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATETRANSMISSIONAASSUREUR.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONASSUREUR.ToString()) : DateTime.Parse("01/01/1900");

                    //clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEVALIDATIONCONTRAASS.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATESUSPENSION = (clsCtcontratDTO.CA_DATESUSPENSION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATESUSPENSION.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATECLOTURE = (clsCtcontratDTO.CA_DATECLOTURE.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATECLOTURE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtcontrat.CA_DATERESILIATION = (clsCtcontratDTO.CA_DATERESILIATION.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATERESILIATION.ToString()) : DateTime.Parse("01/01/1900");

                    //clsCtcontrat.CA_NOMINTERLOCUTEUR = clsCtcontratDTO.CA_NOMINTERLOCUTEUR.ToString();
                    //clsCtcontrat.CA_CONTACTINTERLOCUTEUR = clsCtcontratDTO.CA_CONTACTINTERLOCUTEUR.ToString();
                    //clsCtcontrat.DI_CODEDESIGNATION = clsCtcontratDTO.DI_CODEDESIGNATION.ToString();
                    //clsCtcontrat.TA_CODETYPECONTRATSANTE = clsCtcontratDTO.TA_CODETYPECONTRATSANTE.ToString();
                    //clsCtcontrat.CA_CODECONTRATSECONDAIRE = clsCtcontratDTO.CA_CODECONTRATSECONDAIRE.ToString();
                    //clsCtcontrat.CA_GESA = clsCtcontratDTO.CA_GESA.ToString();
                    //clsCtcontrat.CO_CODECOMMUNE = clsCtcontratDTO.CO_CODECOMMUNE.ToString();
                    //clsCtcontrat.RQ_CODERISQUE = clsCtcontratDTO.RQ_CODERISQUE.ToString();
                    //clsCtcontrat.TA_CODETYPEAFFAIRES = clsCtcontratDTO.TA_CODETYPEAFFAIRES.ToString();
                    //clsCtcontrat.MF_CODEMAINFORTE = clsCtcontratDTO.MF_CODEMAINFORTE.ToString();
                    //clsCtcontrat.ZM_CODEZONEVOYAGE = clsCtcontratDTO.ZM_CODEZONEVOYAGE.ToString();

                    // HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();

                    clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT = (clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString() != "") ? DateTime.Parse(clsCtcontratDTO.CA_DATEDEMANDERENOUVELEMENT.ToString()) : DateTime.Parse("01/01/1900");

                    clsCtcontrat.CA_OBSERVATION = clsCtcontratDTO.CA_OBSERVATION.ToString();
                    clsCtcontrat.TYPEOPERATION = 13;// int.Parse(clsCtcontratDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtcontratDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjourStatutContrat(clsDonnee, clsCtcontrat, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);

            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }


            return clsCtcontrats;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontrat> pvgSupprimer(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireDelete(Objet[Idx]); 
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE , Objet[0].EN_CODEENTREPOT, Objet[0].CA_CODECONTRAT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontrats;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsCtcontratMobileRetours> pvgChargerListeContrat(List<HT_Stock.BOJ.clsCtcontratMobileEnvoi> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratMobileRetours> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontratMobileRetours>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtcontrats = TestChampObligatoireListeMobile(Objet[Idx]);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            ////--TEST CONTRAINTE
            //clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
        }

           
        //clsObjetEnvoi.OE_PARAM= new string[] {  Objet[0].AG_CODEAGENCE,  Objet[0].EN_CODEENTREPOT,  Objet[0].CA_NUMPOLICE, Objet[0].TI_NUMTIERS,  Objet[0].TI_DENOMINATION,  Objet[0].TI_NUMTIERSCOMMERCIAL,  Objet[0].TI_DENOMINATIONCOMMERCIAL,  Objet[0].DATEDEBUT ,  Objet[0].DATEFIN ,Objet[0].RQ_CODERISQUE,  Objet[0].OP_CODEOPERATEUR,  Objet[0].TYPEOPERATION };
        DataSet DataSet = new DataSet();


        try
        {
            clsDonnee.pvgConnectionBase();
            //DataSet = clsCtcontratWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontratMobileRetours>();
            clsCtcontratMobileRetours clsCtcontratMobileRetours = new clsCtcontratMobileRetours();
                clsCtcontratMobileRetours.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratMobileRetours.CA_NUMPOLICE = "CTN000001";
            clsCtcontratMobileRetours.AG_CODEAGENCE = "1000";
            clsCtcontratMobileRetours.CA_DATEECHEANCE = "26-07-2022";
            clsCtcontratMobileRetours.CA_DATEEFFET = "26-07-2021";
            clsCtcontratMobileRetours.CA_DATEEFFET = "26-07-2021";
            clsCtcontratMobileRetours.MONTANTTTCPLUSAIRSI = "500 000";
            clsCtcontratMobileRetours.MONTANTREGLE = "250 000";
            clsCtcontratMobileRetours.SOLDE = "250 000";
            clsCtcontratMobileRetours.TI_EMAIL = "d.baz1008@gmail.com";
            clsCtcontratMobileRetours.clsObjetRetour.SL_CODEMESSAGE = "00";
            clsCtcontratMobileRetours.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratMobileRetours.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
            clsCtcontrats.Add(clsCtcontratMobileRetours);


            //if (DataSet.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow row in DataSet.Tables[0].Rows)
            //    {
            //        HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
            //        clsCtcontrat.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
            //        clsCtcontrat.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
            //        clsCtcontrat.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
            //        clsCtcontrat.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
            //        clsCtcontrat.CA_DATESAISIE = (row["CA_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CA_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "";
            //        clsCtcontrat.CA_DATESAISIE = (clsCtcontrat.CA_DATESAISIE != "01-01-1900") ? clsCtcontrat.CA_DATESAISIE : "";
            //        clsCtcontrat.TI_IDTIERS = row["TI_IDTIERS"].ToString();
            //        clsCtcontrat.IT_CODEINTERMEDIAIRE = row["IT_CODEINTERMEDIAIRE"].ToString();
            //        clsCtcontrat.AP_CODETYPEAPPARTEMENT = row["AP_CODETYPEAPPARTEMENT"].ToString();
            //        clsCtcontrat.OC_CODETYPEOCCUPANT = row["OC_CODETYPEOCCUPANT"].ToString();
            //        clsCtcontrat.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
            //        clsCtcontrat.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
            //        clsCtcontrat.CA_DATEEFFET = (row["CA_DATEEFFET"].ToString() != "") ? DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString().Replace("/", "-") : "";
            //        clsCtcontrat.CA_DATEEFFET = (clsCtcontrat.CA_DATEEFFET != "01-01-1900") ? clsCtcontrat.CA_DATEEFFET : "";
            //        clsCtcontrat.CA_DATEECHEANCE = (row["CA_DATEECHEANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
            //        clsCtcontrat.CA_DATEECHEANCE = (clsCtcontrat.CA_DATEECHEANCE != "01-01-1900") ? clsCtcontrat.CA_DATEECHEANCE : "";
            //        clsCtcontrat.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
            //            if (row["CA_AVENANT"].ToString() != "")
            //                clsCtcontrat.CA_AVENANT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_AVENANT"].ToString()).ToString(), "M");// row["CA_AVENANT"].ToString();
            //            clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = row["CA_SITUATIONGEOGRAPHIQUE"].ToString();
            //        clsCtcontrat.CA_CONDITIONHABITUEL = row["CA_CONDITIONHABITUEL"].ToString();
            //        clsCtcontrat.ST_CODESTATUTSOCIOPROF = row["ST_CODESTATUTSOCIOPROF"].ToString();
            //        clsCtcontrat.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
            //        clsCtcontrat.TA_CODETARIF = row["TA_CODETARIF"].ToString();
            //        clsCtcontrat.US_CODEUSAGE = row["US_CODEUSAGE"].ToString();
            //        clsCtcontrat.GE_CODEGENRE = row["GE_CODEGENRE"].ToString();
            //        clsCtcontrat.TVH_CODETYPE = row["TVH_CODETYPE"].ToString();
            //        clsCtcontrat.TVH_LIBELE = row["TVH_LIBELE"].ToString();
            //        clsCtcontrat.EN_CODEENERGIE = row["EN_CODEENERGIE"].ToString();

                //        clsCtcontrat.MF_CODEMAINFORTE = row["MF_CODEMAINFORTE"].ToString();
                //        clsCtcontrat.MF_LIBLLEMAINFORTE = row["MF_LIBLLEMAINFORTE"].ToString();
                //        clsCtcontrat.ZM_CODEZONEVOYAGE = row["ZM_CODEZONEVOYAGE"].ToString();
                //        clsCtcontrat.ZM_NOMZONEVOYAGE = row["ZM_NOMZONEVOYAGE"].ToString();
                //        clsCtcontrat.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
                //        if (row["CT_NOMBRECONTRAT"].ToString() != "")
                //        clsCtcontrat.CT_NOMBRECONTRAT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CT_NOMBRECONTRAT"].ToString()).ToString(), "M");// row["CT_NOMBRECONTRAT"].ToString();
                //        if (row["CA_NOMBREPIECE"].ToString() != "")
                //            clsCtcontrat.CA_NOMBREPIECE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_NOMBREPIECE"].ToString()).ToString(), "M");
                //        if (row["CA_SUPERFICIE"].ToString() != "")
                //            clsCtcontrat.CA_SUPERFICIE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_SUPERFICIE"].ToString()).ToString(), "M");
                //        if (row["CA_LOYERMENSUEL"].ToString() != "")
                //            clsCtcontrat.CA_LOYERMENSUEL = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_LOYERMENSUEL"].ToString()).ToString(), "M");
                //        clsCtcontrat.CA_DATENAISSANCE = (row["CA_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATENAISSANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATENAISSANCE = (clsCtcontrat.CA_DATENAISSANCE != "01-01-1900") ? clsCtcontrat.CA_DATENAISSANCE : "";
                //        clsCtcontrat.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                //        clsCtcontrat.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                //        clsCtcontrat.CA_LIEUNAISSANCE = row["CA_LIEUNAISSANCE"].ToString() ; 


                //            if (row["CA_TAUX"].ToString()!="")
                //        clsCtcontrat.CA_TAUX = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_TAUX"].ToString()).ToString(), "M");
                //        clsCtcontrat.CA_TYPE = row["CA_TYPE"].ToString();
                //        clsCtcontrat.CA_NUMSERIE = row["CA_NUMSERIE"].ToString();
                //        clsCtcontrat.CA_IMMATRICULATION = row["CA_IMMATRICULATION"].ToString();
                //        if (row["CA_PUISSANCEADMISE"].ToString() != "")
                //            clsCtcontrat.CA_PUISSANCEADMISE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_PUISSANCEADMISE"].ToString()).ToString(), "M");
                //            if (row["CA_CHARGEUTILE"].ToString() != "")
                //                clsCtcontrat.CA_CHARGEUTILE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_CHARGEUTILE"].ToString()).ToString(), "M");
                //            if (row["CA_NBREPLACE"].ToString() != "")
                //                clsCtcontrat.CA_NBREPLACE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_NBREPLACE"].ToString()).ToString(), "M");
                //            if (row["CA_VALNEUVE"].ToString() != "")
                //                clsCtcontrat.CA_VALNEUVE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_VALNEUVE"].ToString()).ToString(), "M");
                //            if (row["CA_VALVENALE"].ToString() != "")
                //                clsCtcontrat.CA_VALVENALE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_VALVENALE"].ToString()).ToString(), "M");
                //        clsCtcontrat.CA_DATEMISECIRCULATION = (row["CA_DATEMISECIRCULATION"].ToString() != "") ? DateTime.Parse(row["CA_DATEMISECIRCULATION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontrat.CA_DATEMISECIRCULATION != "01-01-1900") ? clsCtcontrat.CA_DATEMISECIRCULATION : "";
                //        clsCtcontrat.CA_CLIENTEXONERETAXE = row["CA_CLIENTEXONERETAXE"].ToString();
                //        clsCtcontrat.TI_IDTIERSCOMMERCIAL = row["TI_IDTIERSCOMMERCIAL"].ToString();
                //        clsCtcontrat.TI_IDTIERSASSUREUR = row["TI_IDTIERSASSUREUR"].ToString();
                //        clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (row["CA_DATETRANSMISSIONAASSUREUR"].ToString() != "") ? DateTime.Parse(row["CA_DATETRANSMISSIONAASSUREUR"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR != "01-01-1900") ? clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR : "";
                //        clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (row["CA_DATEVALIDATIONASSUREUR"].ToString() != "") ? DateTime.Parse(row["CA_DATEVALIDATIONASSUREUR"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontrat.CA_DATEVALIDATIONASSUREUR != "01-01-1900") ? clsCtcontrat.CA_DATEVALIDATIONASSUREUR : "";

                //        clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (row["CA_DATEVALIDATIONCONTRAASS"].ToString() != "") ? DateTime.Parse(row["CA_DATEVALIDATIONCONTRAASS"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATESUSPENSION = (row["CA_DATESUSPENSION"].ToString() != "") ? DateTime.Parse(row["CA_DATESUSPENSION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATESUSPENSION = (clsCtcontrat.CA_DATESUSPENSION != "01-01-1900") ? clsCtcontrat.CA_DATESUSPENSION : "";
                //        clsCtcontrat.CA_DATECLOTURE = (row["CA_DATECLOTURE"].ToString() != "") ? DateTime.Parse(row["CA_DATECLOTURE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATECLOTURE = (clsCtcontrat.CA_DATECLOTURE != "01-01-1900") ? clsCtcontrat.CA_DATECLOTURE : "";
                //        clsCtcontrat.CA_DATERESILIATION = (row["CA_DATERESILIATION"].ToString() != "") ? DateTime.Parse(row["CA_DATERESILIATION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                //        clsCtcontrat.CA_DATERESILIATION = (clsCtcontrat.CA_DATERESILIATION != "01-01-1900") ? clsCtcontrat.CA_DATERESILIATION : "";
                //        clsCtcontrat.CA_NOMINTERLOCUTEUR = row["CA_NOMINTERLOCUTEUR"].ToString();
                //        clsCtcontrat.CA_CONTACTINTERLOCUTEUR = row["CA_CONTACTINTERLOCUTEUR"].ToString();
                //        clsCtcontrat.DI_CODEDESIGNATION = row["DI_CODEDESIGNATION"].ToString();
                //        clsCtcontrat.TA_CODETYPECONTRATSANTE = row["TA_CODETYPECONTRATSANTE"].ToString();
                //        clsCtcontrat.CA_CODECONTRATSECONDAIRE = row["CA_CODECONTRATSECONDAIRE"].ToString();
                //        clsCtcontrat.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                //        clsCtcontrat.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                //        clsCtcontrat.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                //        clsCtcontrat.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                //        clsCtcontrat.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                //        clsCtcontrat.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                //        clsCtcontrat.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();

                //        clsCtcontrat.TI_TELEPHONECOMMERCIAL = row["TI_TELEPHONECOMMERCIAL"].ToString();
                //     clsCtcontrat.TI_NUMTIERSASSUREUR = row["TI_NUMTIERSASSUREUR"].ToString();
                //     clsCtcontrat.TI_DENOMINATIONASSUREUR = row["TI_DENOMINATIONASSUREUR"].ToString();
                //     clsCtcontrat.TI_TELEPHONEASSUREUR = row["TI_TELEPHONEASSUREUR"].ToString();
                //     clsCtcontrat.IT_DENOMMINATION = row["IT_DENOMMINATION"].ToString();
                //     clsCtcontrat.TA_LIBLLETYPEAFFAIRES = row["TA_LIBLLETYPEAFFAIRES"].ToString();
                //     clsCtcontrat.DI_LIBELLEDESIGNATION = row["DI_LIBELLEDESIGNATION"].ToString();
                //     clsCtcontrat.TI_NUMTIERSCOMMERCIAL = row["TI_NUMTIERSCOMMERCIAL"].ToString();
                //     clsCtcontrat.TI_DENOMINATIONCOMMERCIAL = row["TI_DENOMINATIONCOMMERCIAL"].ToString();
                //     clsCtcontrat.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                //     clsCtcontrat.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                //     clsCtcontrat.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                //     clsCtcontrat.TA_CODETYPEAFFAIRES = row["TA_CODETYPEAFFAIRES"].ToString();
                //     clsCtcontrat.CD_CODECONDITION = row["CD_CODECONDITION"].ToString();
                //     clsCtcontrat.CD_LIBELLECONDITION = row["CD_LIBELLECONDITION"].ToString();
                //    clsCtcontrat.CA_DUREEENMOIS = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_DUREEENMOIS"].ToString()).ToString(), "M");// row["CA_DUREEENMOIS"].ToString();
                //    clsCtcontrat.AC_SPORT = row["AC_SPORT"].ToString();
                //    clsCtcontrat.CA_ADRESSE = row["CA_ADRESSE"].ToString();
                //    clsCtcontrat.ST_LIBELLESTATUTSOCIOPROF = row["ST_LIBELLESTATUTSOCIOPROF"].ToString();
                //    clsCtcontrat.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                //    clsCtcontrat.EN_LIBELLEENERGIE = row["EN_LIBELLEENERGIE"].ToString();
                //    clsCtcontrat.AU_LIBELLECATEGORIE = row["AU_LIBELLECATEGORIE"].ToString();
                //    clsCtcontrat.TA_LIBELLETARIF = row["TA_LIBELLETARIF"].ToString();
                //    clsCtcontrat.US_LIBELLEUSAGE = row["US_LIBELLEUSAGE"].ToString();
                //    clsCtcontrat.GE_LIBELLEGENRE = row["GE_LIBELLEGENRE"].ToString();
                //    clsCtcontrat.AP_LIBLLETYPEAPPARTEMENT = row["AP_LIBLLETYPEAPPARTEMENT"].ToString();
                //    clsCtcontrat.OC_LIBLLETYPEOCCUPANT = row["OC_LIBLLETYPEOCCUPANT"].ToString();
                //    clsCtcontrat.CA_NUMPASSEPORT = row["CA_NUMPASSEPORT"].ToString();
                //    clsCtcontrat.PY_CODEPAYSDESTINATION = row["PY_CODEPAYSDESTINATION"].ToString();
                //    clsCtcontrat.PY_LIBELLEDESTINATION = row["PY_LIBELLEDESTINATION"].ToString();
                //    clsCtcontrat.CA_DUREESEJOUR = row["CA_DUREESEJOUR"].ToString();
                //    clsCtcontrat.CA_OPTION = row["CA_OPTION"].ToString();
                //    clsCtcontrat.AU_CODETYPECONTRATAUTO = row["AU_CODETYPECONTRATAUTO"].ToString();
                //    clsCtcontrat.AU_LIBELLETYPECONTRATAUTO = row["AU_LIBELLETYPECONTRATAUTO"].ToString();
                //  clsCtcontrat.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                //  clsCtcontrat.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                //  clsCtcontrat.PL_NUMCOMPTETIERS = row["PL_NUMCOMPTETIERS"].ToString();
                //  clsCtcontrat.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();


                //        clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                //        clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE ="00";
                //        clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                //        clsCtcontrat.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                //        clsCtcontrats.Add(clsCtcontrat);
                //    }
                //}
                //else
                //{
                //    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                //    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                //    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                //    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                //    clsCtcontrats.Add(clsCtcontrat);
                //}



            }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratMobileRetours clsCtcontrat = new HT_Stock.BOJ.clsCtcontratMobileRetours();
            clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontrat.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontratMobileRetours>();
            clsCtcontrats.Add(clsCtcontrat);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontrats;
    }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontrat> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }

           
            clsObjetEnvoi.OE_PARAM= new string[] {  Objet[0].AG_CODEAGENCE,  Objet[0].EN_CODEENTREPOT, Objet[0].CA_CODECONTRAT,  Objet[0].CA_NUMPOLICE, Objet[0].TI_NUMTIERS,  Objet[0].TI_DENOMINATION,  Objet[0].TI_NUMTIERSCOMMERCIAL,  Objet[0].TI_DENOMINATIONCOMMERCIAL,  Objet[0].DATEDEBUT ,  Objet[0].DATEFIN ,Objet[0].RQ_CODERISQUE,Objet[0].EX_EXERCICE,  Objet[0].OP_CODEOPERATEUR,  Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            DataSet DataSetCtcontratgarantie = new DataSet();
            DataSet DataSetCtcontratprime = new DataSet();
            DataSet DataSetCtcontratreduction = new DataSet();
            DataSet DataSetCtcontratayantdroit = new DataSet();
            DataSet DataSetCtcontratcapitaux = new DataSet();
            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsCtcontratWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                //string json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                        clsCtcontrat.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                        clsCtcontrat.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsCtcontrat.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsCtcontrat.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                        clsCtcontrat.CA_DATESAISIE = (row["CA_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CA_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATESAISIE = (clsCtcontrat.CA_DATESAISIE != "01-01-1900") ? clsCtcontrat.CA_DATESAISIE : "";
                        clsCtcontrat.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsCtcontrat.IT_CODEINTERMEDIAIRE = row["IT_CODEINTERMEDIAIRE"].ToString();
                        clsCtcontrat.AP_CODETYPEAPPARTEMENT = row["AP_CODETYPEAPPARTEMENT"].ToString();
                        clsCtcontrat.OC_CODETYPEOCCUPANT = row["OC_CODETYPEOCCUPANT"].ToString();
                        clsCtcontrat.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
                        clsCtcontrat.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
                        clsCtcontrat.CA_DATEEFFET = (row["CA_DATEEFFET"].ToString() != "") ? DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEEFFET = (clsCtcontrat.CA_DATEEFFET != "01-01-1900") ? clsCtcontrat.CA_DATEEFFET : "";
                        clsCtcontrat.CA_DATEECHEANCE = (row["CA_DATEECHEANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEECHEANCE = (clsCtcontrat.CA_DATEECHEANCE != "01-01-1900") ? clsCtcontrat.CA_DATEECHEANCE : "";
                        clsCtcontrat.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                            if (row["CA_AVENANT"].ToString() != "")
                                clsCtcontrat.CA_AVENANT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_AVENANT"].ToString()).ToString(), "M");// row["CA_AVENANT"].ToString();
                            clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = row["CA_SITUATIONGEOGRAPHIQUE"].ToString();
                        clsCtcontrat.CA_CONDITIONHABITUEL = row["CA_CONDITIONHABITUEL"].ToString();
                        clsCtcontrat.ST_CODESTATUTSOCIOPROF = row["ST_CODESTATUTSOCIOPROF"].ToString();
                        clsCtcontrat.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
                        clsCtcontrat.TA_CODETARIF = row["TA_CODETARIF"].ToString();
                        clsCtcontrat.US_CODEUSAGE = row["US_CODEUSAGE"].ToString();
                        clsCtcontrat.GE_CODEGENRE = row["GE_CODEGENRE"].ToString();
                        clsCtcontrat.TVH_CODETYPE = row["TVH_CODETYPE"].ToString();
                        clsCtcontrat.TVH_LIBELE = row["TVH_LIBELE"].ToString();
                        clsCtcontrat.EN_CODEENERGIE = row["EN_CODEENERGIE"].ToString();

                        clsCtcontrat.MF_CODEMAINFORTE = row["MF_CODEMAINFORTE"].ToString();
                        clsCtcontrat.MF_LIBLLEMAINFORTE = row["MF_LIBLLEMAINFORTE"].ToString();
                        clsCtcontrat.ZM_CODEZONEVOYAGE = row["ZM_CODEZONEVOYAGE"].ToString();
                        clsCtcontrat.ZM_NOMZONEVOYAGE = row["ZM_NOMZONEVOYAGE"].ToString();
                        clsCtcontrat.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
                        if (row["CT_NOMBRECONTRAT"].ToString() != "")
                        clsCtcontrat.CT_NOMBRECONTRAT = Double.Parse(row["CT_NOMBRECONTRAT"].ToString());// row["CT_NOMBRECONTRAT"].ToString();
                        if (row["CA_NOMBREPIECE"].ToString() != "")
                            clsCtcontrat.CA_NOMBREPIECE = Double.Parse(row["CA_NOMBREPIECE"].ToString());
                        if (row["CA_SUPERFICIE"].ToString() != "")
                            clsCtcontrat.CA_SUPERFICIE = Double.Parse(row["CA_SUPERFICIE"].ToString());
                        if (row["CA_LOYERMENSUEL"].ToString() != "")
                            clsCtcontrat.CA_LOYERMENSUEL = Double.Parse(row["CA_LOYERMENSUEL"].ToString());
                        clsCtcontrat.CA_DATENAISSANCE = (row["CA_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATENAISSANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATENAISSANCE = (clsCtcontrat.CA_DATENAISSANCE != "01-01-1900") ? clsCtcontrat.CA_DATENAISSANCE : "";
                        clsCtcontrat.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                        clsCtcontrat.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                        clsCtcontrat.CA_LIEUNAISSANCE = row["CA_LIEUNAISSANCE"].ToString() ; 


                            if (row["CA_TAUX"].ToString()!="")
                        clsCtcontrat.CA_TAUX = float.Parse(row["CA_TAUX"].ToString()).ToString();
                        clsCtcontrat.CA_TYPE = row["CA_TYPE"].ToString();
                        clsCtcontrat.CA_NUMSERIE = row["CA_NUMSERIE"].ToString();
                        clsCtcontrat.CA_IMMATRICULATION = row["CA_IMMATRICULATION"].ToString();
                        if (row["CA_PUISSANCEADMISE"].ToString() != "")
                            clsCtcontrat.CA_PUISSANCEADMISE =Double.Parse(row["CA_PUISSANCEADMISE"].ToString());
                            if (row["CA_CHARGEUTILE"].ToString() != "")
                                clsCtcontrat.CA_CHARGEUTILE = Double.Parse(row["CA_CHARGEUTILE"].ToString());
                            if (row["CA_NBREPLACE"].ToString() != "")
                                clsCtcontrat.CA_NBREPLACE = Double.Parse(row["CA_NBREPLACE"].ToString());
                            if (row["CA_VALNEUVE"].ToString() != "")
                                clsCtcontrat.CA_VALNEUVE = Double.Parse(row["CA_VALNEUVE"].ToString());
                            if (row["CA_VALVENALE"].ToString() != "")
                                clsCtcontrat.CA_VALVENALE =Double.Parse(row["CA_VALVENALE"].ToString());

                            if (row["DUREE"].ToString() != "")
                                clsCtcontrat.DUREE = Double.Parse(row["DUREE"].ToString());

                        clsCtcontrat.CA_DATEMISECIRCULATION = (row["CA_DATEMISECIRCULATION"].ToString() != "") ? DateTime.Parse(row["CA_DATEMISECIRCULATION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontrat.CA_DATEMISECIRCULATION != "01-01-1900") ? clsCtcontrat.CA_DATEMISECIRCULATION : "";
                        clsCtcontrat.CA_CLIENTEXONERETAXE = row["CA_CLIENTEXONERETAXE"].ToString();
                        clsCtcontrat.TI_IDTIERSCOMMERCIAL = row["TI_IDTIERSCOMMERCIAL"].ToString();
                        clsCtcontrat.TI_IDTIERSASSUREUR = row["TI_IDTIERSASSUREUR"].ToString();
                        clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (row["CA_DATETRANSMISSIONAASSUREUR"].ToString() != "") ? DateTime.Parse(row["CA_DATETRANSMISSIONAASSUREUR"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR != "01-01-1900") ? clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR : "";
                        clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (row["CA_DATEVALIDATIONASSUREUR"].ToString() != "") ? DateTime.Parse(row["CA_DATEVALIDATIONASSUREUR"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontrat.CA_DATEVALIDATIONASSUREUR != "01-01-1900") ? clsCtcontrat.CA_DATEVALIDATIONASSUREUR : "";
                  
                        clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (row["CA_DATEVALIDATIONCONTRAASS"].ToString() != "") ? DateTime.Parse(row["CA_DATEVALIDATIONCONTRAASS"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATESUSPENSION = (row["CA_DATESUSPENSION"].ToString() != "") ? DateTime.Parse(row["CA_DATESUSPENSION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATESUSPENSION = (clsCtcontrat.CA_DATESUSPENSION != "01-01-1900") ? clsCtcontrat.CA_DATESUSPENSION : "";
                        clsCtcontrat.CA_DATECLOTURE = (row["CA_DATECLOTURE"].ToString() != "") ? DateTime.Parse(row["CA_DATECLOTURE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATECLOTURE = (clsCtcontrat.CA_DATECLOTURE != "01-01-1900") ? clsCtcontrat.CA_DATECLOTURE : "";
                        clsCtcontrat.CA_DATERESILIATION = (row["CA_DATERESILIATION"].ToString() != "") ? DateTime.Parse(row["CA_DATERESILIATION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATERESILIATION = (clsCtcontrat.CA_DATERESILIATION != "01-01-1900") ? clsCtcontrat.CA_DATERESILIATION : "";
                        clsCtcontrat.CA_NOMINTERLOCUTEUR = row["CA_NOMINTERLOCUTEUR"].ToString();
                        clsCtcontrat.CA_CONTACTINTERLOCUTEUR = row["CA_CONTACTINTERLOCUTEUR"].ToString();
                        clsCtcontrat.DI_CODEDESIGNATION = row["DI_CODEDESIGNATION"].ToString();
                        clsCtcontrat.TA_CODETYPECONTRATSANTE = row["TA_CODETYPECONTRATSANTE"].ToString();
                        clsCtcontrat.CA_CODECONTRATSECONDAIRE = row["CA_CODECONTRATSECONDAIRE"].ToString();
                        clsCtcontrat.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                        clsCtcontrat.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                        clsCtcontrat.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                        clsCtcontrat.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                        clsCtcontrat.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                        clsCtcontrat.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                        clsCtcontrat.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                        clsCtcontrat.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                        clsCtcontrat.TI_TELEPHONECOMMERCIAL = row["TI_TELEPHONECOMMERCIAL"].ToString();
                        clsCtcontrat.TI_NUMTIERSASSUREUR = row["TI_NUMTIERSASSUREUR"].ToString();
                        clsCtcontrat.TI_DENOMINATIONASSUREUR = row["TI_DENOMINATIONASSUREUR"].ToString();
                        clsCtcontrat.TI_TELEPHONEASSUREUR = row["TI_TELEPHONEASSUREUR"].ToString();
                        clsCtcontrat.IT_DENOMMINATION = row["IT_DENOMMINATION"].ToString();
                        clsCtcontrat.TA_LIBLLETYPEAFFAIRES = row["TA_LIBLLETYPEAFFAIRES"].ToString();
                        clsCtcontrat.DI_LIBELLEDESIGNATION = row["DI_LIBELLEDESIGNATION"].ToString();
                        clsCtcontrat.TI_NUMTIERSCOMMERCIAL = row["TI_NUMTIERSCOMMERCIAL"].ToString();
                        clsCtcontrat.TI_DENOMINATIONCOMMERCIAL = row["TI_DENOMINATIONCOMMERCIAL"].ToString();
                        clsCtcontrat.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsCtcontrat.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsCtcontrat.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        clsCtcontrat.TA_CODETYPEAFFAIRES = row["TA_CODETYPEAFFAIRES"].ToString();
                        clsCtcontrat.CD_CODECONDITION = row["CD_CODECONDITION"].ToString();
                        clsCtcontrat.CD_LIBELLECONDITION = row["CD_LIBELLECONDITION"].ToString();
                    clsCtcontrat.CA_DUREEENMOIS =Double.Parse(row["CA_DUREEENMOIS"].ToString());// row["CA_DUREEENMOIS"].ToString();
                    clsCtcontrat.AC_SPORT = row["AC_SPORT"].ToString();
                    clsCtcontrat.CA_ADRESSE = row["CA_ADRESSE"].ToString();
                    clsCtcontrat.ST_LIBELLESTATUTSOCIOPROF = row["ST_LIBELLESTATUTSOCIOPROF"].ToString();
                    clsCtcontrat.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                    clsCtcontrat.EN_LIBELLEENERGIE = row["EN_LIBELLEENERGIE"].ToString();
                    clsCtcontrat.AU_LIBELLECATEGORIE = row["AU_LIBELLECATEGORIE"].ToString();
                    clsCtcontrat.TA_LIBELLETARIF = row["TA_LIBELLETARIF"].ToString();
                    clsCtcontrat.US_LIBELLEUSAGE = row["US_LIBELLEUSAGE"].ToString();
                    clsCtcontrat.GE_LIBELLEGENRE = row["GE_LIBELLEGENRE"].ToString();
                    clsCtcontrat.AP_LIBLLETYPEAPPARTEMENT = row["AP_LIBLLETYPEAPPARTEMENT"].ToString();
                    clsCtcontrat.OC_LIBLLETYPEOCCUPANT = row["OC_LIBLLETYPEOCCUPANT"].ToString();
                    clsCtcontrat.CA_NUMPASSEPORT = row["CA_NUMPASSEPORT"].ToString();
                    clsCtcontrat.PY_CODEPAYSDESTINATION = row["PY_CODEPAYSDESTINATION"].ToString();
                    clsCtcontrat.PY_LIBELLEDESTINATION = row["PY_LIBELLEDESTINATION"].ToString();
                    if(row["CA_DUREESEJOUR"].ToString()!="")
                    clsCtcontrat.CA_DUREESEJOUR =double.Parse( row["CA_DUREESEJOUR"].ToString());
                    clsCtcontrat.CA_OPTION = row["CA_OPTION"].ToString();
                    clsCtcontrat.AU_CODETYPECONTRATAUTO = row["AU_CODETYPECONTRATAUTO"].ToString();
                    clsCtcontrat.AU_LIBELLETYPECONTRATAUTO = row["AU_LIBELLETYPECONTRATAUTO"].ToString();
                    clsCtcontrat.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    clsCtcontrat.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                    clsCtcontrat.PL_NUMCOMPTETIERS = row["PL_NUMCOMPTETIERS"].ToString();
                    clsCtcontrat.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                    clsCtcontrat.TI_NUMWHATSAPP = row["TI_NUMWHATSAPP"].ToString();
                    if (row["REGLEMENT"].ToString() != "")
                        clsCtcontrat.MONTANTREGLEMENT = Double.Parse(row["REGLEMENT"].ToString());
                    if (row["SOLDE"].ToString() != "")
                    clsCtcontrat.SOLDE =Double.Parse(row["SOLDE"].ToString());
                    if (row["PRIME"].ToString() != "")
                    clsCtcontrat.PRIME = Double.Parse(row["PRIME"].ToString());
                    clsCtcontrat.GR_CODEGARENTIEPRIME = row["GR_CODEGARENTIEPRIME"].ToString();                   
                    clsCtcontrat.GR_LIBELLEGARENTIEPRIME = row["GR_LIBELLEGARENTIEPRIME"].ToString(); 
                    clsCtcontrat.CA_OBSERVATION = row["CA_OBSERVATION"].ToString(); 
                    clsCtcontrat.MESSAGERELANCE = row["MESSAGERELANCE"].ToString(); 
                    clsCtcontrat.TI_EMAIL = row["TI_EMAIL"].ToString(); 
                    clsCtcontrat.EX_EXERCICE = row["EX_EXERCICE"].ToString(); 
                    clsCtcontrat.AS_NUMEROASSUREUR = row["AS_NUMEROASSUREUR"].ToString(); 
                    clsCtcontrat.CA_CODECONTRATORIGINE = row["CA_CODECONTRATORIGINE"].ToString(); 

        //     private string _TI_TELEPHONECOMMERCIAL = "";
        //private string _TI_NUMTIERSASSUREUR = "";
        //private string _TI_DENOMINATIONASSUREUR = "";
        //private string _TI_TELEPHONEASSUREUR = "";
        //private string _IT_DENOMMINATION = "";
        //private string _TA_LIBLLETYPEAFFAIRES = "";

        //private String _PY_CODEPAYS = "";
        //private String _PY_LIBELLE = "";
        //private String _VL_CODEVILLE = "";
        //private String _VL_LIBELLE = "";
        //private String _CO_LIBELLE = "";

        clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE ="00";
                        clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsCtcontrat.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";

                        //=========Debut liste des garanties
                        List<HT_Stock.BOJ.clsCtcontratgarantie> clsCtcontratgarantieDTOS = new List<HT_Stock.BOJ.clsCtcontratgarantie>();
                        clsCtcontratgarantieWSBLL clsCtcontratgarantieWSBLL = new clsCtcontratgarantieWSBLL();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, clsCtcontrat.CA_CODECONTRAT };
                            DataSetCtcontratgarantie = clsCtcontratgarantieWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                        if (DataSetCtcontratgarantie.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rowCtcontratgarantie in DataSetCtcontratgarantie.Tables[0].Rows)
                            {
                                HT_Stock.BOJ.clsCtcontratgarantie clsCtcontratgarantieDTO = new HT_Stock.BOJ.clsCtcontratgarantie();
                                    clsCtcontratgarantieDTO.AG_CODEAGENCE = rowCtcontratgarantie["AG_CODEAGENCE"].ToString();
                                    clsCtcontratgarantieDTO.EN_CODEENTREPOT = rowCtcontratgarantie["EN_CODEENTREPOT"].ToString();
                                    clsCtcontratgarantieDTO.CA_CODECONTRAT = rowCtcontratgarantie["CA_CODECONTRAT"].ToString();
                                    if (rowCtcontratgarantie["CG_CAPITAUXASSURES"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_CAPITAUXASSURES =Double.Parse(rowCtcontratgarantie["CG_CAPITAUXASSURES"].ToString());// rowCtcontratgarantie["CG_CAPITAUXASSURES"].ToString();
                                    if (rowCtcontratgarantie["CG_PRIMES"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_PRIMES = Double.Parse(rowCtcontratgarantie["CG_PRIMES"].ToString());// rowCtcontratgarantie["CG_PRIMES"].ToString();
                                    if (rowCtcontratgarantie["CG_APRESREDUCTION"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_APRESREDUCTION = Double.Parse(rowCtcontratgarantie["CG_APRESREDUCTION"].ToString());// rowCtcontratgarantie["CG_APRESREDUCTION"].ToString();
                                    if (rowCtcontratgarantie["CG_PRORATA"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_PRORATA =Double.Parse(rowCtcontratgarantie["CG_PRORATA"].ToString());// rowCtcontratgarantie["CG_PRORATA"].ToString();

                                    if (rowCtcontratgarantie["CG_FRANCHISES"].ToString() != "")
                                    clsCtcontratgarantieDTO.CG_FRANCHISES = rowCtcontratgarantie["CG_FRANCHISES"].ToString();// rowCtcontratgarantie["CG_FRANCHISES"].ToString();
                                    if (rowCtcontratgarantie["CG_TAUX"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_TAUX = Double.Parse(rowCtcontratgarantie["CG_TAUX"].ToString()).ToString();// rowCtcontratgarantie["CG_TAUX"].ToString();
                                    if (rowCtcontratgarantie["CG_MONTANT"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_MONTANT = Double.Parse(rowCtcontratgarantie["CG_MONTANT"].ToString());// rowCtcontratgarantie["CG_MONTANT"].ToString();
                                    clsCtcontratgarantieDTO.CG_LIBELLE = rowCtcontratgarantie["CG_LIBELLE"].ToString();
                                    clsCtcontratgarantieDTO.CG_LIBELLE = rowCtcontratgarantie["CG_LIBELLE"].ToString();
                                    clsCtcontratgarantieDTO.GA_CODEGARANTIE = rowCtcontratgarantie["GA_CODEGARANTIE"].ToString();
                                    clsCtcontratgarantieDTO.GA_LIBELLEGARANTIE = rowCtcontratgarantie["GA_LIBELLEGARANTIE"].ToString();
                                    clsCtcontratgarantieDTO.SC_CODESOUSCATEGORIE = rowCtcontratgarantie["SC_CODESOUSCATEGORIE"].ToString();
                                    clsCtcontratgarantieDTO.SC_LIBELLESOUSCATEGORIE = rowCtcontratgarantie["SC_LIBELLESOUSCATEGORIE"].ToString();
                                    clsCtcontratgarantieDTO.CT_LIBELLECATEGORIE = rowCtcontratgarantie["CT_LIBELLECATEGORIE"].ToString();
                                    clsCtcontratgarantieDTO.TG_LIBELLETYPEGARANTIE = rowCtcontratgarantie["TG_LIBELLETYPEGARANTIE"].ToString();
                                    clsCtcontratgarantieDTO.CG_GARANTIE = rowCtcontratgarantie["CG_GARANTIE"].ToString();

                                    //clsCtcontratgarantieDTO.RE_CODERESUME = rowCtcontratgarantie["RE_CODERESUME"].ToString();
                                    //clsCtcontratgarantieDTO.CP_VALEUR = rowCtcontratgarantie["CP_VALEUR"].ToString();

                                    clsCtcontratgarantieDTO.clsObjetRetour = new Common.clsObjetRetour();
                                    clsCtcontratgarantieDTO.clsObjetRetour.SL_CODEMESSAGE = "00";
                                    clsCtcontratgarantieDTO.clsObjetRetour.SL_RESULTAT = "TRUE";
                                    clsCtcontratgarantieDTO.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                                    clsCtcontratgarantieDTOS.Add(clsCtcontratgarantieDTO);
                            }
                        }
                        else
                        {
                            HT_Stock.BOJ.clsCtcontratgarantie clsCtcontratgarantieDTO = new HT_Stock.BOJ.clsCtcontratgarantie();
                                clsCtcontratgarantieDTO.clsObjetRetour = new Common.clsObjetRetour();
                                clsCtcontratgarantieDTO.clsObjetRetour.SL_CODEMESSAGE = "99";
                                clsCtcontratgarantieDTO.clsObjetRetour.SL_RESULTAT = "FALSE";
                                clsCtcontratgarantieDTO.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                                clsCtcontratgarantieDTOS.Add(clsCtcontratgarantieDTO);
                        }
                        clsCtcontrat.clsCtcontratgaranties = clsCtcontratgarantieDTOS;
                        //=========Fin liste des garanties



                        //=========Debut liste des primes
                        List<HT_Stock.BOJ.clsCtcontratprime> clsCtcontratprimeDTOS = new List<HT_Stock.BOJ.clsCtcontratprime>();
                        clsCtcontratprimeWSBLL clsCtcontratprimeWSBLL = new clsCtcontratprimeWSBLL();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, clsCtcontrat.CA_CODECONTRAT };
                            DataSetCtcontratprime = clsCtcontratprimeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                        if (DataSetCtcontratprime.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rowCtcontratprime in DataSetCtcontratprime.Tables[0].Rows)
                            {
                                    HT_Stock.BOJ.clsCtcontratprime clsCtcontratprimeDTO = new HT_Stock.BOJ.clsCtcontratprime();
                                    clsCtcontratprimeDTO.AG_CODEAGENCE = rowCtcontratprime["AG_CODEAGENCE"].ToString();
                                    clsCtcontratprimeDTO.EN_CODEENTREPOT = rowCtcontratprime["EN_CODEENTREPOT"].ToString();
                                    clsCtcontratprimeDTO.CA_CODECONTRAT = rowCtcontratprime["CA_CODECONTRAT"].ToString();
                                    clsCtcontratprimeDTO.RE_CODERESUME = rowCtcontratprime["RE_CODERESUME"].ToString();
                                    if (rowCtcontratprime["CP_VALEUR"].ToString() != "")
                                        clsCtcontratprimeDTO.CP_VALEUR = Double.Parse(rowCtcontratprime["CP_VALEUR"].ToString());// rowCtcontratprime["CP_VALEUR"].ToString();
                                    if (rowCtcontratprime["CG_PRIMES"].ToString() != "")
                                        clsCtcontratprimeDTO.CG_PRIMES = Double.Parse(rowCtcontratprime["CP_VALEUR"].ToString());// rowCtcontratprime["CP_VALEUR"].ToString();
                                    clsCtcontratprimeDTO.RE_LIBELLERESUME = rowCtcontratprime["RE_LIBELLERESUME"].ToString();
                                    clsCtcontratprimeDTO.clsObjetRetour = new Common.clsObjetRetour();
                                    clsCtcontratprimeDTO.clsObjetRetour.SL_CODEMESSAGE = "00";
                                    clsCtcontratprimeDTO.clsObjetRetour.SL_RESULTAT = "TRUE";
                                    clsCtcontratprimeDTO.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                                    clsCtcontratprimeDTOS.Add(clsCtcontratprimeDTO);
                            }
                        }
                        else
                        {
                            HT_Stock.BOJ.clsCtcontratprime clsCtcontratprimeDTO = new HT_Stock.BOJ.clsCtcontratprime();
                            clsCtcontratprimeDTO.clsObjetRetour = new Common.clsObjetRetour();
                            clsCtcontratprimeDTO.clsObjetRetour.SL_CODEMESSAGE = "99";
                            clsCtcontratprimeDTO.clsObjetRetour.SL_RESULTAT = "FALSE";
                            clsCtcontratprimeDTO.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                            clsCtcontratprimeDTOS.Add(clsCtcontratprimeDTO);
                        }
                        clsCtcontrat.clsCtcontratprimes = clsCtcontratprimeDTOS;
                        //=========Fin liste des primes



                        //=========Debut liste réduction
                        List<HT_Stock.BOJ.clsCtcontratreduction> clsCtcontratreductionDTOS = new List<HT_Stock.BOJ.clsCtcontratreduction>();
                        clsCtcontratreductionWSBLL clsCtcontratreductionWSBLL = new clsCtcontratreductionWSBLL();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, clsCtcontrat.CA_CODECONTRAT };
                        DataSetCtcontratreduction = clsCtcontratreductionWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                        if (DataSetCtcontratreduction.Tables[0].Rows.Count > 0)
                        {
                            
                            foreach (DataRow rowCtcontratreduction in DataSetCtcontratreduction.Tables[0].Rows)
                            {
                                HT_Stock.BOJ.clsCtcontratreduction clsCtcontratreductionDTO = new HT_Stock.BOJ.clsCtcontratreduction();
                                clsCtcontratreductionDTO.AG_CODEAGENCE = rowCtcontratreduction["AG_CODEAGENCE"].ToString();
                                clsCtcontratreductionDTO.EN_CODEENTREPOT = rowCtcontratreduction["EN_CODEENTREPOT"].ToString();
                                clsCtcontratreductionDTO.CA_CODECONTRAT = rowCtcontratreduction["CA_CODECONTRAT"].ToString();
                                clsCtcontratreductionDTO.RD_CODEREDUCTION = rowCtcontratreduction["RD_CODEREDUCTION"].ToString();
                                clsCtcontratreductionDTO.RD_LIBELLEREDUCTION = rowCtcontratreduction["RD_LIBELLEREDUCTION"].ToString();
                                    if (rowCtcontratreduction["RD_TAUX"].ToString() != "")
                                        clsCtcontratreductionDTO.RD_TAUX = float.Parse(rowCtcontratreduction["RD_TAUX"].ToString()).ToString();// rowCtcontratreduction["RD_TAUX"].ToString();
                                    if (rowCtcontratreduction["RD_MONTANT"].ToString() != "")
                                        clsCtcontratreductionDTO.RD_MONTANT = Double.Parse(rowCtcontratreduction["RD_MONTANT"].ToString());// rowCtcontratreduction["RD_MONTANT"].ToString();

                                clsCtcontratreductionDTO.clsObjetRetour = new Common.clsObjetRetour();
                                clsCtcontratreductionDTO.clsObjetRetour.SL_CODEMESSAGE = "00";
                                clsCtcontratreductionDTO.clsObjetRetour.SL_RESULTAT = "TRUE";
                                clsCtcontratreductionDTO.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                                clsCtcontratreductionDTOS.Add(clsCtcontratreductionDTO);
                            }
                        }
                        else
                        {
                            HT_Stock.BOJ.clsCtcontratreduction clsCtcontratreductionDTO = new HT_Stock.BOJ.clsCtcontratreduction();
                            clsCtcontratreductionDTO.clsObjetRetour = new Common.clsObjetRetour();
                            clsCtcontratreductionDTO.clsObjetRetour.SL_CODEMESSAGE = "99";
                            clsCtcontratreductionDTO.clsObjetRetour.SL_RESULTAT = "FALSE";
                            clsCtcontratreductionDTO.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                            clsCtcontratreductionDTOS.Add(clsCtcontratreductionDTO);
                        }
                        clsCtcontrat.clsCtcontratreductions = clsCtcontratreductionDTOS;
                            //=========Fin liste réduction


                        //=========Debut liste Ayant droit
                        List<HT_Stock.BOJ.clsCtcontratayantdroit> clsCtcontratayantdroitDTOS = new List<HT_Stock.BOJ.clsCtcontratayantdroit>();
                            clsCtcontratayantdroitWSBLL clsCtcontratayantdroitWSBLL = new clsCtcontratayantdroitWSBLL();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.CA_CODECONTRAT };
                            DataSetCtcontratayantdroit = clsCtcontratayantdroitWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                        if (DataSetCtcontratayantdroit.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rowCtcontratayantdroit in DataSetCtcontratayantdroit.Tables[0].Rows)
                            {
                                    HT_Stock.BOJ.clsCtcontratayantdroit clsCtcontratayantdroitDTO = new HT_Stock.BOJ.clsCtcontratayantdroit();
                                    clsCtcontratayantdroitDTO.AG_CODEAGENCE = rowCtcontratayantdroit["AG_CODEAGENCE"].ToString();
                                    clsCtcontratayantdroitDTO.EN_CODEENTREPOT = rowCtcontratayantdroit["EN_CODEENTREPOT"].ToString();
                                    clsCtcontratayantdroitDTO.CA_CODECONTRAT = rowCtcontratayantdroit["CA_CODECONTRAT"].ToString();
                                    clsCtcontratayantdroitDTO.AY_DENOMMINATIONAYANTDROIT = rowCtcontratayantdroit["AY_DENOMMINATIONAYANTDROIT"].ToString();



                                    clsCtcontratayantdroitDTO.AY_DATESAISIE = (rowCtcontratayantdroit["AY_DATESAISIE"].ToString() != "") ? DateTime.Parse(rowCtcontratayantdroit["AY_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                                    clsCtcontratayantdroitDTO.AY_DATESAISIE = (clsCtcontratayantdroitDTO.AY_DATESAISIE != "01-01-1900") ? clsCtcontratayantdroitDTO.AY_DATESAISIE : "";


                                    clsCtcontratayantdroitDTO.AY_INDEX = rowCtcontratayantdroit["AY_INDEX"].ToString();

                                    clsCtcontratayantdroitDTO.AY_DATECLOTURE = (rowCtcontratayantdroit["AY_DATECLOTURE"].ToString() != "") ? DateTime.Parse(rowCtcontratayantdroit["AY_DATECLOTURE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                                    clsCtcontratayantdroitDTO.AY_DATECLOTURE = (clsCtcontratayantdroitDTO.AY_DATECLOTURE != "01-01-1900") ? clsCtcontratayantdroitDTO.AY_DATECLOTURE : "";

                                    clsCtcontratayantdroitDTO.TA_CODETITREAYANTDROIT = rowCtcontratayantdroit["TA_CODETITREAYANTDROIT"].ToString();
                                    clsCtcontratayantdroitDTO.OP_CODEOPERATEUR = rowCtcontratayantdroit["OP_CODEOPERATEUR"].ToString();
                                    clsCtcontratayantdroitDTO.TA_LIBELLETITREAYANTDROIT = rowCtcontratayantdroit["TA_LIBELLETITREAYANTDROIT"].ToString();
                                    if(rowCtcontratayantdroit["AY_TAUX"].ToString()!="")
                                    clsCtcontratayantdroitDTO.AY_TAUX =float.Parse(rowCtcontratayantdroit["AY_TAUX"].ToString()).ToString();
                                    clsCtcontratayantdroitDTO.clsObjetRetour = new Common.clsObjetRetour();
                                    clsCtcontratayantdroitDTO.clsObjetRetour.SL_CODEMESSAGE = "00";
                                    clsCtcontratayantdroitDTO.clsObjetRetour.SL_RESULTAT = "TRUE";
                                    clsCtcontratayantdroitDTO.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                                    clsCtcontratayantdroitDTOS.Add(clsCtcontratayantdroitDTO);
                            }
                        }
                        else
                        {
                            HT_Stock.BOJ.clsCtcontratayantdroit clsCtcontratayantdroitDTO = new HT_Stock.BOJ.clsCtcontratayantdroit();
                                clsCtcontratayantdroitDTO.clsObjetRetour = new Common.clsObjetRetour();
                                clsCtcontratayantdroitDTO.clsObjetRetour.SL_CODEMESSAGE = "99";
                                clsCtcontratayantdroitDTO.clsObjetRetour.SL_RESULTAT = "FALSE";
                                clsCtcontratayantdroitDTO.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                                clsCtcontratayantdroitDTOS.Add(clsCtcontratayantdroitDTO);
                        }
                        clsCtcontrat.clsCtcontratayantdroits = clsCtcontratayantdroitDTOS;
                        //=========Fin liste Ayant droit
                        //=========Debut liste CAPITAUX
                        List<HT_Stock.BOJ.clsCtcontratcapitaux> clsCtcontratcapitauxDTOS = new List<HT_Stock.BOJ.clsCtcontratcapitaux>();
                            clsCtcontratcapitauxWSBLL clsCtcontratcapitauxWSBLL = new clsCtcontratcapitauxWSBLL();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, clsCtcontrat.CA_CODECONTRAT };
                            DataSetCtcontratcapitaux = clsCtcontratcapitauxWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                        if (DataSetCtcontratcapitaux.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rowCtcontratcapitaux in DataSetCtcontratcapitaux.Tables[0].Rows)
                            {
                                    HT_Stock.BOJ.clsCtcontratcapitaux clsCtcontratcapitauxDTO = new HT_Stock.BOJ.clsCtcontratcapitaux();
                                    clsCtcontratcapitauxDTO.AG_CODEAGENCE = rowCtcontratcapitaux["AG_CODEAGENCE"].ToString();
                                    clsCtcontratcapitauxDTO.EN_CODEENTREPOT = rowCtcontratcapitaux["EN_CODEENTREPOT"].ToString();
                                    clsCtcontratcapitauxDTO.CA_CODECONTRAT = rowCtcontratcapitaux["CA_CODECONTRAT"].ToString();
                                    if (rowCtcontratcapitaux["CC_CAPITAUX"].ToString() != "")
                                        clsCtcontratcapitauxDTO.CC_CAPITAUX =double.Parse( rowCtcontratcapitaux["CC_CAPITAUX"].ToString());
                                    clsCtcontratcapitauxDTO.CC_LIBELLE = rowCtcontratcapitaux["CC_LIBELLE"].ToString();
                                    if (rowCtcontratcapitaux["CC_PRIMES"].ToString() != "")
                                        clsCtcontratcapitauxDTO.CC_PRIMES =double.Parse( rowCtcontratcapitaux["CC_PRIMES"].ToString());
                                    if (rowCtcontratcapitaux["CC_TAUX"].ToString() != "0")
                                        clsCtcontratcapitauxDTO.CC_TAUX =float.Parse( rowCtcontratcapitaux["CC_TAUX"].ToString()).ToString();
                                    clsCtcontratcapitauxDTO.CP_CODECAPITAUX = rowCtcontratcapitaux["CP_CODECAPITAUX"].ToString();
                                    clsCtcontratcapitauxDTO.CP_LIBELLECAPITAUX = rowCtcontratcapitaux["CP_LIBELLECAPITAUX"].ToString();
                                    clsCtcontratcapitauxDTO.clsObjetRetour = new Common.clsObjetRetour();
                                    clsCtcontratcapitauxDTO.clsObjetRetour.SL_CODEMESSAGE = "00";
                                    clsCtcontratcapitauxDTO.clsObjetRetour.SL_RESULTAT = "TRUE";
                                    clsCtcontratcapitauxDTO.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                                    clsCtcontratcapitauxDTOS.Add(clsCtcontratcapitauxDTO);
                            }
                        }
                        else
                        {
                            HT_Stock.BOJ.clsCtcontratcapitaux clsCtcontratcapitauxDTO = new HT_Stock.BOJ.clsCtcontratcapitaux();
                                clsCtcontratcapitauxDTO.clsObjetRetour = new Common.clsObjetRetour();
                                clsCtcontratcapitauxDTO.clsObjetRetour.SL_CODEMESSAGE = "99";
                                clsCtcontratcapitauxDTO.clsObjetRetour.SL_RESULTAT = "FALSE";
                                clsCtcontratcapitauxDTO.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                                clsCtcontratcapitauxDTOS.Add(clsCtcontratcapitauxDTO);
                        }
                        clsCtcontrat.clsCtcontratcapitauxs = clsCtcontratcapitauxDTOS;
                        //=========Fin liste CAPITAUX



                            clsCtcontrats.Add(clsCtcontrat);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
                


            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontrats;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontrat> pvgChargerDansDataSetListeContratSansAccessoir(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontrats = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
                //--TEST CONTRAINTE
                clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].CA_CODECONTRAT, Objet[0].CA_NUMPOLICE, Objet[0].TI_NUMTIERS, Objet[0].TI_DENOMINATION, Objet[0].TI_NUMTIERSCOMMERCIAL, Objet[0].TI_DENOMINATIONCOMMERCIAL, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].RQ_CODERISQUE, Objet[0].EX_EXERCICE, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            DataSet DataSetCtcontratgarantie = new DataSet();
            DataSet DataSetCtcontratprime = new DataSet();
            DataSet DataSetCtcontratreduction = new DataSet();
            DataSet DataSetCtcontratayantdroit = new DataSet();
            DataSet DataSetCtcontratcapitaux = new DataSet();
            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsCtcontratWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                //string json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                        clsCtcontrat.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                        clsCtcontrat.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsCtcontrat.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsCtcontrat.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                        clsCtcontrat.CA_DATESAISIE = (row["CA_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CA_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATESAISIE = (clsCtcontrat.CA_DATESAISIE != "01-01-1900") ? clsCtcontrat.CA_DATESAISIE : "";
                        clsCtcontrat.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsCtcontrat.IT_CODEINTERMEDIAIRE = row["IT_CODEINTERMEDIAIRE"].ToString();
                        clsCtcontrat.AP_CODETYPEAPPARTEMENT = row["AP_CODETYPEAPPARTEMENT"].ToString();
                        clsCtcontrat.OC_CODETYPEOCCUPANT = row["OC_CODETYPEOCCUPANT"].ToString();
                        clsCtcontrat.ZA_CODEZONEAUTO = row["ZA_CODEZONEAUTO"].ToString();
                        clsCtcontrat.CB_IDBRANCHE = row["CB_IDBRANCHE"].ToString();
                        clsCtcontrat.CA_DATEEFFET = (row["CA_DATEEFFET"].ToString() != "") ? DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEEFFET = (clsCtcontrat.CA_DATEEFFET != "01-01-1900") ? clsCtcontrat.CA_DATEEFFET : "";
                        clsCtcontrat.CA_DATEECHEANCE = (row["CA_DATEECHEANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEECHEANCE = (clsCtcontrat.CA_DATEECHEANCE != "01-01-1900") ? clsCtcontrat.CA_DATEECHEANCE : "";
                        clsCtcontrat.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        if (row["CA_AVENANT"].ToString() != "")
                            clsCtcontrat.CA_AVENANT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_AVENANT"].ToString()).ToString(), "M");// row["CA_AVENANT"].ToString();
                        clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = row["CA_SITUATIONGEOGRAPHIQUE"].ToString();
                        clsCtcontrat.CA_CONDITIONHABITUEL = row["CA_CONDITIONHABITUEL"].ToString();
                        clsCtcontrat.ST_CODESTATUTSOCIOPROF = row["ST_CODESTATUTSOCIOPROF"].ToString();
                        clsCtcontrat.AU_CODECATEGORIE = row["AU_CODECATEGORIE"].ToString();
                        clsCtcontrat.TA_CODETARIF = row["TA_CODETARIF"].ToString();
                        clsCtcontrat.US_CODEUSAGE = row["US_CODEUSAGE"].ToString();
                        clsCtcontrat.GE_CODEGENRE = row["GE_CODEGENRE"].ToString();
                        clsCtcontrat.TVH_CODETYPE = row["TVH_CODETYPE"].ToString();
                        clsCtcontrat.TVH_LIBELE = row["TVH_LIBELE"].ToString();
                        clsCtcontrat.EN_CODEENERGIE = row["EN_CODEENERGIE"].ToString();

                        clsCtcontrat.MF_CODEMAINFORTE = row["MF_CODEMAINFORTE"].ToString();
                        clsCtcontrat.MF_LIBLLEMAINFORTE = row["MF_LIBLLEMAINFORTE"].ToString();
                        clsCtcontrat.ZM_CODEZONEVOYAGE = row["ZM_CODEZONEVOYAGE"].ToString();
                        clsCtcontrat.ZM_NOMZONEVOYAGE = row["ZM_NOMZONEVOYAGE"].ToString();
                        clsCtcontrat.ZA_NOMZONEAUTO = row["ZA_NOMZONEAUTO"].ToString();
                        if (row["CT_NOMBRECONTRAT"].ToString() != "")
                            clsCtcontrat.CT_NOMBRECONTRAT = Double.Parse(row["CT_NOMBRECONTRAT"].ToString());// row["CT_NOMBRECONTRAT"].ToString();
                        if (row["CA_NOMBREPIECE"].ToString() != "")
                            clsCtcontrat.CA_NOMBREPIECE = Double.Parse(row["CA_NOMBREPIECE"].ToString());
                        if (row["CA_SUPERFICIE"].ToString() != "")
                            clsCtcontrat.CA_SUPERFICIE = Double.Parse(row["CA_SUPERFICIE"].ToString());
                        if (row["CA_LOYERMENSUEL"].ToString() != "")
                            clsCtcontrat.CA_LOYERMENSUEL = Double.Parse(row["CA_LOYERMENSUEL"].ToString());
                        clsCtcontrat.CA_DATENAISSANCE = (row["CA_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATENAISSANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATENAISSANCE = (clsCtcontrat.CA_DATENAISSANCE != "01-01-1900") ? clsCtcontrat.CA_DATENAISSANCE : "";
                        clsCtcontrat.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                        clsCtcontrat.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                        clsCtcontrat.CA_LIEUNAISSANCE = row["CA_LIEUNAISSANCE"].ToString();


                        if (row["CA_TAUX"].ToString() != "")
                            clsCtcontrat.CA_TAUX = float.Parse(row["CA_TAUX"].ToString()).ToString();
                        clsCtcontrat.CA_TYPE = row["CA_TYPE"].ToString();
                        clsCtcontrat.CA_NUMSERIE = row["CA_NUMSERIE"].ToString();
                        clsCtcontrat.CA_IMMATRICULATION = row["CA_IMMATRICULATION"].ToString();
                        if (row["CA_PUISSANCEADMISE"].ToString() != "")
                            clsCtcontrat.CA_PUISSANCEADMISE = Double.Parse(row["CA_PUISSANCEADMISE"].ToString());
                        if (row["CA_CHARGEUTILE"].ToString() != "")
                            clsCtcontrat.CA_CHARGEUTILE = Double.Parse(row["CA_CHARGEUTILE"].ToString());
                        if (row["CA_NBREPLACE"].ToString() != "")
                            clsCtcontrat.CA_NBREPLACE = Double.Parse(row["CA_NBREPLACE"].ToString());
                        if (row["CA_VALNEUVE"].ToString() != "")
                            clsCtcontrat.CA_VALNEUVE = Double.Parse(row["CA_VALNEUVE"].ToString());
                        if (row["CA_VALVENALE"].ToString() != "")
                            clsCtcontrat.CA_VALVENALE = Double.Parse(row["CA_VALVENALE"].ToString());

                        if (row["DUREE"].ToString() != "")
                            clsCtcontrat.DUREE = Double.Parse(row["DUREE"].ToString());

                        clsCtcontrat.CA_DATEMISECIRCULATION = (row["CA_DATEMISECIRCULATION"].ToString() != "") ? DateTime.Parse(row["CA_DATEMISECIRCULATION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEMISECIRCULATION = (clsCtcontrat.CA_DATEMISECIRCULATION != "01-01-1900") ? clsCtcontrat.CA_DATEMISECIRCULATION : "";
                        clsCtcontrat.CA_CLIENTEXONERETAXE = row["CA_CLIENTEXONERETAXE"].ToString();
                        clsCtcontrat.TI_IDTIERSCOMMERCIAL = row["TI_IDTIERSCOMMERCIAL"].ToString();
                        clsCtcontrat.TI_IDTIERSASSUREUR = row["TI_IDTIERSASSUREUR"].ToString();
                        clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (row["CA_DATETRANSMISSIONAASSUREUR"].ToString() != "") ? DateTime.Parse(row["CA_DATETRANSMISSIONAASSUREUR"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = (clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR != "01-01-1900") ? clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR : "";
                        clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (row["CA_DATEVALIDATIONASSUREUR"].ToString() != "") ? DateTime.Parse(row["CA_DATEVALIDATIONASSUREUR"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATEVALIDATIONASSUREUR = (clsCtcontrat.CA_DATEVALIDATIONASSUREUR != "01-01-1900") ? clsCtcontrat.CA_DATEVALIDATIONASSUREUR : "";

                        clsCtcontrat.CA_DATEVALIDATIONCONTRAASS = (row["CA_DATEVALIDATIONCONTRAASS"].ToString() != "") ? DateTime.Parse(row["CA_DATEVALIDATIONCONTRAASS"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATESUSPENSION = (row["CA_DATESUSPENSION"].ToString() != "") ? DateTime.Parse(row["CA_DATESUSPENSION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATESUSPENSION = (clsCtcontrat.CA_DATESUSPENSION != "01-01-1900") ? clsCtcontrat.CA_DATESUSPENSION : "";
                        clsCtcontrat.CA_DATECLOTURE = (row["CA_DATECLOTURE"].ToString() != "") ? DateTime.Parse(row["CA_DATECLOTURE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATECLOTURE = (clsCtcontrat.CA_DATECLOTURE != "01-01-1900") ? clsCtcontrat.CA_DATECLOTURE : "";
                        clsCtcontrat.CA_DATERESILIATION = (row["CA_DATERESILIATION"].ToString() != "") ? DateTime.Parse(row["CA_DATERESILIATION"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATERESILIATION = (clsCtcontrat.CA_DATERESILIATION != "01-01-1900") ? clsCtcontrat.CA_DATERESILIATION : "";
                        clsCtcontrat.CA_NOMINTERLOCUTEUR = row["CA_NOMINTERLOCUTEUR"].ToString();
                        clsCtcontrat.CA_CONTACTINTERLOCUTEUR = row["CA_CONTACTINTERLOCUTEUR"].ToString();
                        clsCtcontrat.DI_CODEDESIGNATION = row["DI_CODEDESIGNATION"].ToString();
                        clsCtcontrat.TA_CODETYPECONTRATSANTE = row["TA_CODETYPECONTRATSANTE"].ToString();
                        clsCtcontrat.CA_CODECONTRATSECONDAIRE = row["CA_CODECONTRATSECONDAIRE"].ToString();
                        clsCtcontrat.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                        clsCtcontrat.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                        clsCtcontrat.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                        clsCtcontrat.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                        clsCtcontrat.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                        clsCtcontrat.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                        clsCtcontrat.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                        clsCtcontrat.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                        clsCtcontrat.TI_TELEPHONECOMMERCIAL = row["TI_TELEPHONECOMMERCIAL"].ToString();
                        clsCtcontrat.TI_NUMTIERSASSUREUR = row["TI_NUMTIERSASSUREUR"].ToString();
                        clsCtcontrat.TI_DENOMINATIONASSUREUR = row["TI_DENOMINATIONASSUREUR"].ToString();
                        clsCtcontrat.TI_TELEPHONEASSUREUR = row["TI_TELEPHONEASSUREUR"].ToString();
                        clsCtcontrat.IT_DENOMMINATION = row["IT_DENOMMINATION"].ToString();
                        clsCtcontrat.TA_LIBLLETYPEAFFAIRES = row["TA_LIBLLETYPEAFFAIRES"].ToString();
                        clsCtcontrat.DI_LIBELLEDESIGNATION = row["DI_LIBELLEDESIGNATION"].ToString();
                        clsCtcontrat.TI_NUMTIERSCOMMERCIAL = row["TI_NUMTIERSCOMMERCIAL"].ToString();
                        clsCtcontrat.TI_DENOMINATIONCOMMERCIAL = row["TI_DENOMINATIONCOMMERCIAL"].ToString();
                        clsCtcontrat.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsCtcontrat.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsCtcontrat.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        clsCtcontrat.TA_CODETYPEAFFAIRES = row["TA_CODETYPEAFFAIRES"].ToString();
                        clsCtcontrat.CD_CODECONDITION = row["CD_CODECONDITION"].ToString();
                        clsCtcontrat.CD_LIBELLECONDITION = row["CD_LIBELLECONDITION"].ToString();
                        clsCtcontrat.CA_DUREEENMOIS = Double.Parse(row["CA_DUREEENMOIS"].ToString());// row["CA_DUREEENMOIS"].ToString();
                        clsCtcontrat.AC_SPORT = row["AC_SPORT"].ToString();
                        clsCtcontrat.CA_ADRESSE = row["CA_ADRESSE"].ToString();
                        clsCtcontrat.ST_LIBELLESTATUTSOCIOPROF = row["ST_LIBELLESTATUTSOCIOPROF"].ToString();
                        clsCtcontrat.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                        clsCtcontrat.EN_LIBELLEENERGIE = row["EN_LIBELLEENERGIE"].ToString();
                        clsCtcontrat.AU_LIBELLECATEGORIE = row["AU_LIBELLECATEGORIE"].ToString();
                        clsCtcontrat.TA_LIBELLETARIF = row["TA_LIBELLETARIF"].ToString();
                        clsCtcontrat.US_LIBELLEUSAGE = row["US_LIBELLEUSAGE"].ToString();
                        clsCtcontrat.GE_LIBELLEGENRE = row["GE_LIBELLEGENRE"].ToString();
                        clsCtcontrat.AP_LIBLLETYPEAPPARTEMENT = row["AP_LIBLLETYPEAPPARTEMENT"].ToString();
                        clsCtcontrat.OC_LIBLLETYPEOCCUPANT = row["OC_LIBLLETYPEOCCUPANT"].ToString();
                        clsCtcontrat.CA_NUMPASSEPORT = row["CA_NUMPASSEPORT"].ToString();
                        clsCtcontrat.PY_CODEPAYSDESTINATION = row["PY_CODEPAYSDESTINATION"].ToString();
                        clsCtcontrat.PY_LIBELLEDESTINATION = row["PY_LIBELLEDESTINATION"].ToString();
                        if (row["CA_DUREESEJOUR"].ToString() != "")
                            clsCtcontrat.CA_DUREESEJOUR = double.Parse(row["CA_DUREESEJOUR"].ToString());
                        clsCtcontrat.CA_OPTION = row["CA_OPTION"].ToString();
                        clsCtcontrat.AU_CODETYPECONTRATAUTO = row["AU_CODETYPECONTRATAUTO"].ToString();
                        clsCtcontrat.AU_LIBELLETYPECONTRATAUTO = row["AU_LIBELLETYPECONTRATAUTO"].ToString();
                        clsCtcontrat.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsCtcontrat.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                        clsCtcontrat.PL_NUMCOMPTETIERS = row["PL_NUMCOMPTETIERS"].ToString();
                        clsCtcontrat.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                        clsCtcontrat.TI_NUMWHATSAPP = row["TI_NUMWHATSAPP"].ToString();
                        if (row["REGLEMENT"].ToString() != "")
                            clsCtcontrat.MONTANTREGLEMENT = Double.Parse(row["REGLEMENT"].ToString());
                        if (row["SOLDE"].ToString() != "")
                            clsCtcontrat.SOLDE = Double.Parse(row["SOLDE"].ToString());
                        if (row["PRIME"].ToString() != "")
                            clsCtcontrat.PRIME = Double.Parse(row["PRIME"].ToString());
                        clsCtcontrat.GR_CODEGARENTIEPRIME = row["GR_CODEGARENTIEPRIME"].ToString();
                        clsCtcontrat.GR_LIBELLEGARENTIEPRIME = row["GR_LIBELLEGARENTIEPRIME"].ToString();
                        clsCtcontrat.CA_OBSERVATION = row["CA_OBSERVATION"].ToString();
                        clsCtcontrat.MESSAGERELANCE = row["MESSAGERELANCE"].ToString();
                        clsCtcontrat.TI_EMAIL = row["TI_EMAIL"].ToString();
                        clsCtcontrat.EX_EXERCICE = row["EX_EXERCICE"].ToString();
                        clsCtcontrat.AS_NUMEROASSUREUR = row["AS_NUMEROASSUREUR"].ToString();
                        clsCtcontrat.CA_CODECONTRATORIGINE = row["CA_CODECONTRATORIGINE"].ToString();
                        //     private string _TI_TELEPHONECOMMERCIAL = "";
                        //private string _TI_NUMTIERSASSUREUR = "";
                        //private string _TI_DENOMINATIONASSUREUR = "";
                        //private string _TI_TELEPHONEASSUREUR = "";
                        //private string _IT_DENOMMINATION = "";
                        //private string _TA_LIBLLETYPEAFFAIRES = "";

                        //private String _PY_CODEPAYS = "";
                        //private String _PY_LIBELLE = "";
                        //private String _VL_CODEVILLE = "";
                        //private String _VL_LIBELLE = "";
                        //private String _CO_LIBELLE = "";

                        clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsCtcontrats.Add(clsCtcontrat);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                clsCtcontrats.Add(clsCtcontrat);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontrats;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgChargerDansDataSetListeContratSansAccessoirNew(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {


            DataSet DataSet = new DataSet();

            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            string json = "";

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireListeDataset(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListeDataSet(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT, Objet[0].CA_NUMPOLICE, Objet[0].TI_NUMTIERS, Objet[0].TI_DENOMINATION, Objet[0].TI_NUMTIERSCOMMERCIAL, Objet[0].TI_DENOMINATIONCOMMERCIAL, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].RQ_CODERISQUE,Objet[0].EX_EXERCICE, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
             DataSet = new DataSet();

            DataSet DataSetCtcontratgarantie = new DataSet();
            DataSet DataSetCtcontratprime = new DataSet();
            DataSet DataSetCtcontratreduction = new DataSet();
            DataSet DataSetCtcontratayantdroit = new DataSet();
            DataSet DataSetCtcontratcapitaux = new DataSet();
            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsCtcontratWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                //string json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["SL_CODEMESSAGE"] = "00";
                        DataSet.Tables[0].Rows[i]["SL_RESULTAT"] = "TRUE";
                        DataSet.Tables[0].Rows[i]["SL_MESSAGE"] = "Opération réalisée avec succès !!!";

                    }

                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Aucun enregistrement trouvé !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                //Execution du log
                Log.Error(SQLEx.Message, null);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontrat> pvgChargerDansDataSetMontantFacture(List<HT_Stock.BOJ.clsCtcontrat> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtcontrats = TestChampObligatoiremONTANTfACTURE(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
            //--TEST CONTRAINTE
            clsCtcontrats = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtcontrats[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontrats;
        }
        clsObjetEnvoi.OE_PARAM= new string[] {  Objet[0].AG_CODEAGENCE,  Objet[0].CA_CODECONTRAT,  Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratWSBLL.pvgChargerDansDataSetMontantFacture(clsDonnee, clsObjetEnvoi);
            clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();

            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                    
                    if (row["MONTANTTTCPLUSAIRSI"].ToString() != "")
                    clsCtcontrat.MONTANTTTCPLUSAIRSI = Double.Parse(row["MONTANTTTCPLUSAIRSI"].ToString());
                    if (row["MONTANTTTCPLUSAIRSI"].ToString() != "")
                    clsCtcontrat.MONTANTTTCPLUSAIRSINF = Double.Parse(row["MONTANTTTCPLUSAIRSI"].ToString());
                    clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontrat.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontrats.Add(clsCtcontrat);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontrats.Add(clsCtcontrat);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
            clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontrat.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
            clsCtcontrats.Add(clsCtcontrat);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontrats;
        }
        
    }
}
