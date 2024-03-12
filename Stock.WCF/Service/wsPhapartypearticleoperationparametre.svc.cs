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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypearticleoperationparametre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypearticleoperationparametre.svc ou wsPhapartypearticleoperationparametre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypearticleoperationparametre : IwsPhapartypearticleoperationparametre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypearticleoperationparametreWSBLL clsPhapartypearticleoperationparametreWSBLL = new clsPhapartypearticleoperationparametreWSBLL();

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
    public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsPhapartypearticleoperationparametres = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsPhapartypearticleoperationparametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticleoperationparametres;
            //--TEST CONTRAINTE
          //  clsPhapartypearticleoperationparametres = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsPhapartypearticleoperationparametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticleoperationparametres;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypearticleoperationparametreWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
                    clsPhapartypearticleoperationparametre.TO_CODEOPERATION = row["TO_CODEOPERATION"].ToString();
                    clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE = row["TO_CODEOPERATIONPARAMETRE"].ToString();
                    //clsPhapartypearticleoperationparametre.NC_NUMEROORDRE = row["NC_NUMEROORDRE"].ToString();

                    clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
            clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
            clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypearticleoperationparametres;
    }

    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> pvgChargerDansDataSetModel(List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticleoperationparametres = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticleoperationparametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticleoperationparametres;
                //--TEST CONTRAINTE
                clsPhapartypearticleoperationparametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticleoperationparametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticleoperationparametres;
            }

      
    clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].TO_CODEOPERATION };
    DataSet DataSet = new DataSet();

    try
    {
        clsDonnee.pvgConnectionBase();
        DataSet = clsPhapartypearticleoperationparametreWSBLL.pvgChargerDansDataSetModel(clsDonnee, clsObjetEnvoi);
        clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
                clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE = row["TO_CODEOPERATIONPARAMETRE"].ToString();
                clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE = row["CP_CODEOPERATIONLIBELLECPTE"].ToString();
                clsPhapartypearticleoperationparametre.CP_LIBELLE = row["CP_LIBELLE"].ToString();
                clsPhapartypearticleoperationparametre.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            }
        }
        else
        {
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
            clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
        }
                


    }
    catch (SqlException SQLEx)
    {
        HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
        clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
        clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
        clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
    }
    catch (Exception SQLEx)
    {
        HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();
        clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
        clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
        clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
    }


    finally
    {
        clsDonnee.pvgDeConnectionBase();
    }
    return clsPhapartypearticleoperationparametres;
    }
        
    }
}
