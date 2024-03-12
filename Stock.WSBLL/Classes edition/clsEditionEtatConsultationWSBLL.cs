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
  public  class clsEditionEtatConsultationWSBLL
    {
      private clsEditionEtatConsultationWSDAL clsEditionEtatConsultationWSDAL = new clsEditionEtatConsultationWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatConsultation clsEditionEtatConsultation, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatConsultationWSDAL.pvgInsertIntoDatasetEtatResultat(clsDonnee, clsEditionEtatConsultation, clsObjetEnvoi.OE_PARAM);
        }


    }
}
