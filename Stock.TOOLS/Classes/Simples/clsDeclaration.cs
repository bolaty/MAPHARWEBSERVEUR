using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Stock.TOOLS
{
    public class clsDeclaration
    {
        #region  declaration unique de la classe

        //declaration unique de la classe clsDeclaration pour tout le projet
        private readonly static clsDeclaration ClassesDeclaration = new clsDeclaration();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsDeclaration()
        {
        }
        //constructeur public de la classe fonction 

        public static clsDeclaration ClasseDeclaration
        {
            get { return ClassesDeclaration; }
        }

        #endregion

        //Constantes couleur
        public static Color GrisClair;
        public static Color VertClair;
        public static Color VertFonce;
        public static Color Gris;
        public static Color Bleu;
        public static Color Blanc;
        public static Color Noir;
        public static Color Rouge;
        public static Color BleuCiel;
        public static Color VertClair2;
        public static Color Anthracite;
        public static Color VertFluo;
        public static Color Jaune;
        public static Color JauneClair;
        public static Color BleuClair;
        public static Color JaunePale;
        public static Color Orange;
        public static Color Kaki;
        //Couleurs d'affichages des fiches
        public static Color vagCouleurFond;
        public static Color vagCouleurActivation;
        public static Color vagCouleurDésactivation;
        public static Color vagCouleurPolice;
        public static Color vagCouleurPoliceEtiquette;
        public static Color vagCouleurPoliceListe;
        public static Color vagCouleurPoliceFrame;
        public static Color vagCouleurPoliceSpecial;


        //
        //timer
        public static System.Windows.Forms.Timer TimerMiseEnVeille = new System.Windows.Forms.Timer();
        //Donne la durée d'inactivité exprimee en millisecondes
        public double vagDureeInactivite;

        //Statut du regmement sur immo:1=reglement guichet;2=reglement sur banque
        public string vagStatutReglementImmo;


        //permet de connaitre l'état de la connexion
        public bool vagEtatConnexion;

        public static string vagCode;
        //
        public enum enEtatOperateur
        {
            OK,
            Inconnu,
            Desactive,
            Connecte
        }

        public struct SParametres
        {
            public string ChaineConnection;
            public string Agence;
            public string NomServeur;
            public string LangueParDefaut;
            public bool ParametreMiseAJourLangues;
            public string CodeLangueInitial;
            public string CodeLangue;
        }
        public static SParametres vagParametres;
        
        //variable globale pour savoir si c'est le démmarage en cours du logiciel
        public static bool vagDemmarage;


        public struct SParametreGlobal
        {
            public decimal PP_TAUXTDI;//TAUX DIRECTION
            public decimal PP_TAUXTEN;//TAUX AGENCE D'ENVOI
            public decimal PP_TAUXTPA;//TAUX AGENCE DE PAIEMENT
            public decimal PP_TAUXTPR;//TAUX PRESTATAIRE
            public decimal PP_TAUXTPS;//TAXE SUR PRESTATION DE SERVICE
            public decimal PP_TAUXTTHU;//TAXE HORS UEMOA
            public decimal PP_TAUXTVA;//TAXE SUR VALEUR AJOUTEE

            public string PP_VALEURADT;//ACTIVER TRIGGER / DESACTIVER TRIGGER
            public double PP_MONTANTBDM;//BASE DE LA DUREE MENSUEL
            public double PP_MONTANTBDA;//BASE DE LA DUREE ANNUEL
            public string PP_VALEURBFO;//BACK OFFICE / FRONT OFFICE          
            public double PP_MONTANTTIM;//TIMBRE
            public double PP_MONTANTACE;//AGENCES CENTRALISES=1 / AGENCES DECENTRALISES=0
            public string PP_SIGNATUREETATFINANCIER;
            public string PP_SIGNATUREETATFINANCIERTITRE;
            //Comptes
            public string PP_VALEURCCAI;//Comptes caisses

            //Entête état financiers
            public string PP_VALEURENT1;
            public string PP_VALEURENT2;
            public string PP_VALEURENT3;
            public string PP_VALEURENT4;

            public string PP_VALEURSOURCEENT;

            //
            //
            public string PP_VALEURCOBP;//Champs obligatoire personne physique
            public string PP_VALEURCOBM;//Champs obligatoire personne morale

            public string PP_MONTANTUOB;//UTILISATION OBLIGATOIRE DU BILLETAGE  
            public string PP_VALEURCBQE;//COMPTE BANQUE  
            public string PP_VALEURCFOU;//COMPTE FOURNISSEUR  
            public string PP_VALEURCHIM;//CHEMIN DE RECUPERATION DES FICHIERS ET IMAGES ENVOYES AU SERVEUR
            public string PP_VALEURCHIL;//CHEMIN DE RECUPERATION DES FICHIERS ET IMAGES ENVOYES AU CLIENT
            public string PP_MONTANTTAIL;//TAILLE DU FICHIER IMAGE
            public double PP_MONTANTDUIN;//DUREE D'INACTIVITE AVANT LA MISE EN VEILLE
            public bool PP_VALEURMODFIERFRAISCREDIT;//POSSIBILITE DE MODIFIER LES FRAIS SUR DOSSIER DE CREDIT
            public string PP_STATUTCODEBARRE;//INFORME SI LE CODE BARRE EST OBLIGATOIRE OU NON
            public string PP_STATUTVAC;//VENTE A LA CAISSE
            public string PP_STATUTVAA;//VENTE AVEC ACCESSOIR
            public string PP_STATUTPRESSING;//VENTE PRESSING
            public string PP_STATUTVSUP;//VENTE SUPERMARCHE
            public string PP_STATUTVSA;//VENTE SANS ACCESSOIR
            public string PP_STATUTDRDV;//DATE RENDEZ-VOUS
            public string PP_STATUTDESC;//STATUT DU CHAMP DESCRIPTION UTILISE LORS DES APPRO
            public string PP_STATUTIPRA;//STATUT DE L'IMPRESSION DU RECU SUR L'ECRAN D'APPRO
            //public string PP_STATUTSDS;//STATUT DE SORTIE DE STOCK
            public string PP_STATUTPAAZ;//STATUT PRIX ACHAT ACCEPTE ZERO
            public string PP_STATUTPVAZ;//PRIX DE VENTE ACCEPTE  ZERO
            public string PP_STATUTDRDVO;//DATE RENDEZ-VOUS OBLIGATOIRE
            public string PP_STATUTTPR;//TYPE RECU (A4(0) /IMPRIMANTE THERMIQUE(1))
            public string PP_CODECLTVC;//CODE CLIENT PAR DEFAUT POUR LA VENTE A LA CAISSE
            public string PP_PY_CODEPAYSSOCIETE;//CODE CLIENT PAR DEFAUT POUR LA VENTE A LA CAISSE
            public string PP_CPTCHARGEREMISE;//COMPTE CHARGE DE REMISE
            public string PP_CPTEPRODUIT;//COMPTE PRODUIT
            public string PP_CPTETVA;//TVA FACTUREE SUR VENTE
            public string PP_CPTETVAA;//TVA SUR ACHAT

            public string PP_CPTEAIRSI;//COMPTE AIRSI
            public string PP_CPTESURPLUS;//COMPTE SURPLUS
            public int PP_UTILISERCPTESURPLUS;//UTILISER LE COMPTE SURPLUS ?
            public string PP_CPTECLTHOTEL;//COMPTE CLIENT HOTEL
            public string PP_PAYSD;//PAYS PAR DEFAUT
            public string PP_STATUTTPPA;//TYPE PRIX ECRAN D'APPRO
            public string PP_STATUTTPPV;//TYPE PRIX ECRAN DE VENTE
            public string PP_STATUTPAEV;//PRIX AFFICHER SUR ECRAN DE VENTE
            public string PP_STATUTPAEA;//PRIX AFFICHER SUR ECRAN D'ACHAT

            public string PP_STATUTSTOCKALERTE;//STATUT DE LA QUANTITE DE L'ARTICLE
            public double PP_POIDSEMBALLAGE;//POIDS EMBALLAGE
            //GESTION LIBELLE=====================================================================================
            public string PP_LIBELLECOMPOSANTCOMMERCIAUX;//LIBELLE COMPOSANT COMMERCIAUX
            public string PP_LIBELLECOMPOSANTCOMMERCIAL;//LIBELLE COMPOSANT COMMERCIAL
            public string PP_CPTECPCO;//COMPTE CHARGE POUR LE REGLEMENT DES COMMERCIAUX
            public string PP_CODEMODEGESTION;//MODE DE GESTION
            public string PP_MG_ENTREPOTOBLIGATOIRE;//MODE DE GESTION ENTREPOT OBLIGATOIRE

            public string PP_LIBELLECOMPOSANTNUMAGRMENT;//LIBELLE COMPOSANT COMMERCIAL
            public string PP_LIBELLECOMPOSANTNUMAGRMENT2;//LIBELLE COMPOSANT COMMERCIAL




            //TYPE PRIX=====================================================================================
            public string PP_TYPEPRIXACHATECRANAPPROSANSACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN D'APPRO SANS ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANAPPROSANSACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN D'APPRO SANS ACCESSOIRE
            public string PP_TYPEPRIXACHATECRANVENTESANSACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN DE VENTE SANS ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANVENTESANSACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN DE VENTE SANS ACCESSOIRE

            public string PP_TYPEPRIXACHATECRANAPPROCOOPERATIVE;//TYPE PRIX D'ACHAT SUR L'ECRAN D'APPRO COOPRATIVE
            public string PP_TYPEPRIXVENTEECRANAPPROCOOPERATIVE;//TYPE PRIX DE VENTE SUR L'ECRAN D'APPRO COOPRATIVE
            public string PP_TYPEPRIXACHATECRANVENTECOOPERATIVE;//TYPE PRIX D'ACHAT SUR L'ECRAN DE VENTE COOPRATIVE
            public string PP_TYPEPRIXVENTEECRANVENTECOOPERATIVE;//TYPE PRIX DE VENTE SUR L'ECRAN DE VENTE COOPRATIVE
           

           

            public string PP_TYPEPRIXACHATECRANAPPRODEPOTBOISSON;//TYPE PRIX D'ACHAT SUR L'ECRAN D'APPRO DEPOT DE BOISSON
            public string PP_TYPEPRIXVENTEECRANAPPRODEPOTBOISSON;//TYPE PRIX DE VENTE SUR L'ECRAN D'APPRO DEPOT DE BOISSON
            public string PP_TYPEPRIXACHATECRANVENTEDEPOTBOISSON;//TYPE PRIX D'ACHAT SUR L'ECRAN DE VENTE DEPOT DE BOISSON
            public string PP_TYPEPRIXVENTECRANVENTEDEPOTBOISSON;//TYPE PRIX DE VENTE SUR L'ECRAN DE VENTE DEPOT DE BOISSON

            public string PP_TYPEPRIXACHATECRANAPPROPRESSING;//TYPE PRIX D'ACHAT SUR L'ECRAN D'APPRO PRESSING
            public string PP_TYPEPRIXVENTEECRANAPPROPRESSING;//TYPE PRIX DE VENTE SUR L'ECRAN D'APPRO PRESSING
            public string PP_TYPEPRIXACHATECRANVENTEPRESSING;//TYPE PRIX D'ACHAT SUR L'ECRAN DE VENTE PRESSING
            public string PP_TYPEPRIXVENTEECRANVENTEPRESSING;//TYPE PRIX DE VENTE SUR L'ECRAN DE VENTE PRESSING

            public string PP_TYPEPRIXACHATECRANAPPROLUNETTERIE;//TYPE PRIX D'ACHAT SUR L'ECRAN D'APPRO LUNETTERIE
            public string PP_TYPEPRIXVENTEECRANAPPROLUNETTERIE;//TYPE PRIX DE VENTE SUR L'ECRAN D'APPRO LUNETTERIE
            public string PP_TYPEPRIXACHATECRANVENTELUNETTERIE;//TYPE PRIX D'ACHAT SUR L'ECRAN DE VENTE LUNETTERIE
            public string PP_TYPEPRIXVENTEECRANVENTELUNETTERIE;//TYPE PRIX DE VENTE SUR L'ECRAN DE VENTE LUNETTERIE


            public string PP_TYPEPRIXACHATECRANPRODUCTION;//TYPE PRIX D'ACHAT SUR L'ECRAN PRODUCTION
            public string PP_TYPEPRIXVENTEECRANPRODUCTION;//TYPE PRIX DE VENTE SUR L'ECRAN PRODUCTION

            public string PP_TYPEPRIXACHATECRANTRANSFERT;//TYPE PRIX D'ACHAT SUR L'ECRAN TRANSFERT
            public string PP_TYPEPRIXVENTEECRANTRANSFERT;//TYPE PRIX DE VENTE SUR L'ECRAN TRANSFERT


            public string PP_TYPEPRIXACHATECRANCOMMANDECLIENTSANSACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN COMMANDE CLIENT SANS ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANCOMMANDECLIENTSANSACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN COMMANDE CLIENT SANS ACCESSOIRE
            public string PP_TYPEPRIXACHATECRANCOMMANDECLIENTAVECACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN COMMANDE CLIENT AVEC ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANCOMMANDECLIENTAVECACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN COMMANDE CLIENT AVEC ACCESSOIRE


            public string PP_TYPEPRIXACHATECRANCOMMANDEFOURNISSEURSANSACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN COMMANDE FOURNISSEUR SANS ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANCOMMANDEFOURNISSEURSANSACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN COMMANDE FOURNISSEUR SANS ACCESSOIRE
            public string PP_TYPEPRIXACHATECRANCOMMANDEFOURNISSEURAVECACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN COMMANDE FOURNISSEUR AVEC ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANCOMMANDEFOURNISSEURAVECACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN COMMANDE FOURNISSEUR AVEC ACCESSOIRE


            public string PP_TYPEPRIXACHATECRANPROFORMASANSACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN COMMANDE PROFORMA SANS ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANPROFORMASANSACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN COMMANDE PROFORMA SANS ACCESSOIRE
            public string PP_TYPEPRIXACHATECRANPROFORMAAVECACCESSOIRE;//TYPE PRIX D'ACHAT SUR L'ECRAN COMMANDE PROFORMA AVEC ACCESSOIRE
            public string PP_TYPEPRIXVENTEECRANPROFORMAAVECACCESSOIRE;//TYPE PRIX DE VENTE SUR L'ECRAN COMMANDE PROFORMA AVEC ACCESSOIRE


           
            public string PP_TYPEPRIXACHATECRANVENTEALACAISSE;//TYPE PRIX D'ACHAT SUR L'ECRAN VENTE A LA CAISSE
            public string PP_TYPEPRIXVENTEECRANVENTEALACAISSE;//TYPE PRIX DE VENTE SUR L'ECRAN VENTE A LA CAISSE



            //TYPE OPERATION=====================================================================================
            public string PP_TYPEOPERATIONAPPROSANSACCESSOIRE;//TYPE OPERATION APPROVISIONNEMENT SANS ACCESSOIRE
            public string PP_TYPEOPERATIONAPPROAVECACCESSOIRE;//TYPE OPERATION APPROVISIONNEMENT AVEC ACCESSOIRE
            public string PP_TYPEOPERATIONVENTESUPPERMARCHE;//TYPE OPERATION VENTE SUPPERMARCHE
            public string PP_TYPEOPERATIONVENTEDEPOTBOISSON;//TYPE OPERATION VENTE DEPOT DE BOISSON
            public string PP_TYPEOPERATIONDEPOTPRESSING;//TYPE OPERATION DEPOT PRESSING
            public string PP_TYPEOPERATIONRETRAITPRESSING;//TYPE OPERATION RETRAIT PRESSING
            public string PP_TYPEOPERATIONECRANTRANSFERTEMIS;//TYPE OPERATION TRANSFERT EMIS
            public string PP_TYPEOPERATIONECRANTRANSFERTERECU;//TYPE OPERATION TRANSFERT RECU
            public string PP_TYPEOPERATIONECRANPRODUCTIONMATIEREPREMIERE;//TYPE OPERATION PRODUCTION MATIERE PREMIERE
            public string PP_TYPEOPERATIONECRANPRODUCTIONPRODUITFINI;//TYPE OPERATION PRODUCTION PRODUIT FINI
            public string PP_TYPEOPERATIONECRANVENTECOOPERATIVE;//TYPE OPERATION VENTE COOPERATIVE
            public string PP_TYPEOPERATIONECRANAPPROCOOPERATIVE;//TYPE OPERATION APPRO COOPERATIVE
            public string PP_TYPEOPERATIONECRANVENTELUNETERIE;//TYPE OPERATION VENTE LUNETERIE

            public double PP_VALEURTAUXTVA;//TAUX TVA
            public double PP_VALEURTAUXAIRSI;//TAUX AIRSI
            public string PP_VALEURMOTDEPASSECOMPLEXE;//--COMPLEXITE DE MOT DE PASSE

            public string PP_VALEURSEUIL;//--SEUIL D'ALERTE AVANT EMISSION DES SMS

            public string vlpET_INDEX ;
            public string vlpET_INDEX1 ;
            public cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEditARemplir;
            public  cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEditCritaire;
            public DataSet DataSetCocher;

            public string PP_SEUILALERTEAVSESMS;//--SEUIL D'ALERTE AVANT EMISSION DE SMS

            public string PP_VALEURTYPEBALANCE;//--TYPE DE BALANCE
            public string PP_VALEURREPARTITION;//--REPARTTITION SUR LES ECRANS D'ACHAT ; VENTE ; OD ; CHARGE
            public string PP_VALEURLIBELLEASDI;//--LIBELLE DE ASDI
            public string PP_VALEURMFACT;//--MODE DE FACTURATION
            public double PP_LONGUEUR_DES_COMPTES_IMPUTABLES; //Champs obligatoire pour l'échéancier

            public string LIBELLENBRESACACHETE; //LIBELLE NOMBRE DE SAC ACHETE
            public string LIBELLENBRESACTRANSMIS; //LIBELLE NOMBRE DE SAC TRANSMIS
            public string LIBELLENBRESAC; //LIBELLE NOMBRE DE SAC
            public DataSet vppDataSetDroitPopupmenu; //DROIT SUR LES POPUPMENUS
            public bool PP_MONTANTAGAN;

            public double PP_MONTANTRPMI;//RECHERCHE DE PIECE COMPTABLE MONTANT MINIMUM
            public double PP_MONTANTRPMA;//RECHERCHE DE PIECE COMPTABLE MONTANT MAXIMUM

            public string PP_VALEURAPPLIQUERTIMB;//APPLIQUER LE TIMBRE FACTURE VENTE(PP_VALEUR=O : OUI; PP_VALEUR=N : NON)
            public string PP_VALEURAPPLIQUERTIMBA;//APPLIQUER LE TIMBRE FACTURE APPRO (PP_VALEUR=O : OUI; PP_VALEUR=N : NON)

            public string PP_VALEURAUTORISERMODIFMONTANT;//AUTORISATION DE MODIFFICATION DE MONTANT DES OPERATIONS QUI NE SOINT PAS DES OPERATIONS DE FACTURE(01=NON AUTORISER ; 02=AUTORISER)
            public string PP_VALEURAUTORISERMODIFCOMPTE;//AUTORISATION DE MODIFFICATION DU COMPTE DES OPERATIONS QUI NE SOINT PAS DES OPERATIONS DE FACTURE(01=NON AUTORISER ; 02=AUTORISER)
            public string PP_VALEURTYPEECRANOD;//TYPE D'ECRAN OD(01=OD UNIQUEMENT ; 02=OD AVEC VALIDATION UNIQUEMENT ; 03=ECRAN OD PLUS ECRAN DE VALIDATION)

            public string PP_VALEURTVAT;//STATUT TVA PAR DEFAUT SUR ECRAN TIERS
            public string PP_VALEURTVAAR;//STATUT TVA PAR DEFAUT SUR ECRAN ARTICLE
            public string PP_VALEURASDIT;//STATUT ASDI PAR DEFAUT SUR ECRAN TIERS
            public string PP_VALEURASDIA;//STATUT ASDI PAR DEFAUT SUR ECRAN ARTICLE
            public double PP_VALEURPALFONDTAUXREMISECLIENT;//PLAFOND DU TAUX DE REMISE CLIENT
            public double PP_VALEURPALFONDTAUXESCOMPTECLIENT;//PLAFOND DU TAUX D'ESCOMPTE CLIENT
            public string PP_VALEURGESTIONARTICLESPERISABLES;//GESTION DES ARTICLES PERISSABLES
            public string PP_VALEURUTILISATIONDELADUREEPARDEFAUTSURARTICLESPERISABLES;//UTILISATION DE LA DUREE PAR DEFAUT SUR LES ARTICLES PERISSABLES
            public double PP_VALEURDUREEPARDEFAUTDESARTICLESPERISABLES;//LA DUREE PAR DEFAUT DES ARTICLES PERISSABLES
            public string PP_VALEURTYPEFACTURE;//TYPE DE FACTURE
            public string PP_VALEURFACTURESANSENTETE;//FACTURE SANS ENTETE (PP_VALEUR=O POUR OUI ET PP_VALEUR=N POUR NON)

            public string PP_VALEURCONDITIONREGLEMENT;//CONDITION REGLEMENT 
            public string PP_VALEURAUTORISERMODIFICATIONCONDITIONREGLEMENT;//AUTORISER LA MODIFICATION CONDITION REGLEMENT (PP_VALEUR=O POUR OUI ET PP_VALEUR=N POUR NON)



        }
        public static SParametreGlobal vagParametreGlobal;

        public struct SSociete
        {
            public string SO_CODESOCIETE;
            public string TY_CODETYPEINSTITUTION;
            public string SO_RAISONSOCIAL;
            public string SO_BOITEPOSTAL;
            public string SO_TELEPHONE;
            public string SO_DIRECTEUR;
            public string SO_EMAIL;
            public string SO_SITEWEB;
            public string SO_ACTIF;
            public string SO_SLOGAN;
        }
        public static SSociete vagSociete;

        public struct SAgence
        {
            public string SO_CODESOCIETE;
            public string AG_CODEAGENCE;
            public string AG_AGENCECODE;
            public string VL_CODEVILLE;
            public string ZN_CODEZONE;
            public string AG_RAISONSOCIAL;
            public string AG_BOITEPOSTAL;
            public string AG_ADRESSEGEOGRAPHIQUE;
            public string AG_TELEPHONE;
            public string AG_FAX;
            public string OP_CODEOPERATEUR;//Ici le code opérateur represente le gérant,il faut un combo pour le selectionner dans les opérateurs
            public string AG_EMAIL;
            public string AG_ACTIF;
            public string AG_NUMEROAGREMENT;
            public string AG_REFERENCE;
            public DateTime AG_DATECREATION;
        }
        public static SAgence vagAgence;



        public struct SEntrepot
        {
            //public string SO_CODESOCIETE;
            public string AG_CODEAGENCE;
            public string EN_NUMENTREPOT;
            //public string VL_CODEVILLE;
            //public string ZN_CODEZONE;
            public string EN_DENOMINATION;
            public string EN_ADRESSEPOSTALE;
            public string EN_ADRESSEGEOGRAPHIQUE;
            public string EN_TELEPHONE;
            public string EN_FAX;
            public string EN_SITEWEB;
            public string OP_CODEOPERATEUR;//Ici le code opérateur represente le gérant,il faut un combo pour le selectionner dans les opérateurs
            public string EN_EMAIL;
            public string EN_GERANT;
            public string EN_ACTIF;
            public double EN_STOCKMAXI;
            public double EN_STOCKMINI;
            public string EN_REFERENCE;
            public string EN_ENTREPOTPARDEFAUT;




        }
        public static SEntrepot vagEntrepot;




        public struct SExercice
        {
            public string AG_CODEAGENCE;
            public string EX_EXERCICE;
            public string EX_DATEDEBUTBILAN;
            public DateTime EX_DATEDEBUT;
            public DateTime EX_DATEFIN;
            public string EX_ETATEXERCICE;
            public string EX_DESCEXERCICE;
            public DateTime EX_DATESAISIE;
            public DateTime EX_DATEDEBUTPREMIEREXERCICE;
            public DateTime EX_DATEAFFECTATIONRESULTAT;
        }
        public static SExercice vagExerciceEnCours;



        public struct SAnnee
        {
            public string AG_CODEAGENCE;
            public string CA_CODECAMPAGNE;
            public string CA_LIBELLEANNEEDEBUT;
            public string CA_LIBELLEANNEEFIN;
            public DateTime CA_DATEDEBUT;
            public DateTime CA_DATECLOTURE;
            //public string EX_ETATEXERCICE;
            //public string EX_DESCEXERCICE;
            //public DateTime EX_DATESAISIE;
            //public DateTime EX_DATEDEBUTPREMIEREXERCICE;
        }
        public static SAnnee vagCampagneEnCours;



        public struct SObjetEnvoi
        {
            public string SO_CODESOCIETE;
            public string AG_CODEAGENCE;
            public string EN_CODEENTREPOT;
            public string ZN_CODEZONE;
            public string OP_CODEOPERATEUR;
            public string DBUSER;
            public string CODEDECRYPTAGE;
            public string DERNIEREXERCICE;//Dernier exercice de l'agence sélectionné.
            public bool PREMIEREEXECUTION;//variable globale pour savoir si c'est la premiere execution du logiciel 
            public string AGENCEREFERENCE;//O=Direction générale,Z=Coordination,N=Agence simple,variable globale pour savoir si c'est l'agence de reference(direction générale) de la societe
            public DateTime JT_DATEJOURNEETRAVAIL;//Elle correspond a la date qui est définit pour travailler dans le system
          
            public DateTime JT_DATESYSTEMSERVEURDEMARRAGE;//Elle correspond a la date système du serveur validée au démmarrage du logiciel
            public string PARAMETRES;
        }
        public static SObjetEnvoi vagObjetEnvoi;

        public struct SJournee
        {
            public string AG_CODEAGENCE;
            public DateTime JT_DATEJOURNEETRAVAIL;//Elle correspond a la date qui est définit pour travailler dans le system
            public DateTime JT_DATEJOURNEETRAVAILDEMARRAGE;//Elle correspond a la date qui est définit pour travailler dans le systeme,au démarrage,celà est utilisée comme information lors des changement d'exerice,lorsqu'on change d'exercice de démarrage et que l'on revient sur ce exercice,c'est cette date qui doit s'afficher par defaut.
            public DateTime JT_DATESYSTEMSERVEURDEMARRAGE;//Elle correspond a la date système du serveur validée au démmarrage du logiciel
            public DateTime JT_DATEDERNIEREJOURNEETRAVAIL;//Elle correspond a la dernière journee de travail
            public string JT_STATUT;
            public string OP_CODEOPERATEUR;
            public SJournee(DateTime vppDate)
            {
                AG_CODEAGENCE = "";
                JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");
                JT_DATEJOURNEETRAVAILDEMARRAGE = DateTime.Parse("01/01/1900");
                JT_DATESYSTEMSERVEURDEMARRAGE = DateTime.Parse("01/01/1900");
                JT_DATEDERNIEREJOURNEETRAVAIL = DateTime.Parse("01/01/1900");
                JT_STATUT = "";
                OP_CODEOPERATEUR = "";
            }
        }
        public static SJournee vagJourneetravail;

        public struct SOperateur
        {
            public string AG_CODEAGENCE;
            public string OP_CODEOPERATEUR;
            public string PO_CODEPROFIL;
            public string TO_CODETYPEOERATEUR;
            public string PL_CODENUMCOMPTE;
            public string PL_NUMCOMPTE;
            public string PL_LIBELLE;
            public string OP_NOMPRENOM;
            public string OP_LOGIN;
            public string OP_MOTPASSE;
            public string OP_ACTIF;
            public string OP_TELEPHONE;
            public string OP_EMAIL;
            public string OP_JOURNEEOUVERTE;
            public DateTime OP_DATESAISIE;
            public string EN_CODEENTREPOT;
            public string TI_IDTIERSCLT;
            public string TI_NUMTIERSCLT;
            public string TI_DENOMINATIONCLT;
            public string PL_CODENUMCOMPTECLT;
            public string PL_NUMCOMPTECLT;
            public string NT_CODENATURETIERSCLT;
            public string TI_ASDICLT;
            public string TI_TVACLT;
            public string OP_EXTOURNE;
            public string OP_CREATIONJOURNE;
            public string OP_FERMETUREJOURNE;
            public string OP_CREATIONPROFILE;
            public string OP_CREATIONOPERATEUR;
            public string OP_CAISSIER;
            public string PL_CODENUMCOMPTECOFFREFORT;
            public string PL_NUMCOMPTECOFFREFORT;

            public string OP_SELECTIONOPERATEURAPPRO;
            public string OP_SELECTIONOPERATEURVENTE;
            public string OP_IMPRESSIONAUTOMATIQUE;
            public string OP_CONTREPARTIEAUTOMATIQUEOD;

            //public string OP_AGENTDIRECTION;

        }
        public static SOperateur vagOperateurEnCours;
        public static SOperateur vagOperateur;
        public static DataGridViewTextBoxEditingControl vagControl;
        //

        public struct SParametreSauvegardeControl
        {
            public string REPERTOIRESAUVEGARDE;
            public string FICHIERPARAMETRE;
            public List<string> EMAIL;
            public string FICHIERPARAMETRESAUVEGARDE;
            //public List<clsParametreSauvegarde> PARAMETRESAUVEGARDE;
            public double TAILLEALERTEREPERTOIRE;

        }
        public static SParametreSauvegardeControl vagParametreSauvegardeControl;


        public struct SParametreSauvegarde
        {
            public string PS_CODE;
            public string PS_DATE;
            public string PS_NOMBASE;
            public string PS_HEURESAUVEGARDE;
            public string PS_ACTIF;

        }
        public static SParametreSauvegarde vagParametreSauvegarde;


        public struct SPays
        {
            public string PY_CODEPAYSPARDEFAUT;//PAYS PAR DEFAUT

        }
        public static SPays vagPays;


        public struct SVille
        {
            public string VL_CODEVILLEPARDEFAUT;//VILLE PAR DEFAUT
        }
        public static SVille vagVille;

        public struct SCommune
        {
            public string CO_CODECOMMUNEPARDEFAUT;//VILLE PAR DEFAUT
        }
        public static SCommune vagCommune;
    }
}
