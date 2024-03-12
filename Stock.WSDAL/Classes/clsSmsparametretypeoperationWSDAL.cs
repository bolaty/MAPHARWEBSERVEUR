using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsSmsparametretypeoperationWSDAL: ITableDAL<clsSmsparametretypeoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(TE_CODESMSTYPEOPERATION) AS TE_CODESMSTYPEOPERATION  FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(TE_CODESMSTYPEOPERATION) AS TE_CODESMSTYPEOPERATION  FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(TE_CODESMSTYPEOPERATION) AS TE_CODESMSTYPEOPERATION  FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsparametretypeoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsparametretypeoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TE_LIBELLE  , TE_ACTIF  FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsSmsparametretypeoperation clsSmsparametretypeoperation = new clsSmsparametretypeoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsparametretypeoperation.TE_LIBELLE = clsDonnee.vogDataReader["TE_LIBELLE"].ToString();
					clsSmsparametretypeoperation.TE_ACTIF = clsDonnee.vogDataReader["TE_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsSmsparametretypeoperation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsparametretypeoperation>clsSmsparametretypeoperation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsSmsparametretypeoperation clsSmsparametretypeoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsSmsparametretypeoperation.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamTE_LIBELLE = new SqlParameter("@TE_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTE_LIBELLE.Value  = clsSmsparametretypeoperation.TE_LIBELLE ;
			SqlParameter vppParamTE_ACTIF = new SqlParameter("@TE_ACTIF", SqlDbType.VarChar, 1);
			vppParamTE_ACTIF.Value  = clsSmsparametretypeoperation.TE_ACTIF ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO SMSPARAMETRETYPEOPERATION (  TE_CODESMSTYPEOPERATION, TE_LIBELLE, TE_ACTIF) " +
					 "VALUES ( @TE_CODESMSTYPEOPERATION, @TE_LIBELLE, @TE_ACTIF) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamTE_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTE_ACTIF);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsparametretypeoperation>clsSmsparametretypeoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsSmsparametretypeoperation clsSmsparametretypeoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTE_LIBELLE = new SqlParameter("@TE_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTE_LIBELLE.Value  = clsSmsparametretypeoperation.TE_LIBELLE ;
			SqlParameter vppParamTE_ACTIF = new SqlParameter("@TE_ACTIF", SqlDbType.VarChar, 1);
			vppParamTE_ACTIF.Value  = clsSmsparametretypeoperation.TE_ACTIF ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE SMSPARAMETRETYPEOPERATION SET " +
							"TE_LIBELLE = @TE_LIBELLE, "+
							"TE_ACTIF = @TE_ACTIF " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTE_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTE_ACTIF);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  SMSPARAMETRETYPEOPERATION "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsparametretypeoperation </returns>
		///<author>Home Technology</author>
		public List<clsSmsparametretypeoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TE_CODESMSTYPEOPERATION, TE_LIBELLE, TE_ACTIF FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsSmsparametretypeoperation> clsSmsparametretypeoperations = new List<clsSmsparametretypeoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsparametretypeoperation clsSmsparametretypeoperation = new clsSmsparametretypeoperation();
					clsSmsparametretypeoperation.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
					clsSmsparametretypeoperation.TE_LIBELLE = clsDonnee.vogDataReader["TE_LIBELLE"].ToString();
					clsSmsparametretypeoperation.TE_ACTIF = clsDonnee.vogDataReader["TE_ACTIF"].ToString();
					clsSmsparametretypeoperations.Add(clsSmsparametretypeoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSmsparametretypeoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsparametretypeoperation </returns>
		///<author>Home Technology</author>
		public List<clsSmsparametretypeoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSmsparametretypeoperation> clsSmsparametretypeoperations = new List<clsSmsparametretypeoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TE_CODESMSTYPEOPERATION, TE_LIBELLE, TE_ACTIF FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSmsparametretypeoperation clsSmsparametretypeoperation = new clsSmsparametretypeoperation();
					clsSmsparametretypeoperation.TE_CODESMSTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_CODESMSTYPEOPERATION"].ToString();
					clsSmsparametretypeoperation.TE_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TE_LIBELLE"].ToString();
					clsSmsparametretypeoperation.TE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TE_ACTIF"].ToString();
					clsSmsparametretypeoperations.Add(clsSmsparametretypeoperation);
				}
				Dataset.Dispose();
			}
		return clsSmsparametretypeoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TE_CODESMSTYPEOPERATION , TE_LIBELLE FROM dbo.SMSPARAMETRETYPEOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TE_CODESMSTYPEOPERATION)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
				this.vapCritere ="WHERE TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION";
				vapNomParametre = new string[]{"@TE_CODESMSTYPEOPERATION"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
