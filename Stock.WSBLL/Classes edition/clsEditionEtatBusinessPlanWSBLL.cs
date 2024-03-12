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
  public  class clsEditionEtatBusinessPlanWSBLL
    {
      private clsEditionEtatBusinessPlanWSDAL clsEditionEtatBusinessPlanWSDAL = new clsEditionEtatBusinessPlanWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();
        
        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatBusinessPlan clsEditionEtatBusinessPlan, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatBusinessPlanWSDAL.pvgInsertIntoDatasetEtatResultat(clsDonnee, clsEditionEtatBusinessPlan, clsObjetEnvoi.OE_PARAM);
        }

    }
}
