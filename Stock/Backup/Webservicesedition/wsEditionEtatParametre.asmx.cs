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
    /// Description résumée de wsEditionEtatParametre
    /// </summary>
    [WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEditionEtatParametre.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEditionEtatParametre : System.Web.Services.WebService
    {

        private clsEditionEtatParametreWSBLL clsEditionEtatParametreWSBLL = new clsEditionEtatParametreWSBLL();
        private clsDonnee _clsDonnee = new clsDonnee();
        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatAutre(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatAutre(clsDonnee, clsObjetEnvoi));
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



        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatPlancomptable(clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatPlancomptable(clsDonnee,clsEditionEtatParametre, clsObjetEnvoi));
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
        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatEntrepot(clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
            {
                clsObjetRetour clsObjetRetour = new clsObjetRetour();
                try
                {
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                    clsDonnee.pvgConnectionBase();
                    clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatEntrepot(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi));
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

        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatJournal(clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
            {
                clsObjetRetour clsObjetRetour = new clsObjetRetour();
                try
                {
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                    clsDonnee.pvgConnectionBase();
                    clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatJournal(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi));
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

        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatRayon(clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatRayon(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi));
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

    [WebMethod]
    public clsObjetRetour pvgInsertIntoDatasetEtatUnite(clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
    {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatUnite(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi));
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


        [WebMethod]
    public clsObjetRetour pvgInsertIntoDatasetEtatParamtre(clsEditionEtatParametre clsEditionEtatParametre, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatParametreWSBLL.pvgInsertIntoDatasetEtatParamtre(clsDonnee, clsEditionEtatParametre, clsObjetEnvoi));
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
