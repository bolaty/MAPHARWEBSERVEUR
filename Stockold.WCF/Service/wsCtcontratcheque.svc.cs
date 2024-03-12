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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontratcheque" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontratcheque.svc ou wsCtcontratcheque.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontratcheque : IwsCtcontratcheque
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratchequeWSBLL clsCtcontratchequeWSBLL = new clsCtcontratchequeWSBLL();

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
        public List<HT_Stock.BOJ.clsCtcontratcheque> pvgAjouter(List<HT_Stock.BOJ.clsCtcontratcheque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratcheques = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
                //--TEST CONTRAINTE
                clsCtcontratcheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratcheque clsCtcontratchequeDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.AG_CODEAGENCE = clsCtcontratchequeDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratcheque.CH_DATESAISIECHEQUE =DateTime.Parse( clsCtcontratchequeDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtcontratcheque.CH_IDEXCHEQUE = clsCtcontratchequeDTO.CH_IDEXCHEQUE.ToString();
                    clsCtcontratcheque.EN_CODEENTREPOT = clsCtcontratchequeDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontratcheque.AB_CODEAGENCEBANCAIRE = clsCtcontratchequeDTO.AB_CODEAGENCEBANCAIRE.ToString();
                    clsCtcontratcheque.CA_CODECONTRAT = clsCtcontratchequeDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratcheque.CH_REFCHEQUE = clsCtcontratchequeDTO.CH_REFCHEQUE.ToString();
                    clsCtcontratcheque.CH_VALEURCHEQUE =double.Parse(clsCtcontratchequeDTO.CH_VALEURCHEQUE.ToString());
                    clsCtcontratcheque.CH_PRIMEAENCAISSER =double.Parse( clsCtcontratchequeDTO.CH_PRIMEAENCAISSER.ToString());
                    clsCtcontratcheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse( clsCtcontratchequeDTO.CH_DATEANNULATIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse( clsCtcontratchequeDTO.CH_DATEEMISSIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse( clsCtcontratchequeDTO.CH_DATEVALIDATIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_NOMTIREUR = clsCtcontratchequeDTO.CH_NOMTIREUR.ToString();
                    clsCtcontratcheque.CH_NOMTIRE = clsCtcontratchequeDTO.CH_NOMTIRE.ToString();
                    clsCtcontratcheque.CH_DATERECEPTIONCHEQUE =DateTime.Parse(clsCtcontratchequeDTO.CH_DATERECEPTIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_NOMDUDEPOSANT = clsCtcontratchequeDTO.CH_NOMDUDEPOSANT.ToString();
                    clsCtcontratcheque.CH_TELEPHONEDEPOSANT = clsCtcontratchequeDTO.CH_TELEPHONEDEPOSANT.ToString();
                    clsCtcontratcheque.CH_DATEEFFET = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEEFFET.ToString());
                    clsCtcontratcheque.OP_CODEOPERATEUR = clsCtcontratchequeDTO.OP_CODEOPERATEUR.ToString();



                    clsObjetEnvoi.OE_A = clsCtcontratchequeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratchequeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtcontratchequeWSBLL.pvgAjouter(clsDonnee, clsCtcontratcheque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratcheques;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratcheque> pvgModifier(List<HT_Stock.BOJ.clsCtcontratcheque> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratcheques = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
                //--TEST CONTRAINTE
                clsCtcontratcheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratcheque clsCtcontratchequeDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.AG_CODEAGENCE = clsCtcontratchequeDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratcheque.CH_DATESAISIECHEQUE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtcontratcheque.CH_IDEXCHEQUE = clsCtcontratchequeDTO.CH_IDEXCHEQUE.ToString();
                    clsCtcontratcheque.EN_CODEENTREPOT = clsCtcontratchequeDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontratcheque.AB_CODEAGENCEBANCAIRE = clsCtcontratchequeDTO.AB_CODEAGENCEBANCAIRE.ToString();
                    clsCtcontratcheque.CA_CODECONTRAT = clsCtcontratchequeDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratcheque.CH_REFCHEQUE = clsCtcontratchequeDTO.CH_REFCHEQUE.ToString();
                    clsCtcontratcheque.CH_VALEURCHEQUE = double.Parse(clsCtcontratchequeDTO.CH_VALEURCHEQUE.ToString());
                    clsCtcontratcheque.CH_PRIMEAENCAISSER = double.Parse(clsCtcontratchequeDTO.CH_PRIMEAENCAISSER.ToString());
                    clsCtcontratcheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEANNULATIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEEMISSIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEVALIDATIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_NOMTIREUR = clsCtcontratchequeDTO.CH_NOMTIREUR.ToString();
                    clsCtcontratcheque.CH_NOMTIRE = clsCtcontratchequeDTO.CH_NOMTIRE.ToString();
                    clsCtcontratcheque.CH_DATERECEPTIONCHEQUE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATERECEPTIONCHEQUE.ToString());
                    clsCtcontratcheque.CH_NOMDUDEPOSANT = clsCtcontratchequeDTO.CH_NOMDUDEPOSANT.ToString();
                    clsCtcontratcheque.CH_TELEPHONEDEPOSANT = clsCtcontratchequeDTO.CH_TELEPHONEDEPOSANT.ToString();
                    clsCtcontratcheque.CH_DATEEFFET = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEEFFET.ToString());
                    clsCtcontratcheque.OP_CODEOPERATEUR = clsCtcontratchequeDTO.OP_CODEOPERATEUR.ToString();
                    clsCtcontratcheque.TYPEOPERATION =int.Parse( clsCtcontratchequeDTO.TYPEOPERATION.ToString());

                    clsObjetEnvoi.OE_A = clsCtcontratchequeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratchequeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratchequeDTO.CH_IDEXCHEQUE };
                    ////++++++++++++++++++++++++Comptabilisation du cheque
                    //if (clsCtcontratchequeDTO.TYPEOPERATION=="3")
                    //{
                    //    //HT_Stock.BOJ.clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new HT_Stock.BOJ.clsPhamouvementstockreglementcheque();
                    //    List<Stock.BOJ.clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<Stock.BOJ.clsPhamouvementstockreglementcheque>();
                    //    Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new Stock.BOJ.clsPhamouvementstockreglement();

                    //    clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "00001"; // LORS DE LA VENTE /APPRO
                    //    clsPhamouvementstockreglement.AG_CODEAGENCE = clsCtcontratchequeDTO.AG_CODEAGENCE;
                    //    clsPhamouvementstockreglement.EN_CODEENTREPOT = clsCtcontratchequeDTO.EN_CODEENTREPOT;
                    //    clsPhamouvementstockreglement.MS_NUMPIECE = clsCtcontratchequeDTO.MS_NUMPIECE;
                    //    clsPhamouvementstockreglement.MV_ANNULATIONPIECE = "N";
                    //    clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEVALIDATIONCHEQUE);
                    //    clsPhamouvementstockreglement.MV_DATESAISIE = DateTime.Parse(clsCtcontratchequeDTO.CH_DATEVALIDATIONCHEQUE);
                    //    clsPhamouvementstockreglement.MV_NOMTIERS = clsCtcontratchequeDTO.MV_NOMTIERS;
                    //    clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = "02";
                    //    clsPhamouvementstockreglement.TI_NUMTIERS = clsCtcontratchequeDTO.TI_NUMTIERS;// cpsDevTextBoxDC1.Text;
                    //    clsPhamouvementstockreglement.PL_NUMCOMPTE = clsCtcontratchequeDTO.PL_NUMCOMPTE;// vlpNumeroCompte;
                    //    clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE = clsCtcontratchequeDTO.PL_NUMCOMPTEBANQUE.ToString();// double.Parse("52110000").ToString();
                    //    clsPhamouvementstockreglement.MV_LIBELLEOPERATION = "REGLEMENT FACTURE N° : ";
                    //    clsPhamouvementstockreglement.OP_CODEOPERATEUR = clsCtcontratchequeDTO.OP_CODEOPERATEUR;
                    //    //clsPhamouvementstockreglement.MS_NUMPIECE = _NUMEROCOMMANDE;
                    //    //clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(cpsDevTextBoxD3.Text);
                    //    //clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                    //    clsPhamouvementstockreglement.MONTANTFACTURE = 0;
                    //    clsPhamouvementstockreglement.MONTANTREMISE = 0;
                    //    clsPhamouvementstockreglement.MONTANTTVA = 0;
                    //    clsPhamouvementstockreglement.MONTANTAIRSI = 0;
                    //    clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsCtcontratchequeDTO.CH_VALEURCHEQUE);
                    //    clsPhamouvementstockreglement.MONTANTTRANSPORT = 0;
                    //    clsPhamouvementstockreglement.MONTANTFACTURETTC = double.Parse(clsCtcontratchequeDTO.CH_VALEURCHEQUE);
                    //    clsPhamouvementstockreglement.RESTEMONTANTFACTURE = 0;
                    //    clsPhamouvementstockreglement.MONTANTIMPAYER = 0;
                    //    clsPhamouvementstockreglement.MS_UTILISERSUPLUS = 0;
                    //    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsCtcontratchequeDTO.CH_REFCHEQUE;// cpsDevTextBoxT5.Text;
                    //    clsPhamouvementstockreglement.FB_IDFOURNISSEUR = "";// TI_IDTIERSASSUREUR;
                    //    clsPhamouvementstockreglement.TYPEOPERATION = 1;

                    //    //MS_MONTANTTOTALREMISE = cpsDevTextBoxD4.Text;
                    //    clsPhamouvementstockreglement.MV_NUMPIECE = "0";
                    //    clsPhamouvementstockreglement.JO_CODEJOURNAL = 2;// clsPhamouvementstockreglementManager.Instance.pvgCodeJournal("02");
                    //    clsPhamouvementstockreglementWSBLL clsPhamouvementstockreglementWSBLL = new clsPhamouvementstockreglementWSBLL();
                    //    clsPhamouvementstockreglementWSBLL.pvgAjouterComptabilisation(clsDonnee, clsPhamouvementstockreglement, clsPhamouvementstockreglementcheques, clsObjetEnvoi);
                    //}
                    ////++++++++++++++++++++++++
                    clsObjetRetour.SetValue(true, clsCtcontratchequeWSBLL.pvgModifier(clsDonnee, clsCtcontratcheque, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratcheques;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratcheque> pvgSupprimer(List<HT_Stock.BOJ.clsCtcontratcheque> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratcheques = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
                //--TEST CONTRAINTE
                clsCtcontratcheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE,Objet[0].CH_DATESAISIECHEQUE, Objet[0].CH_IDEXCHEQUE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratchequeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratcheques;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontratcheque> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontratcheque> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratcheques = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
                //--TEST CONTRAINTE
                clsCtcontratcheques = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT, Objet[0].CH_REFCHEQUE , Objet[0].AB_CODEAGENCEBANCAIRE, Objet[0].MONTANT1, Objet[0].MONTANT2,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratchequeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratcheque.CH_DATESAISIECHEQUE = (row["CH_DATESAISIECHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATESAISIECHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratcheque.CH_DATESAISIECHEQUE = (clsCtcontratcheque.CH_DATESAISIECHEQUE != "01-01-1900") ? clsCtcontratcheque.CH_DATESAISIECHEQUE : "";
                    clsCtcontratcheque.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtcontratcheque.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsCtcontratcheque.AB_CODEAGENCEBANCAIRE = row["AB_CODEAGENCEBANCAIRE"].ToString();
                    clsCtcontratcheque.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                    clsCtcontratcheque.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                    if (row["CH_VALEURCHEQUE"].ToString() != "")
                    clsCtcontratcheque.CH_VALEURCHEQUE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CH_VALEURCHEQUE"].ToString()).ToString(), "M");// row["CH_VALEURCHEQUE"].ToString();
                    if (row["CH_PRIMEAENCAISSER"].ToString() != "")
                    clsCtcontratcheque.CH_PRIMEAENCAISSER = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CH_PRIMEAENCAISSER"].ToString()).ToString(), "M");// row["CH_PRIMEAENCAISSER"].ToString();
                    clsCtcontratcheque.CH_DATEANNULATIONCHEQUE = (row["CH_DATEANNULATIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATEANNULATIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratcheque.CH_DATEANNULATIONCHEQUE = (clsCtcontratcheque.CH_DATEANNULATIONCHEQUE != "01-01-1900") ? clsCtcontratcheque.CH_DATEANNULATIONCHEQUE : "";
                    clsCtcontratcheque.CH_DATEEMISSIONCHEQUE = (row["CH_DATEEMISSIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATEEMISSIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratcheque.CH_DATEEMISSIONCHEQUE = (clsCtcontratcheque.CH_DATEEMISSIONCHEQUE != "01-01-1900") ? clsCtcontratcheque.CH_DATEEMISSIONCHEQUE : "";
                    clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE = (row["CH_DATEVALIDATIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATEVALIDATIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE = (clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE != "01-01-1900") ? clsCtcontratcheque.CH_DATEVALIDATIONCHEQUE : "";
                    clsCtcontratcheque.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
                    clsCtcontratcheque.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
                    clsCtcontratcheque.CH_DATERECEPTIONCHEQUE = (row["CH_DATERECEPTIONCHEQUE"].ToString() != "") ? DateTime.Parse(row["CH_DATERECEPTIONCHEQUE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratcheque.CH_DATERECEPTIONCHEQUE = (clsCtcontratcheque.CH_DATERECEPTIONCHEQUE != "01-01-1900") ? clsCtcontratcheque.CH_DATERECEPTIONCHEQUE : "";
                    clsCtcontratcheque.CH_NOMDUDEPOSANT = row["CH_NOMDUDEPOSANT"].ToString();
                    clsCtcontratcheque.CH_TELEPHONEDEPOSANT = row["CH_TELEPHONEDEPOSANT"].ToString();


                    clsCtcontratcheque.CH_DATEEFFET = (row["CH_DATEEFFET"].ToString() != "") ? DateTime.Parse(row["CH_DATEEFFET"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratcheque.CH_DATEEFFET = (clsCtcontratcheque.CH_DATEEFFET != "01-01-1900") ? clsCtcontratcheque.CH_DATEEFFET : "";


                    clsCtcontratcheque.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsCtcontratcheque.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                    clsCtcontratcheque.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
                    clsCtcontratcheque.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
                    clsCtcontratcheque.BQ_SIGLE = row["BQ_SIGLE"].ToString();


                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
            clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            clsCtcontratcheques.Add(clsCtcontratcheque);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
            clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            clsCtcontratcheques.Add(clsCtcontratcheque);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratcheques;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratcheque> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtcontratcheque> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtcontratcheques = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
        //    //--TEST CONTRAINTE
        //    clsCtcontratcheques = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratcheques[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratcheques;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratchequeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                    clsCtcontratcheque.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtcontratcheque.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                    clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratcheques.Add(clsCtcontratcheque);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratcheques.Add(clsCtcontratcheque);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
            clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            clsCtcontratcheques.Add(clsCtcontratcheque);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
            clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            clsCtcontratcheques.Add(clsCtcontratcheque);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratcheques;
    }


        
    }
}
