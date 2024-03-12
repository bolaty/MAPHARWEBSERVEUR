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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatBudget" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatBudget.svc ou wsEditionEtatBudget.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatBudget : IwsEditionEtatBudget
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatBudgetWSBLL clsEditionEtatBudgetWSBLL = new clsEditionEtatBudgetWSBLL();

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
        public List<Stock.BOJ.clsEditionEtatBudget> pvgInsertIntoDatasetEtatBudget(List<Stock.BOJ.clsEditionEtatBudget> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<Stock.BOJ.clsEditionEtatBudget> clsEditionEtatBudgets = new List<Stock.BOJ.clsEditionEtatBudget>();


            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatBudgets = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatBudgets[0].SL_RESULTAT == "FALSE") return clsEditionEtatBudgets;
                //--TEST CONTRAINTE
                clsEditionEtatBudgets = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatBudgets[0].SL_RESULTAT == "FALSE") return clsEditionEtatBudgets;
            }

      
            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEURSAISIE, Objet[0].OP_CODEOPERATEURVALIDATION, Objet[0].OP_CODEOPERATEUREDITION, Objet[0].BT_CODETYPEBUDGET, Objet[0].BU_CODEBUDGET, Objet[0].BG_CODEPOSTEBUDGETAIRE, Objet[0].SR_CODESERVICE, Objet[0].MONTANT1, Objet[0].MONTANT2 , Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].TYPEETAT };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsEditionEtatBudgetWSBLL.pvgInsertIntoDatasetEtatBudget(clsDonnee, clsObjetEnvoi);
                clsEditionEtatBudgets = new List<Stock.BOJ.clsEditionEtatBudget>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        Stock.BOJ.clsEditionEtatBudget clsEditionEtatBudget = new Stock.BOJ.clsEditionEtatBudget();
                        clsEditionEtatBudget.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsEditionEtatBudget.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                        clsEditionEtatBudget.AG_BOITEPOSTAL = row["AG_BOITEPOSTAL"].ToString();
                        clsEditionEtatBudget.AG_TELEPHONE = row["AG_TELEPHONE"].ToString();
                        clsEditionEtatBudget.AG_FAX = row["AG_FAX"].ToString();
                        clsEditionEtatBudget.BU_CODEBUDGET = row["BU_CODEBUDGET"].ToString();
                        clsEditionEtatBudget.BU_LIBELLE = row["BU_LIBELLE"].ToString();
                        if (row["BU_DATEDEBUT"].ToString()!="")
                             clsEditionEtatBudget.BU_DATEDEBUT =DateTime.Parse(row["BU_DATEDEBUT"].ToString()).ToShortDateString();
                        if (row["BU_DATEFIN"].ToString() != "")
                            clsEditionEtatBudget.BU_DATEFIN = DateTime.Parse(row["BU_DATEFIN"].ToString()).ToShortDateString();
                        if (row["BU_DATESAISIE"].ToString() != "")
                            clsEditionEtatBudget.BU_DATESAISIE = DateTime.Parse(row["BU_DATESAISIE"].ToString()).ToShortDateString();
                        clsEditionEtatBudget.BU_CODEBUDGETLIAISON = row["BU_CODEBUDGETLIAISON"].ToString();
                        clsEditionEtatBudget.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsEditionEtatBudget.BG_CODEPOSTEBUDGETAIRE = row["BG_CODEPOSTEBUDGETAIRE"].ToString();
                        clsEditionEtatBudget.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();
                        clsEditionEtatBudget.BG_CODEPOSTEBUDGETAIRE = row["BG_CODEPOSTEBUDGETAIRE"].ToString();
                        clsEditionEtatBudget.SR_LIBELLE = row["SR_LIBELLE"].ToString();
                        if (row["BE_MONTANT"].ToString() != "")
                            clsEditionEtatBudget.BE_MONTANT = Double.Parse(row["BE_MONTANT"].ToString()).ToString();
                        else
                            clsEditionEtatBudget.BE_MONTANT = "0";

                        if (row["BE_MONTANTREALISATIONMONTANT"].ToString() != "")
                            clsEditionEtatBudget.BE_MONTANTREALISATIONMONTANT = Double.Parse(row["BE_MONTANTREALISATIONMONTANT"].ToString()).ToString();
                        else
                            clsEditionEtatBudget.BE_MONTANTREALISATIONMONTANT = "0";
                        if (row["BE_MONTANTREALISATIONTAUX"].ToString() != "")
                            clsEditionEtatBudget.BE_MONTANTREALISATIONTAUX = Double.Parse(row["BE_MONTANTREALISATIONTAUX"].ToString()).ToString();
                        else
                            clsEditionEtatBudget.BE_MONTANTREALISATIONTAUX = "0";
                        if (row["BE_MONTANTSOLDE"].ToString() != "")
                            clsEditionEtatBudget.BE_MONTANTSOLDE = Double.Parse(row["BE_MONTANTSOLDE"].ToString()).ToString();
                        else
                            clsEditionEtatBudget.BE_MONTANTSOLDE = "0";
                       clsEditionEtatBudget.BE_OBSERVATION = row["BE_OBSERVATION"].ToString();
                        if (row["BU_DATESAISIE"].ToString() != "")
                            clsEditionEtatBudget.BE_DATEVALIDATION = DateTime.Parse(row["BE_DATEVALIDATION"].ToString()).ToShortDateString();
                        if (row["BU_DATESAISIE"].ToString() != "")
                            clsEditionEtatBudget.BE_DATESAISIE = DateTime.Parse(row["BE_DATESAISIE"].ToString()).ToShortDateString();
                        clsEditionEtatBudget.OP_CODEOPERATEURVALIDATION = row["OP_CODEOPERATEURVALIDATION"].ToString();
                        clsEditionEtatBudget.BN_CODENATUREPOSTEBUDGETAIRE = row["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                        clsEditionEtatBudget.BN_LIBELLE = row["BN_LIBELLE"].ToString();
                        clsEditionEtatBudget.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();
                        clsEditionEtatBudget.BT_LIBELLE = row["BT_LIBELLE"].ToString();
                        clsEditionEtatBudget.BD_CODETYPEBUDGETDETAIL = row["BD_CODETYPEBUDGETDETAIL"].ToString();
                        clsEditionEtatBudget.BD_LIBELLE = row["BD_LIBELLE"].ToString();
                        clsEditionEtatBudget.BG_LIBELLE = row["BG_LIBELLE"].ToString();
                        clsEditionEtatBudget.OP_CODEOPERATEURBUDGETDETAIL = row["OP_CODEOPERATEURBUDGETDETAIL"].ToString();
                        clsEditionEtatBudget.SL_CODEMESSAGE ="00";
                        clsEditionEtatBudget.SL_RESULTAT = "TRUE";
                        clsEditionEtatBudget.SL_MESSAGE ="Opération réalisée avec succès !!!";
                        clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                    }
                }
                else
                {
                    Stock.BOJ.clsEditionEtatBudget clsEditionEtatBudget = new Stock.BOJ.clsEditionEtatBudget();

                    clsEditionEtatBudget.SL_CODEMESSAGE = "99";
                    clsEditionEtatBudget.SL_RESULTAT = "FALSE";
                    clsEditionEtatBudget.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                }
                
                //return clsEditionEtatBudgets;

            }
            catch (SqlException SQLEx)
            {
                Stock.BOJ.clsEditionEtatBudget clsEditionEtatBudget = new Stock.BOJ.clsEditionEtatBudget();
                clsEditionEtatBudget.SL_CODEMESSAGE = "99";
                clsEditionEtatBudget.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatBudget.SL_RESULTAT ="FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatBudgets = new List<Stock.BOJ.clsEditionEtatBudget>();
                clsEditionEtatBudgets.Add(clsEditionEtatBudget);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatBudgets;
        }

        
    }
}
