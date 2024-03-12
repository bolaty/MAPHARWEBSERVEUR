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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsStatutgrandlivre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsStatutgrandlivre.svc ou wsStatutgrandlivre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsStatutgrandlivre : IwsStatutgrandlivre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsStatutgrandlivreWSBLL clsStatutgrandlivreWSBLL = new clsStatutgrandlivreWSBLL();

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
        public List<HT_Stock.BOJ.clsStatutgrandlivre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsStatutgrandlivre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsStatutgrandlivre> clsStatutgrandlivres = new List<HT_Stock.BOJ.clsStatutgrandlivre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsStatutgrandlivres = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsStatutgrandlivres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsStatutgrandlivres;
        //    //--TEST CONTRAINTE
        //    clsStatutgrandlivres = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsStatutgrandlivres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsStatutgrandlivres;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "ST_STATUTCODE", "ST_STATUTLIBELLE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("01", "LETTREES");
                DataSet.Tables[0].Rows.Add("02", "NON LETTREES");


                
                  
            clsStatutgrandlivres = new List<HT_Stock.BOJ.clsStatutgrandlivre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsStatutgrandlivre clsStatutgrandlivre = new HT_Stock.BOJ.clsStatutgrandlivre();
                    clsStatutgrandlivre.ST_STATUTCODE = row["ST_STATUTCODE"].ToString();
                    clsStatutgrandlivre.ST_STATUTLIBELLE = row["ST_STATUTLIBELLE"].ToString();
                    clsStatutgrandlivre.clsObjetRetour = new Common.clsObjetRetour();
                    clsStatutgrandlivre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsStatutgrandlivre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsStatutgrandlivre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsStatutgrandlivres.Add(clsStatutgrandlivre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsStatutgrandlivre clsStatutgrandlivre = new HT_Stock.BOJ.clsStatutgrandlivre();
                clsStatutgrandlivre.clsObjetRetour = new Common.clsObjetRetour();
                clsStatutgrandlivre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsStatutgrandlivre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsStatutgrandlivre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsStatutgrandlivres.Add(clsStatutgrandlivre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsStatutgrandlivre clsStatutgrandlivre = new HT_Stock.BOJ.clsStatutgrandlivre();
            clsStatutgrandlivre.clsObjetRetour = new Common.clsObjetRetour();
            clsStatutgrandlivre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsStatutgrandlivre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsStatutgrandlivre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsStatutgrandlivres = new List<HT_Stock.BOJ.clsStatutgrandlivre>();
            clsStatutgrandlivres.Add(clsStatutgrandlivre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsStatutgrandlivre clsStatutgrandlivre = new HT_Stock.BOJ.clsStatutgrandlivre();
            clsStatutgrandlivre.clsObjetRetour = new Common.clsObjetRetour();
            clsStatutgrandlivre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsStatutgrandlivre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsStatutgrandlivre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsStatutgrandlivres = new List<HT_Stock.BOJ.clsStatutgrandlivre>();
            clsStatutgrandlivres.Add(clsStatutgrandlivre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsStatutgrandlivres;
    }


        
    }
}
