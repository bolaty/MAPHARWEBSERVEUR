using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartableauWSDAL: ITableDAL<clsPhapartableau>
	{ 
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(TB_CODETABLEAU) AS TB_CODETABLEAU  FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(TB_CODETABLEAU) AS TB_CODETABLEAU  FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(TB_CODETABLEAU) AS TB_CODETABLEAU  FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartableau comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartableau pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TB_LIBELLE  , TB_DESCRIPTION  FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartableau clsPhapartableau = new clsPhapartableau();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartableau.TB_LIBELLE = clsDonnee.vogDataReader["TB_LIBELLE"].ToString();
					clsPhapartableau.TB_DESCRIPTION = clsDonnee.vogDataReader["TB_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartableau;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartableau>clsPhapartableau</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartableau clsPhapartableau)
		{
			//Préparation des paramètres
			SqlParameter vppParamTB_CODETABLEAU = new SqlParameter("@TB_CODETABLEAU", SqlDbType.VarChar, 3);
			vppParamTB_CODETABLEAU.Value  = clsPhapartableau.TB_CODETABLEAU ;

			SqlParameter vppParamTB_LIBELLE = new SqlParameter("@TB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTB_LIBELLE.Value  = clsPhapartableau.TB_LIBELLE ;

			SqlParameter vppParamTB_DESCRIPTION = new SqlParameter("@TB_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTB_DESCRIPTION.Value  = clsPhapartableau.TB_DESCRIPTION ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARTABLEAU (  TB_CODETABLEAU, TB_LIBELLE, TB_DESCRIPTION) " +
					 "VALUES ( @TB_CODETABLEAU, @TB_LIBELLE, @TB_DESCRIPTION) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTB_CODETABLEAU);
			vppSqlCmd.Parameters.Add(vppParamTB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTB_DESCRIPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartableau>clsPhapartableau</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartableau clsPhapartableau,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTB_LIBELLE = new SqlParameter("@TB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTB_LIBELLE.Value  = clsPhapartableau.TB_LIBELLE ;

			SqlParameter vppParamTB_DESCRIPTION = new SqlParameter("@TB_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTB_DESCRIPTION.Value  = clsPhapartableau.TB_DESCRIPTION ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARTABLEAU SET " +
							"TB_LIBELLE = @TB_LIBELLE, "+
							"TB_DESCRIPTION = @TB_DESCRIPTION " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTB_DESCRIPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARTABLEAU "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartableau </returns>
		///<author>Home Technology</author>
		public List<clsPhapartableau> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TB_CODETABLEAU, TB_LIBELLE, TB_DESCRIPTION FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartableau> clsPhapartableaus = new List<clsPhapartableau>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartableau clsPhapartableau = new clsPhapartableau();
					clsPhapartableau.TB_CODETABLEAU = clsDonnee.vogDataReader["TB_CODETABLEAU"].ToString();
					clsPhapartableau.TB_LIBELLE = clsDonnee.vogDataReader["TB_LIBELLE"].ToString();
					clsPhapartableau.TB_DESCRIPTION = clsDonnee.vogDataReader["TB_DESCRIPTION"].ToString();
					clsPhapartableaus.Add(clsPhapartableau);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartableaus;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartableau </returns>
		///<author>Home Technology</author>
		public List<clsPhapartableau> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartableau> clsPhapartableaus = new List<clsPhapartableau>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TB_CODETABLEAU, TB_LIBELLE, TB_DESCRIPTION FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartableau clsPhapartableau = new clsPhapartableau();
					clsPhapartableau.TB_CODETABLEAU = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODETABLEAU"].ToString();
					clsPhapartableau.TB_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TB_LIBELLE"].ToString();
					clsPhapartableau.TB_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["TB_DESCRIPTION"].ToString();
					clsPhapartableaus.Add(clsPhapartableau);
				}
				Dataset.Dispose();
			}
		return clsPhapartableaus;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TB_CODETABLEAU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TB_CODETABLEAU , TB_LIBELLE FROM dbo.PHAPARTABLEAU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TB_CODETABLEAU)</summary>
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
				this.vapCritere ="WHERE TB_CODETABLEAU=@TB_CODETABLEAU";
				vapNomParametre = new string[]{"@TB_CODETABLEAU"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
