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
  public  class clsEditionEtatOutilsSecuriteWSBLL
    {
      private clsEditionEtatOutilsSecuriteWSDAL clsEditionEtatOutilsSecuriteWSDAL = new clsEditionEtatOutilsSecuriteWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();



        public DataSet pvgInsertIntoDatasetEtatOperateur(clsDonnee clsDonnee, clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatOutilsSecuriteWSDAL.pvgInsertIntoDatasetEtatOperateur(clsDonnee, clsEditionEtatOutilsSecurite, clsObjetEnvoi.OE_PARAM);
        }
       

        string bvlErreurMiseAjour;

    }
}
