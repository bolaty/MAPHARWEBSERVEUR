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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpargarantierisqueassuranceliaison" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpargarantierisqueassuranceliaison.svc ou wsCtpargarantierisqueassuranceliaison.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpargarantierisqueassuranceliaison : IwsCtpargarantierisqueassuranceliaison
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpargarantierisqueassuranceliaisonWSBLL clsCtpargarantierisqueassuranceliaisonWSBLL = new clsCtpargarantierisqueassuranceliaisonWSBLL();

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
    public List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> clsCtpargarantierisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtpargarantierisqueassuranceliaisons = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtpargarantierisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarantierisqueassuranceliaisons;
            //--TEST CONTRAINTE
            clsCtpargarantierisqueassuranceliaisons = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtpargarantierisqueassuranceliaisons[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpargarantierisqueassuranceliaisons;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].RQ_CODERISQUE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpargarantierisqueassuranceliaisonWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpargarantierisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison = new HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison();
                    clsCtpargarantierisqueassuranceliaison.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.GA_CODEGARANTIE = row["GA_CODEGARANTIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.GA_LIBELLEGARANTIE = row["GA_LIBELLEGARANTIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.SC_CODESOUSCATEGORIE = row["SC_CODESOUSCATEGORIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.SC_LIBELLESOUSCATEGORIE = row["SC_LIBELLESOUSCATEGORIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.CT_LIBELLECATEGORIE = row["CT_LIBELLECATEGORIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.TG_LIBELLETYPEGARANTIE = row["TG_LIBELLETYPEGARANTIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.CG_CAPITAUXASSURES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_CAPITAUXASSURES"].ToString()).ToString(),"M");
                    clsCtpargarantierisqueassuranceliaison.CG_PRIMES = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_PRIMES"].ToString()).ToString(), "M");
                    clsCtpargarantierisqueassuranceliaison.CG_APRESREDUCTION = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_APRESREDUCTION"].ToString()).ToString(), "M");
                    clsCtpargarantierisqueassuranceliaison.CG_PRORATA = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_PRORATA"].ToString()).ToString(), "M");
                    clsCtpargarantierisqueassuranceliaison.CG_FRANCHISES =row["CG_FRANCHISES"].ToString();
                    clsCtpargarantierisqueassuranceliaison.CG_TAUX = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["CG_TAUX"].ToString()).ToString(), "M");
                    clsCtpargarantierisqueassuranceliaison.CG_GARANTIE = row["CG_GARANTIE"].ToString();
                    clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison = new HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison();
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison = new HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison();
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargarantierisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison>();
            clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison = new HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison();
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpargarantierisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison>();
            clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpargarantierisqueassuranceliaisons;
    }


        
    }
}
