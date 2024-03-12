using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhainputmodedegestionWSDAL: ITableDAL<clsPhainputmodedegestion>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhainputmodedegestion comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhainputmodedegestion pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT IN_AFFICHER  FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhainputmodedegestion clsPhainputmodedegestion = new clsPhainputmodedegestion();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhainputmodedegestion.IN_AFFICHER = clsDonnee.vogDataReader["IN_AFFICHER"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhainputmodedegestion;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhainputmodedegestion>clsPhainputmodedegestion</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhainputmodedegestion clsPhainputmodedegestion)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhainputmodedegestion.MG_CODEMODEGESTION ;
			SqlParameter vppParamIN_CODETYPEARTICLE = new SqlParameter("@IN_CODETYPEARTICLE", SqlDbType.VarChar, 3);
			vppParamIN_CODETYPEARTICLE.Value  = clsPhainputmodedegestion.IN_CODETYPEARTICLE ;
			SqlParameter vppParamIN_AFFICHER = new SqlParameter("@IN_AFFICHER", SqlDbType.VarChar, 1);
			vppParamIN_AFFICHER.Value  = clsPhainputmodedegestion.IN_AFFICHER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAINPUTMODEDEGESTION  @MG_CODEMODEGESTION, @IN_CODETYPEARTICLE, @IN_AFFICHER, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamIN_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamIN_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhainputmodedegestion>clsPhainputmodedegestion</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhainputmodedegestion clsPhainputmodedegestion,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhainputmodedegestion.MG_CODEMODEGESTION ;
			SqlParameter vppParamIN_CODETYPEARTICLE = new SqlParameter("@IN_CODETYPEARTICLE", SqlDbType.VarChar, 3);
			vppParamIN_CODETYPEARTICLE.Value  = clsPhainputmodedegestion.IN_CODETYPEARTICLE ;
			SqlParameter vppParamIN_AFFICHER = new SqlParameter("@IN_AFFICHER", SqlDbType.VarChar, 1);
			vppParamIN_AFFICHER.Value  = clsPhainputmodedegestion.IN_AFFICHER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAINPUTMODEDEGESTION  @MG_CODEMODEGESTION, @IN_CODETYPEARTICLE, @IN_AFFICHER, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamIN_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamIN_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAINPUTMODEDEGESTION  @MG_CODEMODEGESTION, @IN_CODETYPEARTICLE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainputmodedegestion </returns>
		///<author>Home Technology</author>
		public List<clsPhainputmodedegestion> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, IN_CODETYPEARTICLE, IN_AFFICHER FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhainputmodedegestion> clsPhainputmodedegestions = new List<clsPhainputmodedegestion>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhainputmodedegestion clsPhainputmodedegestion = new clsPhainputmodedegestion();
					clsPhainputmodedegestion.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhainputmodedegestion.IN_CODETYPEARTICLE = clsDonnee.vogDataReader["IN_CODETYPEARTICLE"].ToString();
					clsPhainputmodedegestion.IN_AFFICHER = clsDonnee.vogDataReader["IN_AFFICHER"].ToString();
					clsPhainputmodedegestions.Add(clsPhainputmodedegestion);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhainputmodedegestions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainputmodedegestion </returns>
		///<author>Home Technology</author>
		public List<clsPhainputmodedegestion> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhainputmodedegestion> clsPhainputmodedegestions = new List<clsPhainputmodedegestion>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, IN_CODETYPEARTICLE, IN_AFFICHER FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhainputmodedegestion clsPhainputmodedegestion = new clsPhainputmodedegestion();
					clsPhainputmodedegestion.MG_CODEMODEGESTION = Dataset.Tables["TABLE"].Rows[Idx]["MG_CODEMODEGESTION"].ToString();
					clsPhainputmodedegestion.IN_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["IN_CODETYPEARTICLE"].ToString();
					clsPhainputmodedegestion.IN_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["IN_AFFICHER"].ToString();
					clsPhainputmodedegestions.Add(clsPhainputmodedegestion);
				}
				Dataset.Dispose();
			}
		return clsPhainputmodedegestions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MG_CODEMODEGESTION, IN_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MG_CODEMODEGESTION , IN_AFFICHER FROM dbo.FT_PHAINPUTMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MG_CODEMODEGESTION, IN_CODETYPEARTICLE)</summary>
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
				this.vapCritere ="WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MG_CODEMODEGESTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND IN_CODETYPEARTICLE=@IN_CODETYPEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MG_CODEMODEGESTION","@IN_CODETYPEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
