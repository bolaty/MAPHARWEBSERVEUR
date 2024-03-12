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
 public   class clsEtatComptaAnalytiqueWSDAL
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
        #region Procédures stockées
        public DataSet pvgInsertIntoDatasetStock(clsDonnee clsDonnee,clsEtatComptaAnalytique clsEtatComptaAnalytique, params string[] vppCritere)

        {
           //Ancien vapNomParametre = new string[] { "@AG_CODEAGENCE", "@PV_CODEPOINTVENTE", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT", "@CODEDECRYPTAGE", "@ET_INDEX"};

            vapNomParametre = new string[] { "@ZONE", "@AG_CODEAGENCE", "@PV_CODEPOINTVENTE", "@EXERCICE",	"@PERIODICITE",	"@PERIODE",	"@OPTION", "@ET_INDEX", "@ET_TYPEETAT" };

            vapValeurParametre = new object[] { clsEtatComptaAnalytique.ZONE.Replace("''", "'"), clsEtatComptaAnalytique.AG_CODEAGENCE.Replace("''", "'"), clsEtatComptaAnalytique.PV_CODEPOINTVENTE.Replace("''", "'"), clsEtatComptaAnalytique.EXERCICE.Replace("''", "'"), clsEtatComptaAnalytique.PERIODICITE.Replace("''", "'"), clsEtatComptaAnalytique.PERIODE.Replace("''", "'"), clsEtatComptaAnalytique.OPTION.Replace("''", "'"), clsEtatComptaAnalytique.ET_INDEX.Replace("''", "'"), clsEtatComptaAnalytique.ET_TYPEETAT.Replace("''", "'"), clsDonnee.vogCleCryptage};
            this.vapRequete = "EXEC PS_ETATCOMPTABILITEANALYTIQUE  @ZONE, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @EXERCICE,	@PERIODICITE,	@PERIODE,	@OPTION,	@ET_INDEX,	@ET_TYPEETAT";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        #endregion
    }
}
