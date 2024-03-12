using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpardureeWSDAL: ITableDAL<clsCtparduree>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DU_CODEDUREE) AS DU_CODEDUREE  FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DU_CODEDUREE) AS DU_CODEDUREE  FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DU_CODEDUREE) AS DU_CODEDUREE  FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparduree comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparduree pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DU_LIBELLEDUREE  , DU_ACTIF  , DU_NUMEROORDRE  FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparduree clsCtparduree = new clsCtparduree();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparduree.DU_LIBELLEDUREE = clsDonnee.vogDataReader["DU_LIBELLEDUREE"].ToString();
					clsCtparduree.DU_ACTIF = clsDonnee.vogDataReader["DU_ACTIF"].ToString();
					clsCtparduree.DU_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["DU_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparduree;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparduree>clsCtparduree</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparduree clsCtparduree)
		{
			//Préparation des paramètres
			SqlParameter vppParamDU_CODEDUREE = new SqlParameter("@DU_CODEDUREE", SqlDbType.VarChar, 25);
			vppParamDU_CODEDUREE.Value  = clsCtparduree.DU_CODEDUREE ;
			SqlParameter vppParamDU_LIBELLEDUREE = new SqlParameter("@DU_LIBELLEDUREE", SqlDbType.VarChar, 150);
			vppParamDU_LIBELLEDUREE.Value  = clsCtparduree.DU_LIBELLEDUREE ;
			SqlParameter vppParamDU_ACTIF = new SqlParameter("@DU_ACTIF", SqlDbType.VarChar, 1);
			vppParamDU_ACTIF.Value  = clsCtparduree.DU_ACTIF ;
			SqlParameter vppParamDU_NUMEROORDRE = new SqlParameter("@DU_NUMEROORDRE", SqlDbType.Int);
			vppParamDU_NUMEROORDRE.Value  = clsCtparduree.DU_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARDUREE  @DU_CODEDUREE, @DU_LIBELLEDUREE, @DU_ACTIF, @DU_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDU_CODEDUREE);
			vppSqlCmd.Parameters.Add(vppParamDU_LIBELLEDUREE);
			vppSqlCmd.Parameters.Add(vppParamDU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamDU_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparduree>clsCtparduree</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparduree clsCtparduree,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDU_CODEDUREE = new SqlParameter("@DU_CODEDUREE", SqlDbType.VarChar, 25);
			vppParamDU_CODEDUREE.Value  = clsCtparduree.DU_CODEDUREE ;
			SqlParameter vppParamDU_LIBELLEDUREE = new SqlParameter("@DU_LIBELLEDUREE", SqlDbType.VarChar, 150);
			vppParamDU_LIBELLEDUREE.Value  = clsCtparduree.DU_LIBELLEDUREE ;
			SqlParameter vppParamDU_ACTIF = new SqlParameter("@DU_ACTIF", SqlDbType.VarChar, 1);
			vppParamDU_ACTIF.Value  = clsCtparduree.DU_ACTIF ;
			SqlParameter vppParamDU_NUMEROORDRE = new SqlParameter("@DU_NUMEROORDRE", SqlDbType.Int);
			vppParamDU_NUMEROORDRE.Value  = clsCtparduree.DU_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARDUREE  @DU_CODEDUREE, @DU_LIBELLEDUREE, @DU_ACTIF, @DU_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDU_CODEDUREE);
			vppSqlCmd.Parameters.Add(vppParamDU_LIBELLEDUREE);
			vppSqlCmd.Parameters.Add(vppParamDU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamDU_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARDUREE  @DU_CODEDUREE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparduree </returns>
		///<author>Home Technology</author>
		public List<clsCtparduree> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DU_CODEDUREE, DU_LIBELLEDUREE, DU_ACTIF, DU_NUMEROORDRE FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparduree> clsCtpardurees = new List<clsCtparduree>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparduree clsCtparduree = new clsCtparduree();
					clsCtparduree.DU_CODEDUREE = clsDonnee.vogDataReader["DU_CODEDUREE"].ToString();
					clsCtparduree.DU_LIBELLEDUREE = clsDonnee.vogDataReader["DU_LIBELLEDUREE"].ToString();
					clsCtparduree.DU_ACTIF = clsDonnee.vogDataReader["DU_ACTIF"].ToString();
					clsCtparduree.DU_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["DU_NUMEROORDRE"].ToString());
					clsCtpardurees.Add(clsCtparduree);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpardurees;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparduree </returns>
		///<author>Home Technology</author>
		public List<clsCtparduree> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparduree> clsCtpardurees = new List<clsCtparduree>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DU_CODEDUREE, DU_LIBELLEDUREE, DU_ACTIF, DU_NUMEROORDRE FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparduree clsCtparduree = new clsCtparduree();
					clsCtparduree.DU_CODEDUREE = Dataset.Tables["TABLE"].Rows[Idx]["DU_CODEDUREE"].ToString();
					clsCtparduree.DU_LIBELLEDUREE = Dataset.Tables["TABLE"].Rows[Idx]["DU_LIBELLEDUREE"].ToString();
					clsCtparduree.DU_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["DU_ACTIF"].ToString();
					clsCtparduree.DU_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["DU_NUMEROORDRE"].ToString());
					clsCtpardurees.Add(clsCtparduree);
				}
				Dataset.Dispose();
			}
		return clsCtpardurees;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DU_CODEDUREE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DU_CODEDUREE , DU_LIBELLEDUREE FROM dbo.FT_CTPARDUREE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DU_CODEDUREE)</summary>
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
				this.vapCritere ="WHERE DU_CODEDUREE=@DU_CODEDUREE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DU_CODEDUREE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
