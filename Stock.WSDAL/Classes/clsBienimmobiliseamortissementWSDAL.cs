using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBienimmobiliseamortissementWSDAL: ITableDAL<clsBienimmobiliseamortissement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBienimmobiliseamortissement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBienimmobiliseamortissement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , IA_DATE  , IA_PERIODE  , IA_DOTATIONANTERIEUR  , IA_DOTATIONEXERCICE  , IA_CUMUL  , IA_VALEURRESIDUELLE  FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBienimmobiliseamortissement clsBienimmobiliseamortissement = new clsBienimmobiliseamortissement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobiliseamortissement.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsBienimmobiliseamortissement.IA_DATE = DateTime.Parse(clsDonnee.vogDataReader["IA_DATE"].ToString());
					clsBienimmobiliseamortissement.IA_PERIODE = clsDonnee.vogDataReader["IA_PERIODE"].ToString();
					clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR = double.Parse(clsDonnee.vogDataReader["IA_DOTATIONANTERIEUR"].ToString());
					clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE = double.Parse(clsDonnee.vogDataReader["IA_DOTATIONEXERCICE"].ToString());
					clsBienimmobiliseamortissement.IA_CUMUL = double.Parse(clsDonnee.vogDataReader["IA_CUMUL"].ToString());
					clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE = double.Parse(clsDonnee.vogDataReader["IA_VALEURRESIDUELLE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBienimmobiliseamortissement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobiliseamortissement>clsBienimmobiliseamortissement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBienimmobiliseamortissement clsBienimmobiliseamortissement)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsBienimmobiliseamortissement.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsBienimmobiliseamortissement.TI_IDTIERS ;
			SqlParameter vppParamIA_DATE = new SqlParameter("@IA_DATE", SqlDbType.DateTime);
			vppParamIA_DATE.Value  = clsBienimmobiliseamortissement.IA_DATE ;
			SqlParameter vppParamIA_PERIODE = new SqlParameter("@IA_PERIODE", SqlDbType.VarChar, 25);
			vppParamIA_PERIODE.Value  = clsBienimmobiliseamortissement.IA_PERIODE ;
			if(clsBienimmobiliseamortissement.IA_PERIODE== ""  ) vppParamIA_PERIODE.Value  = DBNull.Value;
			SqlParameter vppParamIA_DOTATIONANTERIEUR = new SqlParameter("@IA_DOTATIONANTERIEUR", SqlDbType.Money);
			vppParamIA_DOTATIONANTERIEUR.Value  = clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR ;
			if(clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR== 0  ) vppParamIA_DOTATIONANTERIEUR.Value  = DBNull.Value;
			SqlParameter vppParamIA_DOTATIONEXERCICE = new SqlParameter("@IA_DOTATIONEXERCICE", SqlDbType.Money);
			vppParamIA_DOTATIONEXERCICE.Value  = clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE ;
			if(clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE== 0  ) vppParamIA_DOTATIONEXERCICE.Value  = DBNull.Value;
			SqlParameter vppParamIA_CUMUL = new SqlParameter("@IA_CUMUL", SqlDbType.Money);
			vppParamIA_CUMUL.Value  = clsBienimmobiliseamortissement.IA_CUMUL ;
			if(clsBienimmobiliseamortissement.IA_CUMUL== 0  ) vppParamIA_CUMUL.Value  = DBNull.Value;
			SqlParameter vppParamIA_VALEURRESIDUELLE = new SqlParameter("@IA_VALEURRESIDUELLE", SqlDbType.Money);
			vppParamIA_VALEURRESIDUELLE.Value  = clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE ;
			if(clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE== 0  ) vppParamIA_VALEURRESIDUELLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEAMORTISSEMENT  @AG_CODEAGENCE, @TI_IDTIERS, @IA_DATE, @IA_PERIODE, @IA_DOTATIONANTERIEUR, @IA_DOTATIONEXERCICE, @IA_CUMUL, @IA_VALEURRESIDUELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamIA_DATE);
			vppSqlCmd.Parameters.Add(vppParamIA_PERIODE);
			vppSqlCmd.Parameters.Add(vppParamIA_DOTATIONANTERIEUR);
			vppSqlCmd.Parameters.Add(vppParamIA_DOTATIONEXERCICE);
			vppSqlCmd.Parameters.Add(vppParamIA_CUMUL);
			vppSqlCmd.Parameters.Add(vppParamIA_VALEURRESIDUELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobiliseamortissement>clsBienimmobiliseamortissement</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBienimmobiliseamortissement clsBienimmobiliseamortissement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsBienimmobiliseamortissement.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsBienimmobiliseamortissement.TI_IDTIERS ;
			SqlParameter vppParamIA_DATE = new SqlParameter("@IA_DATE", SqlDbType.DateTime);
			vppParamIA_DATE.Value  = clsBienimmobiliseamortissement.IA_DATE ;
			SqlParameter vppParamIA_PERIODE = new SqlParameter("@IA_PERIODE", SqlDbType.VarChar, 25);
			vppParamIA_PERIODE.Value  = clsBienimmobiliseamortissement.IA_PERIODE ;
			if(clsBienimmobiliseamortissement.IA_PERIODE== ""  ) vppParamIA_PERIODE.Value  = DBNull.Value;
			SqlParameter vppParamIA_DOTATIONANTERIEUR = new SqlParameter("@IA_DOTATIONANTERIEUR", SqlDbType.Money);
			vppParamIA_DOTATIONANTERIEUR.Value  = clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR ;
			if(clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR== 0  ) vppParamIA_DOTATIONANTERIEUR.Value  = DBNull.Value;
			SqlParameter vppParamIA_DOTATIONEXERCICE = new SqlParameter("@IA_DOTATIONEXERCICE", SqlDbType.Money);
			vppParamIA_DOTATIONEXERCICE.Value  = clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE ;
			if(clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE== 0  ) vppParamIA_DOTATIONEXERCICE.Value  = DBNull.Value;
			SqlParameter vppParamIA_CUMUL = new SqlParameter("@IA_CUMUL", SqlDbType.Money);
			vppParamIA_CUMUL.Value  = clsBienimmobiliseamortissement.IA_CUMUL ;
			if(clsBienimmobiliseamortissement.IA_CUMUL== 0  ) vppParamIA_CUMUL.Value  = DBNull.Value;
			SqlParameter vppParamIA_VALEURRESIDUELLE = new SqlParameter("@IA_VALEURRESIDUELLE", SqlDbType.Money);
			vppParamIA_VALEURRESIDUELLE.Value  = clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE ;
			if(clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE== 0  ) vppParamIA_VALEURRESIDUELLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEAMORTISSEMENT  @AG_CODEAGENCE, @TI_IDTIERS, @IA_DATE, @IA_PERIODE, @IA_DOTATIONANTERIEUR, @IA_DOTATIONEXERCICE, @IA_CUMUL, @IA_VALEURRESIDUELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamIA_DATE);
			vppSqlCmd.Parameters.Add(vppParamIA_PERIODE);
			vppSqlCmd.Parameters.Add(vppParamIA_DOTATIONANTERIEUR);
			vppSqlCmd.Parameters.Add(vppParamIA_DOTATIONEXERCICE);
			vppSqlCmd.Parameters.Add(vppParamIA_CUMUL);
			vppSqlCmd.Parameters.Add(vppParamIA_VALEURRESIDUELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEAMORTISSEMENT  @AG_CODEAGENCE, @TI_IDTIERS, '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobiliseamortissement </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobiliseamortissement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, IA_DATE, IA_PERIODE, IA_DOTATIONANTERIEUR, IA_DOTATIONEXERCICE, IA_CUMUL, IA_VALEURRESIDUELLE FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBienimmobiliseamortissement> clsBienimmobiliseamortissements = new List<clsBienimmobiliseamortissement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobiliseamortissement clsBienimmobiliseamortissement = new clsBienimmobiliseamortissement();
					clsBienimmobiliseamortissement.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsBienimmobiliseamortissement.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsBienimmobiliseamortissement.IA_DATE = DateTime.Parse(clsDonnee.vogDataReader["IA_DATE"].ToString());
					clsBienimmobiliseamortissement.IA_PERIODE = clsDonnee.vogDataReader["IA_PERIODE"].ToString();
					clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR = double.Parse(clsDonnee.vogDataReader["IA_DOTATIONANTERIEUR"].ToString());
					clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE = double.Parse(clsDonnee.vogDataReader["IA_DOTATIONEXERCICE"].ToString());
					clsBienimmobiliseamortissement.IA_CUMUL = double.Parse(clsDonnee.vogDataReader["IA_CUMUL"].ToString());
					clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE = double.Parse(clsDonnee.vogDataReader["IA_VALEURRESIDUELLE"].ToString());
					clsBienimmobiliseamortissements.Add(clsBienimmobiliseamortissement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBienimmobiliseamortissements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobiliseamortissement </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobiliseamortissement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBienimmobiliseamortissement> clsBienimmobiliseamortissements = new List<clsBienimmobiliseamortissement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, IA_DATE, IA_PERIODE, IA_DOTATIONANTERIEUR, IA_DOTATIONEXERCICE, IA_CUMUL, IA_VALEURRESIDUELLE FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBienimmobiliseamortissement clsBienimmobiliseamortissement = new clsBienimmobiliseamortissement();
					clsBienimmobiliseamortissement.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsBienimmobiliseamortissement.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsBienimmobiliseamortissement.IA_DATE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IA_DATE"].ToString());
					clsBienimmobiliseamortissement.IA_PERIODE = Dataset.Tables["TABLE"].Rows[Idx]["IA_PERIODE"].ToString();
					clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IA_DOTATIONANTERIEUR"].ToString());
					clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IA_DOTATIONEXERCICE"].ToString());
					clsBienimmobiliseamortissement.IA_CUMUL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IA_CUMUL"].ToString());
					clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IA_VALEURRESIDUELLE"].ToString());
					clsBienimmobiliseamortissements.Add(clsBienimmobiliseamortissement);
				}
				Dataset.Dispose();
			}
		return clsBienimmobiliseamortissements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERS , IA_DATE FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboCreationCompte(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
	        this.vapRequete = "SELECT TI_IDTIERS , IA_DATE FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboImmobilisation(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
	        this.vapRequete = "SELECT TI_IDTIERS , IA_DATE FROM dbo.FT_BIENIMMOBILISEAMORTISSEMENT(@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TI_IDTIERS)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
