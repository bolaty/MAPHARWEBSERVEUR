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
 public   class clsEtatComptaAnalytiqueWSBLL
    {
     private clsEtatComptaAnalytiqueWSDAL clsEtatComptaAnalytiqueWSDAL = new clsEtatComptaAnalytiqueWSDAL();
        //private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        string bvlErreurMiseAjour;

        public DataSet pvgInsertIntoDatasetStock(clsDonnee clsDonnee, clsEtatComptaAnalytique clsEtatComptaAnalytique, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEtatComptaAnalytiqueWSDAL.pvgInsertIntoDatasetStock(clsDonnee, clsEtatComptaAnalytique, clsObjetEnvoi.OE_PARAM);
        }
    }
}
