using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationpreferenceWSDAL: ITableDAL<clsCliconsultationpreference>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationpreference comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationpreference pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TP_CODETYPEPREFERENCE  , PR_DESCRIPTION  , OP_CODEOPERATEUR  FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationpreference clsCliconsultationpreference = new clsCliconsultationpreference();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationpreference.TP_CODETYPEPREFERENCE = clsDonnee.vogDataReader["TP_CODETYPEPREFERENCE"].ToString();
					clsCliconsultationpreference.PR_DESCRIPTION = clsDonnee.vogDataReader["PR_DESCRIPTION"].ToString();
					clsCliconsultationpreference.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationpreference;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationpreference>clsCliconsultationpreference</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationpreference clsCliconsultationpreference)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationpreference.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCliconsultationpreference.TI_IDTIERS ;
			SqlParameter vppParamPR_NUMSEQUENCE = new SqlParameter("@PR_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamPR_NUMSEQUENCE.Value  = clsCliconsultationpreference.PR_NUMSEQUENCE ;
			SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
			vppParamPR_DATESAISIE.Value  = clsCliconsultationpreference.PR_DATESAISIE ;
			SqlParameter vppParamTP_CODETYPEPREFERENCE = new SqlParameter("@TP_CODETYPEPREFERENCE", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPREFERENCE.Value  = clsCliconsultationpreference.TP_CODETYPEPREFERENCE ;
			SqlParameter vppParamPR_DESCRIPTION = new SqlParameter("@PR_DESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamPR_DESCRIPTION.Value  = clsCliconsultationpreference.PR_DESCRIPTION ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationpreference.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONPREFERENCE  @AG_CODEAGENCE, @TI_IDTIERS, @PR_NUMSEQUENCE, @PR_DATESAISIE, @TP_CODETYPEPREFERENCE, @PR_DESCRIPTION, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPREFERENCE);
			vppSqlCmd.Parameters.Add(vppParamPR_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationpreference>clsCliconsultationpreference</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationpreference clsCliconsultationpreference,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationpreference.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCliconsultationpreference.TI_IDTIERS ;
			SqlParameter vppParamPR_NUMSEQUENCE = new SqlParameter("@PR_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamPR_NUMSEQUENCE.Value  = clsCliconsultationpreference.PR_NUMSEQUENCE ;
			SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
			vppParamPR_DATESAISIE.Value  = clsCliconsultationpreference.PR_DATESAISIE ;
			SqlParameter vppParamTP_CODETYPEPREFERENCE = new SqlParameter("@TP_CODETYPEPREFERENCE", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPREFERENCE.Value  = clsCliconsultationpreference.TP_CODETYPEPREFERENCE ;
			SqlParameter vppParamPR_DESCRIPTION = new SqlParameter("@PR_DESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamPR_DESCRIPTION.Value  = clsCliconsultationpreference.PR_DESCRIPTION ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationpreference.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONPREFERENCE  @AG_CODEAGENCE, @TI_IDTIERS, @PR_NUMSEQUENCE, @PR_DATESAISIE, @TP_CODETYPEPREFERENCE, @PR_DESCRIPTION, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPREFERENCE);
			vppSqlCmd.Parameters.Add(vppParamPR_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONPREFERENCE  @AG_CODEAGENCE, @TI_IDTIERS, @PR_NUMSEQUENCE, @PR_DATESAISIE, '', '' , '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationpreference </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationpreference> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, PR_DESCRIPTION, OP_CODEOPERATEUR FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationpreference> clsCliconsultationpreferences = new List<clsCliconsultationpreference>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationpreference clsCliconsultationpreference = new clsCliconsultationpreference();
					clsCliconsultationpreference.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationpreference.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCliconsultationpreference.PR_NUMSEQUENCE = clsDonnee.vogDataReader["PR_NUMSEQUENCE"].ToString();
					clsCliconsultationpreference.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
					clsCliconsultationpreference.TP_CODETYPEPREFERENCE = clsDonnee.vogDataReader["TP_CODETYPEPREFERENCE"].ToString();
					clsCliconsultationpreference.PR_DESCRIPTION = clsDonnee.vogDataReader["PR_DESCRIPTION"].ToString();
					clsCliconsultationpreference.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationpreferences.Add(clsCliconsultationpreference);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationpreferences;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationpreference </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationpreference> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationpreference> clsCliconsultationpreferences = new List<clsCliconsultationpreference>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, PR_DESCRIPTION, OP_CODEOPERATEUR FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationpreference clsCliconsultationpreference = new clsCliconsultationpreference();
					clsCliconsultationpreference.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationpreference.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsCliconsultationpreference.PR_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["PR_NUMSEQUENCE"].ToString();
					clsCliconsultationpreference.PR_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PR_DATESAISIE"].ToString());
					clsCliconsultationpreference.TP_CODETYPEPREFERENCE = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPEPREFERENCE"].ToString();
					clsCliconsultationpreference.PR_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["PR_DESCRIPTION"].ToString();
					clsCliconsultationpreference.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationpreferences.Add(clsCliconsultationpreference);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationpreferences;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , PR_DESCRIPTION FROM dbo.FT_CLICONSULTATIONPREFERENCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TI_IDTIERS, PR_NUMSEQUENCE, PR_DATESAISIE, TP_CODETYPEPREFERENCE, OP_CODEOPERATEUR)</summary>
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
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND PR_NUMSEQUENCE=@PR_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@PR_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND PR_NUMSEQUENCE=@PR_NUMSEQUENCE AND PR_DATESAISIE=@PR_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@PR_NUMSEQUENCE","@PR_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND PR_NUMSEQUENCE=@PR_NUMSEQUENCE AND PR_DATESAISIE=@PR_DATESAISIE AND TP_CODETYPEPREFERENCE=@TP_CODETYPEPREFERENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@PR_NUMSEQUENCE","@PR_DATESAISIE","@TP_CODETYPEPREFERENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND PR_NUMSEQUENCE=@PR_NUMSEQUENCE AND PR_DATESAISIE=@PR_DATESAISIE AND TP_CODETYPEPREFERENCE=@TP_CODETYPEPREFERENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@PR_NUMSEQUENCE","@PR_DATESAISIE","@TP_CODETYPEPREFERENCE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
