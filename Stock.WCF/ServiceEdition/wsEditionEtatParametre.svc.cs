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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatParametre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatParametre.svc ou wsEditionEtatParametre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatParametre : IwsEditionEtatParametre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatParametreWSBLL clsEditionEtatParametreWSBLL = new clsEditionEtatParametreWSBLL();

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
            public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatAutre(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatParametres = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
                //--TEST CONTRAINTE
                clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatAutre(clsDonnee, clsObjetEnvoi);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                    //clsEditionEtatParametre.ET_INDEX = row["ET_INDEX"].ToString();
                    //clsEditionEtatParametre.ET_LIBELLEEditionEtatParametre = row["ET_LIBELLEEditionEtatParametre"].ToString();
                    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatParametres.Add(clsEditionEtatParametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatParametres;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatPlancomptable(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatParametres = TestChampObligatoireListePlanComptable(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
                //--TEST CONTRAINTE
                clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();

            Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
                for (int Idx = 0; Idx < Objet.Count; Idx++)
                {
                    clsEditionEtatParametre1.BT_CODETYPEBUDGET = Objet[Idx].BT_CODETYPEBUDGET;
                    clsEditionEtatParametre1.ET_TYPEETAT = Objet[Idx].ET_TYPEETAT;
                }
               DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatPlancomptable(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
                clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                    clsEditionEtatParametre.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsEditionEtatParametre.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
                    clsEditionEtatParametre.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                    clsEditionEtatParametre.NC_LIBELLENATURECOMPTE = row["NC_LIBELLENATURECOMPTE"].ToString();
                    clsEditionEtatParametre.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsEditionEtatParametre.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                    clsEditionEtatParametre.PL_COMPTECOLLECTIF = row["PL_COMPTECOLLECTIF"].ToString();
                    clsEditionEtatParametre.PL_REPORTDEBIT = (row["PL_REPORTDEBIT"].ToString() != "") ? double.Parse(row["PL_REPORTDEBIT"].ToString()) : 0;// Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_REPORTDEBIT"].ToString()).ToString(),"M");
                        clsEditionEtatParametre.PL_REPORTCREDIT = (row["PL_REPORTCREDIT"].ToString() != "") ? double.Parse(row["PL_REPORTCREDIT"].ToString()) : 0;// Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_REPORTCREDIT"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_MONTANTPERIODEPRECEDENTDEBIT = (row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString()) : 0;//Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_MONTANTPERIODEPRECEDENTCREDIT = (row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString()) : 0;// Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_MONTANTPERIODEDEBITENCOURS = (row["PL_MONTANTPERIODEDEBITENCOURS"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODEDEBITENCOURS"].ToString()) : 0;//Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_MONTANTPERIODEDEBITENCOURS"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_MONTANTPERIODECREDITENCOURS = (row["PL_MONTANTPERIODECREDITENCOURS"].ToString() != "") ? double.Parse(row["PL_MONTANTPERIODECREDITENCOURS"].ToString()) : 0;// Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_MONTANTPERIODECREDITENCOURS"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_MONTANTSOLDEFINALDEBIT = (row["PL_MONTANTSOLDEFINALDEBIT"].ToString() != "") ? double.Parse(row["PL_MONTANTSOLDEFINALDEBIT"].ToString()) : 0;//Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_MONTANTSOLDEFINALDEBIT"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_MONTANTSOLDEFINALCREDIT = (row["PL_MONTANTSOLDEFINALCREDIT"].ToString() != "") ? double.Parse(row["PL_MONTANTSOLDEFINALCREDIT"].ToString()) : 0;// Stock.WSTOOLS.clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["PL_MONTANTSOLDEFINALCREDIT"].ToString()).ToString(), "M");
                        clsEditionEtatParametre.PL_SENS = row["PL_SENS"].ToString();
                    clsEditionEtatParametre.PL_TYPECOMPTE = row["PL_TYPECOMPTE"].ToString();
                    clsEditionEtatParametre.PL_ACTIF = row["PL_ACTIF"].ToString();

                    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatParametres.Add(clsEditionEtatParametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatParametres;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatEntrepot(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatParametres = TestChampObligatoireListeEntrepot(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
                //--TEST CONTRAINTE
                clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].ET_TYPEETAT };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
               DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatEntrepot(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
                clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                        clsEditionEtatParametre.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsEditionEtatParametre.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsEditionEtatParametre.EN_ADRESSEPOSTALE = row["EN_ADRESSEPOSTALE"].ToString();
                        clsEditionEtatParametre.EN_ADRESSEGEOGRAPHIQUE = row["EN_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsEditionEtatParametre.EN_TELEPHONE = row["EN_TELEPHONE"].ToString();
                        clsEditionEtatParametre.EN_FAX = row["EN_FAX"].ToString();
                        clsEditionEtatParametre.EN_EMAIL = row["EN_EMAIL"].ToString();
                        clsEditionEtatParametre.EN_GERANT = row["EN_GERANT"].ToString();
                        //private string _EN_CODEENTREPOT = "";
                        //private string _EN_DENOMINATION = "";
                        //private string _EN_ADRESSEPOSTALE = "";
                        //private string _EN_ADRESSEGEOGRAPHIQUE = "";
                        //private string _EN_TELEPHONE = "";
                        //private string _EN_FAX = "";
                        //private string _EN_EMAIL = "";
                        //private string _EN_GERANT = "";
                        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatParametres.Add(clsEditionEtatParametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatParametres;
    }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatEntrepotTEST(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatParametres = TestChampObligatoireListeEntrepot(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
                //--TEST CONTRAINTE
                clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].ET_TYPEETAT };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
                DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatEntrepot(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
                clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {


                    string reportPath = "~/Etats/"+ Objet[0].ET_DOSSIER;
                    string reportFileName = Objet[0].ET_NOMETAT;// "YTDVarianceCrossTab.rpt";
                    string exportFilename = "";
                    string URL_ETAT = "";

                    URL_ETAT = Stock.WCF.Utilities.CrystalReport.RenderReport( reportPath,  reportFileName,  exportFilename,  DataSet, Objet[0].vappNomFormule, Objet[0].vappValeurFormule);

                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                        clsEditionEtatParametre.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                        clsEditionEtatParametre.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                        clsEditionEtatParametre.EN_ADRESSEPOSTALE = row["EN_ADRESSEPOSTALE"].ToString();
                        clsEditionEtatParametre.EN_ADRESSEGEOGRAPHIQUE = row["EN_ADRESSEGEOGRAPHIQUE"].ToString();
                        clsEditionEtatParametre.EN_TELEPHONE = row["EN_TELEPHONE"].ToString();
                        clsEditionEtatParametre.EN_FAX = row["EN_FAX"].ToString();
                        clsEditionEtatParametre.EN_EMAIL = row["EN_EMAIL"].ToString();
                        clsEditionEtatParametre.EN_GERANT = row["EN_GERANT"].ToString();
                        clsEditionEtatParametre.URL_ETAT = URL_ETAT;
                        //private string _EN_CODEENTREPOT = "";
                        //private string _EN_DENOMINATION = "";
                        //private string _EN_ADRESSEPOSTALE = "";
                        //private string _EN_ADRESSEGEOGRAPHIQUE = "";
                        //private string _EN_TELEPHONE = "";
                        //private string _EN_FAX = "";
                        //private string _EN_EMAIL = "";
                        //private string _EN_GERANT = "";
                        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                        clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsEditionEtatParametres.Add(clsEditionEtatParametre);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsEditionEtatParametres.Add(clsEditionEtatParametre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsEditionEtatParametres;
        }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatRayon(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatParametres = TestChampObligatoireListeEntrepot(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
                //--TEST CONTRAINTE
                clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].ET_TYPEETAT };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
               DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatRayon(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
                clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                        clsEditionEtatParametre.RY_CODERAYON = row["RY_CODERAYON"].ToString();
                        clsEditionEtatParametre.RY_LIBELLE = row["RY_LIBELLE"].ToString();
                        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatParametres.Add(clsEditionEtatParametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatParametres;
    }




    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatJournal(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
        {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    //for (int Idx = 0; Idx < Objet.Count; Idx++)
    //{
    //    //--TEST DES CHAMPS OBLIGATOIRES
    //    clsEditionEtatParametres = TestChampObligatoireListe(Objet[Idx]);
    //    //--VERIFICATION DU RESULTAT DU TEST
    //    if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
    //    //--TEST CONTRAINTE
    //    clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
    //    //--VERIFICATION DU RESULTAT DU TEST
    //    if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
    //}

      
    clsObjetEnvoi.OE_PARAM= new string[] {};
    DataSet DataSet = new DataSet();

    try
    {
        clsDonnee.pvgConnectionBase();
            Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
            DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatJournal(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                //clsEditionEtatParametre.ET_INDEX = row["ET_INDEX"].ToString();
                //clsEditionEtatParametre.ET_LIBELLEEditionEtatParametre = row["ET_LIBELLEEditionEtatParametre"].ToString();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
        }
        else
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }
                


    }
    catch (SqlException SQLEx)
    {
        HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
        clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }
    catch (Exception SQLEx)
    {
        HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
        clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }


    finally
    {
        clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatParametres;
}

    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatUnite(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
        {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatParametres = TestChampObligatoireListeEntrepot(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
                //--TEST CONTRAINTE
                clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].ET_TYPEETAT };
    DataSet DataSet = new DataSet();

    try
    {
        clsDonnee.pvgConnectionBase();
            Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
            DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatUnite(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
            clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
                clsEditionEtatParametre.UN_CODEUNITE = row["UN_CODEUNITE"].ToString();
                clsEditionEtatParametre.UN_LIBELLE = row["UN_LIBELLE"].ToString();
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
            }
        }
        else
        {
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
        }
                


    }
    catch (SqlException SQLEx)
    {
        HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
        clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }
    catch (Exception SQLEx)
    {
        HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
        clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }


    finally
    {
        clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatParametres;
}  


    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatParamtre(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet)
    {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


    for (int Idx = 0; Idx < Objet.Count; Idx++)
    {
        //--TEST DES CHAMPS OBLIGATOIRES
        clsEditionEtatParametres = TestChampObligatoireListeEntrepot(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
        //--TEST CONTRAINTE
        clsEditionEtatParametres = TestTestContrainteListe(Objet[Idx]);
        //--VERIFICATION DU RESULTAT DU TEST
        if (clsEditionEtatParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatParametres;
    }

            Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre1 = new Stock.BOJ.clsEditionEtatParametre();
    foreach (HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametreDTO in Objet)
    {
        clsEditionEtatParametre1.ET_TYPEETAT = clsEditionEtatParametreDTO.ET_TYPEETAT.ToString();
        clsEditionEtatParametre1.BT_CODETYPEBUDGET = clsEditionEtatParametreDTO.BT_CODETYPEBUDGET.ToString();
        clsObjetEnvoi.OE_A = clsEditionEtatParametreDTO.clsObjetEnvoi.OE_A;
        clsObjetEnvoi.OE_Y = clsEditionEtatParametreDTO.clsObjetEnvoi.OE_Y;


    }

    clsObjetEnvoi.OE_PARAM= new string[] { };
    DataSet DataSet = new DataSet();

    try
    {
    clsDonnee.pvgConnectionBase();

    DataSet = clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatParamtre(clsDonnee, clsEditionEtatParametre1, clsObjetEnvoi);
    clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
    if (DataSet.Tables[0].Rows.Count > 0)
    {
    foreach (DataRow row in DataSet.Tables[0].Rows)
    {
        HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
        clsEditionEtatParametre.PP_CODEPARAMETRE = row["PP_CODEPARAMETRE"].ToString();
        clsEditionEtatParametre.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
        
        clsEditionEtatParametre.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();

        clsEditionEtatParametre.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();

        clsEditionEtatParametre.JO_JOURNALCODE = row["JO_JOURNALCODE"].ToString();
        clsEditionEtatParametre.JO_LIBELLE = row["JO_LIBELLE"].ToString();
        clsEditionEtatParametre.JO_C = row["JO_C"].ToString();

        clsEditionEtatParametre.TJ_LIBELLE = row["TJ_LIBELLE"].ToString();
        clsEditionEtatParametre.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
        clsEditionEtatParametre.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();

        clsEditionEtatParametre.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();

        clsEditionEtatParametre.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
        clsEditionEtatParametre.TJ_CODETYPEJOURNAL = row["TJ_CODETYPEJOURNAL"].ToString();
        clsEditionEtatParametre.JO_NUMEROORDRE = row["JO_NUMEROORDRE"].ToString();
        clsEditionEtatParametre.PP_VALEUR = row["PP_VALEUR"].ToString();
        clsEditionEtatParametre.TB_CODETABLEAU = row["TB_CODETABLEAU"].ToString();
        clsEditionEtatParametre.TB_LIBELLE = row["TB_LIBELLE"].ToString();
        clsEditionEtatParametre.TB_DESCRIPTION = row["TB_DESCRIPTION"].ToString();
        clsEditionEtatParametre.PA_CODEPARAMETRE = row["PA_CODEPARAMETRE"].ToString();
        clsEditionEtatParametre.PA_LIBELLE = row["PA_LIBELLE"].ToString();
        clsEditionEtatParametre.PA_MONTANTMINI = (row["PA_MONTANTMINI"].ToString() != "") ? double.Parse(row["PA_MONTANTMINI"].ToString()) : 0;// row["PA_MONTANTMINI"].ToString();
                        clsEditionEtatParametre.PA_MONTANTMAXI = (row["PA_MONTANTMAXI"].ToString() != "") ? double.Parse(row["PA_MONTANTMAXI"].ToString()) : 0;// row["PA_MONTANTMAXI"].ToString();
                        clsEditionEtatParametre.PA_TAUX = row["PA_TAUX"].ToString();
        clsEditionEtatParametre.PA_MONTANT = (row["PA_MONTANT"].ToString() != "") ? double.Parse(row["PA_MONTANT"].ToString()) : 0;//row["PA_MONTANT"].ToString();
                        clsEditionEtatParametre.AR_CODEARTICLE = row["AR_CODEARTICLE"].ToString();
        clsEditionEtatParametre.AR_CODEARTICLE1 = row["AR_CODEARTICLE1"].ToString();
        clsEditionEtatParametre.MP_QUANTITE = row["MP_QUANTITE"].ToString();
        clsEditionEtatParametre.AR_NOMCOMMERCIALE = row["AR_NOMCOMMERCIALE"].ToString();
        clsEditionEtatParametre.AR_NOMCOMMERCIALE1 = row["AR_NOMCOMMERCIALE1"].ToString();
        clsEditionEtatParametre.BT_LIBELLE = row["BT_LIBELLE"].ToString();
        clsEditionEtatParametre.BD_CODETYPEBUDGETDETAIL = row["BD_CODETYPEBUDGETDETAIL"].ToString();
        clsEditionEtatParametre.BD_LIBELLE = row["BD_LIBELLE"].ToString();
        clsEditionEtatParametre.BG_CODEPOSTEBUDGETAIRE = row["BG_CODEPOSTEBUDGETAIRE"].ToString();
        clsEditionEtatParametre.BG_LIBELLE = row["BG_LIBELLE"].ToString();
        clsEditionEtatParametre.PL_NUMCOMPTEDETAIL = row["PL_NUMCOMPTEDETAIL"].ToString();
        clsEditionEtatParametre.TP_CODEPOSTETRESORERIE = row["TP_CODEPOSTETRESORERIE"].ToString();
        clsEditionEtatParametre.TR_CODERUBRIQUETRESORERIE = row["TR_CODERUBRIQUETRESORERIE"].ToString();
        clsEditionEtatParametre.TF_LIBELLE = row["TF_LIBELLE"].ToString();
        clsEditionEtatParametre.PD_LIBELLE = row["PD_LIBELLE"].ToString();
        clsEditionEtatParametre.TP_LIBELLE = row["TP_LIBELLE"].ToString();
        clsEditionEtatParametre.TR_LIBELLE = row["TR_LIBELLE"].ToString();
        clsEditionEtatParametre.PS_ABREGE = row["PS_ABREGE"].ToString();
        clsEditionEtatParametre.TP_TAUX = row["TP_TAUX"].ToString();
        clsEditionEtatParametre.TN_LIBELLE = row["TN_LIBELLE"].ToString();
        clsEditionEtatParametre.PB_CODEDOCUMENT = row["PB_CODEDOCUMENT"].ToString();
        clsEditionEtatParametre.PD_CODEDOCUMENTDETAIL = row["PD_CODEDOCUMENTDETAIL"].ToString();
        clsEditionEtatParametre.PO_CODEPOSTEBUSINESSPLAN = row["PO_CODEPOSTEBUSINESSPLAN"].ToString();
        clsEditionEtatParametre.PF_LIBELLE = row["PF_LIBELLE"].ToString();
        clsEditionEtatParametre.PB_LIBELLE = row["PB_LIBELLE"].ToString();
        clsEditionEtatParametre.PO_LIBELLE = row["PO_LIBELLE"].ToString();
        clsEditionEtatParametre.PN_LIBELLE = row["PN_LIBELLE"].ToString();
        clsEditionEtatParametre.PO_TAUX = row["PO_TAUX"].ToString();

        clsEditionEtatParametre.PP_AFFICHER = row["PP_AFFICHER"].ToString();
        clsEditionEtatParametre.PP_BORNEMAX = row["PP_BORNEMAX"].ToString();
        clsEditionEtatParametre.PP_BORNEMIN = row["PP_BORNEMIN"].ToString();
        clsEditionEtatParametre.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
        clsEditionEtatParametre.PP_LIBELLE = row["PP_LIBELLE"].ToString();
        clsEditionEtatParametre.PP_MONTANT = (row["PP_MONTANT"].ToString() != "") ? double.Parse(row["PP_MONTANT"].ToString()) : 0;//row["PP_MONTANT"].ToString();
                        clsEditionEtatParametre.PP_MONTANTMAXI = (row["PP_MONTANTMAXI"].ToString() != "") ? double.Parse(row["PP_MONTANTMAXI"].ToString()) : 0;//row["PP_MONTANTMAXI"].ToString();
                        clsEditionEtatParametre.PP_MONTANTMINI = (row["PP_MONTANTMINI"].ToString() != "") ? double.Parse(row["PP_MONTANTMINI"].ToString()) : 0;// row["PP_MONTANTMINI"].ToString();
                        clsEditionEtatParametre.PP_TAUX = row["PP_TAUX"].ToString();
        clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
        clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
        clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
        clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
        clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }
    }
    else
    {
    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
    clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }
                


    }
    catch (SqlException SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
    clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }
    catch (Exception SQLEx)
    {
    HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
    //Execution du log
    Log.Error(SQLEx.Message, null);
    clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
    clsEditionEtatParametres.Add(clsEditionEtatParametre);
    }


    finally
    {
    clsDonnee.pvgDeConnectionBase();
    }
    return clsEditionEtatParametres;
    }  


    }
}
