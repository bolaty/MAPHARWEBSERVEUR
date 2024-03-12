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
  public  class clsEditionEtatParametreWSDAL
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
        public DataSet pvgInsertIntoDatasetEtatAutre(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@DATEDEBUT", "@DATEFIN", "@OP_CODEOPERATEUREDITION", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATAUTRE    @AG_CODEAGENCE, @DATEDEBUT, @DATEFIN,@OP_CODEOPERATEUREDITION,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatPlancomptable(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, params string[] vppCritere)
        {

            vapNomParametre = new string[] {  "@TYPEETAT" };
            vapValeurParametre = new object[] { clsEditionEtatParametre.ET_TYPEETAT };
            this.vapRequete = "EXEC PS_ETATPLANCOMPTABLE   @TYPEETAT";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

         public DataSet pvgInsertIntoDatasetEtatEntrepot(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatParametre.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATENTREPOT   @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
         public DataSet pvgInsertIntoDatasetEtatJournal(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatParametre.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATENTREPOT   @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

         public DataSet pvgInsertIntoDatasetEtatRayon(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, params string[] vppCritere)
         {

             vapNomParametre = new string[] { "@TYPEETAT"};
             vapValeurParametre = new object[] { clsEditionEtatParametre.ET_TYPEETAT };
             this.vapRequete = "EXEC PS_ETATRAYON   @TYPEETAT ";
             this.vapCritere = "";
             SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
             return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
         }

         public DataSet pvgInsertIntoDatasetEtatUnite(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, params string[] vppCritere)
         {

             vapNomParametre = new string[] { "@TYPEETAT"};
             vapValeurParametre = new object[] { clsEditionEtatParametre.ET_TYPEETAT };
             this.vapRequete = "EXEC PS_ETATUNITE   @TYPEETAT ";
             this.vapCritere = "";
             SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
             return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
         }


         public DataSet pvgInsertIntoDatasetEtatParamtre(clsDonnee clsDonnee, clsEditionEtatParametre clsEditionEtatParametre, params string[] vppCritere)
         {

             vapNomParametre = new string[] { "@CODEDECRYPTAGE", "@BT_CODETYPEBUDGET", "@TYPEETAT" };
             vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, clsEditionEtatParametre.BT_CODETYPEBUDGET.Replace("''", "'"), clsEditionEtatParametre.ET_TYPEETAT };
             this.vapRequete = "EXEC PS_ETATPARAMETRE  @BT_CODETYPEBUDGET,@CODEDECRYPTAGE, @TYPEETAT ";
             this.vapCritere = "";
             SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
             return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
         }

       

        #endregion
    }
}
