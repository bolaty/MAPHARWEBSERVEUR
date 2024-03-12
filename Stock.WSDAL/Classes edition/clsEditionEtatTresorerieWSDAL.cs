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
  public  class clsEditionEtatTresorerieWSDAL
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

        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatTresorerie clsEditionEtatTresorerie, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@EX_EXERCICE", "@DATEDEBUT", "@DATEFIN", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatTresorerie.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatTresorerie.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatTresorerie.EX_EXERCICE, clsEditionEtatTresorerie.DATEDEBUT, clsEditionEtatTresorerie.DATEFIN,clsEditionEtatTresorerie.OP_CODEOPERATEUREDITION, clsEditionEtatTresorerie.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTRESORERIE  @AG_CODEAGENCE,@EN_CODEENTREPOT, @EX_EXERCICE,   @DATEDEBUT,@DATEFIN,@OP_CODEOPERATEUREDITION,@ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        #endregion
    }
}
