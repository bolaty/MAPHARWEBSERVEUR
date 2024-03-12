using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparoperationWSDAL: ITableDAL<clsPhaparoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{}; 

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(OT_CODEOPERATION) AS OT_CODEOPERATION  FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(OT_CODEOPERATION) AS OT_CODEOPERATION  FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(OT_CODEOPERATION) AS OT_CODEOPERATION  FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT OT_LIBELLE  , OT_SENS  FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparoperation clsPhaparoperation = new clsPhaparoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparoperation.OT_LIBELLE = clsDonnee.vogDataReader["OT_LIBELLE"].ToString();
					clsPhaparoperation.OT_SENS = clsDonnee.vogDataReader["OT_SENS"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparoperation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparoperation>clsPhaparoperation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparoperation clsPhaparoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamOT_CODEOPERATION = new SqlParameter("@OT_CODEOPERATION", SqlDbType.VarChar, 3);
			vppParamOT_CODEOPERATION.Value  = clsPhaparoperation.OT_CODEOPERATION ;

			SqlParameter vppParamOT_LIBELLE = new SqlParameter("@OT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamOT_LIBELLE.Value  = clsPhaparoperation.OT_LIBELLE ;

			SqlParameter vppParamOT_SENS = new SqlParameter("@OT_SENS", SqlDbType.VarChar, 1);
			vppParamOT_SENS.Value  = clsPhaparoperation.OT_SENS ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPAROPERATION (  OT_CODEOPERATION, OT_LIBELLE, OT_SENS) " +
					 "VALUES ( @OT_CODEOPERATION, @OT_LIBELLE, @OT_SENS) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOT_CODEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamOT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamOT_SENS);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparoperation>clsPhaparoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparoperation clsPhaparoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamOT_LIBELLE = new SqlParameter("@OT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamOT_LIBELLE.Value  = clsPhaparoperation.OT_LIBELLE ;

			SqlParameter vppParamOT_SENS = new SqlParameter("@OT_SENS", SqlDbType.VarChar, 1);
			vppParamOT_SENS.Value  = clsPhaparoperation.OT_SENS ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPAROPERATION SET " +
							"OT_LIBELLE = @OT_LIBELLE, "+
							"OT_SENS = @OT_SENS " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamOT_SENS);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPAROPERATION "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhaparoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  OT_CODEOPERATION, OT_LIBELLE, OT_SENS FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparoperation> clsPhaparoperations = new List<clsPhaparoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparoperation clsPhaparoperation = new clsPhaparoperation();
					clsPhaparoperation.OT_CODEOPERATION = clsDonnee.vogDataReader["OT_CODEOPERATION"].ToString();
					clsPhaparoperation.OT_LIBELLE = clsDonnee.vogDataReader["OT_LIBELLE"].ToString();
					clsPhaparoperation.OT_SENS = clsDonnee.vogDataReader["OT_SENS"].ToString();
					clsPhaparoperations.Add(clsPhaparoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhaparoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparoperation> clsPhaparoperations = new List<clsPhaparoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  OT_CODEOPERATION, OT_LIBELLE, OT_SENS FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparoperation clsPhaparoperation = new clsPhaparoperation();
					clsPhaparoperation.OT_CODEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["OT_CODEOPERATION"].ToString();
					clsPhaparoperation.OT_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["OT_LIBELLE"].ToString();
					clsPhaparoperation.OT_SENS = Dataset.Tables["TABLE"].Rows[Idx]["OT_SENS"].ToString();
					clsPhaparoperations.Add(clsPhaparoperation);
				}
				Dataset.Dispose();
			}
		return clsPhaparoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OT_CODEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT OT_CODEOPERATION , OT_LIBELLE FROM dbo.PHAPAROPERATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OT_CODEOPERATION)</summary>
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
				this.vapCritere ="WHERE OT_CODEOPERATION=@OT_CODEOPERATION";
				vapNomParametre = new string[]{"@OT_CODEOPERATION"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
