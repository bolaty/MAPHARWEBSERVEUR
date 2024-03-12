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
  public  class clsEditionEtatParametreWSBLL
    {
      private clsEditionEtatParametreWSDAL clsEditionEtatParametreWSDAL = new clsEditionEtatParametreWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        public DataSet pvgInsertIntoDatasetEtatAutre(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatAutre(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatPlancomptable(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatPlancomptable(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatEntrepot(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatEntrepot(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatJournal(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatJournal(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatRayon(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatRayon(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatUnite(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatUnite(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatParamtre(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatParametreWSDAL.pvgInsertIntoDatasetEtatParamtre(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi.OE_PARAM);
        }

       
        string bvlErreurMiseAjour;

    }
}
