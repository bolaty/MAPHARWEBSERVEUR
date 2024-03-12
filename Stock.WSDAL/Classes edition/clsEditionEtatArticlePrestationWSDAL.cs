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
  public  class clsEditionEtatArticlePrestationWSDAL
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
        public DataSet pvgInsertIntoDatasetEtatArticlePrestation(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TF_CODETYPEFOURNISSEUR", "@NT_CODENATURETIERS", "@TA_CODETYPEARTICLE", "@TP_DATEJOUR", "@DATEJOURNEE1", "@JF_CODETYPEJOURFACTURATION1", "@LF_CODELIEUFACTURATION1", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2].Replace("''", "'"), vppCritere[3].Replace("''", "'"), vppCritere[4].Replace("''", "'"), vppCritere[5], vppCritere[6], vppCritere[7],vppCritere[8],vppCritere[9], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARCTICLEPRESTATION @AG_CODEAGENCE,@EN_CODEENTREPOT,@TF_CODETYPEFOURNISSEUR,@NT_CODENATURETIERS,@TA_CODETYPEARTICLE,@TP_DATEJOUR,@DATEJOURNEE1, @JF_CODETYPEJOURFACTURATION1, @LF_CODELIEUFACTURATION1,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        public DataSet pvgInsertIntoDatasetEtatMargeBeneficiaire(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TF_CODETYPEFOURNISSEUR", "@TP_CODETYPECLIENT", "@TA_CODETYPEARTICLE", "@TP_CODETYPEPRESTATION", "@TP_DATEJOUR","@TP_DATEJOUR1", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2].Replace("''", "'"), vppCritere[3].Replace("''", "'"), vppCritere[4].Replace("''", "'"), vppCritere[5], vppCritere[6],vppCritere[7], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATMARGEBENEFICIAIRE @AG_CODEAGENCE,@TF_CODETYPEFOURNISSEUR,@TP_CODETYPECLIENT,@TA_CODETYPEARTICLE,@TP_CODETYPEPRESTATION,@TP_DATEJOUR,@TP_DATEJOUR1,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatHistorisationChambre(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_NUMPIECE", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],  vppCritere[2],vppCritere[3],vppCritere[4],  clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATHISTORIQUEOCCUPATIONCHAMBRE @AG_CODEAGENCE,@EN_CODEENTREPOT,@MS_NUMPIECE,@OP_CODEOPERATEUREDITION,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatArticleMoinCher(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TA_CODETYPEARTICLE",  "@DATEJOURNEE1","@DATEJOURNEE2", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"),  vppCritere[2],vppCritere[3],  clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARCTICLEMOINSCHER @AG_CODEAGENCE,@TA_CODETYPEARTICLE,@DATEJOURNEE1,@DATEJOURNEE2,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatSituationArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@DATEDEBUT", "@DATEFIN", "@DATEJOURNEE", "@ET_TYPEETAT", "@NO_CODENATUREOPERATION1", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2].Replace("''", "'"), vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCONSULTATIONARTICLE @AG_CODEAGENCE,@EN_CODEENTREPOT,@AR_CODEARTICLE,@DATEDEBUT,@DATEFIN,@DATEJOURNEE,@ET_TYPEETAT,@NO_CODENATUREOPERATION1,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatPrixArticleHisto(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AR_CODEARTICLE", "@DATEDEBUT", "@DATEFIN", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],vppCritere[2],vppCritere[3],  clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATHISTORIQUECOUTARTICLE @AR_CODEARTICLE,@DATEDEBUT,@DATEFIN,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TA_CODETYPEARTICLE","@AR_DATECREATION", "@ET_TYPEETAT",  "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2], vppCritere[3], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARTICLE @AG_CODEAGENCE,@TA_CODETYPEARTICLE,@AR_DATECREATION,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatArticleChambreDispinible(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@DATEJOURNEE", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARTICLECHAMBREDISPONIBLE @DATEJOURNEE,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatArticleChambreFicheActivite(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TA_CODETYPEARTICLE", "@DATEDEBUT", "@DATEFIN", "@NT_CODENATURETIERS", "@ET_TYPEETAT", "@OP_CODEOPERATEUREDITION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2].Replace("''", "'"), vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARTICLECHAMBREFICHEACTIVITE @AG_CODEAGENCE,@EN_CODEENTREPOT,@TA_CODETYPEARTICLE,@DATEDEBUT,@DATEFIN,@NT_CODENATURETIERS,@ET_TYPEETAT,@OP_CODEOPERATEUREDITION,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatArticleChambreFicheActiviteCompte(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT","@DATEJOURNEE",  "@OP_CODEOPERATEUREDITION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2],  vppCritere[3],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARTICLECHAMBREFICHEACTIVITECOMPTE @AG_CODEAGENCE,@EN_CODEENTREPOT,@DATEJOURNEE,@OP_CODEOPERATEUREDITION,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        public DataSet pvgInsertIntoDatasetEtatForme(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATFORME @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatMarque(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATMARQUE @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatModel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATMODEL @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatFabriquant(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATFABRIQUANT @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatPromotion(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@NT_CODENATURETIERS", "@TA_CODETYPEARTICLE", "@DATEJOURNEE", "@TYPEMONTANT", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2].Replace("''", "'"), vppCritere[3].Replace("''", "'"), vppCritere[4], vppCritere[5], vppCritere[6],vppCritere[7],vppCritere[8], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATPROMOTION @AG_CODEAGENCE, @EN_CODEENTREPOT,@NT_CODENATURETIERS,@TA_CODETYPEARTICLE,@DATEJOURNEE,@TYPEMONTANT,@JF_CODETYPEJOURFACTURATION,@LF_CODELIEUFACTURATION, @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatTypeArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTYPEARTICLE @NT_CODENATURETYPEARTICLE,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatTypePrestation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTYPEPRESTATION @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatDestinationArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATDESTINATIONARTICLE @ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatIntervention(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_IDTIERS", "@OP_CODEOPERATEUREDITION", "@DATEDEBUT", "@DATEFIN", "@AR_CODEARTICLE", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_ETATINTERVENTION] @AG_CODEAGENCE,@EN_CODEENTREPOT,@TI_IDTIERS,@OP_CODEOPERATEUREDITION,@DATEDEBUT,@DATEFIN,@AR_CODEARTICLE,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatDestinationArticlePHOTO(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //vapNomParametre = new string[] { "@ET_TYPEETAT", "@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { vppCritere[0], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM PHAPARARTICLEPHOTO";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        #endregion
    }
}
