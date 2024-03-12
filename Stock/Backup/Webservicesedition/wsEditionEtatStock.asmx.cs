using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Stock.BOJ;
using Stock.WSTOOLS;
using Stock.WSBLL;
using System.Data;
using System.Data.SqlClient;

namespace Stock.WS
{
    /// <summary>
    /// Description résumée de wsEditionEtatStock
    /// </summary>
    [WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEditionEtatStock.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEditionEtatStock : System.Web.Services.WebService
    {

        private clsEditionEtatStockWSBLL clsEditionEtatStockWSBLL = new clsEditionEtatStockWSBLL();
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatAutre(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatAutre(clsDonnee, clsObjetEnvoi));
            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsObjetRetour;
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatStock(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatStock(clsDonnee, clsObjetEnvoi));
            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsObjetRetour;
        }

        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatStockTransFert(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatStockTransFert(clsDonnee, clsObjetEnvoi));
            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsObjetRetour;
        }
        [WebMethod(MessageName = "pvgMiseAJourZeCaisse", Description = "pvgMiseAJourZeCaisse", EnableSession = true)]
        public clsObjetRetour pvgMiseAJourZeCaisse(clsObjetEnvoi clsObjetEnvoi)
        {
            //clsObjetEnvoi.
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgMiseAJourZeCaisse(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee,
                    "GNE0003").MS_LIBELLEMESSAGE);
            }
            catch (SqlException SQLEx)
            {
                string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
                clsObjetRetour.SetValueMessage(false, vlpMessage);
            }
            finally
            {
                clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN); ;
            }
            return clsObjetRetour;
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatFacture(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatFacture(clsDonnee, clsObjetEnvoi));
            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsObjetRetour;
        }

    [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatCommande(clsObjetEnvoi clsObjetEnvoi)
    {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatCommande(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
    }

    [WebMethod]
    public clsObjetRetour pvgInsertIntoDatasetEtatSitutionFournisseurBon(clsObjetEnvoi clsObjetEnvoi)
    {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatSitutionFournisseurBon(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
    }
    [WebMethod]
    public clsObjetRetour pvgInsertIntoDatasetEtatInventaire(clsObjetEnvoi clsObjetEnvoi)
    {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatInventaire(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
    }

        [WebMethod]
    public clsObjetRetour pvgInsertIntoDatasetEtatSituationArticle(clsObjetEnvoi clsObjetEnvoi)
        {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatSituationArticle(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
        }

        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatRepartition(clsObjetEnvoi clsObjetEnvoi)
        {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatRepartition(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatMvtStockQualite(clsObjetEnvoi clsObjetEnvoi)
        {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatMvtStockQualite(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
        }

        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatMvtStockRetenues(clsObjetEnvoi clsObjetEnvoi)
        {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatStockWSBLL.pvgInsertIntoDatasetEtatMvtStockRetenues(clsDonnee, clsObjetEnvoi));
        }
        catch (SqlException SQLEx)
        {
            clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        }
        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsObjetRetour;
        }
        
    }




}
