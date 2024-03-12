using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationantecedantWSDAL: ITableDAL<clsCliconsultationantecedant>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationantecedant comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationantecedant pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETYPEANTECEDANT  , PA_CODEPATHOLOGIE  , OP_CODEOPERATEUR  , AT_DESCRIPTION  FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationantecedant clsCliconsultationantecedant = new clsCliconsultationantecedant();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationantecedant.TA_CODETYPEANTECEDANT = clsDonnee.vogDataReader["TA_CODETYPEANTECEDANT"].ToString();
					clsCliconsultationantecedant.PA_CODEPATHOLOGIE = clsDonnee.vogDataReader["PA_CODEPATHOLOGIE"].ToString();
					clsCliconsultationantecedant.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationantecedant.AT_DESCRIPTION = clsDonnee.vogDataReader["AT_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationantecedant;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationantecedant>clsCliconsultationantecedant</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationantecedant clsCliconsultationantecedant)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationantecedant.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCliconsultationantecedant.TI_IDTIERS ;
			SqlParameter vppParamAT_NUMSEQUENCE = new SqlParameter("@AT_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamAT_NUMSEQUENCE.Value  = clsCliconsultationantecedant.AT_NUMSEQUENCE ;
			SqlParameter vppParamAT_DATESAISIE = new SqlParameter("@AT_DATESAISIE", SqlDbType.DateTime);
			vppParamAT_DATESAISIE.Value  = clsCliconsultationantecedant.AT_DATESAISIE ;

            SqlParameter vppParamAT_DATEANTECEDANT = new SqlParameter("@AT_DATEANTECEDANT", SqlDbType.DateTime);
            vppParamAT_DATEANTECEDANT.Value  = clsCliconsultationantecedant.AT_DATEANTECEDANT;

			SqlParameter vppParamTA_CODETYPEANTECEDANT = new SqlParameter("@TA_CODETYPEANTECEDANT", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPEANTECEDANT.Value  = clsCliconsultationantecedant.TA_CODETYPEANTECEDANT ;
			SqlParameter vppParamPA_CODEPATHOLOGIE = new SqlParameter("@PA_CODEPATHOLOGIE", SqlDbType.VarChar, 25);
			vppParamPA_CODEPATHOLOGIE.Value  = clsCliconsultationantecedant.PA_CODEPATHOLOGIE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationantecedant.OP_CODEOPERATEUR ;
			SqlParameter vppParamAT_DESCRIPTION = new SqlParameter("@AT_DESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamAT_DESCRIPTION.Value  = clsCliconsultationantecedant.AT_DESCRIPTION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONANTECEDANT  @AG_CODEAGENCE, @TI_IDTIERS, @AT_NUMSEQUENCE, @AT_DATESAISIE,@AT_DATEANTECEDANT, @TA_CODETYPEANTECEDANT, @PA_CODEPATHOLOGIE, @OP_CODEOPERATEUR, @AT_DESCRIPTION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAT_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPATHOLOGIE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAT_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationantecedant>clsCliconsultationantecedant</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationantecedant clsCliconsultationantecedant,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationantecedant.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCliconsultationantecedant.TI_IDTIERS ;
			SqlParameter vppParamAT_NUMSEQUENCE = new SqlParameter("@AT_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamAT_NUMSEQUENCE.Value  = clsCliconsultationantecedant.AT_NUMSEQUENCE ;
			SqlParameter vppParamAT_DATESAISIE = new SqlParameter("@AT_DATESAISIE", SqlDbType.DateTime);
			vppParamAT_DATESAISIE.Value  = clsCliconsultationantecedant.AT_DATESAISIE ;

            SqlParameter vppParamAT_DATEANTECEDANT = new SqlParameter("@AT_DATEANTECEDANT", SqlDbType.DateTime);
            vppParamAT_DATEANTECEDANT.Value  = clsCliconsultationantecedant.AT_DATEANTECEDANT;

			SqlParameter vppParamTA_CODETYPEANTECEDANT = new SqlParameter("@TA_CODETYPEANTECEDANT", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPEANTECEDANT.Value  = clsCliconsultationantecedant.TA_CODETYPEANTECEDANT ;
			SqlParameter vppParamPA_CODEPATHOLOGIE = new SqlParameter("@PA_CODEPATHOLOGIE", SqlDbType.VarChar, 25);
			vppParamPA_CODEPATHOLOGIE.Value  = clsCliconsultationantecedant.PA_CODEPATHOLOGIE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationantecedant.OP_CODEOPERATEUR ;
			SqlParameter vppParamAT_DESCRIPTION = new SqlParameter("@AT_DESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamAT_DESCRIPTION.Value  = clsCliconsultationantecedant.AT_DESCRIPTION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONANTECEDANT  @AG_CODEAGENCE, @TI_IDTIERS, @AT_NUMSEQUENCE, @AT_DATESAISIE, @AT_DATEANTECEDANT, @TA_CODETYPEANTECEDANT, @PA_CODEPATHOLOGIE, @OP_CODEOPERATEUR, @AT_DESCRIPTION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAT_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEANTECEDANT);
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPATHOLOGIE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAT_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONANTECEDANT  @AG_CODEAGENCE, @TI_IDTIERS, @AT_NUMSEQUENCE, @AT_DATESAISIE, '01/01/1900', '', '' , '', '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationantecedant </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationantecedant> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, PA_CODEPATHOLOGIE, OP_CODEOPERATEUR, AT_DESCRIPTION FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationantecedant> clsCliconsultationantecedants = new List<clsCliconsultationantecedant>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationantecedant clsCliconsultationantecedant = new clsCliconsultationantecedant();
					clsCliconsultationantecedant.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationantecedant.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCliconsultationantecedant.AT_NUMSEQUENCE = clsDonnee.vogDataReader["AT_NUMSEQUENCE"].ToString();
					clsCliconsultationantecedant.AT_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATESAISIE"].ToString());
					clsCliconsultationantecedant.TA_CODETYPEANTECEDANT = clsDonnee.vogDataReader["TA_CODETYPEANTECEDANT"].ToString();
					clsCliconsultationantecedant.PA_CODEPATHOLOGIE = clsDonnee.vogDataReader["PA_CODEPATHOLOGIE"].ToString();
					clsCliconsultationantecedant.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationantecedant.AT_DESCRIPTION = clsDonnee.vogDataReader["AT_DESCRIPTION"].ToString();
					clsCliconsultationantecedants.Add(clsCliconsultationantecedant);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationantecedants;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationantecedant </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationantecedant> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationantecedant> clsCliconsultationantecedants = new List<clsCliconsultationantecedant>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE,AT_DATEANTECEDANT, TA_CODETYPEANTECEDANT, PA_CODEPATHOLOGIE, OP_CODEOPERATEUR, AT_DESCRIPTION FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationantecedant clsCliconsultationantecedant = new clsCliconsultationantecedant();
					clsCliconsultationantecedant.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationantecedant.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsCliconsultationantecedant.AT_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["AT_NUMSEQUENCE"].ToString();
					clsCliconsultationantecedant.AT_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATESAISIE"].ToString());
                    clsCliconsultationantecedant.AT_DATEANTECEDANT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEANTECEDANT"].ToString());
                    clsCliconsultationantecedant.TA_CODETYPEANTECEDANT = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEANTECEDANT"].ToString();
					clsCliconsultationantecedant.PA_CODEPATHOLOGIE = Dataset.Tables["TABLE"].Rows[Idx]["PA_CODEPATHOLOGIE"].ToString();
					clsCliconsultationantecedant.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationantecedant.AT_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["AT_DESCRIPTION"].ToString();
					clsCliconsultationantecedants.Add(clsCliconsultationantecedant);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationantecedants;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , PA_CODEPATHOLOGIE FROM dbo.FT_CLICONSULTATIONANTECEDANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TI_IDTIERS, AT_NUMSEQUENCE, AT_DATESAISIE, TA_CODETYPEANTECEDANT, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND AT_NUMSEQUENCE=@AT_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@AT_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND AT_NUMSEQUENCE=@AT_NUMSEQUENCE AND AT_DATESAISIE=@AT_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@AT_NUMSEQUENCE","@AT_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND AT_NUMSEQUENCE=@AT_NUMSEQUENCE AND AT_DATESAISIE=@AT_DATESAISIE AND TA_CODETYPEANTECEDANT=@TA_CODETYPEANTECEDANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@AT_NUMSEQUENCE","@AT_DATESAISIE","@TA_CODETYPEANTECEDANT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND AT_NUMSEQUENCE=@AT_NUMSEQUENCE AND AT_DATESAISIE=@AT_DATESAISIE AND TA_CODETYPEANTECEDANT=@TA_CODETYPEANTECEDANT AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS","@AT_NUMSEQUENCE","@AT_DATESAISIE","@TA_CODETYPEANTECEDANT","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
