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
                        clsCtcontratgarantie.CG_APRESREDUCTION = double.Parse(clsCtcontratgarantieDTO.CG_APRESREDUCTION);
                        clsCtcontratgarantie.CG_CAPITAUXASSURES = double.Parse(clsCtcontratgarantieDTO.CG_CAPITAUXASSURES);
                        clsCtcontratgarantie.CG_FRANCHISES = clsCtcontratgarantieDTO.CG_FRANCHISES;
                        clsCtcontratgarantie.CG_LIBELLE = clsCtcontratgarantieDTO.CG_LIBELLE;
                        clsCtcontratgarantie.CG_MONTANT = double.Parse(clsCtcontratgarantieDTO.CG_MONTANT);
                        clsCtcontratgarantie.CG_PRIMES = double.Parse(clsCtcontratgarantieDTO.CG_PRIMES);
                        clsCtcontratgarantie.CG_PRORATA = double.Parse(clsCtcontratgarantieDTO.CG_PRORATA);
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
                        clsCtcontratprime.CP_VALEUR = double.Parse(clsCtcontratprimeDTO.CP_VALEUR);
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
                        clsCtcontratreduction.RD_TAUX = float.Parse(clsCtcontratreductionDTO.RD_TAUX);
                        clsCtcontratreduction.RD_MONTANT = double.Parse(clsCtcontratreductionDTO.RD_MONTANT);

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
                            clsCtcontratayantdroit.AY_TAUX = double.Parse(clsCtcontratayantdroitDTO.AY_TAUX);
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
                            clsCtcontratcapitaux.CC_CAPITAUX = double.Parse(clsCtcontratcapitauxDTO.CC_CAPITAUX);
                            clsCtcontratcapitaux.CC_PRIMES = double.Parse(clsCtcontratcapitauxDTO.CC_PRIMES);
                             clsCtcontratcapitaux.CC_TAUX = float.Parse(clsCtcontratcapitauxDTO.CC_TAUX);   
                             clsCtcontratcapitaux.CP_CODECAPITAUX =clsCtcontratcapitauxDTO.CP_CODECAPITAUX;                              
                                                    
                            clsCtcontratcapitauxs.Add(clsCtcontratcapitaux);
                    }


                    clsObjetRetour.SetValue(true, clsCtcontratWSBLL.pvgMiseAjour(clsDonnee, clsCtcontrat, clsCtcontratgaranties, clsCtcontratprimes, clsCtcontratreductions, clsCtcontratayantdroits, clsCtcontratcapitauxs, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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
                //HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                //clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                //clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                //clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                //clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                ////Execution du log
                //Log.Error(SQLEx.Message, null);
                //clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                //clsCtcontrats.Add(clsCtcontrat);


                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                clsCtcontrats.Add(clsCtcontrat);



            }
            catch (Exception SQLEx)
            {
                //HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                //clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                //clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "99";
                //clsCtcontrat.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                //clsCtcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
                ////Execution du log
                //Log.Error(SQLEx.Message, null);
                //clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
                //clsCtcontrats.Add(clsCtcontrat);


                HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
                clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "00";
                clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontrat.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
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

           
            clsObjetEnvoi.OE_PARAM= new string[] {  Objet[0].AG_CODEAGENCE,  Objet[0].EN_CODEENTREPOT,  Objet[0].CA_NUMPOLICE, Objet[0].TI_NUMTIERS,  Objet[0].TI_DENOMINATION,  Objet[0].TI_NUMTIERSCOMMERCIAL,  Objet[0].TI_DENOMINATIONCOMMERCIAL,  Objet[0].DATEDEBUT ,  Objet[0].DATEFIN ,Objet[0].RQ_CODERISQUE,  Objet[0].OP_CODEOPERATEUR,  Objet[0].TYPEOPERATION };
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
                        clsCtcontrat.CT_NOMBRECONTRAT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CT_NOMBRECONTRAT"].ToString()).ToString(), "M");// row["CT_NOMBRECONTRAT"].ToString();
                        if (row["CA_NOMBREPIECE"].ToString() != "")
                            clsCtcontrat.CA_NOMBREPIECE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_NOMBREPIECE"].ToString()).ToString(), "M");
                        if (row["CA_SUPERFICIE"].ToString() != "")
                            clsCtcontrat.CA_SUPERFICIE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_SUPERFICIE"].ToString()).ToString(), "M");
                        if (row["CA_LOYERMENSUEL"].ToString() != "")
                            clsCtcontrat.CA_LOYERMENSUEL = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_LOYERMENSUEL"].ToString()).ToString(), "M");
                        clsCtcontrat.CA_DATENAISSANCE = (row["CA_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["CA_DATENAISSANCE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                        clsCtcontrat.CA_DATENAISSANCE = (clsCtcontrat.CA_DATENAISSANCE != "01-01-1900") ? clsCtcontrat.CA_DATENAISSANCE : "";
                        clsCtcontrat.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                        clsCtcontrat.PF_LIBELLE = row["PF_LIBELLE"].ToString();
                        clsCtcontrat.CA_LIEUNAISSANCE = row["CA_LIEUNAISSANCE"].ToString() ; 


                            if (row["CA_TAUX"].ToString()!="")
                        clsCtcontrat.CA_TAUX = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_TAUX"].ToString()).ToString(), "M");
                        clsCtcontrat.CA_TYPE = row["CA_TYPE"].ToString();
                        clsCtcontrat.CA_NUMSERIE = row["CA_NUMSERIE"].ToString();
                        clsCtcontrat.CA_IMMATRICULATION = row["CA_IMMATRICULATION"].ToString();
                        if (row["CA_PUISSANCEADMISE"].ToString() != "")
                            clsCtcontrat.CA_PUISSANCEADMISE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_PUISSANCEADMISE"].ToString()).ToString(), "M");
                            if (row["CA_CHARGEUTILE"].ToString() != "")
                                clsCtcontrat.CA_CHARGEUTILE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_CHARGEUTILE"].ToString()).ToString(), "M");
                            if (row["CA_NBREPLACE"].ToString() != "")
                                clsCtcontrat.CA_NBREPLACE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_NBREPLACE"].ToString()).ToString(), "M");
                            if (row["CA_VALNEUVE"].ToString() != "")
                                clsCtcontrat.CA_VALNEUVE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_VALNEUVE"].ToString()).ToString(), "M");
                            if (row["CA_VALVENALE"].ToString() != "")
                                clsCtcontrat.CA_VALVENALE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_VALVENALE"].ToString()).ToString(), "M");
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
                    clsCtcontrat.CA_DUREEENMOIS = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CA_DUREEENMOIS"].ToString()).ToString(), "M");// row["CA_DUREEENMOIS"].ToString();
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
                    clsCtcontrat.CA_DUREESEJOUR = row["CA_DUREESEJOUR"].ToString();
                    clsCtcontrat.CA_OPTION = row["CA_OPTION"].ToString();
                    clsCtcontrat.AU_CODETYPECONTRATAUTO = row["AU_CODETYPECONTRATAUTO"].ToString();
                    clsCtcontrat.AU_LIBELLETYPECONTRATAUTO = row["AU_LIBELLETYPECONTRATAUTO"].ToString();
                    clsCtcontrat.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    clsCtcontrat.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                    clsCtcontrat.PL_NUMCOMPTETIERS = row["PL_NUMCOMPTETIERS"].ToString();
                    clsCtcontrat.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
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
                                        clsCtcontratgarantieDTO.CG_CAPITAUXASSURES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratgarantie["CG_CAPITAUXASSURES"].ToString()).ToString(), "M");// rowCtcontratgarantie["CG_CAPITAUXASSURES"].ToString();
                                    if (rowCtcontratgarantie["CG_PRIMES"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_PRIMES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratgarantie["CG_PRIMES"].ToString()).ToString(), "M");// rowCtcontratgarantie["CG_PRIMES"].ToString();
                                    if (rowCtcontratgarantie["CG_APRESREDUCTION"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_APRESREDUCTION = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratgarantie["CG_APRESREDUCTION"].ToString()).ToString(), "M");// rowCtcontratgarantie["CG_APRESREDUCTION"].ToString();
                                    if (rowCtcontratgarantie["CG_PRORATA"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_PRORATA = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratgarantie["CG_PRORATA"].ToString()).ToString(), "M");// rowCtcontratgarantie["CG_PRORATA"].ToString();
                              
                                        clsCtcontratgarantieDTO.CG_FRANCHISES = rowCtcontratgarantie["CG_FRANCHISES"].ToString();// rowCtcontratgarantie["CG_FRANCHISES"].ToString();
                                    if (rowCtcontratgarantie["CG_TAUX"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_TAUX = Double.Parse(rowCtcontratgarantie["CG_TAUX"].ToString()).ToString();// rowCtcontratgarantie["CG_TAUX"].ToString();
                                    if (rowCtcontratgarantie["CG_MONTANT"].ToString() != "")
                                        clsCtcontratgarantieDTO.CG_MONTANT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratgarantie["CG_MONTANT"].ToString()).ToString(), "M");// rowCtcontratgarantie["CG_MONTANT"].ToString();
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
                                        clsCtcontratprimeDTO.CP_VALEUR = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratprime["CP_VALEUR"].ToString()).ToString(), "M");// rowCtcontratprime["CP_VALEUR"].ToString();
                                    if (rowCtcontratprime["CG_PRIMES"].ToString() != "")
                                        clsCtcontratprimeDTO.CG_PRIMES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratprime["CP_VALEUR"].ToString()).ToString(), "M");// rowCtcontratprime["CP_VALEUR"].ToString();
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
                                        clsCtcontratreductionDTO.RD_TAUX = Double.Parse(rowCtcontratreduction["RD_TAUX"].ToString()).ToString();// rowCtcontratreduction["RD_TAUX"].ToString();
                                    if (rowCtcontratreduction["RD_MONTANT"].ToString() != "")
                                        clsCtcontratreductionDTO.RD_MONTANT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(rowCtcontratreduction["RD_MONTANT"].ToString()).ToString(), "M");// rowCtcontratreduction["RD_MONTANT"].ToString();

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
                                    if(rowCtcontratayantdroit["AY_TAUX"].ToString()!="0")
                                    clsCtcontratayantdroitDTO.AY_TAUX =double.Parse(rowCtcontratayantdroit["AY_TAUX"].ToString()).ToString();
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
                                    if (rowCtcontratcapitaux["CC_CAPITAUX"].ToString() != "0")
                                        clsCtcontratcapitauxDTO.CC_CAPITAUX = rowCtcontratcapitaux["CC_CAPITAUX"].ToString();
                                    clsCtcontratcapitauxDTO.CC_LIBELLE = rowCtcontratcapitaux["CC_LIBELLE"].ToString();
                                    if (rowCtcontratcapitaux["CC_PRIMES"].ToString() != "0")
                                        clsCtcontratcapitauxDTO.CC_PRIMES = rowCtcontratcapitaux["CC_PRIMES"].ToString();
                                    if (rowCtcontratcapitaux["CC_TAUX"].ToString() != "0")
                                        clsCtcontratcapitauxDTO.CC_TAUX = rowCtcontratcapitaux["CC_TAUX"].ToString();
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
                    clsCtcontrat.MONTANTTTCPLUSAIRSI = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MONTANTTTCPLUSAIRSI"].ToString()).ToString(), "M");
                    if (row["MONTANTTTCPLUSAIRSI"].ToString() != "")
                    clsCtcontrat.MONTANTTTCPLUSAIRSINF = Double.Parse(row["MONTANTTTCPLUSAIRSI"].ToString()).ToString();
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
