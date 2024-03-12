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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsASDI" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsASDI.svc ou wsASDI.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsASDI : IwsASDI
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsASDIWSBLL clsASDIWSBLL = new clsASDIWSBLL();

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
        public List<HT_Stock.BOJ.clsASDI> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsASDI> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsASDI> clsASDIs = new List<HT_Stock.BOJ.clsASDI>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsASDIs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsASDIs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsASDIs;
        //    //--TEST CONTRAINTE
        //    clsASDIs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsASDIs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsASDIs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "TI_ASDI", "TI_ASDILIBELLE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("O", "OUI");
                DataSet.Tables[0].Rows.Add("N", "NON");


                
                  
            clsASDIs = new List<HT_Stock.BOJ.clsASDI>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsASDI clsASDI = new HT_Stock.BOJ.clsASDI();
                    clsASDI.TI_ASDI = row["TI_ASDI"].ToString();
                    clsASDI.TI_ASDILIBELLE = row["TI_ASDILIBELLE"].ToString();
                    clsASDI.clsObjetRetour = new Common.clsObjetRetour();
                    clsASDI.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsASDI.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsASDI.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsASDIs.Add(clsASDI);
                }
            }
            else
            {
                HT_Stock.BOJ.clsASDI clsASDI = new HT_Stock.BOJ.clsASDI();
                clsASDI.clsObjetRetour = new Common.clsObjetRetour();
                clsASDI.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsASDI.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsASDI.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsASDIs.Add(clsASDI);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsASDI clsASDI = new HT_Stock.BOJ.clsASDI();
            clsASDI.clsObjetRetour = new Common.clsObjetRetour();
            clsASDI.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsASDI.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsASDI.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsASDIs = new List<HT_Stock.BOJ.clsASDI>();
            clsASDIs.Add(clsASDI);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsASDI clsASDI = new HT_Stock.BOJ.clsASDI();
            clsASDI.clsObjetRetour = new Common.clsObjetRetour();
            clsASDI.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsASDI.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsASDI.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsASDIs = new List<HT_Stock.BOJ.clsASDI>();
            clsASDIs.Add(clsASDI);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsASDIs;
    }


        
    }
}
