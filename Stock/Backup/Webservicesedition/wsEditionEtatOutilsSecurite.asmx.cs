using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Stock.BOJ;
using Stock.WSTOOLS;
using Stock.WSBLL;
using System.Data;
using System.Data.SqlClient;

namespace Stock.WS
{
    /// <summary>
    /// Description résumée de wsEditionEtatOutilsSecurite
    /// </summary>
    [WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEditionEtatOutilsSecurite.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEditionEtatOutilsSecurite : System.Web.Services.WebService
    {

        private clsEditionEtatOutilsSecuriteWSBLL clsEditionEtatOutilsSecuriteWSBLL = new clsEditionEtatOutilsSecuriteWSBLL();
        private clsDonnee _clsDonnee = new clsDonnee();
        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


        



       
        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatOperateur(clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatOutilsSecuriteWSBLL.pvgInsertIntoDatasetEtatOperateur(clsDonnee, clsEditionEtatOutilsSecurite, clsObjetEnvoi));
            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsObjetRetour;
        }

    

        

       
        
        
    }
}
