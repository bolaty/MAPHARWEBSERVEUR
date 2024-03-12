using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsMicbudgetparamtypedetailWSDAL : ITableDAL<clsMicbudgetparamtypedetail>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(BD_CODETYPEBUDGETDETAIL) AS BD_CODETYPEBUDGETDETAIL  FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(BD_CODETYPEBUDGETDETAIL) AS BD_CODETYPEBUDGETDETAIL  FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(BD_CODETYPEBUDGETDETAIL) AS BD_CODETYPEBUDGETDETAIL  FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetparamtypedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetparamtypedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BT_CODETYPEBUDGET  , BD_LIBELLE  FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new clsMicbudgetparamtypedetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET = clsDonnee.vogDataReader["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = clsDonnee.vogDataReader["BD_LIBELLE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparamtypedetail;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparamtypedetail>clsMicbudgetparamtypedetail</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamBT_CODETYPEBUDGET = new SqlParameter("@BT_CODETYPEBUDGET", SqlDbType.VarChar, 3);
            vppParamBT_CODETYPEBUDGET.Value = clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET;
            SqlParameter vppParamBD_CODETYPEBUDGETDETAIL = new SqlParameter("@BD_CODETYPEBUDGETDETAIL", SqlDbType.VarChar, 4);
            vppParamBD_CODETYPEBUDGETDETAIL.Value = clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL;
            SqlParameter vppParamBD_LIBELLE = new SqlParameter("@BD_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBD_LIBELLE.Value = clsMicbudgetparamtypedetail.BD_LIBELLE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMTYPEDETAIL  @BT_CODETYPEBUDGET, @BD_CODETYPEBUDGETDETAIL, @BD_LIBELLE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBT_CODETYPEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBD_CODETYPEBUDGETDETAIL);
            vppSqlCmd.Parameters.Add(vppParamBD_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparamtypedetail>clsMicbudgetparamtypedetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamBT_CODETYPEBUDGET = new SqlParameter("@BT_CODETYPEBUDGET", SqlDbType.VarChar, 3);
            vppParamBT_CODETYPEBUDGET.Value = clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET;
            SqlParameter vppParamBD_CODETYPEBUDGETDETAIL = new SqlParameter("@BD_CODETYPEBUDGETDETAIL", SqlDbType.VarChar, 4);
            vppParamBD_CODETYPEBUDGETDETAIL.Value = clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL;
            SqlParameter vppParamBD_LIBELLE = new SqlParameter("@BD_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBD_LIBELLE.Value = clsMicbudgetparamtypedetail.BD_LIBELLE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMTYPEDETAIL  @BT_CODETYPEBUDGET, @BD_CODETYPEBUDGETDETAIL, @BD_LIBELLE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBT_CODETYPEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBD_CODETYPEBUDGETDETAIL);
            vppSqlCmd.Parameters.Add(vppParamBD_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMTYPEDETAIL  @BT_CODETYPEBUDGET, @BD_CODETYPEBUDGETDETAIL, '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparamtypedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparamtypedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL, BD_LIBELLE FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<clsMicbudgetparamtypedetail>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET = clsDonnee.vogDataReader["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL = clsDonnee.vogDataReader["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = clsDonnee.vogDataReader["BD_LIBELLE"].ToString();
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparamtypedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparamtypedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparamtypedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<clsMicbudgetparamtypedetail>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL, BD_LIBELLE FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new clsMicbudgetparamtypedetail();
                    clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET = Dataset.Tables["TABLE"].Rows[Idx]["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["BD_CODETYPEBUDGETDETAIL"].ToString();
                    clsMicbudgetparamtypedetail.BD_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["BD_LIBELLE"].ToString();
                    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                }
                Dataset.Dispose();
            }
            return clsMicbudgetparamtypedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BD_CODETYPEBUDGETDETAIL , BD_LIBELLE FROM dbo.FT_MICBUDGETPARAMTYPEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL)</summary>
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
                    this.vapCritere = "WHERE BT_CODETYPEBUDGET=@BT_CODETYPEBUDGET";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BT_CODETYPEBUDGET" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE BT_CODETYPEBUDGET=@BT_CODETYPEBUDGET AND BD_CODETYPEBUDGETDETAIL=@BD_CODETYPEBUDGETDETAIL";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BT_CODETYPEBUDGET", "@BD_CODETYPEBUDGETDETAIL" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE BT_CODETYPEBUDGET LIKE '%'+@BT_CODETYPEBUDGET+'%' AND BD_CODETYPEBUDGETDETAIL LIKE '%'+@BD_CODETYPEBUDGETDETAIL+'%' AND BD_LIBELLE LIKE '%'+@BD_LIBELLE+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BT_CODETYPEBUDGET", "@BD_CODETYPEBUDGETDETAIL", "@BD_LIBELLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }
    }
}
