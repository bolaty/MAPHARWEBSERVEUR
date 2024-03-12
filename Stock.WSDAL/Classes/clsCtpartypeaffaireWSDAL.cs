using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartypeaffaireWSDAL: ITableDAL<clsCtpartypeaffaire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETYPEAFFAIRES) AS TA_CODETYPEAFFAIRES  FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETYPEAFFAIRES) AS TA_CODETYPEAFFAIRES  FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETYPEAFFAIRES) AS TA_CODETYPEAFFAIRES  FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartypeaffaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartypeaffaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_LIBLLETYPEAFFAIRES  , TA_NUMEROORDRE  FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartypeaffaire clsCtpartypeaffaire = new clsCtpartypeaffaire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypeaffaire.TA_LIBLLETYPEAFFAIRES = clsDonnee.vogDataReader["TA_LIBLLETYPEAFFAIRES"].ToString();
					clsCtpartypeaffaire.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartypeaffaire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypeaffaire>clsCtpartypeaffaire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartypeaffaire clsCtpartypeaffaire)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPEAFFAIRES = new SqlParameter("@TA_CODETYPEAFFAIRES", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPEAFFAIRES.Value  = clsCtpartypeaffaire.TA_CODETYPEAFFAIRES ;
			SqlParameter vppParamTA_LIBLLETYPEAFFAIRES = new SqlParameter("@TA_LIBLLETYPEAFFAIRES", SqlDbType.VarChar, 150);
			vppParamTA_LIBLLETYPEAFFAIRES.Value  = clsCtpartypeaffaire.TA_LIBLLETYPEAFFAIRES ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsCtpartypeaffaire.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEAFFAIRE  @TA_CODETYPEAFFAIRES, @TA_LIBLLETYPEAFFAIRES, @TA_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEAFFAIRES);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBLLETYPEAFFAIRES);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypeaffaire>clsCtpartypeaffaire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartypeaffaire clsCtpartypeaffaire,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPEAFFAIRES = new SqlParameter("@TA_CODETYPEAFFAIRES", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPEAFFAIRES.Value  = clsCtpartypeaffaire.TA_CODETYPEAFFAIRES ;
			SqlParameter vppParamTA_LIBLLETYPEAFFAIRES = new SqlParameter("@TA_LIBLLETYPEAFFAIRES", SqlDbType.VarChar, 150);
			vppParamTA_LIBLLETYPEAFFAIRES.Value  = clsCtpartypeaffaire.TA_LIBLLETYPEAFFAIRES ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsCtpartypeaffaire.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEAFFAIRE  @TA_CODETYPEAFFAIRES, @TA_LIBLLETYPEAFFAIRES, @TA_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEAFFAIRES);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBLLETYPEAFFAIRES);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEAFFAIRE  @TA_CODETYPEAFFAIRES, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypeaffaire </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypeaffaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEAFFAIRES, TA_LIBLLETYPEAFFAIRES, TA_NUMEROORDRE FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartypeaffaire> clsCtpartypeaffaires = new List<clsCtpartypeaffaire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypeaffaire clsCtpartypeaffaire = new clsCtpartypeaffaire();
					clsCtpartypeaffaire.TA_CODETYPEAFFAIRES = clsDonnee.vogDataReader["TA_CODETYPEAFFAIRES"].ToString();
					clsCtpartypeaffaire.TA_LIBLLETYPEAFFAIRES = clsDonnee.vogDataReader["TA_LIBLLETYPEAFFAIRES"].ToString();
					clsCtpartypeaffaire.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
					clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartypeaffaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypeaffaire </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypeaffaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartypeaffaire> clsCtpartypeaffaires = new List<clsCtpartypeaffaire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEAFFAIRES, TA_LIBLLETYPEAFFAIRES, TA_NUMEROORDRE FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartypeaffaire clsCtpartypeaffaire = new clsCtpartypeaffaire();
					clsCtpartypeaffaire.TA_CODETYPEAFFAIRES = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEAFFAIRES"].ToString();
					clsCtpartypeaffaire.TA_LIBLLETYPEAFFAIRES = Dataset.Tables["TABLE"].Rows[Idx]["TA_LIBLLETYPEAFFAIRES"].ToString();
					clsCtpartypeaffaire.TA_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TA_NUMEROORDRE"].ToString());
					clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
				}
				Dataset.Dispose();
			}
		return clsCtpartypeaffaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEAFFAIRES ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETYPEAFFAIRES , TA_LIBLLETYPEAFFAIRES FROM dbo.FT_CTPARTYPEAFFAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEAFFAIRES)</summary>
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
				this.vapCritere ="WHERE TA_CODETYPEAFFAIRES=@TA_CODETYPEAFFAIRES";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETYPEAFFAIRES"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
