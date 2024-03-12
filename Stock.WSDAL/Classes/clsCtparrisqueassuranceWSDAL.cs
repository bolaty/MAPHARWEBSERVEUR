using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparrisqueassuranceWSDAL: ITableDAL<clsCtparrisqueassurance>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RQ_CODERISQUE) AS RQ_CODERISQUE  FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RQ_CODERISQUE) AS RQ_CODERISQUE  FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RQ_CODERISQUE) AS RQ_CODERISQUE  FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparrisqueassurance comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparrisqueassurance pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RQ_LIBELLERISQUE  , RQ_ACTIF  , RQ_NUMEROORDRE  FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparrisqueassurance clsCtparrisqueassurance = new clsCtparrisqueassurance();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparrisqueassurance.RQ_LIBELLERISQUE = clsDonnee.vogDataReader["RQ_LIBELLERISQUE"].ToString();
					clsCtparrisqueassurance.RQ_ACTIF = clsDonnee.vogDataReader["RQ_ACTIF"].ToString();
					clsCtparrisqueassurance.RQ_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RQ_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparrisqueassurance;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparrisqueassurance>clsCtparrisqueassurance</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparrisqueassurance clsCtparrisqueassurance)
		{
			//Préparation des paramètres
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparrisqueassurance.RQ_CODERISQUE ;
			SqlParameter vppParamRQ_LIBELLERISQUE = new SqlParameter("@RQ_LIBELLERISQUE", SqlDbType.VarChar, 150);
			vppParamRQ_LIBELLERISQUE.Value  = clsCtparrisqueassurance.RQ_LIBELLERISQUE ;
			SqlParameter vppParamRQ_ACTIF = new SqlParameter("@RQ_ACTIF", SqlDbType.VarChar, 1);
			vppParamRQ_ACTIF.Value  = clsCtparrisqueassurance.RQ_ACTIF ;
			SqlParameter vppParamRQ_NUMEROORDRE = new SqlParameter("@RQ_NUMEROORDRE", SqlDbType.Int);
			vppParamRQ_NUMEROORDRE.Value  = clsCtparrisqueassurance.RQ_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARRISQUEASSURANCE  @RQ_CODERISQUE, @RQ_LIBELLERISQUE, @RQ_ACTIF, @RQ_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamRQ_LIBELLERISQUE);
			vppSqlCmd.Parameters.Add(vppParamRQ_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamRQ_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparrisqueassurance>clsCtparrisqueassurance</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparrisqueassurance clsCtparrisqueassurance,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparrisqueassurance.RQ_CODERISQUE ;
			SqlParameter vppParamRQ_LIBELLERISQUE = new SqlParameter("@RQ_LIBELLERISQUE", SqlDbType.VarChar, 150);
			vppParamRQ_LIBELLERISQUE.Value  = clsCtparrisqueassurance.RQ_LIBELLERISQUE ;
			SqlParameter vppParamRQ_ACTIF = new SqlParameter("@RQ_ACTIF", SqlDbType.VarChar, 1);
			vppParamRQ_ACTIF.Value  = clsCtparrisqueassurance.RQ_ACTIF ;
			SqlParameter vppParamRQ_NUMEROORDRE = new SqlParameter("@RQ_NUMEROORDRE", SqlDbType.Int);
			vppParamRQ_NUMEROORDRE.Value  = clsCtparrisqueassurance.RQ_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARRISQUEASSURANCE  @RQ_CODERISQUE, @RQ_LIBELLERISQUE, @RQ_ACTIF, @RQ_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamRQ_LIBELLERISQUE);
			vppSqlCmd.Parameters.Add(vppParamRQ_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamRQ_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARRISQUEASSURANCE  @RQ_CODERISQUE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparrisqueassurance </returns>
		///<author>Home Technology</author>
		public List<clsCtparrisqueassurance> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RQ_CODERISQUE, RQ_LIBELLERISQUE, RQ_ACTIF, RQ_NUMEROORDRE FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparrisqueassurance> clsCtparrisqueassurances = new List<clsCtparrisqueassurance>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparrisqueassurance clsCtparrisqueassurance = new clsCtparrisqueassurance();
					clsCtparrisqueassurance.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtparrisqueassurance.RQ_LIBELLERISQUE = clsDonnee.vogDataReader["RQ_LIBELLERISQUE"].ToString();
					clsCtparrisqueassurance.RQ_ACTIF = clsDonnee.vogDataReader["RQ_ACTIF"].ToString();
					clsCtparrisqueassurance.RQ_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RQ_NUMEROORDRE"].ToString());
					clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparrisqueassurances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparrisqueassurance </returns>
		///<author>Home Technology</author>
		public List<clsCtparrisqueassurance> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparrisqueassurance> clsCtparrisqueassurances = new List<clsCtparrisqueassurance>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RQ_CODERISQUE, RQ_LIBELLERISQUE, RQ_ACTIF, RQ_NUMEROORDRE FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparrisqueassurance clsCtparrisqueassurance = new clsCtparrisqueassurance();
					clsCtparrisqueassurance.RQ_CODERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODERISQUE"].ToString();
					clsCtparrisqueassurance.RQ_LIBELLERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_LIBELLERISQUE"].ToString();
					clsCtparrisqueassurance.RQ_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["RQ_ACTIF"].ToString();
					clsCtparrisqueassurance.RQ_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_NUMEROORDRE"].ToString());
					clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
				}
				Dataset.Dispose();
			}
		return clsCtparrisqueassurances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RQ_CODERISQUE , RQ_LIBELLERISQUE FROM dbo.FT_CTPARRISQUEASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODERISQUE)</summary>
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
				this.vapCritere ="WHERE RQ_CODERISQUE=@RQ_CODERISQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODERISQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
