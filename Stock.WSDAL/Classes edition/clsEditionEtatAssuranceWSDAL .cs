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
  public  class clsEditionEtatAssuranceWSDAL
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

        public DataSet pvgInsertIntoDatasetEtatAssurance(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT", "@DATEDEBUT", "@DATEFIN", "@OP_CODEOPERATEUREDITION", "@RQ_CODERISQUE", "@TI_IDTIERS", "@TI_IDTIERSCOMMERCIAL", "@PY_CODEPAYS", "@VL_CODEVILLE", "@CO_CODECOMMUNE", "@ZA_CODEZONEAUTO", "@NS_CODENATURESINISTRE", "@TA_CODETYPEAFFAIRES", "@CT_CODESTAUT", "@ZN_CODEZONECOMMERCIAL", "@TI_IDTIERSCLIENT", "@EX_EXERCICE", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatAssurance.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatAssurance.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatAssurance.CA_CODECONTRAT.Replace("''", "'"), clsEditionEtatAssurance.DATEDEBUT, clsEditionEtatAssurance.DATEFIN, clsEditionEtatAssurance.OP_CODEOPERATEUREDITION, clsEditionEtatAssurance.RQ_CODERISQUE.Replace("''", "'"), clsEditionEtatAssurance.TI_IDTIERS.Replace("''", "'"), clsEditionEtatAssurance.TI_IDTIERSCOMMERCIAL, clsEditionEtatAssurance.PY_CODEPAYS, clsEditionEtatAssurance.VL_CODEVILLE, clsEditionEtatAssurance.CO_CODECOMMUNE, clsEditionEtatAssurance.ZA_CODEZONEAUTO, clsEditionEtatAssurance.NS_CODENATURESINISTRE, clsEditionEtatAssurance.TA_CODETYPEAFFAIRES, clsEditionEtatAssurance.CT_CODESTAUT,clsEditionEtatAssurance.ZN_CODEZONECOMMERCIAL,clsEditionEtatAssurance.TI_IDTIERSCLIENT, clsEditionEtatAssurance.EX_EXERCICE, clsEditionEtatAssurance.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATASSURANCE  @AG_CODEAGENCE,@EN_CODEENTREPOT, @CA_CODECONTRAT,  @DATEDEBUT,@DATEFIN,@OP_CODEOPERATEUREDITION,@RQ_CODERISQUE,@TI_IDTIERS, @TI_IDTIERSCOMMERCIAL, @PY_CODEPAYS, @VL_CODEVILLE, @CO_CODECOMMUNE, @ZA_CODEZONEAUTO,@NS_CODENATURESINISTRE, @TA_CODETYPEAFFAIRES, @CT_CODESTAUT,@ZN_CODEZONECOMMERCIAL,@TI_IDTIERSCLIENT,@EX_EXERCICE, @ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatSynoptique(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUREDITION", "@RQ_CODERISQUE", "@DATEDEBUT", "@DATEFIN", "@TI_IDTIERSCOMMERCIAL", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatAssurance.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatAssurance.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatAssurance.OP_CODEOPERATEUREDITION, clsEditionEtatAssurance.RQ_CODERISQUE, clsEditionEtatAssurance.DATEDEBUT, clsEditionEtatAssurance.DATEFIN,clsEditionEtatAssurance.TI_IDTIERSCOMMERCIAL, clsEditionEtatAssurance.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATSYNOPTIQUE  @AG_CODEAGENCE,@EN_CODEENTREPOT, @OP_CODEOPERATEUREDITION,  @RQ_CODERISQUE,@DATEDEBUT,@DATEFIN,@TI_IDTIERSCOMMERCIAL,@ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatAssuranceEncaissementCheque(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@DATEDEBUT", "@DATEFIN", "@RQ_CODERISQUE", "@TA_CODETYPEAFFAIRES", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatAssurance.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatAssurance.CA_CODECONTRAT.Replace("''", "'"), clsEditionEtatAssurance.OP_CODEOPERATEUREDITION, clsEditionEtatAssurance.DATEDEBUT, clsEditionEtatAssurance.DATEFIN, clsEditionEtatAssurance.RQ_CODERISQUE,clsEditionEtatAssurance.TA_CODETYPEAFFAIRES, clsEditionEtatAssurance.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCTCONTRATCHEQUEDIFFERES  @AG_CODEAGENCE,@CA_CODECONTRAT, @OP_CODEOPERATEUREDITION,@DATEDEBUT,@DATEFIN,  @RQ_CODERISQUE,@TA_CODETYPEAFFAIRES,@ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        //public DataSet pvgInsertIntoDatasetEtatAssurance(clsDonnee clsDonnee, clsEditionEtatAssurance clsEditionEtatAssurance, params string[] vppCritere)
        //{

        //    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT", "@DATEDEBUT", "@DATEFIN", "@OP_CODEOPERATEUREDITION", "@RQ_CODERISQUE", "@TI_IDTIERS", "@TA_CODETYPEAFFAIRES", "@CT_CODESTAUT", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
        //    vapValeurParametre = new object[] { clsEditionEtatAssurance.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatAssurance.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatAssurance.CA_CODECONTRAT.Replace("''", "'"), clsEditionEtatAssurance.DATEDEBUT, clsEditionEtatAssurance.DATEFIN, clsEditionEtatAssurance.OP_CODEOPERATEUREDITION, clsEditionEtatAssurance.RQ_CODERISQUE.Replace("''", "'"), clsEditionEtatAssurance.TI_IDTIERS.Replace("''", "'"),  clsEditionEtatAssurance.TA_CODETYPEAFFAIRES, clsEditionEtatAssurance.CT_CODESTAUT, clsEditionEtatAssurance.ET_TYPEETAT, clsDonnee.vogCleCryptage };
        //    this.vapRequete = "EXEC PS_ETATASSURANCE  @AG_CODEAGENCE,@EN_CODEENTREPOT, @CA_CODECONTRAT,  @DATEDEBUT,@DATEFIN,@OP_CODEOPERATEUREDITION,@RQ_CODERISQUE,@TI_IDTIERS, @TA_CODETYPEAFFAIRES, @CT_CODESTAUT, @ET_TYPEETAT,@CODEDECRYPTAGE ";
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        //}

        #endregion
    }
}
