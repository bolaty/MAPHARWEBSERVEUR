using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsTypeamortissementWSDAL: ITableDAL<clsTypeamortissement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TI_CODETYPEAMORTISSEMENT) AS TI_CODETYPEAMORTISSEMENT  FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TI_CODETYPEAMORTISSEMENT) AS TI_CODETYPEAMORTISSEMENT  FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TI_CODETYPEAMORTISSEMENT) AS TI_CODETYPEAMORTISSEMENT  FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTypeamortissement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTypeamortissement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_LIBELLE  , TI_ACTIF  , TI_AMORTISSEMENTCREDIT  , TI_NUMEROORDRE  , TI_AMORTISSEMENTIMMOBILISATION  FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsTypeamortissement clsTypeamortissement = new clsTypeamortissement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTypeamortissement.TI_LIBELLE = clsDonnee.vogDataReader["TI_LIBELLE"].ToString();
					clsTypeamortissement.TI_ACTIF = clsDonnee.vogDataReader["TI_ACTIF"].ToString();
					clsTypeamortissement.TI_AMORTISSEMENTCREDIT = clsDonnee.vogDataReader["TI_AMORTISSEMENTCREDIT"].ToString();
					clsTypeamortissement.TI_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TI_NUMEROORDRE"].ToString());
					clsTypeamortissement.TI_AMORTISSEMENTIMMOBILISATION = clsDonnee.vogDataReader["TI_AMORTISSEMENTIMMOBILISATION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsTypeamortissement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTypeamortissement>clsTypeamortissement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsTypeamortissement clsTypeamortissement)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_CODETYPEAMORTISSEMENT = new SqlParameter("@TI_CODETYPEAMORTISSEMENT", SqlDbType.VarChar, 2);
			vppParamTI_CODETYPEAMORTISSEMENT.Value  = clsTypeamortissement.TI_CODETYPEAMORTISSEMENT ;
			SqlParameter vppParamTI_LIBELLE = new SqlParameter("@TI_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTI_LIBELLE.Value  = clsTypeamortissement.TI_LIBELLE ;
			SqlParameter vppParamTI_ACTIF = new SqlParameter("@TI_ACTIF", SqlDbType.VarChar, 1);
			vppParamTI_ACTIF.Value  = clsTypeamortissement.TI_ACTIF ;
			SqlParameter vppParamTI_AMORTISSEMENTCREDIT = new SqlParameter("@TI_AMORTISSEMENTCREDIT", SqlDbType.VarChar, 1);
			vppParamTI_AMORTISSEMENTCREDIT.Value  = clsTypeamortissement.TI_AMORTISSEMENTCREDIT ;
			SqlParameter vppParamTI_NUMEROORDRE = new SqlParameter("@TI_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamTI_NUMEROORDRE.Value  = clsTypeamortissement.TI_NUMEROORDRE ;
			SqlParameter vppParamTI_AMORTISSEMENTIMMOBILISATION = new SqlParameter("@TI_AMORTISSEMENTIMMOBILISATION", SqlDbType.VarChar, 1);
			vppParamTI_AMORTISSEMENTIMMOBILISATION.Value  = clsTypeamortissement.TI_AMORTISSEMENTIMMOBILISATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TYPEAMORTISSEMENT  @TI_CODETYPEAMORTISSEMENT, @TI_LIBELLE, @TI_ACTIF, @TI_AMORTISSEMENTCREDIT, @TI_NUMEROORDRE, @TI_AMORTISSEMENTIMMOBILISATION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_CODETYPEAMORTISSEMENT);
			vppSqlCmd.Parameters.Add(vppParamTI_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTI_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTI_AMORTISSEMENTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamTI_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamTI_AMORTISSEMENTIMMOBILISATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTypeamortissement>clsTypeamortissement</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsTypeamortissement clsTypeamortissement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_CODETYPEAMORTISSEMENT = new SqlParameter("@TI_CODETYPEAMORTISSEMENT", SqlDbType.VarChar, 2);
			vppParamTI_CODETYPEAMORTISSEMENT.Value  = clsTypeamortissement.TI_CODETYPEAMORTISSEMENT ;
			SqlParameter vppParamTI_LIBELLE = new SqlParameter("@TI_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTI_LIBELLE.Value  = clsTypeamortissement.TI_LIBELLE ;
			SqlParameter vppParamTI_ACTIF = new SqlParameter("@TI_ACTIF", SqlDbType.VarChar, 1);
			vppParamTI_ACTIF.Value  = clsTypeamortissement.TI_ACTIF ;
			SqlParameter vppParamTI_AMORTISSEMENTCREDIT = new SqlParameter("@TI_AMORTISSEMENTCREDIT", SqlDbType.VarChar, 1);
			vppParamTI_AMORTISSEMENTCREDIT.Value  = clsTypeamortissement.TI_AMORTISSEMENTCREDIT ;
			SqlParameter vppParamTI_NUMEROORDRE = new SqlParameter("@TI_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamTI_NUMEROORDRE.Value  = clsTypeamortissement.TI_NUMEROORDRE ;
			SqlParameter vppParamTI_AMORTISSEMENTIMMOBILISATION = new SqlParameter("@TI_AMORTISSEMENTIMMOBILISATION", SqlDbType.VarChar, 1);
			vppParamTI_AMORTISSEMENTIMMOBILISATION.Value  = clsTypeamortissement.TI_AMORTISSEMENTIMMOBILISATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TYPEAMORTISSEMENT  @TI_CODETYPEAMORTISSEMENT, @TI_LIBELLE, @TI_ACTIF, @TI_AMORTISSEMENTCREDIT, @TI_NUMEROORDRE, @TI_AMORTISSEMENTIMMOBILISATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_CODETYPEAMORTISSEMENT);
			vppSqlCmd.Parameters.Add(vppParamTI_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTI_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTI_AMORTISSEMENTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamTI_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamTI_AMORTISSEMENTIMMOBILISATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TYPEAMORTISSEMENT  @TI_CODETYPEAMORTISSEMENT, '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTypeamortissement </returns>
		///<author>Home Technology</author>
		public List<clsTypeamortissement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_CODETYPEAMORTISSEMENT, TI_LIBELLE, TI_ACTIF, TI_AMORTISSEMENTCREDIT, TI_NUMEROORDRE, TI_AMORTISSEMENTIMMOBILISATION FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsTypeamortissement> clsTypeamortissements = new List<clsTypeamortissement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTypeamortissement clsTypeamortissement = new clsTypeamortissement();
					clsTypeamortissement.TI_CODETYPEAMORTISSEMENT = clsDonnee.vogDataReader["TI_CODETYPEAMORTISSEMENT"].ToString();
					clsTypeamortissement.TI_LIBELLE = clsDonnee.vogDataReader["TI_LIBELLE"].ToString();
					clsTypeamortissement.TI_ACTIF = clsDonnee.vogDataReader["TI_ACTIF"].ToString();
					clsTypeamortissement.TI_AMORTISSEMENTCREDIT = clsDonnee.vogDataReader["TI_AMORTISSEMENTCREDIT"].ToString();
					clsTypeamortissement.TI_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TI_NUMEROORDRE"].ToString());
					clsTypeamortissement.TI_AMORTISSEMENTIMMOBILISATION = clsDonnee.vogDataReader["TI_AMORTISSEMENTIMMOBILISATION"].ToString();
					clsTypeamortissements.Add(clsTypeamortissement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsTypeamortissements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTypeamortissement </returns>
		///<author>Home Technology</author>
		public List<clsTypeamortissement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsTypeamortissement> clsTypeamortissements = new List<clsTypeamortissement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_CODETYPEAMORTISSEMENT, TI_LIBELLE, TI_ACTIF, TI_AMORTISSEMENTCREDIT, TI_NUMEROORDRE, TI_AMORTISSEMENTIMMOBILISATION FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsTypeamortissement clsTypeamortissement = new clsTypeamortissement();
					clsTypeamortissement.TI_CODETYPEAMORTISSEMENT = Dataset.Tables["TABLE"].Rows[Idx]["TI_CODETYPEAMORTISSEMENT"].ToString();
					clsTypeamortissement.TI_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TI_LIBELLE"].ToString();
					clsTypeamortissement.TI_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TI_ACTIF"].ToString();
					clsTypeamortissement.TI_AMORTISSEMENTCREDIT = Dataset.Tables["TABLE"].Rows[Idx]["TI_AMORTISSEMENTCREDIT"].ToString();
					clsTypeamortissement.TI_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_NUMEROORDRE"].ToString());
					clsTypeamortissement.TI_AMORTISSEMENTIMMOBILISATION = Dataset.Tables["TABLE"].Rows[Idx]["TI_AMORTISSEMENTIMMOBILISATION"].ToString();
					clsTypeamortissements.Add(clsTypeamortissement);
				}
				Dataset.Dispose();
			}
		return clsTypeamortissements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TI_CODETYPEAMORTISSEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_CODETYPEAMORTISSEMENT , TI_LIBELLE FROM dbo.FT_TYPEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TI_CODETYPEAMORTISSEMENT)</summary>
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
				this.vapCritere ="WHERE TI_CODETYPEAMORTISSEMENT=@TI_CODETYPEAMORTISSEMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TI_CODETYPEAMORTISSEMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
