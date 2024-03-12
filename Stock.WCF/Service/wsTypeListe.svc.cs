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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsTypeListe" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsTypeListe.svc ou wsTypeListe.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsTypeListe : IwsTypeListe
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsTypeListeWSBLL clsTypeListeWSBLL = new clsTypeListeWSBLL();

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
        public List<HT_Stock.BOJ.clsTypeListe> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsTypeListe> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsTypeListe> clsTypeListes = new List<HT_Stock.BOJ.clsTypeListe>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsTypeListes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypeListes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeListes;
        //    //--TEST CONTRAINTE
        //    clsTypeListes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsTypeListes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsTypeListes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "RS_CODERUBRIQUE", "RS_LIBELLE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("1", "QUANTITE EN STOCK NULL (0)");
                DataSet.Tables[0].Rows.Add("2", "QUANTITE EN STOCK NON NULL");


                
                  
            clsTypeListes = new List<HT_Stock.BOJ.clsTypeListe>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsTypeListe clsTypeListe = new HT_Stock.BOJ.clsTypeListe();
                    clsTypeListe.RS_CODERUBRIQUE = row["RS_CODERUBRIQUE"].ToString();
                    clsTypeListe.RS_LIBELLE = row["RS_LIBELLE"].ToString();
                    clsTypeListe.clsObjetRetour = new Common.clsObjetRetour();
                    clsTypeListe.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsTypeListe.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsTypeListe.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsTypeListes.Add(clsTypeListe);
                }
            }
            else
            {
                HT_Stock.BOJ.clsTypeListe clsTypeListe = new HT_Stock.BOJ.clsTypeListe();
                clsTypeListe.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeListe.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsTypeListe.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsTypeListe.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsTypeListes.Add(clsTypeListe);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsTypeListe clsTypeListe = new HT_Stock.BOJ.clsTypeListe();
            clsTypeListe.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeListe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypeListe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypeListe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypeListes = new List<HT_Stock.BOJ.clsTypeListe>();
            clsTypeListes.Add(clsTypeListe);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsTypeListe clsTypeListe = new HT_Stock.BOJ.clsTypeListe();
            clsTypeListe.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeListe.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsTypeListe.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsTypeListe.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsTypeListes = new List<HT_Stock.BOJ.clsTypeListe>();
            clsTypeListes.Add(clsTypeListe);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsTypeListes;
    }


        
    }
}
