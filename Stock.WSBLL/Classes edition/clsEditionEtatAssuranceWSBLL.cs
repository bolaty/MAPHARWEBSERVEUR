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
  public  class clsEditionEtatAssuranceWSBLL
    {
      private clsEditionEtatAssuranceWSDAL clsEditionEtatAssuranceWSDAL = new clsEditionEtatAssuranceWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();
        public DataSet pvgInsertIntoDatasetEtatAssurance(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatAssuranceWSDAL.pvgInsertIntoDatasetEtatAssurance(clsDonnee, clsEditionEtatAssurance, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatAssuranceTableauGestionCommission(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatAssuranceWSDAL.pvgInsertIntoDatasetEtatAssuranceTableauGestionCommission(clsDonnee, clsEditionEtatAssurance, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatAssuranceTableauGestion(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatAssuranceWSDAL.pvgInsertIntoDatasetEtatAssuranceTableauGestion(clsDonnee, clsEditionEtatAssurance, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetEtatAssuranceAnnuler(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatAssuranceWSDAL.pvgInsertIntoDatasetEtatAssuranceAnnuler(clsDonnee, clsEditionEtatAssurance, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatSynoptique(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatAssuranceWSDAL.pvgInsertIntoDatasetEtatSynoptique(clsDonnee, clsEditionEtatAssurance, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatAssuranceEncaissementCheque(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatAssuranceWSDAL.pvgInsertIntoDatasetEtatAssuranceEncaissementCheque(clsDonnee, clsEditionEtatAssurance, clsObjetEnvoi.OE_PARAM);
        }



    }
}
