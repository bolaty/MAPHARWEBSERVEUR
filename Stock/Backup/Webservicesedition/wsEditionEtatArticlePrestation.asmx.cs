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
    /// Description résumée de wsEditionEtatArticlePrestation
    /// </summary>
    [WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEditionEtatArticlePrestation.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEditionEtatArticlePrestation : System.Web.Services.WebService
    {

        private clsEditionEtatArticlePrestationWSBLL clsEditionEtatArticlePrestationWSBLL = new clsEditionEtatArticlePrestationWSBLL();
        private clsDonnee _clsDonnee = new clsDonnee();
        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }


        [WebMethod]
        public clsObjetRetour pvgInsertIntoDatasetEtatArticlePrestation(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatArticlePrestation(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatMargeBeneficiaire(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatMargeBeneficiaire(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatHistorisationChambre(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatHistorisationChambre(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatArticleMoinCher(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatArticleMoinCher(clsDonnee, clsObjetEnvoi));
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
  public clsObjetRetour pvgInsertIntoDatasetEtatSituationArticle(clsObjetEnvoi clsObjetEnvoi)
  {
      clsObjetRetour clsObjetRetour = new clsObjetRetour();
      try
      {
          clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
          clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
          clsDonnee.pvgConnectionBase();
          clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatSituationArticle(clsDonnee, clsObjetEnvoi));
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
  public clsObjetRetour pvgInsertIntoDatasetEtatPrixArticleHisto(clsObjetEnvoi clsObjetEnvoi)
  {
      clsObjetRetour clsObjetRetour = new clsObjetRetour();
      try
      {
          clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
          clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
          clsDonnee.pvgConnectionBase();
          clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatPrixArticleHisto(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatArticle(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatArticle(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatArticleChambreDispinible(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatArticleChambreDispinible(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatArticleChambreFicheActivite(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatArticleChambreFicheActivite(clsDonnee, clsObjetEnvoi));
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
    public clsObjetRetour pvgInsertIntoDatasetEtatArticleChambreFicheActiviteCompte(clsObjetEnvoi clsObjetEnvoi)
    {
        clsObjetRetour clsObjetRetour = new clsObjetRetour();
        try
        {
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            clsDonnee.pvgConnectionBase();
            clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatArticleChambreFicheActiviteCompte(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatForme(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatForme(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatMarque(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatMarque(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatModel(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatModel(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatFabriquant(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatFabriquant(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatPromotion(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatPromotion(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatTypeArticle(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatTypeArticle(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatTypePrestation(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatTypePrestation(clsDonnee, clsObjetEnvoi));
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
 public clsObjetRetour pvgInsertIntoDatasetEtatDestinationArticle(clsObjetEnvoi clsObjetEnvoi)
 {
     clsObjetRetour clsObjetRetour = new clsObjetRetour();
     try
     {
         clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
         clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
         clsDonnee.pvgConnectionBase();
         clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatDestinationArticle(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatIntervention(clsObjetEnvoi clsObjetEnvoi)
         {
             clsObjetRetour clsObjetRetour = new clsObjetRetour();
             try
             {
                 clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                 clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                 clsDonnee.pvgConnectionBase();
                 clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatIntervention(clsDonnee, clsObjetEnvoi));
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
        public clsObjetRetour pvgInsertIntoDatasetEtatDestinationArticlePHOTO(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsEditionEtatArticlePrestationWSBLL.pvgInsertIntoDatasetEtatDestinationArticlePHOTO(clsDonnee, clsObjetEnvoi));
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
