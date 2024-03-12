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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsStatutCompte" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsStatutCompte.svc ou wsStatutCompte.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsStatutCompte : IwsStatutCompte
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsStatutCompteWSBLL clsStatutCompteWSBLL = new clsStatutCompteWSBLL();

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
        public List<HT_Stock.BOJ.clsStatutCompte> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsStatutCompte> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsStatutCompte> clsStatutComptes = new List<HT_Stock.BOJ.clsStatutCompte>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsStatutComptes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsStatutComptes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsStatutComptes;
        //    //--TEST CONTRAINTE
        //    clsStatutComptes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsStatutComptes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsStatutComptes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "PL_ACTIF", "PL_ACTIFLIBELLE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("O", "ACTIF");
                DataSet.Tables[0].Rows.Add("N", "NON ACTIF");


                
                  
            clsStatutComptes = new List<HT_Stock.BOJ.clsStatutCompte>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsStatutCompte clsStatutCompte = new HT_Stock.BOJ.clsStatutCompte();
                    clsStatutCompte.PL_ACTIF = row["PL_ACTIF"].ToString();
                    clsStatutCompte.PL_ACTIFLIBELLE = row["PL_ACTIFLIBELLE"].ToString();
                    clsStatutCompte.clsObjetRetour = new Common.clsObjetRetour();
                    clsStatutCompte.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsStatutCompte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsStatutCompte.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsStatutComptes.Add(clsStatutCompte);
                }
            }
            else
            {
                HT_Stock.BOJ.clsStatutCompte clsStatutCompte = new HT_Stock.BOJ.clsStatutCompte();
                clsStatutCompte.clsObjetRetour = new Common.clsObjetRetour();
                clsStatutCompte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsStatutCompte.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsStatutCompte.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsStatutComptes.Add(clsStatutCompte);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsStatutCompte clsStatutCompte = new HT_Stock.BOJ.clsStatutCompte();
            clsStatutCompte.clsObjetRetour = new Common.clsObjetRetour();
            clsStatutCompte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsStatutCompte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsStatutCompte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsStatutComptes = new List<HT_Stock.BOJ.clsStatutCompte>();
            clsStatutComptes.Add(clsStatutCompte);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsStatutCompte clsStatutCompte = new HT_Stock.BOJ.clsStatutCompte();
            clsStatutCompte.clsObjetRetour = new Common.clsObjetRetour();
            clsStatutCompte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsStatutCompte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsStatutCompte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsStatutComptes = new List<HT_Stock.BOJ.clsStatutCompte>();
            clsStatutComptes.Add(clsStatutCompte);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsStatutComptes;
    }


        
    }
}
