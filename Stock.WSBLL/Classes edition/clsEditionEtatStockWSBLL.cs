using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;

namespace Stock.WSBLL
{
  public  class clsEditionEtatStockWSBLL
    {
      private clsEditionEtatStockWSDAL clsEditionEtatStockWSDAL = new clsEditionEtatStockWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        public DataSet pvgInsertIntoDatasetEtatAutre(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatAutre(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatStock(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatStock(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatStockTransFert(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatStockTransFert(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public string pvgMiseAJourZeCaisse(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsEditionEtatStockWSDAL.pvgMiseAJourZeCaisse(clsDonnee, clsObjetEnvoi.OE_PARAM);
            return "";
        }

        public DataSet pvgInsertIntoDatasetEtatFacture(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatFacture(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatCommande(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatCommande(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetEtatSitutionFournisseurBon(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatSitutionFournisseurBon(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatInventaire(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatInventaire(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetEtatSituationArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatSituationArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatRepartition(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatRepartition(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatMvtStockQualite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatMvtStockQualite(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatMvtStockRetenues(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatStockWSDAL.pvgInsertIntoDatasetEtatMvtStockRetenues(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        string bvlErreurMiseAjour;

    }
}
