using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsMicbudgetdetailWSDAL : ITableDAL<clsMicbudgetdetail>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetdetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetdetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , BU_CODEBUDGET  , SR_CODESERVICE  , BE_MONTANT  , BE_DATEVALIDATION  , BE_DATESAISIE  ,BE_DATEDEBUT,BE_DATEFIN, OP_CODEOPERATEURVALIDATION  , OP_CODEOPERATEUR  FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMicbudgetdetail clsMicbudgetdetail = new clsMicbudgetdetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetdetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsMicbudgetdetail.BU_CODEBUDGET = clsDonnee.vogDataReader["BU_CODEBUDGET"].ToString();
                    clsMicbudgetdetail.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
                    clsMicbudgetdetail.BE_MONTANT = double.Parse(clsDonnee.vogDataReader["BE_MONTANT"].ToString());

                    clsMicbudgetdetail.BE_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEDEBUT"].ToString());
                    clsMicbudgetdetail.BE_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEFIN"].ToString());


                    clsMicbudgetdetail.BE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEVALIDATION"].ToString());
                    clsMicbudgetdetail.BE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["BE_DATESAISIE"].ToString());
                    clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION = clsDonnee.vogDataReader["OP_CODEOPERATEURVALIDATION"].ToString();
                    clsMicbudgetdetail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetdetail;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetdetail>clsMicbudgetdetail</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetdetail clsMicbudgetdetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudgetdetail.AG_CODEAGENCE;
            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET1", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudgetdetail.BU_CODEBUDGET;
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE1", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetdetail.BG_CODEPOSTEBUDGETAIRE;
            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE1", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsMicbudgetdetail.SR_CODESERVICE;

            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE1", SqlDbType.VarChar, 2);
            vppParamPE_CODEPERIODICITE.Value = clsMicbudgetdetail.PE_CODEPERIODICITE;


            SqlParameter vppParamBE_MONTANT = new SqlParameter("@BE_MONTANT1", SqlDbType.Money);
            vppParamBE_MONTANT.Value = clsMicbudgetdetail.BE_MONTANT;




            SqlParameter vppParamBE_DATEDEBUT = new SqlParameter("@BE_DATEDEBUT1", SqlDbType.DateTime);
            vppParamBE_DATEDEBUT.Value = clsMicbudgetdetail.BE_DATEDEBUT;

            SqlParameter vppParamBE_DATEFIN = new SqlParameter("@BE_DATEFIN1", SqlDbType.DateTime);
            vppParamBE_DATEFIN.Value = clsMicbudgetdetail.BE_DATEFIN;







            SqlParameter vppParamBE_DATEVALIDATION = new SqlParameter("@BE_DATEVALIDATION1", SqlDbType.DateTime);
            vppParamBE_DATEVALIDATION.Value = clsMicbudgetdetail.BE_DATEVALIDATION;
            if (clsMicbudgetdetail.BE_DATEVALIDATION.Year < 1900) vppParamBE_DATEVALIDATION.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamBE_DATESAISIE = new SqlParameter("@BE_DATESAISIE1", SqlDbType.DateTime);
            vppParamBE_DATESAISIE.Value = clsMicbudgetdetail.BE_DATESAISIE;
            SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION1", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURVALIDATION.Value = clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION;
            if (clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION == "") vppParamOP_CODEOPERATEURVALIDATION.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMicbudgetdetail.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETDETAIL  @AG_CODEAGENCE1, @BU_CODEBUDGET1, @BG_CODEPOSTEBUDGETAIRE1, @SR_CODESERVICE1,@PE_CODEPERIODICITE1,@BE_DATEDEBUT1,@BE_DATEFIN1, @BE_MONTANT1, @BE_DATEVALIDATION1, @BE_DATESAISIE1, @OP_CODEOPERATEURVALIDATION1, @OP_CODEOPERATEUR1, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);

            vppSqlCmd.Parameters.Add(vppParamBE_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBE_DATEFIN);

            vppSqlCmd.Parameters.Add(vppParamBE_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamBE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamBE_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetdetail>clsMicbudgetdetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetdetail clsMicbudgetdetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudgetdetail.AG_CODEAGENCE;
            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudgetdetail.BU_CODEBUDGET;
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetdetail.BG_CODEPOSTEBUDGETAIRE;
            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsMicbudgetdetail.SR_CODESERVICE;

            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE1", SqlDbType.VarChar, 2);
            vppParamPE_CODEPERIODICITE.Value = clsMicbudgetdetail.PE_CODEPERIODICITE;

            SqlParameter vppParamBE_DATEDEBUT = new SqlParameter("@BE_DATEDEBUT", SqlDbType.DateTime);
            vppParamBE_DATEDEBUT.Value = clsMicbudgetdetail.BE_DATEDEBUT;

            SqlParameter vppParamBE_DATEFIN = new SqlParameter("@BE_DATEFIN", SqlDbType.DateTime);
            vppParamBE_DATEFIN.Value = clsMicbudgetdetail.BE_DATEFIN;


            SqlParameter vppParamBE_MONTANT = new SqlParameter("@BE_MONTANT", SqlDbType.Money);
            vppParamBE_MONTANT.Value = clsMicbudgetdetail.BE_MONTANT;
            SqlParameter vppParamBE_DATEVALIDATION = new SqlParameter("@BE_DATEVALIDATION", SqlDbType.DateTime);
            vppParamBE_DATEVALIDATION.Value = clsMicbudgetdetail.BE_DATEVALIDATION;
            if (clsMicbudgetdetail.BE_DATEVALIDATION.Year < 1900) vppParamBE_DATEVALIDATION.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamBE_DATESAISIE = new SqlParameter("@BE_DATESAISIE", SqlDbType.DateTime);
            vppParamBE_DATESAISIE.Value = clsMicbudgetdetail.BE_DATESAISIE;
            SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURVALIDATION.Value = clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION;
            if (clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION == "") vppParamOP_CODEOPERATEURVALIDATION.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMicbudgetdetail.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETDETAIL  @AG_CODEAGENCE, @BU_CODEBUDGET, @BG_CODEPOSTEBUDGETAIRE, @SR_CODESERVICE,@PE_CODEPERIODICITE1,@BE_DATEDEBUT,@BE_DATEFIN, @BE_MONTANT, @BE_DATEVALIDATION, @BE_DATESAISIE, @OP_CODEOPERATEURVALIDATION, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);

            vppSqlCmd.Parameters.Add(vppParamBE_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBE_DATEFIN);

            vppSqlCmd.Parameters.Add(vppParamBE_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamBE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamBE_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetdetail>clsMicbudgetdetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdateValidation(clsDonnee clsDonnee, clsMicbudgetdetail clsMicbudgetdetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudgetdetail.AG_CODEAGENCE;

            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudgetdetail.BU_CODEBUDGET;

            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsMicbudgetdetail.SR_CODESERVICE;

            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE1", SqlDbType.VarChar, 2);
            vppParamPE_CODEPERIODICITE.Value = clsMicbudgetdetail.PE_CODEPERIODICITE;

            SqlParameter vppParamBE_DATEDEBUT = new SqlParameter("@BE_DATEDEBUT", SqlDbType.DateTime);
            vppParamBE_DATEDEBUT.Value = clsMicbudgetdetail.BE_DATEDEBUT;

            SqlParameter vppParamBE_DATEFIN = new SqlParameter("@BE_DATEFIN", SqlDbType.DateTime);
            vppParamBE_DATEFIN.Value = clsMicbudgetdetail.BE_DATEFIN;


            SqlParameter vppParamBE_DATEVALIDATION = new SqlParameter("@BE_DATEVALIDATION", SqlDbType.DateTime);
            vppParamBE_DATEVALIDATION.Value = clsMicbudgetdetail.BE_DATEVALIDATION;

            SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURVALIDATION.Value = clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETDETAIL  @AG_CODEAGENCE, @BU_CODEBUDGET,'', @SR_CODESERVICE,@PE_CODEPERIODICITE1,@BE_DATEDEBUT,@BE_DATEFIN, 0, @BE_DATEVALIDATION, '', @OP_CODEOPERATEURVALIDATION, '', @CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);

            vppSqlCmd.Parameters.Add(vppParamBE_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBE_DATEFIN);

            vppSqlCmd.Parameters.Add(vppParamBE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETDETAIL  @AG_CODEAGENCE, @BU_CODEBUDGET, '', @SR_CODESERVICE,@PE_CODEPERIODICITE,@BE_DATEDEBUT,@BE_DATEFIN,  '' , '' , '' , '' , '' , @CODECRYPTAGE, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetdetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetdetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_MONTANT, BE_DATEVALIDATION, BE_DATESAISIE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsMicbudgetdetail> clsMicbudgetdetails = new List<clsMicbudgetdetail>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetdetail clsMicbudgetdetail = new clsMicbudgetdetail();
                    clsMicbudgetdetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsMicbudgetdetail.BU_CODEBUDGET = clsDonnee.vogDataReader["BU_CODEBUDGET"].ToString();
                    clsMicbudgetdetail.BG_CODEPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetdetail.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
                    clsMicbudgetdetail.BE_MONTANT = double.Parse(clsDonnee.vogDataReader["BE_MONTANT"].ToString());
                    clsMicbudgetdetail.BE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEVALIDATION"].ToString());
                    clsMicbudgetdetail.BE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["BE_DATESAISIE"].ToString());
                    clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION = clsDonnee.vogDataReader["OP_CODEOPERATEURVALIDATION"].ToString();
                    clsMicbudgetdetail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsMicbudgetdetails.Add(clsMicbudgetdetail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetdetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetdetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetdetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMicbudgetdetail> clsMicbudgetdetails = new List<clsMicbudgetdetail>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_MONTANT, BE_DATEVALIDATION, BE_DATESAISIE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMicbudgetdetail clsMicbudgetdetail = new clsMicbudgetdetail();
                    clsMicbudgetdetail.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsMicbudgetdetail.BU_CODEBUDGET = Dataset.Tables["TABLE"].Rows[Idx]["BU_CODEBUDGET"].ToString();
                    clsMicbudgetdetail.BG_CODEPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetdetail.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
                    clsMicbudgetdetail.BE_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_MONTANT"].ToString());
                    clsMicbudgetdetail.BE_DATEVALIDATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_DATEVALIDATION"].ToString());
                    clsMicbudgetdetail.BE_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_DATESAISIE"].ToString());
                    clsMicbudgetdetail.OP_CODEOPERATEURVALIDATION = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEURVALIDATION"].ToString();
                    clsMicbudgetdetail.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
                    clsMicbudgetdetails.Add(clsMicbudgetdetail);
                }
                Dataset.Dispose();
            }
            return clsMicbudgetdetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee, vppCritere);
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET AND SR_CODESERVICE=@SR_CODESERVICE  AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";//--AND BE_DATEDEBUT>=@BE_DATEDEBUT AND BE_DATEFIN<=@BE_DATEFIN;
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET", "@SR_CODESERVICE", "@PE_CODEPERIODICITE", "@BE_DATEDEBUT", "@BE_DATEFIN", "@TYPEECRANT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
            if(vppCritere[6]!= "VALIDE")
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@PE_CODEPERIODICITE,@BE_DATEDEBUT, @BE_DATEFIN,@TYPEECRANT,@CODECRYPTAGE) " + this.vapCritere + " AND BE_DATEVALIDATION='01/01/1900'  ORDER BY BG_LIBELLE";
            else
                this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@PE_CODEPERIODICITE,@BE_DATEDEBUT, @BE_DATEFIN,@TYPEECRANT,@CODECRYPTAGE) " + this.vapCritere + " AND BE_DATEVALIDATION>'01/01/1900'  ORDER BY BG_LIBELLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourSauvegarde(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee, vppCritere);
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BE_DATEDEBUT>=@BE_DATEDEBUT AND BE_DATEFIN<=@BE_DATEFIN";
            vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@BE_DATEDEBUT", "@BE_DATEFIN", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] {  vppCritere[0],vppCritere[1],vppCritere[2], clsDonnee.vogCleCryptage};
            this.vapRequete = "EXEC PS_MICBUDGETDETAILAHISTORISER @AG_CODEAGENCE, @BE_DATEDEBUT, @BE_DATEFIN,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BG_CODEPOSTEBUDGETAIRE , BE_MONTANT FROM dbo.FT_MICBUDGETDETAIL(@AG_CODEAGENCE,@BU_CODEBUDGET,@SR_CODESERVICE,@PE_CODEPERIODICITE,@CODECRYPTAGE) " + this.vapCritere + " AND BE_DATEVALIDATION='01/01/1900'  ORDER BY BG_LIBELLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET AND SR_CODESERVICE=@SR_CODESERVICE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET", "@SR_CODESERVICE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET AND SR_CODESERVICE=@SR_CODESERVICE ";//--AND BE_DATEDEBUT>=@BE_DATEDEBUT AND BE_DATEFIN<=@BE_DATEFIN;
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET", "@SR_CODESERVICE", "@BE_DATEDEBUT", "@BE_DATEFIN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
                case 6:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET AND SR_CODESERVICE=@SR_CODESERVICE  AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";//--AND BE_DATEDEBUT>=@BE_DATEDEBUT AND BE_DATEFIN<=@BE_DATEFIN;
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET", "@SR_CODESERVICE", "@PE_CODEPERIODICITE", "@BE_DATEDEBUT", "@BE_DATEFIN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                    break;

                case 7:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET AND SR_CODESERVICE=@SR_CODESERVICE  AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";//--AND BE_DATEDEBUT>=@BE_DATEDEBUT AND BE_DATEFIN<=@BE_DATEFIN;
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET", "@SR_CODESERVICE", "@PE_CODEPERIODICITE", "@BE_DATEDEBUT", "@BE_DATEFIN", "@TYPEOPERATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] , vppCritere[6] };
                break;



            }
        }
    }
}
