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
    /// Description résumée de wsEditionEtatCaisse
    /// </summary>
    [WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEditionEtatCaisse.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEditionEtatCaisse : System.Web.Services.WebService
    {

        private clsEditionEtatCaisseWSBLL clsEditionEtatCaisseWSBLL = new clsEditionEtatCaisseWSBLL();
        private clsDonnee _clsDonnee = new clsDonnee();
        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


        //[WebMethod]
        //public clsObjetRetour pvgInsertIntoDatasetEtatConsultation(clsObjetEnvoi clsObjetEnvoi)
        //{
        //    clsObjetRetour clsObjetRetour = new clsObjetRetour();
        //    try
        //    {
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //        clsDonnee.pvgConnectionBase();
        //        clsObjetRetour.SetValue(true, clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatConsultation(clsDonnee, clsObjetEnvoi));
        //    }
        //    catch (SqlException SQLEx)
        //    {
        //        clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        //    }
        //    finally
        //    {
        //        clsDonnee.pvgDeConnectionBase();
        //    }
        //    return clsObjetRetour;
        //}


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatBrouillard(clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatBrouillard(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatGdLivre(clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatGdLivre(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatResultat(clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatCaisseWSBLL.pvgInsertIntoDatasetEtatResultat(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi));
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





        [WebMethod(MessageName = "pvgChargerDansDataSet1", Description = "pvgChargerDansDataSet1", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSet1(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatCaisseWSBLL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi));
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


        [WebMethod(MessageName = "pvgChargerDansDataSetActifCirculant", Description = "pvgChargerDansDataSetActifCirculant", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetActifCirculant(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatCaisseWSBLL.pvgChargerDansDataSetActifCirculant(clsDonnee, clsObjetEnvoi));
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
