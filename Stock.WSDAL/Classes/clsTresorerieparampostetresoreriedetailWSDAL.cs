using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsTresorerieparampostetresoreriedetailWSDAL : ITableDAL<clsTresorerieparampostetresoreriedetail>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsTresorerieparampostetresoreriedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsTresorerieparampostetresoreriedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TL_SIGNECOMPTE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsTresorerieparampostetresoreriedetail clsTresorerieparampostetresoreriedetail = new clsTresorerieparampostetresoreriedetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsTresorerieparampostetresoreriedetail.TL_SIGNECOMPTE = clsDonnee.vogDataReader["TL_SIGNECOMPTE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsTresorerieparampostetresoreriedetail;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsTresorerieparampostetresoreriedetail>clsTresorerieparampostetresoreriedetail</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsTresorerieparampostetresoreriedetail clsTresorerieparampostetresoreriedetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE1", SqlDbType.VarChar, 7);
            vppParamTP_CODEPOSTETRESORERIE.Value = clsTresorerieparampostetresoreriedetail.TP_CODEPOSTETRESORERIE;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsTresorerieparampostetresoreriedetail.PL_CODENUMCOMPTE;
            SqlParameter vppParamTL_SIGNECOMPTE = new SqlParameter("@TL_SIGNECOMPTE", SqlDbType.VarChar, 1);
            vppParamTL_SIGNECOMPTE.Value = clsTresorerieparampostetresoreriedetail.TL_SIGNECOMPTE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPARAMPOSTETRESORERIEDETAIL  @TP_CODEPOSTETRESORERIE1, @PL_CODENUMCOMPTE, @TL_SIGNECOMPTE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamTL_SIGNECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsTresorerieparampostetresoreriedetail>clsTresorerieparampostetresoreriedetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsTresorerieparampostetresoreriedetail clsTresorerieparampostetresoreriedetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE1", SqlDbType.VarChar, 7);
            vppParamTP_CODEPOSTETRESORERIE.Value = clsTresorerieparampostetresoreriedetail.TP_CODEPOSTETRESORERIE;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsTresorerieparampostetresoreriedetail.PL_CODENUMCOMPTE;
            SqlParameter vppParamTL_SIGNECOMPTE = new SqlParameter("@TL_SIGNECOMPTE", SqlDbType.VarChar, 1);
            vppParamTL_SIGNECOMPTE.Value = clsTresorerieparampostetresoreriedetail.TL_SIGNECOMPTE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPARAMPOSTETRESORERIEDETAIL  @TP_CODEPOSTETRESORERIE1, @PL_CODENUMCOMPTE, @TL_SIGNECOMPTE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamTL_SIGNECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPARAMPOSTETRESORERIEDETAIL  @TP_CODEPOSTETRESORERIE, '', '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTresorerieparampostetresoreriedetail </returns>
        ///<author>Home Technology</author>
        public List<clsTresorerieparampostetresoreriedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE, TL_SIGNECOMPTE FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsTresorerieparampostetresoreriedetail> clsTresorerieparampostetresoreriedetails = new List<clsTresorerieparampostetresoreriedetail>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsTresorerieparampostetresoreriedetail clsTresorerieparampostetresoreriedetail = new clsTresorerieparampostetresoreriedetail();
                    clsTresorerieparampostetresoreriedetail.TP_CODEPOSTETRESORERIE = clsDonnee.vogDataReader["TP_CODEPOSTETRESORERIE"].ToString();
                    clsTresorerieparampostetresoreriedetail.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsTresorerieparampostetresoreriedetail.TL_SIGNECOMPTE = clsDonnee.vogDataReader["TL_SIGNECOMPTE"].ToString();
                    clsTresorerieparampostetresoreriedetails.Add(clsTresorerieparampostetresoreriedetail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsTresorerieparampostetresoreriedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTresorerieparampostetresoreriedetail </returns>
        ///<author>Home Technology</author>
        public List<clsTresorerieparampostetresoreriedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsTresorerieparampostetresoreriedetail> clsTresorerieparampostetresoreriedetails = new List<clsTresorerieparampostetresoreriedetail>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE, TL_SIGNECOMPTE FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsTresorerieparampostetresoreriedetail clsTresorerieparampostetresoreriedetail = new clsTresorerieparampostetresoreriedetail();
                    clsTresorerieparampostetresoreriedetail.TP_CODEPOSTETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODEPOSTETRESORERIE"].ToString();
                    clsTresorerieparampostetresoreriedetail.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
                    clsTresorerieparampostetresoreriedetail.TL_SIGNECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["TL_SIGNECOMPTE"].ToString();
                    clsTresorerieparampostetresoreriedetails.Add(clsTresorerieparampostetresoreriedetail);
                }
                Dataset.Dispose();
            }
            return clsTresorerieparampostetresoreriedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT DISTINCT TP_CODEPOSTETRESORERIE,TP_LIBELLE ,PL_CODENUMCOMPTE, PL_NUMCOMPTE,PL_LIBELLE,TL_SIGNECOMPTE FROM  dbo.VUE_TRESORERIEPARAMPOSTETRESORERIEDETAIL  " + this.vapCritere ;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TP_CODEPOSTETRESORERIE , TL_SIGNECOMPTE FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIEDETAIL(@CODECRYPTAGE) " + this.vapCritere ;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TP_CODEPOSTETRESORERIE, PL_CODENUMCOMPTE)</summary>
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
                    this.vapCritere = "WHERE TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TP_CODEPOSTETRESORERIE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TP_CODEPOSTETRESORERIE", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
