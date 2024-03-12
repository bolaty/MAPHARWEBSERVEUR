using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsMicbudgetparamtypeWSDAL : ITableDAL<clsMicbudgetparamtype>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(BT_CODETYPEBUDGET) AS BT_CODETYPEBUDGET  FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(BT_CODETYPEBUDGET) AS BT_CODETYPEBUDGET  FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(BT_CODETYPEBUDGET) AS BT_CODETYPEBUDGET  FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetparamtype comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetparamtype pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BT_LIBELLE  FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMicbudgetparamtype clsMicbudgetparamtype = new clsMicbudgetparamtype();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparamtype.BT_LIBELLE = clsDonnee.vogDataReader["BT_LIBELLE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparamtype;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparamtype>clsMicbudgetparamtype</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetparamtype clsMicbudgetparamtype)
        {
            //Préparation des paramètres
            SqlParameter vppParamBT_CODETYPEBUDGET = new SqlParameter("@BT_CODETYPEBUDGET", SqlDbType.VarChar, 3);
            vppParamBT_CODETYPEBUDGET.Value = clsMicbudgetparamtype.BT_CODETYPEBUDGET;
            SqlParameter vppParamBT_LIBELLE = new SqlParameter("@BT_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBT_LIBELLE.Value = clsMicbudgetparamtype.BT_LIBELLE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMTYPE  @BT_CODETYPEBUDGET, @BT_LIBELLE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBT_CODETYPEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBT_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudgetparamtype>clsMicbudgetparamtype</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetparamtype clsMicbudgetparamtype, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamBT_CODETYPEBUDGET = new SqlParameter("@BT_CODETYPEBUDGET", SqlDbType.VarChar, 3);
            vppParamBT_CODETYPEBUDGET.Value = clsMicbudgetparamtype.BT_CODETYPEBUDGET;
            SqlParameter vppParamBT_LIBELLE = new SqlParameter("@BT_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBT_LIBELLE.Value = clsMicbudgetparamtype.BT_LIBELLE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMTYPE  @BT_CODETYPEBUDGET, @BT_LIBELLE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamBT_CODETYPEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBT_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGETPARAMTYPE  @BT_CODETYPEBUDGET, '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparamtype </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparamtype> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BT_CODETYPEBUDGET, BT_LIBELLE FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<clsMicbudgetparamtype>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMicbudgetparamtype clsMicbudgetparamtype = new clsMicbudgetparamtype();
                    clsMicbudgetparamtype.BT_CODETYPEBUDGET = clsDonnee.vogDataReader["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtype.BT_LIBELLE = clsDonnee.vogDataReader["BT_LIBELLE"].ToString();
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMicbudgetparamtypes;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparamtype </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparamtype> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<clsMicbudgetparamtype>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BT_CODETYPEBUDGET, BT_LIBELLE FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMicbudgetparamtype clsMicbudgetparamtype = new clsMicbudgetparamtype();
                    clsMicbudgetparamtype.BT_CODETYPEBUDGET = Dataset.Tables["TABLE"].Rows[Idx]["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtype.BT_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["BT_LIBELLE"].ToString();
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }
                Dataset.Dispose();
            }
            return clsMicbudgetparamtypes;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BT_CODETYPEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BT_CODETYPEBUDGET , BT_LIBELLE FROM dbo.FT_MICBUDGETPARAMTYPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BT_CODETYPEBUDGET)</summary>
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
                    this.vapCritere = "WHERE BT_CODETYPEBUDGET LIKE '%'+@BT_CODETYPEBUDGET+'%' AND BT_LIBELLE LIKE '%'+@BT_LIBELLE+'%' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@BT_CODETYPEBUDGET" , "@BT_LIBELLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1] };
                    break;


            }
        }
    }
}
