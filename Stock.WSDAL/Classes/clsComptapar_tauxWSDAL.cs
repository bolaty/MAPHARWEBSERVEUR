using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsComptapar_tauxWSDAL: ITableDAL<clsComptapar_taux>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(COMPTAPAR_TAUX_CODE) AS COMPTAPAR_TAUX_CODE  FROM dbo.FT_COMPTAPAR_TAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(COMPTAPAR_TAUX_CODE) AS COMPTAPAR_TAUX_CODE  FROM dbo.FT_COMPTAPAR_TAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(COMPTAPAR_TAUX_CODE) AS COMPTAPAR_TAUX_CODE  FROM dbo.FT_COMPTAPAR_TAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsComptapar_taux comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsComptapar_taux pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COMPTAPAR_TAUX_LIBELLE  FROM dbo.FT_COMPTAPAR_TAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsComptapar_taux clsComptapar_taux = new clsComptapar_taux();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsComptapar_taux.COMPTAPAR_TAUX_LIBELLE = clsDonnee.vogDataReader["COMPTAPAR_TAUX_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsComptapar_taux;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsComptapar_taux>clsComptapar_taux</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsComptapar_taux clsComptapar_taux)
		{
			//Préparation des paramètres
			SqlParameter vppParamCOMPTAPAR_TAUX_CODE = new SqlParameter("@COMPTAPAR_TAUX_CODE", SqlDbType.VarChar, 3);
			vppParamCOMPTAPAR_TAUX_CODE.Value  = clsComptapar_taux.COMPTAPAR_TAUX_CODE ;
			SqlParameter vppParamCOMPTAPAR_TAUX_LIBELLE = new SqlParameter("@COMPTAPAR_TAUX_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCOMPTAPAR_TAUX_LIBELLE.Value  = clsComptapar_taux.COMPTAPAR_TAUX_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_COMPTAPAR_TAUX  @COMPTAPAR_TAUX_CODE, @COMPTAPAR_TAUX_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_TAUX_CODE);
			vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_TAUX_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsComptapar_taux>clsComptapar_taux</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsComptapar_taux clsComptapar_taux,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCOMPTAPAR_TAUX_CODE = new SqlParameter("@COMPTAPAR_TAUX_CODE", SqlDbType.VarChar, 3);
			vppParamCOMPTAPAR_TAUX_CODE.Value  = clsComptapar_taux.COMPTAPAR_TAUX_CODE ;
			SqlParameter vppParamCOMPTAPAR_TAUX_LIBELLE = new SqlParameter("@COMPTAPAR_TAUX_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCOMPTAPAR_TAUX_LIBELLE.Value  = clsComptapar_taux.COMPTAPAR_TAUX_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_COMPTAPAR_TAUX  @COMPTAPAR_TAUX_CODE, @COMPTAPAR_TAUX_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_TAUX_CODE);
			vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_TAUX_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_COMPTAPAR_TAUX  @COMPTAPAR_TAUX_CODE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEVISE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsDevise </returns>
        ///<author>Home Technology</author>
        public List<clsComptapar_taux> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  DE_CODEDEVISE, DE_DEVISECODE, DE_LIBELLEDEVISE, DE_DEVISEREFERENCE, DE_ACTIF FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsComptapar_taux> clsComptapar_taux = new List<clsComptapar_taux>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    //clsComptapar_taxe clsComptapar_taxe = new clsComptapar_taxe();
                    //clsDevise.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
                    //clsDevise.DE_DEVISECODE = clsDonnee.vogDataReader["DE_DEVISECODE"].ToString();
                    //clsDevise.DE_LIBELLEDEVISE = clsDonnee.vogDataReader["DE_LIBELLEDEVISE"].ToString();
                    //clsDevise.DE_DEVISEREFERENCE = clsDonnee.vogDataReader["DE_DEVISEREFERENCE"].ToString();
                    //clsDevise.DE_ACTIF = clsDonnee.vogDataReader["DE_ACTIF"].ToString();
                    //clsComptapar_taxe.Add(clsDevise);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsComptapar_taux;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEVISE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsDevise </returns>
        ///<author>Home Technology</author>
        public List<clsComptapar_taux> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsComptapar_taux> clsComptapar_taux = new List<clsComptapar_taux>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  DE_CODEDEVISE, DE_DEVISECODE, DE_LIBELLEDEVISE, DE_DEVISEREFERENCE, DE_ACTIF FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    //clsComptapar_taxe clsComptapar_taxe = new clsComptapar_taxe();
                    //clsDevise.DE_CODEDEVISE = Dataset.Tables["TABLE"].Rows[Idx]["DE_CODEDEVISE"].ToString();
                    //clsDevise.DE_DEVISECODE = Dataset.Tables["TABLE"].Rows[Idx]["DE_DEVISECODE"].ToString();
                    //clsDevise.DE_LIBELLEDEVISE = Dataset.Tables["TABLE"].Rows[Idx]["DE_LIBELLEDEVISE"].ToString();
                    //clsDevise.DE_DEVISEREFERENCE = Dataset.Tables["TABLE"].Rows[Idx]["DE_DEVISEREFERENCE"].ToString();
                    //clsDevise.DE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["DE_ACTIF"].ToString();
                    //clsDevises.Add(clsDevise);
                }
                Dataset.Dispose();
            }
            return clsComptapar_taux;
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_COMPTAPAR_TAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : COMPTAPAR_TAUX_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COMPTAPAR_TAUX_CODE , COMPTAPAR_TAUX_LIBELLE FROM dbo.FT_COMPTAPAR_TAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :COMPTAPAR_TAUX_CODE)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{"@CODECRYPTAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE COMPTAPAR_TAUX_CODE=@COMPTAPAR_TAUX_CODE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@COMPTAPAR_TAUX_CODE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
