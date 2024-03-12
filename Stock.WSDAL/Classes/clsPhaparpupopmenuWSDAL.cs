using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenuWSDAL: ITableDAL<clsPhaparpupopmenu>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PP_CODEPUPOPMENU) AS PP_CODEPUPOPMENU  FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PP_CODEPUPOPMENU) AS PP_CODEPUPOPMENU  FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PP_CODEPUPOPMENU) AS PP_CODEPUPOPMENU  FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenu comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenu pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EC_CODECRAN  , PP_NOMPUPOPMENU  , PP_LIBELLE  FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenu clsPhaparpupopmenu = new clsPhaparpupopmenu();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenu.EC_CODECRAN = clsDonnee.vogDataReader["EC_CODECRAN"].ToString();
					clsPhaparpupopmenu.PP_NOMPUPOPMENU = clsDonnee.vogDataReader["PP_NOMPUPOPMENU"].ToString();
					clsPhaparpupopmenu.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenu;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenu>clsPhaparpupopmenu</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenu clsPhaparpupopmenu)
		{
			//Préparation des paramètres
			SqlParameter vppParamPP_CODEPUPOPMENU = new SqlParameter("@PP_CODEPUPOPMENU", SqlDbType.VarChar, 25);
			vppParamPP_CODEPUPOPMENU.Value  = clsPhaparpupopmenu.PP_CODEPUPOPMENU ;
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparpupopmenu.EC_CODECRAN ;
			SqlParameter vppParamPP_NOMPUPOPMENU = new SqlParameter("@PP_NOMPUPOPMENU", SqlDbType.VarChar, 150);
			vppParamPP_NOMPUPOPMENU.Value  = clsPhaparpupopmenu.PP_NOMPUPOPMENU ;
			SqlParameter vppParamPP_LIBELLE = new SqlParameter("@PP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPP_LIBELLE.Value  = clsPhaparpupopmenu.PP_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENU  @PP_CODEPUPOPMENU, @EC_CODECRAN, @PP_NOMPUPOPMENU, @PP_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPUPOPMENU);
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamPP_NOMPUPOPMENU);
			vppSqlCmd.Parameters.Add(vppParamPP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenu>clsPhaparpupopmenu</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenu clsPhaparpupopmenu,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPP_CODEPUPOPMENU = new SqlParameter("@PP_CODEPUPOPMENU", SqlDbType.VarChar, 25);
			vppParamPP_CODEPUPOPMENU.Value  = clsPhaparpupopmenu.PP_CODEPUPOPMENU ;
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparpupopmenu.EC_CODECRAN ;
			SqlParameter vppParamPP_NOMPUPOPMENU = new SqlParameter("@PP_NOMPUPOPMENU", SqlDbType.VarChar, 150);
			vppParamPP_NOMPUPOPMENU.Value  = clsPhaparpupopmenu.PP_NOMPUPOPMENU ;
			SqlParameter vppParamPP_LIBELLE = new SqlParameter("@PP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPP_LIBELLE.Value  = clsPhaparpupopmenu.PP_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENU  @PP_CODEPUPOPMENU, @EC_CODECRAN, @PP_NOMPUPOPMENU, @PP_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPUPOPMENU);
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamPP_NOMPUPOPMENU);
			vppSqlCmd.Parameters.Add(vppParamPP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENU  @PP_CODEPUPOPMENU, @EC_CODECRAN, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenu </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenu> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PP_CODEPUPOPMENU, EC_CODECRAN, PP_NOMPUPOPMENU, PP_LIBELLE FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenu> clsPhaparpupopmenus = new List<clsPhaparpupopmenu>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenu clsPhaparpupopmenu = new clsPhaparpupopmenu();
					clsPhaparpupopmenu.PP_CODEPUPOPMENU = clsDonnee.vogDataReader["PP_CODEPUPOPMENU"].ToString();
					clsPhaparpupopmenu.EC_CODECRAN = clsDonnee.vogDataReader["EC_CODECRAN"].ToString();
					clsPhaparpupopmenu.PP_NOMPUPOPMENU = clsDonnee.vogDataReader["PP_NOMPUPOPMENU"].ToString();
					clsPhaparpupopmenu.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
					clsPhaparpupopmenus.Add(clsPhaparpupopmenu);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenus;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenu </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenu> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenu> clsPhaparpupopmenus = new List<clsPhaparpupopmenu>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PP_CODEPUPOPMENU, EC_CODECRAN, PP_NOMPUPOPMENU, PP_LIBELLE FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenu clsPhaparpupopmenu = new clsPhaparpupopmenu();
					clsPhaparpupopmenu.PP_CODEPUPOPMENU = Dataset.Tables["TABLE"].Rows[Idx]["PP_CODEPUPOPMENU"].ToString();
					clsPhaparpupopmenu.EC_CODECRAN = Dataset.Tables["TABLE"].Rows[Idx]["EC_CODECRAN"].ToString();
					clsPhaparpupopmenu.PP_NOMPUPOPMENU = Dataset.Tables["TABLE"].Rows[Idx]["PP_NOMPUPOPMENU"].ToString();
					clsPhaparpupopmenu.PP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PP_LIBELLE"].ToString();
					clsPhaparpupopmenus.Add(clsPhaparpupopmenu);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenus;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PP_CODEPUPOPMENU, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PP_CODEPUPOPMENU , PP_NOMPUPOPMENU FROM dbo.FT_PHAPARPUPOPMENU(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PP_CODEPUPOPMENU, EC_CODECRAN)</summary>
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
				this.vapCritere ="WHERE PP_CODEPUPOPMENU=@PP_CODEPUPOPMENU";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PP_CODEPUPOPMENU"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PP_CODEPUPOPMENU=@PP_CODEPUPOPMENU AND EC_CODECRAN=@EC_CODECRAN";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PP_CODEPUPOPMENU","@EC_CODECRAN"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
