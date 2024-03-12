using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypearticlecompteplancomptableWSDAL: ITableDAL<clsPhapartypearticlecompteplancomptable>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticlecompteplancomptable comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticlecompteplancomptable pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_CODENUMCOMPTE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable = new clsPhapartypearticlecompteplancomptable();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticlecompteplancomptable.PL_CODENUMCOMPTE = double.Parse(clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypearticlecompteplancomptable;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticlecompteplancomptable>clsPhapartypearticlecompteplancomptable</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE1", SqlDbType.VarChar, 3);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE ;
			SqlParameter vppParamTO_CODEOPERATIONPARAMETRE = new SqlParameter("@TO_CODEOPERATIONPARAMETRE", SqlDbType.VarChar, 4);
			vppParamTO_CODEOPERATIONPARAMETRE.Value  = clsPhapartypearticlecompteplancomptable.TO_CODEOPERATIONPARAMETRE ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.BigInt);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapartypearticlecompteplancomptable.PL_CODENUMCOMPTE ;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhapartypearticlecompteplancomptable.PL_NUMCOMPTE;

            SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION1", SqlDbType.VarChar, 50);
            vppParamTO_CODEOPERATION.Value = clsPhapartypearticlecompteplancomptable.TO_CODEOPERATION;
            SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 50);
            vppParamCP_CODEOPERATIONLIBELLECPTE.Value = clsPhapartypearticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhapartypearticlecompteplancomptable.TYPEOPERATION;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  @TA_CODETYPEARTICLE1, @TO_CODEOPERATIONPARAMETRE, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE,@TO_CODEOPERATION1,@CP_CODEOPERATIONLIBELLECPTE, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATIONPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticlecompteplancomptable>clsPhapartypearticlecompteplancomptable</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE1", SqlDbType.VarChar, 3);
            vppParamTA_CODETYPEARTICLE.Value = clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE;
            SqlParameter vppParamTO_CODEOPERATIONPARAMETRE = new SqlParameter("@TO_CODEOPERATIONPARAMETRE", SqlDbType.VarChar, 4);
            vppParamTO_CODEOPERATIONPARAMETRE.Value = clsPhapartypearticlecompteplancomptable.TO_CODEOPERATIONPARAMETRE;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.BigInt);
            vppParamPL_CODENUMCOMPTE.Value = clsPhapartypearticlecompteplancomptable.PL_CODENUMCOMPTE;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhapartypearticlecompteplancomptable.PL_NUMCOMPTE;

            SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION1", SqlDbType.VarChar, 50);
            vppParamTO_CODEOPERATION.Value = clsPhapartypearticlecompteplancomptable.TO_CODEOPERATION;
            SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 50);
            vppParamCP_CODEOPERATIONLIBELLECPTE.Value = clsPhapartypearticlecompteplancomptable.CP_CODEOPERATIONLIBELLECPTE;
            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhapartypearticlecompteplancomptable.TYPEOPERATION;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  @TA_CODETYPEARTICLE1, @TO_CODEOPERATIONPARAMETRE, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE,@TO_CODEOPERATION1,@CP_CODEOPERATIONLIBELLECPTE, @CODECRYPTAGE1, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATIONPARAMETRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  @TA_CODETYPEARTICLE, '', '' ,'',@TO_CODEOPERATION,'', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete1(clsDonnee clsDonnee,params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
	        //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  @TA_CODETYPEARTICLE, '', '' ,'','','', @CODECRYPTAGE, 4 ";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	        //Ouverture de la connection et exécution de la commande
	        clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptable </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptable> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE, PL_CODENUMCOMPTE FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypearticlecompteplancomptable> clsPhapartypearticlecompteplancomptables = new List<clsPhapartypearticlecompteplancomptable>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable = new clsPhapartypearticlecompteplancomptable();
					clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
					clsPhapartypearticlecompteplancomptable.TO_CODEOPERATIONPARAMETRE = clsDonnee.vogDataReader["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticlecompteplancomptable.PL_CODENUMCOMPTE = double.Parse(clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString());
					clsPhapartypearticlecompteplancomptables.Add(clsPhapartypearticlecompteplancomptable);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypearticlecompteplancomptables;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptable </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptable> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypearticlecompteplancomptable> clsPhapartypearticlecompteplancomptables = new List<clsPhapartypearticlecompteplancomptable>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE, PL_CODENUMCOMPTE FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable = new clsPhapartypearticlecompteplancomptable();
					clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
					clsPhapartypearticlecompteplancomptable.TO_CODEOPERATIONPARAMETRE = Dataset.Tables["TABLE"].Rows[Idx]["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticlecompteplancomptable.PL_CODENUMCOMPTE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString());
					clsPhapartypearticlecompteplancomptables.Add(clsPhapartypearticlecompteplancomptable);
				}
				Dataset.Dispose();
			}
		return clsPhapartypearticlecompteplancomptables;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@TA_CODETYPEARTICLE,@AR_CODEARTICLE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETYPEARTICLE , PL_CODENUMCOMPTE FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE)</summary>
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
				this.vapCritere ="WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETYPEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE AND TO_CODEOPERATION=@TO_CODEOPERATION1";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@TA_CODETYPEARTICLE", "@TO_CODEOPERATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE)</summary>
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
                    this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TA_CODETYPEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TA_CODETYPEARTICLE", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
	}
}
