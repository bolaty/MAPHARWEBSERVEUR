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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparprimerisqueassuranceliaison" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparprimerisqueassuranceliaison.svc ou wsCtparprimerisqueassuranceliaison.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparprimerisqueassuranceliaison : IwsCtparprimerisqueassuranceliaison
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparprimerisqueassuranceliaisonWSBLL clsCtparprimerisqueassuranceliaisonWSBLL = new clsCtparprimerisqueassuranceliaisonWSBLL();

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
    public List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtparprimerisqueassuranceliaisons = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtparprimerisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparprimerisqueassuranceliaisons;
            //--TEST CONTRAINTE
            clsCtparprimerisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtparprimerisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparprimerisqueassuranceliaisons;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].RQ_CODERISQUE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparprimerisqueassuranceliaisonWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();
                    clsCtparprimerisqueassuranceliaison.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtparprimerisqueassuranceliaison.RE_CODERESUME = row["RE_CODERESUME"].ToString();
                    clsCtparprimerisqueassuranceliaison.RE_LIBELLERESUME = row["RE_LIBELLERESUME"].ToString();
                    clsCtparprimerisqueassuranceliaison.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                    clsCtparprimerisqueassuranceliaison.CG_CAPITAUXASSURES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_CAPITAUXASSURES"].ToString()).ToString(), "M");
                    clsCtparprimerisqueassuranceliaison.CG_PRIMES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_PRIMES"].ToString()).ToString(), "M");
                    clsCtparprimerisqueassuranceliaison.CG_APRESREDUCTION = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_APRESREDUCTION"].ToString()).ToString(), "M");
                    clsCtparprimerisqueassuranceliaison.CG_PRORATA = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_PRORATA"].ToString()).ToString(), "M");
                    clsCtparprimerisqueassuranceliaison.CG_FRANCHISES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_FRANCHISES"].ToString()).ToString(), "M");
                    clsCtparprimerisqueassuranceliaison.CG_TAUX = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_TAUX"].ToString()).ToString(), "M");
                    clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();
                clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
            clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
            clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
        }



        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparprimerisqueassuranceliaisons;
    }


        
    }
}
