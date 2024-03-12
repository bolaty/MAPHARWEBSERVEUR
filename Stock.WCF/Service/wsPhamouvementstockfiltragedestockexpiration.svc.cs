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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhamouvementstockfiltragedestockexpiration" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhamouvementstockfiltragedestockexpiration.svc ou wsPhamouvementstockfiltragedestockexpiration.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhamouvementstockfiltragedestockexpiration : IwsPhamouvementstockfiltragedestockexpiration
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhamouvementstockfiltragedestockexpirationWSBLL clsPhamouvementstockfiltragedestockexpirationWSBLL = new clsPhamouvementstockfiltragedestockexpirationWSBLL();

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
        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhamouvementstockfiltragedestockexpirations = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockfiltragedestockexpirations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockfiltragedestockexpirations;
        //    //--TEST CONTRAINTE
        //    clsPhamouvementstockfiltragedestockexpirations = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockfiltragedestockexpirations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockfiltragedestockexpirations;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockfiltragedestockexpirationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();
                    clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION = row["ME_IDFILTRAGEDESTOCKEXPIRATION"].ToString();
                    clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = row["ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION"].ToString();
                    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockfiltragedestockexpirations;
    }


        
    }
}
