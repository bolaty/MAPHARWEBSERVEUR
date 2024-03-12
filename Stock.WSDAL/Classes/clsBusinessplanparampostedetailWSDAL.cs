using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
    public class clsBusinessplanparampostedetailWSDAL : ITableDAL<clsBusinessplanparampostedetail>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(PO_CODEPOSTEBUSINESSPLAN) AS PO_CODEPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(PO_CODEPOSTEBUSINESSPLAN) AS PO_CODEPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(PO_CODEPOSTEBUSINESSPLAN) AS PO_CODEPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsBusinessplanparampostedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsBusinessplanparampostedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PL_SIGNECOMPTE  FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsBusinessplanparampostedetail clsBusinessplanparampostedetail = new clsBusinessplanparampostedetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsBusinessplanparampostedetail.PL_SIGNECOMPTE = clsDonnee.vogDataReader["PL_SIGNECOMPTE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsBusinessplanparampostedetail;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsBusinessplanparampostedetail>clsBusinessplanparampostedetail</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparampostedetail clsBusinessplanparampostedetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamPO_CODEPOSTEBUSINESSPLAN = new SqlParameter("@PO_CODEPOSTEBUSINESSPLAN1", SqlDbType.VarChar, 7);
            vppParamPO_CODEPOSTEBUSINESSPLAN.Value = clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsBusinessplanparampostedetail.PL_CODENUMCOMPTE;
            SqlParameter vppParamPL_SIGNECOMPTE = new SqlParameter("@PL_SIGNECOMPTE", SqlDbType.VarChar, 1);
            vppParamPL_SIGNECOMPTE.Value = clsBusinessplanparampostedetail.PL_SIGNECOMPTE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTEDETAIL  @PO_CODEPOSTEBUSINESSPLAN1, @PL_CODENUMCOMPTE, @PL_SIGNECOMPTE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPOSTEBUSINESSPLAN);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_SIGNECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsBusinessplanparampostedetail>clsBusinessplanparampostedetail</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparampostedetail clsBusinessplanparampostedetail, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamPO_CODEPOSTEBUSINESSPLAN = new SqlParameter("@PO_CODEPOSTEBUSINESSPLAN1", SqlDbType.VarChar, 7);
            vppParamPO_CODEPOSTEBUSINESSPLAN.Value = clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsBusinessplanparampostedetail.PL_CODENUMCOMPTE;
            SqlParameter vppParamPL_SIGNECOMPTE = new SqlParameter("@PL_SIGNECOMPTE", SqlDbType.VarChar, 1);
            vppParamPL_SIGNECOMPTE.Value = clsBusinessplanparampostedetail.PL_SIGNECOMPTE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTEDETAIL  @PO_CODEPOSTEBUSINESSPLAN1, @PL_CODENUMCOMPTE, @PL_SIGNECOMPTE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPOSTEBUSINESSPLAN);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_SIGNECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTEDETAIL  @PO_CODEPOSTEBUSINESSPLAN, '', '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsBusinessplanparampostedetail </returns>
        ///<author>Home Technology</author>
        public List<clsBusinessplanparampostedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE, PL_SIGNECOMPTE FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsBusinessplanparampostedetail> clsBusinessplanparampostedetails = new List<clsBusinessplanparampostedetail>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsBusinessplanparampostedetail clsBusinessplanparampostedetail = new clsBusinessplanparampostedetail();
                    clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN = clsDonnee.vogDataReader["PO_CODEPOSTEBUSINESSPLAN"].ToString();
                    clsBusinessplanparampostedetail.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsBusinessplanparampostedetail.PL_SIGNECOMPTE = clsDonnee.vogDataReader["PL_SIGNECOMPTE"].ToString();
                    clsBusinessplanparampostedetails.Add(clsBusinessplanparampostedetail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsBusinessplanparampostedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsBusinessplanparampostedetail </returns>
        ///<author>Home Technology</author>
        public List<clsBusinessplanparampostedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsBusinessplanparampostedetail> clsBusinessplanparampostedetails = new List<clsBusinessplanparampostedetail>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE, PL_SIGNECOMPTE FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsBusinessplanparampostedetail clsBusinessplanparampostedetail = new clsBusinessplanparampostedetail();
                    clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPOSTEBUSINESSPLAN"].ToString();
                    clsBusinessplanparampostedetail.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
                    clsBusinessplanparampostedetail.PL_SIGNECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_SIGNECOMPTE"].ToString();
                    clsBusinessplanparampostedetails.Add(clsBusinessplanparampostedetail);
                }
                Dataset.Dispose();
            }
            return clsBusinessplanparampostedetails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT DISTINCT PO_CODEPOSTEBUSINESSPLAN,CAST(DECRYPTBYPASSPHRASE(@CODECRYPTAGE,PB_LIBELLE) AS varchar(150)) AS PB_LIBELLE ,PL_CODENUMCOMPTE, PL_NUMCOMPTE,PL_LIBELLE,PL_SIGNECOMPTE FROM  dbo.VUE_BUSINESSPLANPARAMPOSTEDETAIL  " + this.vapCritere + "  AND PL_CODENUMCOMPTE IS NOT NULL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PO_CODEPOSTEBUSINESSPLAN , PL_SIGNECOMPTE FROM dbo.FT_BUSINESSPLANPARAMPOSTEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE)</summary>
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
                    this.vapCritere = "WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PO_CODEPOSTEBUSINESSPLAN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PO_CODEPOSTEBUSINESSPLAN", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
