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
    /// Description résumée de wsEditionEtatClientFournisseur
    /// </summary>
    [WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEditionEtatClientFournisseur.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEditionEtatClientFournisseur : System.Web.Services.WebService
    {

        private clsEditionEtatClientFournisseurWSBLL clsEditionEtatClientFournisseurWSBLL = new clsEditionEtatClientFournisseurWSBLL();
        private clsDonnee _clsDonnee = new clsDonnee();
        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatConsultation(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatConsultation(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatConsultationReleveCommercial(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatConsultationReleveCommercial(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatConsultationListeVentCommercial(clsObjetEnvoi clsObjetEnvoi)
            {
                clsObjetRetour clsObjetRetour = new clsObjetRetour();
                try
                {
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                    clsDonnee.pvgConnectionBase();
                    clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatConsultationListeVentCommercial(clsDonnee, clsObjetEnvoi));
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
            public clsObjetRetour pvgInsertIntoDatasetReglementCommission(clsObjetEnvoi clsObjetEnvoi)
            {
                clsObjetRetour clsObjetRetour = new clsObjetRetour();
                try
                {
                    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                    clsDonnee.pvgConnectionBase();
                    clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetReglementCommission(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatClientFournisseur(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatClientFournisseur(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatNatureTiers(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatNatureTiers(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatRDV(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatRDV(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatTypeClient(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
    {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatTypeClient(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatTypeFournisseur(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatTypeFournisseur(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatListeChauffeur(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeChauffeur(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatListeFournisseurBon(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeFournisseurBon(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatListeTiers(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeTiers(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatListeVehicule(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeVehicule(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatListeCommerciaux(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatListeCommerciaux(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatRelence(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatRelence(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatFactureCumulee(clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatFactureCumulee(clsDonnee, clsEditionEtatClientFournisseur, clsObjetEnvoi));
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
