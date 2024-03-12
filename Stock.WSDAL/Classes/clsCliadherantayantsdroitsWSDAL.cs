using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliadherantayantsdroitsWSDAL: ITableDAL<clsCliadherantayantsdroits>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AY_DATESAISIE) AS AY_DATESAISIE  FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AY_DATESAISIE) AS AY_DATESAISIE  FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AY_DATESAISIE) AS AY_DATESAISIE  FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliadherantayantsdroits comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliadherantayantsdroits pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , TI_IDTIERSADHERANT  , TI_IDTIERSAYANTDROIT  , AY_DATECLOTURE  , TA_CODETITREAYANTDROIT  , OP_CODEOPERATEUR  FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliadherantayantsdroits clsCliadherantayantsdroits = new clsCliadherantayantsdroits();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliadherantayantsdroits.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliadherantayantsdroits.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCliadherantayantsdroits.TI_IDTIERSADHERANT = clsDonnee.vogDataReader["TI_IDTIERSADHERANT"].ToString();
					clsCliadherantayantsdroits.TI_IDTIERSAYANTDROIT = clsDonnee.vogDataReader["TI_IDTIERSAYANTDROIT"].ToString();
					clsCliadherantayantsdroits.AY_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AY_DATECLOTURE"].ToString());
					clsCliadherantayantsdroits.TA_CODETITREAYANTDROIT = clsDonnee.vogDataReader["TA_CODETITREAYANTDROIT"].ToString();
					clsCliadherantayantsdroits.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliadherantayantsdroits;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliadherantayantsdroits>clsCliadherantayantsdroits</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliadherantayantsdroits clsCliadherantayantsdroits)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliadherantayantsdroits.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCliadherantayantsdroits.EN_CODEENTREPOT ;
			SqlParameter vppParamTI_IDTIERSADHERANT = new SqlParameter("@TI_IDTIERSADHERANT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSADHERANT.Value  = clsCliadherantayantsdroits.TI_IDTIERSADHERANT ;
			SqlParameter vppParamTI_IDTIERSAYANTDROIT = new SqlParameter("@TI_IDTIERSAYANTDROIT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSAYANTDROIT.Value  = clsCliadherantayantsdroits.TI_IDTIERSAYANTDROIT ;
			SqlParameter vppParamAY_DATESAISIE = new SqlParameter("@AY_DATESAISIE", SqlDbType.DateTime);
			vppParamAY_DATESAISIE.Value  = clsCliadherantayantsdroits.AY_DATESAISIE ;
			SqlParameter vppParamAY_DATECLOTURE = new SqlParameter("@AY_DATECLOTURE", SqlDbType.DateTime);
			vppParamAY_DATECLOTURE.Value  = clsCliadherantayantsdroits.AY_DATECLOTURE ;
			SqlParameter vppParamTA_CODETITREAYANTDROIT = new SqlParameter("@TA_CODETITREAYANTDROIT", SqlDbType.VarChar, 2);
			vppParamTA_CODETITREAYANTDROIT.Value  = clsCliadherantayantsdroits.TA_CODETITREAYANTDROIT ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCliadherantayantsdroits.OP_CODEOPERATEUR ;

            SqlParameter vppParamAY_MATRICULE = new SqlParameter("@AY_MATRICULE", SqlDbType.VarChar, 150);
            vppParamAY_MATRICULE.Value  = clsCliadherantayantsdroits.AY_MATRICULE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIADHERANTAYANTSDROITS  @AG_CODEAGENCE, @EN_CODEENTREPOT, @TI_IDTIERSADHERANT, @TI_IDTIERSAYANTDROIT, @AY_DATESAISIE, @AY_DATECLOTURE, @TA_CODETITREAYANTDROIT, @OP_CODEOPERATEUR, @AY_MATRICULE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSADHERANT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamAY_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAY_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAY_MATRICULE);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliadherantayantsdroits>clsCliadherantayantsdroits</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliadherantayantsdroits clsCliadherantayantsdroits,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliadherantayantsdroits.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCliadherantayantsdroits.EN_CODEENTREPOT ;
			SqlParameter vppParamTI_IDTIERSADHERANT = new SqlParameter("@TI_IDTIERSADHERANT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSADHERANT.Value  = clsCliadherantayantsdroits.TI_IDTIERSADHERANT ;
			SqlParameter vppParamTI_IDTIERSAYANTDROIT = new SqlParameter("@TI_IDTIERSAYANTDROIT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSAYANTDROIT.Value  = clsCliadherantayantsdroits.TI_IDTIERSAYANTDROIT ;
			SqlParameter vppParamAY_DATESAISIE = new SqlParameter("@AY_DATESAISIE", SqlDbType.DateTime);
			vppParamAY_DATESAISIE.Value  = clsCliadherantayantsdroits.AY_DATESAISIE ;
			SqlParameter vppParamAY_DATECLOTURE = new SqlParameter("@AY_DATECLOTURE", SqlDbType.DateTime);
			vppParamAY_DATECLOTURE.Value  = clsCliadherantayantsdroits.AY_DATECLOTURE ;
			SqlParameter vppParamTA_CODETITREAYANTDROIT = new SqlParameter("@TA_CODETITREAYANTDROIT", SqlDbType.VarChar, 2);
			vppParamTA_CODETITREAYANTDROIT.Value  = clsCliadherantayantsdroits.TA_CODETITREAYANTDROIT ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCliadherantayantsdroits.OP_CODEOPERATEUR ;

			SqlParameter vppParamAY_MATRICULE = new SqlParameter("@AY_MATRICULE", SqlDbType.VarChar, 50);
            vppParamAY_MATRICULE.Value  = clsCliadherantayantsdroits.AY_MATRICULE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIADHERANTAYANTSDROITS  @AG_CODEAGENCE, @EN_CODEENTREPOT, @TI_IDTIERSADHERANT, @TI_IDTIERSAYANTDROIT, @AY_DATESAISIE, @AY_DATECLOTURE, @TA_CODETITREAYANTDROIT, @OP_CODEOPERATEUR,@AY_MATRICULE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSADHERANT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamAY_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAY_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAY_MATRICULE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIADHERANTAYANTSDROITS  @AG_CODEAGENCE, @EN_CODEENTREPOT, @TI_IDTIERSADHERANT, @TI_IDTIERSAYANTDROIT,'', '' , '' , '','', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliadherantayantsdroits </returns>
		///<author>Home Technology</author>
		public List<clsCliadherantayantsdroits> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, AY_DATECLOTURE, TA_CODETITREAYANTDROIT, OP_CODEOPERATEUR FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliadherantayantsdroits> clsCliadherantayantsdroitss = new List<clsCliadherantayantsdroits>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliadherantayantsdroits clsCliadherantayantsdroits = new clsCliadherantayantsdroits();
					clsCliadherantayantsdroits.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliadherantayantsdroits.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCliadherantayantsdroits.TI_IDTIERSADHERANT = clsDonnee.vogDataReader["TI_IDTIERSADHERANT"].ToString();
					clsCliadherantayantsdroits.TI_IDTIERSAYANTDROIT = clsDonnee.vogDataReader["TI_IDTIERSAYANTDROIT"].ToString();
					clsCliadherantayantsdroits.AY_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["AY_DATESAISIE"].ToString());
					clsCliadherantayantsdroits.AY_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AY_DATECLOTURE"].ToString());
					clsCliadherantayantsdroits.TA_CODETITREAYANTDROIT = clsDonnee.vogDataReader["TA_CODETITREAYANTDROIT"].ToString();
					clsCliadherantayantsdroits.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliadherantayantsdroitss.Add(clsCliadherantayantsdroits);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliadherantayantsdroitss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliadherantayantsdroits </returns>
		///<author>Home Technology</author>
		public List<clsCliadherantayantsdroits> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliadherantayantsdroits> clsCliadherantayantsdroitss = new List<clsCliadherantayantsdroits>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, AY_DATECLOTURE, TA_CODETITREAYANTDROIT, OP_CODEOPERATEUR FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliadherantayantsdroits clsCliadherantayantsdroits = new clsCliadherantayantsdroits();
					clsCliadherantayantsdroits.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliadherantayantsdroits.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCliadherantayantsdroits.TI_IDTIERSADHERANT = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSADHERANT"].ToString();
					clsCliadherantayantsdroits.TI_IDTIERSAYANTDROIT = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSAYANTDROIT"].ToString();
					clsCliadherantayantsdroits.AY_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AY_DATESAISIE"].ToString());
					clsCliadherantayantsdroits.AY_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AY_DATECLOTURE"].ToString());
					clsCliadherantayantsdroits.TA_CODETITREAYANTDROIT = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETITREAYANTDROIT"].ToString();
					clsCliadherantayantsdroits.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliadherantayantsdroitss.Add(clsCliadherantayantsdroits);
				}
				Dataset.Dispose();
			}
		return clsCliadherantayantsdroitss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_IDTIERSADHERANT", "@AS_DATESAISIE1", "@AS_DATESAISIE2", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC [dbo].[PS_CLIADHERANTAYANTSDROITS] @AG_CODEAGENCE,@EN_CODEENTREPOT,@TI_IDTIERSADHERANT,@AS_DATESAISIE1,@AS_DATESAISIE2,@TYPEOPERATION, @CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AY_DATESAISIE , AY_DATECLOTURE FROM dbo.FT_CLIADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, TI_IDTIERSAYANTDROIT, AY_DATESAISIE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@TI_IDTIERSADHERANT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT AND TI_IDTIERSAYANTDROIT=@TI_IDTIERSAYANTDROIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@TI_IDTIERSADHERANT","@TI_IDTIERSAYANTDROIT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT AND TI_IDTIERSAYANTDROIT=@TI_IDTIERSAYANTDROIT AND AY_DATESAISIE=@AY_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@TI_IDTIERSADHERANT","@TI_IDTIERSAYANTDROIT","@AY_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT AND TI_IDTIERSAYANTDROIT=@TI_IDTIERSAYANTDROIT AND AY_DATESAISIE=@AY_DATESAISIE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@TI_IDTIERSADHERANT","@TI_IDTIERSAYANTDROIT","@AY_DATESAISIE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
