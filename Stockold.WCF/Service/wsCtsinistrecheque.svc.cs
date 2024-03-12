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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistrecheque" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistrecheque.svc ou wsCtsinistrecheque.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistrecheque : IwsCtsinistrecheque
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistrechequeWSBLL clsCtsinistrechequeWSBLL = new clsCtsinistrechequeWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinistrecheque> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistrecheque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrecheques = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
                //--TEST CONTRAINTE
                clsCtsinistrecheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrechequeDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.AG_CODEAGENCE = clsCtsinistrechequeDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistrecheque.CH_DATESAISIECHEQUE =DateTime.Parse( clsCtsinistrechequeDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtsinistrecheque.CH_IDEXCHEQUE = clsCtsinistrechequeDTO.CH_IDEXCHEQUE.ToString();
                    clsCtsinistrecheque.EN_CODEENTREPOT = clsCtsinistrechequeDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE = clsCtsinistrechequeDTO.AB_CODEAGENCEBANCAIRE.ToString();
                    clsCtsinistrecheque.SI_CODESINISTRE = clsCtsinistrechequeDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistrecheque.CH_REFCHEQUE = clsCtsinistrechequeDTO.CH_REFCHEQUE.ToString();
                    clsCtsinistrecheque.CH_VALEURCHEQUE =double.Parse(clsCtsinistrechequeDTO.CH_VALEURCHEQUE.ToString());
                    clsCtsinistrecheque.CH_PRIMEAENCAISSER =double.Parse( clsCtsinistrechequeDTO.CH_PRIMEAENCAISSER.ToString());
                    clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse( clsCtsinistrechequeDTO.CH_DATEANNULATIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse( clsCtsinistrechequeDTO.CH_DATEEMISSIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse( clsCtsinistrechequeDTO.CH_DATEVALIDATIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_NOMTIREUR = clsCtsinistrechequeDTO.CH_NOMTIREUR.ToString();
                    clsCtsinistrecheque.CH_NOMTIRE = clsCtsinistrechequeDTO.CH_NOMTIRE.ToString();
                    clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE =DateTime.Parse(clsCtsinistrechequeDTO.CH_DATERECEPTIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_NOMDUDEPOSANT = clsCtsinistrechequeDTO.CH_NOMDUDEPOSANT.ToString();
                    clsCtsinistrecheque.CH_TELEPHONEDEPOSANT = clsCtsinistrechequeDTO.CH_TELEPHONEDEPOSANT.ToString();
                    clsCtsinistrecheque.CH_DATEEFFET = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEEFFET.ToString());
                    clsCtsinistrecheque.OP_CODEOPERATEUR = clsCtsinistrechequeDTO.OP_CODEOPERATEUR.ToString();



                    clsObjetEnvoi.OE_A = clsCtsinistrechequeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistrechequeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtsinistrechequeWSBLL.pvgAjouter(clsDonnee, clsCtsinistrecheque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrecheques;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrecheque> pvgModifier(List<HT_Stock.BOJ.clsCtsinistrecheque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrecheques = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
                //--TEST CONTRAINTE
                clsCtsinistrecheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrechequeDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.AG_CODEAGENCE = clsCtsinistrechequeDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistrecheque.CH_DATESAISIECHEQUE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtsinistrecheque.CH_IDEXCHEQUE = clsCtsinistrechequeDTO.CH_IDEXCHEQUE.ToString();
                    clsCtsinistrecheque.EN_CODEENTREPOT = clsCtsinistrechequeDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE = clsCtsinistrechequeDTO.AB_CODEAGENCEBANCAIRE.ToString();
                    clsCtsinistrecheque.SI_CODESINISTRE = clsCtsinistrechequeDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistrecheque.CH_REFCHEQUE = clsCtsinistrechequeDTO.CH_REFCHEQUE.ToString();
                    clsCtsinistrecheque.CH_VALEURCHEQUE = double.Parse(clsCtsinistrechequeDTO.CH_VALEURCHEQUE.ToString());
                    clsCtsinistrecheque.CH_PRIMEAENCAISSER = double.Parse(clsCtsinistrechequeDTO.CH_PRIMEAENCAISSER.ToString());
                    clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEANNULATIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEEMISSIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEVALIDATIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_NOMTIREUR = clsCtsinistrechequeDTO.CH_NOMTIREUR.ToString();
                    clsCtsinistrecheque.CH_NOMTIRE = clsCtsinistrechequeDTO.CH_NOMTIRE.ToString();
                    clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATERECEPTIONCHEQUE.ToString());
                    clsCtsinistrecheque.CH_NOMDUDEPOSANT = clsCtsinistrechequeDTO.CH_NOMDUDEPOSANT.ToString();
                    clsCtsinistrecheque.CH_TELEPHONEDEPOSANT = clsCtsinistrechequeDTO.CH_TELEPHONEDEPOSANT.ToString();
                    clsCtsinistrecheque.CH_DATEEFFET = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEEFFET.ToString());
                    clsCtsinistrecheque.OP_CODEOPERATEUR = clsCtsinistrechequeDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistrecheque.TYPEOPERATION =int.Parse( clsCtsinistrechequeDTO.TYPEOPERATION.ToString());

                    clsObjetEnvoi.OE_A = clsCtsinistrechequeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistrechequeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistrechequeDTO.CH_IDEXCHEQUE };
                    ////++++++++++++++++++++++++Comptabilisation du cheque
                    //if (clsCtsinistrechequeDTO.TYPEOPERATION=="3")
                    //{
                    //    //HT_Stock.BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new HT_Stock.BOJ.clsPhamouvementstockreglementcheque();
                    //    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    //    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();

                    //    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                    //    clsPhamouvementstockreglement.AG_CODEAGENCE = clsCtsinistrechequeDTO.AG_CODEAGENCE;
                    //    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsCtsinistrechequeDTO.EN_CODEENTREPOT;
                    //    clsPhamouvementstockreglement.MS_NUMPIECE = clsCtsinistrechequeDTO.MS_NUMPIECE;
                    //    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    //    clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEVALIDATIONCHEQUE);
                    //    clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsCtsinistrechequeDTO.CH_DATEVALIDATIONCHEQUE);
                    //    clsPhamouvementstockreglement.MV_NOMTIERS = clsCtsinistrechequeDTO.MV_NOMTIERS;
                    //    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = "02";
                    //    clsPhamouvementstockreglement.TI_NUMTIERS = clsCtsinistrechequeDTO.TI_NUMTIERS;// cpsDevTextBoxDC1.Text;
                    //    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsCtsinistrechequeDTO.PL_NUMCOMPTE;// vlpNumeroCompte;
                    //    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsCtsinistrechequeDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse("52110000").ToString();
                    //    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° : ";
                    //    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsCtsinistrechequeDTO.OP_CODEOPERATEUR;
                    //    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    //    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    //    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    //    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    //    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    //    clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsCtsinistrechequeDTO.CH_VALEURCHEQUE);
                    //    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    //    clsPhamouvementstockreglement.MONTANTFACTURETTC = double.Parse(clsCtsinistrechequeDTO.CH_VALEURCHEQUE);
                    //    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    //    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    //    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    //    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsCtsinistrechequeDTO.CH_REFCHEQUE;// cpsDevTextBoxT5.Text;
                    //    clsPhamouvementstockreglement.FB_IDFOURNISSEUR = "";// TI_IDTIERSASSUREUR;
                    //    clsPhamouvementstockreglement.TYPEOPERATION = 1;

                    //    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    //    clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    //    clsPhamouvementstockreglement.JO_CODEJOURNAL = 2;// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal("02");
                    //    clsPhamouvementstockreglementWSBLL clsPhamouvementstockreglementWSBLL = new clsPhamouvementstockreglementWSBLL();
                    //    clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques, clsObjetEnvoi);
                    //}
                    ////++++++++++++++++++++++++
                    clsObjetRetour.SetValue(true, clsCtsinistrechequeWSBLL.pvgModifier(clsDonnee, clsCtsinistrecheque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrecheques;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrecheque> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistrecheque> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrecheques = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
                //--TEST CONTRAINTE
                clsCtsinistrecheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE,Objet[0].CH_DATESAISIECHEQUE, Objet[0].CH_IDEXCHEQUE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistrechequeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrecheques;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinistrecheque> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistrecheque> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrecheques = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
                //--TEST CONTRAINTE
                clsCtsinistrecheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].SI_CODESINISTRE, Objet[0].CH_REFCHEQUE , Objet[0].AB_CODEAGENCEBANCAIRE, Objet[0].MONTANT1, Objet[0].MONTANT2,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistrechequeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtsinistrecheque.CH_DATESAISIECHEQUE = (row["CH_DATESAISIECHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATESAISIECHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtsinistrecheque.CH_DATESAISIECHEQUE = (clsCtsinistrecheque.CH_DATESAISIECHEQUE != "01-01-1900") ? clsCtsinistrecheque.CH_DATESAISIECHEQUE : "";
                    clsCtsinistrecheque.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtsinistrecheque.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE = row["AB_CODEAGENCEBANCAIRE"].ToString();
                    clsCtsinistrecheque.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistrecheque.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                    if (row["CH_VALEURCHEQUE"].ToString() != "")
                    clsCtsinistrecheque.CH_VALEURCHEQUE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CH_VALEURCHEQUE"].ToString()).ToString(), "M");// row["CH_VALEURCHEQUE"].ToString();
                    if (row["CH_PRIMEAENCAISSER"].ToString() != "")
                    clsCtsinistrecheque.CH_PRIMEAENCAISSER = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CH_PRIMEAENCAISSER"].ToString()).ToString(), "M");// row["CH_PRIMEAENCAISSER"].ToString();
                    clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = (row["CH_DATEANNULATIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATEANNULATIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = (clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE != "01-01-1900") ? clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE : "";
                    clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = (row["CH_DATEEMISSIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATEEMISSIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = (clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE != "01-01-1900") ? clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE : "";
                    clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = (row["CH_DATEVALIDATIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATEVALIDATIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = (clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE != "01-01-1900") ? clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE : "";
                    clsCtsinistrecheque.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
                    clsCtsinistrecheque.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
                    clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE = (row["CH_DATERECEPTIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATERECEPTIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE = (clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE != "01-01-1900") ? clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE : "";
                    clsCtsinistrecheque.CH_NOMDUDEPOSANT = row["CH_NOMDUDEPOSANT"].ToString();
                    clsCtsinistrecheque.CH_TELEPHONEDEPOSANT = row["CH_TELEPHONEDEPOSANT"].ToString();


                    clsCtsinistrecheque.CH_DATEEFFET = (row["CH_DATEEFFET"].ToString() != "") ? DateTime.Parse(row["CH_DATEEFFET"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtsinistrecheque.CH_DATEEFFET = (clsCtsinistrecheque.CH_DATEEFFET != "01-01-1900") ? clsCtsinistrecheque.CH_DATEEFFET : "";


                    clsCtsinistrecheque.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsCtsinistrecheque.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                    clsCtsinistrecheque.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
                    clsCtsinistrecheque.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
                    clsCtsinistrecheque.BQ_SIGLE = row["BQ_SIGLE"].ToString();


                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrecheques;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrecheque> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistrecheque> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinistrecheques = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
        //    //--TEST CONTRAINTE
        //    clsCtsinistrecheques = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistrecheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrecheques;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistrechequeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                    clsCtsinistrecheque.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtsinistrecheque.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                    clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistrecheques.Add(clsCtsinistrecheque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistrecheques;
    }


        
    }
}
