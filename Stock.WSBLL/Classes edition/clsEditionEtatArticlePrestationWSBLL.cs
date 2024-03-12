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
  public  class clsEditionEtatArticlePrestationWSBLL
    {
      private clsEditionEtatArticlePrestationWSDAL clsEditionEtatArticlePrestationWSDAL = new clsEditionEtatArticlePrestationWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        public DataSet pvgInsertIntoDatasetEtatArticlePrestation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatArticlePrestation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatMargeBeneficiaire(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatMargeBeneficiaire(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatHistorisationChambre(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatHistorisationChambre(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatArticleMoinCher(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatArticleMoinCher(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatSituationArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatSituationArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatPrixArticleHisto(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatPrixArticleHisto(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        public DataSet pvgInsertIntoDatasetEtatArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatArticleChambreDispinible(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatArticleChambreDispinible(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatArticleChambreFicheActivite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatArticleChambreFicheActivite(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatArticleChambreFicheActiviteCompte(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatArticleChambreFicheActiviteCompte(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetEtatForme(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatForme(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatMarque(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatMarque(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatModel(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatModel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatFabriquant(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatFabriquant(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatPromotion(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatPromotion(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatTypeArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatTypeArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatTypePrestation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatTypePrestation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatDestinationArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatDestinationArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatIntervention(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatIntervention(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetEtatDestinationArticlePHOTO(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatArticlePrestationWSDAL.pvgInsertIntoDatasetEtatDestinationArticlePHOTO(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        string bvlErreurMiseAjour;

    }
}
