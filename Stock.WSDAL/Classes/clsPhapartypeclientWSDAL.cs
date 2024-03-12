using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypeclientWSDAL: ITableDAL<clsPhapartypeclient>
	{
		private string vapCritere = "";
		private string vapRequete = ""; 
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(TP_CODETYPECLIENT) AS TP_CODETYPECLIENT  FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(TP_CODETYPECLIENT) AS TP_CODETYPECLIENT  FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(TP_CODETYPECLIENT) AS TP_CODETYPECLIENT  FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypeclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypeclient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TP_LIBELLE  , TP_DESCRIPTION  FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypeclient clsPhapartypeclient = new clsPhapartypeclient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypeclient.TP_LIBELLE = clsDonnee.vogDataReader["TP_LIBELLE"].ToString();
					clsPhapartypeclient.TP_DESCRIPTION = clsDonnee.vogDataReader["TP_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypeclient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypeclient>clsPhapartypeclient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypeclient clsPhapartypeclient)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODETYPECLIENT = new SqlParameter("@TP_CODETYPECLIENT", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPECLIENT.Value  = clsPhapartypeclient.TP_CODETYPECLIENT ;

			SqlParameter vppParamTP_LIBELLE = new SqlParameter("@TP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTP_LIBELLE.Value  = clsPhapartypeclient.TP_LIBELLE ;

			SqlParameter vppParamTP_DESCRIPTION = new SqlParameter("@TP_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTP_DESCRIPTION.Value  = clsPhapartypeclient.TP_DESCRIPTION ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARTYPECLIENT (  TP_CODETYPECLIENT, TP_LIBELLE, TP_DESCRIPTION) " +
					 "VALUES ( @TP_CODETYPECLIENT, @TP_LIBELLE, @TP_DESCRIPTION) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPECLIENT);
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTP_DESCRIPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypeclient>clsPhapartypeclient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypeclient clsPhapartypeclient,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_LIBELLE = new SqlParameter("@TP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTP_LIBELLE.Value  = clsPhapartypeclient.TP_LIBELLE ;

			SqlParameter vppParamTP_DESCRIPTION = new SqlParameter("@TP_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTP_DESCRIPTION.Value  = clsPhapartypeclient.TP_DESCRIPTION ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARTYPECLIENT SET " +
							"TP_LIBELLE = @TP_LIBELLE, "+
							"TP_DESCRIPTION = @TP_DESCRIPTION " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTP_DESCRIPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARTYPECLIENT "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypeclient </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypeclient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPECLIENT, TP_LIBELLE, TP_DESCRIPTION FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypeclient> clsPhapartypeclients = new List<clsPhapartypeclient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypeclient clsPhapartypeclient = new clsPhapartypeclient();
					clsPhapartypeclient.TP_CODETYPECLIENT = clsDonnee.vogDataReader["TP_CODETYPECLIENT"].ToString();
					clsPhapartypeclient.TP_LIBELLE = clsDonnee.vogDataReader["TP_LIBELLE"].ToString();
					clsPhapartypeclient.TP_DESCRIPTION = clsDonnee.vogDataReader["TP_DESCRIPTION"].ToString();
					clsPhapartypeclients.Add(clsPhapartypeclient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypeclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypeclient </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypeclient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypeclient> clsPhapartypeclients = new List<clsPhapartypeclient>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPECLIENT, TP_LIBELLE, TP_DESCRIPTION FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypeclient clsPhapartypeclient = new clsPhapartypeclient();
					clsPhapartypeclient.TP_CODETYPECLIENT = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPECLIENT"].ToString();
					clsPhapartypeclient.TP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TP_LIBELLE"].ToString();
					clsPhapartypeclient.TP_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["TP_DESCRIPTION"].ToString();
					clsPhapartypeclients.Add(clsPhapartypeclient);
				}
				Dataset.Dispose();
			}
		return clsPhapartypeclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TP_CODETYPECLIENT , TP_LIBELLE FROM dbo.PHAPARTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TP_CODETYPECLIENT)</summary>
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
				this.vapCritere ="WHERE TP_CODETYPECLIENT=@TP_CODETYPECLIENT";
				vapNomParametre = new string[]{"@TP_CODETYPECLIENT"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
