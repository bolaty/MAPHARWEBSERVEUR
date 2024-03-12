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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsClipartypejourfacturation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsClipartypejourfacturation.svc ou wsClipartypejourfacturation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsClipartypejourfacturation : IwsClipartypejourfacturation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsClipartypejourfacturationWSBLL clsClipartypejourfacturationWSBLL = new clsClipartypejourfacturationWSBLL();

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
        public List<HT_Stock.BOJ.clsClipartypejourfacturation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsClipartypejourfacturation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsClipartypejourfacturation> clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsClipartypejourfacturations = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClipartypejourfacturations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypejourfacturations;
        //    //--TEST CONTRAINTE
        //    clsClipartypejourfacturations = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsClipartypejourfacturations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsClipartypejourfacturations;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsClipartypejourfacturationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();
                    clsClipartypejourfacturation.JF_CODETYPEJOURFACTURATION = row["JF_CODETYPEJOURFACTURATION"].ToString();
                    clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION = row["JF_LIBELLETYPEJOURFACTURATION"].ToString();
                    clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                    clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();
            clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();
            clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsClipartypejourfacturations;
    }


        
    }
}
