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
  public  class clsEditionEtatOutilsSecuriteWSDAL
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
       
        public DataSet pvgInsertIntoDatasetEtatOperateur(clsDonnee clsDonnee, clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_DATERENDEZVOUS1 ", "@MS_DATERENDEZVOUS2", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatOutilsSecurite.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatOutilsSecurite.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatOutilsSecurite.MS_DATERENDEZVOUS1, clsEditionEtatOutilsSecurite.MS_DATERENDEZVOUS2, clsEditionEtatOutilsSecurite.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATOPERATEUR    @AG_CODEAGENCE,@EN_CODEENTREPOT, @MS_DATERENDEZVOUS1,@MS_DATERENDEZVOUS2,@ET_TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        #endregion
    }
}
