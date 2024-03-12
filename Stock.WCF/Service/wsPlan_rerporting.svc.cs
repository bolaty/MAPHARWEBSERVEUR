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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPlan_rerporting" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPlan_rerporting.svc ou wsPlan_rerporting.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPlan_rerporting : IwsPlan_rerporting
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPlan_rerportingWSBLL clsPlan_rerportingWSBLL = new clsPlan_rerportingWSBLL();

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
    public List<HT_Stock.BOJ.clsPlan_rerporting> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPlan_rerporting> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPlan_rerporting> clsPlan_rerportings = new List<HT_Stock.BOJ.clsPlan_rerporting>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsPlan_rerportings = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsPlan_rerportings[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlan_rerportings;
            //--TEST CONTRAINTE
          //  clsPlan_rerportings = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsPlan_rerportings[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlan_rerportings;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlan_rerportingWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPlan_rerportings = new List<HT_Stock.BOJ.clsPlan_rerporting>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlan_rerporting clsPlan_rerporting = new HT_Stock.BOJ.clsPlan_rerporting();
                    clsPlan_rerporting.PLAN_REPORTING_CODE = row["PLAN_REPORTING_CODE"].ToString();
                    clsPlan_rerporting.PLAN_RERPORTING_INTITULE = row["PLAN_RERPORTING_INTITULE"].ToString();
                    //clsPlan_rerporting.NC_NUMEROORDRE = row["NC_NUMEROORDRE"].ToString();

                    clsPlan_rerporting.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlan_rerporting.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlan_rerporting.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlan_rerporting.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlan_rerportings.Add(clsPlan_rerporting);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlan_rerporting clsPlan_rerporting = new HT_Stock.BOJ.clsPlan_rerporting();
                clsPlan_rerporting.clsObjetRetour = new Common.clsObjetRetour();
                clsPlan_rerporting.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlan_rerporting.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlan_rerporting.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlan_rerportings.Add(clsPlan_rerporting);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPlan_rerporting clsPlan_rerporting = new HT_Stock.BOJ.clsPlan_rerporting();
            clsPlan_rerporting.clsObjetRetour = new Common.clsObjetRetour();
            clsPlan_rerporting.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlan_rerporting.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlan_rerporting.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlan_rerportings = new List<HT_Stock.BOJ.clsPlan_rerporting>();
            clsPlan_rerportings.Add(clsPlan_rerporting);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPlan_rerporting clsPlan_rerporting = new HT_Stock.BOJ.clsPlan_rerporting();
            clsPlan_rerporting.clsObjetRetour = new Common.clsObjetRetour();
            clsPlan_rerporting.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlan_rerporting.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlan_rerporting.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlan_rerportings = new List<HT_Stock.BOJ.clsPlan_rerporting>();
            clsPlan_rerportings.Add(clsPlan_rerporting);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPlan_rerportings;
    }


        
    }
}
