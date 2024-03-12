using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparautocategorieWSDAL: ITableDAL<clsCtparautocategorie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AU_CODECATEGORIE) AS AU_CODECATEGORIE  FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AU_CODECATEGORIE) AS AU_CODECATEGORIE  FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AU_CODECATEGORIE) AS AU_CODECATEGORIE  FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparautocategorie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparautocategorie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AU_LIBELLECATEGORIE  , AU_ACTIF  , AU_NUMEROORDRE  FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparautocategorie clsCtparautocategorie = new clsCtparautocategorie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparautocategorie.AU_LIBELLECATEGORIE = clsDonnee.vogDataReader["AU_LIBELLECATEGORIE"].ToString();
					clsCtparautocategorie.AU_ACTIF = clsDonnee.vogDataReader["AU_ACTIF"].ToString();
					clsCtparautocategorie.AU_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AU_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparautocategorie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparautocategorie>clsCtparautocategorie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparautocategorie clsCtparautocategorie)
		{
			//Préparation des paramètres
			SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.VarChar, 25);
			vppParamAU_CODECATEGORIE.Value  = clsCtparautocategorie.AU_CODECATEGORIE ;
			SqlParameter vppParamAU_LIBELLECATEGORIE = new SqlParameter("@AU_LIBELLECATEGORIE", SqlDbType.VarChar, 150);
			vppParamAU_LIBELLECATEGORIE.Value  = clsCtparautocategorie.AU_LIBELLECATEGORIE ;
			SqlParameter vppParamAU_ACTIF = new SqlParameter("@AU_ACTIF", SqlDbType.VarChar, 1);
			vppParamAU_ACTIF.Value  = clsCtparautocategorie.AU_ACTIF ;
			SqlParameter vppParamAU_NUMEROORDRE = new SqlParameter("@AU_NUMEROORDRE", SqlDbType.Int);
			vppParamAU_NUMEROORDRE.Value  = clsCtparautocategorie.AU_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARAUTOCATEGORIE  @AU_CODECATEGORIE, @AU_LIBELLECATEGORIE, @AU_ACTIF, @AU_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamAU_LIBELLECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamAU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamAU_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparautocategorie>clsCtparautocategorie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparautocategorie clsCtparautocategorie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.VarChar, 25);
			vppParamAU_CODECATEGORIE.Value  = clsCtparautocategorie.AU_CODECATEGORIE ;
			SqlParameter vppParamAU_LIBELLECATEGORIE = new SqlParameter("@AU_LIBELLECATEGORIE", SqlDbType.VarChar, 150);
			vppParamAU_LIBELLECATEGORIE.Value  = clsCtparautocategorie.AU_LIBELLECATEGORIE ;
			SqlParameter vppParamAU_ACTIF = new SqlParameter("@AU_ACTIF", SqlDbType.VarChar, 1);
			vppParamAU_ACTIF.Value  = clsCtparautocategorie.AU_ACTIF ;
			SqlParameter vppParamAU_NUMEROORDRE = new SqlParameter("@AU_NUMEROORDRE", SqlDbType.Int);
			vppParamAU_NUMEROORDRE.Value  = clsCtparautocategorie.AU_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARAUTOCATEGORIE  @AU_CODECATEGORIE, @AU_LIBELLECATEGORIE, @AU_ACTIF, @AU_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamAU_LIBELLECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamAU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamAU_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARAUTOCATEGORIE  @AU_CODECATEGORIE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparautocategorie </returns>
		///<author>Home Technology</author>
		public List<clsCtparautocategorie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AU_CODECATEGORIE, AU_LIBELLECATEGORIE, AU_ACTIF, AU_NUMEROORDRE FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparautocategorie> clsCtparautocategories = new List<clsCtparautocategorie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparautocategorie clsCtparautocategorie = new clsCtparautocategorie();
					clsCtparautocategorie.AU_CODECATEGORIE = clsDonnee.vogDataReader["AU_CODECATEGORIE"].ToString();
					clsCtparautocategorie.AU_LIBELLECATEGORIE = clsDonnee.vogDataReader["AU_LIBELLECATEGORIE"].ToString();
					clsCtparautocategorie.AU_ACTIF = clsDonnee.vogDataReader["AU_ACTIF"].ToString();
					clsCtparautocategorie.AU_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AU_NUMEROORDRE"].ToString());
					clsCtparautocategories.Add(clsCtparautocategorie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparautocategories;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparautocategorie </returns>
		///<author>Home Technology</author>
		public List<clsCtparautocategorie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparautocategorie> clsCtparautocategories = new List<clsCtparautocategorie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AU_CODECATEGORIE, AU_LIBELLECATEGORIE, AU_ACTIF, AU_NUMEROORDRE FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparautocategorie clsCtparautocategorie = new clsCtparautocategorie();
					clsCtparautocategorie.AU_CODECATEGORIE = Dataset.Tables["TABLE"].Rows[Idx]["AU_CODECATEGORIE"].ToString();
					clsCtparautocategorie.AU_LIBELLECATEGORIE = Dataset.Tables["TABLE"].Rows[Idx]["AU_LIBELLECATEGORIE"].ToString();
					clsCtparautocategorie.AU_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["AU_ACTIF"].ToString();
					clsCtparautocategorie.AU_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AU_NUMEROORDRE"].ToString());
					clsCtparautocategories.Add(clsCtparautocategorie);
				}
				Dataset.Dispose();
			}
		return clsCtparautocategories;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AU_CODECATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AU_CODECATEGORIE , AU_LIBELLECATEGORIE FROM dbo.FT_CTPARAUTOCATEGORIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AU_CODECATEGORIE)</summary>
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
				this.vapCritere ="WHERE AU_CODECATEGORIE=@AU_CODECATEGORIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AU_CODECATEGORIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
