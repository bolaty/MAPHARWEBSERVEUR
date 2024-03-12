using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsClipartypeconsultattionWSDAL: ITableDAL<clsClipartypeconsultattion>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TY_CODETYPECONSULTATION) AS TY_CODETYPECONSULTATION  FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TY_CODETYPECONSULTATION) AS TY_CODETYPECONSULTATION  FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TY_CODETYPECONSULTATION) AS TY_CODETYPECONSULTATION  FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClipartypeconsultattion comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClipartypeconsultattion pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TY_LIBELLETYPECONSULTATION  FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsClipartypeconsultattion clsClipartypeconsultattion = new clsClipartypeconsultattion();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = clsDonnee.vogDataReader["TY_LIBELLETYPECONSULTATION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsClipartypeconsultattion;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartypeconsultattion>clsClipartypeconsultattion</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsClipartypeconsultattion clsClipartypeconsultattion)
		{
			//Préparation des paramètres
			SqlParameter vppParamTY_CODETYPECONSULTATION = new SqlParameter("@TY_CODETYPECONSULTATION", SqlDbType.VarChar, 2);
			vppParamTY_CODETYPECONSULTATION.Value  = clsClipartypeconsultattion.TY_CODETYPECONSULTATION ;
			SqlParameter vppParamTY_LIBELLETYPECONSULTATION = new SqlParameter("@TY_LIBELLETYPECONSULTATION", SqlDbType.VarChar, 150);
			vppParamTY_LIBELLETYPECONSULTATION.Value  = clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPECONSULTATTION  @TY_CODETYPECONSULTATION, @TY_LIBELLETYPECONSULTATION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTY_CODETYPECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamTY_LIBELLETYPECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartypeconsultattion>clsClipartypeconsultattion</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsClipartypeconsultattion clsClipartypeconsultattion,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTY_CODETYPECONSULTATION = new SqlParameter("@TY_CODETYPECONSULTATION", SqlDbType.VarChar, 2);
			vppParamTY_CODETYPECONSULTATION.Value  = clsClipartypeconsultattion.TY_CODETYPECONSULTATION ;
			SqlParameter vppParamTY_LIBELLETYPECONSULTATION = new SqlParameter("@TY_LIBELLETYPECONSULTATION", SqlDbType.VarChar, 150);
			vppParamTY_LIBELLETYPECONSULTATION.Value  = clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPECONSULTATTION  @TY_CODETYPECONSULTATION, @TY_LIBELLETYPECONSULTATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTY_CODETYPECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamTY_LIBELLETYPECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPECONSULTATTION  @TY_CODETYPECONSULTATION, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartypeconsultattion </returns>
		///<author>Home Technology</author>
		public List<clsClipartypeconsultattion> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TY_CODETYPECONSULTATION, TY_LIBELLETYPECONSULTATION FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsClipartypeconsultattion> clsClipartypeconsultattions = new List<clsClipartypeconsultattion>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartypeconsultattion clsClipartypeconsultattion = new clsClipartypeconsultattion();
					clsClipartypeconsultattion.TY_CODETYPECONSULTATION = clsDonnee.vogDataReader["TY_CODETYPECONSULTATION"].ToString();
					clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = clsDonnee.vogDataReader["TY_LIBELLETYPECONSULTATION"].ToString();
					clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsClipartypeconsultattions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartypeconsultattion </returns>
		///<author>Home Technology</author>
		public List<clsClipartypeconsultattion> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsClipartypeconsultattion> clsClipartypeconsultattions = new List<clsClipartypeconsultattion>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TY_CODETYPECONSULTATION, TY_LIBELLETYPECONSULTATION FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsClipartypeconsultattion clsClipartypeconsultattion = new clsClipartypeconsultattion();
					clsClipartypeconsultattion.TY_CODETYPECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["TY_CODETYPECONSULTATION"].ToString();
					clsClipartypeconsultattion.TY_LIBELLETYPECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["TY_LIBELLETYPECONSULTATION"].ToString();
					clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
				}
				Dataset.Dispose();
			}
		return clsClipartypeconsultattions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TY_CODETYPECONSULTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TY_CODETYPECONSULTATION , TY_LIBELLETYPECONSULTATION FROM dbo.FT_CLIPARTYPECONSULTATTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TY_CODETYPECONSULTATION)</summary>
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
				this.vapCritere ="WHERE TY_CODETYPECONSULTATION=@TY_CODETYPECONSULTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TY_CODETYPECONSULTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
