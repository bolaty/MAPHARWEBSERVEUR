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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPays" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPays.svc ou wsPays.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPays : IwsPays
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPaysWSBLL clsPaysWSBLL = new clsPaysWSBLL();

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
    public List<HT_Stock.BOJ.clsPays> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPays> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPays> clsPayss = new List<HT_Stock.BOJ.clsPays>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsPayss = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsPayss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPayss;
            //--TEST CONTRAINTE
          //  clsPayss = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsPayss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPayss;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPaysWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPayss = new List<HT_Stock.BOJ.clsPays>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPays clsPays = new HT_Stock.BOJ.clsPays();
                    clsPays.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                    clsPays.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                    clsPays.PY_CODEPOSTALE = row["PY_CODEPOSTALE"].ToString();

                    clsPays.clsObjetRetour = new Common.clsObjetRetour();
                    clsPays.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPays.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPays.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPayss.Add(clsPays);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPays clsPays = new HT_Stock.BOJ.clsPays();
                clsPays.clsObjetRetour = new Common.clsObjetRetour();
                clsPays.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPays.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPays.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPayss.Add(clsPays);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPays clsPays = new HT_Stock.BOJ.clsPays();
            clsPays.clsObjetRetour = new Common.clsObjetRetour();
            clsPays.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPays.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPays.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPayss = new List<HT_Stock.BOJ.clsPays>();
            clsPayss.Add(clsPays);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPays clsPays = new HT_Stock.BOJ.clsPays();
            clsPays.clsObjetRetour = new Common.clsObjetRetour();
            clsPays.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPays.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPays.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPayss = new List<HT_Stock.BOJ.clsPays>();
            clsPayss.Add(clsPays);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPayss;
    }


        
    }
}
