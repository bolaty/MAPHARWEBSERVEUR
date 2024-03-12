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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparreduction" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparreduction.svc ou wsCtparreduction.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparreduction : IwsCtparreduction
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparreductionWSBLL clsCtparreductionWSBLL = new clsCtparreductionWSBLL();

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
    public List<HT_Stock.BOJ.clsCtparreduction> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparreduction> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparreduction> clsCtparreductions = new List<HT_Stock.BOJ.clsCtparreduction>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtparreductions = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtparreductions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparreductions;
            //--TEST CONTRAINTE
            clsCtparreductions = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtparreductions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparreductions;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparreductionWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparreductions = new List<HT_Stock.BOJ.clsCtparreduction>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparreduction clsCtparreduction = new HT_Stock.BOJ.clsCtparreduction();
                    clsCtparreduction.RD_CODEREDUCTION = row["RD_CODEREDUCTION"].ToString();
                    clsCtparreduction.RD_LIBELLEREDUCTION = row["RD_LIBELLEREDUCTION"].ToString();
                    clsCtparreduction.RD_ACTIF = row["RD_ACTIF"].ToString();
                        if (row["RD_MONTANT"].ToString() != "")
                            clsCtparreduction.RD_MONTANT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["RD_MONTANT"].ToString()).ToString(), "M");// row["RD_MONTANT"].ToString();
                        if (row["RD_TAUX"].ToString() != "")
                            clsCtparreduction.RD_TAUX = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["RD_TAUX"].ToString()).ToString(), "M");// row["RD_TAUX"].ToString();
                        clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparreduction.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparreduction.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparreductions.Add(clsCtparreduction);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparreduction clsCtparreduction = new HT_Stock.BOJ.clsCtparreduction();
                clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparreduction.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparreduction.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparreductions.Add(clsCtparreduction);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparreduction clsCtparreduction = new HT_Stock.BOJ.clsCtparreduction();
            clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparreduction.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparreduction.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparreductions = new List<HT_Stock.BOJ.clsCtparreduction>();
            clsCtparreductions.Add(clsCtparreduction);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparreduction clsCtparreduction = new HT_Stock.BOJ.clsCtparreduction();
            clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparreduction.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparreduction.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparreductions = new List<HT_Stock.BOJ.clsCtparreduction>();
            clsCtparreductions.Add(clsCtparreduction);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparreductions;
    }


        
    }
}
