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
  public  class clsEditionEtatClientFournisseurWSBLL
    {
      private clsEditionEtatClientFournisseurWSDAL clsEditionEtatClientFournisseurWSDAL = new clsEditionEtatClientFournisseurWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        public DataSet pvgInsertIntoDatasetEtatConsultation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatConsultation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatConsultationReleveCommercial(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatConsultationReleveCommercial(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatConsultationListeVentCommercial(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatConsultationListeVentCommercial(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetReglementCommission(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetReglementCommission(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatClientFournisseur(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatClientFournisseur(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatNatureTiers(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatNatureTiers(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatRDV(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatRDV(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatTypeClient(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatTypeClient(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatTypeFournisseur(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatTypeFournisseur(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatListeChauffeur(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatListeChauffeur(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatListeFournisseurBon(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatListeFournisseurBon(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatListeTiers(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatListeTiers(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatListeVehicule(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatListeVehicule(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatListeCommerciaux(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatListeCommerciaux(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatRelence(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatRelence(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatFactureCumulee(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatClientFournisseurWSDAL.pvgInsertIntoDatasetEtatFactureCumulee(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi.OE_PARAM);
        }
        string bvlErreurMiseAjour;

    }
}
