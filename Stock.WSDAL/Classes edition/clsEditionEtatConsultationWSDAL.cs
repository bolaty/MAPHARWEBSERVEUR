using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
  public  class clsEditionEtatConsultationWSDAL
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet d'executer une requete de selection dans la base de donnée</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<author>Home Technologie</author>
        ///

        

        #region Requêtes Select
        #endregion
        #region Fonctions
        #endregion
        #region Procédures Stockées
        
        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatConsultation clsEditionEtatConsultation, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TI_IDTIERSPATIENT", "@TI_IDTIERSMEDECIN", "@DATEDEBUT", "@DATEFIN", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatConsultation.AG_CODEAGENCE, clsEditionEtatConsultation.TI_IDTIERSPATIENT, clsEditionEtatConsultation.TI_IDTIERSMEDECIN, clsEditionEtatConsultation.DATEDEBUT, clsEditionEtatConsultation.DATEFIN, clsEditionEtatConsultation.OP_CODEOPERATEUREDITION, clsEditionEtatConsultation.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCLINIQUECONSULTATION  @AG_CODEAGENCE,@TI_IDTIERSPATIENT, @TI_IDTIERSMEDECIN,  @DATEDEBUT,@DATEFIN,@OP_CODEOPERATEUREDITION,@ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        #endregion
    }
}
