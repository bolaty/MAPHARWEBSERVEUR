using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparcategorieordonnanceWSDAL: ITableDAL<clsCliparcategorieordonnance>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CT_CODECATEGORIEORDONNANCE) AS CT_CODECATEGORIEORDONNANCE  FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CT_CODECATEGORIEORDONNANCE) AS CT_CODECATEGORIEORDONNANCE  FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CT_CODECATEGORIEORDONNANCE) AS CT_CODECATEGORIEORDONNANCE  FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparcategorieordonnance comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparcategorieordonnance pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CT_LIBELLECATEGORIE  FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparcategorieordonnance clsCliparcategorieordonnance = new clsCliparcategorieordonnance();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcategorieordonnance.CT_LIBELLECATEGORIE = clsDonnee.vogDataReader["CT_LIBELLECATEGORIE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparcategorieordonnance;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcategorieordonnance>clsCliparcategorieordonnance</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparcategorieordonnance clsCliparcategorieordonnance)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODECATEGORIEORDONNANCE = new SqlParameter("@CT_CODECATEGORIEORDONNANCE", SqlDbType.VarChar, 3);
			vppParamCT_CODECATEGORIEORDONNANCE.Value  = clsCliparcategorieordonnance.CT_CODECATEGORIEORDONNANCE ;
			SqlParameter vppParamCT_LIBELLECATEGORIE = new SqlParameter("@CT_LIBELLECATEGORIE", SqlDbType.VarChar, 150);
			vppParamCT_LIBELLECATEGORIE.Value  = clsCliparcategorieordonnance.CT_LIBELLECATEGORIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCATEGORIEORDONNANCE  @CT_CODECATEGORIEORDONNANCE, @CT_LIBELLECATEGORIE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODECATEGORIEORDONNANCE);
			vppSqlCmd.Parameters.Add(vppParamCT_LIBELLECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcategorieordonnance>clsCliparcategorieordonnance</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparcategorieordonnance clsCliparcategorieordonnance,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODECATEGORIEORDONNANCE = new SqlParameter("@CT_CODECATEGORIEORDONNANCE", SqlDbType.VarChar, 3);
			vppParamCT_CODECATEGORIEORDONNANCE.Value  = clsCliparcategorieordonnance.CT_CODECATEGORIEORDONNANCE ;
			SqlParameter vppParamCT_LIBELLECATEGORIE = new SqlParameter("@CT_LIBELLECATEGORIE", SqlDbType.VarChar, 150);
			vppParamCT_LIBELLECATEGORIE.Value  = clsCliparcategorieordonnance.CT_LIBELLECATEGORIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCATEGORIEORDONNANCE  @CT_CODECATEGORIEORDONNANCE, @CT_LIBELLECATEGORIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODECATEGORIEORDONNANCE);
			vppSqlCmd.Parameters.Add(vppParamCT_LIBELLECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCATEGORIEORDONNANCE  @CT_CODECATEGORIEORDONNANCE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcategorieordonnance </returns>
		///<author>Home Technology</author>
		public List<clsCliparcategorieordonnance> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CT_CODECATEGORIEORDONNANCE, CT_LIBELLECATEGORIE FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparcategorieordonnance> clsCliparcategorieordonnances = new List<clsCliparcategorieordonnance>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcategorieordonnance clsCliparcategorieordonnance = new clsCliparcategorieordonnance();
					clsCliparcategorieordonnance.CT_CODECATEGORIEORDONNANCE = clsDonnee.vogDataReader["CT_CODECATEGORIEORDONNANCE"].ToString();
					clsCliparcategorieordonnance.CT_LIBELLECATEGORIE = clsDonnee.vogDataReader["CT_LIBELLECATEGORIE"].ToString();
					clsCliparcategorieordonnances.Add(clsCliparcategorieordonnance);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparcategorieordonnances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcategorieordonnance </returns>
		///<author>Home Technology</author>
		public List<clsCliparcategorieordonnance> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparcategorieordonnance> clsCliparcategorieordonnances = new List<clsCliparcategorieordonnance>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CT_CODECATEGORIEORDONNANCE, CT_LIBELLECATEGORIE FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparcategorieordonnance clsCliparcategorieordonnance = new clsCliparcategorieordonnance();
					clsCliparcategorieordonnance.CT_CODECATEGORIEORDONNANCE = Dataset.Tables["TABLE"].Rows[Idx]["CT_CODECATEGORIEORDONNANCE"].ToString();
					clsCliparcategorieordonnance.CT_LIBELLECATEGORIE = Dataset.Tables["TABLE"].Rows[Idx]["CT_LIBELLECATEGORIE"].ToString();
					clsCliparcategorieordonnances.Add(clsCliparcategorieordonnance);
				}
				Dataset.Dispose();
			}
		return clsCliparcategorieordonnances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CT_CODECATEGORIEORDONNANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CT_CODECATEGORIEORDONNANCE , CT_LIBELLECATEGORIE FROM dbo.FT_CLIPARCATEGORIEORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CT_CODECATEGORIEORDONNANCE)</summary>
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
				this.vapCritere ="WHERE CT_CODECATEGORIEORDONNANCE=@CT_CODECATEGORIEORDONNANCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CT_CODECATEGORIEORDONNANCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
