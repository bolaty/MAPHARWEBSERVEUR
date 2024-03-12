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

                    if(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CA_CODECONTRAT!="")
                    {
                        clsCtcontratchequereglementcaisse.AG_CODEAGENCE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AG_CODEAGENCE;
                        clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE =DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE);
                        clsCtcontratchequereglementcaisse.EN_CODEENTREPOT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.EN_CODEENTREPOT;
                        clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE;
                        clsCtcontratchequereglementcaisse.CA_CODECONTRAT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CA_CODECONTRAT;
                        clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE;
                        clsCtcontratchequereglementcaisse.CHC_REFCHEQUE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_REFCHEQUE;
                        clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE =double.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE);
                        clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER = double.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER);
                        clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE = DateTime.Parse("01/01/1900");
                        clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE = DateTime.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE);
                        clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE = DateTime.Parse("01/01/1900");
                        clsCtcontratchequereglementcaisse.CHC_NOMTIREUR = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMTIREUR;
                        clsCtcontratchequereglementcaisse.CHC_NOMTIRE = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMTIRE;
                        clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE =DateTime.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE);
                        clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT;
                        clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT = clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT;
                        clsCtcontratchequereglementcaisse.CHC_DATEEFFET = DateTime.Parse( clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.CHC_DATEEFFET);
                        clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR =clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR;
                        clsCtcontratchequereglementcaisse.TYPEOPERATION =int.Parse(clsPhamouvementstockreglementDTO.clsCtcontratchequereglementcaisse.TYPEOPERATION);
                    }


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
                    clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT);
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
                    clsPhamouvementstockreglement1.MV_MONTANTCREDIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT);
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
                    clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT =double.Parse( clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT);
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
                    clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT);
                    clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTDEBIT);
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
                    clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT);
                    clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTDEBIT);
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
                        clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTCREDIT);
                        clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(clsPhamouvementstockreglementDTO.MV_MONTANTDEBIT);
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

                    clsPhamouvementstockreglement.RESTEAREGLERCOMMISSION = row["RESTEAREGLERCOMMISSION"].ToString();
                    clsPhamouvementstockreglement.MONTANTREGLERCOMMISSION = row["MONTANTREGLERCOMMISSION"].ToString();
                    clsPhamouvementstockreglement.MONTANTAREGLERCOMMISSION = row["MONTANTAREGLERCOMMISSION"].ToString();
                    clsPhamouvementstockreglement.SR_MONTANTCREDIT = row["SR_MONTANTCREDIT"].ToString();
                    clsPhamouvementstockreglement.RESTEAREGLERASSUREUR = row["RESTEAREGLERASSUREUR"].ToString();
                    clsPhamouvementstockreglement.MONTANTREGLERASSUREUR = row["MONTANTREGLERASSUREUR"].ToString();
                    clsPhamouvementstockreglement.MONTANTAREGLERASSUREUR = row["MONTANTAREGLERASSUREUR"].ToString();
                    clsPhamouvementstockreglement.MONTANTAREGLER = row["MONTANTAREGLER"].ToString();
                    clsPhamouvementstockreglement.SR_MONTANTCREDIT = row["SR_MONTANTCREDIT"].ToString();
                    clsPhamouvementstockreglement.MONTANTREGLER = row["MONTANTREGLER"].ToString();
                    clsPhamouvementstockreglement.RESTEAREGLER = row["RESTEAREGLER"].ToString();
                    clsPhamouvementstockreglement.SR_MONTANTCREDIT = row["SR_MONTANTCREDIT"].ToString();



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
                        clsPhamouvementstockreglement.RESTEAREGLER = row["RESTEAREGLER"].ToString();
                        clsPhamouvementstockreglement.SR_MONTANTCREDIT = row["SR_MONTANTCREDIT"].ToString();
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
