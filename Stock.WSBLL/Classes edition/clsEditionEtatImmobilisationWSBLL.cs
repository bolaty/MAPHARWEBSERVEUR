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
  public  class clsEditionEtatImmobilisationWSBLL
    {
      private clsEditionEtatImmobilisationWSDAL clsEditionEtatImmobilisationWSDAL = new clsEditionEtatImmobilisationWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();



        public DataSet pvgETATIMMOBILISATIONAMORTISSEMENT(clsDonnee clsDonnee, clsEditionEtatImmobilisation clsEditionEtatImmobilisation, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatImmobilisationWSDAL.pvgETATIMMOBILISATIONAMORTISSEMENT(clsDonnee, clsEditionEtatImmobilisation, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgETATTABLEAUAMORTISSEMENT(clsDonnee clsDonnee, clsEditionEtatImmobilisation clsEditionEtatImmobilisation, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatImmobilisationWSDAL.pvgETATTABLEAUAMORTISSEMENT(clsDonnee, clsEditionEtatImmobilisation, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgETATFAMILLEIMMOBILISATION(clsDonnee clsDonnee, clsEditionEtatImmobilisation clsEditionEtatImmobilisation, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatImmobilisationWSDAL.pvgETATFAMILLEIMMOBILISATION(clsDonnee, clsEditionEtatImmobilisation, clsObjetEnvoi.OE_PARAM);
        }
        string bvlErreurMiseAjour;

    }
}
