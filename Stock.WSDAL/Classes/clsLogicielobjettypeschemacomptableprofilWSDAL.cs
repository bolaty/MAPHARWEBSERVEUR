using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielobjettypeschemacomptableprofilWSDAL: ITableDAL<clsLogicielobjettypeschemacomptableprofil>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjettypeschemacomptableprofil comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjettypeschemacomptableprofil pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT LB_ACTIF  FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new clsLogicielobjettypeschemacomptableprofil();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeschemacomptableprofil.LB_ACTIF = clsDonnee.vogDataReader["LB_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogicielobjettypeschemacomptableprofil;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeschemacomptableprofil>clsLogicielobjettypeschemacomptableprofil</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeschemacomptableprofil.AG_CODEAGENCE ;
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL1", SqlDbType.VarChar, 50);
			vppParamPO_CODEPROFIL.Value  = clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION ;


			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION1", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION ;

			SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION1", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofil.NF_CODENATUREFAMILLEOPERATION;


			SqlParameter vppParamLB_ACTIF = new SqlParameter("@LB_ACTIF", SqlDbType.VarChar, 1);
			vppParamLB_ACTIF.Value  = clsLogicielobjettypeschemacomptableprofil.LB_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFILWEB  @AG_CODEAGENCE1, @PO_CODEPROFIL1, @NO_CODENATUREOPERATION, @FO_CODEFAMILLEOPERATION1, @LB_ACTIF, @NF_CODENATUREFAMILLEOPERATION1, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLB_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeschemacomptableprofil>clsLogicielobjettypeschemacomptableprofil</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeschemacomptableprofil.AG_CODEAGENCE ;
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 50);
			vppParamPO_CODEPROFIL.Value  = clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION ;
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofil.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamLB_ACTIF = new SqlParameter("@LB_ACTIF", SqlDbType.VarChar, 1);
			vppParamLB_ACTIF.Value  = clsLogicielobjettypeschemacomptableprofil.LB_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFILWEB2  @AG_CODEAGENCE, @PO_CODEPROFIL, @NO_CODENATUREOPERATION, @FO_CODEFAMILLEOPERATION, @LB_ACTIF,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);

			vppSqlCmd.Parameters.Add(vppParamLB_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFILWEB  @AG_CODEAGENCE, @PO_CODEPROFIL, '', @FO_CODEFAMILLEOPERATION, '' ,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeschemacomptableprofil </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeschemacomptableprofil> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION, LB_ACTIF FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<clsLogicielobjettypeschemacomptableprofil>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new clsLogicielobjettypeschemacomptableprofil();
					clsLogicielobjettypeschemacomptableprofil.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
					clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofil.LB_ACTIF = clsDonnee.vogDataReader["LB_ACTIF"].ToString();
					clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogicielobjettypeschemacomptableprofils;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeschemacomptableprofil </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeschemacomptableprofil> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<clsLogicielobjettypeschemacomptableprofil>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION, LB_ACTIF FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new clsLogicielobjettypeschemacomptableprofil();
					clsLogicielobjettypeschemacomptableprofil.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFIL"].ToString();
					clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofil.LB_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["LB_ACTIF"].ToString();
					clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
				}
				Dataset.Dispose();
			}
		return clsLogicielobjettypeschemacomptableprofils;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , LB_ACTIF FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFIL2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@PO_CODEPROFIL" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
            this.vapRequete = "SELECT * FROM dbo.FT_LOGICIELOBJETTYPESCHEMACOMPTABLEPROFILWEBDROIT(@AG_CODEAGENCE,@NF_CODENATUREFAMILLEOPERATION,@FO_CODEFAMILLEOPERATION ,@PO_CODEPROFIL)  ORDER BY NO_NUMEROORDRE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, PO_CODEPROFIL, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;


                case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL", "@NF_CODENATUREFAMILLEOPERATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;

                case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION ";
                vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL", "@NF_CODENATUREFAMILLEOPERATION" , "@FO_CODEFAMILLEOPERATION" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
                break;

                case 5 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@NO_CODENATUREOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL","@NO_CODENATUREOPERATION","@FO_CODEFAMILLEOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
