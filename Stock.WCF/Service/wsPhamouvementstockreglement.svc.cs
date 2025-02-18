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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhamouvementstockreglement" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhamouvementstockreglement.svc ou wsPhamouvementstockreglement.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhamouvementstockreglement : IwsPhamouvementstockreglement
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhamouvementstockreglementWSBLL clsPhamouvementstockreglementWSBLL = new clsPhamouvementstockreglementWSBLL();
        private clsEditionEtatClientFournisseurWSBLL clsEditionEtatClientFournisseurWSBLL = new clsEditionEtatClientFournisseurWSBLL();

        string vlpAG_CODEAGENCE = "";
        string vlpMV_DATESAISIE = "";

        string vlpTI_IDTIERS = "";
        string vlpEN_CODEENTREPOT = "";
        string vlpOP_CODEOPERATEUR = "";
        string vlpMR_CODEMODEREGLEMENT = "";
        string vlpTI_NUMTIERS ="";
        string vlpMS_NUMPIECE = "";
        string vlpCHC_REFCHEQUE = "";
        string vlpCA_NUMPOLICE = "";

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
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouter(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.MV_NUMPIECE = clsPhamouvementstockreglementDTO.MV_NUMPIECE.ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = clsPhamouvementstockreglementDTO.MV_LIBELLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouter(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgExtourne(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireExtourne(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();

                    //@AG_CODEAGENCE1, @MV_DATESAISIE, @MV_DATEPIECE, @MV_NUMPIECE,@MV_NUMPIECE1,@OP_CODEOPERATEUR,0,@CODECRYPTAGE1


                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    clsPhamouvementstockreglement.MV_DATESAISIE =DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());
                    clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATEPIECE.ToString());
                    clsPhamouvementstockreglement.MV_NUMPIECE = clsPhamouvementstockreglementDTO.MV_NUMPIECE.ToString();
                    clsPhamouvementstockreglement.MV_NUMPIECE1 = clsPhamouvementstockreglementDTO.MV_NUMPIECE1.ToString();
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();

                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgExtourne(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementCommissionAssurance(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();


              



                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "99999"; // LORS DE LA VENTE /APPRO
                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                    clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE =DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_DATESAISIE =DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse(cpsDevTextBoxD11.Text).ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT COMMISSION FACTURE N° : ";
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT =double.Parse( clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURETTC =double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERCOMMISSION"].ToString());
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                    clsPhamouvementstockreglement.FB_IDFOURNISSEUR = clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                    clsPhamouvementstockreglement.TYPEOPERATION = 3;

                     vlpAG_CODEAGENCE =clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques= new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse=new BOJ.clsCtcontratchequereglementcaisse();
                    List<Stock.BOJ.clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses=new List<BOJ.clsCtcontratchequephotoreglementcaisse>();
                    // clsPhamouvementstockreglement clsPhamouvementstockreglement, List< clsPhamouvementstockreglementcheque > clsPhamouvementstockreglementcheques, clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse, List< clsCtcontratchequephotoreglementcaisse > clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi clsObjetEnvoi
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques,  clsCtcontratchequereglementcaisse,  clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {

                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                    //
                    string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);

                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT= vlpNumero;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementAssureur(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                bool vlpTestRepertoire = true;
                clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                if (Objet[0].MR_CODEMODEREGLEMENT.ToString() == "02")
                    vlpTestRepertoire = clsParametreWSBLL.pvgTestCheminRepertoirePhotoSignature(clsDonnee, "PHOT1");
                else
                    vlpTestRepertoire = true;
                //vlpTestRepertoire = clsParametreWSBLL.pvgTestCheminRepertoirePhotoSignature(clsDonnee, "PHOT1");
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (!vlpTestRepertoire)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le dossier n'est pas paramètré ou est inexistant !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    return clsPhamouvementstockreglements;
                }


                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "99999"; // LORS DE LA VENTE /APPRO
                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                    clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// MS_NUMPIECE;
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE =DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_DATESAISIE =DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse(cpsDevTextBoxD11.Text).ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT ASSUREUR SFACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT =double.Parse( clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURETTC =double.Parse( clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                    clsPhamouvementstockreglement.FB_IDFOURNISSEUR = clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                    clsPhamouvementstockreglement.TYPEOPERATION = 4;

                    vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    clsPhamouvementstockreglement.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT); ;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques= new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse=new BOJ.clsCtcontratchequereglementcaisse();
                    List<Stock.BOJ.clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses=new List<BOJ.clsCtcontratchequephotoreglementcaisse>();
                    // clsPhamouvementstockreglement clsPhamouvementstockreglement, List< clsPhamouvementstockreglementcheque > clsPhamouvementstockreglementcheques, clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse, List< clsCtcontratchequephotoreglementcaisse > clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi clsObjetEnvoi
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques,  clsCtcontratchequereglementcaisse,  clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                    //
                    string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);

                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementClient(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            double vlpMONTANTVERSEMENT = 0;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {

                if (string.IsNullOrEmpty(Objet[Idx].MV_REFERENCEPIECE))
                    Objet[Idx].MV_REFERENCEPIECE = "";
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            HT_Stock.BOJ.clsObjetRetour clsObjetRetourTEST = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();


                bool vlpTestRepertoire = true;
                clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                if (Objet[0].MR_CODEMODEREGLEMENT.ToString() == "02")
                    vlpTestRepertoire = clsParametreWSBLL.pvgTestCheminRepertoirePhotoSignature(clsDonnee, "PHOT1");
                else
                    vlpTestRepertoire = true;
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (!vlpTestRepertoire)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le dossier n'est pas paramètré ou est inexistant !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    return clsPhamouvementstockreglements;
                }


                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                    clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                    vlpMS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;

                    clsPhamouvementstockreglement.CH_DATEDEBUTCOUVERTURE = DateTime.Parse(clsPhamouvementstockreglementDTO.CH_DATEDEBUTCOUVERTURE.ToString());
                    clsPhamouvementstockreglement.CH_DATEFINCOUVERTURE = DateTime.Parse(clsPhamouvementstockreglementDTO.CH_DATEFINCOUVERTURE.ToString());

                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse(cpsDevTextBoxD11.Text).ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                    vlpMONTANTVERSEMENT = clsPhamouvementstockreglement.MONTANTVERSEMENT;
                    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURETTC = double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                    clsPhamouvementstockreglement.FB_IDFOURNISSEUR = clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                    clsPhamouvementstockreglement.DT_NUMEROTRANSACTION = clsPhamouvementstockreglementDTO.DT_NUMEROTRANSACTION.ToString();// TI_IDTIERSASSUREUR;

                    clsPhamouvementstockreglement.TYPEOPERATION = 1;

                    vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    vlpTI_IDTIERS = clsPhamouvementstockreglementDTO.TI_IDTIERS.ToString();
                    vlpEN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();
                    vlpOP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();
                    vlpMR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();
                    vlpTI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();


                    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    clsPhamouvementstockreglement.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT); ;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;


                    //=====
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    if (clsPhamouvementstockreglementDTO.clsPhamouvementstockreglementcheques != null)
                        foreach (HT_Stock.BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementchequeDTO in clsPhamouvementstockreglementDTO.clsPhamouvementstockreglementcheques)
                        {
                            BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new BOJ.clsPhamouvementstockreglementcheque();
                            clsPhamouvementstockreglementcheque.AG_CODEAGENCE = clsPhamouvementstockreglementchequeDTO.AG_CODEAGENCE;
                            clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIRE = clsPhamouvementstockreglementchequeDTO.AB_CODEAGENCEBANCAIRE;
                            clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIREASSUREUR = clsPhamouvementstockreglementchequeDTO.AB_CODEAGENCEBANCAIREASSUREUR;
                            clsPhamouvementstockreglementcheque.MS_NUMPIECE = clsPhamouvementstockreglementchequeDTO.MS_NUMPIECE;
                            clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE = clsPhamouvementstockreglementchequeDTO.RC_NUMEROCHEQUE;
                            clsPhamouvementstockreglementcheque.RC_VALEURCHEQUE = clsPhamouvementstockreglementchequeDTO.RC_VALEURCHEQUE;
                            clsPhamouvementstockreglementcheques.Add(clsPhamouvementstockreglementcheque);
                        }

                    //=====


                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new BOJ.clsCtcontratchequereglementcaisse();
                    if (clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse != null)
                        if (clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CA_CODECONTRAT != "")
                        {
                            clsCtcontratchequereglementcaisse.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AG_CODEAGENCE;
                            clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE);
                            clsCtcontratchequereglementcaisse.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.EN_CODEENTREPOT;
                            clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE;
                            clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIREASSUREUR = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIREASSUREUR;
                            clsCtcontratchequereglementcaisse.CA_CODECONTRAT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CA_CODECONTRAT;
                            clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE;
                            clsCtcontratchequereglementcaisse.CHC_REFCHEQUE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_REFCHEQUE;
                            vlpCHC_REFCHEQUE = clsCtcontratchequereglementcaisse.CHC_REFCHEQUE;
                            clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE = double.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE);
                            clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER = double.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER);
                            clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE = DateTime.Parse("01/01/1900");
                            clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE);
                            clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE = DateTime.Parse("01/01/1900");
                            clsCtcontratchequereglementcaisse.CHC_NOMTIREUR = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMTIREUR;
                            clsCtcontratchequereglementcaisse.CHC_NOMTIRE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMTIRE;
                            clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE);

                            clsCtcontratchequereglementcaisse.CHC_DATEDEBUTCOUVERTURE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEDEBUTCOUVERTURE);
                            clsCtcontratchequereglementcaisse.CHC_DATEFINCOUVERTURE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEFINCOUVERTURE);

                            clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT;
                            clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT;
                            clsCtcontratchequereglementcaisse.CHC_DATEEFFET = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEEFFET);
                            clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR;
                            clsCtcontratchequereglementcaisse.TYPEOPERATION = int.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.TYPEOPERATION);
                        }


                    //=====
                    List<Stock.BOJ.clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses = new List<BOJ.clsCtcontratchequephotoreglementcaisse>();
                    if (clsPhamouvementstockreglementDTO.clsCtcontratchequephotoreglementcaisses != null)
                        foreach (HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisseDTO in clsPhamouvementstockreglementDTO.clsCtcontratchequephotoreglementcaisses)
                        {
                            BOJ.clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new BOJ.clsCtcontratchequephotoreglementcaisse();
                            clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE = clsCtcontratchequephotoreglementcaisseDTO.AG_CODEAGENCE;
                            clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE = clsCtcontratchequephotoreglementcaisseDTO.CHC_IDEXCHEQUE;
                            clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE = DateTime.Parse(clsCtcontratchequephotoreglementcaisseDTO.CHC_DATESAISIECHEQUE);
                            clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisseDTO.CHC_CHEMINPHOTOCHEQUE;
                            clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisseDTO.CHC_LIBELLEPHOTOCHEQUE;


                            clsCtcontratchequephotoreglementcaisses.Add(clsCtcontratchequephotoreglementcaisse);
                        }

                    //=====

                    clsObjetRetourTEST.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgVerificatioSoldeCompteAvecChequeDiffere(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques, clsCtcontratchequereglementcaisse, clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    if (vlpBordereau != "")
                    {
                        clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                        //
                        string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                        clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;


                        string TE_CODESMSTYPEOPERATION = "";
                        if (vlpMR_CODEMODEREGLEMENT == "01")
                        {
                            TE_CODESMSTYPEOPERATION = "0006";
                        }
                        if (vlpMR_CODEMODEREGLEMENT == "02")
                        {
                            TE_CODESMSTYPEOPERATION = "0007";
                        }

                        string TI_NUMTIERS = "";
                        string TI_DENOMINATION = "";

                        string TI_TELEPHONE = "";
                        string EN_CODEENTREPOT = "";

                        DataSet DataSet = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, vlpTI_NUMTIERS };
                        clsPhatiersWSBLL clsPhatiersWSBLL = new clsPhatiersWSBLL();
                        DataSet = clsPhatiersWSBLL.pvgChargerDansDataSetAssureAvecCodeClient(clsDonnee, clsObjetEnvoi);
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                            TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                            TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                            EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                            vlpTI_IDTIERS = row["TI_IDTIERS"].ToString();

                        }

                        DataSet DataSetCT = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, Objet[0].MS_NUMPIECE };
                        clsCtcontratWSBLL clsCtcontratWSBLL = new clsCtcontratWSBLL();
                        DataSetCT = clsCtcontratWSBLL.pvgChargerDansDataSetPARID(clsDonnee, clsObjetEnvoi);
                        foreach (DataRow row in DataSetCT.Tables[0].Rows)
                        {
                            vlpCA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();

                        }

                        clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, Objet[0].MS_NUMPIECE, TI_NUMTIERS, vlpMV_DATESAISIE, "2", vlpOP_CODEOPERATEUR };
                        DataSet DataSetRE = new DataSet();
                        DataSetRE = clsPhamouvementstockreglementWSBLL.pvgMouvementResumeReglement(clsDonnee, clsObjetEnvoi);

                        foreach (DataRow row in DataSetRE.Tables[0].Rows)
                        {
                            clsPhamouvementstockreglement.RESTEAREGLER = (row["RESTEAREGLER"].ToString() != "") ? double.Parse(row["RESTEAREGLER"].ToString()) : 0;// row["RESTEAREGLER"].ToString();

                        }





                        BOJ.clsParams clsParams = new BOJ.clsParams();
                        if (TI_TELEPHONE != "")
                        {

                            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                            //if (CL_CONTACT.Length == 10)
                            //    CL_CONTACT = "00225" + CL_CONTACT;
                            string CL_IDCLIENT = "";
                            string SL_MESSAGECLIENT = "PO:" + vlpCA_NUMPOLICE + "#SO:" + clsPhamouvementstockreglement.RESTEAREGLER + "#RF:" + vlpCHC_REFCHEQUE + "#MT:" + vlpMONTANTVERSEMENT.ToString();// clsParams.SMSTEXT;
                            string SL_RESULTATAPI = "";
                            string SL_MESSAGEAPI = "";
                            string SL_MESSAGE = "";

                            //clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, clsMiccomptewebmotpasseoublieListe[0].AG_CODEAGENCE, clsMiccomptewebmotpasseoublieListe[0].PV_CODEPOINTVENTE, clsMiccomptewebmotpasseoublieListe[0].CO_CODECOMPTE, clsMiccomptewebmotpasseoublieListe[0].OB_NOMOBJET, clsMiccomptewebmotpasseoublieDTO.CL_CONTACT, clsMiccomptewebmotpasseoublieListe[0].OP_CODEOPERATEUR, clsMiccomptewebmotpasseoublieListe[0].RP_DATE, "", CL_IDCLIENT, "", clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT, "0024", "0", "01/01/1900", "0", "0", "N", "0", clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE1, clsMiccomptewebmotpasseoublieListe[0].SL_LIBELLE2);

                            //clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string SM_TELEPHONE, string OP_CODEOPERATEUR, DateTime SM_DATEPIECE, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2
                            clsParams = clsSmsoutWSBLL.pvgTraitementSms(clsDonnee, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT, "compte", "FrmClientPhysique", TI_TELEPHONE, vlpOP_CODEOPERATEUR, DateTime.Parse(vlpMV_DATESAISIE.ToString()), "", vlpTI_IDTIERS, "", SL_MESSAGECLIENT, TE_CODESMSTYPEOPERATION, "0", DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), "0", "", "N", "0", "", "");


                            SL_RESULTATAPI = clsParams.SL_RESULTAT;
                            SL_MESSAGEAPI = clsParams.SL_MESSAGE;
                            if (clsParams.SL_RESULTAT == "FALSE") SL_MESSAGE = SL_MESSAGE + " " + SL_MESSAGEAPI;



                        }


                        //=====







                    }



                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementClientMobile(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {

                if (string.IsNullOrEmpty(Objet[Idx].MV_REFERENCEPIECE))
                    Objet[Idx].MV_REFERENCEPIECE = "";
                    //--TEST DES CHAMPS OBLIGATOIRES
                    clsPhamouvementstockreglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                    clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE =DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_DATESAISIE =DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse(cpsDevTextBoxD11.Text).ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT =double.Parse( clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURETTC =double.Parse( clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                    clsPhamouvementstockreglement.FB_IDFOURNISSEUR = clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                    clsPhamouvementstockreglement.TYPEOPERATION =1;

                    vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    clsPhamouvementstockreglement.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT); ;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;


                    //=====
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    if (clsPhamouvementstockreglementDTO.clsPhamouvementstockreglementcheques != null)
                        foreach (HT_Stock.BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementchequeDTO in clsPhamouvementstockreglementDTO.clsPhamouvementstockreglementcheques)
                        {
                            BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new BOJ.clsPhamouvementstockreglementcheque();
                            clsPhamouvementstockreglementcheque.AG_CODEAGENCE = clsPhamouvementstockreglementchequeDTO.AG_CODEAGENCE;
                            clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIRE = clsPhamouvementstockreglementchequeDTO.AB_CODEAGENCEBANCAIRE;
                            clsPhamouvementstockreglementcheque.MS_NUMPIECE = clsPhamouvementstockreglementchequeDTO.MS_NUMPIECE;
                            clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE = clsPhamouvementstockreglementchequeDTO.RC_NUMEROCHEQUE;
                            clsPhamouvementstockreglementcheque.RC_VALEURCHEQUE = clsPhamouvementstockreglementchequeDTO.RC_VALEURCHEQUE;
                            clsPhamouvementstockreglementcheques.Add(clsPhamouvementstockreglementcheque);
                        }

                    //=====


                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse=new BOJ.clsCtcontratchequereglementcaisse();

                    //if(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CA_CODECONTRAT!="")
                    //{
                    //    clsCtcontratchequereglementcaisse.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AG_CODEAGENCE;
                    //    clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE =DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE);
                    //    clsCtcontratchequereglementcaisse.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.EN_CODEENTREPOT;
                    //    clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE;
                    //    clsCtcontratchequereglementcaisse.CA_CODECONTRAT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CA_CODECONTRAT;
                    //    clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE;
                    //    clsCtcontratchequereglementcaisse.CHC_REFCHEQUE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_REFCHEQUE;
                    //    clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE =double.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE);
                    //    clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER = double.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER);
                    //    clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE = DateTime.Parse("01/01/1900");
                    //    clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE);
                    //    clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE = DateTime.Parse("01/01/1900");
                    //    clsCtcontratchequereglementcaisse.CHC_NOMTIREUR = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMTIREUR;
                    //    clsCtcontratchequereglementcaisse.CHC_NOMTIRE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMTIRE;
                    //    clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE =DateTime.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE);
                    //    clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT;
                    //    clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT;
                    //    clsCtcontratchequereglementcaisse.CHC_DATEEFFET = DateTime.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEEFFET);
                    //    clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR =clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR;
                    //    clsCtcontratchequereglementcaisse.TYPEOPERATION =int.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.TYPEOPERATION);
                    //}


                    //=====
                    List<Stock.BOJ.clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses = new List<BOJ.clsCtcontratchequephotoreglementcaisse>();
                    if (clsPhamouvementstockreglementDTO.clsCtcontratchequephotoreglementcaisses != null)
                        foreach (HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisseDTO in clsPhamouvementstockreglementDTO.clsCtcontratchequephotoreglementcaisses)
                        {
                            BOJ.clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new BOJ.clsCtcontratchequephotoreglementcaisse();
                            clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE = clsCtcontratchequephotoreglementcaisseDTO.AG_CODEAGENCE;
                            clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE = clsCtcontratchequephotoreglementcaisseDTO.CHC_IDEXCHEQUE;
                            clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE =DateTime.Parse(clsCtcontratchequephotoreglementcaisseDTO.CHC_DATESAISIECHEQUE);
                            clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisseDTO.CHC_CHEMINPHOTOCHEQUE;
                            clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisseDTO.CHC_LIBELLEPHOTOCHEQUE;


                            clsCtcontratchequephotoreglementcaisses.Add(clsCtcontratchequephotoreglementcaisse);
                        }

                    //=====


                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques,  clsCtcontratchequereglementcaisse,  clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    if (vlpBordereau != "")
                    {
                        clsObjetEnvoi.OE_PARAM = new string[] {vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                        //
                        string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                         clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                    }

                    

                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMiccomptewebResultat> pvgCreationDetailFacture(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebResultat> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            BOJ.clsMiccomptewebResultat clsMiccomptewebResultat = new BOJ.clsMiccomptewebResultat();


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {

                if (string.IsNullOrEmpty(Objet[Idx].MV_REFERENCEPIECE))
                    Objet[Idx].MV_REFERENCEPIECE = "";
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireInsertMobile(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                ////--TEST CONTRAINTE
                //clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                ////--VERIFICATION DU RESULTAT DU TEST
                //if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementBOJ = new Stock.BOJ.clsPhamouvementstockreglement();


                    if (string.IsNullOrEmpty(clsPhamouvementstockreglementDTO.TO_VALIDEROPERATIONENCOURS)) clsPhamouvementstockreglementDTO.TO_VALIDEROPERATIONENCOURS = "N";

                    clsPhamouvementstockreglementBOJ.DT_REFERENCE = ".";
                    clsPhamouvementstockreglementBOJ.DT_DESIGNATION = ".";
                    clsPhamouvementstockreglementBOJ.DT_QUANTITE = "1";
                    clsPhamouvementstockreglementBOJ.DT_PU = clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString();
                    clsPhamouvementstockreglementBOJ.DT_TOTALARTICLE = clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString();
                    clsPhamouvementstockreglementBOJ.DT_TOTALFACTURE = clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString();
                    clsPhamouvementstockreglementBOJ.PY_CODESTATUT = "01";
                    clsPhamouvementstockreglementBOJ.DT_DATEVALIDATION = "01/01/1900";
                    //string NO_CODENATUREVIREMENT = TE_CODESMSTYPEOPERATION;
                    clsPhamouvementstockreglementBOJ.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglementBOJ.MV_NUMEROPIECE = clsPhamouvementstockreglementDTO.MV_NUMEROPIECE;
                    clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION = clsPhamouvementstockreglementDTO.SL_NUMEROTRANSACTION.ToString();

                    //clsPhamouvementstockreglementBOJ.DT_NUMEROFACTURE = "";
                    clsPhamouvementstockreglementBOJ.TYPEOPERATION = int.Parse(clsPhamouvementstockreglementDTO.TYPEOPERATION.ToString());

                    if (clsPhamouvementstockreglementBOJ.TYPEOPERATION == 0)
                        clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION = System.Guid.NewGuid().ToString();



                    clsPhamouvementstockreglementBOJ.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                    clsPhamouvementstockreglementBOJ.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                    clsPhamouvementstockreglementBOJ.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                    clsPhamouvementstockreglementBOJ.PI_CODEPIECE = "";// clsPhamouvementstockreglementDTO.PI_CODEPIECE.ToString();
                    clsPhamouvementstockreglementBOJ.SO_CODESOUSCRIPTION = clsPhamouvementstockreglementDTO.SO_CODESOUSCRIPTION.ToString();
                    string TK_TOKEN = "";
                    clsPhamouvementstockreglementBOJ.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;
                    clsPhamouvementstockreglementBOJ.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// 
                     clsPhamouvementstockreglementBOJ.MONTANTFACTURETTC =double.Parse( clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// 





                    //clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO

                    //clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                    //clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    //clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    //clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    //clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;


                    //clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                    //clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse(cpsDevTextBoxD11.Text).ToString();
                    //clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";

                    ////clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    ////clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    ////clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    //clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    //clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    //clsPhamouvementstockreglement.MONTANTTVA = 0;
                    //clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    //clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                    //clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    //clsPhamouvementstockreglement.MONTANTFACTURETTC = double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                    //clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    //clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    //clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    //clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                    //clsPhamouvementstockreglement.FB_IDFOURNISSEUR = clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                    //clsPhamouvementstockreglement.TYPEOPERATION = 1;

                    //vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    //vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    ////MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    //clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    //clsPhamouvementstockreglement.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT); ;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;


                    //clsHttoken clsHttoken = new clsHttoken();
                    //clsHttoken = clsPhamouvementstockreglementWSBLL.pvgDemandeToken(clsDonnee, AG_CODEAGENCE, TK_TOKEN, TK_CODETYPEOPERATION, EJ_IDEPARGNANTJOURNALIER, "0");


                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new BOJ.clsCtcontratchequereglementcaisse();

                     clsMiccomptewebResultat = new BOJ.clsMiccomptewebResultat();
                    if (clsPhamouvementstockreglementDTO.TO_VALIDEROPERATIONENCOURS != "O")
                        clsMiccomptewebResultat = clsPhamouvementstockreglementWSBLL.pvgCreationDetailFacture(clsDonnee, clsPhamouvementstockreglementBOJ.AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION, clsPhamouvementstockreglementBOJ.DT_NUMEROFACTURE, clsPhamouvementstockreglementBOJ.DT_REFERENCE, clsPhamouvementstockreglementBOJ.DT_DESIGNATION, clsPhamouvementstockreglementBOJ.DT_QUANTITE, clsPhamouvementstockreglementBOJ.DT_PU, clsPhamouvementstockreglementBOJ.DT_TOTALARTICLE, clsPhamouvementstockreglementBOJ.DT_TOTALFACTURE, clsPhamouvementstockreglementBOJ.PY_CODESTATUT, clsPhamouvementstockreglementBOJ.TI_NUMTIERS, clsPhamouvementstockreglementBOJ.MR_CODEMODEREGLEMENT, clsPhamouvementstockreglementBOJ.DT_DATEVALIDATION, clsPhamouvementstockreglementBOJ.PI_CODEPIECE, clsPhamouvementstockreglementBOJ.MV_NOMTIERS, clsPhamouvementstockreglementBOJ.MV_NUMEROPIECE, clsPhamouvementstockreglementBOJ.SO_CODESOUSCRIPTION, TK_TOKEN, clsPhamouvementstockreglementBOJ.OP_CODEOPERATEUR, clsPhamouvementstockreglementBOJ.MS_NUMPIECE, clsPhamouvementstockreglementBOJ.MONTANTFACTURETTC.ToString(), clsPhamouvementstockreglementBOJ.TYPEOPERATION.ToString());
                    else//==Validation Opération MobileMoney
                    {
                        List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglementsTemp = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                        List<HT_Stock.BOJ.clsPhamouvementstockreglement> ObjetTemp = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                        HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementTemp = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                        DataSet DataSet = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementstockreglementBOJ.AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION };
                        DataSet = clsPhamouvementstockreglementWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATION(clsDonnee, clsObjetEnvoi);
                        if (DataSet.Tables[0].Rows.Count == 0)
                        {
                            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                            HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglementTEMP1 = new HT_Stock.BOJ.clsMiccomptewebResultat();
                            clsPhamouvementstockreglementTEMP1.clsObjetRetour = new Common.clsObjetRetour();

                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                            clsPhamouvementstockreglementTEMP1.SL_TELEPHONE = clsMiccomptewebResultat.SL_TELEPHONE;
                            clsPhamouvementstockreglementTEMP1.SL_INDICATIF = clsMiccomptewebResultat.SL_INDICATIF;
                            clsPhamouvementstockreglementTEMP1.SL_MONTANTOPERATION = clsMiccomptewebResultat.SL_MONTANTOPERATION;
                            clsPhamouvementstockreglementTEMP1.SL_URLNOTIFICATION = clsMiccomptewebResultat.SL_URLNOTIFICATION;

                            clsPhamouvementstockreglementTEMP1.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                            clsPhamouvementstockreglementTEMP1.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                            clsPhamouvementstockreglementTEMP1.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                            clsPhamouvementstockreglementTEMP1.SL_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                            clsPhamouvementstockreglementTEMP1.PV_CODEPOINTVENTE = clsMiccomptewebResultat.PV_CODEPOINTVENTE;
                            clsPhamouvementstockreglementTEMP1.CO_CODECOMPTE = clsMiccomptewebResultat.CO_CODECOMPTE;
                            clsPhamouvementstockreglementTEMP1.OB_NOMOBJET = clsMiccomptewebResultat.OB_NOMOBJET;
                            clsPhamouvementstockreglementTEMP1.SL_RESULTATAPI = clsMiccomptewebResultat.SL_RESULTATAPI;
                            clsPhamouvementstockreglementTEMP1.SL_MESSAGEAPI = clsMiccomptewebResultat.SL_MESSAGEAPI;
                            clsPhamouvementstockreglementTEMP1.SL_MESSAGECLIENT = clsMiccomptewebResultat.SL_MESSAGECLIENT;
                            clsPhamouvementstockreglementTEMP1.CL_IDCLIENT = clsMiccomptewebResultat.CL_IDCLIENT;
                            //clsPhamouvementstockreglement.clsReeditions = clsMiccomptewebResultat.clsReeditions;
                            clsPhamouvementstockreglementTEMP1.TK_TOKEN = clsMiccomptewebResultat.TK_TOKEN;

                            clsPhamouvementstockreglementTEMP1.clsObjetRetour.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                            clsPhamouvementstockreglementTEMP1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                            clsPhamouvementstockreglementTEMP1.clsObjetRetour.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                           

                            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglementTEMP1);
                            return clsPhamouvementstockreglements;
                        }

                        //==
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {

                            //AG_CODEAGENCE,EN_CODEENTREPOT,DT_DATEOPERATION,DT_NUMSEQUENCE,DT_NUMEROTRANSACTION,DT_REFERENCE, DT_DESIGNATION, DT_QUANTITE,DT_PU,DT_TOTALARTICLE, DT_TOTALFACTURE,DT_DATESAISIE,TI_IDTIERS,PY_CODESTATUT,MS_NUMPIECE,DT_DATEVALIDATION,PI_CODEPIECE,DT_NOMTIERS,DT_NUMPIECETIERS, CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "', TI_NUMTIERS) AS varchar(150)) AS TI_NUMTIERS, OP_CODEOPERATEUR

                            clsPhamouvementstockreglementTemp.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                            clsPhamouvementstockreglementTemp.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                            clsPhamouvementstockreglementTemp.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();// clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                            clsPhamouvementstockreglementTemp.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();// clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                            clsPhamouvementstockreglementTemp.MV_ANNULATIONPIECE = "N";
                            clsPhamouvementstockreglementTemp.MV_DATEPIECE = row["DT_DATEOPERATION"].ToString();// clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString();// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                            clsPhamouvementstockreglementTemp.MV_DATESAISIE = row["DT_DATEOPERATION"].ToString();// clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString();// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                            clsPhamouvementstockreglementTemp.MV_NOMTIERS = row["TI_DENOMINATION"].ToString();// clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;
                            clsPhamouvementstockreglementTemp.MR_CODEMODEREGLEMENT = "01";// clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                            clsPhamouvementstockreglementTemp.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();// clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                            clsPhamouvementstockreglementTemp.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();// clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                            clsPhamouvementstockreglementTemp.PL_NUMCOMPTEBANQUE = "0";// double.Parse(cpsDevTextBoxD11.Text).ToString();
                            clsPhamouvementstockreglementTemp.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";
                            clsPhamouvementstockreglementTemp.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();// clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;                                                                                                         //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                            clsPhamouvementstockreglementTemp.MONTANTFACTURE = 0;
                            clsPhamouvementstockreglementTemp.MONTANTREMISE = 0;
                            clsPhamouvementstockreglementTemp.MONTANTTVA = 0;
                            clsPhamouvementstockreglementTemp.MONTANTAIRSI = 0;
                            clsPhamouvementstockreglementTemp.MONTANTVERSEMENT = double.Parse(row["DT_TOTALFACTURE"].ToString());// DT_TOTALFACTURE double.Parse(clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                            clsPhamouvementstockreglementTemp.MONTANTTRANSPORT = 0;
                            clsPhamouvementstockreglementTemp.MONTANTFACTURETTC = double.Parse(row["DT_TOTALFACTURE"].ToString());// double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                            clsPhamouvementstockreglementTemp.RESTEMONTANTFACTURE = 0;
                            clsPhamouvementstockreglementTemp.MONTANTIMPAYER = 0;
                            clsPhamouvementstockreglementTemp.MS_UTILISERSUPLUS = "0";
                            clsPhamouvementstockreglementTemp.MV_REFERENCEPIECE = row["TI_NUMTIERS"].ToString();// clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                            clsPhamouvementstockreglementTemp.FB_IDFOURNISSEUR = "";// clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                            clsPhamouvementstockreglementTemp.TYPEOPERATION = "0";
                            //clsPhamouvementstockreglementTemp.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                            clsPhamouvementstockreglementTemp.MV_DATESAISIE = row["DT_DATEOPERATION"].ToString();// DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                            //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                            clsPhamouvementstockreglementTemp.MV_NUMPIECE = "0";
                            clsPhamouvementstockreglementTemp.JO_CODEJOURNAL = "6";// clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi = new Common.clsObjetEnvoi();
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;

                            HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse();
                            clsPhamouvementstockreglementTemp.clsCtcontratchequephotoreglementcaisses =new List<HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse>();
                            //clsPhamouvementstockreglementTemp.clsCtcontratchequephotoreglementcaisses.Add(clsCtcontratchequephotoreglementcaisse);
                            clsPhamouvementstockreglementTemp.clsPhamouvementstockreglementcheques=new List<HT_Stock.BOJ.clsPhamouvementstockreglementcheque>();
                            HT_Stock.BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new HT_Stock.BOJ.clsPhamouvementstockreglementcheque();
                            //clsPhamouvementstockreglementTemp.clsPhamouvementstockreglementcheques.Add(clsPhamouvementstockreglementcheque);

                            //          "clsCtcontratchequephotoreglementcaisses": [

                            //],
                            //  "clsPhamouvementstockreglementcheques": [

                            //  ]

                            ObjetTemp.Add(clsPhamouvementstockreglementTemp);
                            //==

                            clsDonnee = new clsDonnee();
                            clsPhamouvementstockreglementsTemp = pvgReglementClient(ObjetTemp);

                            if (clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_RESULTAT == "TRUE")
                            {
                                clsMiccomptewebResultat = clsPhamouvementstockreglementWSBLL.pvgCreationDetailFacture(clsDonnee, clsPhamouvementstockreglementBOJ.AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION, clsPhamouvementstockreglementBOJ.DT_NUMEROFACTURE, clsPhamouvementstockreglementBOJ.DT_REFERENCE, clsPhamouvementstockreglementBOJ.DT_DESIGNATION, clsPhamouvementstockreglementBOJ.DT_QUANTITE, clsPhamouvementstockreglementBOJ.DT_PU, clsPhamouvementstockreglementBOJ.DT_TOTALARTICLE, clsPhamouvementstockreglementBOJ.DT_TOTALFACTURE, clsPhamouvementstockreglementBOJ.PY_CODESTATUT, clsPhamouvementstockreglementBOJ.TI_NUMTIERS, clsPhamouvementstockreglementBOJ.MR_CODEMODEREGLEMENT, clsPhamouvementstockreglementBOJ.DT_DATEVALIDATION, clsPhamouvementstockreglementBOJ.PI_CODEPIECE, clsPhamouvementstockreglementBOJ.MV_NOMTIERS, clsPhamouvementstockreglementBOJ.MV_NUMEROPIECE, clsPhamouvementstockreglementBOJ.SO_CODESOUSCRIPTION, TK_TOKEN, clsPhamouvementstockreglementBOJ.OP_CODEOPERATEUR, clsPhamouvementstockreglementBOJ.MS_NUMPIECE, clsPhamouvementstockreglementBOJ.MONTANTFACTURETTC.ToString(), clsPhamouvementstockreglementBOJ.TYPEOPERATION.ToString());
                            }
                            else
                            {
                                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement1 = new HT_Stock.BOJ.clsMiccomptewebResultat();
                                clsPhamouvementstockreglement1.clsObjetRetour = new Common.clsObjetRetour();

                                clsPhamouvementstockreglement1.SL_CODEMESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_CODEMESSAGE;
                                clsPhamouvementstockreglement1.SL_MESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_MESSAGE;
                                clsPhamouvementstockreglement1.SL_RESULTAT = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_RESULTAT;
                                clsPhamouvementstockreglement1.SL_NUMEROTRANSACTION = "";
                                clsPhamouvementstockreglement1.PV_CODEPOINTVENTE = "";
                                clsPhamouvementstockreglement1.CO_CODECOMPTE = "";
                                clsPhamouvementstockreglement1.OB_NOMOBJET = "";
                                clsPhamouvementstockreglement1.SL_RESULTATAPI = "";
                                clsPhamouvementstockreglement1.SL_MESSAGEAPI = "";
                                clsPhamouvementstockreglement1.SL_MESSAGECLIENT ="";
                                clsPhamouvementstockreglement1.CL_IDCLIENT ="";
                                //clsPhamouvementstockreglement1.clsReeditions = clsMiccomptewebResultat.clsReeditions;
                                clsPhamouvementstockreglement1.TK_TOKEN = "";

                                clsPhamouvementstockreglement1.clsObjetRetour.SL_CODEMESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_CODEMESSAGE;
                                clsPhamouvementstockreglement1.clsObjetRetour.SL_RESULTAT = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_RESULTAT;
                                clsPhamouvementstockreglement1.clsObjetRetour.SL_MESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_MESSAGE;
                                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement1);

                                return clsPhamouvementstockreglements;
                            }

                        }

                        
                    }
                    //clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques, clsCtcontratchequereglementcaisse, clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                //if (clsMiccomptewebResultat.SL_RESULTAT=="TRUE")
                //{
                    HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    if (vlpBordereau != "")
                    {
                        clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                        //
                        string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                        //clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                    }

                    clsPhamouvementstockreglement.SL_TELEPHONE = clsMiccomptewebResultat.SL_TELEPHONE;
                    clsPhamouvementstockreglement.SL_INDICATIF = clsMiccomptewebResultat.SL_INDICATIF;
                    clsPhamouvementstockreglement.SL_MONTANTOPERATION = clsMiccomptewebResultat.SL_MONTANTOPERATION;
                    clsPhamouvementstockreglement.SL_URLNOTIFICATION = clsMiccomptewebResultat.SL_URLNOTIFICATION;

                    clsPhamouvementstockreglement.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                    clsPhamouvementstockreglement.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                    clsPhamouvementstockreglement.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                    clsPhamouvementstockreglement.SL_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                    clsPhamouvementstockreglement.PV_CODEPOINTVENTE = clsMiccomptewebResultat.PV_CODEPOINTVENTE;
                    clsPhamouvementstockreglement.CO_CODECOMPTE = clsMiccomptewebResultat.CO_CODECOMPTE;
                    clsPhamouvementstockreglement.OB_NOMOBJET = clsMiccomptewebResultat.OB_NOMOBJET;
                    clsPhamouvementstockreglement.SL_RESULTATAPI = clsMiccomptewebResultat.SL_RESULTATAPI;
                    clsPhamouvementstockreglement.SL_MESSAGEAPI = clsMiccomptewebResultat.SL_MESSAGEAPI;
                    clsPhamouvementstockreglement.SL_MESSAGECLIENT = clsMiccomptewebResultat.SL_MESSAGECLIENT;
                    clsPhamouvementstockreglement.CL_IDCLIENT = clsMiccomptewebResultat.CL_IDCLIENT;
                    //clsPhamouvementstockreglement.clsReeditions = clsMiccomptewebResultat.clsReeditions;
                    clsPhamouvementstockreglement.TK_TOKEN = clsMiccomptewebResultat.TK_TOKEN;

                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                //}
                //else
                //{
                //    HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                //}



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }




        public HT_Stock.BOJ.clsMiccomptewebResultat pvgCreationDetailFacture1( string AG_CODEAGENCE, string SL_NUMEROTRANSACTION, string SL_LIBELLEECRAN, string SL_LIBELLEMOUCHARD, string TO_VALIDEROPERATIONENCOURS, string TYPEOPERATION)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglement Objet = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsMobiledetailoperationtontine clsMobiledetailoperationtontine = new clsMobiledetailoperationtontine();

            Objet.AG_CODEAGENCE = AG_CODEAGENCE;
            Objet.SL_NUMEROTRANSACTION = SL_NUMEROTRANSACTION;
            Objet.TO_VALIDEROPERATIONENCOURS = TO_VALIDEROPERATIONENCOURS;
            Objet.SL_LIBELLEECRAN = SL_LIBELLEECRAN;
            Objet.SL_LIBELLEMOUCHARD = SL_LIBELLEMOUCHARD;
            Objet.TYPEOPERATION = TYPEOPERATION;

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMiccomptewebResultat> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            BOJ.clsMiccomptewebResultat clsMiccomptewebResultat = new BOJ.clsMiccomptewebResultat();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> ObjetTemp1 = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            ObjetTemp1.Add(Objet);
            for (int Idx = 0; Idx < ObjetTemp1.Count; Idx++)
            {

                if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
                    ObjetTemp1[Idx].MV_REFERENCEPIECE = "";
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireInsertMobile(ObjetTemp1[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements[0];
                ////--TEST CONTRAINTE
                //clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                ////--VERIFICATION DU RESULTAT DU TEST
                //if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in ObjetTemp1)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementBOJ = new Stock.BOJ.clsPhamouvementstockreglement();


                    if (string.IsNullOrEmpty(clsPhamouvementstockreglementDTO.TO_VALIDEROPERATIONENCOURS)) clsPhamouvementstockreglementDTO.TO_VALIDEROPERATIONENCOURS = "N";

                    clsPhamouvementstockreglementBOJ.DT_REFERENCE = ".";
                    clsPhamouvementstockreglementBOJ.DT_DESIGNATION = ".";
                    clsPhamouvementstockreglementBOJ.DT_QUANTITE = "1";
                    clsPhamouvementstockreglementBOJ.DT_PU = clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString();
                    clsPhamouvementstockreglementBOJ.DT_TOTALARTICLE = clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString();
                    clsPhamouvementstockreglementBOJ.DT_TOTALFACTURE = clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString();
                    clsPhamouvementstockreglementBOJ.PY_CODESTATUT = "01";
                    clsPhamouvementstockreglementBOJ.DT_DATEVALIDATION = "01/01/1900";
                    //string NO_CODENATUREVIREMENT = TE_CODESMSTYPEOPERATION;
                    clsPhamouvementstockreglementBOJ.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglementBOJ.MV_NUMEROPIECE = clsPhamouvementstockreglementDTO.MV_NUMEROPIECE;
                    clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION = clsPhamouvementstockreglementDTO.SL_NUMEROTRANSACTION.ToString();

                    //clsPhamouvementstockreglementBOJ.DT_NUMEROFACTURE = "";
                    clsPhamouvementstockreglementBOJ.TYPEOPERATION = int.Parse(clsPhamouvementstockreglementDTO.TYPEOPERATION.ToString());

                    if (clsPhamouvementstockreglementBOJ.TYPEOPERATION == 0)
                        clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION = System.Guid.NewGuid().ToString();



                    clsPhamouvementstockreglementBOJ.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                    clsPhamouvementstockreglementBOJ.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                    clsPhamouvementstockreglementBOJ.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                    clsPhamouvementstockreglementBOJ.PI_CODEPIECE = "";// clsPhamouvementstockreglementDTO.PI_CODEPIECE.ToString();
                    clsPhamouvementstockreglementBOJ.SO_CODESOUSCRIPTION = clsPhamouvementstockreglementDTO.SO_CODESOUSCRIPTION.ToString();
                    string TK_TOKEN = "";
                    clsPhamouvementstockreglementBOJ.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;
                    clsPhamouvementstockreglementBOJ.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// 
                    clsPhamouvementstockreglementBOJ.MONTANTFACTURETTC = double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// 





                    //clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO

                    //clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                    //clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    //clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    //clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString());// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                    //clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;


                    //clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                    //clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse(cpsDevTextBoxD11.Text).ToString();
                    //clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";

                    ////clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    ////clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    ////clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    //clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    //clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    //clsPhamouvementstockreglement.MONTANTTVA = 0;
                    //clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    //clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                    //clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    //clsPhamouvementstockreglement.MONTANTFACTURETTC = double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                    //clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    //clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    //clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    //clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                    //clsPhamouvementstockreglement.FB_IDFOURNISSEUR = clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                    //clsPhamouvementstockreglement.TYPEOPERATION = 1;

                    //vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    //vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    ////MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    //clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    //clsPhamouvementstockreglement.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT); ;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());


                    //clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    //clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;


                    //clsHttoken clsHttoken = new clsHttoken();
                    //clsHttoken = clsPhamouvementstockreglementWSBLL.pvgDemandeToken(clsDonnee, AG_CODEAGENCE, TK_TOKEN, TK_CODETYPEOPERATION, EJ_IDEPARGNANTJOURNALIER, "0");


                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new BOJ.clsCtcontratchequereglementcaisse();

                    clsMiccomptewebResultat = new BOJ.clsMiccomptewebResultat();
                    if (clsPhamouvementstockreglementDTO.TO_VALIDEROPERATIONENCOURS != "O")
                        clsMiccomptewebResultat = clsPhamouvementstockreglementWSBLL.pvgCreationDetailFacture(clsDonnee, clsPhamouvementstockreglementBOJ.AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION, clsPhamouvementstockreglementBOJ.DT_NUMEROFACTURE, clsPhamouvementstockreglementBOJ.DT_REFERENCE, clsPhamouvementstockreglementBOJ.DT_DESIGNATION, clsPhamouvementstockreglementBOJ.DT_QUANTITE, clsPhamouvementstockreglementBOJ.DT_PU, clsPhamouvementstockreglementBOJ.DT_TOTALARTICLE, clsPhamouvementstockreglementBOJ.DT_TOTALFACTURE, clsPhamouvementstockreglementBOJ.PY_CODESTATUT, clsPhamouvementstockreglementBOJ.TI_NUMTIERS, clsPhamouvementstockreglementBOJ.MR_CODEMODEREGLEMENT, clsPhamouvementstockreglementBOJ.DT_DATEVALIDATION, clsPhamouvementstockreglementBOJ.PI_CODEPIECE, clsPhamouvementstockreglementBOJ.MV_NOMTIERS, clsPhamouvementstockreglementBOJ.MV_NUMEROPIECE, clsPhamouvementstockreglementBOJ.SO_CODESOUSCRIPTION, TK_TOKEN, clsPhamouvementstockreglementBOJ.OP_CODEOPERATEUR, clsPhamouvementstockreglementBOJ.MS_NUMPIECE, clsPhamouvementstockreglementBOJ.MONTANTFACTURETTC.ToString(), clsPhamouvementstockreglementBOJ.TYPEOPERATION.ToString());
                    else//==Validation Opération MobileMoney
                    {
                        List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglementsTemp = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                        List<HT_Stock.BOJ.clsPhamouvementstockreglement> ObjetTemp = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                        HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementTemp = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                        DataSet DataSet = new DataSet();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementstockreglementBOJ.AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION };
                        DataSet = clsPhamouvementstockreglementWSBLL.pvgChargerDansDataSetMOBILEDETAILOPERATION(clsDonnee, clsObjetEnvoi);
                        if (DataSet.Tables[0].Rows.Count == 0)
                        {
                            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                            HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglementTEMP1 = new HT_Stock.BOJ.clsMiccomptewebResultat();
                            clsPhamouvementstockreglementTEMP1.clsObjetRetour = new Common.clsObjetRetour();

                            clsMiccomptewebResultat.SL_CODEMESSAGE = "00";
                            clsMiccomptewebResultat.SL_RESULTAT = "FALSE";
                            clsMiccomptewebResultat.SL_MESSAGE = "L'opération à déjà été validée !!!";
                            clsPhamouvementstockreglementTEMP1.SL_TELEPHONE = clsMiccomptewebResultat.SL_TELEPHONE;
                            clsPhamouvementstockreglementTEMP1.SL_INDICATIF = clsMiccomptewebResultat.SL_INDICATIF;
                            clsPhamouvementstockreglementTEMP1.SL_MONTANTOPERATION = clsMiccomptewebResultat.SL_MONTANTOPERATION;
                            clsPhamouvementstockreglementTEMP1.SL_URLNOTIFICATION = clsMiccomptewebResultat.SL_URLNOTIFICATION;

                            clsPhamouvementstockreglementTEMP1.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                            clsPhamouvementstockreglementTEMP1.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                            clsPhamouvementstockreglementTEMP1.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                            clsPhamouvementstockreglementTEMP1.SL_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                            clsPhamouvementstockreglementTEMP1.PV_CODEPOINTVENTE = clsMiccomptewebResultat.PV_CODEPOINTVENTE;
                            clsPhamouvementstockreglementTEMP1.CO_CODECOMPTE = clsMiccomptewebResultat.CO_CODECOMPTE;
                            clsPhamouvementstockreglementTEMP1.OB_NOMOBJET = clsMiccomptewebResultat.OB_NOMOBJET;
                            clsPhamouvementstockreglementTEMP1.SL_RESULTATAPI = clsMiccomptewebResultat.SL_RESULTATAPI;
                            clsPhamouvementstockreglementTEMP1.SL_MESSAGEAPI = clsMiccomptewebResultat.SL_MESSAGEAPI;
                            clsPhamouvementstockreglementTEMP1.SL_MESSAGECLIENT = clsMiccomptewebResultat.SL_MESSAGECLIENT;
                            clsPhamouvementstockreglementTEMP1.CL_IDCLIENT = clsMiccomptewebResultat.CL_IDCLIENT;
                            //clsPhamouvementstockreglement.clsReeditions = clsMiccomptewebResultat.clsReeditions;
                            clsPhamouvementstockreglementTEMP1.TK_TOKEN = clsMiccomptewebResultat.TK_TOKEN;

                            clsPhamouvementstockreglementTEMP1.clsObjetRetour.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                            clsPhamouvementstockreglementTEMP1.clsObjetRetour.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                            clsPhamouvementstockreglementTEMP1.clsObjetRetour.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;


                            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglementTEMP1);
                            return clsPhamouvementstockreglements[0];
                        }

                        //==
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {

                            //AG_CODEAGENCE,EN_CODEENTREPOT,DT_DATEOPERATION,DT_NUMSEQUENCE,DT_NUMEROTRANSACTION,DT_REFERENCE, DT_DESIGNATION, DT_QUANTITE,DT_PU,DT_TOTALARTICLE, DT_TOTALFACTURE,DT_DATESAISIE,TI_IDTIERS,PY_CODESTATUT,MS_NUMPIECE,DT_DATEVALIDATION,PI_CODEPIECE,DT_NOMTIERS,DT_NUMPIECETIERS, CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "', TI_NUMTIERS) AS varchar(150)) AS TI_NUMTIERS, OP_CODEOPERATEUR

                            clsPhamouvementstockreglementTemp.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                            clsPhamouvementstockreglementTemp.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsDeclaration.vagAgence.AG_CODEAGENCE;
                            clsPhamouvementstockreglementTemp.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();// clsPhamouvementstockreglementDTO.EN_CODEENTREPOT.ToString();// clsDeclaration.vagOperateur.EN_CODEENTREPOT;
                            clsPhamouvementstockreglementTemp.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();// clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();// MS_NUMPIECE;
                            clsPhamouvementstockreglementTemp.MV_ANNULATIONPIECE = "N";
                            clsPhamouvementstockreglementTemp.MV_DATEPIECE = row["DT_DATEOPERATION"].ToString();// clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString();// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                            clsPhamouvementstockreglementTemp.MV_DATESAISIE = row["DT_DATEOPERATION"].ToString();// clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString();// Stock.TOOLS.clsDeclaration.vagObjetEnvoi.JT_DATEJOURNEETRAVAIL;
                            clsPhamouvementstockreglementTemp.MV_NOMTIERS = row["TI_DENOMINATION"].ToString();// clsPhamouvementstockreglementDTO.MV_NOMTIERS.ToString();// cpsDevTextBoxT3.Text;
                            clsPhamouvementstockreglementTemp.MR_CODEMODEREGLEMENT = "01";// clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT.ToString();// cpsDevComboBox5.GetValue();
                            clsPhamouvementstockreglementTemp.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();// clsPhamouvementstockreglementDTO.TI_NUMTIERS.ToString();// cpsDevTextBoxDC1.Text;
                            clsPhamouvementstockreglementTemp.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();// clsPhamouvementstockreglementDTO.PL_NUMCOMPTE.ToString();// vlpNumeroCompte;
                            clsPhamouvementstockreglementTemp.PL_NUMCOMPTEBANQUE = "0";// double.Parse(cpsDevTextBoxD11.Text).ToString();
                            clsPhamouvementstockreglementTemp.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° :";// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// "REGLEMENT ASSUREUR SFACTURE N° : ";
                            clsPhamouvementstockreglementTemp.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();// clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR.ToString();// Stock.TOOLS.clsDeclaration.vagOperateur.OP_CODEOPERATEUR;                                                                                                         //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                            clsPhamouvementstockreglementTemp.MONTANTFACTURE = 0;
                            clsPhamouvementstockreglementTemp.MONTANTREMISE = 0;
                            clsPhamouvementstockreglementTemp.MONTANTTVA = 0;
                            clsPhamouvementstockreglementTemp.MONTANTAIRSI = 0;
                            clsPhamouvementstockreglementTemp.MONTANTVERSEMENT = double.Parse(row["DT_TOTALFACTURE"].ToString());// DT_TOTALFACTURE double.Parse(clsPhamouvementstockreglementDTO.MONTANTVERSEMENT.ToString());// double.Parse(gridView1.GetDataRow(0)["SR_MONTANTCREDIT"].ToString());
                            clsPhamouvementstockreglementTemp.MONTANTTRANSPORT = 0;
                            clsPhamouvementstockreglementTemp.MONTANTFACTURETTC = double.Parse(row["DT_TOTALFACTURE"].ToString());// double.Parse(clsPhamouvementstockreglementDTO.MONTANTFACTURETTC.ToString());// double.Parse(gridView1.GetDataRow(0)["MONTANTAREGLERASSUREUR"].ToString());
                            clsPhamouvementstockreglementTemp.RESTEMONTANTFACTURE = 0;
                            clsPhamouvementstockreglementTemp.DT_NUMEROTRANSACTION = SL_NUMEROTRANSACTION;// clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION;

                            clsPhamouvementstockreglementTemp.MONTANTIMPAYER = 0;
                            clsPhamouvementstockreglementTemp.MS_UTILISERSUPLUS = "0";
                            clsPhamouvementstockreglementTemp.MV_REFERENCEPIECE = row["TI_NUMTIERS"].ToString();// clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE.ToString();// cpsDevTextBoxT5.Text;
                            clsPhamouvementstockreglementTemp.FB_IDFOURNISSEUR = "";// clsPhamouvementstockreglementDTO.FB_IDFOURNISSEUR.ToString();// TI_IDTIERSASSUREUR;
                            clsPhamouvementstockreglementTemp.TYPEOPERATION = "0";
                            //clsPhamouvementstockreglementTemp.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                            clsPhamouvementstockreglementTemp.MV_DATESAISIE = row["DT_DATEOPERATION"].ToString();// DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                            //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                            clsPhamouvementstockreglementTemp.MV_NUMPIECE = "0";
                            clsPhamouvementstockreglementTemp.JO_CODEJOURNAL = "6";// clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;// clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi = new Common.clsObjetEnvoi();
                            //clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                            //clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;

                            HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse();
                            clsPhamouvementstockreglementTemp.clsCtcontratchequephotoreglementcaisses = new List<HT_Stock.BOJ.clsCtcontratchequephotoreglementcaisse>();
                            //clsPhamouvementstockreglementTemp.clsCtcontratchequephotoreglementcaisses.Add(clsCtcontratchequephotoreglementcaisse);
                            clsPhamouvementstockreglementTemp.clsPhamouvementstockreglementcheques = new List<HT_Stock.BOJ.clsPhamouvementstockreglementcheque>();
                            HT_Stock.BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new HT_Stock.BOJ.clsPhamouvementstockreglementcheque();
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi = new Common.clsObjetEnvoi();
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_A = clsPhamouvementstockreglementTemp.AG_CODEAGENCE;
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementTemp.OP_CODEOPERATEUR;
                            clsPhamouvementstockreglementTemp.clsObjetEnvoi.OE_J = clsPhamouvementstockreglementTemp.MV_DATEPIECE;
                            //clsPhamouvementstockreglementTemp.clsPhamouvementstockreglementcheques.Add(clsPhamouvementstockreglementcheque);

                            //          "clsCtcontratchequephotoreglementcaisses": [

                            //],
                            //  "clsPhamouvementstockreglementcheques": [

                            //  ]

                            ObjetTemp.Add(clsPhamouvementstockreglementTemp);
                            //==

                            clsDonnee = new clsDonnee();
                            clsPhamouvementstockreglementsTemp = pvgReglementClient(ObjetTemp);
                            clsDonnee = new clsDonnee();
                            if (clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_RESULTAT == "TRUE")
                            {

                                
                                clsMobiledetailoperationtontine.AG_CODEAGENCE = AG_CODEAGENCE;
                                clsMobiledetailoperationtontine.DT_DATEVALIDATION = clsPhamouvementstockreglementTemp.MV_DATEPIECE;
                                string[] vppCritere = new string[] { AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION };
                                //
                                //clsPhamouvementstockreglementWSBLL.pvgUpdateStatutOperation(clsDonnee, clsMobiledetailoperationtontine, vppCritere);

                               // clsMiccomptewebResultat = clsPhamouvementstockreglementWSBLL.pvgCreationDetailFacture(clsDonnee, clsPhamouvementstockreglementBOJ.AG_CODEAGENCE, clsPhamouvementstockreglementBOJ.DT_NUMEROTRANSACTION, clsPhamouvementstockreglementBOJ.DT_NUMEROFACTURE, clsPhamouvementstockreglementBOJ.DT_REFERENCE, clsPhamouvementstockreglementBOJ.DT_DESIGNATION, clsPhamouvementstockreglementBOJ.DT_QUANTITE, clsPhamouvementstockreglementBOJ.DT_PU, clsPhamouvementstockreglementBOJ.DT_TOTALARTICLE, clsPhamouvementstockreglementBOJ.DT_TOTALFACTURE, clsPhamouvementstockreglementBOJ.PY_CODESTATUT, clsPhamouvementstockreglementBOJ.TI_NUMTIERS, clsPhamouvementstockreglementBOJ.MR_CODEMODEREGLEMENT, clsPhamouvementstockreglementBOJ.DT_DATEVALIDATION, clsPhamouvementstockreglementBOJ.PI_CODEPIECE, clsPhamouvementstockreglementBOJ.MV_NOMTIERS, clsPhamouvementstockreglementBOJ.MV_NUMEROPIECE, clsPhamouvementstockreglementBOJ.SO_CODESOUSCRIPTION, TK_TOKEN, clsPhamouvementstockreglementBOJ.OP_CODEOPERATEUR, clsPhamouvementstockreglementBOJ.MS_NUMPIECE, clsPhamouvementstockreglementBOJ.MONTANTFACTURETTC.ToString(), clsPhamouvementstockreglementBOJ.TYPEOPERATION.ToString());

                               

                                //clsResultatOperation1.clsReeditions = clsResultatOperationListe[0].clsReeditions;

                            }
                            else
                            {
                                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement1 = new HT_Stock.BOJ.clsMiccomptewebResultat();
                                clsPhamouvementstockreglement1.clsObjetRetour = new Common.clsObjetRetour();

                                clsPhamouvementstockreglement1.SL_CODEMESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_CODEMESSAGE;
                                clsPhamouvementstockreglement1.SL_MESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_MESSAGE;
                                clsPhamouvementstockreglement1.SL_RESULTAT = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_RESULTAT;
                                clsPhamouvementstockreglement1.SL_NUMEROTRANSACTION = "";
                                clsPhamouvementstockreglement1.PV_CODEPOINTVENTE = "";
                                clsPhamouvementstockreglement1.CO_CODECOMPTE = "";
                                clsPhamouvementstockreglement1.OB_NOMOBJET = "";
                                clsPhamouvementstockreglement1.SL_RESULTATAPI = "";
                                clsPhamouvementstockreglement1.SL_MESSAGEAPI = "";
                                clsPhamouvementstockreglement1.SL_MESSAGECLIENT = "";
                                clsPhamouvementstockreglement1.CL_IDCLIENT = "";
                                //clsPhamouvementstockreglement1.clsReeditions = clsMiccomptewebResultat.clsReeditions;
                                clsPhamouvementstockreglement1.TK_TOKEN = "";

                                clsPhamouvementstockreglement1.clsObjetRetour.SL_CODEMESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_CODEMESSAGE;
                                clsPhamouvementstockreglement1.clsObjetRetour.SL_RESULTAT = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_RESULTAT;
                                clsPhamouvementstockreglement1.clsObjetRetour.SL_MESSAGE = clsPhamouvementstockreglementsTemp[0].clsObjetRetour.SL_MESSAGE;
                                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement1);

                                return clsPhamouvementstockreglements[0];
                            }

                        }


                    }
                    //clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques, clsCtcontratchequereglementcaisse, clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                //if (clsMiccomptewebResultat.SL_RESULTAT=="TRUE")
                //{
                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                string vlpBordereau = "";
                vlpBordereau = clsObjetRetour.OR_STRING;
                if (vlpBordereau != "")
                {
                    clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                    //
                    string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                    //clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                }

                clsPhamouvementstockreglement.SL_TELEPHONE = clsMiccomptewebResultat.SL_TELEPHONE;
                clsPhamouvementstockreglement.SL_INDICATIF = clsMiccomptewebResultat.SL_INDICATIF;
                clsPhamouvementstockreglement.SL_MONTANTOPERATION = clsMiccomptewebResultat.SL_MONTANTOPERATION;
                clsPhamouvementstockreglement.SL_URLNOTIFICATION = clsMiccomptewebResultat.SL_URLNOTIFICATION;

                clsPhamouvementstockreglement.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                clsPhamouvementstockreglement.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                clsPhamouvementstockreglement.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                clsPhamouvementstockreglement.SL_NUMEROTRANSACTION = clsMiccomptewebResultat.SL_NUMEROTRANSACTION;
                clsPhamouvementstockreglement.PV_CODEPOINTVENTE = clsMiccomptewebResultat.PV_CODEPOINTVENTE;
                clsPhamouvementstockreglement.CO_CODECOMPTE = clsMiccomptewebResultat.CO_CODECOMPTE;
                clsPhamouvementstockreglement.OB_NOMOBJET = clsMiccomptewebResultat.OB_NOMOBJET;
                clsPhamouvementstockreglement.SL_RESULTATAPI = clsMiccomptewebResultat.SL_RESULTATAPI;
                clsPhamouvementstockreglement.SL_MESSAGEAPI = clsMiccomptewebResultat.SL_MESSAGEAPI;
                clsPhamouvementstockreglement.SL_MESSAGECLIENT = clsMiccomptewebResultat.SL_MESSAGECLIENT;
                clsPhamouvementstockreglement.CL_IDCLIENT = clsMiccomptewebResultat.CL_IDCLIENT;
                //clsPhamouvementstockreglement.clsReeditions = clsMiccomptewebResultat.clsReeditions;
                clsPhamouvementstockreglement.TK_TOKEN = clsMiccomptewebResultat.TK_TOKEN;

                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMiccomptewebResultat.SL_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = clsMiccomptewebResultat.SL_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMiccomptewebResultat.SL_MESSAGE;
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                //}
                //else
                //{
                //    HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                //}



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements[0];
        }









        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementCommercial(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            List<Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglementss = new List<Stock.BOJ.clsPhamouvementstockreglement>();
            List<Stock.BOJ.clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials= new List<Stock.BOJ.clsPhamouvementstockreglementcommercial>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {

                if (string.IsNullOrEmpty(Objet[Idx].MV_REFERENCEPIECE))
                    Objet[Idx].MV_REFERENCEPIECE = "";
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireReglementCommissionCommerciale(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();


                



                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();


                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.MS_NUMPIECE = "0";
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE =DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;
                    clsPhamouvementstockreglement.TI_NUMTIERS = "";
                    if (double.Parse(clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE).ToString() == "0")
                    {
                        clsOperateurWSBLL clsOperateurWSBLL = new clsOperateurWSBLL();
                        BOJ.clsOperateur clsOperateur = new BOJ.clsOperateur();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementstockreglementDTO.AG_CODEAGENCE, clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR};
                        clsOperateur=clsOperateurWSBLL.pvgTableLabel1(clsDonnee, clsObjetEnvoi);
                        clsPhamouvementstockreglement.PL_NUMCOMPTE = clsOperateur.PL_NUMCOMPTE;
                    }

                    else
                        clsPhamouvementstockreglement.PL_NUMCOMPTE = double.Parse(clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE).ToString();

                    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = double.Parse(clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE).ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT " + clsPhamouvementstockreglementDTO.MC_LIBELLEOPERATION.ToString() + " RECU PAR : " + clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    clsPhamouvementstockreglement.MV_MONTANTDEBIT = clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT;
                    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURETTC = 0;
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE;
                    //clsPhamouvementstockreglement.FB_IDFOURNISSEUR = ;
                    //clsPhamouvementstockreglement.TYPEOPERATION = 1;

                    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    clsPhamouvementstockreglement.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT); ;// clsPhamouvementstockreglementDTO.JO_CODEJOURNAL;

                    vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE.ToString();
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE.ToString()).ToShortDateString();

                    clsPhamouvementstockreglementss.Add(clsPhamouvementstockreglement);



                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement1 = new Stock.BOJ.clsPhamouvementstockreglement();

                    clsPhamouvementstockreglement1.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                    clsPhamouvementstockreglement1.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    clsPhamouvementstockreglement1.MS_NUMPIECE = "0";
                    clsPhamouvementstockreglement1.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement1.MV_DATEPIECE =DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement1.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement1.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglement1.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;
                    clsPhamouvementstockreglement1.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS;
                    clsPhamouvementstockreglement1.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE; //Stock.TOOLS.clsDeclaration.vagParametreGlobal.PP_CPTECPCO;
                    clsPhamouvementstockreglement1.PL_NUMCOMPTEBANQUE = double.Parse(clsPhamouvementstockreglementDTO.PL_NUMCOMPTEBANQUE).ToString();
                    clsPhamouvementstockreglement1.MV_LIBELLEOPERATION = "REGLEMENT " + clsPhamouvementstockreglementDTO.MC_LIBELLEOPERATION.ToString() + " RECU PAR : " + clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglement1.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR;
                    clsPhamouvementstockreglement1.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT;
                    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    clsPhamouvementstockreglement1.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement1.MONTANTREMISE = 0;
                    clsPhamouvementstockreglement1.MONTANTTVA = 0;
                    clsPhamouvementstockreglement1.MONTANTAIRSI = 0;
                    clsPhamouvementstockreglement1.MV_MONTANTCREDIT = clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT;
                    clsPhamouvementstockreglement1.MONTANTTRANSPORT = 0;
                    clsPhamouvementstockreglement1.MONTANTFACTURETTC = 0;
                    clsPhamouvementstockreglement1.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement1.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement1.MS_UTILISERSUPLUS = 0;
                    clsPhamouvementstockreglement1.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE;
                    //clsPhamouvementstockreglement.FB_IDFOURNISSEUR = ;
                    //clsPhamouvementstockreglement1.TYPEOPERATION = 1;

                    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    clsPhamouvementstockreglement1.MV_NUMPIECE = "0";
                    clsPhamouvementstockreglement1.JO_CODEJOURNAL = clsChaineCaractere.ClasseChaineCaractere.pvgCodeJournal(clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT);// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal(cpsDevComboBox5.GetValue());

                    clsPhamouvementstockreglementss.Add(clsPhamouvementstockreglement1);

                    BOJ.clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial = new BOJ.clsPhamouvementstockreglementcommercial();
                    clsPhamouvementstockreglementcommercial.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL = clsPhamouvementstockreglementDTO.TI_IDTIERS;
                    clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT = 0;
                    clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT = clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT;
                    clsPhamouvementstockreglementcommercial.MC_NUMPIECE = "";
                    clsPhamouvementstockreglementcommercial.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE.ToString();
                    clsPhamouvementstockreglementcommercial.MC_DATEPIECE =DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION = "REGLEMENT " + clsPhamouvementstockreglementDTO.MC_LIBELLEOPERATION.ToString() + " RECU PAR : " + clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglementcommercial.MC_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE = 0;
                    clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE = 0;
                    clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE = "";
                    clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION = "00001";
                    clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR;

                    clsPhamouvementstockreglementcommercials.Add(clsPhamouvementstockreglementcommercial);


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques= new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse=new BOJ.clsCtcontratchequereglementcaisse();
                    List<Stock.BOJ.clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses=new List<BOJ.clsCtcontratchequephotoreglementcaisse>();
                    // List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisationReglementCommissionCommercial(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementcheques, clsPhamouvementstockreglementcommercials, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                    //
                    string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouterListeChargeAvecRepartition(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            List<Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglementss = new List<Stock.BOJ.clsPhamouvementstockreglement>();
            List<Stock.BOJ.clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions = new List<BOJ.clsPhamouvementstockreglementrepartition>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireReglementOD(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();


                    //clsPhamouvementstockreglement clsPhamouvementstockreglement = new clsPhamouvementstockreglement();

                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT;
                    clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE != "" ? clsPhamouvementstockreglementDTO.MS_NUMPIECE : "0";
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE =DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement.MV_DATESAISIE =DateTime.Parse( clsPhamouvementstockreglementDTO.MV_DATESAISIE); 
                    clsPhamouvementstockreglement.MV_MONTANTCREDIT = clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT;
                    clsPhamouvementstockreglement.MV_MONTANTDEBIT = clsPhamouvementstockreglementDTO.MV_MONTANTDEBIT;
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT = 0;
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = clsPhamouvementstockreglementDTO.MV_LIBELLEOPERATION;
                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;
                    clsPhamouvementstockreglement.MV_NUMPIECE = "0";

                    vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE).ToShortDateString();
                    ////
                    //vlpSaisieAnalytique = clsPhamouvementstockreglementDTO.SAISIEANALYTIQUE;
                    ////
                    //if (vlpSaisieAnalytique != "")
                    //    clsPhamouvementstockreglement.MOUVEMENTCOMPTABLEANALYTIQUE = pvpRecuperationParametreObjet(vlpSaisieAnalytique).ToArray();

                    ////

                    if (clsPhamouvementstockreglementDTO.NC_CODENATURECOMPTE != "")
                    {
                        clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE2;
                        clsPhamouvementstockreglement.FR_MATRICULE = "";
                        clsPhamouvementstockreglement.TI_IDTIERS = "";
                    }

                    
                    else
                    {
                        clsPhamouvementstockreglement.CL_NUMCLIENT = "";
                        clsPhamouvementstockreglement.FR_MATRICULE = "";
                        clsPhamouvementstockreglement.TI_IDTIERS = "";
                    }
                    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE;
                    clsPhamouvementstockreglement.JO_CODEJOURNAL = int.Parse(clsPhamouvementstockreglementDTO.JO_CODEJOURNAL);
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00038";
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR;
                    clsPhamouvementstockreglementss.Add(clsPhamouvementstockreglement);


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques= new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse=new BOJ.clsCtcontratchequereglementcaisse();
                 
                    // List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials
                 
                    //clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterListeChargeAvecRepartition(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementcheques, clsPhamouvementstockreglementcommercials, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }






                clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterListeChargeAvecRepartition(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementrepartitions, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                    //
                    string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }








        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouterListeChargeAvecRepartitionReglementTresorerieTiers(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            List<Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglementss = new List<Stock.BOJ.clsPhamouvementstockreglement>();
            List<Stock.BOJ.clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions = new List<BOJ.clsPhamouvementstockreglementrepartition>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireReglementTresorerieTiers(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();


                    //clsPhamouvementstockreglement clsPhamouvementstockreglement = new clsPhamouvementstockreglement();

                    clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT;
                    clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE != "" ? clsPhamouvementstockreglementDTO.MS_NUMPIECE : "0";
                    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                    clsPhamouvementstockreglement.MV_MONTANTCREDIT = clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT;
                    clsPhamouvementstockreglement.MV_MONTANTDEBIT = clsPhamouvementstockreglementDTO.MV_MONTANTDEBIT;
                    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT = 0;
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = clsPhamouvementstockreglementDTO.MV_LIBELLEOPERATION;
                    clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE;
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;
                    clsPhamouvementstockreglement.FR_MATRICULE = clsPhamouvementstockreglementDTO.FR_MATRICULE;
                    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS;
                    clsPhamouvementstockreglement.MV_NUMPIECE = "0";

                    vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                    vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE).ToShortDateString();
                    ////
                    //vlpSaisieAnalytique = clsPhamouvementstockreglementDTO.SAISIEANALYTIQUE;
                    ////
                    //if (vlpSaisieAnalytique != "")
                    //    clsPhamouvementstockreglement.MOUVEMENTCOMPTABLEANALYTIQUE = pvpRecuperationParametreObjet(vlpSaisieAnalytique).ToArray();

                    ////

                    //if (clsPhamouvementstockreglementDTO.NC_CODENATURECOMPTE != "")
                    //{
                    //    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE2;
                    //    clsPhamouvementstockreglement.FR_MATRICULE = "";
                    //    clsPhamouvementstockreglement.TI_IDTIERS = "";
                    //}


                    //else
                    //{
                    //    clsPhamouvementstockreglement.CL_NUMCLIENT = "";
                    //    clsPhamouvementstockreglement.FR_MATRICULE = "";
                    //    clsPhamouvementstockreglement.TI_IDTIERS = "";
                    //}
                    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE;
                    clsPhamouvementstockreglement.JO_CODEJOURNAL = int.Parse(clsPhamouvementstockreglementDTO.JO_CODEJOURNAL);
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION =clsPhamouvementstockreglementDTO.NO_CODENATUREOPERATION; 
                    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR;
                    clsPhamouvementstockreglementss.Add(clsPhamouvementstockreglement);


                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new BOJ.clsCtcontratchequereglementcaisse();

                    // List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials

                    //clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterListeChargeAvecRepartition(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementcheques, clsPhamouvementstockreglementcommercials, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }


                clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterListeChargeAvecRepartition(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementrepartitions, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                    string vlpBordereau = "";
                    vlpBordereau = clsObjetRetour.OR_STRING;
                    clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                    //
                    string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }
            public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouterListeChargeAvecRepartitionReglementTresorerieCaisse(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
            {
                List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
                List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                List<Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglementss = new List<Stock.BOJ.clsPhamouvementstockreglement>();
                List<Stock.BOJ.clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions = new List<BOJ.clsPhamouvementstockreglementrepartition>();
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

                for (int Idx = 0; Idx < Objet.Count; Idx++)
                {
                    //--TEST DES CHAMPS OBLIGATOIRES
                    clsPhamouvementstockreglements = TestChampObligatoireReglementTresorerieCaisse(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                    //--TEST CONTRAINTE
                    clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                    //--VERIFICATION DU RESULTAT DU TEST
                    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                }
                //clsObjetEnvoi.OE_PARAM = new string[] {};
                HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
                try
                {
                    clsDonnee.pvgConnectionBase();

                    foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                    {
                        Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();


                        //clsPhamouvementstockreglement clsPhamouvementstockreglement = new clsPhamouvementstockreglement();

                        clsPhamouvementstockreglement.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                        clsPhamouvementstockreglement.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.EN_CODEENTREPOT;
                        clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstockreglementDTO.MS_NUMPIECE != "" ? clsPhamouvementstockreglementDTO.MS_NUMPIECE : "0";
                        clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                        clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                        clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE);
                        clsPhamouvementstockreglement.MV_MONTANTCREDIT = clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT;
                        clsPhamouvementstockreglement.MV_MONTANTDEBIT = clsPhamouvementstockreglementDTO.MV_MONTANTDEBIT;
                        clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                        clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                        clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                        clsPhamouvementstockreglement.MONTANTVERSEMENT = 0;
                        clsPhamouvementstockreglement.MV_LIBELLEOPERATION = clsPhamouvementstockreglementDTO.MV_LIBELLEOPERATION;
                        clsPhamouvementstockreglement.MV_NOMTIERS = clsPhamouvementstockreglementDTO.MV_NOMTIERS;
                        clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementDTO.MV_REFERENCEPIECE;
                        clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementDTO.MR_CODEMODEREGLEMENT;
                        clsPhamouvementstockreglement.FR_MATRICULE = clsPhamouvementstockreglementDTO.FR_MATRICULE;
                        clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.TI_NUMTIERS;
                        clsPhamouvementstockreglement.MV_NUMPIECE = "0";

                        vlpAG_CODEAGENCE = clsPhamouvementstockreglementDTO.AG_CODEAGENCE;
                        vlpMV_DATESAISIE = DateTime.Parse(clsPhamouvementstockreglementDTO.MV_DATESAISIE).ToShortDateString();
                        ////
                        //vlpSaisieAnalytique = clsPhamouvementstockreglementDTO.SAISIEANALYTIQUE;
                        ////
                        //if (vlpSaisieAnalytique != "")
                        //    clsPhamouvementstockreglement.MOUVEMENTCOMPTABLEANALYTIQUE = pvpRecuperationParametreObjet(vlpSaisieAnalytique).ToArray();

                        ////

                        //if (clsPhamouvementstockreglementDTO.NC_CODENATURECOMPTE != "")
                        //{
                        //    clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE2;
                        //    clsPhamouvementstockreglement.FR_MATRICULE = "";
                        //    clsPhamouvementstockreglement.TI_IDTIERS = "";
                        //}


                        //else
                        //{
                        //    clsPhamouvementstockreglement.CL_NUMCLIENT = "";
                        //    clsPhamouvementstockreglement.FR_MATRICULE = "";
                        //    clsPhamouvementstockreglement.TI_IDTIERS = "";
                        //}
                        clsPhamouvementstockreglement.PL_NUMCOMPTE = clsPhamouvementstockreglementDTO.PL_NUMCOMPTE;
                        clsPhamouvementstockreglement.JO_CODEJOURNAL = int.Parse(clsPhamouvementstockreglementDTO.JO_CODEJOURNAL);
                        clsPhamouvementstockreglement.NO_CODENATUREOPERATION = clsPhamouvementstockreglementDTO.NO_CODENATUREOPERATION;
                        clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsPhamouvementstockreglementDTO.OP_CODEOPERATEUR;
                        clsPhamouvementstockreglementss.Add(clsPhamouvementstockreglement);


                        clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                        clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                        List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                        Stock.BOJ.clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new BOJ.clsCtcontratchequereglementcaisse();

                        // List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials

                        //clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterListeChargeAvecRepartition(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementcheques, clsPhamouvementstockreglementcommercials, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                    }


                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgAjouterListeChargeAvecRepartition(clsDonnee, clsPhamouvementstockreglementss, clsPhamouvementstockreglementrepartitions, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                        string vlpBordereau = "";
                        vlpBordereau = clsObjetRetour.OR_STRING;
                        clsObjetEnvoi.OE_PARAM = new string[] { vlpAG_CODEAGENCE, DateTime.Parse(vlpMV_DATESAISIE.ToString()).ToShortDateString(), vlpBordereau };
                        //
                        string vlpNumero = clsPhamouvementstockreglementWSBLL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi);
                        clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhamouvementstockreglement.NUMEROBORDEREAUREGLEMENT = vlpNumero;
                        clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    }
                    else
                    {
                        HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                        clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                        clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    }



                }
                catch (SqlException SQLEx)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                catch (Exception SQLEx)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }

                finally
                {
                    clsDonnee.pvgDeConnectionBase();
                }
                return clsPhamouvementstockreglements;
            }
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgModifier(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglementDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.MV_NUMPIECE = clsPhamouvementstockreglementDTO.MV_NUMPIECE.ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = clsPhamouvementstockreglementDTO.MV_LIBELLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementstockreglementDTO.MV_NUMPIECE };
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgModifier(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgSupprimer(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].MV_NUMPIECE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhamouvementstockreglementWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhamouvementstockreglements = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            //    //--TEST CONTRAINTE
            //    clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.MV_NUMPIECE = row["MV_NUMPIECE"].ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
            }
            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgMouvementResumeReglement(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhamouvementstockreglements = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            //    //--TEST CONTRAINTE
            //    clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].MS_NUMPIECE, Objet[0].TI_NUMTIERS, Objet[0].MV_DATESAISIE, Objet[0].TYPEOPERATION, Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementWSBLL.pvgMouvementResumeReglement(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                        //"MONTANTAREGLERASSUREUR", "SR_MONTANTCREDIT", "MONTANTREGLERASSUREUR", "RESTEAREGLERASSUREUR", "SR_MONTANTCREDIT"
                        //"MONTANTAREGLERCOMMISSION", "SR_MONTANTCREDIT", "MONTANTREGLERCOMMISSION", "RESTEAREGLERCOMMISSION", "SR_MONTANTCREDIT"

                    clsPhamouvementstockreglement.RESTEAREGLERCOMMISSION = (row["RESTEAREGLERCOMMISSION"].ToString() != "") ? double.Parse(row["RESTEAREGLERCOMMISSION"].ToString()) : 0;//  row["RESTEAREGLERCOMMISSION"].ToString();
                        clsPhamouvementstockreglement.MONTANTREGLERCOMMISSION = (row["MONTANTREGLERCOMMISSION"].ToString() != "") ? double.Parse(row["MONTANTREGLERCOMMISSION"].ToString()) : 0;// row["MONTANTREGLERCOMMISSION"].ToString();
                        clsPhamouvementstockreglement.MONTANTAREGLERCOMMISSION = (row["MONTANTAREGLERCOMMISSION"].ToString() != "") ? double.Parse(row["MONTANTAREGLERCOMMISSION"].ToString()) : 0;// row["MONTANTAREGLERCOMMISSION"].ToString();
                        clsPhamouvementstockreglement.SR_MONTANTCREDIT = (row["SR_MONTANTCREDIT"].ToString() != "") ? double.Parse(row["SR_MONTANTCREDIT"].ToString()) : 0;// row["SR_MONTANTCREDIT"].ToString();
                        clsPhamouvementstockreglement.RESTEAREGLERASSUREUR = (row["RESTEAREGLERASSUREUR"].ToString() != "") ? double.Parse(row["RESTEAREGLERASSUREUR"].ToString()) : 0;//  row["RESTEAREGLERASSUREUR"].ToString();
                        clsPhamouvementstockreglement.MONTANTREGLERASSUREUR = (row["MONTANTREGLERASSUREUR"].ToString() != "") ? double.Parse(row["MONTANTREGLERASSUREUR"].ToString()) : 0;//  row["MONTANTREGLERASSUREUR"].ToString();
                        clsPhamouvementstockreglement.MONTANTAREGLERASSUREUR = (row["MONTANTAREGLERASSUREUR"].ToString() != "") ? double.Parse(row["MONTANTAREGLERASSUREUR"].ToString()) : 0;// row["MONTANTAREGLERASSUREUR"].ToString();
                        clsPhamouvementstockreglement.MONTANTAREGLER = (row["MONTANTAREGLER"].ToString() != "") ? double.Parse(row["MONTANTAREGLER"].ToString()) : 0;//  row["MONTANTAREGLER"].ToString();
                        clsPhamouvementstockreglement.SR_MONTANTCREDIT = (row["SR_MONTANTCREDIT"].ToString() != "") ? double.Parse(row["SR_MONTANTCREDIT"].ToString()) : 0;// row["SR_MONTANTCREDIT"].ToString();
                        clsPhamouvementstockreglement.MONTANTREGLER = (row["MONTANTREGLER"].ToString() != "") ? double.Parse(row["MONTANTREGLER"].ToString()) : 0;// row["MONTANTREGLER"].ToString();
                        clsPhamouvementstockreglement.RESTEAREGLER = (row["RESTEAREGLER"].ToString() != "") ? double.Parse(row["RESTEAREGLER"].ToString()) : 0;// row["RESTEAREGLER"].ToString();
                        clsPhamouvementstockreglement.SR_MONTANTCREDIT = (row["SR_MONTANTCREDIT"].ToString() != "") ? double.Parse(row["SR_MONTANTCREDIT"].ToString()) : 0;// row["SR_MONTANTCREDIT"].ToString();



                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglements;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhamouvementstockreglements = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
        //    //--TEST CONTRAINTE
        //    clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.MV_NUMPIECE = row["MV_NUMPIECE"].ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockreglements;
    }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSetRecudeCaisse(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireRecu(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE,Objet[0].MV_NUMPIECE,Objet[0].MV_NUMBORDEREAU };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementWSBLL.pvgChargerDansDataSetRecudeCaisse(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

                        if (row["MONTANTAREGLER"].ToString() != "")
                            clsPhamouvementstockreglement.MONTANTAREGLER = double.Parse(row["MONTANTAREGLER"].ToString());
                        else
                            clsPhamouvementstockreglement.MONTANTAREGLER = 0;

                        if (row["SR_MONTANTCREDIT"].ToString() != "")
                            clsPhamouvementstockreglement.SR_MONTANTCREDIT =double.Parse( row["SR_MONTANTCREDIT"].ToString());
                        else
                            clsPhamouvementstockreglement.SR_MONTANTCREDIT = 0;


                        if (row["TOTALSR_MONTANTCREDIT"].ToString() != "")
                            clsPhamouvementstockreglement.TOTALSR_MONTANTCREDIT =double.Parse(row["TOTALSR_MONTANTCREDIT"].ToString());
                        else
                            clsPhamouvementstockreglement.TOTALSR_MONTANTCREDIT = 0;



                        if (row["MONTANTREGLER"].ToString() != "")
                            clsPhamouvementstockreglement.MONTANTREGLER =double.Parse(row["MONTANTREGLER"].ToString());
                        else
                            clsPhamouvementstockreglement.MONTANTREGLER = 0;

                    if (row["RESTEAREGLER"].ToString() != "")
                        clsPhamouvementstockreglement.RESTEAREGLER =double.Parse( row["RESTEAREGLER"].ToString());
                    else
                        clsPhamouvementstockreglement.RESTEAREGLER =0;

                    clsPhamouvementstockreglement.RC_LIBELLE = row["RC_LIBELLE"].ToString();
                    clsPhamouvementstockreglement.BORDEREAUVERSEMENT = row["BORDEREAUVERSEMENT"].ToString();
                    clsPhamouvementstockreglement.BORDEREAUFACTURE = row["BORDEREAUFACTURE"].ToString();
                    clsPhamouvementstockreglement.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                    if(row["MS_DATEPIECE"].ToString()!="")
                        clsPhamouvementstockreglement.MS_DATEPIECE =DateTime.Parse( row["MS_DATEPIECE"].ToString()).ToShortDateString();
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsPhamouvementstockreglement.NO_CODENATUREOPERATION1 = row["NO_CODENATUREOPERATION1"].ToString();
                    clsPhamouvementstockreglement.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                    clsPhamouvementstockreglement.CL_NUMCLIENT = row["CL_NUMCLIENT"].ToString();
                    clsPhamouvementstockreglement.CL_DENOMINATION = row["CL_DENOMINATION"].ToString();
                    clsPhamouvementstockreglement.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                    if(row["MV_DATEPIECE"].ToString()!="")
                        clsPhamouvementstockreglement.MV_DATEPIECE =DateTime.Parse( row["MV_DATEPIECE"].ToString()).ToShortDateString();

                    clsPhamouvementstockreglement.MV_NOMTIERS = row["MV_NOMTIERS"].ToString();
                    clsPhamouvementstockreglement.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = row["MR_CODEMODEREGLEMENT"].ToString();
                    clsPhamouvementstockreglement.MR_LIBELLE = row["MR_LIBELLE"].ToString();
                    clsPhamouvementstockreglement.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                    clsPhamouvementstockreglement.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsPhamouvementstockreglement.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                    clsPhamouvementstockreglement.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                    if (row["CA_DATEEFFET"].ToString() != "")
                        clsPhamouvementstockreglement.CA_DATEEFFET = DateTime.Parse(row["CA_DATEEFFET"].ToString()).ToShortDateString();
                    if (row["CA_DATEECHEANCE"].ToString() != "")
                        clsPhamouvementstockreglement.CA_DATEECHEANCE = DateTime.Parse(row["CA_DATEECHEANCE"].ToString()).ToShortDateString();
                    
                    
                    //clsPhamouvementstockreglement.MV_NUMPIECE = row["MV_NUMPIECE"].ToString();
                    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockreglements;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgInsertIntoDatasetReglementCommission(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
                    {

                List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
                List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
           
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireListeReglementCommission(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }

            //"@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CO_NUMCOMMERCIAL", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@DATEJOURNEE", 
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT , Objet[0].TI_NUMTIERS, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].MV_DATESAISIE };
                DataSet DataSet = new DataSet();

                try
                {
                    clsDonnee.pvgConnectionBase();
                    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetReglementCommission(clsDonnee, clsObjetEnvoi);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    if (DataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                            
                        clsPhamouvementstockreglement.CO_IDCOMMERCIAL = row["CO_IDCOMMERCIAL"].ToString();
                        clsPhamouvementstockreglement.CO_NUMCOMMERCIAL = row["CO_NUMCOMMERCIAL"].ToString();
                        clsPhamouvementstockreglement.CO_NOMPRENOM = row["CO_NOMPRENOM"].ToString();
                        clsPhamouvementstockreglement.CO_ADRESSEPOSTALE = row["CO_ADRESSEPOSTALE"].ToString();
                        clsPhamouvementstockreglement.CO_ADRESSEGEOGRAPHIQUE = row["CO_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsPhamouvementstockreglement.CO_TELEPHONE = row["CO_TELEPHONE"].ToString();
                        clsPhamouvementstockreglement.CO_EMAIL = row["CO_EMAIL"].ToString();
                        clsPhamouvementstockreglement.CO_TAUXCOMMISSION = row["CO_TAUXCOMMISSION"].ToString();
                        clsPhamouvementstockreglement.CO_MONTANTCOMMISSION = row["CO_MONTANTCOMMISSION"].ToString();
                        clsPhamouvementstockreglement.MC_NUMPIECE = row["MC_NUMPIECE"].ToString();
                        clsPhamouvementstockreglement.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsPhamouvementstockreglement.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                        clsPhamouvementstockreglement.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsPhamouvementstockreglement.MC_MONTANTDEBIT = row["MC_MONTANTDEBIT"].ToString();
                        clsPhamouvementstockreglement.MC_MONTANTCREDIT = row["MC_MONTANTCREDIT"].ToString();
                        clsPhamouvementstockreglement.RESTEAREGLER = (row["RESTEAREGLER"].ToString() != "") ? double.Parse(row["RESTEAREGLER"].ToString()) : 0; //row["RESTEAREGLER"].ToString();
                        clsPhamouvementstockreglement.SR_MONTANTCREDIT = (row["SR_MONTANTCREDIT"].ToString() != "") ? double.Parse(row["SR_MONTANTCREDIT"].ToString()) : 0; // row["SR_MONTANTCREDIT"].ToString();
                        clsPhamouvementstockreglement.MC_DATEPIECE = row["MC_DATEPIECE"].ToString();
                        clsPhamouvementstockreglement.MC_REFERENCEPIECE = row["MC_REFERENCEPIECE"].ToString();
                        clsPhamouvementstockreglement.MC_LIBELLEOPERATION = row["MC_LIBELLEOPERATION"].ToString();
                        clsPhamouvementstockreglement.MC_NOMTIERS = row["MC_NOMTIERS"].ToString();
                        clsPhamouvementstockreglement.MC_NUMEROPIECE = row["MC_NUMEROPIECE"].ToString();
                        clsPhamouvementstockreglement.MC_NUMSEQUENCE = row["MC_NUMSEQUENCE"].ToString();
                        clsPhamouvementstockreglement.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                        clsPhamouvementstockreglement.MC_SOLDEFINAL = row["MC_SOLDEFINAL"].ToString();
                        clsPhamouvementstockreglement.MONTANTTOTALCOMMISSION = row["MONTANTTOTALCOMMISSION"].ToString();
                        clsPhamouvementstockreglement.MONTANTCOMMISSIONREGLE = row["MONTANTCOMMISSIONREGLE"].ToString();
                        clsPhamouvementstockreglement.MC_SOLDE = row["MC_SOLDE"].ToString();
                        clsPhamouvementstockreglement.SOLDEFINAL = row["SOLDEFINAL"].ToString();



                        clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                        }
                    }
                    else
                    {
                        HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                        clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                        clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    }
                


                }
                catch (SqlException SQLEx)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                catch (Exception SQLEx)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }


                finally
                {
                    clsDonnee.pvgDeConnectionBase();
                }
                return clsPhamouvementstockreglements;
            }






        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSetSoldeCompteEcranOD(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet)
                    {

                List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
                List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
           
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
                clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglements = TestChampObligatoireListeSoldeCompteEcranOD(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglements;
            }

            //"@AG_CODEAGENCE", "@PL_NUMCOMPTEGENERAL", "@TI_NUMTIERS", "@NC_CODENATURECOMPTE", "@DATEJOURNEE"
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].PL_NUMCOMPTEGENERAL, Objet[0].TI_NUMTIERS, Objet[0].NC_CODENATURECOMPTE, Objet[0].MV_DATESAISIE};
                DataSet DataSet = new DataSet();

                try
                {
                    clsDonnee.pvgConnectionBase();
                    DataSet = clsPhamouvementstockreglementWSBLL.pvgChargerDansDataSetSoldeCompteEcranOD(clsDonnee, clsObjetEnvoi);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    if (DataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                        //DataSet.Tables["TABLE"].Rows[0][0].ToString()
                        clsPhamouvementstockreglement.MC_SOLDE = DataSet.Tables["TABLE"].Rows[0][0].ToString();// row["SOLDE"].ToString();

                            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                        }
                    }
                    else
                    {
                        HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                        clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                        clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                        clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    }
                


                }
                catch (SqlException SQLEx)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }
                catch (Exception SQLEx)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
                    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT ="FALSE";
                    //Execution du log
                    Log.Error(SQLEx.Message, null);
                    clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                }


                finally
                {
                    clsDonnee.pvgDeConnectionBase();
                }
                return clsPhamouvementstockreglements;
            }

        
    }
}
