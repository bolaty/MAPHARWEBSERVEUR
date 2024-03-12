using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationredactionWSDAL: ITableDAL<clsCliconsultationredaction>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationredaction comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationredaction pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TL_CODETYPEREDACTION  , OP_CODEOPERATEUR  , TI_IDTIERSMEDECINEMETTEURE  , TI_IDTIERSMEDECINDESTINATAIRE  , RE_LIBELLEREDACTION  FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationredaction clsCliconsultationredaction = new clsCliconsultationredaction();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationredaction.TL_CODETYPEREDACTION = clsDonnee.vogDataReader["TL_CODETYPEREDACTION"].ToString();
					clsCliconsultationredaction.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationredaction.TI_IDTIERSMEDECINEMETTEURE = clsDonnee.vogDataReader["TI_IDTIERSMEDECINEMETTEURE"].ToString();
					clsCliconsultationredaction.TI_IDTIERSMEDECINDESTINATAIRE = clsDonnee.vogDataReader["TI_IDTIERSMEDECINDESTINATAIRE"].ToString();
					clsCliconsultationredaction.RE_LIBELLEREDACTION = clsDonnee.vogDataReader["RE_LIBELLEREDACTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationredaction;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationredaction>clsCliconsultationredaction</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationredaction clsCliconsultationredaction)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationredaction.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationredaction.CO_CODECONSULTATION ;
			SqlParameter vppParamRE_NUMSEQUENCE = new SqlParameter("@RE_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRE_NUMSEQUENCE.Value  = clsCliconsultationredaction.RE_NUMSEQUENCE ;
			SqlParameter vppParamRE_DATESAISIE = new SqlParameter("@RE_DATESAISIE", SqlDbType.DateTime);
			vppParamRE_DATESAISIE.Value  = clsCliconsultationredaction.RE_DATESAISIE ;
			SqlParameter vppParamTL_CODETYPEREDACTION = new SqlParameter("@TL_CODETYPEREDACTION", SqlDbType.VarChar, 2);
			vppParamTL_CODETYPEREDACTION.Value  = clsCliconsultationredaction.TL_CODETYPEREDACTION ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationredaction.OP_CODEOPERATEUR ;
			SqlParameter vppParamTI_IDTIERSMEDECINEMETTEURE = new SqlParameter("@TI_IDTIERSMEDECINEMETTEURE", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECINEMETTEURE.Value  = clsCliconsultationredaction.TI_IDTIERSMEDECINEMETTEURE ;
			SqlParameter vppParamTI_IDTIERSMEDECINDESTINATAIRE = new SqlParameter("@TI_IDTIERSMEDECINDESTINATAIRE", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECINDESTINATAIRE.Value  = clsCliconsultationredaction.TI_IDTIERSMEDECINDESTINATAIRE ;
			SqlParameter vppParamRE_LIBELLEREDACTION = new SqlParameter("@RE_LIBELLEREDACTION", SqlDbType.VarChar, 1000);
			vppParamRE_LIBELLEREDACTION.Value  = clsCliconsultationredaction.RE_LIBELLEREDACTION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONREDACTION  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RE_NUMSEQUENCE, @RE_DATESAISIE, @TL_CODETYPEREDACTION, @OP_CODEOPERATEUR, @TI_IDTIERSMEDECINEMETTEURE, @TI_IDTIERSMEDECINDESTINATAIRE, @RE_LIBELLEREDACTION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamRE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTL_CODETYPEREDACTION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECINEMETTEURE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECINDESTINATAIRE);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLEREDACTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationredaction>clsCliconsultationredaction</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationredaction clsCliconsultationredaction,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationredaction.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationredaction.CO_CODECONSULTATION ;
			SqlParameter vppParamRE_NUMSEQUENCE = new SqlParameter("@RE_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRE_NUMSEQUENCE.Value  = clsCliconsultationredaction.RE_NUMSEQUENCE ;
			SqlParameter vppParamRE_DATESAISIE = new SqlParameter("@RE_DATESAISIE", SqlDbType.DateTime);
			vppParamRE_DATESAISIE.Value  = clsCliconsultationredaction.RE_DATESAISIE ;
			SqlParameter vppParamTL_CODETYPEREDACTION = new SqlParameter("@TL_CODETYPEREDACTION", SqlDbType.VarChar, 2);
			vppParamTL_CODETYPEREDACTION.Value  = clsCliconsultationredaction.TL_CODETYPEREDACTION ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationredaction.OP_CODEOPERATEUR ;
			SqlParameter vppParamTI_IDTIERSMEDECINEMETTEURE = new SqlParameter("@TI_IDTIERSMEDECINEMETTEURE", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECINEMETTEURE.Value  = clsCliconsultationredaction.TI_IDTIERSMEDECINEMETTEURE ;
			SqlParameter vppParamTI_IDTIERSMEDECINDESTINATAIRE = new SqlParameter("@TI_IDTIERSMEDECINDESTINATAIRE", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECINDESTINATAIRE.Value  = clsCliconsultationredaction.TI_IDTIERSMEDECINDESTINATAIRE ;
			SqlParameter vppParamRE_LIBELLEREDACTION = new SqlParameter("@RE_LIBELLEREDACTION", SqlDbType.VarChar, 1000);
			vppParamRE_LIBELLEREDACTION.Value  = clsCliconsultationredaction.RE_LIBELLEREDACTION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONREDACTION  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RE_NUMSEQUENCE, @RE_DATESAISIE, @TL_CODETYPEREDACTION, @OP_CODEOPERATEUR, @TI_IDTIERSMEDECINEMETTEURE, @TI_IDTIERSMEDECINDESTINATAIRE, @RE_LIBELLEREDACTION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamRE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTL_CODETYPEREDACTION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECINEMETTEURE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECINDESTINATAIRE);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLEREDACTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONREDACTION  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RE_NUMSEQUENCE, @RE_DATESAISIE, '', '', '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationredaction </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationredaction> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR, TI_IDTIERSMEDECINEMETTEURE, TI_IDTIERSMEDECINDESTINATAIRE, RE_LIBELLEREDACTION FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationredaction> clsCliconsultationredactions = new List<clsCliconsultationredaction>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationredaction clsCliconsultationredaction = new clsCliconsultationredaction();
					clsCliconsultationredaction.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationredaction.CO_CODECONSULTATION = clsDonnee.vogDataReader["CO_CODECONSULTATION"].ToString();
					clsCliconsultationredaction.RE_NUMSEQUENCE = clsDonnee.vogDataReader["RE_NUMSEQUENCE"].ToString();
					clsCliconsultationredaction.RE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RE_DATESAISIE"].ToString());
					clsCliconsultationredaction.TL_CODETYPEREDACTION = clsDonnee.vogDataReader["TL_CODETYPEREDACTION"].ToString();
					clsCliconsultationredaction.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationredaction.TI_IDTIERSMEDECINEMETTEURE = clsDonnee.vogDataReader["TI_IDTIERSMEDECINEMETTEURE"].ToString();
					clsCliconsultationredaction.TI_IDTIERSMEDECINDESTINATAIRE = clsDonnee.vogDataReader["TI_IDTIERSMEDECINDESTINATAIRE"].ToString();
					clsCliconsultationredaction.RE_LIBELLEREDACTION = clsDonnee.vogDataReader["RE_LIBELLEREDACTION"].ToString();
					clsCliconsultationredactions.Add(clsCliconsultationredaction);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationredactions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationredaction </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationredaction> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationredaction> clsCliconsultationredactions = new List<clsCliconsultationredaction>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR, TI_IDTIERSMEDECINEMETTEURE, TI_IDTIERSMEDECINDESTINATAIRE, RE_LIBELLEREDACTION FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationredaction clsCliconsultationredaction = new clsCliconsultationredaction();
					clsCliconsultationredaction.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationredaction.CO_CODECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION"].ToString();
					clsCliconsultationredaction.RE_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["RE_NUMSEQUENCE"].ToString();
					clsCliconsultationredaction.RE_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RE_DATESAISIE"].ToString());
					clsCliconsultationredaction.TL_CODETYPEREDACTION = Dataset.Tables["TABLE"].Rows[Idx]["TL_CODETYPEREDACTION"].ToString();
					clsCliconsultationredaction.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationredaction.TI_IDTIERSMEDECINEMETTEURE = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSMEDECINEMETTEURE"].ToString();
					clsCliconsultationredaction.TI_IDTIERSMEDECINDESTINATAIRE = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSMEDECINDESTINATAIRE"].ToString();
					clsCliconsultationredaction.RE_LIBELLEREDACTION = Dataset.Tables["TABLE"].Rows[Idx]["RE_LIBELLEREDACTION"].ToString();
					clsCliconsultationredactions.Add(clsCliconsultationredaction);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationredactions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , TI_IDTIERSMEDECINEMETTEURE FROM dbo.FT_CLICONSULTATIONREDACTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_CODECONSULTATION, RE_NUMSEQUENCE, RE_DATESAISIE, TL_CODETYPEREDACTION, OP_CODEOPERATEUR)</summary>
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
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RE_NUMSEQUENCE=@RE_NUMSEQUENCE AND RE_DATESAISIE=@RE_DATESAISIE AND TL_CODETYPEREDACTION=@TL_CODETYPEREDACTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RE_NUMSEQUENCE","@RE_DATESAISIE","@TL_CODETYPEREDACTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RE_NUMSEQUENCE=@RE_NUMSEQUENCE AND RE_DATESAISIE=@RE_DATESAISIE AND TL_CODETYPEREDACTION=@TL_CODETYPEREDACTION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RE_NUMSEQUENCE","@RE_DATESAISIE","@TL_CODETYPEREDACTION","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
