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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsVille" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsVille.svc ou wsVille.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsVille : IwsVille
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsVilleWSBLL clsVilleWSBLL = new clsVilleWSBLL();

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
    public List<HT_Stock.BOJ.clsVille> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsVille> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsVille> clsVilles = new List<HT_Stock.BOJ.clsVille>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsVilles = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsVilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsVilles;
            //--TEST CONTRAINTE
            clsVilles = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsVilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsVilles;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].PY_CODEPAYS };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsVilleWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsVilles = new List<HT_Stock.BOJ.clsVille>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsVille clsVille = new HT_Stock.BOJ.clsVille();
                    clsVille.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                    clsVille.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                    clsVille.clsObjetRetour = new Common.clsObjetRetour();
                    clsVille.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsVille.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsVille.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsVilles.Add(clsVille);
                }
            }
            else
            {
                HT_Stock.BOJ.clsVille clsVille = new HT_Stock.BOJ.clsVille();
                clsVille.clsObjetRetour = new Common.clsObjetRetour();
                clsVille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsVille.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsVille.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsVilles.Add(clsVille);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsVille clsVille = new HT_Stock.BOJ.clsVille();
            clsVille.clsObjetRetour = new Common.clsObjetRetour();
            clsVille.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsVille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsVille.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsVilles = new List<HT_Stock.BOJ.clsVille>();
            clsVilles.Add(clsVille);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsVille clsVille = new HT_Stock.BOJ.clsVille();
            clsVille.clsObjetRetour = new Common.clsObjetRetour();
            clsVille.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsVille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsVille.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsVilles = new List<HT_Stock.BOJ.clsVille>();
            clsVilles.Add(clsVille);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsVilles;
    }


        
    }
}
