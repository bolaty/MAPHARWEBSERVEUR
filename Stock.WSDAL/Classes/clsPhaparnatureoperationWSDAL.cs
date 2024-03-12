using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparnatureoperationWSDAL: ITableDAL<clsPhaparnatureoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns> 
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(NO_CODENATUREOPERATION) AS NO_CODENATUREOPERATION  FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(NO_CODENATUREOPERATION) AS NO_CODENATUREOPERATION  FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(NO_CODENATUREOPERATION) AS NO_CODENATUREOPERATION  FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparnatureoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparnatureoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT NO_LIBELLE  , NO_PROJET  FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparnatureoperation clsPhaparnatureoperation = new clsPhaparnatureoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparnatureoperation.NO_LIBELLE = clsDonnee.vogDataReader["NO_LIBELLE"].ToString();
					clsPhaparnatureoperation.NO_PROJET = clsDonnee.vogDataReader["NO_PROJET"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparnatureoperation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparnatureoperation>clsPhaparnatureoperation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparnatureoperation clsPhaparnatureoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhaparnatureoperation.NO_CODENATUREOPERATION ;

			SqlParameter vppParamNO_LIBELLE = new SqlParameter("@NO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNO_LIBELLE.Value  = clsPhaparnatureoperation.NO_LIBELLE ;

			SqlParameter vppParamNO_PROJET = new SqlParameter("@NO_PROJET", SqlDbType.VarChar, 150);
			vppParamNO_PROJET.Value  = clsPhaparnatureoperation.NO_PROJET ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARNATUREOPERATION (  NO_CODENATUREOPERATION, NO_LIBELLE, NO_PROJET) " +
					 "VALUES ( @NO_CODENATUREOPERATION, @NO_LIBELLE, @NO_PROJET) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamNO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamNO_PROJET);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparnatureoperation>clsPhaparnatureoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparnatureoperation clsPhaparnatureoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNO_LIBELLE = new SqlParameter("@NO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNO_LIBELLE.Value  = clsPhaparnatureoperation.NO_LIBELLE ;

			SqlParameter vppParamNO_PROJET = new SqlParameter("@NO_PROJET", SqlDbType.VarChar, 150);
			vppParamNO_PROJET.Value  = clsPhaparnatureoperation.NO_PROJET ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARNATUREOPERATION SET " +
							"NO_LIBELLE = @NO_LIBELLE, "+
							"NO_PROJET = @NO_PROJET " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamNO_PROJET);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARNATUREOPERATION "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparnatureoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhaparnatureoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  NO_CODENATUREOPERATION, NO_LIBELLE, NO_PROJET FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparnatureoperation> clsPhaparnatureoperations = new List<clsPhaparnatureoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparnatureoperation clsPhaparnatureoperation = new clsPhaparnatureoperation();
					clsPhaparnatureoperation.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhaparnatureoperation.NO_LIBELLE = clsDonnee.vogDataReader["NO_LIBELLE"].ToString();
					clsPhaparnatureoperation.NO_PROJET = clsDonnee.vogDataReader["NO_PROJET"].ToString();
					clsPhaparnatureoperations.Add(clsPhaparnatureoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparnatureoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparnatureoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhaparnatureoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparnatureoperation> clsPhaparnatureoperations = new List<clsPhaparnatureoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  NO_CODENATUREOPERATION, NO_LIBELLE, NO_PROJET FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparnatureoperation clsPhaparnatureoperation = new clsPhaparnatureoperation();
					clsPhaparnatureoperation.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhaparnatureoperation.NO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["NO_LIBELLE"].ToString();
					clsPhaparnatureoperation.NO_PROJET = Dataset.Tables["TABLE"].Rows[Idx]["NO_PROJET"].ToString();
					clsPhaparnatureoperations.Add(clsPhaparnatureoperation);
				}
				Dataset.Dispose();
			}
		return clsPhaparnatureoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT NO_CODENATUREOPERATION , NO_LIBELLE FROM dbo.PHAPARNATUREOPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NO_CODENATUREOPERATION)</summary>
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
				this.vapCritere ="WHERE NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
				vapNomParametre = new string[]{"@NO_CODENATUREOPERATION"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
                case 2 :
                this.vapCritere = "WHERE NO_CODENATUREOPERATION  LIKE  +@NO_CODENATUREOPERATION+'%'  AND NO_AFFICHER=@NO_AFFICHER";
                vapNomParametre = new string[] { "@NO_CODENATUREOPERATION", "@NO_AFFICHER" };
                vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
                break;
			}
		}
	}
}
