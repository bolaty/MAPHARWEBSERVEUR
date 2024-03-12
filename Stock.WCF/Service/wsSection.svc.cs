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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsSection" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsSection.svc ou wsSection.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsSection : IwsSection
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparsectionWSBLL clsPhaparsectionWSBLL = new clsPhaparsectionWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparsection> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhaparsection> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparsections = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparsections[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparsections;
                //--TEST CONTRAINTE
                clsPhaparsections = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparsections[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparsections;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparsectionWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();
                    clsPhaparsection.SC_CODESECTION = row["SC_CODESECTION"].ToString();
                    clsPhaparsection.SC_DENOMINATION = row["SC_DENOMINATION"].ToString();
                    clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparsection.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsPhaparsections.Add(clsPhaparsection);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsPhaparsections.Add(clsPhaparsection);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();
            clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparsection.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparsection.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            clsPhaparsections.Add(clsPhaparsection);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();
            clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparsection.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparsection.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            clsPhaparsections.Add(clsPhaparsection);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparsections;
    }


        
    }
}
