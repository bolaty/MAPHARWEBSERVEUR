using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMiccomptewebmotpasseoublieWSDAL: ITableDAL<clsMiccomptewebmotpasseoublie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMiccomptewebmotpasseoublie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMiccomptewebmotpasseoublie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERS  , MB_IDTIERS  , OP_CODEOPERATEUR  , RP_CODEVALIDATION  , RP_HEURE  , RP_EMAIL  , RP_DATECLOTURE  FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMiccomptewebmotpasseoublie.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsMiccomptewebmotpasseoublie.MB_IDTIERS = clsDonnee.vogDataReader["MB_IDTIERS"].ToString();
					clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsDonnee.vogDataReader["RP_CODEVALIDATION"].ToString();
					clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse(clsDonnee.vogDataReader["RP_HEURE"].ToString());
					clsMiccomptewebmotpasseoublie.RP_EMAIL = clsDonnee.vogDataReader["RP_EMAIL"].ToString();
					clsMiccomptewebmotpasseoublie.RP_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["RP_DATECLOTURE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMiccomptewebmotpasseoublie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMiccomptewebmotpasseoublie>clsMiccomptewebmotpasseoublie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsMiccomptewebmotpasseoublie.AG_CODEAGENCE ;
			SqlParameter vppParamRP_DATE = new SqlParameter("@RP_DATE", SqlDbType.DateTime);
			vppParamRP_DATE.Value  = clsMiccomptewebmotpasseoublie.RP_DATE ;
			SqlParameter vppParamRP_NUMSEQUENCE = new SqlParameter("@RP_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRP_NUMSEQUENCE.Value  = clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsMiccomptewebmotpasseoublie.TI_IDTIERS ;
			if(clsMiccomptewebmotpasseoublie.TI_IDTIERS== ""  ) vppParamTI_IDTIERS.Value  = DBNull.Value;
			SqlParameter vppParamMB_IDTIERS = new SqlParameter("@MB_IDTIERS", SqlDbType.VarChar, 50);
			vppParamMB_IDTIERS.Value  = clsMiccomptewebmotpasseoublie.MB_IDTIERS ;
			if(clsMiccomptewebmotpasseoublie.MB_IDTIERS== ""  ) vppParamMB_IDTIERS.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR ;
			if(clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR== ""  ) vppParamOP_CODEOPERATEUR.Value  = DBNull.Value;
			SqlParameter vppParamRP_CODEVALIDATION = new SqlParameter("@RP_CODEVALIDATION", SqlDbType.VarChar, 1000);
			vppParamRP_CODEVALIDATION.Value  = clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION ;
			SqlParameter vppParamRP_HEURE = new SqlParameter("@RP_HEURE", SqlDbType.DateTime);
			vppParamRP_HEURE.Value  = clsMiccomptewebmotpasseoublie.RP_HEURE ;
			SqlParameter vppParamRP_EMAIL = new SqlParameter("@RP_EMAIL", SqlDbType.VarChar, 1000);
			vppParamRP_EMAIL.Value  = clsMiccomptewebmotpasseoublie.RP_EMAIL ;
			SqlParameter vppParamRP_DATECLOTURE = new SqlParameter("@RP_DATECLOTURE", SqlDbType.DateTime);
			vppParamRP_DATECLOTURE.Value  = clsMiccomptewebmotpasseoublie.RP_DATECLOTURE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_Miccomptewebmotpasseoublie  @AG_CODEAGENCE, @RP_DATE, @RP_NUMSEQUENCE, @TI_IDTIERS, @MB_IDTIERS, @OP_CODEOPERATEUR, @RP_CODEVALIDATION, @RP_HEURE, @RP_EMAIL, @RP_DATECLOTURE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRP_DATE);
			vppSqlCmd.Parameters.Add(vppParamRP_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamMB_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamRP_CODEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamRP_HEURE);
			vppSqlCmd.Parameters.Add(vppParamRP_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamRP_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMiccomptewebmotpasseoublie>clsMiccomptewebmotpasseoublie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsMiccomptewebmotpasseoublie.AG_CODEAGENCE ;
			SqlParameter vppParamRP_DATE = new SqlParameter("@RP_DATE", SqlDbType.DateTime);
			vppParamRP_DATE.Value  = clsMiccomptewebmotpasseoublie.RP_DATE ;
			SqlParameter vppParamRP_NUMSEQUENCE = new SqlParameter("@RP_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRP_NUMSEQUENCE.Value  = clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsMiccomptewebmotpasseoublie.TI_IDTIERS ;
			if(clsMiccomptewebmotpasseoublie.TI_IDTIERS== ""  ) vppParamTI_IDTIERS.Value  = DBNull.Value;
			SqlParameter vppParamMB_IDTIERS = new SqlParameter("@MB_IDTIERS", SqlDbType.VarChar, 50);
			vppParamMB_IDTIERS.Value  = clsMiccomptewebmotpasseoublie.MB_IDTIERS ;
			if(clsMiccomptewebmotpasseoublie.MB_IDTIERS== ""  ) vppParamMB_IDTIERS.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR ;
			if(clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR== ""  ) vppParamOP_CODEOPERATEUR.Value  = DBNull.Value;
			SqlParameter vppParamRP_CODEVALIDATION = new SqlParameter("@RP_CODEVALIDATION", SqlDbType.VarChar, 1000);
			vppParamRP_CODEVALIDATION.Value  = clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION ;
			SqlParameter vppParamRP_HEURE = new SqlParameter("@RP_HEURE", SqlDbType.DateTime);
			vppParamRP_HEURE.Value  = clsMiccomptewebmotpasseoublie.RP_HEURE ;
			SqlParameter vppParamRP_EMAIL = new SqlParameter("@RP_EMAIL", SqlDbType.VarChar, 1000);
			vppParamRP_EMAIL.Value  = clsMiccomptewebmotpasseoublie.RP_EMAIL ;
			SqlParameter vppParamRP_DATECLOTURE = new SqlParameter("@RP_DATECLOTURE", SqlDbType.DateTime);
			vppParamRP_DATECLOTURE.Value  = clsMiccomptewebmotpasseoublie.RP_DATECLOTURE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_Miccomptewebmotpasseoublie  @AG_CODEAGENCE, @RP_DATE, @RP_NUMSEQUENCE, @TI_IDTIERS, @MB_IDTIERS, @OP_CODEOPERATEUR, @RP_CODEVALIDATION, @RP_HEURE, @RP_EMAIL, @RP_DATECLOTURE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRP_DATE);
			vppSqlCmd.Parameters.Add(vppParamRP_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamMB_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamRP_CODEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamRP_HEURE);
			vppSqlCmd.Parameters.Add(vppParamRP_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamRP_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_Miccomptewebmotpasseoublie  @AG_CODEAGENCE, @RP_DATE, @RP_NUMSEQUENCE, '' , @MB_IDTIERS, @OP_CODEOPERATEUR, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMiccomptewebmotpasseoublie </returns>
		///<author>Home Technology</author>
		public List<clsMiccomptewebmotpasseoublie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, TI_IDTIERS, MB_IDTIERS, OP_CODEOPERATEUR, RP_CODEVALIDATION, RP_HEURE, RP_EMAIL, RP_DATECLOTURE FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<clsMiccomptewebmotpasseoublie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
					clsMiccomptewebmotpasseoublie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse(clsDonnee.vogDataReader["RP_DATE"].ToString());
					clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = clsDonnee.vogDataReader["RP_NUMSEQUENCE"].ToString();
					clsMiccomptewebmotpasseoublie.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsMiccomptewebmotpasseoublie.MB_IDTIERS = clsDonnee.vogDataReader["MB_IDTIERS"].ToString();
					clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = clsDonnee.vogDataReader["RP_CODEVALIDATION"].ToString();
					clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse(clsDonnee.vogDataReader["RP_HEURE"].ToString());
					clsMiccomptewebmotpasseoublie.RP_EMAIL = clsDonnee.vogDataReader["RP_EMAIL"].ToString();
					clsMiccomptewebmotpasseoublie.RP_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["RP_DATECLOTURE"].ToString());
					clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMiccomptewebmotpasseoublies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMiccomptewebmotpasseoublie </returns>
		///<author>Home Technology</author>
		public List<clsMiccomptewebmotpasseoublie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<clsMiccomptewebmotpasseoublie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, TI_IDTIERS, MB_IDTIERS, OP_CODEOPERATEUR, RP_CODEVALIDATION, RP_HEURE, RP_EMAIL, RP_DATECLOTURE FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
					clsMiccomptewebmotpasseoublie.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_DATE"].ToString());
					clsMiccomptewebmotpasseoublie.RP_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["RP_NUMSEQUENCE"].ToString();
					clsMiccomptewebmotpasseoublie.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsMiccomptewebmotpasseoublie.MB_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["MB_IDTIERS"].ToString();
					clsMiccomptewebmotpasseoublie.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = Dataset.Tables["TABLE"].Rows[Idx]["RP_CODEVALIDATION"].ToString();
					clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_HEURE"].ToString());
					clsMiccomptewebmotpasseoublie.RP_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["RP_EMAIL"].ToString();
					clsMiccomptewebmotpasseoublie.RP_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_DATECLOTURE"].ToString());
					clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
				}
				Dataset.Dispose();
			}
		return clsMiccomptewebmotpasseoublies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , TI_IDTIERS FROM dbo.FT_Miccomptewebmotpasseoublie(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebmotpasseoublie> pvgSelectDataSetUserForgotPassword(clsDonnee clsDonnee, string LG_CODELANGUE, string CL_CONTACT, string CL_CODECLIENT, string TYPEOPERATION)
        {
            List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<clsMiccomptewebmotpasseoublie>();
            DataSet Dataset = new DataSet();

            //pvpChoixCritere(clsDonnee, vppCritere);

            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@LG_CODELANGUE", "@CL_CONTACT", "@CL_CODECLIENT", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, LG_CODELANGUE, CL_CONTACT, CL_CODECLIENT, TYPEOPERATION };

            this.vapRequete = "EXEC PS_USERFORGOTPASSWORD @LG_CODELANGUE, @CL_CONTACT, @CL_CODECLIENT,@TYPEOPERATION,@CODECRYPTAGE "; //+ this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
                    clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
                    clsMiccomptewebmotpasseoublie.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebmotpasseoublie.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
                    //clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_DATE"].ToString()).ToShortDateString().Replace("/", "-");
                    clsMiccomptewebmotpasseoublie.RP_DATE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_DATE"].ToString());
                    clsMiccomptewebmotpasseoublie.RP_CODEVALIDATION = Dataset.Tables["TABLE"].Rows[Idx]["RP_CODEVALIDATION"].ToString();
                    clsMiccomptewebmotpasseoublie.RP_HEURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_HEURE"].ToString());
                    clsMiccomptewebmotpasseoublie.SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
                    clsMiccomptewebmotpasseoublie.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
                    clsMiccomptewebmotpasseoublie.SL_MESSAGEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGEOBJET"].ToString();
                    clsMiccomptewebmotpasseoublie.AG_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["AG_EMAIL"].ToString();
                    clsMiccomptewebmotpasseoublie.AG_EMAILMOTDEPASSE = Dataset.Tables["TABLE"].Rows[Idx]["AG_EMAILMOTDEPASSE"].ToString();
                    clsMiccomptewebmotpasseoublie.SL_MESSAGECLIENT = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGECLIENT"].ToString();
                    //clsMiccomptewebmotpasseoublie.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
                    clsMiccomptewebmotpasseoublie.OB_NOMOBJET = "FrmOperateur";// Dataset.Tables["TABLE"].Rows[Idx]["OB_NOMOBJET"].ToString();
                   // clsMiccomptewebmotpasseoublie.CO_CODECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMPTE"].ToString();


                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);

                }
                Dataset.Dispose();
            }
            return clsMiccomptewebmotpasseoublies;
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebUserNewPassword> pvgUserUpdatePassword(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW)
        {
            List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswords = new List<clsMiccomptewebUserNewPassword>();
            DataSet Dataset = new DataSet();

            //pvpChoixCritere(clsDonnee, vppCritere);

            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@LG_CODELANGUE", "@SL_MOTPASSEOLD", "@SL_LOGINOLD", "@SL_MOTPASSENEW", "@SL_LOGINNEW" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW };

            this.vapRequete = "EXEC PS_USERUPDATEPASSWORDOPERATEUR @LG_CODELANGUE , @SL_MOTPASSEOLD , @SL_LOGINOLD, @SL_MOTPASSENEW,@SL_LOGINNEW,@CODECRYPTAGE "; //+ this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
                    clsMiccomptewebUserNewPassword.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsMiccomptewebUserNewPassword.AG_RAISONSOCIAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_RAISONSOCIAL"].ToString();
                    clsMiccomptewebUserNewPassword.AG_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["AG_TELEPHONE"].ToString();
                    clsMiccomptewebUserNewPassword.AG_BOITEPOSTAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_BOITEPOSTAL"].ToString();
                    clsMiccomptewebUserNewPassword.CL_IDCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["CL_NOMCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CL_TELEPHONE"].ToString();
                    clsMiccomptewebUserNewPassword.OP_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CL_EMAIL"].ToString();
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
                    clsMiccomptewebUserNewPassword.SL_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["SL_LOGIN"].ToString();
                    clsMiccomptewebUserNewPassword.SL_MOTPASSE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MOTPASSE"].ToString();
                    clsMiccomptewebUserNewPasswords.Add(clsMiccomptewebUserNewPassword);
                }
                Dataset.Dispose();
            }
            return clsMiccomptewebUserNewPasswords;
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebUserNewPassword> pvgUserUpdatePasswordClient(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW)
        {
            List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswords = new List<clsMiccomptewebUserNewPassword>();
            DataSet Dataset = new DataSet();

            //pvpChoixCritere(clsDonnee, vppCritere);

            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@LG_CODELANGUE", "@SL_MOTPASSEOLD", "@SL_LOGINOLD", "@SL_MOTPASSENEW", "@SL_LOGINNEW" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW };

            this.vapRequete = "EXEC PS_USERUPDATEPASSWORD @LG_CODELANGUE , @SL_MOTPASSEOLD , @SL_LOGINOLD, @SL_MOTPASSENEW,@SL_LOGINNEW,@CODECRYPTAGE "; //+ this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
                    clsMiccomptewebUserNewPassword.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsMiccomptewebUserNewPassword.AG_RAISONSOCIAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_RAISONSOCIAL"].ToString();
                    clsMiccomptewebUserNewPassword.AG_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["AG_TELEPHONE"].ToString();
                    clsMiccomptewebUserNewPassword.AG_BOITEPOSTAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_BOITEPOSTAL"].ToString();
                    clsMiccomptewebUserNewPassword.CL_IDCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["CL_NOMCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CL_TELEPHONE"].ToString();
                    clsMiccomptewebUserNewPassword.OP_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CL_EMAIL"].ToString();
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
                    clsMiccomptewebUserNewPassword.SL_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["SL_LOGIN"].ToString();
                    clsMiccomptewebUserNewPassword.SL_MOTPASSE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MOTPASSE"].ToString();
                    clsMiccomptewebUserNewPasswords.Add(clsMiccomptewebUserNewPassword);
                }
                Dataset.Dispose();
            }
            return clsMiccomptewebUserNewPasswords;
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTETontineMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTontineweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebUserNewPassword> pvgUserNewPassword(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSE, string RP_CODEVALIDATION, string RP_DATE, string RP_HEURE, string TYPEOPERATION)
        {
            List<clsMiccomptewebUserNewPassword> clsMiccomptewebUserNewPasswords = new List<clsMiccomptewebUserNewPassword>();
            DataSet Dataset = new DataSet();
            RP_DATE = RP_DATE.Replace("-", "/");

            //pvpChoixCritere(clsDonnee, vppCritere);

            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";


            if (TYPEOPERATION == "01")//--client
            {
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@SL_MOTPASSE ", "@RP_CODEVALIDATION", "@RP_DATE", "@RP_HEURE", "@SL_LOGIN" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, SL_MOTPASSE, RP_CODEVALIDATION, RP_DATE, RP_HEURE, "" };
                this.vapRequete = "EXEC PS_USERNEWPASSWORD  @SL_MOTPASSE , @RP_CODEVALIDATION, @RP_DATE,@RP_HEURE,@SL_LOGIN,@CODECRYPTAGE "; //+ this.vapCritere;
            }


            if (TYPEOPERATION == "02")//--Opérateur
            {
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@LG_CODELANGUE ", "@SL_MOTPASSE ", "@RP_CODEVALIDATION", "@RP_DATE", "@RP_HEURE", "@SL_LOGIN" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, LG_CODELANGUE, SL_MOTPASSE, RP_CODEVALIDATION, RP_DATE, RP_HEURE, "" };

                this.vapRequete = "EXEC PS_USERNEWPASSWORDOPERATEUR @LG_CODELANGUE , @SL_MOTPASSE , @RP_CODEVALIDATION, @RP_DATE,@RP_HEURE,@SL_LOGIN,@CODECRYPTAGE "; //+ this.vapCritere;
            }
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword = new clsMiccomptewebUserNewPassword();
                    clsMiccomptewebUserNewPassword.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsMiccomptewebUserNewPassword.AG_RAISONSOCIAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_RAISONSOCIAL"].ToString();
                    clsMiccomptewebUserNewPassword.AG_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["AG_TELEPHONE"].ToString();
                    clsMiccomptewebUserNewPassword.AG_BOITEPOSTAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_BOITEPOSTAL"].ToString();
                    clsMiccomptewebUserNewPassword.CL_IDCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["CL_NOMCLIENT"].ToString();
                    clsMiccomptewebUserNewPassword.OP_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CL_TELEPHONE"].ToString();
                    clsMiccomptewebUserNewPassword.OP_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CL_EMAIL"].ToString();
                    clsMiccomptewebUserNewPassword.SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
                    clsMiccomptewebUserNewPassword.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
                    clsMiccomptewebUserNewPassword.SL_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["SL_LOGIN"].ToString();
                    clsMiccomptewebUserNewPassword.SL_MOTPASSE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MOTPASSE"].ToString();
                    clsMiccomptewebUserNewPasswords.Add(clsMiccomptewebUserNewPassword);
                }
                Dataset.Dispose();
            }
            return clsMiccomptewebUserNewPasswords;
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RP_DATE=@RP_DATE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@RP_DATE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RP_DATE=@RP_DATE AND RP_NUMSEQUENCE=@RP_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@RP_DATE","@RP_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RP_DATE=@RP_DATE AND RP_NUMSEQUENCE=@RP_NUMSEQUENCE AND MB_IDTIERS=@MB_IDTIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@RP_DATE","@RP_NUMSEQUENCE","@MB_IDTIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RP_DATE=@RP_DATE AND RP_NUMSEQUENCE=@RP_NUMSEQUENCE AND MB_IDTIERS=@MB_IDTIERS AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@RP_DATE","@RP_NUMSEQUENCE","@MB_IDTIERS","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
