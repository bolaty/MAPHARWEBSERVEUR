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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparintermediaire" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparintermediaire.svc ou wsCtparintermediaire.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparintermediaire : IwsCtparintermediaire
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparintermediaireWSBLL clsCtparintermediaireWSBLL = new clsCtparintermediaireWSBLL();

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
    public List<HT_Stock.BOJ.clsCtparintermediaire> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparintermediaire> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparintermediaire> clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsCtparintermediaires = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsCtparintermediaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparintermediaires;
            //--TEST CONTRAINTE
          //  clsCtparintermediaires = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsCtparintermediaires[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparintermediaires;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparintermediaireWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();
                    clsCtparintermediaire.IT_CODEINTERMEDIAIRE = row["IT_CODEINTERMEDIAIRE"].ToString();
                    clsCtparintermediaire.IT_DENOMMINATION = row["IT_DENOMMINATION"].ToString();
                    clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparintermediaire.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparintermediaires.Add(clsCtparintermediaire);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();
                clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparintermediaires.Add(clsCtparintermediaire);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();
            clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparintermediaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
            clsCtparintermediaires.Add(clsCtparintermediaire);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();
            clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparintermediaire.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
            clsCtparintermediaires.Add(clsCtparintermediaire);
        }



        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparintermediaires;
    }


        
    }
}
