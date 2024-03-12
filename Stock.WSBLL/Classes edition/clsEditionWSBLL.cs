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


    public class clsEditionWSBLL
    {
        private clsEditionWSDAL clsEditionWSDAL = new clsEditionWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();


        string  bvlErreurMiseAjour;

        public DataSet pvgChargerDansDataSetPourComboAgenceEdition(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgChargerDansDataSetPourComboAgenceEdition(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetZone(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetZone(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetAgence(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetAgence(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetExercice(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetExercice(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetPeriodicite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetPeriodicite(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetPeriode(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetPeriode(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgPeriodicite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgPeriodicite(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgPeriodiciteDateDebutFin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgPeriodiciteDateDebutFin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetSociete(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetSociete(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetTESTSOCIETE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetTESTSOCIETE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetTESTZONE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetTESTZONE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetTestAgence(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetTestAgence(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        public DataSet pvgEnteteDesEtats(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgEnteteDesEtats(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgMois(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgMois(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        /////<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IN_CODETYPEARTICLE ) </summary>
        /////<param name=clsDonnee>Classe d'acces aux donnees</param>
        /////<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        /////<returns>Une collection de clsPhainput </returns>
        /////<author>Home Technology</author>
        //public List<clsPhainput> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsEtatWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}
    }
}