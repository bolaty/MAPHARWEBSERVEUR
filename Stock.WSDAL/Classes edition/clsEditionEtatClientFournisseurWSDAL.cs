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
  public  class clsEditionEtatClientFournisseurWSDAL
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
        public DataSet pvgInsertIntoDatasetEtatConsultation(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MATRICULE", "@MS_NUMPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@DATEJOURNEE", "@TYPEETAT", "@OP_CODEOPERATEUREDITION", "@NO_CODENATUREOPERATION", "@CA_CODECONTRAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'"), vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9].Replace("''", "'"),vppCritere[10].Replace("''", "'"), clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCONSULTATION    @AG_CODEAGENCE,@EN_CODEENTREPOT, @MATRICULE,@MS_NUMPIECE,@MC_DATEPIECE1, @MC_DATEPIECE2,@DATEJOURNEE,@TYPEETAT,@OP_CODEOPERATEUREDITION,@NO_CODENATUREOPERATION,@CA_CODECONTRAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatConsultationReleveCommercial(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CO_NUMCOMMERCIAL", "@MS_NUMPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@DATEJOURNEE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6],vppCritere[7], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATRELEVECOMMERCIAL    @AG_CODEAGENCE,@EN_CODEENTREPOT, @CO_NUMCOMMERCIAL,@MS_NUMPIECE,@MC_DATEPIECE1, @MC_DATEPIECE2,@DATEJOURNEE,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatConsultationListeVentCommercial(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CO_NUMCOMMERCIAL", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@TYPEETAT", "@OP_CODEOPERATEUREDITION", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5],vppCritere[6], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATVENTECOMMERCIAL    @AG_CODEAGENCE,@EN_CODEENTREPOT, @CO_NUMCOMMERCIAL,@MC_DATEPIECE1, @MC_DATEPIECE2,@TYPEETAT,@OP_CODEOPERATEUREDITION, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }





        public DataSet pvgInsertIntoDatasetReglementCommission(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CO_NUMCOMMERCIAL", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@DATEJOURNEE", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_SITUATIONCOMMISSIONCOMMERCIAL    @AG_CODEAGENCE,  @EN_CODEENTREPOT, @CO_NUMCOMMERCIAL,@MC_DATEPIECE1, @MC_DATEPIECE2,@DATEJOURNEE,@CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatClientFournisseur(clsDonnee clsDonnee,clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUREDITION ", "@TP_CODETYPECLIENT", "@TC_CODECOMPTETYPETIERS", "@SC_CODESECTION", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@TI_ASDI", "@TI_TVA", "@GP_CODEGROUPE", "@PY_CODEPAYS", "@NT_CODENATURETIERS", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatClientFournisseur.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatClientFournisseur.OP_CODEOPERATEUREDITION, clsEditionEtatClientFournisseur.TP_CODETYPECLIENT.Replace("''", "'"), clsEditionEtatClientFournisseur.TC_CODECOMPTETYPETIERS.Replace("''", "'"), clsEditionEtatClientFournisseur.SC_CODESECTION, clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS1, clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsEditionEtatClientFournisseur.TI_ASDI, clsEditionEtatClientFournisseur.TI_TVA, clsEditionEtatClientFournisseur.GP_CODEGROUPE.Replace("''", "'"),clsEditionEtatClientFournisseur.PY_CODEPAYS, clsEditionEtatClientFournisseur.NT_CODENATURETIERS.Replace("''", "'"), clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCLIENTFOURNISSEUR    @AG_CODEAGENCE,@EN_CODEENTREPOT, @OP_CODEOPERATEUREDITION , @TP_CODETYPECLIENT,@TC_CODECOMPTETYPETIERS,@SC_CODESECTION,@MC_DATEPIECE1,@MC_DATEPIECE2,@TI_ASDI,@TI_TVA,@GP_CODEGROUPE,@PY_CODEPAYS,@NT_CODENATURETIERS,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatNatureTiers(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@TP_CODETYPECLIENT",  "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] {  clsEditionEtatClientFournisseur.TP_CODETYPECLIENT.Replace("''", "'"),  clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATNATURETIERS    @TP_CODETYPECLIENT,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatRDV(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@GP_CODEGROUPE", "@MS_DATERENDEZVOUS1 ", "@MS_DATERENDEZVOUS2", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatClientFournisseur.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatClientFournisseur.GP_CODEGROUPE.Replace("''", "'"), clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS1, clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATRDV    @AG_CODEAGENCE,@EN_CODEENTREPOT,@GP_CODEGROUPE, @MS_DATERENDEZVOUS1,@MS_DATERENDEZVOUS2, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatTypeClient(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] {  "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTYPETIERS    @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatTypeFournisseur(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] {  "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTYPEFOURNISSEUR    @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatListeChauffeur(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TC_CODECOMPTETYPETIERS", "@CH_DATESAISIE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatClientFournisseur.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatClientFournisseur.TC_CODECOMPTETYPETIERS.Replace("''", "'"), clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCHAUFFEUR     @AG_CODEAGENCE,@EN_CODEENTREPOT,@TC_CODECOMPTETYPETIERS,@CH_DATESAISIE,@TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatListeFournisseurBon(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@FB_DATESAISIE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATFOURNISSEURBON   @FB_DATESAISIE, @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatListeTiers(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] {  "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATTYPETIERS    @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        public DataSet pvgInsertIntoDatasetEtatListeVehicule(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatClientFournisseur.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATVEHICULE   @AG_CODEAGENCE, @EN_CODEENTREPOT, @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetEtatListeCommerciaux(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CO_DATESAISIE", "@TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatClientFournisseur.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATCOMMERCIAL   @AG_CODEAGENCE,@EN_CODEENTREPOT,@CO_DATESAISIE, @TYPEETAT, @CODEDECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        public DataSet pvgInsertIntoDatasetEtatRelence(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@MR_CODEMODEREGLEMENT", "@NO_CODENATUREOPERATION", "@TYPEETAT", "@CODEDECRYPTAGE" };
            //vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.MR_CODEMODEREGLEMENT.Replace("''", "'"), clsEditionEtatCaisse.NO_CODENATUREOPERATION.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@GP_CODEGROUPE", "@TC_CODECOMPTETYPETIERS", "@DATEDEBUT", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatClientFournisseur.EN_CODEENTREPOT.Replace("''", "'"), clsEditionEtatClientFournisseur.GP_CODEGROUPE.Replace("''", "'"), clsEditionEtatClientFournisseur.TC_CODECOMPTETYPETIERS.Replace("''", "'"), clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsEditionEtatClientFournisseur.OP_CODEOPERATEUREDITION, clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATRELANCE  @AG_CODEAGENCE,@EN_CODEENTREPOT,@GP_CODEGROUPE,@TC_CODECOMPTETYPETIERS,@DATEDEBUT, @OP_CODEOPERATEUREDITION,@ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetEtatFactureCumulee(clsDonnee clsDonnee, clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur, params string[] vppCritere)
        {

            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUREDITION ", "@DATEDEBUT", "@DATEFIN", "@MR_CODEMODEREGLEMENT", "@NO_CODENATUREOPERATION", "@TYPEETAT", "@CODEDECRYPTAGE" };
            //vapValeurParametre = new object[] { clsEditionEtatCaisse.AG_CODEAGENCE.Replace("''", "'"), clsEditionEtatCaisse.OP_CODEOPERATEUREDITION, clsEditionEtatCaisse.DATEDEBUT, clsEditionEtatCaisse.DATEFIN, clsEditionEtatCaisse.MR_CODEMODEREGLEMENT.Replace("''", "'"), clsEditionEtatCaisse.NO_CODENATUREOPERATION.Replace("''", "'"), clsEditionEtatCaisse.ET_TYPEETAT, clsDonnee.vogCleCryptage };

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_NUMTIERS", "@DATEDEBUT", "@DATEFIN", "@OP_CODEOPERATEUREDITION", "@GP_CODEGROUPE", "@MS_NUMPIECEPARAM", "@ET_TYPEETAT", "@CODEDECRYPTAGE" };
            vapValeurParametre = new object[] { clsEditionEtatClientFournisseur.AG_CODEAGENCE, clsEditionEtatClientFournisseur.EN_CODEENTREPOT, clsEditionEtatClientFournisseur.TI_NUMTIERS, clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS1, clsEditionEtatClientFournisseur.MS_DATERENDEZVOUS2, clsEditionEtatClientFournisseur.OP_CODEOPERATEUREDITION, clsEditionEtatClientFournisseur.GP_CODEGROUPE, clsEditionEtatClientFournisseur.MS_NUMPIECEPARAM.Replace("''", "'"), clsEditionEtatClientFournisseur.ET_TYPEETAT, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_ETATFACTURECUMULEE  @AG_CODEAGENCE,@EN_CODEENTREPOT,@TI_NUMTIERS,@DATEDEBUT, @DATEFIN,@OP_CODEOPERATEUREDITION,@GP_CODEGROUPE,@MS_NUMPIECEPARAM,@ET_TYPEETAT,@CODEDECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        #endregion
    }
}
