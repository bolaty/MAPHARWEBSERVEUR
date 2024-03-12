using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationresultatWSDAL: ITableDAL<clsCliconsultationresultat>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationresultat comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationresultat pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE  , PA_CODEPATHOLOGIE  , RE_DATERESULTAT  , RE_VALEURRESULTAT  FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationresultat clsCliconsultationresultat = new clsCliconsultationresultat();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationresultat.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsCliconsultationresultat.PA_CODEPATHOLOGIE = clsDonnee.vogDataReader["PA_CODEPATHOLOGIE"].ToString();
					clsCliconsultationresultat.RE_DATERESULTAT = DateTime.Parse(clsDonnee.vogDataReader["RE_DATERESULTAT"].ToString());
					clsCliconsultationresultat.RE_VALEURRESULTAT = clsDonnee.vogDataReader["RE_VALEURRESULTAT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationresultat;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationresultat>clsCliconsultationresultat</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationresultat clsCliconsultationresultat)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationresultat.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationresultat.CO_CODECONSULTATION ;
			SqlParameter vppParamRE_NUMSEQUENCE = new SqlParameter("@RE_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRE_NUMSEQUENCE.Value  = clsCliconsultationresultat.RE_NUMSEQUENCE ;
			SqlParameter vppParamRE_DATESAISIE = new SqlParameter("@RE_DATESAISIE", SqlDbType.DateTime);
			vppParamRE_DATESAISIE.Value  = clsCliconsultationresultat.RE_DATESAISIE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsCliconsultationresultat.AR_CODEARTICLE ;

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationresultat.OP_CODEOPERATEUR;

			SqlParameter vppParamPA_CODEPATHOLOGIE = new SqlParameter("@PA_CODEPATHOLOGIE", SqlDbType.VarChar, 25);
			vppParamPA_CODEPATHOLOGIE.Value  = clsCliconsultationresultat.PA_CODEPATHOLOGIE ;
			SqlParameter vppParamRE_DATERESULTAT = new SqlParameter("@RE_DATERESULTAT", SqlDbType.DateTime);
			vppParamRE_DATERESULTAT.Value  = clsCliconsultationresultat.RE_DATERESULTAT ;
			SqlParameter vppParamRE_VALEURRESULTAT = new SqlParameter("@RE_VALEURRESULTAT", SqlDbType.VarChar, 1000);
			vppParamRE_VALEURRESULTAT.Value  = clsCliconsultationresultat.RE_VALEURRESULTAT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONRESULTAT  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RE_NUMSEQUENCE, @RE_DATESAISIE, @AR_CODEARTICLE,@OP_CODEOPERATEUR, @PA_CODEPATHOLOGIE, @RE_DATERESULTAT, @RE_VALEURRESULTAT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamRE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPATHOLOGIE);
			vppSqlCmd.Parameters.Add(vppParamRE_DATERESULTAT);
			vppSqlCmd.Parameters.Add(vppParamRE_VALEURRESULTAT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationresultat>clsCliconsultationresultat</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationresultat clsCliconsultationresultat,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationresultat.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationresultat.CO_CODECONSULTATION ;
			SqlParameter vppParamRE_NUMSEQUENCE = new SqlParameter("@RE_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRE_NUMSEQUENCE.Value  = clsCliconsultationresultat.RE_NUMSEQUENCE ;
			SqlParameter vppParamRE_DATESAISIE = new SqlParameter("@RE_DATESAISIE", SqlDbType.DateTime);
			vppParamRE_DATESAISIE.Value  = clsCliconsultationresultat.RE_DATESAISIE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsCliconsultationresultat.AR_CODEARTICLE ;

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationresultat.OP_CODEOPERATEUR;

			SqlParameter vppParamPA_CODEPATHOLOGIE = new SqlParameter("@PA_CODEPATHOLOGIE", SqlDbType.VarChar, 25);
			vppParamPA_CODEPATHOLOGIE.Value  = clsCliconsultationresultat.PA_CODEPATHOLOGIE ;
			SqlParameter vppParamRE_DATERESULTAT = new SqlParameter("@RE_DATERESULTAT", SqlDbType.DateTime);
			vppParamRE_DATERESULTAT.Value  = clsCliconsultationresultat.RE_DATERESULTAT ;
			SqlParameter vppParamRE_VALEURRESULTAT = new SqlParameter("@RE_VALEURRESULTAT", SqlDbType.VarChar, 1000);
			vppParamRE_VALEURRESULTAT.Value  = clsCliconsultationresultat.RE_VALEURRESULTAT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONRESULTAT  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RE_NUMSEQUENCE, @RE_DATESAISIE, @AR_CODEARTICLE,@OP_CODEOPERATEUR, @PA_CODEPATHOLOGIE, @RE_DATERESULTAT, @RE_VALEURRESULTAT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamRE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPATHOLOGIE);
			vppSqlCmd.Parameters.Add(vppParamRE_DATERESULTAT);
			vppSqlCmd.Parameters.Add(vppParamRE_VALEURRESULTAT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONRESULTAT  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RE_NUMSEQUENCE, @RE_DATESAISIE, '' , '' ,'' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationresultat </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationresultat> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, AR_CODEARTICLE,OP_CODEOPERATEUR, PA_CODEPATHOLOGIE, RE_DATERESULTAT, RE_VALEURRESULTAT FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationresultat> clsCliconsultationresultats = new List<clsCliconsultationresultat>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationresultat clsCliconsultationresultat = new clsCliconsultationresultat();
					clsCliconsultationresultat.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationresultat.CO_CODECONSULTATION = clsDonnee.vogDataReader["CO_CODECONSULTATION"].ToString();
					clsCliconsultationresultat.RE_NUMSEQUENCE = clsDonnee.vogDataReader["RE_NUMSEQUENCE"].ToString();
					clsCliconsultationresultat.RE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RE_DATESAISIE"].ToString());
					clsCliconsultationresultat.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsCliconsultationresultat.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationresultat.PA_CODEPATHOLOGIE = clsDonnee.vogDataReader["PA_CODEPATHOLOGIE"].ToString();
					clsCliconsultationresultat.RE_DATERESULTAT = DateTime.Parse(clsDonnee.vogDataReader["RE_DATERESULTAT"].ToString());
					clsCliconsultationresultat.RE_VALEURRESULTAT = clsDonnee.vogDataReader["RE_VALEURRESULTAT"].ToString();
					clsCliconsultationresultats.Add(clsCliconsultationresultat);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationresultats;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationresultat </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationresultat> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationresultat> clsCliconsultationresultats = new List<clsCliconsultationresultat>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, AR_CODEARTICLE,OP_CODEOPERATEUR, PA_CODEPATHOLOGIE, RE_DATERESULTAT, RE_VALEURRESULTAT FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationresultat clsCliconsultationresultat = new clsCliconsultationresultat();
					clsCliconsultationresultat.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationresultat.CO_CODECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION"].ToString();
					clsCliconsultationresultat.RE_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["RE_NUMSEQUENCE"].ToString();
					clsCliconsultationresultat.RE_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RE_DATESAISIE"].ToString());
					clsCliconsultationresultat.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
                    clsCliconsultationresultat.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationresultat.PA_CODEPATHOLOGIE = Dataset.Tables["TABLE"].Rows[Idx]["PA_CODEPATHOLOGIE"].ToString();
					clsCliconsultationresultat.RE_DATERESULTAT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RE_DATERESULTAT"].ToString());
					clsCliconsultationresultat.RE_VALEURRESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["RE_VALEURRESULTAT"].ToString();
					clsCliconsultationresultats.Add(clsCliconsultationresultat);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationresultats;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , AR_CODEARTICLE FROM dbo.FT_CLICONSULTATIONRESULTAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RE_NUMSEQUENCE=@RE_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RE_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RE_NUMSEQUENCE=@RE_NUMSEQUENCE AND RE_DATESAISIE=@RE_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RE_NUMSEQUENCE","@RE_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
