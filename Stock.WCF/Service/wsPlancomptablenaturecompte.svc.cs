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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPlancomptablenaturecompte" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPlancomptablenaturecompte.svc ou wsPlancomptablenaturecompte.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPlancomptablenaturecompte : IwsPlancomptablenaturecompte
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPlancomptablenaturecompteWSBLL clsPlancomptablenaturecompteWSBLL = new clsPlancomptablenaturecompteWSBLL();

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
    public List<HT_Stock.BOJ.clsPlancomptablenaturecompte> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPlancomptablenaturecompte> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPlancomptablenaturecompte> clsPlancomptablenaturecomptes = new List<HT_Stock.BOJ.clsPlancomptablenaturecompte>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsPlancomptablenaturecomptes = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsPlancomptablenaturecomptes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptes;
            //--TEST CONTRAINTE
          //  clsPlancomptablenaturecomptes = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsPlancomptablenaturecomptes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptes;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptablenaturecompteWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPlancomptablenaturecomptes = new List<HT_Stock.BOJ.clsPlancomptablenaturecompte>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new HT_Stock.BOJ.clsPlancomptablenaturecompte();
                    clsPlancomptablenaturecompte.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                    clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE = row["NC_LIBELLENATURECOMPTE"].ToString();
                    //clsPlancomptablenaturecompte.NC_NUMEROORDRE = row["NC_NUMEROORDRE"].ToString();

                    clsPlancomptablenaturecompte.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecompte.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptablenaturecompte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptablenaturecompte.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptablenaturecomptes.Add(clsPlancomptablenaturecompte);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new HT_Stock.BOJ.clsPlancomptablenaturecompte();
                clsPlancomptablenaturecompte.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecompte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecompte.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptablenaturecompte.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptablenaturecomptes.Add(clsPlancomptablenaturecompte);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new HT_Stock.BOJ.clsPlancomptablenaturecompte();
            clsPlancomptablenaturecompte.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecompte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptablenaturecompte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptablenaturecompte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptablenaturecomptes = new List<HT_Stock.BOJ.clsPlancomptablenaturecompte>();
            clsPlancomptablenaturecomptes.Add(clsPlancomptablenaturecompte);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new HT_Stock.BOJ.clsPlancomptablenaturecompte();
            clsPlancomptablenaturecompte.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecompte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptablenaturecompte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptablenaturecompte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptablenaturecomptes = new List<HT_Stock.BOJ.clsPlancomptablenaturecompte>();
            clsPlancomptablenaturecomptes.Add(clsPlancomptablenaturecompte);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPlancomptablenaturecomptes;
    }


        
    }
}
