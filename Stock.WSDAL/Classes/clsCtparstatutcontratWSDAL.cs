using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparstatutcontratWSDAL: ITableDAL<clsCtparstatutcontrat>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CT_CODESTAUT) AS CT_CODESTAUT  FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CT_CODESTAUT) AS CT_CODESTAUT  FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CT_CODESTAUT) AS CT_CODESTAUT  FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparstatutcontrat comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparstatutcontrat pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CT_LIBELLESTATUT  , CT_NUMEROORDRE  FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparstatutcontrat clsCtparstatutcontrat = new clsCtparstatutcontrat();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparstatutcontrat.CT_LIBELLESTATUT = clsDonnee.vogDataReader["CT_LIBELLESTATUT"].ToString();
					clsCtparstatutcontrat.CT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CT_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparstatutcontrat;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparstatutcontrat>clsCtparstatutcontrat</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparstatutcontrat clsCtparstatutcontrat)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODESTAUT = new SqlParameter("@CT_CODESTAUT", SqlDbType.VarChar, 2);
			vppParamCT_CODESTAUT.Value  = clsCtparstatutcontrat.CT_CODESTAUT ;
			SqlParameter vppParamCT_LIBELLESTATUT = new SqlParameter("@CT_LIBELLESTATUT", SqlDbType.VarChar, 150);
			vppParamCT_LIBELLESTATUT.Value  = clsCtparstatutcontrat.CT_LIBELLESTATUT ;
			SqlParameter vppParamCT_NUMEROORDRE = new SqlParameter("@CT_NUMEROORDRE", SqlDbType.Int);
			vppParamCT_NUMEROORDRE.Value  = clsCtparstatutcontrat.CT_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSTATUTCONTRAT  @CT_CODESTAUT, @CT_LIBELLESTATUT, @CT_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODESTAUT);
			vppSqlCmd.Parameters.Add(vppParamCT_LIBELLESTATUT);
			vppSqlCmd.Parameters.Add(vppParamCT_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparstatutcontrat>clsCtparstatutcontrat</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparstatutcontrat clsCtparstatutcontrat,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODESTAUT = new SqlParameter("@CT_CODESTAUT", SqlDbType.VarChar, 2);
			vppParamCT_CODESTAUT.Value  = clsCtparstatutcontrat.CT_CODESTAUT ;
			SqlParameter vppParamCT_LIBELLESTATUT = new SqlParameter("@CT_LIBELLESTATUT", SqlDbType.VarChar, 150);
			vppParamCT_LIBELLESTATUT.Value  = clsCtparstatutcontrat.CT_LIBELLESTATUT ;
			SqlParameter vppParamCT_NUMEROORDRE = new SqlParameter("@CT_NUMEROORDRE", SqlDbType.Int);
			vppParamCT_NUMEROORDRE.Value  = clsCtparstatutcontrat.CT_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSTATUTCONTRAT  @CT_CODESTAUT, @CT_LIBELLESTATUT, @CT_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODESTAUT);
			vppSqlCmd.Parameters.Add(vppParamCT_LIBELLESTATUT);
			vppSqlCmd.Parameters.Add(vppParamCT_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSTATUTCONTRAT  @CT_CODESTAUT, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparstatutcontrat </returns>
		///<author>Home Technology</author>
		public List<clsCtparstatutcontrat> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CT_CODESTAUT, CT_LIBELLESTATUT, CT_NUMEROORDRE FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparstatutcontrat> clsCtparstatutcontrats = new List<clsCtparstatutcontrat>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparstatutcontrat clsCtparstatutcontrat = new clsCtparstatutcontrat();
					clsCtparstatutcontrat.CT_CODESTAUT = clsDonnee.vogDataReader["CT_CODESTAUT"].ToString();
					clsCtparstatutcontrat.CT_LIBELLESTATUT = clsDonnee.vogDataReader["CT_LIBELLESTATUT"].ToString();
					clsCtparstatutcontrat.CT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CT_NUMEROORDRE"].ToString());
					clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparstatutcontrats;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparstatutcontrat </returns>
		///<author>Home Technology</author>
		public List<clsCtparstatutcontrat> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparstatutcontrat> clsCtparstatutcontrats = new List<clsCtparstatutcontrat>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CT_CODESTAUT, CT_LIBELLESTATUT, CT_NUMEROORDRE FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparstatutcontrat clsCtparstatutcontrat = new clsCtparstatutcontrat();
					clsCtparstatutcontrat.CT_CODESTAUT = Dataset.Tables["TABLE"].Rows[Idx]["CT_CODESTAUT"].ToString();
					clsCtparstatutcontrat.CT_LIBELLESTATUT = Dataset.Tables["TABLE"].Rows[Idx]["CT_LIBELLESTATUT"].ToString();
					clsCtparstatutcontrat.CT_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CT_NUMEROORDRE"].ToString());
					clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
				}
				Dataset.Dispose();
			}
		return clsCtparstatutcontrats;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CT_CODESTAUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CT_CODESTAUT , CT_LIBELLESTATUT FROM dbo.FT_CTPARSTATUTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CT_CODESTAUT)</summary>
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
				this.vapCritere ="WHERE CT_CODESTAUT=@CT_CODESTAUT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CT_CODESTAUT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
