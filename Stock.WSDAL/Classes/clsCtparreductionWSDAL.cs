using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparreductionWSDAL: ITableDAL<clsCtparreduction>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RD_CODEREDUCTION) AS RD_CODEREDUCTION  FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RD_CODEREDUCTION) AS RD_CODEREDUCTION  FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RD_CODEREDUCTION) AS RD_CODEREDUCTION  FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparreduction comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparreduction pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RD_LIBELLEREDUCTION  , RD_ACTIF  , RD_NUMEROORDRE  FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparreduction clsCtparreduction = new clsCtparreduction();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparreduction.RD_LIBELLEREDUCTION = clsDonnee.vogDataReader["RD_LIBELLEREDUCTION"].ToString();
					clsCtparreduction.RD_ACTIF = clsDonnee.vogDataReader["RD_ACTIF"].ToString();
					clsCtparreduction.RD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparreduction;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparreduction>clsCtparreduction</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparreduction clsCtparreduction)
		{
			//Préparation des paramètres
			SqlParameter vppParamRD_CODEREDUCTION = new SqlParameter("@RD_CODEREDUCTION", SqlDbType.VarChar, 2);
			vppParamRD_CODEREDUCTION.Value  = clsCtparreduction.RD_CODEREDUCTION ;
			SqlParameter vppParamRD_LIBELLEREDUCTION = new SqlParameter("@RD_LIBELLEREDUCTION", SqlDbType.VarChar, 150);
			vppParamRD_LIBELLEREDUCTION.Value  = clsCtparreduction.RD_LIBELLEREDUCTION ;
			SqlParameter vppParamRD_ACTIF = new SqlParameter("@RD_ACTIF", SqlDbType.VarChar, 1);
			vppParamRD_ACTIF.Value  = clsCtparreduction.RD_ACTIF ;
			SqlParameter vppParamRD_NUMEROORDRE = new SqlParameter("@RD_NUMEROORDRE", SqlDbType.Int);
			vppParamRD_NUMEROORDRE.Value  = clsCtparreduction.RD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARREDUCTION  @RD_CODEREDUCTION, @RD_LIBELLEREDUCTION, @RD_ACTIF, @RD_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRD_CODEREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamRD_LIBELLEREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamRD_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamRD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparreduction>clsCtparreduction</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparreduction clsCtparreduction,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRD_CODEREDUCTION = new SqlParameter("@RD_CODEREDUCTION", SqlDbType.VarChar, 2);
			vppParamRD_CODEREDUCTION.Value  = clsCtparreduction.RD_CODEREDUCTION ;
			SqlParameter vppParamRD_LIBELLEREDUCTION = new SqlParameter("@RD_LIBELLEREDUCTION", SqlDbType.VarChar, 150);
			vppParamRD_LIBELLEREDUCTION.Value  = clsCtparreduction.RD_LIBELLEREDUCTION ;
			SqlParameter vppParamRD_ACTIF = new SqlParameter("@RD_ACTIF", SqlDbType.VarChar, 1);
			vppParamRD_ACTIF.Value  = clsCtparreduction.RD_ACTIF ;
			SqlParameter vppParamRD_NUMEROORDRE = new SqlParameter("@RD_NUMEROORDRE", SqlDbType.Int);
			vppParamRD_NUMEROORDRE.Value  = clsCtparreduction.RD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARREDUCTION  @RD_CODEREDUCTION, @RD_LIBELLEREDUCTION, @RD_ACTIF, @RD_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRD_CODEREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamRD_LIBELLEREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamRD_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamRD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARREDUCTION  @RD_CODEREDUCTION, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparreduction </returns>
		///<author>Home Technology</author>
		public List<clsCtparreduction> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RD_CODEREDUCTION, RD_LIBELLEREDUCTION, RD_ACTIF, RD_NUMEROORDRE FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparreduction> clsCtparreductions = new List<clsCtparreduction>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparreduction clsCtparreduction = new clsCtparreduction();
					clsCtparreduction.RD_CODEREDUCTION = clsDonnee.vogDataReader["RD_CODEREDUCTION"].ToString();
					clsCtparreduction.RD_LIBELLEREDUCTION = clsDonnee.vogDataReader["RD_LIBELLEREDUCTION"].ToString();
					clsCtparreduction.RD_ACTIF = clsDonnee.vogDataReader["RD_ACTIF"].ToString();
					clsCtparreduction.RD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RD_NUMEROORDRE"].ToString());
					clsCtparreductions.Add(clsCtparreduction);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparreductions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparreduction </returns>
		///<author>Home Technology</author>
		public List<clsCtparreduction> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparreduction> clsCtparreductions = new List<clsCtparreduction>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RD_CODEREDUCTION, RD_LIBELLEREDUCTION, RD_ACTIF, RD_NUMEROORDRE FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparreduction clsCtparreduction = new clsCtparreduction();
					clsCtparreduction.RD_CODEREDUCTION = Dataset.Tables["TABLE"].Rows[Idx]["RD_CODEREDUCTION"].ToString();
					clsCtparreduction.RD_LIBELLEREDUCTION = Dataset.Tables["TABLE"].Rows[Idx]["RD_LIBELLEREDUCTION"].ToString();
					clsCtparreduction.RD_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["RD_ACTIF"].ToString();
					clsCtparreduction.RD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_NUMEROORDRE"].ToString());
					clsCtparreductions.Add(clsCtparreduction);
				}
				Dataset.Dispose();
			}
		return clsCtparreductions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY RD_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RD_CODEREDUCTION , RD_LIBELLEREDUCTION FROM dbo.FT_CTPARREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RD_CODEREDUCTION)</summary>
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
				this.vapCritere ="WHERE RD_CODEREDUCTION=@RD_CODEREDUCTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RD_CODEREDUCTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
