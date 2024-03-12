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
  public  class clsEditionEtatBudgetWSDAL
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
        public DataSet pvgInsertIntoDatasetEtatBudget(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEURSAISIE", "@OP_CODEOPERATEURVALIDATION", "@OP_CODEOPERATEUREDITION", "@BT_CODETYPEBUDGET", "@BU_CODEBUDGET", "@BG_CODEPOSTEBUDGETAIRE", "@SR_CODESERVICE", "@MONTANT1", "@MONTANT2",  "@DATEDEBUT", "@DATEFIN", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5].Replace("''", "'"), vppCritere[6].Replace("''", "'"), vppCritere[7].Replace("''", "'"), vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12],  clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_ETATMICBUDGET] @AG_CODEAGENCE,@OP_CODEOPERATEURSAISIE,@OP_CODEOPERATEURVALIDATION,@OP_CODEOPERATEUREDITION,@BT_CODETYPEBUDGET,@BU_CODEBUDGET,@BG_CODEPOSTEBUDGETAIRE,@SR_CODESERVICE, @MONTANT1 , @MONTANT2 ,@DATEDEBUT,@DATEFIN,@TYPEETAT,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatParametreBudget(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@OP_CODEOPERATEUREDITION", "@BT_CODETYPEBUDGET", "@BD_CODETYPEBUDGETDETAIL", "@BN_CODENATUREPOSTEBUDGETAIRE", "@SR_CODESERVICE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1].Replace("''", "'"), vppCritere[2].Replace("''", "'"), vppCritere[3].Replace("''", "'"), vppCritere[4].Replace("''", "'"), vppCritere[5], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_ETATPARAMETREBUDGET] @OP_CODEOPERATEUREDITION,@BT_CODETYPEBUDGET,@BD_CODETYPEBUDGETDETAIL,@BN_CODENATUREPOSTEBUDGETAIRE,@SR_CODESERVICE,@TYPEETAT,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatBudgetCompteFinancier(clsDonnee clsDonnee, params string[] vppCritere)
        {

            //vapNomParametre = new string[] { "@OP_CODEOPERATEUREDITION", "@BT_CODETYPEBUDGET", "@BD_CODETYPEBUDGETDETAIL", "@BN_CODENATUREPOSTEBUDGETAIRE", "@SR_CODESERVICE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            //vapValeurParametre = new object[] { vppCritere[0], vppCritere[1].Replace("''", "'"), vppCritere[2].Replace("''", "'"), vppCritere[3].Replace("''", "'"), vppCritere[4].Replace("''", "'"), vppCritere[5], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM VUE_MICBUDGETCOMPTEFINANCIERANNEE ORDER BY BD_NUMEROORDRE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        #endregion
    }
}
