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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOption" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOption.svc ou wsOption.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOption : IwsOption
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        //private clsOptionWSBLL clsOptionWSBLL = new clsOptionWSBLL();

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
        public List<HT_Stock.BOJ.clsOption> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOption> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOption> clsOptions = new List<HT_Stock.BOJ.clsOption>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOptions = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOptions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOptions;
                //--TEST CONTRAINTE
               // clsOptions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOptions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOptions;
            }


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
                if(Objet[0].TYPEOPERATION == "02")
                {
                    DataSet.Tables[0].Rows.Add("01", "Tous les comptes");
                    DataSet.Tables[0].Rows.Add("02", "Comptes mouvementés");
                    DataSet.Tables[0].Rows.Add("03", "Comptes individuels");
                    DataSet.Tables[0].Rows.Add("04", "Comptes collectifs");
                    DataSet.Tables[0].Rows.Add("05", "Comptes individuels mouvementés");
                }

                if (Objet[0].TYPEOPERATION == "03")
                {
                    DataSet.Tables[0].Rows.Add("SOLDE", "SOLDE");
                    DataSet.Tables[0].Rows.Add("NONSOLDE", "NON SOLDE");
                   
                }

                //DataSet.Tables[0].Rows.Add("02", "Comptes mouvementés");




                clsOptions = new List<HT_Stock.BOJ.clsOption>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOption clsOption = new HT_Stock.BOJ.clsOption();
                    clsOption.RS_CODERUBRIQUE = row["RS_CODERUBRIQUE"].ToString();
                    clsOption.RS_LIBELLE = row["RS_LIBELLE"].ToString();
                    clsOption.clsObjetRetour = new Common.clsObjetRetour();
                    clsOption.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOption.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOption.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOptions.Add(clsOption);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOption clsOption = new HT_Stock.BOJ.clsOption();
                clsOption.clsObjetRetour = new Common.clsObjetRetour();
                clsOption.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOption.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOption.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOptions.Add(clsOption);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOption clsOption = new HT_Stock.BOJ.clsOption();
            clsOption.clsObjetRetour = new Common.clsObjetRetour();
            clsOption.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOption.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOption.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOptions = new List<HT_Stock.BOJ.clsOption>();
            clsOptions.Add(clsOption);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOption clsOption = new HT_Stock.BOJ.clsOption();
            clsOption.clsObjetRetour = new Common.clsObjetRetour();
            clsOption.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOption.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOption.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOptions = new List<HT_Stock.BOJ.clsOption>();
            clsOptions.Add(clsOption);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOptions;
    }


        
    }
}
