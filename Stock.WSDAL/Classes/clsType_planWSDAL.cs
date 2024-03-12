using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsType_planWSDAL: ITableDAL<clsType_plan>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TYPE_PLAN_CODE) AS TYPE_PLAN_CODE  FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(TYPE_PLAN_CODE) AS TYPE_PLAN_CODE  FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(TYPE_PLAN_CODE) AS TYPE_PLAN_CODE  FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsType_plan comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsType_plan pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TYPE_PLAN_LIBELLE  FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsType_plan clsType_plan = new clsType_plan();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsType_plan.TYPE_PLAN_LIBELLE = clsDonnee.vogDataReader["TYPE_PLAN_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsType_plan;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsType_plan>clsType_plan</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsType_plan clsType_plan)
		{
			//Préparation des paramètres
			SqlParameter vppParamTYPE_PLAN_CODE = new SqlParameter("@TYPE_PLAN_CODE", SqlDbType.VarChar, 2);
			vppParamTYPE_PLAN_CODE.Value  = clsType_plan.TYPE_PLAN_CODE ;
			if(clsType_plan.TYPE_PLAN_CODE== ""  ) vppParamTYPE_PLAN_CODE.Value  = DBNull.Value;
			SqlParameter vppParamTYPE_PLAN_LIBELLE = new SqlParameter("@TYPE_PLAN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTYPE_PLAN_LIBELLE.Value  = clsType_plan.TYPE_PLAN_LIBELLE ;
			if(clsType_plan.TYPE_PLAN_LIBELLE== ""  ) vppParamTYPE_PLAN_LIBELLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_TYPE_PLAN  @TYPE_PLAN_CODE, @TYPE_PLAN_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_CODE);
			vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsType_plan>clsType_plan</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsType_plan clsType_plan,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTYPE_PLAN_CODE = new SqlParameter("@TYPE_PLAN_CODE", SqlDbType.VarChar, 2);
			vppParamTYPE_PLAN_CODE.Value  = clsType_plan.TYPE_PLAN_CODE ;
			if(clsType_plan.TYPE_PLAN_CODE== ""  ) vppParamTYPE_PLAN_CODE.Value  = DBNull.Value;
			SqlParameter vppParamTYPE_PLAN_LIBELLE = new SqlParameter("@TYPE_PLAN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTYPE_PLAN_LIBELLE.Value  = clsType_plan.TYPE_PLAN_LIBELLE ;
			if(clsType_plan.TYPE_PLAN_LIBELLE== ""  ) vppParamTYPE_PLAN_LIBELLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_TYPE_PLAN  @TYPE_PLAN_CODE, @TYPE_PLAN_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_CODE);
			vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TYPE_PLAN  @TYPE_PLAN_CODE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsType_plan </returns>
		///<author>Home Technology</author>
		public List<clsType_plan> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  TYPE_PLAN_CODE, TYPE_PLAN_LIBELLE FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsType_plan> clsType_plans = new List<clsType_plan>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsType_plan clsType_plan = new clsType_plan();
					clsType_plan.TYPE_PLAN_CODE = clsDonnee.vogDataReader["TYPE_PLAN_CODE"].ToString();
					clsType_plan.TYPE_PLAN_LIBELLE = clsDonnee.vogDataReader["TYPE_PLAN_LIBELLE"].ToString();
					clsType_plans.Add(clsType_plan);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsType_plans;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsType_plan </returns>
		///<author>Home Technology</author>
		public List<clsType_plan> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsType_plan> clsType_plans = new List<clsType_plan>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  TYPE_PLAN_CODE, TYPE_PLAN_LIBELLE FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsType_plan clsType_plan = new clsType_plan();
					clsType_plan.TYPE_PLAN_CODE = Dataset.Tables["TABLE"].Rows[Idx]["TYPE_PLAN_CODE"].ToString();
					clsType_plan.TYPE_PLAN_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TYPE_PLAN_LIBELLE"].ToString();
					clsType_plans.Add(clsType_plan);
				}
				Dataset.Dispose();
			}
		return clsType_plans;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TYPE_PLAN_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TYPE_PLAN_CODE , TYPE_PLAN_LIBELLE FROM dbo.FT_COMPTAPAR_TYPE_PLAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TYPE_PLAN_CODE)</summary>
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
				this.vapCritere ="WHERE TYPE_PLAN_CODE=@TYPE_PLAN_CODE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TYPE_PLAN_CODE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
