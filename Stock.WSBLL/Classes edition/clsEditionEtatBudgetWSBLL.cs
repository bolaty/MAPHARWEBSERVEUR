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
  public  class clsEditionEtatBudgetWSBLL
    {
      private clsEditionEtatBudgetWSDAL clsEditionEtatBudgetWSDAL = new clsEditionEtatBudgetWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        public DataSet pvgInsertIntoDatasetEtatBudget(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatBudgetWSDAL.pvgInsertIntoDatasetEtatBudget(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatParametreBudget(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatBudgetWSDAL.pvgInsertIntoDatasetEtatParametreBudget(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatBudgetCompteFinancier(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatBudgetWSDAL.pvgInsertIntoDatasetEtatBudgetCompteFinancier(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        string bvlErreurMiseAjour;

    }
}
