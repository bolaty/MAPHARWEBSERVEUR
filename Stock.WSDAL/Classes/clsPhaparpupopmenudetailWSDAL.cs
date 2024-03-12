using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenudetailWSDAL: ITableDAL<clsPhaparpupopmenudetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DP_CODEDETAIL) AS DP_CODEDETAIL  FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DP_CODEDETAIL) AS DP_CODEDETAIL  FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DP_CODEDETAIL) AS DP_CODEDETAIL  FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenudetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenudetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PP_CODEPUPOPMENU  , DP_NOMMENU  , DP_LIBELLE  , DP_AFFICHER  FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenudetail clsPhaparpupopmenudetail = new clsPhaparpupopmenudetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenudetail.PP_CODEPUPOPMENU = clsDonnee.vogDataReader["PP_CODEPUPOPMENU"].ToString();
					clsPhaparpupopmenudetail.DP_NOMMENU = clsDonnee.vogDataReader["DP_NOMMENU"].ToString();
					clsPhaparpupopmenudetail.DP_LIBELLE = clsDonnee.vogDataReader["DP_LIBELLE"].ToString();
					clsPhaparpupopmenudetail.DP_AFFICHER = clsDonnee.vogDataReader["DP_AFFICHER"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenudetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenudetail>clsPhaparpupopmenudetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenudetail clsPhaparpupopmenudetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamDP_CODEDETAIL = new SqlParameter("@DP_CODEDETAIL", SqlDbType.VarChar, 25);
			vppParamDP_CODEDETAIL.Value  = clsPhaparpupopmenudetail.DP_CODEDETAIL ;
			SqlParameter vppParamPP_CODEPUPOPMENU = new SqlParameter("@PP_CODEPUPOPMENU", SqlDbType.VarChar, 25);
			vppParamPP_CODEPUPOPMENU.Value  = clsPhaparpupopmenudetail.PP_CODEPUPOPMENU ;
			SqlParameter vppParamDP_NOMMENU = new SqlParameter("@DP_NOMMENU", SqlDbType.VarChar, 150);
			vppParamDP_NOMMENU.Value  = clsPhaparpupopmenudetail.DP_NOMMENU ;
			SqlParameter vppParamDP_LIBELLE = new SqlParameter("@DP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamDP_LIBELLE.Value  = clsPhaparpupopmenudetail.DP_LIBELLE ;
			SqlParameter vppParamDP_AFFICHER = new SqlParameter("@DP_AFFICHER", SqlDbType.VarChar, 1);
			vppParamDP_AFFICHER.Value  = clsPhaparpupopmenudetail.DP_AFFICHER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUDETAIL  @DP_CODEDETAIL, @PP_CODEPUPOPMENU, @DP_NOMMENU, @DP_LIBELLE, @DP_AFFICHER, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDP_CODEDETAIL);
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPUPOPMENU);
			vppSqlCmd.Parameters.Add(vppParamDP_NOMMENU);
			vppSqlCmd.Parameters.Add(vppParamDP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamDP_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenudetail>clsPhaparpupopmenudetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenudetail clsPhaparpupopmenudetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDP_CODEDETAIL = new SqlParameter("@DP_CODEDETAIL", SqlDbType.VarChar, 25);
			vppParamDP_CODEDETAIL.Value  = clsPhaparpupopmenudetail.DP_CODEDETAIL ;
			SqlParameter vppParamPP_CODEPUPOPMENU = new SqlParameter("@PP_CODEPUPOPMENU", SqlDbType.VarChar, 25);
			vppParamPP_CODEPUPOPMENU.Value  = clsPhaparpupopmenudetail.PP_CODEPUPOPMENU ;
			SqlParameter vppParamDP_NOMMENU = new SqlParameter("@DP_NOMMENU", SqlDbType.VarChar, 150);
			vppParamDP_NOMMENU.Value  = clsPhaparpupopmenudetail.DP_NOMMENU ;
			SqlParameter vppParamDP_LIBELLE = new SqlParameter("@DP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamDP_LIBELLE.Value  = clsPhaparpupopmenudetail.DP_LIBELLE ;
			SqlParameter vppParamDP_AFFICHER = new SqlParameter("@DP_AFFICHER", SqlDbType.VarChar, 1);
			vppParamDP_AFFICHER.Value  = clsPhaparpupopmenudetail.DP_AFFICHER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUDETAIL  @DP_CODEDETAIL, @PP_CODEPUPOPMENU, @DP_NOMMENU, @DP_LIBELLE, @DP_AFFICHER, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDP_CODEDETAIL);
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPUPOPMENU);
			vppSqlCmd.Parameters.Add(vppParamDP_NOMMENU);
			vppSqlCmd.Parameters.Add(vppParamDP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamDP_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUDETAIL  @DP_CODEDETAIL, @PP_CODEPUPOPMENU, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenudetail </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenudetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DP_CODEDETAIL, PP_CODEPUPOPMENU, DP_NOMMENU, DP_LIBELLE, DP_AFFICHER FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenudetail> clsPhaparpupopmenudetails = new List<clsPhaparpupopmenudetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenudetail clsPhaparpupopmenudetail = new clsPhaparpupopmenudetail();
					clsPhaparpupopmenudetail.DP_CODEDETAIL = clsDonnee.vogDataReader["DP_CODEDETAIL"].ToString();
					clsPhaparpupopmenudetail.PP_CODEPUPOPMENU = clsDonnee.vogDataReader["PP_CODEPUPOPMENU"].ToString();
					clsPhaparpupopmenudetail.DP_NOMMENU = clsDonnee.vogDataReader["DP_NOMMENU"].ToString();
					clsPhaparpupopmenudetail.DP_LIBELLE = clsDonnee.vogDataReader["DP_LIBELLE"].ToString();
					clsPhaparpupopmenudetail.DP_AFFICHER = clsDonnee.vogDataReader["DP_AFFICHER"].ToString();
					clsPhaparpupopmenudetails.Add(clsPhaparpupopmenudetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenudetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenudetail </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenudetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenudetail> clsPhaparpupopmenudetails = new List<clsPhaparpupopmenudetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DP_CODEDETAIL, PP_CODEPUPOPMENU, DP_NOMMENU, DP_LIBELLE, DP_AFFICHER FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenudetail clsPhaparpupopmenudetail = new clsPhaparpupopmenudetail();
					clsPhaparpupopmenudetail.DP_CODEDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["DP_CODEDETAIL"].ToString();
					clsPhaparpupopmenudetail.PP_CODEPUPOPMENU = Dataset.Tables["TABLE"].Rows[Idx]["PP_CODEPUPOPMENU"].ToString();
					clsPhaparpupopmenudetail.DP_NOMMENU = Dataset.Tables["TABLE"].Rows[Idx]["DP_NOMMENU"].ToString();
					clsPhaparpupopmenudetail.DP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["DP_LIBELLE"].ToString();
					clsPhaparpupopmenudetail.DP_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["DP_AFFICHER"].ToString();
					clsPhaparpupopmenudetails.Add(clsPhaparpupopmenudetail);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenudetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@EC_CODECRAN,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMenuPrincipal(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee, vppCritere);


                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@MG_CODEMODEGESTION" };
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};

            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALDETAIL() ";// +this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DP_CODEDETAIL, PP_CODEPUPOPMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DP_CODEDETAIL , DP_NOMMENU FROM dbo.FT_PHAPARPUPOPMENUDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DP_CODEDETAIL, PP_CODEPUPOPMENU)</summary>
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
                this.vapCritere = "WHERE EC_CODECRAN=@EC_CODECRAN";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@EC_CODECRAN" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE DP_CODEDETAIL=@DP_CODEDETAIL AND PP_CODEPUPOPMENU=@PP_CODEPUPOPMENU";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DP_CODEDETAIL","@PP_CODEPUPOPMENU"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
