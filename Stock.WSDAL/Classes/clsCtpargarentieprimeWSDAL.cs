using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpargarentieprimeWSDAL: ITableDAL<clsCtpargarentieprime>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(GR_CODEGARENTIEPRIME) AS GR_CODEGARENTIEPRIME  FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(GR_CODEGARENTIEPRIME) AS GR_CODEGARENTIEPRIME  FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(GR_CODEGARENTIEPRIME) AS GR_CODEGARENTIEPRIME  FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpargarentieprime comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpargarentieprime pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT GR_LIBELLEGARENTIEPRIME  , GR_ACTIFPRIME  , GR_NUMEROORDREPRIME  FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpargarentieprime clsCtpargarentieprime = new clsCtpargarentieprime();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpargarentieprime.GR_LIBELLEGARENTIEPRIME = clsDonnee.vogDataReader["GR_LIBELLEGARENTIEPRIME"].ToString();
					clsCtpargarentieprime.GR_ACTIFPRIME = clsDonnee.vogDataReader["GR_ACTIFPRIME"].ToString();
					clsCtpargarentieprime.GR_NUMEROORDREPRIME = int.Parse(clsDonnee.vogDataReader["GR_NUMEROORDREPRIME"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpargarentieprime;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpargarentieprime>clsCtpargarentieprime</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpargarentieprime clsCtpargarentieprime)
		{
			//Préparation des paramètres
			SqlParameter vppParamGR_CODEGARENTIEPRIME = new SqlParameter("@GR_CODEGARENTIEPRIME", SqlDbType.VarChar, 4);
			vppParamGR_CODEGARENTIEPRIME.Value  = clsCtpargarentieprime.GR_CODEGARENTIEPRIME ;
			SqlParameter vppParamGR_LIBELLEGARENTIEPRIME = new SqlParameter("@GR_LIBELLEGARENTIEPRIME", SqlDbType.VarChar, 150);
			vppParamGR_LIBELLEGARENTIEPRIME.Value  = clsCtpargarentieprime.GR_LIBELLEGARENTIEPRIME ;
			SqlParameter vppParamGR_ACTIFPRIME = new SqlParameter("@GR_ACTIFPRIME", SqlDbType.VarChar, 1);
			vppParamGR_ACTIFPRIME.Value  = clsCtpargarentieprime.GR_ACTIFPRIME ;
			SqlParameter vppParamGR_NUMEROORDREPRIME = new SqlParameter("@GR_NUMEROORDREPRIME", SqlDbType.Int);
			vppParamGR_NUMEROORDREPRIME.Value  = clsCtpargarentieprime.GR_NUMEROORDREPRIME ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGARENTIEPRIME  @GR_CODEGARENTIEPRIME, @GR_LIBELLEGARENTIEPRIME, @GR_ACTIFPRIME, @GR_NUMEROORDREPRIME, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGR_CODEGARENTIEPRIME);
			vppSqlCmd.Parameters.Add(vppParamGR_LIBELLEGARENTIEPRIME);
			vppSqlCmd.Parameters.Add(vppParamGR_ACTIFPRIME);
			vppSqlCmd.Parameters.Add(vppParamGR_NUMEROORDREPRIME);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpargarentieprime>clsCtpargarentieprime</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpargarentieprime clsCtpargarentieprime,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamGR_CODEGARENTIEPRIME = new SqlParameter("@GR_CODEGARENTIEPRIME", SqlDbType.VarChar, 4);
			vppParamGR_CODEGARENTIEPRIME.Value  = clsCtpargarentieprime.GR_CODEGARENTIEPRIME ;
			SqlParameter vppParamGR_LIBELLEGARENTIEPRIME = new SqlParameter("@GR_LIBELLEGARENTIEPRIME", SqlDbType.VarChar, 150);
			vppParamGR_LIBELLEGARENTIEPRIME.Value  = clsCtpargarentieprime.GR_LIBELLEGARENTIEPRIME ;
			SqlParameter vppParamGR_ACTIFPRIME = new SqlParameter("@GR_ACTIFPRIME", SqlDbType.VarChar, 1);
			vppParamGR_ACTIFPRIME.Value  = clsCtpargarentieprime.GR_ACTIFPRIME ;
			SqlParameter vppParamGR_NUMEROORDREPRIME = new SqlParameter("@GR_NUMEROORDREPRIME", SqlDbType.Int);
			vppParamGR_NUMEROORDREPRIME.Value  = clsCtpargarentieprime.GR_NUMEROORDREPRIME ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGARENTIEPRIME  @GR_CODEGARENTIEPRIME, @GR_LIBELLEGARENTIEPRIME, @GR_ACTIFPRIME, @GR_NUMEROORDREPRIME, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGR_CODEGARENTIEPRIME);
			vppSqlCmd.Parameters.Add(vppParamGR_LIBELLEGARENTIEPRIME);
			vppSqlCmd.Parameters.Add(vppParamGR_ACTIFPRIME);
			vppSqlCmd.Parameters.Add(vppParamGR_NUMEROORDREPRIME);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGARENTIEPRIME  @GR_CODEGARENTIEPRIME, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargarentieprime </returns>
		///<author>Home Technology</author>
		public List<clsCtpargarentieprime> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  GR_CODEGARENTIEPRIME, GR_LIBELLEGARENTIEPRIME, GR_ACTIFPRIME, GR_NUMEROORDREPRIME FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpargarentieprime> clsCtpargarentieprimes = new List<clsCtpargarentieprime>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpargarentieprime clsCtpargarentieprime = new clsCtpargarentieprime();
					clsCtpargarentieprime.GR_CODEGARENTIEPRIME = clsDonnee.vogDataReader["GR_CODEGARENTIEPRIME"].ToString();
					clsCtpargarentieprime.GR_LIBELLEGARENTIEPRIME = clsDonnee.vogDataReader["GR_LIBELLEGARENTIEPRIME"].ToString();
					clsCtpargarentieprime.GR_ACTIFPRIME = clsDonnee.vogDataReader["GR_ACTIFPRIME"].ToString();
					clsCtpargarentieprime.GR_NUMEROORDREPRIME = int.Parse(clsDonnee.vogDataReader["GR_NUMEROORDREPRIME"].ToString());
					clsCtpargarentieprimes.Add(clsCtpargarentieprime);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpargarentieprimes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargarentieprime </returns>
		///<author>Home Technology</author>
		public List<clsCtpargarentieprime> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpargarentieprime> clsCtpargarentieprimes = new List<clsCtpargarentieprime>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  GR_CODEGARENTIEPRIME, GR_LIBELLEGARENTIEPRIME, GR_ACTIFPRIME, GR_NUMEROORDREPRIME FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpargarentieprime clsCtpargarentieprime = new clsCtpargarentieprime();
					clsCtpargarentieprime.GR_CODEGARENTIEPRIME = Dataset.Tables["TABLE"].Rows[Idx]["GR_CODEGARENTIEPRIME"].ToString();
					clsCtpargarentieprime.GR_LIBELLEGARENTIEPRIME = Dataset.Tables["TABLE"].Rows[Idx]["GR_LIBELLEGARENTIEPRIME"].ToString();
					clsCtpargarentieprime.GR_ACTIFPRIME = Dataset.Tables["TABLE"].Rows[Idx]["GR_ACTIFPRIME"].ToString();
					clsCtpargarentieprime.GR_NUMEROORDREPRIME = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["GR_NUMEROORDREPRIME"].ToString());
					clsCtpargarentieprimes.Add(clsCtpargarentieprime);
				}
				Dataset.Dispose();
			}
		return clsCtpargarentieprimes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GR_CODEGARENTIEPRIME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT GR_CODEGARENTIEPRIME , GR_LIBELLEGARENTIEPRIME FROM dbo.FT_CTPARGARENTIEPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :GR_CODEGARENTIEPRIME)</summary>
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
				this.vapCritere ="WHERE GR_CODEGARENTIEPRIME=@GR_CODEGARENTIEPRIME";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@GR_CODEGARENTIEPRIME"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
