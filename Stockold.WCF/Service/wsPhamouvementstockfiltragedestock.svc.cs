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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhamouvementstockfiltragedestock" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhamouvementstockfiltragedestock.svc ou wsPhamouvementstockfiltragedestock.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhamouvementstockfiltragedestock : IwsPhamouvementstockfiltragedestock
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhamouvementstockfiltragedestockWSBLL clsPhamouvementstockfiltragedestockWSBLL = new clsPhamouvementstockfiltragedestockWSBLL();

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
        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhamouvementstockfiltragedestocks = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockfiltragedestocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockfiltragedestocks;
        //    //--TEST CONTRAINTE
        //    clsPhamouvementstockfiltragedestocks = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockfiltragedestocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockfiltragedestocks;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockfiltragedestockWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();
                    clsPhamouvementstockfiltragedestock.MF_IDFILTRAGEDESTOCK = row["MF_IDFILTRAGEDESTOCK"].ToString();
                    clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK = row["MF_NUMEROLOTFILTRAGEDESTOCK"].ToString();
                    clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();
            clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();
            clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockfiltragedestocks;
    }


        
    }
}
