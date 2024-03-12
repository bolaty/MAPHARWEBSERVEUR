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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypefournisseur" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypefournisseur.svc ou wsPhapartypefournisseur.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypefournisseur : IwsPhapartypefournisseur
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypefournisseurWSBLL clsPhapartypefournisseurWSBLL = new clsPhapartypefournisseurWSBLL();

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
        public List<HT_Stock.BOJ.clsPhapartypefournisseur> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypefournisseur> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypefournisseur> clsPhapartypefournisseurs = new List<HT_Stock.BOJ.clsPhapartypefournisseur>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhapartypefournisseurs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypefournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypefournisseurs;
        //    //--TEST CONTRAINTE
        //    clsPhapartypefournisseurs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypefournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypefournisseurs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypefournisseurWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypefournisseurs = new List<HT_Stock.BOJ.clsPhapartypefournisseur>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypefournisseur clsPhapartypefournisseur = new HT_Stock.BOJ.clsPhapartypefournisseur();
                    clsPhapartypefournisseur.TF_CODETYPEFOURNISSEUR = row["TF_CODETYPEFOURNISSEUR"].ToString();
                    clsPhapartypefournisseur.TF_LIBELLE = row["TF_LIBELLE"].ToString();
                    clsPhapartypefournisseur.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypefournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypefournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypefournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsPhapartypefournisseurs.Add(clsPhapartypefournisseur);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypefournisseur clsPhapartypefournisseur = new HT_Stock.BOJ.clsPhapartypefournisseur();
                clsPhapartypefournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypefournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypefournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypefournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsPhapartypefournisseurs.Add(clsPhapartypefournisseur);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypefournisseur clsPhapartypefournisseur = new HT_Stock.BOJ.clsPhapartypefournisseur();
            clsPhapartypefournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypefournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypefournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypefournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypefournisseurs = new List<HT_Stock.BOJ.clsPhapartypefournisseur>();
            clsPhapartypefournisseurs.Add(clsPhapartypefournisseur);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypefournisseur clsPhapartypefournisseur = new HT_Stock.BOJ.clsPhapartypefournisseur();
            clsPhapartypefournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypefournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypefournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypefournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypefournisseurs = new List<HT_Stock.BOJ.clsPhapartypefournisseur>();
            clsPhapartypefournisseurs.Add(clsPhapartypefournisseur);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypefournisseurs;
    }


        
    }
}
