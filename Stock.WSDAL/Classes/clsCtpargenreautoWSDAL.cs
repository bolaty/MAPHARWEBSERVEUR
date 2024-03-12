using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpargenreautoWSDAL: ITableDAL<clsCtpargenreauto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(GE_CODEGENRE) AS GE_CODEGENRE  FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(GE_CODEGENRE) AS GE_CODEGENRE  FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(GE_CODEGENRE) AS GE_CODEGENRE  FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpargenreauto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpargenreauto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT GE_LIBELLEGENRE  , GE_ACTIF  , GE_NUMEROORDRE  FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpargenreauto clsCtpargenreauto = new clsCtpargenreauto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpargenreauto.GE_LIBELLEGENRE = clsDonnee.vogDataReader["GE_LIBELLEGENRE"].ToString();
					clsCtpargenreauto.GE_ACTIF = clsDonnee.vogDataReader["GE_ACTIF"].ToString();
					clsCtpargenreauto.GE_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GE_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpargenreauto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpargenreauto>clsCtpargenreauto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpargenreauto clsCtpargenreauto)
		{
			//Préparation des paramètres
			SqlParameter vppParamGE_CODEGENRE = new SqlParameter("@GE_CODEGENRE", SqlDbType.VarChar, 3);
			vppParamGE_CODEGENRE.Value  = clsCtpargenreauto.GE_CODEGENRE ;
			SqlParameter vppParamGE_LIBELLEGENRE = new SqlParameter("@GE_LIBELLEGENRE", SqlDbType.VarChar, 150);
			vppParamGE_LIBELLEGENRE.Value  = clsCtpargenreauto.GE_LIBELLEGENRE ;
			SqlParameter vppParamGE_ACTIF = new SqlParameter("@GE_ACTIF", SqlDbType.VarChar, 1);
			vppParamGE_ACTIF.Value  = clsCtpargenreauto.GE_ACTIF ;
			SqlParameter vppParamGE_NUMEROORDRE = new SqlParameter("@GE_NUMEROORDRE", SqlDbType.Int);
			vppParamGE_NUMEROORDRE.Value  = clsCtpargenreauto.GE_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGENREAUTO  @GE_CODEGENRE, @GE_LIBELLEGENRE, @GE_ACTIF, @GE_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGE_CODEGENRE);
			vppSqlCmd.Parameters.Add(vppParamGE_LIBELLEGENRE);
			vppSqlCmd.Parameters.Add(vppParamGE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamGE_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpargenreauto>clsCtpargenreauto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpargenreauto clsCtpargenreauto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamGE_CODEGENRE = new SqlParameter("@GE_CODEGENRE", SqlDbType.VarChar, 3);
			vppParamGE_CODEGENRE.Value  = clsCtpargenreauto.GE_CODEGENRE ;
			SqlParameter vppParamGE_LIBELLEGENRE = new SqlParameter("@GE_LIBELLEGENRE", SqlDbType.VarChar, 150);
			vppParamGE_LIBELLEGENRE.Value  = clsCtpargenreauto.GE_LIBELLEGENRE ;
			SqlParameter vppParamGE_ACTIF = new SqlParameter("@GE_ACTIF", SqlDbType.VarChar, 1);
			vppParamGE_ACTIF.Value  = clsCtpargenreauto.GE_ACTIF ;
			SqlParameter vppParamGE_NUMEROORDRE = new SqlParameter("@GE_NUMEROORDRE", SqlDbType.Int);
			vppParamGE_NUMEROORDRE.Value  = clsCtpargenreauto.GE_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGENREAUTO  @GE_CODEGENRE, @GE_LIBELLEGENRE, @GE_ACTIF, @GE_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGE_CODEGENRE);
			vppSqlCmd.Parameters.Add(vppParamGE_LIBELLEGENRE);
			vppSqlCmd.Parameters.Add(vppParamGE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamGE_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGENREAUTO  @GE_CODEGENRE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargenreauto </returns>
		///<author>Home Technology</author>
		public List<clsCtpargenreauto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  GE_CODEGENRE, GE_LIBELLEGENRE, GE_ACTIF, GE_NUMEROORDRE FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpargenreauto> clsCtpargenreautos = new List<clsCtpargenreauto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpargenreauto clsCtpargenreauto = new clsCtpargenreauto();
					clsCtpargenreauto.GE_CODEGENRE = clsDonnee.vogDataReader["GE_CODEGENRE"].ToString();
					clsCtpargenreauto.GE_LIBELLEGENRE = clsDonnee.vogDataReader["GE_LIBELLEGENRE"].ToString();
					clsCtpargenreauto.GE_ACTIF = clsDonnee.vogDataReader["GE_ACTIF"].ToString();
					clsCtpargenreauto.GE_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GE_NUMEROORDRE"].ToString());
					clsCtpargenreautos.Add(clsCtpargenreauto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpargenreautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargenreauto </returns>
		///<author>Home Technology</author>
		public List<clsCtpargenreauto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpargenreauto> clsCtpargenreautos = new List<clsCtpargenreauto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  GE_CODEGENRE, GE_LIBELLEGENRE, GE_ACTIF, GE_NUMEROORDRE FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpargenreauto clsCtpargenreauto = new clsCtpargenreauto();
					clsCtpargenreauto.GE_CODEGENRE = Dataset.Tables["TABLE"].Rows[Idx]["GE_CODEGENRE"].ToString();
					clsCtpargenreauto.GE_LIBELLEGENRE = Dataset.Tables["TABLE"].Rows[Idx]["GE_LIBELLEGENRE"].ToString();
					clsCtpargenreauto.GE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["GE_ACTIF"].ToString();
					clsCtpargenreauto.GE_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["GE_NUMEROORDRE"].ToString());
					clsCtpargenreautos.Add(clsCtpargenreauto);
				}
				Dataset.Dispose();
			}
		return clsCtpargenreautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GE_CODEGENRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT GE_CODEGENRE , GE_LIBELLEGENRE FROM dbo.FT_CTPARGENREAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :GE_CODEGENRE)</summary>
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
				this.vapCritere ="WHERE GE_CODEGENRE=@GE_CODEGENRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@GE_CODEGENRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
