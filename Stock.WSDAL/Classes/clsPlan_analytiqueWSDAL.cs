using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPlan_analytiqueWSDAL: ITableDAL<clsPlan_analytique>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(PLAN_ANALYTIQUE_CODE) AS PLAN_ANALYTIQUE_CODE  FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(PLAN_ANALYTIQUE_CODE) AS PLAN_ANALYTIQUE_CODE  FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(PLAN_ANALYTIQUE_CODE) AS PLAN_ANALYTIQUE_CODE  FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPlan_analytique comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPlan_analytique pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TYPE_PLAN_CODE  , PLAN_ANALYTIQUE_INTITULE  , PLAN_ANALYTIQUE_ABREGE  , PLAN_ANALYTIQUE_REPORT_A_NOUVEAU  , PLAN_ANALYTIQUE_MISE_EN_SOMMEIL, PLAN_ANALYTIQUE_NUM_SECTION, AF_CODE, TS_CODE, PLAN_ANALYTIQUE_NOMBRE_LIGNE  FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPlan_analytique clsPlan_analytique = new clsPlan_analytique();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPlan_analytique.TYPE_PLAN_CODE = clsDonnee.vogDataReader["TYPE_PLAN_CODE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_INTITULE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_ABREGE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_REPORT_A_NOUVEAU"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_MISE_EN_SOMMEIL"].ToString();
                    clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_NUM_SECTION"].ToString();
                    clsPlan_analytique.AF_CODE = clsDonnee.vogDataReader["AF_CODE"].ToString();
                    clsPlan_analytique.TS_CODE = clsDonnee.vogDataReader["TS_CODE"].ToString();
                    clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_NOMBRE_LIGNE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPlan_analytique;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlan_analytique>clsPlan_analytique</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPlan_analytique clsPlan_analytique)
		{
			//Préparation des paramètres
			SqlParameter vppParamPLAN_ANALYTIQUE_CODE = new SqlParameter("@PLAN_ANALYTIQUE_CODE", SqlDbType.BigInt);
			vppParamPLAN_ANALYTIQUE_CODE.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_CODE ;

            SqlParameter vppParamTYPE_PLAN_CODE = new SqlParameter("@TYPE_PLAN_CODE", SqlDbType.VarChar, 2);
            vppParamTYPE_PLAN_CODE.Value = clsPlan_analytique.TYPE_PLAN_CODE;
            if (clsPlan_analytique.TYPE_PLAN_CODE == "") vppParamTYPE_PLAN_CODE.Value = DBNull.Value;

			SqlParameter vppParamPLAN_ANALYTIQUE_INTITULE = new SqlParameter("@PLAN_ANALYTIQUE_INTITULE", SqlDbType.VarChar, 150);
			vppParamPLAN_ANALYTIQUE_INTITULE.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE== ""  ) vppParamPLAN_ANALYTIQUE_INTITULE.Value  = DBNull.Value;
			SqlParameter vppParamPLAN_ANALYTIQUE_ABREGE = new SqlParameter("@PLAN_ANALYTIQUE_ABREGE", SqlDbType.VarChar, 150);
			vppParamPLAN_ANALYTIQUE_ABREGE.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE== ""  ) vppParamPLAN_ANALYTIQUE_ABREGE.Value  = DBNull.Value;
			SqlParameter vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU = new SqlParameter("@PLAN_ANALYTIQUE_REPORT_A_NOUVEAU", SqlDbType.VarChar, 1);
			vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU== ""  ) vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU.Value  = DBNull.Value;

			SqlParameter vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL = new SqlParameter("@PLAN_ANALYTIQUE_MISE_EN_SOMMEIL", SqlDbType.VarChar, 1);
			vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL== ""  ) vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL.Value  = DBNull.Value;

            SqlParameter vppParamPLAN_ANALYTIQUE_NUM_SECTION = new SqlParameter("@PLAN_ANALYTIQUE_NUM_SECTION", SqlDbType.VarChar, 150);
            vppParamPLAN_ANALYTIQUE_NUM_SECTION.Value = clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION;
            if (clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION == "") vppParamPLAN_ANALYTIQUE_NUM_SECTION.Value = DBNull.Value;

            SqlParameter vppParamAF_CODE = new SqlParameter("@AF_CODE", SqlDbType.VarChar, 150);
            vppParamAF_CODE.Value = clsPlan_analytique.AF_CODE;
            if (clsPlan_analytique.AF_CODE == "") vppParamAF_CODE.Value = DBNull.Value;

            SqlParameter vppParamTS_CODE = new SqlParameter("@TS_CODE", SqlDbType.VarChar, 150);
            vppParamTS_CODE.Value = clsPlan_analytique.TS_CODE;
            if (clsPlan_analytique.TS_CODE == "") vppParamTS_CODE.Value = DBNull.Value;

            SqlParameter vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE = new SqlParameter("@PLAN_ANALYTIQUE_NOMBRE_LIGNE", SqlDbType.VarChar, 150);
            vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE.Value = clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE;
            if (clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE == "") vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE.Value = DBNull.Value;


			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_PLAN_ANALYTIQUE  @PLAN_ANALYTIQUE_CODE, @TYPE_PLAN_CODE, @PLAN_ANALYTIQUE_INTITULE, @PLAN_ANALYTIQUE_ABREGE, @PLAN_ANALYTIQUE_REPORT_A_NOUVEAU, @PLAN_ANALYTIQUE_MISE_EN_SOMMEIL,  @PLAN_ANALYTIQUE_NUM_SECTION,  @AF_CODE, @TS_CODE, @PLAN_ANALYTIQUE_NOMBRE_LIGNE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_CODE);
            vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_INTITULE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_ABREGE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL);
            vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_NUM_SECTION);
            vppSqlCmd.Parameters.Add(vppParamAF_CODE);
            vppSqlCmd.Parameters.Add(vppParamTS_CODE);
            vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlan_analytique>clsPlan_analytique</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPlan_analytique clsPlan_analytique,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPLAN_ANALYTIQUE_CODE = new SqlParameter("@PLAN_ANALYTIQUE_CODE", SqlDbType.BigInt);
			vppParamPLAN_ANALYTIQUE_CODE.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_CODE ;

            SqlParameter vppParamTYPE_PLAN_CODE = new SqlParameter("@TYPE_PLAN_CODE", SqlDbType.VarChar, 150);
            vppParamTYPE_PLAN_CODE.Value = clsPlan_analytique.TYPE_PLAN_CODE;
            if (clsPlan_analytique.TYPE_PLAN_CODE == "") vppParamTYPE_PLAN_CODE.Value = DBNull.Value;
			SqlParameter vppParamPLAN_ANALYTIQUE_INTITULE = new SqlParameter("@PLAN_ANALYTIQUE_INTITULE", SqlDbType.VarChar, 150);
			vppParamPLAN_ANALYTIQUE_INTITULE.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE== ""  ) vppParamPLAN_ANALYTIQUE_INTITULE.Value  = DBNull.Value;
			SqlParameter vppParamPLAN_ANALYTIQUE_ABREGE = new SqlParameter("@PLAN_ANALYTIQUE_ABREGE", SqlDbType.VarChar, 150);
			vppParamPLAN_ANALYTIQUE_ABREGE.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE== ""  ) vppParamPLAN_ANALYTIQUE_ABREGE.Value  = DBNull.Value;
			SqlParameter vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU = new SqlParameter("@PLAN_ANALYTIQUE_REPORT_A_NOUVEAU", SqlDbType.VarChar, 1);
			vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU== ""  ) vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU.Value  = DBNull.Value;

			SqlParameter vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL = new SqlParameter("@PLAN_ANALYTIQUE_MISE_EN_SOMMEIL", SqlDbType.VarChar, 1);
			vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL.Value  = clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL ;
			if(clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL== ""  ) vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL.Value  = DBNull.Value;

            SqlParameter vppParamPLAN_ANALYTIQUE_NUM_SECTION = new SqlParameter("@PLAN_ANALYTIQUE_NUM_SECTION", SqlDbType.VarChar, 150);
            vppParamPLAN_ANALYTIQUE_NUM_SECTION.Value = clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION;
            if (clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION == "") vppParamPLAN_ANALYTIQUE_NUM_SECTION.Value = DBNull.Value;

            SqlParameter vppParamAF_CODE = new SqlParameter("@AF_CODE", SqlDbType.VarChar, 150);
            vppParamAF_CODE.Value = clsPlan_analytique.AF_CODE;
            if (clsPlan_analytique.AF_CODE == "") vppParamAF_CODE.Value = DBNull.Value;

            SqlParameter vppParamTS_CODE = new SqlParameter("@TS_CODE", SqlDbType.VarChar, 150);
            vppParamTS_CODE.Value = clsPlan_analytique.TS_CODE;
            if (clsPlan_analytique.TS_CODE == "") vppParamTS_CODE.Value = DBNull.Value;

            SqlParameter vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE = new SqlParameter("@PLAN_ANALYTIQUE_NOMBRE_LIGNE", SqlDbType.VarChar, 150);
            vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE.Value = clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE;
            if (clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE == "") vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE.Value = DBNull.Value;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_PLAN_ANALYTIQUE  @PLAN_ANALYTIQUE_CODE, @TYPE_PLAN_CODE, @PLAN_ANALYTIQUE_INTITULE, @PLAN_ANALYTIQUE_ABREGE, @PLAN_ANALYTIQUE_REPORT_A_NOUVEAU, @PLAN_ANALYTIQUE_MISE_EN_SOMMEIL, @PLAN_ANALYTIQUE_NUM_SECTION, @AF_CODE, @TS_CODE, @PLAN_ANALYTIQUE_NOMBRE_LIGNE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_CODE);
            vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_INTITULE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_ABREGE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_REPORT_A_NOUVEAU);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_MISE_EN_SOMMEIL);
            vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_NUM_SECTION);
            vppSqlCmd.Parameters.Add(vppParamAF_CODE);
            vppSqlCmd.Parameters.Add(vppParamTS_CODE);
            vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_NOMBRE_LIGNE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_PLAN_ANALYTIQUE  @PLAN_ANALYTIQUE_CODE, '' , '' , '' , '' , '' , '', '', '', '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlan_analytique </returns>
		///<author>Home Technology</author>
		public List<clsPlan_analytique> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  PLAN_ANALYTIQUE_CODE, TYPE_PLAN_CODE, PLAN_ANALYTIQUE_INTITULE, PLAN_ANALYTIQUE_ABREGE, PLAN_ANALYTIQUE_REPORT_A_NOUVEAU, PLAN_ANALYTIQUE_MISE_EN_SOMMEIL,  PLAN_ANALYTIQUE_NUM_SECTION, AF_CODE, TS_CODE, PLAN_ANALYTIQUE_NOMBRE_LIGNE FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPlan_analytique> clsPlan_analytiques = new List<clsPlan_analytique>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlan_analytique clsPlan_analytique = new clsPlan_analytique();
                    clsPlan_analytique.PLAN_ANALYTIQUE_CODE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_CODE"].ToString();
                    clsPlan_analytique.TYPE_PLAN_CODE = clsDonnee.vogDataReader["TYPE_PLAN_CODE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_INTITULE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_ABREGE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_REPORT_A_NOUVEAU"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_MISE_EN_SOMMEIL"].ToString();
                    clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_NUM_SECTION"].ToString();
                    clsPlan_analytique.AF_CODE = clsDonnee.vogDataReader["AF_CODE"].ToString();
                    clsPlan_analytique.TS_CODE = clsDonnee.vogDataReader["TS_CODE"].ToString();
                    clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_NOMBRE_LIGNE"].ToString();
					clsPlan_analytiques.Add(clsPlan_analytique);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlan_analytiques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlan_analytique </returns>
		///<author>Home Technology</author>
		public List<clsPlan_analytique> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlan_analytique> clsPlan_analytiques = new List<clsPlan_analytique>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  PLAN_ANALYTIQUE_CODE, TYPE_PLAN_CODE, PLAN_ANALYTIQUE_INTITULE, PLAN_ANALYTIQUE_ABREGE, PLAN_ANALYTIQUE_REPORT_A_NOUVEAU, PLAN_ANALYTIQUE_MISE_EN_SOMMEIL, PLAN_ANALYTIQUE_NUM_SECTION, AF_CODE, TS_CODE, PLAN_ANALYTIQUE_NOMBRE_LIGNE FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPlan_analytique clsPlan_analytique = new clsPlan_analytique();
					clsPlan_analytique.PLAN_ANALYTIQUE_CODE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_CODE"].ToString();
                    clsPlan_analytique.TYPE_PLAN_CODE = Dataset.Tables["TABLE"].Rows[Idx]["TYPE_PLAN_CODE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_INTITULE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_INTITULE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_ABREGE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_ABREGE"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_REPORT_A_NOUVEAU = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_REPORT_A_NOUVEAU"].ToString();
					clsPlan_analytique.PLAN_ANALYTIQUE_MISE_EN_SOMMEIL = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_MISE_EN_SOMMEIL"].ToString();
                    clsPlan_analytique.PLAN_ANALYTIQUE_NUM_SECTION = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_NUM_SECTION"].ToString();
                    clsPlan_analytique.AF_CODE = Dataset.Tables["TABLE"].Rows[Idx]["AF_CODE"].ToString();
                    clsPlan_analytique.TS_CODE = Dataset.Tables["TABLE"].Rows[Idx]["TS_CODE"].ToString();
                    clsPlan_analytique.PLAN_ANALYTIQUE_NOMBRE_LIGNE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_NOMBRE_LIGNE"].ToString();
					clsPlan_analytiques.Add(clsPlan_analytique);
				}
				Dataset.Dispose();
			}
		return clsPlan_analytiques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            //this.vapRequete = "SELECT *  FROM dbo.FT_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapRequete = "SELECT *  FROM VUE_COMPTAPAR_PLAN_ANALYTIQUE " + this.vapCritere;
            
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PLAN_ANALYTIQUE_CODE, PLAN_ANALYTIQUE_NUM_SECTION, PLAN_ANALYTIQUE_INTITULE  FROM VUE_COMPTAPAR_PLAN_ANALYTIQUE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PLAN_ANALYTIQUE_NUM_SECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT PLAN_ANALYTIQUE_CODE , PLAN_ANALYTIQUE_TYPE FROM dbo.FT_COMPTAPAR_PLAN_ANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PLAN_ANALYTIQUE_NUM_SECTION)</summary>
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
                this.vapCritere = "WHERE PLAN_ANALYTIQUE_CODE=@PLAN_ANALYTIQUE_CODE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@PLAN_ANALYTIQUE_CODE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
