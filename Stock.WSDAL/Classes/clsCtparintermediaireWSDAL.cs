using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparintermediaireWSDAL: ITableDAL<clsCtparintermediaire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(IT_CODEINTERMEDIAIRE) AS IT_CODEINTERMEDIAIRE  FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(IT_CODEINTERMEDIAIRE) AS IT_CODEINTERMEDIAIRE  FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(IT_CODEINTERMEDIAIRE) AS IT_CODEINTERMEDIAIRE  FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparintermediaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparintermediaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT IT_DENOMMINATION  , IT_ACTIF  , IT_NUMEROORDRE  FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparintermediaire clsCtparintermediaire = new clsCtparintermediaire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparintermediaire.IT_DENOMMINATION = clsDonnee.vogDataReader["IT_DENOMMINATION"].ToString();
					clsCtparintermediaire.IT_ACTIF = clsDonnee.vogDataReader["IT_ACTIF"].ToString();
					clsCtparintermediaire.IT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["IT_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparintermediaire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparintermediaire>clsCtparintermediaire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparintermediaire clsCtparintermediaire)
		{
			//Préparation des paramètres
			SqlParameter vppParamIT_CODEINTERMEDIAIRE = new SqlParameter("@IT_CODEINTERMEDIAIRE", SqlDbType.VarChar, 5);
			vppParamIT_CODEINTERMEDIAIRE.Value  = clsCtparintermediaire.IT_CODEINTERMEDIAIRE ;
			SqlParameter vppParamIT_DENOMMINATION = new SqlParameter("@IT_DENOMMINATION", SqlDbType.VarChar, 150);
			vppParamIT_DENOMMINATION.Value  = clsCtparintermediaire.IT_DENOMMINATION ;
			SqlParameter vppParamIT_ACTIF = new SqlParameter("@IT_ACTIF", SqlDbType.VarChar, 1);
			vppParamIT_ACTIF.Value  = clsCtparintermediaire.IT_ACTIF ;
			SqlParameter vppParamIT_NUMEROORDRE = new SqlParameter("@IT_NUMEROORDRE", SqlDbType.Int);
			vppParamIT_NUMEROORDRE.Value  = clsCtparintermediaire.IT_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARINTERMEDIAIRE  @IT_CODEINTERMEDIAIRE, @IT_DENOMMINATION, @IT_ACTIF, @IT_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamIT_CODEINTERMEDIAIRE);
			vppSqlCmd.Parameters.Add(vppParamIT_DENOMMINATION);
			vppSqlCmd.Parameters.Add(vppParamIT_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamIT_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparintermediaire>clsCtparintermediaire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparintermediaire clsCtparintermediaire,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamIT_CODEINTERMEDIAIRE = new SqlParameter("@IT_CODEINTERMEDIAIRE", SqlDbType.VarChar, 5);
			vppParamIT_CODEINTERMEDIAIRE.Value  = clsCtparintermediaire.IT_CODEINTERMEDIAIRE ;
			SqlParameter vppParamIT_DENOMMINATION = new SqlParameter("@IT_DENOMMINATION", SqlDbType.VarChar, 150);
			vppParamIT_DENOMMINATION.Value  = clsCtparintermediaire.IT_DENOMMINATION ;
			SqlParameter vppParamIT_ACTIF = new SqlParameter("@IT_ACTIF", SqlDbType.VarChar, 1);
			vppParamIT_ACTIF.Value  = clsCtparintermediaire.IT_ACTIF ;
			SqlParameter vppParamIT_NUMEROORDRE = new SqlParameter("@IT_NUMEROORDRE", SqlDbType.Int);
			vppParamIT_NUMEROORDRE.Value  = clsCtparintermediaire.IT_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARINTERMEDIAIRE  @IT_CODEINTERMEDIAIRE, @IT_DENOMMINATION, @IT_ACTIF, @IT_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamIT_CODEINTERMEDIAIRE);
			vppSqlCmd.Parameters.Add(vppParamIT_DENOMMINATION);
			vppSqlCmd.Parameters.Add(vppParamIT_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamIT_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARINTERMEDIAIRE  @IT_CODEINTERMEDIAIRE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparintermediaire </returns>
		///<author>Home Technology</author>
		public List<clsCtparintermediaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  IT_CODEINTERMEDIAIRE, IT_DENOMMINATION, IT_ACTIF, IT_NUMEROORDRE FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparintermediaire> clsCtparintermediaires = new List<clsCtparintermediaire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparintermediaire clsCtparintermediaire = new clsCtparintermediaire();
					clsCtparintermediaire.IT_CODEINTERMEDIAIRE = clsDonnee.vogDataReader["IT_CODEINTERMEDIAIRE"].ToString();
					clsCtparintermediaire.IT_DENOMMINATION = clsDonnee.vogDataReader["IT_DENOMMINATION"].ToString();
					clsCtparintermediaire.IT_ACTIF = clsDonnee.vogDataReader["IT_ACTIF"].ToString();
					clsCtparintermediaire.IT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["IT_NUMEROORDRE"].ToString());
					clsCtparintermediaires.Add(clsCtparintermediaire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparintermediaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparintermediaire </returns>
		///<author>Home Technology</author>
		public List<clsCtparintermediaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparintermediaire> clsCtparintermediaires = new List<clsCtparintermediaire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  IT_CODEINTERMEDIAIRE, IT_DENOMMINATION, IT_ACTIF, IT_NUMEROORDRE FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparintermediaire clsCtparintermediaire = new clsCtparintermediaire();
					clsCtparintermediaire.IT_CODEINTERMEDIAIRE = Dataset.Tables["TABLE"].Rows[Idx]["IT_CODEINTERMEDIAIRE"].ToString();
					clsCtparintermediaire.IT_DENOMMINATION = Dataset.Tables["TABLE"].Rows[Idx]["IT_DENOMMINATION"].ToString();
					clsCtparintermediaire.IT_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["IT_ACTIF"].ToString();
					clsCtparintermediaire.IT_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IT_NUMEROORDRE"].ToString());
					clsCtparintermediaires.Add(clsCtparintermediaire);
				}
				Dataset.Dispose();
			}
		return clsCtparintermediaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : IT_CODEINTERMEDIAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT IT_CODEINTERMEDIAIRE , IT_DENOMMINATION FROM dbo.FT_CTPARINTERMEDIAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :IT_CODEINTERMEDIAIRE)</summary>
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
				this.vapCritere ="WHERE IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@IT_CODEINTERMEDIAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
