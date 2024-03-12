using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsClipartypeantecedantWSDAL: ITableDAL<clsClipartypeantecedant>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETYPEANTECEDANT) AS TA_CODETYPEANTECEDANT  FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETYPEANTECEDANT) AS TA_CODETYPEANTECEDANT  FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETYPEANTECEDANT) AS TA_CODETYPEANTECEDANT  FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClipartypeantecedant comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClipartypeantecedant pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_LIBELLEANTECEDANT  FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsClipartypeantecedant clsClipartypeantecedant = new clsClipartypeantecedant();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartypeantecedant.TA_LIBELLEANTECEDANT = clsDonnee.vogDataReader["TA_LIBELLEANTECEDANT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsClipartypeantecedant;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartypeantecedant>clsClipartypeantecedant</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsClipartypeantecedant clsClipartypeantecedant)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPEANTECEDANT = new SqlParameter("@TA_CODETYPEANTECEDANT", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPEANTECEDANT.Value  = clsClipartypeantecedant.TA_CODETYPEANTECEDANT ;
			SqlParameter vppParamTA_LIBELLEANTECEDANT = new SqlParameter("@TA_LIBELLEANTECEDANT", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLEANTECEDANT.Value  = clsClipartypeantecedant.TA_LIBELLEANTECEDANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPEANTECEDANT  @TA_CODETYPEANTECEDANT, @TA_LIBELLEANTECEDANT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartypeantecedant>clsClipartypeantecedant</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsClipartypeantecedant clsClipartypeantecedant,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPEANTECEDANT = new SqlParameter("@TA_CODETYPEANTECEDANT", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPEANTECEDANT.Value  = clsClipartypeantecedant.TA_CODETYPEANTECEDANT ;
			SqlParameter vppParamTA_LIBELLEANTECEDANT = new SqlParameter("@TA_LIBELLEANTECEDANT", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLEANTECEDANT.Value  = clsClipartypeantecedant.TA_LIBELLEANTECEDANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPEANTECEDANT  @TA_CODETYPEANTECEDANT, @TA_LIBELLEANTECEDANT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPEANTECEDANT  @TA_CODETYPEANTECEDANT, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartypeantecedant </returns>
		///<author>Home Technology</author>
		public List<clsClipartypeantecedant> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEANTECEDANT, TA_LIBELLEANTECEDANT FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsClipartypeantecedant> clsClipartypeantecedants = new List<clsClipartypeantecedant>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartypeantecedant clsClipartypeantecedant = new clsClipartypeantecedant();
					clsClipartypeantecedant.TA_CODETYPEANTECEDANT = clsDonnee.vogDataReader["TA_CODETYPEANTECEDANT"].ToString();
					clsClipartypeantecedant.TA_LIBELLEANTECEDANT = clsDonnee.vogDataReader["TA_LIBELLEANTECEDANT"].ToString();
					clsClipartypeantecedants.Add(clsClipartypeantecedant);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsClipartypeantecedants;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartypeantecedant </returns>
		///<author>Home Technology</author>
		public List<clsClipartypeantecedant> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsClipartypeantecedant> clsClipartypeantecedants = new List<clsClipartypeantecedant>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEANTECEDANT, TA_LIBELLEANTECEDANT FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsClipartypeantecedant clsClipartypeantecedant = new clsClipartypeantecedant();
					clsClipartypeantecedant.TA_CODETYPEANTECEDANT = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEANTECEDANT"].ToString();
					clsClipartypeantecedant.TA_LIBELLEANTECEDANT = Dataset.Tables["TABLE"].Rows[Idx]["TA_LIBELLEANTECEDANT"].ToString();
					clsClipartypeantecedants.Add(clsClipartypeantecedant);
				}
				Dataset.Dispose();
			}
		return clsClipartypeantecedants;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEANTECEDANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETYPEANTECEDANT , TA_LIBELLEANTECEDANT FROM dbo.FT_CLIPARTYPEANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEANTECEDANT)</summary>
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
				this.vapCritere ="WHERE TA_CODETYPEANTECEDANT=@TA_CODETYPEANTECEDANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETYPEANTECEDANT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
