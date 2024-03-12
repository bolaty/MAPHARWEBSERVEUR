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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsGrandLivre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsGrandLivre.svc ou wsGrandLivre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsGrandLivre : IwsGrandLivre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsGrandLivreWSBLL clsGrandLivreWSBLL = new clsGrandLivreWSBLL();

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
        public List<HT_Stock.BOJ.clsGrandLivre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsGrandLivre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsGrandLivre> clsGrandLivres = new List<HT_Stock.BOJ.clsGrandLivre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsGrandLivres = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsGrandLivres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsGrandLivres;
        //    //--TEST CONTRAINTE
        //    clsGrandLivres = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsGrandLivres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsGrandLivres;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
                string[] vlpChamp1 = new string[] { "GL_CODEGRANDLIVRE", "GL_GRANDLIVRELIBELLE" };
                DataSet.Tables.Add("TABLE");
                for (int i = 0; i < vlpChamp1.Length; i++)
                {
                    DataSet.Tables[0].Columns.Add(vlpChamp1[i]);
                }
                DataSet.Tables[0].Rows.Add("01", "LETTREES");
                DataSet.Tables[0].Rows.Add("02", "NON LETTREES");


                
                  
            clsGrandLivres = new List<HT_Stock.BOJ.clsGrandLivre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsGrandLivre clsGrandLivre = new HT_Stock.BOJ.clsGrandLivre();
                    clsGrandLivre.GL_CODEGRANDLIVRE = row["GL_CODEGRANDLIVRE"].ToString();
                    clsGrandLivre.GL_GRANDLIVRELIBELLE = row["GL_GRANDLIVRELIBELLE"].ToString();
                    clsGrandLivre.clsObjetRetour = new Common.clsObjetRetour();
                    clsGrandLivre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsGrandLivre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsGrandLivre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsGrandLivres.Add(clsGrandLivre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsGrandLivre clsGrandLivre = new HT_Stock.BOJ.clsGrandLivre();
                clsGrandLivre.clsObjetRetour = new Common.clsObjetRetour();
                clsGrandLivre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsGrandLivre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsGrandLivre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsGrandLivres.Add(clsGrandLivre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsGrandLivre clsGrandLivre = new HT_Stock.BOJ.clsGrandLivre();
            clsGrandLivre.clsObjetRetour = new Common.clsObjetRetour();
            clsGrandLivre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsGrandLivre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsGrandLivre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsGrandLivres = new List<HT_Stock.BOJ.clsGrandLivre>();
            clsGrandLivres.Add(clsGrandLivre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsGrandLivre clsGrandLivre = new HT_Stock.BOJ.clsGrandLivre();
            clsGrandLivre.clsObjetRetour = new Common.clsObjetRetour();
            clsGrandLivre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsGrandLivre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsGrandLivre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsGrandLivres = new List<HT_Stock.BOJ.clsGrandLivre>();
            clsGrandLivres.Add(clsGrandLivre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsGrandLivres;
    }


        
    }
}
