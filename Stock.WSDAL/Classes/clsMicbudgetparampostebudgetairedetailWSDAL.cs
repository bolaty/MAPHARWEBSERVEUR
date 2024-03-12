using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsMicbudgetparampostebudgetairedetailWSDAL : ITableDAL<clsMicbudgetparampostebudgetairedetail>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(BG_CODEPOSTEBUDGETAIRE) AS BG_CODEPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetparampostebudgetairedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetparampostebudgetairedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BL_SIGNECOMPTE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail = new clsMicbudgetparampostebudgetairedetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparampostebudgetairedetail.BL_SIGNECOMPTE = clsDonnee.vogDataReader["BL_SIGNECOMPTE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparampostebudgetairedetail;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparampostebudgetairedetail>clsMicbudgetparampostebudgetairedetail</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE1", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsMicbudgetparampostebudgetairedetail.PL_CODENUMCOMPTE;
            SqlParameter vppParamBL_SIGNECOMPTE = new SqlParameter("@BL_SIGNECOMPTE", SqlDbType.VarChar, 1);
            vppParamBL_SIGNECOMPTE.Value = clsMicbudgetparampostebudgetairedetail.BL_SIGNECOMPTE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  @BG_CODEPOSTEBUDGETAIRE1, @PL_CODENUMCOMPTE, @BL_SIGNECOMPTE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamBL_SIGNECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparampostebudgetairedetail>clsMicbudgetparampostebudgetairedetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE1", SqlDbType.VarChar, 7);
            vppParamBG_CODEPOSTEBUDGETAIRE.Value = clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsMicbudgetparampostebudgetairedetail.PL_CODENUMCOMPTE;
            SqlParameter vppParamBL_SIGNECOMPTE = new SqlParameter("@BL_SIGNECOMPTE", SqlDbType.VarChar, 1);
            vppParamBL_SIGNECOMPTE.Value = clsMicbudgetparampostebudgetairedetail.BL_SIGNECOMPTE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  @BG_CODEPOSTEBUDGETAIRE1, @PL_CODENUMCOMPTE, @BL_SIGNECOMPTE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamBL_SIGNECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  @BG_CODEPOSTEBUDGETAIRE, '', '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparampostebudgetairedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparampostebudgetairedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE, BL_SIGNECOMPTE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsMicbudgetparampostebudgetairedetail> clsMicbudgetparampostebudgetairedetails = new List<clsMicbudgetparampostebudgetairedetail>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail = new clsMicbudgetparampostebudgetairedetail();
                    clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetairedetail.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsMicbudgetparampostebudgetairedetail.BL_SIGNECOMPTE = clsDonnee.vogDataReader["BL_SIGNECOMPTE"].ToString();
                    clsMicbudgetparampostebudgetairedetails.Add(clsMicbudgetparampostebudgetairedetail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparampostebudgetairedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparampostebudgetairedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparampostebudgetairedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMicbudgetparampostebudgetairedetail> clsMicbudgetparampostebudgetairedetails = new List<clsMicbudgetparampostebudgetairedetail>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE, BL_SIGNECOMPTE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail = new clsMicbudgetparampostebudgetairedetail();
                    clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BG_CODEPOSTEBUDGETAIRE"].ToString();
                    clsMicbudgetparampostebudgetairedetail.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
                    clsMicbudgetparampostebudgetairedetail.BL_SIGNECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["BL_SIGNECOMPTE"].ToString();
                    clsMicbudgetparampostebudgetairedetails.Add(clsMicbudgetparampostebudgetairedetail);
                }
                Dataset.Dispose();
            }
            return clsMicbudgetparampostebudgetairedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT DISTINCT BG_CODEPOSTEBUDGETAIRE,CAST(DECRYPTBYPASSPHRASE(@CODECRYPTAGE,BG_LIBELLE) AS varchar(150)) AS BG_LIBELLE ,PL_CODENUMCOMPTE, PL_NUMCOMPTE,PL_LIBELLE,BL_SIGNECOMPTE FROM  dbo.VUE_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  " + this.vapCritere + "  AND PL_CODENUMCOMPTE IS NOT NULL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BG_CODEPOSTEBUDGETAIRE , BL_SIGNECOMPTE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIREDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE)</summary>
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
                    this.vapCritere = "WHERE BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BG_CODEPOSTEBUDGETAIRE", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
