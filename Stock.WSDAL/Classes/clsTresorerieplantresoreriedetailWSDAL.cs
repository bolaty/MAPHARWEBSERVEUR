using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsTresorerieplantresoreriedetailWSDAL : ITableDAL<clsTresorerieplantresoreriedetail>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsTresorerieplantresoreriedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsTresorerieplantresoreriedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , TB_CODEPLANTRESORERIE  , SR_CODESERVICE  , TE_MONTANT  , TE_DATEVALIDATION  , TE_DATESAISIE  ,TE_DATEDEBUT,TE_DATEFIN, OP_CODEOPERATEURVALIDATION  , OP_CODEOPERATEUR  FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail = new clsTresorerieplantresoreriedetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsTresorerieplantresoreriedetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE = clsDonnee.vogDataReader["TB_CODEPLANTRESORERIE"].ToString();
                    //clsTresorerieplantresoreriedetail.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
                    clsTresorerieplantresoreriedetail.TE_MONTANT = double.Parse(clsDonnee.vogDataReader["TE_MONTANT"].ToString());

                    clsTresorerieplantresoreriedetail.TE_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["TE_DATEDEBUT"].ToString());
                    clsTresorerieplantresoreriedetail.TE_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["TE_DATEFIN"].ToString());


                    clsTresorerieplantresoreriedetail.TE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["TE_DATEVALIDATION"].ToString());
                    clsTresorerieplantresoreriedetail.TE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TE_DATESAISIE"].ToString());
                    clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION = clsDonnee.vogDataReader["OP_CODEOPERATEURVALIDATION"].ToString();
                    clsTresorerieplantresoreriedetail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsTresorerieplantresoreriedetail;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsTresorerieplantresoreriedetail>clsTresorerieplantresoreriedetail</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsTresorerieplantresoreriedetail.AG_CODEAGENCE;

            SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE1", SqlDbType.VarChar, 25);
            vppParamTB_CODEPLANTRESORERIE.Value = clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE;
            SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE1", SqlDbType.VarChar, 7);
            vppParamTP_CODEPOSTETRESORERIE.Value = clsTresorerieplantresoreriedetail.TP_CODEPOSTETRESORERIE;


            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE1", SqlDbType.VarChar, 2);
            vppParamPE_CODEPERIODICITE.Value = clsTresorerieplantresoreriedetail.PE_CODEPERIODICITE;


            SqlParameter vppParamTE_MONTANT = new SqlParameter("@TE_MONTANT1", SqlDbType.Money);
            vppParamTE_MONTANT.Value = clsTresorerieplantresoreriedetail.TE_MONTANT;




            SqlParameter vppParamTE_DATEDEBUT = new SqlParameter("@TE_DATEDEBUT1", SqlDbType.DateTime);
            vppParamTE_DATEDEBUT.Value = clsTresorerieplantresoreriedetail.TE_DATEDEBUT;

            SqlParameter vppParamTE_DATEFIN = new SqlParameter("@TE_DATEFIN1", SqlDbType.DateTime);
            vppParamTE_DATEFIN.Value = clsTresorerieplantresoreriedetail.TE_DATEFIN;







            SqlParameter vppParamTE_DATEVALIDATION = new SqlParameter("@TE_DATEVALIDATION1", SqlDbType.DateTime);
            vppParamTE_DATEVALIDATION.Value = clsTresorerieplantresoreriedetail.TE_DATEVALIDATION;
            if (clsTresorerieplantresoreriedetail.TE_DATEVALIDATION.Year < 1900) vppParamTE_DATEVALIDATION.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamTE_DATESAISIE = new SqlParameter("@TE_DATESAISIE1", SqlDbType.DateTime);
            vppParamTE_DATESAISIE.Value = clsTresorerieplantresoreriedetail.TE_DATESAISIE;
            SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION1", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURVALIDATION.Value = clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION;
            if (clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION == "") vppParamOP_CODEOPERATEURVALIDATION.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsTresorerieplantresoreriedetail.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIEDETAIL  @AG_CODEAGENCE1, @TB_CODEPLANTRESORERIE1, @TP_CODEPOSTETRESORERIE1,@PE_CODEPERIODICITE1,@TE_DATEDEBUT1,@TE_DATEFIN1, @TE_MONTANT1, @TE_DATEVALIDATION1, @TE_DATESAISIE1, @OP_CODEOPERATEURVALIDATION1, @OP_CODEOPERATEUR1, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);

            vppSqlCmd.Parameters.Add(vppParamTE_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamTE_DATEFIN);

            vppSqlCmd.Parameters.Add(vppParamTE_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamTE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamTE_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsTresorerieplantresoreriedetail>clsTresorerieplantresoreriedetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsTresorerieplantresoreriedetail.AG_CODEAGENCE;
            SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE", SqlDbType.VarChar, 25);
            vppParamTB_CODEPLANTRESORERIE.Value = clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE;
            SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE", SqlDbType.VarChar, 7);
            vppParamTP_CODEPOSTETRESORERIE.Value = clsTresorerieplantresoreriedetail.TP_CODEPOSTETRESORERIE;
            //SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            //vppParamSR_CODESERVICE.Value = clsTresorerieplantresoreriedetail.SR_CODESERVICE;

            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE1", SqlDbType.VarChar, 2);
            vppParamPE_CODEPERIODICITE.Value = clsTresorerieplantresoreriedetail.PE_CODEPERIODICITE;

            SqlParameter vppParamTE_DATEDEBUT = new SqlParameter("@TE_DATEDEBUT", SqlDbType.DateTime);
            vppParamTE_DATEDEBUT.Value = clsTresorerieplantresoreriedetail.TE_DATEDEBUT;

            SqlParameter vppParamTE_DATEFIN = new SqlParameter("@TE_DATEFIN", SqlDbType.DateTime);
            vppParamTE_DATEFIN.Value = clsTresorerieplantresoreriedetail.TE_DATEFIN;


            SqlParameter vppParamTE_MONTANT = new SqlParameter("@TE_MONTANT", SqlDbType.Money);
            vppParamTE_MONTANT.Value = clsTresorerieplantresoreriedetail.TE_MONTANT;
            SqlParameter vppParamTE_DATEVALIDATION = new SqlParameter("@TE_DATEVALIDATION", SqlDbType.DateTime);
            vppParamTE_DATEVALIDATION.Value = clsTresorerieplantresoreriedetail.TE_DATEVALIDATION;
            if (clsTresorerieplantresoreriedetail.TE_DATEVALIDATION.Year < 1900) vppParamTE_DATEVALIDATION.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamTE_DATESAISIE = new SqlParameter("@TE_DATESAISIE", SqlDbType.DateTime);
            vppParamTE_DATESAISIE.Value = clsTresorerieplantresoreriedetail.TE_DATESAISIE;
            SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURVALIDATION.Value = clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION;
            if (clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION == "") vppParamOP_CODEOPERATEURVALIDATION.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsTresorerieplantresoreriedetail.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIEDETAIL  @AG_CODEAGENCE, @TB_CODEPLANTRESORERIE, @TP_CODEPOSTETRESORERIE, @PE_CODEPERIODICITE1,@TE_DATEDEBUT,@TE_DATEFIN, @TE_MONTANT, @TE_DATEVALIDATION, @TE_DATESAISIE, @OP_CODEOPERATEURVALIDATION, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);
            //vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);

            vppSqlCmd.Parameters.Add(vppParamTE_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamTE_DATEFIN);

            vppSqlCmd.Parameters.Add(vppParamTE_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamTE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamTE_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsTresorerieplantresoreriedetail>clsTresorerieplantresoreriedetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdateValidation(clsDonnee clsDonnee, clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsTresorerieplantresoreriedetail.AG_CODEAGENCE;


            SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE", SqlDbType.VarChar, 25);
            vppParamTB_CODEPLANTRESORERIE.Value = clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE;

            SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE1", SqlDbType.VarChar, 7);
            vppParamTP_CODEPOSTETRESORERIE.Value = clsTresorerieplantresoreriedetail.TP_CODEPOSTETRESORERIE;

            //SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            //vppParamSR_CODESERVICE.Value = clsTresorerieplantresoreriedetail.SR_CODESERVICE;

            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE1", SqlDbType.VarChar, 2);
            vppParamPE_CODEPERIODICITE.Value = clsTresorerieplantresoreriedetail.PE_CODEPERIODICITE;

            SqlParameter vppParamTE_DATEDEBUT = new SqlParameter("@TE_DATEDEBUT", SqlDbType.DateTime);
            vppParamTE_DATEDEBUT.Value = clsTresorerieplantresoreriedetail.TE_DATEDEBUT;

            SqlParameter vppParamTE_DATEFIN = new SqlParameter("@TE_DATEFIN", SqlDbType.DateTime);
            vppParamTE_DATEFIN.Value = clsTresorerieplantresoreriedetail.TE_DATEFIN;


            SqlParameter vppParamTE_DATEVALIDATION = new SqlParameter("@TE_DATEVALIDATION", SqlDbType.DateTime);
            vppParamTE_DATEVALIDATION.Value = clsTresorerieplantresoreriedetail.TE_DATEVALIDATION;

            SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURVALIDATION.Value = clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIEDETAIL  @AG_CODEAGENCE, @TB_CODEPLANTRESORERIE,@TP_CODEPOSTETRESORERIE1,@PE_CODEPERIODICITE1,@TE_DATEDEBUT,@TE_DATEFIN, 0, @TE_DATEVALIDATION, '', @OP_CODEOPERATEURVALIDATION, '', @CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);

            //vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);

            vppSqlCmd.Parameters.Add(vppParamTE_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamTE_DATEFIN);

            vppSqlCmd.Parameters.Add(vppParamTE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIEDETAIL  @AG_CODEAGENCE, @TB_CODEPLANTRESORERIE, '',@PE_CODEPERIODICITE,@TE_DATEDEBUT,@TE_DATEFIN,  '' , '' , '' , '' , '' , @CODECRYPTAGE, @TYPEOPERATION  ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTresorerieplantresoreriedetail </returns>
        ///<author>Home Technology</author>
        public List<clsTresorerieplantresoreriedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE, TE_MONTANT, TE_DATEVALIDATION, TE_DATESAISIE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsTresorerieplantresoreriedetail> clsTresorerieplantresoreriedetails = new List<clsTresorerieplantresoreriedetail>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail = new clsTresorerieplantresoreriedetail();
                    clsTresorerieplantresoreriedetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE = clsDonnee.vogDataReader["TB_CODEPLANTRESORERIE"].ToString();
                    clsTresorerieplantresoreriedetail.TP_CODEPOSTETRESORERIE = clsDonnee.vogDataReader["TP_CODEPOSTETRESORERIE"].ToString();
                    //clsTresorerieplantresoreriedetail.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
                    clsTresorerieplantresoreriedetail.TE_MONTANT = double.Parse(clsDonnee.vogDataReader["TE_MONTANT"].ToString());
                    clsTresorerieplantresoreriedetail.TE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["TE_DATEVALIDATION"].ToString());
                    clsTresorerieplantresoreriedetail.TE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TE_DATESAISIE"].ToString());
                    clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION = clsDonnee.vogDataReader["OP_CODEOPERATEURVALIDATION"].ToString();
                    clsTresorerieplantresoreriedetail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsTresorerieplantresoreriedetails.Add(clsTresorerieplantresoreriedetail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsTresorerieplantresoreriedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTresorerieplantresoreriedetail </returns>
        ///<author>Home Technology</author>
        public List<clsTresorerieplantresoreriedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsTresorerieplantresoreriedetail> clsTresorerieplantresoreriedetails = new List<clsTresorerieplantresoreriedetail>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE, TE_MONTANT, TE_DATEVALIDATION, TE_DATESAISIE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail = new clsTresorerieplantresoreriedetail();
                    clsTresorerieplantresoreriedetail.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODEPLANTRESORERIE"].ToString();
                    clsTresorerieplantresoreriedetail.TP_CODEPOSTETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODEPOSTETRESORERIE"].ToString();
                    //clsTresorerieplantresoreriedetail.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
                    clsTresorerieplantresoreriedetail.TE_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TE_MONTANT"].ToString());
                    clsTresorerieplantresoreriedetail.TE_DATEVALIDATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TE_DATEVALIDATION"].ToString());
                    clsTresorerieplantresoreriedetail.TE_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TE_DATESAISIE"].ToString());
                    clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEURVALIDATION"].ToString();
                    clsTresorerieplantresoreriedetail.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
                    clsTresorerieplantresoreriedetails.Add(clsTresorerieplantresoreriedetail);
                }
                Dataset.Dispose();
            }
            return clsTresorerieplantresoreriedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee, vppCritere);


            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET AND SR_CODESERVICE=@SR_CODESERVICE  AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";//--AND BE_DATEDEBUT>=@BE_DATEDEBUT AND BE_DATEFIN<=@BE_DATEFIN;
            //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET", "@SR_CODESERVICE", "@PE_CODEPERIODICITE", "@BE_DATEDEBUT", "@BE_DATEFIN", "@TYPEECRANT" };
            //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE", "@PE_CODEPERIODICITE", "@TE_DATEDEBUT", "@TE_DATEFIN", "@TYPEECRANT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };

            this.vapRequete = "SELECT *  FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@PE_CODEPERIODICITE,@TE_DATEDEBUT, @TE_DATEFIN,@TYPEECRANT,@CODECRYPTAGE) WHERE  TP_LIBELLE<>'' ";// this.vapCritere + " AND TE_DATEVALIDATION='01/01/1900'  ORDER BY AG_CODEAGENCE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TP_CODEPOSTETRESORERIE , TE_MONTANT FROM dbo.FT_TRESORERIEPLANTRESORERIEDETAIL(@AG_CODEAGENCE,@TB_CODEPLANTRESORERIE,@PE_CODEPERIODICITE,@CODECRYPTAGE) " + this.vapCritere + " AND TE_DATEVALIDATION='01/01/1900'  ORDER BY TP_CODEPOSTETRESORERIE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TB_CODEPLANTRESORERIE, TP_CODEPOSTETRESORERIE, SR_CODESERVICE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE AND TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE", "@TP_CODEPOSTETRESORERIE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE  ";//--AND TE_DATEDEBUT>=@TE_DATEDEBUT AND TE_DATEFIN<=@TE_DATEFIN;
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE",  "@TE_DATEDEBUT", "@TE_DATEFIN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE   AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";//--AND TE_DATEDEBUT>=@TE_DATEDEBUT AND TE_DATEFIN<=@TE_DATEFIN;
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE", "@PE_CODEPERIODICITE", "@TE_DATEDEBUT", "@TE_DATEFIN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

                case 6:
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE   AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";//--AND TE_DATEDEBUT>=@TE_DATEDEBUT AND TE_DATEFIN<=@TE_DATEFIN;
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE", "@PE_CODEPERIODICITE", "@TE_DATEDEBUT", "@TE_DATEFIN", "@TYPEOPERATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5] };
                break;



            }
        }
    }
}
