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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypearticleoperation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypearticleoperation.svc ou wsPhapartypearticleoperation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypearticleoperation : IwsPhapartypearticleoperation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypearticleoperationWSBLL clsPhapartypearticleoperationWSBLL = new clsPhapartypearticleoperationWSBLL();

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
    public List<HT_Stock.BOJ.clsPhapartypearticleoperation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypearticleoperation> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypearticleoperation> clsPhapartypearticleoperations = new List<HT_Stock.BOJ.clsPhapartypearticleoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsPhapartypearticleoperations = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsPhapartypearticleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticleoperations;
            //--TEST CONTRAINTE
          //  clsPhapartypearticleoperations = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsPhapartypearticleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticleoperations;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypearticleoperationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypearticleoperations = new List<HT_Stock.BOJ.clsPhapartypearticleoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypearticleoperation clsPhapartypearticleoperation = new HT_Stock.BOJ.clsPhapartypearticleoperation();
                    clsPhapartypearticleoperation.TO_CODEOPERATION = row["TO_CODEOPERATION"].ToString();
                    clsPhapartypearticleoperation.TO_LIBELLE = row["TO_LIBELLE"].ToString();
                    //clsPhapartypearticleoperation.NC_NUMEROORDRE = row["NC_NUMEROORDRE"].ToString();

                    clsPhapartypearticleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticleoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypearticleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticleoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypearticleoperations.Add(clsPhapartypearticleoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypearticleoperation clsPhapartypearticleoperation = new HT_Stock.BOJ.clsPhapartypearticleoperation();
                clsPhapartypearticleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypearticleoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypearticleoperations.Add(clsPhapartypearticleoperation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticleoperation clsPhapartypearticleoperation = new HT_Stock.BOJ.clsPhapartypearticleoperation();
            clsPhapartypearticleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticleoperations = new List<HT_Stock.BOJ.clsPhapartypearticleoperation>();
            clsPhapartypearticleoperations.Add(clsPhapartypearticleoperation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticleoperation clsPhapartypearticleoperation = new HT_Stock.BOJ.clsPhapartypearticleoperation();
            clsPhapartypearticleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticleoperations = new List<HT_Stock.BOJ.clsPhapartypearticleoperation>();
            clsPhapartypearticleoperations.Add(clsPhapartypearticleoperation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypearticleoperations;
    }


        
    }
}
