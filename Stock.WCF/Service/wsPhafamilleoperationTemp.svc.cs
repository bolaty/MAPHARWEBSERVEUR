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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhafamilleoperationTemp" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhafamilleoperationTemp.svc ou wsPhafamilleoperationTemp.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhafamilleoperationTemp : IwsPhafamilleoperationTemp
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsPhafamilleoperationTempWSBLL clsPhafamilleoperationTempWSBLL = new clsPhafamilleoperationTempWSBLL();

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
        public List<HT_Stock.BOJ.clsPhafamilleoperation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhafamilleoperation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhafamilleoperationTemps = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhafamilleoperationTemps[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperationTemps;
        //    //--TEST CONTRAINTE
        //    clsPhafamilleoperationTemps = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhafamilleoperationTemps[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperationTemps;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "FO_CODEFAMILLEOPERATION", "FO_LIBELLEFAMILLEOPERATION" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("00001", "REGLEMENT");


                
                  
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhafamilleoperations;
    }


        
    }
}
