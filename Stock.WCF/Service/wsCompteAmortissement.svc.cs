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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCompteAmortissement" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCompteAmortissement.svc ou wsCompteAmortissement.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCompteAmortissement : IwsCompteAmortissement
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsBienimmobilisefamilleWSBLL clsBienimmobilisefamilleWSBLL = new clsBienimmobilisefamilleWSBLL();

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
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsBienimmobilisefamille> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsBienimmobilisefamilles = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
        //    //--TEST CONTRAINTE
        //    clsBienimmobilisefamilles = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {"02", ""};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsBienimmobilisefamilleWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.PS_CODESOUSPRODUIT = row["PS_CODESOUSPRODUIT"].ToString();
                    clsBienimmobilisefamille.PS_LIBELLE = row["PS_LIBELLE"].ToString();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }
            }
            else
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsBienimmobilisefamilles;
    }


        
    }
}
