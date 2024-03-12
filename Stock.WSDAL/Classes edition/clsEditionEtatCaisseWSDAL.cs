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
  public  class clsEditionEtatCaisseWSDAL
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
        //public DataSet pvgInsertIntoDatasetEtatConsultation(clsDonnee clsDonnee, params string[] vppCritere)
        //{

        //    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MATRICULE", "@MS_NUMPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@TYPEETAT", "@CODEDECRYPTAGE" };
        //    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5],  clsDonnee.vogCleCryptage };
        //    this.vapRequete = "EXEC PS_ETATCONSULTATION    @AG_CODEAGENCE, @MATRICULE,@MS_NUMPIECE,@MC_DATEPIECE1, @MC_DATEPIECE2,@TYPEETAT, @CODEDECRYPTAGE";
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        //}

        public DataSet pvgInsertIntoDatasetEtatBrouillard(clsDonnee clsDonnee,clsEditionEtatCaisse clsEditionEtatCaisse, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@MR_CODEMODEREGLEMENT", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE, clsEditionEtatCaisse.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.MR_CODEMODEREGLEMENT.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCAISSE   @AG_CODEAGENCE,@EN_CODEENTREPOT, @OP_CODEOPERATEUREDITION ,@DATEDEBUT,@DATEFIN,@MR_CODEMODEREGLEMENT,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatGdLivre(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, params string[] vppCritere)
        {

            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@MR_CODEMODEREGLEMENT", "@NO_CODENATUREOPERATION", "@TYPEETAT", "@CODEDECRYPTAGE" };
            //vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.MR_CODEMODEREGLEMENT.Replace("''", "'"), clsEditionEtatCaisse.NO_CODENATUREOPERATION.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TP_CODETYPETIERS", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@PL_NUMCOMPTE1", "@PL_NUMCOMPTE2", "@PL_NUMCOMPTETIERS", "@MR_CODEMODEREGLEMENT", "@NO_CODENATUREOPERATION", "@JO_CODEJOURNAL", "@MV_STATUTGLVRE", "@OP_CODEOPERATEUR", "@GP_CODEGROUPE", "@PY_CODEPAYS", "@NT_CODENATURETIERS", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatCaisse.TP_CODETYPETIERS.Replace("''", "'"), clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.PL_NUMCOMPTE1, clsEditionEtatCaisse.PL_NUMCOMPTE2,clsEditionEtatCaisse.PL_NUMCOMPTETIERS, clsEditionEtatCaisse.MR_CODEMODEREGLEMENT, clsEditionEtatCaisse.NO_CODENATUREOPERATION, clsEditionEtatCaisse.JO_CODEJOURNAL,clsEditionEtatCaisse.MV_STATUTGLVRE, clsEditionEtatCaisse.OP_CODEOPERATEUR, clsEditionEtatCaisse.GP_CODEGROUPE.Replace("''", "'"), clsEditionEtatCaisse.PY_CODEPAYS,clsEditionEtatCaisse.NT_CODENATURETIERS.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCAISSEGDLIVRE  @AG_CODEAGENCE,@EN_CODEENTREPOT,@TP_CODETYPETIERS, @OP_CODEOPERATEUREDITION , @DATEDEBUT,@DATEFIN,@PL_NUMCOMPTE1, @PL_NUMCOMPTE2,@PL_NUMCOMPTETIERS,@MR_CODEMODEREGLEMENT,@NO_CODENATUREOPERATION,@JO_CODEJOURNAL,@MV_STATUTGLVRE,@OP_CODEOPERATEUR,@GP_CODEGROUPE,@PY_CODEPAYS,@NT_CODENATURETIERS,@TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatResultat(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, params string[] vppCritere)
        {

            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@MR_CODEMODEREGLEMENT", "@NO_CODENATUREOPERATION", "@TYPEETAT", "@CODEDECRYPTAGE" };
            //vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.MR_CODEMODEREGLEMENT.Replace("''", "'"), clsEditionEtatCaisse.NO_CODENATUREOPERATION.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TP_CODETYPETIERS", "@DATEDEBUT", "@DATEFIN", "@PL_NUMCOMPTE1", "@PL_NUMCOMPTE2", "@PL_NUMCOMPTETIERS", "@PL_OPTION", "@OP_CODEOPERATEUREDITION", "@GP_CODEGROUPE", "@PY_CODEPAYS", "@NT_CODENATURETIERS", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatCaisse.TP_CODETYPETIERS.Replace("''", "'"), clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.PL_NUMCOMPTE1, clsEditionEtatCaisse.PL_NUMCOMPTE2, clsEditionEtatCaisse.PL_NUMCOMPTETIERS, clsEditionEtatCaisse.PL_OPTION, clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.GP_CODEGROUPE.Replace("''", "'"), clsEditionEtatCaisse.PY_CODEPAYS,clsEditionEtatCaisse.NT_CODENATURETIERS.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATSITUATIONOPERATIONS  @AG_CODEAGENCE,@EN_CODEENTREPOT, @TP_CODETYPETIERS,  @DATEDEBUT,@DATEFIN,@PL_NUMCOMPTE1, @PL_NUMCOMPTE2,@PL_NUMCOMPTETIERS,@PL_OPTION,@OP_CODEOPERATEUREDITION,@GP_CODEGROUPE,@PY_CODEPAYS,@NT_CODENATURETIERS, @ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatPointPrestations(clsDonnee clsDonnee, clsEditionEtatCaisse clsEditionEtatCaisse, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TP_CODETYPETIERS", "@DATEDEBUT", "@DATEFIN",  "@OP_CODEOPERATEUREDITION", "@GP_CODEGROUPE",  "@NT_CODENATURETIERS", "@TI_IDTIERSMEDECIN", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatCaisse.TP_CODETYPETIERS.Replace("''", "'"), clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.GP_CODEGROUPE.Replace("''", "'"),  clsEditionEtatCaisse.NT_CODENATURETIERS.Replace("''", "'"),clsEditionEtatCaisse.TI_IDTIERSMEDECIN, clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATPOINTPRESTATIONS  @AG_CODEAGENCE,@EN_CODEENTREPOT, @TP_CODETYPETIERS,  @DATEDEBUT,@DATEFIN,@OP_CODEOPERATEUREDITION,@GP_CODEGROUPE,@NT_CODENATURETIERS,@TI_IDTIERSMEDECIN, @ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(vppCritere);

            //this.vapCritere = " WHERE ET_NOMGROUPE=@ET_NOMGROUPE AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ET_AFFICHER='O' AND OD_APERCU='O' ORDER BY ET_NUMEROORDRE";
            vapNomParametre = new string[] { "@ET_TYPEETAT" };
            vapValeurParametre = new object[] { "ET_TYPEETAT" };

            this.vapRequete = "EXEC PS_ETATBILAN @ET_TYPEETAT";// +this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetActifCirculant(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM VUE_TEST_ETAT";  // +this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



       

        #endregion
    }
}
