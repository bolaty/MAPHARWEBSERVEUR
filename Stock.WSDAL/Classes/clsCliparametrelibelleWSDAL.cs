using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparametrelibelleWSDAL: ITableDAL<clsCliparametrelibelle>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PL_CODEPARAMETRELIBELLE) AS PL_CODEPARAMETRELIBELLE  FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PL_CODEPARAMETRELIBELLE) AS PL_CODEPARAMETRELIBELLE  FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PL_CODEPARAMETRELIBELLE) AS PL_CODEPARAMETRELIBELLE  FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparametrelibelle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparametrelibelle pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_LIBELLE  , PL_LIBELLEORIGINE  FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparametrelibelle clsCliparametrelibelle = new clsCliparametrelibelle();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparametrelibelle.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsCliparametrelibelle.PL_LIBELLEORIGINE = clsDonnee.vogDataReader["PL_LIBELLEORIGINE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparametrelibelle;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparametrelibelle>clsCliparametrelibelle</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparametrelibelle clsCliparametrelibelle)
		{
			//Préparation des paramètres
			SqlParameter vppParamPL_CODEPARAMETRELIBELLE = new SqlParameter("@PL_CODEPARAMETRELIBELLE", SqlDbType.VarChar, 4);
			vppParamPL_CODEPARAMETRELIBELLE.Value  = clsCliparametrelibelle.PL_CODEPARAMETRELIBELLE ;
			SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPL_LIBELLE.Value  = clsCliparametrelibelle.PL_LIBELLE ;
			SqlParameter vppParamPL_LIBELLEORIGINE = new SqlParameter("@PL_LIBELLEORIGINE", SqlDbType.VarChar, 150);
			vppParamPL_LIBELLEORIGINE.Value  = clsCliparametrelibelle.PL_LIBELLEORIGINE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARAMETRELIBELLE  @PL_CODEPARAMETRELIBELLE, @PL_LIBELLE, @PL_LIBELLEORIGINE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPARAMETRELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_LIBELLEORIGINE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparametrelibelle>clsCliparametrelibelle</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparametrelibelle clsCliparametrelibelle,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPL_CODEPARAMETRELIBELLE = new SqlParameter("@PL_CODEPARAMETRELIBELLE", SqlDbType.VarChar, 4);
			vppParamPL_CODEPARAMETRELIBELLE.Value  = clsCliparametrelibelle.PL_CODEPARAMETRELIBELLE ;
			SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPL_LIBELLE.Value  = clsCliparametrelibelle.PL_LIBELLE ;
			SqlParameter vppParamPL_LIBELLEORIGINE = new SqlParameter("@PL_LIBELLEORIGINE", SqlDbType.VarChar, 150);
			vppParamPL_LIBELLEORIGINE.Value  = clsCliparametrelibelle.PL_LIBELLEORIGINE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARAMETRELIBELLE  @PL_CODEPARAMETRELIBELLE, @PL_LIBELLE, @PL_LIBELLEORIGINE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPARAMETRELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_LIBELLEORIGINE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARAMETRELIBELLE  @PL_CODEPARAMETRELIBELLE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparametrelibelle </returns>
		///<author>Home Technology</author>
		public List<clsCliparametrelibelle> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PL_CODEPARAMETRELIBELLE, PL_LIBELLE, PL_LIBELLEORIGINE FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparametrelibelle> clsCliparametrelibelles = new List<clsCliparametrelibelle>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparametrelibelle clsCliparametrelibelle = new clsCliparametrelibelle();
					clsCliparametrelibelle.PL_CODEPARAMETRELIBELLE = clsDonnee.vogDataReader["PL_CODEPARAMETRELIBELLE"].ToString();
					clsCliparametrelibelle.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsCliparametrelibelle.PL_LIBELLEORIGINE = clsDonnee.vogDataReader["PL_LIBELLEORIGINE"].ToString();
					clsCliparametrelibelles.Add(clsCliparametrelibelle);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparametrelibelles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparametrelibelle </returns>
		///<author>Home Technology</author>
		public List<clsCliparametrelibelle> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparametrelibelle> clsCliparametrelibelles = new List<clsCliparametrelibelle>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PL_CODEPARAMETRELIBELLE, PL_LIBELLE, PL_LIBELLEORIGINE FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparametrelibelle clsCliparametrelibelle = new clsCliparametrelibelle();
					clsCliparametrelibelle.PL_CODEPARAMETRELIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODEPARAMETRELIBELLE"].ToString();
					clsCliparametrelibelle.PL_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_LIBELLE"].ToString();
					clsCliparametrelibelle.PL_LIBELLEORIGINE = Dataset.Tables["TABLE"].Rows[Idx]["PL_LIBELLEORIGINE"].ToString();
					clsCliparametrelibelles.Add(clsCliparametrelibelle);
				}
				Dataset.Dispose();
			}
		return clsCliparametrelibelles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PL_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_CODEPARAMETRELIBELLE , PL_LIBELLE FROM dbo.FT_CLIPARAMETRELIBELLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PL_CODEPARAMETRELIBELLE)</summary>
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
				this.vapCritere ="WHERE PL_CODEPARAMETRELIBELLE=@PL_CODEPARAMETRELIBELLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PL_CODEPARAMETRELIBELLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
