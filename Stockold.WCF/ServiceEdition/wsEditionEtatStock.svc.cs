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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatStock" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatStock.svc ou wsEditionEtatStock.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatStock : IwsEditionEtatStock
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatStockWSBLL clsEditionEtatStockWSBLL = new clsEditionEtatStockWSBLL();

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
        public List<HT_Stock.BOJ.clsEditionEtatStock> pvgInsertIntoDatasetEtatCommande(List<HT_Stock.BOJ.clsEditionEtatStock> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatStocks = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatStocks;
                //--TEST CONTRAINTE
                clsEditionEtatStocks = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatStocks[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatStocks;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                // Stock.BOJ.clsEditionEtatStock clsEditionEtatStock1 = new Stock.BOJ.clsEditionEtatStock();

              


                foreach (HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStockDTO in Objet)
                {

                    //"@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@DATEJOURNEE1", "@DATEJOURNEE2", "@TP_CODETYPETIERS", "@ET_TYPEETAT", "@ET_TYPELISTE", "@OP_CODEOPERATEUREDITION", "@GP_CODEGROUPE", "@PY_CODEPAYS", "@NT_CODENATURETIERS", "@CODEDECRYPTAGE"
                    clsObjetEnvoi.OE_PARAM = new string[] { clsEditionEtatStockDTO.AG_CODEAGENCE, clsEditionEtatStockDTO.EN_CODEENTREPOT, clsEditionEtatStockDTO.DATEDEBUT, clsEditionEtatStockDTO.DATEFIN , clsEditionEtatStockDTO.TP_CODETYPETIERS , clsEditionEtatStockDTO.ET_TYPEETAT, clsEditionEtatStockDTO.ET_TYPELISTE, clsEditionEtatStockDTO.OP_CODEOPERATEUREDITION, clsEditionEtatStockDTO.GP_CODEGROUPE, clsEditionEtatStockDTO.PY_CODEPAYS, clsEditionEtatStockDTO.NT_CODENATURETIERS };
                    clsObjetEnvoi.OE_A = clsEditionEtatStockDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatStockDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatCommande(clsDonnee,  clsObjetEnvoi);
                clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();
 
                        clsEditionEtatStock.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();

                        clsEditionEtatStock.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsEditionEtatStock.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                        clsEditionEtatStock.MS_NUMSEQUENCE = row["MS_NUMSEQUENCE"].ToString();
                        clsEditionEtatStock.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();


                        clsEditionEtatStock.MK_DATEPIECE = (row["MK_DATEPIECE"].ToString() != "") ? DateTime.Parse(row["MK_DATEPIECE"].ToString()).ToShortDateString().Replace("/", "-") : "01-01-1900";
                        clsEditionEtatStock.MS_DATEPIECE = (row["MS_DATEPIECE"].ToString() != "") ? DateTime.Parse(row["MS_DATEPIECE"].ToString()).ToShortDateString().Replace("/","-") : "01-01-1900";
                        clsEditionEtatStock.CL_NUMCLIENT = row["CL_NUMCLIENT"].ToString();
                        clsEditionEtatStock.CL_DENOMINATION = row["CL_DENOMINATION"].ToString();
                        clsEditionEtatStock.CL_TELEPHONE = row["CL_TELEPHONE"].ToString();
                        clsEditionEtatStock.CL_ADRESSEGEOGRAPHIQUE = row["CL_ADRESSEGEOGRAPHIQUE"].ToString();

                        clsEditionEtatStock.FR_MATRICULE = row["FR_MATRICULE"].ToString();
                        clsEditionEtatStock.FR_DENOMINATION = row["FR_DENOMINATION"].ToString();
                        clsEditionEtatStock.FR_TELEPHONE = row["FR_TELEPHONE"].ToString();
                        clsEditionEtatStock.FR_ADRESSEGEOGRAPHIQUE = row["FR_ADRESSEGEOGRAPHIQUE"].ToString();

                        clsEditionEtatStock.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsEditionEtatStock.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                        clsEditionEtatStock.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                        clsEditionEtatStock.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                        clsEditionEtatStock.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();

                        clsEditionEtatStock.MK_MONTANT= (row["MK_MONTANT"].ToString() != "") ? double.Parse(row["MK_MONTANT"].ToString()).ToString() : "0";

                        clsEditionEtatStock.MK_MONTANTTOTALREMISE = (row["MK_MONTANTTOTALREMISE"].ToString() != "") ? double.Parse(row["MK_MONTANTTOTALREMISE"].ToString()).ToString() : "0";
                        clsEditionEtatStock.MK_MONTANTTRANSPORT = (row["MK_MONTANTTRANSPORT"].ToString() != "") ? double.Parse(row["MK_MONTANTTRANSPORT"].ToString()).ToString() : "0";
                        clsEditionEtatStock.MK_MONTANTVERSE = (row["MK_MONTANTVERSE"].ToString() != "") ? double.Parse(row["MK_MONTANTVERSE"].ToString()).ToString() : "0";

                        clsEditionEtatStock.MS_MONTANT = (row["MS_MONTANT"].ToString() != "") ? double.Parse(row["MS_MONTANT"].ToString()) : 0;
                        clsEditionEtatStock.MS_MONTANTTOTALREMISE = (row["MS_MONTANTTOTALREMISE"].ToString() != "") ? double.Parse(row["MS_MONTANTTOTALREMISE"].ToString()) : 0;
                        clsEditionEtatStock.MS_MONTANTTRANSPORT = (row["MS_MONTANTTRANSPORT"].ToString() != "") ? double.Parse(row["MS_MONTANTTRANSPORT"].ToString()) : 0;
                        clsEditionEtatStock.MS_MONTANTVERSE = (row["MS_MONTANTVERSE"].ToString() != "") ? double.Parse(row["MS_MONTANTVERSE"].ToString()) : 0;
                        clsEditionEtatStock.MD_QUANTITESORTIE = (row["MD_QUANTITESORTIE"].ToString() != "") ? double.Parse(row["MD_QUANTITESORTIE"].ToString()).ToString() : "0";
                        clsEditionEtatStock.LV_QUANTITELIVRER = (row["LV_QUANTITELIVRER"].ToString() != "") ? double.Parse(row["LV_QUANTITELIVRER"].ToString()).ToString() : "0";
                        clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatStock.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatStocks.Add(clsEditionEtatStock);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatStocks.Add(clsEditionEtatStock);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            clsEditionEtatStocks.Add(clsEditionEtatStock);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            clsEditionEtatStocks.Add(clsEditionEtatStock);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatStocks;
    }


      

    }
}
