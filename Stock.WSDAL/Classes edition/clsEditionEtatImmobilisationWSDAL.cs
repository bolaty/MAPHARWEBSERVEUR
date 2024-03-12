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
  public  class clsEditionEtatImmobilisationWSDAL
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


        public DataSet pvgETATIMMOBILISATIONAMORTISSEMENT(clsDonnee clsDonnee, clsEditionEtatImmobilisation clsEditionEtatImmobilisation, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@PV_CODEPOINTVENTE", "@DateJourneeComptable1","@DateJourneeComptable2", "@OP_CODEOPERATEUR", "@OP_CODEOPERATEUREDITION", "@PS_CODESOUSPRODUIT", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatImmobilisation.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatImmobilisation.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatImmobilisation.DATEDEBUT,  clsEditionEtatImmobilisation.DATEFIN, clsEditionEtatImmobilisation.OP_CODEOPERATEUR, clsEditionEtatImmobilisation.OP_CODEOPERATEUREDITION, clsEditionEtatImmobilisation.PS_CODESOUSPRODUIT.Replace("''", "'"),clsEditionEtatImmobilisation.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATIMMOBILISATIONAMORTISSEMENT @AG_CODEAGENCE,@PV_CODEPOINTVENTE,@DateJourneeComptable1,@DateJourneeComptable2,@OP_CODEOPERATEUR,@OP_CODEOPERATEUREDITION,@PS_CODESOUSPRODUIT,@ET_TYPEETAT,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgETATFAMILLEIMMOBILISATION(clsDonnee clsDonnee, clsEditionEtatImmobilisation clsEditionEtatImmobilisation, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT", "@PS_DATESAISIE", "@OP_CODEOPERATEUREDITION", "@TYPEETAT" };
            vapValeurParametre = new object[] { clsEditionEtatImmobilisation.PS_CODESOUSPRODUIT.Replace("''", "'"),  clsEditionEtatImmobilisation.DATEFIN,  clsEditionEtatImmobilisation.OP_CODEOPERATEUREDITION, clsEditionEtatImmobilisation.ET_TYPEETAT };
            this.vapRequete = "EXEC PS_ETATBIENIMMOBILISEFAMILLE @PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT,@PS_DATESAISIE,@OP_CODEOPERATEUREDITION,@TYPEETAT ";

            //this.vapRequete = "SELECT * FROM VUE_ETATBIENIMMOBILISEFAMILLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgETATTABLEAUAMORTISSEMENT(clsDonnee clsDonnee, clsEditionEtatImmobilisation clsEditionEtatImmobilisation, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TI_IDTIERS", "@OP_CODEOPERATEUREDITION", "@TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatImmobilisation.AG_CODEAGENCE,  clsEditionEtatImmobilisation.TI_IDTIERS,  clsEditionEtatImmobilisation.OP_CODEOPERATEUREDITION, clsEditionEtatImmobilisation.ET_TYPEETAT,clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTABLEAMORTISSEMENT @AG_CODEAGENCE,@TI_IDTIERS,@OP_CODEOPERATEUREDITION,@TYPEETAT,@CODECRYPTAGE ";

            //this.vapRequete = "SELECT * FROM VUE_ETATBIENIMMOBILISEFAMILLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        #endregion
    }
}
