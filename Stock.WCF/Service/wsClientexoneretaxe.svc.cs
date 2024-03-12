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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsClientexoneretaxe" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsClientexoneretaxe.svc ou wsClientexoneretaxe.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsClientexoneretaxe : IwsClientexoneretaxe
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsClientexoneretaxeWSBLL clsClientexoneretaxeWSBLL = new clsClientexoneretaxeWSBLL();

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
        public List<HT_Stock.BOJ.clsClientexoneretaxe> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsClientexoneretaxe> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsClientexoneretaxe> clsClientexoneretaxes = new List<HT_Stock.BOJ.clsClientexoneretaxe>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsClientexoneretaxes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClientexoneretaxes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClientexoneretaxes;
        //    //--TEST CONTRAINTE
        //    clsClientexoneretaxes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClientexoneretaxes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClientexoneretaxes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "CA_CLIENTEXONERETAXE", "CA_CLIENTEXONERETAXELIBELLE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("O", "OUI");
                DataSet.Tables[0].Rows.Add("N", "NON");


                
                  
            clsClientexoneretaxes = new List<HT_Stock.BOJ.clsClientexoneretaxe>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsClientexoneretaxe clsClientexoneretaxe = new HT_Stock.BOJ.clsClientexoneretaxe();
                    clsClientexoneretaxe.CA_CLIENTEXONERETAXE = row["CA_CLIENTEXONERETAXE"].ToString();
                    clsClientexoneretaxe.CA_CLIENTEXONERETAXELIBELLE = row["CA_CLIENTEXONERETAXELIBELLE"].ToString();
                    clsClientexoneretaxe.clsObjetRetour = new Common.clsObjetRetour();
                    clsClientexoneretaxe.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsClientexoneretaxe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClientexoneretaxe.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsClientexoneretaxes.Add(clsClientexoneretaxe);
                }
            }
            else
            {
                HT_Stock.BOJ.clsClientexoneretaxe clsClientexoneretaxe = new HT_Stock.BOJ.clsClientexoneretaxe();
                clsClientexoneretaxe.clsObjetRetour = new Common.clsObjetRetour();
                clsClientexoneretaxe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClientexoneretaxe.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsClientexoneretaxe.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsClientexoneretaxes.Add(clsClientexoneretaxe);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsClientexoneretaxe clsClientexoneretaxe = new HT_Stock.BOJ.clsClientexoneretaxe();
            clsClientexoneretaxe.clsObjetRetour = new Common.clsObjetRetour();
            clsClientexoneretaxe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClientexoneretaxe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClientexoneretaxe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClientexoneretaxes = new List<HT_Stock.BOJ.clsClientexoneretaxe>();
            clsClientexoneretaxes.Add(clsClientexoneretaxe);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsClientexoneretaxe clsClientexoneretaxe = new HT_Stock.BOJ.clsClientexoneretaxe();
            clsClientexoneretaxe.clsObjetRetour = new Common.clsObjetRetour();
            clsClientexoneretaxe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClientexoneretaxe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClientexoneretaxe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClientexoneretaxes = new List<HT_Stock.BOJ.clsClientexoneretaxe>();
            clsClientexoneretaxes.Add(clsClientexoneretaxe);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsClientexoneretaxes;
    }


        
    }
}
