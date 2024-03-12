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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCommune" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCommune.svc ou wsCommune.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCommune : IwsCommune
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCommuneWSBLL clsCommuneWSBLL = new clsCommuneWSBLL();

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
    public List<HT_Stock.BOJ.clsCommune> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCommune> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCommunes = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCommunes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCommunes;
            //--TEST CONTRAINTE
            clsCommunes = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCommunes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCommunes;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].VL_CODEVILLE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCommuneWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
                    clsCommune.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                    clsCommune.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                    clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                    clsCommune.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCommune.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCommunes.Add(clsCommune);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCommune.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCommune.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCommunes.Add(clsCommune);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCommune.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCommune.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            clsCommunes.Add(clsCommune);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCommune.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCommune.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            clsCommunes.Add(clsCommune);
        }




        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCommunes;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCommune> pvgChargerDansDataSetPourComboSelonZoneCommercial(List<HT_Stock.BOJ.clsCommune> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCommunes = TestChampObligatoireListeSelonZone(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCommunes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCommunes;
            //--TEST CONTRAINTE
            clsCommunes = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCommunes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCommunes;
        }

            //"@VL_CODEVILLE", "@ZN_CODEZONE", "@CODECRYPTAGE"
        clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].VL_CODEVILLE ,Objet[0].ZN_CODEZONE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCommuneWSBLL.pvgChargerDansDataSetPourComboSelonZoneCommercial(clsDonnee, clsObjetEnvoi);
            clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
                    clsCommune.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                    clsCommune.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                    clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                    clsCommune.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCommune.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCommunes.Add(clsCommune);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCommune.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCommune.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCommunes.Add(clsCommune);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCommune.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCommune.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            clsCommunes.Add(clsCommune);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCommune.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCommune.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            clsCommunes.Add(clsCommune);
        }




        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCommunes;
        }
        
    }
}
