using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsDeviseWSDAL: ITableDAL<clsDevise>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DE_CODEDEVISE) AS DE_CODEDEVISE  FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DE_CODEDEVISE) AS DE_CODEDEVISE  FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DE_CODEDEVISE) AS DE_CODEDEVISE  FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsDevise comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsDevise pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DE_DEVISECODE  , DE_LIBELLEDEVISE  , DE_DEVISEREFERENCE  , DE_ACTIF  FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDevise clsDevise = new clsDevise();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsDevise.DE_DEVISECODE = clsDonnee.vogDataReader["DE_DEVISECODE"].ToString();
					clsDevise.DE_LIBELLEDEVISE = clsDonnee.vogDataReader["DE_LIBELLEDEVISE"].ToString();
					clsDevise.DE_DEVISEREFERENCE = clsDonnee.vogDataReader["DE_DEVISEREFERENCE"].ToString();
					clsDevise.DE_ACTIF = clsDonnee.vogDataReader["DE_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsDevise;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsDevise>clsDevise</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsDevise clsDevise)
		{
			//Préparation des paramètres
			SqlParameter vppParamDE_CODEDEVISE = new SqlParameter("@DE_CODEDEVISE", SqlDbType.VarChar, 4);
			vppParamDE_CODEDEVISE.Value  = clsDevise.DE_CODEDEVISE ;
			SqlParameter vppParamDE_DEVISECODE = new SqlParameter("@DE_DEVISECODE", SqlDbType.VarChar, 50);
			vppParamDE_DEVISECODE.Value  = clsDevise.DE_DEVISECODE ;
			SqlParameter vppParamDE_LIBELLEDEVISE = new SqlParameter("@DE_LIBELLEDEVISE", SqlDbType.VarChar, 150);
			vppParamDE_LIBELLEDEVISE.Value  = clsDevise.DE_LIBELLEDEVISE ;
			SqlParameter vppParamDE_DEVISEREFERENCE = new SqlParameter("@DE_DEVISEREFERENCE", SqlDbType.VarChar, 1);
			vppParamDE_DEVISEREFERENCE.Value  = clsDevise.DE_DEVISEREFERENCE ;
			SqlParameter vppParamDE_ACTIF = new SqlParameter("@DE_ACTIF", SqlDbType.VarChar, 1);
			vppParamDE_ACTIF.Value  = clsDevise.DE_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_DEVISE  @DE_CODEDEVISE, @DE_DEVISECODE, @DE_LIBELLEDEVISE, @DE_DEVISEREFERENCE, @DE_ACTIF, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamDE_DEVISECODE);
			vppSqlCmd.Parameters.Add(vppParamDE_LIBELLEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamDE_DEVISEREFERENCE);
			vppSqlCmd.Parameters.Add(vppParamDE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsDevise>clsDevise</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsDevise clsDevise,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDE_CODEDEVISE = new SqlParameter("@DE_CODEDEVISE", SqlDbType.VarChar, 4);
			vppParamDE_CODEDEVISE.Value  = clsDevise.DE_CODEDEVISE ;
			SqlParameter vppParamDE_DEVISECODE = new SqlParameter("@DE_DEVISECODE", SqlDbType.VarChar, 50);
			vppParamDE_DEVISECODE.Value  = clsDevise.DE_DEVISECODE ;
			SqlParameter vppParamDE_LIBELLEDEVISE = new SqlParameter("@DE_LIBELLEDEVISE", SqlDbType.VarChar, 150);
			vppParamDE_LIBELLEDEVISE.Value  = clsDevise.DE_LIBELLEDEVISE ;
			SqlParameter vppParamDE_DEVISEREFERENCE = new SqlParameter("@DE_DEVISEREFERENCE", SqlDbType.VarChar, 1);
			vppParamDE_DEVISEREFERENCE.Value  = clsDevise.DE_DEVISEREFERENCE ;
			SqlParameter vppParamDE_ACTIF = new SqlParameter("@DE_ACTIF", SqlDbType.VarChar, 1);
			vppParamDE_ACTIF.Value  = clsDevise.DE_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_DEVISE  @DE_CODEDEVISE, @DE_DEVISECODE, @DE_LIBELLEDEVISE, @DE_DEVISEREFERENCE, @DE_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamDE_DEVISECODE);
			vppSqlCmd.Parameters.Add(vppParamDE_LIBELLEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamDE_DEVISEREFERENCE);
			vppSqlCmd.Parameters.Add(vppParamDE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_DEVISE  @DE_CODEDEVISE, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsDevise </returns>
		///<author>Home Technology</author>
		public List<clsDevise> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DE_CODEDEVISE, DE_DEVISECODE, DE_LIBELLEDEVISE, DE_DEVISEREFERENCE, DE_ACTIF FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsDevise> clsDevises = new List<clsDevise>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsDevise clsDevise = new clsDevise();
					clsDevise.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
					clsDevise.DE_DEVISECODE = clsDonnee.vogDataReader["DE_DEVISECODE"].ToString();
					clsDevise.DE_LIBELLEDEVISE = clsDonnee.vogDataReader["DE_LIBELLEDEVISE"].ToString();
					clsDevise.DE_DEVISEREFERENCE = clsDonnee.vogDataReader["DE_DEVISEREFERENCE"].ToString();
					clsDevise.DE_ACTIF = clsDonnee.vogDataReader["DE_ACTIF"].ToString();
					clsDevises.Add(clsDevise);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsDevises;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsDevise </returns>
		///<author>Home Technology</author>
		public List<clsDevise> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsDevise> clsDevises = new List<clsDevise>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DE_CODEDEVISE, DE_DEVISECODE, DE_LIBELLEDEVISE, DE_DEVISEREFERENCE, DE_ACTIF FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsDevise clsDevise = new clsDevise();
					clsDevise.DE_CODEDEVISE = Dataset.Tables["TABLE"].Rows[Idx]["DE_CODEDEVISE"].ToString();
					clsDevise.DE_DEVISECODE = Dataset.Tables["TABLE"].Rows[Idx]["DE_DEVISECODE"].ToString();
					clsDevise.DE_LIBELLEDEVISE = Dataset.Tables["TABLE"].Rows[Idx]["DE_LIBELLEDEVISE"].ToString();
					clsDevise.DE_DEVISEREFERENCE = Dataset.Tables["TABLE"].Rows[Idx]["DE_DEVISEREFERENCE"].ToString();
					clsDevise.DE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["DE_ACTIF"].ToString();
					clsDevises.Add(clsDevise);
				}
				Dataset.Dispose();
			}
		return clsDevises;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DE_CODEDEVISE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DE_CODEDEVISE , DE_DEVISECODE FROM dbo.FT_DEVISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DE_CODEDEVISE)</summary>
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
				this.vapCritere ="WHERE DE_CODEDEVISE=@DE_CODEDEVISE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DE_CODEDEVISE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
