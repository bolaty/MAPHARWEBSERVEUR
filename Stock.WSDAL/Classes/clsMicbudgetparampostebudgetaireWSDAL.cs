using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsMicbudgetparampostebudgetaireWSDAL : ITableDAL<clsMicbudgetparampostebudgetaire>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetparampostebudgetaire comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetparampostebudgetaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BD_CODETYPEBUDGETDETAIL  , BN_CODENATUREPOSTEBUDGETAIRE  , BG_LIBELLE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new clsMicbudgetparampostebudgetaire();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = clsDonnee.vogDataReader["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetaire.BG_LIBELLE = clsDonnee.vogDataReader["BG_LIBELLE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparampostebudgetaire;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparampostebudgetaire>clsMicbudgetparampostebudgetaire</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire)
        {
            //Préparation des paramètres
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE;
            SqlParameter vppParamBD_CODETYPEBUDGETDETAIL = new SqlParameter("@BD_CODETYPEBUDGETDETAIL", SqlDbType.VarChar, 4);
            vppParamBD_CODETYPEBUDGETDETAIL.Value = clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL;
            SqlParameter vppParamBN_CODENATUREPOSTEBUDGETAIRE = new SqlParameter("@BN_CODENATUREPOSTEBUDGETAIRE", SqlDbType.VarChar, 3);
            vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE;
            SqlParameter vppParamBG_LIBELLE = new SqlParameter("@BG_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBG_LIBELLE.Value = clsMicbudgetparampostebudgetaire.BG_LIBELLE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRE  @BG_CODEPOSTEBUDGETAIRE, @BD_CODETYPEBUDGETDETAIL, @BN_CODENATUREPOSTEBUDGETAIRE, @BG_LIBELLE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamBD_CODETYPEBUDGETDETAIL);
            vppSqlCmd.Parameters.Add(vppParamBN_CODENATUREPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamBG_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparampostebudgetaire>clsMicbudgetparampostebudgetaire</param>
        ///<author>Home Technology</author>
        public void pvgInsertPosteBudgetaireService(clsDonnee clsDonnee, clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire)
        {
            //Préparation des paramètres
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE1", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE;

            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE1", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsMicbudgetparampostebudgetaire.SR_CODESERVICE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRESERVICE  @BG_CODEPOSTEBUDGETAIRE1, @SR_CODESERVICE1, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparampostebudgetaire>clsMicbudgetparampostebudgetaire</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE;
            SqlParameter vppParamBD_CODETYPEBUDGETDETAIL = new SqlParameter("@BD_CODETYPEBUDGETDETAIL", SqlDbType.VarChar, 4);
            vppParamBD_CODETYPEBUDGETDETAIL.Value = clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL;
            SqlParameter vppParamBN_CODENATUREPOSTEBUDGETAIRE = new SqlParameter("@BN_CODENATUREPOSTEBUDGETAIRE", SqlDbType.VarChar, 3);
            vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE;
            SqlParameter vppParamBG_LIBELLE = new SqlParameter("@BG_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBG_LIBELLE.Value = clsMicbudgetparampostebudgetaire.BG_LIBELLE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRE  @BG_CODEPOSTEBUDGETAIRE, @BD_CODETYPEBUDGETDETAIL, @BN_CODENATUREPOSTEBUDGETAIRE, @BG_LIBELLE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamBD_CODETYPEBUDGETDETAIL);
            vppSqlCmd.Parameters.Add(vppParamBN_CODENATUREPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamBG_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRE   @BG_CODEPOSTEBUDGETAIRE, '' , '' , '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDeletePosteBudgetaireService(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRESERVICE  @BG_CODEPOSTEBUDGETAIRE, '' ,  @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparampostebudgetaire </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparampostebudgetaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BG_CODEPOSTEBUDGETAIRE, BD_CODETYPEBUDGETDETAIL, BN_CODENATUREPOSTEBUDGETAIRE, BG_LIBELLE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<clsMicbudgetparampostebudgetaire>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = clsDonnee.vogDataReader["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetaire.BG_LIBELLE = clsDonnee.vogDataReader["BG_LIBELLE"].ToString();
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparampostebudgetaires;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparampostebudgetaire </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparampostebudgetaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<clsMicbudgetparampostebudgetaire>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BG_CODEPOSTEBUDGETAIRE, BD_CODETYPEBUDGETDETAIL, BN_CODENATUREPOSTEBUDGETAIRE, BG_LIBELLE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new clsMicbudgetparampostebudgetaire();
                    clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetaire.BG_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["BG_LIBELLE"].ToString();
                    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                }
                Dataset.Dispose();
            }
            return clsMicbudgetparampostebudgetaires;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY BT_LIBELLE,BG_LIBELLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPosteBudgetaireService(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRESERVICE(@BG_CODEPOSTEBUDGETAIRE,@CODECRYPTAGE) " + this.vapCritere + " ORDER BY SR_LIBELLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BG_CODEPOSTEBUDGETAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BG_CODEPOSTEBUDGETAIRE , BG_LIBELLE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BG_CODEPOSTEBUDGETAIRE)</summary>
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
                    this.vapCritere = "WHERE BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BG_CODEPOSTEBUDGETAIRE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE BG_CODEPOSTEBUDGETAIRE LIKE '%'+@BG_CODEPOSTEBUDGETAIRE+'%' AND BG_LIBELLE LIKE '%'+@BG_LIBELLE+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BG_CODEPOSTEBUDGETAIRE", "@BG_LIBELLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
