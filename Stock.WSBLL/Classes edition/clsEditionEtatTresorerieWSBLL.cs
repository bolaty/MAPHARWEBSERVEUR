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
  public  class clsEditionEtatTresorerieWSBLL
    {
      private clsEditionEtatTresorerieWSDAL clsEditionEtatTresorerieWSDAL = new clsEditionEtatTresorerieWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();
        
        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatTresorerie clsEditionEtatTresorerie, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatTresorerieWSDAL.pvgInsertIntoDatasetEtatResultat(clsDonnee, clsEditionEtatTresorerie, clsObjetEnvoi.OE_PARAM);
        }

    }
}
