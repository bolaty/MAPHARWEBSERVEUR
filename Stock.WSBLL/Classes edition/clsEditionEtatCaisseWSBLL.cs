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
  public  class clsEditionEtatCaisseWSBLL
    {
      private clsEditionEtatCaisseWSDAL clsEditionEtatCaisseWSDAL = new clsEditionEtatCaisseWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        //public DataSet pvgInsertIntoDatasetEtatConsultation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsEditionEtatCaisseWSDAL.pvgInsertIntoDatasetEtatConsultation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}
        public DataSet pvgInsertIntoDatasetEtatBrouillard(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatCaisseWSDAL.pvgInsertIntoDatasetEtatBrouillard(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetEtatGdLivre(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatCaisseWSDAL.pvgInsertIntoDatasetEtatGdLivre(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatCaisseWSDAL.pvgInsertIntoDatasetEtatResultat(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetEtatPointPrestations(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatCaisseWSDAL.pvgInsertIntoDatasetEtatPointPrestations(clsDonnee, clsEditionEtatCaisse, clsObjetEnvoi.OE_PARAM);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatCaisseWSDAL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetActifCirculant(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionEtatCaisseWSDAL.pvgChargerDansDataSetActifCirculant(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



       

        string bvlErreurMiseAjour;

    }
}
