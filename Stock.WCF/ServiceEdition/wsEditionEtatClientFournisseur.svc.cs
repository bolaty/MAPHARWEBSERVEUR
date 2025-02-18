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
using System.Web.Script.Serialization;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatClientFournisseur" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatClientFournisseur.svc ou wsEditionEtatClientFournisseur.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatClientFournisseur : IwsEditionEtatClientFournisseur
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatClientFournisseurWSBLL clsEditionEtatClientFournisseurWSBLL = new clsEditionEtatClientFournisseurWSBLL();

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
    public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatNatureTiers(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        clsEditionEtatClientFournisseur1.TP_CODETYPECLIENT = clsEditionEtatClientFournisseurDTO.TP_CODETYPECLIENT.ToString();
        clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
       

    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatNatureTiers(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
        clsEditionEtatClientFournisseur.TP_LIBELLE = row["TP_LIBELLE"].ToString();
        clsEditionEtatClientFournisseur.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
        clsEditionEtatClientFournisseur.NT_LIBELLE = row["NT_LIBELLE"].ToString();
        clsEditionEtatClientFournisseur.NT_DESCRIPTION = row["NT_DESCRIPTION"].ToString();
        clsEditionEtatClientFournisseur.NT_NUMEROORDRE = row["NT_NUMEROORDRE"].ToString();
        clsEditionEtatClientFournisseur.NT_INVENTAIRE = row["NT_INVENTAIRE"].ToString();


        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }

    public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatListeTiers(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeEntrepot(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
       

    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeTiers(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
        clsEditionEtatClientFournisseur.TP_LIBELLE = row["TP_LIBELLE"].ToString();
        clsEditionEtatClientFournisseur.TP_DESCRIPTION = row["TP_DESCRIPTION"].ToString();
        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }

    public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatListeVehicule(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeVpehicule(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
            clsEditionEtatClientFournisseur1.AG_CODEAGENCE = clsEditionEtatClientFournisseurDTO.AG_CODEAGENCE.ToString();
            clsEditionEtatClientFournisseur1.EN_CODEENTREPOT = clsEditionEtatClientFournisseurDTO.EN_CODEENTREPOT.ToString();
            clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
            clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
            clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeVehicule(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
        clsEditionEtatClientFournisseur.VH_CODEVEHICULE = row["VH_CODEVEHICULE"].ToString();
        clsEditionEtatClientFournisseur.VH_MATRICULE = row["VH_MATRICULE"].ToString();
        clsEditionEtatClientFournisseur.TVH_CODETYPE = row["TVH_CODETYPE"].ToString();
        clsEditionEtatClientFournisseur.TVH_LIBELE = row["TVH_LIBELE"].ToString();

        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }





 public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatClientFournisseur(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeEntrepot(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        clsEditionEtatClientFournisseur1.AG_CODEAGENCE = clsEditionEtatClientFournisseurDTO.AG_CODEAGENCE.ToString();
        clsEditionEtatClientFournisseur1.EN_CODEENTREPOT = clsEditionEtatClientFournisseurDTO.EN_CODEENTREPOT.ToString();
        clsEditionEtatClientFournisseur1.GP_CODEGROUPE = clsEditionEtatClientFournisseurDTO.GP_CODEGROUPE.ToString();
        clsEditionEtatClientFournisseur1.OP_CODEOPERATEUREDITION = clsEditionEtatClientFournisseurDTO.OP_CODEOPERATEUREDITION.ToString();
        clsEditionEtatClientFournisseur1.TP_CODETYPECLIENT = clsEditionEtatClientFournisseurDTO.TP_CODETYPECLIENT.ToString();
        clsEditionEtatClientFournisseur1.TC_CODECOMPTETYPETIERS = clsEditionEtatClientFournisseurDTO.TC_CODECOMPTETYPETIERS.ToString();
        clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS1 = clsEditionEtatClientFournisseurDTO.DATEDEBUT.ToString();
        clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS2 = clsEditionEtatClientFournisseurDTO.DATEFIN.ToString();
        clsEditionEtatClientFournisseur1.TI_TVA = clsEditionEtatClientFournisseurDTO.TI_TVA.ToString();
        clsEditionEtatClientFournisseur1.TI_ASDI = clsEditionEtatClientFournisseurDTO.TI_ASDI.ToString();
        clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsEditionEtatClientFournisseur1.SC_CODESECTION = clsEditionEtatClientFournisseurDTO.SC_CODESECTION.ToString();
        clsEditionEtatClientFournisseur1.PY_CODEPAYS = clsEditionEtatClientFournisseurDTO.PY_CODEPAYS.ToString();
        clsEditionEtatClientFournisseur1.NT_CODENATURETIERS = clsEditionEtatClientFournisseurDTO.NT_CODENATURETIERS.ToString();


        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
       

    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatClientFournisseur(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
        if (Objet[0].ET_TYPEETAT == "LTI") {

                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            // Vérifiez si l'objet avec ce TI_IDTIERS existe déjà dans la liste
                            string tiIdTiers = row["TI_IDTIERS"].ToString();
                            string tiCODERISQUE = row["RQ_CODERISQUE"].ToString();
                            var existingClient = clsEditionEtatClientFournisseurs.FirstOrDefault(client => client.TI_IDTIERS == tiIdTiers);

                            // Si l'objet n'existe pas, créez un nouveau et ajoutez-le à la liste
                            if (existingClient == null)
                            {

                                HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
                                clsEditionEtatClientFournisseur.CL_IDCLIENT = row["CL_IDCLIENT"].ToString();
                                clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                                clsEditionEtatClientFournisseur.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                                clsEditionEtatClientFournisseur.SM_CODESITUATIONMATRIMONIALE = row["SM_CODESITUATIONMATRIMONIALE"].ToString();
                                clsEditionEtatClientFournisseur.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                                clsEditionEtatClientFournisseur.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                                clsEditionEtatClientFournisseur.TP_CODETYPECLIENT = row["TP_CODETYPECLIENT"].ToString();
                                clsEditionEtatClientFournisseur.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                                clsEditionEtatClientFournisseur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                                clsEditionEtatClientFournisseur.CL_NUMCLIENT = row["CL_NUMCLIENT"].ToString();
                                clsEditionEtatClientFournisseur.CL_DATENAISSANCE = (row["CL_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["CL_DATENAISSANCE"].ToString()).ToShortDateString() : "01/01/1900";//DateTime.Parse( row["CL_DATENAISSANCE"].ToString()).ToShortDateString();
                                clsEditionEtatClientFournisseur.CL_DENOMINATION = row["CL_DENOMINATION"].ToString();
                                clsEditionEtatClientFournisseur.CL_DESCRIPTIONCLIENT = row["CL_DESCRIPTIONCLIENT"].ToString();
                                clsEditionEtatClientFournisseur.CL_ADRESSEPOSTALE = row["CL_ADRESSEPOSTALE"].ToString();
                                clsEditionEtatClientFournisseur.CL_ADRESSEGEOGRAPHIQUE = row["CL_ADRESSEGEOGRAPHIQUE"].ToString();
                                clsEditionEtatClientFournisseur.CL_TELEPHONE = row["CL_TELEPHONE"].ToString();
                                clsEditionEtatClientFournisseur.CL_FAX = row["CL_FAX"].ToString();
                                clsEditionEtatClientFournisseur.CL_SITEWEB = row["CL_SITEWEB"].ToString();
                                clsEditionEtatClientFournisseur.CL_EMAIL = row["CL_EMAIL"].ToString();
                                clsEditionEtatClientFournisseur.CL_GERANT = row["CL_GERANT"].ToString();
                                clsEditionEtatClientFournisseur.CL_STATUT = row["CL_STATUT"].ToString();
                                clsEditionEtatClientFournisseur.CL_DATESAISIE = (row["CL_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CL_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";// DateTime.Parse(row["CL_DATESAISIE"].ToString()).ToShortDateString();
                                clsEditionEtatClientFournisseur.CL_DATEDEPART = (row["CL_DATEDEPART"].ToString() != "") ? DateTime.Parse(row["CL_DATEDEPART"].ToString()).ToShortDateString() : "01/01/1900";// DateTime.Parse(row["CL_DATEDEPART"].ToString()).ToShortDateString();
                                clsEditionEtatClientFournisseur.CL_ASDI = row["CL_ASDI"].ToString();
                                clsEditionEtatClientFournisseur.CL_TVA = row["CL_TVA"].ToString();
                                clsEditionEtatClientFournisseur.CL_STATUTDOUTEUX = (row["CL_STATUTDOUTEUX"].ToString() != "") ? double.Parse(row["CL_STATUTDOUTEUX"].ToString()) : 0;//row["CL_STATUTDOUTEUX"].ToString();
                                clsEditionEtatClientFournisseur.CL_PLAFONDCREDIT = (row["CL_PLAFONDCREDIT"].ToString() != "") ? double.Parse(row["CL_PLAFONDCREDIT"].ToString()) : 0;// double.Parse(row["CL_PLAFONDCREDIT"].ToString()).ToString();
                                clsEditionEtatClientFournisseur.CL_NUMCPTECONTIBUABLE = row["CL_NUMCPTECONTIBUABLE"].ToString();
                                clsEditionEtatClientFournisseur.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                                clsEditionEtatClientFournisseur.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                                clsEditionEtatClientFournisseur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                                clsEditionEtatClientFournisseur.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                                clsEditionEtatClientFournisseur.TI_DATENAISSANCE = (row["TI_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["TI_DATENAISSANCE"].ToString()).ToShortDateString() : "01/01/1900";// DateTime.Parse(row["TI_DATENAISSANCE"].ToString()).ToShortDateString();
                                clsEditionEtatClientFournisseur.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                                clsEditionEtatClientFournisseur.TI_DESCRIPTIONTIERS = row["TI_DESCRIPTIONTIERS"].ToString();
                                clsEditionEtatClientFournisseur.TI_ADRESSEPOSTALE = row["TI_ADRESSEPOSTALE"].ToString();
                                clsEditionEtatClientFournisseur.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                                clsEditionEtatClientFournisseur.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                                clsEditionEtatClientFournisseur.TI_FAX = row["TI_FAX"].ToString();
                                clsEditionEtatClientFournisseur.TI_SITEWEB = row["TI_SITEWEB"].ToString();
                                clsEditionEtatClientFournisseur.TI_EMAIL = row["TI_EMAIL"].ToString();
                                clsEditionEtatClientFournisseur.TI_GERANT = row["TI_GERANT"].ToString();
                                clsEditionEtatClientFournisseur.TI_STATUT = row["TI_STATUT"].ToString();
                                clsEditionEtatClientFournisseur.TI_DATESAISIE = (row["TI_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["TI_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";//  DateTime.Parse(row["TI_DATESAISIE"].ToString()).ToShortDateString();
                                clsEditionEtatClientFournisseur.TI_DATEDEPART = (row["TI_DATEDEPART"].ToString() != "") ? DateTime.Parse(row["TI_DATEDEPART"].ToString()).ToShortDateString() : "01/01/1900";//  DateTime.Parse(row["TI_DATEDEPART"].ToString()).ToShortDateString();
                                if (row["RQ_CODERISQUE"].ToString() == "04")
                                {
                                    clsEditionEtatClientFournisseur.TI_ASDI = "RV";
                                }
                                else
                                {
                                    clsEditionEtatClientFournisseur.TI_ASDI = "RD";
                                }
                                //clsEditionEtatClientFournisseur.TI_ASDI = row["RQ_CODERISQUE"].ToString(); //row["TI_ASDI"].ToString();
                                clsEditionEtatClientFournisseur.TI_TVA = row["VL_LIBELLE"].ToString();
                                clsEditionEtatClientFournisseur.TI_STATUTDOUTEUX = row["TI_STATUTDOUTEUX"].ToString();
                                clsEditionEtatClientFournisseur.TI_PLAFONDCREDIT = (row["TI_PLAFONDCREDIT"].ToString() != "") ? double.Parse(row["TI_PLAFONDCREDIT"].ToString()) : 0;//double.Parse( row["TI_PLAFONDCREDIT"].ToString()).ToString();
                                clsEditionEtatClientFournisseur.TI_NUMCPTECONTIBUABLE = row["TI_NUMCPTECONTIBUABLE"].ToString();
                                clsEditionEtatClientFournisseur.TI_TAUXREMISE = row["TI_TAUXREMISE"].ToString();
                                clsEditionEtatClientFournisseur.TI_SOLDE = (row["TI_SOLDE"].ToString() != "") ? double.Parse(row["TI_SOLDE"].ToString()) : 0;// double.Parse(row["TI_SOLDE"].ToString()).ToString();
                                clsEditionEtatClientFournisseur.TI_CHIFFREAFFAIRE = (row["TI_CHIFFREAFFAIRE"].ToString() != "") ? double.Parse(row["TI_CHIFFREAFFAIRE"].ToString()) : 0;// double.Parse(row["TI_CHIFFREAFFAIRE"].ToString()).ToString();
                                clsEditionEtatClientFournisseur.FR_CODEFOURNISSEUR = row["FR_CODEFOURNISSEUR"].ToString();
                                clsEditionEtatClientFournisseur.TF_CODETYPEFOURNISSEUR = row["TF_CODETYPEFOURNISSEUR"].ToString();
                                clsEditionEtatClientFournisseur.TF_LIBELLE = row["TF_LIBELLE"].ToString();
                                clsEditionEtatClientFournisseur.FR_MATRICULE = row["FR_MATRICULE"].ToString();
                                clsEditionEtatClientFournisseur.FR_DENOMINATION = row["FR_DENOMINATION"].ToString();
                                clsEditionEtatClientFournisseur.FR_SIEGE = row["FR_SIEGE"].ToString();
                                clsEditionEtatClientFournisseur.FR_ADRESSEPOSTALE = row["FR_ADRESSEPOSTALE"].ToString();
                                clsEditionEtatClientFournisseur.FR_ADRESSEGEOGRAPHIQUE = row["FR_ADRESSEGEOGRAPHIQUE"].ToString();
                                clsEditionEtatClientFournisseur.FR_TELEPHONE = row["FR_TELEPHONE"].ToString();
                                clsEditionEtatClientFournisseur.FR_SITEWEB = row["FR_SITEWEB"].ToString();
                                clsEditionEtatClientFournisseur.FR_EMAIL = row["FR_EMAIL"].ToString();
                                clsEditionEtatClientFournisseur.FR_GERANT = row["FR_GERANT"].ToString();
                                clsEditionEtatClientFournisseur.FR_STATUT = row["FR_STATUT"].ToString();
                                clsEditionEtatClientFournisseur.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                                clsEditionEtatClientFournisseur.CO_LIBELLE = row["PF_LIBELLE"].ToString();// row["CO_LIBELLE"].ToString();
                                clsEditionEtatClientFournisseur.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "00";
                                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);



                            }
                            else 
                            {
                                foreach (var client in clsEditionEtatClientFournisseurs)
                                {
                                    // Vérifie si le client existe déjà et que le tiCODERISQUE est "04"
                                    if (client.TI_IDTIERS == tiIdTiers)
                                    {
                                        // Mettre à jour le TI_STATUT à "RV"
                                        client.TI_STATUT = "RD";
                                    }
                                }
                            }/*else if (existingClient != null && tiCODERISQUE == "04")
                            {
                                foreach (var client in clsEditionEtatClientFournisseurs)
                                {
                                    // Vérifie si le client existe déjà et que le tiCODERISQUE est "04"
                                    if (client.TI_IDTIERS == tiIdTiers && tiCODERISQUE == "04")
                                    {
                                        // Mettre à jour le TI_STATUT à "RV"
                                        client.TI_STATUT = "RV";
                                    }
                                }
                            }*/

                        }
                    }
                    else
                    {
                        foreach (DataRow row in DataSet.Tables[0].Rows)
                        {
                            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
                            clsEditionEtatClientFournisseur.CL_IDCLIENT = row["CL_IDCLIENT"].ToString();
                            clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsEditionEtatClientFournisseur.SX_CODESEXE = row["SX_CODESEXE"].ToString();
                            clsEditionEtatClientFournisseur.SM_CODESITUATIONMATRIMONIALE = row["SM_CODESITUATIONMATRIMONIALE"].ToString();
                            clsEditionEtatClientFournisseur.PF_CODEPROFESSION = row["PF_CODEPROFESSION"].ToString();
                            clsEditionEtatClientFournisseur.AC_CODEACTIVITE = row["AC_CODEACTIVITE"].ToString();
                            clsEditionEtatClientFournisseur.TP_CODETYPECLIENT = row["TP_CODETYPECLIENT"].ToString();
                            clsEditionEtatClientFournisseur.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                            clsEditionEtatClientFournisseur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                            clsEditionEtatClientFournisseur.CL_NUMCLIENT = row["CL_NUMCLIENT"].ToString();
                            clsEditionEtatClientFournisseur.CL_DATENAISSANCE = (row["CL_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["CL_DATENAISSANCE"].ToString()).ToShortDateString() : "01/01/1900";//DateTime.Parse( row["CL_DATENAISSANCE"].ToString()).ToShortDateString();
                            clsEditionEtatClientFournisseur.CL_DENOMINATION = row["CL_DENOMINATION"].ToString();
                            clsEditionEtatClientFournisseur.CL_DESCRIPTIONCLIENT = row["CL_DESCRIPTIONCLIENT"].ToString();
                            clsEditionEtatClientFournisseur.CL_ADRESSEPOSTALE = row["CL_ADRESSEPOSTALE"].ToString();
                            clsEditionEtatClientFournisseur.CL_ADRESSEGEOGRAPHIQUE = row["CL_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsEditionEtatClientFournisseur.CL_TELEPHONE = row["CL_TELEPHONE"].ToString();
                            clsEditionEtatClientFournisseur.CL_FAX = row["CL_FAX"].ToString();
                            clsEditionEtatClientFournisseur.CL_SITEWEB = row["CL_SITEWEB"].ToString();
                            clsEditionEtatClientFournisseur.CL_EMAIL = row["CL_EMAIL"].ToString();
                            clsEditionEtatClientFournisseur.CL_GERANT = row["CL_GERANT"].ToString();
                            clsEditionEtatClientFournisseur.CL_STATUT = row["CL_STATUT"].ToString();
                            clsEditionEtatClientFournisseur.CL_DATESAISIE = (row["CL_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CL_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";// DateTime.Parse(row["CL_DATESAISIE"].ToString()).ToShortDateString();
                            clsEditionEtatClientFournisseur.CL_DATEDEPART = (row["CL_DATEDEPART"].ToString() != "") ? DateTime.Parse(row["CL_DATEDEPART"].ToString()).ToShortDateString() : "01/01/1900";// DateTime.Parse(row["CL_DATEDEPART"].ToString()).ToShortDateString();
                            clsEditionEtatClientFournisseur.CL_ASDI = row["CL_ASDI"].ToString();
                            clsEditionEtatClientFournisseur.CL_TVA = row["CL_TVA"].ToString();
                            clsEditionEtatClientFournisseur.CL_STATUTDOUTEUX = (row["CL_STATUTDOUTEUX"].ToString() != "") ? double.Parse(row["CL_STATUTDOUTEUX"].ToString()) : 0;//row["CL_STATUTDOUTEUX"].ToString();
                            clsEditionEtatClientFournisseur.CL_PLAFONDCREDIT = (row["CL_PLAFONDCREDIT"].ToString() != "") ? double.Parse(row["CL_PLAFONDCREDIT"].ToString()) : 0;// double.Parse(row["CL_PLAFONDCREDIT"].ToString()).ToString();
                            clsEditionEtatClientFournisseur.CL_NUMCPTECONTIBUABLE = row["CL_NUMCPTECONTIBUABLE"].ToString();
                            clsEditionEtatClientFournisseur.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                            clsEditionEtatClientFournisseur.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                            clsEditionEtatClientFournisseur.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                            clsEditionEtatClientFournisseur.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                            clsEditionEtatClientFournisseur.TI_DATENAISSANCE = (row["TI_DATENAISSANCE"].ToString() != "") ? DateTime.Parse(row["TI_DATENAISSANCE"].ToString()).ToShortDateString() : "01/01/1900";// DateTime.Parse(row["TI_DATENAISSANCE"].ToString()).ToShortDateString();
                            clsEditionEtatClientFournisseur.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                            clsEditionEtatClientFournisseur.TI_DESCRIPTIONTIERS = row["TI_DESCRIPTIONTIERS"].ToString();
                            clsEditionEtatClientFournisseur.TI_ADRESSEPOSTALE = row["TI_ADRESSEPOSTALE"].ToString();
                            clsEditionEtatClientFournisseur.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsEditionEtatClientFournisseur.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                            clsEditionEtatClientFournisseur.TI_FAX = row["TI_FAX"].ToString();
                            clsEditionEtatClientFournisseur.TI_SITEWEB = row["TI_SITEWEB"].ToString();
                            clsEditionEtatClientFournisseur.TI_EMAIL = row["TI_EMAIL"].ToString();
                            clsEditionEtatClientFournisseur.TI_GERANT = row["TI_GERANT"].ToString();
                            clsEditionEtatClientFournisseur.TI_STATUT = row["TI_STATUT"].ToString();
                            clsEditionEtatClientFournisseur.TI_DATESAISIE = (row["TI_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["TI_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";//  DateTime.Parse(row["TI_DATESAISIE"].ToString()).ToShortDateString();
                            clsEditionEtatClientFournisseur.TI_DATEDEPART = (row["TI_DATEDEPART"].ToString() != "") ? DateTime.Parse(row["TI_DATEDEPART"].ToString()).ToShortDateString() : "01/01/1900";//  DateTime.Parse(row["TI_DATEDEPART"].ToString()).ToShortDateString();
                            clsEditionEtatClientFournisseur.TI_ASDI = row["TI_ASDI"].ToString();
                            clsEditionEtatClientFournisseur.TI_TVA = row["VL_LIBELLE"].ToString();
                            clsEditionEtatClientFournisseur.TI_STATUTDOUTEUX = row["TI_STATUTDOUTEUX"].ToString();
                            clsEditionEtatClientFournisseur.TI_PLAFONDCREDIT = (row["TI_PLAFONDCREDIT"].ToString() != "") ? double.Parse(row["TI_PLAFONDCREDIT"].ToString()) : 0;//double.Parse( row["TI_PLAFONDCREDIT"].ToString()).ToString();
                            clsEditionEtatClientFournisseur.TI_NUMCPTECONTIBUABLE = row["TI_NUMCPTECONTIBUABLE"].ToString();
                            clsEditionEtatClientFournisseur.TI_TAUXREMISE = row["TI_TAUXREMISE"].ToString();
                            clsEditionEtatClientFournisseur.TI_SOLDE = (row["TI_SOLDE"].ToString() != "") ? double.Parse(row["TI_SOLDE"].ToString()) : 0;// double.Parse(row["TI_SOLDE"].ToString()).ToString();
                            clsEditionEtatClientFournisseur.TI_CHIFFREAFFAIRE = (row["TI_CHIFFREAFFAIRE"].ToString() != "") ? double.Parse(row["TI_CHIFFREAFFAIRE"].ToString()) : 0;// double.Parse(row["TI_CHIFFREAFFAIRE"].ToString()).ToString();
                            clsEditionEtatClientFournisseur.FR_CODEFOURNISSEUR = row["FR_CODEFOURNISSEUR"].ToString();
                            clsEditionEtatClientFournisseur.TF_CODETYPEFOURNISSEUR = row["TF_CODETYPEFOURNISSEUR"].ToString();
                            clsEditionEtatClientFournisseur.TF_LIBELLE = row["TF_LIBELLE"].ToString();
                            clsEditionEtatClientFournisseur.FR_MATRICULE = row["FR_MATRICULE"].ToString();
                            clsEditionEtatClientFournisseur.FR_DENOMINATION = row["FR_DENOMINATION"].ToString();
                            clsEditionEtatClientFournisseur.FR_SIEGE = row["FR_SIEGE"].ToString();
                            clsEditionEtatClientFournisseur.FR_ADRESSEPOSTALE = row["FR_ADRESSEPOSTALE"].ToString();
                            clsEditionEtatClientFournisseur.FR_ADRESSEGEOGRAPHIQUE = row["FR_ADRESSEGEOGRAPHIQUE"].ToString();
                            clsEditionEtatClientFournisseur.FR_TELEPHONE = row["FR_TELEPHONE"].ToString();
                            clsEditionEtatClientFournisseur.FR_SITEWEB = row["FR_SITEWEB"].ToString();
                            clsEditionEtatClientFournisseur.FR_EMAIL = row["FR_EMAIL"].ToString();
                            clsEditionEtatClientFournisseur.FR_GERANT = row["FR_GERANT"].ToString();
                            clsEditionEtatClientFournisseur.FR_STATUT = row["FR_STATUT"].ToString();
                            clsEditionEtatClientFournisseur.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                            clsEditionEtatClientFournisseur.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                            clsEditionEtatClientFournisseur.SX_LIBELLE = row["SX_LIBELLE"].ToString();
                            clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "00";
                            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                        }
                    }
        
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }

    public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatListeChauffeur(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeChauffeur(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        clsEditionEtatClientFournisseur1.AG_CODEAGENCE = clsEditionEtatClientFournisseurDTO.AG_CODEAGENCE.ToString();
        clsEditionEtatClientFournisseur1.EN_CODEENTREPOT = clsEditionEtatClientFournisseurDTO.EN_CODEENTREPOT.ToString();
        clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS2 = clsEditionEtatClientFournisseurDTO.DATEFIN.ToString();
        clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeChauffeur(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.CH_IDCHAUFFEUR = row["CH_IDCHAUFFEUR"].ToString();
        clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
        clsEditionEtatClientFournisseur.SX_CODESEXE = row["SX_CODESEXE"].ToString();
        clsEditionEtatClientFournisseur.SM_CODESITUATIONMATRIMONIALE = row["SM_CODESITUATIONMATRIMONIALE"].ToString();
        clsEditionEtatClientFournisseur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
        clsEditionEtatClientFournisseur.CH_NUMCHAUFFEUR = row["CH_NUMCHAUFFEUR"].ToString();
        clsEditionEtatClientFournisseur.CH_DATENAISSANCE = row["CH_DATENAISSANCE"].ToString();
        clsEditionEtatClientFournisseur.CH_NOMPRENOM = row["CH_NOMPRENOM"].ToString();
        clsEditionEtatClientFournisseur.CH_ADRESSEPOSTALE = row["CH_ADRESSEPOSTALE"].ToString();
        clsEditionEtatClientFournisseur.CH_ADRESSEGEOGRAPHIQUE = row["CH_ADRESSEGEOGRAPHIQUE"].ToString();
        clsEditionEtatClientFournisseur.CH_TELEPHONE = row["CH_TELEPHONE"].ToString();
        clsEditionEtatClientFournisseur.CH_EMAIL = row["CH_EMAIL"].ToString();
        clsEditionEtatClientFournisseur.CH_STATUT = row["CH_STATUT"].ToString();
        clsEditionEtatClientFournisseur.CH_DATESAISIE = (row["CH_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CH_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";//DateTime.Parse( row["CL_DATENAISSANCE"].ToString()).ToShortDateString();            
        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }

public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatListeCommerciaux(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeCommerciaux(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        clsEditionEtatClientFournisseur1.AG_CODEAGENCE = clsEditionEtatClientFournisseurDTO.AG_CODEAGENCE.ToString();
        clsEditionEtatClientFournisseur1.EN_CODEENTREPOT = clsEditionEtatClientFournisseurDTO.EN_CODEENTREPOT.ToString();
        clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS2 = clsEditionEtatClientFournisseurDTO.DATEFIN.ToString();
        clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
       

    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeCommerciaux(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.CO_IDCOMMERCIAL = row["CO_IDCOMMERCIAL"].ToString();
        clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
        clsEditionEtatClientFournisseur.SX_CODESEXE = row["SX_CODESEXE"].ToString();
        clsEditionEtatClientFournisseur.SM_CODESITUATIONMATRIMONIALE = row["SM_CODESITUATIONMATRIMONIALE"].ToString();
        clsEditionEtatClientFournisseur.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
        clsEditionEtatClientFournisseur.CO_NUMCOMMERCIAL = row["CO_NUMCOMMERCIAL"].ToString();
        clsEditionEtatClientFournisseur.CO_DATENAISSANCE = row["CO_DATENAISSANCE"].ToString();
        clsEditionEtatClientFournisseur.CO_NOMPRENOM = row["CO_NOMPRENOM"].ToString();
        clsEditionEtatClientFournisseur.CO_ADRESSEPOSTALE = row["CO_ADRESSEPOSTALE"].ToString();
        clsEditionEtatClientFournisseur.CO_ADRESSEGEOGRAPHIQUE = row["CO_ADRESSEGEOGRAPHIQUE"].ToString();
        clsEditionEtatClientFournisseur.CO_TELEPHONE = row["CO_TELEPHONE"].ToString();
        clsEditionEtatClientFournisseur.CO_EMAIL = row["CO_EMAIL"].ToString();
        clsEditionEtatClientFournisseur.CO_STATUT = row["CO_STATUT"].ToString();
        clsEditionEtatClientFournisseur.CO_TAUXCOMMISSION = row["CO_TAUXCOMMISSION"].ToString();
                        clsEditionEtatClientFournisseur.CO_MONTANTCOMMISSION = (row["CO_MONTANTCOMMISSION"].ToString() != "") ? double.Parse(row["CO_MONTANTCOMMISSION"].ToString()) : 0;// row["CO_MONTANTCOMMISSION"].ToString();
        clsEditionEtatClientFournisseur.CO_ENCOURS = (row["CO_ENCOURS"].ToString() != "") ? double.Parse(row["CO_ENCOURS"].ToString()) : 0;// row["CO_ENCOURS"].ToString();


                        clsEditionEtatClientFournisseur.CO_DATESAISIE = (row["CO_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CO_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";//DateTime.Parse( row["CL_DATENAISSANCE"].ToString()).ToShortDateString();            
        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }

public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatRelence(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeChauffeur(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        //"@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@GP_CODEGROUPE", "@TC_CODECOMPTETYPETIERS", "@DATEDEBUT", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT",
        clsEditionEtatClientFournisseur1.AG_CODEAGENCE = clsEditionEtatClientFournisseurDTO.AG_CODEAGENCE.ToString();
        clsEditionEtatClientFournisseur1.EN_CODEENTREPOT = clsEditionEtatClientFournisseurDTO.EN_CODEENTREPOT.ToString();
        clsEditionEtatClientFournisseur1.GP_CODEGROUPE = clsEditionEtatClientFournisseurDTO.GP_CODEGROUPE.ToString();
        clsEditionEtatClientFournisseur1.TC_CODECOMPTETYPETIERS = clsEditionEtatClientFournisseurDTO.TC_CODECOMPTETYPETIERS.ToString();
        clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS1 = clsEditionEtatClientFournisseurDTO.DATEDEBUT.ToString();
        clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS2 = clsEditionEtatClientFournisseurDTO.DATEFIN.ToString();
        clsEditionEtatClientFournisseur1.OP_CODEOPERATEUREDITION = clsEditionEtatClientFournisseurDTO.OP_CODEOPERATEUREDITION.ToString();
        clsEditionEtatClientFournisseur1.ET_TYPEETAT = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
       

    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatRelence(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
        clsEditionEtatClientFournisseur.TI_IDTIERS = row["TI_IDTIERS"].ToString();
        clsEditionEtatClientFournisseur.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
        clsEditionEtatClientFournisseur.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
        clsEditionEtatClientFournisseur.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
        clsEditionEtatClientFournisseur.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
        clsEditionEtatClientFournisseur.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
        clsEditionEtatClientFournisseur.EC_MONTANTECHEANCE = (row["EC_MONTANTECHEANCE"].ToString() != "") ? double.Parse(row["EC_MONTANTECHEANCE"].ToString()) : 0;// row["EC_MONTANTECHEANCE"].ToString();
        clsEditionEtatClientFournisseur.EC_DATEECHEANCE = row["EC_DATEECHEANCE"].ToString();
        clsEditionEtatClientFournisseur.MONTANTFACTURE = (row["MONTANTFACTURE"].ToString() != "") ? double.Parse(row["MONTANTFACTURE"].ToString()) : 0;// row["MONTANTFACTURE"].ToString();
        clsEditionEtatClientFournisseur.MONTANTAPAYER = (row["MONTANTAPAYER"].ToString() != "") ? double.Parse(row["MONTANTAPAYER"].ToString()) : 0;//row["MONTANTAPAYER"].ToString();
        clsEditionEtatClientFournisseur.MONTANTPAYER = (row["MONTANTPAYER"].ToString() != "") ? double.Parse(row["MONTANTPAYER"].ToString()) : 0;// row["MONTANTPAYER"].ToString();
        clsEditionEtatClientFournisseur.RESTEAPAYER = (row["RESTEAPAYER"].ToString() != "") ? double.Parse(row["RESTEAPAYER"].ToString()) : 0;// row["RESTEAPAYER"].ToString();
        //clsEditionEtatClientFournisseur.CO_TAUXCOMMISSION = row["CO_TAUXCOMMISSION"].ToString();
        //clsEditionEtatClientFournisseur.CO_MONTANTCOMMISSION = (row["CO_MONTANTCOMMISSION"].ToString() != "") ? double.Parse(row["CO_MONTANTCOMMISSION"].ToString()) : 0;// row["CO_MONTANTCOMMISSION"].ToString();
        //clsEditionEtatClientFournisseur.CO_ENCOURS = (row["CO_ENCOURS"].ToString() != "") ? double.Parse(row["CO_ENCOURS"].ToString()) : 0;// row["CO_ENCOURS"].ToString();


        //clsEditionEtatClientFournisseur.CO_DATESAISIE = (row["CO_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["CO_DATESAISIE"].ToString()).ToShortDateString() : "01/01/1900";//DateTime.Parse( row["CL_DATENAISSANCE"].ToString()).ToShortDateString();            
        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }




public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatTypeClient(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeEntrepot(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {
        clsEditionEtatClientFournisseur1.NT_CODENATURETIERS = clsEditionEtatClientFournisseurDTO.ET_TYPEETAT.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatTypeClient(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
        clsEditionEtatClientFournisseur.TP_LIBELLE = row["TP_LIBELLE"].ToString();
        clsEditionEtatClientFournisseur.TP_DESCRIPTION = row["TP_DESCRIPTION"].ToString();
        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }

public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatRDV(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatClientFournisseurs = TestChampObligatoireListeEntrepot(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
        //--TEST CONTRAINTE
        clsEditionEtatClientFournisseurs = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatClientFournisseurs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatClientFournisseurs;
    }
    Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur1 = new Stock.BOJ.clsEditionEtatClientFournisseur();
    foreach (HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseurDTO in Objet)
    {

             //   "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@GP_CODEGROUPE", "@MS_DATERENDEZVOUS1 ", "@MS_DATERENDEZVOUS2",
                clsEditionEtatClientFournisseur1.AG_CODEAGENCE = clsEditionEtatClientFournisseurDTO.AG_CODEAGENCE.ToString();
                clsEditionEtatClientFournisseur1.EN_CODEENTREPOT = clsEditionEtatClientFournisseurDTO.EN_CODEENTREPOT.ToString();
                clsEditionEtatClientFournisseur1.GP_CODEGROUPE = clsEditionEtatClientFournisseurDTO.GP_CODEGROUPE.ToString();
                clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS1 = clsEditionEtatClientFournisseurDTO.MS_DATERENDEZVOUS1.ToString();
                clsEditionEtatClientFournisseur1.MS_DATERENDEZVOUS2 = clsEditionEtatClientFournisseurDTO.MS_DATERENDEZVOUS2.ToString();
                clsObjetEnvoi.OE_A = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatClientFournisseurDTO.clsObjetEnvoi.OE_Y;
    }


    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();
 
    DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatRDV(clsDonnee, clsEditionEtatClientFournisseur1, clsObjetEnvoi);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
        clsEditionEtatClientFournisseur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
        clsEditionEtatClientFournisseur.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
        clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS = row["MS_DATERENDEZVOUS"].ToString();
        clsEditionEtatClientFournisseur.CL_NUMCLIENT = row["CL_NUMCLIENT"].ToString();
        clsEditionEtatClientFournisseur.CL_DENOMINATION = row["CL_DENOMINATION"].ToString();
        clsEditionEtatClientFournisseur.CL_TELEPHONE = row["CL_TELEPHONE"].ToString();
        clsEditionEtatClientFournisseur.CL_ADRESSEGEOGRAPHIQUE = row["CL_ADRESSEGEOGRAPHIQUE"].ToString();
        clsEditionEtatClientFournisseur.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
        clsEditionEtatClientFournisseur.MD_REMETTANT = row["MD_REMETTANT"].ToString();
        clsEditionEtatClientFournisseur.MS_DATEPIECE = row["MS_DATEPIECE"].ToString();
        clsEditionEtatClientFournisseur.MS_NUMSEQUENCE = row["MS_NUMSEQUENCE"].ToString();

        clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatClientFournisseurs;
    }




        public List<BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatBudget(List<BOJ.clsEditionEtatClientFournisseur> Objet)
        {
            throw new NotImplementedException();
        }

        public string ConvertDataTabletoString()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=SureshDasari;Initial Catalog=master;Integrated Security=true"))
            {
                using (SqlCommand cmd = new SqlCommand("select title=City,lat=latitude,lng=longitude,description from LocationDetails", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
        }


        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        //using System.Web.Script.Serialization;  
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }



        //  using Newtonsoft.JSON;  
        //public string DataTableToJSONWithJSONNet(DataTable table)
        //    {
        //        string JSONString = string.Empty;
        //        JSONString = JSONConvert.SerializeObject(table);
        //        return JSONString;
        //    }


        public static object DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(list);
        }


    }
}
