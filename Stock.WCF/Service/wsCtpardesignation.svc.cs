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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpardesignation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpardesignation.svc ou wsCtpardesignation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpardesignation : IwsCtpardesignation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpardesignationWSBLL clsCtpardesignationWSBLL = new clsCtpardesignationWSBLL();

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
    public List<HT_Stock.BOJ.clsCtpardesignation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpardesignation> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpardesignation> clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsCtpardesignations = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsCtpardesignations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardesignations;
            //--TEST CONTRAINTE
          //  clsCtpardesignations = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsCtpardesignations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardesignations;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpardesignationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();
                    clsCtpardesignation.DI_CODEDESIGNATION = row["DI_CODEDESIGNATION"].ToString();
                    clsCtpardesignation.DI_LIBELLEDESIGNATION = row["DI_LIBELLEDESIGNATION"].ToString();
                    clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpardesignation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpardesignations.Add(clsCtpardesignation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();
                clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpardesignation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpardesignations.Add(clsCtpardesignation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();
            clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpardesignation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpardesignation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
            clsCtpardesignations.Add(clsCtpardesignation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();
            clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpardesignation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpardesignation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
            clsCtpardesignations.Add(clsCtpardesignation);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpardesignations;
    }


        
    }
}
