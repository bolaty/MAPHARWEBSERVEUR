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
  public  class clsEditionEtatStockWSDAL
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

        public DataSet pvgInsertIntoDatasetEtatStock(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TA_CODETYPEARTICLE", "@AR_CODEARTICLE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@NT_CODENATURETIERS", "@MF_IDFILTRAGEDESTOCK", "@ME_IDFILTRAGEDESTOCKEXPIRATION", "@MF_IDFILTRAGEDESTOCKM1", "@MF_IDFILTRAGEDESTOCKM2", "@TYPELISTE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"),vppCritere[2].Replace("''", "'"),vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7], vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATSTOCK    @AG_CODEAGENCE,@EN_CODEENTREPOT,@TA_CODETYPEARTICLE,@AR_CODEARTICLE,@MC_DATEPIECE1,@MC_DATEPIECE2,@NT_CODENATURETIERS,@MF_IDFILTRAGEDESTOCK,@ME_IDFILTRAGEDESTOCKEXPIRATION,@MF_IDFILTRAGEDESTOCKM1,@MF_IDFILTRAGEDESTOCKM2,@TYPELISTE,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatStockTransFert(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_NUMPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@MS_ANNULATIONPIECE", "@NO_CODENATUREOPERATION1", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6].Replace("''", "'"),vppCritere[7], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATPHAMOUVEMENTSTOCKTRANSFERT    @AG_CODEAGENCE,@EN_CODEENTREPOT,@MS_NUMPIECE,@MC_DATEPIECE1,@MC_DATEPIECE2,@MS_ANNULATIONPIECE,@NO_CODENATUREOPERATION1,@ET_TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        //Mise à jour de COMPTE
        public void pvgMiseAJourZeCaisse(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@DATEJOURNEE1", "@DATEJOURNEE2", "@ZC_CODE1", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],vppCritere[2],vppCritere[3], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAZDECAISSEEDITION @AG_CODEAGENCE,@DATEJOURNEE1,@DATEJOURNEE2,@ZC_CODE1,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        public DataSet pvgInsertIntoDatasetEtatFacture(clsDonnee clsDonnee, params string[] vppCritere)
        {

            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            //vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM VUE_ETATFACTURE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatCommande(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@DATEJOURNEE1", "@DATEJOURNEE2", "@TP_CODETYPETIERS", "@ET_TYPEETAT", "@ET_TYPELISTE", "@OP_CODEOPERATEUREDITION", "@GP_CODEGROUPE", "@PY_CODEPAYS", "@NT_CODENATURETIERS", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8].Replace("''", "'"), vppCritere[9],vppCritere[10].Replace("''", "'"), clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCOMMANDE @AG_CODEAGENCE,@EN_CODEENTREPOT, @DATEJOURNEE1,@DATEJOURNEE2,@TP_CODETYPETIERS,@ET_TYPEETAT,@ET_TYPELISTE,@OP_CODEOPERATEUREDITION,@GP_CODEGROUPE,@PY_CODEPAYS,@NT_CODENATURETIERS, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatSitutionFournisseurBon(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@DATEJOURNEE1", "@DATEJOURNEE2", "@FB_IDFOURNISSEUR", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATSITUATIONFOURNISSEURBON @AG_CODEAGENCE,@DATEJOURNEE1,@DATEJOURNEE2,@FB_IDFOURNISSEUR,@ET_TYPEETAT,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatInventaire(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@DATEJOURNEE1", "@DATEJOURNEE2", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2], vppCritere[3],vppCritere[4],  clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATINVENTAIRE @AG_CODEAGENCE,@EN_CODEENTREPOT,@DATEJOURNEE1,@DATEJOURNEE2,@ET_TYPEETAT,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        public DataSet pvgInsertIntoDatasetEtatSituationArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TA_CODETYPEARTICLE", "@AR_CODEARTICLE", "@AR_DATEDEBUT", "@AR_DATEFIN", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2].Replace("''", "'"), vppCritere[3], vppCritere[4],vppCritere[5], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATARTICLEPERIMES @AG_CODEAGENCE,@TA_CODETYPEARTICLE,@AR_CODEARTICLE,@AR_DATEDEBUT,@AR_DATEFIN,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatRepartition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_NUMPIECE", "@NUMEROBORDEREAU",  "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],  clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATREAPARTION @AG_CODEAGENCE,@EN_CODEENTREPOT,@MS_NUMPIECE,@NUMEROBORDEREAU,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatMvtStockQualite(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_NUMPIECE", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATPHAMOUVEMENTSTOCKPHAPARQUALITE @AG_CODEAGENCE,@EN_CODEENTREPOT,@MS_NUMPIECE,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatMvtStockRetenues(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_NUMPIECE", "@ET_TYPEETAT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATPHAMOUVEMENTSTOCKPHAPARRETENUE @AG_CODEAGENCE,@EN_CODEENTREPOT,@MS_NUMPIECE,@ET_TYPEETAT,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        #endregion
    }
}
