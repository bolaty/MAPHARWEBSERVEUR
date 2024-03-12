using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPlan_rerportingWSDAL: ITableDAL<clsPlan_rerporting>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(PLAN_REPORTING_CODE) AS PLAN_REPORTING_CODE  FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(PLAN_REPORTING_CODE) AS PLAN_REPORTING_CODE  FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(PLAN_REPORTING_CODE) AS PLAN_REPORTING_CODE  FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPlan_rerporting comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPlan_rerporting pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TYPE_PLAN_CODE  , PLAN_RERPORTING_INTITULE  , PLAN_RERPORTING_ABREGE  , TS_CODE  , PLAN_RERPORTING_NOMBRE_LIGNE, PLAN_REPORTING_NUMERO  FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPlan_rerporting clsPlan_rerporting = new clsPlan_rerporting();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPlan_rerporting.TYPE_PLAN_CODE = clsDonnee.vogDataReader["TYPE_PLAN_CODE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_INTITULE = clsDonnee.vogDataReader["PLAN_RERPORTING_INTITULE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_ABREGE = clsDonnee.vogDataReader["PLAN_RERPORTING_ABREGE"].ToString();
                    clsPlan_rerporting.TS_CODE = clsDonnee.vogDataReader["TS_CODE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE = clsDonnee.vogDataReader["PLAN_RERPORTING_NOMBRE_LIGNE"].ToString();
                    clsPlan_rerporting.PLAN_REPORTING_NUMERO = clsDonnee.vogDataReader["PLAN_REPORTING_NUMERO"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPlan_rerporting;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlan_rerporting>clsPlan_rerporting</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPlan_rerporting clsPlan_rerporting)
		{
			//Préparation des paramètres
			SqlParameter vppParamPLAN_REPORTING_CODE = new SqlParameter("@PLAN_REPORTING_CODE", SqlDbType.VarChar, 4);
			vppParamPLAN_REPORTING_CODE.Value  = clsPlan_rerporting.PLAN_REPORTING_CODE ;

            SqlParameter vppParamTYPE_PLAN_CODE = new SqlParameter("@TYPE_PLAN_CODE", SqlDbType.VarChar, 2);
            vppParamTYPE_PLAN_CODE.Value = clsPlan_rerporting.TYPE_PLAN_CODE;
            if (clsPlan_rerporting.TYPE_PLAN_CODE == "") vppParamTYPE_PLAN_CODE.Value = DBNull.Value;
			SqlParameter vppParamPLAN_RERPORTING_INTITULE = new SqlParameter("@PLAN_RERPORTING_INTITULE", SqlDbType.VarChar, 150);
			vppParamPLAN_RERPORTING_INTITULE.Value  = clsPlan_rerporting.PLAN_RERPORTING_INTITULE ;
			if(clsPlan_rerporting.PLAN_RERPORTING_INTITULE== ""  ) vppParamPLAN_RERPORTING_INTITULE.Value  = DBNull.Value;
			SqlParameter vppParamPLAN_RERPORTING_ABREGE = new SqlParameter("@PLAN_RERPORTING_ABREGE", SqlDbType.VarChar, 150);
			vppParamPLAN_RERPORTING_ABREGE.Value  = clsPlan_rerporting.PLAN_RERPORTING_ABREGE ;
			if(clsPlan_rerporting.PLAN_RERPORTING_ABREGE== ""  ) vppParamPLAN_RERPORTING_ABREGE.Value  = DBNull.Value;
            SqlParameter vppParamTS_CODE = new SqlParameter("@TS_CODE", SqlDbType.VarChar, 150);
            vppParamTS_CODE.Value = clsPlan_rerporting.TS_CODE;
            if (clsPlan_rerporting.TS_CODE == "") vppParamTS_CODE.Value = DBNull.Value;

			SqlParameter vppParamPLAN_RERPORTING_NOMBRE_LIGNE = new SqlParameter("@PLAN_RERPORTING_NOMBRE_LIGNE", SqlDbType.Int);
			vppParamPLAN_RERPORTING_NOMBRE_LIGNE.Value  = clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE ;
			if(clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE== ""  ) vppParamPLAN_RERPORTING_NOMBRE_LIGNE.Value  = DBNull.Value;

            SqlParameter vppParamPLAN_REPORTING_NUMERO = new SqlParameter("@PLAN_REPORTING_NUMERO", SqlDbType.VarChar, 150);
            vppParamPLAN_REPORTING_NUMERO.Value = clsPlan_rerporting.PLAN_REPORTING_NUMERO;
            if (clsPlan_rerporting.PLAN_REPORTING_NUMERO == "") vppParamPLAN_REPORTING_NUMERO.Value = DBNull.Value;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_PLAN_REPORTING  @PLAN_REPORTING_CODE, @TYPE_PLAN_CODE, @PLAN_RERPORTING_INTITULE, @PLAN_RERPORTING_ABREGE, @TS_CODE, @PLAN_RERPORTING_NOMBRE_LIGNE, @PLAN_REPORTING_NUMERO,  @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPLAN_REPORTING_CODE);
            vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_RERPORTING_INTITULE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_RERPORTING_ABREGE);
            vppSqlCmd.Parameters.Add(vppParamTS_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_RERPORTING_NOMBRE_LIGNE);
            vppSqlCmd.Parameters.Add(vppParamPLAN_REPORTING_NUMERO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlan_rerporting>clsPlan_rerporting</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPlan_rerporting clsPlan_rerporting,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPLAN_REPORTING_CODE = new SqlParameter("@PLAN_REPORTING_CODE", SqlDbType.VarChar, 4);
            //vppParamPLAN_REPORTING_CODE.Value = clsPlan_rerporting.PLAN_REPORTING_CODE;
            vppParamPLAN_REPORTING_CODE.Value = vppCritere[0];

            SqlParameter vppParamTYPE_PLAN_CODE = new SqlParameter("@TYPE_PLAN_CODE", SqlDbType.VarChar, 150);
            vppParamTYPE_PLAN_CODE.Value = clsPlan_rerporting.TYPE_PLAN_CODE;
            if (clsPlan_rerporting.TYPE_PLAN_CODE == "") vppParamTYPE_PLAN_CODE.Value = DBNull.Value;
			SqlParameter vppParamPLAN_RERPORTING_INTITULE = new SqlParameter("@PLAN_RERPORTING_INTITULE", SqlDbType.VarChar, 150);
			vppParamPLAN_RERPORTING_INTITULE.Value  = clsPlan_rerporting.PLAN_RERPORTING_INTITULE ;
			if(clsPlan_rerporting.PLAN_RERPORTING_INTITULE== ""  ) vppParamPLAN_RERPORTING_INTITULE.Value  = DBNull.Value;
			SqlParameter vppParamPLAN_RERPORTING_ABREGE = new SqlParameter("@PLAN_RERPORTING_ABREGE", SqlDbType.VarChar, 150);
			vppParamPLAN_RERPORTING_ABREGE.Value  = clsPlan_rerporting.PLAN_RERPORTING_ABREGE ;
			if(clsPlan_rerporting.PLAN_RERPORTING_ABREGE== ""  ) vppParamPLAN_RERPORTING_ABREGE.Value  = DBNull.Value;
            SqlParameter vppParamTS_CODE = new SqlParameter("@TS_CODE", SqlDbType.VarChar, 150);
            vppParamTS_CODE.Value = clsPlan_rerporting.TS_CODE;
            if (clsPlan_rerporting.TS_CODE == "") vppParamTS_CODE.Value = DBNull.Value;

			SqlParameter vppParamPLAN_RERPORTING_NOMBRE_LIGNE = new SqlParameter("@PLAN_RERPORTING_NOMBRE_LIGNE", SqlDbType.Int);
			vppParamPLAN_RERPORTING_NOMBRE_LIGNE.Value  = clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE ;
			if(clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE== ""  ) vppParamPLAN_RERPORTING_NOMBRE_LIGNE.Value  = DBNull.Value;

            SqlParameter vppParamPLAN_REPORTING_NUMERO = new SqlParameter("@PLAN_REPORTING_NUMERO", SqlDbType.VarChar, 150);
            vppParamPLAN_REPORTING_NUMERO.Value = clsPlan_rerporting.PLAN_REPORTING_NUMERO;
            if (clsPlan_rerporting.PLAN_REPORTING_NUMERO == "") vppParamPLAN_REPORTING_NUMERO.Value = DBNull.Value;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_PLAN_REPORTING  @PLAN_REPORTING_CODE, @TYPE_PLAN_CODE, @PLAN_RERPORTING_INTITULE, @PLAN_RERPORTING_ABREGE, @TS_CODE, @PLAN_RERPORTING_NOMBRE_LIGNE, @PLAN_REPORTING_NUMERO,  @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPLAN_REPORTING_CODE);
            vppSqlCmd.Parameters.Add(vppParamTYPE_PLAN_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_RERPORTING_INTITULE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_RERPORTING_ABREGE);
            vppSqlCmd.Parameters.Add(vppParamTS_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_RERPORTING_NOMBRE_LIGNE);
            vppSqlCmd.Parameters.Add(vppParamPLAN_REPORTING_NUMERO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_PLAN_REPORTING  @PLAN_REPORTING_CODE, '' , '' , '' , '' , '', '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlan_rerporting </returns>
		///<author>Home Technology</author>
		public List<clsPlan_rerporting> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  PLAN_REPORTING_CODE, TYPE_PLAN_CODE, PLAN_RERPORTING_INTITULE, PLAN_RERPORTING_ABREGE, TS_CODE, PLAN_RERPORTING_NOMBRE_LIGNE, PLAN_REPORTING_NUMERO FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPlan_rerporting> clsPlan_rerportings = new List<clsPlan_rerporting>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlan_rerporting clsPlan_rerporting = new clsPlan_rerporting();
					clsPlan_rerporting.PLAN_REPORTING_CODE = clsDonnee.vogDataReader["PLAN_REPORTING_CODE"].ToString();
                    clsPlan_rerporting.TYPE_PLAN_CODE = clsDonnee.vogDataReader["TYPE_PLAN_CODE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_INTITULE = clsDonnee.vogDataReader["PLAN_RERPORTING_INTITULE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_ABREGE = clsDonnee.vogDataReader["PLAN_RERPORTING_ABREGE"].ToString();
                    clsPlan_rerporting.TS_CODE = clsDonnee.vogDataReader["TS_CODE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE = clsDonnee.vogDataReader["PLAN_RERPORTING_NOMBRE_LIGNE"].ToString();
                    clsPlan_rerporting.PLAN_REPORTING_NUMERO = clsDonnee.vogDataReader["PLAN_REPORTING_NUMERO"].ToString();
					clsPlan_rerportings.Add(clsPlan_rerporting);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlan_rerportings;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlan_rerporting </returns>
		///<author>Home Technology</author>
		public List<clsPlan_rerporting> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlan_rerporting> clsPlan_rerportings = new List<clsPlan_rerporting>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  PLAN_REPORTING_CODE, TYPE_PLAN_CODE, PLAN_RERPORTING_INTITULE, PLAN_RERPORTING_ABREGE, TS_CODE, PLAN_RERPORTING_NOMBRE_LIGNE, PLAN_REPORTING_NUMERO FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPlan_rerporting clsPlan_rerporting = new clsPlan_rerporting();
                    clsPlan_rerporting.PLAN_REPORTING_CODE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_REPORTING_CODE"].ToString();
                    clsPlan_rerporting.TYPE_PLAN_CODE = Dataset.Tables["TABLE"].Rows[Idx]["TYPE_PLAN_CODE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_INTITULE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_RERPORTING_INTITULE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_ABREGE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_RERPORTING_ABREGE"].ToString();
                    clsPlan_rerporting.TS_CODE = Dataset.Tables["TABLE"].Rows[Idx]["TS_CODE"].ToString();
					clsPlan_rerporting.PLAN_RERPORTING_NOMBRE_LIGNE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_RERPORTING_NOMBRE_LIGNE"].ToString();
                    clsPlan_rerporting.PLAN_REPORTING_NUMERO = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_REPORTING_NUMERO"].ToString();
					clsPlan_rerportings.Add(clsPlan_rerporting);
				}
				Dataset.Dispose();
			}
		return clsPlan_rerportings;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            //this.vapRequete = "SELECT *  FROM dbo.FT_PLAN_RERPORTING(@CODECRYPTAGE) " + this.vapCritere;
            this.vapRequete = "SELECT *  FROM VUE_COMPTAPAR_PLAN_REPORTING " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PLAN_REPORTING_NUMERO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT PLAN_REPORTING_CODE , PLAN_RERPORTING_INTITULE FROM dbo.FT_COMPTAPAR_PLAN_REPORTING(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PLAN_REPORTING_NUMERO)</summary>
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
				this.vapCritere ="WHERE PLAN_REPORTING_CODE=@PLAN_REPORTING_CODE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PLAN_REPORTING_CODE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
