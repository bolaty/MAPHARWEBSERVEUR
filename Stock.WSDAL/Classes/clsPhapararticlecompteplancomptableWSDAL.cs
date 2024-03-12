using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapararticlecompteplancomptableWSDAL: ITableDAL<clsPhapararticlecompteplancomptable>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TO_CODEOPERATION) AS TO_CODEOPERATION  FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TO_CODEOPERATION) AS TO_CODEOPERATION  FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TO_CODEOPERATION) AS TO_CODEOPERATION  FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapararticlecompteplancomptable comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapararticlecompteplancomptable pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_CODENUMCOMPTE  FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapararticlecompteplancomptable clsPhapararticlecompteplancomptable = new clsPhapararticlecompteplancomptable();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapararticlecompteplancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapararticlecompteplancomptable;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapararticlecompteplancomptable>clsPhapararticlecompteplancomptable</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapararticlecompteplancomptable clsPhapararticlecompteplancomptable)
		{
			//Préparation des paramètres
			SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION", SqlDbType.VarChar, 2);
			vppParamTO_CODEOPERATION.Value  = clsPhapararticlecompteplancomptable.TO_CODEOPERATION ;
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapararticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhapararticlecompteplancomptable.AR_CODEARTICLE ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapararticlecompteplancomptable.PL_CODENUMCOMPTE ;
            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPhapararticlecompteplancomptable.PL_NUMCOMPTE;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARARTICLECOMPTEPLANCOMPTABLE  @TO_CODEOPERATION, @CP_CODEOPERATIONLIBELLECPTE, @AR_CODEARTICLE1, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapararticlecompteplancomptable>clsPhapararticlecompteplancomptable</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapararticlecompteplancomptable clsPhapararticlecompteplancomptable,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION", SqlDbType.VarChar, 2);
			vppParamTO_CODEOPERATION.Value  = clsPhapararticlecompteplancomptable.TO_CODEOPERATION ;
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapararticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhapararticlecompteplancomptable.AR_CODEARTICLE ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapararticlecompteplancomptable.PL_CODENUMCOMPTE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARARTICLECOMPTEPLANCOMPTABLE  @TO_CODEOPERATION, @CP_CODEOPERATIONLIBELLECPTE, @AR_CODEARTICLE, @PL_CODENUMCOMPTE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARARTICLECOMPTEPLANCOMPTABLE  @TO_CODEOPERATION1, '', @AR_CODEARTICLE, '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete1(clsDonnee clsDonnee,params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
	        //Préparation de la commande
		        this.vapRequete = "EXECUTE PC_PHAPARARTICLECOMPTEPLANCOMPTABLE  '', '', @AR_CODEARTICLE, '' ,'' , @CODECRYPTAGE, 3 ";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	        //Ouverture de la connection et exécution de la commande
	        clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticlecompteplancomptable </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticlecompteplancomptable> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE, PL_CODENUMCOMPTE FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapararticlecompteplancomptable> clsPhapararticlecompteplancomptables = new List<clsPhapararticlecompteplancomptable>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapararticlecompteplancomptable clsPhapararticlecompteplancomptable = new clsPhapararticlecompteplancomptable();
					clsPhapararticlecompteplancomptable.TO_CODEOPERATION = clsDonnee.vogDataReader["TO_CODEOPERATION"].ToString();
					clsPhapararticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE = clsDonnee.vogDataReader["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapararticlecompteplancomptable.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhapararticlecompteplancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPhapararticlecompteplancomptables.Add(clsPhapararticlecompteplancomptable);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapararticlecompteplancomptables;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticlecompteplancomptable </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticlecompteplancomptable> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapararticlecompteplancomptable> clsPhapararticlecompteplancomptables = new List<clsPhapararticlecompteplancomptable>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE, PL_CODENUMCOMPTE FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapararticlecompteplancomptable clsPhapararticlecompteplancomptable = new clsPhapararticlecompteplancomptable();
					clsPhapararticlecompteplancomptable.TO_CODEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TO_CODEOPERATION"].ToString();
					clsPhapararticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapararticlecompteplancomptable.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhapararticlecompteplancomptable.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsPhapararticlecompteplancomptables.Add(clsPhapararticlecompteplancomptable);
				}
				Dataset.Dispose();
			}
		return clsPhapararticlecompteplancomptables;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetComptesArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetComptesArticleCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@AR_CODEARTICLE", "@TO_CODEOPERATION" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1] };
            this.vapRequete = "EXEC [dbo].[PS_COMBOCOMPTEARTICLE] @AR_CODEARTICLE,@TO_CODEOPERATION " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TO_CODEOPERATION , PL_CODENUMCOMPTE FROM dbo.FT_PHAPARARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE)</summary>
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
                this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND TO_CODEOPERATION=@TO_CODEOPERATION1";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE", "@TO_CODEOPERATION1" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE TO_CODEOPERATION=@TO_CODEOPERATION AND CP_CODEOPERATIONLIBELLECPTE=@CP_CODEOPERATIONLIBELLECPTE AND AR_CODEARTICLE=@AR_CODEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TO_CODEOPERATION","@CP_CODEOPERATIONLIBELLECPTE","@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE, AR_CODEARTICLE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE TO_CODEOPERATION=@TO_CODEOPERATION AND AR_CODEARTICLE=@AR_CODEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE", "@TO_CODEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE TO_CODEOPERATION=@TO_CODEOPERATION AND CP_CODEOPERATIONLIBELLECPTE=@CP_CODEOPERATIONLIBELLECPTE AND AR_CODEARTICLE=@AR_CODEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TO_CODEOPERATION", "@CP_CODEOPERATIONLIBELLECPTE", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }




	}
}
