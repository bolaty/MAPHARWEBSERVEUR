using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypequantiteWSDAL: ITableDAL<clsPhapartypequantite>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TQ_CODETYPEQUANTITE) AS TQ_CODETYPEQUANTITE  FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TQ_CODETYPEQUANTITE) AS TQ_CODETYPEQUANTITE  FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TQ_CODETYPEQUANTITE) AS TQ_CODETYPEQUANTITE  FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypequantite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypequantite pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TQ_LIBELLE  , TQ_DESCRIPTION  FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypequantite clsPhapartypequantite = new clsPhapartypequantite();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypequantite.TQ_LIBELLE = clsDonnee.vogDataReader["TQ_LIBELLE"].ToString();
					clsPhapartypequantite.TQ_DESCRIPTION = clsDonnee.vogDataReader["TQ_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypequantite;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypequantite>clsPhapartypequantite</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypequantite clsPhapartypequantite)
		{
			//Préparation des paramètres
			SqlParameter vppParamTQ_CODETYPEQUANTITE = new SqlParameter("@TQ_CODETYPEQUANTITE", SqlDbType.VarChar, 2);
			vppParamTQ_CODETYPEQUANTITE.Value  = clsPhapartypequantite.TQ_CODETYPEQUANTITE ;
			SqlParameter vppParamTQ_LIBELLE = new SqlParameter("@TQ_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTQ_LIBELLE.Value  = clsPhapartypequantite.TQ_LIBELLE ;
			SqlParameter vppParamTQ_DESCRIPTION = new SqlParameter("@TQ_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTQ_DESCRIPTION.Value  = clsPhapartypequantite.TQ_DESCRIPTION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITE  @TQ_CODETYPEQUANTITE, @TQ_LIBELLE, @TQ_DESCRIPTION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTQ_CODETYPEQUANTITE);
			vppSqlCmd.Parameters.Add(vppParamTQ_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTQ_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypequantite>clsPhapartypequantite</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypequantite clsPhapartypequantite,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTQ_CODETYPEQUANTITE = new SqlParameter("@TQ_CODETYPEQUANTITE", SqlDbType.VarChar, 2);
			vppParamTQ_CODETYPEQUANTITE.Value  = clsPhapartypequantite.TQ_CODETYPEQUANTITE ;
			SqlParameter vppParamTQ_LIBELLE = new SqlParameter("@TQ_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTQ_LIBELLE.Value  = clsPhapartypequantite.TQ_LIBELLE ;
			SqlParameter vppParamTQ_DESCRIPTION = new SqlParameter("@TQ_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTQ_DESCRIPTION.Value  = clsPhapartypequantite.TQ_DESCRIPTION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITE  @TQ_CODETYPEQUANTITE, @TQ_LIBELLE, @TQ_DESCRIPTION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTQ_CODETYPEQUANTITE);
			vppSqlCmd.Parameters.Add(vppParamTQ_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTQ_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITE  @TQ_CODETYPEQUANTITE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypequantite </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypequantite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TQ_CODETYPEQUANTITE, TQ_LIBELLE, TQ_DESCRIPTION FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypequantite> clsPhapartypequantites = new List<clsPhapartypequantite>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypequantite clsPhapartypequantite = new clsPhapartypequantite();
					clsPhapartypequantite.TQ_CODETYPEQUANTITE = clsDonnee.vogDataReader["TQ_CODETYPEQUANTITE"].ToString();
					clsPhapartypequantite.TQ_LIBELLE = clsDonnee.vogDataReader["TQ_LIBELLE"].ToString();
					clsPhapartypequantite.TQ_DESCRIPTION = clsDonnee.vogDataReader["TQ_DESCRIPTION"].ToString();
					clsPhapartypequantites.Add(clsPhapartypequantite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypequantites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypequantite </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypequantite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypequantite> clsPhapartypequantites = new List<clsPhapartypequantite>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TQ_CODETYPEQUANTITE, TQ_LIBELLE, TQ_DESCRIPTION FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypequantite clsPhapartypequantite = new clsPhapartypequantite();
					clsPhapartypequantite.TQ_CODETYPEQUANTITE = Dataset.Tables["TABLE"].Rows[Idx]["TQ_CODETYPEQUANTITE"].ToString();
					clsPhapartypequantite.TQ_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TQ_LIBELLE"].ToString();
					clsPhapartypequantite.TQ_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["TQ_DESCRIPTION"].ToString();
					clsPhapartypequantites.Add(clsPhapartypequantite);
				}
				Dataset.Dispose();
			}
		return clsPhapartypequantites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPEQUANTITE(@AR_CODEARTICLE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TQ_CODETYPEQUANTITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TQ_CODETYPEQUANTITE , TQ_LIBELLE FROM dbo.FT_PHAPARTYPEQUANTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TQ_CODETYPEQUANTITE)</summary>
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
                //this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
